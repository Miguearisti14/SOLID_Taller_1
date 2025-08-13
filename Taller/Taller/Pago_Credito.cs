using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Eventos;
using Taller.Interfaces;
using Taller.Clases;
namespace Taller
{
    public class Pago_Credito : IGestor_Pago
    {

        internal static Publisher_FacturaCanceladaSalida publisher_cancelada;
        internal static Publisher_CreditoActualizado publisher_credito;
        internal static void EventHandler()
        {

        }

        public float Cancelar_Pago(float pago, Cliente cliente, float costoRepuesto)
        {
            try
            {
                float totalDeuda = Reparacion.Valor + costoRepuesto;

                // Si no tiene deuda registrada, la calculamos
                if (cliente.Saldopendiente <= 0)
                {
                    cliente.Saldopendiente = totalDeuda;
                }

                // Resta el pago al saldo pendiente
                cliente.Saldopendiente -= pago;

                if (cliente.Saldopendiente > 0)
                {
                    // Evento de crédito actualizado (no se terminó de pagar)
                    publisher_credito = new Publisher_CreditoActualizado();
                    publisher_credito.evt_credito += EventHandler;
                    publisher_credito.Informar_Credito_Actualizado();

                    Console.WriteLine($"Pago parcial recibido. Saldo pendiente: {cliente.Saldopendiente}");

                 
                }
                else
                {
                    // Deuda cancelada
                    cliente.Saldopendiente = 0;

                    // Evento de factura pagada
                    publisher_cancelada = new Publisher_FacturaCanceladaSalida();
                    publisher_cancelada.evt_factura_salida += EventHandler;
                    publisher_cancelada.Informar_Cancelamiento_Factura_Salida(pago, cliente);

                    Console.WriteLine($"Pago total recibido. La deuda ha sido cancelada.");
                }

                return cliente.Saldopendiente;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el método Cancelar_Pago_Credito: " + ex.Message);
            }
        }

    }
}
