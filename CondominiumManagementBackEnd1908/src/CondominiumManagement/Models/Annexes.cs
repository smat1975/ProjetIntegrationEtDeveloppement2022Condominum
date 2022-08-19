using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models
{
    public class Annexes
    {

            public int IdAnnexe { get; set; }
            public int IdMessage { get; set; }
            //public int? IdDecompte { get; set; }
            public int? IdPhoto { get; set; }
            public string Remarque { get; set; }


        //Remarque : Qu'on fasse un  int IdDecompte + Decomptes Decomptes
        //ou int IdDecompte + Decomptes IdDecompteNavigation, c'est la même
        //chose car on a bien à chaque fois un Id pour identifier précisemement
        //le tuple de la "collection" et un objet au format du tuple, qu'on le 
        //nomme NomObjetId+Navigation n'a pas d'importance! C'est une convention!
        //A chaque fois qu'on a une foreign key, on a ce genre de format!...
        //A chaque fois qu'un attribut est clé primaire d'un 1-to-many => ...
        public Messages Message { get; set; }
        public ICollection<Photos> Photos { get; set; }


    }
}


