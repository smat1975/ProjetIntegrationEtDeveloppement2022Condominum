using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Decomptes
    {

        public int IdDecompte { get; set; }
        public string IdCoproprietaire { get; set; }
        public int IdGroupement { get; set; }
        public int IdPeriode { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateDebutDecompte { get; set; }
        public DateTime DateFinDecompte { get; set; }
        public double? MontantTotalDecompte { get; set; }
        public int? IdTypeTva { get; set; }
        public double? MontantTotalTva { get; set; }
        public DateTime? DateEcheance { get; set; }
        public string ReferencePaiement { get; set; }
        public string Commentaire { get; set; }
        public bool? SoldeON { get; set; }
        public string Remarque { get; set; }

        public Coproprietaires Coproprietaire { get; set; }
        public Groupements Groupement { get; set; }
        public Periodes Periode { get; set; }
        public TypesTva TypeTva { get; set; }
        public ICollection<LignesDecomptes> LignesDecomptes { get; set; }
        public ICollection<MatchingsPaiements> MatchingsPaiements { get; set; }

        //Calculer montant total décompte
        //Calculer montant total tva
        //Générer Référence paiement
        //Affecter Soldé O/N


    }
}
