using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class ComptesBque
    {

        public int IdCompteBque { get; set; }
        public string NomBque { get; set; }
        public string NumCompteBque { get; set; }
        public string IdCoproprietaire { get; set; }
        public string Description { get; set; }
        public bool? ActifON { get; set; }
        public string Remarque { get; set; }

        //public Coproprietaires Coproprietaire { get; set; }
        //public ICollection<Paiements> Paiements { get; set; }
    }
}
