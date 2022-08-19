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
    public class AnnexesController : Controller
    {

        private IAnnexesRepository _annexesRepository;

        public AnnexesController(IAnnexesRepository annexesRepository)
        {
            _annexesRepository = annexesRepository;
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les annexes
        /// </summary>
        /// <returns></returns>
        [HttpGet("listallannexes/")]
        [Route("listallannexes/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.Annexes>>> ListAllAnnexes()
        {
            var listeAnnexes = await _annexesRepository.ListAllAnnexes();

            if (listeAnnexes == null)
            {
                return NotFound();
            }

            return Ok(listeAnnexes.ToList());
        }

        //OK BON!!!!//
        /// <summary>
        /// Détails de l'annexe
        /// </summary>
        /// <param name="idAnnexe">Identifiant de l'annexe</param>
        /// <returns></returns>
        [HttpGet("detailsannexe/{idAnnexe}")]
        [Route("detailsannexe/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Annexes>> DetailsAnnexe(int idAnnexe)
        {
            var annexe = await _annexesRepository.DetailsAnnexe(idAnnexe);

            if (annexe == null)
            {
                return NotFound();
            }
            return Ok(annexe);
        }



        //OK BON//Original
        /// <summary>
        /// Créer une annexe
        /// </summary>
        /// <returns></returns>
        [HttpPost("creerannexe/{nouvelleAnnexe}")]
        [Route("creerannexe/")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Annexes>> CreerAnnexe(DAL.EFEntities.Annexes nouvelleAnnexe)
        {
            await _annexesRepository.CreerAnnexe(nouvelleAnnexe);
            if (nouvelleAnnexe == null)
            {
                return BadRequest();
            }
            return Ok(nouvelleAnnexe);
        }

        //OK BON//De Microsoft
        /// <summary>
        /// Créer une Annexe Retry
        /// </summary>
        /// <returns></returns>
        [HttpPost("creerannexeretry/{nouvelleAnnexe}")]
        [Route("creerannexeretry/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreerAnnexeRetry(DAL.EFEntities.Annexes nouvelleAnnexe)
        {
            if (nouvelleAnnexe == null)
            {
                return BadRequest();
            }
            await _annexesRepository.CreerAnnexeRetry(nouvelleAnnexe);
            return Ok(nouvelleAnnexe);

        }

        //OK BON//
        /// <summary>
        /// Modifier une annexe
        /// </summary>
        /// <param name="idAnnexe">Identifiant de l'annexe</param>
        /// <param name="annexe">Objet contenu annexe</param>
        /// <returns></returns>
        [HttpPut("modifierannexe/{idAnnexe}")]
        [Route("modifierannexe/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<ActionResult<DAL.EFEntities.Annexes>> ModifierAnnexe(int idAnnexe, DAL.EFEntities.Annexes annexe)
        {
            if (idAnnexe != annexe.IdAnnexe)
            {
                return NotFound();
            }

            try
            {
                await _annexesRepository.ModifierAnnexe(idAnnexe, annexe);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(annexe);
        }

        //OK BON//
        /// <summary>
        /// Modifier une annexe bis
        /// </summary>
        /// <param name="annexe">Objet contenu annexe</param>
        /// <returns></returns>
        [HttpPut("modifierannexebis/{annexe}")]
        [Route("modifierannexebis/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Annexes>> ModifierAnnexeBis(DAL.EFEntities.Annexes annexe)
        {
            try
            {
                await _annexesRepository.ModifierAnnexeBis(annexe);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(annexe);
        }

        //OK BON//
        /// <summary>
        /// Supprimer une annexe
        /// </summary>
        /// <param name="idAnnexe">Identifiant de l'objet annexe</param>
        /// <returns></returns>
        [HttpDelete("supprimerannexe/{idAnnexe}")]
        [Route("supprimerannexe/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<ActionResult> SupprimerAnnexe(int idAnnexe)
        {
            await _annexesRepository.SupprimerAnnexe(idAnnexe);
            return NoContent();
        }

        //!\\A Faire!!!!//!\\

        //!\\A VERIFIER!!!!//!\\ ==> PAS BON!!!!

        //PAS BON//
        /// <summary>
        /// Modifier une annexe en y rajoutant une/des photo(s) sous forme d'une liste de photos
        /// </summary>
        /// <param name="annexe">Objet contenu annexe</param>
        /// <param name="[idPhoto]">Un tableau/collection d'idPhoto</param>
        /// <returns></returns>
        /*[HttpPut("{idAnnexe}, {[idPhoto]}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Annexes>> AjouterPhotosAAnnexe([FromBody]ICollection<DAL.EFEntities.Photos> listePhotos, DAL.EFEntities.Annexes annexe)
        {
            try
            {
                await _annexesRepository.AjouterPhotosAAnnexe(listePhotos, annexe);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(annexe);
        }*/


        //*********En utilisant la méthode façon ADO.net!!!!**************
        // |
        // v

        //!\\A VERIFIER!!!!//!\\

        //OK BON//
        /// <summary>
        /// Liste de toutes les annexes pour un message déterminé
        /// </summary>
        /// <param name="idMessage"></param>
        /// <returns></returns>
        [HttpGet("getannexesformessage/{idMessage}")]
        [Route("getannexesformessage/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.Annexes>>> GetAnnexesForMessage(int idMessage)
        {
            var listeAnnexes = await _annexesRepository.GetAnnexesForMessage(idMessage);

            if (listeAnnexes == null)
            {
                return NotFound();
            }

            return Ok(listeAnnexes.ToList());
        }

        //!\\A VERIFIER!!!!//!\\

        //OK BON//
        /// <summary>
        /// Ensemble de toutes les Annexes
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallannexes/")]
        [Route("getallannexes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.Annexes>>> GetAllAnnexes()
        {
            var ensembleAnnexes = await _annexesRepository.GetAllAnnexes();

            if (ensembleAnnexes == null)
            {
                return NotFound();
            }

            return Ok(ensembleAnnexes.ToString());
        }

        //!\\A VERIFIER!!!!//!\\

        //OK BON//
        /// <summary>
        /// Annexe déterminée selon son identifiant 
        /// </summary>
        /// <param name="idAnnexe"></param>
        /// <returns></returns>
        [HttpGet("getannexebyid/{idAnnexe}")]
        [Route("getannexebyid/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.Annexes>> GetAnnexeById(int idAnnexe)
        {
            var annexe = await _annexesRepository.GetAnnexeById(idAnnexe);

            if (annexe == null)
            {
                return NotFound();
            }

            return Ok(annexe);
        }



        //OK BON!!!!//
        /// <summary>
        /// Méthode pour ajouter une nouvelle Photo à une Annexe (en cours de) création et préalablement existante
        /// </summary>
        /// <param name="idAnnexe">Identifiant de l'annexe auquel ajouter une photo</param>
        /// <returns></returns>
        [HttpGet("addphototoannexe/{idAnnexe}")]
        [Route("addphototoannexe/{idAnnexe}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Annexes>>> AddPhotoToAnnexe(int idAnnexe, Photos nouvellePhoto)
        {
            var result = await _annexesRepository.GetAnnexeById(idAnnexe);
            if (result != null)
            {
                if (nouvellePhoto.Ressource == null)
                {
                    return BadRequest();
                }
                else
                {
                    var annexe = await _annexesRepository.AddPhotoToAnnexe(idAnnexe, nouvellePhoto);
                    return Ok(annexe);
                }
            }
            return NotFound();
        }
    }
}
