using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IGroupementsRepository
    {
        Task<Groupements> CreerGroupement(Groupements nouveauGroupement);
        Task<Groupements> CreerGroupementBis(Groupements nouveauGroupement);
        Task<Groupements> DetailsGroupement(int idGroupement);
        Task<Groupes> GetGroupeForGroupement(int idGroupement);
        Task<IEnumerable<Groupements>> GetGroupementForLot(int idLot);
        Task<IEnumerable<Groupements>> GetGroupementsForCoproprietaire(string idCoproprietaire);
        Task<IEnumerable<Groupements>> GetGroupementsForGroupe(int idGroupe);
        Task<IEnumerable<Groupements>> ListAllGroupements();
        Task<Groupements> ModifierGroupement(int idGroupement, Groupements Groupement);
        Task<Groupements> ModifierGroupementBis(Groupements groupement);
        Task<Groupements> SupprimerGroupement(int idGroupement);
    }
}