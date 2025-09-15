using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller;

namespace Taller
{
    public class LujoAireAcondicionadoStrategy : IServicioStrategy
    {
        public IVehiculo Ejecutar(IVehiculo vehiculo, object data)
        {
            vehiculo = new AireAcondicionado(vehiculo);

            Console.WriteLine($"Vehículo actualizado con lujo: Aire Acondicionado");

            return vehiculo;
        }
    }
}
