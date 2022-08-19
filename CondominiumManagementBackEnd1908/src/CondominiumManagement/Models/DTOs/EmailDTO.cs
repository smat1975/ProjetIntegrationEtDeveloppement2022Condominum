using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Models.DTOs
{
    public class EmailDTO
    {
        [Required]
        [Display(Name = "Nom expéditeur")]
        public string NomExpediteur { get; set; } = "Le Syndic";
        [Required]
        [EmailAddress]
        [Display(Name = "Adresse email expéditeur")]
        public string EmailExpediteur { get; set; } = "s.mathot@students.ephec.be";
        [Required]
        [Display(Name = "Destinataire")]
        public string NomDestinaire { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Adresse email destinataire")]
        public  string EmailDestinaire { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date d'expédition")]
        public DateTime DateExpedition { get; set; }
        [Required]
        [Display(Name = "Titre email")]
        [MinLength (5)]
        public string TitreEmail { get; set; }
        [Required]
        [Display(Name = "Contenu email")]
        [MaxLength (250/*, ErrorMessage = "Message trop long, maximum 250 caratères!"*/)]
        public string Contenu { get; set; }
        public int IdAnnexe { get; set; }
        [Display(Name = "Commentaire pièce(s) jointe(s)")]
        public string Commentaire { get; set; }

    }
}
