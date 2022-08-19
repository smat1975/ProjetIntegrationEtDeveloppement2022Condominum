using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class TypesMessage
    {
        public TypesMessage()
        {
            Messages = new HashSet<Messages>();
        }

        public int IdTypeMessage { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public string Remarque { get; set; }

        public virtual ICollection<Messages> Messages { get; set; }
    }
}
