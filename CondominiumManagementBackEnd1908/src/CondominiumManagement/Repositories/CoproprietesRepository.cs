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
    public class CoproprietesRepository : ICoproprietesRepository
    {

        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public CoproprietesRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Coproprietes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Coproprietes>> ListAllCoproprietes()
        {

            return (IEnumerable<DAL.EFEntities.Coproprietes>)await _condominiumMgtContext.Coproprietes.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Copropriete
        /// <param name="idCopropriete"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietes> DetailsCopropriete(int idCopropriete)
        {
            try
            {

                return await _condominiumMgtContext.Coproprietes.Where(x => x.IdCopropriete == idCopropriete).FirstOrDefaultAsync();

            }
            //!\\A REGLER!!!!//!\\
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw e;
            }
        }


        //-------------Autres Méthodes A Ajouter------------------//

        //OK BON//
        /// <summary>
        /// Coproprietes pour un Copropriétaire déterminé
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Coproprietes>> GetCompteBqueForCopropriete(string idCoproprietaire)
        {
            try
            {
                return await _condominiumMgtContext.Coproprietes.Where(x => x.IdCoproprietaire == idCoproprietaire).ToListAsync();
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
        /// Coproprietes pour un Coproprietaire déterminé
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Coproprietes>> GetCoproprieteForCoproprietaire(string idCoproprietaire)
        {
            try
            {
                return await _condominiumMgtContext.Coproprietes.Where(x => x.IdCoproprietaire == idCoproprietaire).ToListAsync();
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
        /// Créer/ajouter une nouvelle Copropriete
        /// </summary>
        /// <param name="nouvelleCopropriete">Objet contenu Copropriete</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietes> CreerCopropriete(DAL.EFEntities.Coproprietes nouvelleCopropriete)
        {
            var result = await _condominiumMgtContext.Coproprietes.AddAsync(nouvelleCopropriete);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier une Copropriete existante
        /// </summary>
        /// <param name="idCopropriete">Identifiant de l'objet</param>
        /// <param name="copropriete">Objet contenu Coproprietes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietes> ModifierCopropriete(int idCopropriete, DAL.EFEntities.Coproprietes copropriete)
        {

            if (idCopropriete != copropriete.IdCopropriete)
            {
                return null;
            }

            _condominiumMgtContext.Entry(copropriete).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return copropriete;
        }

        //OK BON//
        /// <summary>
        /// Modifier une Copropriete existante
        /// </summary>
        /// <param name="idCopropriete">Identifiant de l'objet</param>!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// <param name="copropriete">Objet contenu Copropriete</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietes> ModifierCoproprieteBis(DAL.EFEntities.Coproprietes copropriete)
        {
            var content = await _condominiumMgtContext.Coproprietes.Where(x => x.IdCopropriete == copropriete.IdCopropriete).FirstOrDefaultAsync();

            if (content != null)
            {

                content.IdCoproprietaire = copropriete.IdCoproprietaire;
                content.NumContrat = copropriete.NumContrat;
                content.DateDebut = copropriete.DateDebut;
                content.DateFin = copropriete.DateFin;
                content.Remarque = copropriete.Remarque;


                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer une copropriete
        /// </summary>
        /// <param name="idCopropriete">Identifiant de la Copropriete</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietes> SupprimerCopropriete(int idCopropriete)
        {
            var result = await _condominiumMgtContext.Coproprietes.FirstOrDefaultAsync(a => a.IdCopropriete == idCopropriete);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idCopropriete);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Coproprietes> CreerCoproprieteBis(DAL.EFEntities.Coproprietes nouvelleCopropriete)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Coproprietes.AddAsync(nouvelleCopropriete);
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
            return nouvelleCopropriete;
        }

    }
}
