using Com.Creditos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Creditos.Repository.Contract
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetClientes();
        Cliente GetCliente(string numeroDocumento);
    }
}
