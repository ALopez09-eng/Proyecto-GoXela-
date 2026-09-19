using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Go_Xela
{

    [System.ComponentModel.DesignerCategory("Code")]
    public class DetalleEntrega : Form
    {
        private Entrega _entrega;
        private Label lblCliente, lblPaquete, lblRepartidor, lblVehiculo, lblOrigen, lblDestino, lblDistancia, lblFechaSolicitud;
        private ComboBox cbEstado;
        private ComboBox cbCalificacion;
        private ListBox lbIncidencias;
        private TextBox txtNuevaIncidencia;
        private Button btnAddIncidencia, btnGuardar, btnCancelar;

        public DetalleEntrega(Entrega entrega)
        {
            _entrega = entrega ?? throw new ArgumentNullException(nameof(entrega));
            InitializeComponent();

            cbEstado.SelectedIndexChanged += CbEstado_SelectedIndexChanged;
            btnCancelar.Click += BtnCancelar_Click;

            LoadData();
        }

        private string FormatIncidencia(Incidencia inc)
        {
            if (inc == null) return "";
            return $"{inc.Codigo} | {inc.Tipo} | {inc.Estado} | {inc.Fecha:g} | {inc.Descripcion} | Acción: {inc.AccionTomada}";
        }

        private void InitializeComponent()
        {
            this.Text = "Detalle de entrega";
            this.Size = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            lblCliente = new Label() { Left = 10, Top = 10, Width = 560 };
            lblPaquete = new Label() { Left = 10, Top = 35, Width = 560 };
            lblRepartidor = new Label() { Left = 10, Top = 60, Width = 560 };
            lblVehiculo = new Label() { Left = 10, Top = 85, Width = 560 };
            lblOrigen = new Label() { Left = 10, Top = 110, Width = 560 };
            lblDestino = new Label() { Left = 10, Top = 135, Width = 560 };
            lblDistancia = new Label() { Left = 10, Top = 160, Width = 560 };
            lblFechaSolicitud = new Label() { Left = 10, Top = 185, Width = 560 };

            var lblEstado = new Label() { Left = 10, Top = 215, Width = 120, Text = "Estado:" };
            cbEstado = new ComboBox() { Left = 140, Top = 210, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblCalificacion = new Label() { Left = 355, Top = 215, Width = 95, Text = "Calificación:" };
            cbCalificacion = new ComboBox() { Left = 455, Top = 210, Width = 60, DropDownStyle = ComboBoxStyle.DropDownList };
            cbCalificacion.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });

            var lblInc = new Label() { Left = 10, Top = 320, Width = 200, Text = "Incidencias:" };
            lbIncidencias = new ListBox() { Left = 10, Top = 380, Width = 560, Height = 100 };

            var lblTipo = new Label() { Left = 10, Top = 340, Width = 80, Text = "Tipo:" };
            var cbTipoIncidencia = new ComboBox() { Left = 95, Top = 336, Width = 180, Name = "cbTipoIncidencia", DropDownStyle = ComboBoxStyle.DropDownList };
            cbTipoIncidencia.Items.AddRange(Enum.GetNames(typeof(IncidenciaTipo)));

            var lblAccion = new Label() { Left = 285, Top = 340, Width = 80, Text = "Acción:" };
            var txtAccion = new TextBox() { Left = 360, Top = 336, Width = 210, Name = "txtAccion" };

            var lblHist = new Label() { Left = 10, Top = 250, Width = 200, Text = "Historial de estados:" };
            var lbHistorial = new ListBox() { Left = 10, Top = 275, Width = 560, Height = 40, Name = "lbHistorial" };

            txtNuevaIncidencia = new TextBox() { Left = 10, Top = 488, Width = 430 };
            btnAddIncidencia = new Button() { Left = 450, Top = 486, Width = 120, Text = "Añadir" };
            btnAddIncidencia.Click += BtnAddIncidencia_Click;

            btnGuardar = new Button() { Left = 310, Top = 525, Width = 120, Text = "Guardar" };
            btnCancelar = new Button() { Left = 440, Top = 525, Width = 120, Text = "Cancelar" };
            btnGuardar.Click += BtnGuardar_Click;

            this.Controls.Add(lblCliente);
            this.Controls.Add(lblPaquete);
            this.Controls.Add(lblRepartidor);
            this.Controls.Add(lblVehiculo);
            this.Controls.Add(lblOrigen);
            this.Controls.Add(lblDestino);
            this.Controls.Add(lblDistancia);
            this.Controls.Add(lblFechaSolicitud);
            this.Controls.Add(lblEstado);
            this.Controls.Add(cbEstado);
            this.Controls.Add(lblCalificacion);
            this.Controls.Add(cbCalificacion);
            this.Controls.Add(lblHist);
            this.Controls.Add(lbHistorial);
            this.Controls.Add(lblInc);
            this.Controls.Add(lbIncidencias);
            this.Controls.Add(lblTipo);
            this.Controls.Add(cbTipoIncidencia);
            this.Controls.Add(lblAccion);
            this.Controls.Add(txtAccion);
            this.Controls.Add(txtNuevaIncidencia);
            this.Controls.Add(btnAddIncidencia);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnCancelar);
        }

        private void CbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCalificacion.Enabled = cbEstado.SelectedItem != null &&
                cbEstado.SelectedItem.ToString() == DeliveryStatus.Entregada.ToString();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadData()
        {
            lblCliente.Text = "Cliente: " + (_entrega.Cliente?.Nombre ?? "-");
            lblPaquete.Text = "Paquete: " + (_entrega.Paquete?.Descripcion ?? "-");
            lblRepartidor.Text = "Repartidor: " + (_entrega.Repartidor?.Nombre ?? "-");
            lblVehiculo.Text = "Vehículo: " + (_entrega.Vehiculo ?? "-");
            lblOrigen.Text = "Origen: " + (_entrega.Origen ?? "-");
            lblDestino.Text = "Destino: " + (_entrega.Destino ?? "-");
            lblDistancia.Text = "Distancia estimada (km): " + _entrega.DistanciaKm.ToString("F2");
            lblFechaSolicitud.Text = "Fecha de solicitud: " + _entrega.FechaSolicitud.ToString("g");

            cbEstado.Items.Clear();
            cbEstado.Items.Add(_entrega.Estado.ToString());
            var allowed = InMemoryStore.GetAllowedTransitions(_entrega.Estado);
            foreach (var st in allowed)
            {
                if (st.ToString() != _entrega.Estado.ToString()) cbEstado.Items.Add(st.ToString());
            }
            cbEstado.SelectedItem = _entrega.Estado.ToString();

            bool esEntregada = _entrega.Estado == DeliveryStatus.Entregada;
            cbCalificacion.Enabled = esEntregada;
            cbCalificacion.SelectedItem = _entrega.Calificacion.HasValue ? _entrega.Calificacion.Value.ToString() : null;
            bool esFinal = _entrega.Estado == DeliveryStatus.Entregada || _entrega.Estado == DeliveryStatus.Cancelada;
            btnAddIncidencia.Enabled = !esFinal;
            txtNuevaIncidencia.Enabled = !esFinal;

            var histControl = this.Controls.Find("lbHistorial", true).FirstOrDefault() as ListBox;
            if (histControl != null)
            {
                histControl.Items.Clear();
                if (_entrega.EstadoHistorial != null && _entrega.EstadoHistorial.Any())
                {
                    foreach (var h in _entrega.EstadoHistorial)
                    {
                        histControl.Items.Add($"{h.Timestamp:g} - {h.User}: {h.From} -> {h.To}");
                    }
                }
            }

            lbIncidencias.Items.Clear();
            if (_entrega.Incidencias != null && _entrega.Incidencias.Any())
            {
                foreach (var inc in _entrega.Incidencias)
                    lbIncidencias.Items.Add(FormatIncidencia(inc));
            }
            var cbTipo = this.Controls.Find("cbTipoIncidencia", true).FirstOrDefault() as ComboBox;
            var txtAcc = this.Controls.Find("txtAccion", true).FirstOrDefault() as TextBox;
            if (cbTipo != null) cbTipo.SelectedIndex = 0;
            if (txtAcc != null) txtAcc.Text = string.Empty;
        }

        private void BtnAddIncidencia_Click(object sender, EventArgs e)
        {
            if (_entrega.Estado == DeliveryStatus.Entregada || _entrega.Estado == DeliveryStatus.Cancelada)
            {
                MessageBox.Show("No se pueden agregar incidencias a una entrega ya finalizada o cancelada.",
                    "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var desc = txtNuevaIncidencia.Text?.Trim();
            if (string.IsNullOrEmpty(desc)) return;

            var cbTipo = this.Controls.Find("cbTipoIncidencia", true).FirstOrDefault() as ComboBox;
            var txtAcc = this.Controls.Find("txtAccion", true).FirstOrDefault() as TextBox;
            IncidenciaTipo tipo = IncidenciaTipo.ClienteAusente;
            if (cbTipo != null && cbTipo.SelectedItem != null)
            {
                Enum.TryParse<IncidenciaTipo>(cbTipo.SelectedItem.ToString(), out tipo);
            }

            var accion = txtAcc?.Text?.Trim();

            if (_entrega.Incidencias == null) _entrega.Incidencias = new List<Incidencia>();
            var code = $"E{_entrega.Id}-{_entrega.Incidencias.Count + 1}";
            var inc = new Incidencia
            {
                Codigo = code,
                Tipo = tipo,
                Descripcion = desc,
                Fecha = DateTime.Now,
                Estado = IncidenciaEstado.Abierta,
                AccionTomada = accion
            };
            _entrega.Incidencias.Add(inc);
            lbIncidencias.Items.Add(FormatIncidencia(inc));

            txtNuevaIncidencia.Clear();
            if (txtAcc != null) txtAcc.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cbEstado.SelectedItem != null)
            {
                if (Enum.TryParse<DeliveryStatus>(cbEstado.SelectedItem.ToString(), out var st))
                {
                    if (!InMemoryStore.TryChangeEntregaState(_entrega.Id, st, Environment.UserName, out var msg))
                    {
                        MessageBox.Show(msg ?? "Transición inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (cbCalificacion.Enabled && cbCalificacion.SelectedItem != null &&
                int.TryParse(cbCalificacion.SelectedItem.ToString(), out int calificacion))
            {
                if (!InMemoryStore.CalificarEntrega(_entrega.Id, calificacion, out var califMsg))
                {
                    MessageBox.Show(califMsg ?? "No se pudo registrar la calificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            InMemoryStore.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}