using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
            ImprimirItems(queries.TresPrimerosLibrosDeLaColeccion());



            // Impresion 

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
                foreach(var item in listadelibros)
                {
                    Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
                }

            }






        }

    }
}
