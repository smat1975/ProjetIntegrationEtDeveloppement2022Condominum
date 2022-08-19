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
    public class RaisonsClotureRepository : IRaisonsClotureRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public RaisonsClotureRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les RaisonsCloture
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.RaisonsCloture>> ListAllRaisonsCloture()
        {

            return (IEnumerable<DAL.EFEntities.RaisonsCloture>)await _condominiumMgtContext.RaisonsCloture.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails RaisonCloture
        /// <param name="idRaisonCloture"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.RaisonsCloture> DetailsRaisonCloture(int idRaisonCloture)
        {
            try
            {

                return await _condominiumMgtContext.RaisonsCloture.Where(x => x.IdRaisonCloture == idRaisonCloture).FirstOrDefaultAsync();

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
        /// RaisonCloture pour un copriprietaire déterminé
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietaires> GetRaisonClotureForCoproprietaire(string idCoproprietaire)
        {
            try
            {
                return await _condominiumMgtContext.Coproprietaires.Where(x => x.IdCoproprietaire == idCoproprietaire).FirstOrDefaultAsync();
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
        /// Coproprietaires pour une RaisonCloture déterminé
        /// <param name="idRaisonCloture"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietaires> GetCoproprietairesForRaisonCloture(int idRaisonCloture)
        {
            try
            {
                return await _condominiumMgtContext.Coproprietaires.Where(x => x.IdRaisonCloture == idRaisonCloture).FirstOrDefaultAsync();
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
        /// Créer/ajouter une nouvelle RaisonCloture
        /// </summary>
        /// <param name="nouvelleRaisonCloture">Objet contenu RaisonCloture</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.RaisonsCloture> CreerRaisonCloture(DAL.EFEntities.RaisonsCloture nouvelleRaisonCloture)
        {
            var result = await _condominiumMgtContext.RaisonsCloture.AddAsync(nouvelleRaisonCloture);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier une RaisonCloture existante
        /// </summary>
        /// <param name="idRaisonCloture">Identifiant de l'objet</param>
        /// <param name="raisonCloture">Objet contenu RaisonsCloture</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.RaisonsCloture> ModifierRaisonCloture(int idRaisonCloture, DAL.EFEntities.RaisonsCloture raisonCloture)
        {

            if (idRaisonCloture != raisonCloture.IdRaisonCloture)
            {
                return null;
            }

            _condominiumMgtContext.Entry(raisonCloture).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return raisonCloture;
        }

        //OK BON//
        /// <summary>
        /// Modifier une RaisonCloture existante
        /// </summary>
        /// <param name="idRaisonCloture">Identifiant de l'objet</param>
        /// <param name="raisonCloture">Objet contenu RaisonsCloture</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.RaisonsCloture> ModifierRaisonClotureBis(DAL.EFEntities.RaisonsCloture raisonCloture)
        {
            var content = await _condominiumMgtContext.RaisonsCloture.Where(x => x.IdRaisonCloture == raisonCloture.IdRaisonCloture).FirstOrDefaultAsync();

            if (content != null)
            {
                content.Denomination = raisonCloture.Denomination;
                content.Description = raisonCloture.Description;
                content.Remarque = raisonCloture.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer une RaisonCloture
        /// </summary>
        /// <param name="idRaisonCloture">Identifiant du RaisonsCloture</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.RaisonsCloture> SupprimerRaisonCloture(int idRaisonCloture)
        {
            var result = await _condominiumMgtContext.RaisonsCloture.FirstOrDefaultAsync(a => a.IdRaisonCloture == idRaisonCloture);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idRaisonCloture);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.RaisonsCloture> CreerRaisonClotureBis(DAL.EFEntities.RaisonsCloture nouvelleRaisonCloture)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.RaisonsCloture.AddAsync(nouvelleRaisonCloture);
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
            return nouvelleRaisonCloture;
        }
    }
}
