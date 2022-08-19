using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Photos
    {
        public int IdPhoto { get; set; }
        public int IdAnnexe { get; set; }
        public string Ressource { get; set; }

        public virtual Annexes IdAnnexeNavigation { get; set; }
    }
}
