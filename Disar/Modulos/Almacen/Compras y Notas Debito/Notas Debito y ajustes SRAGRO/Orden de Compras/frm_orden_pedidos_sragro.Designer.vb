<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_orden_pedidos_sragro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_orden_pedidos_sragro))
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
        Me.btn_quitar = New System.Windows.Forms.Button
        Me.btn_agregar = New System.Windows.Forms.Button
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
        Me.Peso = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.grp_ingreso_datos = New System.Windows.Forms.GroupBox
        Me.cmb_vehiculo = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
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
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txt_capacidad = New System.Windows.Forms.TextBox
        Me.txt_peso_cargado = New System.Windows.Forms.TextBox
        Me.btn_excel = New System.Windows.Forms.Button
        Me.grp_partida.SuspendLayout()
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_ingreso_datos.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_mostrador_producto
        '
        Me.txt_mostrador_producto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_mostrador_producto.Location = New System.Drawing.Point(74, 468)
        Me.txt_mostrador_producto.Name = "txt_mostrador_producto"
        Me.txt_mostrador_producto.ReadOnly = True
        Me.txt_mostrador_producto.Size = New System.Drawing.Size(622, 20)
        Me.txt_mostrador_producto.TabIndex = 33
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(18, 471)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Producto:"
        '
        'txt_total_final
        '
        Me.txt_total_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_final.Location = New System.Drawing.Point(827, 543)
        Me.txt_total_final.Name = "txt_total_final"
        Me.txt_total_final.ReadOnly = True
        Me.txt_total_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_total_final.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(781, 545)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Total:"
        '
        'txt_isv_final
        '
        Me.txt_isv_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_isv_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isv_final.Location = New System.Drawing.Point(827, 517)
        Me.txt_isv_final.Name = "txt_isv_final"
        Me.txt_isv_final.ReadOnly = True
        Me.txt_isv_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_isv_final.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(778, 519)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "I.S.V.:"
        '
        'txt_descuento_final
        '
        Me.txt_descuento_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_descuento_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_final.Location = New System.Drawing.Point(827, 491)
        Me.txt_descuento_final.Name = "txt_descuento_final"
        Me.txt_descuento_final.ReadOnly = True
        Me.txt_descuento_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_descuento_final.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(749, 493)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Descuento:"
        '
        'txt_subtotal_final
        '
        Me.txt_subtotal_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_subtotal_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_subtotal_final.Location = New System.Drawing.Point(827, 465)
        Me.txt_subtotal_final.Name = "txt_subtotal_final"
        Me.txt_subtotal_final.ReadOnly = True
        Me.txt_subtotal_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_subtotal_final.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(759, 467)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Sub-total:"
        '
        'btn_quitar
        '
        Me.btn_quitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar.Location = New System.Drawing.Point(121, 118)
        Me.btn_quitar.Name = "btn_quitar"
        Me.btn_quitar.Size = New System.Drawing.Size(102, 23)
        Me.btn_quitar.TabIndex = 0
        Me.btn_quitar.Text = "Quitar"
        Me.btn_quitar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.Location = New System.Drawing.Point(13, 118)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(102, 23)
        Me.btn_agregar.TabIndex = 0
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'grp_partida
        '
        Me.grp_partida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_partida.Controls.Add(Me.grd_ingreso)
        Me.grp_partida.Location = New System.Drawing.Point(12, 147)
        Me.grp_partida.Name = "grp_partida"
        Me.grp_partida.Size = New System.Drawing.Size(976, 312)
        Me.grp_partida.TabIndex = 20
        Me.grp_partida.TabStop = False
        '
        'grd_ingreso
        '
        Me.grd_ingreso.AllowUserToAddRows = False
        Me.grd_ingreso.AllowUserToDeleteRows = False
        Me.grd_ingreso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_ingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ingreso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.uni, Me.cve_art, Me.producto, Me.fconversion, Me.cantidad, Me.precio_negociado, Me.descuento_por, Me.isv_por, Me.Sub_total, Me.descuento, Me.Isv, Me.total, Me.Peso})
        Me.grd_ingreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_ingreso.Location = New System.Drawing.Point(3, 16)
        Me.grd_ingreso.Name = "grd_ingreso"
        Me.grd_ingreso.ReadOnly = True
        Me.grd_ingreso.RowHeadersVisible = False
        Me.grd_ingreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_ingreso.Size = New System.Drawing.Size(970, 293)
        Me.grd_ingreso.TabIndex = 0
        '
        'uni
        '
        Me.uni.FillWeight = 21.69472!
        Me.uni.HeaderText = "Uni"
        Me.uni.Name = "uni"
        Me.uni.ReadOnly = True
        '
        'cve_art
        '
        Me.cve_art.FillWeight = 30.0!
        Me.cve_art.HeaderText = "Codigo"
        Me.cve_art.Name = "cve_art"
        Me.cve_art.ReadOnly = True
        Me.cve_art.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'producto
        '
        Me.producto.FillWeight = 246.2263!
        Me.producto.HeaderText = "Producto"
        Me.producto.Name = "producto"
        Me.producto.ReadOnly = True
        '
        'fconversion
        '
        Me.fconversion.FillWeight = 35.48102!
        Me.fconversion.HeaderText = "Factor Conversion"
        Me.fconversion.Name = "fconversion"
        Me.fconversion.ReadOnly = True
        '
        'cantidad
        '
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.cantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.cantidad.FillWeight = 35.48102!
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        '
        'precio_negociado
        '
        DataGridViewCellStyle2.Format = "N2"
        Me.precio_negociado.DefaultCellStyle = DataGridViewCellStyle2
        Me.precio_negociado.FillWeight = 35.48102!
        Me.precio_negociado.HeaderText = "Precio Negociado"
        Me.precio_negociado.Name = "precio_negociado"
        Me.precio_negociado.ReadOnly = True
        '
        'descuento_por
        '
        DataGridViewCellStyle3.Format = "N2"
        Me.descuento_por.DefaultCellStyle = DataGridViewCellStyle3
        Me.descuento_por.FillWeight = 35.48102!
        Me.descuento_por.HeaderText = "% Descuento"
        Me.descuento_por.Name = "descuento_por"
        Me.descuento_por.ReadOnly = True
        '
        'isv_por
        '
        DataGridViewCellStyle4.Format = "N2"
        Me.isv_por.DefaultCellStyle = DataGridViewCellStyle4
        Me.isv_por.FillWeight = 35.48102!
        Me.isv_por.HeaderText = "% Isv"
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
        Me.total.FillWeight = 35.48102!
        Me.total.HeaderText = "Total"
        Me.total.Name = "total"
        Me.total.ReadOnly = True
        '
        'Peso
        '
        Me.Peso.HeaderText = "Peso"
        Me.Peso.Name = "Peso"
        Me.Peso.ReadOnly = True
        Me.Peso.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(978, 118)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView1.TabIndex = 1
        Me.DataGridView1.Visible = False
        '
        'grp_ingreso_datos
        '
        Me.grp_ingreso_datos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_vehiculo)
        Me.grp_ingreso_datos.Controls.Add(Me.Label24)
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
        Me.grp_ingreso_datos.Size = New System.Drawing.Size(976, 100)
        Me.grp_ingreso_datos.TabIndex = 19
        Me.grp_ingreso_datos.TabStop = False
        Me.grp_ingreso_datos.Text = "Datos Generales"
        '
        'cmb_vehiculo
        '
        Me.cmb_vehiculo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_vehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_vehiculo.FormattingEnabled = True
        Me.cmb_vehiculo.Items.AddRange(New Object() {"Camion 250", "Camion 350", "Camion 450", "Rastra"})
        Me.cmb_vehiculo.Location = New System.Drawing.Point(89, 71)
        Me.cmb_vehiculo.Name = "cmb_vehiculo"
        Me.cmb_vehiculo.Size = New System.Drawing.Size(216, 21)
        Me.cmb_vehiculo.TabIndex = 15
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(24, 74)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 13)
        Me.Label24.TabIndex = 14
        Me.Label24.Text = "Vehiculo:"
        '
        'cmb_fecha_documento
        '
        Me.cmb_fecha_documento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_documento.Location = New System.Drawing.Point(435, 46)
        Me.cmb_fecha_documento.Name = "cmb_fecha_documento"
        Me.cmb_fecha_documento.Size = New System.Drawing.Size(215, 20)
        Me.cmb_fecha_documento.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(390, 47)
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
        Me.cmb_sucursal.Location = New System.Drawing.Point(816, 45)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(142, 21)
        Me.cmb_sucursal.TabIndex = 7
        '
        'btn_get_folio
        '
        Me.btn_get_folio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_get_folio.Location = New System.Drawing.Point(122, 19)
        Me.btn_get_folio.Name = "btn_get_folio"
        Me.btn_get_folio.Size = New System.Drawing.Size(25, 22)
        Me.btn_get_folio.TabIndex = 2
        Me.btn_get_folio.Text = "..."
        Me.btn_get_folio.UseVisualStyleBackColor = True
        '
        'btn_new_prov
        '
        Me.btn_new_prov.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_new_prov.Location = New System.Drawing.Point(312, 19)
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
        Me.Label3.Location = New System.Drawing.Point(759, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Almacen:"
        '
        'txt_rfc
        '
        Me.txt_rfc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_rfc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_rfc.Location = New System.Drawing.Point(62, 45)
        Me.txt_rfc.Name = "txt_rfc"
        Me.txt_rfc.ReadOnly = True
        Me.txt_rfc.Size = New System.Drawing.Size(113, 20)
        Me.txt_rfc.TabIndex = 4
        '
        'txt_nombre_proveedor
        '
        Me.txt_nombre_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombre_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_proveedor.Location = New System.Drawing.Point(514, 19)
        Me.txt_nombre_proveedor.Name = "txt_nombre_proveedor"
        Me.txt_nombre_proveedor.ReadOnly = True
        Me.txt_nombre_proveedor.Size = New System.Drawing.Size(444, 20)
        Me.txt_nombre_proveedor.TabIndex = 4
        '
        'txt_codigo_proveedor
        '
        Me.txt_codigo_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_proveedor.Location = New System.Drawing.Point(343, 19)
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
        Me.Label8.Location = New System.Drawing.Point(28, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "RFC:"
        '
        'txt_descuento_general
        '
        Me.txt_descuento_general.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_descuento_general.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_general.Location = New System.Drawing.Point(723, 45)
        Me.txt_descuento_general.Name = "txt_descuento_general"
        Me.txt_descuento_general.Size = New System.Drawing.Size(32, 20)
        Me.txt_descuento_general.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(458, 23)
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
        Me.Label2.Location = New System.Drawing.Point(242, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Proveedor:"
        '
        'txt_referencia_proveedor
        '
        Me.txt_referencia_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_referencia_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_referencia_proveedor.Location = New System.Drawing.Point(278, 45)
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
        Me.Label9.Location = New System.Drawing.Point(654, 48)
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
        Me.Label1.Location = New System.Drawing.Point(181, 49)
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
        Me.txt_num_registro.Location = New System.Drawing.Point(153, 19)
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
        Me.lbl_codigo.Location = New System.Drawing.Point(18, 21)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(105, 13)
        Me.lbl_codigo.TabIndex = 0
        Me.lbl_codigo.Text = "Orden de pedido:"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.btn_cancelar.Location = New System.Drawing.Point(906, 570)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(82, 51)
        Me.btn_cancelar.TabIndex = 30
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
        Me.btn_guardar.Location = New System.Drawing.Point(12, 570)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(82, 51)
        Me.btn_guardar.TabIndex = 31
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ProgressBar1.ForeColor = System.Drawing.Color.DarkRed
        Me.ProgressBar1.Location = New System.Drawing.Point(431, 580)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(233, 21)
        Me.ProgressBar1.TabIndex = 34
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(337, 584)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 13)
        Me.Label20.TabIndex = 35
        Me.Label20.Text = "Estado de carga:"
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(364, 608)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 13)
        Me.Label22.TabIndex = 36
        Me.Label22.Text = "Capacidad:"
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(532, 607)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(38, 13)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "Carga:"
        '
        'txt_capacidad
        '
        Me.txt_capacidad.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt_capacidad.Location = New System.Drawing.Point(431, 604)
        Me.txt_capacidad.Name = "txt_capacidad"
        Me.txt_capacidad.ReadOnly = True
        Me.txt_capacidad.Size = New System.Drawing.Size(88, 20)
        Me.txt_capacidad.TabIndex = 38
        '
        'txt_peso_cargado
        '
        Me.txt_peso_cargado.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt_peso_cargado.Location = New System.Drawing.Point(576, 605)
        Me.txt_peso_cargado.Name = "txt_peso_cargado"
        Me.txt_peso_cargado.ReadOnly = True
        Me.txt_peso_cargado.Size = New System.Drawing.Size(88, 20)
        Me.txt_peso_cargado.TabIndex = 38
        '
        'btn_excel
        '
        Me.btn_excel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excel.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.btn_excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_excel.Location = New System.Drawing.Point(100, 569)
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(82, 51)
        Me.btn_excel.TabIndex = 31
        Me.btn_excel.Text = "Excel"
        Me.btn_excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_excel.UseVisualStyleBackColor = True
        '
        'frm_orden_pedidos_sragro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 633)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn_quitar)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.txt_peso_cargado)
        Me.Controls.Add(Me.txt_capacidad)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.txt_mostrador_producto)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_excel)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txt_total_final)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_isv_final)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_descuento_final)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_subtotal_final)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.grp_partida)
        Me.Controls.Add(Me.grp_ingreso_datos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frm_orden_pedidos_sragro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de Pedidos SR Agro"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_partida.ResumeLayout(False)
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_ingreso_datos.ResumeLayout(False)
        Me.grp_ingreso_datos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents btn_quitar As System.Windows.Forms.Button
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents grp_partida As System.Windows.Forms.GroupBox
    Friend WithEvents grp_ingreso_datos As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_fecha_documento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btn_get_folio As System.Windows.Forms.Button
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
    Friend WithEvents txt_num_registro As System.Windows.Forms.TextBox
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_capacidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_peso_cargado As System.Windows.Forms.TextBox
    Friend WithEvents cmb_vehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
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
    Friend WithEvents Peso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_excel As System.Windows.Forms.Button
    Public WithEvents grd_ingreso As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
