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
    public class FournisseursRepository : IFournisseursRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public FournisseursRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Fournisseurs
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Fournisseurs>> ListAllFournisseurs()
        {

            return (IEnumerable<DAL.EFEntities.Fournisseurs>)await _condominiumMgtContext.Fournisseurs.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Fournisseur
        /// <param name="idFournisseur"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Fournisseurs> DetailsFournisseur(int idFournisseur)
        {
            try
            {

                return await _condominiumMgtContext.Fournisseurs.Where(x => x.IdFournisseur == idFournisseur).FirstOrDefaultAsync();

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
        /// Fournisseur pour un DocumentFournisseur déterminé!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// <param name="idDocumentFournisseur"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.DocumentsFournisseurs>> GetFournisseurForDocumentFournisseur(int idDocumentFournisseur)
        {
            try
            {
                return await _condominiumMgtContext.DocumentsFournisseurs.Where(x => x.IdDocumentFournisseur == idDocumentFournisseur).ToListAsync();
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
        /// Créer/ajouter un nouveau Fournisseur
        /// </summary>
        /// <param name="nouveauFournisseur">Objet contenu Fournisseur</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Fournisseurs> CreerFournisseur(DAL.EFEntities.Fournisseurs nouveauFournisseur)
        {
            var result = await _condominiumMgtContext.Fournisseurs.AddAsync(nouveauFournisseur);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Fournisseur existant
        /// </summary>
        /// <param name="idFournisseur">Identifiant de l'objet</param>
        /// <param name="fournisseur">Objet contenu Fournisseurs</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Fournisseurs> ModifierFournisseur(int idFournisseur, DAL.EFEntities.Fournisseurs fournisseur)
        {

            if (idFournisseur != fournisseur.IdFournisseur)
            {
                return null;
            }

            _condominiumMgtContext.Entry(fournisseur).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return fournisseur;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Fournisseur existant
        /// </summary>
        /// <param name="idFournisseur">Identifiant de l'objet</param>
        /// <param name="fournisseur">Objet contenu Fournisseurs</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Fournisseurs> ModifierFournisseurBis(DAL.EFEntities.Fournisseurs fournisseur)
        {
            var content = await _condominiumMgtContext.Fournisseurs.Where(x => x.IdFournisseur == fournisseur.IdFournisseur).FirstOrDefaultAsync();

            if (content != null)
            {

                content.Denomination = fournisseur.Denomination;
                content.NomContact = fournisseur.NomContact;
                content.Adresse = fournisseur.Adresse;
                content.Email = fournisseur.Email;
                content.NumTel = fournisseur.NumTel;
                content.NumRegistre = fournisseur.NumRegistre;
                content.Activite = fournisseur.Activite;
                content.NumAgregation = fournisseur.NumAgregation;
                content.Description = fournisseur.Description;
                content.DateDebut = fournisseur.DateDebut;
                content.DateFin = fournisseur.DateFin;
                content.Remarque = fournisseur.Remarque;



                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un Fournisseur
        /// </summary>
        /// <param name="idFournisseur">Identifiant du Fournisseurs</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Fournisseurs> SupprimerFournisseur(int idFournisseur)
        {
            var result = await _condominiumMgtContext.Fournisseurs.FirstOrDefaultAsync(a => a.IdFournisseur == idFournisseur);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idFournisseur);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Fournisseurs> CreerFournisseurBis(DAL.EFEntities.Fournisseurs nouveauFournisseur)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Fournisseurs.AddAsync(nouveauFournisseur);
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
            return nouveauFournisseur;
        }

    }
}
