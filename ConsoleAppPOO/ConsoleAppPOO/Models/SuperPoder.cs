using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPOO.Models
{
    
        public class SuperPoder
        {
            public string Nombre { get; set; }
            public string Descripcion { get; set; }

            public NivelPoder Nivel { get; set; }

            public SuperPoder() { }

            public SuperPoder(string nombre, string descripcion, NivelPoder nivel)
            {
                Nombre = nombre;
                Descripcion = descripcion;
                Nivel = nivel;
            }
            public enum NivelPoder
            {
                NivelUno,
                NivelDos,
                NivelTres
            }
        }

    }
