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
    public class GroupesController : ControllerBase
    {
            private IGroupesRepository _groupesRepository;

            public GroupesController(IGroupesRepository groupesRepository)
            {
                _groupesRepository = groupesRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de tous les Groupes
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.Groupes>>> ListAllGroupes()
            {
                var listeGroupes = await _groupesRepository.ListAllGroupes();

                if (listeGroupes == null)
                {
                    return NotFound();
                }

                return Ok(listeGroupes.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails du Groupe
            /// </summary>
            /// <param name="idGroupe">Identifiant du Groupe</param>
            /// <returns></returns>
            [HttpGet("{idGroupe}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Groupes>> DetailsGroupe(int idGroupe)
            {
                var groupe = await _groupesRepository.DetailsGroupe(idGroupe);

                if (groupe == null)
                {
                    return NotFound();
                }
                return Ok(groupe);
            }



            //OK BON//Original
            /// <summary>
            /// Créer un Groupe
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouveauGroupe}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Groupes>> CreerGroupe(DAL.EFEntities.Groupes nouveauGroupe)
            {
                await _groupesRepository.CreerGroupe(nouveauGroupe);
                if (nouveauGroupe == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauGroupe);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Groupe
            /// </summary>
            /// <param name="idGroupe">Identifiant du Groupe</param>
            /// <param name="groupe">Objet contenu Groupe</param>
            /// <returns></returns>
            [HttpPut("{idGroupe}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierGroupe(int idGroupe, DAL.EFEntities.Groupes groupe)
            {
                if (idGroupe != groupe.IdGroupe)
                {
                    return NotFound();
                }

                try
                {
                    await _groupesRepository.ModifierGroupe(idGroupe, groupe);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(groupe);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Groupe bis
            /// </summary>
            /// <param name="groupe">Objet contenu Groupe</param>
            /// <returns></returns>
            [HttpPut("{idGroupe}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierGroupeBis(DAL.EFEntities.Groupes groupe)
            {
                try
                {
                    await _groupesRepository.ModifierGroupeBis(groupe);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(groupe);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un Groupe
            /// </summary>
            /// <param name="idGroupe">Identifiant de l'objet Groupe</param>
            /// <returns></returns>
            [HttpDelete("{idGroupe}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerGroupe(int idGroupe)
            {
                await _groupesRepository.SupprimerGroupe(idGroupe);
                return NoContent();
            }

    }
}
