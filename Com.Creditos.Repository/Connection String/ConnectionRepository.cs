using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Creditos.Repository.Connection_String
{
    public class ConnectionRepository
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CreditosDB"].ToString();
        }
    }
}
