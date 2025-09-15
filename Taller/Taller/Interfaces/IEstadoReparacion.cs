using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public interface IEstadoReparacion
    {
        void Avanzar(ReparacionBase reparacion);
        string GetEstado();
    }
}
