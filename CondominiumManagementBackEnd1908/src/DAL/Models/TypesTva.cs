using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TypesTva
    {

        public int IdTypeTva { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public bool? ActifON { get; set; }
        public string Remarque { get; set; }

        public ICollection<Decomptes> Decomptes { get; set; }
        public ICollection<DocumentsFournisseurs> DocumentsFournisseurs { get; set; }
        public ICollection<LignesDocumentsFournisseurs> LignesDocumentsFournisseurs { get; set; }
    }
}
