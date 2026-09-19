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
    public partial class GestionVehiculos : Form
    {
        private const string ESTADO_INICIAL = "DISPONIBLE";
        private const string PLACEHOLDER = "SELECCIONE UNA OPCIÓN";

        private int _idVehiculoEnEdicion = -1;

        public GestionVehiculos()
        {
            InitializeComponent();
        }

        private void GestionVehiculos_Load(object sender, EventArgs e)
        {
            button1.Click += button1_Click;
            ActualizarRepartidor.Click += ActualizarRepartidor_Click;

            ActualizarRepartidor.Enabled = false;

            foreach (var v in InMemoryStore.GetVehiculos())
            {
                string estadoReconstruido = v.Disponible ? "DISPONIBLE" : "ASIGNADO";
                LisViewVehiculos.Items.Add(CrearItemVehiculo(
                    v.Id, v.Tipo.ToString().ToUpper(), v.Placa, v.Marca, v.Modelo,
                    v.CapacidadKg, estadoReconstruido, v.CostoOperativo));
            }
        }

        private bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrEmpty(placa)) return false;

            int letras = placa.Count(char.IsLetter);
            int numeros = placa.Count(char.IsDigit);
            int otrosCaracteres = placa.Length - letras - numeros;

            return letras == 3 && numeros == 3 && otrosCaracteres == 0;
        }

        private ListViewItem CrearItemVehiculo(int id, string tipo, string placa, string marca, string modelo,
            double capacidad, string estado, double costo)
        {
            var item = new ListViewItem(id.ToString());          // Código
            item.SubItems.Add(tipo ?? "");                        // Tipo de Vehículo
            item.SubItems.Add(placa ?? "");                       // Placa
            item.SubItems.Add(marca ?? "");                       // Marca
            item.SubItems.Add(modelo ?? "");                      // Modelo
            item.SubItems.Add($"{capacidad} kg");                 // Capacidad Máxima
            item.SubItems.Add(estado ?? "");                      // Estado
            item.SubItems.Add($"Q{costo:F2}");                    // Costo Operativo
            return item;
        }

        private void LimpiarCamposVehiculo()
        {
            TipoVehiculo.Text = PLACEHOLDER;
            PlacaVehiculo.Text = "";
            PlacaVehiculo.Enabled = true;
            MarcaVehiculo.Clear();
            ModeloVehículo.Clear();
            CapacidadMaximaVehiculo.Clear();
            CostoOperativoVehiuclo.Clear();
            EstadoVehiculo.Text = PLACEHOLDER;
            MarcaVehiculo.Focus();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void PlacaVehiculo_TextChanged(object sender, EventArgs e)
        {

        }

        private void CostoOperativoVehiuclo_TextChanged(object sender, EventArgs e)
        {

        }

        private void TipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esBicicleta = (TipoVehiculo.Text ?? "").Trim().Equals("BICICLETA", StringComparison.OrdinalIgnoreCase);

            if (esBicicleta)
            {
                PlacaVehiculo.Text = "N/A";
                PlacaVehiculo.Enabled = false;
            }
            else
            {
                if (!PlacaVehiculo.Enabled)
                {
                    PlacaVehiculo.Text = "";
                }
                PlacaVehiculo.Enabled = true;
            }
        }

        private void registrarRepartidor_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoTexto = TipoVehiculo.Text?.Trim();
                string placa = PlacaVehiculo.Text?.Trim();
                string marca = MarcaVehiculo.Text?.Trim();
                string modelo = ModeloVehículo.Text?.Trim();
                string capacidadTexto = CapacidadMaximaVehiculo.Text?.Trim();
                string costoTexto = CostoOperativoVehiuclo.Text?.Trim();

                bool esBicicleta = !string.IsNullOrEmpty(tipoTexto) &&
                    tipoTexto.Equals("BICICLETA", StringComparison.OrdinalIgnoreCase);

                if (string.IsNullOrEmpty(tipoTexto) || tipoTexto.Equals(PLACEHOLDER, StringComparison.OrdinalIgnoreCase) ||
                    string.IsNullOrEmpty(placa) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo) ||
                    string.IsNullOrEmpty(capacidadTexto) || string.IsNullOrEmpty(costoTexto))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Datos incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!esBicicleta && !ValidarPlaca(placa))
                {
                    MessageBox.Show("La placa debe contener exactamente 3 números y 3 letras.",
                        "Placa inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PlacaVehiculo.Focus();
                    return;
                }

                if (!double.TryParse(capacidadTexto, out double capacidad) || capacidad < 0)
                {
                    MessageBox.Show("La capacidad máxima debe ser un número válido y no puede ser negativa.",
                        "Capacidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CapacidadMaximaVehiculo.Focus();
                    return;
                }

                if (!double.TryParse(costoTexto, out double costo) || costo < 0)
                {
                    MessageBox.Show("El costo operativo debe ser un número válido y no puede ser negativo.",
                        "Costo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CostoOperativoVehiuclo.Focus();
                    return;
                }

                var v = new Vehiculo
                {
                    Placa = esBicicleta ? "N/A" : placa,
                    Marca = marca,
                    Modelo = modelo,
                    Tipo = VehicleType.Carro,
                    CapacidadKg = capacidad,
                    Disponible = true, 
                    LicenciaRequerida = "",
                    CostoOperativo = costo
                };
                try { v.Tipo = (VehicleType)Enum.Parse(typeof(VehicleType), tipoTexto, true); } catch { }

                v = InMemoryStore.AddVehiculo(v);
                MessageBox.Show($"Vehículo registrado. Id: {v.Id}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LisViewVehiculos.Items.Add(CrearItemVehiculo(
                    v.Id, tipoTexto.ToUpper(), v.Placa, marca, modelo, capacidad, ESTADO_INICIAL, costo));

                LimpiarCamposVehiculo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar vehículo: " + ex.Message);
            }
        }

        private void LisViewVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LisViewVehiculos.SelectedItems.Count == 0)
                return;

            var item = LisViewVehiculos.SelectedItems[0];

            if (!int.TryParse(item.Text, out int id))
                return;

            _idVehiculoEnEdicion = id;


            string tipoGuardado = item.SubItems[1].Text;
            string placaGuardada = item.SubItems[2].Text;
            string marcaGuardada = item.SubItems[3].Text;
            string modeloGuardado = item.SubItems[4].Text;
            string capacidadGuardada = item.SubItems[5].Text.Replace("kg", "").Trim();
            string estadoGuardado = item.SubItems[6].Text;
            string costoGuardado = item.SubItems[7].Text.Replace("Q", "").Trim();

            TipoVehiculo.Text = tipoGuardado;
            MarcaVehiculo.Text = marcaGuardada;
            ModeloVehículo.Text = modeloGuardado;
            CapacidadMaximaVehiculo.Text = capacidadGuardada;
            CostoOperativoVehiuclo.Text = costoGuardado;
            EstadoVehiculo.Text = estadoGuardado; 


            bool esBicicleta = tipoGuardado.Trim().Equals("BICICLETA", StringComparison.OrdinalIgnoreCase);
            if (esBicicleta)
            {
                PlacaVehiculo.Enabled = false;
                PlacaVehiculo.Text = "N/A";
            }
            else
            {
                PlacaVehiculo.Enabled = true;
                PlacaVehiculo.Text = placaGuardada;
            }

            registrarRepartidor.Enabled = false;
            ActualizarRepartidor.Enabled = true;
        }

        private void MarcaVehiculo_TextChanged(object sender, EventArgs e)
        {

        }

        private void ModeloVehículo_TextChanged(object sender, EventArgs e)
        {

        }

        private void CapacidadMaximaVehiculo_TextChanged(object sender, EventArgs e)
        {

        }

        private void EstadoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarCamposVehiculo();
            _idVehiculoEnEdicion = -1;
            LisViewVehiculos.SelectedIndices.Clear();
            registrarRepartidor.Enabled = true;
            ActualizarRepartidor.Enabled = false;
        }

        private void ActualizarRepartidor_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idVehiculoEnEdicion == -1)
                {
                    MessageBox.Show("Debe seleccionar un vehículo de la lista antes de actualizar.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipoTexto = TipoVehiculo.Text?.Trim();
                string placa = PlacaVehiculo.Text?.Trim();
                string marca = MarcaVehiculo.Text?.Trim();
                string modelo = ModeloVehículo.Text?.Trim();
                string capacidadTexto = CapacidadMaximaVehiculo.Text?.Trim();
                string costoTexto = CostoOperativoVehiuclo.Text?.Trim();
                string estadoTexto = EstadoVehiculo.Text?.Trim();

                bool esBicicleta = !string.IsNullOrEmpty(tipoTexto) &&
                    tipoTexto.Equals("BICICLETA", StringComparison.OrdinalIgnoreCase);

                if (string.IsNullOrEmpty(tipoTexto) || tipoTexto.Equals(PLACEHOLDER, StringComparison.OrdinalIgnoreCase) ||
                    string.IsNullOrEmpty(placa) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo) ||
                    string.IsNullOrEmpty(capacidadTexto) || string.IsNullOrEmpty(costoTexto) ||
                    string.IsNullOrEmpty(estadoTexto) || estadoTexto.Equals(PLACEHOLDER, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Datos incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!esBicicleta && !ValidarPlaca(placa))
                {
                    MessageBox.Show("La placa debe contener exactamente 3 números y 3 letras.",
                        "Placa inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PlacaVehiculo.Focus();
                    return;
                }

                if (!double.TryParse(capacidadTexto, out double capacidad) || capacidad < 0)
                {
                    MessageBox.Show("La capacidad máxima debe ser un número válido y no puede ser negativa.",
                        "Capacidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CapacidadMaximaVehiculo.Focus();
                    return;
                }

                if (!double.TryParse(costoTexto, out double costo) || costo < 0)
                {
                    MessageBox.Show("El costo operativo debe ser un número válido y no puede ser negativo.",
                        "Costo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CostoOperativoVehiuclo.Focus();
                    return;
                }

                var vehiculo = InMemoryStore.GetVehiculos().FirstOrDefault(x => x.Id == _idVehiculoEnEdicion);
                if (vehiculo == null)
                {
                    MessageBox.Show("No se encontró el vehículo a actualizar.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vehiculo.Placa = esBicicleta ? "N/A" : placa;
                vehiculo.Marca = marca;
                vehiculo.Modelo = modelo;
                vehiculo.CapacidadKg = capacidad;
                vehiculo.CostoOperativo = costo;
                try { vehiculo.Tipo = (VehicleType)Enum.Parse(typeof(VehicleType), tipoTexto, true); } catch { }

                vehiculo.Disponible = estadoTexto.Equals("DISPONIBLE", StringComparison.OrdinalIgnoreCase);

                foreach (ListViewItem item in LisViewVehiculos.Items)
                {
                    if (item.Text == _idVehiculoEnEdicion.ToString())
                    {
                        item.SubItems[1].Text = tipoTexto.ToUpper();
                        item.SubItems[2].Text = vehiculo.Placa ?? "";
                        item.SubItems[3].Text = vehiculo.Marca ?? "";
                        item.SubItems[4].Text = vehiculo.Modelo ?? "";
                        item.SubItems[5].Text = $"{vehiculo.CapacidadKg} kg";
                        item.SubItems[6].Text = estadoTexto.ToUpper();
                        item.SubItems[7].Text = $"Q{vehiculo.CostoOperativo:F2}";
                        break;
                    }
                }

                MessageBox.Show("Vehículo actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCamposVehiculo();
                _idVehiculoEnEdicion = -1;
                LisViewVehiculos.SelectedIndices.Clear();
                registrarRepartidor.Enabled = true;
                ActualizarRepartidor.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar vehículo: " + ex.Message);
            }
        }
    }
}