using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class DetalleVenta
    {
        public string codigo { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; }
        public string descripcion { get; set; }
        public decimal descuento { get; set; }
        public double porcentajeDescuento { get; set; }
    }
}
