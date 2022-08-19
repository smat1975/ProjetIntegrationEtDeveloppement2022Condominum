using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Lots
    {
        public Lots()
        {
            Coproprietes = new HashSet<Coproprietes>();
            Groupements = new HashSet<Groupements>();
            Quotites = new HashSet<Quotites>();
        }

        public int IdLot { get; set; }
        public int IdTypeLot { get; set; }
        public string CodeLot { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int IdLocalisation { get; set; }
        public string Description { get; set; }
        public int NombreM2 { get; set; }
        public string Remarque { get; set; }

        public virtual Localisations IdLocalisationNavigation { get; set; }
        public virtual TypesLot IdTypeLotNavigation { get; set; }
        public virtual ICollection<Coproprietes> Coproprietes { get; set; }
        public virtual ICollection<Groupements> Groupements { get; set; }
        public virtual ICollection<Quotites> Quotites { get; set; }
    }
}
