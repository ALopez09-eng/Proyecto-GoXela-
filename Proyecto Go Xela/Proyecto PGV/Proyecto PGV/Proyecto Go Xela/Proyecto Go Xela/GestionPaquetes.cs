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
    public partial class GestionPaquetes : Form
    {
        private const string ESTADO_INICIAL = "EN CAMINO";
        private const string PLACEHOLDER = "SELECCIONE UNA OPCIÓN";

        // Id del paquete seleccionado en el ListView para edición. -1 = modo "Registrar".
        private int _idPaqueteEnEdicion = -1;

        public GestionPaquetes()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GestionPaquetes_Load(object sender, EventArgs e)
        {
            // "registrarRepartidor", "CancelarPaquete" y "ActualizarRepartidor" ya están conectados
            // desde el Designer a registrarRepartidor_Click, CancelarPaquete_Click y ActualizarRepartidor_Click.
            ActualizarRepartidor.Enabled = false;

            // Cargar paquetes existentes en el ListView (Paquete.Estado ya es un string, así que
            // aquí no hay pérdida de información al recargar, a diferencia de otros formularios).
            foreach (var p in InMemoryStore.GetPaquetes())
            {
                var item = CrearItemPaquete(p.Id, p.Descripcion, p.PesoKg, p.ValorDeclarado,
                    p.DireccionOrigen, p.DireccionDestino, p.Tipo.ToString(), p.Estado);
                IvRegistroPaquetes.Items.Add(item);
            }
        }

        // ---------- Helpers ----------

        // Columnas reales del ListView (por índice, no por DisplayIndex):
        // 0 Codigo, 1 Descripcion, 2 Peso, 3 ValorDeclarado, 4 DireccionOrigen, 5 DireccionDestino, 6 TipoPaquete, 7 Estado
        private ListViewItem CrearItemPaquete(int id, string descripcion, double peso, double valorDeclarado,
            string direccionOrigen, string direccionDestino, string tipo, string estado)
        {
            var item = new ListViewItem(id.ToString());       // Código
            item.SubItems.Add(descripcion ?? "");               // Descripción
            item.SubItems.Add($"{peso:F2} kg");                 // Peso
            item.SubItems.Add($"Q{valorDeclarado:F2}");         // Valor Declarado
            item.SubItems.Add(direccionOrigen ?? "");           // Dirección de Origen
            item.SubItems.Add(direccionDestino ?? "");          // Dirección de Destino
            item.SubItems.Add(tipo ?? "");                      // Tipo de Paquete
            item.SubItems.Add(estado ?? "");                    // Estado
            return item;
        }

        private void LimpiarCamposPaquete()
        {
            DescripciónPaquete.Clear();
            PesoPaquete.Clear();
            ValorDeclaradoPaquete.Clear();
            DireccionOrigenPaquete.Clear();
            DireccionDestinoPaquete.Clear();
            TipoPaquete.Text = PLACEHOLDER;
            EstadoPaquete.Text = PLACEHOLDER;
            DescripciónPaquete.Focus();
        }

        // Botón "REGISTRAR" (ya conectado en el Designer)
        private void registrarRepartidor_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = DescripciónPaquete.Text?.Trim();
                string pesoTexto = PesoPaquete.Text?.Trim();
                string valorTexto = ValorDeclaradoPaquete.Text?.Trim();
                string direccionOrigen = DireccionOrigenPaquete.Text?.Trim();
                string direccionDestino = DireccionDestinoPaquete.Text?.Trim();
                string tipoTexto = TipoPaquete.Text?.Trim();

                // 1) Todos los campos son obligatorios (el Estado NO se exige aquí: siempre
                // se fuerza a "EN CAMINO" al registrar, sin importar lo que tenga el combo)
                if (string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(pesoTexto) ||
                    string.IsNullOrEmpty(valorTexto) || string.IsNullOrEmpty(direccionOrigen) ||
                    string.IsNullOrEmpty(direccionDestino) ||
                    string.IsNullOrEmpty(tipoTexto) || tipoTexto.Equals(PLACEHOLDER, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Datos incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2) Peso y valor declarado positivos y mayores a 0
                if (!double.TryParse(pesoTexto, out double peso) || peso <= 0)
                {
                    MessageBox.Show("El peso debe ser un número positivo mayor a 0.",
                        "Peso inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PesoPaquete.Focus();
                    return;
                }

                if (!double.TryParse(valorTexto, out double valorDeclarado) || valorDeclarado <= 0)
                {
                    MessageBox.Show("El valor declarado debe ser un número positivo mayor a 0.",
                        "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ValorDeclaradoPaquete.Focus();
                    return;
                }

                // 3) Dirección de origen y destino no pueden ser iguales
                if (direccionOrigen.Equals(direccionDestino, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("La dirección de origen y destino no pueden ser iguales.",
                        "Direcciones inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DireccionDestinoPaquete.Focus();
                    return;
                }

                var p = new Paquete
                {
                    Descripcion = descripcion,
                    PesoKg = peso,
                    Dimensiones = "",
                    DireccionOrigen = direccionOrigen,
                    DireccionDestino = direccionDestino,
                    ValorDeclarado = valorDeclarado,
                    Estado = ESTADO_INICIAL, // 4) Siempre inicia "EN CAMINO", sin importar el combo de Estado
                    Tipo = PackageType.Normal
                };
                try { if (Enum.TryParse<PackageType>(tipoTexto, true, out var t)) p.Tipo = t; } catch { }

                p = InMemoryStore.AddPaquete(p);

                // 5) Mostrar en el ListView
                var item = CrearItemPaquete(p.Id, p.Descripcion, p.PesoKg, p.ValorDeclarado,
                    direccionOrigen, direccionDestino, tipoTexto.ToUpper(), ESTADO_INICIAL);
                IvRegistroPaquetes.Items.Add(item);

                LimpiarCamposPaquete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar paquete: " + ex.Message);
            }
        }

        private void DescripciónPaquete_TextChanged(object sender, EventArgs e)
        {

        }

        private void PesoPaquete_TextChanged(object sender, EventArgs e)
        {

        }

        private void ValorDeclaradoPaquete_TextChanged(object sender, EventArgs e)
        {

        }

        private void DireccionOrigenPaquete_TextChanged(object sender, EventArgs e)
        {

        }

        private void DireccionDestinoPaquete_TextChanged(object sender, EventArgs e)
        {

        }

        private void TipoPaquete_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EstadoPaquete_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Botón "CANCELAR" (ya conectado en el Designer). Deja el GroupBox limpio y vuelve al modo "Registrar".
        private void CancelarPaquete_Click(object sender, EventArgs e)
        {
            LimpiarCamposPaquete();
            _idPaqueteEnEdicion = -1;
            IvRegistroPaquetes.SelectedIndices.Clear();
            registrarRepartidor.Enabled = true;
            ActualizarRepartidor.Enabled = false;
        }

        // Botón "ACTUALIZAR" (ya conectado en el Designer).
        // Valida, actualiza el paquete en InMemoryStore y refleja los cambios en el ListView.
        private void ActualizarRepartidor_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idPaqueteEnEdicion == -1)
                {
                    MessageBox.Show("Debe seleccionar un paquete de la lista antes de actualizar.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string descripcion = DescripciónPaquete.Text?.Trim();
                string pesoTexto = PesoPaquete.Text?.Trim();
                string valorTexto = ValorDeclaradoPaquete.Text?.Trim();
                string direccionOrigen = DireccionOrigenPaquete.Text?.Trim();
                string direccionDestino = DireccionDestinoPaquete.Text?.Trim();
                string tipoTexto = TipoPaquete.Text?.Trim();
                string estadoTexto = EstadoPaquete.Text?.Trim();

                if (string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(pesoTexto) ||
                    string.IsNullOrEmpty(valorTexto) || string.IsNullOrEmpty(direccionOrigen) ||
                    string.IsNullOrEmpty(direccionDestino) ||
                    string.IsNullOrEmpty(tipoTexto) || tipoTexto.Equals(PLACEHOLDER, StringComparison.OrdinalIgnoreCase) ||
                    string.IsNullOrEmpty(estadoTexto) || estadoTexto.Equals(PLACEHOLDER, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Datos incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(pesoTexto, out double peso) || peso <= 0)
                {
                    MessageBox.Show("El peso debe ser un número positivo mayor a 0.",
                        "Peso inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PesoPaquete.Focus();
                    return;
                }

                if (!double.TryParse(valorTexto, out double valorDeclarado) || valorDeclarado <= 0)
                {
                    MessageBox.Show("El valor declarado debe ser un número positivo mayor a 0.",
                        "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ValorDeclaradoPaquete.Focus();
                    return;
                }

                if (direccionOrigen.Equals(direccionDestino, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("La dirección de origen y destino no pueden ser iguales.",
                        "Direcciones inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DireccionDestinoPaquete.Focus();
                    return;
                }

                var paquete = InMemoryStore.GetPaquetes().FirstOrDefault(x => x.Id == _idPaqueteEnEdicion);
                if (paquete == null)
                {
                    MessageBox.Show("No se encontró el paquete a actualizar.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                paquete.Descripcion = descripcion;
                paquete.PesoKg = peso;
                paquete.ValorDeclarado = valorDeclarado;
                paquete.DireccionOrigen = direccionOrigen;
                paquete.DireccionDestino = direccionDestino;
                try { if (Enum.TryParse<PackageType>(tipoTexto, true, out var t)) paquete.Tipo = t; } catch { }

                // 4) En edición sí se permite cambiar el estado según lo seleccionado en el combo
                paquete.Estado = estadoTexto;

                // Reflejar los cambios en la fila del ListView
                foreach (ListViewItem item in IvRegistroPaquetes.Items)
                {
                    if (item.Text == _idPaqueteEnEdicion.ToString())
                    {
                        item.SubItems[1].Text = descripcion;
                        item.SubItems[2].Text = $"{peso:F2} kg";
                        item.SubItems[3].Text = $"Q{valorDeclarado:F2}";
                        item.SubItems[4].Text = direccionOrigen;
                        item.SubItems[5].Text = direccionDestino;
                        item.SubItems[6].Text = tipoTexto.ToUpper();
                        item.SubItems[7].Text = estadoTexto.ToUpper();
                        break;
                    }
                }

                MessageBox.Show("Paquete actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCamposPaquete();
                _idPaqueteEnEdicion = -1;
                IvRegistroPaquetes.SelectedIndices.Clear();
                registrarRepartidor.Enabled = true;
                ActualizarRepartidor.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar paquete: " + ex.Message);
            }
        }

        // 5) Al seleccionar una fila, cargar sus datos en el GroupBox y pasar a modo edición
        private void IvRegistroPaquetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IvRegistroPaquetes.SelectedItems.Count == 0)
                return;

            var item = IvRegistroPaquetes.SelectedItems[0];

            if (!int.TryParse(item.Text, out int id))
                return;

            _idPaqueteEnEdicion = id;

            DescripciónPaquete.Text = item.SubItems[1].Text;
            PesoPaquete.Text = item.SubItems[2].Text.Replace("kg", "").Trim();
            ValorDeclaradoPaquete.Text = item.SubItems[3].Text.Replace("Q", "").Trim();
            DireccionOrigenPaquete.Text = item.SubItems[4].Text;
            DireccionDestinoPaquete.Text = item.SubItems[5].Text;
            TipoPaquete.Text = item.SubItems[6].Text;
            EstadoPaquete.Text = item.SubItems[7].Text; // 4) En edición sí se puede ver/cambiar el estado

            // Bloquear Registrar y habilitar Cancelar/Actualizar (modo edición)
            registrarRepartidor.Enabled = false;
            ActualizarRepartidor.Enabled = true;
        }
    }
}