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
    public class DocumentsFournisseursController : ControllerBase
    {
            private IDocumentsFournisseursRepository _documentsFournisseursRepository;

            public  DocumentsFournisseursController(IDocumentsFournisseursRepository  documentsFournisseursRepository)
            {
                _documentsFournisseursRepository =  documentsFournisseursRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de tous les DocumentsFournisseurs
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.DocumentsFournisseurs>>> ListAllDocumentsFournisseur()
            {
                var listeDocumentsFournisseurs = await _documentsFournisseursRepository.ListAllDocumentsFournisseur();

                if (listeDocumentsFournisseurs == null)
                {
                    return NotFound();
                }

                return Ok(listeDocumentsFournisseurs.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails du DocumentFournisseur
            /// </summary>
            /// <param name="id DocumentFournisseur">Identifiant du DocumentFournisseur</param>
            /// <returns></returns>
            [HttpGet("{idDocumentFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.DocumentsFournisseurs>> DetailsDocumentFournisseur(int idDocumentFournisseur)
            {
                var  documentFournisseur = await _documentsFournisseursRepository.DetailsDocumentFournisseur(idDocumentFournisseur);

                if (documentFournisseur == null)
                {
                    return NotFound();
                }
                return Ok(documentFournisseur);
            }



            //OK BON//Original
            /// <summary>
            /// Créer un DocumentFournisseur
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouveauDocumentFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.DocumentsFournisseurs>> CreerDocumentFournisseur(DAL.EFEntities.DocumentsFournisseurs nouveauDocumentFournisseur)
            {
                await _documentsFournisseursRepository.CreerDocumentFournisseur(nouveauDocumentFournisseur);
                if (nouveauDocumentFournisseur == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauDocumentFournisseur);
            }

            //OK BON//
            /// <summary>
            /// Modifier un DocumentFournisseur
            /// </summary>
            /// <param name="idDocumentFournisseur">Identifiant du DocumentFournisseur</param>
            /// <param name="documentFournisseur">Objet contenu DocumentFournisseur</param>
            /// <returns></returns>
            [HttpPut("{idDocumentFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierDocumentFournisseur(int idDocumentFournisseur, DAL.EFEntities.DocumentsFournisseurs documentFournisseur)
            {
                if (idDocumentFournisseur != documentFournisseur.IdDocumentFournisseur)
                {
                    return NotFound();
                }

                try
                {
                    await _documentsFournisseursRepository.ModifierDocumentFournisseur(idDocumentFournisseur, documentFournisseur);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(documentFournisseur);
            }

            //OK BON//
            /// <summary>
            /// Modifier un DocumentFournisseur bis
            /// </summary>
            /// <param name="documentFournisseur">Objet contenu DocumentFournisseur</param>
            /// <returns></returns>
            [HttpPut("{idDocumentFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierDocumentFournisseurBis(DAL.EFEntities.DocumentsFournisseurs documentFournisseur)
            {
                try
                {
                    await _documentsFournisseursRepository.ModifierDocumentFournisseurBis(documentFournisseur);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(documentFournisseur);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un DocumentFournisseur
            /// </summary>
            /// <param name="idDocumentFournisseur">Identifiant de l'objet DocumentFournisseur</param>
            /// <returns></returns>
            [HttpDelete("{idDocumentFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult> SupprimerDocumentFournisseur(int idDocumentFournisseur)
            {
                await _documentsFournisseursRepository.SupprimerDocumentFournisseur(idDocumentFournisseur);
                return NoContent();
            }


            //!\\A Vérifier!!!!//!\\
/*
            //PAS BON//\\A MODIFIER!!!!//\\
            /// <summary>
            /// Ajouter une nouvelle LignesDocumentFournisseur à un DocumentFournisseur
            /// <param name="nouvelleLigneDocumentFournisseur"></param>
            /// <param name="documentFournisseur"></param>
            /// <returns></returns>
            [HttpPut("{nouvelleLigneDocumentFournisseur}, {documentFournisseur},")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DocumentsFournisseurs>> AjouterLignesDocumentFournisseurADocumentFournisseur(LignesDocumentsFournisseurs nouvelleLigneDocumentFournisseur, DocumentsFournisseurs documentFournisseur)
            {
                try
                {
                    await _documentsFournisseursRepository.AjouterLignesDocumentFournisseurADocumentFournisseur(nouvelleLigneDocumentFournisseur, documentFournisseur);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok();
            }
*/
            //OK BON!!!!//
            /// <summary>
            /// Ensemble des DocumentsFournisseur pour un Fournisseur déterminé
            /// </summary>
            /// <param name="idFournisseur">Identifiant du Fournisseur</param>
            /// <returns></returns>
            [HttpGet("{idFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DocumentsFournisseurs>>> GetDocumentsFournisseurForFournisseur(int idFournisseur)
            {
                var ensembleDocumentsFournisseurs = await _documentsFournisseursRepository.GetDocumentsFournisseurForFournisseur(idFournisseur);

                if (ensembleDocumentsFournisseurs == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ensembleDocumentsFournisseurs);
                }
            }
    }
}
