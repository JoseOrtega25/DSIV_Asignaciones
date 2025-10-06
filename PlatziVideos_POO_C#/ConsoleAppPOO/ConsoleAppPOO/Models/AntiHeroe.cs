using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleAppPOO.Models
{
    internal class AntiHeroe : SuperHeroe
    {
        public string RealizarAccionDeAntiheroe(string accion)
        {
            return $"El antiheroe {Nombre} ha realizado {accion}";
        }
    }
}
