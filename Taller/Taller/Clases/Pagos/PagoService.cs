using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class PagoService : IPublisher<PagoService>
    {
        private readonly List<IObservador<PagoService>> observadores = new();

        public void AgregarObservador(IObservador<PagoService> obs) => observadores.Add(obs);
        public void QuitarObservador(IObservador<PagoService> obs) => observadores.Remove(obs);

        public void Notificar(PagoService sujeto, string mensaje)
        {
            foreach (var obs in observadores)
                obs.Actualizar(sujeto, mensaje);
        }

        public void ProcesarPago(IGestorPago gestorPago, float monto, Cliente cliente, ReparacionBase reparacion)
        {
            float saldoPendiente = gestorPago.CancelarPago(monto, cliente, reparacion);

            if (saldoPendiente == 0)
                Notificar(this, $"Pago completo registrado para {cliente.Nombre}");
            else
                Notificar(this, $"Pago parcial registrado para {cliente.Nombre}. Pendiente {saldoPendiente}");
            
            if (cliente.Saldo > 0)
            {
                Console.WriteLine($"Cliente {cliente.Nombre} tiene un saldo a favor de: {cliente.Saldo}");
            }
        }
    }
}
