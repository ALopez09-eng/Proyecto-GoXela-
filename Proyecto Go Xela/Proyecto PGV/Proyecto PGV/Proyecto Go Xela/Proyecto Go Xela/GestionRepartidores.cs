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

        // Id del repartidor seleccionado en el ListView para edición. -1 = modo "Registrar".
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

        // 2) Si el tipo de licencia es "N/A", bloquear el número de licencia con "N/A"; en cualquier otro caso, habilitarlo.
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
                // Si venía bloqueado con "N/A", lo limpiamos para que el usuario escriba el número real
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
            // Asociar evento del botón Registrar.
            // "button1" (Cancelar) y "ActualizarRepartidor" (Actualizar) ya están conectados desde
            // el Designer a button1_Click y button2_Click, así que solo llenamos sus cuerpos más abajo.
            registrarRepartidor.Click += RegistrarRepartidor_Click;

            ActualizarRepartidor.Enabled = false;

            // Cargar repartidores existentes en el ListView.
            // NOTA: Repartidor no guarda el número de licencia (solo el tipo en "Licencias"),
            // así que ese campo queda vacío al recargar desde el almacenamiento (ver aviso al final).
            foreach (var r in InMemoryStore.GetRepartidores())
            {
                string tipoLicenciaGuardado = (r.Licencias != null && r.Licencias.Count > 0) ? r.Licencias[0] : "";
                string estadoGuardado = r.Disponible ? "DISPONIBLE" : "ASIGNADO";

                var item = CrearItemRepartidor(r.Id, r.Nombre, r.Telefono, tipoLicenciaGuardado, "", "0", "0", estadoGuardado);
                IvRegistroReparidores.Items.Add(item);
            }
        }

        // ---------- Helpers ----------

        // 1) Teléfono positivo con exactamente 8 dígitos.
        private bool ValidarTelefono(string telefono)
        {
            return !string.IsNullOrEmpty(telefono) && telefono.Length == 8 && telefono.All(char.IsDigit);
        }

        // Número de licencia: exactamente 13 dígitos, ni más ni menos, sin signo negativo.
        private bool ValidarNumeroLicencia(string numero)
        {
            return !string.IsNullOrEmpty(numero) && numero.Length == 13 && numero.All(char.IsDigit);
        }

        // Columnas reales del ListView (según el Designer, por orden de índice -no de DisplayIndex-):
        // 0 Codigo, 1 Nombre, 2 Telefono, 3 TipoLicencia, 4 NumeroLicencia, 5 CantidadEntregas, 6 CalificacionPromedio, 7 Estado
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

                // Todos los campos son obligatorios
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono) ||
                    string.IsNullOrEmpty(tipoLicencia) || tipoLicencia.Equals(PLACEHOLDER, StringComparison.OrdinalIgnoreCase) ||
                    string.IsNullOrEmpty(numeroLicencia))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Datos incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1) Teléfono positivo, exactamente 8 dígitos
                if (!ValidarTelefono(telefono))
                {
                    MessageBox.Show("El número de teléfono debe contener exactamente 8 dígitos y no puede ser negativo.",
                        "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NumeroTelefonoRepartidor.Focus();
                    return;
                }

                // Número de licencia: exactamente 13 dígitos, sin signo negativo (no aplica si es "N/A")
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

                // 3) Siempre inicia DISPONIBLE, sin importar lo que tenga seleccionado el combo de Estado
                r.Disponible = true;
                r.Licencias = new List<string> { tipoLicencia };
                r = InMemoryStore.AddRepartidor(r);

                // 5) Mostrar en el ListView
                var item = CrearItemRepartidor(r.Id, r.Nombre, r.Telefono, tipoLicencia,
                    esNA ? "N/A" : numeroLicencia, "0", "0", ESTADO_INICIAL);
                IvRegistroReparidores.Items.Add(item);

                // 4) Limpiar el formulario para poder registrar otro repartidor
                LimpiarCamposRepartidor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar repartidor: " + ex.Message);
            }
        }

        // Botón "CANCELAR" (ya conectado en el Designer). Deja el GroupBox limpio y vuelve al modo "Registrar".
        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarCamposRepartidor();
            _idRepartidorEnEdicion = -1;
            IvRegistroReparidores.SelectedIndices.Clear();
            registrarRepartidor.Enabled = true;
            ActualizarRepartidor.Enabled = false;
        }

        // Botón "ACTUALIZAR" (control ActualizarRepartidor, ya conectado en el Designer a este método).
        // Valida, actualiza el repartidor en InMemoryStore y refleja los cambios en el ListView.
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

                // Número de licencia: exactamente 13 dígitos, sin signo negativo (no aplica si es "N/A")
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

                // 3) En edición sí se permite cambiar el estado según lo seleccionado en el combo
                repartidor.Disponible = estadoTexto.Equals("DISPONIBLE", StringComparison.OrdinalIgnoreCase);

                // Reflejar los cambios en la fila del ListView
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

        // 5) Al seleccionar una fila, cargar sus datos en el GroupBox y pasar a modo edición
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
            EstadoDisponibilidad.Text = estadoGuardado; // 3) En edición sí se puede ver/cambiar el estado

            // 2) Forzar el estado correcto del número de licencia según el tipo real
            // (al asignar Text por código, el combo no siempre dispara SelectedIndexChanged)
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

            // Bloquear Registrar y habilitar Cancelar/Actualizar (modo edición)
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