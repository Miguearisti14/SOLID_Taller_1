using System;
using Taller.Clases;

namespace Taller
{
    public interface IGestor_Pago
    {
        float Cancelar_Pago(float pago, Cliente cliente, float costo_repuesto);

    }
}
