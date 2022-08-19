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
    public class TypesLotController : ControllerBase
    {

        private ITypesLotRepository _typesLotRepository;

        public TypesLotController(ITypesLotRepository TypesLotRepository)
        {
            _typesLotRepository = TypesLotRepository;
        }


        //OK BON//
        /// <summary>
        /// Liste de tous les TypesLot
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DAL.EFEntities.TypesLot>>> ListAllTypesLot()
        {
            var listeTypesLot = await _typesLotRepository.ListAllTypesLot();

            if (listeTypesLot == null)
            {
                return NotFound();
            }

            return Ok(listeTypesLot.ToList());
        }

        //OK BON!!!!//
        /// <summary>
        /// Détails du TypeLot
        /// </summary>
        /// <param name="idTypeLot">Identifiant du TypeLot</param>
        /// <returns></returns>
        [HttpGet("{idTypeLot}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.TypesLot>> DetailsTypeLot(int idTypeLot)
        {
            var TypeLot = await _typesLotRepository.DetailsTypeLot(idTypeLot);

            if (TypeLot == null)
            {
                return NotFound();
            }
            return Ok(TypeLot);
        }



        //OK BON//Original
        /// <summary>
        /// Créer un TypeLot
        /// </summary>
        /// <returns></returns>
        [HttpPost("{nouveauTypeLot}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DAL.EFEntities.TypesLot>> CreerTypeLot(DAL.EFEntities.TypesLot nouveauTypeLot)
        {
            await _typesLotRepository.CreerTypeLot(nouveauTypeLot);
            if (nouveauTypeLot == null)
            {
                return BadRequest();
            }
            return Ok(nouveauTypeLot);
        }

        //OK BON//
        /// <summary>
        /// Modifier un TypeLot
        /// </summary>
        /// <param name="idTypeLot">Identifiant du TypeLot</param>
        /// <param name="TypeLot">Objet contenu TypeLot</param>
        /// <returns></returns>
        [HttpPut("{idTypeLot}")]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ModifierTypeLot(int idTypeLot, DAL.EFEntities.TypesLot TypeLot)
        {
            if (idTypeLot != TypeLot.IdTypeLot)
            {
                return NotFound();
            }

            try
            {
                await _typesLotRepository.ModifierTypeLot(idTypeLot, TypeLot);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Ok(TypeLot);
        }

    }
}
