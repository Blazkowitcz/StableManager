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
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainWindow mainWindow;
        public MainMenu(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void HorseButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.frameClass.ChangeFrame(mainWindow.frameClass.menuChevaux);
        }

        private void EcurieButton_Click(object sender, RoutedEventArgs e)
        {
            LockPin lockPin = new LockPin(mainWindow.databaseManager, mainWindow);
            lockPin.Show();
        }
    }
}
