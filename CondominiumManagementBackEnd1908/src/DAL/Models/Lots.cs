using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Lots
    {
        public int IdLot { get; set; }
        public int IdTypeLot { get; set; }
        public string CodeLot { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int IdLocalisation { get; set; }
        public string Description { get; set; }
        public int NombreM2 { get; set; }
        public string Remarque { get; set; }

        public Localisations Localisation { get; set; }
        public TypesLot TypeLot { get; set; }
        public ICollection<Coproprietes> Coproprietes { get; set; }
        public ICollection<Groupements> Groupements { get; set; }
        public ICollection<Quotites> Quotites { get; set; }

    }
}
