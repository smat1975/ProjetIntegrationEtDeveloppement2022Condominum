using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class CodesPcmn
    {
        public CodesPcmn()
        {
            LignesDecomptes = new HashSet<LignesDecomptes>();
            LignesDocumentsFournisseurs = new HashSet<LignesDocumentsFournisseurs>();
        }

        public int IdCodePcmn { get; set; }
        public int CodePcmn { get; set; }
        public string Libelle { get; set; }
        public int CodeDecompte { get; set; }
        public string Denomination { get; set; }

        public virtual ICollection<LignesDecomptes> LignesDecomptes { get; set; }
        public virtual ICollection<LignesDocumentsFournisseurs> LignesDocumentsFournisseurs { get; set; }
    }
}
