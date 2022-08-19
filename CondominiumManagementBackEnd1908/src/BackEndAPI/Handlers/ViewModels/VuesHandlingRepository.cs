using BackEndAPI.Handlers.ErrorHandling;
using BackEndAPI.Handlers.ViewModels;
using BackEndAPI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CondominiumManagement.Models.DTOs;


namespace BackEndAPI.Handlers.ViewModels
{
    public class VuesHandlingRepository : IVuesHandlingRepository
    {

        private readonly string _connectionString;

        public VuesHandlingRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<MessagesPublicsToShowDto>> GetAllMessagesPublicsToShow()
        {
            try
            {
                using (SqlConnection oConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetTVueMessages", oConn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<MessagesPublicsToShowDto>();
                        await oConn.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToValueMessagesPublics(reader));
                            }
                        }

                        return response;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<MessagesCompleteToShowDto>> GetAllMessagesCompleteToShow()
        {
            try
            {
                using (SqlConnection oConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetTVueMessagesComplete", oConn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<MessagesCompleteToShowDto>();
                        await oConn.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToValueMessagesComplete(reader));
                            }
                        }

                        return response;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<MessagesToShowDto>> GetAllMessagesToShow()
        {
            try
            {
                using (SqlConnection oConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetTVueMessagesGen", oConn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<MessagesToShowDto>();
                        await oConn.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToValueMessages(reader));
                            }
                        }

                        return response;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<MessagesUtilisateurToShowDto>> GetAllMessagesUtilisateurToShow(int IdUtilisateur)
        {
            try
            {
                using (SqlConnection oConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetTVueMessagesUtilisateur", oConn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdUtilisateur", IdUtilisateur));
                        var response = new List<MessagesUtilisateurToShowDto>();
                        await oConn.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToValueMessagesUtilisateur(reader));
                            }
                        }

                        return response;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<MessagesUtilisateurDetailsToShowDto>> GetAllMessagesUtilisateurDetailsToShow(int IdMessage)
        {
            try
            {
                using (SqlConnection oConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetTVueMessagesUtilisateurDetails", oConn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdMessage", IdMessage));
                        var response = new List<MessagesUtilisateurDetailsToShowDto>();
                        await oConn.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToValueMessagesUtilisateurDetails(reader));
                            }
                        }

                        return response;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /*============*/
        

        private MessagesPublicsToShowDto MapToValueMessagesPublics(SqlDataReader reader)
        {
            try
            {
                return new MessagesPublicsToShowDto()
                {

                    ContenuMessage = reader["ContenuMessage"].ToString(),
                    DateExpedition = (DateTime)reader["DateExpedition"],
                    //EMail = reader["EMail"].ToString(),
                };
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private MessagesToShowDto MapToValueMessages(SqlDataReader reader)
        {
            try
            {
                return new MessagesToShowDto()
                {
                    //Expediteur = reader["Expediteur"].ToString(),   
                    //Email = reader["Email"].ToString(),
                    DateExpedition = (DateTime)reader["DateExpedition"],
                    TitreMessage = reader["TitreMessage"].ToString(),
                    ContenuMessage = reader["ContenuMessage"].ToString(),
                    TypeMessage = reader["TypeMessage"].ToString(),
                };
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private MessagesUtilisateurToShowDto MapToValueMessagesUtilisateur(SqlDataReader reader)
        {
            try
            {
                return new MessagesUtilisateurToShowDto()
                {
                    DateExpedition = (DateTime)reader["DateExpedition"],
                    //TypeMessage = reader["TypeMessage"].ToString(),
                    TitreMessage = reader["TitreMessage"].ToString(),
                    Validation = (bool?)reader["Lu"],
                    //Email = reader["Email"].ToString(),
                };
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private MessagesUtilisateurDetailsToShowDto MapToValueMessagesUtilisateurDetails(SqlDataReader reader)
        {
            try
            {
                return new MessagesUtilisateurDetailsToShowDto()
                {
                    //Email = reader["Email"].ToString(),
                    DateExpedition = (DateTime)reader["DateExpedition"],
                    TitreMessage = reader["TitreMessage"].ToString(),
                    ContenuMessage = reader["ContenuMessage"].ToString(),
                    //TypeMessage = reader["TypeMessage"].ToString(),
                    Validation = (bool?)reader["Lu"],
                };
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private MessagesCompleteToShowDto MapToValueMessagesComplete(SqlDataReader reader)
        {
            try
            {
                return new MessagesCompleteToShowDto()
                {
                    Email = reader["Email"].ToString(),
                    DateExpedition = (DateTime)reader["DateExpedition"],
                    //TitreMessage = reader["TitreMessage"].ToString(),
                    ContenuMessage = reader["ContenuMessage"].ToString(),
                    //TypeMessage = reader["TypeMessage"].ToString(),
                    //Validation = (bool?)reader["Lu"],
                };
            }
            catch (SqlException e)
            {
                throw new CondominiumMgtErrors(e.Number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
