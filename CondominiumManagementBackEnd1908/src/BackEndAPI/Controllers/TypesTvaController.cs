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
    public class TypesTvaController : ControllerBase
    {

        private ITypesTvaRepository _typesTvaRepository;

        public TypesTvaController(ITypesTvaRepository typesTvaRepository)
        {
            _typesTvaRepository = typesTvaRepository;
        }


        //OK BON//
        /// <summary>
        /// Liste de tous les TypesTva
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.TypesTva>>> ListAllTypesTva()
        {
            var listeTypesTva = await _typesTvaRepository.ListAllTypesTva();

            if (listeTypesTva == null)
            {
                return NotFound();
            }

            return Ok(listeTypesTva.ToList());
        }

        //OK BON!!!!//
        /// <summary>
        /// Détails du TypeTva
        /// </summary>
        /// <param name="idTypeTva">Identifiant du TypeTva</param>
        /// <returns></returns>
        [HttpGet("{idTypeTva}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.TypesTva>> DetailsTypeTva(int idTypeTva)
        {
            var typeTva = await _typesTvaRepository.DetailsTypeTva(idTypeTva);

            if (typeTva == null)
            {
                return NotFound();
            }
            return Ok(typeTva);
        }


        //OK BON//Original
        /// <summary>
        /// Créer un TypeTva
        /// </summary>
        /// <returns></returns>
        [HttpPost("{nouveauTypeTva}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.TypesTva>> CreerTypeTva(DAL.EFEntities.TypesTva nouveauTypeTva)
        {
            await _typesTvaRepository.CreerTypeTva(nouveauTypeTva);
            if (nouveauTypeTva == null)
            {
                return BadRequest();
            }
            return Ok(nouveauTypeTva);
        }

        //OK BON//
        /// <summary>
        /// Modifier un TypeTva
        /// </summary>
        /// <param name="idTypeTva">Identifiant du TypeTva</param>
        /// <param name="typeTva">Objet contenu TypeTva</param>
        /// <returns></returns>
        [HttpPut("{idTypeTva}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ModifierTypeTva(int idTypeTva, DAL.EFEntities.TypesTva typeTva)
        {
            if (idTypeTva != typeTva.IdTypeTva)
            {
                return NotFound();
            }

            try
            {
                await _typesTvaRepository.ModifierTypeTva(idTypeTva, typeTva);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(typeTva);
        }

        //OK BON//
        /// <summary>
        /// Modifier un TypeTva bis
        /// </summary>
        /// <param name="typeTva">Objet contenu TypeTva</param>
        /// <returns></returns>
        [HttpPut("{idTypeTva}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModifierTypeTvaBis(DAL.EFEntities.TypesTva typeTva)
        {
            try
            {
                await _typesTvaRepository.ModifierTypeTvaBis(typeTva);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(typeTva);
        }

        //OK BON//
        /// <summary>
        /// Supprimer un TypeTva
        /// </summary>
        /// <param name="idTypeTva">Identifiant de l'objet TypeTva</param>
        /// <returns></returns>
        [HttpDelete("{idTypeTva}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> SupprimerTypeTva(int idTypeTva)
        {
            await _typesTvaRepository.SupprimerTypeTva(idTypeTva);
            return NoContent();
        }

        //!\\A Vérifier!!!!//!\\

        //OK BON!!!!//
        /// <summary>
        /// Obtenir le TypeTva d'un Decompte
        /// </summary>
        /// <param name="idDecompte">Identifiant du Decompte</param>
        /// <returns></returns>
        [HttpGet("{idDecompte}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Decomptes>>> GetTypesTvaForDecompte(int idDecompte)
        {
            var typeTva = await _typesTvaRepository.GetTypesTvaForDecompte(idDecompte);

            if (typeTva == null)
            {
                return NotFound();
            }
            return Ok(typeTva);
        }

        //OK BON!!!!//
        /// <summary>
        /// Obtenir le Type Tva d'une LignesDocumentsFournisseurs
        /// </summary>
        /// <param name="idLigneDocumentFournissseur">Identifiant de la LigneDocumentFournissseur</param>
        /// <returns></returns>
        [HttpGet("{idLigneDocumentFournissseur}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LignesDocumentsFournisseurs>> GetTypesTvaForLigneDocumentFournissseur(int idLigneDocumentFournisseur)
        {
            var typeTva = await _typesTvaRepository.GetTypesTvaForLigneDocumentFournissseur(idLigneDocumentFournisseur);

            if (typeTva == null)
            {
                return NotFound();
            }
            return Ok(typeTva);
        }

    }
}

