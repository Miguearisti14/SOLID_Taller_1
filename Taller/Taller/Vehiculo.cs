using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public abstract class Vehiculo
    {
        protected string Placa { get; }
        protected string Marca { get; }
        protected int Modelo { get; }
        protected Cliente Dueno { get; }

        protected Vehiculo(string placa, string marca, int modelo, Cliente dueno)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Dueno = dueno;

        }
    }
}
