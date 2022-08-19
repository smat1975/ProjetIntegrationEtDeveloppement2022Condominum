using DAL.EFEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IAnnexesRepository
    {
        Task<DAL.EFEntities.Annexes> CreerAnnexe(DAL.EFEntities.Annexes nouvelleAnnexe);
        Task<ActionResult<DAL.EFEntities.Annexes>> CreerAnnexeRetry(DAL.EFEntities.Annexes nouvelleAnnexe);
        Task<DAL.EFEntities.Annexes> DetailsAnnexe(int idAnnexe);
        Task<List<string>> GetListAnnexes();
        Task<List<DAL.EFEntities.Annexes>> GetAllAnnexes();
        Task<Models.Annexes> GetAnnexeById(int idAnnexe);
        Task<IEnumerable<DAL.EFEntities.Annexes>> GetAnnexesForMessage(int idMessage);
        Task<IEnumerable<DAL.EFEntities.Annexes>> ListAllAnnexes();
        Task<DAL.EFEntities.Annexes> ModifierAnnexe(int idAnnexe, DAL.EFEntities.Annexes annexe);
        Task<DAL.EFEntities.Annexes> ModifierAnnexeBis(DAL.EFEntities.Annexes annexe);
        Task<DAL.EFEntities.Annexes> SupprimerAnnexe(int idAnnexe);
        Task<DAL.EFEntities.Annexes> AddPhotoToAnnexe(int idAnnexe, Photos nouvellePhoto);
    }
}