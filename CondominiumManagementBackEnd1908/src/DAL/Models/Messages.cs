using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Messages
    { 
        [Key]
        [Display(Name = "Id message")]
        public int IdMessage { get; set; }
        [Required]
        [Display(Name = "Expéditeur")]
        [ForeignKey("IdUtilisateur")]
        public string IdExpediteur { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MM yyyy}")]
        [Display(Name = "Date expédition")]
        public DateTime DateExpedition { get; set; }
        [Required]
        [Display(Name = "Titre")]
        public string TitreMessage { get; set; }
        [Display(Name = "Contenu")]
        public string ContenuMessage { get; set; }
        //[Required]
        [Display(Name = "Type message")]
        [ForeignKey("IdTypeMessage")]
        public int IdTypeMessage { get; set; }
        [Display(Name = "Validé par l'administrateur")]
        public bool? Validation { get; set; }

        public Coproprietaires Expediteur { get; set; }
        public TypesMessage TypeMessage { get; set; }
        public ICollection<Annexes> Annexes { get; set; }
        public ICollection<Destinations> Destinations { get; set; }

    }
}
