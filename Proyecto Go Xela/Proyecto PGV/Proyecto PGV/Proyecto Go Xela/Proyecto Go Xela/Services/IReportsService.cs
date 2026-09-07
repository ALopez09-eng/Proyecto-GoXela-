using System.Collections.Generic;

namespace Proyecto_Go_Xela
{
    public interface IReportsService
    {
        IEnumerable<Entrega> GetEntregasActivas();
        IEnumerable<Entrega> GetEntregasFinalizadas();
        IEnumerable<Entrega> GetEntregasCanceladas();
        IEnumerable<Entrega> GetEntregasConIncidencias();
        IEnumerable<Repartidor> GetRepartidoresDisponibles();
        Repartidor GetRepartidorConMasEntregas();
        string GetVehiculoMasUtilizado();
        IDictionary<PackageType,int> GetCantidadPaquetesPorTipo();
        double GetTotalIngresos();
        Entrega GetEntregaConMayorCosto();
    }
}