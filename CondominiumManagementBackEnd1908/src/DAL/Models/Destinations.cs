using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Destinations
    {
        public int IdDestination { get; set; }
        public int IdMessage { get; set; }
        public string IdDestinataire { get; set; }

        public Coproprietaires Destinataire { get; set; }
        public Messages Message { get; set; }

        //Affecter plusieurs destinations => email groupé
    }
}
