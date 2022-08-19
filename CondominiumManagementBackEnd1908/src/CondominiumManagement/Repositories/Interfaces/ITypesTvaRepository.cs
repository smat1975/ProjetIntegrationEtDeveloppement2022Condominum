using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface ITypesTvaRepository
    {
        Task<TypesTva> CreerTypeTva(TypesTva nouveauTypeTva);
        Task<TypesTva> CreerTypeTvaBis(TypesTva nouveauTypeTva);
        Task<TypesTva> DetailsTypeTva(int idTypeTva);
        Task<Decomptes> GetTypesTvaForDecompte(int idDecompte);
        Task<LignesDocumentsFournisseurs> GetTypesTvaForLigneDocumentFournissseur(int idLigneDocumentFournisseur);
        Task<IEnumerable<TypesTva>> ListAllTypesTva();
        Task<TypesTva> ModifierTypeTva(int idTypeTva, TypesTva typeTva);
        Task<TypesTva> ModifierTypeTvaBis(TypesTva typeTva);
        Task<TypesTva> SupprimerTypeTva(int idTypeTva);
    }
}