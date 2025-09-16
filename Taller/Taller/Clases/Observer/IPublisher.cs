using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public interface IPublisher
    {
        void AgregarObservador(IObservador observador);
        void QuitarObservador(IObservador observador);
        void Notificar(string mensaje);
    }

}
