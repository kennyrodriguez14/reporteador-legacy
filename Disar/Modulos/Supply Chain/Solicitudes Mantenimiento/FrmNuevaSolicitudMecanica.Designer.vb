<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNuevaSolicitudMecanica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNuevaSolicitudMecanica))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.BtnGuarda = New System.Windows.Forms.Button
        Me.TextEnvio = New System.Windows.Forms.TextBox
        Me.btnBuscaFotografías = New System.Windows.Forms.Button
        Me.PictureFotos = New System.Windows.Forms.PictureBox
        Me.TextSolicitud = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupVehiculo = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboVehiculo = New System.Windows.Forms.ComboBox
        Me.ComboEnregador = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Dialog = New System.Windows.Forms.OpenFileDialog
        Me._txtPort = New System.Windows.Forms.TextBox
        Me._txtServer = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me._txtReceptor = New System.Windows.Forms.TextBox
        Me._txtPass = New System.Windows.Forms.TextBox
        Me._lblemisor = New System.Windows.Forms.Label
        Me._txtEmisor = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureFotos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupVehiculo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.BtnGuarda)
        Me.GroupBox1.Controls.Add(Me.TextEnvio)
        Me.GroupBox1.Controls.Add(Me.btnBuscaFotografías)
        Me.GroupBox1.Controls.Add(Me.PictureFotos)
        Me.GroupBox1.Controls.Add(Me.TextSolicitud)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.GroupVehiculo)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(416, 391)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Tipo de solicitud:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"General", "Vehicular"})
        Me.ComboBox1.Location = New System.Drawing.Point(119, 15)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(271, 21)
        Me.ComboBox1.TabIndex = 10
        '
        'BtnGuarda
        '
        Me.BtnGuarda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuarda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuarda.Image = Global.Disar.My.Resources.Resources.img_aceptar
        Me.BtnGuarda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuarda.Location = New System.Drawing.Point(248, 331)
        Me.BtnGuarda.Name = "BtnGuarda"
        Me.BtnGuarda.Size = New System.Drawing.Size(142, 42)
        Me.BtnGuarda.TabIndex = 25
        Me.BtnGuarda.Text = "Enviar Solicitud"
        Me.BtnGuarda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuarda.UseVisualStyleBackColor = True
        '
        'TextEnvio
        '
        Me.TextEnvio.Location = New System.Drawing.Point(156, 255)
        Me.TextEnvio.Multiline = True
        Me.TextEnvio.Name = "TextEnvio"
        Me.TextEnvio.Size = New System.Drawing.Size(234, 51)
        Me.TextEnvio.TabIndex = 24
        Me.TextEnvio.Text = "Departamento de Mantenimiento" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnBuscaFotografías
        '
        Me.btnBuscaFotografías.Location = New System.Drawing.Point(29, 229)
        Me.btnBuscaFotografías.Name = "btnBuscaFotografías"
        Me.btnBuscaFotografías.Size = New System.Drawing.Size(108, 23)
        Me.btnBuscaFotografías.TabIndex = 23
        Me.btnBuscaFotografías.Text = "Carga Imagen"
        Me.btnBuscaFotografías.UseVisualStyleBackColor = True
        '
        'PictureFotos
        '
        Me.PictureFotos.Image = Global.Disar.My.Resources.Resources.Sin_Imagen
        Me.PictureFotos.Location = New System.Drawing.Point(29, 259)
        Me.PictureFotos.Name = "PictureFotos"
        Me.PictureFotos.Size = New System.Drawing.Size(108, 114)
        Me.PictureFotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureFotos.TabIndex = 22
        Me.PictureFotos.TabStop = False
        '
        'TextSolicitud
        '
        Me.TextSolicitud.Location = New System.Drawing.Point(29, 139)
        Me.TextSolicitud.Multiline = True
        Me.TextSolicitud.Name = "TextSolicitud"
        Me.TextSolicitud.Size = New System.Drawing.Size(361, 81)
        Me.TextSolicitud.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(153, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Enviar a:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Descripción de la solicitud:"
        '
        'GroupVehiculo
        '
        Me.GroupVehiculo.Controls.Add(Me.Label1)
        Me.GroupVehiculo.Controls.Add(Me.ComboVehiculo)
        Me.GroupVehiculo.Controls.Add(Me.ComboEnregador)
        Me.GroupVehiculo.Controls.Add(Me.Label2)
        Me.GroupVehiculo.Location = New System.Drawing.Point(6, 39)
        Me.GroupVehiculo.Name = "GroupVehiculo"
        Me.GroupVehiculo.Size = New System.Drawing.Size(404, 76)
        Me.GroupVehiculo.TabIndex = 26
        Me.GroupVehiculo.TabStop = False
        Me.GroupVehiculo.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Vehículo:"
        '
        'ComboVehiculo
        '
        Me.ComboVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVehiculo.FormattingEnabled = True
        Me.ComboVehiculo.Location = New System.Drawing.Point(88, 15)
        Me.ComboVehiculo.Name = "ComboVehiculo"
        Me.ComboVehiculo.Size = New System.Drawing.Size(296, 21)
        Me.ComboVehiculo.TabIndex = 10
        '
        'ComboEnregador
        '
        Me.ComboEnregador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEnregador.FormattingEnabled = True
        Me.ComboEnregador.Location = New System.Drawing.Point(88, 42)
        Me.ComboEnregador.Name = "ComboEnregador"
        Me.ComboEnregador.Size = New System.Drawing.Size(296, 21)
        Me.ComboEnregador.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Entregador:"
        '
        'Dialog
        '
        Me.Dialog.Filter = "Todos los archivos de Imagen|(*.jpg;*.PNG;*.JPG;*.JPEG;*.GIF;*.png;)"
        Me.Dialog.InitialDirectory = "C:\\"
        Me.Dialog.Title = "Seleccionar Documentos de Respaldo..."
        '
        '_txtPort
        '
        Me._txtPort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me._txtPort.Enabled = False
        Me._txtPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPort.Location = New System.Drawing.Point(358, 135)
        Me._txtPort.Name = "_txtPort"
        Me._txtPort.Size = New System.Drawing.Size(36, 22)
        Me._txtPort.TabIndex = 17
        Me._txtPort.Text = "26"
        '
        '_txtServer
        '
        Me._txtServer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me._txtServer.Enabled = False
        Me._txtServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtServer.Location = New System.Drawing.Point(193, 137)
        Me._txtServer.Name = "_txtServer"
        Me._txtServer.Size = New System.Drawing.Size(116, 22)
        Me._txtServer.TabIndex = 16
        Me._txtServer.Text = "mail.disarhn.com"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(119, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Servidor:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(315, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Puerto:"
        '
        '_txtReceptor
        '
        Me._txtReceptor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me._txtReceptor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtReceptor.Location = New System.Drawing.Point(193, 266)
        Me._txtReceptor.Name = "_txtReceptor"
        Me._txtReceptor.Size = New System.Drawing.Size(207, 22)
        Me._txtReceptor.TabIndex = 20
        '
        '_txtPass
        '
        Me._txtPass.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me._txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPass.Location = New System.Drawing.Point(195, 210)
        Me._txtPass.Name = "_txtPass"
        Me._txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me._txtPass.Size = New System.Drawing.Size(207, 22)
        Me._txtPass.TabIndex = 19
        Me._txtPass.Text = "talento123"
        '
        '_lblemisor
        '
        Me._lblemisor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me._lblemisor.AutoSize = True
        Me._lblemisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblemisor.Location = New System.Drawing.Point(152, 177)
        Me._lblemisor.Name = "_lblemisor"
        Me._lblemisor.Size = New System.Drawing.Size(29, 16)
        Me._lblemisor.TabIndex = 12
        Me._lblemisor.Text = "De:"
        '
        '_txtEmisor
        '
        Me._txtEmisor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me._txtEmisor.Enabled = False
        Me._txtEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtEmisor.Location = New System.Drawing.Point(187, 176)
        Me._txtEmisor.Name = "_txtEmisor"
        Me._txtEmisor.Size = New System.Drawing.Size(207, 22)
        Me._txtEmisor.TabIndex = 18
        Me._txtEmisor.Text = "talento.humano@disarhn.com"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(109, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Contraseña:"
        '
        'FrmNuevaSolicitudMecanica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 416)
        Me.Controls.Add(Me._txtPort)
        Me.Controls.Add(Me._txtServer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me._txtReceptor)
        Me.Controls.Add(Me._txtPass)
        Me.Controls.Add(Me._lblemisor)
        Me.Controls.Add(Me._txtEmisor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmNuevaSolicitudMecanica"
        Me.Text = "Nueva Solicitud de Servicio Para Vehículo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureFotos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupVehiculo.ResumeLayout(False)
        Me.GroupVehiculo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboEnregador As System.Windows.Forms.ComboBox
    Friend WithEvents TextSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaFotografías As System.Windows.Forms.Button
    Friend WithEvents PictureFotos As System.Windows.Forms.PictureBox
    Friend WithEvents TextEnvio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnGuarda As System.Windows.Forms.Button
    Friend WithEvents Dialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents _txtPort As System.Windows.Forms.TextBox
    Friend WithEvents _txtServer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents _txtReceptor As System.Windows.Forms.TextBox
    Friend WithEvents _txtPass As System.Windows.Forms.TextBox
    Friend WithEvents _lblemisor As System.Windows.Forms.Label
    Friend WithEvents _txtEmisor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupVehiculo As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
