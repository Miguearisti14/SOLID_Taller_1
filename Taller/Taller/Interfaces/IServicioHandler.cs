using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public interface IServicioHandler
    {
        IServicioHandler SetNext(IServicioHandler next);
        IVehiculo Handle(string tipoServicio, IVehiculo vehiculo, object data);
    }

}
