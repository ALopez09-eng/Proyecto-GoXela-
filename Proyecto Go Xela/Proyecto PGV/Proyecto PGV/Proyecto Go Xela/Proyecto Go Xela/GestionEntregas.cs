using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Go_Xela
{
    public partial class GestionEntregas : Form
    {
        // Misma constante que CostCalculator.TarifaPorKm en Program.cs, para poder
        // mostrar/validar la tarifa base en el formulario antes de registrar la entrega.
        private const double TARIFA_POR_KM = 1.2;

        public GestionEntregas()
        {
            InitializeComponent();
        }

        private void GestionEntregas_Load(object sender, EventArgs e)
        {
            // 1) y 4) Tarifa Base y Total siempre bloqueados (se calculan, no se digitan)
            TarifaBase.ReadOnly = true;
            TotalEntregas.ReadOnly = true;

            // 5) Agregar columnas para Origen, Destino, Tarifa Base, Recargos y Descuento
            // si el Designer todavía no las tiene.
            if (IvRegistroPaquetes.Columns.Count < 13)
            {
                IvRegistroPaquetes.Columns.Add("Origen", 150);
                IvRegistroPaquetes.Columns.Add("Destino", 150);
                IvRegistroPaquetes.Columns.Add("Tarifa Base", 110);
                IvRegistroPaquetes.Columns.Add("Recargos", 110);
                IvRegistroPaquetes.Columns.Add("Descuento", 110);
            }

            // Poblar combos con datos en memoria
            CargarCombosEntrega();

            // Vehículos por defecto si no hay datos
            if (VEHICULOPAQUETE.Items.Count == 0)
            {
                VEHICULOPAQUETE.Items.AddRange(new object[] { "MOTO", "CARRO", "BICICLETA" });
            }

            // Asociar evento al botón registrar (se reutiliza el botón existente)
            registrarRepartidor.Click += RegistrarRepartidor_Click;
        }

        // ---------- Helpers ----------

        // Recarga los combos de Cliente/Paquete/Repartidor desde InMemoryStore.
        // Se reutiliza tras cada registro para que los repartidores/vehículos que
        // acaban de quedar "no disponibles" no sigan mostrándose como opción disponible.
        private void CargarCombosEntrega()
        {
            ClientePaquete.DataSource = null;
            ClientePaquete.DisplayMember = "Nombre";
            ClientePaquete.ValueMember = "Id";
            ClientePaquete.DataSource = InMemoryStore.GetClientes();

            PaqueteEntrega.DataSource = null;
            PaqueteEntrega.DisplayMember = "Descripcion";
            PaqueteEntrega.ValueMember = "Id";
            PaqueteEntrega.DataSource = InMemoryStore.GetPaquetes();

            RepartidorPaquete.DataSource = null;
            RepartidorPaquete.DisplayMember = "Nombre";
            RepartidorPaquete.ValueMember = "Id";
            RepartidorPaquete.DataSource = InMemoryStore.GetRepartidores();
        }

        // Deja el formulario limpio para poder registrar otra entrega sin borrar todo a mano.
        private void LimpiarFormularioEntrega()
        {
            CargarCombosEntrega(); // refresca disponibilidad de repartidores/paquetes

            ClientePaquete.SelectedIndex = -1;
            PaqueteEntrega.SelectedIndex = -1;
            RepartidorPaquete.SelectedIndex = -1;
            VEHICULOPAQUETE.SelectedIndex = -1;
            if (ServicioEntrega != null) ServicioEntrega.SelectedIndex = -1;

            // 1) Al no haber paquete seleccionado, origen/destino vuelven a ser editables
            DireccionOrigenEntregas.ReadOnly = false;
            DirecciónDestinoEntregas.ReadOnly = false;
            DireccionOrigenEntregas.Clear();
            DirecciónDestinoEntregas.Clear();
            DistanciaEstimadaEntrega.Clear();
            FechaSolicitudPaquete.Clear();

            TarifaBase.Clear();
            RecargosEntregas.Clear();
            DescuentoEntregas.Clear();
            TotalEntregas.Clear();

            DireccionOrigenEntregas.Focus();
        }

        // 1) Recalcula la Tarifa Base (Q1.20 × distancia) cada vez que cambia la distancia
        // o se selecciona un vehículo. El campo permanece bloqueado (ReadOnly) siempre.
        private void RecalcularTarifaBase()
        {
            double.TryParse(DistanciaEstimadaEntrega.Text?.Trim(), out double distancia);
            double tarifa = Math.Round(TARIFA_POR_KM * distancia, 2);
            TarifaBase.Text = tarifa.ToString("F2");
            RecalcularTotalPreview();
        }

        // Vista previa en vivo del Total (Tarifa + Recargos - Descuento) mientras el usuario escribe.
        // El valor final y validado se recalcula de nuevo justo antes de registrar.
        private void RecalcularTotalPreview()
        {
            double.TryParse(TarifaBase.Text, out double tarifa);
            double.TryParse(RecargosEntregas.Text, out double recargos);
            double.TryParse(DescuentoEntregas.Text, out double descuento);
            double total = Math.Round(tarifa + recargos - descuento, 2);
            TotalEntregas.Text = total.ToString("F2");
        }

        // 2) Filtra el combo de Repartidores según la licencia que requiere el tipo de vehículo:
        // Bicicleta -> "N/A", Moto -> "M", Carro -> "B" o "C".
        private void FiltrarRepartidoresPorVehiculo(string vehTipoStr)
        {
            List<Repartidor> repartidoresFiltrados;

            if (string.IsNullOrWhiteSpace(vehTipoStr))
            {
                repartidoresFiltrados = InMemoryStore.GetRepartidores();
            }
            else if (vehTipoStr.Equals("BICICLETA", StringComparison.OrdinalIgnoreCase))
            {
                repartidoresFiltrados = InMemoryStore.GetRepartidores()
                    .Where(r => r.Licencias != null && r.Licencias.Any(l => l.Equals("N/A", StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }
            else if (vehTipoStr.Equals("MOTO", StringComparison.OrdinalIgnoreCase))
            {
                repartidoresFiltrados = InMemoryStore.GetRepartidores()
                    .Where(r => r.Licencias != null && r.Licencias.Any(l => l.Equals("M", StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }
            else if (vehTipoStr.Equals("CARRO", StringComparison.OrdinalIgnoreCase))
            {
                repartidoresFiltrados = InMemoryStore.GetRepartidores()
                    .Where(r => r.Licencias != null && r.Licencias.Any(l =>
                        l.Equals("B", StringComparison.OrdinalIgnoreCase) || l.Equals("C", StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }
            else
            {
                // Tipo de vehículo no contemplado en la regla (ej. Furgón): no filtrar
                repartidoresFiltrados = InMemoryStore.GetRepartidores();
            }

            RepartidorPaquete.DataSource = null;
            RepartidorPaquete.DisplayMember = "Nombre";
            RepartidorPaquete.ValueMember = "Id";
            RepartidorPaquete.DataSource = repartidoresFiltrados;
            RepartidorPaquete.SelectedIndex = -1;
        }

        // 5) Columnas reales (por índice): 0 Codigo, 1 Cliente, 2 Repartidor, 3 Vehiculo, 4 TipoServicio,
        // 5 Estado, 6 Total, 7 FechaSolicitud, 8 Origen, 9 Destino, 10 TarifaBase, 11 Recargos, 12 Descuento
        private ListViewItem CrearItemEntrega(Entrega entrega, string vehiculoTextoFallback)
        {
            var item = new ListViewItem(entrega.Id.ToString());
            item.SubItems.Add(entrega.Cliente?.Nombre ?? "-");
            item.SubItems.Add(entrega.Repartidor?.Nombre ?? "-");
            item.SubItems.Add(entrega.Vehiculo ?? (vehiculoTextoFallback ?? "-"));
            item.SubItems.Add(entrega.TipoServicio.ToString());
            item.SubItems.Add(entrega.Estado.ToString().ToUpper());
            item.SubItems.Add($"Q{entrega.Total:F2}");
            item.SubItems.Add(entrega.FechaSolicitud.ToString("g"));
            item.SubItems.Add(entrega.Origen ?? "-");
            item.SubItems.Add(entrega.Destino ?? "-");
            item.SubItems.Add($"Q{entrega.TarifaBase:F2}");
            item.SubItems.Add($"Q{entrega.Recargos:F2}");
            item.SubItems.Add($"Q{entrega.Descuentos:F2}");
            return item;
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void DescripciónPaquete_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void IvRegistroPaquetes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarRepartidor_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = ClientePaquete.SelectedItem as Cliente;
                var repartidor = RepartidorPaquete.SelectedItem as Repartidor;
                var paquete = PaqueteEntrega.SelectedItem as Paquete;

                var origen = DireccionOrigenEntregas.Text?.Trim();
                var destino = DirecciónDestinoEntregas.Text?.Trim();
                var distanciaTexto = DistanciaEstimadaEntrega.Text?.Trim();
                var fechaTexto = FechaSolicitudPaquete.Text?.Trim();

                // 1) Origen y destino son obligatorios
                if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino) || string.IsNullOrEmpty(distanciaTexto))
                {
                    MessageBox.Show("Debe ingresar la dirección de origen, destino y la distancia estimada.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2) Origen y destino no pueden ser iguales
                if (origen.Equals(destino, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("La dirección de origen y destino no pueden ser iguales.",
                        "Direcciones inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DirecciónDestinoEntregas.Focus();
                    return;
                }

                // 3) Distancia: numérica y positiva (mayor a 0)
                if (!double.TryParse(distanciaTexto, out double distancia) || distancia <= 0)
                {
                    MessageBox.Show("La distancia estimada debe ser un número positivo mayor a 0.",
                        "Distancia inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DistanciaEstimadaEntrega.Focus();
                    return;
                }

                // 4) Fecha de solicitud: si el usuario escribió algo, debe ser una fecha válida.
                // Si la deja en blanco, se usa la fecha/hora actual (comportamiento original).
                DateTime fechaSolicitud = DateTime.Now;
                if (!string.IsNullOrEmpty(fechaTexto) && !DateTime.TryParse(fechaTexto, out fechaSolicitud))
                {
                    MessageBox.Show("La fecha de solicitud no es válida.", "Fecha inválida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FechaSolicitudPaquete.Focus();
                    return;
                }

                // 3) Recargos: obligatorio, numérico y estrictamente mayor a 0
                if (!double.TryParse(RecargosEntregas.Text?.Trim(), out double recargos) || recargos <= 0)
                {
                    MessageBox.Show("Los recargos deben ser un número positivo mayor a 0.",
                        "Recargos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RecargosEntregas.Focus();
                    return;
                }

                // 3) Descuento: obligatorio, numérico y no negativo
                if (!double.TryParse(DescuentoEntregas.Text?.Trim(), out double descuento) || descuento < 0)
                {
                    MessageBox.Show("El descuento debe ser un número no negativo.",
                        "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DescuentoEntregas.Focus();
                    return;
                }

                // 3) El descuento no puede ser mayor al total antes de aplicarlo (tarifa base + recargos)
                double tarifaBase = Math.Round(TARIFA_POR_KM * distancia, 2);
                double subtotalAntesDeDescuento = tarifaBase + recargos;
                if (descuento > subtotalAntesDeDescuento)
                {
                    MessageBox.Show("El descuento no puede ser mayor al total (tarifa base + recargos).",
                        "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DescuentoEntregas.Focus();
                    return;
                }

                // Tipo de servicio
                ServiceType tipo = ServiceType.Normal;
                if (ServicioEntrega.SelectedItem != null)
                {
                    var s = ServicioEntrega.SelectedItem.ToString().ToUpper();
                    if (s.Contains("URGENTE")) tipo = ServiceType.Urgente;
                    else if (s.Contains("PRIORIT")) tipo = ServiceType.Prioritario;
                }

                // Validaciones antes de asignar repartidor y vehículo
                if (cliente == null)
                {
                    MessageBox.Show("Seleccione un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (paquete == null)
                {
                    MessageBox.Show("Seleccione un paquete.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (repartidor == null)
                {
                    MessageBox.Show("Seleccione un repartidor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!repartidor.Disponible)
                {
                    MessageBox.Show("El repartidor seleccionado no está disponible.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var vehTipoStr = VEHICULOPAQUETE.SelectedItem?.ToString();
                if (string.IsNullOrWhiteSpace(vehTipoStr))
                {
                    MessageBox.Show("Seleccione un vehículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var veh = InMemoryStore.GetVehiculos().FirstOrDefault(v => v.Tipo.ToString().Equals(vehTipoStr, StringComparison.OrdinalIgnoreCase) && v.Disponible);
                if (veh == null)
                {
                    MessageBox.Show($"No hay vehículos disponibles del tipo {vehTipoStr}.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Comprobar que el paquete no esté ya asignado a otra entrega activa
                var asignada = InMemoryStore.GetEntregas().Any(en => en.Paquete != null && paquete.Id == en.Paquete.Id && en.Estado != DeliveryStatus.Cancelada && en.Estado != DeliveryStatus.Entregada);
                if (asignada)
                {
                    MessageBox.Show("El paquete ya está asignado a otra entrega.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Comprobar capacidad
                if (paquete.PesoKg > veh.CapacidadKg)
                {
                    MessageBox.Show($"El peso del paquete ({paquete.PesoKg} kg) supera la capacidad del vehículo ({veh.CapacidadKg} kg).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Compatibilidad vehículo-paquete (reglas simples)
                bool compatible = true;
                switch (paquete.Tipo)
                {
                    case PackageType.Fragil:
                        compatible = (veh.Tipo == VehicleType.Carro || veh.Tipo == VehicleType.Furgon);
                        break;
                    case PackageType.Refrigerado:
                        compatible = (veh.Tipo == VehicleType.Furgon || veh.Tipo == VehicleType.Carro);
                        break;
                    case PackageType.Sobredimensionado:
                        compatible = (veh.Tipo == VehicleType.Furgon);
                        break;
                    default:
                        compatible = true;
                        break;
                }
                if (!compatible)
                {
                    MessageBox.Show("El vehículo seleccionado no es compatible con el tipo de paquete.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Comprobar licencia del repartidor
                if (!string.IsNullOrWhiteSpace(veh.LicenciaRequerida))
                {
                    if (repartidor.Licencias == null || !repartidor.Licencias.Any(l => string.Equals(l, veh.LicenciaRequerida, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show($"El repartidor no posee la licencia requerida ({veh.LicenciaRequerida}) para conducir el vehículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var entrega = new Entrega
                {
                    Cliente = cliente,
                    Repartidor = repartidor,
                    Paquete = paquete,
                    Origen = origen,
                    Destino = destino,
                    DistanciaKm = distancia,
                    FechaSolicitud = fechaSolicitud,
                    Vehiculo = string.IsNullOrWhiteSpace(veh.Placa) ? veh.Tipo.ToString() : veh.Placa,
                    TipoServicio = tipo
                };

                InMemoryStore.AddEntrega(entrega);

                // IMPORTANTE: InMemoryStore.AddEntrega ya recalculó TarifaBase/Recargos/Descuentos/Total
                // automáticamente (CostCalculator.ApplyCosts), lo cual pisaría los valores validados
                // que el usuario ingresó para Recargos y Descuento. Los sobrescribimos aquí.
                entrega.Recargos = recargos;
                entrega.Descuentos = descuento;
                entrega.Total = Math.Round(entrega.TarifaBase + entrega.Recargos - entrega.Descuentos, 2);

                // Cambiar estado a Asignada
                if (!InMemoryStore.TryChangeEntregaState(entrega.Id, DeliveryStatus.Asignada, Environment.UserName, out var errMsg))
                {
                    MessageBox.Show(errMsg ?? "No se pudo asignar la entrega.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Marcar repartidor y vehículo como no disponibles
                repartidor.Disponible = false;
                veh.Disponible = false;
                InMemoryStore.Save();

                // Mostrar resultados en los textboxes de tarifa/recargos/descuento/total
                TarifaBase.Text = entrega.TarifaBase.ToString("F2");
                RecargosEntregas.Text = entrega.Recargos.ToString("F2");
                DescuentoEntregas.Text = entrega.Descuentos.ToString("F2");
                TotalEntregas.Text = entrega.Total.ToString("F2");

                // 5) Añadir a la lista de registros (incluye Origen, Destino, Tarifa, Recargos y Descuento)
                IvRegistroPaquetes.Items.Add(CrearItemEntrega(entrega, vehTipoStr));

                MessageBox.Show($"Entrega registrada. Id: {entrega.Id}", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Dejar el formulario listo para registrar la siguiente entrega
                LimpiarFormularioEntrega();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar entrega: " + ex.Message);
            }
        }

        private void btnDetalleEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                if (IvRegistroPaquetes.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Seleccione una entrega en la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var idText = IvRegistroPaquetes.SelectedItems[0].Text;
                if (!int.TryParse(idText, out int id))
                {
                    MessageBox.Show("Id de entrega inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var entrega = InMemoryStore.GetEntregas().FirstOrDefault(x => x.Id == id);
                if (entrega == null)
                {
                    MessageBox.Show("No se encontró la entrega seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var dlg = new DetalleEntrega(entrega))
                {
                    var dr = dlg.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        // Actualizar la fila seleccionada con los nuevos valores.
                        // Se refrescan Estado Y Total, ya que el detalle puede modificar ambos.
                        var item = IvRegistroPaquetes.SelectedItems[0];
                        item.SubItems[5].Text = entrega.Estado.ToString().ToUpper();
                        item.SubItems[6].Text = entrega.Total.ToString("F2");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir detalle de entrega: " + ex.Message);
            }
        }

        private void ClientePaquete_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // 1) Al seleccionar un paquete, autocompletar y bloquear Origen/Destino con
        // sus direcciones registradas. Sin paquete seleccionado, quedan editables.
        private void PaqueteEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            var paquete = PaqueteEntrega.SelectedItem as Paquete;
            if (paquete != null)
            {
                DireccionOrigenEntregas.Text = paquete.DireccionOrigen ?? "";
                DirecciónDestinoEntregas.Text = paquete.DireccionDestino ?? "";
                DireccionOrigenEntregas.ReadOnly = true;
                DirecciónDestinoEntregas.ReadOnly = true;
            }
            else
            {
                DireccionOrigenEntregas.ReadOnly = false;
                DirecciónDestinoEntregas.ReadOnly = false;
            }
        }

        private void RepartidorPaquete_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // 1) y 2) Al seleccionar el vehículo: recalcular/bloquear Tarifa Base y filtrar Repartidores.
        private void VEHICULOPAQUETE_SelectedIndexChanged(object sender, EventArgs e)
        {
            var vehTipoStr = VEHICULOPAQUETE.SelectedItem?.ToString();

            RecalcularTarifaBase();
            FiltrarRepartidoresPorVehiculo(vehTipoStr);
        }

        private void FechaSolicitudPaquete_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TipoServicioEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DireccionOrigenEntregas_TextChanged(object sender, EventArgs e)
        {

        }

        private void DistanciaEstimadaEntrega_TextChanged(object sender, EventArgs e)
        {
            RecalcularTarifaBase();
        }

        private void TarifaBase_TextChanged(object sender, EventArgs e)
        {

        }

        private void RecargosEntregas_TextChanged(object sender, EventArgs e)
        {
            RecalcularTotalPreview();
        }

        private void DescuentoEntregas_TextChanged(object sender, EventArgs e)
        {
            RecalcularTotalPreview();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TotalEntregas_TextChanged(object sender, EventArgs e)
        {

        }
    }
}