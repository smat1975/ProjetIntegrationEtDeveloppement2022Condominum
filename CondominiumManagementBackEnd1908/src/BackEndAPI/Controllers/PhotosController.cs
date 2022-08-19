//using CondominiumManagement.Models;
using CondominiumManagement.Repositories.Interfaces;
using DAL.EFEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    [Produces("application/json")]
    [Route("backendapi/[Controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {

            private IPhotosRepository _photosRepository;

            public PhotosController(IPhotosRepository photosRepository)
            {
                _photosRepository = photosRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de toutes les Photos
            /// </summary>
            /// <returns></returns>
            [HttpGet("listallphotos/")]
            [Route("listallphotos/")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.Photos>>> ListAllPhotos()
            {
                var listePhotos = await _photosRepository.ListAllPhotos();

                if (listePhotos == null)
                {
                    return NotFound();
                }

                return Ok(listePhotos.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails d'une Photo
            /// </summary>
            /// <param name="idPhoto">Identifiant d'une Photo</param>
            /// <returns></returns>
            [HttpGet("detailsphoto/{idPhoto}")]
            [Route("detailsphoto/{idPhoto}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Photos>> DetailsPhoto(int idPhoto)
            {
                var photo = await _photosRepository.DetailsPhoto(idPhoto);

                if (photo == null)
                {
                    return NotFound();
                }
                return Ok(photo);
            }



            //OK BON//Original
            /// <summary>
            /// Créer une Photo
            /// </summary>
            /// <returns></returns>
            [HttpPost("creerphoto/{nouvellePhoto}")]
            [Route("creerphoto/")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Photos>> CreerPhoto(DAL.EFEntities.Photos nouvellePhoto)
            {
                await _photosRepository.CreerPhoto(nouvellePhoto);
                if (nouvellePhoto == null)
                {
                    return BadRequest();
                }
                return Ok(nouvellePhoto);
            }

        //OK BON//De Microsoft
        /// <summary>
        /// Créer une Photo Retry
        /// </summary>
        /// <returns></returns>
        [HttpPost("creerphotoretry/{nouvellePhoto}")]
        [Route("creerphotoretry/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreerPhotoRetry(DAL.EFEntities.Photos nouvellePhoto)
        {
            if (nouvellePhoto == null)
            {
                return BadRequest();
            }
            await _photosRepository.CreerPhotoRetry(nouvellePhoto);
            return Ok(nouvellePhoto);

        }

        //OK BON//
        /// <summary>
        /// Modifier un Photo
        /// </summary>
        /// <param name="idPhoto">Identifiant du Photo</param>
        /// <param name="photo">Objet contenu Photo</param>
        /// <returns></returns>
        [HttpPut("{idPhoto}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierPhoto(int idPhoto, DAL.EFEntities.Photos photo)
            {
                if (idPhoto != photo.IdPhoto)
                {
                    return NotFound();
                }

                try
                {
                    await _photosRepository.ModifierPhoto(idPhoto, photo);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(photo);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Photo bis
            /// </summary>
            /// <param name="photo">Objet contenu Photo</param>
            /// <returns></returns>
            [HttpPut("{idPhoto}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierPhotoBis(DAL.EFEntities.Photos photo)
            {
                try
                {
                    await _photosRepository.ModifierPhotoBis(photo);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(photo);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un Photo
            /// </summary>
            /// <param name="idPhoto">Identifiant de l'objet Photo</param>
            /// <returns></returns>
            [HttpDelete("{idPhoto}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerPhoto(int idPhoto)
            {
                await _photosRepository.SupprimerPhoto(idPhoto);
                return NoContent();
            }


        //!\\A Vérifier!!!!//!\\

        //OK BON!!!!//
        /// <summary>
        /// Ajouter une Photo à une Annexe via une url déterminé
        /// </summary>
        /// <param name="IdAnnexe">Identifiant de l'Annexe</param>
        /// <param name="urlPhoto">Localisation de la ressource</param>
        /// <returns></returns>
        [HttpGet("{IdAnnexe}, {urlPhoto}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Photos>> AjouterPhotoViaUrl(int IdAnnexe, string urlPhoto)
        {
            await _photosRepository.AjouterPhotoViaUrl(IdAnnexe, urlPhoto);
            if (urlPhoto == null)
            {
                return BadRequest();
            }
            return Ok();
        }


        //OK BON!!!!//
        /// <summary>
        /// Ensemble des Photos pour une Annexe determinée
        /// </summary>
        /// <param name="idAnnexe">Identifiant de l'Annexe</param>
        /// <returns></returns>
        [HttpGet("{idAnnexe}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Photos>>> GetPhotosForAnnexe(int idAnnexe)
        {
            var ensemblePhotos = await _photosRepository.GetPhotosForAnnexe(idAnnexe);
            if (ensemblePhotos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensemblePhotos);
            }
        }

    }
}
