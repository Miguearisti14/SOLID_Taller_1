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

            // Fachada
            var gestor = new GestorServicios();

            // Solicitudes
            Console.WriteLine("\n---- REPARACIÓN MECÁNICA ----");
            carro = gestor.AtenderSolicitud("Mecanica", carro, Tuple.Create(gestorRepuesto, mecanicos));

            Console.WriteLine("\n---- LUJO (Aire acondicionado) ----");
            carro = gestor.AtenderSolicitud("Lujo", carro, "Aire");

            Console.WriteLine("\n---- LUJO (Sonido estéreo) ----");
            carro = gestor.AtenderSolicitud("Lujo", carro, "Sonido");

            // Resultado final
            Console.WriteLine($"\nVehículo final con servicios: {carro.Descripcion()}");

            Console.WriteLine("\n//////////////////////////////////////////////////////////");
        }
    }
    }


