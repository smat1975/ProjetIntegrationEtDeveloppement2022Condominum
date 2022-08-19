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
    public class TypesLotRepository : ITypesLotRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;

        public TypesLotRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }

        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.TypesLot> CreerTypeLotBis(DAL.EFEntities.TypesLot nouveauTypeLot)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.TypesLot.AddAsync(nouveauTypeLot);
                await context.SaveChangesAsync();


                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                transaction.Commit();
            }
            catch (Exception e)
            {
                // TODO: Handle failure
                Console.WriteLine(e);
                throw;
                //Gestion d'erreurs à améliorer!!//
            }
            return nouveauTypeLot;
        }

        //OK BON//
        /// <summary>
        /// Liste de tous les TypesLot
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.TypesLot>> ListAllTypesLot()
        {

            return (IEnumerable<DAL.EFEntities.TypesLot>)await _condominiumMgtContext.TypesLot.ToListAsync();

        }

        //OK BON//
        /// <summary>
        /// Détails TypeLot
        /// <param name="idTypeLot"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.TypesLot> DetailsTypeLot(int idTypeLot)
        {
            try
            {

                return await _condominiumMgtContext.TypesLot.Where(x => x.IdTypeLot == idTypeLot).FirstOrDefaultAsync();

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
        /// Créer/ajouter un nouveau TypeLot
        /// </summary>
        /// <param name="nouveauTypeLot">Objet contenu TypeLot</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.TypesLot> CreerTypeLot(DAL.EFEntities.TypesLot nouveauTypeLot)
        {
            var result = await _condominiumMgtContext.TypesLot.AddAsync(nouveauTypeLot);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Modifier un TypeLot existant
        /// </summary>
        /// <param name="idTypeLot">Identifiant de l'objet</param>
        /// <param name="typeLot">Objet contenu TypesLot</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.TypesLot> ModifierTypeLot(int idTypeLot, DAL.EFEntities.TypesLot typeLot)
        {

            if (idTypeLot != typeLot.IdTypeLot)
            {
                return null;
            }

            _condominiumMgtContext.Entry(typeLot).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return typeLot;
        }
    }
}
