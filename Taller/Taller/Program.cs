using System;
using System.Collections.Generic;

namespace Taller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"/////////////////////////////////////////////////////////////////////////////////////");

            // 1️⃣ Crear cliente
            Cliente cliente1 = new Cliente(1, "Juan Pérez", "3001234567", credito: false);

            // 2️⃣ Crear motor y carro
            IMotor motorElectrico = new Electrico();
            Carro carro1 = new Carro(
                placa: "ABC123",
                marca: "Tesla",
                modelo: 2022,
                dueno: cliente1,
                motor: motorElectrico,
                nro_Puertas: 4,
                transmision: "Automática"
            );

            // 3️⃣ Crear mecánicos
            List<Mecanico> mecanicos = new List<Mecanico>
            {
                new Mecanico(101, "Pedro Gómez", "3015551234", "Eléctrico"),
                new Mecanico(102, "Luis Martínez", "3024445678", "Suspensión")
            };

            // 4️⃣ Crear repuestos
            List<Repuesto> listaRepuestos = new List<Repuesto>
            {
                new Repuesto("Batería", "ProveedorX", DateTime.Now, 2000m),
                new Repuesto("Cable de carga", "ProveedorY", DateTime.Now, 500m)
            };

            IGestorRepuesto gestorRepuesto = new GestorRepuesto(listaRepuestos);

            // 5️⃣ Crear reparación
            ReparacionBase reparacion = new ReparacionElectrico(carro1, gestorRepuesto, mecanicos);

            // Iniciar reparación (opcional si no tiene lógica especial)
            reparacion.IniciarReparacion();

            // Finalizar reparación
            reparacion.FinalizarReparacion();

            Console.WriteLine($"Valor total de la reparación: {reparacion.ValorTotal}");

            // 6️⃣ Realizar pago al contado
            IGestorPago pagoContado = new PagoContado();
            Console.WriteLine("\nCliente intenta pagar...");

            pagoContado.CancelarPago(
                pago: 3000,   // monto que entrega el cliente
                cliente: cliente1,
                reparacion: reparacion
            );

            Console.WriteLine($"\nSaldo a favor final del cliente: {cliente1.Saldo}");
            Console.WriteLine($"Saldo pendiente final del cliente: {cliente1.Saldopendiente}");
            Console.WriteLine($"\n/////////////////////////////////////////////////////////////////////////////////////");

            // 1️⃣ Crear cliente con opción de crédito
            Cliente cliente2 = new Cliente(2, "Juan Pérez", "3001234567", credito: true);

            // 2️⃣ Crear motor y carro
            IMotor motorGasolina = new Gasolina();
            Carro carro2 = new Carro(
                placa: "XYZ987",
                marca: "Toyota",
                modelo: 2021,
                dueno: cliente2,
                motor: motorGasolina,
                nro_Puertas: 4,
                transmision: "Manual"
            );

            // 3️⃣ Crear mecánicos
            List<Mecanico> mecanicos2 = new List<Mecanico>
            {
                new Mecanico(201, "Pedro Gómez", "3015551234", "Motor"),
                new Mecanico(202, "Luis Martínez", "3024445678", "Transmisión")
            };

            // 4️⃣ Crear repuestos
            List<Repuesto> listaRepuestos2 = new List<Repuesto>
            {
                new Repuesto("Filtro de aceite", "ProveedorX", DateTime.Now, 100m),
                new Repuesto("Bujías", "ProveedorY", DateTime.Now, 200m)
            };

            IGestorRepuesto gestorRepuesto2 = new GestorRepuesto(listaRepuestos2);

            // 5️⃣ Crear reparación
            ReparacionBase reparacion2 = new ReparacionMecanica(carro2, gestorRepuesto2, mecanicos2);

            reparacion2.IniciarReparacion();
            reparacion2.FinalizarReparacion();

            Console.WriteLine($"Valor total de la reparación: {reparacion2.ValorTotal}");

            // 6️⃣ Pago a crédito
            IGestorPago pagoCredito = new PagoCredito();
            Console.WriteLine("\nCliente paga a crédito...");

            pagoCredito.CancelarPago(
                pago: 150,   
                cliente: cliente2,
                reparacion: reparacion2
            );

            Console.WriteLine($"\nSaldo a favor del cliente: {cliente2.Saldo}");
            Console.WriteLine($"Saldo pendiente del cliente: {cliente2.Saldopendiente}");
        
    }
    }
}
