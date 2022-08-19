using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IComptesBqueRepository
    {
        Task<ComptesBque> CreerCompteBque(ComptesBque nouveauCompteBque);
        Task<ComptesBque> CreerCompteBqueBis(ComptesBque nouveauCompteBque);
        Task<ComptesBque> DetailsComptesBque(int idCompteBque);
        Task<IEnumerable<ComptesBque>> GetComptesBqueForCoproprietaire(string idCoproprietaire);
        Task<IEnumerable<ComptesBque>> ListAllComptesBque();
        Task<ComptesBque> ModifierCompteBque(int idCompteBque, ComptesBque compteBque);
        Task<ComptesBque> ModifierCompteBqueBis(ComptesBque compteBque);
        Task<ComptesBque> SupprimerCompteBque(int idCompteBque);
    }
}