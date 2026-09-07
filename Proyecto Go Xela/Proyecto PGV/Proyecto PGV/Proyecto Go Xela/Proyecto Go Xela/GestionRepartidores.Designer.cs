namespace Proyecto_Go_Xela
{
    partial class GestionRepartidores
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
            this.ActualizarRepartidor = new System.Windows.Forms.Button();
            this.EstadoDisponibilidad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.registrarRepartidor = new System.Windows.Forms.Button();
            this.TipoLicencia = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.NombreRepartidor = new System.Windows.Forms.TextBox();
            this.NombreCliente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NumeroLicencia = new System.Windows.Forms.TextBox();
            this.NumeroTelefonoRepartidor = new System.Windows.Forms.TextBox();
            this.IvRegistroReparidores = new System.Windows.Forms.ListView();
            this.MostrarCodigoRepartidor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarNombreRepartidor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarTelefonoRepartidor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarTipoLicencia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CantidadEntregas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CalificaciónPromedio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LicenciaNumero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EstadoRepartidor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(568, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(532, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTION DE REPARTIDORES";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ActualizarRepartidor);
            this.groupBox1.Controls.Add(this.EstadoDisponibilidad);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.registrarRepartidor);
            this.groupBox1.Controls.Add(this.TipoLicencia);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Controls.Add(this.NombreRepartidor);
            this.groupBox1.Controls.Add(this.NombreCliente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NumeroLicencia);
            this.groupBox1.Controls.Add(this.NumeroTelefonoRepartidor);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 510);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DEL REPARTIDOR: ";
            // 
            // ActualizarRepartidor
            // 
            this.ActualizarRepartidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActualizarRepartidor.Location = new System.Drawing.Point(279, 411);
            this.ActualizarRepartidor.Name = "ActualizarRepartidor";
            this.ActualizarRepartidor.Size = new System.Drawing.Size(130, 49);
            this.ActualizarRepartidor.TabIndex = 13;
            this.ActualizarRepartidor.Text = "ACTUALIZAR";
            this.ActualizarRepartidor.UseVisualStyleBackColor = true;
            this.ActualizarRepartidor.Click += new System.EventHandler(this.button2_Click);
            // 
            // EstadoDisponibilidad
            // 
            this.EstadoDisponibilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.EstadoDisponibilidad.FormattingEnabled = true;
            this.EstadoDisponibilidad.Items.AddRange(new object[] {
            "DISPONIBLE",
            "ASIGNADO",
            "FUERA DE SERVICIO"});
            this.EstadoDisponibilidad.Location = new System.Drawing.Point(6, 345);
            this.EstadoDisponibilidad.Name = "EstadoDisponibilidad";
            this.EstadoDisponibilidad.Size = new System.Drawing.Size(346, 26);
            this.EstadoDisponibilidad.TabIndex = 10;
            this.EstadoDisponibilidad.Text = "SELECCIONE UNA OPCIÓN";
            this.EstadoDisponibilidad.SelectedIndexChanged += new System.EventHandler(this.EstadoDisponibilidad_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "ESTADO DE DISPONIBILIDAD: ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(143, 411);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(130, 49);
            this.button1.TabIndex = 12;
            this.button1.Text = "CANCELAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // registrarRepartidor
            // 
            this.registrarRepartidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrarRepartidor.Location = new System.Drawing.Point(8, 411);
            this.registrarRepartidor.Name = "registrarRepartidor";
            this.registrarRepartidor.Size = new System.Drawing.Size(130, 49);
            this.registrarRepartidor.TabIndex = 11;
            this.registrarRepartidor.Text = "REGISTRAR";
            this.registrarRepartidor.UseVisualStyleBackColor = true;
            // 
            // TipoLicencia
            // 
            this.TipoLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoLicencia.FormattingEnabled = true;
            this.TipoLicencia.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "N/A"});
            this.TipoLicencia.Location = new System.Drawing.Point(6, 202);
            this.TipoLicencia.Name = "TipoLicencia";
            this.TipoLicencia.Size = new System.Drawing.Size(346, 33);
            this.TipoLicencia.TabIndex = 8;
            this.TipoLicencia.Text = "SELECCIONE UNA OPCIÓN";
            this.TipoLicencia.SelectedIndexChanged += new System.EventHandler(this.TipoLicencia_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(3, 183);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(138, 16);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "TIPO DE LICENICA";
            // 
            // NombreRepartidor
            // 
            this.NombreRepartidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreRepartidor.Location = new System.Drawing.Point(6, 52);
            this.NombreRepartidor.Name = "NombreRepartidor";
            this.NombreRepartidor.Size = new System.Drawing.Size(340, 30);
            this.NombreRepartidor.TabIndex = 1;
            this.NombreRepartidor.TextChanged += new System.EventHandler(this.NombreRepartidor_TextChanged);
            // 
            // NombreCliente
            // 
            this.NombreCliente.AutoSize = true;
            this.NombreCliente.Location = new System.Drawing.Point(7, 33);
            this.NombreCliente.Name = "NombreCliente";
            this.NombreCliente.Size = new System.Drawing.Size(216, 16);
            this.NombreCliente.TabIndex = 0;
            this.NombreCliente.Text = "NOMBRE DEL REPARTIDOR: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "NUMERO DE LICENCIA: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "NUMERO DE TELEFONO: ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // NumeroLicencia
            // 
            this.NumeroLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumeroLicencia.Location = new System.Drawing.Point(6, 283);
            this.NumeroLicencia.Name = "NumeroLicencia";
            this.NumeroLicencia.Size = new System.Drawing.Size(340, 30);
            this.NumeroLicencia.TabIndex = 7;
            this.NumeroLicencia.TextChanged += new System.EventHandler(this.NumeroLicencia_TextChanged);
            // 
            // NumeroTelefonoRepartidor
            // 
            this.NumeroTelefonoRepartidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumeroTelefonoRepartidor.Location = new System.Drawing.Point(6, 133);
            this.NumeroTelefonoRepartidor.Name = "NumeroTelefonoRepartidor";
            this.NumeroTelefonoRepartidor.Size = new System.Drawing.Size(340, 30);
            this.NumeroTelefonoRepartidor.TabIndex = 3;
            this.NumeroTelefonoRepartidor.TextChanged += new System.EventHandler(this.NumeroTelefonoRepartidor_TextChanged);
            // 
            // IvRegistroReparidores
            // 
            this.IvRegistroReparidores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MostrarCodigoRepartidor,
            this.MostrarNombreRepartidor,
            this.MostrarTelefonoRepartidor,
            this.MostrarTipoLicencia,
            this.LicenciaNumero,
            this.CantidadEntregas,
            this.CalificaciónPromedio,
            this.EstadoRepartidor});
            this.IvRegistroReparidores.HideSelection = false;
            this.IvRegistroReparidores.Location = new System.Drawing.Point(486, 104);
            this.IvRegistroReparidores.Name = "IvRegistroReparidores";
            this.IvRegistroReparidores.Size = new System.Drawing.Size(967, 426);
            this.IvRegistroReparidores.TabIndex = 2;
            this.IvRegistroReparidores.UseCompatibleStateImageBehavior = false;
            this.IvRegistroReparidores.View = System.Windows.Forms.View.Details;
            this.IvRegistroReparidores.SelectedIndexChanged += new System.EventHandler(this.IvRegistroReparidores_SelectedIndexChanged);
            // 
            // MostrarCodigoRepartidor
            // 
            this.MostrarCodigoRepartidor.Text = "Codigo: ";
            this.MostrarCodigoRepartidor.Width = 110;
            // 
            // MostrarNombreRepartidor
            // 
            this.MostrarNombreRepartidor.Text = "Nombre:";
            this.MostrarNombreRepartidor.Width = 134;
            // 
            // MostrarTelefonoRepartidor
            // 
            this.MostrarTelefonoRepartidor.Text = "Telefono:";
            this.MostrarTelefonoRepartidor.Width = 140;
            // 
            // MostrarTipoLicencia
            // 
            this.MostrarTipoLicencia.Text = "Tipo De Licencia: ";
            this.MostrarTipoLicencia.Width = 212;
            // 
            // CantidadEntregas
            // 
            this.CantidadEntregas.DisplayIndex = 4;
            this.CantidadEntregas.Text = "Cantidad de entregas:";
            this.CantidadEntregas.Width = 163;
            // 
            // CalificaciónPromedio
            // 
            this.CalificaciónPromedio.DisplayIndex = 5;
            this.CalificaciónPromedio.Text = "Calificación Promedio";
            this.CalificaciónPromedio.Width = 170;
            // 
            // LicenciaNumero
            // 
            this.LicenciaNumero.DisplayIndex = 6;
            this.LicenciaNumero.Text = "Numero de Licencia:";
            this.LicenciaNumero.Width = 147;
            // 
            // EstadoRepartidor
            // 
            this.EstadoRepartidor.Text = "Estado: ";
            // 
            // GestionRepartidores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1562, 757);
            this.Controls.Add(this.IvRegistroReparidores);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "GestionRepartidores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionRepartidores";
            this.Load += new System.EventHandler(this.GestionRepartidores_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label NombreCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NombreRepartidor;
        private System.Windows.Forms.TextBox NumeroTelefonoRepartidor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox NumeroLicencia;
        private System.Windows.Forms.ComboBox TipoLicencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox EstadoDisponibilidad;
        private System.Windows.Forms.ListView IvRegistroReparidores;
        private System.Windows.Forms.Button registrarRepartidor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader MostrarCodigoRepartidor;
        private System.Windows.Forms.ColumnHeader MostrarNombreRepartidor;
        private System.Windows.Forms.ColumnHeader MostrarTelefonoRepartidor;
        private System.Windows.Forms.ColumnHeader MostrarTipoLicencia;
        private System.Windows.Forms.ColumnHeader CalificaciónPromedio;
        private System.Windows.Forms.Button ActualizarRepartidor;
        private System.Windows.Forms.ColumnHeader LicenciaNumero;
        private System.Windows.Forms.ColumnHeader EstadoRepartidor;
        private System.Windows.Forms.ColumnHeader CantidadEntregas;
    }
}