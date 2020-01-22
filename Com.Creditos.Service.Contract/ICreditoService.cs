using Com.Creditos.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Com.Creditos.Service.Contract
{
    [ServiceContract]
    public interface ICreditoService
    {
        [OperationContract]
        [Description("Servicio REST que lista toda la informacion de los creditos")]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetCreditos",
            BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Credito> GetCreditos();

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetCredito/{id}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        Credito GetCredito(string id);

        [OperationContract]
        [WebInvoke(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            UriTemplate = "/NewCredito",
            BodyStyle = WebMessageBodyStyle.Bare)]
        Credito Save(Credito credito);

        [OperationContract]
        [WebInvoke(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "PUT",
            UriTemplate = "/UpdateCredito",
            BodyStyle = WebMessageBodyStyle.Bare)]
        Credito Update(Credito credito);

        [OperationContract]
        [WebInvoke(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "DELETE",
            UriTemplate = "/DeleteCredito/{id}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        bool Delete(string id);
    }
}
