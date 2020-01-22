using Com.Creditos.Domain;
using Com.Creditos.Repository.Connection_String;
using Com.Creditos.Repository.Contract;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Creditos.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public Cliente GetCliente(string numeroDocumento)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionRepository.GetConnectionString()))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("NumeroDocumento", numeroDocumento);

                var cliente = connection.QuerySingle<Cliente>("sp_cliente_obtener", param: parameters, commandType: CommandType.StoredProcedure);
                return cliente;
            }
        }

        public IEnumerable<Cliente> GetClientes()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionRepository.GetConnectionString()))
            {
                connection.Open();
                var clientes = connection.Query<Cliente>("sp_cliente_listar", commandType: CommandType.StoredProcedure);
                return clientes;
            }
        }
    }
}
