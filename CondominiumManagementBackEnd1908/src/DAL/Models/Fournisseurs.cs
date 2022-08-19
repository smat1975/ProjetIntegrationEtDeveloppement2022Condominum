using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Fournisseurs
    {

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

        public ICollection<DocumentsFournisseurs> DocumentsFournisseurs { get; set; }
    }
}
