using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using b_taller_automovil.Eventos;

namespace b_taller_automovil.Clases
{

    public class Taller
    {
        private List<Reparacion> l_reparaciones_cientes;

        internal static Publisher_FacturaCanceladaSalida publicador;
        internal static Publisher_CreditoActualizado publicador2;
        internal static void EventHandler()
        {

        }


        internal List<Reparacion> L_reparaciones_cientes { get => l_reparaciones_cientes; set => l_reparaciones_cientes = value; }


        //REVISAR ESTOS METODOS CONFUSION ENTRE SALDO Y EL CREDITO 
        public static string Cancelar_Pago(float pago, Cliente cliente, float costo_repuesto)
        {

            try
            {
                if (pago < (Reparacion.Valor + costo_repuesto))
                {
                    cliente.Saldopendiente = (Reparacion.Valor + costo_repuesto) - pago; // Ajusta el saldo pendiente
                    return $"El pago no se pudo realizar completamente. Monto pendiente: {cliente.Saldopendiente}";
                }
                else
                {
                    cliente.Saldopendiente = 0; // Se cancela la deuda completamente
                    cliente.Saldo = Math.Max(cliente.Saldo - pago, 0); // Deja el saldo en cero o resta lo necesario

                    // Emite el evento de factura pagada si es exitoso
                    publicador = new Publisher_FacturaCanceladaSalida();
                    publicador.evt_factura_salida += EventHandler;
                    publicador.Informar_Cancelamiento_Factura_Salida(pago);

                    return $"El pago fue ejecutado de manera exitosa. Saldo restante: {cliente.Saldo}";
                }

            }
            catch (Exception ex) 
            {
                throw new Exception("Ocurrio un error en el metodo Cancelar Pago" + ex.Message);
            }

        }
        public static float Cancelar_Pago_float(float pago, Cliente cliente, float costo_repuesto)
        {

            try
            {
                if (pago < (Reparacion.Valor + costo_repuesto))
                {
                    return cliente.Saldopendiente = (Reparacion.Valor + costo_repuesto) - pago; // Ajusta el saldo pendiente
                    
                }
                else
                {                    
                    cliente.Saldopendiente = Math.Max(cliente.Saldo - pago, 0); // Deja el saldo en cero o resta lo necesario

                    // Emite el evento de factura pagada si es exitoso
                    publicador = new Publisher_FacturaCanceladaSalida();
                    publicador.evt_factura_salida += EventHandler;
                    publicador.Informar_Cancelamiento_Factura_Salida(pago);

                    return cliente.Saldo;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error en el metodo Cancelar Pago" + ex.Message);
            }

        }

        //REVISAR ESTOS METODOS CONFUSION ENTRE SALDO Y EL CREDITO 
        public static string Credito_Cliente(Cliente cliente, float saldo_pendiente)
        {
            try
            {
                if (cliente.Credito)
                {
                    return "El cliente no tiene crédito disponible.";
                }

                if (saldo_pendiente > 0)
                {
                    // Registrar el crédito pendiente
                    publicador2 = new Publisher_CreditoActualizado();
                    publicador2.evt_credito += EventHandler;
                    publicador2.Informar_Credito_Actualizado();
                    cliente.Saldopendiente = saldo_pendiente;

                    return $"Crédito actualizado. Monto pendiente: {saldo_pendiente}.";
                }

                return "No hay crédito pendiente para actualizar.";
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el método Credito_Cliente: " + ex.Message);
            }
        }

        public static float Cancelar_Pago_Credito(float pago, float pendiente)
        {
            // Verificamos si el cliente tiene saldo pendiente
            if (pendiente <= 0)
            {
                return 0; // No hay saldo pendiente
            }

            // Calculamos el nuevo saldo después del pago
            float nuevoSaldo = pendiente - pago;

            // Actualizamos el saldo del cliente
            pendiente = Math.Max(nuevoSaldo, 0); // No permitimos saldo negativo

            // Devolvemos el saldo pendiente restante
            return pendiente;
        }
    }
}
