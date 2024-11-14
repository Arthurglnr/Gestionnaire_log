using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestionnaire_d_événements_locaux
{
    public partial class Form1 : Form
    {
        private string logName = "Application";
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (!IsAdministrator())
            {
                MessageBox.Show("Please run the application as an administrator to manage event logs.", "Permissions Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }

            await LoadEventLogsAsync();

            
            eventListView.Columns.Add("Level", 100);
            eventListView.Columns.Add("Date and Time", 150);
            eventListView.Columns.Add("Source", 150);
            eventListView.Columns.Add("Category", 100);
            eventListView.View = View.Details;

            levelComboBox.Items.AddRange(Enum.GetNames(typeof(EventLogEntryType)));
        }

        private async Task LoadEventLogsAsync()
        {
            eventLogTreeView.Nodes.Clear();

            await Task.Run(() =>
            {
                foreach (var logName in EventLog.GetEventLogs().Select(log => log.Log))
                {
                    Invoke(new Action(() =>
                    {
                        eventLogTreeView.Nodes.Add(logName);
                    }));
                }
            });
        }

        private bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void categoryTextBox_Enter(object sender, EventArgs e)
        {
            if (categoryTextBox.Text == "Category")
            {
                categoryTextBox.Text = "";
            }
        }

        private void sourceTextBox_Enter(object sender, EventArgs e)
        {
            if (sourceTextBox.Text == "Source")
            {
                sourceTextBox.Text = "";
            }
        }

        private void levelTextBox_Enter(object sender, EventArgs e)
        {
           
        }

        private async void eventLogTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
           if (e.Node != null)
            {
                label3.Text = $"{e.Node.Text}";
                await LoadEventsAsync(e.Node.Text);
            }
        }

        private async Task LoadEventsAsync(string logName)
        {
            eventListView.Items.Clear(); // Clear previous items

            if (IsHandleCreated && !IsDisposed)
            {
                MessageBox.Show("Please wait while loading all the logs...", "Loading Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                await Task.Run(() =>
                {
                    if (_cancellationTokenSource.Token.IsCancellationRequested)
                        return;

                    EventLog log = new EventLog(logName);
                    var entries = log.Entries.Cast<EventLogEntry>().ToList();

                    if (entries.Count == 0)
                    {
                        Invoke(new Action(() =>
                        {
                            if (!IsDisposed) 
                            {
                                MessageBox.Show($"No logs available for the selected event: {logName}", "No Logs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }));
                        return;
                    }

                    foreach (EventLogEntry entry in entries)
                    {
                        if (_cancellationTokenSource.Token.IsCancellationRequested)
                        {
                             Invoke(new Action(() =>
                            {
                                if (!IsDisposed) 
                                {
                                    MessageBox.Show("The operation was canceled.", "Operation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }));
                            return; 
                        }

                        var item = new ListViewItem(new[]
                        {
                    entry.EntryType.ToString(),
                    entry.TimeGenerated.ToString(),
                    entry.Source,
                    entry.Category.ToString()
                })
                        {
                            Tag = entry.Index 
                        };

                        Invoke(new Action(() =>
                        {
                            if (!IsDisposed) 
                            {
                                eventListView.Items.Add(item);
                            }
                        }));
                    }
                }, _cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading events for {logName}: {ex.Message}");
            }
        }

        private async void filterButton_Click(object sender, EventArgs e)
        {
            if (eventLogTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select an event log to filter.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string level = levelComboBox.Text;
            string source = sourceTextBox.Text;
            string category = categoryTextBox.Text;
            DateTime? startDate = startDatePicker.Checked ? startDatePicker.Value : (DateTime?)null;
            DateTime? endDate = endDatePicker.Checked ? endDatePicker.Value : (DateTime?)null;

          
            if (startDate.HasValue && endDate.HasValue && startDate > endDate)
            {
                MessageBox.Show("Start date cannot be greater than end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            eventListView.Items.Clear();

            try
            {
                var logName = eventLogTreeView.SelectedNode.Text;

                await Task.Run(() =>
                {
                    EventLog log = new EventLog(logName);
                    var filteredEntries = log.Entries.Cast<EventLogEntry>().Where(entry =>
                        (string.IsNullOrEmpty(level) || entry.EntryType.ToString().Equals(level, StringComparison.OrdinalIgnoreCase)) &&
                        (string.IsNullOrEmpty(source) || entry.Source.IndexOf(source, StringComparison.OrdinalIgnoreCase) >= 0) &&
                        (string.IsNullOrEmpty(category) || entry.Category.ToString().IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0) &&
                        (!startDate.HasValue || entry.TimeGenerated >= startDate) &&
                        (!endDate.HasValue || entry.TimeGenerated <= endDate)).ToList();

                    Invoke(new Action(() =>
                    {
                        if (filteredEntries.Count == 0)
                        {
                            MessageBox.Show("No logs found for the specified filters.", "No Logs Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            foreach (EventLogEntry entry in filteredEntries)
                            {
                                var item = new ListViewItem(new[]
                                {
                            entry.EntryType.ToString(),
                            entry.TimeGenerated.ToString(),
                            entry.Source,
                            entry.Category.ToString()
                        })
                                {
                                    Tag = entry.Index 
                                };

                                eventListView.Items.Add(item);
                            }
                        }
                    }));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering events: {ex.Message}");
            }
        }


        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (eventListView.SelectedItems.Count > 0)
            {
               int selectedIndex = (int)eventListView.SelectedItems[0].Tag;
                await DeleteSelectedEventLogEntry(selectedIndex);
            }
            else
            {
                MessageBox.Show("Please select an event log entry to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task DeleteSelectedEventLogEntry(int index)
        {
            if (eventLogTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select an event log entry to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string logName = eventLogTreeView.SelectedNode.Text;

            if (IsHandleCreated && !IsDisposed)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Deleting... Please wait.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }

            await Task.Run(() =>
            {
                try
                {
                    EventLog log = new EventLog(logName);
                    var entries = log.Entries.Cast<EventLogEntry>().ToList();
                    var entryToDelete = entries.FirstOrDefault(entry => entry.Index == index);

                    if (entryToDelete != null)
                    {
                        var remainingEntries = entries.Where(entry => entry.Index != index).ToList();

                        log.Clear();

                        foreach (var entry in remainingEntries)
                        {
                            _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                            try
                            {
                                LogEvent(logName, entry);
                            }
                            catch (Exception ex)
                            {
                                if (IsHandleCreated && !IsDisposed)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        MessageBox.Show($"Error logging entry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }));
                                }
                            }
                        }

                        if (IsHandleCreated && !IsDisposed)
                        {
                            Invoke(new Action(() =>
                            {
                                LoadEventsAsync(logName);
                                MessageBox.Show("Selected log entry deleted successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }));
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                }
                catch (ArgumentException ex)
                {
                    if (IsHandleCreated && !IsDisposed)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    if (IsHandleCreated && !IsDisposed)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
            }, _cancellationTokenSource.Token);
        }


        private void LogEvent(string logName, EventLogEntry entry)
        {
            EventLogEntryType entryType = entry.EntryType;
            string message = entry.Message;

           int eventId = (int)(entry.InstanceId % 65536);

            EventLog.WriteEntry(logName, message, entryType, eventId, (short)entry.CategoryNumber);
        }

        private async void clearAllButton_Click(object sender, EventArgs e)
        {
            if (eventLogTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select an event log to clear.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string logName = eventLogTreeView.SelectedNode.Text;
            EventLog log = new EventLog(logName);
            try
            {
                await Task.Run(() =>
                {
                    log.Clear();
                    Invoke(new Action(async () =>
                    {
                        await LoadEventsAsync(logName); 
                        MessageBox.Show($"All log entries for {logName} have been cleared.", "Clear Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing events for {logName}: {ex.Message}");
            }
        }

        private async void quitButton_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();

            await Task.Delay(500);

            Application.Exit();
        }

        private void eventListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void clearfiltersButton_Click(object sender, EventArgs e)
        {
          
                levelComboBox.SelectedIndex = -1; 
                sourceTextBox.Text = "Source"; 
                categoryTextBox.Text = "Category"; 
                startDatePicker.Checked = false; 
                endDatePicker.Checked = false; 

                
                if (eventLogTreeView.SelectedNode != null)
                {
                    string logName = eventLogTreeView.SelectedNode.Text;
                    LoadEventsAsync(logName); 
                }
                else
                {
                    MessageBox.Show("Please select an event log to reload.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
    
}
