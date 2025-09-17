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
        private readonly PagoService PagoService;

        public PagoCreditoCommand(IGestorPago gestor, Cliente cliente, ReparacionBase reparacion, float monto, PagoService pagoService)
        {
            Gestor = gestor;
            Cliente = cliente;
            Reparacion = reparacion;
            Monto = monto;
            PagoService = pagoService;
        }

        public void Execute()
        {
            
            PagoService.ProcesarPago(Gestor, Monto, Cliente, Reparacion);
        }

    }
}
