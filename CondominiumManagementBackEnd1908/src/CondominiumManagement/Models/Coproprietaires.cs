using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class Coproprietaires
    {

        public string IdCoproprietaire { get; set; }
        public string Nom { get; set; }
        public string Prenoms { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string NumNiss { get; set; }
        public int Sexe { get; set; }
        public string Email { get; set; }
        public string NumTel { get; set; }
        public string NumGsm { get; set; }
        public string Adresse { get; set; }
        public int IdCivilite { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateCloture { get; set; }
        public int IdRaisonCloture { get; set; }
        public string ContactAdresse { get; set; }
        public string ContactNom { get; set; }
        public string ContactTel { get; set; }
        public string ContactEmail { get; set; }
        public string ContactRelation { get; set; }
        public string AdresseFacturation { get; set; }
        public string AdresseEnvoiFacture { get; set; }
        public string EmailEnvoiFacture { get; set; }
        public string NumTelEnvoiFacture { get; set; }
        public string Remarques { get; set; }

        //public Civilites Civilite { get; set; }
        //public RaisonsCloture RaisonCloture { get; set; }
        //public ICollection<ComptesBque> ComptesBque { get; set; }
        //public ICollection<Coproprietes> Coproprietes { get; set; }
        //public ICollection<Decomptes> Decomptes { get; set; }
        //public ICollection<Destinations> Destinations { get; set; }
        //public ICollection<Messages> Messages { get; set; }
    }
}
