using DAL.EFEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IPhotosRepository
    {
        Task<Photos> AjouterPhotoViaUrl(int IdAnnexe, string urlPhoto);
        Task<Photos> CreerPhoto(Photos nouvellePhoto);
        Task<ActionResult<DAL.EFEntities.Photos>> CreerPhotoRetry(DAL.EFEntities.Photos nouvellePhoto);
        Task<Photos> CreerPhotoBis(Photos nouvellePhoto);
        Task<Photos> DetailsPhoto(int idPhoto);
        Task<IEnumerable<Photos>> GetPhotosForAnnexe(int idAnnexe);
        Task<IEnumerable<Photos>> ListAllPhotos();
        Task<Photos> ModifierPhoto(int idPhoto, Photos photo);
        Task<Photos> ModifierPhotoBis(Photos photo);
        Task<Photos> SupprimerPhoto(int idPhoto);
        Task<DAL.EFEntities.Photos> AddPhotoToAnnexe(int idAnnexe, Photos nouvellePhoto);
    }
}