using System;
using System.Collections.Generic;

namespace Taller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente(1, "Juan Pérez", "3001234567", credito: false);
            IMotor motor = new Gasolina();
            IVehiculo carro = new Carro("AAA111", "Mazda", 2022, cliente, motor, 4, "Manual");

            var mecanicos = new List<Mecanico> { new Mecanico(1, "Pedro", "3011111111", "Motor") };
            var repuestos = new List<Repuesto> { new Repuesto("Filtro aceite", "ProveedorX", DateTime.Now, 100m) };
            IGestorRepuesto gestor = new GestorRepuesto(repuestos);

            ReparacionBase reparacion = new ReparacionMecanica(carro, gestor, mecanicos);

            // 🔔 Agregar observadores
            reparacion.AgregarObservador(new ClienteObservador(cliente.Nombre));
            reparacion.AgregarObservador(new SupervisorObservador());

            // ⚙️ Simular flujo
            reparacion.AvanzarEstado();
            reparacion.AvanzarEstado();
            reparacion.AvanzarEstado(); // no avanza más, pero igual notifica
        }


    }

}


