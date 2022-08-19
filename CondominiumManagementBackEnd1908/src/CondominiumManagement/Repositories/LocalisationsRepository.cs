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
    public class LocalisationsRepository : ILocalisationsRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public LocalisationsRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Localisations
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Localisations>> ListAllLocalisations()
        {

            return (IEnumerable<DAL.EFEntities.Localisations>)await _condominiumMgtContext.Localisations.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Localisation
        /// <param name="idLocalisation"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Localisations> DetailsLocalisation(int idLocalisation)
        {
            try
            {

                return await _condominiumMgtContext.Localisations.Where(x => x.IdLocalisation == idLocalisation).FirstOrDefaultAsync();

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
        /// Localisation pour un Lot déterminé!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// <param name="idLot"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Lots>> GetLocalisationForLot(int idLot)
        {
            try
            {
                return await _condominiumMgtContext.Lots.Where(x => x.IdLot == idLot).ToListAsync();
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
        /// Liste des lots pour un Localisation déterminée!!!
        /// <param name="idLocalisation"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Lots>> ListeAllLotsForLocalisation(int idLocalisation)
        {
            try
            {
                return await _condominiumMgtContext.Lots.Where(x => x.IdLocalisation == idLocalisation).ToListAsync();
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
        /// Créer/ajouter une nouvelle Localisation
        /// </summary>
        /// <param name="nouvelleLocalisation">Objet contenu Localisations</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Localisations> CreerLocalisation(DAL.EFEntities.Localisations nouvelleLocalisation)
        {
            var result = await _condominiumMgtContext.Localisations.AddAsync(nouvelleLocalisation);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier une Localisation existante
        /// </summary>
        /// <param name="idLocalisation">Identifiant de l'objet</param>
        /// <param name="localisation">Objet contenu Localisations</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Localisations> ModifierLocalisation(int idLocalisation, DAL.EFEntities.Localisations localisation)
        {

            if (idLocalisation != localisation.IdLocalisation)
            {
                return null;
            }

            _condominiumMgtContext.Entry(localisation).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return localisation;
        }

        //OK BON//
        /// <summary>
        /// Modifier une Localisation existante
        /// </summary>
        /// <param name="idLocalisation">Identifiant de l'objet</param>
        /// <param name="localisation">Objet contenu Localisations</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Localisations> ModifierLocalisationBis(DAL.EFEntities.Localisations localisation)
        {
            var content = await _condominiumMgtContext.Localisations.Where(x => x.IdLocalisation == localisation.IdLocalisation).FirstOrDefaultAsync();

            if (content != null)
            {

                content.Adresse = localisation.Adresse;
                content.CodeLocalisation = localisation.CodeLocalisation;
                content.Description = localisation.Description;
                content.DateDebut = localisation.DateDebut;
                content.DateFin = localisation.DateFin;
                content.Remarque = localisation.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer une Localisation!!!!!!!!!!!!!!!!A VERIFIER SI PAS BESOIN D'UNE TRANSACTION CAR EFFECEMENT DEFINITIF!!!!!!!!!!!!!!!!
        /// </summary>
        /// <param name="idLocalisation">Identifiant du Localisations</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Localisations> SupprimerLocalisation(int idLocalisation)
        {
            var result = await _condominiumMgtContext.Localisations.FirstOrDefaultAsync(a => a.IdLocalisation == idLocalisation);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idLocalisation);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Localisations> CreerLocalisationBis(DAL.EFEntities.Localisations nouvelleLocalisation)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Localisations.AddAsync(nouvelleLocalisation);
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
            return nouvelleLocalisation;
        }

    }

}
