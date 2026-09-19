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
            ActualizarRepartidor.Enabled = false;

            foreach (var p in InMemoryStore.GetPaquetes())
            {
                var item = CrearItemPaquete(p.Id, p.Descripcion, p.PesoKg, p.ValorDeclarado,
                    p.DireccionOrigen, p.DireccionDestino, p.Tipo.ToString(), p.Estado);
                IvRegistroPaquetes.Items.Add(item);
            }
        }


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

                if (string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(pesoTexto) ||
                    string.IsNullOrEmpty(valorTexto) || string.IsNullOrEmpty(direccionOrigen) ||
                    string.IsNullOrEmpty(direccionDestino) ||
                    string.IsNullOrEmpty(tipoTexto) || tipoTexto.Equals(PLACEHOLDER, StringComparison.OrdinalIgnoreCase))
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

                var p = new Paquete
                {
                    Descripcion = descripcion,
                    PesoKg = peso,
                    Dimensiones = "",
                    DireccionOrigen = direccionOrigen,
                    DireccionDestino = direccionDestino,
                    ValorDeclarado = valorDeclarado,
                    Estado = ESTADO_INICIAL, 
                    Tipo = PackageType.Normal
                };
                try { if (Enum.TryParse<PackageType>(tipoTexto, true, out var t)) p.Tipo = t; } catch { }

                p = InMemoryStore.AddPaquete(p);

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

        private void CancelarPaquete_Click(object sender, EventArgs e)
        {
            LimpiarCamposPaquete();
            _idPaqueteEnEdicion = -1;
            IvRegistroPaquetes.SelectedIndices.Clear();
            registrarRepartidor.Enabled = true;
            ActualizarRepartidor.Enabled = false;
        }

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

                paquete.Estado = estadoTexto;

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
            EstadoPaquete.Text = item.SubItems[7].Text;

            registrarRepartidor.Enabled = false;
            ActualizarRepartidor.Enabled = true;
        }
    }
}