using Com.Creditos.Domain;
using Com.Creditos.Repository;
using Com.Creditos.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Creditos.Facade
{
    public class ClienteFacade : IDisposable
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteFacade()
        {
            _clienteRepository = new ClienteRepository();
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _clienteRepository.GetClientes();
        }

        public Cliente GetCliente(string numeroDocumento)
        {
            return _clienteRepository.GetCliente(numeroDocumento);
        }

        public void Dispose()
        {
            //Suprime algunas instancias cuando ya no lo necesite
            GC.SuppressFinalize(this);
        }
    }
}
