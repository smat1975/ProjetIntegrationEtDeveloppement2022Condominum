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

namespace DAL.DbTransactions
{

    public partial class Lots
    {
        //private readonly CondominiumMgtContext context;

        //public Lots(CondominiumMgtContext _context) 
        //{
        //    context = _context;

        //}

        //Méthode Microsoft Originale!!!!//
        //A vérifier MAIS méthode pas asynchrone!!//
        public void CreerLot(int IdTypeLotPasse, string CodeLotPasse, DateTime DateDebutPasse, int IdLocalisationPasse, string DescriptionPasse, int NombreM2Passe, string RemarquePasse)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                context.Lots.Add(new DAL.EFEntities.Lots { IdTypeLot = IdTypeLotPasse, CodeLot = CodeLotPasse, DateDebut = DateDebutPasse, IdLocalisation = IdLocalisationPasse, Description = DescriptionPasse, NombreM2 = NombreM2Passe, Remarque = RemarquePasse });
                context.SaveChanges();

                //var lots = context.Lots
                //    .OrderBy(b => b.CodeLot)
                //    .ToList();

                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                transaction.Commit();

            }
            catch (Exception e)
            {
                // TODO: Handle failure
                Console.WriteLine(e);
                throw;
            }

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

                //var lots = context.Lots
                //    .OrderBy(b => b.CodeLot)
                //    .ToList();

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
            return nouveauLot;
        }

        //Pas bon!!!!//
       /* public async Task<DAL.EFEntities.Lots> CreerLotAvecCodeLot(int IdTypeLotPasse, string CodeLotPasse, DateTime DateDebutPasse, int IdLocalisationPasse, string DescriptionPasse, int NombreM2Passe, string RemarquePasse)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();


            try
            {

                var content = context.Lots.AddAsync(new DAL.EFEntities.Lots { IdTypeLot = IdTypeLotPasse, CodeLot = CodeLotPasse, DateDebut = DateDebutPasse, IdLocalisation = IdLocalisationPasse, Description = DescriptionPasse, NombreM2 = NombreM2Passe, Remarque = RemarquePasse });
                await context.SaveChangesAsync();

                //var lots = context.Lots
                //    .OrderBy(b => b.CodeLot)
                //    .ToList();

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
            return ;
        }*/

        //Pas bon!!!!//
       /* public static void DetailsLot(int IdLotPasse)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.ExecuteSqlCommandAsync();

            try
            {
                context.Lots.Add(new DAL.EFEntities.Lots { IdLot = IdLotPasse });
                context.SaveChanges();

                //var lots = context.Lots
                //    .OrderBy(b => b.CodeLot)
                //    .ToList();

                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                transaction.Commit();
            }
            catch (Exception e)
            {
                // TODO: Handle failure
                Console.WriteLine(e);
                throw;
            }

        }*/


    }
}
