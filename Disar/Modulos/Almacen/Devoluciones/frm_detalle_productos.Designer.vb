<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_detalle_productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_detalle_productos))
        Me.txt_factura_final = New System.Windows.Forms.TextBox
        Me.txt_factura_inicial = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_fecha = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.grp_informacion_general = New System.Windows.Forms.GroupBox
        Me.txt_almacen = New System.Windows.Forms.TextBox
        Me.txt_producto = New System.Windows.Forms.TextBox
        Me.txt_cve_art = New System.Windows.Forms.TextBox
        Me.txt_num_alma = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.grd_detalle_productos = New System.Windows.Forms.DataGridView
        Me.grp_informacion_general.SuspendLayout()
        CType(Me.grd_detalle_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_factura_final
        '
        Me.txt_factura_final.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_factura_final.Location = New System.Drawing.Point(450, 77)
        Me.txt_factura_final.Name = "txt_factura_final"
        Me.txt_factura_final.Size = New System.Drawing.Size(203, 20)
        Me.txt_factura_final.TabIndex = 8
        '
        'txt_factura_inicial
        '
        Me.txt_factura_inicial.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_factura_inicial.Location = New System.Drawing.Point(97, 77)
        Me.txt_factura_inicial.Name = "txt_factura_inicial"
        Me.txt_factura_inicial.Size = New System.Drawing.Size(203, 20)
        Me.txt_factura_inicial.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(358, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Rango Inicial:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Rango Inicial:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Sucursal:"
        '
        'cmb_fecha
        '
        Me.cmb_fecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha.Location = New System.Drawing.Point(450, 48)
        Me.cmb_fecha.Name = "cmb_fecha"
        Me.cmb_fecha.Size = New System.Drawing.Size(203, 20)
        Me.cmb_fecha.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(398, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Fecha:"
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
        Me.grp_informacion_general.Location = New System.Drawing.Point(12, 1)
        Me.grp_informacion_general.Name = "grp_informacion_general"
        Me.grp_informacion_general.Size = New System.Drawing.Size(695, 107)
        Me.grp_informacion_general.TabIndex = 16
        Me.grp_informacion_general.TabStop = False
        Me.grp_informacion_general.Text = "Informacion General"
        '
        'txt_almacen
        '
        Me.txt_almacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_almacen.Location = New System.Drawing.Point(130, 47)
        Me.txt_almacen.Name = "txt_almacen"
        Me.txt_almacen.Size = New System.Drawing.Size(170, 20)
        Me.txt_almacen.TabIndex = 5
        '
        'txt_producto
        '
        Me.txt_producto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_producto.Location = New System.Drawing.Point(251, 21)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(402, 20)
        Me.txt_producto.TabIndex = 4
        '
        'txt_cve_art
        '
        Me.txt_cve_art.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_cve_art.Location = New System.Drawing.Point(97, 21)
        Me.txt_cve_art.Name = "txt_cve_art"
        Me.txt_cve_art.Size = New System.Drawing.Size(148, 20)
        Me.txt_cve_art.TabIndex = 3
        '
        'txt_num_alma
        '
        Me.txt_num_alma.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_num_alma.Location = New System.Drawing.Point(97, 47)
        Me.txt_num_alma.Name = "txt_num_alma"
        Me.txt_num_alma.Size = New System.Drawing.Size(27, 20)
        Me.txt_num_alma.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Producto:"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Location = New System.Drawing.Point(93, 114)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 1
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Location = New System.Drawing.Point(12, 114)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 0
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
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
        Me.grd_detalle_productos.Location = New System.Drawing.Point(12, 145)
        Me.grd_detalle_productos.Name = "grd_detalle_productos"
        Me.grd_detalle_productos.Size = New System.Drawing.Size(695, 429)
        Me.grd_detalle_productos.TabIndex = 2
        '
        'frm_detalle_productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 586)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.grd_detalle_productos)
        Me.Controls.Add(Me.grp_informacion_general)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_detalle_productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle productos"
        Me.grp_informacion_general.ResumeLayout(False)
        Me.grp_informacion_general.PerformLayout()
        CType(Me.grd_detalle_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_factura_final As System.Windows.Forms.TextBox
    Friend WithEvents txt_factura_inicial As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grp_informacion_general As System.Windows.Forms.GroupBox
    Friend WithEvents txt_almacen As System.Windows.Forms.TextBox
    Friend WithEvents txt_num_alma As System.Windows.Forms.TextBox
    Friend WithEvents grd_detalle_productos As System.Windows.Forms.DataGridView
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_cve_art As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
End Class
