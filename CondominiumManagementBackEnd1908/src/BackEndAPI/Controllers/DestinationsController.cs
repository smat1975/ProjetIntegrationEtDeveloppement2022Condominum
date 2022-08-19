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
    public class DestinationsController : ControllerBase
    {

        private IDestinationsRepository _destinationsRepository;

        public DestinationsController(IDestinationsRepository destinationsRepository)
        {
            _destinationsRepository = destinationsRepository;
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Destinations
        /// </summary>
        /// <returns></returns>
        [HttpGet("listalldestinations/")]
        [Route("listalldestinations/")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.Destinations>>> ListAllDestinations()
        {
            var listeDestinations = await _destinationsRepository.ListAllDestinations();

            if (listeDestinations == null)
            {
                return NotFound();
            }

            return Ok(listeDestinations.ToList());
        }

        //OK BON!!!!//
        /// <summary>
        /// Détails de la Destination
        /// </summary>
        /// <param name="idDestination">Identifiant du Destination</param>
        /// <returns></returns>
        [HttpGet("detailsdestination/{idDestination}")]
        [Route("detailsdestination/{idDestination}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Destinations>> DetailsDestination(int idDestination)
        {
            var destination = await _destinationsRepository.DetailsDestination(idDestination);

            if (destination == null)
            {
                return NotFound();
            }
            return Ok(destination);
        }



        //OK BON//Original
        /// <summary>
        /// Créer une Destination
        /// </summary>
        /// <returns></returns>
        [HttpPost("creerdestination/{nouvelleDestination}")]
        [Route("creerdestination/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Destinations>> CreerDestination(DAL.EFEntities.Destinations nouvelleDestination)
        {
            await _destinationsRepository.CreerDestination(nouvelleDestination);
            if (nouvelleDestination == null)
            {
                return BadRequest();
            }
            return Ok(nouvelleDestination);
        }


        //OK BON//De Microsoft
        /// <summary>
        /// Créer une Destination Retry
        /// </summary>
        /// <returns></returns>
        [HttpPost("creerdestinationretry/{nouvelleDestination}")]
        [Route("creerdestinationretry/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreerDestinationRetry(DAL.EFEntities.Destinations nouvelleDestination)
        {
            if (nouvelleDestination == null)
            {
                return BadRequest();
            }
            await _destinationsRepository.CreerDestinationRetry(nouvelleDestination);
            return Ok(nouvelleDestination);

        }

        //OK BON//
        /// <summary>
        /// Modifier une Destination
        /// </summary>
        /// <param name="idDestination">Identifiant du Destination</param>
        /// <param name="destination">Objet contenu Destination</param>
        /// <returns></returns>
        [HttpPut("modifierdestination/{idDestination}")]
        [Route("modifierdestination/{idDestination}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ModifierDestination(int idDestination, DAL.EFEntities.Destinations destination)
        {
            if (idDestination != destination.IdDestination)
            {
                return NotFound();
            }

            try
            {
                await _destinationsRepository.ModifierDestination(idDestination, destination);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(destination);
        }

        //OK BON//
        /// <summary>
        /// Modifier une Destination bis
        /// </summary>
        /// <param name="destination">Objet contenu Destination</param>
        /// <returns></returns>
        [HttpPut("modifierdestinationbis/{idDestination}")]
        [Route("modifierdestinationbis/{idDestination}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModifierDestinationBis(DAL.EFEntities.Destinations destination)
        {
            try
            {
                await _destinationsRepository.ModifierDestinationBis(destination);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(destination);
        }

        //OK BON//
        /// <summary>
        /// Supprimer une Destination
        /// </summary>
        /// <param name="idDestination">Identifiant de l'objet Destination</param>
        /// <returns></returns>
        [HttpDelete("supprimerdestination/{idDestination}")]
        [Route("supprimerdestination/{idDestination}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> SupprimerDestination(int idDestination)
        {
            await _destinationsRepository.SupprimerDestination(idDestination);
            return NoContent();
        }


        //!\\A Vérifier!!!!//!\\ ==> PAS BON!!!!

/*
        //OK BON//
        /// <summary>
        /// Obtenir la Destination d'un/des Message(s) pour un Coproprietaire déterminé
        /// </summary>
        /// <param name="idCoprorpietaire">Identifiant de l'objet Coproprietaire</param>
        /// <returns></returns>
        [HttpDelete("{idCoproprietaire}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetDestinationsForCoproprietaire(string idCoproprietaire)
        {

            var listeDestinations = await _destinationsRepository.GetDestinationsForCoproprietaire(idCoproprietaire);

            if (listeDestinations == null)
            {
                return NotFound();
            }

            return Ok(listeDestinations.ToList());

        }

        //OK BON//
        /// <summary>
        /// Obtenir la Destination d'un/des Message(s) déterminé
        /// </summary>
        /// <param name="idMessage">Identifiant de l'objet Message</param>
        /// <returns></returns>
        [HttpDelete("{idMessage}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetDestinationsForMessage(int idMessage)
        {

            var listeDestinations = await _destinationsRepository.GetDestinationsForMessage(idMessage);

            if (listeDestinations == null)
            {
                return NotFound();
            }

            return Ok(listeDestinations);
        }
*/
    }
}
