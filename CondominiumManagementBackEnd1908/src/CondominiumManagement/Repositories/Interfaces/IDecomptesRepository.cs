using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IDecomptesRepository
    {
        Task<Decomptes> AjouterLignesDecompteADecompte(LignesDecomptes nouvelleLigneDecompte, Decomptes decompte);
        Task<Decomptes> AjouterMontantTotalLignesDecompteADecompte(double? montantTotalLignesDecompte, Decomptes decompte);
        Task<double?> CalculerMontantTotalHorsTvaDecompte(ICollection<LignesDecomptes> listeLignesDecompte, Decomptes decompte);
        Task<double?> CalculerMontantTotalTvacDecompte(Decomptes decompte, int tauxTva, double? montantTotalHorsTva);
        Task<Decomptes> CreerDecompte(Decomptes nouveauDecompte);
        Task<Decomptes> CreerDecompteBis(Decomptes nouveauDecompte);
        Task<Decomptes> DetailsDecompte(int idDecompte);
        Task<IEnumerable<Decomptes>> GetDecomptesForCoproprietaire(string idCoproprietaire);
        Task<IEnumerable<Decomptes>> ListAllDecomptes();
        Task<Decomptes> ModifierDecompte(int idDecompte, Decomptes decompte);
        Task<Decomptes> ModifierDecompteBis(Decomptes decompte);
        Task<Decomptes> SupprimerDecompte(int idDecompte);
    }
}