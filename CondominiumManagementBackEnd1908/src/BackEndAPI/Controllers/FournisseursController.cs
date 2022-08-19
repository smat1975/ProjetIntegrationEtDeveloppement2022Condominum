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
    public class FournisseursController : ControllerBase
    {
            private IFournisseursRepository _fournisseursRepository;

            public FournisseursController(IFournisseursRepository fournisseursRepository)
            {
                _fournisseursRepository = fournisseursRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de tous les Fournisseurs
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.Fournisseurs>>> ListAllFournisseurs()
            {
                var listeFournisseurs = await _fournisseursRepository.ListAllFournisseurs();

                if (listeFournisseurs == null)
                {
                    return NotFound();
                }

                return Ok(listeFournisseurs.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails du Fournisseur
            /// </summary>
            /// <param name="idFournisseur">Identifiant du Fournisseur</param>
            /// <returns></returns>
            [HttpGet("{idFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Fournisseurs>> DetailsFournisseur(int idFournisseur)
            {
                var fournisseur = await _fournisseursRepository.DetailsFournisseur(idFournisseur);

                if (fournisseur == null)
                {
                    return NotFound();
                }
                return Ok(fournisseur);
            }



            //OK BON//Original
            /// <summary>
            /// Créer un Fournisseur
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouveauFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Fournisseurs>> CreerFournisseur(DAL.EFEntities.Fournisseurs nouveauFournisseur)
            {
                await _fournisseursRepository.CreerFournisseur(nouveauFournisseur);
                if (nouveauFournisseur == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauFournisseur);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Fournisseur
            /// </summary>
            /// <param name="idFournisseur">Identifiant du Fournisseur</param>
            /// <param name="fournisseur">Objet contenu Fournisseur</param>
            /// <returns></returns>
            [HttpPut("{idFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierFournisseur(int idFournisseur, DAL.EFEntities.Fournisseurs fournisseur)
            {
                if (idFournisseur != fournisseur.IdFournisseur)
                {
                    return NotFound();
                }

                try
                {
                    await _fournisseursRepository.ModifierFournisseur(idFournisseur, fournisseur);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(fournisseur);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Fournisseur bis
            /// </summary>
            /// <param name="fournisseur">Objet contenu Fournisseur</param>
            /// <returns></returns>
            [HttpPut("{idFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierFournisseurBis(DAL.EFEntities.Fournisseurs fournisseur)
            {
                try
                {
                    await _fournisseursRepository.ModifierFournisseurBis(fournisseur);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(fournisseur);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un Fournisseur
            /// </summary>
            /// <param name="idFournisseur">Identifiant de l'objet Fournisseur</param>
            /// <returns></returns>
            [HttpDelete("{idFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerFournisseur(int idFournisseur)
            {
                await _fournisseursRepository.SupprimerFournisseur(idFournisseur);
                return NoContent();
            }

        /*
            //!\\A Vérifier!!!!//!\\

            //OK BON!!!!//
            /// <summary>
            /// Fournisseur pour un DocumentFournisseur déterminé
            /// </summary>
            /// <param name="idDocumentFournisseur">Identifiant du Fournisseur</param>
            /// <returns></returns>
            [HttpGet("{idDocumentFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<Fournisseurs>> GetFournisseurForDocumentFournisseur(int idDocumentFournisseur)
            {
                var fournisseur = await _fournisseursRepository.GetFournisseurForDocumentFournisseur(idDocumentFournisseur);

                if (fournisseur == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(fournisseur);
                }
            }
        */
    }
}
