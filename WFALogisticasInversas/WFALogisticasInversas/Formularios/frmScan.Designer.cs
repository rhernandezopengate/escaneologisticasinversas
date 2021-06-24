namespace WFALogisticasInversas.Formularios
{
    partial class frmScan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ddlOrigen = new System.Windows.Forms.ComboBox();
            this.liorigenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetOrigenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetOrigen = new WFALogisticasInversas.DataSets.DataSetOrigen();
            this.btnAgregarLogistica = new System.Windows.Forms.Button();
            this.li_origenTableAdapter = new WFALogisticasInversas.DataSets.DataSetOrigenTableAdapters.li_origenTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFolioCaja = new System.Windows.Forms.Label();
            this.lblFolioTarima = new System.Windows.Forms.Label();
            this.lblOrigenLogistica = new System.Windows.Forms.Label();
            this.lblFolioLogistica = new System.Windows.Forms.Label();
            this.lblFolioLogisticaUsar = new System.Windows.Forms.Label();
            this.lblFolioTarimaUsar = new System.Windows.Forms.Label();
            this.lblFolioCajaUsar = new System.Windows.Forms.Label();
            this.txtScanSKU = new System.Windows.Forms.TextBox();
            this.btnCajas = new System.Windows.Forms.Button();
            this.btnTarima = new System.Windows.Forms.Button();
            this.btnContinuarCaja = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCerrarLogistica = new System.Windows.Forms.Button();
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOperacionActualUsar = new System.Windows.Forms.Label();
            this.lblReImprimirUsar = new System.Windows.Forms.Label();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.liorigenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetOrigenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetOrigen)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlOrigen
            // 
            this.ddlOrigen.DataSource = this.liorigenBindingSource;
            this.ddlOrigen.DisplayMember = "descripcion";
            this.ddlOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlOrigen.FormattingEnabled = true;
            this.ddlOrigen.Location = new System.Drawing.Point(156, 3);
            this.ddlOrigen.Name = "ddlOrigen";
            this.ddlOrigen.Size = new System.Drawing.Size(268, 32);
            this.ddlOrigen.TabIndex = 0;
            this.ddlOrigen.ValueMember = "id";
            // 
            // liorigenBindingSource
            // 
            this.liorigenBindingSource.DataMember = "li_origen";
            this.liorigenBindingSource.DataSource = this.dataSetOrigenBindingSource;
            // 
            // dataSetOrigenBindingSource
            // 
            this.dataSetOrigenBindingSource.DataSource = this.dataSetOrigen;
            this.dataSetOrigenBindingSource.Position = 0;
            // 
            // dataSetOrigen
            // 
            this.dataSetOrigen.DataSetName = "DataSetOrigen";
            this.dataSetOrigen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAgregarLogistica
            // 
            this.btnAgregarLogistica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarLogistica.BackgroundImage")));
            this.btnAgregarLogistica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarLogistica.Location = new System.Drawing.Point(13, 214);
            this.btnAgregarLogistica.Name = "btnAgregarLogistica";
            this.btnAgregarLogistica.Size = new System.Drawing.Size(112, 81);
            this.btnAgregarLogistica.TabIndex = 1;
            this.btnAgregarLogistica.UseVisualStyleBackColor = true;
            this.btnAgregarLogistica.Click += new System.EventHandler(this.btnAgregarLogistica_Click);
            // 
            // li_origenTableAdapter
            // 
            this.li_origenTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.52915F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.47086F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblFolioCaja, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFolioTarima, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ddlOrigen, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOrigenLogistica, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFolioLogistica, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFolioLogisticaUsar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFolioTarimaUsar, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFolioCajaUsar, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtScanSKU, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.5641F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.4359F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 195);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "SKU";
            // 
            // lblFolioCaja
            // 
            this.lblFolioCaja.AutoSize = true;
            this.lblFolioCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioCaja.Location = new System.Drawing.Point(3, 118);
            this.lblFolioCaja.Name = "lblFolioCaja";
            this.lblFolioCaja.Size = new System.Drawing.Size(94, 24);
            this.lblFolioCaja.TabIndex = 6;
            this.lblFolioCaja.Text = "Folio Caja";
            // 
            // lblFolioTarima
            // 
            this.lblFolioTarima.AutoSize = true;
            this.lblFolioTarima.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioTarima.Location = new System.Drawing.Point(3, 78);
            this.lblFolioTarima.Name = "lblFolioTarima";
            this.lblFolioTarima.Size = new System.Drawing.Size(115, 24);
            this.lblFolioTarima.TabIndex = 4;
            this.lblFolioTarima.Text = "Folio Tarima";
            // 
            // lblOrigenLogistica
            // 
            this.lblOrigenLogistica.AutoSize = true;
            this.lblOrigenLogistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigenLogistica.Location = new System.Drawing.Point(3, 0);
            this.lblOrigenLogistica.Name = "lblOrigenLogistica";
            this.lblOrigenLogistica.Size = new System.Drawing.Size(146, 24);
            this.lblOrigenLogistica.TabIndex = 1;
            this.lblOrigenLogistica.Text = "Origen Logistica";
            // 
            // lblFolioLogistica
            // 
            this.lblFolioLogistica.AutoSize = true;
            this.lblFolioLogistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioLogistica.Location = new System.Drawing.Point(3, 41);
            this.lblFolioLogistica.Name = "lblFolioLogistica";
            this.lblFolioLogistica.Size = new System.Drawing.Size(130, 24);
            this.lblFolioLogistica.TabIndex = 2;
            this.lblFolioLogistica.Text = "Folio Logistica";
            // 
            // lblFolioLogisticaUsar
            // 
            this.lblFolioLogisticaUsar.AutoSize = true;
            this.lblFolioLogisticaUsar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioLogisticaUsar.Location = new System.Drawing.Point(156, 41);
            this.lblFolioLogisticaUsar.Name = "lblFolioLogisticaUsar";
            this.lblFolioLogisticaUsar.Size = new System.Drawing.Size(185, 24);
            this.lblFolioLogisticaUsar.TabIndex = 3;
            this.lblFolioLogisticaUsar.Text = "NO HAY LOGISTICA";
            // 
            // lblFolioTarimaUsar
            // 
            this.lblFolioTarimaUsar.AutoSize = true;
            this.lblFolioTarimaUsar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioTarimaUsar.Location = new System.Drawing.Point(156, 78);
            this.lblFolioTarimaUsar.Name = "lblFolioTarimaUsar";
            this.lblFolioTarimaUsar.Size = new System.Drawing.Size(217, 24);
            this.lblFolioTarimaUsar.TabIndex = 5;
            this.lblFolioTarimaUsar.Text = "NO HAY MAS TARIMAS";
            // 
            // lblFolioCajaUsar
            // 
            this.lblFolioCajaUsar.AutoSize = true;
            this.lblFolioCajaUsar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioCajaUsar.Location = new System.Drawing.Point(156, 118);
            this.lblFolioCajaUsar.Name = "lblFolioCajaUsar";
            this.lblFolioCajaUsar.Size = new System.Drawing.Size(194, 24);
            this.lblFolioCajaUsar.TabIndex = 7;
            this.lblFolioCajaUsar.Text = "NO HAY MAS CAJAS";
            // 
            // txtScanSKU
            // 
            this.txtScanSKU.Enabled = false;
            this.txtScanSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScanSKU.Location = new System.Drawing.Point(156, 156);
            this.txtScanSKU.Name = "txtScanSKU";
            this.txtScanSKU.Size = new System.Drawing.Size(268, 29);
            this.txtScanSKU.TabIndex = 9;
            this.txtScanSKU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScanSKU_KeyPress);
            // 
            // btnCajas
            // 
            this.btnCajas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCajas.BackgroundImage")));
            this.btnCajas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCajas.Location = new System.Drawing.Point(290, 371);
            this.btnCajas.Name = "btnCajas";
            this.btnCajas.Size = new System.Drawing.Size(111, 81);
            this.btnCajas.TabIndex = 4;
            this.btnCajas.UseVisualStyleBackColor = true;
            this.btnCajas.Click += new System.EventHandler(this.btnCajas_Click);
            // 
            // btnTarima
            // 
            this.btnTarima.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTarima.BackgroundImage")));
            this.btnTarima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTarima.Location = new System.Drawing.Point(150, 371);
            this.btnTarima.Name = "btnTarima";
            this.btnTarima.Size = new System.Drawing.Size(111, 81);
            this.btnTarima.TabIndex = 5;
            this.btnTarima.UseVisualStyleBackColor = true;
            this.btnTarima.Click += new System.EventHandler(this.btnTarima_Click);
            // 
            // btnContinuarCaja
            // 
            this.btnContinuarCaja.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnContinuarCaja.BackgroundImage")));
            this.btnContinuarCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnContinuarCaja.Location = new System.Drawing.Point(12, 555);
            this.btnContinuarCaja.Name = "btnContinuarCaja";
            this.btnContinuarCaja.Size = new System.Drawing.Size(111, 80);
            this.btnContinuarCaja.TabIndex = 6;
            this.btnContinuarCaja.UseVisualStyleBackColor = true;
            this.btnContinuarCaja.Click += new System.EventHandler(this.btnContinuarCaja_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.Location = new System.Drawing.Point(150, 555);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 80);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Folio,
            this.Cantidad,
            this.SKU,
            this.descripcion});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.Location = new System.Drawing.Point(465, 13);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(853, 693);
            this.dgvDatos.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Generar Logistica";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(155, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cerrar Tarima";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(301, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Cerrar Caja";
            // 
            // btnCerrarLogistica
            // 
            this.btnCerrarLogistica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrarLogistica.BackgroundImage")));
            this.btnCerrarLogistica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrarLogistica.Location = new System.Drawing.Point(14, 371);
            this.btnCerrarLogistica.Name = "btnCerrarLogistica";
            this.btnCerrarLogistica.Size = new System.Drawing.Size(111, 81);
            this.btnCerrarLogistica.TabIndex = 12;
            this.btnCerrarLogistica.UseVisualStyleBackColor = true;
            this.btnCerrarLogistica.Click += new System.EventHandler(this.btnCerrarLogistica_Click);
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReimprimir.BackgroundImage")));
            this.btnReimprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReimprimir.Location = new System.Drawing.Point(290, 555);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(111, 80);
            this.btnReimprimir.TabIndex = 13;
            this.btnReimprimir.UseVisualStyleBackColor = true;
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(301, 638);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Reimprimir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(177, 638);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Limpiar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 638);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Continuar Caja";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 455);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Cerrar Logistica";
            // 
            // lblOperacionActualUsar
            // 
            this.lblOperacionActualUsar.AutoSize = true;
            this.lblOperacionActualUsar.Location = new System.Drawing.Point(13, 676);
            this.lblOperacionActualUsar.Name = "lblOperacionActualUsar";
            this.lblOperacionActualUsar.Size = new System.Drawing.Size(60, 13);
            this.lblOperacionActualUsar.TabIndex = 18;
            this.lblOperacionActualUsar.Text = "CREANDO";
            this.lblOperacionActualUsar.Visible = false;
            // 
            // lblReImprimirUsar
            // 
            this.lblReImprimirUsar.AutoSize = true;
            this.lblReImprimirUsar.Location = new System.Drawing.Point(290, 675);
            this.lblReImprimirUsar.Name = "lblReImprimirUsar";
            this.lblReImprimirUsar.Size = new System.Drawing.Size(61, 13);
            this.lblReImprimirUsar.TabIndex = 19;
            this.lblReImprimirUsar.Text = "ETIQUETA";
            this.lblReImprimirUsar.Visible = false;
            // 
            // Folio
            // 
            this.Folio.DataPropertyName = "folio";
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            this.Folio.Width = 90;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 50;
            // 
            // SKU
            // 
            this.SKU.DataPropertyName = "sku";
            this.SKU.HeaderText = "SKU";
            this.SKU.Name = "SKU";
            this.SKU.ReadOnly = true;
            this.SKU.Width = 90;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 580;
            // 
            // frmScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 718);
            this.Controls.Add(this.lblReImprimirUsar);
            this.Controls.Add(this.lblOperacionActualUsar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReimprimir);
            this.Controls.Add(this.btnCerrarLogistica);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnContinuarCaja);
            this.Controls.Add(this.btnTarima);
            this.Controls.Add(this.btnCajas);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnAgregarLogistica);
            this.Name = "frmScan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmScan";
            this.Load += new System.EventHandler(this.frmScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.liorigenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetOrigenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetOrigen)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlOrigen;
        private System.Windows.Forms.Button btnAgregarLogistica;
        private System.Windows.Forms.BindingSource dataSetOrigenBindingSource;
        private DataSets.DataSetOrigen dataSetOrigen;
        private System.Windows.Forms.BindingSource liorigenBindingSource;
        private DataSets.DataSetOrigenTableAdapters.li_origenTableAdapter li_origenTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblOrigenLogistica;
        private System.Windows.Forms.Label lblFolioLogistica;
        private System.Windows.Forms.Label lblFolioLogisticaUsar;
        private System.Windows.Forms.Label lblFolioTarima;
        private System.Windows.Forms.Label lblFolioTarimaUsar;
        private System.Windows.Forms.Label lblFolioCaja;
        private System.Windows.Forms.Label lblFolioCajaUsar;
        private System.Windows.Forms.Button btnCajas;
        private System.Windows.Forms.Button btnTarima;
        private System.Windows.Forms.Button btnContinuarCaja;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtScanSKU;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCerrarLogistica;
        private System.Windows.Forms.Button btnReimprimir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOperacionActualUsar;
        private System.Windows.Forms.Label lblReImprimirUsar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}