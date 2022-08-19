using BackEndAPI.Handlers.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
//using Application.Services.Interfaces;
using DAL.EFContext;
using DAL.EFEntities;
//using CondominiumManagement.Models;
using CondominiumManagement.Repositories.Interfaces;
using CondominiumManagement.Models.DTOs;


namespace BackEndAPI.Controllers
{
    [Produces("application/json")]
    [Route("backendapi/[Controller]")]
    [ApiController]
    public class VuesHandlingController : Controller
    {
        private readonly IVuesHandlingRepository _IVuesRepository;

        public VuesHandlingController(IVuesHandlingRepository IVuesRepository)
        {
            this._IVuesRepository = IVuesRepository ?? throw new ArgumentNullException(nameof(IVuesRepository));
        }

        //OK BON!!!!//
        /// <summary>
        /// Liste de messages publics à montrer
        /// </summary>
        /// <returns></returns>
        [HttpGet("listemessagespublicstoshow/")]
        [Route("listemessagespublicstoshow/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MessagesPublicsToShowDto>>> GetListeMessagesPublicsToShow()
        {
            return await _IVuesRepository.GetAllMessagesPublicsToShow();
        }

        //OK BON!!!!//
        /// <summary>
        /// Liste de messages complets à montrer
        /// </summary>
        /// <returns></returns>
        [HttpGet("listemessagescompletetoshow/")]
        [Route("listemessagescompletetoshow/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MessagesCompleteToShowDto>>> GetListeMessagesCompleteToShow()
        {
            return await _IVuesRepository.GetAllMessagesCompleteToShow();
        }

        //OK BON!!!!//
        /// <summary>
        /// Liste de messages publics à montrer
        /// </summary>
        /// <returns></returns>
        [HttpGet("listemessagestoshow/")]
        [Route("listemessagestoshow/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MessagesToShowDto>>> GetListeMessagesToShow()
        {
            return await _IVuesRepository.GetAllMessagesToShow();
        }

        //OK BON!!!!//
        /// <summary>
        /// Liste des messages d'un utilisateur déterminé à montrer
        /// </summary>
        /// <param name="IdUtilisateur">Identifiant de l'Utilisateur</param>
        /// <returns></returns>
        [HttpGet("listemessagesutilisateurtoshow/{IdUtilisateur}")]
        [Route("listemessagesutilisateurtoshow/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MessagesUtilisateurToShowDto>>> GetListeMessagesUtilisateurToShow(int IdUtilisateur)
        {
            return await _IVuesRepository.GetAllMessagesUtilisateurToShow(IdUtilisateur);
        }

        //OK BON!!!!//
        /// <summary>
        /// Détails d'un messages d'un utilisateur déterminé à montrer
        /// </summary>
        /// <param name="IdMessage">Identifiant du message</param>
        /// <returns></returns>
        [HttpGet("listemessagesutilisateurdetailstoshow/{IdMessage}")]
        [Route("listemessagesutilisateurdetailstoshow/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MessagesUtilisateurDetailsToShowDto>>> GetListeMessagesUtilisateurDetailsToShow(int IdMessage)
        {
            return await _IVuesRepository.GetAllMessagesUtilisateurDetailsToShow(IdMessage);
        }

        /*
        //OK BON!!!!//
        /// <summary>
        /// Liste de messages publics à montrer
        /// </summary>
        /// <param name="idAcp">Identifiant de l'Utilisateur</param>
        /// <returns></returns>
        [HttpGet("listemessagespublicstoshow/{idAcp}")]
        [Route("listemessagespublicstoshow/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Domain.Models.MessagesPublicsToShowDto>> GetListeMessagesPublicsAcpToShow(int idAcp)
        {
            var response = await _IVuesRepository.GetListeMessagesPublicsAcpToShow(idAcp);
            if (response == null) { return NotFound(); }
            return response;
        }*/
    }
}
