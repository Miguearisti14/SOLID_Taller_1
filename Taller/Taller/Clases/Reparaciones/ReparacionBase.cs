namespace Taller
{
    public abstract class ReparacionBase : IReparacion, IPublisher<ReparacionBase>
    {
        public abstract float ValorTotal { get; }
        public IEstadoReparacion estado { get; protected set; }
        public IVehiculo Vehiculo{ get; protected set; }
        public DateTime Fecha { get; protected set; }
        public List<Mecanico> Mecanicos { get; protected set; }
        public string ResultadoPuestaPunto { get; set; }
        private readonly List<IObservador<ReparacionBase>> observadores = new();
        protected IGestorRepuesto gestorRepuestos;


        protected ReparacionBase(IVehiculo vehiculo, IGestorRepuesto gestorRepuestos, List<Mecanico> mecanicos)
        {
            Vehiculo = vehiculo;
            this.gestorRepuestos = gestorRepuestos;
            Mecanicos = mecanicos;
            Fecha = DateTime.Now;
            estado = new EstadoPendiente();

        }
        
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
            Notificar(this, $"Estado cambiado a: {estado.GetType().Name}");

        }
        public void AgregarObservador(IObservador<ReparacionBase> obs) => observadores.Add(obs);
        public void QuitarObservador(IObservador<ReparacionBase> obs) => observadores.Remove(obs);
        public void Notificar(ReparacionBase sujeto, string mensaje)
        {
            foreach (var obs in observadores)
                obs.Actualizar(sujeto, mensaje);
        }

    }
}
