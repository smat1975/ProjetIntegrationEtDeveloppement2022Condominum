using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class Quotites
    {
        public int IdQuotite { get; set; }
        public int IdLot { get; set; }
        public int IdLocalisation { get; set; }
        public int ValeurLot { get; set; }
        public int ValeurLocalisation { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public bool? ActifON { get; set; }
        public string Remarque { get; set; }

        //public Localisations Localisation { get; set; }
        //public Lots Lot { get; set; }
        //public ICollection<LignesDecomptes> LignesDecomptes { get; set; }

    }
}
