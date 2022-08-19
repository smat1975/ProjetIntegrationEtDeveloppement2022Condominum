using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class LignesDecomptes
    {
        public int IdLigneDecompte { get; set; }
        public int IdDecompte { get; set; }
        public int? IdCodePcmn { get; set; }
        public string Description { get; set; }
        public int IdLigneDocumentFournisseur { get; set; }
        public int? IdQuotite { get; set; }
        public DateTime? DateDebutLigne { get; set; }
        public DateTime? DateFinLigne { get; set; }
        public int? NbreJoursLigne { get; set; }
        public double? MontantTotalTvacligne { get; set; }
        public double? MontantTvaligne { get; set; }
        public string Remarque { get; set; }

        //public CodesPcmn CodePcmn { get; set; }
        //public Decomptes Decompte { get; set; }
        //public LignesDocumentsFournisseurs LigneDocumentFournisseur { get; set; }
        //public Quotites Quotite { get; set; }

        //Calculer montant total TVAC ligne
        //Calculer montant total TVA


    }
}
