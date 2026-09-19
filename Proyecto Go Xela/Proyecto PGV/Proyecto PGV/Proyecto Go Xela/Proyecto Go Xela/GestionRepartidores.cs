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
    public partial class GestionRepartidores : Form
    {
        private const string ESTADO_INICIAL = "DISPONIBLE";
        private const string PLACEHOLDER = "SELECCIONE UNA OPCIÓN";

        private int _idRepartidorEnEdicion = -1;

        public GestionRepartidores()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TipoLicencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void TipoLicencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esNA = (TipoLicencia.Text ?? "").Trim().Equals("N/A", StringComparison.OrdinalIgnoreCase);

            if (esNA)
            {
                NumeroLicencia.Text = "N/A";
                NumeroLicencia.Enabled = false;
            }
            else
            {
                if (!NumeroLicencia.Enabled)
                {
                    NumeroLicencia.Text = "";
                }
                NumeroLicencia.Enabled = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void GestionRepartidores_Load(object sender, EventArgs e)
        {

            registrarRepartidor.Click += RegistrarRepartidor_Click;

            ActualizarRepartidor.Enabled = false;

            foreach (var r in InMemoryStore.GetRepartidores())
            {
                string tipoLicenciaGuardado = (r.Licencias != null && r.Licencias.Count > 0) ? r.Licencias[0] : "";
                string estadoGuardado = r.Disponible ? "DISPONIBLE" : "ASIGNADO";

                var item = CrearItemRepartidor(r.Id, r.Nombre, r.Telefono, tipoLicenciaGuardado,
                    r.NumeroLicencia ?? "", r.CantidadEntregasRealizadas.ToString(), r.CalificacionPromedio.ToString("F2"), estadoGuardado);
                IvRegistroReparidores.Items.Add(item);
            }
        }


        private bool ValidarTelefono(string telefono)
        {
            return !string.IsNullOrEmpty(telefono) && telefono.Length == 8 && telefono.All(char.IsDigit);
        }

        private bool ValidarNumeroLicencia(string numero)
        {
            return !string.IsNullOrEmpty(numero) && numero.Length == 13 && numero.All(char.IsDigit);
        }

        private ListViewItem CrearItemRepartidor(int id, string nombre, string telefono, string tipoLicencia,
            string numeroLicencia, string entregas, string calificacion, string estado)
        {
            var item = new ListViewItem(id.ToString());   // Código
            item.SubItems.Add(nombre ?? "");                // Nombre
            item.SubItems.Add(telefono ?? "");              // Teléfono
            item.SubItems.Add(tipoLicencia ?? "");          // Tipo de Licencia
            item.SubItems.Add(numeroLicencia ?? "");        // Número de Licencia
            item.SubItems.Add(entregas ?? "0");             // Cantidad de Entregas
            item.SubItems.Add(calificacion ?? "0");         // Calificación Promedio
            item.SubItems.Add(estado ?? "");                // Estado
            return item;
        }

        private void LimpiarCamposRepartidor()
        {
            NombreRepartidor.Clear();
            NumeroTelefonoRepartidor.Clear();
            TipoLicencia.Text = PLACEHOLDER;
            NumeroLicencia.Text = "";
            NumeroLicencia.Enabled = true;
            EstadoDisponibilidad.Text = PLACEHOLDER;
            NombreRepartidor.Focus();
        }

        private void RegistrarRepartidor_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = NombreRepartidor.Text?.Trim();
                string telefono = NumeroTelefonoRepartidor.Text?.Trim();
                string tipoLicencia = TipoLicencia.Text?.Trim();
                string numeroLicencia = NumeroLicencia.Text?.Trim();

                bool esNA = !string.IsNullOrEmpty(tipoLicencia) &&
                    tipoLicencia.Equals("N/A", StringComparison.OrdinalIgnoreCase);

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono) ||
                    string.IsNullOrEmpty(tipoLicencia) || tipoLicencia.Equals(PLACEHOLDER, StringComparison.OrdinalIgnoreCase) ||
                    string.IsNullOrEmpty(numeroLicencia))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Datos incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarTelefono(telefono))
                {
                    MessageBox.Show("El número de teléfono debe contener exactamente 8 dígitos y no puede ser negativo.",
                        "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NumeroTelefonoRepartidor.Focus();
                    return;
                }

                if (!esNA && !ValidarNumeroLicencia(numeroLicencia))
                {
                    MessageBox.Show("El número de licencia debe contener exactamente 13 dígitos y no puede ser negativo.",
                        "Número de licencia inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NumeroLicencia.Focus();
                    return;
                }

                var r = new Repartidor
                {
                    Nombre = nombre,
                    Telefono = telefono
                };

                r.Disponible = true;
                r.Licencias = new List<string> { tipoLicencia };
                r.NumeroLicencia = esNA ? "N/A" : numeroLicencia;
                r = InMemoryStore.AddRepartidor(r);

                var item = CrearItemRepartidor(r.Id, r.Nombre, r.Telefono, tipoLicencia,
                    r.NumeroLicencia, r.CantidadEntregasRealizadas.ToString(), r.CalificacionPromedio.ToString("F2"), ESTADO_INICIAL);
                IvRegistroReparidores.Items.Add(item);

                LimpiarCamposRepartidor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar repartidor: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarCamposRepartidor();
            _idRepartidorEnEdicion = -1;
            IvRegistroReparidores.SelectedIndices.Clear();
            registrarRepartidor.Enabled = true;
            ActualizarRepartidor.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idRepartidorEnEdicion == -1)
                {
                    MessageBox.Show("Debe seleccionar un repartidor de la lista antes de actualizar.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombre = NombreRepartidor.Text?.Trim();
                string telefono = NumeroTelefonoRepartidor.Text?.Trim();
                string tipoLicencia = TipoLicencia.Text?.Trim();
                string numeroLicencia = NumeroLicencia.Text?.Trim();
                string estadoTexto = EstadoDisponibilidad.Text?.Trim();

                bool esNA = !string.IsNullOrEmpty(tipoLicencia) &&
                    tipoLicencia.Equals("N/A", StringComparison.OrdinalIgnoreCase);

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono) ||
                    string.IsNullOrEmpty(tipoLicencia) || tipoLicencia.Equals(PLACEHOLDER, StringComparison.OrdinalIgnoreCase) ||
                    string.IsNullOrEmpty(numeroLicencia) ||
                    string.IsNullOrEmpty(estadoTexto) || estadoTexto.Equals(PLACEHOLDER, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Datos incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarTelefono(telefono))
                {
                    MessageBox.Show("El número de teléfono debe contener exactamente 8 dígitos y no puede ser negativo.",
                        "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NumeroTelefonoRepartidor.Focus();
                    return;
                }

                if (!esNA && !ValidarNumeroLicencia(numeroLicencia))
                {
                    MessageBox.Show("El número de licencia debe contener exactamente 13 dígitos y no puede ser negativo.",
                        "Número de licencia inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NumeroLicencia.Focus();
                    return;
                }

                var repartidor = InMemoryStore.GetRepartidores().FirstOrDefault(x => x.Id == _idRepartidorEnEdicion);
                if (repartidor == null)
                {
                    MessageBox.Show("No se encontró el repartidor a actualizar.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                repartidor.Nombre = nombre;
                repartidor.Telefono = telefono;
                repartidor.Licencias = new List<string> { tipoLicencia };
                repartidor.NumeroLicencia = esNA ? "N/A" : numeroLicencia;

                repartidor.Disponible = estadoTexto.Equals("DISPONIBLE", StringComparison.OrdinalIgnoreCase);

                foreach (ListViewItem item in IvRegistroReparidores.Items)
                {
                    if (item.Text == _idRepartidorEnEdicion.ToString())
                    {
                        item.SubItems[1].Text = nombre;
                        item.SubItems[2].Text = telefono;
                        item.SubItems[3].Text = tipoLicencia;
                        item.SubItems[4].Text = esNA ? "N/A" : numeroLicencia;
                        item.SubItems[7].Text = estadoTexto.ToUpper();
                        break;
                    }
                }

                MessageBox.Show("Repartidor actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCamposRepartidor();
                _idRepartidorEnEdicion = -1;
                IvRegistroReparidores.SelectedIndices.Clear();
                registrarRepartidor.Enabled = true;
                ActualizarRepartidor.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar repartidor: " + ex.Message);
            }
        }

        private void IvRegistroReparidores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IvRegistroReparidores.SelectedItems.Count == 0)
                return;

            var item = IvRegistroReparidores.SelectedItems[0];

            if (!int.TryParse(item.Text, out int id))
                return;

            _idRepartidorEnEdicion = id;

            string nombreGuardado = item.SubItems[1].Text;
            string telefonoGuardado = item.SubItems[2].Text;
            string tipoLicenciaGuardado = item.SubItems[3].Text;
            string numeroLicenciaGuardado = item.SubItems[4].Text;
            string estadoGuardado = item.SubItems[7].Text;

            NombreRepartidor.Text = nombreGuardado;
            NumeroTelefonoRepartidor.Text = telefonoGuardado;
            TipoLicencia.Text = tipoLicenciaGuardado;
            EstadoDisponibilidad.Text = estadoGuardado; 

            bool esNA = tipoLicenciaGuardado.Trim().Equals("N/A", StringComparison.OrdinalIgnoreCase);
            if (esNA)
            {
                NumeroLicencia.Enabled = false;
                NumeroLicencia.Text = "N/A";
            }
            else
            {
                NumeroLicencia.Enabled = true;
                NumeroLicencia.Text = numeroLicenciaGuardado;
            }

            registrarRepartidor.Enabled = false;
            ActualizarRepartidor.Enabled = true;
        }

        private void NombreRepartidor_TextChanged(object sender, EventArgs e)
        {

        }

        private void NumeroTelefonoRepartidor_TextChanged(object sender, EventArgs e)
        {

        }

        private void NumeroLicencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void EstadoDisponibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}