using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class LujoHandler : ServicioHandler
    {
        public override IVehiculo Handle(string tipoServicio, IVehiculo vehiculo, object data)
        {
            if (tipoServicio == "Lujo")
            {
                string lujo = data as string;
                if (lujo == "Aire")
                    vehiculo = new AireAcondicionado(vehiculo);
                else if (lujo == "Sonido")
                    vehiculo = new SonidoEstereo(vehiculo);

                Console.WriteLine($"Se aplicó el lujo: {lujo}");
                return vehiculo;
            }

            return base.Handle(tipoServicio, vehiculo, data);
        }
    }

}
