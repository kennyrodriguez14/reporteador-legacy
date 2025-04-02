<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Det_Creditos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Det_Creditos))
        Me.Detalle = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Tipo = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Liquidacion = New System.Windows.Forms.Label
        Me.Entregador = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnContinuar = New System.Windows.Forms.Button
        CType(Me.Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Detalle
        '
        Me.Detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Detalle.Location = New System.Drawing.Point(32, 138)
        Me.Detalle.Name = "Detalle"
        Me.Detalle.Size = New System.Drawing.Size(685, 265)
        Me.Detalle.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Tipo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Liquidacion)
        Me.GroupBox1.Controls.Add(Me.Entregador)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(685, 100)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle"
        '
        'Tipo
        '
        Me.Tipo.AutoSize = True
        Me.Tipo.Location = New System.Drawing.Point(607, 30)
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Size = New System.Drawing.Size(28, 13)
        Me.Tipo.TabIndex = 1
        Me.Tipo.Text = "Tipo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Liquidación:"
        '
        'Liquidacion
        '
        Me.Liquidacion.AutoSize = True
        Me.Liquidacion.Location = New System.Drawing.Point(122, 56)
        Me.Liquidacion.Name = "Liquidacion"
        Me.Liquidacion.Size = New System.Drawing.Size(62, 13)
        Me.Liquidacion.TabIndex = 0
        Me.Liquidacion.Text = "Entregador:"
        '
        'Entregador
        '
        Me.Entregador.AutoSize = True
        Me.Entregador.Location = New System.Drawing.Point(122, 30)
        Me.Entregador.Name = "Entregador"
        Me.Entregador.Size = New System.Drawing.Size(62, 13)
        Me.Entregador.TabIndex = 0
        Me.Entregador.Text = "Entregador:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Entregador:"
        '
        'BtnContinuar
        '
        Me.BtnContinuar.Location = New System.Drawing.Point(642, 422)
        Me.BtnContinuar.Name = "BtnContinuar"
        Me.BtnContinuar.Size = New System.Drawing.Size(75, 23)
        Me.BtnContinuar.TabIndex = 2
        Me.BtnContinuar.Text = "Continuar"
        Me.BtnContinuar.UseVisualStyleBackColor = True
        '
        'Frm_Det_Creditos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 457)
        Me.Controls.Add(Me.BtnContinuar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Detalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Det_Creditos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Créditos"
        CType(Me.Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Detalle As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Liquidacion As System.Windows.Forms.Label
    Friend WithEvents Entregador As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnContinuar As System.Windows.Forms.Button
    Friend WithEvents Tipo As System.Windows.Forms.Label
End Class
