using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Clases;
using Taller.Eventos;

namespace Taller
{
    public class ReparacionElectrico : ReparacionBase
    {
        private const float PrecioBase = 150;

        public ReparacionElectrico(Carro carro, IGestorRepuestos gestorRepuestos, List<Mecanico> mecanicos)
            : base(carro, gestorRepuestos, mecanicos) { }

        public override float ValorTotal => PrecioBase + (float)gestorRepuestos.CalcularTotalRepuestos();

        public override void FinalizarReparacion()
        {
            ReparacionCompletada = true;
            publicadorFinal = new Publisher_ReparacionFinalizada();
            publicadorFinal.Informar_Reparacion_Finalizada(true);
        }

        public static bool ReparacionCompletada { get; private set; }
    }
}
