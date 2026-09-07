using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_Go_Xela
{
    public class ReportsForm : Form
    {
        private readonly IReportsService _reports;
        private TextBox _txt;
        private Button _btnRefresh;

        public ReportsForm()
        {
            _reports = new ReportsService();

            _txt = new TextBox { Multiline = true, ScrollBars = ScrollBars.Vertical, Dock = DockStyle.Fill, ReadOnly = true };
            _btnRefresh = new Button { Text = "Actualizar", Dock = DockStyle.Top, Height = 30 };
            _btnRefresh.Click += (s, e) => RefreshReports();

            this.Controls.Add(_txt);
            this.Controls.Add(_btnRefresh);
            this.Text = "Reportes";
            this.Width = 800;
            this.Height = 600;

            RefreshReports();
        }

        private void RefreshReports()
        {
            try
            {
                var sb = new StringBuilder();

                var activas = _reports.GetEntregasActivas();
                sb.AppendLine($"1. Entregas activas: {activas.Count()}");

                var finalizadas = _reports.GetEntregasFinalizadas();
                sb.AppendLine($"2. Entregas finalizadas: {finalizadas.Count()}");

                var canceladas = _reports.GetEntregasCanceladas();
                sb.AppendLine($"3. Entregas canceladas: {canceladas.Count()}");

                var conInc = _reports.GetEntregasConIncidencias();
                sb.AppendLine($"4. Entregas con incidencias: {conInc.Count()}");

                var disponibles = _reports.GetRepartidoresDisponibles();
                sb.AppendLine($"5. Repartidores disponibles: {disponibles.Count()}");

                var topRepartidor = _reports.GetRepartidorConMasEntregas();
                sb.AppendLine($"6. Repartidor con más entregas: {(topRepartidor != null ? topRepartidor.Nombre + " (ID=" + topRepartidor.Id + ")" : "N/A")}");

                var veh = _reports.GetVehiculoMasUtilizado();
                sb.AppendLine($"7. Vehículo más utilizado: {veh ?? "N/A"}");

                var porTipo = _reports.GetCantidadPaquetesPorTipo();
                sb.AppendLine("8. Cantidad de paquetes por tipo:");
                foreach (var kv in porTipo)
                {
                    sb.AppendLine($"   - {kv.Key}: {kv.Value}");
                }

                var ingresos = _reports.GetTotalIngresos();
                sb.AppendLine($"9. Total de ingresos (entregas finalizadas): {ingresos}");

                var mayorCosto = _reports.GetEntregaConMayorCosto();
                sb.AppendLine($"10. Entrega con mayor costo: {(mayorCosto != null ? $"ID={mayorCosto.Id}, Total={mayorCosto.Total}" : "N/A")}");

                _txt.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                _txt.Text = "Error generando reportes: " + ex.Message;
            }
        }
    }
}
