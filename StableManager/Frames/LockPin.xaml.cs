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
    /// Logique d'interaction pour LockPin.xaml
    /// </summary>
    public partial class LockPin : Window
    {
        private DatabaseManager databaseManager;
        private MainWindow mainWindow;
        bool repeat = false;
        string pin = "";
        public LockPin(DatabaseManager databaseManager, MainWindow mainWindow)
        {
            InitializeComponent();
            this.databaseManager = databaseManager;
            this.mainWindow = mainWindow;
        }

        public void ClickButton(object sender, RoutedEventArgs e)
        {
            if (pin.Length < 4)
            {
                pin += (sender as Button).Content;
                textBox.Text = "";
                foreach (char i in pin)
                {
                    textBox.Text += "*";
                }
            }
        }

        public void CreatePin(object sender, RoutedEventArgs e)
        {
            List<Pin> listPin = databaseManager.SQLiteConnection.Table<Pin>().ToList();
            foreach (Pin pins in listPin)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(pin);
                string encryptPass = Convert.ToBase64String(bytes);
                if (pins.pin.Equals(encryptPass))
                {
                    Close();
                    mainWindow.frameClass.ChangeFrame(mainWindow.frameClass.gestionEcurie);
                }
                else
                {
                    pin = "";
                    label.Content = "Mauvais Pin ! Veuillez retenter";
                }
            }

        }

        private void Pin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        private bool IsValid(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= 5 && i <= 9999;
        }
    }
}
