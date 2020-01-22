using Com.Creditos.Domain;
using Com.Creditos.Facade;
using Com.Creditos.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Creditos.Service
{
    public class CreditoService : ICreditoService
    {
        public bool Delete(string id)
        {
            using (var creditoFacade = new CreditoFacade())
            {
                int idCredito = Int32.Parse(id);
                return creditoFacade.Delete(idCredito);
            }
        }

        public Credito GetCredito(string id)
        {
            using (var creditoFacade = new CreditoFacade())
            {
                int idCredito = Convert.ToInt32(id);
                return creditoFacade.GetCredito(idCredito);
            }
        }

        public IEnumerable<Credito> GetCreditos()
        {
            using (var creditoFacade = new CreditoFacade())
            {
                return creditoFacade.GetCreditos();
            }
        }

        public Credito Save(Credito credito)
        {
            using (var creditoFacade = new CreditoFacade())
            {
                return creditoFacade.Save(credito);
            }
        }

        public Credito Update(Credito credito)
        {
            using (var creditoFacade = new CreditoFacade())
            {
                return creditoFacade.Update(credito);
            }
        }
    }
}
