using DAL.EFEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface ILignesDocumentsFournisseursRepository
    {
        //Task<LignesDecomptes> CreerLigneDocumentFournisseurBis(int idDecompte, int idCodePcmn, string description, int idlLigneDocumentsFournisseurs, int idQuotite, DateTime dateDebutLigne, DateTime dateFinLigne, int nbreJoursLigne, double? montantTotalTvacligne, double? montantTvaligne, string remarque);
        Task<LignesDocumentsFournisseurs> CreerLigneDocumentFournisseur(LignesDocumentsFournisseurs nouvelleLigneDocumentFournisseur);
        Task<LignesDocumentsFournisseurs> CreerLigneDocumentFournisseurTer(LignesDocumentsFournisseurs nouvelleLigneDocumentFournisseur);
        Task<LignesDocumentsFournisseurs> DetailsLigneDocumentFournisseur(int idLigneDocumentFournisseur);
        Task<IEnumerable<LignesDocumentsFournisseurs>> GetLignesDocumentsFournisseursForCoproprietaire(int idDocumentFournisseur);
        Task<IEnumerable<LignesDocumentsFournisseurs>> ListAllLignesDocumentsFournisseurs();
        Task<LignesDocumentsFournisseurs> ModifierLigneDocumentFournisseur(int idLigneDocumentFournisseur, LignesDocumentsFournisseurs ligneDocumentFournisseur);
        Task<LignesDocumentsFournisseurs> ModifierLigneDocumentFournisseurBis(LignesDocumentsFournisseurs ligneDocumentFournisseur);
        Task<LignesDocumentsFournisseurs> SupprimerLigneDocumentFournisseur(int idLigneDocumentFournisseur);
    }
}