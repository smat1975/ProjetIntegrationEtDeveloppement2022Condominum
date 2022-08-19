using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Localisations
    {
        public Localisations()
        {
            Lots = new HashSet<Lots>();
            Quotites = new HashSet<Quotites>();
        }

        public int IdLocalisation { get; set; }
        public string Adresse { get; set; }
        public string CodeLocalisation { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string Remarque { get; set; }

        public virtual ICollection<Lots> Lots { get; set; }
        public virtual ICollection<Quotites> Quotites { get; set; }
    }
}
