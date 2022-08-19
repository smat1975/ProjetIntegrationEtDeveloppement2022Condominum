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

    public class CoproprietairesController : ControllerBase
        {

            private ICoproprietairesRepository _coproprietairesRepository;

            public CoproprietairesController(ICoproprietairesRepository coproprietairesRepository)
            {
                _coproprietairesRepository = coproprietairesRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de tous les Coproprietaires
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.Coproprietaires>>> ListAllCoproprietaires()
            {
                var listeCoproprietaires = await _coproprietairesRepository.ListAllCoproprietaires();

                if (listeCoproprietaires == null)
                {
                    return NotFound();
                }

                return Ok(listeCoproprietaires.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails du Coproprietaire
            /// </summary>
            /// <param name="idCoproprietaire">Identifiant du Coproprietaire</param>
            /// <returns></returns>
            [HttpGet("{idCoproprietaire}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Coproprietaires>> DetailsCoproprietaire(string idCoproprietaire)
            {
                var coproprietaire = await _coproprietairesRepository.DetailsCoproprietaires(idCoproprietaire);

                if (coproprietaire == null)
                {
                    return NotFound();
                }
                return Ok(coproprietaire);
            }



            //OK BON//Original
            /// <summary>
            /// Créer un Coproprietaire
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouveauCoproprietaire}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Coproprietaires>> CreerCoproprietaire(DAL.EFEntities.Coproprietaires nouveauCoproprietaire)
            {
                await _coproprietairesRepository.CreerCoproprietaire(nouveauCoproprietaire);
                if (nouveauCoproprietaire == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauCoproprietaire);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Coproprietaire
            /// </summary>
            /// <param name="idCoproprietaire">Identifiant du Coproprietaire</param>
            /// <param name="coproprietaire">Objet contenu Coproprietaire</param>
            /// <returns></returns>
            [HttpPut("{idCoproprietaire}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierCoproprietaire(string idCoproprietaire, DAL.EFEntities.Coproprietaires coproprietaire)
            {
                if (idCoproprietaire != coproprietaire.IdCoproprietaire)
                {
                    return NotFound();
                }

                try
                {
                    await _coproprietairesRepository.ModifierCoproprietaire(idCoproprietaire, coproprietaire);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(coproprietaire);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Coproprietaire bis
            /// </summary>
            /// <param name="coproprietaire">Objet contenu Coproprietaire</param>
            /// <returns></returns>
            [HttpPut("{idCoproprietaire}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierCoproprietaireBis(DAL.EFEntities.Coproprietaires coproprietaire)
            {
                try
                {
                    await _coproprietairesRepository.ModifierCoproprietaireBis(coproprietaire);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(coproprietaire);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un Coproprietaire
            /// </summary>
            /// <param name="idCoproprietaire">Identifiant de l'objet Coproprietaire</param>
            /// <returns></returns>
            [HttpDelete("{idCoproprietaire}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerCoproprietaire(string idCoproprietaire)
            {
                await _coproprietairesRepository.SupprimerCoproprietaire(idCoproprietaire);
                return NoContent();
            }
    }
}
