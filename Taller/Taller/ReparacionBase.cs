namespace Taller
{
    public abstract class ReparacionBase : IReparacion
    {
        public abstract float ValorTotal { get; }

        public Carro Carro { get; protected set; }
        public DateTime Fecha { get; protected set; }
        public List<Mecanico> Mecanicos { get; protected set; }
        public string ResultadoPuestaPunto { get; set; }

        protected IGestorRepuesto gestorRepuestos;
        protected PublisherReparacionFinalizada publicadorFinal;
        protected PublisherVehiculoIngresado publicadorIngreso;

        protected ReparacionBase(Carro carro, IGestorRepuesto gestorRepuestos, List<Mecanico> mecanicos)
        {
            Carro = carro;
            this.gestorRepuestos = gestorRepuestos;
            Mecanicos = mecanicos;
            Fecha = DateTime.Now;

            publicadorIngreso = new PublisherVehiculoIngresado();
            publicadorIngreso.evt_ingreso += EventHandler;
            publicadorIngreso.informarReparacion(true);
        }

        public virtual void IniciarReparacion() { }
        public abstract void FinalizarReparacion();

        protected virtual void EventHandler() { }
    }
}
