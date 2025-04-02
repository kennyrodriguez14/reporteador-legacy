<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_orden_pedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_orden_pedidos))
        Me.grp_ingreso_datos = New System.Windows.Forms.GroupBox
        Me.cmb_fecha_documento = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.btn_get_folio = New System.Windows.Forms.Button
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
        Me.txt_num_registro = New System.Windows.Forms.TextBox
        Me.lbl_codigo = New System.Windows.Forms.Label
        Me.grp_partida = New System.Windows.Forms.GroupBox
        Me.grd_ingreso = New System.Windows.Forms.DataGridView
        Me.uni = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cve_art = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fconversion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio_negociado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descuento_por = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.isv_por = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sub_total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descuento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Isv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grp_ingreso_producto = New System.Windows.Forms.GroupBox
        Me.cmb_uni = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_descuento_por = New System.Windows.Forms.TextBox
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.btn_quitar = New System.Windows.Forms.Button
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.btn_agregar_producto = New System.Windows.Forms.Button
        Me.txt_isv_por = New System.Windows.Forms.TextBox
        Me.txt_precio_neg = New System.Windows.Forms.TextBox
        Me.txt_cantidad = New System.Windows.Forms.TextBox
        Me.txt_codigo_producto = New System.Windows.Forms.TextBox
        Me.txt_factor_conversion = New System.Windows.Forms.TextBox
        Me.txt_nombre_producto = New System.Windows.Forms.TextBox
        Me.txt_subtotal_final = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_descuento_final = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_isv_final = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_total_final = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_mostrador_producto = New System.Windows.Forms.TextBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.grp_ingreso_datos.SuspendLayout()
        Me.grp_partida.SuspendLayout()
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_ingreso_producto.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_ingreso_datos
        '
        Me.grp_ingreso_datos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_documento)
        Me.grp_ingreso_datos.Controls.Add(Me.Label17)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_sucursal)
        Me.grp_ingreso_datos.Controls.Add(Me.btn_get_folio)
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
        Me.grp_ingreso_datos.Controls.Add(Me.txt_num_registro)
        Me.grp_ingreso_datos.Controls.Add(Me.lbl_codigo)
        Me.grp_ingreso_datos.Location = New System.Drawing.Point(12, 12)
        Me.grp_ingreso_datos.Name = "grp_ingreso_datos"
        Me.grp_ingreso_datos.Size = New System.Drawing.Size(838, 141)
        Me.grp_ingreso_datos.TabIndex = 7
        Me.grp_ingreso_datos.TabStop = False
        Me.grp_ingreso_datos.Text = "Datos Generales"
        '
        'cmb_fecha_documento
        '
        Me.cmb_fecha_documento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_documento.Location = New System.Drawing.Point(126, 111)
        Me.cmb_fecha_documento.Name = "cmb_fecha_documento"
        Me.cmb_fecha_documento.Size = New System.Drawing.Size(215, 20)
        Me.cmb_fecha_documento.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(78, 112)
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
        Me.cmb_sucursal.Location = New System.Drawing.Point(126, 84)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(215, 21)
        Me.cmb_sucursal.TabIndex = 7
        '
        'btn_get_folio
        '
        Me.btn_get_folio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_get_folio.Location = New System.Drawing.Point(167, 32)
        Me.btn_get_folio.Name = "btn_get_folio"
        Me.btn_get_folio.Size = New System.Drawing.Size(25, 22)
        Me.btn_get_folio.TabIndex = 2
        Me.btn_get_folio.Text = "..."
        Me.btn_get_folio.UseVisualStyleBackColor = True
        '
        'btn_new_prov
        '
        Me.btn_new_prov.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_new_prov.Location = New System.Drawing.Point(624, 30)
        Me.btn_new_prov.Name = "btn_new_prov"
        Me.btn_new_prov.Size = New System.Drawing.Size(25, 22)
        Me.btn_new_prov.TabIndex = 2
        Me.btn_new_prov.Text = "..."
        Me.btn_new_prov.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(65, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Almacen:"
        '
        'txt_rfc
        '
        Me.txt_rfc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_rfc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_rfc.Location = New System.Drawing.Point(655, 60)
        Me.txt_rfc.Name = "txt_rfc"
        Me.txt_rfc.ReadOnly = True
        Me.txt_rfc.Size = New System.Drawing.Size(108, 20)
        Me.txt_rfc.TabIndex = 4
        '
        'txt_nombre_proveedor
        '
        Me.txt_nombre_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombre_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_proveedor.Location = New System.Drawing.Point(126, 58)
        Me.txt_nombre_proveedor.Name = "txt_nombre_proveedor"
        Me.txt_nombre_proveedor.ReadOnly = True
        Me.txt_nombre_proveedor.Size = New System.Drawing.Size(445, 20)
        Me.txt_nombre_proveedor.TabIndex = 4
        '
        'txt_codigo_proveedor
        '
        Me.txt_codigo_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_proveedor.Location = New System.Drawing.Point(655, 30)
        Me.txt_codigo_proveedor.Name = "txt_codigo_proveedor"
        Me.txt_codigo_proveedor.ReadOnly = True
        Me.txt_codigo_proveedor.Size = New System.Drawing.Size(108, 20)
        Me.txt_codigo_proveedor.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(614, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "RFC:"
        '
        'txt_descuento_general
        '
        Me.txt_descuento_general.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_descuento_general.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_general.Location = New System.Drawing.Point(655, 90)
        Me.txt_descuento_general.Name = "txt_descuento_general"
        Me.txt_descuento_general.Size = New System.Drawing.Size(108, 20)
        Me.txt_descuento_general.TabIndex = 6
        Me.txt_descuento_general.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(70, 62)
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
        Me.Label2.Location = New System.Drawing.Point(554, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Proveedor:"
        '
        'txt_referencia_proveedor
        '
        Me.txt_referencia_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_referencia_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_referencia_proveedor.Location = New System.Drawing.Point(463, 85)
        Me.txt_referencia_proveedor.Name = "txt_referencia_proveedor"
        Me.txt_referencia_proveedor.Size = New System.Drawing.Size(108, 20)
        Me.txt_referencia_proveedor.TabIndex = 5
        Me.txt_referencia_proveedor.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(577, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Descuento:"
        Me.Label9.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(360, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ref. Proveedor:"
        Me.Label1.Visible = False
        '
        'txt_num_registro
        '
        Me.txt_num_registro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_num_registro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_num_registro.Location = New System.Drawing.Point(198, 32)
        Me.txt_num_registro.Name = "txt_num_registro"
        Me.txt_num_registro.ReadOnly = True
        Me.txt_num_registro.Size = New System.Drawing.Size(82, 20)
        Me.txt_num_registro.TabIndex = 1
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(64, 34)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(105, 13)
        Me.lbl_codigo.TabIndex = 0
        Me.lbl_codigo.Text = "Orden de pedido:"
        '
        'grp_partida
        '
        Me.grp_partida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_partida.Controls.Add(Me.grd_ingreso)
        Me.grp_partida.Location = New System.Drawing.Point(12, 281)
        Me.grp_partida.Name = "grp_partida"
        Me.grp_partida.Size = New System.Drawing.Size(838, 342)
        Me.grp_partida.TabIndex = 8
        Me.grp_partida.TabStop = False
        '
        'grd_ingreso
        '
        Me.grd_ingreso.AllowUserToAddRows = False
        Me.grd_ingreso.AllowUserToDeleteRows = False
        Me.grd_ingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ingreso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.uni, Me.cve_art, Me.producto, Me.fconversion, Me.cantidad, Me.precio_negociado, Me.descuento_por, Me.isv_por, Me.Sub_total, Me.descuento, Me.Isv, Me.total})
        Me.grd_ingreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_ingreso.Location = New System.Drawing.Point(3, 16)
        Me.grd_ingreso.Name = "grd_ingreso"
        Me.grd_ingreso.ReadOnly = True
        Me.grd_ingreso.RowHeadersVisible = False
        Me.grd_ingreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_ingreso.Size = New System.Drawing.Size(832, 323)
        Me.grd_ingreso.TabIndex = 0
        '
        'uni
        '
        Me.uni.HeaderText = "Uni"
        Me.uni.Name = "uni"
        Me.uni.ReadOnly = True
        Me.uni.Width = 50
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
        'cantidad
        '
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.cantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        '
        'precio_negociado
        '
        DataGridViewCellStyle2.Format = "N2"
        Me.precio_negociado.DefaultCellStyle = DataGridViewCellStyle2
        Me.precio_negociado.HeaderText = "Precio Negociado"
        Me.precio_negociado.Name = "precio_negociado"
        Me.precio_negociado.ReadOnly = True
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
        Me.grp_ingreso_producto.Controls.Add(Me.Label15)
        Me.grp_ingreso_producto.Controls.Add(Me.Label14)
        Me.grp_ingreso_producto.Controls.Add(Me.Label11)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_descuento_por)
        Me.grp_ingreso_producto.Controls.Add(Me.btn_limpiar)
        Me.grp_ingreso_producto.Controls.Add(Me.btn_quitar)
        Me.grp_ingreso_producto.Controls.Add(Me.btn_agregar)
        Me.grp_ingreso_producto.Controls.Add(Me.btn_agregar_producto)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_isv_por)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_precio_neg)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_cantidad)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_codigo_producto)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_factor_conversion)
        Me.grp_ingreso_producto.Controls.Add(Me.txt_nombre_producto)
        Me.grp_ingreso_producto.Location = New System.Drawing.Point(13, 160)
        Me.grp_ingreso_producto.Name = "grp_ingreso_producto"
        Me.grp_ingreso_producto.Size = New System.Drawing.Size(837, 115)
        Me.grp_ingreso_producto.TabIndex = 9
        Me.grp_ingreso_producto.TabStop = False
        Me.grp_ingreso_producto.Text = "Ingreso de productos"
        '
        'cmb_uni
        '
        Me.cmb_uni.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_uni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_uni.FormattingEnabled = True
        Me.cmb_uni.Items.AddRange(New Object() {"pz", "cj"})
        Me.cmb_uni.Location = New System.Drawing.Point(71, 38)
        Me.cmb_uni.Name = "cmb_uni"
        Me.cmb_uni.Size = New System.Drawing.Size(61, 21)
        Me.cmb_uni.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(654, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(93, 13)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Factor Conversion"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(282, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Producto"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(68, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(23, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Uni"
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(234, 66)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "% Descuento"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(316, 66)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(32, 13)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "% Isv"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(135, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Precio Negociado"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(57, 66)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Cantidad"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(135, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Codigo"
        '
        'txt_descuento_por
        '
        Me.txt_descuento_por.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_descuento_por.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_por.Location = New System.Drawing.Point(237, 81)
        Me.txt_descuento_por.Name = "txt_descuento_por"
        Me.txt_descuento_por.Size = New System.Drawing.Size(72, 20)
        Me.txt_descuento_por.TabIndex = 1
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.Location = New System.Drawing.Point(728, 78)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(65, 23)
        Me.btn_limpiar.TabIndex = 0
        Me.btn_limpiar.Text = "Limpiar"
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'btn_quitar
        '
        Me.btn_quitar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_quitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar.Location = New System.Drawing.Point(657, 79)
        Me.btn_quitar.Name = "btn_quitar"
        Me.btn_quitar.Size = New System.Drawing.Size(65, 23)
        Me.btn_quitar.TabIndex = 0
        Me.btn_quitar.Text = "Quitar"
        Me.btn_quitar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.Location = New System.Drawing.Point(586, 79)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(65, 23)
        Me.btn_agregar.TabIndex = 0
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'btn_agregar_producto
        '
        Me.btn_agregar_producto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_agregar_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar_producto.Location = New System.Drawing.Point(35, 37)
        Me.btn_agregar_producto.Name = "btn_agregar_producto"
        Me.btn_agregar_producto.Size = New System.Drawing.Size(28, 20)
        Me.btn_agregar_producto.TabIndex = 0
        Me.btn_agregar_producto.Text = "..."
        Me.btn_agregar_producto.UseVisualStyleBackColor = True
        '
        'txt_isv_por
        '
        Me.txt_isv_por.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_isv_por.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isv_por.Location = New System.Drawing.Point(315, 81)
        Me.txt_isv_por.Name = "txt_isv_por"
        Me.txt_isv_por.Size = New System.Drawing.Size(72, 20)
        Me.txt_isv_por.TabIndex = 1
        '
        'txt_precio_neg
        '
        Me.txt_precio_neg.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_precio_neg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_precio_neg.Location = New System.Drawing.Point(138, 81)
        Me.txt_precio_neg.Name = "txt_precio_neg"
        Me.txt_precio_neg.ReadOnly = True
        Me.txt_precio_neg.Size = New System.Drawing.Size(72, 20)
        Me.txt_precio_neg.TabIndex = 1
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cantidad.Location = New System.Drawing.Point(60, 81)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(72, 20)
        Me.txt_cantidad.TabIndex = 1
        '
        'txt_codigo_producto
        '
        Me.txt_codigo_producto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_codigo_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_producto.Location = New System.Drawing.Point(138, 37)
        Me.txt_codigo_producto.Name = "txt_codigo_producto"
        Me.txt_codigo_producto.ReadOnly = True
        Me.txt_codigo_producto.Size = New System.Drawing.Size(141, 20)
        Me.txt_codigo_producto.TabIndex = 1
        '
        'txt_factor_conversion
        '
        Me.txt_factor_conversion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_factor_conversion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_factor_conversion.Location = New System.Drawing.Point(657, 37)
        Me.txt_factor_conversion.Name = "txt_factor_conversion"
        Me.txt_factor_conversion.ReadOnly = True
        Me.txt_factor_conversion.Size = New System.Drawing.Size(136, 20)
        Me.txt_factor_conversion.TabIndex = 4
        '
        'txt_nombre_producto
        '
        Me.txt_nombre_producto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_nombre_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_producto.Location = New System.Drawing.Point(285, 37)
        Me.txt_nombre_producto.Name = "txt_nombre_producto"
        Me.txt_nombre_producto.ReadOnly = True
        Me.txt_nombre_producto.Size = New System.Drawing.Size(366, 20)
        Me.txt_nombre_producto.TabIndex = 4
        '
        'txt_subtotal_final
        '
        Me.txt_subtotal_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_subtotal_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_subtotal_final.Location = New System.Drawing.Point(686, 629)
        Me.txt_subtotal_final.Name = "txt_subtotal_final"
        Me.txt_subtotal_final.ReadOnly = True
        Me.txt_subtotal_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_subtotal_final.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(618, 631)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Sub-total:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(608, 657)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Descuento:"
        '
        'txt_descuento_final
        '
        Me.txt_descuento_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_descuento_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_final.Location = New System.Drawing.Point(686, 655)
        Me.txt_descuento_final.Name = "txt_descuento_final"
        Me.txt_descuento_final.ReadOnly = True
        Me.txt_descuento_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_descuento_final.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(637, 683)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "I.S.V.:"
        '
        'txt_isv_final
        '
        Me.txt_isv_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_isv_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isv_final.Location = New System.Drawing.Point(686, 681)
        Me.txt_isv_final.Name = "txt_isv_final"
        Me.txt_isv_final.ReadOnly = True
        Me.txt_isv_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_isv_final.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(640, 709)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Total:"
        '
        'txt_total_final
        '
        Me.txt_total_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_final.Location = New System.Drawing.Point(686, 707)
        Me.txt_total_final.Name = "txt_total_final"
        Me.txt_total_final.ReadOnly = True
        Me.txt_total_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_total_final.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 635)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 13)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Producto"
        '
        'txt_mostrador_producto
        '
        Me.txt_mostrador_producto.Location = New System.Drawing.Point(18, 650)
        Me.txt_mostrador_producto.Name = "txt_mostrador_producto"
        Me.txt_mostrador_producto.ReadOnly = True
        Me.txt_mostrador_producto.Size = New System.Drawing.Size(469, 20)
        Me.txt_mostrador_producto.TabIndex = 18
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.btn_cancelar.Location = New System.Drawing.Point(765, 730)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(82, 51)
        Me.btn_cancelar.TabIndex = 16
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
        Me.btn_guardar.Location = New System.Drawing.Point(12, 730)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(82, 51)
        Me.btn_guardar.TabIndex = 16
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'frm_orden_pedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 793)
        Me.Controls.Add(Me.txt_mostrador_producto)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txt_total_final)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_isv_final)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_descuento_final)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_subtotal_final)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.grp_ingreso_producto)
        Me.Controls.Add(Me.grp_partida)
        Me.Controls.Add(Me.grp_ingreso_datos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_orden_pedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de pedido"
        Me.grp_ingreso_datos.ResumeLayout(False)
        Me.grp_ingreso_datos.PerformLayout()
        Me.grp_partida.ResumeLayout(False)
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_ingreso_producto.ResumeLayout(False)
        Me.grp_ingreso_producto.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grp_ingreso_datos As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_fecha_documento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btn_new_prov As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_descuento_general As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_referencia_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_num_registro As System.Windows.Forms.TextBox
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents txt_rfc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grp_partida As System.Windows.Forms.GroupBox
    Friend WithEvents grd_ingreso As System.Windows.Forms.DataGridView
    Friend WithEvents grp_ingreso_producto As System.Windows.Forms.GroupBox
    Friend WithEvents txt_subtotal_final As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento_final As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_isv_final As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_total_final As System.Windows.Forms.TextBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents cmb_uni As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_agregar_producto As System.Windows.Forms.Button
    Friend WithEvents txt_codigo_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento_por As System.Windows.Forms.TextBox
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_quitar As System.Windows.Forms.Button
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents txt_precio_neg As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_factor_conversion As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_isv_por As System.Windows.Forms.TextBox
    Friend WithEvents uni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cve_art As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fconversion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio_negociado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descuento_por As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isv_por As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sub_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Isv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_mostrador_producto As System.Windows.Forms.TextBox
    Friend WithEvents btn_get_folio As System.Windows.Forms.Button
End Class
