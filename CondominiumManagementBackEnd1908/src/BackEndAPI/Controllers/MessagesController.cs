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
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BackEndAPI.Handlers.ErrorHandling;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Produces("application/json")]
    [Route("backendapi/[Controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
            private IMessagesRepository _messagesRepository;
            //private CondominiumMgtContext _condominiumMgtContext;

        public MessagesController(IMessagesRepository messagesRepository/*, CondominiumMgtContext condominiumMgtContext*/)
        {
                _messagesRepository = messagesRepository;
                //_condominiumMgtContext = condominiumMgtContext;
        }

     
            //OK BON// ====> N'existe plus car les Messages sont devenus complexes à cause du traitement de EFCore
            /// <summary>
            /// Liste de tous les Messages
            /// </summary>
            /// <returns></returns>
            [HttpGet("listallmessages/")]
            [Route("listallmessages/")]
            [ProducesResponseType(StatusCodes.Status200OK)]

            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<CondominiumManagement.Models.Messages>>> ListAllMessages()
            {
                var listeMessages = await _messagesRepository.ListAllMessages();

                if (listeMessages == null)
                {
                    return NotFound();
                }

                return Ok(listeMessages.ToList());
            }

        //OK BON//
        /// <summary>
        /// Liste de tous les Messages Complexe
        /// </summary>
        /// <returns></returns>
        [HttpGet("listallmessagescomplexe/")]
        [Route("listallmessagescomplexe/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.Messages>>> ListAllMessagesComplexe()
        {
            var listeMessages = await _messagesRepository.ListAllMessages();

            if (listeMessages == null)
            {
                return NotFound();
            }

            return Ok(listeMessages.ToList());
        }

        //OK BON//
        /// <summary>
        /// Liste de tous les Messages Simple
        /// </summary>
        /// <returns></returns>
        [HttpGet("listallmessagessimple/")]
        [Route("listallmessagessimple/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CondominiumManagement.Models.Messages>>> ListAllMessagesSimple()
        {
            var listeMessages = await _messagesRepository.ListAllMessagesSimple();

            if (listeMessages == null)
            {
                return NotFound();
            }

            return Ok(listeMessages.ToList());
        }

        //OK BON//
        /// <summary>
        /// Liste de tous les Messages Complet
        /// </summary>
        /// <returns></returns>
        [HttpGet("listallmessagescomplet/")]
        [Route("listallmessagescomplet/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.Messages>>> ListAllMessagesComplet()
        {
            var listeMessagesComplet = await _messagesRepository.ListAllMessagesComplet();

            if (listeMessagesComplet == null)
            {
                return NotFound();
            }

            return Ok(listeMessagesComplet.ToList());
        }

        //OK BON!!!!//
        /// <summary>
        /// Détails du Message
        /// </summary>
        /// <param name="idMessage">Identifiant du Message</param>
        /// <returns></returns>
        [HttpGet("detailsmessage/{idMessage}")]
            [Route("detailsmessage/{idMessage}")]
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

        //OK BON!!!!//
        /// <summary>
        /// Trouver le Message par son identifiant
        /// </summary>
        /// <param name="idMessage">Identifiant du Message</param>
        /// <returns></returns>
        [HttpGet("getmessagebyid/{idMessage}")]
        [Route("getmessagebyid/{idMessage}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Messages>> GetMessageById(int idMessage)
        {
            var message = await _messagesRepository.GetMessageById(idMessage);

            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        //OK BON//De Microsoft
        /// <summary>
        /// Créer un Message Retry
        /// </summary>
        /// <returns></returns>
        [HttpPost("creermessageretry/{nouveauMessage}")]
        [Route("creermessageretry/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreerMessageRetry(DAL.EFEntities.Messages nouveauMessage)
        {
            if (nouveauMessage == null)
            {
                return BadRequest();
            }
            await _messagesRepository.CreerMessageRetry(nouveauMessage);
            return Ok(nouveauMessage);

        }
        

            //OK BON//
            /// <summary>
            /// Modifier un Message
            /// </summary>
            /// <param name="idMessage">Identifiant du Message</param>
            /// <param name="message">Objet contenu Message</param>
            /// <returns></returns>
            [HttpPut("modifiermessage/{idMessage}")]
            [Route("modifiermessage/{idMessage}")]
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
            [HttpPut("modifiermessagebis/{idMessage}")]
            [Route("modifiermessagebis/{idMessage}")]
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
            [HttpDelete("supprimermessage/{idMessage}")]
            [Route("supprimermessage/{idMessage}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult> SupprimerMessage(int idMessage)
            {
                await _messagesRepository.SupprimerMessage(idMessage);

                return NoContent();
        }


        //OK BON//
        /// <summary>
        /// Supprimer un Message BIS
        /// </summary>
        /// <param name="idMessage">Identifiant du Message</param>
        /// <returns></returns>
        [HttpDelete("supprimermessagebis/{idMessage}")]
        [Route("supprimermessagebis/{idMessage}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SupprimerMessageBIS(int idMessage)
        {
            try
            {
                var message = await _messagesRepository.DetailsMessage(idMessage);
                if (message == null)
                {
                    return NotFound();
                }
                await _messagesRepository.SupprimerMessageBIS(idMessage);
                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        //OK BON//
        /// <summary>
        /// Supprimer un Message ById
        /// </summary>
        /// <param name="idMessage">Identifiant du Message</param>
        /// <returns></returns>
        [HttpDelete("supprimermessagebyid/{idMessage}")]
        [Route("supprimermessagebyid/{idMessage}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SupprimerMessageById(int idMessage)
        {
            //try
            //{
                var message = await _messagesRepository.DetailsMessage(idMessage);
                if (message == null)
                {
                    return NotFound();
                }
                await _messagesRepository.SupprimerMessageById(idMessage);
                return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    //_logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
            //    return StatusCode(501, "Internal server error");
            //}
        }

        //OK BON//
        /// <summary>
        /// Supprimer un message TER
        /// </summary>
        /// <param name="idMessage">Identifiant de l'objet message</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("supprimermessageter/{idMessage}")]
        [Route("supprimermessageter/{idMessage}")]
        public async Task<ActionResult> SupprimerMessageTER(int idMessage)
        {
            var result = await _messagesRepository.GetMessageById(idMessage);
            if (result == null)
            {
                return NotFound();
            }
            await _messagesRepository.SupprimerMessageTER(idMessage);
            return NoContent();
        }


        //OK BON//
        /// <summary>
        /// Supprimer un Message QUATER => Ne fonctionne pas : problème avec .Remove => Problèmes avec EFcore????
        /// </summary>
        /// <param name="idMessage">Identifiant du Message</param>
        /// <returns></returns>
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpDelete("supprimermessagequater/{idMessage}")]
        //[Route("supprimermessagequater/{idMessage}")]
        //public async Task<ActionResult> SupprimerMessageQuater(int idMessage)
        //{
        //    //CondominiumMgtContext _condominiumMgtContext = new CondominiumMgtContext();
        //        var result = await _condominiumMgtContext.Messages.FindAsync(idMessage);

        //        if (result != null)
        //        {
        //        _condominiumMgtContext.Remove(idMessage);
        //        await _condominiumMgtContext.SaveChangesAsync();
        //        }
        //        return null;
        //}


        //OK BON//
        /// <summary>
        /// Supprimer un Message DIRECTE
        /// </summary>
        /// <param name="idMessage">Identifiant du Message</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("supprimermessagedirecte/{idMessage}")]
        [Route("supprimermessagedirecte/{idMessage}")]
        public async Task<ActionResult> SupprimerMessageDirecte(int idMessage)
        {
            
            var result = await _messagesRepository.GetMessageById(idMessage);
            if (result == null)
            {
                return NotFound();
            }
            await _messagesRepository.SupprimerMessageDirecte(idMessage);
            return NoContent();
        }
   

        //!\\A Vérifier!!!!//!\\

        //OK BON!!!!//
        /// <summary>
        /// Ensemble des Messages pour un Coproprietaire-Expediteur déterminé
        /// </summary>
        /// <param name="idExpediteur">Identifiant de la Coproprietaire-Expediteur</param>
        /// <returns></returns>
        [HttpGet("getmessagesofcoproprietaireexpediteur/{idExpediteur}")]
        [Route("getmessagesofcoproprietaireexpediteur/{idExpediteur}")]
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
        }



        //OK BON!!!!//
        /// <summary>
        /// Méthode pour ajouter une nouvelle Annexe à un Message (en cours de) création et préalablement existant
        /// </summary>
        /// <param name="idMessage">Identifiant du message auquel ajouter une annexe</param>
        /// <returns></returns>
        [HttpGet("addannexetomessage/{idMessage}")]
        [Route("addannexetomessage/{idMessage}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Messages>>> AddAnnexeToMessage(int idMessage, Annexes nouvelleAnnexe)
        {
            var result = await _messagesRepository.GetMessageById(idMessage);
            if (result != null)
            {
                if (nouvelleAnnexe == null)
                {
                    return BadRequest();
                }
                else
                {
                    var message = await _messagesRepository.AddAnnexeToMessage(idMessage, nouvelleAnnexe);
                    return Ok(message);
                }
            }
            return NotFound();
        }



        //OK BON!!!!//
        /// <summary>
        /// Méthode pour ajouter une nouvelle Destination à un Message (en cours de) création et préalablement existant
        /// </summary>
        /// <param name="idMessage">Identifiant du message auquel ajouter une destination</param>
        /// <returns></returns>
        [HttpGet("adddestinationtomessage/{idMessage}")]
        [Route("adddestinationtomessage/{idMessage}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Messages>>> AddDestinationToMessage(int idMessage, Destinations nouvelleDestination)
        {
            var result = await _messagesRepository.GetMessageById(idMessage);
            if (result != null)
            {
                if (nouvelleDestination == null)
                {
                    return BadRequest();
                }
                else
                {
                    var message = await _messagesRepository.AddDestinationToMessage(idMessage, nouvelleDestination);
                    return Ok(message);
                }
            }
            return NotFound();
        }
    }
}
