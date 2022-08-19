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
    public class PhotosRepository : IPhotosRepository
    {
        private readonly CondominiumMgtContext _condominiumMgtContext;
        //private readonly IMapper _mapper;


        //!\\Il faut utiliser l'interface IFormFile pour passer un fichier via et sous le format HttpRequest!!!!//!\\
        //!\\Quand on utilise Cloudinary, on  peut utiliser aussi le type ImageUploadResult avec Task pour faire passer un fichier vers Cloudinary!!!!//!\\


        public PhotosRepository(CondominiumMgtContext condominiumMgtContext/*, IMapper mapper*/)
        {
            _condominiumMgtContext = condominiumMgtContext;
            /*_mapper = mapper;*/
        }


        //OK BON//
        /// <summary>
        /// Liste de toutes les Photos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Photos>> ListAllPhotos()
        {

            return (IEnumerable<DAL.EFEntities.Photos>)await _condominiumMgtContext.Photos.ToListAsync();

        }


        //OK BON//
        /// <summary>
        /// Détails Photo
        /// <param name="idPhoto"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Photos> DetailsPhoto(int idPhoto)
        {
            try
            {

                return await _condominiumMgtContext.Photos.Where(x => x.IdPhoto == idPhoto).FirstOrDefaultAsync();

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
        /// Photos pour une Annexe déterminé!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// <param name="idAnnexe"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DAL.EFEntities.Photos>> GetPhotosForAnnexe(int idAnnexe)
        {
            try
            {
                return await _condominiumMgtContext.Photos.Where(x => x.IdAnnexe == idAnnexe).ToListAsync();
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
        /// Créer/ajouter une nouvelle Photo
        /// </summary>
        /// <param name="nouvellePhoto">Objet contenu Photo</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Photos> CreerPhoto(DAL.EFEntities.Photos nouvellePhoto)
        {
            var result = await _condominiumMgtContext.Photos.AddAsync(nouvellePhoto);
            await _condominiumMgtContext.SaveChangesAsync();

            return result.Entity;
        }


        //OK BON//
        /// <summary>
        /// Créer/ajouter une nouvelle Photo Retry
        /// </summary>
        /// <param name="nouvellePhoto">Objet contenu Photo</param>
        /// <returns></returns>
        public async Task<ActionResult<DAL.EFEntities.Photos>> CreerPhotoRetry(DAL.EFEntities.Photos nouvellePhoto)
        {
            try
            {
                var result = await _condominiumMgtContext.Photos.AddAsync(nouvellePhoto);
                await _condominiumMgtContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //!\\ATTENTION URI et string!!!!//!\\
        //OK BON//
        /// <summary>
        /// Ajouter une nouvelle Photo via sa ressource
        /// </summary>
        /// <param name="urlPhoto"></param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Photos> AjouterPhotoViaUrl(int IdAnnexe, string urlPhoto)
        {
            //string stringUrlPhoto = urlPhoto.ToString(); A mettre dans le controller WebAPI

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();
            Photos nouvellePhoto = new Photos();

            try
            {
                nouvellePhoto.IdAnnexe = IdAnnexe;
                nouvellePhoto.Ressource = urlPhoto;

                var content = context.Photos.AddAsync(nouvellePhoto);
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
            return nouvellePhoto;

        }


        //OK BON//
        /// <summary>
        /// Modifier une Photo existante
        /// </summary>
        /// <param name="idPhoto">Identifiant de l'objet</param>
        /// <param name="photo">Objet contenu Photos</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Photos> ModifierPhoto(int idPhoto, DAL.EFEntities.Photos photo)
        {

            if (idPhoto != photo.IdPhoto)
            {
                return null;
            }

            _condominiumMgtContext.Entry(photo).State = EntityState.Modified;

            try
            {
                await _condominiumMgtContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //!\\A vérifier!!!!//!\\
                throw;
            }
            return photo;
        }

        //OK BON//
        /// <summary>
        /// Modifier une Photo existante
        /// </summary>
        /// <param name="idPhoto">Identifiant de l'objet</param>
        /// <param name="photo">Objet contenu Photos</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Photos> ModifierPhotoBis(DAL.EFEntities.Photos photo)
        {
            var content = await _condominiumMgtContext.Photos.Where(x => x.IdPhoto == photo.IdPhoto).FirstOrDefaultAsync();

            if (content != null)
            {
                content.IdAnnexe = photo.IdAnnexe;
                content.Ressource = photo.Ressource;

                await _condominiumMgtContext.SaveChangesAsync();

                return content;
            }
            return null;
        }

        //OK BON//
        /// <summary>
        /// Supprimer une Photo
        /// </summary>
        /// <param name="idPhoto">Identifiant du Photos</param>
        /// <returns></returns>
        public async Task<DAL.EFEntities.Photos> SupprimerPhoto(int idPhoto)
        {
            var result = await _condominiumMgtContext.Photos.FirstOrDefaultAsync(a => a.IdPhoto == idPhoto);

            if (result != null)
            {
                _condominiumMgtContext.Remove(idPhoto);
                await _condominiumMgtContext.SaveChangesAsync();
            }
            return null;
        }


        //A vérifier MAIS cette méthode asynchrone semble bonne!!//
        public async Task<DAL.EFEntities.Photos> CreerPhotoBis(DAL.EFEntities.Photos nouvellePhoto)
        {

            using var context = new CondominiumMgtContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var content = context.Photos.AddAsync(nouvellePhoto);
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
            return nouvellePhoto;
        }


        public async Task<DAL.EFEntities.Photos> AddPhotoToAnnexe(int idAnnexe, Photos nouvellePhoto)
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
    }
}
