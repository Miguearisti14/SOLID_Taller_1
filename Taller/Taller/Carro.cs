using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Eventos;
using Taller.Interfaces;

namespace Taller
{
    public abstract class Carro : IReparacion
    {
        private string placa;
        private string marca;
        private string modelo;
        private int año;
        private string dueño;


        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int Año { get => año; set => año = value; }
        public string Dueño { get => dueño; set => dueño = value; }

        public Carro(string placa, string marca, string modelo, int año, string dueño)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Año = año;
            Dueño = dueño;
        }

        public abstract string Reparacion_Puesto_Punto();
    }
}
