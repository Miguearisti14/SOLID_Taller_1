using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class ClienteObservador : IObservador
    {
        private string Nombre;
        public ClienteObservador(string nombre) { Nombre = nombre; }

        public void Actualizar(string mensaje)
        {
            Console.WriteLine($"[Cliente {Nombre}] Notificación: {mensaje}");
        }
    }
}
