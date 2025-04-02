<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cancelar_nc
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_nc = New System.Windows.Forms.TextBox
        Me.btn_cancelar_nc = New System.Windows.Forms.Button
        Me.txt_factura = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_codigo_local = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_cod_cliente = New System.Windows.Forms.TextBox
        Me.txt_cliente = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_monto = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_tipo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_cargo_por_dev = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_ctlpol = New System.Windows.Forms.TextBox
        Me.grd_ctlpol = New System.Windows.Forms.DataGridView
        Me.grd_facturas = New System.Windows.Forms.DataGridView
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.grd_poliza = New System.Windows.Forms.DataGridView
        Me.Label11 = New System.Windows.Forms.Label
        Me.btn_salir = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_mes = New System.Windows.Forms.TextBox
        Me.txt_year = New System.Windows.Forms.TextBox
        Me.txt_contabilizado = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_interface = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_contabilizado_C31 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_ctlpol_C31 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_mes_c31 = New System.Windows.Forms.TextBox
        Me.txt_year_C31 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txt_interface_C31 = New System.Windows.Forms.TextBox
        Me.grd_ctlpol_C31 = New System.Windows.Forms.DataGridView
        Me.grd_facturas_C31 = New System.Windows.Forms.DataGridView
        Me.grd_poliza_C31 = New System.Windows.Forms.DataGridView
        CType(Me.grd_ctlpol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_poliza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_ctlpol_C31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_facturas_C31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_poliza_C31, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nota de Credito:"
        '
        'txt_nc
        '
        Me.txt_nc.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_nc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nc.Location = New System.Drawing.Point(29, 52)
        Me.txt_nc.Name = "txt_nc"
        Me.txt_nc.ReadOnly = True
        Me.txt_nc.Size = New System.Drawing.Size(186, 20)
        Me.txt_nc.TabIndex = 1
        '
        'btn_cancelar_nc
        '
        Me.btn_cancelar_nc.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_cancelar_nc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar_nc.Location = New System.Drawing.Point(12, 639)
        Me.btn_cancelar_nc.Name = "btn_cancelar_nc"
        Me.btn_cancelar_nc.Size = New System.Drawing.Size(101, 34)
        Me.btn_cancelar_nc.TabIndex = 2
        Me.btn_cancelar_nc.Text = "Cancelar NC"
        Me.btn_cancelar_nc.UseVisualStyleBackColor = True
        '
        'txt_factura
        '
        Me.txt_factura.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_factura.Location = New System.Drawing.Point(221, 52)
        Me.txt_factura.Name = "txt_factura"
        Me.txt_factura.ReadOnly = True
        Me.txt_factura.Size = New System.Drawing.Size(190, 20)
        Me.txt_factura.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(217, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Factura:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(414, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Descuento Tactico:"
        '
        'txt_codigo_local
        '
        Me.txt_codigo_local.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_codigo_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_local.Location = New System.Drawing.Point(417, 52)
        Me.txt_codigo_local.Name = "txt_codigo_local"
        Me.txt_codigo_local.ReadOnly = True
        Me.txt_codigo_local.Size = New System.Drawing.Size(171, 20)
        Me.txt_codigo_local.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(33, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Cliente:"
        '
        'txt_cod_cliente
        '
        Me.txt_cod_cliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cod_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cod_cliente.Location = New System.Drawing.Point(90, 7)
        Me.txt_cod_cliente.Name = "txt_cod_cliente"
        Me.txt_cod_cliente.ReadOnly = True
        Me.txt_cod_cliente.Size = New System.Drawing.Size(79, 20)
        Me.txt_cod_cliente.TabIndex = 1
        '
        'txt_cliente
        '
        Me.txt_cliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cliente.Location = New System.Drawing.Point(175, 7)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.ReadOnly = True
        Me.txt_cliente.Size = New System.Drawing.Size(407, 20)
        Me.txt_cliente.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Monto:"
        '
        'txt_monto
        '
        Me.txt_monto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_monto.Location = New System.Drawing.Point(72, 75)
        Me.txt_monto.Name = "txt_monto"
        Me.txt_monto.ReadOnly = True
        Me.txt_monto.Size = New System.Drawing.Size(71, 20)
        Me.txt_monto.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(37, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tipo:"
        '
        'txt_tipo
        '
        Me.txt_tipo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo.Location = New System.Drawing.Point(72, 101)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.ReadOnly = True
        Me.txt_tipo.Size = New System.Drawing.Size(71, 20)
        Me.txt_tipo.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(148, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "CargoXDev:"
        '
        'txt_cargo_por_dev
        '
        Me.txt_cargo_por_dev.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cargo_por_dev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cargo_por_dev.Location = New System.Drawing.Point(224, 75)
        Me.txt_cargo_por_dev.Name = "txt_cargo_por_dev"
        Me.txt_cargo_por_dev.ReadOnly = True
        Me.txt_cargo_por_dev.Size = New System.Drawing.Size(79, 20)
        Me.txt_cargo_por_dev.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(165, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "CTLPOL:"
        '
        'txt_ctlpol
        '
        Me.txt_ctlpol.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_ctlpol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ctlpol.Location = New System.Drawing.Point(224, 101)
        Me.txt_ctlpol.Name = "txt_ctlpol"
        Me.txt_ctlpol.ReadOnly = True
        Me.txt_ctlpol.Size = New System.Drawing.Size(79, 20)
        Me.txt_ctlpol.TabIndex = 1
        '
        'grd_ctlpol
        '
        Me.grd_ctlpol.AllowUserToAddRows = False
        Me.grd_ctlpol.AllowUserToDeleteRows = False
        Me.grd_ctlpol.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_ctlpol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_ctlpol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ctlpol.Location = New System.Drawing.Point(12, 147)
        Me.grd_ctlpol.Name = "grd_ctlpol"
        Me.grd_ctlpol.ReadOnly = True
        Me.grd_ctlpol.Size = New System.Drawing.Size(582, 48)
        Me.grd_ctlpol.TabIndex = 5
        '
        'grd_facturas
        '
        Me.grd_facturas.AllowUserToAddRows = False
        Me.grd_facturas.AllowUserToDeleteRows = False
        Me.grd_facturas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_facturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_facturas.Location = New System.Drawing.Point(12, 214)
        Me.grd_facturas.Name = "grd_facturas"
        Me.grd_facturas.ReadOnly = True
        Me.grd_facturas.Size = New System.Drawing.Size(582, 221)
        Me.grd_facturas.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Interface en SAE"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 198)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Documentos en Interface"
        '
        'grd_poliza
        '
        Me.grd_poliza.AllowUserToAddRows = False
        Me.grd_poliza.AllowUserToDeleteRows = False
        Me.grd_poliza.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_poliza.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_poliza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_poliza.Location = New System.Drawing.Point(12, 454)
        Me.grd_poliza.Name = "grd_poliza"
        Me.grd_poliza.ReadOnly = True
        Me.grd_poliza.Size = New System.Drawing.Size(582, 178)
        Me.grd_poliza.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 438)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Poliza en COI"
        '
        'btn_salir
        '
        Me.btn_salir.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Location = New System.Drawing.Point(821, 638)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(101, 34)
        Me.btn_salir.TabIndex = 2
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(315, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Periodo:"
        '
        'txt_mes
        '
        Me.txt_mes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_mes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_mes.Location = New System.Drawing.Point(373, 101)
        Me.txt_mes.Name = "txt_mes"
        Me.txt_mes.ReadOnly = True
        Me.txt_mes.Size = New System.Drawing.Size(30, 20)
        Me.txt_mes.TabIndex = 1
        '
        'txt_year
        '
        Me.txt_year.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_year.Location = New System.Drawing.Point(404, 101)
        Me.txt_year.Name = "txt_year"
        Me.txt_year.ReadOnly = True
        Me.txt_year.Size = New System.Drawing.Size(30, 20)
        Me.txt_year.TabIndex = 1
        '
        'txt_contabilizado
        '
        Me.txt_contabilizado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_contabilizado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_contabilizado.Location = New System.Drawing.Point(538, 78)
        Me.txt_contabilizado.Name = "txt_contabilizado"
        Me.txt_contabilizado.ReadOnly = True
        Me.txt_contabilizado.Size = New System.Drawing.Size(49, 20)
        Me.txt_contabilizado.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(445, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Contabilizado:"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(307, 77)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Interface:"
        '
        'txt_interface
        '
        Me.txt_interface.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_interface.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_interface.Location = New System.Drawing.Point(373, 75)
        Me.txt_interface.Name = "txt_interface"
        Me.txt_interface.ReadOnly = True
        Me.txt_interface.Size = New System.Drawing.Size(61, 20)
        Me.txt_interface.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(622, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Contabilizado (C31):"
        '
        'txt_contabilizado_C31
        '
        Me.txt_contabilizado_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_contabilizado_C31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_contabilizado_C31.Location = New System.Drawing.Point(742, 44)
        Me.txt_contabilizado_C31.Name = "txt_contabilizado_C31"
        Me.txt_contabilizado_C31.ReadOnly = True
        Me.txt_contabilizado_C31.Size = New System.Drawing.Size(79, 20)
        Me.txt_contabilizado_C31.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(651, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "CTLPOL (C31):"
        '
        'txt_ctlpol_C31
        '
        Me.txt_ctlpol_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_ctlpol_C31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ctlpol_C31.Location = New System.Drawing.Point(742, 70)
        Me.txt_ctlpol_C31.Name = "txt_ctlpol_C31"
        Me.txt_ctlpol_C31.ReadOnly = True
        Me.txt_ctlpol_C31.Size = New System.Drawing.Size(79, 20)
        Me.txt_ctlpol_C31.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(663, 98)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Periodo C31:"
        '
        'txt_mes_c31
        '
        Me.txt_mes_c31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_mes_c31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_mes_c31.Location = New System.Drawing.Point(742, 96)
        Me.txt_mes_c31.Name = "txt_mes_c31"
        Me.txt_mes_c31.ReadOnly = True
        Me.txt_mes_c31.Size = New System.Drawing.Size(30, 20)
        Me.txt_mes_c31.TabIndex = 1
        '
        'txt_year_C31
        '
        Me.txt_year_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_year_C31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_year_C31.Location = New System.Drawing.Point(778, 96)
        Me.txt_year_C31.Name = "txt_year_C31"
        Me.txt_year_C31.ReadOnly = True
        Me.txt_year_C31.Size = New System.Drawing.Size(43, 20)
        Me.txt_year_C31.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(655, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Interface C31:"
        '
        'txt_interface_C31
        '
        Me.txt_interface_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_interface_C31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_interface_C31.Location = New System.Drawing.Point(742, 18)
        Me.txt_interface_C31.Name = "txt_interface_C31"
        Me.txt_interface_C31.ReadOnly = True
        Me.txt_interface_C31.Size = New System.Drawing.Size(79, 20)
        Me.txt_interface_C31.TabIndex = 1
        '
        'grd_ctlpol_C31
        '
        Me.grd_ctlpol_C31.AllowUserToAddRows = False
        Me.grd_ctlpol_C31.AllowUserToDeleteRows = False
        Me.grd_ctlpol_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_ctlpol_C31.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_ctlpol_C31.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ctlpol_C31.Location = New System.Drawing.Point(600, 147)
        Me.grd_ctlpol_C31.Name = "grd_ctlpol_C31"
        Me.grd_ctlpol_C31.ReadOnly = True
        Me.grd_ctlpol_C31.Size = New System.Drawing.Size(322, 48)
        Me.grd_ctlpol_C31.TabIndex = 5
        '
        'grd_facturas_C31
        '
        Me.grd_facturas_C31.AllowUserToAddRows = False
        Me.grd_facturas_C31.AllowUserToDeleteRows = False
        Me.grd_facturas_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_facturas_C31.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_facturas_C31.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_facturas_C31.Location = New System.Drawing.Point(600, 214)
        Me.grd_facturas_C31.Name = "grd_facturas_C31"
        Me.grd_facturas_C31.ReadOnly = True
        Me.grd_facturas_C31.Size = New System.Drawing.Size(322, 221)
        Me.grd_facturas_C31.TabIndex = 5
        '
        'grd_poliza_C31
        '
        Me.grd_poliza_C31.AllowUserToAddRows = False
        Me.grd_poliza_C31.AllowUserToDeleteRows = False
        Me.grd_poliza_C31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_poliza_C31.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_poliza_C31.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_poliza_C31.Location = New System.Drawing.Point(600, 454)
        Me.grd_poliza_C31.Name = "grd_poliza_C31"
        Me.grd_poliza_C31.ReadOnly = True
        Me.grd_poliza_C31.Size = New System.Drawing.Size(322, 178)
        Me.grd_poliza_C31.TabIndex = 5
        '
        'frm_cancelar_nc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 685)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frm_cancelar_nc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelar NC"
        CType(Me.grd_ctlpol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_facturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_poliza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_ctlpol_C31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_facturas_C31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_poliza_C31, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_nc As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancelar_nc As System.Windows.Forms.Button
    Friend WithEvents txt_factura As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_local As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_monto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_cargo_por_dev As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_ctlpol As System.Windows.Forms.TextBox
    Friend WithEvents grd_ctlpol As System.Windows.Forms.DataGridView
    Friend WithEvents grd_facturas As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grd_poliza As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_mes As System.Windows.Forms.TextBox
    Friend WithEvents txt_year As System.Windows.Forms.TextBox
    Friend WithEvents txt_contabilizado As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_interface As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_contabilizado_C31 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_ctlpol_C31 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_mes_c31 As System.Windows.Forms.TextBox
    Friend WithEvents txt_year_C31 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_interface_C31 As System.Windows.Forms.TextBox
    Friend WithEvents grd_ctlpol_C31 As System.Windows.Forms.DataGridView
    Friend WithEvents grd_facturas_C31 As System.Windows.Forms.DataGridView
    Friend WithEvents grd_poliza_C31 As System.Windows.Forms.DataGridView
End Class
