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
    public class DestinationsRepository : IDestinationsRepository
    {

        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public DestinationsRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Destinations
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Destinations>> ListAllDestinations()
        {

            return (IEnumerable<DAL.EFEntities.Destinations>)await _condominiumMgtContext.Destinations.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Destination
        /// <param name="idDestination"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Destinations> DetailsDestination(int idDestination)
        {
            try
            {

                return await _condominiumMgtContext.Destinations.Where(x => x.IdDestination == idDestination).FirstOrDefaultAsync();

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
        /// Destination pour le(s) message(s) d'un Copropriétaire déterminé
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Destinations>> GetDestinationsForCoproprietaire(string idCoproprietaire)
        {
            try
            {
                return await _condominiumMgtContext.Destinations.Where(x => x.IdDestinataire == idCoproprietaire).ToListAsync();
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
        /// Liste des Destinations pour un Message déterminé
        /// <param name="idMessage"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Destinations>> GetDestinationsForMessage(int idMessage)
        {
            try
            {
                return await _condominiumMgtContext.Destinations.Where(x => x.IdMessage == idMessage).ToListAsync();
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
        /// Créer/ajouter une nouvelle Destination
        /// </summary>
        /// <param name="nouvelleDestination">Objet contenu Destination</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Destinations> CreerDestination(DAL.EFEntities.Destinations nouvelleDestination)
        {
            var result = await _condominiumMgtContext.Destinations.AddAsync(nouvelleDestination);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier une Destination existante
        /// </summary>
        /// <param name="idDestination">Identifiant de l'objet</param>
        /// <param name="destination">Objet contenu Destinations</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Destinations> ModifierDestination(int idDestination, DAL.EFEntities.Destinations destination)
        {

            if (idDestination != destination.IdDestination)
            {
                return null;
            }

            _condominiumMgtContext.Entry(destination).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return destination;
        }

        //OK BON//
        /// <summary>
        /// Modifier une Destination existante
        /// </summary>
        /// <param name="idDestination">Identifiant de l'objet</param>
        /// <param name="destination">Objet contenu Destinations</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Destinations> ModifierDestinationBis(DAL.EFEntities.Destinations destination)
        {
            var content = await _condominiumMgtContext.Destinations.Where(x => x.IdDestination == destination.IdDestination).FirstOrDefaultAsync();

            if (content != null)
            {

                content.IdMessage = destination.IdMessage;
                content.IdDestinataire = destination.IdDestinataire;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer une Destination
        /// </summary>
        /// <param name="idDestination">Identifiant du Destinations</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Destinations> SupprimerDestination(int idDestination)
        {
            var result = await _condominiumMgtContext.Destinations.FirstOrDefaultAsync(a => a.IdDestination == idDestination);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idDestination);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Destinations> CreerDestinationBis(DAL.EFEntities.Destinations nouvelleDestination)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Destinations.AddAsync(nouvelleDestination);
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
            return nouvelleDestination;
        }

        //OK BON//
        /// <summary>
        /// Créer/ajouter un nouvelle Destination Retry
        /// </summary>
        /// <param name="nouvelleDestination">Objet contenu Destination</param>
        /// <returns></returns>
        public async Task<ActionResult<DAL.EFEntities.Destinations>> CreerDestinationRetry(DAL.EFEntities.Destinations nouvelleDestination)
        {
            try
            {
                var result = await _condominiumMgtContext.Destinations.AddAsync(nouvelleDestination);
                await _condominiumMgtContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
