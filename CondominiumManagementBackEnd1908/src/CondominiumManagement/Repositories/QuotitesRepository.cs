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
    public class QuotitesRepository : IQuotitesRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public QuotitesRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Quotites
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Quotites>> ListAllQuotites()
        {

            return (IEnumerable<DAL.EFEntities.Quotites>)await _condominiumMgtContext.Quotites.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Quotite
        /// <param name="idQuotite"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Quotites> DetailsQuotite(int idQuotite)
        {
            try
            {

                return await _condominiumMgtContext.Quotites.Where(x => x.IdQuotite == idQuotite).FirstOrDefaultAsync();

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
        /// Quotite pour un Lot déterminé!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// <param name="idLot"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Lots> GetQuotiteForLot(int idLot)
        {
            try
            {
                return await _condominiumMgtContext.Lots.Where(x => x.IdLot == idLot).FirstOrDefaultAsync();
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
        /// Créer/ajouter une nouvelle Quotite
        /// </summary>
        /// <param name="nouvelleQuotite">Objet contenu Quotite</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Quotites> CreerQuotite(DAL.EFEntities.Quotites nouvelleQuotite)
        {
            var result = await _condominiumMgtContext.Quotites.AddAsync(nouvelleQuotite);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier une Quotite existante
        /// </summary>
        /// <param name="idQuotite">Identifiant de l'objet</param>
        /// <param name="quotite">Objet contenu Quotites</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Quotites> ModifierQuotite(int idQuotite, DAL.EFEntities.Quotites quotite)
        {

            if (idQuotite != quotite.IdQuotite)
            {
                return null;
            }

            _condominiumMgtContext.Entry(quotite).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return quotite;
        }

        //OK BON//
        /// <summary>
        /// Modifier une Quotite existante
        /// </summary>
        /// <param name="idQuotite">Identifiant de l'objet</param>
        /// <param name="quotite">Objet contenu Quotites</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Quotites> ModifierQuotiteBis(DAL.EFEntities.Quotites quotite)
        {
            var content = await _condominiumMgtContext.Quotites.Where(x => x.IdQuotite == quotite.IdQuotite).FirstOrDefaultAsync();

            if (content != null)
            {

                content.IdLot = quotite.IdLot;
                content.IdLocalisation = quotite.IdLocalisation;
                content.ValeurLot = quotite.ValeurLot;
                content.ValeurLocalisation = quotite.ValeurLocalisation;
                content.DateDebut = quotite.DateDebut;
                content.DateFin = quotite.DateFin;
                content.ActifON = quotite.ActifON;
                content.Remarque = quotite.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer une Quotite
        /// </summary>
        /// <param name="idQuotite">Identifiant du Quotites</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Quotites> SupprimerQuotite(int idQuotite)
        {
            var result = await _condominiumMgtContext.Quotites.FirstOrDefaultAsync(a => a.IdQuotite == idQuotite);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idQuotite);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Quotites> CreerQuotiteBis(DAL.EFEntities.Quotites nouvelleQuotite)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Quotites.AddAsync(nouvelleQuotite);
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
            return nouvelleQuotite;
        }

    }
}
