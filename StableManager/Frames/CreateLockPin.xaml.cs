using StableManager.Classes;
using StableManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CreateLockPin.xaml
    /// </summary>
    public partial class CreateLockPin : Window
    {
        private DatabaseManager databaseManager;
        bool repeat = false;
        string pin = "";
        string repeatPin = "";
        public CreateLockPin(DatabaseManager databaseManager)
        {
            InitializeComponent();
            this.databaseManager = databaseManager;
        }

        public void ClickButton (object sender, RoutedEventArgs e)
        {
            if (!repeat)
            {
                if(pin.Length < 4)
                {
                    pin += (sender as Button).Content;
                    textBox.Text = "";
                    foreach(char i in pin)
                    {
                        textBox.Text += "*";
                    }
                }
            }
            else
            {
                if (repeatPin.Length < 4)
                {
                    repeatPin += (sender as Button).Content;
                    textBox.Text = "";
                    foreach (char i in repeatPin)
                    {
                        textBox.Text += "*";
                    }
                }
            }
        }

        public void CreatePin(object sender, RoutedEventArgs e)
        {
            if (!repeat)
            {
                textBox.Text = "";
                label.Content = "Veuillez répéter le code";
                repeat = true;
            }
            else
            {
                if (pin.Equals(repeatPin))
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(pin);
                    string encryptPass = Convert.ToBase64String(bytes);
                    Pin pins = new Pin();
                    pins.pin = encryptPass;
                    databaseManager.SQLiteConnection.Insert(pins);
                }
                else
                {
                    repeat = false;
                    pin = "";
                    repeatPin = "";
                    label.Content = "Erreur : Veuillez entrer un code";
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
