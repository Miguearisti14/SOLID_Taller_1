namespace Taller
{
    public class ReparacionMecanica : ReparacionBase
    {
        private const float PrecioBase = 130;

        public ReparacionMecanica(IVehiculo vehiculo, IGestorRepuesto gestorRepuestos, List<Mecanico> mecanicos)
            : base(vehiculo, gestorRepuestos, mecanicos) { }

        public override float ValorTotal => PrecioBase + (float)gestorRepuestos.CalcularTotalRepuestos();

        public static bool ReparacionCompletada { get; private set; }
    }
}
