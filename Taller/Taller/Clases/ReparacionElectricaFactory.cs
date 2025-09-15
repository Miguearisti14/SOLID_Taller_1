using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Clases
{
    public class ReparacionElectricaFactory : ReparacionFactory
    {
        internal override IReparacion CrearReparacion(Vehiculo vehiculo, IGestorRepuesto gestorRepuestos, List<Mecanico> mecanicos)
        {
            return new ReparacionElectrico(vehiculo, gestorRepuestos, mecanicos);
        }
    }
}
