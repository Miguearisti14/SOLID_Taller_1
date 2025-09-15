namespace Taller
{
    public class Carro : Vehiculo
    {
        public IMotor Motor { get; }
        public int Nro_Puertas { get; }
        public string Transmision { get; }

        public Carro(string placa, string marca, int modelo, Cliente dueno, IMotor motor, int nro_Puertas, string transmision)
            : base(placa, marca, modelo, dueno)
        {
            Motor = motor;
            Nro_Puertas = nro_Puertas;
            Transmision = transmision;

        }

        public override string Descripcion()
        {
            return $"Carro {Marca} con placa {Placa}";
        }
    }

}
