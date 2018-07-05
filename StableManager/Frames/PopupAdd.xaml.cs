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
using System.Windows.Shapes;

namespace StableManager.Frames
{
    /// <summary>
    /// Interaction logic for PopupAdd.xaml
    /// </summary>
    public partial class PopupAdd : Window
    {
        DatabaseManager databaseManager;
        int idCheval;
        InfoCheval infoCheval;
        public PopupAdd(DatabaseManager databaseManager, int idCheval, InfoCheval infoCheval, string type)
        {
            InitializeComponent();
            this.databaseManager = databaseManager;
            this.idCheval = idCheval;
            this.infoCheval = infoCheval;
            Type.Text = type;
        }

        private void ClickButtonValidate(object sender, RoutedEventArgs e)
        {
            object obj;
            switch (Type.Text)
            {
                case "Soin":
                    Soins soin = new Soins();
                    soin.IdCheval = idCheval;
                    soin.Soin = Commentaire.Text;
                    soin.DateSoin = DateTime.Now.ToString("dd/MM/yyyy");
                    obj = soin;
                    databaseManager.SQLiteConnection.Insert(obj);
                    infoCheval.TreatInformations();
                    Close();
                    break;
                case "Fer":
                    Fers fers = new Fers();
                    fers.IdCheval = idCheval;
                    fers.Fer = Commentaire.Text;
                    fers.DateFer = DateTime.Now.ToString("dd/MM/yyyy");
                    obj = fers;
                    databaseManager.SQLiteConnection.Insert(obj);
                    infoCheval.TreatInformations();
                    Close();
                    break;
                case "Vaccin":
                    Vaccins vaccins = new Vaccins();
                    vaccins.IdCheval = idCheval;
                    vaccins.Vaccin = Commentaire.Text;
                    vaccins.DateVaccin = DateTime.Now.ToString("dd/MM/yyyy");
                    obj = vaccins;
                    databaseManager.SQLiteConnection.Insert(obj);
                    infoCheval.TreatInformations();
                    Close();
                    break;
                case "Vermifuge":
                    Vermifuges vermifuge = new Vermifuges();
                    vermifuge.IdCheval = idCheval;
                    vermifuge.Vermifuge = Commentaire.Text;
                    vermifuge.DateVermifuge = DateTime.Now.ToString("dd/MM/yyyy");
                    obj = vermifuge;
                    databaseManager.SQLiteConnection.Insert(obj);
                    infoCheval.TreatInformations();
                    Close();
                    break;

            }
        }

        private void ClickButtonCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
}
