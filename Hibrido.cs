using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_taller_automovil.Clases
{
    public class Hibrido : Carro
    {
        private int numero_bateria;
        private static bool reparacion;

        public Hibrido(string placa, string marca, string modelo, int año, string dueño, int numero_bateria) 
            : base(placa, marca, modelo, año, dueño)
        {
            this.Numero_bateria = numero_bateria;
        }

        public Hibrido(string placa, string marca, string modelo, int año, string dueño)
            : base(placa, marca, modelo, año, dueño)
        {
        }

        public int Numero_bateria { get => numero_bateria; set => numero_bateria = value; }
        public static bool Reparacion { get => reparacion; set => reparacion = value; }

        public override string Reparacion_Puesto_Punto()
        {
            Reparacion = true;
            return $"Se lubrico el motor generador eléctrico, tambien se cambian los frenos y se calibran, recarga de las baterías, se examina el desgaste de las llantas, se examina amortiguación y se cambia el líquido de frenos.";
        }
    }
}
