using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class EstadoCompletada : IEstadoReparacion
    {
        public void Avanzar(ReparacionBase reparacion)
        {
            Console.WriteLine("La reparación ya está completada. No se puede avanzar más.");
        }

        public string GetEstado() => "Completada";
    }
}
