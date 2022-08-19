using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumManagement.Repositories
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
        }

}


