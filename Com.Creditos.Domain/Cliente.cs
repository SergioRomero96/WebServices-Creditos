using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Creditos.Domain
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int IdCliente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }
        [DataMember]
        public string NumeroDocumento { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public DateTime Fechanac { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string CodigoPostal { get; set; }
        [DataMember]
        public string EstadoCivil { get; set; }
    }
}
