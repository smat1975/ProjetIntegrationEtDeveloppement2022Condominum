using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class DocumentsFournisseurs
    {
        public DocumentsFournisseurs()
        {
            LignesDocumentsFournisseurs = new HashSet<LignesDocumentsFournisseurs>();
        }

        public int IdDocumentFournisseur { get; set; }
        public int IdTypeDocumentFournisseur { get; set; }
        public int IdFournisseur { get; set; }
        public int? IdPeriode { get; set; }
        public string Description { get; set; }
        public double? MontantTotalTvacdocument { get; set; }
        public int? IdTypeTva { get; set; }
        public double? MontantTva { get; set; }
        public DateTime DateEnregistrement { get; set; }
        public DateTime DateDocument { get; set; }
        public DateTime? DateEcheance { get; set; }
        public string Remarque { get; set; }

        public virtual Fournisseurs IdFournisseurNavigation { get; set; }
        public virtual Periodes IdPeriodeNavigation { get; set; }
        public virtual TypesDocumentFournisseur IdTypeDocumentFournisseurNavigation { get; set; }
        public virtual TypesTva IdTypeTvaNavigation { get; set; }
        public virtual ICollection<LignesDocumentsFournisseurs> LignesDocumentsFournisseurs { get; set; }
    }
}
