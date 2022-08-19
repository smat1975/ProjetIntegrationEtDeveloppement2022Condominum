using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class ComptesBque
    {
        public ComptesBque()
        {
            Paiements = new HashSet<Paiements>();
        }

        public int IdCompteBque { get; set; }
        public string NomBque { get; set; }
        public string NumCompteBque { get; set; }
        public string IdCoproprietaire { get; set; }
        public string Description { get; set; }
        public bool? ActifON { get; set; }
        public string Remarque { get; set; }

        public virtual Coproprietaires IdCoproprietaireNavigation { get; set; }
        public virtual ICollection<Paiements> Paiements { get; set; }
    }
}
