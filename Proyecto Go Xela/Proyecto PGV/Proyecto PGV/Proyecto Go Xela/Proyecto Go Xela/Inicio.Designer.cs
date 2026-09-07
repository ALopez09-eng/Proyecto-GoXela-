namespace Proyecto_Go_Xela
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.GestionClientes = new System.Windows.Forms.Button();
            this.GestionRepartidores = new System.Windows.Forms.Button();
            this.GestionVehiculos = new System.Windows.Forms.Button();
            this.GestionPaquetes = new System.Windows.Forms.Button();
            this.GestionEntregas = new System.Windows.Forms.Button();
            this.btnResetData = new System.Windows.Forms.Button();
            this.btnOpenDetalle = new System.Windows.Forms.Button();
            this.DetalleEntrega = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GestionClientes
            // 
            this.GestionClientes.Location = new System.Drawing.Point(177, 183);
            this.GestionClientes.Name = "GestionClientes";
            this.GestionClientes.Size = new System.Drawing.Size(296, 89);
            this.GestionClientes.TabIndex = 0;
            this.GestionClientes.Text = "Gestion de Clientes";
            this.GestionClientes.UseVisualStyleBackColor = true;
            this.GestionClientes.Click += new System.EventHandler(this.GestionClientes_Click);
            // 
            // GestionRepartidores
            // 
            this.GestionRepartidores.Location = new System.Drawing.Point(644, 358);
            this.GestionRepartidores.Name = "GestionRepartidores";
            this.GestionRepartidores.Size = new System.Drawing.Size(296, 89);
            this.GestionRepartidores.TabIndex = 1;
            this.GestionRepartidores.Text = "Gestion de Repartidores";
            this.GestionRepartidores.UseVisualStyleBackColor = true;
            this.GestionRepartidores.Click += new System.EventHandler(this.GestionRepartidores_Click);
            // 
            // GestionVehiculos
            // 
            this.GestionVehiculos.Location = new System.Drawing.Point(177, 358);
            this.GestionVehiculos.Name = "GestionVehiculos";
            this.GestionVehiculos.Size = new System.Drawing.Size(296, 89);
            this.GestionVehiculos.TabIndex = 2;
            this.GestionVehiculos.Text = "Gestion de Vehículos";
            this.GestionVehiculos.UseVisualStyleBackColor = true;
            this.GestionVehiculos.Click += new System.EventHandler(this.GestionVehiculos_Click);
            // 
            // GestionPaquetes
            // 
            this.GestionPaquetes.Location = new System.Drawing.Point(644, 552);
            this.GestionPaquetes.Name = "GestionPaquetes";
            this.GestionPaquetes.Size = new System.Drawing.Size(296, 89);
            this.GestionPaquetes.TabIndex = 3;
            this.GestionPaquetes.Text = "Gestion de Paquetes";
            this.GestionPaquetes.UseVisualStyleBackColor = true;
            this.GestionPaquetes.Click += new System.EventHandler(this.GestionPaquetes_Click);
            // 
            // GestionEntregas
            // 
            this.GestionEntregas.Location = new System.Drawing.Point(177, 552);
            this.GestionEntregas.Name = "GestionEntregas";
            this.GestionEntregas.Size = new System.Drawing.Size(296, 89);
            this.GestionEntregas.TabIndex = 4;
            this.GestionEntregas.Text = "Gestions de Entregas";
            this.GestionEntregas.UseVisualStyleBackColor = true;
            this.GestionEntregas.Click += new System.EventHandler(this.GestionEntregas_Click);
            // 
            // btnResetData
            // 
            this.btnResetData.Location = new System.Drawing.Point(1238, 657);
            this.btnResetData.Name = "btnResetData";
            this.btnResetData.Size = new System.Drawing.Size(228, 70);
            this.btnResetData.TabIndex = 5;
            this.btnResetData.Text = "Reiniciar datos";
            this.btnResetData.UseVisualStyleBackColor = true;
            this.btnResetData.Click += new System.EventHandler(this.btnResetData_Click);
            // 
            // btnOpenDetalle
            // 
            this.btnOpenDetalle.Location = new System.Drawing.Point(1088, 552);
            this.btnOpenDetalle.Name = "btnOpenDetalle";
            this.btnOpenDetalle.Size = new System.Drawing.Size(296, 89);
            this.btnOpenDetalle.TabIndex = 6;
            this.btnOpenDetalle.Text = "Abrir Detalle Entrega";
            this.btnOpenDetalle.UseVisualStyleBackColor = true;
            // 
            // DetalleEntrega
            // 
            this.DetalleEntrega.Location = new System.Drawing.Point(644, 183);
            this.DetalleEntrega.Name = "DetalleEntrega";
            this.DetalleEntrega.Size = new System.Drawing.Size(296, 89);
            this.DetalleEntrega.TabIndex = 6;
            this.DetalleEntrega.Text = "Detalles de Entregas";
            this.DetalleEntrega.UseVisualStyleBackColor = true;
            this.DetalleEntrega.Click += new System.EventHandler(this.button1_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(1478, 749);
            this.Controls.Add(this.DetalleEntrega);
            this.Controls.Add(this.GestionEntregas);
            this.Controls.Add(this.GestionPaquetes);
            this.Controls.Add(this.GestionVehiculos);
            this.Controls.Add(this.GestionRepartidores);
            this.Controls.Add(this.GestionClientes);
            this.Controls.Add(this.btnResetData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GestionClientes;
        private System.Windows.Forms.Button GestionRepartidores;
        private System.Windows.Forms.Button GestionVehiculos;
        private System.Windows.Forms.Button GestionPaquetes;
        private System.Windows.Forms.Button GestionEntregas;
        private System.Windows.Forms.Button btnResetData;
        private System.Windows.Forms.Button btnOpenDetalle;
        private System.Windows.Forms.Button DetalleEntrega;
    }
}

