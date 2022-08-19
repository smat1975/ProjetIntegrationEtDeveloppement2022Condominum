using DAL.EFEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface ILocalisationsRepository
    {
        Task<Localisations> CreerLocalisation(Localisations nouvelleLocalisation);
        Task<Localisations> CreerLocalisationBis(Localisations nouvelleLocalisation);
        Task<Localisations> DetailsLocalisation(int idLocalisation);
        Task<IEnumerable<Lots>> GetLocalisationForLot(int idLot);
        Task<IEnumerable<Localisations>> ListAllLocalisations();
        Task<IEnumerable<Lots>> ListeAllLotsForLocalisation(int idLocalisation);
        Task<Localisations> ModifierLocalisation(int idLocalisation, Localisations localisation);
        Task<Localisations> ModifierLocalisationBis(Localisations localisation);
        Task<Localisations> SupprimerLocalisation(int idLocalisation);
    }
}