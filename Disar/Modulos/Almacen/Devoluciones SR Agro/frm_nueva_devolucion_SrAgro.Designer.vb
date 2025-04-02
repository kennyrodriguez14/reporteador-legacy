<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_nueva_devolucion_SrAgro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_nueva_devolucion_SrAgro))
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.grp_ingreso_datos = New System.Windows.Forms.GroupBox
        Me.btn_devolucion_parcial = New System.Windows.Forms.Button
        Me.txt_tipo = New System.Windows.Forms.TextBox
        Me.btn_devolucion_completa = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmb_fecha_documento = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmb_concepto = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmb_fecha_descuento_tactico = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.btn_facturas = New System.Windows.Forms.Button
        Me.btn_new_client = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox
        Me.txt_numero_factura = New System.Windows.Forms.TextBox
        Me.txt_codigo_cliente = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_vehiculo = New System.Windows.Forms.TextBox
        Me.txt_codigo_entregador = New System.Windows.Forms.TextBox
        Me.txt_entregador = New System.Windows.Forms.TextBox
        Me.txt_nombre_vendedor = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_codigo_vendedor = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_num_registro = New System.Windows.Forms.TextBox
        Me.lbl_codigo = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.grp_ingreso = New System.Windows.Forms.GroupBox
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.txt_cantidad_real = New System.Windows.Forms.TextBox
        Me.txt_cantidad = New System.Windows.Forms.TextBox
        Me.txt_nombre_producto = New System.Windows.Forms.TextBox
        Me.txt_numero_partida = New System.Windows.Forms.TextBox
        Me.txt_codigo_producto = New System.Windows.Forms.TextBox
        Me.e_ltpd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.uni_venta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.num_mov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.con_lote = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fact_conv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grp_productos_factura = New System.Windows.Forms.GroupBox
        Me.grd_productos = New System.Windows.Forms.DataGridView
        Me.txt_autoanio_prod = New System.Windows.Forms.TextBox
        Me.txt_folio_prod = New System.Windows.Forms.TextBox
        Me.txt_autoriza_prod = New System.Windows.Forms.TextBox
        Me.txt_e_ltpd_prod = New System.Windows.Forms.TextBox
        Me.txt_uni_venta_prod = New System.Windows.Forms.TextBox
        Me.txt_poli_apli_prod = New System.Windows.Forms.TextBox
        Me.txt_num_alm_prod = New System.Windows.Forms.TextBox
        Me.txt_desc1_prod = New System.Windows.Forms.TextBox
        Me.txt_impu_prod = New System.Windows.Forms.TextBox
        Me.txt_cost_prod = New System.Windows.Forms.TextBox
        Me.txt_fact_conv = New System.Windows.Forms.TextBox
        Me.txt_con_lote = New System.Windows.Forms.TextBox
        Me.txt_prec_prod = New System.Windows.Forms.TextBox
        Me.txt_autoriza = New System.Windows.Forms.TextBox
        Me.polit_apli = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmb_fecha_entrega = New System.Windows.Forms.DateTimePicker
        Me.txt_condicion = New System.Windows.Forms.TextBox
        Me.txt_autoanio = New System.Windows.Forms.TextBox
        Me.txt_folio = New System.Windows.Forms.TextBox
        Me.cmb_fecha_vencimiento = New System.Windows.Forms.DateTimePicker
        Me.num_alm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id_producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_num_mov = New System.Windows.Forms.TextBox
        Me.num_par = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_con_credito = New System.Windows.Forms.TextBox
        Me.Pxrs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.impu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cost = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.prec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grd_ingreso = New System.Windows.Forms.DataGridView
        Me.txt_rfc = New System.Windows.Forms.TextBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.grp_ingreso_datos.SuspendLayout()
        Me.grp_ingreso.SuspendLayout()
        Me.grp_productos_factura.SuspendLayout()
        CType(Me.grd_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(734, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Cantidad"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(277, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Producto"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(69, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Numero Partida"
        '
        'grp_ingreso_datos
        '
        Me.grp_ingreso_datos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso_datos.Controls.Add(Me.btn_devolucion_parcial)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_tipo)
        Me.grp_ingreso_datos.Controls.Add(Me.btn_devolucion_completa)
        Me.grp_ingreso_datos.Controls.Add(Me.Label6)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_documento)
        Me.grp_ingreso_datos.Controls.Add(Me.Label17)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_concepto)
        Me.grp_ingreso_datos.Controls.Add(Me.Label12)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_descuento_tactico)
        Me.grp_ingreso_datos.Controls.Add(Me.Label4)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_sucursal)
        Me.grp_ingreso_datos.Controls.Add(Me.btn_facturas)
        Me.grp_ingreso_datos.Controls.Add(Me.btn_new_client)
        Me.grp_ingreso_datos.Controls.Add(Me.Label3)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_nombre_cliente)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_numero_factura)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_codigo_cliente)
        Me.grp_ingreso_datos.Controls.Add(Me.Label5)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_vehiculo)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_codigo_entregador)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_entregador)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_nombre_vendedor)
        Me.grp_ingreso_datos.Controls.Add(Me.Label14)
        Me.grp_ingreso_datos.Controls.Add(Me.Label2)
        Me.grp_ingreso_datos.Controls.Add(Me.Label13)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_codigo_vendedor)
        Me.grp_ingreso_datos.Controls.Add(Me.Label1)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_num_registro)
        Me.grp_ingreso_datos.Controls.Add(Me.lbl_codigo)
        Me.grp_ingreso_datos.Location = New System.Drawing.Point(15, 7)
        Me.grp_ingreso_datos.Name = "grp_ingreso_datos"
        Me.grp_ingreso_datos.Size = New System.Drawing.Size(1032, 130)
        Me.grp_ingreso_datos.TabIndex = 29
        Me.grp_ingreso_datos.TabStop = False
        Me.grp_ingreso_datos.Text = "Datos Generales"
        '
        'btn_devolucion_parcial
        '
        Me.btn_devolucion_parcial.Location = New System.Drawing.Point(182, 98)
        Me.btn_devolucion_parcial.Name = "btn_devolucion_parcial"
        Me.btn_devolucion_parcial.Size = New System.Drawing.Size(116, 23)
        Me.btn_devolucion_parcial.TabIndex = 12
        Me.btn_devolucion_parcial.Text = "Devolucion Parcial"
        Me.btn_devolucion_parcial.UseVisualStyleBackColor = True
        '
        'txt_tipo
        '
        Me.txt_tipo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo.Location = New System.Drawing.Point(852, 17)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.ReadOnly = True
        Me.txt_tipo.Size = New System.Drawing.Size(169, 20)
        Me.txt_tipo.TabIndex = 17
        '
        'btn_devolucion_completa
        '
        Me.btn_devolucion_completa.Location = New System.Drawing.Point(34, 98)
        Me.btn_devolucion_completa.Name = "btn_devolucion_completa"
        Me.btn_devolucion_completa.Size = New System.Drawing.Size(116, 23)
        Me.btn_devolucion_completa.TabIndex = 11
        Me.btn_devolucion_completa.Text = "Devolucion Completa"
        Me.btn_devolucion_completa.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(759, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tipo de Pago:"
        '
        'cmb_fecha_documento
        '
        Me.cmb_fecha_documento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_documento.Enabled = False
        Me.cmb_fecha_documento.Location = New System.Drawing.Point(79, 71)
        Me.cmb_fecha_documento.Name = "cmb_fecha_documento"
        Me.cmb_fecha_documento.Size = New System.Drawing.Size(219, 20)
        Me.cmb_fecha_documento.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(302, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(117, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Fecha Elaboracion:"
        '
        'cmb_concepto
        '
        Me.cmb_concepto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_concepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_concepto.FormattingEnabled = True
        Me.cmb_concepto.Location = New System.Drawing.Point(715, 71)
        Me.cmb_concepto.Name = "cmb_concepto"
        Me.cmb_concepto.Size = New System.Drawing.Size(309, 21)
        Me.cmb_concepto.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(644, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Concepto:"
        '
        'cmb_fecha_descuento_tactico
        '
        Me.cmb_fecha_descuento_tactico.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_descuento_tactico.Location = New System.Drawing.Point(419, 71)
        Me.cmb_fecha_descuento_tactico.Name = "cmb_fecha_descuento_tactico"
        Me.cmb_fecha_descuento_tactico.Size = New System.Drawing.Size(211, 20)
        Me.cmb_fecha_descuento_tactico.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Fecha SAE:"
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.Enabled = False
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(419, 44)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(334, 21)
        Me.cmb_sucursal.TabIndex = 4
        '
        'btn_facturas
        '
        Me.btn_facturas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_facturas.Enabled = False
        Me.btn_facturas.Location = New System.Drawing.Point(855, 43)
        Me.btn_facturas.Name = "btn_facturas"
        Me.btn_facturas.Size = New System.Drawing.Size(25, 22)
        Me.btn_facturas.TabIndex = 9
        Me.btn_facturas.Text = "..."
        Me.btn_facturas.UseVisualStyleBackColor = True
        Me.btn_facturas.Visible = False
        '
        'btn_new_client
        '
        Me.btn_new_client.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_new_client.Location = New System.Drawing.Point(224, 18)
        Me.btn_new_client.Name = "btn_new_client"
        Me.btn_new_client.Size = New System.Drawing.Size(25, 22)
        Me.btn_new_client.TabIndex = 2
        Me.btn_new_client.Text = "..."
        Me.btn_new_client.UseVisualStyleBackColor = True
        Me.btn_new_client.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(360, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sucursal:"
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombre_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(333, 18)
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.ReadOnly = True
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(420, 20)
        Me.txt_nombre_cliente.TabIndex = 2
        '
        'txt_numero_factura
        '
        Me.txt_numero_factura.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_numero_factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero_factura.Location = New System.Drawing.Point(852, 43)
        Me.txt_numero_factura.Name = "txt_numero_factura"
        Me.txt_numero_factura.ReadOnly = True
        Me.txt_numero_factura.Size = New System.Drawing.Size(169, 20)
        Me.txt_numero_factura.TabIndex = 5
        '
        'txt_codigo_cliente
        '
        Me.txt_codigo_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_cliente.Location = New System.Drawing.Point(255, 19)
        Me.txt_codigo_cliente.Name = "txt_codigo_cliente"
        Me.txt_codigo_cliente.ReadOnly = True
        Me.txt_codigo_cliente.Size = New System.Drawing.Size(72, 20)
        Me.txt_codigo_cliente.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(777, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nº Factura:"
        '
        'txt_vehiculo
        '
        Me.txt_vehiculo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_vehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_vehiculo.Location = New System.Drawing.Point(788, 101)
        Me.txt_vehiculo.Name = "txt_vehiculo"
        Me.txt_vehiculo.ReadOnly = True
        Me.txt_vehiculo.Size = New System.Drawing.Size(193, 20)
        Me.txt_vehiculo.TabIndex = 10
        '
        'txt_codigo_entregador
        '
        Me.txt_codigo_entregador.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_entregador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_entregador.Location = New System.Drawing.Point(419, 101)
        Me.txt_codigo_entregador.Name = "txt_codigo_entregador"
        Me.txt_codigo_entregador.ReadOnly = True
        Me.txt_codigo_entregador.Size = New System.Drawing.Size(55, 20)
        Me.txt_codigo_entregador.TabIndex = 25
        '
        'txt_entregador
        '
        Me.txt_entregador.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_entregador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_entregador.Location = New System.Drawing.Point(480, 101)
        Me.txt_entregador.Name = "txt_entregador"
        Me.txt_entregador.ReadOnly = True
        Me.txt_entregador.Size = New System.Drawing.Size(193, 20)
        Me.txt_entregador.TabIndex = 9
        '
        'txt_nombre_vendedor
        '
        Me.txt_nombre_vendedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombre_vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_vendedor.Location = New System.Drawing.Point(134, 45)
        Me.txt_nombre_vendedor.Name = "txt_nombre_vendedor"
        Me.txt_nombre_vendedor.ReadOnly = True
        Me.txt_nombre_vendedor.Size = New System.Drawing.Size(193, 20)
        Me.txt_nombre_vendedor.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(722, 103)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Vehiculo:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(176, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Cliente:"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(341, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Entregador:"
        '
        'txt_codigo_vendedor
        '
        Me.txt_codigo_vendedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_vendedor.Location = New System.Drawing.Point(86, 45)
        Me.txt_codigo_vendedor.Name = "txt_codigo_vendedor"
        Me.txt_codigo_vendedor.ReadOnly = True
        Me.txt_codigo_vendedor.Size = New System.Drawing.Size(40, 20)
        Me.txt_codigo_vendedor.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Vendedor:"
        '
        'txt_num_registro
        '
        Me.txt_num_registro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_num_registro.Location = New System.Drawing.Point(86, 20)
        Me.txt_num_registro.Name = "txt_num_registro"
        Me.txt_num_registro.ReadOnly = True
        Me.txt_num_registro.Size = New System.Drawing.Size(64, 20)
        Me.txt_num_registro.TabIndex = 0
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(17, 22)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(63, 13)
        Me.lbl_codigo.TabIndex = 13
        Me.lbl_codigo.Text = "Num Reg:"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(169, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Codigo producto"
        '
        'grp_ingreso
        '
        Me.grp_ingreso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso.Controls.Add(Me.Label9)
        Me.grp_ingreso.Controls.Add(Me.Label8)
        Me.grp_ingreso.Controls.Add(Me.Label10)
        Me.grp_ingreso.Controls.Add(Me.Label7)
        Me.grp_ingreso.Controls.Add(Me.btn_eliminar)
        Me.grp_ingreso.Controls.Add(Me.btn_agregar)
        Me.grp_ingreso.Controls.Add(Me.txt_cantidad_real)
        Me.grp_ingreso.Controls.Add(Me.txt_cantidad)
        Me.grp_ingreso.Controls.Add(Me.txt_nombre_producto)
        Me.grp_ingreso.Controls.Add(Me.txt_numero_partida)
        Me.grp_ingreso.Controls.Add(Me.txt_codigo_producto)
        Me.grp_ingreso.Enabled = False
        Me.grp_ingreso.Location = New System.Drawing.Point(12, 368)
        Me.grp_ingreso.Name = "grp_ingreso"
        Me.grp_ingreso.Size = New System.Drawing.Size(1035, 57)
        Me.grp_ingreso.TabIndex = 30
        Me.grp_ingreso.TabStop = False
        Me.grp_ingreso.Text = "Ingreso"
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_eliminar.Location = New System.Drawing.Point(901, 25)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(75, 22)
        Me.btn_eliminar.TabIndex = 5
        Me.btn_eliminar.Text = "Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_agregar.Location = New System.Drawing.Point(820, 25)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(75, 22)
        Me.btn_agregar.TabIndex = 4
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'txt_cantidad_real
        '
        Me.txt_cantidad_real.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_cantidad_real.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cantidad_real.Location = New System.Drawing.Point(724, 35)
        Me.txt_cantidad_real.Name = "txt_cantidad_real"
        Me.txt_cantidad_real.Size = New System.Drawing.Size(80, 20)
        Me.txt_cantidad_real.TabIndex = 17
        Me.txt_cantidad_real.Visible = False
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_cantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cantidad.Location = New System.Drawing.Point(724, 28)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(80, 20)
        Me.txt_cantidad.TabIndex = 3
        '
        'txt_nombre_producto
        '
        Me.txt_nombre_producto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombre_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_producto.Location = New System.Drawing.Point(275, 28)
        Me.txt_nombre_producto.Name = "txt_nombre_producto"
        Me.txt_nombre_producto.ReadOnly = True
        Me.txt_nombre_producto.Size = New System.Drawing.Size(443, 20)
        Me.txt_nombre_producto.TabIndex = 2
        '
        'txt_numero_partida
        '
        Me.txt_numero_partida.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_numero_partida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero_partida.Location = New System.Drawing.Point(69, 27)
        Me.txt_numero_partida.Name = "txt_numero_partida"
        Me.txt_numero_partida.ReadOnly = True
        Me.txt_numero_partida.Size = New System.Drawing.Size(97, 20)
        Me.txt_numero_partida.TabIndex = 0
        '
        'txt_codigo_producto
        '
        Me.txt_codigo_producto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_producto.Location = New System.Drawing.Point(172, 28)
        Me.txt_codigo_producto.Name = "txt_codigo_producto"
        Me.txt_codigo_producto.ReadOnly = True
        Me.txt_codigo_producto.Size = New System.Drawing.Size(97, 20)
        Me.txt_codigo_producto.TabIndex = 1
        '
        'e_ltpd
        '
        Me.e_ltpd.HeaderText = "e_ltpd"
        Me.e_ltpd.Name = "e_ltpd"
        Me.e_ltpd.ReadOnly = True
        Me.e_ltpd.Visible = False
        '
        'uni_venta
        '
        Me.uni_venta.HeaderText = "uni_venta"
        Me.uni_venta.Name = "uni_venta"
        Me.uni_venta.ReadOnly = True
        Me.uni_venta.Visible = False
        '
        'num_mov
        '
        Me.num_mov.HeaderText = "num_mov"
        Me.num_mov.Name = "num_mov"
        Me.num_mov.ReadOnly = True
        Me.num_mov.Visible = False
        '
        'con_lote
        '
        Me.con_lote.HeaderText = "con_lote"
        Me.con_lote.Name = "con_lote"
        Me.con_lote.ReadOnly = True
        Me.con_lote.Visible = False
        '
        'fact_conv
        '
        Me.fact_conv.HeaderText = "fact_conv"
        Me.fact_conv.Name = "fact_conv"
        Me.fact_conv.ReadOnly = True
        Me.fact_conv.Visible = False
        '
        'grp_productos_factura
        '
        Me.grp_productos_factura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_productos_factura.Controls.Add(Me.grd_productos)
        Me.grp_productos_factura.Enabled = False
        Me.grp_productos_factura.Location = New System.Drawing.Point(12, 137)
        Me.grp_productos_factura.Name = "grp_productos_factura"
        Me.grp_productos_factura.Size = New System.Drawing.Size(1035, 232)
        Me.grp_productos_factura.TabIndex = 28
        Me.grp_productos_factura.TabStop = False
        Me.grp_productos_factura.Text = "Contenido de la Factura"
        '
        'grd_productos
        '
        Me.grd_productos.AllowUserToAddRows = False
        Me.grd_productos.AllowUserToDeleteRows = False
        Me.grd_productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_productos.Location = New System.Drawing.Point(3, 16)
        Me.grd_productos.MultiSelect = False
        Me.grd_productos.Name = "grd_productos"
        Me.grd_productos.ReadOnly = True
        Me.grd_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_productos.Size = New System.Drawing.Size(1029, 213)
        Me.grd_productos.TabIndex = 0
        '
        'txt_autoanio_prod
        '
        Me.txt_autoanio_prod.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_autoanio_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_autoanio_prod.Location = New System.Drawing.Point(909, 382)
        Me.txt_autoanio_prod.Name = "txt_autoanio_prod"
        Me.txt_autoanio_prod.Size = New System.Drawing.Size(80, 20)
        Me.txt_autoanio_prod.TabIndex = 42
        Me.txt_autoanio_prod.Visible = False
        '
        'txt_folio_prod
        '
        Me.txt_folio_prod.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_folio_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_folio_prod.Location = New System.Drawing.Point(823, 382)
        Me.txt_folio_prod.Name = "txt_folio_prod"
        Me.txt_folio_prod.Size = New System.Drawing.Size(80, 20)
        Me.txt_folio_prod.TabIndex = 43
        Me.txt_folio_prod.Visible = False
        '
        'txt_autoriza_prod
        '
        Me.txt_autoriza_prod.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_autoriza_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_autoriza_prod.Location = New System.Drawing.Point(737, 382)
        Me.txt_autoriza_prod.Name = "txt_autoriza_prod"
        Me.txt_autoriza_prod.Size = New System.Drawing.Size(80, 20)
        Me.txt_autoriza_prod.TabIndex = 41
        Me.txt_autoriza_prod.Visible = False
        '
        'txt_e_ltpd_prod
        '
        Me.txt_e_ltpd_prod.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_e_ltpd_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_e_ltpd_prod.Location = New System.Drawing.Point(651, 382)
        Me.txt_e_ltpd_prod.Name = "txt_e_ltpd_prod"
        Me.txt_e_ltpd_prod.Size = New System.Drawing.Size(80, 20)
        Me.txt_e_ltpd_prod.TabIndex = 38
        Me.txt_e_ltpd_prod.Visible = False
        '
        'txt_uni_venta_prod
        '
        Me.txt_uni_venta_prod.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_uni_venta_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_uni_venta_prod.Location = New System.Drawing.Point(565, 382)
        Me.txt_uni_venta_prod.Name = "txt_uni_venta_prod"
        Me.txt_uni_venta_prod.Size = New System.Drawing.Size(80, 20)
        Me.txt_uni_venta_prod.TabIndex = 48
        Me.txt_uni_venta_prod.Visible = False
        '
        'txt_poli_apli_prod
        '
        Me.txt_poli_apli_prod.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_poli_apli_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_poli_apli_prod.Location = New System.Drawing.Point(479, 382)
        Me.txt_poli_apli_prod.Name = "txt_poli_apli_prod"
        Me.txt_poli_apli_prod.Size = New System.Drawing.Size(80, 20)
        Me.txt_poli_apli_prod.TabIndex = 45
        Me.txt_poli_apli_prod.Visible = False
        '
        'txt_num_alm_prod
        '
        Me.txt_num_alm_prod.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_num_alm_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_num_alm_prod.Location = New System.Drawing.Point(393, 382)
        Me.txt_num_alm_prod.Name = "txt_num_alm_prod"
        Me.txt_num_alm_prod.Size = New System.Drawing.Size(80, 20)
        Me.txt_num_alm_prod.TabIndex = 46
        Me.txt_num_alm_prod.Visible = False
        '
        'txt_desc1_prod
        '
        Me.txt_desc1_prod.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_desc1_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_desc1_prod.Location = New System.Drawing.Point(307, 382)
        Me.txt_desc1_prod.Name = "txt_desc1_prod"
        Me.txt_desc1_prod.Size = New System.Drawing.Size(80, 20)
        Me.txt_desc1_prod.TabIndex = 47
        Me.txt_desc1_prod.Visible = False
        '
        'txt_impu_prod
        '
        Me.txt_impu_prod.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_impu_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_impu_prod.Location = New System.Drawing.Point(221, 382)
        Me.txt_impu_prod.Name = "txt_impu_prod"
        Me.txt_impu_prod.Size = New System.Drawing.Size(80, 20)
        Me.txt_impu_prod.TabIndex = 39
        Me.txt_impu_prod.Visible = False
        '
        'txt_cost_prod
        '
        Me.txt_cost_prod.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_cost_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cost_prod.Location = New System.Drawing.Point(135, 382)
        Me.txt_cost_prod.Name = "txt_cost_prod"
        Me.txt_cost_prod.Size = New System.Drawing.Size(80, 20)
        Me.txt_cost_prod.TabIndex = 50
        Me.txt_cost_prod.Visible = False
        '
        'txt_fact_conv
        '
        Me.txt_fact_conv.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_fact_conv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fact_conv.Location = New System.Drawing.Point(135, 408)
        Me.txt_fact_conv.Name = "txt_fact_conv"
        Me.txt_fact_conv.Size = New System.Drawing.Size(80, 20)
        Me.txt_fact_conv.TabIndex = 51
        Me.txt_fact_conv.Visible = False
        '
        'txt_con_lote
        '
        Me.txt_con_lote.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_con_lote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_con_lote.Location = New System.Drawing.Point(49, 408)
        Me.txt_con_lote.Name = "txt_con_lote"
        Me.txt_con_lote.Size = New System.Drawing.Size(80, 20)
        Me.txt_con_lote.TabIndex = 49
        Me.txt_con_lote.Visible = False
        '
        'txt_prec_prod
        '
        Me.txt_prec_prod.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_prec_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_prec_prod.Location = New System.Drawing.Point(49, 382)
        Me.txt_prec_prod.Name = "txt_prec_prod"
        Me.txt_prec_prod.Size = New System.Drawing.Size(80, 20)
        Me.txt_prec_prod.TabIndex = 40
        Me.txt_prec_prod.Visible = False
        '
        'txt_autoriza
        '
        Me.txt_autoriza.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_autoriza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_autoriza.Location = New System.Drawing.Point(973, 94)
        Me.txt_autoriza.Name = "txt_autoriza"
        Me.txt_autoriza.ReadOnly = True
        Me.txt_autoriza.Size = New System.Drawing.Size(71, 20)
        Me.txt_autoriza.TabIndex = 53
        Me.txt_autoriza.Visible = False
        '
        'polit_apli
        '
        Me.polit_apli.HeaderText = "polit_apli"
        Me.polit_apli.Name = "polit_apli"
        Me.polit_apli.ReadOnly = True
        Me.polit_apli.Visible = False
        '
        'cmb_fecha_entrega
        '
        Me.cmb_fecha_entrega.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_entrega.Enabled = False
        Me.cmb_fecha_entrega.Location = New System.Drawing.Point(973, 140)
        Me.cmb_fecha_entrega.Name = "cmb_fecha_entrega"
        Me.cmb_fecha_entrega.Size = New System.Drawing.Size(74, 20)
        Me.cmb_fecha_entrega.TabIndex = 35
        Me.cmb_fecha_entrega.Visible = False
        '
        'txt_condicion
        '
        Me.txt_condicion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_condicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_condicion.Location = New System.Drawing.Point(973, 117)
        Me.txt_condicion.Name = "txt_condicion"
        Me.txt_condicion.ReadOnly = True
        Me.txt_condicion.Size = New System.Drawing.Size(71, 20)
        Me.txt_condicion.TabIndex = 52
        Me.txt_condicion.Visible = False
        '
        'txt_autoanio
        '
        Me.txt_autoanio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_autoanio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_autoanio.Location = New System.Drawing.Point(896, 16)
        Me.txt_autoanio.Name = "txt_autoanio"
        Me.txt_autoanio.ReadOnly = True
        Me.txt_autoanio.Size = New System.Drawing.Size(71, 20)
        Me.txt_autoanio.TabIndex = 54
        Me.txt_autoanio.Visible = False
        '
        'txt_folio
        '
        Me.txt_folio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_folio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_folio.Location = New System.Drawing.Point(973, 68)
        Me.txt_folio.Name = "txt_folio"
        Me.txt_folio.ReadOnly = True
        Me.txt_folio.Size = New System.Drawing.Size(71, 20)
        Me.txt_folio.TabIndex = 55
        Me.txt_folio.Visible = False
        '
        'cmb_fecha_vencimiento
        '
        Me.cmb_fecha_vencimiento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_vencimiento.Enabled = False
        Me.cmb_fecha_vencimiento.Location = New System.Drawing.Point(915, 140)
        Me.cmb_fecha_vencimiento.Name = "cmb_fecha_vencimiento"
        Me.cmb_fecha_vencimiento.Size = New System.Drawing.Size(52, 20)
        Me.cmb_fecha_vencimiento.TabIndex = 36
        Me.cmb_fecha_vencimiento.Visible = False
        '
        'num_alm
        '
        Me.num_alm.HeaderText = "num_alm"
        Me.num_alm.Name = "num_alm"
        Me.num_alm.ReadOnly = True
        Me.num_alm.Visible = False
        '
        'desc
        '
        Me.desc.HeaderText = "desc"
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        Me.desc.Visible = False
        '
        'id_producto
        '
        Me.id_producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.id_producto.HeaderText = "Codigo Producto"
        Me.id_producto.Name = "id_producto"
        Me.id_producto.ReadOnly = True
        Me.id_producto.Width = 102
        '
        'producto
        '
        Me.producto.HeaderText = "Producto"
        Me.producto.Name = "producto"
        Me.producto.ReadOnly = True
        '
        'txt_num_mov
        '
        Me.txt_num_mov.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_num_mov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_num_mov.Location = New System.Drawing.Point(221, 408)
        Me.txt_num_mov.Name = "txt_num_mov"
        Me.txt_num_mov.Size = New System.Drawing.Size(80, 20)
        Me.txt_num_mov.TabIndex = 44
        Me.txt_num_mov.Visible = False
        '
        'num_par
        '
        Me.num_par.HeaderText = "Numero de Partida"
        Me.num_par.Name = "num_par"
        Me.num_par.ReadOnly = True
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        '
        'txt_con_credito
        '
        Me.txt_con_credito.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_con_credito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_con_credito.Location = New System.Drawing.Point(973, 16)
        Me.txt_con_credito.Name = "txt_con_credito"
        Me.txt_con_credito.ReadOnly = True
        Me.txt_con_credito.Size = New System.Drawing.Size(71, 20)
        Me.txt_con_credito.TabIndex = 31
        Me.txt_con_credito.Visible = False
        '
        'Pxrs
        '
        Me.Pxrs.HeaderText = "Pxrs"
        Me.Pxrs.Name = "Pxrs"
        Me.Pxrs.ReadOnly = True
        '
        'impu
        '
        Me.impu.HeaderText = "impu"
        Me.impu.Name = "impu"
        Me.impu.ReadOnly = True
        Me.impu.Visible = False
        '
        'cost
        '
        Me.cost.HeaderText = "cost"
        Me.cost.Name = "cost"
        Me.cost.ReadOnly = True
        Me.cost.Visible = False
        '
        'prec
        '
        Me.prec.HeaderText = "prec"
        Me.prec.Name = "prec"
        Me.prec.ReadOnly = True
        Me.prec.Visible = False
        '
        'grd_ingreso
        '
        Me.grd_ingreso.AllowUserToAddRows = False
        Me.grd_ingreso.AllowUserToDeleteRows = False
        Me.grd_ingreso.AllowUserToResizeColumns = False
        Me.grd_ingreso.AllowUserToResizeRows = False
        Me.grd_ingreso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_ingreso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_ingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ingreso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.num_par, Me.id_producto, Me.producto, Me.cantidad, Me.Pxrs, Me.prec, Me.cost, Me.impu, Me.desc, Me.num_alm, Me.polit_apli, Me.uni_venta, Me.e_ltpd, Me.num_mov, Me.fact_conv, Me.con_lote})
        Me.grd_ingreso.Enabled = False
        Me.grd_ingreso.Location = New System.Drawing.Point(12, 430)
        Me.grd_ingreso.MultiSelect = False
        Me.grd_ingreso.Name = "grd_ingreso"
        Me.grd_ingreso.ReadOnly = True
        Me.grd_ingreso.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grd_ingreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_ingreso.Size = New System.Drawing.Size(1035, 248)
        Me.grd_ingreso.TabIndex = 32
        '
        'txt_rfc
        '
        Me.txt_rfc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_rfc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_rfc.Location = New System.Drawing.Point(973, 42)
        Me.txt_rfc.Name = "txt_rfc"
        Me.txt_rfc.ReadOnly = True
        Me.txt_rfc.Size = New System.Drawing.Size(71, 20)
        Me.txt_rfc.TabIndex = 37
        Me.txt_rfc.Visible = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.Location = New System.Drawing.Point(959, 684)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(85, 37)
        Me.btn_cancelar.TabIndex = 34
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Image = Global.Disar.My.Resources.Resources.Guardar
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.Location = New System.Drawing.Point(868, 684)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(85, 37)
        Me.btn_guardar.TabIndex = 33
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'frm_nueva_devolucion_SrAgro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 729)
        Me.Controls.Add(Me.grp_ingreso_datos)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.grp_ingreso)
        Me.Controls.Add(Me.grp_productos_factura)
        Me.Controls.Add(Me.txt_autoanio_prod)
        Me.Controls.Add(Me.txt_folio_prod)
        Me.Controls.Add(Me.txt_autoriza_prod)
        Me.Controls.Add(Me.txt_e_ltpd_prod)
        Me.Controls.Add(Me.txt_uni_venta_prod)
        Me.Controls.Add(Me.txt_poli_apli_prod)
        Me.Controls.Add(Me.txt_num_alm_prod)
        Me.Controls.Add(Me.txt_desc1_prod)
        Me.Controls.Add(Me.txt_impu_prod)
        Me.Controls.Add(Me.txt_cost_prod)
        Me.Controls.Add(Me.txt_fact_conv)
        Me.Controls.Add(Me.txt_con_lote)
        Me.Controls.Add(Me.txt_prec_prod)
        Me.Controls.Add(Me.txt_autoriza)
        Me.Controls.Add(Me.cmb_fecha_entrega)
        Me.Controls.Add(Me.txt_condicion)
        Me.Controls.Add(Me.txt_autoanio)
        Me.Controls.Add(Me.txt_folio)
        Me.Controls.Add(Me.cmb_fecha_vencimiento)
        Me.Controls.Add(Me.txt_num_mov)
        Me.Controls.Add(Me.txt_con_credito)
        Me.Controls.Add(Me.grd_ingreso)
        Me.Controls.Add(Me.txt_rfc)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_nueva_devolucion_SrAgro"
        Me.Text = "Nueva Devolución SR Agro"
        Me.grp_ingreso_datos.ResumeLayout(False)
        Me.grp_ingreso_datos.PerformLayout()
        Me.grp_ingreso.ResumeLayout(False)
        Me.grp_ingreso.PerformLayout()
        Me.grp_productos_factura.ResumeLayout(False)
        CType(Me.grd_productos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grp_ingreso_datos As System.Windows.Forms.GroupBox
    Friend WithEvents btn_devolucion_parcial As System.Windows.Forms.Button
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents btn_devolucion_completa As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_documento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmb_concepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_descuento_tactico As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btn_facturas As System.Windows.Forms.Button
    Friend WithEvents btn_new_client As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero_factura As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_vehiculo As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_entregador As System.Windows.Forms.TextBox
    Friend WithEvents txt_entregador As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_num_registro As System.Windows.Forms.TextBox
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents grp_ingreso As System.Windows.Forms.GroupBox
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents txt_cantidad_real As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero_partida As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_producto As System.Windows.Forms.TextBox
    Friend WithEvents e_ltpd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uni_venta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num_mov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents con_lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fact_conv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grp_productos_factura As System.Windows.Forms.GroupBox
    Friend WithEvents grd_productos As System.Windows.Forms.DataGridView
    Friend WithEvents txt_autoanio_prod As System.Windows.Forms.TextBox
    Friend WithEvents txt_folio_prod As System.Windows.Forms.TextBox
    Friend WithEvents txt_autoriza_prod As System.Windows.Forms.TextBox
    Friend WithEvents txt_e_ltpd_prod As System.Windows.Forms.TextBox
    Friend WithEvents txt_uni_venta_prod As System.Windows.Forms.TextBox
    Friend WithEvents txt_poli_apli_prod As System.Windows.Forms.TextBox
    Friend WithEvents txt_num_alm_prod As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc1_prod As System.Windows.Forms.TextBox
    Friend WithEvents txt_impu_prod As System.Windows.Forms.TextBox
    Friend WithEvents txt_cost_prod As System.Windows.Forms.TextBox
    Friend WithEvents txt_fact_conv As System.Windows.Forms.TextBox
    Friend WithEvents txt_con_lote As System.Windows.Forms.TextBox
    Friend WithEvents txt_prec_prod As System.Windows.Forms.TextBox
    Friend WithEvents txt_autoriza As System.Windows.Forms.TextBox
    Friend WithEvents polit_apli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmb_fecha_entrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_condicion As System.Windows.Forms.TextBox
    Friend WithEvents txt_autoanio As System.Windows.Forms.TextBox
    Friend WithEvents txt_folio As System.Windows.Forms.TextBox
    Friend WithEvents cmb_fecha_vencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents num_alm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_num_mov As System.Windows.Forms.TextBox
    Friend WithEvents num_par As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_con_credito As System.Windows.Forms.TextBox
    Friend WithEvents Pxrs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents impu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grd_ingreso As System.Windows.Forms.DataGridView
    Friend WithEvents txt_rfc As System.Windows.Forms.TextBox
End Class
