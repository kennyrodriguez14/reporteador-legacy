<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Vista
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Vista))
        Me.TextTipoGranja = New System.Windows.Forms.TextBox
        Me.TextAnimales = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextUbicacion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextVendedor = New System.Windows.Forms.TextBox
        Me.TextDia = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextIDRTN = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextListas = New System.Windows.Forms.TextBox
        Me.TextClaveCliente = New System.Windows.Forms.TextBox
        Me.TextNombreCliente = New System.Windows.Forms.TextBox
        Me.TextManzanas = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.BtnFiltroFechas = New System.Windows.Forms.Button
        Me.TextTieneMascota = New System.Windows.Forms.TextBox
        Me.DataCompras = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.DataDevolucion = New System.Windows.Forms.DataGridView
        Me.DataCancela = New System.Windows.Forms.DataGridView
        Me.BtnFiltro = New System.Windows.Forms.Button
        Me.TextMarcas = New System.Windows.Forms.TextBox
        Me.GroupFechas = New System.Windows.Forms.GroupBox
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextFecha = New System.Windows.Forms.TextBox
        Me.TextTotalFacturas = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Progress = New System.Windows.Forms.ProgressBar
        Me.BtnDetalle = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.LabelDesde = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.DataDetalles = New System.Windows.Forms.DataGridView
        Me.DataDevolucionDetalles = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextPorque = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextAgroservicio = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextCultivos = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupFacturas = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.CantidadFact = New System.Windows.Forms.NumericUpDown
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataDevolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCancela, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupFechas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataDevolucionDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupFacturas.SuspendLayout()
        CType(Me.CantidadFact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextTipoGranja
        '
        Me.TextTipoGranja.Location = New System.Drawing.Point(361, 52)
        Me.TextTipoGranja.Name = "TextTipoGranja"
        Me.TextTipoGranja.ReadOnly = True
        Me.TextTipoGranja.Size = New System.Drawing.Size(177, 20)
        Me.TextTipoGranja.TabIndex = 7
        '
        'TextAnimales
        '
        Me.TextAnimales.Location = New System.Drawing.Point(601, 39)
        Me.TextAnimales.Multiline = True
        Me.TextAnimales.Name = "TextAnimales"
        Me.TextAnimales.ReadOnly = True
        Me.TextAnimales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextAnimales.Size = New System.Drawing.Size(137, 33)
        Me.TextAnimales.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(540, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "# Animales:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(540, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Tiene Mascota:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextUbicacion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextVendedor)
        Me.GroupBox1.Controls.Add(Me.TextDia)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextIDRTN)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextListas)
        Me.GroupBox1.Controls.Add(Me.TextClaveCliente)
        Me.GroupBox1.Controls.Add(Me.TextNombreCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 122)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 97)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 13)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "Día de visita:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(247, 98)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 13)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Vendedor:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Dirección:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "ID / RTN de Cliente:"
        '
        'TextUbicacion
        '
        Me.TextUbicacion.Location = New System.Drawing.Point(312, 42)
        Me.TextUbicacion.Name = "TextUbicacion"
        Me.TextUbicacion.ReadOnly = True
        Me.TextUbicacion.Size = New System.Drawing.Size(289, 20)
        Me.TextUbicacion.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Clave de Cliente:"
        '
        'TextVendedor
        '
        Me.TextVendedor.Location = New System.Drawing.Point(312, 94)
        Me.TextVendedor.Name = "TextVendedor"
        Me.TextVendedor.ReadOnly = True
        Me.TextVendedor.Size = New System.Drawing.Size(288, 20)
        Me.TextVendedor.TabIndex = 3
        '
        'TextDia
        '
        Me.TextDia.Location = New System.Drawing.Point(110, 94)
        Me.TextDia.Name = "TextDia"
        Me.TextDia.ReadOnly = True
        Me.TextDia.Size = New System.Drawing.Size(131, 20)
        Me.TextDia.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(68, 67)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(302, 20)
        Me.TextBox1.TabIndex = 3
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(434, 67)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(166, 20)
        Me.TextBox2.TabIndex = 3
        '
        'TextIDRTN
        '
        Me.TextIDRTN.Location = New System.Drawing.Point(110, 42)
        Me.TextIDRTN.Name = "TextIDRTN"
        Me.TextIDRTN.ReadOnly = True
        Me.TextIDRTN.Size = New System.Drawing.Size(131, 20)
        Me.TextIDRTN.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(209, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre de Cliente:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(635, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 12)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Listas de precios:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(376, 70)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Teléfono:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(247, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ubicación:"
        '
        'TextListas
        '
        Me.TextListas.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextListas.Location = New System.Drawing.Point(629, 26)
        Me.TextListas.Multiline = True
        Me.TextListas.Name = "TextListas"
        Me.TextListas.ReadOnly = True
        Me.TextListas.Size = New System.Drawing.Size(108, 78)
        Me.TextListas.TabIndex = 1
        '
        'TextClaveCliente
        '
        Me.TextClaveCliente.Location = New System.Drawing.Point(110, 16)
        Me.TextClaveCliente.Name = "TextClaveCliente"
        Me.TextClaveCliente.ReadOnly = True
        Me.TextClaveCliente.Size = New System.Drawing.Size(93, 20)
        Me.TextClaveCliente.TabIndex = 1
        '
        'TextNombreCliente
        '
        Me.TextNombreCliente.Location = New System.Drawing.Point(312, 16)
        Me.TextNombreCliente.Name = "TextNombreCliente"
        Me.TextNombreCliente.ReadOnly = True
        Me.TextNombreCliente.Size = New System.Drawing.Size(289, 20)
        Me.TextNombreCliente.TabIndex = 2
        '
        'TextManzanas
        '
        Me.TextManzanas.Location = New System.Drawing.Point(361, 13)
        Me.TextManzanas.Multiline = True
        Me.TextManzanas.Name = "TextManzanas"
        Me.TextManzanas.ReadOnly = True
        Me.TextManzanas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextManzanas.Size = New System.Drawing.Size(173, 33)
        Me.TextManzanas.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(277, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "# Manzanas:"
        '
        'BtnFiltroFechas
        '
        Me.BtnFiltroFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFiltroFechas.Location = New System.Drawing.Point(285, 7)
        Me.BtnFiltroFechas.Name = "BtnFiltroFechas"
        Me.BtnFiltroFechas.Size = New System.Drawing.Size(28, 23)
        Me.BtnFiltroFechas.TabIndex = 14
        Me.BtnFiltroFechas.Text = "»"
        Me.BtnFiltroFechas.UseVisualStyleBackColor = True
        '
        'TextTieneMascota
        '
        Me.TextTieneMascota.Location = New System.Drawing.Point(638, 13)
        Me.TextTieneMascota.Name = "TextTieneMascota"
        Me.TextTieneMascota.ReadOnly = True
        Me.TextTieneMascota.Size = New System.Drawing.Size(100, 20)
        Me.TextTieneMascota.TabIndex = 1
        '
        'DataCompras
        '
        Me.DataCompras.AllowUserToAddRows = False
        Me.DataCompras.AllowUserToDeleteRows = False
        Me.DataCompras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataCompras.Location = New System.Drawing.Point(9, 38)
        Me.DataCompras.Name = "DataCompras"
        Me.DataCompras.ReadOnly = True
        Me.DataCompras.RowHeadersWidth = 20
        Me.DataCompras.Size = New System.Drawing.Size(593, 144)
        Me.DataCompras.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(277, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Tipo de granja:"
        '
        'DataDevolucion
        '
        Me.DataDevolucion.AllowUserToAddRows = False
        Me.DataDevolucion.AllowUserToDeleteRows = False
        Me.DataDevolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDevolucion.Location = New System.Drawing.Point(422, 93)
        Me.DataDevolucion.Name = "DataDevolucion"
        Me.DataDevolucion.ReadOnly = True
        Me.DataDevolucion.Size = New System.Drawing.Size(178, 78)
        Me.DataDevolucion.TabIndex = 9
        '
        'DataCancela
        '
        Me.DataCancela.AllowUserToAddRows = False
        Me.DataCancela.AllowUserToDeleteRows = False
        Me.DataCancela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataCancela.ColumnHeadersVisible = False
        Me.DataCancela.Location = New System.Drawing.Point(77, 112)
        Me.DataCancela.Name = "DataCancela"
        Me.DataCancela.ReadOnly = True
        Me.DataCancela.Size = New System.Drawing.Size(152, 40)
        Me.DataCancela.TabIndex = 10
        '
        'BtnFiltro
        '
        Me.BtnFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFiltro.Location = New System.Drawing.Point(9, 14)
        Me.BtnFiltro.Name = "BtnFiltro"
        Me.BtnFiltro.Size = New System.Drawing.Size(110, 21)
        Me.BtnFiltro.TabIndex = 13
        Me.BtnFiltro.Text = "Filtrar Por Fechas"
        Me.BtnFiltro.UseVisualStyleBackColor = True
        '
        'TextMarcas
        '
        Me.TextMarcas.Location = New System.Drawing.Point(139, 151)
        Me.TextMarcas.Multiline = True
        Me.TextMarcas.Name = "TextMarcas"
        Me.TextMarcas.ReadOnly = True
        Me.TextMarcas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextMarcas.Size = New System.Drawing.Size(599, 29)
        Me.TextMarcas.TabIndex = 12
        '
        'GroupFechas
        '
        Me.GroupFechas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupFechas.Controls.Add(Me.BtnFiltroFechas)
        Me.GroupFechas.Controls.Add(Me.DateHasta)
        Me.GroupFechas.Controls.Add(Me.Label20)
        Me.GroupFechas.Controls.Add(Me.DateDesde)
        Me.GroupFechas.Controls.Add(Me.Label19)
        Me.GroupFechas.Location = New System.Drawing.Point(289, 0)
        Me.GroupFechas.Name = "GroupFechas"
        Me.GroupFechas.Size = New System.Drawing.Size(322, 32)
        Me.GroupFechas.TabIndex = 12
        Me.GroupFechas.TabStop = False
        Me.GroupFechas.Visible = False
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(191, 9)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(89, 20)
        Me.DateHasta.TabIndex = 1
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(148, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(38, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Hasta:"
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(50, 9)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(89, 20)
        Me.DateDesde.TabIndex = 1
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(7, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Desde:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 151)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 26)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Marcas de fertilizantes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "que más utiliza:"
        '
        'TextFecha
        '
        Me.TextFecha.Location = New System.Drawing.Point(9, 77)
        Me.TextFecha.Name = "TextFecha"
        Me.TextFecha.ReadOnly = True
        Me.TextFecha.Size = New System.Drawing.Size(128, 20)
        Me.TextFecha.TabIndex = 0
        '
        'TextTotalFacturas
        '
        Me.TextTotalFacturas.Location = New System.Drawing.Point(22, 32)
        Me.TextTotalFacturas.Name = "TextTotalFacturas"
        Me.TextTotalFacturas.ReadOnly = True
        Me.TextTotalFacturas.Size = New System.Drawing.Size(112, 20)
        Me.TextTotalFacturas.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 35)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(16, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "L."
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.Progress)
        Me.Panel1.Controls.Add(Me.BtnDetalle)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 702)
        Me.Panel1.TabIndex = 10
        '
        'Progress
        '
        Me.Progress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Progress.Location = New System.Drawing.Point(630, 486)
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(143, 23)
        Me.Progress.TabIndex = 10
        '
        'BtnDetalle
        '
        Me.BtnDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDetalle.Location = New System.Drawing.Point(630, 447)
        Me.BtnDetalle.Name = "BtnDetalle"
        Me.BtnDetalle.Size = New System.Drawing.Size(143, 32)
        Me.BtnDetalle.TabIndex = 9
        Me.BtnDetalle.Text = "Detalles de Facturas"
        Me.BtnDetalle.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.TextFecha)
        Me.GroupBox5.Controls.Add(Me.TextTotalFacturas)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.LabelDesde)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Location = New System.Drawing.Point(630, 335)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(143, 106)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        '
        'LabelDesde
        '
        Me.LabelDesde.AutoSize = True
        Me.LabelDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDesde.Location = New System.Drawing.Point(6, 60)
        Me.LabelDesde.Name = "LabelDesde"
        Me.LabelDesde.Size = New System.Drawing.Size(47, 13)
        Me.LabelDesde.TabIndex = 0
        Me.LabelDesde.Text = "Desde:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(111, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Total en Facturas:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.DataDetalles)
        Me.GroupBox4.Controls.Add(Me.DataDevolucionDetalles)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 526)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(760, 172)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalles de la factura seleccionada"
        '
        'DataDetalles
        '
        Me.DataDetalles.AllowUserToAddRows = False
        Me.DataDetalles.AllowUserToDeleteRows = False
        Me.DataDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataDetalles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataDetalles.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataDetalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataDetalles.Location = New System.Drawing.Point(3, 16)
        Me.DataDetalles.Name = "DataDetalles"
        Me.DataDetalles.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataDetalles.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataDetalles.RowHeadersWidth = 20
        Me.DataDetalles.Size = New System.Drawing.Size(754, 153)
        Me.DataDetalles.TabIndex = 0
        '
        'DataDevolucionDetalles
        '
        Me.DataDevolucionDetalles.Location = New System.Drawing.Point(546, 29)
        Me.DataDevolucionDetalles.Name = "DataDevolucionDetalles"
        Me.DataDevolucionDetalles.Size = New System.Drawing.Size(187, 114)
        Me.DataDevolucionDetalles.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextTipoGranja)
        Me.GroupBox2.Controls.Add(Me.TextAnimales)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TextManzanas)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TextTieneMascota)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextMarcas)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TextPorque)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TextAgroservicio)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TextCultivos)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 138)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(752, 191)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'TextPorque
        '
        Me.TextPorque.Location = New System.Drawing.Point(139, 113)
        Me.TextPorque.Multiline = True
        Me.TextPorque.Name = "TextPorque"
        Me.TextPorque.ReadOnly = True
        Me.TextPorque.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextPorque.Size = New System.Drawing.Size(599, 29)
        Me.TextPorque.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 116)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "¿Por qué?"
        '
        'TextAgroservicio
        '
        Me.TextAgroservicio.Location = New System.Drawing.Point(139, 78)
        Me.TextAgroservicio.Multiline = True
        Me.TextAgroservicio.Name = "TextAgroservicio"
        Me.TextAgroservicio.ReadOnly = True
        Me.TextAgroservicio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextAgroservicio.Size = New System.Drawing.Size(599, 29)
        Me.TextAgroservicio.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Agroservicio más visitado:"
        '
        'TextCultivos
        '
        Me.TextCultivos.Location = New System.Drawing.Point(60, 13)
        Me.TextCultivos.Multiline = True
        Me.TextCultivos.Name = "TextCultivos"
        Me.TextCultivos.ReadOnly = True
        Me.TextCultivos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextCultivos.Size = New System.Drawing.Size(211, 59)
        Me.TextCultivos.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Cultivos:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.DataCompras)
        Me.GroupBox3.Controls.Add(Me.DataDevolucion)
        Me.GroupBox3.Controls.Add(Me.DataCancela)
        Me.GroupBox3.Controls.Add(Me.BtnFiltro)
        Me.GroupBox3.Controls.Add(Me.GroupFechas)
        Me.GroupBox3.Controls.Add(Me.GroupFacturas)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 335)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(611, 190)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Últimas facturas"
        '
        'GroupFacturas
        '
        Me.GroupFacturas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupFacturas.Controls.Add(Me.Label18)
        Me.GroupFacturas.Controls.Add(Me.CantidadFact)
        Me.GroupFacturas.Controls.Add(Me.Label14)
        Me.GroupFacturas.Location = New System.Drawing.Point(451, 0)
        Me.GroupFacturas.Name = "GroupFacturas"
        Me.GroupFacturas.Size = New System.Drawing.Size(160, 33)
        Me.GroupFacturas.TabIndex = 11
        Me.GroupFacturas.TabStop = False
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(102, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Facturas:"
        '
        'CantidadFact
        '
        Me.CantidadFact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CantidadFact.Location = New System.Drawing.Point(61, 9)
        Me.CantidadFact.Name = "CantidadFact"
        Me.CantidadFact.Size = New System.Drawing.Size(40, 20)
        Me.CantidadFact.TabIndex = 1
        Me.CantidadFact.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Últimas:"
        '
        'Vista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 702)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Vista"
        Me.Text = "Vista"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataDevolucion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCancela, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupFechas.ResumeLayout(False)
        Me.GroupFechas.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DataDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataDevolucionDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupFacturas.ResumeLayout(False)
        Me.GroupFacturas.PerformLayout()
        CType(Me.CantidadFact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextTipoGranja As System.Windows.Forms.TextBox
    Friend WithEvents TextAnimales As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextVendedor As System.Windows.Forms.TextBox
    Friend WithEvents TextDia As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextIDRTN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextListas As System.Windows.Forms.TextBox
    Friend WithEvents TextClaveCliente As System.Windows.Forms.TextBox
    Friend WithEvents TextNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents TextManzanas As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnFiltroFechas As System.Windows.Forms.Button
    Friend WithEvents TextTieneMascota As System.Windows.Forms.TextBox
    Friend WithEvents DataCompras As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DataDevolucion As System.Windows.Forms.DataGridView
    Friend WithEvents DataCancela As System.Windows.Forms.DataGridView
    Friend WithEvents BtnFiltro As System.Windows.Forms.Button
    Friend WithEvents TextMarcas As System.Windows.Forms.TextBox
    Friend WithEvents GroupFechas As System.Windows.Forms.GroupBox
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextFecha As System.Windows.Forms.TextBox
    Friend WithEvents TextTotalFacturas As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnDetalle As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelDesde As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DataDetalles As System.Windows.Forms.DataGridView
    Friend WithEvents DataDevolucionDetalles As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextPorque As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextAgroservicio As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextCultivos As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupFacturas As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CantidadFact As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Progress As System.Windows.Forms.ProgressBar
End Class
