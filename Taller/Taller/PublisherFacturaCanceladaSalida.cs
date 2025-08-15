namespace Taller
{
    public class PublisherFacturaCanceladaSalida : IEventoFactura
    {
        internal delegate void delegado_factura_salida();
        internal event delegado_factura_salida evt_factura_salida;

        public void informar_pago(Cliente cliente)
        {
            try
            {
                if (evt_factura_salida != null)
                {
                    evt_factura_salida();
                    if (cliente.Saldopendiente == 0)
                    {
                        Console.WriteLine("El pago fue procesado con exito, puede pasar a retirar su vehiculo");
                    }
                    else
                    {
                        Console.WriteLine("El pago no fue procesado, revise que la cantidad es el costo de la reparacion o intente de nuevo");
                    }

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
