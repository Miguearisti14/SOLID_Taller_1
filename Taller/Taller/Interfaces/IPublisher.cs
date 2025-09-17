using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller
{
    public interface IPublisher<T>
    {
        void AgregarObservador(IObservador<T> obs);
        void QuitarObservador(IObservador<T> obs);
        void Notificar(T sujeto, string mensaje);
    }

}
