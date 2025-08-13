using Taller.Clases;
using Taller;

class Program
{
    static void Main(string[] args)
    {
        // Simulación de reparación
        Reparacion.Valor = 500; // Precio base de la reparación
        float costoRepuesto = 150;

        // Cliente para prueba de pago contado
        Cliente clienteContado = new Cliente()
        {
            Nombre = "Carlos",
            Saldo = 800,
            Saldopendiente = 0
        };

        // Cliente para prueba de pago a crédito
        Cliente clienteCredito = new Cliente()
        {
            Nombre = "Ana",
            Saldo = 0, // en crédito normalmente el saldo en efectivo no importa
            Saldopendiente = 0
        };

        Console.WriteLine("=== PRUEBA DE PAGO AL CONTADO ===");
        IGestor_Pago pagoContado = new Pago_Contado();
        pagoContado.Cancelar_Pago(650, clienteContado, costoRepuesto); // Paga el total
        pagoContado.Cancelar_Pago(300, clienteContado, costoRepuesto); // Intenta pagar menos de lo debido

        Console.WriteLine("\n=== PRUEBA DE PAGO A CRÉDITO ===");
        IGestor_Pago pagoCredito = new Pago_Credito();
        pagoCredito.Cancelar_Pago(200, clienteCredito, costoRepuesto); // Paga parcialmente
        pagoCredito.Cancelar_Pago(650, clienteCredito, costoRepuesto); // Cancela la deuda
    }
}

// Simulación de clases necesarias
public class Cliente
{
    public string Nombre { get; set; }
    public float Saldo { get; set; }
    public float Saldopendiente { get; set; }
}

public static class Reparacion
{
    public static float Valor { get; set; }
}

