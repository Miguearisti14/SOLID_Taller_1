using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class EstadoPendiente : IEstadoReparacion
    {
        public void Avanzar(ReparacionBase reparacion)
        {
            Console.WriteLine("La reparación ha comenzado.");
            reparacion.SetEstado(new EstadoEnProgreso());
        }

        public string GetEstado() => "Pendiente";
    }
}
