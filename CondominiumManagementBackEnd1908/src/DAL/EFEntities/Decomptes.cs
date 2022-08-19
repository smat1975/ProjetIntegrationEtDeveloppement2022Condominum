using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Decomptes
    {
        public Decomptes()
        {
            LignesDecomptes = new HashSet<LignesDecomptes>();
            MatchingsPaiements = new HashSet<MatchingsPaiements>();
        }

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

        public virtual Coproprietaires IdCoproprietaireNavigation { get; set; }
        public virtual Groupements IdGroupementNavigation { get; set; }
        public virtual Periodes IdPeriodeNavigation { get; set; }
        public virtual TypesTva IdTypeTvaNavigation { get; set; }
        public virtual ICollection<LignesDecomptes> LignesDecomptes { get; set; }
        public virtual ICollection<MatchingsPaiements> MatchingsPaiements { get; set; }
    }
}
