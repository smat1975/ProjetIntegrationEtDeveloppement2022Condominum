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
    public class PaiementsRepository : IPaiementsRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public PaiementsRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Paiements
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Paiements>> ListAllPaiements()
        {

            return (IEnumerable<DAL.EFEntities.Paiements>)await _condominiumMgtContext.Paiements.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Paiement
        /// <param name="idPaiement"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Paiements> DetailsPaiement(int idPaiement)
        {
            try
            {

                return await _condominiumMgtContext.Paiements.Where(x => x.IdPaiement == idPaiement).FirstOrDefaultAsync();

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
        /// Paiements d'un CompteBque Payeur déterminé
        /// <param name="idCompteBquePayeur"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Paiements>> GetPaiementsFromCompteBquePayeur(int idCompteBquePayeur)
        {
            try
            {
                return await _condominiumMgtContext.Paiements.Where(x => x.IdCompteBquePayeur == idCompteBquePayeur).ToListAsync();
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
        /// Paiements d'un Coproprietaire déterminé!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        /*public async Task<IEnumerable<DAL.EFEntities.Paiements>> GetPaiementsFromCoproprietaire(int idCoproprietaire)
        {
            try
            {
                return await _condominiumMgtContext.Paiements.Where(x => x.IdCoproprietaire == idCoproprietaire).ToListAsync();
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
        /// Créer/ajouter un nouveau Paiement
        /// </summary>
        /// <param name="nouveauPaiement">Objet contenu Paiement</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Paiements> CreerPaiement(DAL.EFEntities.Paiements nouveauPaiement)
        {
            var result = await _condominiumMgtContext.Paiements.AddAsync(nouveauPaiement);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Paiement existant
        /// </summary>
        /// <param name="idPaiement">Identifiant de l'objet</param>
        /// <param name="paiement">Objet contenu Paiements</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Paiements> ModifierPaiement(int idPaiement, DAL.EFEntities.Paiements paiement)
        {

            if (idPaiement != paiement.IdPaiement)
            {
                return null;
            }

            _condominiumMgtContext.Entry(paiement).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return paiement;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Paiement existant
        /// </summary>
        /// <param name="idPaiement">Identifiant de l'objet</param>
        /// <param name="paiement">Objet contenu Paiements</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Paiements> ModifierPaiementBis(DAL.EFEntities.Paiements paiement)
        {
            var content = await _condominiumMgtContext.Paiements.Where(x => x.IdPaiement == paiement.IdPaiement).FirstOrDefaultAsync();

            if (content != null)
            {

                content.IdCompteBquePayeur = paiement.IdCompteBquePayeur;
                content.NomPayeurAutre = paiement.NomPayeurAutre;
                content.Communication = paiement.Communication;
                content.Montant = paiement.Montant;
                content.DateEnregistrement = paiement.DateEnregistrement;
                content.DateDocument = paiement.DateDocument;
                content.NumDocument = paiement.NumDocument;
                content.Remarque = paiement.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un Paiement
        /// </summary>
        /// <param name="idPaiement">Identifiant du Paiements</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Paiements> SupprimerPaiement(int idPaiement)
        {
            var result = await _condominiumMgtContext.Paiements.FirstOrDefaultAsync(a => a.IdPaiement == idPaiement);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idPaiement);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Paiements> CreerPaiementBis(DAL.EFEntities.Paiements nouveauPaiement)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Paiements.AddAsync(nouveauPaiement);
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
            return nouveauPaiement;
        }

        //OK BON//
        /// <summary>
        /// Paiements pour un Coproprietaire déterminé
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Paiements>> GetPaiementsForCopropietaire(string idCoproprietaire)
        {
            var listeCompteBqueCoproprietaire = await _condominiumMgtContext.ComptesBque.Where(x => x.IdCoproprietaire == idCoproprietaire).ToListAsync();
            List<Paiements> listePaiements = new List<Paiements>();

            foreach (var compteBque in listeCompteBqueCoproprietaire)
            {
                try
                {
                    var response = await _condominiumMgtContext.Paiements.Where(x => x.IdCompteBquePayeur == compteBque.IdCompteBque).ToListAsync();
                    foreach (var paiement in response)
                    {
                        listePaiements.Add(paiement);
                    }
                }
                //!\\A REGLER!!!!//!\\
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    throw e;
                }
            }
            return listePaiements;

        }
    }
}
