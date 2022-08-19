using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface ICoproprietairesRepository
    {
        Task<Coproprietaires> CreerCoproprietaire(Coproprietaires nouveauCoproprietaire);
        Task<Coproprietaires> CreerCoproprietaireBis(Coproprietaires nouveauCoproprietaire);
        Task<Coproprietaires> DetailsCoproprietaires(string idCoproprietaire);
        Task<IEnumerable<Coproprietaires>> ListAllCoproprietaires();
        Task<Coproprietaires> ModifierCoproprietaire(string idCoproprietaire, Coproprietaires coproprietaire);
        Task<Coproprietaires> ModifierCoproprietaireBis(Coproprietaires coproprietaire);
        Task<Coproprietaires> SupprimerCoproprietaire(string idCoproprietaire);
    }
}