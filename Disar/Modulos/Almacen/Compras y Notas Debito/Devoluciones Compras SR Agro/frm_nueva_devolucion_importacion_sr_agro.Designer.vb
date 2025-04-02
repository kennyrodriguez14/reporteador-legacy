<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_nueva_devolucion_importacion_sr_agro
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_nueva_devolucion_importacion_sr_agro))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.btn_salir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.txt_mostrador_producto = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_totalmostrador = New System.Windows.Forms.TextBox
        Me.txt_total_final = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_isvmostrador = New System.Windows.Forms.TextBox
        Me.txt_isv_final = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_descuento_mostrador = New System.Windows.Forms.TextBox
        Me.txt_descuento_final = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_subtotalmostrador = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txt_subtotal_final = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grp_partida = New System.Windows.Forms.GroupBox
        Me.grd_ingreso = New System.Windows.Forms.DataGridView
        Me.grp_ingreso_datos = New System.Windows.Forms.GroupBox
        Me.cmb_tipo_devolucion = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.cmb_lote = New System.Windows.Forms.CheckBox
        Me.txt_lote = New System.Windows.Forms.TextBox
        Me.cmb_fecha_documento = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.btn_cargar_compra = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_rfc = New System.Windows.Forms.TextBox
        Me.txt_nombre_proveedor = New System.Windows.Forms.TextBox
        Me.txt_codigo_proveedor = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_descuento_general = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_referencia_proveedor = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_flete = New System.Windows.Forms.TextBox
        Me.txtn_fact_sae = New System.Windows.Forms.TextBox
        Me.txt_cve_compra = New System.Windows.Forms.TextBox
        Me.cmb_fecha_vencimiento = New System.Windows.Forms.DateTimePicker
        Me.Label28 = New System.Windows.Forms.Label
        Me.txt_tasa_cambio = New System.Windows.Forms.TextBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.txt_honorarios = New System.Windows.Forms.TextBox
        Me.txt_seguro = New System.Windows.Forms.TextBox
        Me.txt_pyc = New System.Windows.Forms.TextBox
        Me.txt_parqueo = New System.Windows.Forms.TextBox
        Me.txt_encomiendas = New System.Windows.Forms.TextBox
        Me.txt_gastosvariables = New System.Windows.Forms.TextBox
        Me.txt_boletin = New System.Windows.Forms.TextBox
        Me.txt_agencia = New System.Windows.Forms.TextBox
        Me.txt_revdescarg = New System.Windows.Forms.TextBox
        Me.txt_emision_gremision = New System.Windows.Forms.TextBox
        Me.txt_tdatos = New System.Windows.Forms.TextBox
        Me.txt_otroprov = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_refer_vesta = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip2.SuspendLayout()
        Me.grp_partida.SuspendLayout()
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_ingreso_datos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_salir, Me.ToolStripSeparator7})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1173, 39)
        Me.ToolStrip2.TabIndex = 77
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_salir.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(68, 36)
        Me.btn_salir.Text = "Salir"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 39)
        '
        'txt_mostrador_producto
        '
        Me.txt_mostrador_producto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_mostrador_producto.Location = New System.Drawing.Point(74, 436)
        Me.txt_mostrador_producto.Name = "txt_mostrador_producto"
        Me.txt_mostrador_producto.ReadOnly = True
        Me.txt_mostrador_producto.Size = New System.Drawing.Size(434, 20)
        Me.txt_mostrador_producto.TabIndex = 76
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(18, 438)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 13)
        Me.Label16.TabIndex = 75
        Me.Label16.Text = "Producto"
        '
        'txt_totalmostrador
        '
        Me.txt_totalmostrador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_totalmostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_totalmostrador.Location = New System.Drawing.Point(1000, 499)
        Me.txt_totalmostrador.Name = "txt_totalmostrador"
        Me.txt_totalmostrador.ReadOnly = True
        Me.txt_totalmostrador.Size = New System.Drawing.Size(161, 20)
        Me.txt_totalmostrador.TabIndex = 64
        '
        'txt_total_final
        '
        Me.txt_total_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_final.Location = New System.Drawing.Point(761, 499)
        Me.txt_total_final.Name = "txt_total_final"
        Me.txt_total_final.ReadOnly = True
        Me.txt_total_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_total_final.TabIndex = 58
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(959, 501)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(40, 13)
        Me.Label27.TabIndex = 73
        Me.Label27.Text = "Total:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(718, 501)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "Total:"
        '
        'txt_isvmostrador
        '
        Me.txt_isvmostrador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_isvmostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isvmostrador.Location = New System.Drawing.Point(1000, 478)
        Me.txt_isvmostrador.Name = "txt_isvmostrador"
        Me.txt_isvmostrador.ReadOnly = True
        Me.txt_isvmostrador.Size = New System.Drawing.Size(161, 20)
        Me.txt_isvmostrador.TabIndex = 63
        '
        'txt_isv_final
        '
        Me.txt_isv_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_isv_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isv_final.Location = New System.Drawing.Point(761, 478)
        Me.txt_isv_final.Name = "txt_isv_final"
        Me.txt_isv_final.ReadOnly = True
        Me.txt_isv_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_isv_final.TabIndex = 57
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(956, 480)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(43, 13)
        Me.Label26.TabIndex = 69
        Me.Label26.Text = "I.S.V.:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(715, 480)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "I.S.V.:"
        '
        'txt_descuento_mostrador
        '
        Me.txt_descuento_mostrador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_descuento_mostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_mostrador.Location = New System.Drawing.Point(1000, 457)
        Me.txt_descuento_mostrador.Name = "txt_descuento_mostrador"
        Me.txt_descuento_mostrador.ReadOnly = True
        Me.txt_descuento_mostrador.Size = New System.Drawing.Size(161, 20)
        Me.txt_descuento_mostrador.TabIndex = 62
        '
        'txt_descuento_final
        '
        Me.txt_descuento_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_descuento_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_final.Location = New System.Drawing.Point(761, 457)
        Me.txt_descuento_final.Name = "txt_descuento_final"
        Me.txt_descuento_final.ReadOnly = True
        Me.txt_descuento_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_descuento_final.TabIndex = 59
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(927, 459)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 13)
        Me.Label25.TabIndex = 71
        Me.Label25.Text = "Descuento:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(686, 459)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Descuento:"
        '
        'txt_subtotalmostrador
        '
        Me.txt_subtotalmostrador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_subtotalmostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_subtotalmostrador.Location = New System.Drawing.Point(1000, 436)
        Me.txt_subtotalmostrador.Name = "txt_subtotalmostrador"
        Me.txt_subtotalmostrador.ReadOnly = True
        Me.txt_subtotalmostrador.Size = New System.Drawing.Size(161, 20)
        Me.txt_subtotalmostrador.TabIndex = 61
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(937, 438)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(62, 13)
        Me.Label24.TabIndex = 65
        Me.Label24.Text = "Sub-total:"
        '
        'txt_subtotal_final
        '
        Me.txt_subtotal_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_subtotal_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_subtotal_final.Location = New System.Drawing.Point(761, 436)
        Me.txt_subtotal_final.Name = "txt_subtotal_final"
        Me.txt_subtotal_final.ReadOnly = True
        Me.txt_subtotal_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_subtotal_final.TabIndex = 56
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(696, 438)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Sub-total:"
        '
        'grp_partida
        '
        Me.grp_partida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_partida.Controls.Add(Me.grd_ingreso)
        Me.grp_partida.Location = New System.Drawing.Point(12, 127)
        Me.grp_partida.Name = "grp_partida"
        Me.grp_partida.Size = New System.Drawing.Size(1152, 303)
        Me.grp_partida.TabIndex = 60
        Me.grp_partida.TabStop = False
        '
        'grd_ingreso
        '
        Me.grd_ingreso.AllowUserToAddRows = False
        Me.grd_ingreso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_ingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ingreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_ingreso.Enabled = False
        Me.grd_ingreso.Location = New System.Drawing.Point(3, 16)
        Me.grd_ingreso.Name = "grd_ingreso"
        Me.grd_ingreso.RowHeadersVisible = False
        Me.grd_ingreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_ingreso.Size = New System.Drawing.Size(1146, 284)
        Me.grd_ingreso.TabIndex = 14
        '
        'grp_ingreso_datos
        '
        Me.grp_ingreso_datos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_tipo_devolucion)
        Me.grp_ingreso_datos.Controls.Add(Me.Label7)
        Me.grp_ingreso_datos.Controls.Add(Me.Label29)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_lote)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_lote)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_documento)
        Me.grp_ingreso_datos.Controls.Add(Me.Label17)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_sucursal)
        Me.grp_ingreso_datos.Controls.Add(Me.btn_cargar_compra)
        Me.grp_ingreso_datos.Controls.Add(Me.Label3)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_rfc)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_nombre_proveedor)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_codigo_proveedor)
        Me.grp_ingreso_datos.Controls.Add(Me.Label8)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_descuento_general)
        Me.grp_ingreso_datos.Controls.Add(Me.Label2)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_referencia_proveedor)
        Me.grp_ingreso_datos.Controls.Add(Me.Label9)
        Me.grp_ingreso_datos.Controls.Add(Me.Label1)
        Me.grp_ingreso_datos.Location = New System.Drawing.Point(12, 42)
        Me.grp_ingreso_datos.Name = "grp_ingreso_datos"
        Me.grp_ingreso_datos.Size = New System.Drawing.Size(1152, 79)
        Me.grp_ingreso_datos.TabIndex = 55
        Me.grp_ingreso_datos.TabStop = False
        Me.grp_ingreso_datos.Text = "Datos Generales"
        '
        'cmb_tipo_devolucion
        '
        Me.cmb_tipo_devolucion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_tipo_devolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo_devolucion.FormattingEnabled = True
        Me.cmb_tipo_devolucion.Items.AddRange(New Object() {"Total", "Parcial"})
        Me.cmb_tipo_devolucion.Location = New System.Drawing.Point(959, 50)
        Me.cmb_tipo_devolucion.Name = "cmb_tipo_devolucion"
        Me.cmb_tipo_devolucion.Size = New System.Drawing.Size(187, 21)
        Me.cmb_tipo_devolucion.TabIndex = 53
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(834, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Tipo de Devolucion:"
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(2, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(71, 13)
        Me.Label29.TabIndex = 9
        Me.Label29.Text = "Nº Compra:"
        '
        'cmb_lote
        '
        Me.cmb_lote.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_lote.AutoSize = True
        Me.cmb_lote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmb_lote.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmb_lote.Location = New System.Drawing.Point(841, 21)
        Me.cmb_lote.Name = "cmb_lote"
        Me.cmb_lote.Size = New System.Drawing.Size(55, 17)
        Me.cmb_lote.TabIndex = 0
        Me.cmb_lote.Text = "Lote:"
        Me.cmb_lote.UseVisualStyleBackColor = True
        '
        'txt_lote
        '
        Me.txt_lote.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_lote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_lote.Enabled = False
        Me.txt_lote.Location = New System.Drawing.Point(902, 20)
        Me.txt_lote.Name = "txt_lote"
        Me.txt_lote.ReadOnly = True
        Me.txt_lote.Size = New System.Drawing.Size(75, 20)
        Me.txt_lote.TabIndex = 0
        '
        'cmb_fecha_documento
        '
        Me.cmb_fecha_documento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_documento.Enabled = False
        Me.cmb_fecha_documento.Location = New System.Drawing.Point(609, 50)
        Me.cmb_fecha_documento.Name = "cmb_fecha_documento"
        Me.cmb_fecha_documento.Size = New System.Drawing.Size(215, 20)
        Me.cmb_fecha_documento.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(561, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Fecha:"
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.Enabled = False
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(73, 47)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(215, 21)
        Me.cmb_sucursal.TabIndex = 2
        '
        'btn_cargar_compra
        '
        Me.btn_cargar_compra.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_cargar_compra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_cargar_compra.Location = New System.Drawing.Point(73, 19)
        Me.btn_cargar_compra.Name = "btn_cargar_compra"
        Me.btn_cargar_compra.Size = New System.Drawing.Size(25, 22)
        Me.btn_cargar_compra.TabIndex = 1
        Me.btn_cargar_compra.Text = "..."
        Me.btn_cargar_compra.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(14, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Almacen:"
        '
        'txt_rfc
        '
        Me.txt_rfc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_rfc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_rfc.Location = New System.Drawing.Point(727, 20)
        Me.txt_rfc.Name = "txt_rfc"
        Me.txt_rfc.ReadOnly = True
        Me.txt_rfc.Size = New System.Drawing.Size(108, 20)
        Me.txt_rfc.TabIndex = 0
        Me.txt_rfc.TabStop = False
        '
        'txt_nombre_proveedor
        '
        Me.txt_nombre_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombre_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_proveedor.Location = New System.Drawing.Point(243, 19)
        Me.txt_nombre_proveedor.Name = "txt_nombre_proveedor"
        Me.txt_nombre_proveedor.ReadOnly = True
        Me.txt_nombre_proveedor.Size = New System.Drawing.Size(445, 20)
        Me.txt_nombre_proveedor.TabIndex = 0
        Me.txt_nombre_proveedor.TabStop = False
        '
        'txt_codigo_proveedor
        '
        Me.txt_codigo_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_proveedor.Location = New System.Drawing.Point(172, 19)
        Me.txt_codigo_proveedor.Name = "txt_codigo_proveedor"
        Me.txt_codigo_proveedor.ReadOnly = True
        Me.txt_codigo_proveedor.Size = New System.Drawing.Size(70, 20)
        Me.txt_codigo_proveedor.TabIndex = 0
        Me.txt_codigo_proveedor.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(691, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "RFC:"
        '
        'txt_descuento_general
        '
        Me.txt_descuento_general.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_descuento_general.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_general.Location = New System.Drawing.Point(1071, 20)
        Me.txt_descuento_general.Name = "txt_descuento_general"
        Me.txt_descuento_general.ReadOnly = True
        Me.txt_descuento_general.Size = New System.Drawing.Size(75, 20)
        Me.txt_descuento_general.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(103, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Proveedor:"
        '
        'txt_referencia_proveedor
        '
        Me.txt_referencia_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_referencia_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_referencia_proveedor.Location = New System.Drawing.Point(395, 50)
        Me.txt_referencia_proveedor.Name = "txt_referencia_proveedor"
        Me.txt_referencia_proveedor.ReadOnly = True
        Me.txt_referencia_proveedor.Size = New System.Drawing.Size(152, 20)
        Me.txt_referencia_proveedor.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(998, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Descuento:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(294, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ref. Proveedor:"
        '
        'txt_flete
        '
        Me.txt_flete.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_flete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_flete.Location = New System.Drawing.Point(180, 19)
        Me.txt_flete.Name = "txt_flete"
        Me.txt_flete.ReadOnly = True
        Me.txt_flete.Size = New System.Drawing.Size(38, 20)
        Me.txt_flete.TabIndex = 10
        Me.txt_flete.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_flete, "flete")
        '
        'txtn_fact_sae
        '
        Me.txtn_fact_sae.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtn_fact_sae.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtn_fact_sae.Location = New System.Drawing.Point(3, 19)
        Me.txtn_fact_sae.Name = "txtn_fact_sae"
        Me.txtn_fact_sae.ReadOnly = True
        Me.txtn_fact_sae.Size = New System.Drawing.Size(39, 20)
        Me.txtn_fact_sae.TabIndex = 10
        Me.txtn_fact_sae.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txtn_fact_sae, "fact sae")
        '
        'txt_cve_compra
        '
        Me.txt_cve_compra.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_cve_compra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cve_compra.Location = New System.Drawing.Point(48, 19)
        Me.txt_cve_compra.Name = "txt_cve_compra"
        Me.txt_cve_compra.ReadOnly = True
        Me.txt_cve_compra.Size = New System.Drawing.Size(38, 20)
        Me.txt_cve_compra.TabIndex = 10
        Me.txt_cve_compra.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_cve_compra, "cve compra")
        '
        'cmb_fecha_vencimiento
        '
        Me.cmb_fecha_vencimiento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_vencimiento.Enabled = False
        Me.cmb_fecha_vencimiento.Location = New System.Drawing.Point(430, 19)
        Me.cmb_fecha_vencimiento.Name = "cmb_fecha_vencimiento"
        Me.cmb_fecha_vencimiento.Size = New System.Drawing.Size(58, 20)
        Me.cmb_fecha_vencimiento.TabIndex = 8
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(309, 23)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(119, 13)
        Me.Label28.TabIndex = 7
        Me.Label28.Text = "Fecha Vencimiento:"
        '
        'txt_tasa_cambio
        '
        Me.txt_tasa_cambio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_tasa_cambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tasa_cambio.Location = New System.Drawing.Point(224, 19)
        Me.txt_tasa_cambio.Name = "txt_tasa_cambio"
        Me.txt_tasa_cambio.ReadOnly = True
        Me.txt_tasa_cambio.Size = New System.Drawing.Size(38, 20)
        Me.txt_tasa_cambio.TabIndex = 10
        Me.txt_tasa_cambio.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_tasa_cambio, "tasa cambio")
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.btn_cancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_cancelar.Location = New System.Drawing.Point(1079, 525)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(82, 51)
        Me.btn_cancelar.TabIndex = 68
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btn_guardar.Image = Global.Disar.My.Resources.Resources.Guardar
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_guardar.Location = New System.Drawing.Point(12, 525)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(82, 51)
        Me.btn_guardar.TabIndex = 67
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'txt_honorarios
        '
        Me.txt_honorarios.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_honorarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_honorarios.Location = New System.Drawing.Point(312, 44)
        Me.txt_honorarios.Name = "txt_honorarios"
        Me.txt_honorarios.ReadOnly = True
        Me.txt_honorarios.Size = New System.Drawing.Size(38, 20)
        Me.txt_honorarios.TabIndex = 10
        Me.txt_honorarios.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_honorarios, "honorarios")
        '
        'txt_seguro
        '
        Me.txt_seguro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_seguro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_seguro.Location = New System.Drawing.Point(356, 44)
        Me.txt_seguro.Name = "txt_seguro"
        Me.txt_seguro.ReadOnly = True
        Me.txt_seguro.Size = New System.Drawing.Size(38, 20)
        Me.txt_seguro.TabIndex = 10
        Me.txt_seguro.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_seguro, "seguro")
        '
        'txt_pyc
        '
        Me.txt_pyc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_pyc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pyc.Location = New System.Drawing.Point(92, 44)
        Me.txt_pyc.Name = "txt_pyc"
        Me.txt_pyc.ReadOnly = True
        Me.txt_pyc.Size = New System.Drawing.Size(38, 20)
        Me.txt_pyc.TabIndex = 54
        Me.txt_pyc.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_pyc, "pyc")
        '
        'txt_parqueo
        '
        Me.txt_parqueo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_parqueo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_parqueo.Location = New System.Drawing.Point(136, 44)
        Me.txt_parqueo.Name = "txt_parqueo"
        Me.txt_parqueo.ReadOnly = True
        Me.txt_parqueo.Size = New System.Drawing.Size(38, 20)
        Me.txt_parqueo.TabIndex = 55
        Me.txt_parqueo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_parqueo, "parqueo")
        '
        'txt_encomiendas
        '
        Me.txt_encomiendas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_encomiendas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_encomiendas.Location = New System.Drawing.Point(268, 44)
        Me.txt_encomiendas.Name = "txt_encomiendas"
        Me.txt_encomiendas.ReadOnly = True
        Me.txt_encomiendas.Size = New System.Drawing.Size(38, 20)
        Me.txt_encomiendas.TabIndex = 55
        Me.txt_encomiendas.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_encomiendas, "encomiendas")
        '
        'txt_gastosvariables
        '
        Me.txt_gastosvariables.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_gastosvariables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_gastosvariables.Location = New System.Drawing.Point(3, 45)
        Me.txt_gastosvariables.Name = "txt_gastosvariables"
        Me.txt_gastosvariables.ReadOnly = True
        Me.txt_gastosvariables.Size = New System.Drawing.Size(39, 20)
        Me.txt_gastosvariables.TabIndex = 55
        Me.txt_gastosvariables.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_gastosvariables, "gastos variables")
        '
        'txt_boletin
        '
        Me.txt_boletin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_boletin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_boletin.Location = New System.Drawing.Point(48, 45)
        Me.txt_boletin.Name = "txt_boletin"
        Me.txt_boletin.ReadOnly = True
        Me.txt_boletin.Size = New System.Drawing.Size(38, 20)
        Me.txt_boletin.TabIndex = 55
        Me.txt_boletin.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_boletin, "boletin")
        '
        'txt_agencia
        '
        Me.txt_agencia.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_agencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_agencia.Location = New System.Drawing.Point(268, 19)
        Me.txt_agencia.Name = "txt_agencia"
        Me.txt_agencia.ReadOnly = True
        Me.txt_agencia.Size = New System.Drawing.Size(38, 20)
        Me.txt_agencia.TabIndex = 55
        Me.txt_agencia.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_agencia, "agencia")
        '
        'txt_revdescarg
        '
        Me.txt_revdescarg.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_revdescarg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_revdescarg.Location = New System.Drawing.Point(180, 44)
        Me.txt_revdescarg.Name = "txt_revdescarg"
        Me.txt_revdescarg.ReadOnly = True
        Me.txt_revdescarg.Size = New System.Drawing.Size(38, 20)
        Me.txt_revdescarg.TabIndex = 55
        Me.txt_revdescarg.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_revdescarg, "revdesc")
        '
        'txt_emision_gremision
        '
        Me.txt_emision_gremision.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_emision_gremision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_emision_gremision.Location = New System.Drawing.Point(224, 45)
        Me.txt_emision_gremision.Name = "txt_emision_gremision"
        Me.txt_emision_gremision.ReadOnly = True
        Me.txt_emision_gremision.Size = New System.Drawing.Size(38, 20)
        Me.txt_emision_gremision.TabIndex = 55
        Me.txt_emision_gremision.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_emision_gremision, "emision")
        '
        'txt_tdatos
        '
        Me.txt_tdatos.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_tdatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tdatos.Location = New System.Drawing.Point(136, 19)
        Me.txt_tdatos.Name = "txt_tdatos"
        Me.txt_tdatos.ReadOnly = True
        Me.txt_tdatos.Size = New System.Drawing.Size(38, 20)
        Me.txt_tdatos.TabIndex = 55
        Me.txt_tdatos.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_tdatos, "datos")
        '
        'txt_otroprov
        '
        Me.txt_otroprov.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_otroprov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_otroprov.Location = New System.Drawing.Point(92, 18)
        Me.txt_otroprov.Name = "txt_otroprov"
        Me.txt_otroprov.ReadOnly = True
        Me.txt_otroprov.Size = New System.Drawing.Size(38, 20)
        Me.txt_otroprov.TabIndex = 55
        Me.txt_otroprov.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txt_otroprov, "otro prov")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_parqueo)
        Me.GroupBox1.Controls.Add(Me.txt_revdescarg)
        Me.GroupBox1.Controls.Add(Me.txt_boletin)
        Me.GroupBox1.Controls.Add(Me.txt_refer_vesta)
        Me.GroupBox1.Controls.Add(Me.txt_seguro)
        Me.GroupBox1.Controls.Add(Me.txt_otroprov)
        Me.GroupBox1.Controls.Add(Me.txt_honorarios)
        Me.GroupBox1.Controls.Add(Me.txt_gastosvariables)
        Me.GroupBox1.Controls.Add(Me.txt_cve_compra)
        Me.GroupBox1.Controls.Add(Me.txt_encomiendas)
        Me.GroupBox1.Controls.Add(Me.txt_tdatos)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.txt_pyc)
        Me.GroupBox1.Controls.Add(Me.txt_emision_gremision)
        Me.GroupBox1.Controls.Add(Me.cmb_fecha_vencimiento)
        Me.GroupBox1.Controls.Add(Me.txtn_fact_sae)
        Me.GroupBox1.Controls.Add(Me.txt_flete)
        Me.GroupBox1.Controls.Add(Me.txt_agencia)
        Me.GroupBox1.Controls.Add(Me.txt_tasa_cambio)
        Me.GroupBox1.Location = New System.Drawing.Point(143, 462)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(511, 73)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "datos adicionales"
        Me.GroupBox1.Visible = False
        '
        'txt_refer_vesta
        '
        Me.txt_refer_vesta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_refer_vesta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_refer_vesta.Location = New System.Drawing.Point(400, 44)
        Me.txt_refer_vesta.Name = "txt_refer_vesta"
        Me.txt_refer_vesta.ReadOnly = True
        Me.txt_refer_vesta.Size = New System.Drawing.Size(38, 20)
        Me.txt_refer_vesta.TabIndex = 10
        Me.txt_refer_vesta.TabStop = False
        '
        'frm_nueva_devolucion_importacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 588)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.txt_mostrador_producto)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txt_totalmostrador)
        Me.Controls.Add(Me.txt_total_final)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_isvmostrador)
        Me.Controls.Add(Me.txt_isv_final)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_descuento_mostrador)
        Me.Controls.Add(Me.txt_descuento_final)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_subtotalmostrador)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txt_subtotal_final)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.grp_partida)
        Me.Controls.Add(Me.grp_ingreso_datos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_nueva_devolucion_importacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devolucion de Importacion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.grp_partida.ResumeLayout(False)
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_ingreso_datos.ResumeLayout(False)
        Me.grp_ingreso_datos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txt_mostrador_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_totalmostrador As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_final As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_isvmostrador As System.Windows.Forms.TextBox
    Friend WithEvents txt_isv_final As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento_mostrador As System.Windows.Forms.TextBox
    Friend WithEvents txt_descuento_final As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_subtotalmostrador As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_subtotal_final As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grp_partida As System.Windows.Forms.GroupBox
    Friend WithEvents grd_ingreso As System.Windows.Forms.DataGridView
    Friend WithEvents grp_ingreso_datos As System.Windows.Forms.GroupBox
    Friend WithEvents txt_flete As System.Windows.Forms.TextBox
    Friend WithEvents cmb_tipo_devolucion As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtn_fact_sae As System.Windows.Forms.TextBox
    Friend WithEvents txt_cve_compra As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_vencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmb_lote As System.Windows.Forms.CheckBox
    Friend WithEvents txt_lote As System.Windows.Forms.TextBox
    Friend WithEvents cmb_fecha_documento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btn_cargar_compra As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_rfc As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento_general As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_referencia_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_tasa_cambio As System.Windows.Forms.TextBox
    Friend WithEvents txt_parqueo As System.Windows.Forms.TextBox
    Friend WithEvents txt_pyc As System.Windows.Forms.TextBox
    Friend WithEvents txt_seguro As System.Windows.Forms.TextBox
    Friend WithEvents txt_honorarios As System.Windows.Forms.TextBox
    Friend WithEvents txt_agencia As System.Windows.Forms.TextBox
    Friend WithEvents txt_boletin As System.Windows.Forms.TextBox
    Friend WithEvents txt_gastosvariables As System.Windows.Forms.TextBox
    Friend WithEvents txt_encomiendas As System.Windows.Forms.TextBox
    Friend WithEvents txt_revdescarg As System.Windows.Forms.TextBox
    Friend WithEvents txt_emision_gremision As System.Windows.Forms.TextBox
    Friend WithEvents txt_otroprov As System.Windows.Forms.TextBox
    Friend WithEvents txt_tdatos As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txt_refer_vesta As System.Windows.Forms.TextBox
End Class
