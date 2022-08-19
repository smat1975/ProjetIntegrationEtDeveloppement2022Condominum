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
    public class LignesDecomptesController : ControllerBase
    {
        private ILignesDecomptesRepository _lignesDecomptesRepository;

        public LignesDecomptesController(ILignesDecomptesRepository lignesDecomptesRepository)
        {
            _lignesDecomptesRepository = lignesDecomptesRepository;
        }

        //OK BON!!!!//
        /// <summary>
        /// Créer une nouvelle LigneDecompte
        /// </summary>
        /// <param name="nouvelleLigneDecompte">Objet LigneDecompte</param>
        /// <returns></returns>
        [HttpPost("{nouvelleLigneDecompte}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LignesDecomptes>> CreerLigneDecompte(LignesDecomptes nouvelleLigneDecompte)
        {
            await _lignesDecomptesRepository.CreerLigneDecompte(nouvelleLigneDecompte);

            if (nouvelleLigneDecompte == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(nouvelleLigneDecompte);
            }
        }

        //OK BON//
        /// <summary>
        /// Créer une nouvelle LigneDecompte
        /// <param name="idDecompte"></param>
        /// <param name="idCodePcmn"></param>
        /// <param name="description"></param>
        /// <param name="idlLigneDocumentsFournisseurs"></param>
        /// <param name="idQuotite"></param>
        /// <param name="dateDebutLigne"></param>
        /// <param name="dateFinLigne"></param>
        /// <param name="nbreJoursLigne"></param>
        /// <param name="montantTotalTvacligne"></param>
        /// <param name="montantTvaligne"></param>
        /// <param name="remarque"></param>
        /// <returns></returns>
        [HttpPost("{idDecompte}, {idCodePcmn}, {description},{idlLigneDocumentsFournisseurs}, {idQuotite}, {dateDebutLigne}, {dateFinLigne}, {nbreJoursLigne}, {montantTotalTvacligne},{montantTvaligne}, {remarque}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LignesDecomptes>> CreerLigneDecompteBis(int idDecompte, int idCodePcmn, string description, int idlLigneDocumentsFournisseurs, int idQuotite, DateTime dateDebutLigne, DateTime dateFinLigne, int nbreJoursLigne, double? montantTotalTvacligne, double? montantTvaligne, string remarque)
        { 
            try
            {
                await _lignesDecomptesRepository.CreerLigneDecompteBis(idDecompte, idCodePcmn, description, idlLigneDocumentsFournisseurs, idQuotite, dateDebutLigne, dateFinLigne, nbreJoursLigne, montantTotalTvacligne, montantTvaligne, remarque);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok();
        }

        //OK BON!!!!//
        /// <summary>
        /// Créer une nouvelle LigneDecompte 
        /// </summary>
        /// <param name="nouvelleLigneDecompte">Objet LignesDecomptes</param>
        /// <returns></returns>
        [HttpGet("{nouvelleLigneDecompte}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LignesDecomptes>> CreerLigneDecompteTer(LignesDecomptes nouvelleLigneDecompte)
        {
            await _lignesDecomptesRepository.CreerLigneDecompteTer(nouvelleLigneDecompte);

            if (nouvelleLigneDecompte == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(nouvelleLigneDecompte);
            }
        }

        //OK BON!!!!//
        /// <summary>
        /// Details d'une LigneDecompte
        /// </summary>
        /// <param name="idLigneDecompte">Identifiant de la LigneDecompte</param>
        /// <returns></returns>
        [HttpGet("{idLigneDecompte}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LignesDecomptes>> DetailsLigneDecompte(int idLigneDecompte)
        {
            var ligneDecompte = await _lignesDecomptesRepository.DetailsLigneDecompte(idLigneDecompte);

            if  (ligneDecompte == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ligneDecompte);
            }
        }

        //!\\A Vérifier!!!!//!\\

        //OK BON//
        /// <summary>
        /// Ajouter un Montant Total Hors Tva à une LigneDecompte
        /// <param name="ligneDecompte"></param>
        /// <param name="montantHorsTva"></param>
        /// <param name="montantTvaLigne"></param>
        /// <returns></returns>
        [HttpPut("{idDecompte}, {tauxTva}, {montantTotalHorsTva}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<double?>> CalculerMontantTotalTvacLigne(LignesDecomptes ligneDecompte, double? montantHorsTva, double? montantTvaLigne)
        {
            try
            {
                await _lignesDecomptesRepository.CalculerMontantTotalTvacLigne(ligneDecompte, montantHorsTva, montantTvaLigne);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok();
        }

        //OK BON//
        /// <summary>
        /// Ajouter un Montant Total Hors Tva à une LigneDecompte
        /// <param name="ligneDecompte"></param>
        /// <param name="tauxTva"></param>
        /// <param name="montantHorsTva"></param>
        /// <returns></returns>
        [HttpPut("{idDecompte}, {tauxTva}, {montantTotalHorsTva}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<double?>> CalculerMontantTvaLigne(LignesDecomptes ligneDecompte, int tauxTva, double? montantHorsTva)
        {
            try
            {
                await _lignesDecomptesRepository.CalculerMontantTvaLigne(ligneDecompte, tauxTva, montantHorsTva);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok();
        }

        //OK BON//
        /// <summary>
        /// Ajouter un Montant Total Hors Tva à une LigneDecompte
        /// <param name="ligneDecompte"></param>
        /// <param name="dateDebutLigne"></param>
        /// <param name="dateFinLigne"></param>
        /// <returns></returns>
        [HttpPut("{ligneDecompte}, {dateDebutLigne}, {dateFinLigne}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CalculerNombreJoursLigne(LignesDecomptes ligneDecompte, DateTime dateDebutLigne, DateTime dateFinLigne)
        {
            try
            {
                await _lignesDecomptesRepository.CalculerNombreJoursLigne(ligneDecompte, dateDebutLigne, dateFinLigne);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok();
        }

        //OK BON!!!!//
        /// <summary>
        /// Ensemble des LignesDecomptes pour un Decompte déterminé
        /// </summary>
        /// <param name="idDecompte">Identifiant du Decompte</param>
        /// <returns></returns>
        [HttpGet("{idDecompte}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<LignesDecomptes>>> GetLignesDecompteForDecompte(int idDecompte)
        {
            var ensembleLignesDecomptes = await _lignesDecomptesRepository.GetLignesDecompteForDecompte(idDecompte);

            if (ensembleLignesDecomptes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ensembleLignesDecomptes);
            }
        }

    }
}
