using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class TypesTva
    {
        public TypesTva()
        {
            Decomptes = new HashSet<Decomptes>();
            DocumentsFournisseurs = new HashSet<DocumentsFournisseurs>();
            LignesDocumentsFournisseurs = new HashSet<LignesDocumentsFournisseurs>();
        }

        public int IdTypeTva { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public bool? ActifON { get; set; }
        public string Remarque { get; set; }

        public virtual ICollection<Decomptes> Decomptes { get; set; }
        public virtual ICollection<DocumentsFournisseurs> DocumentsFournisseurs { get; set; }
        public virtual ICollection<LignesDocumentsFournisseurs> LignesDocumentsFournisseurs { get; set; }
    }
}
