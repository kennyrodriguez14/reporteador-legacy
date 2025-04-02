<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Edicion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Edicion))
        Me.TextTieneMascota = New System.Windows.Forms.ComboBox
        Me.TextTipoGranja = New System.Windows.Forms.TextBox
        Me.TextAnimales = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextManzanas = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextMarcas = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextPorque = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextAgroservicio = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextCultivos = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextUbicacion = New System.Windows.Forms.TextBox
        Me.TextIDRTN = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextClaveCliente = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextNombreCliente = New System.Windows.Forms.TextBox
        Me.BtnGuarda = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextTieneMascota
        '
        Me.TextTieneMascota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TextTieneMascota.FormattingEnabled = True
        Me.TextTieneMascota.Items.AddRange(New Object() {"SI", "NO"})
        Me.TextTieneMascota.Location = New System.Drawing.Point(142, 109)
        Me.TextTieneMascota.Name = "TextTieneMascota"
        Me.TextTieneMascota.Size = New System.Drawing.Size(129, 21)
        Me.TextTieneMascota.TabIndex = 13
        '
        'TextTipoGranja
        '
        Me.TextTipoGranja.Location = New System.Drawing.Point(94, 71)
        Me.TextTipoGranja.Name = "TextTipoGranja"
        Me.TextTipoGranja.Size = New System.Drawing.Size(177, 20)
        Me.TextTipoGranja.TabIndex = 7
        '
        'TextAnimales
        '
        Me.TextAnimales.Location = New System.Drawing.Point(377, 71)
        Me.TextAnimales.Multiline = True
        Me.TextAnimales.Name = "TextAnimales"
        Me.TextAnimales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextAnimales.Size = New System.Drawing.Size(211, 28)
        Me.TextAnimales.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(302, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "# Animales:"
        '
        'TextManzanas
        '
        Me.TextManzanas.Location = New System.Drawing.Point(377, 17)
        Me.TextManzanas.Multiline = True
        Me.TextManzanas.Name = "TextManzanas"
        Me.TextManzanas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextManzanas.Size = New System.Drawing.Size(211, 48)
        Me.TextManzanas.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Tiene Mascota:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(302, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "# Manzanas:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Clave de Cliente:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Tipo de granja:"
        '
        'TextMarcas
        '
        Me.TextMarcas.Location = New System.Drawing.Point(142, 231)
        Me.TextMarcas.Multiline = True
        Me.TextMarcas.Name = "TextMarcas"
        Me.TextMarcas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextMarcas.Size = New System.Drawing.Size(446, 48)
        Me.TextMarcas.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 234)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 26)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Marcas de fertilizantes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "que más utiliza"
        '
        'TextPorque
        '
        Me.TextPorque.Location = New System.Drawing.Point(142, 176)
        Me.TextPorque.Multiline = True
        Me.TextPorque.Name = "TextPorque"
        Me.TextPorque.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextPorque.Size = New System.Drawing.Size(446, 48)
        Me.TextPorque.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 179)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "¿Por qué?"
        '
        'TextAgroservicio
        '
        Me.TextAgroservicio.Location = New System.Drawing.Point(142, 136)
        Me.TextAgroservicio.Multiline = True
        Me.TextAgroservicio.Name = "TextAgroservicio"
        Me.TextAgroservicio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextAgroservicio.Size = New System.Drawing.Size(446, 33)
        Me.TextAgroservicio.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 139)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Agroservicio más visitado:"
        '
        'TextCultivos
        '
        Me.TextCultivos.Location = New System.Drawing.Point(60, 17)
        Me.TextCultivos.Multiline = True
        Me.TextCultivos.Name = "TextCultivos"
        Me.TextCultivos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextCultivos.Size = New System.Drawing.Size(211, 48)
        Me.TextCultivos.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Cultivos:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "ID / RTN de Cliente:"
        '
        'TextUbicacion
        '
        Me.TextUbicacion.Location = New System.Drawing.Point(312, 49)
        Me.TextUbicacion.Name = "TextUbicacion"
        Me.TextUbicacion.ReadOnly = True
        Me.TextUbicacion.Size = New System.Drawing.Size(276, 20)
        Me.TextUbicacion.TabIndex = 4
        '
        'TextIDRTN
        '
        Me.TextIDRTN.Location = New System.Drawing.Point(110, 49)
        Me.TextIDRTN.Name = "TextIDRTN"
        Me.TextIDRTN.ReadOnly = True
        Me.TextIDRTN.Size = New System.Drawing.Size(131, 20)
        Me.TextIDRTN.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(209, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre de Cliente:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(247, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ubicación:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextTieneMascota)
        Me.GroupBox2.Controls.Add(Me.TextTipoGranja)
        Me.GroupBox2.Controls.Add(Me.TextAnimales)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TextManzanas)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextMarcas)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TextPorque)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TextAgroservicio)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TextCultivos)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(594, 289)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        '
        'TextClaveCliente
        '
        Me.TextClaveCliente.Location = New System.Drawing.Point(97, 23)
        Me.TextClaveCliente.Name = "TextClaveCliente"
        Me.TextClaveCliente.ReadOnly = True
        Me.TextClaveCliente.Size = New System.Drawing.Size(100, 20)
        Me.TextClaveCliente.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextUbicacion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextIDRTN)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextClaveCliente)
        Me.GroupBox1.Controls.Add(Me.TextNombreCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(594, 87)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'TextNombreCliente
        '
        Me.TextNombreCliente.Location = New System.Drawing.Point(312, 23)
        Me.TextNombreCliente.Name = "TextNombreCliente"
        Me.TextNombreCliente.ReadOnly = True
        Me.TextNombreCliente.Size = New System.Drawing.Size(276, 20)
        Me.TextNombreCliente.TabIndex = 2
        '
        'BtnGuarda
        '
        Me.BtnGuarda.Location = New System.Drawing.Point(514, 395)
        Me.BtnGuarda.Name = "BtnGuarda"
        Me.BtnGuarda.Size = New System.Drawing.Size(87, 32)
        Me.BtnGuarda.TabIndex = 16
        Me.BtnGuarda.Text = "Guardar"
        Me.BtnGuarda.UseVisualStyleBackColor = True
        '
        'Edicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 435)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnGuarda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Edicion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edicion"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextTieneMascota As System.Windows.Forms.ComboBox
    Friend WithEvents TextTipoGranja As System.Windows.Forms.TextBox
    Friend WithEvents TextAnimales As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextManzanas As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextMarcas As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextPorque As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextAgroservicio As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextCultivos As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents TextIDRTN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextClaveCliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents BtnGuarda As System.Windows.Forms.Button
End Class
