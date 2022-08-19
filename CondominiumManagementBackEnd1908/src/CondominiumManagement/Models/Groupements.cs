using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class Groupements
    {
        public int IdGroupement { get; set; }
        public int IdGroupe { get; set; }
        public int IdLot { get; set; }
        public DateTime? DateDebutGroupement { get; set; }
        public DateTime? DateFinGroupement { get; set; }
        public string Remarque { get; set; }

        //public Groupes Groupe { get; set; }
        //public Lots Lot { get; set; }
        //public ICollection<Decomptes> Decomptes { get; set; }

        //Affecter un/plusieurs lot(s) à un groupe

    }
}
