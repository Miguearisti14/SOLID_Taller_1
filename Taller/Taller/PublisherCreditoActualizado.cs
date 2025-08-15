namespace Taller
{
    public class PublisherCreditoActualizado : IEventoFactura
    {
        internal delegate void delegado_credito();
        internal event delegado_credito evt_credito;

        public void informar_pago(Cliente cliente)
        {
            try
            {
                if (evt_credito != null)
                {
                    evt_credito();
                    Console.WriteLine("El credito fue procesado con exito, Revise su nuevo valor de credito");

                }
                else Console.WriteLine("Llamada no valida al método");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error en el evento Informar Factura Cancelada" + ex);
                throw;
            }
        }
    }
}
