<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPreventivoCorrectivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPreventivoCorrectivo))
        Me.Hasta = New System.Windows.Forms.DateTimePicker
        Me.Desde = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbVehiculo = New System.Windows.Forms.ComboBox
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.BtnGenerar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextPreventivos = New System.Windows.Forms.TextBox
        Me.TextCorrectivos = New System.Windows.Forms.TextBox
        Me.TextPorcentajePreventivos = New System.Windows.Forms.TextBox
        Me.TextPorcentajeCorrectivos = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextTotalMantenimientos = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Hasta
        '
        Me.Hasta.Location = New System.Drawing.Point(480, 43)
        Me.Hasta.Name = "Hasta"
        Me.Hasta.Size = New System.Drawing.Size(200, 20)
        Me.Hasta.TabIndex = 9
        '
        'Desde
        '
        Me.Desde.Location = New System.Drawing.Point(480, 17)
        Me.Desde.Name = "Desde"
        Me.Desde.Size = New System.Drawing.Size(200, 20)
        Me.Desde.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(439, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Hasta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(439, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Desde:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Hasta)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Desde)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.CmbVehiculo)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(702, 74)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filtrar Vehículo"
        '
        'CmbVehiculo
        '
        Me.CmbVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVehiculo.FormattingEnabled = True
        Me.CmbVehiculo.Location = New System.Drawing.Point(109, 20)
        Me.CmbVehiculo.Name = "CmbVehiculo"
        Me.CmbVehiculo.Size = New System.Drawing.Size(273, 21)
        Me.CmbVehiculo.TabIndex = 3
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Location = New System.Drawing.Point(12, 156)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.RowHeadersVisible = False
        Me.DataDatos.Size = New System.Drawing.Size(947, 330)
        Me.DataDatos.TabIndex = 9
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Location = New System.Drawing.Point(720, 29)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(75, 34)
        Me.BtnGenerar.TabIndex = 10
        Me.BtnGenerar.Text = "Generar"
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextTotalMantenimientos)
        Me.GroupBox1.Controls.Add(Me.TextPorcentajeCorrectivos)
        Me.GroupBox1.Controls.Add(Me.TextPorcentajePreventivos)
        Me.GroupBox1.Controls.Add(Me.TextCorrectivos)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TextPreventivos)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(947, 76)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Total Mantenimientos Preventivos:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Total Mantenimientos Correctivos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(287, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(154, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "% Mantenimientos Preventivos:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(287, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(151, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "% Mantenimientos Correctivos:"
        '
        'TextPreventivos
        '
        Me.TextPreventivos.Enabled = False
        Me.TextPreventivos.Location = New System.Drawing.Point(181, 18)
        Me.TextPreventivos.Name = "TextPreventivos"
        Me.TextPreventivos.Size = New System.Drawing.Size(100, 20)
        Me.TextPreventivos.TabIndex = 1
        '
        'TextCorrectivos
        '
        Me.TextCorrectivos.Enabled = False
        Me.TextCorrectivos.Location = New System.Drawing.Point(181, 48)
        Me.TextCorrectivos.Name = "TextCorrectivos"
        Me.TextCorrectivos.Size = New System.Drawing.Size(100, 20)
        Me.TextCorrectivos.TabIndex = 1
        '
        'TextPorcentajePreventivos
        '
        Me.TextPorcentajePreventivos.Enabled = False
        Me.TextPorcentajePreventivos.Location = New System.Drawing.Point(444, 18)
        Me.TextPorcentajePreventivos.Name = "TextPorcentajePreventivos"
        Me.TextPorcentajePreventivos.Size = New System.Drawing.Size(100, 20)
        Me.TextPorcentajePreventivos.TabIndex = 1
        '
        'TextPorcentajeCorrectivos
        '
        Me.TextPorcentajeCorrectivos.Enabled = False
        Me.TextPorcentajeCorrectivos.Location = New System.Drawing.Point(444, 48)
        Me.TextPorcentajeCorrectivos.Name = "TextPorcentajeCorrectivos"
        Me.TextPorcentajeCorrectivos.Size = New System.Drawing.Size(100, 20)
        Me.TextPorcentajeCorrectivos.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(562, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Total Mantenimientos:"
        '
        'TextTotalMantenimientos
        '
        Me.TextTotalMantenimientos.Enabled = False
        Me.TextTotalMantenimientos.Location = New System.Drawing.Point(679, 33)
        Me.TextTotalMantenimientos.Name = "TextTotalMantenimientos"
        Me.TextTotalMantenimientos.Size = New System.Drawing.Size(100, 20)
        Me.TextTotalMantenimientos.TabIndex = 1
        '
        'FormPreventivoCorrectivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 498)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnGenerar)
        Me.Controls.Add(Me.DataDatos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormPreventivoCorrectivo"
        Me.Text = "Mantenimientos Preventivos Vrs Correctivos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextCorrectivos As System.Windows.Forms.TextBox
    Friend WithEvents TextPreventivos As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextTotalMantenimientos As System.Windows.Forms.TextBox
    Friend WithEvents TextPorcentajeCorrectivos As System.Windows.Forms.TextBox
    Friend WithEvents TextPorcentajePreventivos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
