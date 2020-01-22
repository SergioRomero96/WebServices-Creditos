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
    public class CreditoRepository : ICreditoRepository
    {
        public bool Delete(int id)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionRepository.GetConnectionString()))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("IdCredito", id);

                var result = connection.Execute("sp_credito_eliminar", param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public IEnumerable<Credito> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionRepository.GetConnectionString()))
            {
                connection.Open();
                var creditos = connection.Query<Credito>("sp_credito_listar", commandType: CommandType.StoredProcedure);
                return creditos;
            }
        }

        public Credito Add(Credito credito)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionRepository.GetConnectionString()))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("TipoCredito", credito.TipoCredito);
                parameters.Add("IdCliente", credito.IdCliente);
                parameters.Add("Fecha", credito.Fecha);
                parameters.Add("Monto", credito.Monto);
                parameters.Add("DiaPago", credito.DiaPago);
                parameters.Add("Tasa", credito.Tasa);
                parameters.Add("Comision", credito.Comision);
                parameters.Add("IdCredito", credito.IdCredito, DbType.Int32, ParameterDirection.Output);

                //va a obtener un valor autogenerado para IdCredito
                connection.ExecuteScalar("sp_credito_insertar", param: parameters, commandType:CommandType.StoredProcedure);
                var idCredito = parameters.Get<Int32>("IdCredito");
                credito.IdCredito = idCredito;
                return credito;
            }
        }

        public Credito Update(Credito credito)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionRepository.GetConnectionString()))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("IdCredito", credito.IdCredito);
                parameters.Add("TipoCredito", credito.TipoCredito);
                parameters.Add("IdCliente", credito.IdCliente);
                parameters.Add("Fecha", credito.Fecha);
                parameters.Add("Monto", credito.Monto);
                parameters.Add("DiaPago", credito.DiaPago);
                parameters.Add("Tasa", credito.Tasa);
                parameters.Add("Comision", credito.Comision);

                var result = connection.Execute("sp_credito_actualizar", param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0 ? credito : new Credito();
            }
        }
    }
}
