using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class ClienteObservador : IObservador<ReparacionBase>, IObservador<PagoService>
    {
        private readonly string nombre;

        public ClienteObservador(string nombre) => this.nombre = nombre;

        public void Actualizar(ReparacionBase sujeto, string mensaje)
        {
            Console.WriteLine($"Cliente {nombre} notificado: {mensaje}");
        }

        public void Actualizar(PagoService sujeto, string mensaje)
        {
            Console.WriteLine($"Cliente {nombre} notificado (pago): {mensaje}");
        }
    }
}
