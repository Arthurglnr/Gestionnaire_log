#Gestionnaire d'Événements Locaux

Une application de gestion des événements système développée avec Visual Studio 2022. Cette application permet de visualiser, filtrer, et gérer les journaux d'événements de votre ordinateur.
Fonctionnalités

    Liste des journaux d'événements : Affiche les différentes catégories de journaux disponibles sur votre système (ex : Application, Sécurité, Système, etc.).
    Affichage des événements : Affiche les logs dans la catégorie sélectionnée, avec des informations telles que le niveau, la date, la source, et la catégorie.
    Filtrage : Permet de filtrer les événements affichés en fonction de critères spécifiques saisis par l'utilisateur.
    Suppression d'un événement : Supprime l'événement sélectionné de la liste affichée.
    Suppression de tous les événements : Supprime tous les événements de la catégorie sélectionnée.
    Quitter : Ferme l'application.

#Prérequis

    Visual Studio 2022
    .NET Framework (version appropriée pour exécuter l'application, vérifiez la configuration du projet dans Visual Studio)

#Installation

    Clonez ce dépôt :

    git clone https://github.com/votre-utilisateur/nom-du-repo.git

    Ouvrez le projet dans Visual Studio 2022.

    Compilez et lancez l'application.

#Utilisation

    Lancez l'application en mode administrateur.
    ⚠️ Important : L'application doit être exécutée en tant qu'administrateur pour pouvoir lire et modifier les logs. Assurez-vous de cliquer sur "Exécuter en tant qu'administrateur" lorsque vous démarrez l'application.

    Sélectionnez une catégorie de journaux dans la liste de gauche pour afficher les événements correspondants.

    Utilisez les boutons disponibles :
        Filtrer : Entrez des critères dans le champ de filtre et cliquez sur "Filtrer" pour afficher les événements correspondant aux critères spécifiés.
        Supprimer : Sélectionnez un événement dans la liste et cliquez sur "Supprimer" pour le retirer.
        Tout supprimer : Supprime tous les événements de la catégorie sélectionnée.
        Quitter : Ferme l'application.

#Aperçu

#Avertissement

L'application manipule les journaux d'événements locaux. La suppression d'événements peut affecter la traçabilité et le diagnostic de votre système. Utilisez cette fonctionnalité avec précaution.
