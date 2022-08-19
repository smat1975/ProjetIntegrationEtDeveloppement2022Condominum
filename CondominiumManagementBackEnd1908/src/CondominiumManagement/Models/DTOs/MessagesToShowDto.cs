﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DAL.EFContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace CondominiumManagement.Models.DTOs
{
    public class MessagesToShowDto
    {      
        [Display(Name = "Email")]
        public string Email { get; set; }        
        [Display(Name = "Date expédition")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = /*"{0:yyyy/MM/dd}"*/"{0:dd MM yyyy}")]
        public DateTime DateExpedition { get; set; }
        [Display(Name = "Titre")]
        public string TitreMessage { get; set; }
        [Display(Name = "Contenu")]
        public string ContenuMessage { get; set; }
        [Display(Name = "Type du message")]
        public string TypeMessage { get; set; }
    }
}
