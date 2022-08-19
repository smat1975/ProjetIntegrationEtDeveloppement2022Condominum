using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Groupements
    {
        public Groupements()
        {
            Decomptes = new HashSet<Decomptes>();
        }

        public int IdGroupement { get; set; }
        public int IdGroupe { get; set; }
        public int IdLot { get; set; }
        public DateTime? DateDebutGroupement { get; set; }
        public DateTime? DateFinGroupement { get; set; }
        public string Remarque { get; set; }

        public virtual Groupes IdGroupeNavigation { get; set; }
        public virtual Lots IdLotNavigation { get; set; }
        public virtual ICollection<Decomptes> Decomptes { get; set; }
    }
}
