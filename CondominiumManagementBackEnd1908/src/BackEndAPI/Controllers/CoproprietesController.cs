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
    public class CoproprietesController : ControllerBase
    {

            private ICoproprietesRepository _coproprietesRepository;

            public CoproprietesController(ICoproprietesRepository coproprietesRepository)
            {
                _coproprietesRepository = coproprietesRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de toutes les Coproprietes
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.Coproprietes>>> ListAllCoproprietes()
            {
                var listeCoproprietes = await _coproprietesRepository.ListAllCoproprietes();

                if (listeCoproprietes == null)
                {
                    return NotFound();
                }

                return Ok(listeCoproprietes.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails de la Copropriete
            /// </summary>
            /// <param name="idCopropriete">Identifiant de la Copropriete</param>
            /// <returns></returns>
            [HttpGet("{idCopropriete}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Coproprietaires>> DetailsCopropriete(int idCopropriete)
            {
                var copropriete = await _coproprietesRepository.DetailsCopropriete(idCopropriete);

                if (copropriete == null)
                {
                    return NotFound();
                }
                return Ok(copropriete);
            }



            //OK BON//Original
            /// <summary>
            /// Créer une Copropriete
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouvelleCopropriete}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Coproprietes>> CreerCopropriete(DAL.EFEntities.Coproprietes nouvelleCopropriete)
            {
                await _coproprietesRepository.CreerCopropriete(nouvelleCopropriete);
                if (nouvelleCopropriete == null)
                {
                    return BadRequest();
                }
                return Ok(nouvelleCopropriete);
            }

        //OK BON//
        /// <summary>
        /// Modifier une Copropriete
        /// </summary>
        /// <param name="idCopropriete">Identifiant de la Copropriete</param>
        /// <param name="coproprietes">Objet contenu Copropriete</param>
        /// <returns></returns>
        [HttpPut("{idCopropriete}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierCopropriete(int idCopropriete, DAL.EFEntities.Coproprietes copropriete)
            {
                if (idCopropriete != copropriete.IdCopropriete)
                {
                    return NotFound();
                }

                try
                {
                    await _coproprietesRepository.ModifierCopropriete(idCopropriete, copropriete);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(copropriete);
            }

        //OK BON//
        /// <summary>
        /// Modifier une Copropriete bis
        /// </summary>
        /// <param name="copropriete">Objet contenu copropriete</param>
        /// <returns></returns>
        [HttpPut("{idCopropriete}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierCoproprieteBis(DAL.EFEntities.Coproprietes copropriete)
            {
                try
                {
                    await _coproprietesRepository.ModifierCoproprieteBis(copropriete);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(copropriete);
            }

            //OK BON//
            /// <summary>
            /// Supprimer une Copropriete
            /// </summary>
            /// <param name="idCopropriete">Identifiant de l'objet Copropriete</param>
            /// <returns></returns>
            [HttpDelete("{idCoproprietes}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerCopropriete(int idCopropriete)
            {
                await _coproprietesRepository.SupprimerCopropriete(idCopropriete);
                return NoContent();
            }
        

        //!\\A Vérifier!!!!//!\\ ==> OK BON!!!!
    
        //OK BON!!!!//
        /// <summary>
        /// Ensemble des coproprietes pour un Coproprietaire déterminé
        /// </summary>
        /// <param name="idCoproprietaire">Identifiant de la Coproprietaire</param>
        /// <returns></returns>
        [HttpGet("{idCoproprietaire}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Coproprietes>>> GetCoproprietesForCoproprietaire(string idCoproprietaire)
        {
            var ensembleCoproprietes = await _coproprietesRepository.GetCoproprieteForCoproprietaire(idCoproprietaire);

            if (ensembleCoproprietes == null)
            {
                return /*(IEnumerable<Coproprietes>)*/NotFound();
            }
            else
            {
            return /*(IEnumerable<Coproprietes>)*/Ok(ensembleCoproprietes); 
            }
        }
        
    }
}
