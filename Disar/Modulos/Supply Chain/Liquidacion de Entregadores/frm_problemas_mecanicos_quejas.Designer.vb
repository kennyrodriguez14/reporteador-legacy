<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_problemas_mecanicos_quejas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_problemas_mecanicos_quejas))
        Me.Label1 = New System.Windows.Forms.Label
        Me.RadioProblema = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.RadioQueja = New System.Windows.Forms.RadioButton
        Me.Queja = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnEnviar = New System.Windows.Forms.Button
        Me.labelVehiculo = New System.Windows.Forms.Label
        Me.Vehiculo = New System.Windows.Forms.TextBox
        Me.PictureFotos = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureFotos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(295, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo"
        '
        'RadioProblema
        '
        Me.RadioProblema.AutoSize = True
        Me.RadioProblema.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioProblema.Location = New System.Drawing.Point(59, 25)
        Me.RadioProblema.Name = "RadioProblema"
        Me.RadioProblema.Size = New System.Drawing.Size(183, 24)
        Me.RadioProblema.TabIndex = 1
        Me.RadioProblema.TabStop = True
        Me.RadioProblema.Text = "Problema Mecánico"
        Me.RadioProblema.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.RadioQueja)
        Me.GroupBox1.Controls.Add(Me.RadioProblema)
        Me.GroupBox1.Location = New System.Drawing.Point(289, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(413, 69)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(257, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 37)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "/"
        '
        'RadioQueja
        '
        Me.RadioQueja.AutoSize = True
        Me.RadioQueja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioQueja.Location = New System.Drawing.Point(303, 25)
        Me.RadioQueja.Name = "RadioQueja"
        Me.RadioQueja.Size = New System.Drawing.Size(74, 24)
        Me.RadioQueja.TabIndex = 2
        Me.RadioQueja.TabStop = True
        Me.RadioQueja.Text = "Queja"
        Me.RadioQueja.UseVisualStyleBackColor = True
        '
        'Queja
        '
        Me.Queja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Queja.Location = New System.Drawing.Point(299, 244)
        Me.Queja.Multiline = True
        Me.Queja.Name = "Queja"
        Me.Queja.Size = New System.Drawing.Size(403, 139)
        Me.Queja.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(295, 221)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(249, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Explique su problema o queja:"
        '
        'BtnEnviar
        '
        Me.BtnEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEnviar.Location = New System.Drawing.Point(627, 405)
        Me.BtnEnviar.Name = "BtnEnviar"
        Me.BtnEnviar.Size = New System.Drawing.Size(75, 37)
        Me.BtnEnviar.TabIndex = 5
        Me.BtnEnviar.Text = "Enviar"
        Me.BtnEnviar.UseVisualStyleBackColor = True
        '
        'labelVehiculo
        '
        Me.labelVehiculo.AutoSize = True
        Me.labelVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelVehiculo.Location = New System.Drawing.Point(295, 168)
        Me.labelVehiculo.Name = "labelVehiculo"
        Me.labelVehiculo.Size = New System.Drawing.Size(83, 20)
        Me.labelVehiculo.TabIndex = 6
        Me.labelVehiculo.Text = "Vehículo:"
        '
        'Vehiculo
        '
        Me.Vehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vehiculo.Location = New System.Drawing.Point(384, 166)
        Me.Vehiculo.Name = "Vehiculo"
        Me.Vehiculo.Size = New System.Drawing.Size(318, 22)
        Me.Vehiculo.TabIndex = 7
        '
        'PictureFotos
        '
        Me.PictureFotos.Image = Global.Disar.My.Resources.Resources.Sin_Imagen
        Me.PictureFotos.Location = New System.Drawing.Point(971, 455)
        Me.PictureFotos.Name = "PictureFotos"
        Me.PictureFotos.Size = New System.Drawing.Size(11, 10)
        Me.PictureFotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureFotos.TabIndex = 23
        Me.PictureFotos.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(718, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(264, 39)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Si envía un problema mecánico se enviará una" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "solicitud por correo al departament" & _
            "o de mantenimiento " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "para que se revise el desperfecto."
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(299, 405)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 37)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm_problemas_mecanicos_quejas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(994, 477)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureFotos)
        Me.Controls.Add(Me.Vehiculo)
        Me.Controls.Add(Me.labelVehiculo)
        Me.Controls.Add(Me.BtnEnviar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Queja)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_problemas_mecanicos_quejas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Problemas Mecánicos / Quejas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureFotos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioProblema As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioQueja As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Queja As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnEnviar As System.Windows.Forms.Button
    Friend WithEvents labelVehiculo As System.Windows.Forms.Label
    Friend WithEvents Vehiculo As System.Windows.Forms.TextBox
    Friend WithEvents PictureFotos As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
