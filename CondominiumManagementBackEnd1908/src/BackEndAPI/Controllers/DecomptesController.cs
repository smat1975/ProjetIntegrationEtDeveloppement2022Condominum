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
    public class DecomptesController : ControllerBase
    {

            private IDecomptesRepository _decomptesRepository;

            public DecomptesController(IDecomptesRepository decomptesRepository)
            {
                _decomptesRepository = decomptesRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de tous les Decomptes
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.Decomptes>>> ListAllDecomptes()
            {
                var listeDecomptes = await _decomptesRepository.ListAllDecomptes();

                if (listeDecomptes == null)
                {
                    return NotFound();
                }

                return Ok(listeDecomptes.ToList());
            }

            //OK BON!!!!//
            /// <summary>
            /// Détails du Decompte
            /// </summary>
            /// <param name="idDecompte">Identifiant du Decompte</param>
            /// <returns></returns>
            [HttpGet("{idDecompte}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Decomptes>> DetailsDecompte(int idDecompte)
            {
                var decompte = await _decomptesRepository.DetailsDecompte(idDecompte);

                if (decompte == null)
                {
                    return NotFound();
                }
                return Ok(decompte);
            }



            //OK BON//Original
            /// <summary>
            /// Créer un Decompte
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouveauDecompte}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.Decomptes>> CreerDecompte(DAL.EFEntities.Decomptes nouveauDecompte)
            {
                await _decomptesRepository.CreerDecompte(nouveauDecompte);
                if (nouveauDecompte == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauDecompte);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Decompte
            /// </summary>
            /// <param name="idDecompte">Identifiant du Decompte</param>
            /// <param name="decompte">Objet contenu Decompte</param>
            /// <returns></returns>
            [HttpPut("{idDecompte}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierDecompte(int idDecompte, DAL.EFEntities.Decomptes decompte)
            {
                if (idDecompte != decompte.IdDecompte)
                {
                    return NotFound();
                }

                try
                {
                    await _decomptesRepository.ModifierDecompte(idDecompte, decompte);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(decompte);
            }

            //OK BON//
            /// <summary>
            /// Modifier un Decompte bis
            /// </summary>
            /// <param name="decompte">Objet contenu Decompte</param>
            /// <returns></returns>
            [HttpPut("{idDecompte}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierDecompteBis(DAL.EFEntities.Decomptes decompte)
            {
                try
                {
                    await _decomptesRepository.ModifierDecompteBis(decompte);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(decompte);
            }

            //OK BON//
            /// <summary>
            /// Supprimer un Decompte
            /// </summary>
            /// <param name="idDecompte">Identifiant de l'objet Decompte</param>
            /// <returns></returns>
            [HttpDelete("{idDecompte}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerDecompte(int idDecompte)
            {
                await _decomptesRepository.SupprimerDecompte(idDecompte);
                return NoContent();
            }

        /*
            //!\\A Vérifier!!!!//!\\

            //OK BON//
            /// <summary>
            /// Ajouter une nouvelle LigneDecompte à un Decompte
            /// <param name="idLigneDecompte"></param>
            /// <param name="idDecompte"></param>
            /// <returns></returns>
            [HttpPut("{nouvelleLigneDecompte}, {idDecompte}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<Decomptes>> AjouterLignesDecompteADecompte(LignesDecomptes nouvelleLigneDecompte, Decomptes decompte)
            {
                try
                {
                    await _decomptesRepository.AjouterLignesDecompteADecompte(nouvelleLigneDecompte, decompte);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(decompte);
            }
        
            //OK BON//
            /// <summary>
            /// Ajouter un montantTotalLignesDecompte à un Decompte
            /// <param name="montantTotalLignesDecompte"></param>
            /// <param name="decompte"></param>
            /// <returns></returns>
            [HttpPut("{montantTotalLignesDecompte}, {idDecompte}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<Decomptes>> AjouterMontantTotalLignesDecompteADecompte(double? montantTotalLignesDecompte, Decomptes decompte)
            {
                try
                {
                    await _decomptesRepository.AjouterMontantTotalLignesDecompteADecompte(montantTotalLignesDecompte, decompte);
                }
                catch (DbUpdateConcurrencyException)
                {
                
                }

                return Ok(decompte);
            }



            //OK BON//
            /// <summary>
            /// Ajouter un Montant Total Hors Tva à un Decompte
            /// <param name="listeLignesDecompte"></param>
            /// <param name="decompte"></param>
            /// <returns></returns>
            [HttpPut("{montantTotalLignesDecompte}, {idDecompte}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<double?>> CalculerMontantTotalHorsTvaDecompte(ICollection<LignesDecomptes> listeLignesDecompte, Decomptes decompte)
            {
            try
            {
                await _decomptesRepository.CalculerMontantTotalHorsTvaDecompte(listeLignesDecompte, decompte);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok();
            }


            //OK BON//
            /// <summary>
            /// Ajouter un Montant Total Hors Tva à un Decompte
            /// <param name="decompte"></param>
            /// <param name="tauxTva"></param>
            /// <param name="montantTotalHorsTva"></param>
            /// <returns></returns>
            [HttpPut("{idDecompte}, {tauxTva}, {montantTotalHorsTva}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<double?>> CalculerMontantTotalTvacDecompte(Decomptes decompte, int tauxTva, double? montantTotalHorsTva)
            {
            try
            {
                await _decomptesRepository.CalculerMontantTotalTvacDecompte(decompte, tauxTva, montantTotalHorsTva);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok();
            }
/*
            //OK BON!!!!//
            /// <summary>
            /// Ensemble des Decomptes pour un Coproprietaire déterminé
            /// </summary>
            /// <param name="idCoproprietaire">Identifiant du Coproprietaire</param>
            /// <returns></returns>
            [HttpGet("{idCoproprietaire}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<Decomptes>>> GetDecomptesForCoproprietaire(string idCoproprietaire)
            {
            var ensembleDecomptes = await _decomptesRepository.GetDecomptesForCoproprietaire(idCoproprietaire);

            if (ensembleDecomptes == null)
            {
                return /*(IEnumerable<Decomptes>)NotFound();
            }
            return /*(IEnumerable<Decomptes>)Ok(ensembleDecomptes);
            }
*/
    }
}
