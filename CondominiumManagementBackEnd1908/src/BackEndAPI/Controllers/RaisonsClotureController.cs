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
    public class RaisonsClotureController : ControllerBase
    {

        private IRaisonsClotureRepository _raisonsClotureRepository;

        public RaisonsClotureController(IRaisonsClotureRepository raisonsClotureRepository)
        {
            _raisonsClotureRepository = raisonsClotureRepository;
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les RaisonsCloture
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.RaisonsCloture>>> ListAllRaisonsCloture()
        {
            var listeRaisonsCloture = await _raisonsClotureRepository.ListAllRaisonsCloture();

            if (listeRaisonsCloture == null)
            {
                return NotFound();
            }

            return Ok(listeRaisonsCloture.ToList());
        }

        //OK BON!!!!//
        /// <summary>
        /// Détails d'une RaisonCloture
        /// </summary>
        /// <param name="idRaisonCloture">Identifiant d'une RaisonCloture</param>
        /// <returns></returns>
        [HttpGet("{idRaisonCloture}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.RaisonsCloture>> DetailsRaisonCloture(int idRaisonCloture)
        {
            var raisonCloture = await _raisonsClotureRepository.DetailsRaisonCloture(idRaisonCloture);

            if (raisonCloture == null)
            {
                return NotFound();
            }
            return Ok(raisonCloture);
        }



        //OK BON//Original
        /// <summary>
        /// Créer une RaisonCloture
        /// </summary>
        /// <returns></returns>
        [HttpPost("{nouvelleRaisonCloture}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.RaisonsCloture>> CreerNouvelleRaisonCloture(DAL.EFEntities.RaisonsCloture nouvelleRaisonCloture)
        {
            await _raisonsClotureRepository.CreerRaisonCloture(nouvelleRaisonCloture);
            if (nouvelleRaisonCloture == null)
            {
                return BadRequest();
            }
            return Ok(nouvelleRaisonCloture);
        }

        //OK BON//
        /// <summary>
        /// Modifier un RaisonCloture
        /// </summary>
        /// <param name="idRaisonCloture">Identifiant du RaisonCloture</param>
        /// <param name="raisonCloture">Objet contenu RaisonCloture</param>
        /// <returns></returns>
        [HttpPut("{idRaisonCloture}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ModifierRaisonCloture(int idRaisonCloture, DAL.EFEntities.RaisonsCloture raisonCloture)
        {
            if (idRaisonCloture != raisonCloture.IdRaisonCloture)
            {
                return NotFound();
            }

            try
            {
                await _raisonsClotureRepository.ModifierRaisonCloture(idRaisonCloture,raisonCloture);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(raisonCloture);
        }

        //OK BON//
        /// <summary>
        /// Modifier un RaisonCloture bis
        /// </summary>
        /// <param name="raisonCloture">Objet contenu RaisonCloture</param>
        /// <returns></returns>
        [HttpPut("{idRaisonCloture}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModifierRaisonClotureBis(DAL.EFEntities.RaisonsCloture raisonCloture)
        {
            try
            {
                await _raisonsClotureRepository.ModifierRaisonClotureBis(raisonCloture);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(raisonCloture);
        }

        //OK BON//
        /// <summary>
        /// Supprimer un RaisonCloture
        /// </summary>
        /// <param name="idRaisonCloture">Identifiant de l'objet RaisonCloture</param>
        /// <returns></returns>
        [HttpDelete("{idRaisonCloture}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> SupprimerRaisonCloture(int idRaisonCloture)
        {
            await _raisonsClotureRepository.SupprimerRaisonCloture(idRaisonCloture);
            return NoContent();
        }

        //!\\A Vérifier!!!!//!\\

        //OK BON!!!!//
        /// <summary>
        /// Ensemble des coproprietaires pour une RaisonCloture déterminé
        /// </summary>
        /// <param name="idRaisonCloture">Identifiant de la RaisonCloture</param>
        /// <returns></returns>
        [HttpGet("{idRaisonCloture}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Coproprietaires>> GetCoproprietairesForRaisonCloture(int idRaisonCloture)
        {
            var ensembleCoproprietaires = await _raisonsClotureRepository.GetCoproprietairesForRaisonCloture(idRaisonCloture);

            if (ensembleCoproprietaires == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensembleCoproprietaires);
            }
        }

        
        //OK BON!!!!//
        /// <summary>
        /// Ensemble des coproprietes pour un Coproprietaire déterminé
        /// </summary>
        /// <param name="idCoproprietaire">Identifiant de la Coproprietaire</param>
        /// <returns></returns>
        [HttpGet("{idCoproprietaire}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Coproprietaires>> GetRaisonClotureForCoproprietaire(string idCoproprietaire)
        {
            var ensembleCoproprietes = await _raisonsClotureRepository.GetRaisonClotureForCoproprietaire(idCoproprietaire);

            if (ensembleCoproprietes == null)
            {
                return /*(IEnumerable<Coproprietes>)*/NotFound();
            }
            else
            {
                return /*(IEnumerable<Coproprietes>)*/Ok(ensembleCoproprietes);
            }
        }

    }
}
