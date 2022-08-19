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
    public class PaiementsController : ControllerBase
    {

            private IPaiementsRepository _paiementsRepository;

            public PaiementsController(IPaiementsRepository paiementsRepository)
            {
                _paiementsRepository = paiementsRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de tous les Paiements
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.Paiements>>> ListAllPaiements()
            {
                var listePaiements = await _paiementsRepository.ListAllPaiements();

                if (listePaiements == null)
                {
                    return NotFound();
                }

                return Ok(listePaiements.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails du Paiement
            /// </summary>
            /// <param name="idPaiement">Identifiant du Paiement</param>
            /// <returns></returns>
            [HttpGet("{idPaiement}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Paiements>> DetailsPaiement(int idPaiement)
            {
                var Paiement = await _paiementsRepository.DetailsPaiement(idPaiement);

                if (Paiement == null)
                {
                    return NotFound();
                }
                return Ok(Paiement);
            }



            //OK BON//Original
            /// <summary>
            /// Créer un Paiement
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouveauPaiement}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Paiements>> CreerPaiement(DAL.EFEntities.Paiements nouveauPaiement)
            {
                await _paiementsRepository.CreerPaiement(nouveauPaiement);
                if (nouveauPaiement == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauPaiement);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Paiement
            /// </summary>
            /// <param name="idPaiement">Identifiant du Paiement</param>
            /// <param name="paiement">Objet contenu Paiement</param>
            /// <returns></returns>
            [HttpPut("{idPaiement}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierPaiement(int idPaiement, DAL.EFEntities.Paiements paiement)
            {
                if (idPaiement != paiement.IdPaiement)
                {
                    return NotFound();
                }

                try
                {
                    await _paiementsRepository.ModifierPaiement(idPaiement, paiement);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(paiement);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Paiement bis
            /// </summary>
            /// <param name="paiement">Objet contenu Paiement</param>
            /// <returns></returns>
            [HttpPut("{idPaiement}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierPaiementBis(DAL.EFEntities.Paiements paiement)
            {
                try
                {
                    await _paiementsRepository.ModifierPaiementBis(paiement);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(paiement);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un Paiement
            /// </summary>
            /// <param name="idPaiement">Identifiant de l'objet Paiement</param>
            /// <returns></returns>
            [HttpDelete("{idPaiement}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerPaiement(int idPaiement)
            {
                await _paiementsRepository.SupprimerPaiement(idPaiement);
                return NoContent();
            }


        //!\\A Vérifier!!!!//!\\

        //OK BON!!!!//
        /// <summary>
        /// Ensemble des Paiements pour un Coproprietaire déterminé
        /// </summary>
        /// <param name="idCoproprietaire">Identifiant du Coproprietaire</param>
        /// <returns></returns>
        [HttpGet("{idCoproprietaire}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Paiements>>> GetPaiementsForCopropietaire(string idCoproprietaire)
        {
            var ensemblePaiementss = await _paiementsRepository.GetPaiementsForCopropietaire(idCoproprietaire);

            if (ensemblePaiementss == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensemblePaiementss);
            }
        }

        //OK BON!!!!//
        /// <summary>
        /// Ensemble des Paiements pour un CompteBque déterminé
        /// </summary>
        /// <param name="idCompteBquePayeur">Identifiant du CompteBque</param>
        /// <returns></returns>
        [HttpGet("{idCompteBquePayeur}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Paiements>>> GetPaiementsFromCompteBquePayeur(int idCompteBquePayeur)
        {
            var ensemblePaiements = await _paiementsRepository.GetPaiementsFromCompteBquePayeur(idCompteBquePayeur);

            if (ensemblePaiements == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensemblePaiements);
            }
        }

    }
}
