using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI;
using System.Data.Common;

namespace BackEndAPI.Handlers.ErrorHandling
{
    public class CondominiumMgtErrors : Exception
    {

        public int errID { get; set; }
        public override string Message { get; }

        public CondominiumMgtErrors(int errorID)
        {
            errID = errorID;
            switch (errID)
            {
                case 55401:
                    this.Message =
                        " ... ";
                    break;
                case 55501:
                    this.Message =
                        " ... ";
                    break;
                case 55502:
                    this.Message =
                        " ... ";
                    break;
                case 55511:
                    this.Message =
                        " ... ";
                    break;
                case 55512:
                    this.Message =
                        " ... ";
                    break;
                case 55513:
                    this.Message =
                        " ... ";
                    break;

                case 56001:
                    this.Message = " ... ";
                    break;
                case 18456:
                    this.Message = " ... ";
                    break;
                default:
                    this.Message = " ... ";
                    break;
            }
        }

        /*public static int SqlExceptionToCondominiumMgtErrors(SqlException sqlEx) //Méthode permettant de "convertir" une erreur sql en erreur custom.
        {
            int errorCode = 999999999;
            switch (sqlEx.Number)
            {
                case 2627:
                    if (sqlEx.Message.Contains("..."))
                        errorCode = 55511;
                    if (sqlEx.Message.Contains("..."))
                        errorCode = 55512;
                    if (sqlEx.Message.Contains("..."))
                        errorCode = 55513;
                    break;
                case 3609:
                    if (sqlEx.Message.Contains("55401"))
                        errorCode = 55401;
                    if (sqlEx.Message.Contains("55501"))
                        errorCode = 55501;
                    if (sqlEx.Message.Contains("55502"))
                        errorCode = 55502;
                    break;
                case 18456:
                    errorCode = 56100;
                    break;

                default:
                    errorCode = 999999999;
                    break;
            }

            return errorCode;
        }*/
    }

}
