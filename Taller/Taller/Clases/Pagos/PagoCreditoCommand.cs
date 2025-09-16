using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class PagoCreditoCommand : ICommand
    {
        private readonly IGestorPago Gestor;
        private readonly Cliente Cliente;
        private readonly ReparacionBase Reparacion;
        private readonly float Monto;

        public PagoCreditoCommand(IGestorPago gestor, Cliente cliente, ReparacionBase reparacion, float monto)
        {
            Gestor = gestor;
            Cliente = cliente;
            Reparacion = reparacion;
            Monto = monto;
        }

        public void Execute()
        {
            Console.WriteLine("=== Ejecutando pago a CRÉDITO ===");
            Gestor.CancelarPago(Monto, Cliente, Reparacion);
        }

    }
}
