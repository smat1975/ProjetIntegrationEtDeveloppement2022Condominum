using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Messages
    {
        public Messages()
        {
            Annexes = new HashSet<Annexes>();
            Destinations = new HashSet<Destinations>();
        }

        public int IdMessage { get; set; }
        public string IdExpediteur { get; set; }
        public DateTime DateExpedition { get; set; }
        public string TitreMessage { get; set; }
        public string ContenuMessage { get; set; }
        public int IdTypeMessage { get; set; }
        public bool? Validation { get; set; }

        public virtual Coproprietaires IdExpediteurNavigation { get; set; }
        public virtual TypesMessage IdTypeMessageNavigation { get; set; }
        public virtual ICollection<Annexes> Annexes { get; set; }
        public virtual ICollection<Destinations> Destinations { get; set; }
    }
}
