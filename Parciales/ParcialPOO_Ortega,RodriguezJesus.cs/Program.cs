// See https://aka.ms/new-console-template for more information
using ParcialPOO_Ortega_RodriguezJesus.cs;

public class Program
{
    public static void Main()
    {
        //materias genericas
        Materia m1 = new Materia("Programacion", "INF101", 3, 30, 25);
        Materia m2 = new Materia("Matematica", "MAT201", 4, 25, 20);
        Materia m3 = new Materia("Bases de Datos", "INF301", 3, 20, 18);

        //estudiantes genericos
        Estudiante e1 = new Estudiante("Carlos Pérez", "E001", "Ingenieria en Sistemas");
        Estudiante e2 = new Estudiante("Ana López", "E002", "Ingenieria en Sistemas");
        EstudianteBecado eb1 = new EstudianteBecado("Luis Torres", "E003", "Ingenieria en Sistemas", 50);

        //calificaciones genericas
        Calificacion c1 = new Calificacion(e1, m1, 90);
        Calificacion c2 = new Calificacion(e2, m2, 80);
        Calificacion c3 = new Calificacion(eb1, m3, 95);

        //vinculacion
        e1.Calificaciones.Add(c1);
        e2.Calificaciones.Add(c2);
        eb1.Calificaciones.Add(c3);

        //polimorfismo
        List<MostrarInterfaz> items = new List<MostrarInterfaz>
        {
            e1, e2, eb1,
            m1, m2, m3,
            c1, c2, c3
        };

        Console.WriteLine("=== Datos con polimorfismo ===\n");
        foreach (MostrarInterfaz i in items)
        {
            i.MostrarDatos();
        }

        //mostrar resultados y calculos
        Console.WriteLine("RESULTADOS DE OPERACIONES\n");

        double promedioE1 = e1.CalcularPromedio();
        Console.WriteLine($"Promedio de {e1.Nombre}: {promedioE1:F2}");

        int cargaM1 = m1.CalcularCargaSemanal(3);
        Console.WriteLine($"Carga semanal de {m1.Nombre}: {cargaM1} horas");

        double puntosC1 = c1.CalcularPuntos();
        Console.WriteLine($"Puntos obtenidos por {e1.Nombre} en {m1.Nombre}: {puntosC1:F2}");

        double matriculaDescuento = eb1.CalcularMatriculaConDescuento(1200);
        Console.WriteLine($"Matricula con descuento ({eb1.PorcentajeBeca}%): {matriculaDescuento:F2}");
    }
}