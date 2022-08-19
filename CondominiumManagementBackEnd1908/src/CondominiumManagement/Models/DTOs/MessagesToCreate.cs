using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models.DTOs
{
    public class MessagesToCreate
    {
        public int IdMessage { get; set; }
        public string IdExpediteur { get; set; }
        public DateTime DateExpedition { get; set; }
        public string TitreMessage { get; set; }
        public string ContenuMessage { get; set; }
        public int IdTypeMessage { get; set; }
        public bool? Validation { get; set; }
    }
}
