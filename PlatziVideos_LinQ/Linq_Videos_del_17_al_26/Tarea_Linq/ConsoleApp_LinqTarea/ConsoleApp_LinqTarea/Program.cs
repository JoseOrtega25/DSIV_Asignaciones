// See https://aka.ms/new-console-template for more information
using ConsoleApp_LinqTarea;

LinqQueries queries = new LinqQueries();

// 1 .Join/LeftJoion
var resultados = queries.NombreProductoCategoria();
foreach (var item in resultados)
{
    Console.WriteLine($"{item.NombreCategoria} - {item.NombreProducto}");
}

// 2  GroupBy
var ResumenProductos = queries.ResumenPorCategoria();

foreach (var item in ResumenProductos)
{
    Console.WriteLine($"Categoria: {item.Categoria} | Canridad: {item.CantidadProductos} |" +
        $"Promedio: {item.PrecioPromedio:c} | Máx: {item.PrecioMaximo:c} Min: {item.PrecioMinimo:c}");
}

//3  Subconsultas
var subConsultas = queries.ProductosMasCarosDeCadaCategoria();
foreach (dynamic item in subConsultas)
{
    Console.WriteLine($"Categoría: {item.Categoria}");
    Console.WriteLine($"Producto: {item.Nombre}");
    Console.WriteLine($"Precio: {item.Precio}");
    Console.WriteLine(new string('-', 30));
}

// 4 Uso del Aggregate para concatenarn nombre de productos en una variable string
Console.WriteLine(queries.NombreDeProductos());

/*5️ SELECTMANY(Aplanamiento de colecciones)
Reto:
Simula que cada categoría contiene una lista de productos.
Usa SelectMany para aplanar todas esas listas en una única colección con los nombres de categorías y productos.*/

// Lista de categorías con productos
var categorias = new List<Categoria2>()
        {
            new Categoria2
            {
                Nombre = "Electrónica",
                Productos = new List<Producto2>
                {
                    new Producto2 { Nombre = "Televisor", Precio = 500 },
                    new Producto2 { Nombre = "Celular", Precio = 300 }
                }
            },
            new Categoria2
            {
                Nombre = "Hogar",
                Productos = new List<Producto2>
                {
                    new Producto2 { Nombre = "Licuadora", Precio = 100 },
                    new Producto2 { Nombre = "Plancha", Precio = 80 }
                }
            }
        };

var productosAplanados = categorias
    .SelectMany(c => c.Productos, (categoria, producto) => new
    {
        Categoria = categoria.Nombre,
        Producto = producto.Nombre,
        Precio = producto.Precio
    });

foreach (var item in productosAplanados)
{
    Console.WriteLine($"{item.Categoria} - {item.Producto} - ${item.Precio}");
}


//Reto 6 Combina varios operadores LINQ para obtener las 3 categorías con mayor precio promedio,
// y dentro de cada una, muestra sus productos ordenados por precio descendente.
queries.CategoriasConMayorPrecioPromedio();









