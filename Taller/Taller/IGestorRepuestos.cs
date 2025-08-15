using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Clases;

namespace Taller
{
    public interface IGestorRepuestos
    {
        void AgregarRepuesto(Repuesto repuesto);
        void QuitarRepuesto(string nombre);
        decimal CalcularTotalRepuestos();
    
    }
}
