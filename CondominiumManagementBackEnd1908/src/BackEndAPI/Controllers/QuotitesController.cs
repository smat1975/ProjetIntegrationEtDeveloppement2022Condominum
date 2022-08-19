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

namespace BackEndAPI.Controllers
{
    [Produces("application/json")]
    [Route("backendapi/[Controller]")]
    [ApiController]
    public class QuotitesController : ControllerBase
    {

        private IQuotitesRepository _quotitesRepository;

        public QuotitesController(IQuotitesRepository quotitesRepository)
        {
            _quotitesRepository = quotitesRepository;
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Quotites
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.Quotites>>> ListAllQuotites()
        {
            var listeQuotites = await _quotitesRepository.ListAllQuotites();

            if (listeQuotites == null)
            {
                return NotFound();
            }

            return Ok(listeQuotites.ToList());
        }

        //OK BON!!!!//
        /// <summary>
        /// Détails d'une Quotite
        /// </summary>
        /// <param name="idQuotite">Identifiant d'une Quotite</param>
        /// <returns></returns>
        [HttpGet("{idQuotite}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Quotites>> DetailsQuotite(int idQuotite)
        {
            var quotite = await _quotitesRepository.DetailsQuotite(idQuotite);

            if (quotite == null)
            {
                return NotFound();
            }
            return Ok(quotite);
        }



        //OK BON//Original
        /// <summary>
        /// Créer une Quotite
        /// </summary>
        /// <returns></returns>
        [HttpPost("{nouvelleQuotite}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Quotites>> CreerNouvelleQuotite(DAL.EFEntities.Quotites nouvelleQuotite)
        {
            await _quotitesRepository.CreerQuotite(nouvelleQuotite);
            if (nouvelleQuotite == null)
            {
                return BadRequest();
            }
            return Ok(nouvelleQuotite);
        }

        //OK BON//
        /// <summary>
        /// Modifier un Quotite
        /// </summary>
        /// <param name="idQuotite">Identifiant du Quotite</param>
        /// <param name="quotite">Objet contenu Quotite</param>
        /// <returns></returns>
        [HttpPut("{idQuotite}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ModifierQuotite(int idQuotite, DAL.EFEntities.Quotites quotite)
        {
            if (idQuotite != quotite.IdQuotite)
            {
                return NotFound();
            }

            try
            {
                await _quotitesRepository.ModifierQuotite(idQuotite, quotite);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(quotite);
        }

        //OK BON//
        /// <summary>
        /// Modifier un Quotite bis
        /// </summary>
        /// <param name="quotite">Objet contenu Quotite</param>
        /// <returns></returns>
        [HttpPut("{idQuotite}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModifierQuotiteBis(DAL.EFEntities.Quotites quotite)
        {
            try
            {
                await _quotitesRepository.ModifierQuotiteBis(quotite);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(quotite);
        }

        //OK BON//
        /// <summary>
        /// Supprimer un Quotite
        /// </summary>
        /// <param name="idQuotite">Identifiant de l'objet Quotite</param>
        /// <returns></returns>
        [HttpDelete("{idQuotite}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> SupprimerQuotite(int idQuotite)
        {
            await _quotitesRepository.SupprimerQuotite(idQuotite);
            return NoContent();
        }

        //!\\A Vérifier!!!!//!\\

        //OK BON!!!!//
        /// <summary>
        /// Ensemble des Quotites pour un Lot déterminé
        /// </summary>
        /// <param name="idLot">Identifiant du Lot</param>
        /// <returns></returns>
        [HttpGet("{idLot}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Lots>> GetQuotiteForLot(int idLot)
        {
            var ensembleQuoties = await _quotitesRepository.GetQuotiteForLot(idLot);

            if (ensembleQuoties == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensembleQuoties);
            }
        }

    }
}

