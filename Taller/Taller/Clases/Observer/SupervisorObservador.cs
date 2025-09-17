using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class SupervisorObservador : IObservador<ReparacionBase>, IObservador<PagoService>
    {
        public void Actualizar(ReparacionBase sujeto, string mensaje)
        {
            Console.WriteLine($"🛠️ Supervisor recibe alerta de reparación: {mensaje}");
        }

        public void Actualizar(PagoService sujeto, string mensaje)
        {
            Console.WriteLine($"📊 Supervisor recibe alerta de pago: {mensaje}");
        }
    }
}
