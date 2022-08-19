using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Destinations
    {
        public int IdDestination { get; set; }
        public int IdMessage { get; set; }
        public string IdDestinataire { get; set; }

        public virtual Coproprietaires IdDestinataireNavigation { get; set; }
        public virtual Messages IdMessageNavigation { get; set; }
    }
}
