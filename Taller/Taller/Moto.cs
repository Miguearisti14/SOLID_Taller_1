using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Eventos;
using Taller.Interfaces;

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
    }

}
