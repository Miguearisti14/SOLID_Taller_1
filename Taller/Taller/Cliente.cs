namespace Taller
{
    public class Cliente : Persona
    {
        public bool credito;
        public float saldo;
        public static float saldopendiente;

        public Cliente(int id, string nombre, string telefono, bool credito) : base(id, nombre, telefono)
        {
            Credito = credito;
            Saldo = 0;
        }


        public bool Credito { get => credito; set => credito = value; }
        public float Saldo { get => saldo; set => saldo = value; }
        public float Saldopendiente { get => saldopendiente; set => saldopendiente = value; }
    }
}
