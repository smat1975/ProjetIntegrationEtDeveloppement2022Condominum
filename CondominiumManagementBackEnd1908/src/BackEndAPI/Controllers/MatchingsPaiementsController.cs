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
    public class MatchingsPaiementsController : ControllerBase
    {

            private IMatchingsPaiementsRepository _matchingsPaiementsRepository;

            public MatchingsPaiementsController(IMatchingsPaiementsRepository matchingsPaiementsRepository)
            {
                _matchingsPaiementsRepository = matchingsPaiementsRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de tous les MatchingsPaiements
            /// </summary>
            /// <returns></returns>
            [HttpGet("listallmatchingspaiements/")]
            [Route("listallmatchingspaiements/")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.MatchingsPaiements>>> ListAllMatchingsPaiements()
            {
                var listeMatchingsPaiements = await _matchingsPaiementsRepository.ListAllMatchingsPaiements();

                if (listeMatchingsPaiements == null)
                {
                    return NotFound();
                }

                return Ok(listeMatchingsPaiements.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails du MatchingPaiement
            /// </summary>
            /// <param name="idMatchingPaiement">Identifiant du MatchingPaiement</param>
            /// <returns></returns>
            [HttpGet("detailsmatchingpaiement/{idMatchingPaiement}")]
            [Route("detailsmatchingpaiement/{idMatchingPaiement}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.MatchingsPaiements>> DetailsMatchingPaiement(int idMatchingPaiement)
            {
                var matchingPaiement = await _matchingsPaiementsRepository.DetailsMatchingPaiement(idMatchingPaiement);

                if (matchingPaiement == null)
                {
                    return NotFound();
                }
                return Ok(matchingPaiement);
            }



            //OK BON//Original
            /// <summary>
            /// Créer un MatchingPaiement
            /// </summary>
            /// <returns></returns>
            [HttpPost("creermatchingpaiement/{nouveauMatchingPaiement}")]
            [Route("creermatchingpaiement/{nouveauMatchingPaiement}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.MatchingsPaiements>> CreerMatchingPaiement(DAL.EFEntities.MatchingsPaiements nouveauMatchingPaiement)
            {
                await _matchingsPaiementsRepository.CreerMatchingPaiement(nouveauMatchingPaiement);
                if (nouveauMatchingPaiement == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauMatchingPaiement);
            }

            //OK BON//
            /// <summary>
            /// Modifier un MatchingPaiement
            /// </summary>
            /// <param name="idMatchingPaiement">Identifiant du MatchingPaiement</param>
            /// <param name="matchingPaiement">Objet contenu MatchingPaiement</param>
            /// <returns></returns>
            [HttpPut("modifiermatchingpaiement/{idMatchingPaiement}")]
            [Route("modifiermatchingpaiement/{idMatchingPaiement}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierMatchingPaiement(int idMatchingPaiement, DAL.EFEntities.MatchingsPaiements matchingPaiement)
            {
                if (idMatchingPaiement != matchingPaiement.IdMatchingPaiement)
                {
                    return NotFound();
                }

                try
                {
                    await _matchingsPaiementsRepository.ModifierMatchingPaiement(idMatchingPaiement, matchingPaiement);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(matchingPaiement);
            }

            //OK BON//
            /// <summary>
            /// Modifier un MatchingPaiement bis
            /// </summary>
            /// <param name="matchingPaiement">Objet contenu MatchingPaiement</param>
            /// <returns></returns>
            [HttpPut("modifiermatchingpaiementbis/{idMatchingPaiement}")]
            [Route("modifiermatchingpaiementbis/{idMatchingPaiement}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierMatchingPaiementBis(DAL.EFEntities.MatchingsPaiements matchingPaiement)
            {
                try
                {
                    await _matchingsPaiementsRepository.ModifierMatchingPaiementBis(matchingPaiement);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(matchingPaiement);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un MatchingPaiement
            /// </summary>
            /// <param name="idMatchingPaiement">Identifiant de l'objet MatchingPaiement</param>
            /// <returns></returns>
            [HttpDelete("supprimermatchingpaiement/{idMatchingPaiement}")]
            [Route("supprimermatchingpaiement/{idMatchingPaiement}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerMatchingPaiement(int idMatchingPaiement)
            {
                await _matchingsPaiementsRepository.SupprimerMatchingPaiement(idMatchingPaiement);
                return NoContent();
            }


        //!\\A Vérifier!!!!//!\\

        //OK BON!!!!//
        /// <summary>
        /// Ensemble des MatchingPaiements pour un CompteBque déterminé
        /// </summary>
        /// <param name="idCompteBque">Identifiant du CompteBque</param>
        /// <returns></returns>
        [HttpGet("getmatchingspaiementsforcomptebque/{idCompteBque}")]
        [Route("getmatchingspaiementsforcomptebque/{idCompteBque}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MatchingsPaiements>>> GetMatchingsPaiementsForCompteBque(int idCompteBque)
        {
            var ensembleMatchingsPaiements = await _matchingsPaiementsRepository.GetMatchingsPaiementsForCompteBque(idCompteBque);

            if (ensembleMatchingsPaiements == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensembleMatchingsPaiements);
            }
        }


        //OK BON!!!!//
        /// <summary>
        /// Ensemble des MatchingsPaiements pour un Decompte déterminé
        /// </summary>
        /// <param name="idDecompte">Identifiant du Decompte</param>
        /// <returns></returns>
        [HttpGet("getmatchingspaiementsfordecompte/{idDecompte}")]
        [Route("getmatchingspaiementsfordecompte/{idDecompte}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MatchingsPaiements>>> GetMatchingsPaiementsForDecompte(int idDecompte)
        {
            var ensembleMatchingsPaiements = await _matchingsPaiementsRepository.GetMatchingsPaiementsForDecompte(idDecompte);

            if (ensembleMatchingsPaiements == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensembleMatchingsPaiements);
            }
        }


        //OK BON!!!!//
        /// <summary>
        /// Ensemble des MatchingsPaiements pour un Paiement déterminé
        /// </summary>
        /// <param name="idPaiement">Identifiant du Paiement</param>
        /// <returns></returns>
        [HttpGet("getmatchingspaiementsforpaiement/{idPaiement}")]
        [Route("getmatchingspaiementsforpaiement/{idPaiement}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MatchingsPaiements>>> GetMatchingsPaiementsForPaiement(int idPaiement)
        {
            var ensembleMatchingsPaiements = await _matchingsPaiementsRepository.GetMatchingsPaiementsForPaiement(idPaiement);
            if (ensembleMatchingsPaiements == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensembleMatchingsPaiements);
            }
        }

    }
}
