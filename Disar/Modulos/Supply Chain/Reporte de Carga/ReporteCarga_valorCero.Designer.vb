<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteCarga_valorCero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteCarga_valorCero))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.grdBodega = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me.folio_fin = New System.Windows.Forms.Label
        Me.folio_ini = New System.Windows.Forms.Label
        Me.cmbFecha = New System.Windows.Forms.DateTimePicker
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox
        Me.cmbSucursal = New System.Windows.Forms.ComboBox
        Me._btnLimpiar = New System.Windows.Forms.Button
        Me._txtHasta = New System.Windows.Forms.TextBox
        Me._txtDesde = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Unidadesbodega = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.pesobodega = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.rango = New System.Windows.Forms.Label
        Me.Contenedor = New System.Windows.Forms.TabControl
        Me.Bodega = New System.Windows.Forms.TabPage
        Me.Contado = New System.Windows.Forms.TabPage
        Me.Label11 = New System.Windows.Forms.Label
        Me.pesocontado = New System.Windows.Forms.Label
        Me.unidadescontado = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.grdContado = New System.Windows.Forms.DataGridView
        Me.Credito = New System.Windows.Forms.TabPage
        Me.Label19 = New System.Windows.Forms.Label
        Me.pesocredito = New System.Windows.Forms.Label
        Me.unidadescredito = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.grdCredito = New System.Windows.Forms.DataGridView
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grdBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Contenedor.SuspendLayout()
        Me.Bodega.SuspendLayout()
        Me.Contado.SuspendLayout()
        CType(Me.grdContado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Credito.SuspendLayout()
        CType(Me.grdCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1121, 55)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.Reportes
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(107, 52)
        Me.ToolStripButton1.Tag = "Exportar"
        Me.ToolStripButton1.Text = "Exportar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
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
        Me.grdBodega.Location = New System.Drawing.Point(6, 25)
        Me.grdBodega.Name = "grdBodega"
        Me.grdBodega.ReadOnly = True
        Me.grdBodega.Size = New System.Drawing.Size(1077, 360)
        Me.grdBodega.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Imagen)
        Me.GroupBox1.Controls.Add(Me.folio_fin)
        Me.GroupBox1.Controls.Add(Me.folio_ini)
        Me.GroupBox1.Controls.Add(Me.cmbFecha)
        Me.GroupBox1.Controls.Add(Me.cmbAlmacen)
        Me.GroupBox1.Controls.Add(Me.cmbSucursal)
        Me.GroupBox1.Controls.Add(Me._btnLimpiar)
        Me.GroupBox1.Controls.Add(Me._txtHasta)
        Me.GroupBox1.Controls.Add(Me._txtDesde)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me._btnGenerar)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1097, 76)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(979, 16)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(108, 19)
        Me.CheckBox1.TabIndex = 13
        Me.CheckBox1.Text = "Ocultar Totales"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Imagen
        '
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.wtSR
        Me.Imagen.Location = New System.Drawing.Point(7, 13)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(21, 15)
        Me.Imagen.TabIndex = 11
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        'folio_fin
        '
        Me.folio_fin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.folio_fin.AutoSize = True
        Me.folio_fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folio_fin.Location = New System.Drawing.Point(562, 47)
        Me.folio_fin.Name = "folio_fin"
        Me.folio_fin.Size = New System.Drawing.Size(0, 15)
        Me.folio_fin.TabIndex = 10
        '
        'folio_ini
        '
        Me.folio_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.folio_ini.AutoSize = True
        Me.folio_ini.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folio_ini.Location = New System.Drawing.Point(200, 47)
        Me.folio_ini.Name = "folio_ini"
        Me.folio_ini.Size = New System.Drawing.Size(0, 15)
        Me.folio_ini.TabIndex = 10
        '
        'cmbFecha
        '
        Me.cmbFecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbFecha.Location = New System.Drawing.Point(623, 13)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.Size = New System.Drawing.Size(245, 21)
        Me.cmbFecha.TabIndex = 3
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(404, 11)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(167, 23)
        Me.cmbAlmacen.TabIndex = 2
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(194, 11)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(144, 23)
        Me.cmbSucursal.TabIndex = 1
        '
        '_btnLimpiar
        '
        Me._btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnLimpiar.Location = New System.Drawing.Point(888, 44)
        Me._btnLimpiar.Name = "_btnLimpiar"
        Me._btnLimpiar.Size = New System.Drawing.Size(77, 27)
        Me._btnLimpiar.TabIndex = 7
        Me._btnLimpiar.Text = "Limpiar"
        Me._btnLimpiar.UseVisualStyleBackColor = True
        '
        '_txtHasta
        '
        Me._txtHasta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._txtHasta.Location = New System.Drawing.Point(680, 44)
        Me._txtHasta.Name = "_txtHasta"
        Me._txtHasta.Size = New System.Drawing.Size(188, 21)
        Me._txtHasta.TabIndex = 5
        Me._txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        '_txtDesde
        '
        Me._txtDesde.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._txtDesde.Location = New System.Drawing.Point(309, 44)
        Me._txtDesde.Name = "_txtDesde"
        Me._txtDesde.Size = New System.Drawing.Size(191, 21)
        Me._txtDesde.TabIndex = 4
        Me._txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(577, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 15)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Fecha:"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(346, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Almacen:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(514, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Hasta:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(134, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Empresa:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(148, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Desde:"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Location = New System.Drawing.Point(888, 13)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(77, 26)
        Me._btnGenerar.TabIndex = 6
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(722, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Total Unidades:"
        '
        'Unidadesbodega
        '
        Me.Unidadesbodega.AutoSize = True
        Me.Unidadesbodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Unidadesbodega.Location = New System.Drawing.Point(836, 7)
        Me.Unidadesbodega.Name = "Unidadesbodega"
        Me.Unidadesbodega.Size = New System.Drawing.Size(23, 15)
        Me.Unidadesbodega.TabIndex = 10
        Me.Unidadesbodega.Text = "    "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(389, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Total en Peso:"
        '
        'pesobodega
        '
        Me.pesobodega.AutoSize = True
        Me.pesobodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pesobodega.Location = New System.Drawing.Point(494, 7)
        Me.pesobodega.Name = "pesobodega"
        Me.pesobodega.Size = New System.Drawing.Size(23, 15)
        Me.pesobodega.TabIndex = 10
        Me.pesobodega.Text = "    "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(55, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Rango Facturas:"
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
        'Contenedor
        '
        Me.Contenedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Contenedor.Controls.Add(Me.Bodega)
        Me.Contenedor.Controls.Add(Me.Contado)
        Me.Contenedor.Controls.Add(Me.Credito)
        Me.Contenedor.Location = New System.Drawing.Point(12, 126)
        Me.Contenedor.Name = "Contenedor"
        Me.Contenedor.SelectedIndex = 0
        Me.Contenedor.Size = New System.Drawing.Size(1097, 417)
        Me.Contenedor.TabIndex = 11
        '
        'Bodega
        '
        Me.Bodega.Controls.Add(Me.grdBodega)
        Me.Bodega.Controls.Add(Me.rango)
        Me.Bodega.Controls.Add(Me.Label3)
        Me.Bodega.Controls.Add(Me.pesobodega)
        Me.Bodega.Controls.Add(Me.Unidadesbodega)
        Me.Bodega.Controls.Add(Me.Label4)
        Me.Bodega.Controls.Add(Me.Label7)
        Me.Bodega.Location = New System.Drawing.Point(4, 22)
        Me.Bodega.Name = "Bodega"
        Me.Bodega.Padding = New System.Windows.Forms.Padding(3)
        Me.Bodega.Size = New System.Drawing.Size(1089, 391)
        Me.Bodega.TabIndex = 0
        Me.Bodega.Text = "Bodega"
        Me.Bodega.UseVisualStyleBackColor = True
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
        Me.Contado.Size = New System.Drawing.Size(1089, 391)
        Me.Contado.TabIndex = 1
        Me.Contado.Text = "Contado"
        Me.Contado.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(657, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 15)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Total Unidades:"
        '
        'pesocontado
        '
        Me.pesocontado.AutoSize = True
        Me.pesocontado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pesocontado.Location = New System.Drawing.Point(299, 3)
        Me.pesocontado.Name = "pesocontado"
        Me.pesocontado.Size = New System.Drawing.Size(23, 15)
        Me.pesocontado.TabIndex = 18
        Me.pesocontado.Text = "    "
        '
        'unidadescontado
        '
        Me.unidadescontado.AutoSize = True
        Me.unidadescontado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unidadescontado.Location = New System.Drawing.Point(771, 3)
        Me.unidadescontado.Name = "unidadescontado"
        Me.unidadescontado.Size = New System.Drawing.Size(23, 15)
        Me.unidadescontado.TabIndex = 17
        Me.unidadescontado.Text = "    "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(194, 3)
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
        Me.grdContado.Location = New System.Drawing.Point(6, 21)
        Me.grdContado.Name = "grdContado"
        Me.grdContado.ReadOnly = True
        Me.grdContado.Size = New System.Drawing.Size(949, 364)
        Me.grdContado.TabIndex = 9
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
        Me.Credito.Size = New System.Drawing.Size(1089, 391)
        Me.Credito.TabIndex = 2
        Me.Credito.Text = "Credito"
        Me.Credito.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(636, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 15)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "Total Unidades:"
        '
        'pesocredito
        '
        Me.pesocredito.AutoSize = True
        Me.pesocredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pesocredito.Location = New System.Drawing.Point(278, 3)
        Me.pesocredito.Name = "pesocredito"
        Me.pesocredito.Size = New System.Drawing.Size(23, 15)
        Me.pesocredito.TabIndex = 18
        Me.pesocredito.Text = "    "
        '
        'unidadescredito
        '
        Me.unidadescredito.AutoSize = True
        Me.unidadescredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unidadescredito.Location = New System.Drawing.Point(750, 3)
        Me.unidadescredito.Name = "unidadescredito"
        Me.unidadescredito.Size = New System.Drawing.Size(23, 15)
        Me.unidadescredito.TabIndex = 17
        Me.unidadescredito.Text = "    "
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(173, 3)
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
        Me.grdCredito.Size = New System.Drawing.Size(949, 364)
        Me.grdCredito.TabIndex = 9
        '
        'ReporteCarga_valorCero
        '
        Me.AcceptButton = Me._btnGenerar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1121, 555)
        Me.Controls.Add(Me.Contenedor)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReporteCarga_valorCero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Carga"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grdBodega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Contenedor.ResumeLayout(False)
        Me.Bodega.ResumeLayout(False)
        Me.Bodega.PerformLayout()
        Me.Contado.ResumeLayout(False)
        Me.Contado.PerformLayout()
        CType(Me.grdContado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Credito.ResumeLayout(False)
        Me.Credito.PerformLayout()
        CType(Me.grdCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grdBodega As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _txtHasta As System.Windows.Forms.TextBox
    Friend WithEvents _txtDesde As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents _btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Unidadesbodega As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pesobodega As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rango As System.Windows.Forms.Label
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Contenedor As System.Windows.Forms.TabControl
    Friend WithEvents Bodega As System.Windows.Forms.TabPage
    Friend WithEvents Contado As System.Windows.Forms.TabPage
    Friend WithEvents Credito As System.Windows.Forms.TabPage
    Friend WithEvents grdContado As System.Windows.Forms.DataGridView
    Friend WithEvents grdCredito As System.Windows.Forms.DataGridView
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents folio_fin As System.Windows.Forms.Label
    Friend WithEvents folio_ini As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pesocontado As System.Windows.Forms.Label
    Friend WithEvents unidadescontado As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents pesocredito As System.Windows.Forms.Label
    Friend WithEvents unidadescredito As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
