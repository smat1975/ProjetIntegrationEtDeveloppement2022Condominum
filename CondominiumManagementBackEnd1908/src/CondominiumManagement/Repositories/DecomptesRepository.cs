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
    public class DecomptesRepository : IDecomptesRepository
    {

        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public DecomptesRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Decomptes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Decomptes>> ListAllDecomptes()
        {

            return (IEnumerable<DAL.EFEntities.Decomptes>)await _condominiumMgtContext.Decomptes.Include(o => o.LignesDecomptes).ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Decompte
        /// <param name="idDecompte"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Decomptes> DetailsDecompte(int idDecompte)
        {
            try
            {

                return await _condominiumMgtContext.Decomptes.Include(o => o.LignesDecomptes).Where(x => x.IdDecompte == idDecompte).FirstOrDefaultAsync();

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
        /// Decomptes pour un Copropriétaire déterminé
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Decomptes>> GetDecomptesForCoproprietaire(string idCoproprietaire)
        {
            try
            {
                return await _condominiumMgtContext.Decomptes.Include(o => o.LignesDecomptes).Where(x => x.IdCoproprietaire == idCoproprietaire).ToListAsync();
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
        /// Créer/ajouter un nouveau Decompte
        /// </summary>
        /// <param name="nouveauDecompte">Objet contenu Decompte</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Decomptes> CreerDecompte(DAL.EFEntities.Decomptes nouveauDecompte)
        {
            var result = await _condominiumMgtContext.Decomptes.AddAsync(nouveauDecompte);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Decompte existant
        /// </summary>
        /// <param name="idDecompte">Identifiant de l'objet</param>
        /// <param name="decompte">Objet contenu Decomptes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Decomptes> ModifierDecompte(int idDecompte, DAL.EFEntities.Decomptes decompte)
        {

            if (idDecompte != decompte.IdDecompte)
            {
                return null;
            }

            _condominiumMgtContext.Entry(decompte).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return decompte;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Decompte existant
        /// </summary>
        /// <param name="idDecompte">Identifiant de l'objet</param>
        /// <param name="decompte">Objet contenu Decomptes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Decomptes> ModifierDecompteBis(DAL.EFEntities.Decomptes decompte)
        {
            var content = await _condominiumMgtContext.Decomptes.Where(x => x.IdDecompte == decompte.IdDecompte).FirstOrDefaultAsync();

            if (content != null)
            {


                content.IdCoproprietaire = decompte.IdCoproprietaire;
                content.IdGroupement = decompte.IdGroupement;
                content.IdPeriode = decompte.IdPeriode;
                content.DateCreation = decompte.DateCreation;
                content.DateDebutDecompte = decompte.DateDebutDecompte;
                content.DateFinDecompte = decompte.DateFinDecompte;
                content.MontantTotalDecompte = decompte.MontantTotalDecompte;
                content.IdTypeTva = decompte.IdTypeTva;
                content.MontantTotalTva = decompte.MontantTotalTva;
                content.DateEcheance = decompte.DateEcheance;
                content.ReferencePaiement = decompte.ReferencePaiement;
                content.Commentaire = decompte.Commentaire;
                content.SoldeON = decompte.SoldeON;
                content.Remarque = decompte.Remarque;


                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un Decompte
        /// </summary>
        /// <param name="idDecompte">Identifiant du Decomptes</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Decomptes> SupprimerDecompte(int idDecompte)
        {
            var result = await _condominiumMgtContext.Decomptes.FirstOrDefaultAsync(a => a.IdDecompte == idDecompte);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idDecompte);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Créer un Decompte
        /// </summary>
        /// <param name="nouveauDecompte">Objet contenu Decomptes</param>
        /// <returns></returns>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Decomptes> CreerDecompteBis(DAL.EFEntities.Decomptes nouveauDecompte)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Decomptes.AddAsync(nouveauDecompte);
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
            return nouveauDecompte;
        }


        //OK BON//
        /// <summary>
        /// Ajouter une/des ligne(s) à un Decompte
        /// </summary>
        /// <param name="nouvelleLigneDecompte">Objet contenu LignesDecomptes</param>
        /// <returns></returns>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Decomptes> AjouterLignesDecompteADecompte(DAL.EFEntities.LignesDecomptes nouvelleLigneDecompte, Decomptes decompte)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();
            //var ListeNouvellesLignesDecompte = new List<LignesDecomptes>();
            ICollection<LignesDecomptes> collectionLignesDecompte = new Collection<LignesDecomptes>();

            try
            {
                var response = await _condominiumMgtContext.Decomptes.FirstOrDefaultAsync(a => a.IdDecompte == decompte.IdDecompte);
                response.LignesDecomptes.Add((LignesDecomptes)collectionLignesDecompte);
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
            return decompte;
        }

        //OK BON//
        /// <summary>
        /// Ajouter le montant total à un Decompte
        /// </summary>
        /// <param name="montantTotalLignesDecompte"></param>
        /// <param name="decompte">Objet contenu Decompte</param>
        /// <returns></returns>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Decomptes> AjouterMontantTotalLignesDecompteADecompte(double? montantTotalLignesDecompte, Decomptes decompte)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var response = await _condominiumMgtContext.Decomptes.FirstOrDefaultAsync(a => a.IdDecompte == decompte.IdDecompte);
                response.MontantTotalDecompte = montantTotalLignesDecompte;
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
            return decompte;
        }


        //OK BON//
        /// <summary>
        /// Injecter le montant total et montant total hors TVA  d'un Decompte
        /// </summary>
        /// <param name="montantTotal"></param>
        /// <param name="decompte">Objet contenu Decompte</param>
        /// <returns></returns>
        //A vérifier MAIS cette méthode semble pas correcte ou fonctionner!!//
        /*public async Task<Double?> InjecterMontantTotalDecompte(double? montantTotalTvac, double? montantTotalHorsTva, Decomptes decompte)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var response = await _condominiumMgtContext.Decomptes.FirstOrDefaultAsync(a => a.IdDecompte == decompte.IdDecompte);

                {
                    response.MontantTotalTva = (montantTotalTvac);
                    response.MontantTotalDecompte = (montantTotalHorsTva);
                }

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
            return montantTotalHorsTva;
        }*/


        //OK BON//
        /// <summary>
        /// Calculer le montant total des lignes hors TVA d'un Decompte
        /// </summary>
        /// <param name="listeLignesDecompte"></param>
        /// <param name="decompte">Objet contenu Decompte</param>
        /// <returns></returns>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<double?> CalculerMontantTotalHorsTvaDecompte(ICollection<DAL.EFEntities.LignesDecomptes> listeLignesDecompte, Decomptes decompte)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();
            ICollection<LignesDecomptes> collectionLignesDecompte = new Collection<LignesDecomptes>();
            double? montantTotalHorsTva = 0;

            try
            {
                var response = await _condominiumMgtContext.Decomptes.FirstOrDefaultAsync(a => a.IdDecompte == decompte.IdDecompte);
                response.LignesDecomptes.Add((LignesDecomptes)collectionLignesDecompte);
                //await context.SaveChangesAsync();

                double? montantLigne;

                foreach (var ligne in collectionLignesDecompte)
                {

                    montantLigne = (ligne.MontantTotalTvacligne - ligne.MontantTvaligne);
                    montantTotalHorsTva = (montantTotalHorsTva + montantLigne);

                }

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
            return montantTotalHorsTva;
        }


        //OK BON//
        /// <summary>
        /// Calculer le montant total TVAC d'un Decompte
        /// </summary>
        /// <param name="montantTotalHorsTva"></param>
        /// <param name="tauxTva"></param>
        /// <param name="decompte">Objet contenu Decompte</param>
        /// <returns></returns>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<double?> CalculerMontantTotalTvacDecompte(Decomptes decompte, int tauxTva, double? montantTotalHorsTva)
        {

            using var context = new CondominiumMgtContext();
            double? montantTotalTvac = 0;

            //!\\ATTENTION: Vérifier si le montant total TVAC ne doit pas être calculer à partir de la somme des montants lignes TVAC//!\\
            //!\\ATTENTION: Vérifier si la TVA doit être calculée à partir du montant total hors tva et puis on ajoute la tva sur ce montant-là OU
            //!\\le montant total de Tva du décompte est calculé à partir de la somme des montants de la tva de toutes les lignesDécomptes en dessous!!!!

            try
            {
                var response = await _condominiumMgtContext.Decomptes.FirstOrDefaultAsync(a => a.IdDecompte == decompte.IdDecompte);
                montantTotalTvac = montantTotalHorsTva + (montantTotalHorsTva * tauxTva);
            }
            catch (Exception e)
            {
                // TODO: Handle failure
                throw e;
                //Gestion d'erreurs à améliorer!!//
            }
            return montantTotalTvac;
        }

    }
}
