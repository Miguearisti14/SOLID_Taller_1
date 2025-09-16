namespace Taller
{
    public class ReparacionElectrico : ReparacionBase
    {
        private const float PrecioBase = 150;

        public ReparacionElectrico(IVehiculo vehiculo, IGestorRepuesto gestorRepuestos, List<Mecanico> mecanicos)
            : base(vehiculo, gestorRepuestos, mecanicos) { }

        public override float ValorTotal => PrecioBase + (float)gestorRepuestos.CalcularTotalRepuestos();

        public static bool ReparacionCompletada { get; private set; }
    }
}
