using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using b_taller_automovil.Eventos;
using b_taller_automovil.Interfaces;

namespace b_taller_automovil.Clases
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
            this.Placa = placa;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Año = año;
            this.Dueño = dueño;
        }

        public abstract string Reparacion_Puesto_Punto();
    }
}
