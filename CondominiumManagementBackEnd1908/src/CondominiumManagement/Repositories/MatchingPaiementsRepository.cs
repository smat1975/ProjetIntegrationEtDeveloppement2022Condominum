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
    public class MatchingsPaiementsRepository : IMatchingsPaiementsRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public MatchingsPaiementsRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de tous les MatchingsPaiements
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.MatchingsPaiements>> ListAllMatchingsPaiements()
        {

            return (IEnumerable<DAL.EFEntities.MatchingsPaiements>)await _condominiumMgtContext.MatchingsPaiements.Include(o => o.IdPaiement).Include(p => p.IdDecompte).ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails MatchingPaiement
        /// <param name="idMatchingPaiement"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.MatchingsPaiements> DetailsMatchingPaiement(int idMatchingPaiement)
        {
            try
            {

                return await _condominiumMgtContext.MatchingsPaiements.Where(x => x.IdMatchingPaiement == idMatchingPaiement).FirstOrDefaultAsync();

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
        /// MatchingsPaiements pour un Paiement déterminé
        /// <param name="idPaiement"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.MatchingsPaiements>> GetMatchingsPaiementsForPaiement(int idPaiement)
        {
            try
            {
                return await _condominiumMgtContext.MatchingsPaiements.Where(x => x.IdPaiement == idPaiement).ToListAsync();
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
        /// MatchingsPaiements pour un décompte déterminé
        /// <param name="idDecompte"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.MatchingsPaiements>> GetMatchingsPaiementsForDecompte(int idDecompte)
        {
            try
            {
                return await _condominiumMgtContext.MatchingsPaiements.Where(x => x.IdDecompte == idDecompte).ToListAsync();
            }
            //!\\A REGLER!!!!//!\\
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw e;
            }
        }

        //!\\A FAIRE ABSOLUMENT POUR UN COPROPRIETAIRE VIA TOUS SES COMPTES BANCAIRES!!!!//!\\

        //OK BON//
        /// <summary>
        /// MatchingsPaiements pour un compte bancaire déterminé
        /// <param name="idCompteBque"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.MatchingsPaiements>> GetMatchingsPaiementsForCompteBque(int idCompteBque)
        {
            var listePaiements = await _condominiumMgtContext.Paiements.Where(x => x.IdCompteBquePayeur == idCompteBque).ToListAsync();
            List<MatchingsPaiements> listeMatchingPaiements = new List<MatchingsPaiements>();

            foreach (var paiement in listePaiements)
            {
                try
                {
                    var response = await _condominiumMgtContext.MatchingsPaiements.FirstOrDefaultAsync(x => x.IdPaiement == paiement.IdPaiement);
                    listeMatchingPaiements.Add(response);
                }
                //!\\A REGLER!!!!//!\\
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    throw e;
                }
            }
            return listeMatchingPaiements;
        }


        /*------------------------
        //!\\A vérifier!!!!//!\\
        | 
        V
        */
        //OK BON//
        /// <summary>
        /// Créer/ajouter un nouveau MatchingPaiement
        /// </summary>
        /// <param name="nouveauMatchingPaiement">Objet contenu MatchingsPaiements</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.MatchingsPaiements> CreerMatchingPaiement(DAL.EFEntities.MatchingsPaiements nouveauMatchingPaiement)
        {
            var result = await _condominiumMgtContext.MatchingsPaiements.AddAsync(nouveauMatchingPaiement);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un MatchingPaiement existant
        /// </summary>
        /// <param name="idMatchingPaiement">Identifiant de l'objet</param>
        /// <param name="matchingPaiement">Objet contenu MatchingsPaiements</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.MatchingsPaiements> ModifierMatchingPaiement(int idMatchingPaiement, DAL.EFEntities.MatchingsPaiements matchingPaiement)
        {

            if (idMatchingPaiement != matchingPaiement.IdMatchingPaiement)
            {
                return null;
            }

            _condominiumMgtContext.Entry(matchingPaiement).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return matchingPaiement;
        }

        //OK BON//
        /// <summary>
        /// Modifier un matchingPaiement existant
        /// </summary>
        /// <param name="idmatchingPaiement">Identifiant de l'objet</param>
        /// <param name="matchingPaiement">Objet contenu MatchingsPaiements</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.MatchingsPaiements> ModifierMatchingPaiementBis(DAL.EFEntities.MatchingsPaiements matchingPaiement)
        {
            var content = await _condominiumMgtContext.MatchingsPaiements.Where(x => x.IdMatchingPaiement == matchingPaiement.IdMatchingPaiement).FirstOrDefaultAsync();

            if (content != null)
            {
                content.IdDecompte = matchingPaiement.IdDecompte;
                content.IdPaiement = matchingPaiement.IdPaiement;
                content.Montant = matchingPaiement.Montant;
                content.DateEnregistrement = matchingPaiement.DateEnregistrement;
                content.Remarque = matchingPaiement.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un matchingPaiement
        /// </summary>
        /// <param name="idMatchingPaiement">Identifiant du MatchingsPaiements</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.MatchingsPaiements> SupprimerMatchingPaiement(int idMatchingPaiement)
        {
            var result = await _condominiumMgtContext.MatchingsPaiements.FirstOrDefaultAsync(a => a.IdMatchingPaiement == idMatchingPaiement);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idMatchingPaiement);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.MatchingsPaiements> CreerMatchingPaiementBis(DAL.EFEntities.MatchingsPaiements nouveauMatchingPaiement)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.MatchingsPaiements.AddAsync(nouveauMatchingPaiement);
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
            return nouveauMatchingPaiement;
        }
    }
}
