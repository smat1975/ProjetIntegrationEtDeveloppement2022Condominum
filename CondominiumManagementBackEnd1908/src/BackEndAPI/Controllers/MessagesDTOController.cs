using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Application.Services.Interfaces;
using System.Text;
using DAL.EFContext;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using DAL.EFEntities;
//using CondominiumManagement.Models;
using Newtonsoft.Json;
using CondominiumManagement.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Produces("application/json")]
    [Route("backendapi/[Controller]")]
    [ApiController]
    public class MessagesDTOController : ControllerBase
    {
            private IMessagesRepository _messagesRepository;

            public MessagesDTOController(IMessagesRepository messagesRepository)
            {
                _messagesRepository = messagesRepository;
            }


            /*//OK BON//
            /// <summary>
            /// Liste de tous les Messages DTO
            /// </summary>
            /// <returns></returns>
            [HttpGet("listallmessagesdto/")]
            [Route("listallmessagesdto/")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<CondominiumManagement.Models.Messages>>> ListAllMessagesDto()
            {
                var listeMessages = await _messagesRepository.ListAllMessages();

                if (listeMessages == null)
                {
                    return NotFound();
                }

                return Ok(listeMessages.ToList());
            }*/

        //OK BON//
        /// <summary>
        /// Liste de tous les Messages Complexe DTO
        /// </summary>
        /// <returns></returns>
        [HttpGet("listallmessagescomplexedto/")]
        [Route("listallmessagescomplexedto/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CondominiumManagement.Models.DTOs.MessagesComplexeDto>>> ListAllMessagesComplexeDto()
        {
            var listeMessagesComplexe = await _messagesRepository.ListAllMessagesComplexeDto();

            if (listeMessagesComplexe == null)
            {
                return NotFound();
            }

            return Ok(listeMessagesComplexe.ToList());
        }
        /*
        //OK BON!!!!//
        /// <summary>
        /// Détails du Message
        /// </summary>
        /// <param name="idMessage">Identifiant du Message</param>
        /// <returns></returns>
        [HttpGet("{idMessage}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Messages>> DetailsMessage(int idMessage)
            {
                var message = await _messagesRepository.DetailsMessage(idMessage);

                if (message == null)
                {
                    return NotFound();
                }
                return Ok(message);
            }



            //OK BON//Original
            /// <summary>
            /// Créer un Message
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouveauMessage}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Messages>> CreerMessage(DAL.EFEntities.Messages nouveauMessage)
            {
                await _messagesRepository.CreerMessage(nouveauMessage);
                if (nouveauMessage == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauMessage);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Message
            /// </summary>
            /// <param name="idMessage">Identifiant du Message</param>
            /// <param name="message">Objet contenu Message</param>
            /// <returns></returns>
            [HttpPut("{idMessage}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierMessage(int idMessage, DAL.EFEntities.Messages message)
            {
                if (idMessage != message.IdMessage)
                {
                    return NotFound();
                }

                try
                {
                    await _messagesRepository.ModifierMessage(idMessage, message);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(message);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Message bis
            /// </summary>
            /// <param name="message">Objet contenu Message</param>
            /// <returns></returns>
            [HttpPut("{idMessage}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierMessageBis(DAL.EFEntities.Messages message)
            {
                try
                {
                    await _messagesRepository.ModifierMessageBis(message);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(message);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un Message
            /// </summary>
            /// <param name="idMessage">Identifiant de l'objet Message</param>
            /// <returns></returns>
            [HttpDelete("{idMessage}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerMessage(int idMessage)
            {
                await _messagesRepository.SupprimerMessage(idMessage);
                return NoContent();
            }

        //!\\A Vérifier!!!!//!\\

        //OK BON!!!!//
        /// <summary>
        /// Ensemble des Messages pour un Coproprietaire-Expediteur déterminé
        /// </summary>
        /// <param name="idExpediteur">Identifiant de la Coproprietaire-Expediteur</param>
        /// <returns></returns>
        [HttpGet("{idExpediteur}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Messages>>> GetMessagesOfCoproprietaireExpediteur(string idExpediteur)
        {
            var ensembleMessages = await _messagesRepository.GetMessagesOfCoproprietaireExpediteur(idExpediteur);

            if (ensembleMessages == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensembleMessages);
            }
        }*/
        
    }
}
