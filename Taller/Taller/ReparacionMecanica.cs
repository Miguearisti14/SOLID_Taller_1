namespace Taller
{
    public class ReparacionMecanica : ReparacionBase
    {
        private const float PrecioBase = 130;

        public ReparacionMecanica(Carro carro, IGestorRepuesto gestorRepuestos, List<Mecanico> mecanicos)
            : base(carro, gestorRepuestos, mecanicos) { }

        public override float ValorTotal => PrecioBase + (float)gestorRepuestos.CalcularTotalRepuestos();

        public override void FinalizarReparacion()
        {
            ReparacionCompletada = true;
            publicadorFinal = new PublisherReparacionFinalizada();
            publicadorFinal.evt_reparacion += EventHandler;
            publicadorFinal.informarReparacion(true);
        }

        public static bool ReparacionCompletada { get; private set; }
    }
}
