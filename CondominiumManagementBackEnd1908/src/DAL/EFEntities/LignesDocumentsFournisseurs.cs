using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class LignesDocumentsFournisseurs
    {
        public LignesDocumentsFournisseurs()
        {
            LignesDecomptes = new HashSet<LignesDecomptes>();
        }

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

        public virtual CodesPcmn IdCodePcmnNavigation { get; set; }
        public virtual DocumentsFournisseurs IdDocumentFournisseurNavigation { get; set; }
        public virtual TypesTva IdTypeTvaNavigation { get; set; }
        public virtual ICollection<LignesDecomptes> LignesDecomptes { get; set; }
    }
}
