using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Clases;

namespace Taller.Eventos
{
    public class Publisher_ReparacionFinalizada
    {
        internal delegate void delegado_reparacion();
        internal event delegado_reparacion evt_reparacion;

        public void Informar_Reparacion_Finalizada(bool final)
        {
            try
            {
                if (evt_reparacion != null)
                {
                    evt_reparacion();
                    if (final == true)
                    {
                        Console.WriteLine("La reparacion del auto se ha hecho de manera exitosa, puede pasar a cancelar el costo de reparacion");
                    }
                    else
                    {
                        Console.WriteLine("La reparacion del auto no ha terminado aun, no se puede cancelar el costo de reparacion");
                    }

                }
                else Console.WriteLine("Llamada no valida al método");

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error en el evento Informar Reparacion Finalizada" + ex);
                throw;
            }

        }
    }
}
