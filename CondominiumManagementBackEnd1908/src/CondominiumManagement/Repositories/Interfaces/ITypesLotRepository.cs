using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface ITypesLotRepository
    {
        Task<TypesLot> CreerTypeLot(TypesLot nouveauTypeLot);
        Task<TypesLot> CreerTypeLotBis(TypesLot nouveauTypeLot);
        Task<TypesLot> DetailsTypeLot(int idTypeLot);
        Task<IEnumerable<TypesLot>> ListAllTypesLot();
        Task<TypesLot> ModifierTypeLot(int idTypeLot, TypesLot typeLot);
    }
}