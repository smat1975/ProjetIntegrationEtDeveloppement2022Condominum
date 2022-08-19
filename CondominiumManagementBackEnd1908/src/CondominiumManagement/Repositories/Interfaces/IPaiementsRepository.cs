using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IPaiementsRepository
    {
        Task<Paiements> CreerPaiement(Paiements nouveauPaiement);
        Task<Paiements> CreerPaiementBis(Paiements nouveauPaiement);
        Task<Paiements> DetailsPaiement(int idPaiement);
        Task<IEnumerable<Paiements>> GetPaiementsForCopropietaire(string idCoproprietaire);
        Task<IEnumerable<Paiements>> GetPaiementsFromCompteBquePayeur(int idCompteBquePayeur);
        Task<IEnumerable<Paiements>> ListAllPaiements();
        Task<Paiements> ModifierPaiement(int idPaiement, Paiements paiement);
        Task<Paiements> ModifierPaiementBis(Paiements paiement);
        Task<Paiements> SupprimerPaiement(int idPaiement);
    }
}