using System;
using System.Collections.Generic;
using DAL.EFContext;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CondominiumManagement.Models.DTOs
{
    public class MessagesPublicsToShowDto
    {
        [Display(Name = "Contenu")]
        public string ContenuMessage { get; set; }
        [Display(Name = "Date expédition")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = /*"{0:yyyy/MM/dd}"*/"{0:dd MM yyyy}")]
        public DateTime DateExpedition { get; set; }

    }
}
