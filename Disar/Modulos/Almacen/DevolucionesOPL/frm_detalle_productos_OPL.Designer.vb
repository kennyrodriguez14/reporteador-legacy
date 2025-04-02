<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_detalle_productos_OPL
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
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.txt_cve_art = New System.Windows.Forms.TextBox()
        Me.txt_num_alma = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.txt_factura_final = New System.Windows.Forms.TextBox()
        Me.grd_detalle_productos = New System.Windows.Forms.DataGridView()
        Me.txt_producto = New System.Windows.Forms.TextBox()
        Me.txt_almacen = New System.Windows.Forms.TextBox()
        Me.cmb_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_factura_inicial = New System.Windows.Forms.TextBox()
        Me.grp_informacion_general = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.grd_detalle_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_informacion_general.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_guardar
        '
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Location = New System.Drawing.Point(16, 148)
        Me.btn_guardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(100, 28)
        Me.btn_guardar.TabIndex = 17
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'txt_cve_art
        '
        Me.txt_cve_art.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_cve_art.Location = New System.Drawing.Point(129, 26)
        Me.txt_cve_art.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_cve_art.Name = "txt_cve_art"
        Me.txt_cve_art.Size = New System.Drawing.Size(196, 22)
        Me.txt_cve_art.TabIndex = 3
        '
        'txt_num_alma
        '
        Me.txt_num_alma.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_num_alma.Location = New System.Drawing.Point(129, 58)
        Me.txt_num_alma.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_num_alma.Name = "txt_num_alma"
        Me.txt_num_alma.Size = New System.Drawing.Size(35, 22)
        Me.txt_num_alma.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(41, 28)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Producto:"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Location = New System.Drawing.Point(124, 148)
        Me.btn_cancelar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(100, 28)
        Me.btn_cancelar.TabIndex = 18
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'txt_factura_final
        '
        Me.txt_factura_final.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_factura_final.Location = New System.Drawing.Point(600, 95)
        Me.txt_factura_final.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_factura_final.Name = "txt_factura_final"
        Me.txt_factura_final.Size = New System.Drawing.Size(269, 22)
        Me.txt_factura_final.TabIndex = 8
        '
        'grd_detalle_productos
        '
        Me.grd_detalle_productos.AllowUserToAddRows = False
        Me.grd_detalle_productos.AllowUserToDeleteRows = False
        Me.grd_detalle_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_detalle_productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_detalle_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_detalle_productos.Location = New System.Drawing.Point(16, 186)
        Me.grd_detalle_productos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grd_detalle_productos.Name = "grd_detalle_productos"
        Me.grd_detalle_productos.RowHeadersWidth = 51
        Me.grd_detalle_productos.Size = New System.Drawing.Size(927, 528)
        Me.grd_detalle_productos.TabIndex = 19
        '
        'txt_producto
        '
        Me.txt_producto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_producto.Location = New System.Drawing.Point(335, 26)
        Me.txt_producto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(535, 22)
        Me.txt_producto.TabIndex = 4
        '
        'txt_almacen
        '
        Me.txt_almacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_almacen.Location = New System.Drawing.Point(173, 58)
        Me.txt_almacen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_almacen.Name = "txt_almacen"
        Me.txt_almacen.Size = New System.Drawing.Size(225, 22)
        Me.txt_almacen.TabIndex = 5
        '
        'cmb_fecha
        '
        Me.cmb_fecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha.Location = New System.Drawing.Point(600, 59)
        Me.cmb_fecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmb_fecha.Name = "cmb_fecha"
        Me.cmb_fecha.Size = New System.Drawing.Size(269, 22)
        Me.cmb_fecha.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(531, 62)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Fecha:"
        '
        'txt_factura_inicial
        '
        Me.txt_factura_inicial.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_factura_inicial.Location = New System.Drawing.Point(129, 95)
        Me.txt_factura_inicial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_factura_inicial.Name = "txt_factura_inicial"
        Me.txt_factura_inicial.Size = New System.Drawing.Size(269, 22)
        Me.txt_factura_inicial.TabIndex = 7
        '
        'grp_informacion_general
        '
        Me.grp_informacion_general.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_informacion_general.Controls.Add(Me.cmb_fecha)
        Me.grp_informacion_general.Controls.Add(Me.txt_factura_final)
        Me.grp_informacion_general.Controls.Add(Me.Label1)
        Me.grp_informacion_general.Controls.Add(Me.txt_almacen)
        Me.grp_informacion_general.Controls.Add(Me.txt_producto)
        Me.grp_informacion_general.Controls.Add(Me.txt_cve_art)
        Me.grp_informacion_general.Controls.Add(Me.txt_num_alma)
        Me.grp_informacion_general.Controls.Add(Me.txt_factura_inicial)
        Me.grp_informacion_general.Controls.Add(Me.Label5)
        Me.grp_informacion_general.Controls.Add(Me.Label2)
        Me.grp_informacion_general.Controls.Add(Me.Label3)
        Me.grp_informacion_general.Controls.Add(Me.Label4)
        Me.grp_informacion_general.Enabled = False
        Me.grp_informacion_general.Location = New System.Drawing.Point(16, 9)
        Me.grp_informacion_general.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grp_informacion_general.Name = "grp_informacion_general"
        Me.grp_informacion_general.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grp_informacion_general.Size = New System.Drawing.Size(927, 132)
        Me.grp_informacion_general.TabIndex = 20
        Me.grp_informacion_general.TabStop = False
        Me.grp_informacion_general.Text = "Informacion General"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Sucursal:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 98)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Rango Inicial:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(477, 98)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Rango Inicial:"
        '
        'frm_detalle_productos_OPL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 721)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.grd_detalle_productos)
        Me.Controls.Add(Me.grp_informacion_general)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frm_detalle_productos_OPL"
        Me.Text = "Detalle de Productos - OPL"
        CType(Me.grd_detalle_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_informacion_general.ResumeLayout(False)
        Me.grp_informacion_general.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_cve_art As System.Windows.Forms.TextBox
    Friend WithEvents txt_num_alma As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents txt_factura_final As System.Windows.Forms.TextBox
    Friend WithEvents grd_detalle_productos As System.Windows.Forms.DataGridView
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_almacen As System.Windows.Forms.TextBox
    Friend WithEvents cmb_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_factura_inicial As System.Windows.Forms.TextBox
    Friend WithEvents grp_informacion_general As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
