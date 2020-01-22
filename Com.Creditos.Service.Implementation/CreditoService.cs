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
        public bool Delete(int id)
        {
            using (var creditoFacade = new CreditoFacade())
            {
                return creditoFacade.Delete(id);
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
