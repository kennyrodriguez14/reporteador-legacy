<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetallesFactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetallesFactura))
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.FechaFacturas = New System.Windows.Forms.Label
        Me.NombreCliente = New System.Windows.Forms.Label
        Me.CodigoCliente = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextCredito = New System.Windows.Forms.TextBox
        Me.TextTotal = New System.Windows.Forms.TextBox
        Me.TextNoEspecificado = New System.Windows.Forms.TextBox
        Me.TextInsumos = New System.Windows.Forms.TextBox
        Me.TextSacos = New System.Windows.Forms.TextBox
        Me.TextFertilizantes = New System.Windows.Forms.TextBox
        Me.TextMascotas = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBalanceados = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Aceptar = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(75, 251)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "- Notas de Crédito:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.FechaFacturas)
        Me.GroupBox2.Controls.Add(Me.NombreCliente)
        Me.GroupBox2.Controls.Add(Me.CodigoCliente)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(384, 65)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cliente:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Desde:"
        '
        'FechaFacturas
        '
        Me.FechaFacturas.AutoSize = True
        Me.FechaFacturas.Location = New System.Drawing.Point(64, 40)
        Me.FechaFacturas.Name = "FechaFacturas"
        Me.FechaFacturas.Size = New System.Drawing.Size(81, 13)
        Me.FechaFacturas.TabIndex = 0
        Me.FechaFacturas.Text = "♦♦/♦♦/♦♦♦♦"
        '
        'NombreCliente
        '
        Me.NombreCliente.Location = New System.Drawing.Point(127, 16)
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.Size = New System.Drawing.Size(251, 46)
        Me.NombreCliente.TabIndex = 0
        Me.NombreCliente.Text = "♦♦♦♦♦♦"
        '
        'CodigoCliente
        '
        Me.CodigoCliente.AutoSize = True
        Me.CodigoCliente.Location = New System.Drawing.Point(64, 16)
        Me.CodigoCliente.Name = "CodigoCliente"
        Me.CodigoCliente.Size = New System.Drawing.Size(55, 13)
        Me.CodigoCliente.TabIndex = 0
        Me.CodigoCliente.Text = "♦♦♦♦♦♦"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.TextCredito)
        Me.GroupBox1.Controls.Add(Me.TextTotal)
        Me.GroupBox1.Controls.Add(Me.TextNoEspecificado)
        Me.GroupBox1.Controls.Add(Me.TextInsumos)
        Me.GroupBox1.Controls.Add(Me.TextSacos)
        Me.GroupBox1.Controls.Add(Me.TextFertilizantes)
        Me.GroupBox1.Controls.Add(Me.TextMascotas)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TextBalanceados)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Snow
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(417, 326)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles de Consumo en Facturas"
        '
        'TextCredito
        '
        Me.TextCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCredito.Location = New System.Drawing.Point(174, 248)
        Me.TextCredito.Name = "TextCredito"
        Me.TextCredito.ReadOnly = True
        Me.TextCredito.Size = New System.Drawing.Size(160, 20)
        Me.TextCredito.TabIndex = 1
        '
        'TextTotal
        '
        Me.TextTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotal.Location = New System.Drawing.Point(174, 289)
        Me.TextTotal.Name = "TextTotal"
        Me.TextTotal.ReadOnly = True
        Me.TextTotal.Size = New System.Drawing.Size(160, 21)
        Me.TextTotal.TabIndex = 1
        '
        'TextNoEspecificado
        '
        Me.TextNoEspecificado.Location = New System.Drawing.Point(174, 223)
        Me.TextNoEspecificado.Name = "TextNoEspecificado"
        Me.TextNoEspecificado.ReadOnly = True
        Me.TextNoEspecificado.Size = New System.Drawing.Size(160, 20)
        Me.TextNoEspecificado.TabIndex = 1
        '
        'TextInsumos
        '
        Me.TextInsumos.Location = New System.Drawing.Point(174, 198)
        Me.TextInsumos.Name = "TextInsumos"
        Me.TextInsumos.ReadOnly = True
        Me.TextInsumos.Size = New System.Drawing.Size(160, 20)
        Me.TextInsumos.TabIndex = 1
        '
        'TextSacos
        '
        Me.TextSacos.Location = New System.Drawing.Point(174, 173)
        Me.TextSacos.Name = "TextSacos"
        Me.TextSacos.ReadOnly = True
        Me.TextSacos.Size = New System.Drawing.Size(160, 20)
        Me.TextSacos.TabIndex = 1
        '
        'TextFertilizantes
        '
        Me.TextFertilizantes.Location = New System.Drawing.Point(174, 148)
        Me.TextFertilizantes.Name = "TextFertilizantes"
        Me.TextFertilizantes.ReadOnly = True
        Me.TextFertilizantes.Size = New System.Drawing.Size(160, 20)
        Me.TextFertilizantes.TabIndex = 1
        '
        'TextMascotas
        '
        Me.TextMascotas.Location = New System.Drawing.Point(174, 123)
        Me.TextMascotas.Name = "TextMascotas"
        Me.TextMascotas.ReadOnly = True
        Me.TextMascotas.Size = New System.Drawing.Size(160, 20)
        Me.TextMascotas.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(83, 292)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "TOTAL:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(83, 226)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "No especificado:"
        '
        'TextBalanceados
        '
        Me.TextBalanceados.Location = New System.Drawing.Point(174, 98)
        Me.TextBalanceados.Name = "TextBalanceados"
        Me.TextBalanceados.ReadOnly = True
        Me.TextBalanceados.Size = New System.Drawing.Size(160, 20)
        Me.TextBalanceados.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(83, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Insumos:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(83, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Sacos:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(83, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fertilizantes:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(83, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mascotas:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(83, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Balanceados:"
        '
        'Aceptar
        '
        Me.Aceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aceptar.ForeColor = System.Drawing.Color.DimGray
        Me.Aceptar.Location = New System.Drawing.Point(340, 342)
        Me.Aceptar.Name = "Aceptar"
        Me.Aceptar.Size = New System.Drawing.Size(89, 23)
        Me.Aceptar.TabIndex = 4
        Me.Aceptar.Text = "Aceptar"
        Me.Aceptar.UseVisualStyleBackColor = True
        '
        'DetallesFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(440, 374)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Aceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DetallesFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DetallesFactura"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents FechaFacturas As System.Windows.Forms.Label
    Friend WithEvents NombreCliente As System.Windows.Forms.Label
    Friend WithEvents CodigoCliente As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextCredito As System.Windows.Forms.TextBox
    Friend WithEvents TextTotal As System.Windows.Forms.TextBox
    Friend WithEvents TextNoEspecificado As System.Windows.Forms.TextBox
    Friend WithEvents TextInsumos As System.Windows.Forms.TextBox
    Friend WithEvents TextSacos As System.Windows.Forms.TextBox
    Friend WithEvents TextFertilizantes As System.Windows.Forms.TextBox
    Friend WithEvents TextMascotas As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBalanceados As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Aceptar As System.Windows.Forms.Button
End Class
