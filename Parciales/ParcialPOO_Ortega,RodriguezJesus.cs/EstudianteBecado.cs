using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPOO_Ortega_RodriguezJesus.cs
{
    public class EstudianteBecado : Estudiante
    {
        private double porcentajeBeca;

        public double PorcentajeBeca
        {
            get => porcentajeBeca;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("El porcentaje de beca debe estar entre 0 y 100.");
                porcentajeBeca = value;
            }
        }

        public EstudianteBecado(string nombre, string id, string carrera, double porcentajeBeca)
            : base(nombre, id, carrera)
        {
            PorcentajeBeca = porcentajeBeca;
        }

        //Metodo aritmético
        public double CalcularMatriculaConDescuento(double matriculaBase)
        {
            return matriculaBase * (1 - (PorcentajeBeca / 100.0));
        }

        // Override del método MostrarDatos
        public override void MostrarDatos()
        {
            base.MostrarDatos();
            Console.WriteLine($"Beca: {PorcentajeBeca}%");
        }
    }
}
