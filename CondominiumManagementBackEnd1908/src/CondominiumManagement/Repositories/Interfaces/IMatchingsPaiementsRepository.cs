using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IMatchingsPaiementsRepository
    {
        Task<MatchingsPaiements> CreerMatchingPaiement(MatchingsPaiements nouveauMatchingPaiement);
        Task<MatchingsPaiements> CreerMatchingPaiementBis(MatchingsPaiements nouveauMatchingPaiement);
        Task<MatchingsPaiements> DetailsMatchingPaiement(int idMatchingPaiement);
        Task<IEnumerable<MatchingsPaiements>> GetMatchingsPaiementsForCompteBque(int idCompteBque);
        Task<IEnumerable<MatchingsPaiements>> GetMatchingsPaiementsForDecompte(int idDecompte);
        Task<IEnumerable<MatchingsPaiements>> GetMatchingsPaiementsForPaiement(int idPaiement);
        Task<IEnumerable<MatchingsPaiements>> ListAllMatchingsPaiements();
        Task<MatchingsPaiements> ModifierMatchingPaiement(int idMatchingPaiement, MatchingsPaiements matchingPaiement);
        Task<MatchingsPaiements> ModifierMatchingPaiementBis(MatchingsPaiements matchingPaiement);
        Task<MatchingsPaiements> SupprimerMatchingPaiement(int idMatchingPaiement);
    }
}