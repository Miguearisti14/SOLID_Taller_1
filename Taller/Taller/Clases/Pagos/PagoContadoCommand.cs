using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class PagoContadoCommand : ICommand
    {
        private readonly IGestorPago Gestor;
        private readonly Cliente Cliente;
        private readonly ReparacionBase Reparacion;
        private readonly float Monto;

        public PagoContadoCommand(IGestorPago gestor, Cliente cliente, ReparacionBase reparacion, float monto)
        {
            Gestor = gestor;
            Cliente = cliente;
            Reparacion = reparacion;
            Monto = monto;
        }

        public void Execute()
        {
            Console.WriteLine("=== Ejecutando pago al CONTADO ===");
            Gestor.CancelarPago(Monto, Cliente, Reparacion);
        }

    }
}
