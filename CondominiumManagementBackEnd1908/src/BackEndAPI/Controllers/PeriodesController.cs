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
    public class PeriodesController : ControllerBase
    {
            private IPeriodesRepository _periodesRepository;

            public PeriodesController(IPeriodesRepository periodesRepository)
            {
                _periodesRepository = periodesRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de toutes les Periodes
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.Periodes>>> ListAllPeriodes()
            {
                var listePeriodes = await _periodesRepository.ListAllPeriodes();

                if (listePeriodes == null)
                {
                    return NotFound();
                }

                return Ok(listePeriodes.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails d'une Periode
            /// </summary>
            /// <param name="idPeriode">Identifiant d'une Periode</param>
            /// <returns></returns>
            [HttpGet("{idPeriode}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Periodes>> DetailsPeriode(int idPeriode)
            {
                var periode = await _periodesRepository.DetailsPeriode(idPeriode);

                if (periode == null)
                {
                    return NotFound();
                }
                return Ok(periode);
            }



            //OK BON//Original
            /// <summary>
            /// Créer une Periode
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouvellePeriode}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Periodes>> CreerNouvellePeriode(DAL.EFEntities.Periodes nouvellePeriode)
            {
                await _periodesRepository.CreerNouvellePeriode(nouvellePeriode);
                if (nouvellePeriode == null)
                {
                    return BadRequest();
                }
                return Ok(nouvellePeriode);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Periode
            /// </summary>
            /// <param name="idPeriode">Identifiant du Periode</param>
            /// <param name="periode">Objet contenu Periode</param>
            /// <returns></returns>
            [HttpPut("{idPeriode}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierPeriode(int idPeriode, DAL.EFEntities.Periodes periode)
            {
                if (idPeriode != periode.IdPeriode)
                {
                    return NotFound();
                }

                try
                {
                    await _periodesRepository.ModifierPeriode(idPeriode, periode);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(periode);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Periode bis
            /// </summary>
            /// <param name="periode">Objet contenu Periode</param>
            /// <returns></returns>
            [HttpPut("{idPeriode}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierPeriodeBis(DAL.EFEntities.Periodes periode)
            {
                try
                {
                    await _periodesRepository.ModifierPeriodeBis(periode);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(periode);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un Periode
            /// </summary>
            /// <param name="idPeriode">Identifiant de l'objet Periode</param>
            /// <returns></returns>
            [HttpDelete("{idPeriode}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerPeriode(int idPeriode)
            {
                await _periodesRepository.SupprimerPeriode(idPeriode);
                return NoContent();
            }


        //!\\A Vérifier!!!!//!\\

        //OK BON!!!!//
        /// <summary>
        /// Ensemble des Decomptes pour une Periode déterminée
        /// </summary>
        /// <param name="idPeriode">Identifiant de la Periode</param>
        /// <returns></returns>
        [HttpGet("{idPeriode}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Decomptes>>> GetDecomptesForPeriode(int idPeriode)
        {
            var ensembleDecomptes = await _periodesRepository.GetDecomptesForPeriode(idPeriode);

            if (ensembleDecomptes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensembleDecomptes);
            }
        }


        //OK BON!!!!//
        /// <summary>
        /// Periode pour un Decompte déterminé
        /// </summary>
        /// <param name="idDecompte">Identifiant du Decompte</param>
        /// <returns></returns>
        [HttpGet("{idDecompte}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Decomptes>> GetPeriodeForDecompte(int idDecompte)
        {
            var periode = await _periodesRepository.GetPeriodeForDecompte(idDecompte);

            if (periode == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(periode);
            }
        }

    }
}
