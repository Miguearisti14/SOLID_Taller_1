using System;
using System.Collections.Generic;

namespace Taller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("/////////////////////// TALLER ///////////////////////");

            // 1️⃣ Crear cliente y vehículo
            Cliente cliente = new Cliente(1, "Juan Pérez", "3001234567", credito: false);
            IMotor motor = new Gasolina();
            IVehiculo carro = new Carro(
                placa: "AAA111",
                marca: "Mazda",
                modelo: 2022,
                dueno: cliente,
                nro_Puertas: 4,
                transmision: "Manual",
                motor: motor
            );

            // 2️⃣ Crear mecánicos
            var mecanicos = new List<Mecanico>
        {
            new Mecanico(1, "Pedro Gómez", "3011111111", "Motor"),
            new Mecanico(2, "Luis Martínez", "3022222222", "Transmisión")
        };

            // 3️⃣ Crear repuestos
            var repuestos = new List<Repuesto>
        {
            new Repuesto("Filtro aceite", "ProveedorX", DateTime.Now, 100m),
            new Repuesto("Bujías", "ProveedorY", DateTime.Now, 200m)
        };
            IGestorRepuesto gestorRepuesto = new GestorRepuesto(repuestos);

            // 4️⃣ Crear reparación mecánica
            ReparacionBase reparacion = new ReparacionMecanica(carro, gestorRepuesto, mecanicos);

            Console.WriteLine($"Estado inicial de la reparación: {reparacion.EstadoActual()}");

            // 5️⃣ Simular proceso de la reparación usando STATE
            reparacion.AvanzarEstado(); // Pendiente → En Progreso
            Console.WriteLine($"Estado actual: {reparacion.EstadoActual()}");

            reparacion.AvanzarEstado(); // En Progreso → Completada
            Console.WriteLine($"Estado actual: {reparacion.EstadoActual()}");

            reparacion.AvanzarEstado(); // Completada → No avanza
            Console.WriteLine($"Estado actual: {reparacion.EstadoActual()}");

            // 6️⃣ Mostrar descripción final del vehículo
            Console.WriteLine($"\nVehículo final: {carro.Descripcion()}");

            Console.WriteLine("//////////////////////////////////////////////////////////");
        }
    }

}


