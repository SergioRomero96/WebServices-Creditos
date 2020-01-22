using Com.Creditos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Com.Creditos.Service.Contract
{
    //WebGet nos va a permitir trabajar como WCF SOAP o un servicio REST
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetCliente/{NumeroDocumento}",
            BodyStyle = WebMessageBodyStyle.Bare
            )]
        Cliente GetCliente(string numeroDocumento);

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetClientes",
            BodyStyle = WebMessageBodyStyle.Bare
            )]
        IEnumerable<Cliente> GetClientes();
    }
}
