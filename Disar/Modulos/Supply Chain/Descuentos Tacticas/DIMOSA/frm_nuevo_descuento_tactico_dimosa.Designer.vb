<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_nuevo_descuento_tactico_dimosa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_nuevo_descuento_tactico_dimosa))
        Me.btn_carga_producto = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmb_concepto_prov = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmb_concepto = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.grp_ingreso_datos = New System.Windows.Forms.GroupBox
        Me.cmb_fecha_documento = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmb_fecha_descuento_tactico = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.btn_facturas = New System.Windows.Forms.Button
        Me.btn_new_client = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_con_credito = New System.Windows.Forms.TextBox
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox
        Me.txt_fecha_entrega = New System.Windows.Forms.TextBox
        Me.txt_rfc = New System.Windows.Forms.TextBox
        Me.txt_tipo = New System.Windows.Forms.TextBox
        Me.txt_numero_factura = New System.Windows.Forms.TextBox
        Me.txt_codigo_cliente = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_nombre_vendedor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_codigo_vendedor = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_num_registro = New System.Windows.Forms.TextBox
        Me.lbl_codigo = New System.Windows.Forms.Label
        Me.nombre_concepto_proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.codigo_proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grp_ingreso = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.txt_subtotal_noisv = New System.Windows.Forms.TextBox
        Me.txt_isv = New System.Windows.Forms.TextBox
        Me.txt_importe_sisv = New System.Windows.Forms.TextBox
        Me.txt_cantidad = New System.Windows.Forms.TextBox
        Me.txt_codigo_proveedor = New System.Windows.Forms.TextBox
        Me.txt_proveedor = New System.Windows.Forms.TextBox
        Me.txt_nombre_producto = New System.Windows.Forms.TextBox
        Me.txt_codigo_producto = New System.Windows.Forms.TextBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.grp_productos_factura = New System.Windows.Forms.GroupBox
        Me.grd_productos = New System.Windows.Forms.DataGridView
        Me.subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.isv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.concepto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.idconcepto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id_proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id_producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grd_ingreso = New System.Windows.Forms.DataGridView
        Me.grp_ingreso_datos.SuspendLayout()
        Me.grp_ingreso.SuspendLayout()
        Me.grp_productos_factura.SuspendLayout()
        CType(Me.grd_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_carga_producto
        '
        Me.btn_carga_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_carga_producto.Location = New System.Drawing.Point(6, 36)
        Me.btn_carga_producto.Name = "btn_carga_producto"
        Me.btn_carga_producto.Size = New System.Drawing.Size(114, 66)
        Me.btn_carga_producto.TabIndex = 25
        Me.btn_carga_producto.Text = "Cargar Producto Individual" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_carga_producto.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(704, 46)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "SubTotal"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(774, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Monto"
        '
        'cmb_concepto_prov
        '
        Me.cmb_concepto_prov.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_concepto_prov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_concepto_prov.FormattingEnabled = True
        Me.cmb_concepto_prov.Location = New System.Drawing.Point(673, 19)
        Me.cmb_concepto_prov.Name = "cmb_concepto_prov"
        Me.cmb_concepto_prov.Size = New System.Drawing.Size(253, 21)
        Me.cmb_concepto_prov.TabIndex = 14
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(541, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(126, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Concepto proveedor:"
        '
        'cmb_concepto
        '
        Me.cmb_concepto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_concepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_concepto.FormattingEnabled = True
        Me.cmb_concepto.Location = New System.Drawing.Point(217, 19)
        Me.cmb_concepto.Name = "cmb_concepto"
        Me.cmb_concepto.Size = New System.Drawing.Size(253, 21)
        Me.cmb_concepto.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(146, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Concepto:"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(647, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "I.S.V"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(584, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Cantidad"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(263, 89)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Proveedor"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(146, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Codigo Proveedor"
        '
        'grp_ingreso_datos
        '
        Me.grp_ingreso_datos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_documento)
        Me.grp_ingreso_datos.Controls.Add(Me.Label17)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_descuento_tactico)
        Me.grp_ingreso_datos.Controls.Add(Me.Label4)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_sucursal)
        Me.grp_ingreso_datos.Controls.Add(Me.btn_facturas)
        Me.grp_ingreso_datos.Controls.Add(Me.btn_new_client)
        Me.grp_ingreso_datos.Controls.Add(Me.Label3)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_con_credito)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_nombre_cliente)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_fecha_entrega)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_rfc)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_tipo)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_numero_factura)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_codigo_cliente)
        Me.grp_ingreso_datos.Controls.Add(Me.Label6)
        Me.grp_ingreso_datos.Controls.Add(Me.Label5)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_nombre_vendedor)
        Me.grp_ingreso_datos.Controls.Add(Me.Label2)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_codigo_vendedor)
        Me.grp_ingreso_datos.Controls.Add(Me.Label1)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_num_registro)
        Me.grp_ingreso_datos.Controls.Add(Me.lbl_codigo)
        Me.grp_ingreso_datos.Location = New System.Drawing.Point(11, 12)
        Me.grp_ingreso_datos.Name = "grp_ingreso_datos"
        Me.grp_ingreso_datos.Size = New System.Drawing.Size(1071, 98)
        Me.grp_ingreso_datos.TabIndex = 30
        Me.grp_ingreso_datos.TabStop = False
        Me.grp_ingreso_datos.Text = "Datos Generales"
        '
        'cmb_fecha_documento
        '
        Me.cmb_fecha_documento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_documento.Location = New System.Drawing.Point(513, 69)
        Me.cmb_fecha_documento.Name = "cmb_fecha_documento"
        Me.cmb_fecha_documento.Size = New System.Drawing.Size(215, 20)
        Me.cmb_fecha_documento.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(396, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Fecha Documento:"
        '
        'cmb_fecha_descuento_tactico
        '
        Me.cmb_fecha_descuento_tactico.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_descuento_tactico.Location = New System.Drawing.Point(175, 69)
        Me.cmb_fecha_descuento_tactico.Name = "cmb_fecha_descuento_tactico"
        Me.cmb_fecha_descuento_tactico.Size = New System.Drawing.Size(215, 20)
        Me.cmb_fecha_descuento_tactico.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Fecha Descuento Tactico:"
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.Enabled = False
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(80, 41)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(314, 21)
        Me.cmb_sucursal.TabIndex = 7
        '
        'btn_facturas
        '
        Me.btn_facturas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_facturas.Location = New System.Drawing.Point(475, 40)
        Me.btn_facturas.Name = "btn_facturas"
        Me.btn_facturas.Size = New System.Drawing.Size(25, 22)
        Me.btn_facturas.TabIndex = 9
        Me.btn_facturas.Text = "..."
        Me.btn_facturas.UseVisualStyleBackColor = True
        '
        'btn_new_client
        '
        Me.btn_new_client.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_new_client.Location = New System.Drawing.Point(196, 14)
        Me.btn_new_client.Name = "btn_new_client"
        Me.btn_new_client.Size = New System.Drawing.Size(25, 22)
        Me.btn_new_client.TabIndex = 2
        Me.btn_new_client.Text = "..."
        Me.btn_new_client.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sucursal:"
        '
        'txt_con_credito
        '
        Me.txt_con_credito.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_con_credito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_con_credito.Location = New System.Drawing.Point(694, 14)
        Me.txt_con_credito.Name = "txt_con_credito"
        Me.txt_con_credito.ReadOnly = True
        Me.txt_con_credito.Size = New System.Drawing.Size(42, 20)
        Me.txt_con_credito.TabIndex = 4
        Me.txt_con_credito.Visible = False
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombre_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(301, 15)
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.ReadOnly = True
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(387, 20)
        Me.txt_nombre_cliente.TabIndex = 4
        '
        'txt_fecha_entrega
        '
        Me.txt_fecha_entrega.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_fecha_entrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha_entrega.Location = New System.Drawing.Point(894, 42)
        Me.txt_fecha_entrega.Name = "txt_fecha_entrega"
        Me.txt_fecha_entrega.ReadOnly = True
        Me.txt_fecha_entrega.Size = New System.Drawing.Size(71, 20)
        Me.txt_fecha_entrega.TabIndex = 10
        Me.txt_fecha_entrega.Visible = False
        '
        'txt_rfc
        '
        Me.txt_rfc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_rfc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_rfc.Location = New System.Drawing.Point(817, 42)
        Me.txt_rfc.Name = "txt_rfc"
        Me.txt_rfc.ReadOnly = True
        Me.txt_rfc.Size = New System.Drawing.Size(71, 20)
        Me.txt_rfc.TabIndex = 12
        Me.txt_rfc.Visible = False
        '
        'txt_tipo
        '
        Me.txt_tipo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo.Location = New System.Drawing.Point(740, 42)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.ReadOnly = True
        Me.txt_tipo.Size = New System.Drawing.Size(71, 20)
        Me.txt_tipo.TabIndex = 11
        '
        'txt_numero_factura
        '
        Me.txt_numero_factura.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_numero_factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero_factura.Location = New System.Drawing.Point(506, 41)
        Me.txt_numero_factura.Name = "txt_numero_factura"
        Me.txt_numero_factura.ReadOnly = True
        Me.txt_numero_factura.Size = New System.Drawing.Size(138, 20)
        Me.txt_numero_factura.TabIndex = 10
        '
        'txt_codigo_cliente
        '
        Me.txt_codigo_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_cliente.Location = New System.Drawing.Point(227, 15)
        Me.txt_codigo_cliente.Name = "txt_codigo_cliente"
        Me.txt_codigo_cliente.ReadOnly = True
        Me.txt_codigo_cliente.Size = New System.Drawing.Size(72, 20)
        Me.txt_codigo_cliente.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(654, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tipo de Pago:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(397, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nº Factura:"
        '
        'txt_nombre_vendedor
        '
        Me.txt_nombre_vendedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombre_vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_vendedor.Location = New System.Drawing.Point(865, 17)
        Me.txt_nombre_vendedor.Name = "txt_nombre_vendedor"
        Me.txt_nombre_vendedor.ReadOnly = True
        Me.txt_nombre_vendedor.Size = New System.Drawing.Size(193, 20)
        Me.txt_nombre_vendedor.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(148, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Cliente:"
        '
        'txt_codigo_vendedor
        '
        Me.txt_codigo_vendedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_vendedor.Location = New System.Drawing.Point(817, 17)
        Me.txt_codigo_vendedor.Name = "txt_codigo_vendedor"
        Me.txt_codigo_vendedor.ReadOnly = True
        Me.txt_codigo_vendedor.Size = New System.Drawing.Size(40, 20)
        Me.txt_codigo_vendedor.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(746, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendedor:"
        '
        'txt_num_registro
        '
        Me.txt_num_registro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_num_registro.Location = New System.Drawing.Point(80, 15)
        Me.txt_num_registro.Name = "txt_num_registro"
        Me.txt_num_registro.ReadOnly = True
        Me.txt_num_registro.Size = New System.Drawing.Size(64, 20)
        Me.txt_num_registro.TabIndex = 1
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(11, 19)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(63, 13)
        Me.lbl_codigo.TabIndex = 0
        Me.lbl_codigo.Text = "Num Reg:"
        '
        'nombre_concepto_proveedor
        '
        Me.nombre_concepto_proveedor.HeaderText = "Nombre Concepto Proveedor"
        Me.nombre_concepto_proveedor.Name = "nombre_concepto_proveedor"
        Me.nombre_concepto_proveedor.ReadOnly = True
        Me.nombre_concepto_proveedor.Width = 155
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(265, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Producto"
        '
        'codigo_proveedor
        '
        Me.codigo_proveedor.HeaderText = "Codigo Concepto Proveedor"
        Me.codigo_proveedor.Name = "codigo_proveedor"
        Me.codigo_proveedor.ReadOnly = True
        Me.codigo_proveedor.Width = 151
        '
        'grp_ingreso
        '
        Me.grp_ingreso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso.Controls.Add(Me.btn_carga_producto)
        Me.grp_ingreso.Controls.Add(Me.Label16)
        Me.grp_ingreso.Controls.Add(Me.Label10)
        Me.grp_ingreso.Controls.Add(Me.cmb_concepto_prov)
        Me.grp_ingreso.Controls.Add(Me.Label18)
        Me.grp_ingreso.Controls.Add(Me.cmb_concepto)
        Me.grp_ingreso.Controls.Add(Me.Label12)
        Me.grp_ingreso.Controls.Add(Me.Label15)
        Me.grp_ingreso.Controls.Add(Me.Label9)
        Me.grp_ingreso.Controls.Add(Me.Label13)
        Me.grp_ingreso.Controls.Add(Me.Label14)
        Me.grp_ingreso.Controls.Add(Me.Label8)
        Me.grp_ingreso.Controls.Add(Me.Label7)
        Me.grp_ingreso.Controls.Add(Me.btn_eliminar)
        Me.grp_ingreso.Controls.Add(Me.btn_agregar)
        Me.grp_ingreso.Controls.Add(Me.txt_subtotal_noisv)
        Me.grp_ingreso.Controls.Add(Me.txt_isv)
        Me.grp_ingreso.Controls.Add(Me.txt_importe_sisv)
        Me.grp_ingreso.Controls.Add(Me.txt_cantidad)
        Me.grp_ingreso.Controls.Add(Me.txt_codigo_proveedor)
        Me.grp_ingreso.Controls.Add(Me.txt_proveedor)
        Me.grp_ingreso.Controls.Add(Me.txt_nombre_producto)
        Me.grp_ingreso.Controls.Add(Me.txt_codigo_producto)
        Me.grp_ingreso.Location = New System.Drawing.Point(14, 276)
        Me.grp_ingreso.Name = "grp_ingreso"
        Me.grp_ingreso.Size = New System.Drawing.Size(1068, 132)
        Me.grp_ingreso.TabIndex = 31
        Me.grp_ingreso.TabStop = False
        Me.grp_ingreso.Text = "Ingreso"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(148, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Codigo producto"
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_eliminar.Location = New System.Drawing.Point(851, 90)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(75, 22)
        Me.btn_eliminar.TabIndex = 24
        Me.btn_eliminar.Text = "Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_agregar.Location = New System.Drawing.Point(851, 62)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(75, 22)
        Me.btn_agregar.TabIndex = 23
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'txt_subtotal_noisv
        '
        Me.txt_subtotal_noisv.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_subtotal_noisv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_subtotal_noisv.Location = New System.Drawing.Point(697, 62)
        Me.txt_subtotal_noisv.Name = "txt_subtotal_noisv"
        Me.txt_subtotal_noisv.ReadOnly = True
        Me.txt_subtotal_noisv.Size = New System.Drawing.Size(71, 20)
        Me.txt_subtotal_noisv.TabIndex = 19
        '
        'txt_isv
        '
        Me.txt_isv.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_isv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isv.Location = New System.Drawing.Point(641, 62)
        Me.txt_isv.Name = "txt_isv"
        Me.txt_isv.ReadOnly = True
        Me.txt_isv.Size = New System.Drawing.Size(46, 20)
        Me.txt_isv.TabIndex = 18
        '
        'txt_importe_sisv
        '
        Me.txt_importe_sisv.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_importe_sisv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_importe_sisv.Location = New System.Drawing.Point(774, 62)
        Me.txt_importe_sisv.Name = "txt_importe_sisv"
        Me.txt_importe_sisv.Size = New System.Drawing.Size(71, 20)
        Me.txt_importe_sisv.TabIndex = 20
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_cantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cantidad.Location = New System.Drawing.Point(592, 62)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(46, 20)
        Me.txt_cantidad.TabIndex = 17
        '
        'txt_codigo_proveedor
        '
        Me.txt_codigo_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_proveedor.Location = New System.Drawing.Point(151, 106)
        Me.txt_codigo_proveedor.Name = "txt_codigo_proveedor"
        Me.txt_codigo_proveedor.ReadOnly = True
        Me.txt_codigo_proveedor.Size = New System.Drawing.Size(97, 20)
        Me.txt_codigo_proveedor.TabIndex = 21
        '
        'txt_proveedor
        '
        Me.txt_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_proveedor.Location = New System.Drawing.Point(262, 105)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.ReadOnly = True
        Me.txt_proveedor.Size = New System.Drawing.Size(319, 20)
        Me.txt_proveedor.TabIndex = 22
        '
        'txt_nombre_producto
        '
        Me.txt_nombre_producto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombre_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_producto.Location = New System.Drawing.Point(264, 62)
        Me.txt_nombre_producto.Name = "txt_nombre_producto"
        Me.txt_nombre_producto.ReadOnly = True
        Me.txt_nombre_producto.Size = New System.Drawing.Size(319, 20)
        Me.txt_nombre_producto.TabIndex = 16
        '
        'txt_codigo_producto
        '
        Me.txt_codigo_producto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_producto.Location = New System.Drawing.Point(151, 62)
        Me.txt_codigo_producto.Name = "txt_codigo_producto"
        Me.txt_codigo_producto.ReadOnly = True
        Me.txt_codigo_producto.Size = New System.Drawing.Size(97, 20)
        Me.txt_codigo_producto.TabIndex = 15
        '
        'txt_total
        '
        Me.txt_total.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(524, 666)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(110, 23)
        Me.txt_total.TabIndex = 34
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(425, 669)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 17)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Valor Total:"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.Location = New System.Drawing.Point(991, 659)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(85, 37)
        Me.btn_cancelar.TabIndex = 36
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Image = Global.Disar.My.Resources.Resources.Guardar
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.Location = New System.Drawing.Point(900, 659)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(85, 37)
        Me.btn_guardar.TabIndex = 35
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'grp_productos_factura
        '
        Me.grp_productos_factura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_productos_factura.Controls.Add(Me.grd_productos)
        Me.grp_productos_factura.Location = New System.Drawing.Point(11, 116)
        Me.grp_productos_factura.Name = "grp_productos_factura"
        Me.grp_productos_factura.Size = New System.Drawing.Size(1071, 157)
        Me.grp_productos_factura.TabIndex = 29
        Me.grp_productos_factura.TabStop = False
        Me.grp_productos_factura.Text = "Contenido de la Factura"
        '
        'grd_productos
        '
        Me.grd_productos.AllowUserToAddRows = False
        Me.grd_productos.AllowUserToDeleteRows = False
        Me.grd_productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_productos.Location = New System.Drawing.Point(3, 16)
        Me.grd_productos.MultiSelect = False
        Me.grd_productos.Name = "grd_productos"
        Me.grd_productos.ReadOnly = True
        Me.grd_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_productos.Size = New System.Drawing.Size(1065, 138)
        Me.grd_productos.TabIndex = 13
        '
        'subtotal
        '
        Me.subtotal.HeaderText = "Subtotal"
        Me.subtotal.Name = "subtotal"
        Me.subtotal.ReadOnly = True
        Me.subtotal.Width = 71
        '
        'isv
        '
        Me.isv.HeaderText = "I.S.V"
        Me.isv.Name = "isv"
        Me.isv.ReadOnly = True
        Me.isv.Width = 55
        '
        'concepto
        '
        Me.concepto.HeaderText = "Concepto"
        Me.concepto.Name = "concepto"
        Me.concepto.ReadOnly = True
        Me.concepto.Width = 78
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        Me.cantidad.Width = 74
        '
        'monto
        '
        Me.monto.HeaderText = "Monto"
        Me.monto.Name = "monto"
        Me.monto.ReadOnly = True
        Me.monto.Width = 62
        '
        'producto
        '
        Me.producto.HeaderText = "Producto"
        Me.producto.Name = "producto"
        Me.producto.ReadOnly = True
        Me.producto.Width = 75
        '
        'idconcepto
        '
        Me.idconcepto.HeaderText = "Codigo Concepto"
        Me.idconcepto.Name = "idconcepto"
        Me.idconcepto.ReadOnly = True
        Me.idconcepto.Width = 105
        '
        'id_proveedor
        '
        Me.id_proveedor.HeaderText = "Codigo Proveedor"
        Me.id_proveedor.Name = "id_proveedor"
        Me.id_proveedor.ReadOnly = True
        Me.id_proveedor.Width = 107
        '
        'id_producto
        '
        Me.id_producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.id_producto.HeaderText = "Codigo Producto"
        Me.id_producto.Name = "id_producto"
        Me.id_producto.ReadOnly = True
        Me.id_producto.Width = 102
        '
        'proveedor
        '
        Me.proveedor.HeaderText = "Proveedor"
        Me.proveedor.Name = "proveedor"
        Me.proveedor.ReadOnly = True
        Me.proveedor.Width = 81
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
        Me.grd_ingreso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_ingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ingreso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_producto, Me.producto, Me.cantidad, Me.monto, Me.id_proveedor, Me.proveedor, Me.idconcepto, Me.concepto, Me.isv, Me.subtotal, Me.codigo_proveedor, Me.nombre_concepto_proveedor})
        Me.grd_ingreso.Location = New System.Drawing.Point(11, 414)
        Me.grd_ingreso.MultiSelect = False
        Me.grd_ingreso.Name = "grd_ingreso"
        Me.grd_ingreso.ReadOnly = True
        Me.grd_ingreso.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grd_ingreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_ingreso.Size = New System.Drawing.Size(1071, 239)
        Me.grd_ingreso.TabIndex = 33
        '
        'frm_nuevo_descuento_tactico_dimosa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1092, 708)
        Me.Controls.Add(Me.grp_ingreso_datos)
        Me.Controls.Add(Me.grp_ingreso)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.grp_productos_factura)
        Me.Controls.Add(Me.grd_ingreso)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_nuevo_descuento_tactico_dimosa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Descuento Tactico DIMOSA"
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
    Friend WithEvents btn_carga_producto As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmb_concepto_prov As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmb_concepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents grp_ingreso_datos As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_fecha_documento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_descuento_tactico As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btn_facturas As System.Windows.Forms.Button
    Friend WithEvents btn_new_client As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_con_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha_entrega As System.Windows.Forms.TextBox
    Friend WithEvents txt_rfc As System.Windows.Forms.TextBox
    Friend WithEvents txt_tipo As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero_factura As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_num_registro As System.Windows.Forms.TextBox
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents nombre_concepto_proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents codigo_proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grp_ingreso As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents txt_subtotal_noisv As System.Windows.Forms.TextBox
    Friend WithEvents txt_isv As System.Windows.Forms.TextBox
    Friend WithEvents txt_importe_sisv As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents grp_productos_factura As System.Windows.Forms.GroupBox
    Friend WithEvents grd_productos As System.Windows.Forms.DataGridView
    Friend WithEvents subtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idconcepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grd_ingreso As System.Windows.Forms.DataGridView
End Class
