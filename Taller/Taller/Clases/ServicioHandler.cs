using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public abstract class ServicioHandler : IServicioHandler
    {
        private IServicioHandler Next;

        public IServicioHandler SetNext(IServicioHandler next)
        {
            Next = next;
            return next;
        }

        public virtual IVehiculo Handle(string tipoServicio, IVehiculo vehiculo, object data)
        {
            if (Next != null)
                return Next.Handle(tipoServicio, vehiculo, data);

            return vehiculo;
        }
    }

}
