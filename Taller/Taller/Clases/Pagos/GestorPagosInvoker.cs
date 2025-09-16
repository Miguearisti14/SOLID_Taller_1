using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public class GestorPagosInvoker
    {
        private readonly Stack<ICommand> Historial = new Stack<ICommand>();

        public void EjecutarPago(ICommand comando)
        {
            comando.Execute();
            Historial.Push(comando);
        }

    }
}
