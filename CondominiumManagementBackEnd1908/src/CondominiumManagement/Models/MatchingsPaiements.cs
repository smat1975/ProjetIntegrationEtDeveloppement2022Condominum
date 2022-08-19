using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class MatchingsPaiements
    {
        public int IdMatchingPaiement { get; set; }
        public int IdDecompte { get; set; }
        public int IdPaiement { get; set; }
        public double Montant { get; set; }
        public DateTime DateEnregistrement { get; set; }
        public string Remarque { get; set; }

        //public Decomptes Decompte { get; set; }
        //public Paiements Paiement { get; set; }
    }
}
