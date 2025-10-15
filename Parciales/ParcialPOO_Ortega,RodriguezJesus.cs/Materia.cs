using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPOO_Ortega_RodriguezJesus.cs
{
    public class Materia : MostrarInterfaz
    {
        private string nombre;
        private string codigo;
        private int creditos;
        private int cupos;
        private int inscritos;

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string Codigo
        {
            get => codigo;
            set => codigo = value;
        }

        public int Creditos
        {
            get => creditos;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Los créditos deben ser mayores que 0.");
                creditos = value;
            }
        }

        public int Cupos
        {
            get => cupos;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Los cupos no pueden ser negativos.");
                cupos = value;
            }
        }

        public int Inscritos
        {
            get => inscritos;
            set
            {
                if (value < 0 || value > Cupos)
                    throw new ArgumentException("Inscritos debe ser >= 0 y <= Cupos.");
                inscritos = value;
            }
        }

        public Materia(string nombre, string codigo, int creditos, int cupos = 0, int inscritos = 0)
        {
            Nombre = nombre;
            Codigo = codigo;
            Creditos = creditos;
            Cupos = cupos;
            Inscritos = inscritos;
        }

        // Método aritmético
        public int CalcularCargaSemanal(int horasPorCredito)
        {
            return Creditos * horasPorCredito;
        }

        // Mostrar datos
        public void MostrarDatos()
        {
            Console.WriteLine($"Materia: {Nombre} ({Codigo}) - Créditos: {Creditos}, Cupos: {Cupos}, Inscritos: {Inscritos}");
        }
    }
}
