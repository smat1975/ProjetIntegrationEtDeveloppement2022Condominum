using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models.DTOs
{
    public class MessagesToCreateDTO
    {
        public int IdMessage { get; set; }
        public string IdExpediteur { get; set; }
        public DateTime DateExpedition { get; set; }
        public string TitreMessage { get; set; }
        public string ContenuMessage { get; set; }
        public int IdTypeMessage { get; set; }
        public bool? Validation { get; set; }


        public virtual Coproprietaires IdExpediteurNavigation { get; set; }
        public virtual TypesMessage IdTypeMessageNavigation { get; set; }
        public ICollection<Annexes> Annexes { get; set; }
        public ICollection<Destinations> Destinations { get; set; }
    }
}
