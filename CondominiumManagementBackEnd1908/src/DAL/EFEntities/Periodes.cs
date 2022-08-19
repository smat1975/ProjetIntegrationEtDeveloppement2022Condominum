using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Periodes
    {
        public Periodes()
        {
            Decomptes = new HashSet<Decomptes>();
            DocumentsFournisseurs = new HashSet<DocumentsFournisseurs>();
        }

        public int IdPeriode { get; set; }
        public string Denomination { get; set; }
        public int Annee { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string Remarque { get; set; }

        public virtual ICollection<Decomptes> Decomptes { get; set; }
        public virtual ICollection<DocumentsFournisseurs> DocumentsFournisseurs { get; set; }
    }
}
