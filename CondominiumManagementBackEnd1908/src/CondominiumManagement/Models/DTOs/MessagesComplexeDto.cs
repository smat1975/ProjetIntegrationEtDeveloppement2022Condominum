using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models.DTOs
{
    public class MessagesComplexeDto
    {
        public int IdMessage { get; set; }
        public int IdExpediteur { get; set; }
        public DateTime DateExpedition { get; set; }
        public string TitreMessage { get; set; }
        public string ContenuMessage { get; set; }
        public int IdTypeMessage { get; set; }
        public string[] Annexe { get; set; }
        public string[] Destination { get; set; }
        public bool? validation { get; set; }
        /*public int? IdExpediteurNavigation { get; set; }
        public int? IdTypeMessageNavigation { get; set; }*/
    }
}
