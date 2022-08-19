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
using CondominiumManagement.Repositories;
using CondominiumManagement.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CondominiumManagement.Repositories
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;
        private readonly string _connectionString;

        public MessagesRepository(CondominiumMgtContext condominiumMgtContext, IConfiguration configuration/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
            _condominiumMgtContext = condominiumMgtContext;
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Messages
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Messages>> ListAllMessages()
        {

            return (IEnumerable<DAL.EFEntities.Messages>)await _condominiumMgtContext.Messages.ToListAsync();

        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Messages Version Complexe DTO
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CondominiumManagement.Models.DTOs.MessagesComplexeDto>> ListAllMessagesComplexeDto()
        {

            return (IEnumerable<CondominiumManagement.Models.DTOs.MessagesComplexeDto>)await _condominiumMgtContext.Messages.ToListAsync();

        }

        //OK BON//
        /// <summary>
        /// Liste de toutes les Messages Version Simple
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CondominiumManagement.Models.Messages>> ListAllMessagesSimple()
        {

            return (IEnumerable<Models.Messages>)await _condominiumMgtContext.Messages.ToListAsync();

        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Messages Version Complet
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Messages>> ListAllMessagesComplet()
        {
            return await _condominiumMgtContext.Messages.Include(o => o.Annexes).ThenInclude(p => p.Photos).Include(d => d.Destinations).ToListAsync();
        }


        //OK BON//
        /// <summary>
        /// Détails Message
        /// <param name="idMessage"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Messages> DetailsMessage(int idMessage)
        {
            try
            {

                return await _condominiumMgtContext.Messages.Where(x => x.IdMessage == idMessage).FirstOrDefaultAsync();

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
        /// Détails Message-Annexes complexe
        /// <param name="idMessage"></param>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DAL.EFEntities.Messages> AllMessagesComplexe
        {
                get
                {
                    return  _condominiumMgtContext.Messages.Include(c => c.Annexes);
                }
        }

        //OK BON//
        /// <summary>
        /// Trouver le Message par son identifiant
        /// <param name="idMessage"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Messages> GetMessageById(int idMessage)
        {
            try
            {

                var message = await _condominiumMgtContext.Messages.FindAsync(idMessage);

                return message;
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
        /// Messages envoyés par un Expediteur(Copropriétaire) déterminé
        /// <param name="idExpediteur"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Messages>> GetMessagesOfCoproprietaireExpediteur(string idExpediteur)
        {
            try
            {
                return await _condominiumMgtContext.Messages.Where(x => x.IdExpediteur == idExpediteur).ToListAsync();
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
        /// Créer/ajouter un nouveau Message Retry
        /// </summary>
        /// <param name="nouveauMessage">Objet contenu Message</param>
        /// <returns></returns>
        public async Task<ActionResult<DAL.EFEntities.Messages>> CreerMessageRetry(DAL.EFEntities.Messages nouveauMessage)
        {
            try
            {
                var result = await _condominiumMgtContext.Messages.AddAsync(nouveauMessage);
                await _condominiumMgtContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //OK BON//
        /// <summary>
        /// Creer un Message 
        /// </summary>
        /// <param name="message">Objet contenu Messages</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Messages> CreerMessageTer(DAL.EFEntities.Messages message)
        {
            try
            {
                using (SqlConnection oConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AddMessage", oConn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var oParam1 = new SqlParameter("@IdExpediteur", message.IdExpediteur);
                        var oParam2 = new SqlParameter("@DateExpedition", message.DateExpedition);
                        var oParam3 = new SqlParameter("@TitreMessage", message.TitreMessage);
                        var oParam4 = new SqlParameter("@ContenuMessage", message.ContenuMessage);
                        var oParam5 = new SqlParameter("@IdTypeMessage", message.IdTypeMessage);
                        var oParam6 = new SqlParameter("@Validation", message.Validation);
                        cmd.Parameters.Add(oParam1);
                        cmd.Parameters.Add(oParam2);
                        cmd.Parameters.Add(oParam3);
                        cmd.Parameters.Add(oParam4);
                        cmd.Parameters.Add(oParam5);
                        cmd.Parameters.Add(oParam6);
                        await oConn.OpenAsync();
                        cmd.ExecuteNonQuery();
                        oConn.Close();

                        return message;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //OK BON//
        /// <summary>
        /// Modifier un Message existant
        /// </summary>
        /// <param name="idMessage">Identifiant de l'objet</param>
        /// <param name="message">Objet contenu Messages</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Messages> ModifierMessage(int idMessage, DAL.EFEntities.Messages message)
        {

            if (idMessage != message.IdMessage)
            {
                return null;
            }

            _condominiumMgtContext.Entry(message).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return message;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Message existant
        /// </summary>
        /// <param name="idMessage">Identifiant de l'objet</param>
        /// <param name="message">Objet contenu Messages</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Messages> ModifierMessageBis(DAL.EFEntities.Messages message)
        {
            var content = await _condominiumMgtContext.Messages.Where(x => x.IdMessage == message.IdMessage).FirstOrDefaultAsync();

            if (content != null)
            {


                content.IdExpediteur = message.IdExpediteur;
                content.DateExpedition = message.DateExpedition;
                content.TitreMessage = message.TitreMessage;
                content.ContenuMessage = message.ContenuMessage;
                content.IdTypeMessage = message.IdTypeMessage;
                content.Validation = message.Validation;



                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un Message
        /// </summary>
        /// <param name="idMessage">Identifiant du Messages</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Messages> SupprimerMessage(int idMessage)    
        {
            var result = await _condominiumMgtContext.Messages.FirstOrDefaultAsync(a => a.IdMessage == idMessage);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idMessage);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un Message BIS
        /// </summary>
        /// <param name="idMessage">Identifiant du Message</param>
        /// <returns></returns>
        public async Task<IActionResult> SupprimerMessageBIS(int idMessage)
        {
            var result = await _condominiumMgtContext.Messages.FirstOrDefaultAsync(a => a.IdMessage == idMessage);


            if (result!= null)
            {
                _condominiumMgtContext.Remove(idMessage);
                await _condominiumMgtContext.SaveChangesAsync();
            }

            return null;

        }


        //OK BON//
        /// <summary>
        /// Supprimer un Message ById
        /// </summary>
        /// <param name="idMessage">Identifiant du Message</param>
        /// <returns></returns>
        public async Task<IActionResult> SupprimerMessageById(int idMessage)
        {
                var content = await _condominiumMgtContext.Messages.Where(x => x.IdMessage == idMessage).FirstOrDefaultAsync();

                if (content != null)
                {
                    _condominiumMgtContext.Remove(idMessage);
                    await _condominiumMgtContext.SaveChangesAsync();
                }

                return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un message TER
        /// </summary>
        /// <param name="idMessage">Identifiant du message</param>
        /// <returns></returns>
        public async Task<ActionResult> SupprimerMessageTER(int idMessage)
        {
            var result = await _condominiumMgtContext.Messages.Where(x => x.IdMessage == idMessage).FirstOrDefaultAsync();


            if (result != null)
            {
                _condominiumMgtContext.Remove(idMessage);
                await _condominiumMgtContext.SaveChangesAsync();
            }

            return null;
        }

        //OK PAS BON//
        /// <summary>
        /// Supprimer un message QUATER
        /// </summary>
        /// <param name="message">Objet Message</param>
        /// <returns></returns>
        //public async Task<CondominiumManagement.Models.Messages> SupprimerMessageQUATER(Messages message)
        //{
        //    //var result = await _condominiumMgtContext.Messages.Where(x => x.IdMessage == message.IdMessage).FirstOrDefaultAsync();

        //    if (message != null)
        //    {
        //        _condominiumMgtContext.Remove(message);
        //        await _condominiumMgtContext.SaveChangesAsync();
        //    }

        //    return null;
        //}


        //OK BON MAIS SOLUTION DE SECOUR CAR PROBLEMES AVEC LES METHODES DELETE AVEC EFCORE => POSSIBLES PROBLEMES AVEC EFCORE????//
        /// <summary>
        /// Supprimer un message QUATER
        /// </summary>
        /// <param name="message">Objet Message</param>
        /// <returns></returns>
        public async Task<ActionResult> SupprimerMessageDirecte(int idMessage)
        {
            try
            {
                using (SqlConnection oConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteMessageById", oConn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdMessage", idMessage));
                        await oConn.OpenAsync();
                        cmd.ExecuteNonQuery();
                        oConn.Close();

                        return null;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Messages> CreerMessageBis(DAL.EFEntities.Messages nouveauMessage)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Messages.AddAsync(nouveauMessage);
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
            return nouveauMessage;
        }



        public async Task<DAL.EFEntities.Messages> AddAnnexeToMessage(int idMessage, Annexes nouvelleAnnexe)
        {
            var objetMessage = await _condominiumMgtContext.Messages.Where(x => x.IdMessage == idMessage).FirstOrDefaultAsync();

            if (objetMessage != null)
            {
                try
                {
                    objetMessage.Annexes.Add(nouvelleAnnexe);
                    await _condominiumMgtContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return null;
        }


        //public Messages nouveauMessage = new Messages();

        //public void AddToMessage(Photos nouvellePhoto) 
        //{
        //    var nouvelleAnnexe = new Annexes();
        //    nouvelleAnnexe.AnnexeIdPhoto = nouvellePhoto.IdPhoto;
        //    nouvelleAnnexe.AnnexePhotoRessource = nouvellePhoto.Ressource;

        //    this.nouveauMessage.Annexes.Add(nouvelleAnnexe);
        //}

        //public void AddAnnexeToMessage(Annexes nouvelleAnnexe)
        //{
        //    this.nouveauMessage.Annexes.Add(nouvelleAnnexe);
        //}


        //public void AddDestinationToMessage(Destinations nouvelleDestination)
        //{
        //    this.nouveauMessage.Destinations.Add(nouvelleDestination);
        //}


        public async Task<DAL.EFEntities.Destinations> AddDestinationToMessage(int idMessage, Destinations nouvelleDestination)
        {
            var objetMessage = await _condominiumMgtContext.Messages.Where(x => x.IdMessage == idMessage).FirstOrDefaultAsync();

            if (objetMessage != null)
            {
                try
                {
                    objetMessage.Destinations.Add(nouvelleDestination);
                    await _condominiumMgtContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return null;
        }

    }
}
