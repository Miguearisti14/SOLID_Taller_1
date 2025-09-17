using System;
using System.Collections.Generic;

namespace Taller
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Iniciando pruebas del Taller ===\n");

            // 1. Pruebas de clientes y mecánicos
            var (cliente1, cliente2, mecanicos) = InicializarPersonas();

            // 2. Pruebas de vehículos
            var (carro1, moto1) = InicializarVehiculos(cliente1, cliente2);

            Console.WriteLine(carro1.Descripcion());
            Console.WriteLine(moto1.Descripcion());

            // 3. Pruebas de aplicación de lujos
            carro1 = ProbarLujos(carro1);

            Console.WriteLine("Vehículo con lujos: " + carro1.Descripcion());

            // 4. Pruebas de reparación mecánica y observadores usando Factory
            var reparacionMec = ProbarReparacionMecanica(carro1, mecanicos, cliente1);

            // 5. Pruebas de avance de estados
            ProbarEstados(reparacionMec);

            // 6. Pruebas de pagos
            ProbarPagos(cliente1, reparacionMec);

            Console.WriteLine("\n=== Fin de pruebas ===");
        }

        private static (Cliente, Cliente, List<Mecanico>) InicializarPersonas()
        {
            var cliente1 = new Cliente(1, "Daniela", "3001234567", credito: true);
            var cliente2 = new Cliente(2, "Carlos", "3019876543", credito: false);

            var mecanicos = new List<Mecanico>
            {
                new Mecanico(1, "Juan", "3201234567", "Mecánica"),
                new Mecanico(2, "Pedro", "3101112222", "Eléctrica")
            };

            return (cliente1, cliente2, mecanicos);
        }

        private static (IVehiculo, IVehiculo) InicializarVehiculos(Cliente cliente1, Cliente cliente2)
        {
            IVehiculo carro1 = new Carro("ABC123", "Toyota", 2020, cliente1, new Gasolina(), 4, "Manual");
            IVehiculo moto1 = new Moto("XYZ987", "Yamaha", 2022, cliente2, new Electrico(), 200, "Automática");
            return (carro1, moto1);
        }

        private static IVehiculo ProbarLujos(IVehiculo carro)
        {
            ServicioHandler handler = new ServicioHandler();
            carro = handler.Handle("Aire", carro, null);
            carro = handler.Handle("Sonido", carro, null);
            return carro;
        }

        // Usar el factory definido en el proyecto para reparación mecánica
        private static ReparacionBase ProbarReparacionMecanica(IVehiculo carro, List<Mecanico> mecanicos, Cliente cliente)
        {
            IGestorRepuesto gestorRepuestos = new GestorRepuesto(new List<Repuesto>
            {
                new Repuesto("Filtro de aceite", "Proveedor1", DateTime.Now, 50),
                new Repuesto("Bujía", "Proveedor2", DateTime.Now, 30)
            });

            ReparacionFactory factory = new ReparacionMecanicaFactory();
            IReparacion reparacion = factory.CrearReparacion(carro, gestorRepuestos, mecanicos);

            // Cast para acceder a métodos de observador y estado
            ReparacionBase reparacionBase = reparacion as ReparacionBase;

            var clienteObs = new ClienteObservador(cliente.Nombre);
            var supervisorObs = new SupervisorObservador();

            reparacionBase.AgregarObservador(clienteObs);
            reparacionBase.AgregarObservador(supervisorObs);

            return reparacionBase;
        }

        private static void ProbarEstados(ReparacionBase reparacionMec)
        {
            Console.WriteLine("\n--- Avanzando reparación ---");
            Console.WriteLine("Estado actual: " + reparacionMec.EstadoActual());
            reparacionMec.AvanzarEstado();
            Console.WriteLine("Estado actual: " + reparacionMec.EstadoActual());
            reparacionMec.AvanzarEstado();
            Console.WriteLine("Estado actual: " + reparacionMec.EstadoActual());
            reparacionMec.AvanzarEstado();
        }

        private static void ProbarPagos(Cliente cliente, ReparacionBase reparacionMec)
        {
            PagoService pagoService = new PagoService();
            var clienteObs = new ClienteObservador(cliente.Nombre);
            var supervisorObs = new SupervisorObservador();

            pagoService.AgregarObservador(clienteObs);
            pagoService.AgregarObservador(supervisorObs);

            GestorPagosInvoker invoker = new GestorPagosInvoker();

            Console.WriteLine("\n--- PROBANDO PAGOS ---");
            var pagoContado = new PagoContado();
            ICommand pagoContadoCmd = new PagoContadoCommand(pagoContado, cliente, reparacionMec, 100, pagoService);
            invoker.EjecutarPago(pagoContadoCmd);

            var pagoCredito = new PagoCredito();
            ICommand pagoCreditoCmd = new PagoCreditoCommand(pagoCredito, cliente, reparacionMec, 50, pagoService);
            invoker.EjecutarPago(pagoCreditoCmd);

            ICommand pagoCreditoCmd2 = new PagoCreditoCommand(pagoCredito, cliente, reparacionMec, 200, pagoService);
            invoker.EjecutarPago(pagoCreditoCmd2);
        }
    }
}
