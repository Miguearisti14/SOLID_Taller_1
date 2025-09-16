using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller;

namespace Taller.Clases
{
    public class ReparacionMecanicaStrategy : IServicioStrategy
    {
        public IVehiculo Ejecutar(IVehiculo vehiculo, object data)
        {
            var info = (Tuple<IGestorRepuesto, List<Mecanico>>)data;
            var reparacion = new ReparacionMecanica(vehiculo, info.Item1, info.Item2);
           
        
            return vehiculo;
        }

    }
}
