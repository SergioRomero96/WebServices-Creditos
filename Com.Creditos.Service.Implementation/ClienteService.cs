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
    public class ClienteService : IClienteService
    {
        public Cliente GetCliente(string numeroDocumento)
        {
            using (var clienteFacade = new ClienteFacade())
            {
                return clienteFacade.GetCliente(numeroDocumento);
            }
        }

        public IEnumerable<Cliente> GetClientes()
        {
            using (var clienteFacade = new ClienteFacade())
            {
                return clienteFacade.GetClientes();
            }
        }
    }
}
