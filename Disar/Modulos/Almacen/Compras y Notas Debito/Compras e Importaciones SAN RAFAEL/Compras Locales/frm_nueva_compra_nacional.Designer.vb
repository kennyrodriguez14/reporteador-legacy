<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_orden_compra_nacional
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_orden_compra_nacional))
        Me.grp_ingreso_datos = New System.Windows.Forms.GroupBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.cmb_fecha_factura = New System.Windows.Forms.DateTimePicker
        Me.cmb_fecha_vencimiento = New System.Windows.Forms.DateTimePicker
        Me.Label28 = New System.Windows.Forms.Label
        Me.cmb_lote = New System.Windows.Forms.CheckBox
        Me.txt_lote = New System.Windows.Forms.TextBox
        Me.cmb_valores_base = New System.Windows.Forms.ComboBox
        Me.cmb_fecha_documento = New System.Windows.Forms.DateTimePicker
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.btn_new_prov = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_rfc = New System.Windows.Forms.TextBox
        Me.txt_nombre_proveedor = New System.Windows.Forms.TextBox
        Me.txt_codigo_proveedor = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_descuento_general = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_referencia_proveedor = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextPedido = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.grp_ingreso_producto = New System.Windows.Forms.GroupBox
        Me.cmb_uni = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_descuento_por = New System.Windows.Forms.TextBox
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.btn_quitar = New System.Windows.Forms.Button
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.btn_calcular = New System.Windows.Forms.Button
        Me.btn_agregar_producto = New System.Windows.Forms.Button
        Me.txt_isv_por = New System.Windows.Forms.TextBox
        Me.txt_precio_final = New System.Windows.Forms.TextBox
        Me.txt_con_lote = New System.Windows.Forms.TextBox
        Me.txt_uni_entrada = New System.Windows.Forms.TextBox
        Me.txt_precio_neg = New System.Windows.Forms.TextBox
        Me.txt_cantidad = New System.Windows.Forms.TextBox
        Me.txt_codigo_producto = New System.Windows.Forms.TextBox
        Me.txt_factor_conversion = New System.Windows.Forms.TextBox
        Me.txt_nombre_producto = New System.Windows.Forms.TextBox
        Me.grp_partida = New System.Windows.Forms.GroupBox
        Me.grd_ingreso = New System.Windows.Forms.DataGridView
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cve_art = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fconversion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.uni = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio_negociado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio_final = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descuento_por = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.isv_por = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sub_total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descuento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Isv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio_ins = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ajuste = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.uni_entrada = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.subtotal_mostrador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.totalmostrador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descuento_mostrador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.isv_mostrador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.con_lote = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Precio_Calc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_mostrador_producto = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_total_final = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_isv_final = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_descuento_final = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_subtotal_final = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txt_subtotalmostrador = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txt_descuento_mostrador = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txt_isvmostrador = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txt_totalmostrador = New System.Windows.Forms.TextBox
        Me.VerNotas = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.BtnDevolver = New System.Windows.Forms.Button
        Me.grp_ingreso_datos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grp_ingreso_producto.SuspendLayout()
        Me.grp_partida.SuspendLayout()
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp_ingreso_datos
        '
        Me.grp_ingreso_datos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso_datos.Controls.Add(Me.Label29)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_factura)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_vencimiento)
        Me.grp_ingreso_datos.Controls.Add(Me.Label28)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_lote)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_lote)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_valores_base)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_documento)
        Me.grp_ingreso_datos.Controls.Add(Me.Label23)
        Me.grp_ingreso_datos.Controls.Add(Me.Label17)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_sucursal)
        Me.grp_ingreso_datos.Controls.Add(Me.btn_new_prov)
        Me.grp_ingreso_datos.Controls.Add(Me.Label3)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_rfc)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_nombre_proveedor)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_codigo_proveedor)
        Me.grp_ingreso_datos.Controls.Add(Me.Label8)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_descuento_general)
        Me.grp_ingreso_datos.Controls.Add(Me.Label7)
        Me.grp_ingreso_datos.Controls.Add(Me.Label2)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_referencia_proveedor)
        Me.grp_ingreso_datos.Controls.Add(Me.Label9)
        Me.grp_ingreso_datos.Controls.Add(Me.Label1)
        Me.grp_ingreso_datos.Controls.Add(Me.GroupBox1)
        Me.grp_ingreso_datos.Location = New System.Drawing.Point(12, 12)
        Me.grp_ingreso_datos.Name = "grp_ingreso_datos"
        Me.grp_ingreso_datos.Size = New System.Drawing.Size(996, 163)
        Me.grp_ingreso_datos.TabIndex = 0
        Me.grp_ingreso_datos.TabStop = False
        Me.grp_ingreso_datos.Text = "Datos Generales"
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(80, 130)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(93, 13)
        Me.Label29.TabIndex = 7
        Me.Label29.Text = "Fecha Factura:"
        '
        'cmb_fecha_factura
        '
        Me.cmb_fecha_factura.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_factura.Location = New System.Drawing.Point(179, 127)
        Me.cmb_fecha_factura.Name = "cmb_fecha_factura"
        Me.cmb_fecha_factura.Size = New System.Drawing.Size(216, 20)
        Me.cmb_fecha_factura.TabIndex = 8
        '
        'cmb_fecha_vencimiento
        '
        Me.cmb_fecha_vencimiento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_vencimiento.Enabled = False
        Me.cmb_fecha_vencimiento.Location = New System.Drawing.Point(617, 100)
        Me.cmb_fecha_vencimiento.Name = "cmb_fecha_vencimiento"
        Me.cmb_fecha_vencimiento.Size = New System.Drawing.Size(221, 20)
        Me.cmb_fecha_vencimiento.TabIndex = 8
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(495, 104)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(119, 13)
        Me.Label28.TabIndex = 7
        Me.Label28.Text = "Fecha Vencimiento:"
        '
        'cmb_lote
        '
        Me.cmb_lote.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_lote.AutoSize = True
        Me.cmb_lote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_lote.Location = New System.Drawing.Point(672, 77)
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
        Me.txt_lote.Location = New System.Drawing.Point(730, 74)
        Me.txt_lote.Name = "txt_lote"
        Me.txt_lote.Size = New System.Drawing.Size(108, 20)
        Me.txt_lote.TabIndex = 0
        '
        'cmb_valores_base
        '
        Me.cmb_valores_base.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_valores_base.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valores_base.FormattingEnabled = True
        Me.cmb_valores_base.Items.AddRange(New Object() {"Sub Total", "Impuesto"})
        Me.cmb_valores_base.Location = New System.Drawing.Point(180, 100)
        Me.cmb_valores_base.Name = "cmb_valores_base"
        Me.cmb_valores_base.Size = New System.Drawing.Size(216, 21)
        Me.cmb_valores_base.TabIndex = 6
        '
        'cmb_fecha_documento
        '
        Me.cmb_fecha_documento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_documento.Location = New System.Drawing.Point(180, 74)
        Me.cmb_fecha_documento.Name = "cmb_fecha_documento"
        Me.cmb_fecha_documento.Size = New System.Drawing.Size(215, 20)
        Me.cmb_fecha_documento.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(71, 104)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(102, 13)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Valores en base:"
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(127, 76)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Fecha:"
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(180, 47)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(215, 21)
        Me.cmb_sucursal.TabIndex = 2
        '
        'btn_new_prov
        '
        Me.btn_new_prov.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_new_prov.Location = New System.Drawing.Point(179, 19)
        Me.btn_new_prov.Name = "btn_new_prov"
        Me.btn_new_prov.Size = New System.Drawing.Size(25, 22)
        Me.btn_new_prov.TabIndex = 1
        Me.btn_new_prov.Text = "..."
        Me.btn_new_prov.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(112, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Almacen:"
        '
        'txt_rfc
        '
        Me.txt_rfc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_rfc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_rfc.Location = New System.Drawing.Point(730, 48)
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
        Me.txt_nombre_proveedor.Location = New System.Drawing.Point(393, 20)
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
        Me.txt_codigo_proveedor.Location = New System.Drawing.Point(210, 20)
        Me.txt_codigo_proveedor.Name = "txt_codigo_proveedor"
        Me.txt_codigo_proveedor.ReadOnly = True
        Me.txt_codigo_proveedor.Size = New System.Drawing.Size(108, 20)
        Me.txt_codigo_proveedor.TabIndex = 0
        Me.txt_codigo_proveedor.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(689, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "RFC:"
        '
        'txt_descuento_general
        '
        Me.txt_descuento_general.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_descuento_general.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_general.Location = New System.Drawing.Point(531, 74)
        Me.txt_descuento_general.Name = "txt_descuento_general"
        Me.txt_descuento_general.Size = New System.Drawing.Size(108, 20)
        Me.txt_descuento_general.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(337, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(104, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Proveedor:"
        '
        'txt_referencia_proveedor
        '
        Me.txt_referencia_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_referencia_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_referencia_proveedor.Location = New System.Drawing.Point(531, 48)
        Me.txt_referencia_proveedor.Name = "txt_referencia_proveedor"
        Me.txt_referencia_proveedor.Size = New System.Drawing.Size(152, 20)
        Me.txt_referencia_proveedor.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(453, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Descuento:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(428, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ref. Proveedor:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.GroupBox1.Controls.Add(Me.TextPedido)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Location = New System.Drawing.Point(870, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(114, 81)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'TextPedido
        '
        Me.TextPedido.Location = New System.Drawing.Point(17, 44)
        Me.TextPedido.Name = "TextPedido"
        Me.TextPedido.Size = New System.Drawing.Size(82, 20)
        Me.TextPedido.TabIndex = 10
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(6, 16)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(106, 13)
        Me.Label30.TabIndex = 9
        Me.Label30.Text = "Orden de Pedido:"
        '
        'grp_ingreso_producto
        '
        Me.grp_ingreso_producto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso_producto.Controls.Add(Me.cmb_uni)
        Me.grp_ingreso_producto.Controls.Add(Me.Label18)
        Me.grp_ingreso_producto.Controls.Add(Me.Label12)
        Me.grp_ingreso_producto.Controls.Add(Me.Label13)
        Me.grp_ingreso_producto.Controls.Add(Me.Label19)
        Me.grp_ingreso_producto.Controls.Add(Me.Label21)
        Me.grp_ingreso_producto.Controls.Add(Me.Label20)
        Me.grp_ingreso_producto.Controls.Add(Me.Label22)
        Me.grp_ingreso_producto.Controls.Add(Me.Label15)
        Me.grp_ingreso_producto.Controls.Add(Me.Label14)
        Me.grp_ingreso_producto.Controls.Add(Me.Label11)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_descuento_por)
        Me.grp_ingreso_producto.Controls.Add(Me.btn_limpiar)
        Me.grp_ingreso_producto.Controls.Add(Me.btn_quitar)
        Me.grp_ingreso_producto.Controls.Add(Me.btn_agregar)
        Me.grp_ingreso_producto.Controls.Add(Me.btn_calcular)
        Me.grp_ingreso_producto.Controls.Add(Me.btn_agregar_producto)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_isv_por)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_precio_final)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_con_lote)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_uni_entrada)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_precio_neg)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_cantidad)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_codigo_producto)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_factor_conversion)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_nombre_producto)
        Me.grp_ingreso_producto.Location = New System.Drawing.Point(12, 181)
        Me.grp_ingreso_producto.Name = "grp_ingreso_producto"
        Me.grp_ingreso_producto.Size = New System.Drawing.Size(996, 103)
        Me.grp_ingreso_producto.TabIndex = 10
        Me.grp_ingreso_producto.TabStop = False
        Me.grp_ingreso_producto.Text = "Ingreso de productos"
        '
        'cmb_uni
        '
        Me.cmb_uni.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_uni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_uni.FormattingEnabled = True
        Me.cmb_uni.Items.AddRange(New Object() {"pz", "cj"})
        Me.cmb_uni.Location = New System.Drawing.Point(189, 30)
        Me.cmb_uni.Name = "cmb_uni"
        Me.cmb_uni.Size = New System.Drawing.Size(61, 21)
        Me.cmb_uni.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(772, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(93, 13)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Factor Conversion"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(400, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Producto"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(186, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(23, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Uni"
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(389, 57)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "% Descuento"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(540, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(32, 13)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "% Isv"
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(126, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Precio Final"
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(941, 15)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(44, 13)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "Entrada"
        Me.Label22.Visible = False
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(247, 57)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Precio Negociado"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(84, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Cantidad"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(253, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Codigo"
        '
        'txt_descuento_por
        '
        Me.txt_descuento_por.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_descuento_por.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_por.Location = New System.Drawing.Point(376, 72)
        Me.txt_descuento_por.Name = "txt_descuento_por"
        Me.txt_descuento_por.Size = New System.Drawing.Size(97, 20)
        Me.txt_descuento_por.TabIndex = 0
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.Location = New System.Drawing.Point(834, 69)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(77, 23)
        Me.btn_limpiar.TabIndex = 13
        Me.btn_limpiar.Text = "Limpiar"
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'btn_quitar
        '
        Me.btn_quitar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_quitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar.Location = New System.Drawing.Point(730, 69)
        Me.btn_quitar.Name = "btn_quitar"
        Me.btn_quitar.Size = New System.Drawing.Size(77, 23)
        Me.btn_quitar.TabIndex = 12
        Me.btn_quitar.Text = "Quitar"
        Me.btn_quitar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.Location = New System.Drawing.Point(632, 69)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(78, 23)
        Me.btn_agregar.TabIndex = 11
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'btn_calcular
        '
        Me.btn_calcular.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_calcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_calcular.Location = New System.Drawing.Point(76, 72)
        Me.btn_calcular.Name = "btn_calcular"
        Me.btn_calcular.Size = New System.Drawing.Size(28, 20)
        Me.btn_calcular.TabIndex = 9
        Me.btn_calcular.Text = "..."
        Me.btn_calcular.UseVisualStyleBackColor = True
        '
        'btn_agregar_producto
        '
        Me.btn_agregar_producto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_agregar_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar_producto.Location = New System.Drawing.Point(154, 32)
        Me.btn_agregar_producto.Name = "btn_agregar_producto"
        Me.btn_agregar_producto.Size = New System.Drawing.Size(28, 20)
        Me.btn_agregar_producto.TabIndex = 8
        Me.btn_agregar_producto.Text = "..."
        Me.btn_agregar_producto.UseVisualStyleBackColor = True
        '
        'txt_isv_por
        '
        Me.txt_isv_por.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_isv_por.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isv_por.Location = New System.Drawing.Point(508, 72)
        Me.txt_isv_por.Name = "txt_isv_por"
        Me.txt_isv_por.Size = New System.Drawing.Size(97, 20)
        Me.txt_isv_por.TabIndex = 0
        '
        'txt_precio_final
        '
        Me.txt_precio_final.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_precio_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_precio_final.Location = New System.Drawing.Point(115, 72)
        Me.txt_precio_final.Name = "txt_precio_final"
        Me.txt_precio_final.Size = New System.Drawing.Size(97, 20)
        Me.txt_precio_final.TabIndex = 10
        '
        'txt_con_lote
        '
        Me.txt_con_lote.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_con_lote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_con_lote.Location = New System.Drawing.Point(933, 56)
        Me.txt_con_lote.Name = "txt_con_lote"
        Me.txt_con_lote.ReadOnly = True
        Me.txt_con_lote.Size = New System.Drawing.Size(57, 20)
        Me.txt_con_lote.TabIndex = 0
        Me.txt_con_lote.Visible = False
        '
        'txt_uni_entrada
        '
        Me.txt_uni_entrada.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_uni_entrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_uni_entrada.Location = New System.Drawing.Point(933, 30)
        Me.txt_uni_entrada.Name = "txt_uni_entrada"
        Me.txt_uni_entrada.ReadOnly = True
        Me.txt_uni_entrada.Size = New System.Drawing.Size(57, 20)
        Me.txt_uni_entrada.TabIndex = 0
        Me.txt_uni_entrada.Visible = False
        '
        'txt_precio_neg
        '
        Me.txt_precio_neg.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_precio_neg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_precio_neg.Location = New System.Drawing.Point(246, 72)
        Me.txt_precio_neg.Name = "txt_precio_neg"
        Me.txt_precio_neg.ReadOnly = True
        Me.txt_precio_neg.Size = New System.Drawing.Size(97, 20)
        Me.txt_precio_neg.TabIndex = 0
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cantidad.Location = New System.Drawing.Point(76, 32)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(72, 20)
        Me.txt_cantidad.TabIndex = 7
        '
        'txt_codigo_producto
        '
        Me.txt_codigo_producto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_codigo_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_producto.Location = New System.Drawing.Point(256, 31)
        Me.txt_codigo_producto.Name = "txt_codigo_producto"
        Me.txt_codigo_producto.ReadOnly = True
        Me.txt_codigo_producto.Size = New System.Drawing.Size(141, 20)
        Me.txt_codigo_producto.TabIndex = 0
        '
        'txt_factor_conversion
        '
        Me.txt_factor_conversion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_factor_conversion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_factor_conversion.Location = New System.Drawing.Point(775, 31)
        Me.txt_factor_conversion.Name = "txt_factor_conversion"
        Me.txt_factor_conversion.ReadOnly = True
        Me.txt_factor_conversion.Size = New System.Drawing.Size(136, 20)
        Me.txt_factor_conversion.TabIndex = 0
        '
        'txt_nombre_producto
        '
        Me.txt_nombre_producto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_nombre_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_producto.Location = New System.Drawing.Point(403, 31)
        Me.txt_nombre_producto.Name = "txt_nombre_producto"
        Me.txt_nombre_producto.ReadOnly = True
        Me.txt_nombre_producto.Size = New System.Drawing.Size(366, 20)
        Me.txt_nombre_producto.TabIndex = 0
        '
        'grp_partida
        '
        Me.grp_partida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_partida.Controls.Add(Me.grd_ingreso)
        Me.grp_partida.Location = New System.Drawing.Point(12, 285)
        Me.grp_partida.Name = "grp_partida"
        Me.grp_partida.Size = New System.Drawing.Size(996, 274)
        Me.grp_partida.TabIndex = 11
        Me.grp_partida.TabStop = False
        '
        'grd_ingreso
        '
        Me.grd_ingreso.AllowUserToAddRows = False
        Me.grd_ingreso.AllowUserToDeleteRows = False
        Me.grd_ingreso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_ingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ingreso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cantidad, Me.cve_art, Me.producto, Me.fconversion, Me.uni, Me.precio_negociado, Me.precio_final, Me.descuento_por, Me.isv_por, Me.Sub_total, Me.descuento, Me.Isv, Me.total, Me.precio_ins, Me.ajuste, Me.uni_entrada, Me.subtotal_mostrador, Me.totalmostrador, Me.descuento_mostrador, Me.isv_mostrador, Me.con_lote, Me.Precio_Calc})
        Me.grd_ingreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_ingreso.Location = New System.Drawing.Point(3, 16)
        Me.grd_ingreso.Name = "grd_ingreso"
        Me.grd_ingreso.ReadOnly = True
        Me.grd_ingreso.RowHeadersVisible = False
        Me.grd_ingreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_ingreso.Size = New System.Drawing.Size(990, 255)
        Me.grd_ingreso.TabIndex = 14
        '
        'cantidad
        '
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.cantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        '
        'cve_art
        '
        Me.cve_art.HeaderText = "Codigo"
        Me.cve_art.Name = "cve_art"
        Me.cve_art.ReadOnly = True
        '
        'producto
        '
        Me.producto.HeaderText = "Producto"
        Me.producto.Name = "producto"
        Me.producto.ReadOnly = True
        Me.producto.Visible = False
        '
        'fconversion
        '
        Me.fconversion.HeaderText = "Factor Conversion"
        Me.fconversion.Name = "fconversion"
        Me.fconversion.ReadOnly = True
        '
        'uni
        '
        Me.uni.HeaderText = "Uni"
        Me.uni.Name = "uni"
        Me.uni.ReadOnly = True
        '
        'precio_negociado
        '
        DataGridViewCellStyle2.Format = "N2"
        Me.precio_negociado.DefaultCellStyle = DataGridViewCellStyle2
        Me.precio_negociado.HeaderText = "Precio Negociado"
        Me.precio_negociado.Name = "precio_negociado"
        Me.precio_negociado.ReadOnly = True
        '
        'precio_final
        '
        Me.precio_final.HeaderText = "Precio Final"
        Me.precio_final.Name = "precio_final"
        Me.precio_final.ReadOnly = True
        '
        'descuento_por
        '
        DataGridViewCellStyle3.Format = "N2"
        Me.descuento_por.DefaultCellStyle = DataGridViewCellStyle3
        Me.descuento_por.HeaderText = "%Descuento"
        Me.descuento_por.Name = "descuento_por"
        Me.descuento_por.ReadOnly = True
        '
        'isv_por
        '
        DataGridViewCellStyle4.Format = "N2"
        Me.isv_por.DefaultCellStyle = DataGridViewCellStyle4
        Me.isv_por.HeaderText = "%Isv"
        Me.isv_por.Name = "isv_por"
        Me.isv_por.ReadOnly = True
        '
        'Sub_total
        '
        DataGridViewCellStyle5.Format = "N2"
        Me.Sub_total.DefaultCellStyle = DataGridViewCellStyle5
        Me.Sub_total.HeaderText = "SubTotal"
        Me.Sub_total.Name = "Sub_total"
        Me.Sub_total.ReadOnly = True
        Me.Sub_total.Visible = False
        '
        'descuento
        '
        DataGridViewCellStyle6.Format = "N2"
        Me.descuento.DefaultCellStyle = DataGridViewCellStyle6
        Me.descuento.HeaderText = "Descuento"
        Me.descuento.Name = "descuento"
        Me.descuento.ReadOnly = True
        Me.descuento.Visible = False
        '
        'Isv
        '
        DataGridViewCellStyle7.Format = "N2"
        Me.Isv.DefaultCellStyle = DataGridViewCellStyle7
        Me.Isv.HeaderText = "Isv"
        Me.Isv.Name = "Isv"
        Me.Isv.ReadOnly = True
        Me.Isv.Visible = False
        '
        'total
        '
        DataGridViewCellStyle8.Format = "N2"
        Me.total.DefaultCellStyle = DataGridViewCellStyle8
        Me.total.HeaderText = "Total"
        Me.total.Name = "total"
        Me.total.ReadOnly = True
        Me.total.Visible = False
        '
        'precio_ins
        '
        Me.precio_ins.HeaderText = "precio_insertar"
        Me.precio_ins.Name = "precio_ins"
        Me.precio_ins.ReadOnly = True
        Me.precio_ins.Visible = False
        '
        'ajuste
        '
        Me.ajuste.HeaderText = "Ajuste"
        Me.ajuste.Name = "ajuste"
        Me.ajuste.ReadOnly = True
        Me.ajuste.Visible = False
        '
        'uni_entrada
        '
        Me.uni_entrada.HeaderText = "Uni Entrada"
        Me.uni_entrada.Name = "uni_entrada"
        Me.uni_entrada.ReadOnly = True
        Me.uni_entrada.Visible = False
        '
        'subtotal_mostrador
        '
        Me.subtotal_mostrador.HeaderText = "SubTotal"
        Me.subtotal_mostrador.Name = "subtotal_mostrador"
        Me.subtotal_mostrador.ReadOnly = True
        '
        'totalmostrador
        '
        Me.totalmostrador.HeaderText = "Total"
        Me.totalmostrador.Name = "totalmostrador"
        Me.totalmostrador.ReadOnly = True
        '
        'descuento_mostrador
        '
        Me.descuento_mostrador.HeaderText = "Descuento"
        Me.descuento_mostrador.Name = "descuento_mostrador"
        Me.descuento_mostrador.ReadOnly = True
        '
        'isv_mostrador
        '
        Me.isv_mostrador.HeaderText = "Isv"
        Me.isv_mostrador.Name = "isv_mostrador"
        Me.isv_mostrador.ReadOnly = True
        Me.isv_mostrador.Visible = False
        '
        'con_lote
        '
        Me.con_lote.HeaderText = "Con Lote"
        Me.con_lote.Name = "con_lote"
        Me.con_lote.ReadOnly = True
        '
        'Precio_Calc
        '
        Me.Precio_Calc.HeaderText = "Precio_Calc"
        Me.Precio_Calc.Name = "Precio_Calc"
        Me.Precio_Calc.ReadOnly = True
        Me.Precio_Calc.Visible = False
        '
        'txt_mostrador_producto
        '
        Me.txt_mostrador_producto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_mostrador_producto.Location = New System.Drawing.Point(15, 580)
        Me.txt_mostrador_producto.Name = "txt_mostrador_producto"
        Me.txt_mostrador_producto.ReadOnly = True
        Me.txt_mostrador_producto.Size = New System.Drawing.Size(434, 20)
        Me.txt_mostrador_producto.TabIndex = 30
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 566)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Producto"
        '
        'txt_total_final
        '
        Me.txt_total_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_final.Location = New System.Drawing.Point(585, 642)
        Me.txt_total_final.Name = "txt_total_final"
        Me.txt_total_final.ReadOnly = True
        Me.txt_total_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_total_final.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(539, 644)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Total:"
        '
        'txt_isv_final
        '
        Me.txt_isv_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_isv_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isv_final.Location = New System.Drawing.Point(585, 616)
        Me.txt_isv_final.Name = "txt_isv_final"
        Me.txt_isv_final.ReadOnly = True
        Me.txt_isv_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_isv_final.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(536, 618)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "I.S.V.:"
        '
        'txt_descuento_final
        '
        Me.txt_descuento_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_descuento_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_final.Location = New System.Drawing.Point(585, 590)
        Me.txt_descuento_final.Name = "txt_descuento_final"
        Me.txt_descuento_final.ReadOnly = True
        Me.txt_descuento_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_descuento_final.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(507, 592)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Descuento:"
        '
        'txt_subtotal_final
        '
        Me.txt_subtotal_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_subtotal_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_subtotal_final.Location = New System.Drawing.Point(585, 564)
        Me.txt_subtotal_final.Name = "txt_subtotal_final"
        Me.txt_subtotal_final.ReadOnly = True
        Me.txt_subtotal_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_subtotal_final.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(517, 566)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Sub-total:"
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(776, 566)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(62, 13)
        Me.Label24.TabIndex = 19
        Me.Label24.Text = "Sub-total:"
        '
        'txt_subtotalmostrador
        '
        Me.txt_subtotalmostrador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_subtotalmostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_subtotalmostrador.Location = New System.Drawing.Point(844, 564)
        Me.txt_subtotalmostrador.Name = "txt_subtotalmostrador"
        Me.txt_subtotalmostrador.ReadOnly = True
        Me.txt_subtotalmostrador.Size = New System.Drawing.Size(161, 20)
        Me.txt_subtotalmostrador.TabIndex = 15
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(766, 592)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 13)
        Me.Label25.TabIndex = 21
        Me.Label25.Text = "Descuento:"
        '
        'txt_descuento_mostrador
        '
        Me.txt_descuento_mostrador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_descuento_mostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_mostrador.Location = New System.Drawing.Point(844, 590)
        Me.txt_descuento_mostrador.Name = "txt_descuento_mostrador"
        Me.txt_descuento_mostrador.ReadOnly = True
        Me.txt_descuento_mostrador.Size = New System.Drawing.Size(161, 20)
        Me.txt_descuento_mostrador.TabIndex = 16
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(795, 618)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(43, 13)
        Me.Label26.TabIndex = 20
        Me.Label26.Text = "I.S.V.:"
        '
        'txt_isvmostrador
        '
        Me.txt_isvmostrador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_isvmostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isvmostrador.Location = New System.Drawing.Point(844, 616)
        Me.txt_isvmostrador.Name = "txt_isvmostrador"
        Me.txt_isvmostrador.ReadOnly = True
        Me.txt_isvmostrador.Size = New System.Drawing.Size(161, 20)
        Me.txt_isvmostrador.TabIndex = 17
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(798, 644)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(40, 13)
        Me.Label27.TabIndex = 22
        Me.Label27.Text = "Total:"
        '
        'txt_totalmostrador
        '
        Me.txt_totalmostrador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_totalmostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_totalmostrador.Location = New System.Drawing.Point(844, 642)
        Me.txt_totalmostrador.Name = "txt_totalmostrador"
        Me.txt_totalmostrador.ReadOnly = True
        Me.txt_totalmostrador.Size = New System.Drawing.Size(161, 20)
        Me.txt_totalmostrador.TabIndex = 18
        '
        'VerNotas
        '
        Me.VerNotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.VerNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VerNotas.Image = Global.Disar.My.Resources.Resources.Evaluacion_PDSE
        Me.VerNotas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.VerNotas.Location = New System.Drawing.Point(100, 683)
        Me.VerNotas.Name = "VerNotas"
        Me.VerNotas.Size = New System.Drawing.Size(135, 51)
        Me.VerNotas.TabIndex = 31
        Me.VerNotas.Text = "Ver Notas de Crédito y Débito"
        Me.VerNotas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.VerNotas.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.btn_cancelar.Location = New System.Drawing.Point(926, 683)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(82, 51)
        Me.btn_cancelar.TabIndex = 20
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = Global.Disar.My.Resources.Resources.Guardar
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(12, 683)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(82, 51)
        Me.btn_guardar.TabIndex = 19
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'BtnDevolver
        '
        Me.BtnDevolver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDevolver.Enabled = False
        Me.BtnDevolver.Image = Global.Disar.My.Resources.Resources.Adblock_Dark_32
        Me.BtnDevolver.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnDevolver.Location = New System.Drawing.Point(240, 683)
        Me.BtnDevolver.Name = "BtnDevolver"
        Me.BtnDevolver.Size = New System.Drawing.Size(109, 51)
        Me.BtnDevolver.TabIndex = 32
        Me.BtnDevolver.Text = "Devolver"
        Me.BtnDevolver.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnDevolver.UseVisualStyleBackColor = True
        Me.BtnDevolver.Visible = False
        '
        'frm_orden_compra_nacional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 746)
        Me.Controls.Add(Me.BtnDevolver)
        Me.Controls.Add(Me.VerNotas)
        Me.Controls.Add(Me.txt_mostrador_producto)
        Me.Controls.Add(Me.Label16)
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
        Me.Controls.Add(Me.grp_ingreso_producto)
        Me.Controls.Add(Me.grp_ingreso_datos)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_orden_compra_nacional"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva orden de compra"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_ingreso_datos.ResumeLayout(False)
        Me.grp_ingreso_datos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_ingreso_producto.ResumeLayout(False)
        Me.grp_ingreso_producto.PerformLayout()
        Me.grp_partida.ResumeLayout(False)
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grp_ingreso_datos As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_fecha_documento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btn_new_prov As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_rfc As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento_general As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_referencia_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grp_ingreso_producto As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_uni As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento_por As System.Windows.Forms.TextBox
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_quitar As System.Windows.Forms.Button
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_producto As System.Windows.Forms.Button
    Friend WithEvents txt_isv_por As System.Windows.Forms.TextBox
    Friend WithEvents txt_precio_neg As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_factor_conversion As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_producto As System.Windows.Forms.TextBox
    Friend WithEvents grp_partida As System.Windows.Forms.GroupBox
    Friend WithEvents grd_ingreso As System.Windows.Forms.DataGridView
    Friend WithEvents txt_mostrador_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_total_final As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_isv_final As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento_final As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_subtotal_final As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_precio_final As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_uni_entrada As System.Windows.Forms.TextBox
    Friend WithEvents btn_calcular As System.Windows.Forms.Button
    Friend WithEvents cmb_valores_base As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_subtotalmostrador As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento_mostrador As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txt_isvmostrador As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txt_totalmostrador As System.Windows.Forms.TextBox
    Friend WithEvents txt_lote As System.Windows.Forms.TextBox
    Friend WithEvents cmb_lote As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_fecha_vencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txt_con_lote As System.Windows.Forms.TextBox
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cve_art As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fconversion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio_negociado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio_final As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descuento_por As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isv_por As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sub_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Isv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio_ins As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ajuste As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uni_entrada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents subtotal_mostrador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalmostrador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descuento_mostrador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isv_mostrador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents con_lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio_Calc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerNotas As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_factura As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextPedido As System.Windows.Forms.TextBox
    Friend WithEvents BtnDevolver As System.Windows.Forms.Button
End Class
