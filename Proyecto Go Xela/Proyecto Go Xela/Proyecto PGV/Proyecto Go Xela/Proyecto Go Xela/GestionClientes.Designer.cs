namespace Proyecto_Go_Xela
{
    partial class GestionClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ActualizarCliente = new System.Windows.Forms.Button();
            this.RegistrarCliente = new System.Windows.Forms.Button();
            this.DireccionClinete = new System.Windows.Forms.TextBox();
            this.CorreoElectronicoCliente = new System.Windows.Forms.TextBox();
            this.NumeroTelefonoCliente = new System.Windows.Forms.TextBox();
            this.NombreCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.MostrarCodigoCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarNombreCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarNumeroCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarCorreoCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarDireccionCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarCantidadSolicitudes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CancelarRegistroCliente = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(655, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTION DE CLIENTES";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CancelarRegistroCliente);
            this.groupBox1.Controls.Add(this.ActualizarCliente);
            this.groupBox1.Controls.Add(this.RegistrarCliente);
            this.groupBox1.Controls.Add(this.DireccionClinete);
            this.groupBox1.Controls.Add(this.CorreoElectronicoCliente);
            this.groupBox1.Controls.Add(this.NumeroTelefonoCliente);
            this.groupBox1.Controls.Add(this.NombreCliente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(38, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 639);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DEL CLIENTE";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ActualizarCliente
            // 
            this.ActualizarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActualizarCliente.Location = new System.Drawing.Point(283, 416);
            this.ActualizarCliente.Name = "ActualizarCliente";
            this.ActualizarCliente.Size = new System.Drawing.Size(130, 49);
            this.ActualizarCliente.TabIndex = 16;
            this.ActualizarCliente.Text = "ACTUALIZAR";
            this.ActualizarCliente.UseVisualStyleBackColor = true;
            this.ActualizarCliente.Click += new System.EventHandler(this.ActualizarCliente_Click);
            // 
            // RegistrarCliente
            // 
            this.RegistrarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegistrarCliente.Location = new System.Drawing.Point(12, 416);
            this.RegistrarCliente.Name = "RegistrarCliente";
            this.RegistrarCliente.Size = new System.Drawing.Size(130, 49);
            this.RegistrarCliente.TabIndex = 14;
            this.RegistrarCliente.Text = "REGISTRAR";
            this.RegistrarCliente.UseVisualStyleBackColor = true;
            this.RegistrarCliente.Click += new System.EventHandler(this.RegistrarCliente_Click_1);
            // 
            // DireccionClinete
            // 
            this.DireccionClinete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DireccionClinete.Location = new System.Drawing.Point(10, 291);
            this.DireccionClinete.Name = "DireccionClinete";
            this.DireccionClinete.Size = new System.Drawing.Size(340, 30);
            this.DireccionClinete.TabIndex = 9;
            this.DireccionClinete.TextChanged += new System.EventHandler(this.DireccionClinete_TextChanged);
            // 
            // CorreoElectronicoCliente
            // 
            this.CorreoElectronicoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CorreoElectronicoCliente.Location = new System.Drawing.Point(10, 211);
            this.CorreoElectronicoCliente.Name = "CorreoElectronicoCliente";
            this.CorreoElectronicoCliente.Size = new System.Drawing.Size(340, 30);
            this.CorreoElectronicoCliente.TabIndex = 8;
            this.CorreoElectronicoCliente.TextChanged += new System.EventHandler(this.CorreoElectronicoCliente_TextChanged);
            // 
            // NumeroTelefonoCliente
            // 
            this.NumeroTelefonoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumeroTelefonoCliente.Location = new System.Drawing.Point(10, 132);
            this.NumeroTelefonoCliente.Name = "NumeroTelefonoCliente";
            this.NumeroTelefonoCliente.Size = new System.Drawing.Size(340, 30);
            this.NumeroTelefonoCliente.TabIndex = 7;
            this.NumeroTelefonoCliente.TextChanged += new System.EventHandler(this.NumeroTelefonoCliente_TextChanged);
            // 
            // NombreCliente
            // 
            this.NombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreCliente.Location = new System.Drawing.Point(10, 55);
            this.NombreCliente.Name = "NombreCliente";
            this.NombreCliente.Size = new System.Drawing.Size(340, 30);
            this.NombreCliente.TabIndex = 2;
            this.NombreCliente.TextChanged += new System.EventHandler(this.NombreRepartidor_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "DIRECCIÓN: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "CORREO ELECTRONICO:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "NUMERO DE TELEFONO: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "NOMBRE COMPLETO: ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MostrarCodigoCliente,
            this.MostrarNombreCliente,
            this.MostrarNumeroCliente,
            this.MostrarCorreoCliente,
            this.MostrarDireccionCliente,
            this.MostrarCantidadSolicitudes});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(529, 87);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(895, 543);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // MostrarCodigoCliente
            // 
            this.MostrarCodigoCliente.Text = "Codigo:";
            this.MostrarCodigoCliente.Width = 108;
            // 
            // MostrarNombreCliente
            // 
            this.MostrarNombreCliente.Text = "Nombre completo";
            // 
            // MostrarNumeroCliente
            // 
            this.MostrarNumeroCliente.Text = "Número de teléfono";
            // 
            // MostrarCorreoCliente
            // 
            this.MostrarCorreoCliente.Text = "CorreoElectronico";
            // 
            // MostrarDireccionCliente
            // 
            this.MostrarDireccionCliente.Text = "Cliente";
            // 
            // MostrarCantidadSolicitudes
            // 
            this.MostrarCantidadSolicitudes.Text = "Cantidad de Solicitudes";
            // 
            // CancelarRegistroCliente
            // 
            this.CancelarRegistroCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarRegistroCliente.Location = new System.Drawing.Point(148, 416);
            this.CancelarRegistroCliente.Name = "CancelarRegistroCliente";
            this.CancelarRegistroCliente.Size = new System.Drawing.Size(130, 49);
            this.CancelarRegistroCliente.TabIndex = 17;
            this.CancelarRegistroCliente.Text = "CANCELAR";
            this.CancelarRegistroCliente.UseVisualStyleBackColor = true;
            this.CancelarRegistroCliente.Click += new System.EventHandler(this.CancelarRegistroCliente_Click);
            // 
            // GestionClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1562, 757);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "GestionClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionClientes";
            this.Load += new System.EventHandler(this.GestionClientes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NombreCliente;
        private System.Windows.Forms.TextBox NumeroTelefonoCliente;
        private System.Windows.Forms.TextBox DireccionClinete;
        private System.Windows.Forms.TextBox CorreoElectronicoCliente;
        private System.Windows.Forms.Button ActualizarCliente;

        private System.Windows.Forms.Button RegistrarCliente;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader MostrarCodigoCliente;
        private System.Windows.Forms.ColumnHeader MostrarNombreCliente;
        private System.Windows.Forms.ColumnHeader MostrarNumeroCliente;
        private System.Windows.Forms.ColumnHeader MostrarCorreoCliente;
        private System.Windows.Forms.ColumnHeader MostrarDireccionCliente;
        private System.Windows.Forms.ColumnHeader MostrarCantidadSolicitudes;
        private System.Windows.Forms.Button CancelarRegistroCliente;
    }
}