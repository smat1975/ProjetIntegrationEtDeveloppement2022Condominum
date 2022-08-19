using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Fournisseurs
    {
        public Fournisseurs()
        {
            DocumentsFournisseurs = new HashSet<DocumentsFournisseurs>();
        }

        public int IdFournisseur { get; set; }
        public string Denomination { get; set; }
        public string NomContact { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public string NumTel { get; set; }
        public string NumRegistre { get; set; }
        public string NumTva { get; set; }
        public string Activite { get; set; }
        public string NumAgregation { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string Remarque { get; set; }

        public virtual ICollection<DocumentsFournisseurs> DocumentsFournisseurs { get; set; }
    }
}
