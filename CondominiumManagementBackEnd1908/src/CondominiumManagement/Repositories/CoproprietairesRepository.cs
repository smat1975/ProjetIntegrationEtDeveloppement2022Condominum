using CondominiumManagement.Repositories.Interfaces;
using DAL.EFContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using AutoMapper;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories
{
    public class CoproprietairesRepository : ICoproprietairesRepository
    {

        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public CoproprietairesRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de tous les Coproprietaires
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Coproprietaires>> ListAllCoproprietaires()
        {

            return (IEnumerable<DAL.EFEntities.Coproprietaires>)await _condominiumMgtContext.Coproprietaires.ToListAsync();

        }

        //OK BON//
        /// <summary>
        /// Détails Coproprietaire
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietaires> DetailsCoproprietaires(string idCoproprietaire)
        {
            try
            {

                return await _condominiumMgtContext.Coproprietaires.Where(x => x.IdCoproprietaire == idCoproprietaire).FirstOrDefaultAsync();

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
        /// Comptes Bque pour un Copropriétaire déterminé
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        /*public async Task<IEnumerable<DAL.EFEntities.ComptesBque>> GetCompteBqueForCoproprietaire(string idCoproprietaire)
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
        /// Créer/ajouter une nouveau Coproprietaire
        /// </summary>
        /// <param name="nouveauCoproprietaire">Objet contenu Coproprietaire</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietaires> CreerCoproprietaire(DAL.EFEntities.Coproprietaires nouveauCoproprietaire)
        {
            var result = await _condominiumMgtContext.Coproprietaires.AddAsync(nouveauCoproprietaire);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Coproprietaire existant
        /// </summary>
        /// <param name="idCoproprietaire">Identifiant de l'objet</param>
        /// <param name="coproprietaire">Objet contenu Coproprietaires</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietaires> ModifierCoproprietaire(string idCoproprietaire, DAL.EFEntities.Coproprietaires coproprietaire)
        {

            if (idCoproprietaire != coproprietaire.IdCoproprietaire)
            {
                return null;
            }

            _condominiumMgtContext.Entry(coproprietaire).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return coproprietaire;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Coproprietaire existant
        /// </summary>
        /// <param name="idCoproprietaire">Identifiant de l'objet</param>
        /// <param name="coproprietaire">Objet contenu Coproprietaire</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietaires> ModifierCoproprietaireBis(DAL.EFEntities.Coproprietaires coproprietaire)
        {
            var content = await _condominiumMgtContext.Coproprietaires.Where(x => x.IdCoproprietaire == coproprietaire.IdCoproprietaire).FirstOrDefaultAsync();

            if (content != null)
            {
                content.Nom = coproprietaire.Nom;
                content.Prenoms = coproprietaire.Prenoms;
                content.DateNaissance = coproprietaire.DateNaissance;
                content.NumNiss = coproprietaire.NumNiss;
                content.Sexe = coproprietaire.Sexe;
                content.Email = coproprietaire.Email;
                content.NumTel = coproprietaire.NumTel;
                content.NumGsm = coproprietaire.NumGsm;
                content.Adresse = coproprietaire.Adresse;
                content.IdCivilite = coproprietaire.IdCivilite;
                content.DateCreation = coproprietaire.DateCreation;
                content.DateCloture = coproprietaire.DateCloture;
                content.IdRaisonCloture = coproprietaire.IdRaisonCloture;
                content.ContactAdresse = coproprietaire.ContactAdresse;
                content.ContactNom = coproprietaire.ContactNom;
                content.ContactTel = coproprietaire.ContactTel;
                content.ContactEmail = coproprietaire.ContactEmail;
                content.ContactRelation = coproprietaire.ContactRelation;
                content.AdresseFacturation = coproprietaire.AdresseFacturation;
                content.AdresseEnvoiFacture = coproprietaire.AdresseEnvoiFacture;
                content.EmailEnvoiFacture = coproprietaire.EmailEnvoiFacture;
                content.NumTelEnvoiFacture = coproprietaire.NumTelEnvoiFacture;
                content.Remarques = coproprietaire.Remarques;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un coproprietaire
        /// </summary>
        /// <param name="idCoproprietaire">Identifiant du Coproprietaire</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Coproprietaires> SupprimerCoproprietaire(string idCoproprietaire)
        {
            var result = await _condominiumMgtContext.Coproprietaires.FirstOrDefaultAsync(a => a.IdCoproprietaire == idCoproprietaire);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idCoproprietaire);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Coproprietaires> CreerCoproprietaireBis(DAL.EFEntities.Coproprietaires nouveauCoproprietaire)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Coproprietaires.AddAsync(nouveauCoproprietaire);
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
            return nouveauCoproprietaire;
        }

    }
}
