namespace Taller
{
    public class PagoCredito : IGestorPago
    {

        public float CancelarPago(float pago, Cliente cliente, ReparacionBase reparacion)
        {
            try
            {

                // Usar la RN para actualizar saldos
                var rn = new RNPagoCredito();
                float saldoPendiente = rn.ProcesarPago(pago, cliente, reparacion);


                return saldoPendiente;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en CancelarPago: " + ex.Message);
            }
        }
    }
}
