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
            float totalAPagar = Reparacion.Valor + costo_repuesto;
            float excedente = pago - totalAPagar;

            try
            {

                // Aplicar saldo a favor existente
                if (cliente.Saldo > 0)
                {
                    cliente.Saldo += pago;
                    Console.WriteLine($"Usando saldo a favor: {cliente.Saldo}");
                    totalAPagar -= cliente.Saldo;
                    if (totalAPagar < 0) totalAPagar = 0; // por si el saldo cubre todo
                    cliente.Saldo = Math.Max(cliente.Saldo - (Reparacion.Valor + costo_repuesto), 0);
                    Console.WriteLine($"Saldo a favor restante: {cliente.Saldo}");

                }


                if (pago < totalAPagar)
                {
                    cliente.Saldopendiente = totalAPagar - pago;
                    Console.WriteLine($"El pago no se pudo realizar completamente. Monto pendiente: {cliente.Saldopendiente}");
                    return cliente.Saldopendiente;
                }
                else
                {
                    cliente.Saldopendiente = 0;  

                    if (excedente > 0)
                    {
                        cliente.Saldo += excedente; // saldo a favor
                        Console.WriteLine($"Pago exitoso. Saldo a favor del cliente: {cliente.Saldo}");
                    }
                    else
                    {
                        Console.WriteLine("Pago exitoso. No hay saldo pendiente.");
                    }

                    publisher_cancelada = new Publisher_FacturaCanceladaSalida();
                    publisher_cancelada.evt_factura_salida += EventHandler;
                    publisher_cancelada.Informar_Cancelamiento_Factura_Salida(pago, cliente);

                    return cliente.Saldo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el método Cancelar_Pago: " + ex.Message);
            }
        }
    }
}
