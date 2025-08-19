using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class Mecanico : Persona
    {
        private string especialidad;

        public Mecanico(int id, string nombre, string telefono, string especialidad) : base(id, nombre, telefono)
        {
            this.Especialidad = especialidad;
        }

        public string Especialidad { get => especialidad; set => especialidad = value; }
    }
}
