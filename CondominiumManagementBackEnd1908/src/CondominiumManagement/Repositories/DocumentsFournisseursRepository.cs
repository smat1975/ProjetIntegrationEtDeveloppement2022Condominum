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
using System.Collections.ObjectModel;
using CondominiumManagement.Repositories.Interfaces;

namespace CondominiumManagement.Repositories
{
    public class DocumentsFournisseursRepository : IDocumentsFournisseursRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public DocumentsFournisseursRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les DocumentsFournisseurs
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.DocumentsFournisseurs>> ListAllDocumentsFournisseur()
        {

            return (IEnumerable<DAL.EFEntities.DocumentsFournisseurs>)await _condominiumMgtContext.DocumentsFournisseurs.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails DocumentFournisseur
        /// <param name="idDocumentFournisseur"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.DocumentsFournisseurs> DetailsDocumentFournisseur(int idDocumentFournisseur)
        {
            try
            {

                return await _condominiumMgtContext.DocumentsFournisseurs.Where(x => x.IdDocumentFournisseur == idDocumentFournisseur).FirstOrDefaultAsync();

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
        /// DocumentsFournisseur pour un Fournisseur déterminé
        /// <param name="idFournisseur"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.DocumentsFournisseurs>> GetDocumentsFournisseurForFournisseur(int idFournisseur)
        {
            try
            {
                return await _condominiumMgtContext.DocumentsFournisseurs.Where(x => x.IdFournisseur == idFournisseur).ToListAsync();
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
        /// Créer/ajouter une nouveau DocumentFournisseur
        /// </summary>
        /// <param name="nouveauDocumentFournisseur">Objet contenu DocumentFournisseur</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.DocumentsFournisseurs> CreerDocumentFournisseur(DAL.EFEntities.DocumentsFournisseurs nouveauDocumentFournisseur)
        {
            var result = await _condominiumMgtContext.DocumentsFournisseurs.AddAsync(nouveauDocumentFournisseur);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un DocumentFournisseur existant
        /// </summary>
        /// <param name="idDocumentFournisseur">Identifiant de l'objet</param>
        /// <param name="documentFournisseur">Objet contenu DocumentsFournisseurs</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.DocumentsFournisseurs> ModifierDocumentFournisseur(int idDocumentFournisseur, DAL.EFEntities.DocumentsFournisseurs documentFournisseur)
        {

            if (idDocumentFournisseur != documentFournisseur.IdDocumentFournisseur)
            {
                return null;
            }

            _condominiumMgtContext.Entry(documentFournisseur).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return documentFournisseur;
        }

        //OK BON//
        /// <summary>
        /// Modifier un DocumentFournisseur existant
        /// </summary>
        /// <param name="idDocumentFournisseur">Identifiant de l'objet</param>
        /// <param name="documentFournisseur">Objet contenu DocumentsFournisseurs</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.DocumentsFournisseurs> ModifierDocumentFournisseurBis(DAL.EFEntities.DocumentsFournisseurs documentFournisseur)
        {
            var content = await _condominiumMgtContext.DocumentsFournisseurs.Where(x => x.IdDocumentFournisseur == documentFournisseur.IdDocumentFournisseur).FirstOrDefaultAsync();

            if (content != null)
            {

                content.IdTypeDocumentFournisseur = documentFournisseur.IdTypeDocumentFournisseur;
                content.IdFournisseur = documentFournisseur.IdFournisseur;
                content.IdPeriode = documentFournisseur.IdPeriode;
                content.Description = documentFournisseur.Description;
                content.MontantTotalTvacdocument = documentFournisseur.MontantTotalTvacdocument;
                content.IdTypeTva = documentFournisseur.IdTypeTva;
                content.MontantTva = documentFournisseur.MontantTva;
                content.DateEnregistrement = documentFournisseur.DateEnregistrement;
                content.DateEcheance = documentFournisseur.DateEcheance;
                content.Remarque = documentFournisseur.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un DocumentFournisseur
        /// </summary>
        /// <param name="idDocumentFournisseur">Identifiant du DocumentsFournisseurs</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.DocumentsFournisseurs> SupprimerDocumentFournisseur(int idDocumentFournisseur)
        {
            var result = await _condominiumMgtContext.DocumentsFournisseurs.FirstOrDefaultAsync(a => a.IdDocumentFournisseur == idDocumentFournisseur);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idDocumentFournisseur);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.DocumentsFournisseurs> CreerDocumentFournisseurBis(DAL.EFEntities.DocumentsFournisseurs nouveauDocumentFournisseur)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.DocumentsFournisseurs.AddAsync(nouveauDocumentFournisseur);
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
            return nouveauDocumentFournisseur;
        }

        //!\\Pas besoin de calculer la TVA puisqu'elle figure obligatoirement sur les documents des fournisseurs
        //et qu'elle doit être rentrée manuellement tellequelle lors de l'encodage!!!!

        //OK BON//
        /// <summary>
        /// Ajouter une/des LignesDocumentsFournisseurs à un DocumentFournisseur
        /// </summary>
        /// <param name="nouvelleLigneDocumentFournisseur">Objet contenu LignesDocumentsFournisseurs</param>
        /// <returns></returns>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.DocumentsFournisseurs> AjouterLignesDocumentFournisseurADocumentFournisseur(DAL.EFEntities.LignesDocumentsFournisseurs nouvelleLigneDocumentFournisseur, DocumentsFournisseurs documentFournisseur)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();
            ICollection<LignesDocumentsFournisseurs> collectionLignesDocumentsFournisseurs = new Collection<LignesDocumentsFournisseurs>();

            try
            {
                var response = await _condominiumMgtContext.DocumentsFournisseurs.FirstOrDefaultAsync(a => a.IdDocumentFournisseur == nouvelleLigneDocumentFournisseur.IdDocumentFournisseur);
                response.LignesDocumentsFournisseurs.Add((LignesDocumentsFournisseurs)collectionLignesDocumentsFournisseurs);
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
            return documentFournisseur;
        }



    }
}
