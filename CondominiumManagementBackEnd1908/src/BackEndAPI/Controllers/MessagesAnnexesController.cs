using Microsoft.AspNetCore.Http;
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

namespace BackEndAPI.Controllers
{

    [Produces("application/json")]
    [Route("backendapi/[Controller]")]
    [ApiController]
    public class MessagesAnnexesController : Controller
    {
            private IMessagesRepository _messagesRepository;
            //private CondominiumMgtContext _condominiumMgtContext;

            public MessagesAnnexesController(IMessagesRepository messagesRepository/*, CondominiumMgtContext condominiumMgtContext*/)
            {
                _messagesRepository = messagesRepository;
                //_condominiumMgtContext = condominiumMgtContext;
            }

        //OK BON!!!!//
        /// <summary>
        /// Trouver le MessageAnnexes par son identifiant
        /// </summary>
        /// <param name="idAnnexes">Identifiant du Message</param>
        /// <returns></returns>
        //[HttpGet("getmessageannexebyid/{idAnnexe}")]
        //[Route("getmessageannexebyid/{idAnnexe}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<DAL.EFEntities.Messages>> GetMessageAnnexeById(int idAnnexe)
        //{
        //    var message = await _messagesRepository.GetMessageById(idAnnexe);

        //    if (message == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(message);
        //}

        //OK BON//De Microsoft
        /// <summary>
        /// Créer une Annexe dans un Message
        /// </summary>
        /// <param name="idMessage">Identifiant du Message</param>
        /// <param name="nouvelleAnnexe">Objet Annexe</param>
        /// <returns></returns>
        [HttpPost("creermessageannexe/{idMessage}")]
        [Route("creermessageannexe/{idMessage}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreerMessageAnnexe(int idMessage, DAL.EFEntities.Annexes nouvelleAnnexe)
        {
            if (nouvelleAnnexe == null)
            {
                return BadRequest();
            }
            //await _messagesRepository.CreerMessageAnnexe(nouvelleAnnexe);
            return Ok(nouvelleAnnexe);

        }


        //OK BON//
        /// <summary>
        /// Modifier un Message
        /// </summary>
        /// <param name="idMessage">Identifiant du Message</param>
        /// <param name="message">Objet contenu Message</param>
        /// <returns></returns>
        //[HttpPut("modifiermessage/{idMessage}")]
        //[Route("modifiermessage/{idMessage}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

        //public async Task<IActionResult> ModifierMessage(int idMessage, DAL.EFEntities.Messages message)
        //{
        //    if (idMessage != message.IdMessage)
        //    {
        //        return NotFound();
        //    }

        //    try
        //    {
        //        await _messagesRepository.ModifierMessage(idMessage, message);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {

        //    }

        //    return Ok(message);
        //}



    }
}
