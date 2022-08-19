using System;
using System.Collections.Generic;
using DAL.EFContext;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.EFEntities
{
    public partial class Civilites
    {
        public Civilites()
        {
            Coproprietaires = new HashSet<Coproprietaires>();
        }

        public int IdCivilite { get; set; }
        public string Denomination { get; set; }
        public string Remarque { get; set; }

        public virtual ICollection<Coproprietaires> Coproprietaires { get; set; }
    }
}
