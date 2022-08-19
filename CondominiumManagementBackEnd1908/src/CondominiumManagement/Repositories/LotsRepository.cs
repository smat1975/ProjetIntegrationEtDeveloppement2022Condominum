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
    public class LotsRepository : ILotsRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public LotsRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de tous les Lots
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Lots>> ListAllLots()
        {

            return (IEnumerable<DAL.EFEntities.Lots>)await _condominiumMgtContext.Lots.ToListAsync();

        }

        //
        //

        //
        //

        //OK BON//
        /// <summary>
        /// Détails Lot
        /// <param name="idLot"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Lots> DetailsLot(int idLot)
        {
            try
            {

                return await _condominiumMgtContext.Lots.Where(x => x.IdLot == idLot).FirstOrDefaultAsync();

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
        /// Lot pour une Copropriété déterminée
        /// <param name="idCopropriete"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Lots> GetLotForCopropriete(int idCopropriete)
        {
            var response = await _condominiumMgtContext.Coproprietes.FindAsync(idCopropriete);
            try
            {
                var content = await _condominiumMgtContext.Lots.FirstOrDefaultAsync(x => x.IdLot == response.IdLot);
                return content;
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
        /// Lots pour un Coproprietaire déterminé
        /// <param name="idCoproprietaire"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Lots>> GetLotsForCopropietaire(string idCoproprietaire)
        {
            var listeCoproprietesCoproprietaire = await _condominiumMgtContext.Coproprietes.Where(x => x.IdCoproprietaire == idCoproprietaire).ToListAsync();
            List<Lots> listeLots = new List<Lots>();

            foreach (var copropriete in listeCoproprietesCoproprietaire)
            {
                try
                {
                    var response = await _condominiumMgtContext.Lots.FirstOrDefaultAsync(x => x.IdLot == copropriete.IdLot);
                    listeLots.Add(response);
                }
                //!\\A REGLER!!!!//!\\
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    throw e;
                }
            }
            return listeLots;

        }

        /*
        //!\\A vérifier!!!!//!\\
        | 
        V
        */
        //OK BON//
        /// <summary>
        /// Créer/ajouter un nouveau Lot
        /// </summary>
        /// <param name="nouveauLot">Objet contenu Lots</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Lots> CreerLot(DAL.EFEntities.Lots nouveauLot)
        {
            var result = await _condominiumMgtContext.Lots.AddAsync(nouveauLot);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Lot existant
        /// </summary>
        /// <param name="idLot">Identifiant de l'objet</param>
        /// <param name="lot">Objet contenu Lots</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Lots> ModifierLot(int idLot, DAL.EFEntities.Lots lot)
        {

            if (idLot != lot.IdLot)
            {
                return null;
            }

            _condominiumMgtContext.Entry(lot).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return lot;
        }

        //OK BON//
        /// <summary>
        /// Modifier un Lot existant
        /// </summary>
        /// <param name="idLot">Identifiant de l'objet</param>
        /// <param name="lot">Objet contenu Lots</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Lots> ModifierLotBis(DAL.EFEntities.Lots lot)
        {
            var content = await _condominiumMgtContext.Lots.Where(x => x.IdLot == lot.IdLot).FirstOrDefaultAsync();

            if (content != null)
            {
                content.IdTypeLot = lot.IdTypeLot;
                content.CodeLot = lot.CodeLot;
                content.DateDebut = lot.DateDebut;
                content.DateFin = lot.DateFin;
                content.IdLocalisation = lot.IdLocalisation;
                content.Description = lot.Description;
                content.NombreM2 = lot.NombreM2;
                content.Remarque = lot.Remarque;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer un lot
        /// </summary>
        /// <param name="idLot">Identifiant du lot</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Lots> SupprimerLot(int idLot)
        {
            var result = await _condominiumMgtContext.Lots.FirstOrDefaultAsync(a => a.IdLot == idLot);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idLot);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Lots> CreerLotBis(DAL.EFEntities.Lots nouveauLot)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Lots.AddAsync(nouveauLot);
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
            return nouveauLot;
        }

    }
}
