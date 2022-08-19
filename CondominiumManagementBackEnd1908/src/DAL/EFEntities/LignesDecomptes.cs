using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class LignesDecomptes
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

        public virtual CodesPcmn IdCodePcmnNavigation { get; set; }
        public virtual Decomptes IdDecompteNavigation { get; set; }
        public virtual LignesDocumentsFournisseurs IdLigneDocumentFournisseurNavigation { get; set; }
        public virtual Quotites IdQuotiteNavigation { get; set; }
    }
}
