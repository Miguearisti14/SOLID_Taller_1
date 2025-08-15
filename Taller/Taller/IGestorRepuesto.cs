namespace Taller
{
    public interface IGestorRepuesto
    {
        void AgregarRepuesto(Repuesto repuesto);
        void QuitarRepuesto(string nombre);
        decimal CalcularTotalRepuestos();
    
    }
}
