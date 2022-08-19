using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Quotites
    {
        public Quotites()
        {
            LignesDecomptes = new HashSet<LignesDecomptes>();
        }

        public int IdQuotite { get; set; }
        public int IdLot { get; set; }
        public int IdLocalisation { get; set; }
        public int ValeurLot { get; set; }
        public int ValeurLocalisation { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public bool? ActifON { get; set; }
        public string Remarque { get; set; }

        public virtual Localisations IdLocalisationNavigation { get; set; }
        public virtual Lots IdLotNavigation { get; set; }
        public virtual ICollection<LignesDecomptes> LignesDecomptes { get; set; }
    }
}
