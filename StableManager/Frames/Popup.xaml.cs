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
    /// Logique d'interaction pour Test.xaml
    /// </summary>
    public partial class Popup : Window
    {
        public Popup()
        {
            InitializeComponent();
        }

        public void LoadInformations(Proprietaires prop)
        {
            Nom.Text = prop.Nom;
            Prenom.Text = prop.Prenom;
            Adresse.Text = prop.Adresse;
            Telephone.Text = prop.Telephone;
            Mail.Text = prop.Mail;
        }

        public void LoadInformations(Marechaux mar)
        {
            Nom.Text = mar.Nom;
            Prenom.Text = mar.Prenom;
            Adresse.Text = mar.Adresse;
            Telephone.Text = mar.Telephone;
            Mail.Text = mar.Mail;
        }

        public void LoadInformations(Veterinaires vet)
        {
            Nom.Text = vet.Nom;
            Prenom.Text = vet.Prenom;
            Adresse.Text = vet.Adresse;
            Telephone.Text = vet.Telephone;
            Mail.Text = vet.Mail;
        }
    }
}
