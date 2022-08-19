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
    public class LignesDocumentsFournisseursRepository : ILignesDocumentsFournisseursRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public LignesDocumentsFournisseursRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les LignesDocumentsFournisseurs
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.LignesDocumentsFournisseurs>> ListAllLignesDocumentsFournisseurs()
        {

            return (IEnumerable<DAL.EFEntities.LignesDocumentsFournisseurs>)await _condominiumMgtContext.LignesDocumentsFournisseurs.ToListAsync();

        }


        //OK BON//
        /// <summary>
        /// Détails LigneDocumentFournisseur
        /// <param name="idLigneDocumentFournisseur"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.LignesDocumentsFournisseurs> DetailsLigneDocumentFournisseur(int idLigneDocumentFournisseur)
        {
            try
            {

                return await _condominiumMgtContext.LignesDocumentsFournisseurs.Where(x => x.IdLigneDocumentFournisseur == idLigneDocumentFournisseur).FirstOrDefaultAsync();

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
        /// LignesDocumentsFournisseurs pour un DocumentFournisseur déterminé
        /// <param name="idDocumentFournisseur"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.LignesDocumentsFournisseurs>> GetLignesDocumentsFournisseursForCoproprietaire(int idDocumentFournisseur)
        {
            try
            {
                return await _condominiumMgtContext.LignesDocumentsFournisseurs.Where(x => x.IdDocumentFournisseur == idDocumentFournisseur).ToListAsync();
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
        /// Créer/ajouter une nouvelle LigneDocumentFournisseur
        /// </summary>
        /// <param name="nouvelleLigneDocumentFournisseur">Objet contenu LignesDocumentsFournisseurs</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.LignesDocumentsFournisseurs> CreerLigneDocumentFournisseur(DAL.EFEntities.LignesDocumentsFournisseurs nouvelleLigneDocumentFournisseur)
        {
            var result = await _condominiumMgtContext.LignesDocumentsFournisseurs.AddAsync(nouvelleLigneDocumentFournisseur);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un LigneDocumentFournisseur existant
        /// </summary>
        /// <param name="idLigneDocumentFournisseur">Identifiant de l'objet</param>
        /// <param name="ligneDocumentFournisseur">Objet contenu LignesDocumentsFournisseurs</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.LignesDocumentsFournisseurs> ModifierLigneDocumentFournisseur(int idLigneDocumentFournisseur, DAL.EFEntities.LignesDocumentsFournisseurs ligneDocumentFournisseur)
        {

            if (idLigneDocumentFournisseur != ligneDocumentFournisseur.IdLigneDocumentFournisseur)
            {
                return null;
            }

            _condominiumMgtContext.Entry(ligneDocumentFournisseur).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return ligneDocumentFournisseur;
        }

        //OK BON//
        /// <summary>
        /// Modifier un LigneDocumentFournisseur existant
        /// </summary>
        /// <param name="idLigneDocumentFournisseur">Identifiant de l'objet</param>
        /// <param name="ligneDocumentFournisseur">Objet contenu LignesDocumentsFournisseurs</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.LignesDocumentsFournisseurs> ModifierLigneDocumentFournisseurBis(DAL.EFEntities.LignesDocumentsFournisseurs ligneDocumentFournisseur)
        {
            var content = await _condominiumMgtContext.LignesDocumentsFournisseurs.Where(x => x.IdLigneDocumentFournisseur == ligneDocumentFournisseur.IdLigneDocumentFournisseur).FirstOrDefaultAsync();

            if (content != null)
            {

                content.IdDocumentFournisseur = ligneDocumentFournisseur.IdDocumentFournisseur;
                content.IdCodePcmn = ligneDocumentFournisseur.IdCodePcmn;
                content.Description = ligneDocumentFournisseur.Description;
                content.DateDebutLigne = ligneDocumentFournisseur.DateDebutLigne;
                content.DateFinLigne = ligneDocumentFournisseur.DateFinLigne;
                content.NbreJoursLigne = ligneDocumentFournisseur.NbreJoursLigne;
                content.MontantTotalTvacligne = ligneDocumentFournisseur.MontantTotalTvacligne;
                content.IdTypeTva = ligneDocumentFournisseur.IdTypeTva;
                content.MontantTvaligne = ligneDocumentFournisseur.MontantTvaligne;
                content.Remarque = ligneDocumentFournisseur.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un LigneDocumentFournisseur
        /// </summary>
        /// <param name="idLigneDocumentFournisseur">Identifiant du LignesDocumentsFournisseurs</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.LignesDocumentsFournisseurs> SupprimerLigneDocumentFournisseur(int idLigneDocumentFournisseur)
        {
            var result = await _condominiumMgtContext.LignesDocumentsFournisseurs.FirstOrDefaultAsync(a => a.IdLigneDocumentFournisseur == idLigneDocumentFournisseur);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idLigneDocumentFournisseur);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//


        //!!!!PAS BON!!!!//
        /// <summary>
        /// Créer une nouvelle LigneDocumentFournisseur avec passage d'infos concernant des objets extérieurs
        /// </summary>
        /// <param name="idDecompte">Identifiant de l'objet extérieur</param>
        /// <param name="idCodePcmn">Identifiant de l'objet extérieur</param>
        /// <param name="description"></param>
        /// <param name="idlLigneDocumentsFournisseurs">Identifiant de l'objet extérieur</param>
        /// <param name="idQuotite">Identifiant de l'objet extérieur</param>
        /// <param name="dateDebutLigne"></param>
        /// <param name="dateFinLigne"></param>
        /// <param name="nbreJoursLigne"></param>
        /// <param name="montantTotalTvacligne"></param>
        /// <param name="montantTvaligne"></param>
        /// <param name="remarque"></param>
        /// <returns></returns>
       /* public async Task<DAL.EFEntities.LignesDecomptes> CreerLigneDecompteBis(int idDecompte, int idCodePcmn, string description, int idlLigneDocumentsFournisseurs, int idQuotite, DateTime dateDebutLigne, DateTime dateFinLigne, int nbreJoursLigne, double? montantTotalTvacligne, double? montantTvaligne, string remarque)
        {
            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();
            var nouvelleLigneDecompte = new LignesDecomptes();

            try
            {
                nouvelleLigneDecompte.IdDecompte = idDecompte;
                nouvelleLigneDecompte.IdCodePcmn = idCodePcmn;
                nouvelleLigneDecompte.Description = description;
                nouvelleLigneDecompte.IdLigneDocumentFournisseur = idlLigneDocumentsFournisseurs;
                nouvelleLigneDecompte.IdQuotite = idQuotite;
                nouvelleLigneDecompte.DateDebutLigne = dateDebutLigne;
                nouvelleLigneDecompte.DateFinLigne = dateFinLigne;
                nouvelleLigneDecompte.NbreJoursLigne = nbreJoursLigne;
                nouvelleLigneDecompte.MontantTotalTvacligne = montantTotalTvacligne;
                nouvelleLigneDecompte.MontantTvaligne = montantTvaligne;
                nouvelleLigneDecompte.Remarque = remarque;

                var content = context.LignesDecomptes.AddAsync(nouvelleLigneDecompte);
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
            return nouvelleLigneDecompte;
        }*/

        //!\\La méthode ci-dessous n'est pas appropriée pour la création d'une nouvelleLigneDecompte parce qu'elle n'indique pas comment
        //faire rentrer les différents attributs!!!!


        //PLUS BON//
        /// <summary>
        /// Créer une nouvelle LigneDecompte
        /// </summary>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.LignesDocumentsFournisseurs> CreerLigneDocumentFournisseurTer(DAL.EFEntities.LignesDocumentsFournisseurs nouvelleLigneDocumentFournisseur)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.LignesDocumentsFournisseurs.AddAsync(nouvelleLigneDocumentFournisseur);
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
            return nouvelleLigneDocumentFournisseur;
        }

    }
}
