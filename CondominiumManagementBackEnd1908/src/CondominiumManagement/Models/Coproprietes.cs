using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class Coproprietes
    {
        public int IdCopropriete { get; set; }
        public string IdCoproprietaire { get; set; }
        public int IdLot { get; set; }
        public string NumContrat { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string Remarque { get; set; }

        //public Coproprietaires Coproprietaire { get; set; }
        //public Lots Lot { get; set; }

    }
}
