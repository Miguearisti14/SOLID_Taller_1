namespace Taller
{
    public class PagoCredito : IGestorPago
    {

        internal static PublisherFacturaCanceladaSalida publisher_cancelada;
        internal static PublisherCreditoActualizado publisher_credito;
        internal static void EventHandler()
        {

        }

        public float CancelarPago(float pago, Cliente cliente, ReparacionBase reparacion)
        {
            try
            {
                // Asegurar que la deuda ya está registrada (solo si es estrictamente necesario)
                if (cliente.Saldopendiente <= 0)
                {
                    cliente.Saldopendiente = reparacion.ValorTotal;
                }

                // Si paga más de lo que debe
                if (pago >= cliente.Saldopendiente)
                {
                    float excedente = pago - cliente.Saldopendiente;
                    cliente.Saldopendiente = 0;

                    // Guardar saldo a favor si hay exceso
                    if (excedente > 0)
                    {
                        cliente.Saldo += excedente;
                        Console.WriteLine($"Pago total recibido. Excedente registrado como saldo a favor: {cliente.Saldo}");
                    }
                    else
                    {
                        Console.WriteLine("Pago total recibido. No hay saldo pendiente.");
                    }

                    // Evento de factura pagada
                    publisher_cancelada = new PublisherFacturaCanceladaSalida();
                    publisher_cancelada.evt_factura_salida += EventHandler;
                    publisher_cancelada.informar_pago(cliente);
                }
                else
                {
                    // Pago parcial
                    cliente.Saldopendiente -= pago;

                    publisher_credito = new PublisherCreditoActualizado();
                    publisher_credito.evt_credito += EventHandler;
                    publisher_credito.informar_pago(cliente);

                    Console.WriteLine($"Pago parcial recibido. Saldo pendiente: {cliente.Saldopendiente}");
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
