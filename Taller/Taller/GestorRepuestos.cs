using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Clases;

namespace Taller
{
    public class GestorRepuestos : IGestorRepuestos
    {
        private readonly List<Repuesto> _repuestos;

        public GestorRepuestos(List<Repuesto> repuestosIniciales = null)
        {
            _repuestos = repuestosIniciales ?? new List<Repuesto>();
        }

        public void AgregarRepuesto(Repuesto repuesto)
        {
            _repuestos.Add(repuesto);
        }

        public void QuitarRepuesto(string nombre)
        {
            var repuesto = _repuestos.FirstOrDefault(r => r.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (repuesto != null)
                _repuestos.Remove(repuesto);
        }

        public decimal CalcularTotalRepuestos()
        {
            return _repuestos.Sum(r => r.Precio);
        }

        public List<Repuesto> Repuestos { get; private set; }
    }
}
