using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class MatchingsPaiements
    {
        public int IdMatchingPaiement { get; set; }
        public int IdDecompte { get; set; }
        public int IdPaiement { get; set; }
        public double Montant { get; set; }
        public DateTime DateEnregistrement { get; set; }
        public string Remarque { get; set; }

        public virtual Decomptes IdDecompteNavigation { get; set; }
        public virtual Paiements IdPaiementNavigation { get; set; }
    }
}
