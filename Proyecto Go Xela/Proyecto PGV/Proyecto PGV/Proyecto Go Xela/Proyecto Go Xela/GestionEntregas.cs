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

        private const double TARIFA_POR_KM = 1.2;

        public GestionEntregas()
        {
            InitializeComponent();
        }

        private void GestionEntregas_Load(object sender, EventArgs e)
        {
            TarifaBase.ReadOnly = true;
            TotalEntregas.ReadOnly = true;


            if (IvRegistroPaquetes.Columns.Count < 13)
            {
                IvRegistroPaquetes.Columns.Add("Origen", 150);
                IvRegistroPaquetes.Columns.Add("Destino", 150);
                IvRegistroPaquetes.Columns.Add("Tarifa Base", 110);
                IvRegistroPaquetes.Columns.Add("Recargos", 110);
                IvRegistroPaquetes.Columns.Add("Descuento", 110);
            }

            CargarCombosEntrega();

            if (VEHICULOPAQUETE.Items.Count == 0)
            {
                VEHICULOPAQUETE.Items.AddRange(new object[] { "MOTO", "CARRO", "BICICLETA" });
            }

            registrarRepartidor.Click += RegistrarRepartidor_Click;
        }

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

        private void LimpiarFormularioEntrega()
        {
            CargarCombosEntrega(); 

            ClientePaquete.SelectedIndex = -1;
            PaqueteEntrega.SelectedIndex = -1;
            RepartidorPaquete.SelectedIndex = -1;
            VEHICULOPAQUETE.SelectedIndex = -1;
            if (ServicioEntrega != null) ServicioEntrega.SelectedIndex = -1;

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


        private void RecalcularTarifaBase()
        {
            double.TryParse(DistanciaEstimadaEntrega.Text?.Trim(), out double distancia);
            double tarifa = Math.Round(TARIFA_POR_KM * distancia, 2);
            TarifaBase.Text = tarifa.ToString("F2");
            RecalcularTotalPreview();
        }


        private void RecalcularTotalPreview()
        {
            double.TryParse(TarifaBase.Text, out double tarifa);
            double.TryParse(RecargosEntregas.Text, out double recargos);
            double.TryParse(DescuentoEntregas.Text, out double descuento);
            double total = Math.Round(tarifa + recargos - descuento, 2);
            TotalEntregas.Text = total.ToString("F2");
        }


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
                repartidoresFiltrados = InMemoryStore.GetRepartidores();
            }

            RepartidorPaquete.DataSource = null;
            RepartidorPaquete.DisplayMember = "Nombre";
            RepartidorPaquete.ValueMember = "Id";
            RepartidorPaquete.DataSource = repartidoresFiltrados;
            RepartidorPaquete.SelectedIndex = -1;
        }


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

                if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino) || string.IsNullOrEmpty(distanciaTexto))
                {
                    MessageBox.Show("Debe ingresar la dirección de origen, destino y la distancia estimada.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (origen.Equals(destino, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("La dirección de origen y destino no pueden ser iguales.",
                        "Direcciones inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DirecciónDestinoEntregas.Focus();
                    return;
                }

                if (!double.TryParse(distanciaTexto, out double distancia) || distancia <= 0)
                {
                    MessageBox.Show("La distancia estimada debe ser un número positivo mayor a 0.",
                        "Distancia inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DistanciaEstimadaEntrega.Focus();
                    return;
                }

                DateTime fechaSolicitud = DateTime.Now;
                if (!string.IsNullOrEmpty(fechaTexto) && !DateTime.TryParse(fechaTexto, out fechaSolicitud))
                {
                    MessageBox.Show("La fecha de solicitud no es válida.", "Fecha inválida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FechaSolicitudPaquete.Focus();
                    return;
                }

                if (!double.TryParse(RecargosEntregas.Text?.Trim(), out double recargos) || recargos <= 0)
                {
                    MessageBox.Show("Los recargos deben ser un número positivo mayor a 0.",
                        "Recargos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RecargosEntregas.Focus();
                    return;
                }

                if (!double.TryParse(DescuentoEntregas.Text?.Trim(), out double descuento) || descuento < 0)
                {
                    MessageBox.Show("El descuento debe ser un número no negativo.",
                        "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DescuentoEntregas.Focus();
                    return;
                }

                double tarifaBase = Math.Round(TARIFA_POR_KM * distancia, 2);
                double subtotalAntesDeDescuento = tarifaBase + recargos;
                if (descuento > subtotalAntesDeDescuento)
                {
                    MessageBox.Show("El descuento no puede ser mayor al total (tarifa base + recargos).",
                        "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DescuentoEntregas.Focus();
                    return;
                }

                ServiceType tipo = ServiceType.Normal;
                if (ServicioEntrega.SelectedItem != null)
                {
                    var s = ServicioEntrega.SelectedItem.ToString().ToUpper();
                    if (s.Contains("URGENTE")) tipo = ServiceType.Urgente;
                    else if (s.Contains("PRIORIT")) tipo = ServiceType.Prioritario;
                }

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

                var asignada = InMemoryStore.GetEntregas().Any(en => en.Paquete != null && paquete.Id == en.Paquete.Id && en.Estado != DeliveryStatus.Cancelada && en.Estado != DeliveryStatus.Entregada);
                if (asignada)
                {
                    MessageBox.Show("El paquete ya está asignado a otra entrega.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (paquete.PesoKg > veh.CapacidadKg)
                {
                    MessageBox.Show($"El peso del paquete ({paquete.PesoKg} kg) supera la capacidad del vehículo ({veh.CapacidadKg} kg).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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


                entrega.Recargos = recargos;
                entrega.Descuentos = descuento;
                entrega.Total = Math.Round(entrega.TarifaBase + entrega.Recargos - entrega.Descuentos, 2);

                if (!InMemoryStore.TryChangeEntregaState(entrega.Id, DeliveryStatus.Asignada, Environment.UserName, out var errMsg))
                {
                    MessageBox.Show(errMsg ?? "No se pudo asignar la entrega.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                repartidor.Disponible = false;
                veh.Disponible = false;
                InMemoryStore.Save();

                TarifaBase.Text = entrega.TarifaBase.ToString("F2");
                RecargosEntregas.Text = entrega.Recargos.ToString("F2");
                DescuentoEntregas.Text = entrega.Descuentos.ToString("F2");
                TotalEntregas.Text = entrega.Total.ToString("F2");

                IvRegistroPaquetes.Items.Add(CrearItemEntrega(entrega, vehTipoStr));

                try
                {
                    if (!string.IsNullOrWhiteSpace(cliente.CorreoElectronico))
                    {
                        Notification correoNotif = new EmailNotification(cliente.CorreoElectronico, "Entrega registrada",
                            $"Su entrega #{entrega.Id} fue registrada y asignada a {repartidor.Nombre}.");
                        correoNotif.Send();
                    }
                    Notification smsNotif = new SmsNotification(repartidor.Telefono,
                        $"Se te asignó la entrega #{entrega.Id} (destino: {destino}).");
                    smsNotif.Send();
                }
                catch
                {

                }

                double tarifaSoloDistancia = TariffCalculatorEx.Calculate(distancia);
                double tarifaConPeso = TariffCalculatorEx.Calculate(distancia, paquete.PesoKg);
                double tarifaConServicio = TariffCalculatorEx.Calculate(distancia, tipo);

                MessageBox.Show(
                    $"Entrega registrada. Id: {entrega.Id}\n\n" +
                    $"Total registrado: Q{entrega.Total:F2}\n\n" +
                    $"Referencia (sobrecarga TariffCalculatorEx):\n" +
                    $"  Solo distancia: Q{tarifaSoloDistancia:F2}\n" +
                    $"  Distancia + peso: Q{tarifaConPeso:F2}\n" +
                    $"  Distancia + tipo de servicio: Q{tarifaConServicio:F2}",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
