using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Coproprietaires
    {
        public Coproprietaires()
        {
            ComptesBque = new HashSet<ComptesBque>();
            Coproprietes = new HashSet<Coproprietes>();
            Decomptes = new HashSet<Decomptes>();
            Destinations = new HashSet<Destinations>();
            Messages = new HashSet<Messages>();
        }

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

        public virtual Civilites IdCiviliteNavigation { get; set; }
        public virtual RaisonsCloture IdRaisonClotureNavigation { get; set; }
        public virtual ICollection<ComptesBque> ComptesBque { get; set; }
        public virtual ICollection<Coproprietes> Coproprietes { get; set; }
        public virtual ICollection<Decomptes> Decomptes { get; set; }
        public virtual ICollection<Destinations> Destinations { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
    }
}
