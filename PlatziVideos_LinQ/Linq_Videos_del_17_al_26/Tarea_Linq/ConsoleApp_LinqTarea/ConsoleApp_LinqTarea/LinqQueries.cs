using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp_LinqTarea
{
    internal class LinqQueries
    {
        private List<Categoria> categorias = new List<Categoria>();

        private List<Producto> productos = new List<Producto>();

        internal LinqQueries()
        {
            // Inicializar categorías
            categorias = new List<Categoria>()
    {
        new Categoria { CategoriaId = 1, Nombre = "Bebidas" },
        new Categoria { CategoriaId = 2, Nombre = "Snacks" },
        new Categoria { CategoriaId = 3, Nombre = "Lácteos" },
        new Categoria { CategoriaId = 4, Nombre = "Frutas" },
        new Categoria { CategoriaId = 5, Nombre = "Verduras" },
        new Categoria { CategoriaId = 6, Nombre = "Cereales" },
        new Categoria { CategoriaId = 7, Nombre = "Carnes" },
        new Categoria { CategoriaId = 8, Nombre = "Panadería" }
    };

            // Inicializar productos
            productos = new List<Producto>()
    {
        // BEBIDAS
        new Producto { Id = 1, Nombre = "Coca-Cola", CategoriaId = 1, Precio = 1.50m, Stock = 50 },
        new Producto { Id = 2, Nombre = "Pepsi", CategoriaId = 1, Precio = 1.40m, Stock = 30 },
        new Producto { Id = 3, Nombre = "Agua Mineral", CategoriaId = 1, Precio = 0.80m, Stock = 100 },
        new Producto { Id = 4, Nombre = "Jugo de Naranja", CategoriaId = 1, Precio = 1.75m, Stock = 25 },

        // SNACKS
        new Producto { Id = 5, Nombre = "Galletas Oreo", CategoriaId = 2, Precio = 2.00m, Stock = 20 },
        new Producto { Id = 6, Nombre = "Papas Fritas Lays", CategoriaId = 2, Precio = 1.25m, Stock = 40 },
        new Producto { Id = 7, Nombre = "Doritos", CategoriaId = 2, Precio = 1.50m, Stock = 35 },
        new Producto { Id = 8, Nombre = "Chocolatina Snickers", CategoriaId = 2, Precio = 1.10m, Stock = 15 },

        // LÁCTEOS
        new Producto { Id = 9, Nombre = "Yogurt Natural", CategoriaId = 3, Precio = 0.90m, Stock = 15 },
        new Producto { Id = 10, Nombre = "Queso Mozzarella", CategoriaId = 3, Precio = 3.50m, Stock = 10 },
        new Producto { Id = 11, Nombre = "Leche Entera", CategoriaId = 3, Precio = 1.20m, Stock = 60 },
        new Producto { Id = 12, Nombre = "Mantequilla", CategoriaId = 3, Precio = 2.10m, Stock = 25 },

        // FRUTAS
        new Producto { Id = 13, Nombre = "Manzanas", CategoriaId = 4, Precio = 1.80m, Stock = 40 },
        new Producto { Id = 14, Nombre = "Bananas", CategoriaId = 4, Precio = 1.10m, Stock = 50 },
        new Producto { Id = 15, Nombre = "Uvas", CategoriaId = 4, Precio = 2.50m, Stock = 20 },
        new Producto { Id = 16, Nombre = "Fresas", CategoriaId = 4, Precio = 2.90m, Stock = 18 },

        // VERDURAS
        new Producto { Id = 17, Nombre = "Tomates", CategoriaId = 5, Precio = 1.30m, Stock = 35 },
        new Producto { Id = 18, Nombre = "Lechuga", CategoriaId = 5, Precio = 0.95m, Stock = 25 },
        new Producto { Id = 19, Nombre = "Zanahorias", CategoriaId = 5, Precio = 1.00m, Stock = 30 },
        new Producto { Id = 20, Nombre = "Pimientos", CategoriaId = 5, Precio = 1.75m, Stock = 20 },

        // CEREALES
        new Producto { Id = 21, Nombre = "Avena", CategoriaId = 6, Precio = 1.60m, Stock = 40 },
        new Producto { Id = 22, Nombre = "Corn Flakes", CategoriaId = 6, Precio = 2.20m, Stock = 30 },
        new Producto { Id = 23, Nombre = "Granola", CategoriaId = 6, Precio = 3.00m, Stock = 15 },

        // CARNES
        new Producto { Id = 24, Nombre = "Pechuga de Pollo", CategoriaId = 7, Precio = 4.50m, Stock = 20 },
        new Producto { Id = 25, Nombre = "Carne de Res", CategoriaId = 7, Precio = 6.00m, Stock = 15 },
        new Producto { Id = 26, Nombre = "Chuleta de Cerdo", CategoriaId = 7, Precio = 5.50m, Stock = 10 },

        // PANADERÍA
        new Producto { Id = 27, Nombre = "Pan Blanco", CategoriaId = 8, Precio = 1.00m, Stock = 60 },
        new Producto { Id = 28, Nombre = "Pan Integral", CategoriaId = 8, Precio = 1.20m, Stock = 50 },
        new Producto { Id = 29, Nombre = "Croissant", CategoriaId = 8, Precio = 1.80m, Stock = 25 },
        new Producto { Id = 30, Nombre = "Donas", CategoriaId = 8, Precio = 1.50m, Stock = 30 }
            };
        }

        //Reto: 1 JOIN / GROUPJOIN / LEFT JOIN
        //Combina las colecciones de categorías y productos para mostrar el nombre de la categoría junto con el nombre de cada producto.
        //Asegúrate de incluir las categorías que no tengan productos asociados(LEFT JOIN).

        public IEnumerable<ProductoCategoria> NombreProductoCategoria()
        {
            var consulta = from c in categorias
                           join p in productos
                           on c.CategoriaId equals p.CategoriaId into grupo
                           from producto in grupo.DefaultIfEmpty()  // Left Join
                           select new ProductoCategoria
                           {
                               NombreCategoria = c.Nombre,
                               NombreProducto = producto?.Nombre ?? "Sin productos"
                           };

            return consulta;



        }

        /* 2️ GROUPBY + AGREGACIONES (Count(), Average(), Max(), Min()
        Reto:
        Agrupa los productos por categoría y calcula para cada grupo:
        la cantidad de productos,
        el promedio de precios,
        el precio máximo y mínimo dentro del grupo.
        Objetivo: Mostrar un resumen de estadísticas por categoría.*/

        public IEnumerable<ResumenProducto> ResumenPorCategoria()
        {
            var resumen = from c in categorias
                          join p in productos
                          on c.CategoriaId equals p.CategoriaId
                          group p by c.Nombre into grupo
                          select new ResumenProducto
                          {
                              Categoria = grupo.Key,
                              CantidadProductos = grupo.Count(),
                              PrecioPromedio = grupo.Average(x => x.Precio),
                              PrecioMaximo = grupo.Max(x => x.Precio),
                              PrecioMinimo = grupo.Min(x => x.Precio),
                          };
            return resumen;

        }
        /* 3 SUBCONSULTAS (Subqueries)

        Reto:
        Usa una subconsulta para encontrar los productos cuyo precio sea igual al mayor precio dentro de su categoría.
        Objetivo: Mostrar solo los productos más caros de cada categoría.*/
        public IEnumerable<object> ProductosMasCarosDeCadaCategoria()
        {
            var productosCaros = productos
                .Where(p => p.Precio == productos
                .Where(x => x.CategoriaId == p.CategoriaId).Max(x => x.Precio)).Select(p => new
                {
                    p.Nombre,
                    Categoria = categorias.First(c => c.CategoriaId == p.CategoriaId).Nombre,
                    p.Precio
                });
            return productosCaros;
        }

        /* 4 AGRGREGATE
         * Usa Aggregate para concatenar los nombres de todos los productos en una sola cadena de texto separada por comas.*/
        public string NombreDeProductos()
        {
            string Productos = productos.Select(p => p.Nombre).Aggregate((actual, siguiente) => actual + ", " + siguiente);
            return Productos;
        }



        // Reto 5 en clase program

        // Reto 5
        public void CategoriasConMayorPrecioPromedio()
        {
            var resultado =
                (from p in productos
                 group p by p.CategoriaId into grupoCat
                 let promedio = grupoCat.Average(x => x.Precio)
                 orderby promedio descending
                 select new
                 {
                     Categoria = categorias.First(c => c.CategoriaId == grupoCat.Key).Nombre,
                     Promedio = promedio,
                     Productos = grupoCat
                         .OrderByDescending(x => x.Precio)
                         .Select(x => new { x.Nombre, x.Precio })
                 })
                .Take(3);

            foreach (var categoria in resultado)
            {
                Console.WriteLine($"\n {categoria.Categoria} - Promedio: ${categoria.Promedio:F2}");
                foreach (var producto in categoria.Productos)
                {
                    Console.WriteLine($"   🔹 {producto.Nombre} - ${producto.Precio}");
                }
            }

        }

    }
}
