using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Clases;
using Taller.Eventos;
using Taller.Interfaces;

namespace Taller
{
    public abstract class ReparacionBase : IReparaciones
    {
        public abstract float ValorTotal { get; }

        public Carro Carro { get; protected set; }
        public DateTime Fecha { get; protected set; }
        public List<Mecanico> Mecanicos { get; protected set; }
        public string ResultadoPuestaPunto { get; set; }

        protected IGestorRepuestos gestorRepuestos;
        protected Publisher_ReparacionFinalizada publicadorFinal;
        protected Publisher_VehiculoIngresado publicadorIngreso;

        protected ReparacionBase(Carro carro, IGestorRepuestos gestorRepuestos, List<Mecanico> mecanicos)
        {
            Carro = carro;
            this.gestorRepuestos = gestorRepuestos;
            Mecanicos = mecanicos;
            Fecha = DateTime.Now;

            publicadorIngreso = new Publisher_VehiculoIngresado();
            publicadorIngreso.evt_ingreso += EventHandler;
            publicadorIngreso.Informar_Ingreso_Vehiculo(true);
        }

        public virtual void IniciarReparacion() { }
        public abstract void FinalizarReparacion();

        protected virtual void EventHandler() { }
    }
}
