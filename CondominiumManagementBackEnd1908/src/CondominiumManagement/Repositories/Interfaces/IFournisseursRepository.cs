using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IFournisseursRepository
    {
        Task<Fournisseurs> CreerFournisseur(Fournisseurs nouveauFournisseur);
        Task<Fournisseurs> CreerFournisseurBis(Fournisseurs nouveauFournisseur);
        Task<Fournisseurs> DetailsFournisseur(int idFournisseur);
        Task<IEnumerable<DocumentsFournisseurs>> GetFournisseurForDocumentFournisseur(int idDocumentFournisseur);
        Task<IEnumerable<Fournisseurs>> ListAllFournisseurs();
        Task<Fournisseurs> ModifierFournisseur(int idFournisseur, Fournisseurs fournisseur);
        Task<Fournisseurs> ModifierFournisseurBis(Fournisseurs fournisseur);
        Task<Fournisseurs> SupprimerFournisseur(int idFournisseur);
    }
}