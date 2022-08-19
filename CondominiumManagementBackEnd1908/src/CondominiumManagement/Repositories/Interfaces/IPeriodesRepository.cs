using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IPeriodesRepository
    {
        Task<Periodes> CreerNouvellePeriode(Periodes nouvellePeriode);
        Task<Periodes> CreerPeriodeBis(Periodes nouvellePeriode);
        Task<Periodes> DetailsPeriode(int idPeriode);
        Task<IEnumerable<Decomptes>> GetDecomptesForPeriode(int idPeriode);
        Task<Decomptes> GetPeriodeForDecompte(int idDecompte);
        Task<IEnumerable<Periodes>> ListAllPeriodes();
        Task<Periodes> ModifierPeriode(int idperiode, Periodes periode);
        Task<Periodes> ModifierPeriodeBis(Periodes periode);
        Task<Periodes> SupprimerPeriode(int idPeriode);
    }
}