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
    /// Logique d'interaction pour MenuChevaux.xaml
    /// </summary>
    public partial class MenuChevaux : Page
    {
        public MainWindow mainWindows;
        public DatabaseManager databaseManager;
        List<ChevauxInfos> listChevaux = new List<ChevauxInfos>();
        public MenuChevaux(DatabaseManager databaseManager, MainWindow mainWindow)
        {
            InitializeComponent();
            this.databaseManager = databaseManager;
            this.mainWindows = mainWindow;
            RefreshList();
        }

        void OnClick(object sender, RoutedEventArgs args)
        {
            Button button = sender as Button;
            String nom = button.Tag.ToString();
            mainWindows.frameClass.infoCheval.LoadInfoCheval(nom);
            mainWindows.frameClass.ChangeFrame(mainWindows.frameClass.infoCheval);
        }

        public void RefreshList()
        {
            listChevaux.Clear();
            var chevaux = databaseManager.SQLiteConnection.Table<Chevaux>();
            foreach (Chevaux cheval in chevaux)
            {
                string url = Environment.CurrentDirectory + "\\Images\\test.jpg";
                if (cheval.photo != "" && cheval.photo != null)
                {
                    url = cheval.photo;
                }
                Console.WriteLine(url);
                ChevauxInfos chevalInfo = new ChevauxInfos
                {
                    Name = cheval.Nom,
                    Url = url

                };
                listChevaux.Add(chevalInfo);
            }
            lvDataBinding.ItemsSource = listChevaux;
        }

    }

    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }
    }
}
