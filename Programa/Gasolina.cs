using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_taller_automovil.Clases
{
    public class Gasolina : Carro
    {
        private int numero_cilindro;
        private static bool reparacion;

        public Gasolina(string placa, string marca, string modelo, int año, string dueño, int numero_cilindro) 
            : base(placa, marca, modelo, año, dueño)
        {
            this.Numero_cilindro = numero_cilindro;
        }

        public Gasolina(string placa, string marca, string modelo, int año, string dueño)
            : base(placa, marca, modelo, año, dueño)
        {
        }

        public int Numero_cilindro { get => numero_cilindro; set => numero_cilindro = value; }
        public static bool Reparacion { get => reparacion; set => reparacion = value; }

        public override string Reparacion_Puesto_Punto()
        {
            Reparacion = true;
            return $"Se cambiaron las correas, las bujías, se drena el radiador y se le ajustan los inyectores. ";
        }
    }
}
