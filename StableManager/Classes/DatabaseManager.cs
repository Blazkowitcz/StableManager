using SQLite;
using StableManager.Entity;
using StableManager.Frames;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StableManager.Classes
{
    public class DatabaseManager
    {
        public SQLiteConnection SQLiteConnection;
        public DatabaseManager()
        {
            if (!File.Exists("database.db"))
            {
                CreateLockPin createLockPin = new CreateLockPin(this);
                createLockPin.Show();
                SQLiteConnection = new SQLiteConnection("database.db");
                SQLiteConnection.CreateTable<Chevaux>();
                SQLiteConnection.CreateTable<Proprietaires>();
                SQLiteConnection.CreateTable<Soins>();
                SQLiteConnection.CreateTable<Veterinaires>();
                SQLiteConnection.CreateTable<Marechaux>();
                SQLiteConnection.CreateTable<Vermifuges>();
                SQLiteConnection.CreateTable<Vaccins>();
                SQLiteConnection.CreateTable<Fers>();
                SQLiteConnection.CreateTable<Pin>();
            }
            else
            {
                SQLiteConnection = new SQLiteConnection("database.db");
            }
            
        }

        public void AddCheval(Chevaux cheval)
        {
            SQLiteConnection.Insert(cheval);
        }

        public Chevaux InformationCheval(string name)
        {
            List<Chevaux> listChevaux = SQLiteConnection.Table<Chevaux>().ToList();
            foreach(Chevaux cheval in listChevaux)
            {
                if (cheval.Nom.Equals(name))
                {
                    return cheval;
                }
            }
            return null;
        }

        public Proprietaires InformationProprietaire(string name)
        {
            List<Proprietaires> listProprio = SQLiteConnection.Table<Proprietaires>().ToList();
            foreach (Proprietaires prop in listProprio)
            {
                if (prop.Nom.Equals(name))
                {
                    return prop;
                }
            }
            return null;
        }

        public Proprietaires RetrieveProprietaire(int id)
        {
            List<Proprietaires> proprietaire = SQLiteConnection.Table<Proprietaires>().Where(Proprietaires => Proprietaires.Id == id).ToList();
            foreach(Proprietaires prop in proprietaire)
            {
                return prop;
            }
            return null;
        }

        public List<Proprietaires> RetrieveListProprietaire()
        {
            List<Proprietaires> proprietaire = SQLiteConnection.Table<Proprietaires>().ToList();
            return proprietaire;
        }

        public Veterinaires RetrieveVeterinaire(int id)
        {
            List<Veterinaires> proprietaire = SQLiteConnection.Table<Veterinaires>().Where(Veterinaire => Veterinaire.Id == id).ToList();
            foreach (Veterinaires prop in proprietaire)
            {
                return prop;
            }
            return null;
        }

        public List<Veterinaires> RetrieveListVeterinaire()
        {
            List<Veterinaires> veterinare = SQLiteConnection.Table<Veterinaires>().ToList();
            return veterinare;
        }

        public Marechaux RetrieveMarechal(int id)
        {
            List<Marechaux> proprietaire = SQLiteConnection.Table<Marechaux>().Where(Marechal => Marechal.Id == id).ToList();
            foreach (Marechaux prop in proprietaire)
            {
                return prop;
            }
            return null;
        }

        public List<Marechaux> RetrieveListMarechal()
        {
            List<Marechaux> marechal = SQLiteConnection.Table<Marechaux>().ToList();
            return marechal;
        }

        public List<Soins> RetrieveSoins(int id)
        {
            List<Soins> soins = SQLiteConnection.Table<Soins>().Where(Soins => Soins.IdCheval == id).ToList();
            return soins;
        }

        public List<Fers> RetrieveFers(int id)
        {
            List<Fers> fers = SQLiteConnection.Table<Fers>().Where(Fers => Fers.IdCheval == id).ToList();
            return fers;
        }

        public List<Vermifuges> RetrieveVermifuge(int id)
        {
            List<Vermifuges> vermifuges = SQLiteConnection.Table<Vermifuges>().Where(Vermifuges => Vermifuges.IdCheval == id).ToList();
            return vermifuges;
        }

        public List<Vaccins> RetrieveVaccins(int id)
        {
            List<Vaccins> vaccins = SQLiteConnection.Table<Vaccins>().Where(Vaccins => Vaccins.IdCheval == id).ToList();
            return vaccins;
        }
    }
}
