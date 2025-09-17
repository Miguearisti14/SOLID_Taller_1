namespace Taller
{
    public class PagoContado : IGestorPago
    {

        public float CancelarPago(float pago, Cliente cliente, ReparacionBase reparacion)
        {
            try
            {
                var rn = new RNPagoContado();
                float resultado = rn.ProcesarPago(pago, cliente, reparacion);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en CancelarPago: " + ex.Message);
            }
        }
    }
}
