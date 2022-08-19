using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class TypesDocumentFournisseur
    {
        public int IdTypeDocumentFournisseur { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public string Remarque { get; set; }

        //public ICollection<DocumentsFournisseurs> DocumentsFournisseurs { get; set; }
    }
}
