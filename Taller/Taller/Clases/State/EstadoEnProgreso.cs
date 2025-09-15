using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class EstadoEnProgreso : IEstadoReparacion
    {
        public void Avanzar(ReparacionBase reparacion)
        {
            Console.WriteLine("La reparación fue completada.");
            reparacion.SetEstado(new EstadoCompletada());
        }

        public string GetEstado() => "En Progreso";
    }
}
