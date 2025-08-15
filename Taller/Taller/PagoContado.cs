namespace Taller
{
    public class PagoContado : IGestorPago
    {
        internal static PublisherFacturaCanceladaSalida publisher_cancelada;
        internal static PublisherCreditoActualizado publisher_credito;
        internal static void EventHandler()
        {

        }

        public float CancelarPago(float pago, Cliente cliente, ReparacionBase reparacion)
        {
            float totalAPagar = reparacion.ValorTotal; // ya incluye repuesto y mano de obra
            float excedente = pago - totalAPagar;

            try
            {
                // Usar saldo a favor primero
                if (cliente.Saldo > 0)
                {
                    Console.WriteLine($"Usando saldo a favor: {cliente.Saldo}");
                    totalAPagar -= cliente.Saldo;
                    if (totalAPagar < 0) totalAPagar = 0;
                    cliente.Saldo = Math.Max(cliente.Saldo - reparacion.ValorTotal, 0);
                    Console.WriteLine($"Saldo a favor restante: {cliente.Saldo}");
                }

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

                    publisher_cancelada = new PublisherFacturaCanceladaSalida();
                    publisher_cancelada.evt_factura_salida += EventHandler;
                    publisher_cancelada.informar_pago(cliente);

                    return cliente.Saldo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en CancelarPago: " + ex.Message);
            }
        }
    }
}
