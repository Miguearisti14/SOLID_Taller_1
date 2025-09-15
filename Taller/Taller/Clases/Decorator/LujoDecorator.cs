using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public abstract class LujoDecorator : IVehiculo
    {
        protected IVehiculo vehiculo;

        protected LujoDecorator(IVehiculo vehiculo)
        {
            this.vehiculo = vehiculo;
        }

        public virtual string Descripcion()
        {
            return vehiculo.Descripcion();
        }

    }

}
