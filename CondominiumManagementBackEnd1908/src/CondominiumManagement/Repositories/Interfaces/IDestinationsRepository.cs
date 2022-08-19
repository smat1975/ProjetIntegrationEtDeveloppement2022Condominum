using DAL.EFEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IDestinationsRepository
    {
        Task<Destinations> CreerDestination(Destinations nouvelleDestination);
        Task<ActionResult<DAL.EFEntities.Destinations>> CreerDestinationRetry(DAL.EFEntities.Destinations nouvelleDestination);
        Task<Destinations> CreerDestinationBis(Destinations nouvelleDestination);
        Task<Destinations> DetailsDestination(int idDestination);
        Task<IEnumerable<Destinations>> GetDestinationsForCoproprietaire(string idCoproprietaire);
        Task<IEnumerable<Destinations>> GetDestinationsForMessage(int idMessage);
        Task<IEnumerable<Destinations>> ListAllDestinations();
        Task<Destinations> ModifierDestination(int idDestination, Destinations destination);
        Task<Destinations> ModifierDestinationBis(Destinations destination);
        Task<Destinations> SupprimerDestination(int idDestination);
    }
}