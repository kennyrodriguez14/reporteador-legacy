<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificarClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModificarClientes))
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextID = New System.Windows.Forms.TextBox
        Me.TextNombre = New System.Windows.Forms.TextBox
        Me.TextDireccion = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBarrio = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextTelefono = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextPropietario = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextDiaVisita = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextLatitud = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextLongitud = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextRTN = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TextDepartamento = New System.Windows.Forms.TextBox
        Me.TextMunicipio = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextVendedor = New System.Windows.Forms.TextBox
        Me.ComboVendedor = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente:"
        '
        'TextID
        '
        Me.TextID.Enabled = False
        Me.TextID.Location = New System.Drawing.Point(119, 27)
        Me.TextID.Name = "TextID"
        Me.TextID.Size = New System.Drawing.Size(94, 20)
        Me.TextID.TabIndex = 1
        '
        'TextNombre
        '
        Me.TextNombre.Enabled = False
        Me.TextNombre.Location = New System.Drawing.Point(219, 27)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(478, 20)
        Me.TextNombre.TabIndex = 3
        '
        'TextDireccion
        '
        Me.TextDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDireccion.Location = New System.Drawing.Point(119, 19)
        Me.TextDireccion.Name = "TextDireccion"
        Me.TextDireccion.Size = New System.Drawing.Size(248, 20)
        Me.TextDireccion.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Dirección:"
        '
        'TextBarrio
        '
        Me.TextBarrio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBarrio.Location = New System.Drawing.Point(119, 42)
        Me.TextBarrio.Name = "TextBarrio"
        Me.TextBarrio.Size = New System.Drawing.Size(248, 20)
        Me.TextBarrio.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Barrio / Colonia:"
        '
        'TextTelefono
        '
        Me.TextTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTelefono.Location = New System.Drawing.Point(119, 93)
        Me.TextTelefono.Name = "TextTelefono"
        Me.TextTelefono.Size = New System.Drawing.Size(248, 20)
        Me.TextTelefono.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Teléfono:"
        '
        'TextPropietario
        '
        Me.TextPropietario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextPropietario.Location = New System.Drawing.Point(119, 123)
        Me.TextPropietario.Name = "TextPropietario"
        Me.TextPropietario.Size = New System.Drawing.Size(248, 20)
        Me.TextPropietario.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Propietario:"
        '
        'TextDiaVisita
        '
        Me.TextDiaVisita.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDiaVisita.Location = New System.Drawing.Point(92, 25)
        Me.TextDiaVisita.Name = "TextDiaVisita"
        Me.TextDiaVisita.Size = New System.Drawing.Size(208, 20)
        Me.TextDiaVisita.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Día de Visita:"
        '
        'TextLatitud
        '
        Me.TextLatitud.Location = New System.Drawing.Point(92, 35)
        Me.TextLatitud.Name = "TextLatitud"
        Me.TextLatitud.Size = New System.Drawing.Size(94, 20)
        Me.TextLatitud.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(89, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Latitud:"
        '
        'TextLongitud
        '
        Me.TextLongitud.Location = New System.Drawing.Point(206, 35)
        Me.TextLongitud.Name = "TextLongitud"
        Me.TextLongitud.Size = New System.Drawing.Size(94, 20)
        Me.TextLongitud.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(203, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Longitud:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextID)
        Me.GroupBox1.Controls.Add(Me.TextNombre)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(714, 70)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TextRTN)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TextDireccion)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TextBarrio)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TextTelefono)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TextPropietario)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 88)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(387, 205)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "RTN:"
        '
        'TextRTN
        '
        Me.TextRTN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRTN.Location = New System.Drawing.Point(119, 152)
        Me.TextRTN.Name = "TextRTN"
        Me.TextRTN.Size = New System.Drawing.Size(248, 20)
        Me.TextRTN.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextDiaVisita)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(409, 156)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(317, 64)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.TextLatitud)
        Me.GroupBox4.Controls.Add(Me.TextLongitud)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(409, 228)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(317, 66)
        Me.GroupBox4.TabIndex = 22
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Coordenadas:"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(537, 337)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(89, 48)
        Me.BtnGuardar.TabIndex = 9
        Me.BtnGuardar.Text = "Guardar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cambios"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(637, 337)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(89, 48)
        Me.BtnCancelar.TabIndex = 23
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TextDepartamento)
        Me.GroupBox5.Controls.Add(Me.TextMunicipio)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Location = New System.Drawing.Point(409, 89)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(317, 71)
        Me.GroupBox5.TabIndex = 24
        Me.GroupBox5.TabStop = False
        '
        'TextDepartamento
        '
        Me.TextDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDepartamento.Location = New System.Drawing.Point(118, 42)
        Me.TextDepartamento.Name = "TextDepartamento"
        Me.TextDepartamento.Size = New System.Drawing.Size(182, 20)
        Me.TextDepartamento.TabIndex = 3
        '
        'TextMunicipio
        '
        Me.TextMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextMunicipio.Location = New System.Drawing.Point(118, 19)
        Me.TextMunicipio.Name = "TextMunicipio"
        Me.TextMunicipio.Size = New System.Drawing.Size(182, 20)
        Me.TextMunicipio.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Departamento:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Municipio/Localidad:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.TextVendedor)
        Me.GroupBox6.Controls.Add(Me.ComboVendedor)
        Me.GroupBox6.Location = New System.Drawing.Point(16, 299)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(387, 48)
        Me.GroupBox6.TabIndex = 25
        Me.GroupBox6.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Ruta:"
        '
        'TextVendedor
        '
        Me.TextVendedor.Location = New System.Drawing.Point(67, 16)
        Me.TextVendedor.Name = "TextVendedor"
        Me.TextVendedor.Size = New System.Drawing.Size(46, 20)
        Me.TextVendedor.TabIndex = 3
        '
        'ComboVendedor
        '
        Me.ComboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVendedor.FormattingEnabled = True
        Me.ComboVendedor.Location = New System.Drawing.Point(119, 15)
        Me.ComboVendedor.Name = "ComboVendedor"
        Me.ComboVendedor.Size = New System.Drawing.Size(248, 21)
        Me.ComboVendedor.TabIndex = 4
        '
        'FrmModificarClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 399)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmModificarClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Información de Clientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextID As System.Windows.Forms.TextBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBarrio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextPropietario As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextDiaVisita As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextLatitud As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextLongitud As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextRTN As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TextDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents TextMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents TextVendedor As System.Windows.Forms.TextBox
    Friend WithEvents ComboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
