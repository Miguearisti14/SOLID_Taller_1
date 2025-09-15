using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class AireAcondicionado : VehiculoDecorator
    {
        public AireAcondicionado(IVehiculo vehiculo) : base(vehiculo) { }

        public override string Descripcion()
        {
            return base.Descripcion() + " + Aire Acondicionado";
        }

    }

}
