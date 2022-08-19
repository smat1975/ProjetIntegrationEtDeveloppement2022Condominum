using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface ICoproprietesRepository
    {
        Task<Coproprietes> CreerCopropriete(Coproprietes nouvelleCopropriete);
        Task<Coproprietes> CreerCoproprieteBis(Coproprietes nouvelleCopropriete);
        Task<Coproprietes> DetailsCopropriete(int idCopropriete);
        Task<IEnumerable<Coproprietes>> GetCompteBqueForCopropriete(string idCoproprietaire);
        Task<IEnumerable<Coproprietes>> GetCoproprieteForCoproprietaire(string idCoproprietaire);
        Task<IEnumerable<Coproprietes>> ListAllCoproprietes();
        Task<Coproprietes> ModifierCopropriete(int idCopropriete, Coproprietes copropriete);
        Task<Coproprietes> ModifierCoproprieteBis(Coproprietes copropriete);
        Task<Coproprietes> SupprimerCopropriete(int idCopropriete);
    }
}