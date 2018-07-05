using StableManager.Classes;
using StableManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StableManager.Frames
{
    public partial class InfoProprietaire : Page
    {
        DatabaseManager databaseManager;
        MainWindow mainWindow;
        Proprietaires proprietaire;
        public InfoProprietaire(MainWindow mainWindow, DatabaseManager databaseManager)
        {
            this.databaseManager = databaseManager;
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public void LoadInfoProprietaire(string name)
        {
            //proprietaire = databaseManager.InformationProprietaire(name);
            //Nom.Text = proprietaire.Nom;
            //Prenom.Text = proprietaire.Prenom;
            //Adresse.Text = proprietaire.Adresse;
            //Telephone.Text = proprietaire.Telephone;
            //Mail.Text = proprietaire.Mail;
        }
    }
}
