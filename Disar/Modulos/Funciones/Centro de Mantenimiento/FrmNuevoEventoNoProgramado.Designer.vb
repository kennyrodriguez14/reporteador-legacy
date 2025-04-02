<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNuevoEventoNoProgramado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNuevoEventoNoProgramado))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.ComboVehiculo = New System.Windows.Forms.ComboBox
        Me.ComboEvento = New System.Windows.Forms.ComboBox
        Me.TextDuracion = New System.Windows.Forms.TextBox
        Me.TextNuevoEvento = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.ComboVehiculo)
        Me.GroupBox1.Controls.Add(Me.ComboEvento)
        Me.GroupBox1.Controls.Add(Me.TextDuracion)
        Me.GroupBox1.Controls.Add(Me.TextNuevoEvento)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(472, 194)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(129, 122)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(204, 20)
        Me.DateTimePicker1.TabIndex = 3
        '
        'ComboVehiculo
        '
        Me.ComboVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVehiculo.FormattingEnabled = True
        Me.ComboVehiculo.Location = New System.Drawing.Point(129, 23)
        Me.ComboVehiculo.Name = "ComboVehiculo"
        Me.ComboVehiculo.Size = New System.Drawing.Size(305, 21)
        Me.ComboVehiculo.TabIndex = 2
        '
        'ComboEvento
        '
        Me.ComboEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEvento.FormattingEnabled = True
        Me.ComboEvento.Location = New System.Drawing.Point(129, 52)
        Me.ComboEvento.Name = "ComboEvento"
        Me.ComboEvento.Size = New System.Drawing.Size(305, 21)
        Me.ComboEvento.TabIndex = 2
        '
        'TextDuracion
        '
        Me.TextDuracion.Location = New System.Drawing.Point(129, 154)
        Me.TextDuracion.Name = "TextDuracion"
        Me.TextDuracion.Size = New System.Drawing.Size(305, 20)
        Me.TextDuracion.TabIndex = 1
        '
        'TextNuevoEvento
        '
        Me.TextNuevoEvento.Location = New System.Drawing.Point(129, 80)
        Me.TextNuevoEvento.Name = "TextNuevoEvento"
        Me.TextNuevoEvento.Size = New System.Drawing.Size(305, 20)
        Me.TextNuevoEvento.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha en que se realizó:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Vehículo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Duración del evento:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descripción:"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(409, 212)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "Guardar Programación"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'FrmNuevoEventoNoProgramado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 247)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmNuevoEventoNoProgramado"
        Me.Text = "Nuevo Evento No Programado"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents ComboEvento As System.Windows.Forms.ComboBox
    Friend WithEvents TextDuracion As System.Windows.Forms.TextBox
    Friend WithEvents TextNuevoEvento As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
End Class
