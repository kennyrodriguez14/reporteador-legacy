<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Correo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Correo))
        Me._lblemisor = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me._gbMail = New System.Windows.Forms.GroupBox
        Me._txtmsj = New System.Windows.Forms.RichTextBox
        Me._btnCancelar = New System.Windows.Forms.Button
        Me._btnEnviar = New System.Windows.Forms.Button
        Me._txtAsunto = New System.Windows.Forms.TextBox
        Me._txtReceptor = New System.Windows.Forms.TextBox
        Me._txtPass = New System.Windows.Forms.TextBox
        Me._txtEmisor = New System.Windows.Forms.TextBox
        Me._txtPort = New System.Windows.Forms.TextBox
        Me._txtServer = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me._gbMail.SuspendLayout()
        Me.SuspendLayout()
        '
        '_lblemisor
        '
        Me._lblemisor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._lblemisor.AutoSize = True
        Me._lblemisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblemisor.Location = New System.Drawing.Point(59, 65)
        Me._lblemisor.Name = "_lblemisor"
        Me._lblemisor.Size = New System.Drawing.Size(29, 16)
        Me._lblemisor.TabIndex = 0
        Me._lblemisor.Text = "De:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Para:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contraseña:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Servidor:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(214, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Puerto:"
        '
        '_gbMail
        '
        Me._gbMail.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._gbMail.Controls.Add(Me._txtmsj)
        Me._gbMail.Controls.Add(Me._btnCancelar)
        Me._gbMail.Controls.Add(Me._btnEnviar)
        Me._gbMail.Controls.Add(Me._txtAsunto)
        Me._gbMail.Controls.Add(Me._txtReceptor)
        Me._gbMail.Controls.Add(Me._txtPass)
        Me._gbMail.Controls.Add(Me._txtEmisor)
        Me._gbMail.Controls.Add(Me._txtPort)
        Me._gbMail.Controls.Add(Me._txtServer)
        Me._gbMail.Controls.Add(Me.Label6)
        Me._gbMail.Controls.Add(Me.Label5)
        Me._gbMail.Controls.Add(Me.Label3)
        Me._gbMail.Controls.Add(Me.Label4)
        Me._gbMail.Controls.Add(Me.Label2)
        Me._gbMail.Controls.Add(Me._lblemisor)
        Me._gbMail.Controls.Add(Me.Label1)
        Me._gbMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbMail.Location = New System.Drawing.Point(10, 2)
        Me._gbMail.Name = "_gbMail"
        Me._gbMail.Size = New System.Drawing.Size(323, 318)
        Me._gbMail.TabIndex = 5
        Me._gbMail.TabStop = False
        Me._gbMail.Text = "Datos"
        '
        '_txtmsj
        '
        Me._txtmsj.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._txtmsj.Location = New System.Drawing.Point(94, 211)
        Me._txtmsj.Name = "_txtmsj"
        Me._txtmsj.Size = New System.Drawing.Size(207, 66)
        Me._txtmsj.TabIndex = 16
        Me._txtmsj.Text = "Adjunto Archivo" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        '_btnCancelar
        '
        Me._btnCancelar.Location = New System.Drawing.Point(174, 285)
        Me._btnCancelar.Name = "_btnCancelar"
        Me._btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me._btnCancelar.TabIndex = 15
        Me._btnCancelar.Text = "Cancelar"
        Me._btnCancelar.UseVisualStyleBackColor = True
        '
        '_btnEnviar
        '
        Me._btnEnviar.Location = New System.Drawing.Point(51, 285)
        Me._btnEnviar.Name = "_btnEnviar"
        Me._btnEnviar.Size = New System.Drawing.Size(75, 23)
        Me._btnEnviar.TabIndex = 14
        Me._btnEnviar.Text = "Enviar"
        Me._btnEnviar.UseVisualStyleBackColor = True
        '
        '_txtAsunto
        '
        Me._txtAsunto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._txtAsunto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtAsunto.Location = New System.Drawing.Point(94, 174)
        Me._txtAsunto.Name = "_txtAsunto"
        Me._txtAsunto.Size = New System.Drawing.Size(207, 22)
        Me._txtAsunto.TabIndex = 12
        '
        '_txtReceptor
        '
        Me._txtReceptor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._txtReceptor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtReceptor.Location = New System.Drawing.Point(94, 137)
        Me._txtReceptor.Name = "_txtReceptor"
        Me._txtReceptor.Size = New System.Drawing.Size(207, 22)
        Me._txtReceptor.TabIndex = 11
        '
        '_txtPass
        '
        Me._txtPass.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPass.Location = New System.Drawing.Point(94, 99)
        Me._txtPass.Name = "_txtPass"
        Me._txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me._txtPass.Size = New System.Drawing.Size(207, 22)
        Me._txtPass.TabIndex = 10
        '
        '_txtEmisor
        '
        Me._txtEmisor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._txtEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtEmisor.Location = New System.Drawing.Point(94, 64)
        Me._txtEmisor.Name = "_txtEmisor"
        Me._txtEmisor.Size = New System.Drawing.Size(207, 22)
        Me._txtEmisor.TabIndex = 9
        Me._txtEmisor.Text = "departamento.it@disarhn.com"
        '
        '_txtPort
        '
        Me._txtPort.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._txtPort.Enabled = False
        Me._txtPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtPort.Location = New System.Drawing.Point(265, 31)
        Me._txtPort.Name = "_txtPort"
        Me._txtPort.Size = New System.Drawing.Size(36, 22)
        Me._txtPort.TabIndex = 8
        Me._txtPort.Text = "26"
        '
        '_txtServer
        '
        Me._txtServer.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._txtServer.Enabled = False
        Me._txtServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtServer.Location = New System.Drawing.Point(94, 31)
        Me._txtServer.Name = "_txtServer"
        Me._txtServer.Size = New System.Drawing.Size(116, 22)
        Me._txtServer.TabIndex = 7
        Me._txtServer.Text = "mail.disarhn.com"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Mensaje:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(36, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Asunto:"
        '
        'Correo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 322)
        Me.Controls.Add(Me._gbMail)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Correo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Correo"
        Me._gbMail.ResumeLayout(False)
        Me._gbMail.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _lblemisor As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents _gbMail As System.Windows.Forms.GroupBox
    Friend WithEvents _btnCancelar As System.Windows.Forms.Button
    Friend WithEvents _btnEnviar As System.Windows.Forms.Button
    Friend WithEvents _txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents _txtReceptor As System.Windows.Forms.TextBox
    Friend WithEvents _txtPass As System.Windows.Forms.TextBox
    Friend WithEvents _txtEmisor As System.Windows.Forms.TextBox
    Friend WithEvents _txtPort As System.Windows.Forms.TextBox
    Friend WithEvents _txtServer As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents _txtmsj As System.Windows.Forms.RichTextBox
End Class
