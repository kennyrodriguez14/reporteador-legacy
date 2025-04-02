<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configuracion))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Server = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pass = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnCambiar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.lblServer = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.lblPass = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me._grpDatos = New System.Windows.Forms.GroupBox
        Me.lblsrc = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblsps = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.lblContra = New System.Windows.Forms.Label
        Me.TextBox9 = New System.Windows.Forms.TextBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sucursal, Me.Server, Me.BD, Me.User, Me.Pass})
        Me.DataGridView1.Location = New System.Drawing.Point(7, 198)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(497, 128)
        Me.DataGridView1.TabIndex = 0
        '
        'Sucursal
        '
        Me.Sucursal.HeaderText = "Sucursal"
        Me.Sucursal.Name = "Sucursal"
        Me.Sucursal.ReadOnly = True
        '
        'Server
        '
        Me.Server.HeaderText = "Server"
        Me.Server.Name = "Server"
        Me.Server.ReadOnly = True
        '
        'BD
        '
        Me.BD.HeaderText = "BD"
        Me.BD.Name = "BD"
        Me.BD.ReadOnly = True
        '
        'User
        '
        Me.User.HeaderText = "User"
        Me.User.Name = "User"
        Me.User.ReadOnly = True
        '
        'Pass
        '
        Me.Pass.HeaderText = "Pass"
        Me.Pass.Name = "Pass"
        Me.Pass.ReadOnly = True
        '
        'btnCambiar
        '
        Me.btnCambiar.Location = New System.Drawing.Point(296, 7)
        Me.btnCambiar.Name = "btnCambiar"
        Me.btnCambiar.Size = New System.Drawing.Size(75, 23)
        Me.btnCambiar.TabIndex = 1
        Me.btnCambiar.Text = "Cambiar"
        Me.btnCambiar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Location = New System.Drawing.Point(429, 7)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(22, 34)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(41, 13)
        Me.lblServer.TabIndex = 3
        Me.lblServer.Text = "Server:"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(31, 94)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(32, 13)
        Me.lblUser.TabIndex = 4
        Me.lblUser.Text = "User:"
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Location = New System.Drawing.Point(4, 64)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(59, 13)
        Me.lblPass.TabIndex = 5
        Me.lblPass.Text = "PassWord:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "BD:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(67, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(170, 20)
        Me.TextBox1.TabIndex = 7
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(67, 61)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(170, 20)
        Me.TextBox2.TabIndex = 8
        '
        '_grpDatos
        '
        Me._grpDatos.Controls.Add(Me.lblsrc)
        Me._grpDatos.Controls.Add(Me.TextBox5)
        Me._grpDatos.Controls.Add(Me.TextBox6)
        Me._grpDatos.Controls.Add(Me.TextBox7)
        Me._grpDatos.Controls.Add(Me.Label3)
        Me._grpDatos.Controls.Add(Me.Label4)
        Me._grpDatos.Controls.Add(Me.Label5)
        Me._grpDatos.Controls.Add(Me.TextBox8)
        Me._grpDatos.Controls.Add(Me.Label6)
        Me._grpDatos.Controls.Add(Me.lblsps)
        Me._grpDatos.Controls.Add(Me.TextBox4)
        Me._grpDatos.Controls.Add(Me.TextBox3)
        Me._grpDatos.Controls.Add(Me.TextBox2)
        Me._grpDatos.Controls.Add(Me.Label1)
        Me._grpDatos.Controls.Add(Me.lblUser)
        Me._grpDatos.Controls.Add(Me.lblServer)
        Me._grpDatos.Controls.Add(Me.TextBox1)
        Me._grpDatos.Controls.Add(Me.lblPass)
        Me._grpDatos.Location = New System.Drawing.Point(7, 42)
        Me._grpDatos.Name = "_grpDatos"
        Me._grpDatos.Size = New System.Drawing.Size(497, 150)
        Me._grpDatos.TabIndex = 9
        Me._grpDatos.TabStop = False
        Me._grpDatos.Text = "Datos"
        Me._grpDatos.Visible = False
        '
        'lblsrc
        '
        Me.lblsrc.AutoSize = True
        Me.lblsrc.Location = New System.Drawing.Point(373, 10)
        Me.lblsrc.Name = "lblsrc"
        Me.lblsrc.Size = New System.Drawing.Size(29, 13)
        Me.lblsrc.TabIndex = 20
        Me.lblsrc.Text = "SRC"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(315, 118)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(170, 20)
        Me.TextBox5.TabIndex = 19
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(315, 89)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(170, 20)
        Me.TextBox6.TabIndex = 18
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(315, 60)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox7.Size = New System.Drawing.Size(170, 20)
        Me.TextBox7.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(286, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "BD:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(279, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "User:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(270, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Server:"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(315, 31)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(170, 20)
        Me.TextBox8.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(252, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "PassWord:"
        '
        'lblsps
        '
        Me.lblsps.AutoSize = True
        Me.lblsps.Location = New System.Drawing.Point(125, 11)
        Me.lblsps.Name = "lblsps"
        Me.lblsps.Size = New System.Drawing.Size(28, 13)
        Me.lblsps.TabIndex = 11
        Me.lblsps.Text = "SPS"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(67, 119)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(170, 20)
        Me.TextBox4.TabIndex = 10
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(67, 90)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(170, 20)
        Me.TextBox3.TabIndex = 9
        '
        'lblContra
        '
        Me.lblContra.AutoSize = True
        Me.lblContra.Location = New System.Drawing.Point(12, 12)
        Me.lblContra.Name = "lblContra"
        Me.lblContra.Size = New System.Drawing.Size(102, 13)
        Me.lblContra.TabIndex = 10
        Me.lblContra.Text = "Ingrese Contraseña:"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(120, 9)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox9.Size = New System.Drawing.Size(160, 20)
        Me.TextBox9.TabIndex = 11
        '
        'Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 334)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.lblContra)
        Me.Controls.Add(Me._grpDatos)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCambiar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Configuracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuracion"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me._grpDatos.ResumeLayout(False)
        Me._grpDatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnCambiar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents _grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblsps As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents lblsrc As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblContra As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Sucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Server As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents User As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pass As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
