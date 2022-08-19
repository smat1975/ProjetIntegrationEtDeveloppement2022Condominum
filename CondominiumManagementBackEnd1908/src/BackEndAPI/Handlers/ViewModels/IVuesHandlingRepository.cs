using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Handlers.ViewModels;
using CondominiumManagement.Models.DTOs;

namespace BackEndAPI.Handlers.ViewModels
{
    public interface IVuesHandlingRepository
    {
        Task<List<MessagesPublicsToShowDto>> GetAllMessagesPublicsToShow();
        Task<List<MessagesCompleteToShowDto>> GetAllMessagesCompleteToShow();
        Task<List<MessagesToShowDto>> GetAllMessagesToShow();
        Task<List<MessagesUtilisateurToShowDto>> GetAllMessagesUtilisateurToShow(int IdUtilisateur);
        Task<List<MessagesUtilisateurDetailsToShowDto>> GetAllMessagesUtilisateurDetailsToShow(int IdMessage);
        //Task<List<Domain.Models.MessagesPublicsToShowDto>> GetAllMessagesPublicsAcpToShow(int idACp);

        //Domain.Models.MessagesPublicsToShowDto MapToValue(System.Data.SqlClient.SqlDataReader reader);
        //DataSet GetTVueMessagesAcp(int IdAcp);
    }
}
