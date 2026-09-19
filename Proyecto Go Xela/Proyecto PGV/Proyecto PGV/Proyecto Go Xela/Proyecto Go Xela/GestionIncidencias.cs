using System;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Go_Xela
{

    public class GestionIncidencias : Form
    {
        private ListView lvIncidencias;
        private Button btnActualizarEstado, btnRefrescar;
        private ComboBox cbEstado;
        private TextBox txtAccion;
        private Label lblEstado, lblAccion;

        public GestionIncidencias()
        {
            InitializeComponent();
            CargarIncidencias();
        }

        private void InitializeComponent()
        {
            this.Text = "Gestión de incidencias";
            this.Size = new System.Drawing.Size(900, 520);
            this.StartPosition = FormStartPosition.CenterParent;

            lvIncidencias = new ListView
            {
                Left = 10,
                Top = 10,
                Width = 865,
                Height = 350,
                View = View.Details,
                FullRowSelect = true,
                HideSelection = false
            };
            lvIncidencias.Columns.Add("Código", 90);
            lvIncidencias.Columns.Add("Entrega", 70);
            lvIncidencias.Columns.Add("Tipo", 150);
            lvIncidencias.Columns.Add("Descripción", 230);
            lvIncidencias.Columns.Add("Fecha", 120);
            lvIncidencias.Columns.Add("Estado", 90);
            lvIncidencias.Columns.Add("Acción tomada", 105);
            lvIncidencias.SelectedIndexChanged += LvIncidencias_SelectedIndexChanged;

            lblEstado = new Label { Left = 10, Top = 375, Width = 60, Text = "Estado:" };
            cbEstado = new ComboBox { Left = 75, Top = 371, Width = 130, DropDownStyle = ComboBoxStyle.DropDownList };
            cbEstado.Items.AddRange(Enum.GetNames(typeof(IncidenciaEstado)));

            lblAccion = new Label { Left = 220, Top = 375, Width = 90, Text = "Acción tomada:" };
            txtAccion = new TextBox { Left = 315, Top = 371, Width = 300 };

            btnActualizarEstado = new Button { Left = 625, Top = 369, Width = 120, Height = 28, Text = "Guardar cambios" };
            btnActualizarEstado.Click += BtnActualizarEstado_Click;

            btnRefrescar = new Button { Left = 755, Top = 369, Width = 120, Height = 28, Text = "Refrescar" };
            btnRefrescar.Click += (s, e) => CargarIncidencias();

            var lblAyuda = new Label
            {
                Left = 10,
                Top = 410,
                Width = 865,
                Height = 40,
                ForeColor = System.Drawing.Color.DimGray,
                Text = "Seleccione una incidencia de la lista para editar su estado y la acción tomada. " +
                       "Para editar el detalle completo de la entrega (estado de la entrega, calificación), " +
                       "use \"Ver / Editar entrega\" desde Gestión de Entregas."
            };

            this.Controls.Add(lvIncidencias);
            this.Controls.Add(lblEstado);
            this.Controls.Add(cbEstado);
            this.Controls.Add(lblAccion);
            this.Controls.Add(txtAccion);
            this.Controls.Add(btnActualizarEstado);
            this.Controls.Add(btnRefrescar);
            this.Controls.Add(lblAyuda);
        }

        private void CargarIncidencias()
        {
            lvIncidencias.Items.Clear();

            var entregas = InMemoryStore.GetEntregas();
            foreach (var entrega in entregas)
            {
                if (entrega.Incidencias == null) continue;

                foreach (var inc in entrega.Incidencias)
                {
                    var item = new ListViewItem(inc.Codigo);
                    item.SubItems.Add(entrega.Id.ToString());
                    item.SubItems.Add(inc.Tipo.ToString());
                    item.SubItems.Add(inc.Descripcion ?? "");
                    item.SubItems.Add(inc.Fecha.ToString("g"));
                    item.SubItems.Add(inc.Estado.ToString());
                    item.SubItems.Add(inc.AccionTomada ?? "");
                    item.Tag = new Tuple<Entrega, Incidencia>(entrega, inc);
                    lvIncidencias.Items.Add(item);
                }
            }

            cbEstado.SelectedIndex = -1;
            txtAccion.Clear();
        }

        private void LvIncidencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvIncidencias.SelectedItems.Count == 0) return;

            var tag = lvIncidencias.SelectedItems[0].Tag as Tuple<Entrega, Incidencia>;
            if (tag == null) return;

            var inc = tag.Item2;
            cbEstado.SelectedItem = inc.Estado.ToString();
            txtAccion.Text = inc.AccionTomada ?? "";
        }

        private void BtnActualizarEstado_Click(object sender, EventArgs e)
        {
            if (lvIncidencias.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione una incidencia de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbEstado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un estado.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tag = lvIncidencias.SelectedItems[0].Tag as Tuple<Entrega, Incidencia>;
            if (tag == null) return;

            var inc = tag.Item2;
            if (Enum.TryParse<IncidenciaEstado>(cbEstado.SelectedItem.ToString(), out var nuevoEstado))
            {
                inc.Estado = nuevoEstado;
            }
            inc.AccionTomada = txtAccion.Text?.Trim();

            InMemoryStore.Save();

            MessageBox.Show("Incidencia actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarIncidencias();
        }
    }
}
