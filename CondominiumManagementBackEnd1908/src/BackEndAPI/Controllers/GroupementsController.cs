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
    public class GroupementsController : ControllerBase
    {
            private IGroupementsRepository _groupementsRepository;

            public GroupementsController(IGroupementsRepository groupementsRepository)
            {
                _groupementsRepository = groupementsRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de tous les Groupements
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.Groupements>>> ListAllGroupements()
            {
                var listeGroupements = await _groupementsRepository.ListAllGroupements();

                if (listeGroupements == null)
                {
                    return NotFound();
                }

                return Ok(listeGroupements.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails du Groupement
            /// </summary>
            /// <param name="idGroupement">Identifiant du Groupement</param>
            /// <returns></returns>
            [HttpGet("{idGroupement}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Groupements>> DetailsGroupement(int idGroupement)
            {
                var groupement = await _groupementsRepository.DetailsGroupement(idGroupement);

                if (groupement == null)
                {
                    return NotFound();
                }
                return Ok(groupement);
            }



            //OK BON//Original
            /// <summary>
            /// Créer un Groupement
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouveauGroupement}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Groupements>> CreerGroupement(DAL.EFEntities.Groupements nouveauGroupement)
            {
                await _groupementsRepository.CreerGroupement(nouveauGroupement);
                if (nouveauGroupement == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauGroupement);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Groupement
            /// </summary>
            /// <param name="idGroupement">Identifiant du Groupement</param>
            /// <param name="groupement">Objet contenu Groupement</param>
            /// <returns></returns>
            [HttpPut("{idGroupement}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierGroupement(int idGroupement, DAL.EFEntities.Groupements groupement)
            {
                if (idGroupement != groupement.IdGroupement)
                {
                    return NotFound();
                }

                try
                {
                    await _groupementsRepository.ModifierGroupement(idGroupement, groupement);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(groupement);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Groupement bis
            /// </summary>
            /// <param name="groupement">Objet contenu Groupement</param>
            /// <returns></returns>
            [HttpPut("{idGroupement}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierGroupementBis(DAL.EFEntities.Groupements groupement)
            {
                try
                {
                    await _groupementsRepository.ModifierGroupementBis(groupement);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(groupement);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un Groupement
            /// </summary>
            /// <param name="idGroupement">Identifiant de l'objet Groupement</param>
            /// <returns></returns>
            [HttpDelete("{idGroupement}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerGroupement(int idGroupement)
            {
                await _groupementsRepository.SupprimerGroupement(idGroupement);
                return NoContent();
            }


            //!\\A Vérifier!!!!//!\\ ==> OK TOUS BON!!!!

            //OK BON!!!!//
            /// <summary>
            /// Ensemble des Groupes pour un Groupement déterminé
            /// </summary>
            /// <param name="idGroupement">Identifiant du Groupement</param>
            /// <returns></returns>
            [HttpGet("{idGroupement}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<Groupes>>> GetGroupesForGroupement(int idGroupement)
            {
                var ensembleGroupes = await _groupementsRepository.GetGroupeForGroupement(idGroupement);

                if (ensembleGroupes == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ensembleGroupes);
                }
            }
        
            //OK BON!!!!//
            /// <summary>
            /// Ensemble des Groupements pour un Lot déterminé
            /// </summary>
            /// <param name="idLot">Identifiant du Lot</param>
            /// <returns></returns>
            [HttpGet("{idLot}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<Groupements>>> GetGroupementForLot(int idLot)
            {
                var ensembleGroupements = await _groupementsRepository.GetGroupementForLot(idLot);

                if (ensembleGroupements == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ensembleGroupements);
                }
            }

            //OK BON!!!!//
            /// <summary>
            /// Ensemble des Groupements pour un Coproprietaire déterminé
            /// </summary>
            /// <param name="idCoproprietaire">Identifiant du  Coproprietaire</param>
            /// <returns></returns>
            [HttpGet("{idCoproprietaire}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<Groupements>>> GetGroupementsForCoproprietaire(string idCoproprietaire)
            {
                var ensembleGroupements = await _groupementsRepository.GetGroupementsForCoproprietaire(idCoproprietaire);

                if (ensembleGroupements == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ensembleGroupements);
                }
            }

            //OK BON!!!!//
            /// <summary>
            /// Ensemble des Groupements pour un Groupe déterminé
            /// </summary>
            /// <param name="idGroupe">Identifiant du Groupe</param>
            /// <returns></returns>
            [HttpGet("{idGroupe}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<Groupements>>> GetGroupementsForGroupe(int idGroupe)
            {
                var ensembleGroupements = await _groupementsRepository.GetGroupementsForGroupe(idGroupe);

                if (ensembleGroupements == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ensembleGroupements);
                }
            }

    }
}
