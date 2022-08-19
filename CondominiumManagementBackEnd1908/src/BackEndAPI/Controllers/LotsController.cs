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
    public class LotsController : ControllerBase
    {

            private ILotsRepository _lotsRepository;

            public LotsController(ILotsRepository lotsRepository)
            {
                _lotsRepository = lotsRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de tous les Lots
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.Lots>>> ListAllLots()
            {
                var listeLots = await _lotsRepository.ListAllLots();

                if (listeLots == null)
                {
                    return NotFound();
                }

                return Ok(listeLots.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails du Lot
            /// </summary>
            /// <param name="idLot">Identifiant du Lot</param>
            /// <returns></returns>
            [HttpGet("{idLot}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Lots>> DetailsLot(int idLot)
            {
                var lot = await _lotsRepository.DetailsLot(idLot);

                if (lot == null)
                {
                    return NotFound();
                }
                return Ok(lot);
            }



            //OK BON//Original
            /// <summary>
            /// Créer un Lot
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouveauLot}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Lots>> CreerLot(DAL.EFEntities.Lots nouveauLot)
            {
                await _lotsRepository.CreerLot(nouveauLot);
                if (nouveauLot == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauLot);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Lot
            /// </summary>
            /// <param name="idLot">Identifiant du Lot</param>
            /// <param name="lot">Objet contenu Lot</param>
            /// <returns></returns>
            [HttpPut("{idLot}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierLot(int idLot, DAL.EFEntities.Lots lot)
            {
                if (idLot != lot.IdLot)
                {
                    return NotFound();
                }

                try
                {
                    await _lotsRepository.ModifierLot(idLot, lot);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(lot);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Lot bis
            /// </summary>
            /// <param name="lot">Objet contenu Lot</param>
            /// <returns></returns>
            [HttpPut("{idLot}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierLotBis(DAL.EFEntities.Lots lot)
            {
                try
                {
                    await _lotsRepository.ModifierLotBis(lot);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(lot);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un Lot
            /// </summary>
            /// <param name="idLot">Identifiant de l'objet Lot</param>
            /// <returns></returns>
            [HttpDelete("{idLot}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerLot(int idLot)
            {
                await _lotsRepository.SupprimerLot(idLot);
                return NoContent();
            }


        //!\\A Vérifier!!!!//!\\


        //OK BON!!!!//
        /// <summary>
        /// LotLot pour une Copropriete déterminé
        /// </summary>
        /// <param name="idCopropriete">Identifiant de la Copropriete</param>
        /// <returns></returns>
        [HttpGet("{idCopropriete}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Lots>> GetLotForCopropriete(int idCopropriete)
        {
            var lot = await _lotsRepository.GetLotForCopropriete(idCopropriete);

            if (lot == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lot);
            }
        }


        //OK BON!!!!//
        /// <summary>
        /// Ensemble des Lots pour un Coproprietaire déterminé
        /// </summary>
        /// <param name="idCoproprietaire">Identifiant du Coproprietaire</param>
        /// <returns></returns>
        [HttpGet("{idCoproprietaire}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Lots>>> GetLotsForCopropietaire(string idCoproprietaire)
        {
            var ensembleLots = await _lotsRepository.GetLotsForCopropietaire(idCoproprietaire);

            if (ensembleLots == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensembleLots);
            }
        }

    }
}
