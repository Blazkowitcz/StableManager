using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StableManager.Entity
{
    public class Vermifuges
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdCheval { get; set; }
        public string DateVermifuge { get; set; }
        public string Vermifuge { get; set; }
    }
}
