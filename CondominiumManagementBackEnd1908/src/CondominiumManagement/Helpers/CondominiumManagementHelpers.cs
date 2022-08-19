using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.EFContext;
using DAL.EFEntities;

namespace CondominiumManagement.Helpers
{
    public class CondominiumManagementHelpers
    {

        private readonly DAL.EFContext.CondominiumMgtContext condominiumMgtContext;
        private List<string> listContent = new List<string>();

        public CondominiumManagementHelpers(DAL.EFContext.CondominiumMgtContext _condominiumMgtContext)
        {
            condominiumMgtContext = _condominiumMgtContext;
        }

        public List<string> listeCodesLots()
        {
            using CondominiumMgtContext context = new CondominiumMgtContext();
            //var listContent = new List<string>();

            try
            {
                //var listeLots = context.Lots.ToList();
                var listContent = context.Lots.OrderByDescending(c => c.CodeLot).ToList();
            }
            catch (Exception e)
            {
                // TODO: Handle failure
                Console.WriteLine(e);
                throw;
                //Gestion d'erreurs à améliorer!!//
            }
            return listContent;
        }

        public bool isInList(string CodeLot)
        {
            List<string> listeCodes = listeCodesLots();
            var result = false;

            if (listeCodes != null)
            {
                return result = (listeCodes.Contains(CodeLot) ? true : false);

                /*if (listeCodes.Contains(CodeLot))
                {
                    return true;
                }
                else 
                {
                    return false;
                }*/
            }
            else 
            { 
                return false;
            }
        }

    }
}
   

