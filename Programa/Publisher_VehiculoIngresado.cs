using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using b_taller_automovil.Clases;

namespace b_taller_automovil.Eventos
{
    public class Publisher_VehiculoIngresado
    {
        internal delegate void delegado_ingreso();
        internal event delegado_ingreso evt_ingreso;

        public void Informar_Ingreso_Vehiculo(bool carro)
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
