using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class SonidoEstereo : VehiculoDecorator
    {
        public SonidoEstereo(IVehiculo vehiculo) : base(vehiculo) { }

        public override string Descripcion()
        {
            return base.Descripcion() + " + Sonido Estéreo";
        }

    }
}
