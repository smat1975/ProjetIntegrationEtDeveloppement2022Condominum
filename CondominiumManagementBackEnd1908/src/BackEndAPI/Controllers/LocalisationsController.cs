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
    public class LocalisationsController : ControllerBase
    {
        private ILocalisationsRepository _localisationsRepository;

        public LocalisationsController(ILocalisationsRepository localisationsRepository)
        {
            _localisationsRepository = localisationsRepository;
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Localisations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.Localisations>>> ListAllLocalisations()
        {
            var listeLocalisations = await _localisationsRepository.ListAllLocalisations();

            if (listeLocalisations == null)
            {
                return NotFound();
            }

            return Ok(listeLocalisations.ToList());
        }

        //OK BON!!!!//
        /// <summary>
        /// Détails de la Localisation
        /// </summary>
        /// <param name="idLocalisation">Identifiant de la Localisation</param>
        /// <returns></returns>
        [HttpGet("{idLocalisation}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Coproprietaires>> DetailsLocalisation(int idLocalisation)
        {
            var localisation = await _localisationsRepository.DetailsLocalisation(idLocalisation);

            if (localisation == null)
            {
                return NotFound();
            }
            return Ok(localisation);
        }



        //OK BON//Original
        /// <summary>
        /// Créer une Localisation
        /// </summary>
        /// <returns></returns>
        [HttpPost("{nouvelleLocalisation}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Localisations>> CreerLocalisation(DAL.EFEntities.Localisations nouvelleLocalisation)
        {
            await _localisationsRepository.CreerLocalisation(nouvelleLocalisation);
            if (nouvelleLocalisation == null)
            {
                return BadRequest();
            }
            return Ok(nouvelleLocalisation);
        }

        //OK BON//
        /// <summary>
        /// Modifier une Localisation
        /// </summary>
        /// <param name="idLocalisation">Identifiant de la Localisation</param>
        /// <param name="localisations">Objet contenu Localisation</param>
        /// <returns></returns>
        [HttpPut("{idLocalisation}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ModifierLocalisation(int idLocalisation, DAL.EFEntities.Localisations localisation)
        {
            if (idLocalisation != localisation.IdLocalisation)
            {
                return NotFound();
            }

            try
            {
                await _localisationsRepository.ModifierLocalisation(idLocalisation, localisation);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(localisation);
        }

        //OK BON//
        /// <summary>
        /// Modifier une Localisation bis
        /// </summary>
        /// <param name="localisation">Objet contenu Localisation</param>
        /// <returns></returns>
        [HttpPut("{idLocalisation}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModifierLocalisationBis(DAL.EFEntities.Localisations localisation)
        {
            try
            {
                await _localisationsRepository.ModifierLocalisationBis(localisation);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(localisation);
        }

        //OK BON//
        /// <summary>
        /// Supprimer une Localisation
        /// </summary>
        /// <param name="idLocalisation">Identifiant de l'objet Localisation</param>
        /// <returns></returns>
        [HttpDelete("{idLocalisations}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> SupprimerLocalisation(int idLocalisation)
        {
            await _localisationsRepository.SupprimerLocalisation(idLocalisation);
            return NoContent();
        }


        //!\\A Vérifier!!!!//!\\


        //OK BON!!!!//
        /// <summary>
        /// Localisation pour un Lot déterminé
        /// </summary>
        /// <param name="idLot">Identifiant du Lot</param>
        /// <returns></returns>
        [HttpGet("{idLot}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Lots>>> GetLocalisationForLot(int idLot)
        {
            var localisation = await _localisationsRepository.GetLocalisationForLot(idLot);

            if (localisation == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(localisation);
            }
        }

    }
}
