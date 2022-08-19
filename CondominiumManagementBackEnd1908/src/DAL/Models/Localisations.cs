using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Localisations
    {

        public int IdLocalisation { get; set; }
        public string Adresse { get; set; }
        public string CodeLocalisation { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string Remarque { get; set; }

        public ICollection<Lots> Lots { get; set; }
        public ICollection<Quotites> Quotites { get; set; }

    }
}
