using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Civilites
    {

        public int IdCivilite { get; set; }
        public string Denomination { get; set; }
        public string Remarque { get; set; }

        public ICollection<Coproprietaires> Coproprietaires { get; set; }
    }
}
