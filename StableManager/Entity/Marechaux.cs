using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StableManager.Entity
{
    public class Marechaux
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Adresse { get; set; }
        public String Telephone { get; set; }
        public String Mail { get; set; }
    }
}
