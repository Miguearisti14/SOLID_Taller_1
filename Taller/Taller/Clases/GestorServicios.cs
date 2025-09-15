using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class GestorServicios
    {
        private readonly IServicioHandler Handler;

        public GestorServicios()
        {
            // Se arma la cadena
            var reparacionHandler = new ReparacionHandler();
            var lujoHandler = new LujoHandler();

            reparacionHandler.SetNext(lujoHandler);
            Handler = reparacionHandler;
        }

        public IVehiculo AtenderSolicitud(string tipoServicio, IVehiculo vehiculo, object data)
        {
            return Handler.Handle(tipoServicio, vehiculo, data);
        }
    }

}
