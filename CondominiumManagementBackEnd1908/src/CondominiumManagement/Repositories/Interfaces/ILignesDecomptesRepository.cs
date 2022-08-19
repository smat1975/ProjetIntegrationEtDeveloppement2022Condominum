using DAL.EFEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface ILignesDecomptesRepository
    {
        Task<double?> CalculerMontantTotalTvacLigne(LignesDecomptes ligneDecompte, double? montantHorsTva, double? montantTvaLigne);
        Task<double?> CalculerMontantTvaLigne(LignesDecomptes ligneDecompte, int tauxTva, double? montantHorsTva);
        Task<int> CalculerNombreJoursLigne(LignesDecomptes ligneDecompte, DateTime dateDebutLigne, DateTime dateFinLigne);
        Task<LignesDecomptes> CreerLigneDecompte(LignesDecomptes nouvelleLigneDecompte);
        Task<LignesDecomptes> CreerLigneDecompteBis(int idDecompte, int idCodePcmn, string description, int idlLigneDocumentsFournisseurs, int idQuotite, DateTime dateDebutLigne, DateTime dateFinLigne, int nbreJoursLigne, double? montantTotalTvacligne, double? montantTvaligne, string remarque);
        Task<LignesDecomptes> CreerLigneDecompteTer(LignesDecomptes nouvelleLigneDecompte);
        Task<LignesDecomptes> DetailsLigneDecompte(int idLigneDecompte);
        Task<IEnumerable<LignesDecomptes>> GetLignesDecompteForDecompte(int idDecompte);
        Task<IEnumerable<LignesDecomptes>> ListAllLignesDecomptes();
        Task<LignesDecomptes> ModifierDecompte(int idDecompte, LignesDecomptes ligneDecompte);
        Task<LignesDecomptes> ModifierLigneDecompteBis(LignesDecomptes ligneDecompte);
        Task<LignesDecomptes> SupprimerLigneDecompte(int idLigneDecompte);
    }
}