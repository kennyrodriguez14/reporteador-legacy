<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductoDetalles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductoDetalles))
        Me.TextTotal = New System.Windows.Forms.TextBox
        Me.Aceptar = New System.Windows.Forms.Button
        Me.NombreCliente = New System.Windows.Forms.Label
        Me.TextCantidad = New System.Windows.Forms.TextBox
        Me.CodigoCliente = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PromedioVenta = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Producto = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.UltimaCompra = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextTotal
        '
        Me.TextTotal.Location = New System.Drawing.Point(431, 265)
        Me.TextTotal.Name = "TextTotal"
        Me.TextTotal.ReadOnly = True
        Me.TextTotal.Size = New System.Drawing.Size(125, 20)
        Me.TextTotal.TabIndex = 7
        '
        'Aceptar
        '
        Me.Aceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aceptar.ForeColor = System.Drawing.Color.DimGray
        Me.Aceptar.Location = New System.Drawing.Point(499, 312)
        Me.Aceptar.Name = "Aceptar"
        Me.Aceptar.Size = New System.Drawing.Size(89, 23)
        Me.Aceptar.TabIndex = 7
        Me.Aceptar.Text = "Aceptar"
        Me.Aceptar.UseVisualStyleBackColor = True
        '
        'NombreCliente
        '
        Me.NombreCliente.Location = New System.Drawing.Point(115, 14)
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.Size = New System.Drawing.Size(415, 24)
        Me.NombreCliente.TabIndex = 0
        Me.NombreCliente.Text = "♦♦♦♦♦♦"
        '
        'TextCantidad
        '
        Me.TextCantidad.Location = New System.Drawing.Point(101, 265)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.ReadOnly = True
        Me.TextCantidad.Size = New System.Drawing.Size(83, 20)
        Me.TextCantidad.TabIndex = 7
        '
        'CodigoCliente
        '
        Me.CodigoCliente.AutoSize = True
        Me.CodigoCliente.Location = New System.Drawing.Point(63, 14)
        Me.CodigoCliente.Name = "CodigoCliente"
        Me.CodigoCliente.Size = New System.Drawing.Size(55, 13)
        Me.CodigoCliente.TabIndex = 0
        Me.CodigoCliente.Text = "♦♦♦♦♦♦"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Snow
        Me.Label3.Location = New System.Drawing.Point(303, 268)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "TOTAL ANTES DE ISV:"
        '
        'PromedioVenta
        '
        Me.PromedioVenta.AutoSize = True
        Me.PromedioVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PromedioVenta.ForeColor = System.Drawing.Color.Snow
        Me.PromedioVenta.Location = New System.Drawing.Point(32, 308)
        Me.PromedioVenta.Name = "PromedioVenta"
        Me.PromedioVenta.Size = New System.Drawing.Size(65, 12)
        Me.PromedioVenta.TabIndex = 6
        Me.PromedioVenta.Text = "Cantidad total:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Snow
        Me.Label1.Location = New System.Drawing.Point(20, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Compras totales por producto"
        '
        'Producto
        '
        Me.Producto.AutoSize = True
        Me.Producto.Location = New System.Drawing.Point(62, 40)
        Me.Producto.Name = "Producto"
        Me.Producto.Size = New System.Drawing.Size(119, 13)
        Me.Producto.TabIndex = 0
        Me.Producto.Text = "♦♦♦♦♦♦♦♦♦♦♦♦♦♦"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Snow
        Me.Label2.Location = New System.Drawing.Point(20, 268)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Cantidad total:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Producto:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextTotal)
        Me.GroupBox1.Controls.Add(Me.TextCantidad)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 298)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(20, 103)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.Size = New System.Drawing.Size(536, 151)
        Me.DataGridView1.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Producto)
        Me.GroupBox2.Controls.Add(Me.NombreCliente)
        Me.GroupBox2.Controls.Add(Me.CodigoCliente)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Snow
        Me.GroupBox2.Location = New System.Drawing.Point(20, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(536, 65)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cliente:"
        '
        'UltimaCompra
        '
        Me.UltimaCompra.AutoSize = True
        Me.UltimaCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltimaCompra.ForeColor = System.Drawing.Color.Snow
        Me.UltimaCompra.Location = New System.Drawing.Point(32, 322)
        Me.UltimaCompra.Name = "UltimaCompra"
        Me.UltimaCompra.Size = New System.Drawing.Size(70, 12)
        Me.UltimaCompra.TabIndex = 5
        Me.UltimaCompra.Text = "Última Compra:"
        '
        'ProductoDetalles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(600, 343)
        Me.Controls.Add(Me.Aceptar)
        Me.Controls.Add(Me.PromedioVenta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.UltimaCompra)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProductoDetalles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProductoDetalles"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextTotal As System.Windows.Forms.TextBox
    Friend WithEvents Aceptar As System.Windows.Forms.Button
    Friend WithEvents NombreCliente As System.Windows.Forms.Label
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents CodigoCliente As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PromedioVenta As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Producto As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UltimaCompra As System.Windows.Forms.Label
End Class
