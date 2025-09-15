using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public abstract class ReparacionFactory
    {
        internal abstract IReparacion CrearReparacion(IVehiculo vehiculo, IGestorRepuesto gestorRepuestos, List<Mecanico> mecanicos);
    }
}
