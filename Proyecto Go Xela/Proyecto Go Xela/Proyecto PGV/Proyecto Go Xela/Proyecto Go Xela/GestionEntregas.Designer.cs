namespace Proyecto_Go_Xela
{
    partial class GestionEntregas
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
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ServicioEntrega = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.FechaSolicitudPaquete = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VEHICULOPAQUETE = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RepartidorPaquete = new System.Windows.Forms.ComboBox();
            this.Laboel = new System.Windows.Forms.Label();
            this.PaqueteEntrega = new System.Windows.Forms.ComboBox();
            this.ClientePaquete = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ActualizarRepartidor = new System.Windows.Forms.Button();
            this.TotalEntregas = new System.Windows.Forms.TextBox();
            this.CancelarGestionEntregas = new System.Windows.Forms.Button();
            this.registrarRepartidor = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.DescuentoEntregas = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RecargosEntregas = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TarifaBase = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DistanciaEstimadaEntrega = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.DirecciónDestinoEntregas = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.DireccionOrigenEntregas = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.IvRegistroPaquetes = new System.Windows.Forms.ListView();
            this.MostrarCodigoEntrega = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarClienteEntrega = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarRepartidorEntrega = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarVehiculoEntrega = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarTipoServicoEntrega = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarEstadoEntrega = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarTotalEntrega = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarFechaSolicitudEntrega = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDetalleEntrega = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(587, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(445, 39);
            this.label8.TabIndex = 2;
            this.label8.Text = "GESTIÓN DE ENTREGAS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ServicioEntrega);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.FechaSolicitudPaquete);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.VEHICULOPAQUETE);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RepartidorPaquete);
            this.groupBox1.Controls.Add(this.Laboel);
            this.groupBox1.Controls.Add(this.PaqueteEntrega);
            this.groupBox1.Controls.Add(this.ClientePaquete);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 625);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la entrega";
            // 
            // ServicioEntrega
            // 
            this.ServicioEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ServicioEntrega.FormattingEnabled = true;
            this.ServicioEntrega.Items.AddRange(new object[] {
            "NORMAL",
            "PRIORITARIO",
            "URGENTE"});
            this.ServicioEntrega.Location = new System.Drawing.Point(6, 430);
            this.ServicioEntrega.Name = "ServicioEntrega";
            this.ServicioEntrega.Size = new System.Drawing.Size(346, 26);
            this.ServicioEntrega.TabIndex = 24;
            this.ServicioEntrega.Text = "SELECCIONE UN SERVICIO";
            this.ServicioEntrega.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "TIPO DE SERVICIO";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // FechaSolicitudPaquete
            // 
            this.FechaSolicitudPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaSolicitudPaquete.Location = new System.Drawing.Point(9, 353);
            this.FechaSolicitudPaquete.Name = "FechaSolicitudPaquete";
            this.FechaSolicitudPaquete.Size = new System.Drawing.Size(346, 30);
            this.FechaSolicitudPaquete.TabIndex = 24;
            this.FechaSolicitudPaquete.TextChanged += new System.EventHandler(this.FechaSolicitudPaquete_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "FECHA DE SOLICITUD";
            // 
            // VEHICULOPAQUETE
            // 
            this.VEHICULOPAQUETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VEHICULOPAQUETE.FormattingEnabled = true;
            this.VEHICULOPAQUETE.Location = new System.Drawing.Point(6, 197);
            this.VEHICULOPAQUETE.Name = "VEHICULOPAQUETE";
            this.VEHICULOPAQUETE.Size = new System.Drawing.Size(346, 26);
            this.VEHICULOPAQUETE.TabIndex = 22;
            this.VEHICULOPAQUETE.Text = "SELECCIONE UN VEHÍCULO";
            this.VEHICULOPAQUETE.SelectedIndexChanged += new System.EventHandler(this.VEHICULOPAQUETE_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "VEHÍCULO:";
            // 
            // RepartidorPaquete
            // 
            this.RepartidorPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.RepartidorPaquete.FormattingEnabled = true;
            this.RepartidorPaquete.Location = new System.Drawing.Point(6, 275);
            this.RepartidorPaquete.Name = "RepartidorPaquete";
            this.RepartidorPaquete.Size = new System.Drawing.Size(346, 26);
            this.RepartidorPaquete.TabIndex = 22;
            this.RepartidorPaquete.Text = "SELECCIONE UNA REPARITODOR";
            this.RepartidorPaquete.SelectedIndexChanged += new System.EventHandler(this.RepartidorPaquete_SelectedIndexChanged);
            // 
            // Laboel
            // 
            this.Laboel.AutoSize = true;
            this.Laboel.Location = new System.Drawing.Point(3, 247);
            this.Laboel.Name = "Laboel";
            this.Laboel.Size = new System.Drawing.Size(110, 16);
            this.Laboel.TabIndex = 21;
            this.Laboel.Text = "REPARTIDOR:";
            // 
            // PaqueteEntrega
            // 
            this.PaqueteEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PaqueteEntrega.FormattingEnabled = true;
            this.PaqueteEntrega.Location = new System.Drawing.Point(6, 125);
            this.PaqueteEntrega.Name = "PaqueteEntrega";
            this.PaqueteEntrega.Size = new System.Drawing.Size(346, 26);
            this.PaqueteEntrega.TabIndex = 20;
            this.PaqueteEntrega.Text = "SELECCIONE UNA PAQUETE";
            this.PaqueteEntrega.SelectedIndexChanged += new System.EventHandler(this.PaqueteEntrega_SelectedIndexChanged);
            // 
            // ClientePaquete
            // 
            this.ClientePaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ClientePaquete.FormattingEnabled = true;
            this.ClientePaquete.Location = new System.Drawing.Point(6, 49);
            this.ClientePaquete.Name = "ClientePaquete";
            this.ClientePaquete.Size = new System.Drawing.Size(346, 26);
            this.ClientePaquete.TabIndex = 19;
            this.ClientePaquete.Text = "SELECCIONE UNA CLIENTE";
            this.ClientePaquete.SelectedIndexChanged += new System.EventHandler(this.ClientePaquete_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "PAQUETE:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(3, 30);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(74, 16);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "CLIENTE:";
            this.Label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ActualizarRepartidor);
            this.groupBox2.Controls.Add(this.TotalEntregas);
            this.groupBox2.Controls.Add(this.CancelarGestionEntregas);
            this.groupBox2.Controls.Add(this.registrarRepartidor);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.DescuentoEntregas);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.RecargosEntregas);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.TarifaBase);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.DistanciaEstimadaEntrega);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.DirecciónDestinoEntregas);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.DireccionOrigenEntregas);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(396, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 625);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DIRECCIONES Y TARIFA";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // ActualizarRepartidor
            // 
            this.ActualizarRepartidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActualizarRepartidor.Location = new System.Drawing.Point(278, 570);
            this.ActualizarRepartidor.Name = "ActualizarRepartidor";
            this.ActualizarRepartidor.Size = new System.Drawing.Size(130, 49);
            this.ActualizarRepartidor.TabIndex = 32;
            this.ActualizarRepartidor.Text = "ACTUALIZAR";
            this.ActualizarRepartidor.UseVisualStyleBackColor = true;
            // 
            // TotalEntregas
            // 
            this.TotalEntregas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalEntregas.Location = new System.Drawing.Point(9, 509);
            this.TotalEntregas.Name = "TotalEntregas";
            this.TotalEntregas.Size = new System.Drawing.Size(346, 30);
            this.TotalEntregas.TabIndex = 41;
            this.TotalEntregas.TextChanged += new System.EventHandler(this.TotalEntregas_TextChanged);
            // 
            // CancelarGestionEntregas
            // 
            this.CancelarGestionEntregas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarGestionEntregas.Location = new System.Drawing.Point(142, 570);
            this.CancelarGestionEntregas.Name = "CancelarGestionEntregas";
            this.CancelarGestionEntregas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CancelarGestionEntregas.Size = new System.Drawing.Size(130, 49);
            this.CancelarGestionEntregas.TabIndex = 31;
            this.CancelarGestionEntregas.Text = "CANCELAR";
            this.CancelarGestionEntregas.UseVisualStyleBackColor = true;
            // 
            // registrarRepartidor
            // 
            this.registrarRepartidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrarRepartidor.Location = new System.Drawing.Point(7, 570);
            this.registrarRepartidor.Name = "registrarRepartidor";
            this.registrarRepartidor.Size = new System.Drawing.Size(130, 49);
            this.registrarRepartidor.TabIndex = 30;
            this.registrarRepartidor.Text = "REGISTRAR";
            this.registrarRepartidor.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 486);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 16);
            this.label10.TabIndex = 40;
            this.label10.Text = "TOTAL:";
            // 
            // DescuentoEntregas
            // 
            this.DescuentoEntregas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescuentoEntregas.Location = new System.Drawing.Point(9, 434);
            this.DescuentoEntregas.Name = "DescuentoEntregas";
            this.DescuentoEntregas.Size = new System.Drawing.Size(346, 30);
            this.DescuentoEntregas.TabIndex = 39;
            this.DescuentoEntregas.TextChanged += new System.EventHandler(this.DescuentoEntregas_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 411);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 16);
            this.label9.TabIndex = 38;
            this.label9.Text = "DESCUENTO:";
            // 
            // RecargosEntregas
            // 
            this.RecargosEntregas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecargosEntregas.Location = new System.Drawing.Point(9, 353);
            this.RecargosEntregas.Name = "RecargosEntregas";
            this.RecargosEntregas.Size = new System.Drawing.Size(346, 30);
            this.RecargosEntregas.TabIndex = 37;
            this.RecargosEntregas.TextChanged += new System.EventHandler(this.RecargosEntregas_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 330);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 16);
            this.label13.TabIndex = 36;
            this.label13.Text = "RECARGOS:";
            // 
            // TarifaBase
            // 
            this.TarifaBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TarifaBase.Location = new System.Drawing.Point(9, 275);
            this.TarifaBase.Name = "TarifaBase";
            this.TarifaBase.Size = new System.Drawing.Size(346, 30);
            this.TarifaBase.TabIndex = 35;
            this.TarifaBase.TextChanged += new System.EventHandler(this.TarifaBase_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 252);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 16);
            this.label12.TabIndex = 34;
            this.label12.Text = "TARIFA BASE:";
            // 
            // DistanciaEstimadaEntrega
            // 
            this.DistanciaEstimadaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DistanciaEstimadaEntrega.Location = new System.Drawing.Point(9, 197);
            this.DistanciaEstimadaEntrega.Name = "DistanciaEstimadaEntrega";
            this.DistanciaEstimadaEntrega.Size = new System.Drawing.Size(346, 30);
            this.DistanciaEstimadaEntrega.TabIndex = 33;
            this.DistanciaEstimadaEntrega.TextChanged += new System.EventHandler(this.DistanciaEstimadaEntrega_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 174);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(203, 16);
            this.label14.TabIndex = 32;
            this.label14.Text = "DISTANCIA ESTIMADA (KM)";
            // 
            // DirecciónDestinoEntregas
            // 
            this.DirecciónDestinoEntregas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirecciónDestinoEntregas.Location = new System.Drawing.Point(9, 120);
            this.DirecciónDestinoEntregas.Name = "DirecciónDestinoEntregas";
            this.DirecciónDestinoEntregas.Size = new System.Drawing.Size(346, 30);
            this.DirecciónDestinoEntregas.TabIndex = 31;
            this.DirecciónDestinoEntregas.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(193, 16);
            this.label15.TabIndex = 30;
            this.label15.Text = "DIRECCION DE DESTINO: ";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // DireccionOrigenEntregas
            // 
            this.DireccionOrigenEntregas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DireccionOrigenEntregas.Location = new System.Drawing.Point(6, 53);
            this.DireccionOrigenEntregas.Name = "DireccionOrigenEntregas";
            this.DireccionOrigenEntregas.Size = new System.Drawing.Size(346, 30);
            this.DireccionOrigenEntregas.TabIndex = 29;
            this.DireccionOrigenEntregas.TextChanged += new System.EventHandler(this.DireccionOrigenEntregas_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(184, 16);
            this.label16.TabIndex = 7;
            this.label16.Text = "DIRECCION DE ORIGEN: ";
            // 
            // IvRegistroPaquetes
            // 
            this.IvRegistroPaquetes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MostrarCodigoEntrega,
            this.MostrarClienteEntrega,
            this.MostrarRepartidorEntrega,
            this.MostrarVehiculoEntrega,
            this.MostrarTipoServicoEntrega,
            this.MostrarEstadoEntrega,
            this.MostrarTotalEntrega,
            this.MostrarFechaSolicitudEntrega});
            this.IvRegistroPaquetes.HideSelection = false;
            this.IvRegistroPaquetes.Location = new System.Drawing.Point(821, 80);
            this.IvRegistroPaquetes.Name = "IvRegistroPaquetes";
            this.IvRegistroPaquetes.Size = new System.Drawing.Size(729, 539);
            this.IvRegistroPaquetes.TabIndex = 30;
            this.IvRegistroPaquetes.UseCompatibleStateImageBehavior = false;
            this.IvRegistroPaquetes.View = System.Windows.Forms.View.Details;
            this.IvRegistroPaquetes.SelectedIndexChanged += new System.EventHandler(this.IvRegistroPaquetes_SelectedIndexChanged);
            // 
            // MostrarCodigoEntrega
            // 
            this.MostrarCodigoEntrega.Text = "Codigo";
            this.MostrarCodigoEntrega.Width = 110;
            // 
            // MostrarClienteEntrega
            // 
            this.MostrarClienteEntrega.Text = "Cliente";
            this.MostrarClienteEntrega.Width = 134;
            // 
            // MostrarRepartidorEntrega
            // 
            this.MostrarRepartidorEntrega.Text = "Repartidor";
            this.MostrarRepartidorEntrega.Width = 140;
            // 
            // MostrarVehiculoEntrega
            // 
            this.MostrarVehiculoEntrega.Text = "Vehículo";
            this.MostrarVehiculoEntrega.Width = 119;
            // 
            // MostrarTipoServicoEntrega
            // 
            this.MostrarTipoServicoEntrega.Text = "Tipo Servicio";
            this.MostrarTipoServicoEntrega.Width = 167;
            // 
            // MostrarEstadoEntrega
            // 
            this.MostrarEstadoEntrega.Text = "Estado";
            this.MostrarEstadoEntrega.Width = 170;
            // 
            // MostrarTotalEntrega
            // 
            this.MostrarTotalEntrega.Text = "Total";
            this.MostrarTotalEntrega.Width = 147;
            // 
            // MostrarFechaSolicitudEntrega
            // 
            this.MostrarFechaSolicitudEntrega.Text = "Fecha de Solicitud";
            // 
            // btnDetalleEntrega
            // 
            this.btnDetalleEntrega.Location = new System.Drawing.Point(821, 630);
            this.btnDetalleEntrega.Name = "btnDetalleEntrega";
            this.btnDetalleEntrega.Size = new System.Drawing.Size(160, 40);
            this.btnDetalleEntrega.TabIndex = 31;
            this.btnDetalleEntrega.Text = "Ver / Editar entrega";
            this.btnDetalleEntrega.UseVisualStyleBackColor = true;
            this.btnDetalleEntrega.Click += new System.EventHandler(this.btnDetalleEntrega_Click);
            // 
            // GestionEntregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1562, 757);
            this.Controls.Add(this.IvRegistroPaquetes);
            this.Controls.Add(this.btnDetalleEntrega);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Name = "GestionEntregas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionEntregas";
            this.Load += new System.EventHandler(this.GestionEntregas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ClientePaquete;
        private System.Windows.Forms.ComboBox PaqueteEntrega;
        private System.Windows.Forms.ComboBox VEHICULOPAQUETE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox RepartidorPaquete;
        private System.Windows.Forms.Label Laboel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FechaSolicitudPaquete;
        private System.Windows.Forms.ComboBox ServicioEntrega;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox DirecciónDestinoEntregas;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox DireccionOrigenEntregas;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox DistanciaEstimadaEntrega;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TotalEntregas;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox DescuentoEntregas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox RecargosEntregas;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TarifaBase;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button ActualizarRepartidor;
        private System.Windows.Forms.Button CancelarGestionEntregas;
        private System.Windows.Forms.Button registrarRepartidor;
        private System.Windows.Forms.ListView IvRegistroPaquetes;
        private System.Windows.Forms.ColumnHeader MostrarCodigoEntrega;
        private System.Windows.Forms.ColumnHeader MostrarClienteEntrega;
        private System.Windows.Forms.ColumnHeader MostrarRepartidorEntrega;
        private System.Windows.Forms.ColumnHeader MostrarVehiculoEntrega;
        private System.Windows.Forms.ColumnHeader MostrarTipoServicoEntrega;
        private System.Windows.Forms.ColumnHeader MostrarEstadoEntrega;
        private System.Windows.Forms.ColumnHeader MostrarTotalEntrega;
        private System.Windows.Forms.ColumnHeader MostrarFechaSolicitudEntrega;
        private System.Windows.Forms.Button btnDetalleEntrega;
    }
}