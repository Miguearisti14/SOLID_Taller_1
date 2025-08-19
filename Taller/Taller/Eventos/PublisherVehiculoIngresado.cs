namespace Taller
{
    public class PublisherVehiculoIngresado : IEventoReparacion
    {
        internal delegate void delegado_ingreso();
        internal event delegado_ingreso evt_ingreso;

        public void informarReparacion(bool carro)
        {
            try
            {
                if (evt_ingreso != null)
                {
                    evt_ingreso();
                    if (carro == true)
                    {
                        Console.WriteLine("El ingreso del Carro se hizo de manera exitosa, Puede seguir con la reparacion");
                    }
                    else
                        Console.WriteLine("El carro no se ha ingresado, o no hay ningun carro que ingresar");

                }
                else Console.WriteLine("Llamada no valida al método");
               
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error en el evento Informar Ingreso Vehiculo" + ex);
                throw;
            }

        }
    }
}
