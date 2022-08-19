using DAL.EFEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories.Interfaces
{
    public interface IMessagesRepository
    {
        Task<ActionResult<DAL.EFEntities.Messages>> CreerMessageRetry(DAL.EFEntities.Messages nouveauMessage);
        Task<DAL.EFEntities.Messages> CreerMessageTer(DAL.EFEntities.Messages message);
        Task<Messages> DetailsMessage(int idMessage);
        Task<DAL.EFEntities.Messages> GetMessageById(int idMessage);
        Task<IEnumerable<Messages>> GetMessagesOfCoproprietaireExpediteur(string idExpediteur);
        Task<IEnumerable<Messages>> ListAllMessages();
        Task<IEnumerable<CondominiumManagement.Models.DTOs.MessagesComplexeDto>> ListAllMessagesComplexeDto();
        Task<IEnumerable<CondominiumManagement.Models.Messages>> ListAllMessagesSimple();
        Task<IEnumerable<DAL.EFEntities.Messages>> ListAllMessagesComplet();
        Task<Messages> ModifierMessage(int idMessage, Messages message);
        Task<Messages> ModifierMessageBis(Messages message);
        Task<DAL.EFEntities.Messages> SupprimerMessage(int idMessage);
        Task<IActionResult> SupprimerMessageBIS(int idMessage);
        Task<IActionResult> SupprimerMessageById(int idMessage);
        Task<ActionResult> SupprimerMessageTER(int idMessage);
        Task<ActionResult> SupprimerMessageDirecte(int idMessage);
        Task<DAL.EFEntities.Messages> AddAnnexeToMessage(int idMessage, Annexes annexe);
        Task<DAL.EFEntities.Destinations> AddDestinationToMessage(int idMessage, Destinations nouvelleDestination);

    }
}