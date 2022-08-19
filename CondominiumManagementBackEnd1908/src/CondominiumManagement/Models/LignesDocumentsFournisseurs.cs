using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class LignesDocumentsFournisseurs
    {

        public int IdLigneDocumentFournisseur { get; set; }
        public int IdDocumentFournisseur { get; set; }
        public int? IdCodePcmn { get; set; }
        public string Description { get; set; }
        public DateTime? DateDebutLigne { get; set; }
        public DateTime? DateFinLigne { get; set; }
        public int? NbreJoursLigne { get; set; }
        public double? MontantTotalTvacligne { get; set; }
        public int? IdTypeTva { get; set; }
        public double? MontantTvaligne { get; set; }
        public string Remarque { get; set; }

        //public CodesPcmn CodePcmn { get; set; }
        //public DocumentsFournisseurs DocumentFournisseur { get; set; }
        //public TypesTva TypeTva { get; set; }
        //public ICollection<LignesDecomptes> LignesDecomptes { get; set; }

    }
}
