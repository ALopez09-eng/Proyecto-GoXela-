namespace Proyecto_Go_Xela
{
    partial class GestionPaquetes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ActualizarRepartidor = new System.Windows.Forms.Button();
            this.CancelarPaquete = new System.Windows.Forms.Button();
            this.registrarRepartidor = new System.Windows.Forms.Button();
            this.TipoPaquete = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EstadoPaquete = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DireccionDestinoPaquete = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DireccionOrigenPaquete = new System.Windows.Forms.TextBox();
            this.ValorDeclaradoPaquete = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PesoPaquete = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DescripciónPaquete = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.IvRegistroPaquetes = new System.Windows.Forms.ListView();
            this.MostrarCodigoRepartidor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarDescripcionoPaquete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarPesoPaquete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarValorDeclarado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarDireccionOrige = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarDireccionDestino = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarEstadoPaquete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MostrarTipoPaquete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ActualizarRepartidor);
            this.groupBox1.Controls.Add(this.CancelarPaquete);
            this.groupBox1.Controls.Add(this.registrarRepartidor);
            this.groupBox1.Controls.Add(this.TipoPaquete);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.EstadoPaquete);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DireccionDestinoPaquete);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DireccionOrigenPaquete);
            this.groupBox1.Controls.Add(this.ValorDeclaradoPaquete);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PesoPaquete);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DescripciónPaquete);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 691);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DEL PAQUETE";
            // 
            // ActualizarRepartidor
            // 
            this.ActualizarRepartidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActualizarRepartidor.Location = new System.Drawing.Point(279, 579);
            this.ActualizarRepartidor.Name = "ActualizarRepartidor";
            this.ActualizarRepartidor.Size = new System.Drawing.Size(130, 49);
            this.ActualizarRepartidor.TabIndex = 21;
            this.ActualizarRepartidor.Text = "ACTUALIZAR";
            this.ActualizarRepartidor.UseVisualStyleBackColor = true;
            this.ActualizarRepartidor.Click += new System.EventHandler(this.ActualizarRepartidor_Click);
            // 
            // CancelarPaquete
            // 
            this.CancelarPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarPaquete.Location = new System.Drawing.Point(143, 579);
            this.CancelarPaquete.Name = "CancelarPaquete";
            this.CancelarPaquete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CancelarPaquete.Size = new System.Drawing.Size(130, 49);
            this.CancelarPaquete.TabIndex = 20;
            this.CancelarPaquete.Text = "CANCELAR";
            this.CancelarPaquete.UseVisualStyleBackColor = true;
            this.CancelarPaquete.Click += new System.EventHandler(this.CancelarPaquete_Click);
            // 
            // registrarRepartidor
            // 
            this.registrarRepartidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrarRepartidor.Location = new System.Drawing.Point(8, 579);
            this.registrarRepartidor.Name = "registrarRepartidor";
            this.registrarRepartidor.Size = new System.Drawing.Size(130, 49);
            this.registrarRepartidor.TabIndex = 19;
            this.registrarRepartidor.Text = "REGISTRAR";
            this.registrarRepartidor.UseVisualStyleBackColor = true;
            this.registrarRepartidor.Click += new System.EventHandler(this.registrarRepartidor_Click);
            // 
            // TipoPaquete
            // 
            this.TipoPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TipoPaquete.FormattingEnabled = true;
            this.TipoPaquete.Items.AddRange(new object[] {
            "DOCUMENTO",
            "PAQUETE ESTÁNDAR",
            "PAQUETE FRÁGIL",
            "PRODUCTO REFRIGERADO"});
            this.TipoPaquete.Location = new System.Drawing.Point(9, 431);
            this.TipoPaquete.Name = "TipoPaquete";
            this.TipoPaquete.Size = new System.Drawing.Size(346, 26);
            this.TipoPaquete.TabIndex = 18;
            this.TipoPaquete.Text = "SELECCIONE UNA OPCIÓN";
            this.TipoPaquete.SelectedIndexChanged += new System.EventHandler(this.TipoPaquete_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 412);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "TIPO DE PAQUETE:";
            // 
            // EstadoPaquete
            // 
            this.EstadoPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.EstadoPaquete.FormattingEnabled = true;
            this.EstadoPaquete.Items.AddRange(new object[] {
            "EN CAMINO",
            "ENTREGADO",
            "CANCELADO"});
            this.EstadoPaquete.Location = new System.Drawing.Point(6, 508);
            this.EstadoPaquete.Name = "EstadoPaquete";
            this.EstadoPaquete.Size = new System.Drawing.Size(346, 26);
            this.EstadoPaquete.TabIndex = 16;
            this.EstadoPaquete.Text = "SELECCIONE UNA OPCIÓN";
            this.EstadoPaquete.SelectedIndexChanged += new System.EventHandler(this.EstadoPaquete_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 489);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "ESTADO: ";
            // 
            // DireccionDestinoPaquete
            // 
            this.DireccionDestinoPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DireccionDestinoPaquete.Location = new System.Drawing.Point(9, 354);
            this.DireccionDestinoPaquete.Name = "DireccionDestinoPaquete";
            this.DireccionDestinoPaquete.Size = new System.Drawing.Size(340, 30);
            this.DireccionDestinoPaquete.TabIndex = 14;
            this.DireccionDestinoPaquete.TextChanged += new System.EventHandler(this.DireccionDestinoPaquete_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "DIRECCION DE DESTINO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "DIRECCION DE ORIGEN:";
            // 
            // DireccionOrigenPaquete
            // 
            this.DireccionOrigenPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DireccionOrigenPaquete.Location = new System.Drawing.Point(9, 274);
            this.DireccionOrigenPaquete.Name = "DireccionOrigenPaquete";
            this.DireccionOrigenPaquete.Size = new System.Drawing.Size(340, 30);
            this.DireccionOrigenPaquete.TabIndex = 11;
            this.DireccionOrigenPaquete.TextChanged += new System.EventHandler(this.DireccionOrigenPaquete_TextChanged);
            // 
            // ValorDeclaradoPaquete
            // 
            this.ValorDeclaradoPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValorDeclaradoPaquete.Location = new System.Drawing.Point(9, 194);
            this.ValorDeclaradoPaquete.Name = "ValorDeclaradoPaquete";
            this.ValorDeclaradoPaquete.Size = new System.Drawing.Size(340, 30);
            this.ValorDeclaradoPaquete.TabIndex = 10;
            this.ValorDeclaradoPaquete.TextChanged += new System.EventHandler(this.ValorDeclaradoPaquete_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "VALOR DECLARADO:";
            // 
            // PesoPaquete
            // 
            this.PesoPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PesoPaquete.Location = new System.Drawing.Point(9, 123);
            this.PesoPaquete.Name = "PesoPaquete";
            this.PesoPaquete.Size = new System.Drawing.Size(340, 30);
            this.PesoPaquete.TabIndex = 8;
            this.PesoPaquete.TextChanged += new System.EventHandler(this.PesoPaquete_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "PESO (kg):";
            // 
            // DescripciónPaquete
            // 
            this.DescripciónPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescripciónPaquete.Location = new System.Drawing.Point(9, 55);
            this.DescripciónPaquete.Name = "DescripciónPaquete";
            this.DescripciónPaquete.Size = new System.Drawing.Size(340, 30);
            this.DescripciónPaquete.TabIndex = 6;
            this.DescripciónPaquete.TextChanged += new System.EventHandler(this.DescripciónPaquete_TextChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 36);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(117, 16);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "DESCRIPCIÓN: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(538, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(443, 39);
            this.label8.TabIndex = 1;
            this.label8.Text = "GESTIÓN DE PAQUETES";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // IvRegistroPaquetes
            // 
            this.IvRegistroPaquetes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MostrarCodigoRepartidor,
            this.MostrarDescripcionoPaquete,
            this.MostrarPesoPaquete,
            this.MostrarValorDeclarado,
            this.MostrarDireccionOrige,
            this.MostrarDireccionDestino,
            this.MostrarTipoPaquete,
            this.MostrarEstadoPaquete});
            this.IvRegistroPaquetes.HideSelection = false;
            this.IvRegistroPaquetes.Location = new System.Drawing.Point(503, 77);
            this.IvRegistroPaquetes.Name = "IvRegistroPaquetes";
            this.IvRegistroPaquetes.Size = new System.Drawing.Size(1002, 469);
            this.IvRegistroPaquetes.TabIndex = 3;
            this.IvRegistroPaquetes.UseCompatibleStateImageBehavior = false;
            this.IvRegistroPaquetes.View = System.Windows.Forms.View.Details;
            this.IvRegistroPaquetes.SelectedIndexChanged += new System.EventHandler(this.IvRegistroPaquetes_SelectedIndexChanged);
            // 
            // MostrarCodigoRepartidor
            // 
            this.MostrarCodigoRepartidor.Text = "Codigo";
            this.MostrarCodigoRepartidor.Width = 110;
            // 
            // MostrarDescripcionoPaquete
            // 
            this.MostrarDescripcionoPaquete.Text = "Descripción";
            this.MostrarDescripcionoPaquete.Width = 134;
            // 
            // MostrarPesoPaquete
            // 
            this.MostrarPesoPaquete.Text = "Peso";
            this.MostrarPesoPaquete.Width = 140;
            // 
            // MostrarValorDeclarado
            // 
            this.MostrarValorDeclarado.Text = "Valor declarado";
            this.MostrarValorDeclarado.Width = 119;
            // 
            // MostrarDireccionOrige
            // 
            this.MostrarDireccionOrige.Text = "Dirección de origen";
            this.MostrarDireccionOrige.Width = 163;
            // 
            // MostrarDireccionDestino
            // 
            this.MostrarDireccionDestino.Text = "Dirección de destino";
            this.MostrarDireccionDestino.Width = 170;
            // 
            // MostrarEstadoPaquete
            // 
            this.MostrarEstadoPaquete.DisplayIndex = 6;
            this.MostrarEstadoPaquete.Text = "Estado";
            this.MostrarEstadoPaquete.Width = 147;
            // 
            // MostrarTipoPaquete
            // 
            this.MostrarTipoPaquete.DisplayIndex = 7;
            this.MostrarTipoPaquete.Text = "Tipo de Paquete";
            // 
            // GestionPaquetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1562, 757);
            this.Controls.Add(this.IvRegistroPaquetes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Name = "GestionPaquetes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionPaquetes";
            this.Load += new System.EventHandler(this.GestionPaquetes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox DescripciónPaquete;
        private System.Windows.Forms.TextBox ValorDeclaradoPaquete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PesoPaquete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DireccionDestinoPaquete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DireccionOrigenPaquete;
        private System.Windows.Forms.ComboBox EstadoPaquete;
        private System.Windows.Forms.ComboBox TipoPaquete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ActualizarRepartidor;
        private System.Windows.Forms.Button CancelarPaquete;
        private System.Windows.Forms.Button registrarRepartidor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView IvRegistroPaquetes;
        private System.Windows.Forms.ColumnHeader MostrarCodigoRepartidor;
        private System.Windows.Forms.ColumnHeader MostrarDescripcionoPaquete;
        private System.Windows.Forms.ColumnHeader MostrarPesoPaquete;
        private System.Windows.Forms.ColumnHeader MostrarValorDeclarado;
        private System.Windows.Forms.ColumnHeader MostrarDireccionOrige;
        private System.Windows.Forms.ColumnHeader MostrarDireccionDestino;
        private System.Windows.Forms.ColumnHeader MostrarEstadoPaquete;
        private System.Windows.Forms.ColumnHeader MostrarTipoPaquete;
    }
}