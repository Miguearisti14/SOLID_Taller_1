using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Taller
{
    public class Hibrido : IMotor
    {
        public int NumeroBateria { get; }
        public static bool Reparacion { get; private set; }


        public void Encender()
        {
            Console.WriteLine("Motor híbrido encendido.");
        }

    }
}
