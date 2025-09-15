namespace Taller
{
    public abstract class ReparacionBase : IReparacion
    {
        public abstract float ValorTotal { get; }
        protected IEstadoReparacion estado;
        public IVehiculo Vehiculo{ get; protected set; }
        public DateTime Fecha { get; protected set; }
        public List<Mecanico> Mecanicos { get; protected set; }
        public string ResultadoPuestaPunto { get; set; }

        protected IGestorRepuesto gestorRepuestos;
        protected PublisherReparacionFinalizada publicadorFinal;
        protected PublisherVehiculoIngresado publicadorIngreso;

        protected ReparacionBase(IVehiculo vehiculo, IGestorRepuesto gestorRepuestos, List<Mecanico> mecanicos)
        {
            Vehiculo = vehiculo;
            this.gestorRepuestos = gestorRepuestos;
            Mecanicos = mecanicos;
            Fecha = DateTime.Now;
            estado = new EstadoPendiente();

            publicadorIngreso = new PublisherVehiculoIngresado();
            publicadorIngreso.evt_ingreso += EventHandler;
            publicadorIngreso.informarReparacion(true);
        }

        public virtual void IniciarReparacion() { }
        public abstract void FinalizarReparacion();
        public void SetEstado(IEstadoReparacion nuevoEstado)
        {
            estado = nuevoEstado;
        }
        public string EstadoActual()
        {
            return estado.GetEstado();
        }
        public void AvanzarEstado()
        {
            estado.Avanzar(this);
        }

        protected virtual void EventHandler() { }
    }
}
