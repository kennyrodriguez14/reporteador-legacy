<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cancelar_nc_opl
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grd_poliza_C31 = New System.Windows.Forms.DataGridView()
        Me.grd_poliza = New System.Windows.Forms.DataGridView()
        Me.grd_facturas_C31 = New System.Windows.Forms.DataGridView()
        Me.grd_facturas = New System.Windows.Forms.DataGridView()
        Me.grd_ctlpol_C31 = New System.Windows.Forms.DataGridView()
        Me.grd_ctlpol = New System.Windows.Forms.DataGridView()
        Me.txt_codigo_local = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_factura = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_cancelar_nc = New System.Windows.Forms.Button()
        Me.txt_cliente = New System.Windows.Forms.TextBox()
        Me.txt_interface_C31 = New System.Windows.Forms.TextBox()
        Me.txt_interface = New System.Windows.Forms.TextBox()
        Me.txt_contabilizado_C31 = New System.Windows.Forms.TextBox()
        Me.txt_contabilizado = New System.Windows.Forms.TextBox()
        Me.txt_year_C31 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_year = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_mes_c31 = New System.Windows.Forms.TextBox()
        Me.txt_mes = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_ctlpol_C31 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_ctlpol = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_cargo_por_dev = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_tipo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_monto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_cod_cliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_nc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.grd_poliza_C31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_poliza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_facturas_C31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_ctlpol_C31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_ctlpol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 435)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 13)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "Poliza en COI"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 195)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 13)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Documentos en Interface"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 13)
        Me.Label9.TabIndex = 93
        Me.Label9.Text = "Interface en SAE"
        '
        'grd_poliza_C31
        '
        Me.grd_poliza_C31.AllowUserToAddRows = False
        Me.grd_poliza_C31.AllowUserToDeleteRows = False
        Me.grd_poliza_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_poliza_C31.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_poliza_C31.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_poliza_C31.Location = New System.Drawing.Point(597, 451)
        Me.grd_poliza_C31.Name = "grd_poliza_C31"
        Me.grd_poliza_C31.ReadOnly = True
        Me.grd_poliza_C31.Size = New System.Drawing.Size(322, 178)
        Me.grd_poliza_C31.TabIndex = 86
        '
        'grd_poliza
        '
        Me.grd_poliza.AllowUserToAddRows = False
        Me.grd_poliza.AllowUserToDeleteRows = False
        Me.grd_poliza.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_poliza.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_poliza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_poliza.Location = New System.Drawing.Point(9, 451)
        Me.grd_poliza.Name = "grd_poliza"
        Me.grd_poliza.ReadOnly = True
        Me.grd_poliza.Size = New System.Drawing.Size(582, 178)
        Me.grd_poliza.TabIndex = 90
        '
        'grd_facturas_C31
        '
        Me.grd_facturas_C31.AllowUserToAddRows = False
        Me.grd_facturas_C31.AllowUserToDeleteRows = False
        Me.grd_facturas_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_facturas_C31.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_facturas_C31.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_facturas_C31.Location = New System.Drawing.Point(597, 211)
        Me.grd_facturas_C31.Name = "grd_facturas_C31"
        Me.grd_facturas_C31.ReadOnly = True
        Me.grd_facturas_C31.Size = New System.Drawing.Size(322, 221)
        Me.grd_facturas_C31.TabIndex = 91
        '
        'grd_facturas
        '
        Me.grd_facturas.AllowUserToAddRows = False
        Me.grd_facturas.AllowUserToDeleteRows = False
        Me.grd_facturas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_facturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_facturas.Location = New System.Drawing.Point(9, 211)
        Me.grd_facturas.Name = "grd_facturas"
        Me.grd_facturas.ReadOnly = True
        Me.grd_facturas.Size = New System.Drawing.Size(582, 221)
        Me.grd_facturas.TabIndex = 88
        '
        'grd_ctlpol_C31
        '
        Me.grd_ctlpol_C31.AllowUserToAddRows = False
        Me.grd_ctlpol_C31.AllowUserToDeleteRows = False
        Me.grd_ctlpol_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_ctlpol_C31.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_ctlpol_C31.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ctlpol_C31.Location = New System.Drawing.Point(597, 144)
        Me.grd_ctlpol_C31.Name = "grd_ctlpol_C31"
        Me.grd_ctlpol_C31.ReadOnly = True
        Me.grd_ctlpol_C31.Size = New System.Drawing.Size(322, 48)
        Me.grd_ctlpol_C31.TabIndex = 89
        '
        'grd_ctlpol
        '
        Me.grd_ctlpol.AllowUserToAddRows = False
        Me.grd_ctlpol.AllowUserToDeleteRows = False
        Me.grd_ctlpol.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_ctlpol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_ctlpol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ctlpol.Location = New System.Drawing.Point(9, 144)
        Me.grd_ctlpol.Name = "grd_ctlpol"
        Me.grd_ctlpol.ReadOnly = True
        Me.grd_ctlpol.Size = New System.Drawing.Size(582, 48)
        Me.grd_ctlpol.TabIndex = 87
        '
        'txt_codigo_local
        '
        Me.txt_codigo_local.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_codigo_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_local.Location = New System.Drawing.Point(414, 49)
        Me.txt_codigo_local.Name = "txt_codigo_local"
        Me.txt_codigo_local.ReadOnly = True
        Me.txt_codigo_local.Size = New System.Drawing.Size(171, 20)
        Me.txt_codigo_local.TabIndex = 85
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(411, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 13)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Descuento Tactico:"
        '
        'txt_factura
        '
        Me.txt_factura.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_factura.Location = New System.Drawing.Point(218, 49)
        Me.txt_factura.Name = "txt_factura"
        Me.txt_factura.ReadOnly = True
        Me.txt_factura.Size = New System.Drawing.Size(190, 20)
        Me.txt_factura.TabIndex = 84
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(214, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Factura:"
        '
        'btn_salir
        '
        Me.btn_salir.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Location = New System.Drawing.Point(818, 635)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(101, 34)
        Me.btn_salir.TabIndex = 80
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_cancelar_nc
        '
        Me.btn_cancelar_nc.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_cancelar_nc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar_nc.Location = New System.Drawing.Point(9, 636)
        Me.btn_cancelar_nc.Name = "btn_cancelar_nc"
        Me.btn_cancelar_nc.Size = New System.Drawing.Size(101, 34)
        Me.btn_cancelar_nc.TabIndex = 81
        Me.btn_cancelar_nc.Text = "Cancelar NC"
        Me.btn_cancelar_nc.UseVisualStyleBackColor = True
        '
        'txt_cliente
        '
        Me.txt_cliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cliente.Location = New System.Drawing.Point(172, 4)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.Size = New System.Drawing.Size(407, 20)
        Me.txt_cliente.TabIndex = 74
        '
        'txt_interface_C31
        '
        Me.txt_interface_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_interface_C31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_interface_C31.Location = New System.Drawing.Point(739, 15)
        Me.txt_interface_C31.Name = "txt_interface_C31"
        Me.txt_interface_C31.ReadOnly = True
        Me.txt_interface_C31.Size = New System.Drawing.Size(79, 20)
        Me.txt_interface_C31.TabIndex = 73
        '
        'txt_interface
        '
        Me.txt_interface.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_interface.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_interface.Location = New System.Drawing.Point(370, 72)
        Me.txt_interface.Name = "txt_interface"
        Me.txt_interface.ReadOnly = True
        Me.txt_interface.Size = New System.Drawing.Size(61, 20)
        Me.txt_interface.TabIndex = 76
        '
        'txt_contabilizado_C31
        '
        Me.txt_contabilizado_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_contabilizado_C31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_contabilizado_C31.Location = New System.Drawing.Point(739, 41)
        Me.txt_contabilizado_C31.Name = "txt_contabilizado_C31"
        Me.txt_contabilizado_C31.ReadOnly = True
        Me.txt_contabilizado_C31.Size = New System.Drawing.Size(79, 20)
        Me.txt_contabilizado_C31.TabIndex = 79
        '
        'txt_contabilizado
        '
        Me.txt_contabilizado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_contabilizado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_contabilizado.Location = New System.Drawing.Point(535, 75)
        Me.txt_contabilizado.Name = "txt_contabilizado"
        Me.txt_contabilizado.ReadOnly = True
        Me.txt_contabilizado.Size = New System.Drawing.Size(49, 20)
        Me.txt_contabilizado.TabIndex = 78
        '
        'txt_year_C31
        '
        Me.txt_year_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_year_C31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_year_C31.Location = New System.Drawing.Point(775, 93)
        Me.txt_year_C31.Name = "txt_year_C31"
        Me.txt_year_C31.ReadOnly = True
        Me.txt_year_C31.Size = New System.Drawing.Size(43, 20)
        Me.txt_year_C31.TabIndex = 77
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(652, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 13)
        Me.Label18.TabIndex = 63
        Me.Label18.Text = "Interface C31:"
        '
        'txt_year
        '
        Me.txt_year.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_year.Location = New System.Drawing.Point(401, 98)
        Me.txt_year.Name = "txt_year"
        Me.txt_year.ReadOnly = True
        Me.txt_year.Size = New System.Drawing.Size(30, 20)
        Me.txt_year.TabIndex = 67
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(304, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "Interface:"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(619, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 13)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "Contabilizado (C31):"
        '
        'txt_mes_c31
        '
        Me.txt_mes_c31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_mes_c31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_mes_c31.Location = New System.Drawing.Point(739, 93)
        Me.txt_mes_c31.Name = "txt_mes_c31"
        Me.txt_mes_c31.ReadOnly = True
        Me.txt_mes_c31.Size = New System.Drawing.Size(30, 20)
        Me.txt_mes_c31.TabIndex = 65
        '
        'txt_mes
        '
        Me.txt_mes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_mes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_mes.Location = New System.Drawing.Point(370, 98)
        Me.txt_mes.Name = "txt_mes"
        Me.txt_mes.ReadOnly = True
        Me.txt_mes.Size = New System.Drawing.Size(30, 20)
        Me.txt_mes.TabIndex = 70
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(660, 95)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 13)
        Me.Label17.TabIndex = 51
        Me.Label17.Text = "Periodo C31:"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(442, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 13)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Contabilizado:"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(312, 100)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 53
        Me.Label12.Text = "Periodo:"
        '
        'txt_ctlpol_C31
        '
        Me.txt_ctlpol_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_ctlpol_C31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ctlpol_C31.Location = New System.Drawing.Point(739, 67)
        Me.txt_ctlpol_C31.Name = "txt_ctlpol_C31"
        Me.txt_ctlpol_C31.ReadOnly = True
        Me.txt_ctlpol_C31.Size = New System.Drawing.Size(79, 20)
        Me.txt_ctlpol_C31.TabIndex = 69
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(648, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "CTLPOL (C31):"
        '
        'txt_ctlpol
        '
        Me.txt_ctlpol.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_ctlpol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ctlpol.Location = New System.Drawing.Point(221, 98)
        Me.txt_ctlpol.Name = "txt_ctlpol"
        Me.txt_ctlpol.ReadOnly = True
        Me.txt_ctlpol.Size = New System.Drawing.Size(79, 20)
        Me.txt_ctlpol.TabIndex = 64
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(162, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "CTLPOL:"
        '
        'txt_cargo_por_dev
        '
        Me.txt_cargo_por_dev.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cargo_por_dev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cargo_por_dev.Location = New System.Drawing.Point(221, 72)
        Me.txt_cargo_por_dev.Name = "txt_cargo_por_dev"
        Me.txt_cargo_por_dev.ReadOnly = True
        Me.txt_cargo_por_dev.Size = New System.Drawing.Size(79, 20)
        Me.txt_cargo_por_dev.TabIndex = 75
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(145, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "CargoXDev:"
        '
        'txt_tipo
        '
        Me.txt_tipo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo.Location = New System.Drawing.Point(69, 98)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.ReadOnly = True
        Me.txt_tipo.Size = New System.Drawing.Size(71, 20)
        Me.txt_tipo.TabIndex = 66
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(34, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Tipo:"
        '
        'txt_monto
        '
        Me.txt_monto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_monto.Location = New System.Drawing.Point(69, 72)
        Me.txt_monto.Name = "txt_monto"
        Me.txt_monto.ReadOnly = True
        Me.txt_monto.Size = New System.Drawing.Size(71, 20)
        Me.txt_monto.TabIndex = 72
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Monto:"
        '
        'txt_cod_cliente
        '
        Me.txt_cod_cliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cod_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cod_cliente.Location = New System.Drawing.Point(87, 4)
        Me.txt_cod_cliente.Name = "txt_cod_cliente"
        Me.txt_cod_cliente.ReadOnly = True
        Me.txt_cod_cliente.Size = New System.Drawing.Size(79, 20)
        Me.txt_cod_cliente.TabIndex = 68
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Cliente:"
        '
        'txt_nc
        '
        Me.txt_nc.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_nc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nc.Location = New System.Drawing.Point(26, 49)
        Me.txt_nc.Name = "txt_nc"
        Me.txt_nc.ReadOnly = True
        Me.txt_nc.Size = New System.Drawing.Size(186, 20)
        Me.txt_nc.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Nota de Credito:"
        '
        'frm_cancelar_nc_opl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 675)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.grd_poliza_C31)
        Me.Controls.Add(Me.grd_poliza)
        Me.Controls.Add(Me.grd_facturas_C31)
        Me.Controls.Add(Me.grd_facturas)
        Me.Controls.Add(Me.grd_ctlpol_C31)
        Me.Controls.Add(Me.grd_ctlpol)
        Me.Controls.Add(Me.txt_codigo_local)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_factura)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_cancelar_nc)
        Me.Controls.Add(Me.txt_cliente)
        Me.Controls.Add(Me.txt_interface_C31)
        Me.Controls.Add(Me.txt_interface)
        Me.Controls.Add(Me.txt_contabilizado_C31)
        Me.Controls.Add(Me.txt_contabilizado)
        Me.Controls.Add(Me.txt_year_C31)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txt_year)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txt_mes_c31)
        Me.Controls.Add(Me.txt_mes)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_ctlpol_C31)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txt_ctlpol)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_cargo_por_dev)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_tipo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_monto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_cod_cliente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_nc)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_cancelar_nc_opl"
        Me.Text = "frm_cancelar_nc_opl"
        CType(Me.grd_poliza_C31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_poliza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_facturas_C31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_facturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_ctlpol_C31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_ctlpol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents grd_poliza_C31 As DataGridView
    Friend WithEvents grd_poliza As DataGridView
    Friend WithEvents grd_facturas_C31 As DataGridView
    Friend WithEvents grd_facturas As DataGridView
    Friend WithEvents grd_ctlpol_C31 As DataGridView
    Friend WithEvents grd_ctlpol As DataGridView
    Friend WithEvents txt_codigo_local As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_factura As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_cancelar_nc As Button
    Friend WithEvents txt_cliente As TextBox
    Friend WithEvents txt_interface_C31 As TextBox
    Friend WithEvents txt_interface As TextBox
    Friend WithEvents txt_contabilizado_C31 As TextBox
    Friend WithEvents txt_contabilizado As TextBox
    Friend WithEvents txt_year_C31 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txt_year As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txt_mes_c31 As TextBox
    Friend WithEvents txt_mes As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_ctlpol_C31 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txt_ctlpol As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_cargo_por_dev As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_tipo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_monto As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_cod_cliente As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_nc As TextBox
    Friend WithEvents Label1 As Label
End Class
