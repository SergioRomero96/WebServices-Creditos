using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Com.Creditos.Web.Models
{
    public class CreditoViewModel
    {
        public int IdCredito { get; set; }
        public int TipoCredito { get; set; }
        public int IdCliente { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DiaPago { get; set; }
        public decimal Tasa { get; set; }
        public decimal Comision { get; set; }
    }
}