using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller;

namespace Taller
{
    public class LujoSonidoEstereoStrategy : IServicioStrategy
    {
        public IVehiculo Ejecutar(IVehiculo vehiculo, object data)
        {
            vehiculo = new SonidoEstereo(vehiculo);

            Console.WriteLine($"Vehículo actualizado con lujo: Sonido Estereo");

            return vehiculo;
        }
    }
}
