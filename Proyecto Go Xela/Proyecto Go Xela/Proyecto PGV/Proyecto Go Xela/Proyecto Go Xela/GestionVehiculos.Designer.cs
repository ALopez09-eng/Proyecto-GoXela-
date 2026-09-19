namespace Proyecto_Go_Xela
{
    partial class GestionVehiculos
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
            this.DATOSVEHICULO = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EstadoVehiculo = new System.Windows.Forms.ComboBox();
            this.ActualizarRepartidor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.registrarRepartidor = new System.Windows.Forms.Button();
            this.CostoOperativoVehiuclo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CapacidadMaximaVehiculo = new System.Windows.Forms.TextBox();
            this.ModeloVehículo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MarcaVehiculo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PlacaVehiculo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TipoVehiculo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LisViewVehiculos = new System.Windows.Forms.ListView();
            this.MostrarCodigoCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarTipoVehiculo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarPlaca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarMarca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarModelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarCapacidadMaxima = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarEstoVehiculo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarCostoOperativo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DATOSVEHICULO.SuspendLayout();
            this.SuspendLayout();
            // 
            // DATOSVEHICULO
            // 
            this.DATOSVEHICULO.Controls.Add(this.label7);
            this.DATOSVEHICULO.Controls.Add(this.EstadoVehiculo);
            this.DATOSVEHICULO.Controls.Add(this.ActualizarRepartidor);
            this.DATOSVEHICULO.Controls.Add(this.label6);
            this.DATOSVEHICULO.Controls.Add(this.button1);
            this.DATOSVEHICULO.Controls.Add(this.registrarRepartidor);
            this.DATOSVEHICULO.Controls.Add(this.CostoOperativoVehiuclo);
            this.DATOSVEHICULO.Controls.Add(this.label5);
            this.DATOSVEHICULO.Controls.Add(this.CapacidadMaximaVehiculo);
            this.DATOSVEHICULO.Controls.Add(this.ModeloVehículo);
            this.DATOSVEHICULO.Controls.Add(this.label4);
            this.DATOSVEHICULO.Controls.Add(this.MarcaVehiculo);
            this.DATOSVEHICULO.Controls.Add(this.label3);
            this.DATOSVEHICULO.Controls.Add(this.label2);
            this.DATOSVEHICULO.Controls.Add(this.PlacaVehiculo);
            this.DATOSVEHICULO.Controls.Add(this.label1);
            this.DATOSVEHICULO.Controls.Add(this.TipoVehiculo);
            this.DATOSVEHICULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DATOSVEHICULO.Location = new System.Drawing.Point(12, 50);
            this.DATOSVEHICULO.Name = "DATOSVEHICULO";
            this.DATOSVEHICULO.Size = new System.Drawing.Size(432, 695);
            this.DATOSVEHICULO.TabIndex = 0;
            this.DATOSVEHICULO.TabStop = false;
            this.DATOSVEHICULO.Text = "DATOS DEL VEHÍCULO";
            this.DATOSVEHICULO.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 399);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "ESTADO:";
            // 
            // EstadoVehiculo
            // 
            this.EstadoVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EstadoVehiculo.FormattingEnabled = true;
            this.EstadoVehiculo.Items.AddRange(new object[] {
            "DISPONIBLE",
            "ASIGNADO",
            "EN MANTENIMIENTO"});
            this.EstadoVehiculo.Location = new System.Drawing.Point(12, 418);
            this.EstadoVehiculo.Name = "EstadoVehiculo";
            this.EstadoVehiculo.Size = new System.Drawing.Size(346, 26);
            this.EstadoVehiculo.TabIndex = 21;
            this.EstadoVehiculo.Text = "SELECCIONE UNA OPCIÓN";
            this.EstadoVehiculo.SelectedIndexChanged += new System.EventHandler(this.EstadoVehiculo_SelectedIndexChanged);
            // 
            // ActualizarRepartidor
            // 
            this.ActualizarRepartidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActualizarRepartidor.Location = new System.Drawing.Point(283, 618);
            this.ActualizarRepartidor.Name = "ActualizarRepartidor";
            this.ActualizarRepartidor.Size = new System.Drawing.Size(130, 49);
            this.ActualizarRepartidor.TabIndex = 16;
            this.ActualizarRepartidor.Text = "ACTUALIZAR";
            this.ActualizarRepartidor.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 466);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "COSTO OPERATIVO:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(147, 618);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(130, 49);
            this.button1.TabIndex = 15;
            this.button1.Text = "CANCELAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // registrarRepartidor
            // 
            this.registrarRepartidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrarRepartidor.Location = new System.Drawing.Point(11, 618);
            this.registrarRepartidor.Name = "registrarRepartidor";
            this.registrarRepartidor.Size = new System.Drawing.Size(130, 49);
            this.registrarRepartidor.TabIndex = 14;
            this.registrarRepartidor.Text = "REGISTRAR";
            this.registrarRepartidor.UseVisualStyleBackColor = true;
            this.registrarRepartidor.Click += new System.EventHandler(this.registrarRepartidor_Click);
            // 
            // CostoOperativoVehiuclo
            // 
            this.CostoOperativoVehiuclo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostoOperativoVehiuclo.Location = new System.Drawing.Point(12, 485);
            this.CostoOperativoVehiuclo.Name = "CostoOperativoVehiuclo";
            this.CostoOperativoVehiuclo.Size = new System.Drawing.Size(346, 30);
            this.CostoOperativoVehiuclo.TabIndex = 19;
            this.CostoOperativoVehiuclo.TextChanged += new System.EventHandler(this.CostoOperativoVehiuclo_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(266, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "CAPACIDAD MAXIMA DE CARGA (kg)";
            // 
            // CapacidadMaximaVehiculo
            // 
            this.CapacidadMaximaVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CapacidadMaximaVehiculo.Location = new System.Drawing.Point(12, 352);
            this.CapacidadMaximaVehiculo.Name = "CapacidadMaximaVehiculo";
            this.CapacidadMaximaVehiculo.Size = new System.Drawing.Size(346, 30);
            this.CapacidadMaximaVehiculo.TabIndex = 17;
            this.CapacidadMaximaVehiculo.TextChanged += new System.EventHandler(this.CapacidadMaximaVehiculo_TextChanged);
            // 
            // ModeloVehículo
            // 
            this.ModeloVehículo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeloVehículo.Location = new System.Drawing.Point(12, 275);
            this.ModeloVehículo.Name = "ModeloVehículo";
            this.ModeloVehículo.Size = new System.Drawing.Size(346, 30);
            this.ModeloVehículo.TabIndex = 16;
            this.ModeloVehículo.TextChanged += new System.EventHandler(this.ModeloVehículo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "MODELO:";
            // 
            // MarcaVehiculo
            // 
            this.MarcaVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MarcaVehiculo.Location = new System.Drawing.Point(12, 195);
            this.MarcaVehiculo.Name = "MarcaVehiculo";
            this.MarcaVehiculo.Size = new System.Drawing.Size(346, 30);
            this.MarcaVehiculo.TabIndex = 14;
            this.MarcaVehiculo.TextChanged += new System.EventHandler(this.MarcaVehiculo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "MARCA: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "PLACA:";
            // 
            // PlacaVehiculo
            // 
            this.PlacaVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlacaVehiculo.Location = new System.Drawing.Point(12, 120);
            this.PlacaVehiculo.Name = "PlacaVehiculo";
            this.PlacaVehiculo.Size = new System.Drawing.Size(346, 30);
            this.PlacaVehiculo.TabIndex = 11;
            this.PlacaVehiculo.TextChanged += new System.EventHandler(this.PlacaVehiculo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "TIPO DE VEHÍCULO:";
            // 
            // TipoVehiculo
            // 
            this.TipoVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoVehiculo.FormattingEnabled = true;
            this.TipoVehiculo.Items.AddRange(new object[] {
            "BICICLETA",
            "MOTOCICLETA",
            "AUTOMOVIL"});
            this.TipoVehiculo.Location = new System.Drawing.Point(12, 58);
            this.TipoVehiculo.Name = "TipoVehiculo";
            this.TipoVehiculo.Size = new System.Drawing.Size(346, 26);
            this.TipoVehiculo.TabIndex = 9;
            this.TipoVehiculo.Text = "SELECCIONE UNA OPCIÓN";
            this.TipoVehiculo.SelectedIndexChanged += new System.EventHandler(this.TipoVehiculo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(568, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(456, 39);
            this.label8.TabIndex = 2;
            this.label8.Text = "GESTION DE VEHICULOS";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // LisViewVehiculos
            // 
            this.LisViewVehiculos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MostrarCodigoCliente,
            this.MostrarTipoVehiculo,
            this.MostrarPlaca,
            this.MostrarMarca,
            this.MostrarModelo,
            this.MostrarCapacidadMaxima,
            this.MostrarEstoVehiculo,
            this.MostrarCostoOperativo});
            this.LisViewVehiculos.HideSelection = false;
            this.LisViewVehiculos.Location = new System.Drawing.Point(476, 78);
            this.LisViewVehiculos.Name = "LisViewVehiculos";
            this.LisViewVehiculos.Size = new System.Drawing.Size(1057, 543);
            this.LisViewVehiculos.TabIndex = 3;
            this.LisViewVehiculos.UseCompatibleStateImageBehavior = false;
            this.LisViewVehiculos.View = System.Windows.Forms.View.Details;
            this.LisViewVehiculos.SelectedIndexChanged += new System.EventHandler(this.LisViewVehiculos_SelectedIndexChanged);
            // 
            // MostrarCodigoCliente
            // 
            this.MostrarCodigoCliente.Text = "Codigo:";
            this.MostrarCodigoCliente.Width = 108;
            // 
            // MostrarTipoVehiculo
            // 
            this.MostrarTipoVehiculo.Text = "Tipo de Vehículo: ";
            // 
            // MostrarPlaca
            // 
            this.MostrarPlaca.Text = "Placa:";
            // 
            // MostrarMarca
            // 
            this.MostrarMarca.Text = "Marca";
            // 
            // MostrarModelo
            // 
            this.MostrarModelo.Text = "Modelo: ";
            // 
            // MostrarCapacidadMaxima
            // 
            this.MostrarCapacidadMaxima.Text = "Capacidad Maxima (kg)";
            // 
            // MostrarEstoVehiculo
            // 
            this.MostrarEstoVehiculo.Text = "Estado: ";
            // 
            // MostrarCostoOperativo
            // 
            this.MostrarCostoOperativo.Text = "Costo Operativo";
            // 
            // GestionVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1562, 757);
            this.Controls.Add(this.LisViewVehiculos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DATOSVEHICULO);
            this.Name = "GestionVehiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Vehiculos";
            this.Load += new System.EventHandler(this.GestionVehiculos_Load);
            this.DATOSVEHICULO.ResumeLayout(false);
            this.DATOSVEHICULO.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox DATOSVEHICULO;
        private System.Windows.Forms.ComboBox TipoVehiculo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PlacaVehiculo;
        private System.Windows.Forms.TextBox ModeloVehículo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MarcaVehiculo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CapacidadMaximaVehiculo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CostoOperativoVehiuclo;
        private System.Windows.Forms.Button ActualizarRepartidor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button registrarRepartidor;
        private System.Windows.Forms.ListView listViewVehiculos;
        private System.Windows.Forms.ColumnHeader colPlaca;
        private System.Windows.Forms.ColumnHeader colMarca;
        private System.Windows.Forms.ColumnHeader colModelo;
        private System.Windows.Forms.ColumnHeader colCapacidad;
        private System.Windows.Forms.ColumnHeader colCosto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView LisViewVehiculos;
        private System.Windows.Forms.ColumnHeader MostrarCodigoCliente;
        private System.Windows.Forms.ColumnHeader MostrarTipoVehiculo;
        private System.Windows.Forms.ColumnHeader MostrarPlaca;
        private System.Windows.Forms.ColumnHeader MostrarMarca;
        private System.Windows.Forms.ColumnHeader MostrarModelo;
        private System.Windows.Forms.ColumnHeader MostrarCapacidadMaxima;
        private System.Windows.Forms.ColumnHeader MostrarEstoVehiculo;
        private System.Windows.Forms.ColumnHeader MostrarCostoOperativo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox EstadoVehiculo;
    }
}