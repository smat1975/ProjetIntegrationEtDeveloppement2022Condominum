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
    public class PeriodesRepository : IPeriodesRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public PeriodesRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Periodes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Periodes>> ListAllPeriodes()
        {

            return (IEnumerable<DAL.EFEntities.Periodes>)await _condominiumMgtContext.Periodes.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails periode
        /// <param name="idPeriode"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Periodes> DetailsPeriode(int idPeriode)
        {
            try
            {

                return await _condominiumMgtContext.Periodes.Where(x => x.IdPeriode == idPeriode).FirstOrDefaultAsync();

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
        /// Periode pour un Decompte déterminé
        /// <param name="idDecompte"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Decomptes> GetPeriodeForDecompte(int idDecompte)
        {
            try
            {
                return await _condominiumMgtContext.Decomptes.Where(x => x.IdDecompte == idDecompte).FirstOrDefaultAsync();
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
        /// Liste Decomptes pour une Periode déterminé
        /// <param name="idPeriode"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Decomptes>> GetDecomptesForPeriode(int idPeriode)
        {
            try
            {
                return await _condominiumMgtContext.Decomptes.Where(x => x.IdPeriode == idPeriode).ToListAsync();
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
        /// Créer/ajouter une nouvelle periode
        /// </summary>
        /// <param name="nouvellePeriode">Objet contenu Periodes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Periodes> CreerNouvellePeriode(DAL.EFEntities.Periodes nouvellePeriode)
        {
            var result = await _condominiumMgtContext.Periodes.AddAsync(nouvellePeriode);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un periode existant
        /// </summary>
        /// <param name="idperiode">Identifiant de l'objet</param>
        /// <param name="periode">Objet contenu Periodes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Periodes> ModifierPeriode(int idperiode, DAL.EFEntities.Periodes periode)
        {

            if (idperiode != periode.IdPeriode)
            {
                return null;
            }

            _condominiumMgtContext.Entry(periode).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return periode;
        }

        //OK BON//
        /// <summary>
        /// Modifier un periode existant
        /// </summary>
        /// <param name="idperiode">Identifiant de l'objet</param>
        /// <param name="periode">Objet contenu Periodes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Periodes> ModifierPeriodeBis(DAL.EFEntities.Periodes periode)
        {
            var content = await _condominiumMgtContext.Periodes.Where(x => x.IdPeriode == periode.IdPeriode).FirstOrDefaultAsync();

            if (content != null)
            {
                content.Denomination = periode.Denomination;
                content.Annee = periode.Annee;
                content.DateDebut = periode.DateDebut;
                content.DateFin = periode.DateFin;
                content.Remarque = periode.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer une Periode
        /// </summary>
        /// <param name="idPeriode">Identifiant du Periodes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Periodes> SupprimerPeriode(int idPeriode)
        {
            var result = await _condominiumMgtContext.Periodes.FirstOrDefaultAsync(a => a.IdPeriode == idPeriode);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idPeriode);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Periodes> CreerPeriodeBis(DAL.EFEntities.Periodes nouvellePeriode)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Periodes.AddAsync(nouvellePeriode);
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
            return nouvellePeriode;
        }

    }
}
