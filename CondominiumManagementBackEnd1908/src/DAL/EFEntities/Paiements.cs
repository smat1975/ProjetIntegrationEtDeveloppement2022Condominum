using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Paiements
    {
        public Paiements()
        {
            MatchingsPaiements = new HashSet<MatchingsPaiements>();
        }

        public int IdPaiement { get; set; }
        public int IdCompteBquePayeur { get; set; }
        public string NomPayeurAutre { get; set; }
        public string Communication { get; set; }
        public double Montant { get; set; }
        public DateTime DateEnregistrement { get; set; }
        public DateTime DateDocument { get; set; }
        public string NumDocument { get; set; }
        public string Remarque { get; set; }

        public virtual ComptesBque IdCompteBquePayeurNavigation { get; set; }
        public virtual ICollection<MatchingsPaiements> MatchingsPaiements { get; set; }
    }
}
