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
using MahApps.Metro.Controls;
using StableManager.Frames;
using StableManager.Classes;
using SQLite;
using StableManager.Entity;

namespace StableManager
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainMenu menu;
        public MenuChevaux menuChevaux;
        public GestionEcurie gestionEcurie;
        public FrameClass frameClass;
        public DatabaseManager databaseManager;

        public MainWindow()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager();
            Loaded += OnLoaded;
            frameClass = new FrameClass(this, MainFrame, databaseManager);
            frameClass.ChangeFrame(frameClass.mainMenu);
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            WindowState = WindowState.Maximized;
            ResizeMode = ResizeMode.NoResize;
            ShowMaxRestoreButton = false;
            ShowMinButton = false;
            Loaded -= OnLoaded;
        }
    }

}
