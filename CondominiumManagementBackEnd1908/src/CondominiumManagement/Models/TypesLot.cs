using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class TypesLot
    {
        public int IdTypeLot { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public string Remarque { get; set; }

        //public ICollection<Lots> Lots { get; set; }
    }
}
