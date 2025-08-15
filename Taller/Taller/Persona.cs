using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public abstract class Persona
    {
        public int id;
        public string nombre;
        public string telefono;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public Persona(int id, string nombre, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }
    }
}
