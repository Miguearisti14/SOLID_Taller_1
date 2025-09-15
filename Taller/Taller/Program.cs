using System;
using System.Collections.Generic;

namespace Taller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("/////////////////////// TALLER ///////////////////////");

            // 1️⃣ Cliente y vehículo
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

            // 2️⃣ Mecánicos
            var mecanicos = new List<Mecanico>
        {
            new Mecanico(1, "Pedro Gómez", "3011111111", "Motor"),
            new Mecanico(2, "Luis Martínez", "3022222222", "Eléctrico")
        };

            // 3️⃣ Repuestos
            var repuestos = new List<Repuesto>
        {
            new Repuesto("Bujía", "ProveedorX", DateTime.Now, 150m),
            new Repuesto("Filtro aceite", "ProveedorY", DateTime.Now, 100m)
        };
            IGestorRepuesto gestorRepuesto = new GestorRepuesto(repuestos);

            var servicioHandler = new ServicioHandler();

            // Reparación mecánica
            carro = servicioHandler.Handle("Mecanica", carro, Tuple.Create(gestorRepuesto, mecanicos));

            // Lujo: aire acondicionado
            carro = servicioHandler.Handle("Aire", carro, null);
            
            // Lujo: sonido estéreo
            carro = servicioHandler.Handle("Sonido", carro, null);

            Console.WriteLine($"\n Vehículo final: {carro.Descripcion()}");
        }
    }
    }


