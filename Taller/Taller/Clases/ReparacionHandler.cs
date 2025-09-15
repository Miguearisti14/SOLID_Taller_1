using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Clases;

namespace Taller
{
    public class ReparacionHandler : ServicioHandler
    {
        public override IVehiculo Handle(string tipoServicio, IVehiculo vehiculo, object data)
        {
            if (tipoServicio == "Mecanica" || tipoServicio == "Electrica")
            {
                ReparacionFactory factory = tipoServicio == "Mecanica"
                    ? new ReparacionMecanicaFactory()
                    : new ReparacionElectricaFactory();

                var info = (Tuple<IGestorRepuesto, List<Mecanico>>)data;
                var reparacion = factory.CrearReparacion(vehiculo, info.Item1, info.Item2);
                reparacion.FinalizarReparacion();

                Console.WriteLine($"Reparación {tipoServicio} realizada al vehículo {vehiculo.Descripcion()}");

                return vehiculo; // 🔑 Se devuelve el mismo vehículo (sin decorador)
            }

            // Si no maneja este tipo, pasa al siguiente handler
            return base.Handle(tipoServicio, vehiculo, data);
        }
    }

}
