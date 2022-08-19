using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IDocumentsFournisseursRepository
    {
        Task<DocumentsFournisseurs> AjouterLignesDocumentFournisseurADocumentFournisseur(LignesDocumentsFournisseurs nouvelleLigneDocumentFournisseur, DocumentsFournisseurs documentFournisseur);
        Task<DocumentsFournisseurs> CreerDocumentFournisseur(DocumentsFournisseurs nouveauDocumentFournisseur);
        Task<DocumentsFournisseurs> CreerDocumentFournisseurBis(DocumentsFournisseurs nouveauDocumentFournisseur);
        Task<DocumentsFournisseurs> DetailsDocumentFournisseur(int idDocumentFournisseur);
        Task<IEnumerable<DocumentsFournisseurs>> GetDocumentsFournisseurForFournisseur(int idFournisseur);
        Task<IEnumerable<DocumentsFournisseurs>> ListAllDocumentsFournisseur();
        Task<DocumentsFournisseurs> ModifierDocumentFournisseur(int idDocumentFournisseur, DocumentsFournisseurs documentFournisseur);
        Task<DocumentsFournisseurs> ModifierDocumentFournisseurBis(DocumentsFournisseurs documentFournisseur);
        Task<DocumentsFournisseurs> SupprimerDocumentFournisseur(int idDocumentFournisseur);
    }
}