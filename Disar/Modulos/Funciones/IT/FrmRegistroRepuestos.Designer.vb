<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroRepuestos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroRepuestos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TextDiscoDuro = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextRAM = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TextProcesador = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ComboProveedor = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboMarca = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextContacto = New System.Windows.Forms.TextBox
        Me.TextModelo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextSerie = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Numero = New System.Windows.Forms.Label
        Me.ComboCat = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextDescripcion = New System.Windows.Forms.TextBox
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.ComboEstado = New System.Windows.Forms.ComboBox
        Me.ComboUbicacion = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.BtnCancelar)
        Me.GroupBox1.Controls.Add(Me.BtnGuardar)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(747, 350)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextDiscoDuro)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.TextRAM)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.TextProcesador)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 195)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(370, 104)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'TextDiscoDuro
        '
        Me.TextDiscoDuro.Location = New System.Drawing.Point(102, 70)
        Me.TextDiscoDuro.Name = "TextDiscoDuro"
        Me.TextDiscoDuro.Size = New System.Drawing.Size(241, 20)
        Me.TextDiscoDuro.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(27, 73)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Disco Duro:"
        '
        'TextRAM
        '
        Me.TextRAM.Location = New System.Drawing.Point(102, 45)
        Me.TextRAM.Name = "TextRAM"
        Me.TextRAM.Size = New System.Drawing.Size(241, 20)
        Me.TextRAM.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(56, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "RAM:"
        '
        'TextProcesador
        '
        Me.TextProcesador.Location = New System.Drawing.Point(102, 19)
        Me.TextProcesador.Name = "TextProcesador"
        Me.TextProcesador.Size = New System.Drawing.Size(241, 20)
        Me.TextProcesador.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(28, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Procesador:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox6)
        Me.GroupBox2.Controls.Add(Me.ComboProveedor)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ComboMarca)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TextContacto)
        Me.GroupBox2.Controls.Add(Me.TextModelo)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TextSerie)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 85)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(732, 107)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'ComboProveedor
        '
        Me.ComboProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboProveedor.FormattingEnabled = True
        Me.ComboProveedor.Location = New System.Drawing.Point(482, 19)
        Me.ComboProveedor.Name = "ComboProveedor"
        Me.ComboProveedor.Size = New System.Drawing.Size(209, 21)
        Me.ComboProveedor.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(423, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Contacto:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(417, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Proveedor:"
        '
        'ComboMarca
        '
        Me.ComboMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboMarca.FormattingEnabled = True
        Me.ComboMarca.Location = New System.Drawing.Point(102, 71)
        Me.ComboMarca.Name = "ComboMarca"
        Me.ComboMarca.Size = New System.Drawing.Size(241, 21)
        Me.ComboMarca.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Marca:"
        '
        'TextContacto
        '
        Me.TextContacto.Location = New System.Drawing.Point(482, 45)
        Me.TextContacto.Name = "TextContacto"
        Me.TextContacto.Size = New System.Drawing.Size(209, 20)
        Me.TextContacto.TabIndex = 3
        '
        'TextModelo
        '
        Me.TextModelo.Location = New System.Drawing.Point(102, 45)
        Me.TextModelo.Name = "TextModelo"
        Me.TextModelo.Size = New System.Drawing.Size(241, 20)
        Me.TextModelo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Modelo:"
        '
        'TextSerie
        '
        Me.TextSerie.Location = New System.Drawing.Point(102, 19)
        Me.TextSerie.Name = "TextSerie"
        Me.TextSerie.Size = New System.Drawing.Size(241, 20)
        Me.TextSerie.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Serie:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Numero)
        Me.GroupBox4.Controls.Add(Me.ComboCat)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.TextDescripcion)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(733, 70)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(46, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Item No:"
        '
        'Numero
        '
        Me.Numero.AutoSize = True
        Me.Numero.Location = New System.Drawing.Point(100, 18)
        Me.Numero.Name = "Numero"
        Me.Numero.Size = New System.Drawing.Size(23, 13)
        Me.Numero.TabIndex = 3
        Me.Numero.Text = "♦♦"
        '
        'ComboCat
        '
        Me.ComboCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCat.FormattingEnabled = True
        Me.ComboCat.Location = New System.Drawing.Point(483, 36)
        Me.ComboCat.Name = "ComboCat"
        Me.ComboCat.Size = New System.Drawing.Size(209, 21)
        Me.ComboCat.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(420, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Categoría:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Descripción:"
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(103, 36)
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(241, 20)
        Me.TextDescripcion.TabIndex = 0
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.BtnCancelar.Location = New System.Drawing.Point(542, 290)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 54)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Disar.My.Resources.Resources.img_aceptar
        Me.BtnGuardar.Location = New System.Drawing.Point(623, 290)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 54)
        Me.BtnGuardar.TabIndex = 5
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Location = New System.Drawing.Point(367, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(10, 70)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Location = New System.Drawing.Point(366, -1)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(10, 109)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.ComboEstado)
        Me.GroupBox7.Controls.Add(Me.ComboUbicacion)
        Me.GroupBox7.Controls.Add(Me.Label17)
        Me.GroupBox7.Location = New System.Drawing.Point(382, 195)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(359, 83)
        Me.GroupBox7.TabIndex = 3
        Me.GroupBox7.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(57, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Estado:"
        '
        'ComboEstado
        '
        Me.ComboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEstado.FormattingEnabled = True
        Me.ComboEstado.Items.AddRange(New Object() {"Bueno", "Dañado", "En reparación"})
        Me.ComboEstado.Location = New System.Drawing.Point(106, 18)
        Me.ComboEstado.Name = "ComboEstado"
        Me.ComboEstado.Size = New System.Drawing.Size(209, 21)
        Me.ComboEstado.TabIndex = 0
        '
        'ComboUbicacion
        '
        Me.ComboUbicacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboUbicacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboUbicacion.FormattingEnabled = True
        Me.ComboUbicacion.Location = New System.Drawing.Point(106, 44)
        Me.ComboUbicacion.Name = "ComboUbicacion"
        Me.ComboUbicacion.Size = New System.Drawing.Size(209, 21)
        Me.ComboUbicacion.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(41, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Ubicación:"
        '
        'FrmRegistroRepuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 370)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRegistroRepuestos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Repuestos y Dañados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextDiscoDuro As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextRAM As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextProcesador As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboMarca As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextContacto As System.Windows.Forms.TextBox
    Friend WithEvents TextModelo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Numero As System.Windows.Forms.Label
    Friend WithEvents ComboCat As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ComboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents ComboUbicacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
