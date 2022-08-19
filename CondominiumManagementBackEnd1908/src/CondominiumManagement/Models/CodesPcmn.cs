using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class CodesPcmn
    {

        public int IdCodePcmn { get; set; }
        public int CodePcmn { get; set; }
        public string Libelle { get; set; }
        public int CodeDecompte { get; set; }
        public string Denomination { get; set; }

        //public ICollection<LignesDecomptes> LignesDecomptes { get; set; }
        //public ICollection<LignesDocumentsFournisseurs> LignesDocumentsFournisseurs { get; set; }
    }
}
