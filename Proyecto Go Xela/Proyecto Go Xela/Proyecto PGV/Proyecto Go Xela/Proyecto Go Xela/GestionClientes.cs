using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Go_Xela
{
    public partial class GestionClientes : Form
    {

        private int _idClienteEnEdicion = -1;

        public GestionClientes()
        {
            InitializeComponent();
        }

        private void GestionClientes_Load(object sender, EventArgs e)
        {

            RegistrarCliente.Click += RegistrarCliente_Click;


            CancelarRegistroCliente.Click += CancelarRegistroCliente_Click;


            ActualizarCliente.Click += ActualizarCliente_Click;


            ActualizarCliente.Enabled = false;


            foreach (var c in InMemoryStore.GetClientes())
            {
                var item = new ListViewItem(c.Id.ToString());
                item.SubItems.Add(c.Nombre);
                item.SubItems.Add(c.Telefono);
                item.SubItems.Add(c.CorreoElectronico ?? "");
                item.SubItems.Add(c.Direccion.ToString());
                item.SubItems.Add(c.CantidadSolicitudes.ToString());
                listView1.Items.Add(item);
            }
        }

        private void RegistrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = NombreCliente.Text?.Trim();
                string telefono = NumeroTelefonoCliente.Text?.Trim();
                string correo = CorreoElectronicoCliente.Text?.Trim();
                string direccion = DireccionClinete.Text?.Trim();

                if (string.IsNullOrEmpty(nombre) ||
                    string.IsNullOrEmpty(telefono) ||
                    string.IsNullOrEmpty(correo) ||
                    string.IsNullOrEmpty(direccion))
                {
                    MessageBox.Show("Todos los campos son obligatorios. Por favor complete la información antes de registrar.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(telefono, @"^\d{1,8}$"))
                {
                    MessageBox.Show("El número de teléfono debe contener solo dígitos, sin signos negativos, y no puede exceder 8 dígitos.",
                        "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NumeroTelefonoCliente.Focus();
                    return;
                }

                if (!correo.Contains("@"))
                {
                    MessageBox.Show("El correo electrónico debe contener al menos un símbolo '@'.",
                        "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CorreoElectronicoCliente.Focus();
                    return;
                }

                try
                {
                    var _ = new SecureClient(0, nombre, telefono);
                }
                catch (ValidationException vex)
                {
                    MessageBox.Show(vex.Message, "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var c = new Cliente
                {
                    Nombre = nombre,
                    Telefono = telefono,
                    EsPreferente = false,
                    CorreoElectronico = correo,
                    Direccion = new Address { Street = direccion },
                };
                c = InMemoryStore.AddCliente(c);

                var item = new ListViewItem(c.Id.ToString());
                item.SubItems.Add(c.Nombre);
                item.SubItems.Add(c.Telefono);
                item.SubItems.Add(correo);
                item.SubItems.Add(direccion);
                item.SubItems.Add(c.CantidadSolicitudes.ToString());
                listView1.Items.Add(item);

                MessageBox.Show("Cliente registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar cliente: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            NombreCliente.Clear();
            NumeroTelefonoCliente.Clear();
            CorreoElectronicoCliente.Clear();
            DireccionClinete.Clear();
            NombreCliente.Focus();
        }

        private void CancelarRegistroCliente_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

            _idClienteEnEdicion = -1;
            listView1.SelectedIndices.Clear();
            RegistrarCliente.Enabled = true;
            ActualizarCliente.Enabled = false;
        }

        private void ActualizarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idClienteEnEdicion == -1)
                {
                    MessageBox.Show("Debe seleccionar un cliente de la lista antes de actualizar.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombre = NombreCliente.Text?.Trim();
                string telefono = NumeroTelefonoCliente.Text?.Trim();
                string correo = CorreoElectronicoCliente.Text?.Trim();
                string direccion = DireccionClinete.Text?.Trim();

                if (string.IsNullOrEmpty(nombre) ||
                    string.IsNullOrEmpty(telefono) ||
                    string.IsNullOrEmpty(correo) ||
                    string.IsNullOrEmpty(direccion))
                {
                    MessageBox.Show("Todos los campos son obligatorios.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(telefono, @"^\d{1,8}$"))
                {
                    MessageBox.Show("El número de teléfono debe contener solo dígitos, sin signos negativos, y no puede exceder 8 dígitos.",
                        "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NumeroTelefonoCliente.Focus();
                    return;
                }

                if (!correo.Contains("@"))
                {
                    MessageBox.Show("El correo electrónico debe contener al menos un símbolo '@'.",
                        "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CorreoElectronicoCliente.Focus();
                    return;
                }

                var cliente = InMemoryStore.GetClientes().FirstOrDefault(c => c.Id == _idClienteEnEdicion);
                if (cliente != null)
                {
                    cliente.Nombre = nombre;
                    cliente.Telefono = telefono;
                    cliente.CorreoElectronico = correo;
                    cliente.Direccion = new Address { Street = direccion };
                }

                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Text == _idClienteEnEdicion.ToString())
                    {
                        item.SubItems[1].Text = nombre;
                        item.SubItems[2].Text = telefono;
                        item.SubItems[3].Text = correo;
                        item.SubItems[4].Text = direccion;
                        break;
                    }
                }

                MessageBox.Show("Cliente actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                _idClienteEnEdicion = -1;
                listView1.SelectedIndices.Clear();
                RegistrarCliente.Enabled = true;
                ActualizarCliente.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cliente: " + ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CorreoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void NombreRepartidor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            var item = listView1.SelectedItems[0];

            if (int.TryParse(item.Text, out int id))
            {
                _idClienteEnEdicion = id;
            }

            NombreCliente.Text = item.SubItems.Count > 1 ? item.SubItems[1].Text : "";
            NumeroTelefonoCliente.Text = item.SubItems.Count > 2 ? item.SubItems[2].Text : "";
            CorreoElectronicoCliente.Text = item.SubItems.Count > 3 ? item.SubItems[3].Text : "";
            DireccionClinete.Text = item.SubItems.Count > 4 ? item.SubItems[4].Text : "";

            RegistrarCliente.Enabled = false;
            ActualizarCliente.Enabled = true;
        }

        private void NumeroTelefonoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void CorreoElectronicoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void DireccionClinete_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarCliente_Click_1(object sender, EventArgs e)
        {

        }

        private void CancelarCliente(object sender, EventArgs e)
        {

        }
    }
}