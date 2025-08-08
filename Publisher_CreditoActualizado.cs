using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using b_taller_automovil.Clases;

namespace b_taller_automovil.Eventos
{
    public class Publisher_CreditoActualizado
    {
        internal delegate void delegado_credito();
        internal event delegado_credito evt_credito;

        public void Informar_Credito_Actualizado()
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
