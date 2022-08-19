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
    public class GroupesRepository : IGroupesRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public GroupesRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Groupes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Groupes>> ListAllGroupes()
        {

            return (IEnumerable<DAL.EFEntities.Groupes>)await _condominiumMgtContext.Groupes.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Groupe
        /// <param name="idGroupe"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Groupes> DetailsGroupe(int idGroupe)
        {
            try
            {

                return await _condominiumMgtContext.Groupes.Where(x => x.IdGroupe == idGroupe).FirstOrDefaultAsync();

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
        /// Groupes pour un Groupement déterminé!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// <param name="idGroupement"></param>
        /// </summary>
        /// <returns></returns>
        /*public async Task<IEnumerable<DAL.EFEntities.Groupes>> GetGroupesForGroupement(int idGroupement)
        {
            try
            {
                return await _condominiumMgtContext.Groupes.Where(x => x.Groupements == idGroupement).ToListAsync();
            }
            //!\\A REGLER!!!!//!\\
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw e;
            }
        }*/

        /*------------------------
        //!\\A vérifier!!!!//!\\
        | 
        V
        */
        //OK BON//
        /// <summary>
        /// Créer/ajouter un nouveau Groupe
        /// </summary>
        /// <param name="nouveauGroupe">Objet contenu Groupes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Groupes> CreerGroupe(DAL.EFEntities.Groupes nouveauGroupe)
        {
            var result = await _condominiumMgtContext.Groupes.AddAsync(nouveauGroupe);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Groupe existant
        /// </summary>
        /// <param name="idGroupe">Identifiant de l'objet</param>
        /// <param name="groupe">Objet contenu Groupes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Groupes> ModifierGroupe(int idGroupe, DAL.EFEntities.Groupes groupe)
        {

            if (idGroupe != groupe.IdGroupe)
            {
                return null;
            }

            _condominiumMgtContext.Entry(groupe).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return groupe;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Groupe existant
        /// </summary>
        /// <param name="idGroupe">Identifiant de l'objet</param>
        /// <param name="groupe">Objet contenu Groupes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Groupes> ModifierGroupeBis(DAL.EFEntities.Groupes groupe)
        {
            var content = await _condominiumMgtContext.Groupes.Where(x => x.IdGroupe == groupe.IdGroupe).FirstOrDefaultAsync();

            if (content != null)
            {

                content.Denomination = groupe.Denomination;
                content.Description = groupe.Description;
                content.Remarque = groupe.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un Groupe
        /// </summary>
        /// <param name="idGroupe">Identifiant du Groupes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Groupes> SupprimerGroupe(int idGroupe)
        {
            var result = await _condominiumMgtContext.Groupes.FirstOrDefaultAsync(a => a.IdGroupe == idGroupe);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idGroupe);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Groupes> CreerGroupeBis(DAL.EFEntities.Groupes nouveauGroupe)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Groupes.AddAsync(nouveauGroupe);
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
            return nouveauGroupe;
        }

    }
}
