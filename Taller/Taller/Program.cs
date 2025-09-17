using System;
using System.Collections.Generic;

namespace Taller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // =============================
            // 🔹 1. Crear cliente y vehículo
            // =============================
            Cliente cliente = new Cliente(1, "Juan Pérez", "3001234567", credito: false);
            IMotor motor = new Gasolina();
            IVehiculo carro = new Carro("AAA111", "Mazda", 2022, cliente, motor, 4, "Manual");

            // =============================
            // 🔹 2. Crear mecánicos y repuestos
            // =============================
            var mecanicos = new List<Mecanico> { new Mecanico(1, "Pedro", "3011111111", "Motor") };
            var repuestos = new List<Repuesto> { new Repuesto("Filtro aceite", "ProveedorX", DateTime.Now, 100m) };
            IGestorRepuesto gestor = new GestorRepuesto(repuestos);

            // =============================
            // 🔹 3. Crear reparación (State + Observer)
            // =============================
            ReparacionBase reparacion = new ReparacionMecanica(carro, gestor, mecanicos);

            // Agregar observadores de reparación
            reparacion.AgregarObservador(new ClienteObservador(cliente.Nombre));
            reparacion.AgregarObservador(new SupervisorObservador());

            // Simular flujo de reparación
            Console.WriteLine("\n=== 🔧 Flujo de reparación ===");
            reparacion.AvanzarEstado();
            reparacion.AvanzarEstado();
            reparacion.AvanzarEstado(); // No avanza más, pero igual notifica

            // =============================
            // 🔹 4. Etapa de pagos (Command + Observer)
            // =============================
            Console.WriteLine("\n=== 💰 Etapa de pagos ===");

            // Crear servicio de pagos y agregar observadores
            PagoService pagoService = new PagoService();
            pagoService.AgregarObservador(new ClienteObservador(cliente.Nombre));
            pagoService.AgregarObservador(new SupervisorObservador());

            // Crear invoker
            GestorPagosInvoker invoker = new GestorPagosInvoker();

            // 🔸 Escenario 1: Pago de contado (exitoso, cliente paga 600 por un total de 500)
            IGestorPago pagoContado = new PagoContado();
            ICommand comandoContado = new PagoContadoCommand(pagoContado, cliente, reparacion, 600);

            Console.WriteLine("\n--- Pago contado ---");
            invoker.EjecutarPago(comandoContado);
            pagoService.ProcesarPago(pagoContado, 600, cliente, reparacion);

            // 🔸 Escenario 2: Pago a crédito (cliente abona solo una parte)
            IGestorPago pagoCredito = new PagoCredito();
            ICommand comandoCredito1 = new PagoCreditoCommand(pagoCredito, cliente, reparacion, 200);

            Console.WriteLine("\n--- Pago crédito parcial ---");
            invoker.EjecutarPago(comandoCredito1);
            pagoService.ProcesarPago(pagoCredito, 200, cliente, reparacion);

            // 🔸 Escenario 3: Cliente termina de pagar el crédito
            ICommand comandoCredito2 = new PagoCreditoCommand(pagoCredito, cliente, reparacion, 300);

            Console.WriteLine("\n--- Pago crédito final ---");
            invoker.EjecutarPago(comandoCredito2);
            pagoService.ProcesarPago(pagoCredito, 300, cliente, reparacion);

            Console.WriteLine("\n=== ✅ Flujo finalizado ===");
        }
    }
}
