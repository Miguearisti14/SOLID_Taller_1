using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class ReparacionMecanicaFactory : ReparacionFactory
    {
        internal override IReparacion CrearReparacion(IVehiculo vehiculo, IGestorRepuesto gestorRepuestos, List<Mecanico> mecanicos)
        {
            return new ReparacionMecanica(vehiculo, gestorRepuestos, mecanicos);
        }
    }
}
