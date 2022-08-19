using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondominiumManagement.Models;
using CondominiumManagement.Models.DTOs;
using CondominiumManagement.Services;

namespace BackEndAPI.Controllers
{
    public class EnvoiEmailController : Controller
    {
        private readonly IMailService _mailService;

        public EnvoiEmailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        // POST: EamilDTOController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnvoyerMail(EmailDTO model)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    //Envoyer email
                    _mailService.EnvoyerEmail(model.EmailDestinaire, model.TitreEmail, $"From: {model.NomExpediteur} - {model.EmailExpediteur} , Message: {model.Contenu}, Annexe: {model.IdAnnexe} - {model.Commentaire}");
                    ModelState.Clear();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
