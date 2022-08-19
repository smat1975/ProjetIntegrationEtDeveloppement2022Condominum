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
    public class LignesDecomptesRepository : ILignesDecomptesRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public LignesDecomptesRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les LignesDecomptes!!!!!!!!!!!!!!!!!!!!Pas vraiment utile!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.LignesDecomptes>> ListAllLignesDecomptes()
        {

            return (IEnumerable<DAL.EFEntities.LignesDecomptes>)await _condominiumMgtContext.LignesDecomptes.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails LigneDecompte
        /// <param name="idLigneDecompte"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.LignesDecomptes> DetailsLigneDecompte(int idLigneDecompte)
        {
            try
            {

                return await _condominiumMgtContext.LignesDecomptes.Where(x => x.IdLigneDecompte == idLigneDecompte).FirstOrDefaultAsync();

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
        /// LignesDecompte pour un Decompte déterminé
        /// <param name="idDecomte"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.LignesDecomptes>> GetLignesDecompteForDecompte(int idDecompte)
        {
            try
            {
                return await _condominiumMgtContext.LignesDecomptes.Where(x => x.IdDecompte == idDecompte).ToListAsync();
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
        /// Créer/ajouter une nouvelle Ligne Decompte
        /// </summary>
        /// <param name="nouvelleLigneDecompte">Objet contenu LigneDecompte</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.LignesDecomptes> CreerLigneDecompte(DAL.EFEntities.LignesDecomptes nouvelleLigneDecompte)
        {
            var result = await _condominiumMgtContext.LignesDecomptes.AddAsync(nouvelleLigneDecompte);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier une LigneDecompte existante!!!!!!!!!!!!!!!!!!!!PAS UTILE CAR SI MODIFICATIONS IL FAUT CREER UNE AUTRE LIGNE CORRECTRICE!!!!!
        /// </summary>
        /// <param name="idDecompte">Identifiant de l'objet</param>
        /// <param name="decompte">Objet contenu LignesDecomptes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.LignesDecomptes> ModifierDecompte(int idDecompte, DAL.EFEntities.LignesDecomptes ligneDecompte)
        {

            if (idDecompte != ligneDecompte.IdLigneDecompte)
            {
                return null;
            }

            _condominiumMgtContext.Entry(ligneDecompte).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return ligneDecompte;
        }

        //OK BON//
        /// <summary>
        /// Modifier une LigneDecompte existante
        /// </summary>
        /// <param name="idLigneDecompte">Identifiant de l'objet</param>
        /// <param name="ligneDecompte">Objet contenu LignesDecomptes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.LignesDecomptes> ModifierLigneDecompteBis(DAL.EFEntities.LignesDecomptes ligneDecompte)
        {
            var content = await _condominiumMgtContext.LignesDecomptes.Where(x => x.IdLigneDecompte == ligneDecompte.IdLigneDecompte).FirstOrDefaultAsync();

            if (content != null)
            {

                content.IdDecompte = ligneDecompte.IdDecompte;
                content.IdCodePcmn = ligneDecompte.IdCodePcmn;
                content.Description = ligneDecompte.Description;
                content.IdLigneDocumentFournisseur = ligneDecompte.IdLigneDocumentFournisseur;
                content.IdQuotite = ligneDecompte.IdQuotite;
                content.DateDebutLigne = ligneDecompte.DateDebutLigne;
                content.DateFinLigne = ligneDecompte.DateFinLigne;
                content.NbreJoursLigne = ligneDecompte.NbreJoursLigne;
                content.MontantTotalTvacligne = ligneDecompte.MontantTotalTvacligne;
                content.MontantTvaligne = ligneDecompte.MontantTvaligne;
                content.Remarque = ligneDecompte.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer une LigneDecompte
        /// </summary>
        /// <param name="idLigneDecompte">Identifiant du LignesDecomptes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.LignesDecomptes> SupprimerLigneDecompte(int idLigneDecompte)
        {
            var result = await _condominiumMgtContext.LignesDecomptes.FirstOrDefaultAsync(a => a.IdLigneDecompte == idLigneDecompte);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idLigneDecompte);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }

        //A vérifier MAIS cette méthode asynchrone semble bonne!!//


        //OK BON//
        /// <summary>
        /// Créer une nouvelle LigneDecompte avec passage d'infos concernant des objets extérieurs
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
        public async Task<DAL.EFEntities.LignesDecomptes> CreerLigneDecompteBis(int idDecompte, int idCodePcmn, string description, int idlLigneDocumentsFournisseurs, int idQuotite, DateTime dateDebutLigne, DateTime dateFinLigne, int nbreJoursLigne, double? montantTotalTvacligne, double? montantTvaligne, string remarque)
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
        }

        //!\\La méthode ci-dessous n'est pas appropriée pour la création d'une nouvelleLigneDecompte parce qu'elle n'indique pas comment
        //faire rentrer les différents attributs!!!!


        //PLUS BON//
        /// <summary>
        /// Créer une nouvelle LigneDecompte
        /// </summary>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.LignesDecomptes> CreerLigneDecompteTer(DAL.EFEntities.LignesDecomptes nouvelleLigneDecompte)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
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
        }

        //Calculer montant totalTVAC Ligne
        //Calculer montant total TVA Ligne
        //Calculer nombre jours ligne

        //OK BON//
        /// <summary>
        /// Calculer le montant tva d'une LigneDecompte
        /// </summary>
        /// <param name="montantHorsTva"></param>
        /// <param name="tauxTva"></param>
        /// <param name="ligneDecompte">Objet contenu Decompte</param>
        /// <returns></returns>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<double?> CalculerMontantTvaLigne(LignesDecomptes ligneDecompte, int tauxTva, double? montantHorsTva)
        {

            using var context = new CondominiumMgtContext();
            double? montantTvaLigne = 0;

            try
            {
                var response = await _condominiumMgtContext.LignesDecomptes.FirstOrDefaultAsync(a => a.IdLigneDecompte == ligneDecompte.IdLigneDecompte);
                montantTvaLigne = (montantHorsTva * tauxTva);
            }
            catch (Exception e)
            {
                // TODO: Handle failure
                throw e;
                //Gestion d'erreurs à améliorer!!//
            }
            return montantTvaLigne;
        }

        //OK BON//
        /// <summary>
        /// Calculer le montant total TVAC d'une LigneDecompte
        /// </summary>
        /// <param name="montantHorsTva"></param>
        /// <param name="montantTvaLigne"></param>
        /// <param name="ligneDecompte">Objet contenu Decompte</param>
        /// <returns></returns>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<double?> CalculerMontantTotalTvacLigne(LignesDecomptes ligneDecompte, double? montantHorsTva, double? montantTvaLigne)
        {

            using var context = new CondominiumMgtContext();
            double? montantTotalTvacLigne = 0;

            try
            {
                var response = await _condominiumMgtContext.LignesDecomptes.FirstOrDefaultAsync(a => a.IdLigneDecompte == ligneDecompte.IdLigneDecompte);
                montantTotalTvacLigne = (montantHorsTva + montantTvaLigne);
            }
            catch (Exception e)
            {
                // TODO: Handle failure
                throw e;
                //Gestion d'erreurs à améliorer!!//
            }
            return montantTotalTvacLigne;
        }

        //OK BON//
        /// <summary>nombre jours LigneDecompte
        /// </summary>
        /// <param name="dateDebutLigne"></param>
        /// <param name="dateFinLigne"></param>
        /// <param name="ligneDecompte">Objet contenu Decompte</param>
        /// <returns></returns>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<int> CalculerNombreJoursLigne(LignesDecomptes ligneDecompte, DateTime dateDebutLigne, DateTime dateFinLigne)
        {

            using var context = new CondominiumMgtContext();
            int nombreJoursLigne = 0;

            try
            {
                var response = await _condominiumMgtContext.LignesDecomptes.FirstOrDefaultAsync(a => a.IdLigneDecompte == ligneDecompte.IdLigneDecompte);
                TimeSpan ecartDates = (dateFinLigne - dateDebutLigne);
                nombreJoursLigne = (int)ecartDates.TotalDays;

            }
            catch (Exception e)
            {
                // TODO: Handle failure
                throw e;
                //Gestion d'erreurs à améliorer!!//
            }
            return nombreJoursLigne;
        }
    }
}
