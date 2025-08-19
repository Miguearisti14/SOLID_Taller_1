using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class RNPagoContado
    {
        public float ProcesarPago(float pago, Cliente cliente, ReparacionBase reparacion)
        {
            float totalAPagar = reparacion.ValorTotal;
            float excedente = pago - totalAPagar;

            // Usar saldo a favor primero
            if (cliente.Saldo > 0)
            {
                Console.WriteLine($"Usando saldo a favor: {cliente.Saldo}");
                totalAPagar -= cliente.Saldo;
                if (totalAPagar < 0) totalAPagar = 0;
                cliente.Saldo = Math.Max(cliente.Saldo - reparacion.ValorTotal, 0);
                Console.WriteLine($"Saldo a favor restante: {cliente.Saldo}");
            }

            // Si el pago no alcanza
            if (pago < totalAPagar)
            {
                cliente.Saldopendiente = totalAPagar - pago;
                Console.WriteLine($"Pago incompleto. Monto pendiente: {cliente.Saldopendiente}");
                return cliente.Saldopendiente;
            }
            else
            {
                cliente.Saldopendiente = 0;

                if (excedente > 0)
                {
                    cliente.Saldo += excedente;
                    Console.WriteLine($"Pago exitoso. Saldo a favor del cliente: {cliente.Saldo}");
                }
                else
                {
                    Console.WriteLine("Pago exitoso. No hay saldo pendiente.");
                }

                return cliente.Saldo;
            }
        }
    }
}
