using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IGroupesRepository
    {
        Task<Groupes> CreerGroupe(Groupes nouveauGroupe);
        Task<Groupes> CreerGroupeBis(Groupes nouveauGroupe);
        Task<Groupes> DetailsGroupe(int idGroupe);
        Task<IEnumerable<Groupes>> ListAllGroupes();
        Task<Groupes> ModifierGroupe(int idGroupe, Groupes groupe);
        Task<Groupes> ModifierGroupeBis(Groupes groupe);
        Task<Groupes> SupprimerGroupe(int idGroupe);
    }
}