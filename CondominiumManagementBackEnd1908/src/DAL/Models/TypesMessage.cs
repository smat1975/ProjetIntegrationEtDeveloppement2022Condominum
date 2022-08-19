using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TypesMessage
    {

        public int IdTypeMessage { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public string Remarque { get; set; }

        public ICollection<Messages> Messages { get; set; }
    }
}
