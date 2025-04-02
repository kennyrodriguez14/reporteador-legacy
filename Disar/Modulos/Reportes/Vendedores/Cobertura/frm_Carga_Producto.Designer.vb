<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Carga_Producto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Carga_Producto))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TextBusca = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DataProductos = New System.Windows.Forms.DataGridView
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Disar.My.Resources.Resources.img_modulo_monitoreo
        Me.PictureBox1.Location = New System.Drawing.Point(409, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 33)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'TextBusca
        '
        Me.TextBusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBusca.Location = New System.Drawing.Point(107, 13)
        Me.TextBusca.Name = "TextBusca"
        Me.TextBusca.Size = New System.Drawing.Size(306, 20)
        Me.TextBusca.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Buscar Producto:"
        '
        'DataProductos
        '
        Me.DataProductos.AllowUserToAddRows = False
        Me.DataProductos.AllowUserToDeleteRows = False
        Me.DataProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataProductos.Location = New System.Drawing.Point(12, 39)
        Me.DataProductos.Name = "DataProductos"
        Me.DataProductos.ReadOnly = True
        Me.DataProductos.Size = New System.Drawing.Size(721, 252)
        Me.DataProductos.TabIndex = 24
        '
        'frm_Carga_Producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 307)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBusca)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DataProductos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Carga_Producto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Producto"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBusca As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataProductos As System.Windows.Forms.DataGridView
End Class
