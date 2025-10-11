using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_LinqTarea
{
    internal class ResumenProducto
    {
        public string Categoria { get; set; }
        public int CantidadProductos { get; set; }
        public decimal PrecioPromedio { get; set; }
        public decimal PrecioMaximo { get; set; }
        public decimal PrecioMinimo { get; set; }

    }
}
