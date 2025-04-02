<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroEvento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroEvento))
        Me.ComboVehiculo = New System.Windows.Forms.ComboBox
        Me.ComboCategoria = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.TextOtraCategoria = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextHerraientas = New System.Windows.Forms.TextBox
        Me.TextCostoAnomalia = New System.Windows.Forms.TextBox
        Me.TextEvento = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnCompletarRemision = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboVehiculo
        '
        Me.ComboVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVehiculo.FormattingEnabled = True
        Me.ComboVehiculo.Location = New System.Drawing.Point(73, 18)
        Me.ComboVehiculo.Name = "ComboVehiculo"
        Me.ComboVehiculo.Size = New System.Drawing.Size(305, 21)
        Me.ComboVehiculo.TabIndex = 8
        '
        'ComboCategoria
        '
        Me.ComboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCategoria.FormattingEnabled = True
        Me.ComboCategoria.Location = New System.Drawing.Point(73, 45)
        Me.ComboCategoria.Name = "ComboCategoria"
        Me.ComboCategoria.Size = New System.Drawing.Size(305, 21)
        Me.ComboCategoria.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Categoría:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Vehículo:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.TextOtraCategoria)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboVehiculo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ComboCategoria)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(679, 86)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(381, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Fecha de evento:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(470, 19)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 10
        '
        'TextOtraCategoria
        '
        Me.TextOtraCategoria.Location = New System.Drawing.Point(384, 46)
        Me.TextOtraCategoria.Name = "TextOtraCategoria"
        Me.TextOtraCategoria.Size = New System.Drawing.Size(286, 20)
        Me.TextOtraCategoria.TabIndex = 9
        Me.TextOtraCategoria.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextHerraientas)
        Me.GroupBox2.Controls.Add(Me.TextCostoAnomalia)
        Me.GroupBox2.Controls.Add(Me.TextEvento)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 105)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(598, 155)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'TextHerraientas
        '
        Me.TextHerraientas.Location = New System.Drawing.Point(191, 123)
        Me.TextHerraientas.Name = "TextHerraientas"
        Me.TextHerraientas.Size = New System.Drawing.Size(263, 20)
        Me.TextHerraientas.TabIndex = 6
        '
        'TextCostoAnomalia
        '
        Me.TextCostoAnomalia.Location = New System.Drawing.Point(190, 93)
        Me.TextCostoAnomalia.Name = "TextCostoAnomalia"
        Me.TextCostoAnomalia.Size = New System.Drawing.Size(264, 20)
        Me.TextCostoAnomalia.TabIndex = 6
        '
        'TextEvento
        '
        Me.TextEvento.Location = New System.Drawing.Point(190, 19)
        Me.TextEvento.Multiline = True
        Me.TextEvento.Name = "TextEvento"
        Me.TextEvento.Size = New System.Drawing.Size(390, 64)
        Me.TextEvento.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(171, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Registro de herramientas dañadas:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Costo de anomalía:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Descripción del Evento:"
        '
        'BtnCompletarRemision
        '
        Me.BtnCompletarRemision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCompletarRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCompletarRemision.Image = Global.Disar.My.Resources.Resources.img_aceptar
        Me.BtnCompletarRemision.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCompletarRemision.Location = New System.Drawing.Point(617, 189)
        Me.BtnCompletarRemision.Name = "BtnCompletarRemision"
        Me.BtnCompletarRemision.Size = New System.Drawing.Size(84, 70)
        Me.BtnCompletarRemision.TabIndex = 18
        Me.BtnCompletarRemision.Text = "Guardar Evento"
        Me.BtnCompletarRemision.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCompletarRemision.UseVisualStyleBackColor = True
        '
        'FrmRegistroEvento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 268)
        Me.Controls.Add(Me.BtnCompletarRemision)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRegistroEvento"
        Me.Text = "Nuevo Evento"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents ComboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextOtraCategoria As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextEvento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnCompletarRemision As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextHerraientas As System.Windows.Forms.TextBox
    Friend WithEvents TextCostoAnomalia As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
