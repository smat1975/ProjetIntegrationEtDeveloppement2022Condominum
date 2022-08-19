using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DAL.EFContext;
using DAL.EFEntities;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using AutoMapper;
using System.Data;
using Microsoft.Data.SqlClient;
using CondominiumManagement.Helpers;
using CondominiumManagement.Repositories.Interfaces;

namespace CondominiumManagement.Repositories
{
    public class CodesPcmnRepository : ICodesPcmnRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public CodesPcmnRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }

        //OK BON//
        /// <summary>
        /// Liste de toutes les Codes Pcmn
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.CodesPcmn>> ListAllCodesPcmn()
        {
            
            return (IEnumerable<DAL.EFEntities.CodesPcmn>) await _condominiumMgtContext.CodesPcmn.ToListAsync();
            
        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Code Pcmn
        /// <param name="idCodePcmn"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.CodesPcmn> DetailsCodesPcmn(int idCodePcmn)
        {
            try
            {

                return await _condominiumMgtContext.CodesPcmn.Where(x => x.IdCodePcmn == idCodePcmn).FirstOrDefaultAsync();

            }
            //!\\A REGLER!!!!//!\\
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw e;
            }
        }


        //OK BON//
        /// <summary>
        /// Code Pcmn pour un code Decompte déterminé
        /// <param name="codeDecompte"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.CodesPcmn>> GetCodesPcmnForCodeDecompte(int codeDecompte)
        {
            try
            {
                return await _condominiumMgtContext.CodesPcmn.Where(x => x.CodeDecompte == codeDecompte).ToListAsync();
            }
            //!\\A REGLER!!!!//!\\
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw e;
            }
        }

        /*------------------------
        //!\\A vérifier!!!!//!\\
        | 
        V
        */
        //OK BON//
        /// <summary>
        /// Créer/ajouter une nouveau Code Pcmn
        /// </summary>
        /// <param name="nouveauCodePcmn">Objet contenu CodesPcmn</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.CodesPcmn> CreerCodePcmn(DAL.EFEntities.CodesPcmn nouveauCodePcmn)
        {
            var result = await _condominiumMgtContext.CodesPcmn.AddAsync(nouveauCodePcmn);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Code Pcmn existant
        /// </summary>
        /// <param name="idCodePcmn">Identifiant de l'objet</param>
        /// <param name="CodePcmn">Objet contenu CodesPcmn</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.CodesPcmn> ModifierCodePcmn(int idCodePcmn, DAL.EFEntities.CodesPcmn codesPcmn)
        {

            if (idCodePcmn != codesPcmn.IdCodePcmn)
            {
                return null;
            }

            _condominiumMgtContext.Entry(codesPcmn).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return codesPcmn;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Code Pcmn existant
        /// </summary>
        /// <param name="idCodePcmn">Identifiant de l'objet</param>
        /// <param name="codesPcmn">Objet contenu CodesPcmn</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.CodesPcmn> ModifierCodePcmnBis(DAL.EFEntities.CodesPcmn codePcmn)
        {
            var content = await _condominiumMgtContext.CodesPcmn.Where(x => x.CodePcmn == codePcmn.IdCodePcmn).FirstOrDefaultAsync();

            if (content != null)
            {
                content.CodePcmn = codePcmn.CodePcmn;
                content.Libelle = codePcmn.Libelle;
                content.CodeDecompte = codePcmn.CodeDecompte;
                content.Denomination = codePcmn.Denomination;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un Code Pcmn
        /// </summary>
        /// <param name="idCodePcmn">Identifiant du CodePcmn</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.CodesPcmn> SupprimerCodePcmn(int idCodePcmn)
        {
            var result = await _condominiumMgtContext.CodesPcmn.FirstOrDefaultAsync(a => a.IdCodePcmn == idCodePcmn);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idCodePcmn);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.CodesPcmn> CreerCodePcmnBis(DAL.EFEntities.CodesPcmn nouveauCodePcmn)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.CodesPcmn.AddAsync(nouveauCodePcmn);
                await context.SaveChangesAsync();

                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                transaction.Commit();
            }
            catch (Exception e)
            {
                // TODO: Handle failure
                throw e;
                //Gestion d'erreurs à améliorer!!//
            }
            return nouveauCodePcmn;
        }

        //!\\A Vérifier!!!!//!\\

        public async Task<IEnumerable<DAL.EFEntities.CodesPcmn>> GetCodesPcmnForLigneDocumentFournisseur(int idLigneDocumentFournisseur) {
            var content = await _condominiumMgtContext.LignesDocumentsFournisseurs.Where(x => x.IdLigneDocumentFournisseur == idLigneDocumentFournisseur).FirstOrDefaultAsync();
            try
            {
                return await _condominiumMgtContext.CodesPcmn.Where(x => x.CodePcmn == content.IdLigneDocumentFournisseur).ToListAsync();
            }
            //!\\A REGLER!!!!//!\\
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw e;
            }
        }
        
    }
}
