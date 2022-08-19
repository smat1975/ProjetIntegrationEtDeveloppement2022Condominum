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
    public class LignesDocumentsFournisseursController : ControllerBase
    {
        private ILignesDocumentsFournisseursRepository _lignesDocumentsFournisseursRepository;

        public LignesDocumentsFournisseursController(ILignesDocumentsFournisseursRepository lignesDocumentsFournisseursRepository)
        {
            _lignesDocumentsFournisseursRepository = lignesDocumentsFournisseursRepository;
        }

     
        //OK BON!!!!//
        /// <summary>
        /// Créer une nouvelle LigneDocumentFournisseur
        /// </summary>
        /// <param name="nouvelleLigneDocumentFournisseur">Objet LigneDocumentFournisseur</param>
        /// <returns></returns>
        [HttpPost("{nouvelleLigneDocumentFournisseur}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LignesDocumentsFournisseurs>> CreerLigneDocumentFournisseur(LignesDocumentsFournisseurs nouvelleLigneDocumentFournisseur)
        {
            await _lignesDocumentsFournisseursRepository.CreerLigneDocumentFournisseur(nouvelleLigneDocumentFournisseur);

            if (nouvelleLigneDocumentFournisseur == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(nouvelleLigneDocumentFournisseur);
            }
        }
        //OK BON!!!!//
        /// <summary>
        /// Créer une nouvelle LigneDocumentFournisseur
        /// </summary>
        /// <param name="nouvelleLigneDocumentFournisseur">Objet LignesDocumentsFournisseurs</param>
        /// <returns></returns>
        [HttpGet("{nouvelleLigneDocumentFournisseur}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LignesDocumentsFournisseurs>> CreerLigneDocumentFournisseurTer(LignesDocumentsFournisseurs nouvelleLigneDocumentFournisseur)
        {
            await _lignesDocumentsFournisseursRepository.CreerLigneDocumentFournisseurTer(nouvelleLigneDocumentFournisseur);

            if (nouvelleLigneDocumentFournisseur == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(nouvelleLigneDocumentFournisseur);
            }
        }

        //OK BON!!!!//
        /// <summary>
        /// Details d'une LigneDocumentFournisseur
        /// </summary>
        /// <param name="idLigneDecompte">Identifiant de la LigneDocumentFournisseur</param>
        /// <returns></returns>
        [HttpGet("{idLigneDocumentFournisseur}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LignesDocumentsFournisseurs>> DetailsLigneDocumentFournisseur(int idLigneDocumentFournisseur)
        {
            var ligneDocumentFournisseur = await _lignesDocumentsFournisseursRepository.DetailsLigneDocumentFournisseur(idLigneDocumentFournisseur);


            if (ligneDocumentFournisseur == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ligneDocumentFournisseur);
            }
        }

        //OK BON//
        /// <summary>
        /// Liste de toutes les LignesDocumentsFournisseurs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.LignesDocumentsFournisseurs>>> ListAllLignesDocumentsFournisseur()
        {
            var listeLignesDocumentsFournisseurs = await _lignesDocumentsFournisseursRepository.ListAllLignesDocumentsFournisseurs();

            if (listeLignesDocumentsFournisseurs == null)
            {
                return NotFound();
            }

            return Ok(listeLignesDocumentsFournisseurs);
        }

        //OK BON//
        /// <summary>
        /// Modifier une LigneDocumentFournisseur
        /// </summary>
        /// <param name="idLigneDocumentFournisseur">Identifiant de la LigneDocumentFournisseur</param>
        /// <param name="ligneDocumentFournisseur">Objet contenu LigneDocumentFournisseur</param>
        /// <returns></returns>
        [HttpPut("{idLigneDocumentFournisseur}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ModifierLigneDocumentFournisseur(int idLigneDocumentFournisseur, DAL.EFEntities.LignesDocumentsFournisseurs ligneDocumentFournisseur)
        {
            if (idLigneDocumentFournisseur != ligneDocumentFournisseur.IdLigneDocumentFournisseur)
            {
                return NotFound();
            }

            try
            {
                await _lignesDocumentsFournisseursRepository.ModifierLigneDocumentFournisseur(idLigneDocumentFournisseur, ligneDocumentFournisseur);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(ligneDocumentFournisseur);
        }


        //OK BON//
        /// <summary>
        /// Modifier une LigneDocumentFournisseur bis
        /// </summary>
        /// <param name="ligneDocumentFournisseur">Objet contenu LigneocumentFournisseur</param>
        /// <returns></returns>
        [HttpPut("{idLigneDocumentFournisseur}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModifierDocumentFournisseurBis(DAL.EFEntities.LignesDocumentsFournisseurs ligneDocumentFournisseur)
        {
            try
            {
                await _lignesDocumentsFournisseursRepository.ModifierLigneDocumentFournisseurBis(ligneDocumentFournisseur);

            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(ligneDocumentFournisseur);
        }

        //OK BON//
        /// <summary>
        /// Supprimer une LigneDocumentFournisseur
        /// </summary>
        /// <param name="idLigneDocumentFournisseur">Identifiant de l'objet LigneDocumentFournisseur</param>
        /// <returns></returns>
        [HttpDelete("{idLigneDocumentFournisseur}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SupprimerLigneDocumentFournisseur(int idLigneDocumentFournisseur)
        {
            await _lignesDocumentsFournisseursRepository.SupprimerLigneDocumentFournisseur(idLigneDocumentFournisseur);
            return NoContent();
        }


        //!\\A Vérifier!!!!//!\\

        //OK BON!!!!//
        /// <summary>
        /// Ensemble des LignesDocumentsFournisseurs pour un DocumentFournisseur déterminé
        /// </summary>
        /// <param name="ididDocumentFournisseur">Identifiant du DocumentFournisseur</param>
        /// <returns></returns>
        [HttpGet("{idDocumentFournisseur}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<LignesDocumentsFournisseurs>>> GetLignesDocumentsFournisseursForCoproprietaire(int idDocumentFournisseur)
        {
            var ensembleLignesDocumentsFournisseurs = await _lignesDocumentsFournisseursRepository.GetLignesDocumentsFournisseursForCoproprietaire(idDocumentFournisseur);

            if (ensembleLignesDocumentsFournisseurs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensembleLignesDocumentsFournisseurs);
            }
        }

    }
}
