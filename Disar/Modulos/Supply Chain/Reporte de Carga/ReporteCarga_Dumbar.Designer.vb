<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteCarga_Dumbar
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteCarga_Dumbar))
        Me.Label11 = New System.Windows.Forms.Label
        Me.Contado = New System.Windows.Forms.TabPage
        Me.pesocontado = New System.Windows.Forms.Label
        Me.unidadescontado = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.grdContado = New System.Windows.Forms.DataGridView
        Me.Label15 = New System.Windows.Forms.Label
        Me.dinerocontado = New System.Windows.Forms.Label
        Me.Bodega = New System.Windows.Forms.TabPage
        Me.grdBodega = New System.Windows.Forms.DataGridView
        Me.rango = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.pesobodega = New System.Windows.Forms.Label
        Me.Unidadesbodega = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dinerobodega = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Contenedor = New System.Windows.Forms.TabControl
        Me.Credito = New System.Windows.Forms.TabPage
        Me.Label19 = New System.Windows.Forms.Label
        Me.pesocredito = New System.Windows.Forms.Label
        Me.unidadescredito = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.grdCredito = New System.Windows.Forms.DataGridView
        Me.Label23 = New System.Windows.Forms.Label
        Me.dinerocredito = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmbFecha = New System.Windows.Forms.DateTimePicker
        Me.cmbEntregador = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me.cmbFecha2 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dinerodevoluciones = New System.Windows.Forms.Label
        Me.TotalDineroMDev = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Rangos = New System.Windows.Forms.DataGridView
        Me.Rango_Inicial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rango_Final = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.RangosContado = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Devoluciones = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.RangosCredito = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FacturasContado = New System.Windows.Forms.DataGridView
        Me.FacturasCredito = New System.Windows.Forms.DataGridView
        Me.Label13 = New System.Windows.Forms.Label
        Me.ComboSucursal = New System.Windows.Forms.ComboBox
        Me.Contado.SuspendLayout()
        CType(Me.grdContado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bodega.SuspendLayout()
        CType(Me.grdBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Contenedor.SuspendLayout()
        Me.Credito.SuspendLayout()
        CType(Me.grdCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rangos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RangosContado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RangosCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FacturasContado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FacturasCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(652, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 15)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Total Unidades:"
        '
        'Contado
        '
        Me.Contado.Controls.Add(Me.Label11)
        Me.Contado.Controls.Add(Me.pesocontado)
        Me.Contado.Controls.Add(Me.unidadescontado)
        Me.Contado.Controls.Add(Me.Label17)
        Me.Contado.Controls.Add(Me.grdContado)
        Me.Contado.Location = New System.Drawing.Point(4, 22)
        Me.Contado.Name = "Contado"
        Me.Contado.Padding = New System.Windows.Forms.Padding(3)
        Me.Contado.Size = New System.Drawing.Size(87, 3)
        Me.Contado.TabIndex = 1
        Me.Contado.Text = "Contado"
        Me.Contado.UseVisualStyleBackColor = True
        '
        'pesocontado
        '
        Me.pesocontado.AutoSize = True
        Me.pesocontado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pesocontado.Location = New System.Drawing.Point(528, 3)
        Me.pesocontado.Name = "pesocontado"
        Me.pesocontado.Size = New System.Drawing.Size(23, 15)
        Me.pesocontado.TabIndex = 18
        Me.pesocontado.Text = "    "
        '
        'unidadescontado
        '
        Me.unidadescontado.AutoSize = True
        Me.unidadescontado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unidadescontado.Location = New System.Drawing.Point(766, 3)
        Me.unidadescontado.Name = "unidadescontado"
        Me.unidadescontado.Size = New System.Drawing.Size(23, 15)
        Me.unidadescontado.TabIndex = 17
        Me.unidadescontado.Text = "    "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(423, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 15)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Total en Peso:"
        '
        'grdContado
        '
        Me.grdContado.AllowUserToAddRows = False
        Me.grdContado.AllowUserToDeleteRows = False
        Me.grdContado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdContado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdContado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdContado.Location = New System.Drawing.Point(6, 30)
        Me.grdContado.Name = "grdContado"
        Me.grdContado.ReadOnly = True
        Me.grdContado.Size = New System.Drawing.Size(191, 25)
        Me.grdContado.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(29, 144)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 15)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Total Contado:"
        '
        'dinerocontado
        '
        Me.dinerocontado.AutoSize = True
        Me.dinerocontado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dinerocontado.Location = New System.Drawing.Point(173, 144)
        Me.dinerocontado.Name = "dinerocontado"
        Me.dinerocontado.Size = New System.Drawing.Size(23, 15)
        Me.dinerocontado.TabIndex = 14
        Me.dinerocontado.Text = "    "
        '
        'Bodega
        '
        Me.Bodega.Controls.Add(Me.grdBodega)
        Me.Bodega.Controls.Add(Me.rango)
        Me.Bodega.Location = New System.Drawing.Point(4, 22)
        Me.Bodega.Name = "Bodega"
        Me.Bodega.Padding = New System.Windows.Forms.Padding(3)
        Me.Bodega.Size = New System.Drawing.Size(87, 3)
        Me.Bodega.TabIndex = 0
        Me.Bodega.Text = "Bodega"
        Me.Bodega.UseVisualStyleBackColor = True
        '
        'grdBodega
        '
        Me.grdBodega.AllowUserToAddRows = False
        Me.grdBodega.AllowUserToDeleteRows = False
        Me.grdBodega.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdBodega.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdBodega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBodega.Location = New System.Drawing.Point(6, 21)
        Me.grdBodega.Name = "grdBodega"
        Me.grdBodega.ReadOnly = True
        Me.grdBodega.Size = New System.Drawing.Size(75, 0)
        Me.grdBodega.TabIndex = 8
        '
        'rango
        '
        Me.rango.AutoSize = True
        Me.rango.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rango.Location = New System.Drawing.Point(173, 7)
        Me.rango.Name = "rango"
        Me.rango.Size = New System.Drawing.Size(23, 15)
        Me.rango.TabIndex = 10
        Me.rango.Text = "    "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(313, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Total Unidades:"
        '
        'pesobodega
        '
        Me.pesobodega.AutoSize = True
        Me.pesobodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pesobodega.Location = New System.Drawing.Point(474, 144)
        Me.pesobodega.Name = "pesobodega"
        Me.pesobodega.Size = New System.Drawing.Size(23, 15)
        Me.pesobodega.TabIndex = 10
        Me.pesobodega.Text = "    "
        '
        'Unidadesbodega
        '
        Me.Unidadesbodega.AutoSize = True
        Me.Unidadesbodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Unidadesbodega.Location = New System.Drawing.Point(474, 162)
        Me.Unidadesbodega.Name = "Unidadesbodega"
        Me.Unidadesbodega.Size = New System.Drawing.Size(23, 15)
        Me.Unidadesbodega.TabIndex = 10
        Me.Unidadesbodega.Text = "    "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Total  Dinero:"
        '
        'dinerobodega
        '
        Me.dinerobodega.AutoSize = True
        Me.dinerobodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dinerobodega.Location = New System.Drawing.Point(173, 194)
        Me.dinerobodega.Name = "dinerobodega"
        Me.dinerobodega.Size = New System.Drawing.Size(23, 15)
        Me.dinerobodega.TabIndex = 10
        Me.dinerobodega.Text = "    "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(313, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Total en Peso:"
        '
        'Contenedor
        '
        Me.Contenedor.Controls.Add(Me.Bodega)
        Me.Contenedor.Controls.Add(Me.Contado)
        Me.Contenedor.Controls.Add(Me.Credito)
        Me.Contenedor.Location = New System.Drawing.Point(85, 78)
        Me.Contenedor.Name = "Contenedor"
        Me.Contenedor.SelectedIndex = 0
        Me.Contenedor.Size = New System.Drawing.Size(95, 29)
        Me.Contenedor.TabIndex = 14
        Me.Contenedor.Visible = False
        '
        'Credito
        '
        Me.Credito.Controls.Add(Me.Label19)
        Me.Credito.Controls.Add(Me.pesocredito)
        Me.Credito.Controls.Add(Me.unidadescredito)
        Me.Credito.Controls.Add(Me.Label25)
        Me.Credito.Controls.Add(Me.grdCredito)
        Me.Credito.Location = New System.Drawing.Point(4, 22)
        Me.Credito.Name = "Credito"
        Me.Credito.Padding = New System.Windows.Forms.Padding(3)
        Me.Credito.Size = New System.Drawing.Size(87, 3)
        Me.Credito.TabIndex = 2
        Me.Credito.Text = "Credito"
        Me.Credito.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(652, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 15)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "Total Unidades:"
        '
        'pesocredito
        '
        Me.pesocredito.AutoSize = True
        Me.pesocredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pesocredito.Location = New System.Drawing.Point(528, 3)
        Me.pesocredito.Name = "pesocredito"
        Me.pesocredito.Size = New System.Drawing.Size(23, 15)
        Me.pesocredito.TabIndex = 18
        Me.pesocredito.Text = "    "
        '
        'unidadescredito
        '
        Me.unidadescredito.AutoSize = True
        Me.unidadescredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unidadescredito.Location = New System.Drawing.Point(766, 3)
        Me.unidadescredito.Name = "unidadescredito"
        Me.unidadescredito.Size = New System.Drawing.Size(23, 15)
        Me.unidadescredito.TabIndex = 17
        Me.unidadescredito.Text = "    "
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(423, 3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(99, 15)
        Me.Label25.TabIndex = 13
        Me.Label25.Text = "Total en Peso:"
        '
        'grdCredito
        '
        Me.grdCredito.AllowUserToAddRows = False
        Me.grdCredito.AllowUserToDeleteRows = False
        Me.grdCredito.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCredito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCredito.Location = New System.Drawing.Point(6, 21)
        Me.grdCredito.Name = "grdCredito"
        Me.grdCredito.ReadOnly = True
        Me.grdCredito.Size = New System.Drawing.Size(940, 229)
        Me.grdCredito.TabIndex = 9
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(29, 162)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(93, 15)
        Me.Label23.TabIndex = 11
        Me.Label23.Text = "Total Crédito:"
        '
        'dinerocredito
        '
        Me.dinerocredito.AutoSize = True
        Me.dinerocredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dinerocredito.Location = New System.Drawing.Point(173, 162)
        Me.dinerocredito.Name = "dinerocredito"
        Me.dinerocredito.Size = New System.Drawing.Size(23, 15)
        Me.dinerocredito.TabIndex = 14
        Me.dinerocredito.Text = "    "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(990, 39)
        Me.ToolStrip1.TabIndex = 13
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.MailGreenHover
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(80, 36)
        Me.ToolStripButton1.Tag = "Enviar correo a "
        Me.ToolStripButton1.Text = "Enviar "
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'cmbFecha
        '
        Me.cmbFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFecha.Location = New System.Drawing.Point(636, 19)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.Size = New System.Drawing.Size(227, 21)
        Me.cmbFecha.TabIndex = 2
        '
        'cmbEntregador
        '
        Me.cmbEntregador.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEntregador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbEntregador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEntregador.FormattingEnabled = True
        Me.cmbEntregador.Items.AddRange(New Object() {"CONSUMO", "SR AGRO"})
        Me.cmbEntregador.Location = New System.Drawing.Point(357, 45)
        Me.cmbEntregador.Name = "cmbEntregador"
        Me.cmbEntregador.Size = New System.Drawing.Size(229, 23)
        Me.cmbEntregador.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ComboSucursal)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Imagen)
        Me.GroupBox1.Controls.Add(Me.cmbFecha2)
        Me.GroupBox1.Controls.Add(Me.cmbFecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbEntregador)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me._btnGenerar)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(966, 76)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Imagen
        '
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.wtSR
        Me.Imagen.Location = New System.Drawing.Point(7, 11)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(187, 61)
        Me.Imagen.TabIndex = 11
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        'cmbFecha2
        '
        Me.cmbFecha2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFecha2.Location = New System.Drawing.Point(636, 46)
        Me.cmbFecha2.Name = "cmbFecha2"
        Me.cmbFecha2.Size = New System.Drawing.Size(227, 21)
        Me.cmbFecha2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(592, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Hasta:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(287, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Entregador:"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._btnGenerar.Location = New System.Drawing.Point(875, 22)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(85, 42)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(592, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 15)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Desde:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 215)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Devoluciones:"
        '
        'dinerodevoluciones
        '
        Me.dinerodevoluciones.AutoSize = True
        Me.dinerodevoluciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dinerodevoluciones.Location = New System.Drawing.Point(173, 215)
        Me.dinerodevoluciones.Name = "dinerodevoluciones"
        Me.dinerodevoluciones.Size = New System.Drawing.Size(23, 15)
        Me.dinerodevoluciones.TabIndex = 10
        Me.dinerodevoluciones.Text = "    "
        '
        'TotalDineroMDev
        '
        Me.TotalDineroMDev.AutoSize = True
        Me.TotalDineroMDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalDineroMDev.Location = New System.Drawing.Point(173, 243)
        Me.TotalDineroMDev.Name = "TotalDineroMDev"
        Me.TotalDineroMDev.Size = New System.Drawing.Size(23, 15)
        Me.TotalDineroMDev.TabIndex = 10
        Me.TotalDineroMDev.Text = "    "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "TOTAL:"
        '
        'Rangos
        '
        Me.Rangos.AllowUserToAddRows = False
        Me.Rangos.AllowUserToDeleteRows = False
        Me.Rangos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Rangos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Rangos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rango_Inicial, Me.Rango_Final})
        Me.Rangos.Location = New System.Drawing.Point(569, 193)
        Me.Rangos.Name = "Rangos"
        Me.Rangos.ReadOnly = True
        Me.Rangos.RowHeadersVisible = False
        Me.Rangos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Rangos.Size = New System.Drawing.Size(409, 101)
        Me.Rangos.TabIndex = 15
        '
        'Rango_Inicial
        '
        Me.Rango_Inicial.HeaderText = "Inicio"
        Me.Rango_Inicial.Name = "Rango_Inicial"
        Me.Rango_Inicial.ReadOnly = True
        '
        'Rango_Final
        '
        Me.Rango_Final.HeaderText = "Final"
        Me.Rango_Final.Name = "Rango_Final"
        Me.Rango_Final.ReadOnly = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(566, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(202, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Rangos de Facturas [General]:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(569, 300)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(409, 256)
        Me.DataGridView1.TabIndex = 16
        '
        'RangosContado
        '
        Me.RangosContado.AllowUserToAddRows = False
        Me.RangosContado.AllowUserToDeleteRows = False
        Me.RangosContado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.RangosContado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RangosContado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Total, Me.Devoluciones})
        Me.RangosContado.Location = New System.Drawing.Point(19, 300)
        Me.RangosContado.Name = "RangosContado"
        Me.RangosContado.ReadOnly = True
        Me.RangosContado.RowHeadersVisible = False
        Me.RangosContado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.RangosContado.Size = New System.Drawing.Size(544, 114)
        Me.RangosContado.TabIndex = 15
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Inicio"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Final"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'Devoluciones
        '
        Me.Devoluciones.HeaderText = "Devoluciones"
        Me.Devoluciones.Name = "Devoluciones"
        Me.Devoluciones.ReadOnly = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 282)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 15)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Rangos de Contado"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 424)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 15)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Rangos de Crédito"
        '
        'RangosCredito
        '
        Me.RangosCredito.AllowUserToAddRows = False
        Me.RangosCredito.AllowUserToDeleteRows = False
        Me.RangosCredito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.RangosCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RangosCredito.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.RangosCredito.Location = New System.Drawing.Point(19, 442)
        Me.RangosCredito.Name = "RangosCredito"
        Me.RangosCredito.ReadOnly = True
        Me.RangosCredito.RowHeadersVisible = False
        Me.RangosCredito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.RangosCredito.Size = New System.Drawing.Size(544, 114)
        Me.RangosCredito.TabIndex = 15
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Inicio"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Final"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Devoluciones"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'FacturasContado
        '
        Me.FacturasContado.AllowUserToAddRows = False
        Me.FacturasContado.AllowUserToDeleteRows = False
        Me.FacturasContado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FacturasContado.Location = New System.Drawing.Point(238, 102)
        Me.FacturasContado.Name = "FacturasContado"
        Me.FacturasContado.ReadOnly = True
        Me.FacturasContado.Size = New System.Drawing.Size(29, 12)
        Me.FacturasContado.TabIndex = 17
        '
        'FacturasCredito
        '
        Me.FacturasCredito.AllowUserToAddRows = False
        Me.FacturasCredito.AllowUserToDeleteRows = False
        Me.FacturasCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FacturasCredito.Location = New System.Drawing.Point(489, 88)
        Me.FacturasCredito.Name = "FacturasCredito"
        Me.FacturasCredito.ReadOnly = True
        Me.FacturasCredito.Size = New System.Drawing.Size(58, 17)
        Me.FacturasCredito.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(287, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 15)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Empresa:"
        '
        'ComboSucursal
        '
        Me.ComboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSucursal.FormattingEnabled = True
        Me.ComboSucursal.Location = New System.Drawing.Point(357, 16)
        Me.ComboSucursal.Name = "ComboSucursal"
        Me.ComboSucursal.Size = New System.Drawing.Size(229, 23)
        Me.ComboSucursal.TabIndex = 13
        '
        'ReporteCarga_Dumbar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 568)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pesobodega)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Unidadesbodega)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dinerocredito)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dinerocontado)
        Me.Controls.Add(Me.TotalDineroMDev)
        Me.Controls.Add(Me.dinerodevoluciones)
        Me.Controls.Add(Me.dinerobodega)
        Me.Controls.Add(Me.Contenedor)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Rangos)
        Me.Controls.Add(Me.RangosContado)
        Me.Controls.Add(Me.RangosCredito)
        Me.Controls.Add(Me.FacturasCredito)
        Me.Controls.Add(Me.FacturasContado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReporteCarga_Dumbar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Dunbar"
        Me.Contado.ResumeLayout(False)
        Me.Contado.PerformLayout()
        CType(Me.grdContado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bodega.ResumeLayout(False)
        Me.Bodega.PerformLayout()
        CType(Me.grdBodega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Contenedor.ResumeLayout(False)
        Me.Credito.ResumeLayout(False)
        Me.Credito.PerformLayout()
        CType(Me.grdCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rangos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RangosContado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RangosCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FacturasContado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FacturasCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Contado As System.Windows.Forms.TabPage
    Friend WithEvents pesocontado As System.Windows.Forms.Label
    Friend WithEvents unidadescontado As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dinerocontado As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents grdContado As System.Windows.Forms.DataGridView
    Friend WithEvents Bodega As System.Windows.Forms.TabPage
    Friend WithEvents grdBodega As System.Windows.Forms.DataGridView
    Friend WithEvents rango As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pesobodega As System.Windows.Forms.Label
    Friend WithEvents Unidadesbodega As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dinerobodega As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Contenedor As System.Windows.Forms.TabControl
    Friend WithEvents Credito As System.Windows.Forms.TabPage
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents pesocredito As System.Windows.Forms.Label
    Friend WithEvents unidadescredito As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dinerocredito As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents grdCredito As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents cmbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbEntregador As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dinerodevoluciones As System.Windows.Forms.Label
    Friend WithEvents TotalDineroMDev As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Rangos As System.Windows.Forms.DataGridView
    Friend WithEvents Rango_Inicial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rango_Final As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents RangosContado As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Devoluciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RangosCredito As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FacturasContado As System.Windows.Forms.DataGridView
    Friend WithEvents FacturasCredito As System.Windows.Forms.DataGridView
    Friend WithEvents ComboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
