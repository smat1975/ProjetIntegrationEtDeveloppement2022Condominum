using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class Paiements
    {
        public int IdPaiement { get; set; }
        public int IdCompteBquePayeur { get; set; }
        public string NomPayeurAutre { get; set; }
        public string Communication { get; set; }
        public double Montant { get; set; }
        public DateTime DateEnregistrement { get; set; }
        public DateTime DateDocument { get; set; }
        public string NumDocument { get; set; }
        public string Remarque { get; set; }

        //public ComptesBque CompteBquePayeur { get; set; }
        //public ICollection<MatchingsPaiements> MatchingsPaiements { get; set; }
    }
}
