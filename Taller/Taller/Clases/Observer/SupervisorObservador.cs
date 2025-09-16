using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class SupervisorObservador : IObservador
    {
        public void Actualizar(string mensaje)
        {
            Console.WriteLine($"[Supervisor] Se recibió actualización: {mensaje}");
        }
    }
}
