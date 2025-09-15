namespace Taller
{
    public class PagoContado : IGestorPago
    {
        internal static PublisherFacturaCanceladaSalida publisher_cancelada;
        internal static void EventHandler() { }

        public float CancelarPago(float pago, Cliente cliente, ReparacionBase reparacion)
        {
            try
            {
                var rn = new RNPagoContado();
                float resultado = rn.ProcesarPago(pago, cliente, reparacion);

                if (cliente.Saldopendiente == 0)
                {
                    publisher_cancelada = new PublisherFacturaCanceladaSalida();
                    publisher_cancelada.evt_factura_salida += EventHandler;
                    publisher_cancelada.informar_pago(cliente);
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en CancelarPago: " + ex.Message);
            }
        }
    }
}
