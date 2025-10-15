using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPOO_Ortega_RodriguezJesus.cs
{
    public class Estudiante : MostrarInterfaz
    {
        private string nombre;
        private string id;
        private string carrera;
        private List<Calificacion> calificaciones;

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string Carrera
        {
            get => carrera;
            set => carrera = value;
        }

        public List<Calificacion> Calificaciones
        {
            get => calificaciones;
        }

        public Estudiante(string nombre, string id, string carrera)
        {
            Nombre = nombre;
            Id = id;
            Carrera = carrera;
            calificaciones = new List<Calificacion>();
        }

        // Método aritmético
        public double CalcularPromedio()
        {
            if (calificaciones.Count == 0) return 0;

            double totalPonderado = 0;
            double totalCreditos = 0;

            foreach (var c in calificaciones)
            {
                totalPonderado += c.Nota * c.Materia.Creditos;
                totalCreditos += c.Materia.Creditos;
            }

            return totalPonderado / totalCreditos;
        }

        // Mostrar datos
        public virtual void MostrarDatos()
        {
            Console.WriteLine($"Estudiante: {Nombre} (ID: {Id}) - Carrera: {Carrera}");
            Console.WriteLine($"Promedio: {CalcularPromedio():F2}\n");
        }
    }
}
