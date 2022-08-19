using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface ILotsRepository
    {
        Task<Lots> CreerLot(Lots nouveauLot);
        Task<Lots> CreerLotBis(Lots nouveauLot);
        Task<Lots> DetailsLot(int idLot);
        Task<Lots> GetLotForCopropriete(int idCopropriete);
        Task<IEnumerable<Lots>> GetLotsForCopropietaire(string idCoproprietaire);
        Task<IEnumerable<Lots>> ListAllLots();
        Task<Lots> ModifierLot(int idLot, Lots lot);
        Task<Lots> ModifierLotBis(Lots lot);
        Task<Lots> SupprimerLot(int idLot);
    }
}