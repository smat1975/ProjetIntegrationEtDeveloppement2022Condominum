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
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using CondominiumManagement.Repositories.Interfaces;

namespace CondominiumManagement.Repositories
{

    public class AnnexesRepository : IAnnexesRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        private readonly string _connectionString;
        //private readonly IMapper _mapper;

        public AnnexesRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }

        public AnnexesRepository(CondominiumMgtContext condominiumMgtContext, IConfiguration configuration/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            /*_mapper = mapper;*/
        }

        //OK BON//
        /// <summary>
        /// Liste de toutes les Annexes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Annexes>> ListAllAnnexes()
        {

            return (IEnumerable<DAL.EFEntities.Annexes>)await _condominiumMgtContext.Annexes.Include(p => p.Photos).ToListAsync();

        }

        //!\\Est-ce vraiment utile??!!!!//!\\

        //OK BON//
        /// <summary>
        /// Liste de toutes les Annexes | Autre version : façon ADO.net
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetListAnnexes()
        {
            try
            {
                using (SqlConnection oConn = new SqlConnection(_connectionString))
                {
                    using (var oCmd = new SqlCommand("GetAllAnnexes", oConn))
                    {
                        oCmd.CommandType = CommandType.StoredProcedure;
                        var response = new List</*Models.Annexes*/string>();
                        await oConn.OpenAsync();
                        using (var reader = await oCmd.ExecuteReaderAsync())
                        //Rem: reader est du type SqlDataReader
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(reader.ToString());
                            }
                        }
                        oConn.Close();
                        return response;
                    }
                }
            }
            //!\\A REGLER!!!!//!\\
            catch (SqlException e)
            {
                throw e;
            }
            //!\\A REGLER!!!!//!\\
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw e;
            }
        }

        //!\\Est-ce vraiment utile??!!!!//!\\

        //OK BON//
        /// Ensemble de toutes les Annexes | Autre version : façon ADO.net
        /// </summary>
        /// <returns></returns>
        public async Task<List<DAL.EFEntities.Annexes>> GetAllAnnexes()
        {
            try
            {
                using (SqlConnection oConn = new SqlConnection(_connectionString))
                {
                    using (var oCmd = new SqlCommand("GetAllAnnexes", oConn))
                    {
                        oCmd.CommandType = CommandType.StoredProcedure;
                        var listAnnexes = new List<string>();
                        var ensembleAnnexes = new List<DAL.EFEntities.Annexes>();
                        await oConn.OpenAsync();
                        using (var reader = await oCmd.ExecuteReaderAsync())
                        //Rem: reader est du type SqlDataReader
                        {
                            while (await reader.ReadAsync())
                            {
                                listAnnexes.Add(reader.ToString());
                            }
                        }
                        foreach (var item in listAnnexes)
                        {
                            using (var reader = await oCmd.ExecuteReaderAsync())
                            {

                                Annexes annexe = new Annexes();
                                //Rem: reader est du type SqlDataReader
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        annexe.IdAnnexe = reader.GetInt32(0);
                                        annexe.IdMessage = reader.GetInt32(0);
                                        annexe.Remarque = reader.GetString(0);
                                    }
                                }
                                else
                                {
                                    //throw error;
                                }
                                ensembleAnnexes.Add(annexe);
                            }
                        }
                        oConn.Close();
                        return ensembleAnnexes;
                    }
                }
            }
            //!\\A REGLER!!!!//!\\
            catch (SqlException e)
            {
                throw e;
            }
            //!\\A REGLER!!!!//!\\
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw e;
            }
        }

        //!\\Est-ce vraiment utile??!!!!//!\\

        //OK BON//
        /// <summary>
        /// Annexe par son Id | Autre version : façon ADO.net
        /// <param name="idAnnexe"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<Models.Annexes> GetAnnexeById(int idAnnexe)
        {
            Models.Annexes response = new Models.Annexes();
            response = null;
            try
            {
                using (SqlConnection oConn = new SqlConnection(_connectionString))
                {
                    using (var oCmd = new SqlCommand("GetAnnexeById", oConn))
                    {
                        oCmd.CommandType = CommandType.StoredProcedure;
                        var oParam = new SqlParameter("@IdAnnexe", idAnnexe);
                        oCmd.Parameters.Add(oParam);
                        await oConn.OpenAsync();

                        using (var reader = await oCmd.ExecuteReaderAsync())
                        {
                            //Rem: reader est du type SqlDataReader
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    response.IdAnnexe = reader.GetInt32(0);
                                    response.IdMessage = reader.GetInt32(0);
                                    response.Remarque = reader.GetString(0);
                                }
                            }
                            else
                            {
                                //throw new FifaError.FifaError(56001);
                            }
                        }
                        oConn.Close();
                    }
                }
            }
            //!\\A REGLER!!!!//!\\
            catch (SqlException e)
            {
                throw e;
            }
            //!\\A REGLER!!!!//!\\
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw e;
            }
            return response;
        }

        //OK BON//
        /// <summary>
        /// Détails Annexe
        /// <param name="idAnnexe"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Annexes> DetailsAnnexe(int idAnnexe)
        {
            try
            {

                return await _condominiumMgtContext.Annexes.Include(p => p.Photos).Where(x => x.IdAnnexe == idAnnexe).FirstOrDefaultAsync();

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
        /// Annexes pour un message déterminé
        /// <param name="idMessage"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Annexes>> GetAnnexesForMessage(int idMessage)
        {
            try
            {
                return await _condominiumMgtContext.Annexes.Where(x => x.IdMessage == idMessage).ToListAsync();
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
        /// Créer/ajouter une nouvelle Annexe
        /// </summary>
        /// <param name="nouvelleAnnexe">Objet contenu Annexe</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Annexes> CreerAnnexe(DAL.EFEntities.Annexes nouvelleAnnexe)
        {
            var result = await _condominiumMgtContext.Annexes.AddAsync(nouvelleAnnexe);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }

        //OK BON//
        /// <summary>
        /// Créer/ajouter une nouvelle Annexe Retry
        /// </summary>
        /// <param name="nouvelleAnnexe">Objet contenu Annexe</param>
        /// <returns></returns>
        public async Task<ActionResult<DAL.EFEntities.Annexes>> CreerAnnexeRetry(DAL.EFEntities.Annexes nouvelleAnnexe)
        {
            try
            {
                var result = await _condominiumMgtContext.Annexes.AddAsync(nouvelleAnnexe);
                await _condominiumMgtContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //OK BON//
        /// <summary>
        /// Modifier une Annexe existante
        /// </summary>
        /// <param name="idAnnexe">Identifiant de l'objet</param>
        /// <param name="annexe">Objet contenu Annexe</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Annexes> ModifierAnnexe(int idAnnexe, DAL.EFEntities.Annexes annexe)
        {

            if (idAnnexe != annexe.IdAnnexe)
            {
                return null;
            }

            _condominiumMgtContext.Entry(annexe).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return annexe;
        }

        //OK BON//
        /// <summary>
        /// Modifier une annexe existante
        /// </summary>
        /// <param name="idAnnexe">Identifiant de l'objet</param>
        /// <param name="annexe">Objet contenu Annexe</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Annexes> ModifierAnnexeBis(DAL.EFEntities.Annexes annexe)
        {
            var content = await _condominiumMgtContext.Annexes.Where(x => x.IdAnnexe == annexe.IdAnnexe).FirstOrDefaultAsync();

            if (content != null)
            {
                content.IdMessage = annexe.IdMessage;
                content.Remarque = annexe.Remarque;


                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer une Annexe
        /// </summary>
        /// <param name="idAnnexe">Identifiant de l'Annexe</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Annexes> SupprimerAnnexe(int idAnnexe)
        {
            var result = await _condominiumMgtContext.Annexes.FirstOrDefaultAsync(a => a.IdAnnexe == idAnnexe);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idAnnexe);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Ajouter une ou plusieurs photos à une annexe
        /// </summary>
        /// <param name="listePhotos"></param>
        /// <param name="annexe">Objet contenu Annexe</param>
        /// <returns></returns>
        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        /*public async Task<Annexes> AjouterPhotosAAnnexe(ICollection<DAL.EFEntities.Photos> listePhotos, Annexes annexe)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();
            ICollection<Photos> collectionPhotos = new Collection<Photos>();

            try
            {
                var response = await _condominiumMgtContext.Annexes.FirstOrDefaultAsync(a => a.IdAnnexe == annexe.IdAnnexe);

                foreach (var photo in collectionPhotos)
                {
                    response.Photos.Add((Photos)collectionPhotos);
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
            return annexe;
        }*/

        //-------------------------------------------------------------------------------------------------------

        //BON - MAIS mieux ailleurs!!!!//
        /// <summary>
        /// Détails de l'Annexe
        /// </summary>
        /// <param name="idAnnexe"></param>
        /// <returns></returns>
        /*public async Task<Annexes> DetailsAnnexe(int idAnnexe)
        {
        var param = new SqlParameter("@IdMessage", idAnnexe);
        //_condominiumMgtContext.Database.ExecuteSqlCommand("GetAllAnnexesForMessage @p0", param);
        //return (Annexes)await _condominiumMgtContext.Annexes.ToListAsync();
        return (Annexes)await _condominiumMgtContext.Annexes.FromSql("GetAllAnnexesForMessage @p0", param).ToListAsync();
        }*/

        //BON - MAIS mieux ailleurs!!!!//
        /// <summary>
        /// Détails de l'Annexe
        /// </summary>
        /// <param name="idAnnexe"></param>
        /// <returns></returns>
        /*public async Task<DAL.EFEntities.Annexes> DetailsAnnexe(int idAnnexe)
        {
            //var param = new SqlParameter("@IdMessage", idAnnexe);
            //return (Annexes)await _condominiumMgtContext.Database.ExecuteSqlCommand("GetAllAnnexesForMessage @p0", idAnnexe).FirstOrDefaultAsync();
            return (DAL.EFEntities.Annexes)await _condominiumMgtContext.Database.ExecuteSqlRaw("GetAllAnnexesForMessage {0}", idAnnexe).FirstOrDefaultAsync();
        }*/


        public async Task<DAL.EFEntities.Annexes> AddPhotoToAnnexe(int idAnnexe, Photos nouvellePhoto)
        {
            var objetAnnexe = await _condominiumMgtContext.Annexes.Where(x => x.IdAnnexe == idAnnexe).FirstOrDefaultAsync();

            if (objetAnnexe != null)
            {

                try
                {
                    objetAnnexe.Photos.Add(nouvellePhoto);
                    await _condominiumMgtContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return null;
        }


        public Annexes nouvelleAnnexe = new Annexes();

        public void AddPhotoToAnnexe(Photos nouvellePhoto)
        {
            this.nouvelleAnnexe.Photos.Add(nouvellePhoto);
        }

    }
}


