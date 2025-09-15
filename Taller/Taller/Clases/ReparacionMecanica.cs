namespace Taller
{
    public class ReparacionMecanica : ReparacionBase
    {
        private const float PrecioBase = 130;

        public ReparacionMecanica(Vehiculo vehiculo, IGestorRepuesto gestorRepuestos, List<Mecanico> mecanicos)
            : base(vehiculo, gestorRepuestos, mecanicos) { }

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
