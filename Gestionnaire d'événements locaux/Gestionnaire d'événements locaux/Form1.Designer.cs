namespace Gestionnaire_d_événements_locaux
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventLogTreeView = new System.Windows.Forms.TreeView();
            this.eventListView = new System.Windows.Forms.ListView();
            this.quitButton = new System.Windows.Forms.Button();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clearfiltersButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.levelComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventLogTreeView
            // 
            this.eventLogTreeView.Location = new System.Drawing.Point(9, 44);
            this.eventLogTreeView.Name = "eventLogTreeView";
            this.eventLogTreeView.Size = new System.Drawing.Size(486, 543);
            this.eventLogTreeView.TabIndex = 0;
            this.eventLogTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.eventLogTreeView_AfterSelect);
            // 
            // eventListView
            // 
            this.eventListView.FullRowSelect = true;
            this.eventListView.HideSelection = false;
            this.eventListView.Location = new System.Drawing.Point(609, 72);
            this.eventListView.Name = "eventListView";
            this.eventListView.Size = new System.Drawing.Size(984, 543);
            this.eventListView.TabIndex = 11;
            this.eventListView.UseCompatibleStateImageBehavior = false;
            this.eventListView.SelectedIndexChanged += new System.EventHandler(this.eventListView_SelectedIndexChanged);
            // 
            // quitButton
            // 
            this.quitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.quitButton.Location = new System.Drawing.Point(745, 624);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(207, 57);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Quitter";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // clearAllButton
            // 
            this.clearAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearAllButton.Location = new System.Drawing.Point(504, 624);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(235, 57);
            this.clearAllButton.TabIndex = 4;
            this.clearAllButton.Text = "Tout supprimer";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.deleteButton.Location = new System.Drawing.Point(289, 624);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(207, 57);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Supprimer";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // filterButton
            // 
            this.filterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.filterButton.Location = new System.Drawing.Point(76, 624);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(207, 57);
            this.filterButton.TabIndex = 4;
            this.filterButton.Text = "Filtrer";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clearfiltersButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.quitButton);
            this.groupBox2.Controls.Add(this.clearAllButton);
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Controls.Add(this.filterButton);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(569, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1030, 768);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Événements";
            // 
            // clearfiltersButton
            // 
            this.clearfiltersButton.Location = new System.Drawing.Point(76, 695);
            this.clearfiltersButton.Name = "clearfiltersButton";
            this.clearfiltersButton.Size = new System.Drawing.Size(207, 59);
            this.clearfiltersButton.TabIndex = 6;
            this.clearfiltersButton.Text = "Effacer Le Filtre";
            this.clearfiltersButton.UseVisualStyleBackColor = true;
            this.clearfiltersButton.Click += new System.EventHandler(this.clearfiltersButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.levelComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.categoryTextBox);
            this.groupBox1.Controls.Add(this.eventLogTreeView);
            this.groupBox1.Controls.Add(this.endDatePicker);
            this.groupBox1.Controls.Add(this.sourceTextBox);
            this.groupBox1.Controls.Add(this.startDatePicker);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(8, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 768);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Journaux d\'événements";
            // 
            // levelComboBox
            // 
            this.levelComboBox.FormattingEnabled = true;
            this.levelComboBox.Location = new System.Drawing.Point(41, 624);
            this.levelComboBox.Name = "levelComboBox";
            this.levelComboBox.Size = new System.Drawing.Size(121, 37);
            this.levelComboBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 695);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 695);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Start Date";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(336, 624);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(116, 35);
            this.categoryTextBox.TabIndex = 5;
            this.categoryTextBox.Text = "Category";
            this.categoryTextBox.Enter += new System.EventHandler(this.categoryTextBox_Enter);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(267, 727);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(244, 35);
            this.endDatePicker.TabIndex = 8;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(190, 624);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(116, 35);
            this.sourceTextBox.TabIndex = 6;
            this.sourceTextBox.Text = "Source";
            this.sourceTextBox.Enter += new System.EventHandler(this.sourceTextBox_Enter);
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(4, 727);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(257, 35);
            this.startDatePicker.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1606, 919);
            this.Controls.Add(this.eventListView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Gestionnaire D’événement Locaux";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView eventLogTreeView;
        private System.Windows.Forms.ListView eventListView;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox levelComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Button clearfiltersButton;
    }
}

