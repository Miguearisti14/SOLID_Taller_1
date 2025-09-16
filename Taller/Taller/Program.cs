using System;
using System.Collections.Generic;

namespace Taller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 🔹 Crear cliente y vehículo
            Cliente cliente = new Cliente(1, "Juan Pérez", "3001234567", credito: false);
            IMotor motor = new Gasolina();
            IVehiculo carro = new Carro("AAA111", "Mazda", 2022, cliente, motor, 4, "Manual");

            // 🔹 Crear mecánicos y repuestos
            var mecanicos = new List<Mecanico> { new Mecanico(1, "Pedro", "3011111111", "Motor") };
            var repuestos = new List<Repuesto> { new Repuesto("Filtro aceite", "ProveedorX", DateTime.Now, 100m) };
            IGestorRepuesto gestor = new GestorRepuesto(repuestos);

            // 🔹 Crear reparación
            ReparacionBase reparacion = new ReparacionMecanica(carro, gestor, mecanicos);
            

            // 🔔 Agregar observadores (Observer)
            reparacion.AgregarObservador(new ClienteObservador(cliente.Nombre));
            reparacion.AgregarObservador(new SupervisorObservador());

            // ⚙️ Simular flujo de reparación (State)
            reparacion.AvanzarEstado();
            reparacion.AvanzarEstado();
            reparacion.AvanzarEstado(); // No avanza más, pero igual notifica

            Console.WriteLine("\n=== 🔹 Etapa de pagos (Command Pattern) ===");

            // 🔹 Crear invoker
            GestorPagosInvoker invoker = new GestorPagosInvoker();

            // Escenario 1: Pago de contado (exitoso, cliente paga 600 por un total de 500)
            IGestorPago pagoContado = new PagoContado();
            ICommand comandoContado = new PagoContadoCommand(pagoContado, cliente, reparacion, 600);
            invoker.EjecutarPago(comandoContado);

            // Escenario 2: Pago a crédito (cliente abona solo una parte)
            IGestorPago pagoCredito = new PagoCredito();
            ICommand comandoCredito1 = new PagoCreditoCommand(pagoCredito, cliente, reparacion, 200);
            invoker.EjecutarPago(comandoCredito1);

            // Escenario 3: Cliente termina de pagar el crédito
            ICommand comandoCredito2 = new PagoCreditoCommand(pagoCredito, cliente, reparacion, 300);
            invoker.EjecutarPago(comandoCredito2);

            Console.WriteLine("\n=== Flujo finalizado ===");
        }
    }
}
