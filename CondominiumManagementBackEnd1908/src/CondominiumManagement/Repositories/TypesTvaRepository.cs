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
    public class TypesTvaRepository : ITypesTvaRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public TypesTvaRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de tous les TypesTva
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.TypesTva>> ListAllTypesTva()
        {

            return (IEnumerable<DAL.EFEntities.TypesTva>)await _condominiumMgtContext.TypesTva.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails TypeTva
        /// <param name="idTypeTva"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.TypesTva> DetailsTypeTva(int idTypeTva)
        {
            try
            {

                return await _condominiumMgtContext.TypesTva.Where(x => x.IdTypeTva == idTypeTva).FirstOrDefaultAsync();

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
        /// TypesTva pour un Decompte déterminé
        /// <param name="idDecompte"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Decomptes> GetTypesTvaForDecompte(int idDecompte)
        {
            try
            {
                return await _condominiumMgtContext.Decomptes.FindAsync(idDecompte);
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
        /// TypesTva pour une LigneDocumentsFournisseur déterminé
        /// <param name="idLigneDocumentFournisseur"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.LignesDocumentsFournisseurs> GetTypesTvaForLigneDocumentFournissseur(int idLigneDocumentFournisseur)
        {
            try
            {
                return await _condominiumMgtContext.LignesDocumentsFournisseurs.FindAsync(idLigneDocumentFournisseur);
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
        /// Créer/ajouter un nouveau TypeTva
        /// </summary>
        /// <param name="nouveauTypeTva">Objet contenu TypeTva</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.TypesTva> CreerTypeTva(DAL.EFEntities.TypesTva nouveauTypeTva)
        {
            var result = await _condominiumMgtContext.TypesTva.AddAsync(nouveauTypeTva);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un TypeTva existant
        /// </summary>
        /// <param name="idTypeTva">Identifiant de l'objet</param>
        /// <param name="typeTva">Objet contenu TypesTva</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.TypesTva> ModifierTypeTva(int idTypeTva, DAL.EFEntities.TypesTva typeTva)
        {

            if (idTypeTva != typeTva.IdTypeTva)
            {
                return null;
            }

            _condominiumMgtContext.Entry(typeTva).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return typeTva;
        }

        //OK BON//
        /// <summary>
        /// Modifier un TypeTva existant
        /// </summary>
        /// <param name="idTypeTva">Identifiant de l'objet</param>
        /// <param name="typeTva">Objet contenu TypesTva</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.TypesTva> ModifierTypeTvaBis(DAL.EFEntities.TypesTva typeTva)
        {
            var content = await _condominiumMgtContext.TypesTva.Where(x => x.IdTypeTva == typeTva.IdTypeTva).FirstOrDefaultAsync();

            if (content != null)
            {
                content.Denomination = typeTva.Denomination;
                content.Description = typeTva.Description;
                content.ActifON = typeTva.ActifON;
                content.Remarque = typeTva.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un TypeTva
        /// </summary>
        /// <param name="idTypeTva">Identifiant du TypesTva</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.TypesTva> SupprimerTypeTva(int idTypeTva)
        {
            var result = await _condominiumMgtContext.TypesTva.FirstOrDefaultAsync(a => a.IdTypeTva == idTypeTva);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idTypeTva);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.TypesTva> CreerTypeTvaBis(DAL.EFEntities.TypesTva nouveauTypeTva)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.TypesTva.AddAsync(nouveauTypeTva);
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
            return nouveauTypeTva;
        }
    }
}
