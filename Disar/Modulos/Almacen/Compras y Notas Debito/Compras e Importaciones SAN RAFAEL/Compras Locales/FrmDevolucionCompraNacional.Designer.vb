<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDevolucionCompraNacional
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDevolucionCompraNacional))
        Me.grp_ingreso_datos = New System.Windows.Forms.GroupBox
        Me.ComboTipo = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_almacen = New System.Windows.Forms.TextBox
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
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Grd_Partidas = New System.Windows.Forms.DataGridView
        Me.txt_total_final = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_isv_final = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_descuento_final = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_subtotal_final = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grp_ingreso_datos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grd_Partidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_ingreso_datos
        '
        Me.grp_ingreso_datos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso_datos.Controls.Add(Me.ComboTipo)
        Me.grp_ingreso_datos.Controls.Add(Me.Label4)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_almacen)
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
        Me.grp_ingreso_datos.Location = New System.Drawing.Point(13, 7)
        Me.grp_ingreso_datos.Name = "grp_ingreso_datos"
        Me.grp_ingreso_datos.Size = New System.Drawing.Size(1003, 132)
        Me.grp_ingreso_datos.TabIndex = 1
        Me.grp_ingreso_datos.TabStop = False
        Me.grp_ingreso_datos.Text = "Datos Generales"
        '
        'ComboTipo
        '
        Me.ComboTipo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ComboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipo.FormattingEnabled = True
        Me.ComboTipo.Items.AddRange(New Object() {"Parcial", "Completa"})
        Me.ComboTipo.Location = New System.Drawing.Point(771, 92)
        Me.ComboTipo.Name = "ComboTipo"
        Me.ComboTipo.Size = New System.Drawing.Size(216, 21)
        Me.ComboTipo.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(770, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Tipo De Devolución"
        '
        'txt_almacen
        '
        Me.txt_almacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_almacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_almacen.Enabled = False
        Me.txt_almacen.Location = New System.Drawing.Point(104, 49)
        Me.txt_almacen.Name = "txt_almacen"
        Me.txt_almacen.Size = New System.Drawing.Size(135, 20)
        Me.txt_almacen.TabIndex = 9
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label29.AutoSize = True
        Me.Label29.Enabled = False
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(5, 102)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(93, 13)
        Me.Label29.TabIndex = 7
        Me.Label29.Text = "Fecha Factura:"
        '
        'cmb_fecha_factura
        '
        Me.cmb_fecha_factura.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_factura.Enabled = False
        Me.cmb_fecha_factura.Location = New System.Drawing.Point(104, 99)
        Me.cmb_fecha_factura.Name = "cmb_fecha_factura"
        Me.cmb_fecha_factura.Size = New System.Drawing.Size(216, 20)
        Me.cmb_fecha_factura.TabIndex = 8
        '
        'cmb_fecha_vencimiento
        '
        Me.cmb_fecha_vencimiento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_vencimiento.Enabled = False
        Me.cmb_fecha_vencimiento.Location = New System.Drawing.Point(541, 99)
        Me.cmb_fecha_vencimiento.Name = "cmb_fecha_vencimiento"
        Me.cmb_fecha_vencimiento.Size = New System.Drawing.Size(221, 20)
        Me.cmb_fecha_vencimiento.TabIndex = 8
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label28.AutoSize = True
        Me.Label28.Enabled = False
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(419, 103)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(119, 13)
        Me.Label28.TabIndex = 7
        Me.Label28.Text = "Fecha Vencimiento:"
        '
        'cmb_lote
        '
        Me.cmb_lote.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_lote.AutoSize = True
        Me.cmb_lote.Enabled = False
        Me.cmb_lote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_lote.Location = New System.Drawing.Point(596, 77)
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
        Me.txt_lote.Location = New System.Drawing.Point(654, 74)
        Me.txt_lote.Name = "txt_lote"
        Me.txt_lote.Size = New System.Drawing.Size(108, 20)
        Me.txt_lote.TabIndex = 0
        '
        'cmb_valores_base
        '
        Me.cmb_valores_base.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_valores_base.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_valores_base.Enabled = False
        Me.cmb_valores_base.FormattingEnabled = True
        Me.cmb_valores_base.Items.AddRange(New Object() {"Sub Total", "Impuesto"})
        Me.cmb_valores_base.Location = New System.Drawing.Point(769, 40)
        Me.cmb_valores_base.Name = "cmb_valores_base"
        Me.cmb_valores_base.Size = New System.Drawing.Size(216, 21)
        Me.cmb_valores_base.TabIndex = 6
        '
        'cmb_fecha_documento
        '
        Me.cmb_fecha_documento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_documento.Enabled = False
        Me.cmb_fecha_documento.Location = New System.Drawing.Point(104, 74)
        Me.cmb_fecha_documento.Name = "cmb_fecha_documento"
        Me.cmb_fecha_documento.Size = New System.Drawing.Size(215, 20)
        Me.cmb_fecha_documento.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label23.AutoSize = True
        Me.Label23.Enabled = False
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(768, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(102, 13)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Valores en base:"
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label17.AutoSize = True
        Me.Label17.Enabled = False
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(51, 76)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Almacen:"
        '
        'txt_rfc
        '
        Me.txt_rfc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_rfc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_rfc.Enabled = False
        Me.txt_rfc.Location = New System.Drawing.Point(654, 48)
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
        Me.txt_nombre_proveedor.Enabled = False
        Me.txt_nombre_proveedor.Location = New System.Drawing.Point(317, 20)
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
        Me.txt_codigo_proveedor.Enabled = False
        Me.txt_codigo_proveedor.Location = New System.Drawing.Point(104, 22)
        Me.txt_codigo_proveedor.Name = "txt_codigo_proveedor"
        Me.txt_codigo_proveedor.ReadOnly = True
        Me.txt_codigo_proveedor.Size = New System.Drawing.Size(135, 20)
        Me.txt_codigo_proveedor.TabIndex = 0
        Me.txt_codigo_proveedor.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(613, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "RFC:"
        '
        'txt_descuento_general
        '
        Me.txt_descuento_general.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_descuento_general.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_general.Enabled = False
        Me.txt_descuento_general.Location = New System.Drawing.Point(455, 74)
        Me.txt_descuento_general.Name = "txt_descuento_general"
        Me.txt_descuento_general.Size = New System.Drawing.Size(108, 20)
        Me.txt_descuento_general.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Enabled = False
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(261, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Proveedor:"
        '
        'txt_referencia_proveedor
        '
        Me.txt_referencia_proveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_referencia_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_referencia_proveedor.Enabled = False
        Me.txt_referencia_proveedor.Location = New System.Drawing.Point(455, 48)
        Me.txt_referencia_proveedor.Name = "txt_referencia_proveedor"
        Me.txt_referencia_proveedor.Size = New System.Drawing.Size(152, 20)
        Me.txt_referencia_proveedor.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(377, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Descuento:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(352, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ref. Proveedor:"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(934, 577)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(82, 53)
        Me.btn_cancelar.TabIndex = 22
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
        Me.btn_guardar.Location = New System.Drawing.Point(13, 577)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(135, 53)
        Me.btn_guardar.TabIndex = 21
        Me.btn_guardar.Text = "Guardar Devolución"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Grd_Partidas)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 140)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1003, 366)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'Grd_Partidas
        '
        Me.Grd_Partidas.AllowUserToAddRows = False
        Me.Grd_Partidas.AllowUserToDeleteRows = False
        Me.Grd_Partidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Grd_Partidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Partidas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Partidas.Location = New System.Drawing.Point(3, 16)
        Me.Grd_Partidas.Name = "Grd_Partidas"
        Me.Grd_Partidas.RowHeadersVisible = False
        Me.Grd_Partidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grd_Partidas.Size = New System.Drawing.Size(997, 347)
        Me.Grd_Partidas.TabIndex = 15
        '
        'txt_total_final
        '
        Me.txt_total_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_total_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_final.Location = New System.Drawing.Point(103, 96)
        Me.txt_total_final.Name = "txt_total_final"
        Me.txt_total_final.ReadOnly = True
        Me.txt_total_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_total_final.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(34, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Total:"
        '
        'txt_isv_final
        '
        Me.txt_isv_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_isv_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isv_final.Location = New System.Drawing.Point(103, 70)
        Me.txt_isv_final.Name = "txt_isv_final"
        Me.txt_isv_final.ReadOnly = True
        Me.txt_isv_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_isv_final.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(34, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "I.S.V.:"
        '
        'txt_descuento_final
        '
        Me.txt_descuento_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_descuento_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_final.Location = New System.Drawing.Point(103, 44)
        Me.txt_descuento_final.Name = "txt_descuento_final"
        Me.txt_descuento_final.ReadOnly = True
        Me.txt_descuento_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_descuento_final.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(34, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Descuento:"
        '
        'txt_subtotal_final
        '
        Me.txt_subtotal_final.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_subtotal_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_subtotal_final.Location = New System.Drawing.Point(103, 18)
        Me.txt_subtotal_final.Name = "txt_subtotal_final"
        Me.txt_subtotal_final.ReadOnly = True
        Me.txt_subtotal_final.Size = New System.Drawing.Size(161, 20)
        Me.txt_subtotal_final.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(34, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Sub-total:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.GroupBox2.Controls.Add(Me.txt_descuento_final)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txt_subtotal_final)
        Me.GroupBox2.Controls.Add(Me.txt_total_final)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txt_isv_final)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(408, 508)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(299, 125)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        '
        'FrmDevolucionCompraNacional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 640)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.grp_ingreso_datos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmDevolucionCompraNacional"
        Me.Text = "Devolucion Compra Nacional"
        Me.grp_ingreso_datos.ResumeLayout(False)
        Me.grp_ingreso_datos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Grd_Partidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp_ingreso_datos As System.Windows.Forms.GroupBox
    Friend WithEvents txt_almacen As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_factura As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_fecha_vencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmb_lote As System.Windows.Forms.CheckBox
    Friend WithEvents txt_lote As System.Windows.Forms.TextBox
    Friend WithEvents cmb_valores_base As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_fecha_documento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
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
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grd_Partidas As System.Windows.Forms.DataGridView
    Friend WithEvents ComboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_total_final As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_isv_final As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento_final As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_subtotal_final As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
