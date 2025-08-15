using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Taller.Clases
{
    public class Gasolina : IMotor
    {
        public int NumeroCilindros { get; }
        public static bool Reparacion { get; private set; }

        public void Encender()
        {
            Console.WriteLine("Motor a gasolina encendido.");
        }

    }
}
