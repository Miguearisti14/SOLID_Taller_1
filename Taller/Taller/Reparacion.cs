using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Clases;
using Taller.Eventos;

namespace Taller.Clases
{
    public class Reparacion
    {
        private const float valor = 1200000;

        public Carro carro;
        private DateTime fecha;
        private List<Repuesto> l_repuesto;
        private List<Mecanico> l_mecanicos;
        private static bool ingreso = false;


        public static Publisher_ReparacionFinalizada publicador;
        public Publisher_VehiculoIngresado publicador_2;
        internal static void EventHandler()
        {

        }

        public Reparacion(Carro carro, List<Repuesto> l_repuesto, List<Mecanico> l_mecanicos)
        {
            Carro = carro;
            Fecha = DateTime.Now;
            L_repuesto = l_repuesto;
            L_mecanicos = l_mecanicos;

            publicador_2 = new Publisher_VehiculoIngresado();
            //suscribir el metodo al evento
            publicador_2.evt_ingreso += EventHandler;
            //invocar evento
            publicador_2.Informar_Ingreso_Vehiculo(ingreso = true);

        }

        public static void Finalizar_Reparacion()
        {
            try
            {
                if (Gasolina.Reparacion == true ||
                    Hibrido.Reparacion == true ||
                    Electrico.Reparacion == true)

                {
                    publicador = new Publisher_ReparacionFinalizada();
                    //suscribir el metodo al evento
                    publicador.evt_reparacion += EventHandler;
                    //invocar evento
                    publicador.Informar_Reparacion_Finalizada(true);
                }
                else
                {
                    publicador = new Publisher_ReparacionFinalizada();
                    //suscribir el metodo al evento
                    publicador.evt_reparacion += EventHandler;
                    //invocar evento
                    publicador.Informar_Reparacion_Finalizada(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error en el metodo Finalizar Reparacion");
            }

        }

        public static float Valor { get => valor; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Carro Carro { get => carro; set => carro = value; }
        public List<Repuesto> L_repuesto { get => l_repuesto; set => l_repuesto = value; }
        public List<Mecanico> L_mecanicos { get => l_mecanicos; set => l_mecanicos = value; }
        public string ResultadoPuestaPunto { get; set; }
    }
}
