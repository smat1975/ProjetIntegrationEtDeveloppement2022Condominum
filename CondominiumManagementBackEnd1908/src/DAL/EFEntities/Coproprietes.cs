using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Coproprietes
    {
        public int IdCopropriete { get; set; }
        public string IdCoproprietaire { get; set; }
        public int IdLot { get; set; }
        public string NumContrat { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string Remarque { get; set; }

        public virtual Coproprietaires IdCoproprietaireNavigation { get; set; }
        public virtual Lots IdLotNavigation { get; set; }
    }
}
