using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Annexes
    {
        public Annexes()
        {
            Photos = new HashSet<Photos>();
        }

        public int IdAnnexe { get; set; }
        public int IdMessage { get; set; }
        public string Remarque { get; set; }

        public virtual Messages IdMessageNavigation { get; set; }
        public virtual ICollection<Photos> Photos { get; set; }

        //----
        //public int AnnexeIdPhoto { get; set; }
        //public string AnnexePhotoRessource { get; set; }
    }
}
