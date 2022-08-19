using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface ICodesPcmnRepository
    {
        Task<DAL.EFEntities.CodesPcmn> CreerCodePcmn(DAL.EFEntities.CodesPcmn nouveauCodePcmn);
        Task<DAL.EFEntities.CodesPcmn> CreerCodePcmnBis(DAL.EFEntities.CodesPcmn nouveauCodePcmn);
        Task<DAL.EFEntities.CodesPcmn> DetailsCodesPcmn(int idCodePcmn);
        Task<IEnumerable<DAL.EFEntities.CodesPcmn>> ListAllCodesPcmn();
        Task<DAL.EFEntities.CodesPcmn> ModifierCodePcmn(int idCodePcmn, DAL.EFEntities.CodesPcmn codesPcmn);
        Task<DAL.EFEntities.CodesPcmn> ModifierCodePcmnBis(DAL.EFEntities.CodesPcmn codePcmn);
        Task<DAL.EFEntities.CodesPcmn> SupprimerCodePcmn(int idCodePcmn);


        //!\\A Verifier!!!!//!\\

        Task<IEnumerable<DAL.EFEntities.CodesPcmn>> GetCodesPcmnForLigneDocumentFournisseur(int idLigneDocumentFournisseur);
        Task<IEnumerable<DAL.EFEntities.CodesPcmn>> GetCodesPcmnForCodeDecompte(int codeDecompte);

    }
}