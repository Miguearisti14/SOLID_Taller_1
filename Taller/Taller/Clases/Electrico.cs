using System;

namespace Taller
{
    public class Electrico : IMotor
    {
        public int Autonomia { get; }
        public static bool Reparacion { get; private set; }

  
        public void Encender()
        {
            Console.WriteLine("Motor eléctrico encendido en silencio.");
        }

    }
}
