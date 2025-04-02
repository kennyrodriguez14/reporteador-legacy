<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_facturas_credito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_facturas_credito))
        Me.grid_factura = New System.Windows.Forms.DataGridView
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio_unitario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio_bruto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.porcetaje_descuento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grd_descuento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.porcentaje_isv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grd_isv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grd_total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_cargar_cliente = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.txt_num_factura = New System.Windows.Forms.TextBox
        Me.lbl_clientes = New System.Windows.Forms.TextBox
        Me.txt_cve_vend = New System.Windows.Forms.TextBox
        Me.lbl_codigo = New System.Windows.Forms.TextBox
        Me.cmb_fecha = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.btn_cargar_productos = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtdescuento = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtisv = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txttotal = New System.Windows.Forms.Label
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtsubtotal = New System.Windows.Forms.Label
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.grid_factura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grid_factura
        '
        Me.grid_factura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid_factura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid_factura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_factura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cantidad, Me.codigo, Me.descripcion, Me.precio_unitario, Me.precio_bruto, Me.porcetaje_descuento, Me.grd_descuento, Me.porcentaje_isv, Me.grd_isv, Me.grd_total, Me.costo})
        Me.grid_factura.Location = New System.Drawing.Point(13, 164)
        Me.grid_factura.Name = "grid_factura"
        Me.grid_factura.Size = New System.Drawing.Size(1064, 301)
        Me.grid_factura.TabIndex = 0
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.Width = 74
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.Width = 65
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Width = 88
        '
        'precio_unitario
        '
        Me.precio_unitario.HeaderText = "Precio Unitario"
        Me.precio_unitario.Name = "precio_unitario"
        Me.precio_unitario.Width = 101
        '
        'precio_bruto
        '
        Me.precio_bruto.HeaderText = "Precio Bruto"
        Me.precio_bruto.Name = "precio_bruto"
        Me.precio_bruto.Width = 90
        '
        'porcetaje_descuento
        '
        Me.porcetaje_descuento.HeaderText = "% Descuento"
        Me.porcetaje_descuento.Name = "porcetaje_descuento"
        Me.porcetaje_descuento.Width = 95
        '
        'grd_descuento
        '
        Me.grd_descuento.HeaderText = "Descuento"
        Me.grd_descuento.Name = "grd_descuento"
        Me.grd_descuento.Width = 84
        '
        'porcentaje_isv
        '
        Me.porcentaje_isv.HeaderText = "% ISV"
        Me.porcentaje_isv.Name = "porcentaje_isv"
        Me.porcentaje_isv.Width = 60
        '
        'grd_isv
        '
        Me.grd_isv.HeaderText = "I.S.V"
        Me.grd_isv.Name = "grd_isv"
        Me.grd_isv.Width = 55
        '
        'grd_total
        '
        Me.grd_total.HeaderText = "TOTAL"
        Me.grd_total.Name = "grd_total"
        Me.grd_total.Width = 67
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cliente:"
        '
        'btn_cargar_cliente
        '
        Me.btn_cargar_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cargar_cliente.Location = New System.Drawing.Point(107, 44)
        Me.btn_cargar_cliente.Name = "btn_cargar_cliente"
        Me.btn_cargar_cliente.Size = New System.Drawing.Size(16, 23)
        Me.btn_cargar_cliente.TabIndex = 3
        Me.btn_cargar_cliente.Text = "+"
        Me.btn_cargar_cliente.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmb_almacen)
        Me.GroupBox1.Controls.Add(Me.txt_num_factura)
        Me.GroupBox1.Controls.Add(Me.lbl_clientes)
        Me.GroupBox1.Controls.Add(Me.txt_cve_vend)
        Me.GroupBox1.Controls.Add(Me.lbl_codigo)
        Me.GroupBox1.Controls.Add(Me.cmb_fecha)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_cargar_cliente)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1065, 117)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'cmb_almacen
        '
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(320, 14)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(264, 21)
        Me.cmb_almacen.TabIndex = 7
        '
        'txt_num_factura
        '
        Me.txt_num_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_num_factura.Location = New System.Drawing.Point(107, 19)
        Me.txt_num_factura.Name = "txt_num_factura"
        Me.txt_num_factura.ReadOnly = True
        Me.txt_num_factura.Size = New System.Drawing.Size(111, 20)
        Me.txt_num_factura.TabIndex = 6
        '
        'lbl_clientes
        '
        Me.lbl_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_clientes.Location = New System.Drawing.Point(224, 45)
        Me.lbl_clientes.Name = "lbl_clientes"
        Me.lbl_clientes.ReadOnly = True
        Me.lbl_clientes.Size = New System.Drawing.Size(360, 20)
        Me.lbl_clientes.TabIndex = 6
        '
        'txt_cve_vend
        '
        Me.txt_cve_vend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cve_vend.Location = New System.Drawing.Point(459, 75)
        Me.txt_cve_vend.Name = "txt_cve_vend"
        Me.txt_cve_vend.ReadOnly = True
        Me.txt_cve_vend.Size = New System.Drawing.Size(88, 20)
        Me.txt_cve_vend.TabIndex = 6
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(130, 45)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.ReadOnly = True
        Me.lbl_codigo.Size = New System.Drawing.Size(88, 20)
        Me.lbl_codigo.TabIndex = 6
        '
        'cmb_fecha
        '
        Me.cmb_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_fecha.Location = New System.Drawing.Point(107, 73)
        Me.cmb_fecha.Name = "cmb_fecha"
        Me.cmb_fecha.Size = New System.Drawing.Size(200, 26)
        Me.cmb_fecha.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(238, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 20)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Almacen:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Nº Factura:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(316, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 20)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Codigo Vendedor:"
        '
        'btn_cargar_productos
        '
        Me.btn_cargar_productos.Location = New System.Drawing.Point(13, 135)
        Me.btn_cargar_productos.Name = "btn_cargar_productos"
        Me.btn_cargar_productos.Size = New System.Drawing.Size(23, 23)
        Me.btn_cargar_productos.TabIndex = 3
        Me.btn_cargar_productos.Text = "+"
        Me.btn_cargar_productos.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(761, 511)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descuento:"
        '
        'txtdescuento
        '
        Me.txtdescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdescuento.AutoSize = True
        Me.txtdescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento.Location = New System.Drawing.Point(858, 511)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.Size = New System.Drawing.Size(19, 20)
        Me.txtdescuento.TabIndex = 6
        Me.txtdescuento.Text = "0"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(819, 538)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Isv:"
        '
        'txtisv
        '
        Me.txtisv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtisv.AutoSize = True
        Me.txtisv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtisv.Location = New System.Drawing.Point(858, 538)
        Me.txtisv.Name = "txtisv"
        Me.txtisv.Size = New System.Drawing.Size(19, 20)
        Me.txtisv.TabIndex = 6
        Me.txtisv.Text = "0"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(804, 565)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 20)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Total:"
        '
        'txttotal
        '
        Me.txttotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttotal.AutoSize = True
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(858, 565)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(19, 20)
        Me.txttotal.TabIndex = 6
        Me.txttotal.Text = "0"
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Location = New System.Drawing.Point(12, 509)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 7
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(770, 485)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Sub-Total:"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtsubtotal.AutoSize = True
        Me.txtsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubtotal.Location = New System.Drawing.Point(858, 485)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.Size = New System.Drawing.Size(19, 20)
        Me.txtsubtotal.TabIndex = 6
        Me.txtsubtotal.Text = "0"
        '
        'costo
        '
        Me.costo.HeaderText = "Costo"
        Me.costo.Name = "costo"
        Me.costo.Width = 59
        '
        'frm_facturas_credito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 602)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtisv)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtsubtotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtdescuento)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grid_factura)
        Me.Controls.Add(Me.btn_cargar_productos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_facturas_credito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturas"
        CType(Me.grid_factura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grid_factura As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_cargar_cliente As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cargar_productos As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdescuento As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtisv As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents cmb_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_clientes As System.Windows.Forms.TextBox
    Friend WithEvents lbl_codigo As System.Windows.Forms.TextBox
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio_unitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio_bruto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents porcetaje_descuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grd_descuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents porcentaje_isv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grd_isv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grd_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtsubtotal As System.Windows.Forms.Label
    Friend WithEvents txt_num_factura As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents txt_cve_vend As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
