using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StableManager.Entity
{
    public class Soins
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdCheval { get; set; }
        public string DateSoin { get; set; }
        public string Soin { get; set; }
    }
}
