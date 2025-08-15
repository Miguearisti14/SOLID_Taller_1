using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class RNPagoCredito
    {
        public float ProcesarPago(float pago, Cliente cliente, ReparacionBase reparacion)
        {
            // Si no hay deuda registrada, usar el valor total de la reparación
            if (cliente.Saldopendiente <= 0)
            {
                cliente.Saldopendiente = reparacion.ValorTotal;
            }

            // Pago total o mayor al saldo pendiente
            if (pago >= cliente.Saldopendiente)
            {
                float excedente = pago - cliente.Saldopendiente;
                cliente.Saldopendiente = 0;

                // Registrar saldo a favor si sobra dinero
                if (excedente > 0)
                {
                    cliente.Saldo += excedente;
                }
            }
            else
            {
                // Pago parcial
                cliente.Saldopendiente -= pago;
            }

            return cliente.Saldopendiente; // Devuelve cuánto queda pendiente
        }
    }
}
