using Microsoft.Win32;
using StableManager.Classes;
using StableManager.Entity;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour AjouterCheval.xaml
    /// </summary>
    public partial class AjouterCheval : Page
    {
        MainWindow mainWindow;
        DatabaseManager databaseManager;
        List<Proprietaires> proprietaire;
        List<Marechaux> marechal;
        List<Veterinaires> veterinaire;
        public AjouterCheval(MainWindow mainWindow, DatabaseManager databaseManager)
        {
            InitializeComponent();
            this.databaseManager = databaseManager;
            this.mainWindow = mainWindow;
            proprietaire = databaseManager.RetrieveListProprietaire();
            marechal = databaseManager.RetrieveListMarechal();
            veterinaire = databaseManager.RetrieveListVeterinaire();
            Proprietaire.DisplayMemberPath = "Key";
            Proprietaire.SelectedValuePath = "Value";
            Marechal.DisplayMemberPath = "Key";
            Marechal.SelectedValuePath = "Value";
            Veterinaire.DisplayMemberPath = "Key";
            Veterinaire.SelectedValuePath = "Value";
            foreach (Proprietaires prop in proprietaire){ Proprietaire.Items.Add(new KeyValuePair<string, int>(prop.Nom, prop.Id));}
            foreach (Marechaux prop in marechal) { Marechal.Items.Add(new KeyValuePair<string, int>(prop.Nom, prop.Id)); }
            foreach (Veterinaires prop in veterinaire) { Veterinaire.Items.Add(new KeyValuePair<string, int>(prop.Nom, prop.Id)); }
        }

        string img = "";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Chevaux cheval = new Chevaux
            {
                Nom = Nom.Text,
                Race = Race.Text,
                Sire = Sire.Text,
                Annee = int.Parse(Annee.Text),
                Sexe = Sexe.Text,
                Robe = Robe.Text,
                Pere = Pere.Text,
                Mere = Mere.Text,
                photo = GetImage(),
                IdProprietaire = ProprietaireId(Proprietaire.Text)
            };
            mainWindow.databaseManager.AddCheval(cheval);
            mainWindow.frameClass.gererChevaux.TreatInformations();
            mainWindow.frameClass.menuChevaux.RefreshList();
            mainWindow.frameClass.ChangeFrame(mainWindow.frameClass.gererChevaux);
        }

        private string GetImage()
        {
            if(img != "")
            {
                string name = System.IO.Path.GetFileName(img);
                string image = Environment.CurrentDirectory + "\\Images\\" + name;
                File.Copy(img, image);
                return image;
            }
            else
            {
                return "";
            }
        }

        private int ProprietaireId(string name)
        {
            List<Proprietaires> proprietaire = databaseManager.SQLiteConnection.Table<Proprietaires>().Where(Proprietaires => Proprietaires.Nom == name).ToList();
            foreach (Proprietaires prop in proprietaire)
            {
                return prop.Id;
            }
            return -1;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                img = openFileDialog.FileName;
            }
        }
    }
}
