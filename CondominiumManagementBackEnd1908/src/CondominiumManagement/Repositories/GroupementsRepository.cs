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
    public class GroupementsRepository : IGroupementsRepository
    {

        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public GroupementsRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Groupements
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Groupements>> ListAllGroupements()
        {

            return (IEnumerable<DAL.EFEntities.Groupements>)await _condominiumMgtContext.Groupements.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Groupement
        /// <param name="idGroupement"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Groupements> DetailsGroupement(int idGroupement)
        {
            try
            {

                return await _condominiumMgtContext.Groupements.Where(x => x.IdGroupement == idGroupement).FirstOrDefaultAsync();

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
        /// Groupement pour un Lot déterminé !!!!!!!!!!!!!!!!!!!!
        /// <param name="idLot"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Groupements>> GetGroupementForLot(int idLot)
        {
            try
            {
                return await _condominiumMgtContext.Groupements.Where(x => x.IdLot == idLot).ToListAsync();
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
        /// Groupements pour un Groupe déterminé !!!!!!!!!!!!!!!!!!!!
        /// <param name="idGroupe"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Groupements>> GetGroupementsForGroupe(int idGroupe)
        {
            try
            {
                return await _condominiumMgtContext.Groupements.Where(x => x.IdGroupe == idGroupe).ToListAsync();
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
        /// Groupe pour un Groupement déterminé !!!!!!!!!!!!!!!!!!!!
        /// <param name="idGroupement"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Groupes> GetGroupeForGroupement(int idGroupement)
        {
            var response = await _condominiumMgtContext.Groupements.FirstOrDefaultAsync(x => x.IdGroupement == idGroupement);
            try
            {
                var result = await _condominiumMgtContext.Groupes.FirstOrDefaultAsync(x => x.IdGroupe == response.IdGroupe);
                return result;
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
        /// Groupements pour un coproprietaire déterminé!!!!!!!!!!!!!!!!!!!
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Groupements>> GetGroupementsForCoproprietaire(string idCoproprietaire)
        {
            var listeCoproprietesCoproprietaire = await _condominiumMgtContext.Coproprietes.Where(x => x.IdCoproprietaire == idCoproprietaire).ToListAsync();
            List<Lots> listeLotsCoproprietaire = new List<Lots>();
            List<Groupements> listeGroupementsCoproprietaire = new List<Groupements>();

            try
            {
                foreach (var copropriete in listeCoproprietesCoproprietaire)
                {
                    var result = await _condominiumMgtContext.Lots.FirstOrDefaultAsync(x => x.IdLot == copropriete.IdLot);
                    listeLotsCoproprietaire.Add(result);
                }
                foreach (var lot in listeLotsCoproprietaire)
                {
                    var result = await _condominiumMgtContext.Groupements.FirstOrDefaultAsync(x => x.IdLot == lot.IdLot);
                    listeGroupementsCoproprietaire.Add(result);
                }
                return listeGroupementsCoproprietaire;
            }
            //!\\A REGLER!!!!//!\\
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw e;
            }
        }

        /*
        //!\\A vérifier!!!!//!\\
        | 
        V
        */
        //OK BON//
        /// <summary>
        /// Créer/ajouter un nouveau Groupement
        /// </summary>
        /// <param name="nouveauGroupement">Objet contenu Groupement</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Groupements> CreerGroupement(DAL.EFEntities.Groupements nouveauGroupement)
        {
            var result = await _condominiumMgtContext.Groupements.AddAsync(nouveauGroupement);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Groupement existant
        /// </summary>
        /// <param name="idGroupement">Identifiant de l'objet</param>
        /// <param name="Groupement">Objet contenu Groupements</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Groupements> ModifierGroupement(int idGroupement, DAL.EFEntities.Groupements Groupement)
        {

            if (idGroupement != Groupement.IdGroupement)
            {
                return null;
            }

            _condominiumMgtContext.Entry(Groupement).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return Groupement;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Groupement existant
        /// </summary>
        /// <param name="idGroupement">Identifiant de l'objet</param>
        /// <param name="groupement">Objet contenu Groupements</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Groupements> ModifierGroupementBis(DAL.EFEntities.Groupements groupement)
        {
            var content = await _condominiumMgtContext.Groupements.Where(x => x.IdGroupement == groupement.IdGroupement).FirstOrDefaultAsync();

            if (content != null)
            {

                content.IdGroupe = groupement.IdGroupe;
                content.IdLot = groupement.IdLot;
                content.DateDebutGroupement = groupement.DateDebutGroupement;
                content.DateFinGroupement = groupement.DateFinGroupement;
                content.Remarque = groupement.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un Groupement
        /// </summary>
        /// <param name="idGroupement">Identifiant du Groupements</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Groupements> SupprimerGroupement(int idGroupement)
        {
            var result = await _condominiumMgtContext.Groupements.FirstOrDefaultAsync(a => a.IdGroupement == idGroupement);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idGroupement);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Groupements> CreerGroupementBis(DAL.EFEntities.Groupements nouveauGroupement)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Groupements.AddAsync(nouveauGroupement);
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
            return nouveauGroupement;
        }

    }
}
