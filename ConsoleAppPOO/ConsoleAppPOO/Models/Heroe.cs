using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPOO.Models
{
    public abstract class Heroe
    {
        public abstract string Nombre { get; set; }

        public abstract string SalvarElMundo();


        public virtual string SalvarLaTierra()
        {
            return $"El héroe {Nombre} ha salvado la Tierra.";
        }
    }
}
