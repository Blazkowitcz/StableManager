using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace StableManager.Entity
{
    public class Chevaux
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Race { get; set; }
        public String Sire { get; set; }
        public int Annee { get; set; }
        public String Sexe { get; set; }
        public String Robe { get; set; }
        public String Pere { get; set; }
        public String Mere { get; set; }
        public int ListeSport { get; set; }
        public int IdProprietaire { get; set; }
        public int IdVeterinaire { get; set; }
        public int IdMarechal { get; set; }
        public String DateVaccin { get; set; }
        public String DateFer { get; set; }
        public String ProchainVaccin { get; set; }
        public String ProchainFer { get; set; }
        public String TypeFer { get; set; }
        public String photo { get; set; }
    }
}
