using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IRaisonsClotureRepository
    {
        Task<RaisonsCloture> CreerRaisonCloture(RaisonsCloture nouvelleRaisonCloture);
        Task<RaisonsCloture> CreerRaisonClotureBis(RaisonsCloture nouvelleRaisonCloture);
        Task<RaisonsCloture> DetailsRaisonCloture(int idRaisonCloture);
        Task<Coproprietaires> GetCoproprietairesForRaisonCloture(int idRaisonCloture);
        Task<Coproprietaires> GetRaisonClotureForCoproprietaire(string idCoproprietaire);
        Task<IEnumerable<RaisonsCloture>> ListAllRaisonsCloture();
        Task<RaisonsCloture> ModifierRaisonCloture(int idRaisonCloture, RaisonsCloture raisonCloture);
        Task<RaisonsCloture> ModifierRaisonClotureBis(RaisonsCloture raisonCloture);
        Task<RaisonsCloture> SupprimerRaisonCloture(int idRaisonCloture);
    }
}