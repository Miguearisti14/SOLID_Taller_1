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

                // Usar la RN para actualizar saldos
                var rn = new RNPagoCredito();
                float saldoPendiente = rn.ProcesarPago(pago, cliente, reparacion);

                // Disparar eventos según el resultado
                if (saldoPendiente == 0)
                {
                    publisher_cancelada = new PublisherFacturaCanceladaSalida();
                    publisher_cancelada.evt_factura_salida += EventHandler;
                    publisher_cancelada.informar_pago(cliente);

                    Console.WriteLine($"Pago total recibido. Saldo a favor: {cliente.Saldo}");
                }
                else
                {
                    publisher_credito = new PublisherCreditoActualizado();
                    publisher_credito.evt_credito += EventHandler;
                    publisher_credito.informar_pago(cliente);

                    Console.WriteLine($"Pago parcial recibido. Saldo pendiente: {saldoPendiente}");
                }

                return saldoPendiente;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en CancelarPago: " + ex.Message);
            }
        }
    }
}
