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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            this.CenterToScreen();

            // Añadir botón dinámico para abrir la ventana de reportes
            try
            {
                var btnReports = new Button();
                btnReports.Name = "btnReports";
                btnReports.Text = "Reportes";
                btnReports.Width = 100;
                // Posicionar en la parte superior derecha teniendo en cuenta el tamaño del formulario
                btnReports.Left = Math.Max(10, this.ClientSize.Width - btnReports.Width - 10);
                btnReports.Top = 10;
                btnReports.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnReports.Click += (s, e) => {
                    try { new ReportsForm().Show(); } catch { }
                };
                this.Controls.Add(btnReports);
            }
            catch
            {
                // ignorar si no se puede crear el control dinámicamente
            }
        }

        // Simple prompt dialog para pedir texto al usuario
        private string Prompt(string title, string prompt)
        {
            using (var form = new Form())
            {
                form.Width = 400;
                form.Height = 150;
                form.Text = title;
                form.StartPosition = FormStartPosition.CenterParent;

                var lbl = new Label() { Left = 10, Top = 10, Text = prompt, Width = 360 };
                var txt = new TextBox() { Left = 10, Top = 35, Width = 360 };
                var btnOk = new Button() { Text = "OK", Left = 200, Width = 80, Top = 65, DialogResult = DialogResult.OK };
                var btnCancel = new Button() { Text = "Cancelar", Left = 290, Width = 80, Top = 65, DialogResult = DialogResult.Cancel };
                form.Controls.Add(lbl);
                form.Controls.Add(txt);
                form.Controls.Add(btnOk);
                form.Controls.Add(btnCancel);
                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                var dr = form.ShowDialog();
                if (dr == DialogResult.OK) return txt.Text;
                return null;
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            /*La leyenda cuenta que el lethercaacers*/
            // Asegurar que los botones añadidos por código estén visibles en tiempo de ejecución
            try
            {
                if (this.btnOpenDetalle != null)
                {
                    this.btnOpenDetalle.Visible = true;
                    this.btnOpenDetalle.BringToFront();
                }
                if (this.btnResetData != null)
                {
                    this.btnResetData.Visible = true;
                    this.btnResetData.BringToFront();
                }
            }
            catch
            {
                // ignorar
            }
        }

        private void GestionClientes_Click(object sender, EventArgs e)
        {
            GestionClientes EnviaraGestionCliente = new GestionClientes();
            EnviaraGestionCliente.Show();

        }

        private void GestionRepartidores_Click(object sender, EventArgs e)
        {
            GestionRepartidores EnviaraGestionRepartidor = new GestionRepartidores();
            EnviaraGestionRepartidor.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void GestionVehiculos_Click(object sender, EventArgs e)
        {
            GestionVehiculos EnviaraGestionVehiculos = new GestionVehiculos();
            EnviaraGestionVehiculos.Show();

        }

        private void GestionPaquetes_Click(object sender, EventArgs e)
        {
            GestionPaquetes EnviaraGestionPaquetes = new GestionPaquetes();
            EnviaraGestionPaquetes.Show();
        }

        private void GestionEntregas_Click(object sender, EventArgs e)
        {
            GestionEntregas EnviaraGestionEntregas = new GestionEntregas();
            EnviaraGestionEntregas.Show();
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("¿Desea reiniciar y borrar los datos guardados? Esta acción no se puede deshacer.", "Confirmar reinicio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                InMemoryStore.ResetData();
                MessageBox.Show("Los datos se han reiniciado correctamente.", "Reiniciado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var input = Prompt("Abrir detalle de entrega", "Ingrese el ID de la entrega:");
                if (string.IsNullOrWhiteSpace(input)) return;
                if (!int.TryParse(input.Trim(), out int id))
                {
                    MessageBox.Show("ID inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var entrega = InMemoryStore.GetEntregas().FirstOrDefault(x => x.Id == id);
                if (entrega == null)
                {
                    MessageBox.Show("No se encontró la entrega con ese ID.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var dlg = new DetalleEntrega(entrega))
                {
                    dlg.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error abriendo detalle: " + ex.Message);
            }
        }
    }
}