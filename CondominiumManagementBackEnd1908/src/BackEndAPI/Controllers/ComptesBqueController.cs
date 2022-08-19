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
    public class ComptesBqueController : ControllerBase
    {

            private IComptesBqueRepository _comptesBqueRepository;

            public ComptesBqueController(IComptesBqueRepository comptesBqueRepository)
            {
                _comptesBqueRepository = comptesBqueRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de tous les ComptesBque
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.ComptesBque>>> ListAllComptesBque()
            {
                var listeComptesBque = await _comptesBqueRepository.ListAllComptesBque();

                if (listeComptesBque == null)
                {
                    return NotFound();
                }

                return Ok(listeComptesBque.ToList());
            }
        
            //OK BON!!!!//
            /// <summary>
            /// Détails du CompteBque
            /// </summary>
            /// <param name="idCompteBque">Identifiant du CompteBque</param>
            /// <returns></returns>
            [HttpGet("{idCompteBque}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.ComptesBque>> DetailsCompteBque(int idCompteBque)
            {
                var compteBque = await _comptesBqueRepository.DetailsComptesBque(idCompteBque);

                if (compteBque == null)
                {
                    return NotFound();
                }
                return Ok(compteBque);
            }

            //OK BON//Original
            /// <summary>
            /// Créer un CompteBque
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouveauCompteBque}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.ComptesBque>> CreerCompteBque(DAL.EFEntities.ComptesBque nouveauCompteBque)
            {
                await _comptesBqueRepository.CreerCompteBque(nouveauCompteBque);
                if (nouveauCompteBque == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauCompteBque);
            }

            //OK BON//
            /// <summary>
            /// Modifier un CompteBque
            /// </summary>
            /// <param name="idCompteBque">Identifiant du CompteBque</param>
            /// <param name="compteBque">Objet contenu compteBque</param>
            /// <returns></returns>
            [HttpPut("{idCompteBque}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierCompteBque(int idCompteBque, DAL.EFEntities.ComptesBque compteBque)
            {
                if (idCompteBque != compteBque.IdCompteBque)
                {
                    return NotFound();
                }

                try
                {
                    await _comptesBqueRepository.ModifierCompteBque(idCompteBque, compteBque);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(compteBque);
            }

            //OK BON//
            /// <summary>
            /// Modifier un CompteBque bis
            /// </summary>
            /// <param name="compteBque">Objet contenu CompteBque</param>
            /// <returns></returns>
            [HttpPut("{idCompteBque}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierCompteBqueBis(DAL.EFEntities.ComptesBque compteBque)
            {
                try
                {
                    await _comptesBqueRepository.ModifierCompteBqueBis(compteBque);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(compteBque);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un CompteBque
            /// </summary>
            /// <param name="idCompteBque">Identifiant de l'objet CompteBque</param>
            /// <returns></returns>
            [HttpDelete("{idCompteBque}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerCompteBque(int idCompteBque)
            {
                await _comptesBqueRepository.SupprimerCompteBque(idCompteBque);
                return NoContent();
            }

        /*
            //!\\A Vérifier!!!!//!\\ ==> PAS BON!!!!

            //OK BON//
            /// <summary>
            /// Ensemble de ComptesBque pour un Coproprietaire déterminée
            /// </summary>
            /// <param name="coproprietaire"></param>
            /// <returns></returns>
            [HttpGet("coproprietaire}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IEnumerable<ComptesBque>> GetComptesBqueForCoproprietaire(string idCoproprietaire)
            {
                var comptesBque = await _comptesBqueRepository.GetComptesBqueForCoproprietaire(idCoproprietaire);

                if (comptesBque == null)
                {
                    return (IEnumerable<ComptesBque>)NotFound();
                }

                return (IEnumerable<ComptesBque>)Ok(comptesBque);
            }
        */
    }
}



