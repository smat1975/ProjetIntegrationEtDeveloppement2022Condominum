using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Periodes
    {
        public int IdPeriode { get; set; }
        public string Denomination { get; set; }
        public int Annee { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string Remarque { get; set; }

        public ICollection<Decomptes> Decomptes { get; set; }
        public ICollection<DocumentsFournisseurs> DocumentsFournisseurs { get; set; }

    }
}
