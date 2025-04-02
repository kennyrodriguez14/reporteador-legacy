<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarContraseña
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambiarContraseña))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtPasAnt = New System.Windows.Forms.TextBox
        Me.txtPass1 = New System.Windows.Forms.TextBox
        Me.txtPass2 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Contraseña Anterior:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contraseña Nueva:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Confirmar Contraseña:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(44, 98)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(215, 98)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtPasAnt
        '
        Me.txtPasAnt.Location = New System.Drawing.Point(125, 9)
        Me.txtPasAnt.Name = "txtPasAnt"
        Me.txtPasAnt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasAnt.Size = New System.Drawing.Size(165, 20)
        Me.txtPasAnt.TabIndex = 1
        '
        'txtPass1
        '
        Me.txtPass1.Location = New System.Drawing.Point(125, 38)
        Me.txtPass1.Name = "txtPass1"
        Me.txtPass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass1.Size = New System.Drawing.Size(165, 20)
        Me.txtPass1.TabIndex = 2
        '
        'txtPass2
        '
        Me.txtPass2.Location = New System.Drawing.Point(125, 66)
        Me.txtPass2.Name = "txtPass2"
        Me.txtPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass2.Size = New System.Drawing.Size(165, 20)
        Me.txtPass2.TabIndex = 3
        '
        'CambiarContraseña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(305, 133)
        Me.Controls.Add(Me.txtPass2)
        Me.Controls.Add(Me.txtPass1)
        Me.Controls.Add(Me.txtPasAnt)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CambiarContraseña"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar Contraseña"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtPasAnt As System.Windows.Forms.TextBox
    Friend WithEvents txtPass1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPass2 As System.Windows.Forms.TextBox
End Class
