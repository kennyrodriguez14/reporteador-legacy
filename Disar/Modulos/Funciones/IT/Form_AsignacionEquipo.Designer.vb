<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_AsignacionEquipo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_AsignacionEquipo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TextObsevaciones = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextAccesorios = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextDepartamentoEntrega = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextNombreRecibe = New System.Windows.Forms.TextBox
        Me.TextRecibe = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextEntrega = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextNumero = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Num = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextDepartamentoEntrega)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextNombreRecibe)
        Me.GroupBox1.Controls.Add(Me.TextRecibe)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextEntrega)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextNumero)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Num)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(709, 392)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Administración", "Almacén", "Auditoría", "Cadena de Suministros", "Comercial", "Créditos", "Distribución", "Mantenimiento", "Operaciones Logística", "Sistemas y Tecnología", "Talento Humano", "Ventas"})
        Me.ComboBox1.Location = New System.Drawing.Point(474, 111)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(220, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnCancelar)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.BtnGuardar)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.TextObsevaciones)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextAccesorios)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 163)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(681, 212)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.BtnCancelar.Location = New System.Drawing.Point(519, 145)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 54)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Location = New System.Drawing.Point(130, 34)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(226, 20)
        Me.DateTimePicker1.TabIndex = 2
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Disar.My.Resources.Resources.img_aceptar
        Me.BtnGuardar.Location = New System.Drawing.Point(600, 145)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 54)
        Me.BtnGuardar.TabIndex = 6
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(22, 34)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(110, 17)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "Con Fecha Límite"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextObsevaciones
        '
        Me.TextObsevaciones.Location = New System.Drawing.Point(440, 69)
        Me.TextObsevaciones.Multiline = True
        Me.TextObsevaciones.Name = "TextObsevaciones"
        Me.TextObsevaciones.Size = New System.Drawing.Size(235, 70)
        Me.TextObsevaciones.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(362, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Observaciones:"
        '
        'TextAccesorios
        '
        Me.TextAccesorios.Location = New System.Drawing.Point(130, 69)
        Me.TextAccesorios.Multiline = True
        Me.TextAccesorios.Name = "TextAccesorios"
        Me.TextAccesorios.Size = New System.Drawing.Size(226, 66)
        Me.TextAccesorios.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(63, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Accesorios:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(394, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Departamento"
        '
        'TextDepartamentoEntrega
        '
        Me.TextDepartamentoEntrega.Location = New System.Drawing.Point(474, 62)
        Me.TextDepartamentoEntrega.Name = "TextDepartamentoEntrega"
        Me.TextDepartamentoEntrega.Size = New System.Drawing.Size(220, 20)
        Me.TextDepartamentoEntrega.TabIndex = 2
        Me.TextDepartamentoEntrega.Text = "Sistemas y Tecnología"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(394, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Departamento"
        '
        'TextNombreRecibe
        '
        Me.TextNombreRecibe.Location = New System.Drawing.Point(149, 133)
        Me.TextNombreRecibe.Name = "TextNombreRecibe"
        Me.TextNombreRecibe.ReadOnly = True
        Me.TextNombreRecibe.Size = New System.Drawing.Size(226, 20)
        Me.TextNombreRecibe.TabIndex = 5
        Me.TextNombreRecibe.TabStop = False
        '
        'TextRecibe
        '
        Me.TextRecibe.Location = New System.Drawing.Point(149, 112)
        Me.TextRecibe.Name = "TextRecibe"
        Me.TextRecibe.ReadOnly = True
        Me.TextRecibe.Size = New System.Drawing.Size(226, 20)
        Me.TextRecibe.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 26)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Persona que recibe el " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "equipo"
        '
        'TextEntrega
        '
        Me.TextEntrega.Location = New System.Drawing.Point(149, 62)
        Me.TextEntrega.Name = "TextEntrega"
        Me.TextEntrega.Size = New System.Drawing.Size(226, 20)
        Me.TextEntrega.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre de quien entrega"
        '
        'TextNumero
        '
        Me.TextNumero.Enabled = False
        Me.TextNumero.Location = New System.Drawing.Point(149, 36)
        Me.TextNumero.Name = "TextNumero"
        Me.TextNumero.Size = New System.Drawing.Size(226, 20)
        Me.TextNumero.TabIndex = 0
        Me.TextNumero.Tag = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(124, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Nº"
        '
        'Num
        '
        Me.Num.AutoSize = True
        Me.Num.Location = New System.Drawing.Point(675, 39)
        Me.Num.Name = "Num"
        Me.Num.Size = New System.Drawing.Size(19, 13)
        Me.Num.TabIndex = 0
        Me.Num.Text = "Nº"
        '
        'Form_AsignacionEquipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 415)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_AsignacionEquipo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Equipo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextNumero As System.Windows.Forms.TextBox
    Friend WithEvents Num As System.Windows.Forms.Label
    Friend WithEvents TextRecibe As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextDepartamentoEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextObsevaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextAccesorios As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextNombreRecibe As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
