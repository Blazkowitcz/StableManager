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
    /// <summary>
    /// Logique d'interaction pour InfoCheval.xaml
    /// </summary>
    public partial class InfoCheval : Page
    {
        DatabaseManager databaseManager;
        List<Soins> listSoins = new List<Soins>();
        List<Vermifuges> listVermifuges = new List<Vermifuges>();
        List<Vaccins> listVaccins = new List<Vaccins>();
        List<Fers> listFers = new List<Fers>();
        Chevaux cheval = new Chevaux();
        Proprietaires prop = new Proprietaires();
        Marechaux marechal = new Marechaux();
        Veterinaires veterinaire = new Veterinaires();
        MainWindow mainWindow;
        public InfoCheval(MainWindow mainWindow, DatabaseManager databaseManager)
        {
            this.databaseManager = databaseManager;
            InitializeComponent();
            
            TableSoin.ItemsSource = listSoins;
            TableVaccin.ItemsSource = listVaccins;
            TableVermifuge.ItemsSource = listVermifuges;
            TableFer.ItemsSource = listFers;
            this.mainWindow = mainWindow;
        }

        public void LoadInfoCheval(string name)
        {
            cheval = databaseManager.InformationCheval(name);
            prop = databaseManager.RetrieveProprietaire(cheval.IdProprietaire);
            marechal = databaseManager.RetrieveMarechal(cheval.IdMarechal);
            veterinaire = databaseManager.RetrieveVeterinaire(cheval.IdVeterinaire);
            Nom.Content = cheval.Nom;
            Race.Text = cheval.Race;
            Sire.Text = cheval.Sire;
            Annee.Text = cheval.Annee.ToString();
            Sexe.Text = cheval.Sexe;
            Robe.Text = cheval.Robe;
            Pere.Text = cheval.Pere;
            Mere.Text = cheval.Mere;
            Proprietaire.Text = prop != null ? prop.Nom : "Inconnu";
            Veterinaire.Text = veterinaire != null ? veterinaire.Nom : "Inconnu";
            Marechal.Text =  marechal != null ? marechal.Nom : "Inconnu";
            TreatInformations();
            CheckButton();
        }

        private void CheckButton()
        {
            if (Marechal.Text.Equals("Inconnu")) { buttonMarechal.IsEnabled = false; } else { buttonMarechal.IsEnabled = true; }
            if (Veterinaire.Text.Equals("Inconnu")) { buttonVeterinaire.IsEnabled = false; } else { buttonVeterinaire.IsEnabled = true; }
            if (Proprietaire.Text.Equals("Inconnu")) { buttonProprietaire.IsEnabled = false; } else { buttonProprietaire.IsEnabled = true; }
        }

        public void TreatInformations()
        {
            this.listSoins.Clear();
            this.listFers.Clear();
            this.listVaccins.Clear();
            this.listVermifuges.Clear();

            List<Soins>listSoins = databaseManager.RetrieveSoins(cheval.Id);
            foreach (Soins soin in listSoins)
            {
                this.listSoins.Add(soin);
            }

            List<Fers> listFers = databaseManager.RetrieveFers(cheval.Id);
            foreach (Fers fer in listFers)
            {
                Console.WriteLine(fer.Fer);
                this.listFers.Add(fer);
            }

            List<Vermifuges> listVermifuges = databaseManager.RetrieveVermifuge(cheval.Id);
            foreach (Vermifuges vermifuges in listVermifuges)
            {
                this.listVermifuges.Add(vermifuges);
            }

            List<Vaccins> listVaccins = databaseManager.RetrieveVaccins(cheval.Id);
            foreach (Vaccins vaccins in listVaccins)
            {
                this.listVaccins.Add(vaccins);
            }
            TableVaccin.Items.Refresh();
            TableFer.Items.Refresh();
            TableSoin.Items.Refresh();
            TableVermifuge.Items.Refresh();
        }

        

        private void ClickButtonAddSoin(object sender, RoutedEventArgs e)
        {
            PopupAdd popupAdd = new PopupAdd(databaseManager, cheval.Id, this, "Soin");
            popupAdd.Show();
        }

        private void ClickButtonAddFer(object sender, RoutedEventArgs e)
        {
            PopupAdd popupAdd = new PopupAdd(databaseManager, cheval.Id, this, "Fer");
            popupAdd.Show();
        }

        private void ClickButtonAddVaccin(object sender, RoutedEventArgs e)
        {
            PopupAdd popupAdd = new PopupAdd(databaseManager, cheval.Id, this, "Vaccin");
            popupAdd.Show();
        }

        private void ClickButtonAddVermifuge(object sender, RoutedEventArgs e)
        {
            PopupAdd popupAdd = new PopupAdd(databaseManager, cheval.Id, this, "Vermifuge");
            popupAdd.Show();
        }

        private void ClickButtonProprietaire(object sender, RoutedEventArgs e)
        {
            Popup popup = new Popup();
            popup.Show();
            popup.LoadInformations(prop);
        }

        private void ClickButtonMarechal(object sender, RoutedEventArgs e)
        {
            Popup popup = new Popup();
            popup.Show();
            popup.LoadInformations(marechal);
        }

        private void ClickButtonVeterinaire(object sender, RoutedEventArgs e)
        {
            Popup popup = new Popup();
            popup.Show();
            popup.LoadInformations(veterinaire);
        }
    }
}
