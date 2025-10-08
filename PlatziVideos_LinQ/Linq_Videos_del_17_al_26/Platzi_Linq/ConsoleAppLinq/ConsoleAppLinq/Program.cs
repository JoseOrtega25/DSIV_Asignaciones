// See https://aka.ms/new-console-template for more information
using ConsoleAppLinq;

LinqQueries queries = new LinqQueries();

//1.
//Toda la colleccion
//ImprimirValores(queries.TodaLaColeccion());

//2. 
//Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesDel2000 ());

//3.
// Imprimir los libros con mas de 250 paginas  y que en el titulo contengan la palabra Action o in
//ImprimirValores(queries.LibrosMas250Paginas());

//4.Cuarto reto con linq
// Todos los libros tienen status
//Console.WriteLine($" Todos los libros tiene sstatus?{queries.TodosLosLibrosTienenStatus()} ");

//5. 
// Preguntamos si algun libro de la colleccion fue publicado en 2005
//Console.WriteLine($"¡Agun libro fue publicado en 2005 ? {queries.AlgunLibroPublicadoEn2005()}");

//6.
//  libros de la colleccion de categoria Python
//ImprimirValores(queries.CategoriaPython());

//7.
// Libros de la categoria de Java ordenados por nombre
//ImprimirValores(queries.LibrosdeJavaPorNombreAscendente());

//8.
// Libros con mas de 450 paginas en orden descendente 
//ImprimirValores(queries.LibrosConMasDe450PaginasEnOrdenDescendente());

//9. 
// Tres libros mas recientes de la categoria Java
//ImprimirValores(queries.Libros3RecientesJava());

//10
// Tercer y cuarto libro con mas de 400 paginas
//ImprimirValores(queries.LibrosConMasDe400Paginas());

//11.
//Tres primeros libros haciendo  select de ciertos valores
//ImprimirItems(queries.TresPrimerosLibrosDeLaColeccion());

//12 LongCount o Count
//Cantidad de libros que tiene entre 200 y 500 paginas con (LongCount o Count)
//Console.WriteLine("Cantidad de libros que tienen entre 200 y 500 paginas: " + queries.CantidadDeLibrosEntre200y500Pag());

//13 Operadores Min y Max
//Utilizando el operador min retornar la menor fecha de pubicacion de un libro
Console.WriteLine("Fecha de publicacion menor de un libro: " + queries.FechaDePublicacionMenor());

//14 Operador Max
//Retorna el valor maximo de paginas que tiene un libro de la coleccion
Console.WriteLine("Mayor cantidad de paginas de un libro de la coleccion: " + queries.NumeroDePaginasLibroMayor());

//15 MinBy
// Retorna el libro que tenga la menor cantidad de pagina pero mayor a 0
//var libroMenorPag = queries.LibroConMenorNumeroDePagina();
//Console.WriteLine($"{libroMenorPag.Title} - {libroMenorPag.PageCount}");

// 16 MaxBy
// Libro con fecha de publicacion mas reciente 
//var libroMenorPag2 = queries.LibroConFechaPublicacionMasReciente();
//Console.WriteLine($"{libroMenorPag2.Title} - {libroMenorPag2.PublishedDate.ToShortDateString()}");


// 17 Operador Sum
// Retornar la cantidad de paginas de todos los libros con paginas entre 0 y 500
//Console.WriteLine("Suma total de paginas de libros que tienen entre 0 y 500 paginas:  "+queries.SumaDeTodasLasPaginasLibirsEntr200y500());

// 18 Operador Aggregate
//Retorna el titulo de los libros que tienen fecha de publicacion posterior a 2015
//Console.WriteLine(queries.LibrosDespuesDel2015Concatenados());

// 18 Average
//Retornar el promedio de caracteres que tiene los títulos de la colección
//Console.WriteLine("Promedio de caracteres de los titulos de los libros de la coleccion: "+queries.PromedioCaracteresTitulo());

//19 GroupBy
// Retornar todos los libros publicados a partir del 2000 y agruparlos por año
//ImprimirGrupo(queries.LibrosDespuesDel2000AgrupadosPorAno());

// Impresion 
// 20 Lookup 
// Retorna un diccionario que permita consultar los libros de acuerdo a la letra con la que inicia el título del libro
var diccionarioLookup = queries.DiccionariosDeLibrosporLetra();
ImprimirDiccionario(diccionarioLookup, 'S');

// 21 Join
// Obten una collecion que tenga todos los libors con mas de 50 paginas
// y otra coleccion que contenga los libros publicados despues del 2005 y
// retorna los libros que esten en ambas colecciones

ImprimirValores(queries.LibrosDespuesDel2005conmasde500Pags());



void ImprimirDiccionario(ILookup <char, Book> ListadeLibros, char letra)
{

        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");

        foreach (var item in ListadeLibros[letra])
        {
            Console.WriteLine("{0, -60}, {1, 15}, {2, 15} ", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
 }

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N.Paginas", "Fecha publicacion");

        foreach (var item in grupo)
        {
            Console.WriteLine("{0, -60}, {1, 15}, {2, 15} ", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}


void ImprimirItems(IEnumerable<Item> items)
{
    foreach (var item in items)
    {
        Console.WriteLine($"{item.Title} - {item.PageCount} páginas");
    }
}


void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N.paginas", "Fecha publicacion");
    foreach (var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }

}
