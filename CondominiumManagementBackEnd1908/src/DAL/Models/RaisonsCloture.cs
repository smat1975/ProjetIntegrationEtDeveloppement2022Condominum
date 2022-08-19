using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class RaisonsCloture
    {
        public int IdRaisonCloture { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public string Remarque { get; set; }

        public ICollection<Coproprietaires> Coproprietaires { get; set; }
    }
}
