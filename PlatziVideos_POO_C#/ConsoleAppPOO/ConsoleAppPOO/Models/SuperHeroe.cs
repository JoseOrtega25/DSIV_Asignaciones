using ConsoleAppPOO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPOO.Models
{
    public class SuperHeroe : Heroe, ISuperHeroe
    {
        // Propiedades públicas del superhéroe
        private string _Nombre;
        public int Id { get; set; }
        public override string Nombre
        {
            get
            {
                return _Nombre;

            }

            set
            {
                _Nombre = value.Trim();
            }
        }
        public string IdentidadSecreta { get; set; }
        public string Ciudad { get; set; }
        public List<SuperPoder> SuperPoderes { get; set; }
        public bool PuedeVolar { get; set; }

        public SuperHeroe() { }

        public SuperHeroe(int id, string nombre, string identidadSecreta, string ciudad, bool puedeVolar, List<SuperPoder> superPoderes)
        {
            Id = id;
            Nombre = nombre;
            IdentidadSecreta = identidadSecreta;
            Ciudad = ciudad;
            PuedeVolar = puedeVolar;
            SuperPoderes = superPoderes;
        }

        public override string SalvarLaTierra()
        {
            return $"El superhéroe {IdentidadSecreta} ha salvado la Tierra!";
        }

        public void UsarSuperpoder()
        {
        }

        private void MetodoPrivado()
        {
        }

        internal void MetodoInterno()
        {
        }

        protected internal void MetodoProtegidoInterno()
        {
        }

        public override string SalvarElMundo()
        {
            return $"El superhéroe {Nombre} está salvando el mundo!";
        }
    }
}

