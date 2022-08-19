using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IQuotitesRepository
    {
        Task<Quotites> CreerQuotite(Quotites nouvelleQuotite);
        Task<Quotites> CreerQuotiteBis(Quotites nouvelleQuotite);
        Task<Quotites> DetailsQuotite(int idQuotite);
        Task<Lots> GetQuotiteForLot(int idLot);
        Task<IEnumerable<Quotites>> ListAllQuotites();
        Task<Quotites> ModifierQuotite(int idQuotite, Quotites quotite);
        Task<Quotites> ModifierQuotiteBis(Quotites quotite);
        Task<Quotites> SupprimerQuotite(int idQuotite);
    }
}