namespace Taller
{
    public class Moto : Vehiculo
    {
        public IMotor Motor { get; }
        public int Cilindraje { get; }
        public string Transmision { get; }

        public Moto(string placa, string marca, int modelo, Cliente dueno, IMotor motor, int cilindraje, string transmision)
            : base(placa, marca, modelo, dueno)
        {
            Motor = motor;
            Cilindraje = cilindraje;
            Transmision = transmision;

        }

        public override string Descripcion()
        {
            return $"Moto {Marca} con placa {Placa}";
        }
    }

}
