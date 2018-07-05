using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using StableManager.Classes;
using StableManager.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour GererChevaux.xaml
    /// </summary>
    public partial class GererChevaux : Page
    {
        List<Chevaux> listChevaux = new List<Chevaux>();
        MainWindow mainWindow;
        DatabaseManager databaseManager;
        public GererChevaux(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            TableChevaux.ItemsSource = listChevaux;
            databaseManager = mainWindow.databaseManager;
            TreatInformations();
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.frameClass.ChangeFrame(mainWindow.frameClass.ajouterCheval);
        }

        public void TreatInformations()
        {
            this.listChevaux.Clear();

            List<Chevaux> listChevaux = databaseManager.SQLiteConnection.Table<Chevaux>().ToList();
            foreach (Chevaux cheval in listChevaux)
            {
                this.listChevaux.Add(cheval);
            }
            TableChevaux.Items.Refresh();
        }

        private void SupprimerCheval(object sender, RoutedEventArgs e)
        {
            Chevaux row = (Chevaux)TableChevaux.SelectedItems[0];
            List<Chevaux> listChevaux = databaseManager.SQLiteConnection.Table<Chevaux>().ToList();
            this.listChevaux.Clear();
            foreach (Chevaux cheval in listChevaux)
            {
                if (cheval.Sire.Equals(row.Sire))
                {
                    databaseManager.SQLiteConnection.Delete(cheval);
                }
                else
                {
                    this.listChevaux.Add(cheval);
                }
            }
            TableChevaux.Items.Refresh();
        }
    }
}
