namespace Taller
{
    public interface IGestorPago
    {
        float CancelarPago(float pago, Cliente cliente, ReparacionBase reparacion);

    }
}
