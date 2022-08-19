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
    public class ComptesBqueRepository : IComptesBqueRepository
    {

        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public ComptesBqueRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Comptes Bque
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.ComptesBque>> ListAllComptesBque()
        {

            return (IEnumerable<DAL.EFEntities.ComptesBque>) await _condominiumMgtContext.ComptesBque.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Compte Bque
        /// <param name="idCompteBque"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.ComptesBque> DetailsComptesBque(int idCompteBque)
        {
            try
            {

                return await _condominiumMgtContext.ComptesBque.Where(x => x.IdCompteBque == idCompteBque).FirstOrDefaultAsync();

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
        /// Comptes Bque pour un Copropriétaire déterminé
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.ComptesBque>> GetComptesBqueForCoproprietaire(string idCoproprietaire)
        {
            try
            {
                return await _condominiumMgtContext.ComptesBque.Where(x => x.IdCoproprietaire == idCoproprietaire).ToListAsync();
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
        /// Créer/ajouter une nouveau Compte Bque
        /// </summary>
        /// <param name="nouveauCompteBque">Objet contenu Compte Bque</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.ComptesBque> CreerCompteBque(DAL.EFEntities.ComptesBque nouveauCompteBque)
        {
            var result = await _condominiumMgtContext.ComptesBque.AddAsync(nouveauCompteBque);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Compte Bque existant
        /// </summary>
        /// <param name="idCompteBque">Identifiant de l'objet</param>
        /// <param name="compteBque">Objet contenu ComptesBque</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.ComptesBque> ModifierCompteBque(int idCompteBque, DAL.EFEntities.ComptesBque compteBque)
        {

            if (idCompteBque != compteBque.IdCompteBque)
            {
                return null;
            }

            _condominiumMgtContext.Entry(compteBque).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return compteBque;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Compte Bque existant
        /// </summary>
        /// <param name="idCompteBque">Identifiant de l'objet</param>
        /// <param name="compteBque">Objet contenu ComptesBque</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.ComptesBque> ModifierCompteBqueBis(DAL.EFEntities.ComptesBque compteBque)
        {
            var content = await _condominiumMgtContext.ComptesBque.Where(x => x.IdCompteBque == compteBque.IdCompteBque).FirstOrDefaultAsync();

            if (content != null)
            {

                content.NomBque = compteBque.NomBque;
                content.NumCompteBque = compteBque.NumCompteBque;
                content.IdCoproprietaire = compteBque.IdCoproprietaire;
                content.Description = compteBque.Description;
                content.ActifON = compteBque.ActifON;
                content.Remarque = compteBque.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un compte Bque
        /// </summary>
        /// <param name="idComptesBque">Identifiant du ComptesBque</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.ComptesBque> SupprimerCompteBque(int idCompteBque)
        {
            var result = await _condominiumMgtContext.ComptesBque.FirstOrDefaultAsync(a => a.IdCompteBque == idCompteBque);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idCompteBque);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.ComptesBque> CreerCompteBqueBis(DAL.EFEntities.ComptesBque nouveauCompteBque)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.ComptesBque.AddAsync(nouveauCompteBque);
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
            return nouveauCompteBque;
        }




    }
}
