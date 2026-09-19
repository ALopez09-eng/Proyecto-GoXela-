using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Go_Xela
{
    public class ReportsService : IReportsService
    {
        public IEnumerable<Entrega> GetEntregasActivas()
        {
            return InMemoryStore.GetEntregas().Where(e => e.Estado != DeliveryStatus.Entregada && e.Estado != DeliveryStatus.Cancelada).ToList();
        }

        public IEnumerable<Entrega> GetEntregasFinalizadas()
        {
            return InMemoryStore.GetEntregas().Where(e => e.Estado == DeliveryStatus.Entregada).ToList();
        }

        public IEnumerable<Entrega> GetEntregasCanceladas()
        {
            return InMemoryStore.GetEntregas().Where(e => e.Estado == DeliveryStatus.Cancelada).ToList();
        }

        public IEnumerable<Entrega> GetEntregasConIncidencias()
        {
            return InMemoryStore.GetEntregas().Where(e => e.Incidencias != null && e.Incidencias.Any()).ToList();
        }

        public IEnumerable<Repartidor> GetRepartidoresDisponibles()
        {
            return InMemoryStore.GetRepartidores().Where(r => r.Disponible).ToList();
        }

        public Repartidor GetRepartidorConMasEntregas()
        {
            var entregas = InMemoryStore.GetEntregas().Where(e => e.Repartidor != null);
            var grouped = entregas.GroupBy(e => e.Repartidor.Id)
                                   .Select(g => new { RepartidorId = g.Key, Count = g.Count() })
                                   .OrderByDescending(x => x.Count)
                                   .FirstOrDefault();
            if (grouped == null) return null;
            return InMemoryStore.GetRepartidores().FirstOrDefault(r => r.Id == grouped.RepartidorId);
        }

        public string GetVehiculoMasUtilizado()
        {
            var veh = InMemoryStore.GetEntregas().Where(e => !string.IsNullOrWhiteSpace(e.Vehiculo))
                         .GroupBy(e => e.Vehiculo)
                         .Select(g => new { Veh = g.Key, Count = g.Count() })
                         .OrderByDescending(x => x.Count)
                         .FirstOrDefault();
            return veh?.Veh;
        }

        public IDictionary<PackageType,int> GetCantidadPaquetesPorTipo()
        {

            var paquetes = InMemoryStore.GetPaquetes();
            var resultado = new Dictionary<PackageType, int>();
            foreach (PackageType tipo in Enum.GetValues(typeof(PackageType)))
            {
                var cantidad = RecursionExamples.ContarPaquetesPorTipoRecursivo(paquetes, tipo);
                if (cantidad > 0) resultado[tipo] = cantidad;
            }
            return resultado;
        }

        public double GetTotalIngresos()
        {

            var entregasFinalizadas = InMemoryStore.GetEntregas().Where(e => e.Estado == DeliveryStatus.Entregada).ToList();
            return RecursionExamples.SumarIngresosRecursivo(entregasFinalizadas);
        }

        public Entrega GetEntregaConMayorCosto()
        {
            return InMemoryStore.GetEntregas().OrderByDescending(e => e.Total).FirstOrDefault();
        }
    }
}
