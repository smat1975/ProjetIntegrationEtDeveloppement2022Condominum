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

    public class CodesPcmnController : ControllerBase
    {

            private ICodesPcmnRepository _codesPcmnRepository;

            public CodesPcmnController(ICodesPcmnRepository codesPcmnRepository)
            {
                _codesPcmnRepository = codesPcmnRepository;
            }


            //OK BON//
            /// <summary>
            /// Liste de tous les codes pcmn
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.CodesPcmn>>> ListAllCodesPcmn()
            {
                var listeCodesPcmn = await _codesPcmnRepository.ListAllCodesPcmn();

                if (listeCodesPcmn == null)
                {
                    return NotFound();
                }

                return Ok(listeCodesPcmn.ToList());
            }
        
        
            //OK BON!!!!//
            /// <summary>
            /// Détails du CodePcmn
            /// </summary>
            /// <param name="idCodePcmn">Identifiant du CodePcmn</param>
            /// <returns></returns>
            [HttpGet("{idCodePcmn}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.CodesPcmn>> DetailsCodePcmn(int idCodePcmn)
            {
                var codePcmn = await _codesPcmnRepository.DetailsCodesPcmn(idCodePcmn);

                if (codePcmn == null)
                {
                    return NotFound();
                }
                return Ok(codePcmn);
            }


        
            //OK BON//Original
            /// <summary>
            /// Créer un CodePcmn
            /// </summary>
            /// <returns></returns>
            [HttpPost("{nouveauCodePcmn}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<DAL.EFEntities.CodesPcmn>> CreerCodePcmn(DAL.EFEntities.CodesPcmn nouveauCodePcmn)
            {
                await _codesPcmnRepository.CreerCodePcmn(nouveauCodePcmn);
                if (nouveauCodePcmn == null)
                {
                    return BadRequest();
                }
                return Ok(nouveauCodePcmn);
            }
        
            //OK BON//
            /// <summary>
            /// Modifier une CodePcmn
            /// </summary>
            /// <param name="idCodePcmn">Identifiant du CodePcmn</param>
            /// <param name="codePcmn">Objet contenu CodePcmn</param>
            /// <returns></returns>
            [HttpPut("{idCodePcmn}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<IActionResult> ModifierCodePcmn(int idCodePcmn, DAL.EFEntities.CodesPcmn codePcmn)
            {
                if (idCodePcmn != codePcmn.IdCodePcmn)
                {
                    return NotFound();
                }

                try
                {
                    await _codesPcmnRepository.ModifierCodePcmn(idCodePcmn, codePcmn);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(codePcmn);
            }
        
            //OK BON//
            /// <summary>
            /// Modifier une CodePcmn bis
            /// </summary>
            /// <param name="codePcmn">Objet contenu CodePcmn</param>
            /// <returns></returns>
            [HttpPut("{idCodePcmn}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> ModifierCodePcmnBis(DAL.EFEntities.CodesPcmn codePcmn)
            {
                try
                {
                    await _codesPcmnRepository.ModifierCodePcmnBis(codePcmn);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return Ok(codePcmn);
            }

        
            //OK BON//
            /// <summary>
            /// Supprimer un codePcmn
            /// </summary>
            /// <param name="idCodePcmn">Identifiant de l'objet CodePcmn</param>
            /// <returns></returns>
            [HttpDelete("{idCodePcmn}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]

            public async Task<ActionResult> SupprimerCodePcmn(int idCodePcmn)
            {
                await _codesPcmnRepository.SupprimerCodePcmn(idCodePcmn);
                return NoContent();
            }

            //!\\A Vérifier!!!!//!\\

            //OK BON//
            /// <summary>
            /// Liste de tous les CodesPcmn pour une LigneDocumentFournisseur déterminée
            /// </summary>
            /// <param name="idLigneDocumentFournisseur"></param>
            /// <returns></returns>
            [HttpGet("{idLigneDocumentFournisseur}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<IEnumerable<DAL.EFEntities.CodesPcmn>>> GetCodesPcmnForLigneDocumentFournisseur(int idLigneDocumentFournisseur)
            {
                var codesPcmn = await _codesPcmnRepository.GetCodesPcmnForLigneDocumentFournisseur(idLigneDocumentFournisseur);

                if (codesPcmn == null)
                {
                    return NotFound();
                }

                return Ok(codesPcmn.ToList());
            }
        
            //!\\A Vérifier!!!!//!\\ ==> PAS BON!!!!
       /*
            //OK BON//
            /// <summary>
            /// CodePcmn pour un codeDecompte déterminée
            /// </summary>
            /// <param name="codeDecompte"></param>
            /// <returns></returns>
            [HttpGet("codeDecompte}")]
            //[Route("")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IEnumerable<DAL.EFEntities.CodesPcmn>> GetCodesPcmnForCodeDecompte(int codeDecompte)
            {
                var codesPcmn = await _codesPcmnRepository.GetCodesPcmnForLigneDocumentFournisseur(codeDecompte);

                if (codesPcmn == null)
                {
                    return (IEnumerable<CodesPcmn>)NotFound();
                }

                return (IEnumerable<CodesPcmn>)Ok(codesPcmn.ToList());
            }
        */
    }
}
