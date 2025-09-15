using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Clases;
using Taller;

namespace Taller
{
    public class ServicioHandler
    {
        private readonly Dictionary<string, IServicioStrategy> estrategias;

        public ServicioHandler()
        {
            estrategias = new Dictionary<string, IServicioStrategy>
        {
            { "Mecanica", new ReparacionMecanicaStrategy() },
            { "Electrico", new ReparacionElectricaStrategy() },
            { "Sonido", new LujoSonidoEstereoStrategy() },
            { "Aire", new LujoAireAcondicionadoStrategy() }
        };
        }

        public IVehiculo Handle(string tipoServicio, IVehiculo vehiculo, object data)
        {
            if (estrategias.TryGetValue(tipoServicio, out var estrategia))
            {
                IVehiculo vehiculoDecorado = estrategia.Ejecutar(vehiculo, data);

                return vehiculoDecorado;
            }
            else
            {
                Console.WriteLine($"Servicio no soportado: {tipoServicio}");

                return vehiculo;
            }

            
        }
    }

}
