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
    public class Pago_Contado : IGestor_Pago
    {
        internal static Publisher_FacturaCanceladaSalida publisher_cancelada;
        internal static Publisher_CreditoActualizado publisher_credito;
        internal static void EventHandler()
        {

        }

        public float Cancelar_Pago(float pago, Cliente cliente, float costo_repuesto)
        {

            try
            {
                if (pago < (Reparacion.Valor + costo_repuesto))
                {
                    cliente.Saldopendiente = (Reparacion.Valor + costo_repuesto) - pago;
                    Console.WriteLine($"El pago no se pudo realizar completamente. Monto pendiente: {cliente.Saldopendiente}");
                    return cliente.Saldopendiente; // Ajusta el saldo pendiente

                }
                else
                {
                    cliente.Saldopendiente = Math.Max(cliente.Saldo - pago, 0); // Deja el saldo en cero o resta lo necesario

                    // Emite el evento de factura pagada si es exitoso
                    publisher_cancelada = new Publisher_FacturaCanceladaSalida();
                    publisher_cancelada.evt_factura_salida += EventHandler;
                    publisher_cancelada.Informar_Cancelamiento_Factura_Salida(pago, cliente);

                    Console.WriteLine($"El pago fue ejecutado de manera exitosa. Saldo restante: {cliente.Saldo}");
                    return cliente.Saldo;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error en el metodo Cancelar Pago" + ex.Message);
            }

        }
    }
}
