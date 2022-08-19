using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DocumentsFournisseurs
    {

        public int IdDocumentFournisseur { get; set; }
        public int IdTypeDocumentFournisseur { get; set; }
        public int IdFournisseur { get; set; }
        public int? IdPeriode { get; set; }
        public string Description { get; set; }
        public double? MontantTotalTvacdocument { get; set; }
        public int? IdTypeTva { get; set; }
        public double? MontantTva { get; set; }
        public DateTime DateEnregistrement { get; set; }
        public DateTime DateDocument { get; set; }
        public DateTime? DateEcheance { get; set; }
        public string Remarque { get; set; }

        public Fournisseurs Fournisseur { get; set; }
        public Periodes Periode { get; set; }
        public TypesDocumentFournisseur TypeDocumentFournisseur { get; set; }
        public TypesTva TypeTva { get; set; }
        public ICollection<LignesDocumentsFournisseurs> LignesDocumentsFournisseurs { get; set; }
    }
}
