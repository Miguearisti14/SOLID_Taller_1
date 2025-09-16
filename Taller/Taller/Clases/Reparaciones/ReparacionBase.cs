namespace Taller
{
    public abstract class ReparacionBase : IReparacion, IPublisher
    {
        public abstract float ValorTotal { get; }
        public IEstadoReparacion estado { get; protected set; }
        public IVehiculo Vehiculo{ get; protected set; }
        public DateTime Fecha { get; protected set; }
        public List<Mecanico> Mecanicos { get; protected set; }
        public string ResultadoPuestaPunto { get; set; }
        private readonly List<IObservador> observadores = new();
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
            Notificar($"Reparación del {Vehiculo.Descripcion()} ahora está en estado: {estado.GetEstado()}");

        }
        public void AgregarObservador(IObservador observador) => observadores.Add(observador);
        public void QuitarObservador(IObservador observador) => observadores.Remove(observador);
        public void Notificar(string mensaje)
        {
            foreach (var obs in observadores)
            {
                obs.Actualizar(mensaje);
            }
        }

    }
}
