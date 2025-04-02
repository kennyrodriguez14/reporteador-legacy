<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Usuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Usuarios))
        Me.gridUsuarios = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnArchivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton
        Me.btnEditar = New System.Windows.Forms.ToolStripButton
        Me.Lista = New System.Windows.Forms.GroupBox
        Me.Editar = New System.Windows.Forms.GroupBox
        Me.txtNumReg = New System.Windows.Forms.TextBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.cmbTipo = New System.Windows.Forms.ComboBox
        Me.cmbEstado = New System.Windows.Forms.ComboBox
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBuscar = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.gridUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Lista.SuspendLayout()
        Me.Editar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridUsuarios
        '
        Me.gridUsuarios.AllowUserToAddRows = False
        Me.gridUsuarios.AllowUserToDeleteRows = False
        Me.gridUsuarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.gridUsuarios.Location = New System.Drawing.Point(3, 49)
        Me.gridUsuarios.Name = "gridUsuarios"
        Me.gridUsuarios.ReadOnly = True
        Me.gridUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridUsuarios.Size = New System.Drawing.Size(587, 317)
        Me.gridUsuarios.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnArchivo, Me.btnNuevo, Me.btnEditar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(620, 39)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnArchivo
        '
        Me.btnArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarToolStripMenuItem})
        Me.btnArchivo.Image = Global.Disar.My.Resources.Resources.Archivo
        Me.btnArchivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnArchivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(93, 36)
        Me.btnArchivo.Text = "Archivo"
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.CerrarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(122, 38)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Disar.My.Resources.Resources.Cliente
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 36)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Disar.My.Resources.Resources.Guardar
        Me.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(73, 36)
        Me.btnEditar.Text = "Editar"
        '
        'Lista
        '
        Me.Lista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lista.Controls.Add(Me.PictureBox1)
        Me.Lista.Controls.Add(Me.Label5)
        Me.Lista.Controls.Add(Me.TextBuscar)
        Me.Lista.Controls.Add(Me.gridUsuarios)
        Me.Lista.Location = New System.Drawing.Point(12, 34)
        Me.Lista.Name = "Lista"
        Me.Lista.Size = New System.Drawing.Size(593, 369)
        Me.Lista.TabIndex = 2
        Me.Lista.TabStop = False
        '
        'Editar
        '
        Me.Editar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Editar.Controls.Add(Me.txtNumReg)
        Me.Editar.Controls.Add(Me.btnCancelar)
        Me.Editar.Controls.Add(Me.btnAceptar)
        Me.Editar.Controls.Add(Me.cmbTipo)
        Me.Editar.Controls.Add(Me.cmbEstado)
        Me.Editar.Controls.Add(Me.txtPass)
        Me.Editar.Controls.Add(Me.txtUser)
        Me.Editar.Controls.Add(Me.Label4)
        Me.Editar.Controls.Add(Me.Label3)
        Me.Editar.Controls.Add(Me.Label2)
        Me.Editar.Controls.Add(Me.Label1)
        Me.Editar.Location = New System.Drawing.Point(168, 123)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(299, 207)
        Me.Editar.TabIndex = 3
        Me.Editar.TabStop = False
        Me.Editar.Visible = False
        '
        'txtNumReg
        '
        Me.txtNumReg.Location = New System.Drawing.Point(265, 169)
        Me.txtNumReg.Name = "txtNumReg"
        Me.txtNumReg.Size = New System.Drawing.Size(28, 20)
        Me.txtNumReg.TabIndex = 7
        Me.txtNumReg.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(184, 166)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(81, 166)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"Administrador", "Jefe", "Colaborador", "Contabilidad", "Saldos"})
        Me.cmbTipo.Location = New System.Drawing.Point(80, 126)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(194, 21)
        Me.cmbTipo.TabIndex = 4
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Bloqueado"})
        Me.cmbEstado.Location = New System.Drawing.Point(80, 89)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(194, 21)
        Me.cmbEstado.TabIndex = 3
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(81, 54)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(193, 20)
        Me.txtPass.TabIndex = 2
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(81, 19)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(193, 20)
        Me.txtUser.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tipo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Estado:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contraseña:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario:"
        '
        'TextBuscar
        '
        Me.TextBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBuscar.Location = New System.Drawing.Point(340, 19)
        Me.TextBuscar.Name = "TextBuscar"
        Me.TextBuscar.Size = New System.Drawing.Size(247, 20)
        Me.TextBuscar.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(295, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Buscar:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Disar.My.Resources.Resources.lupa
        Me.PictureBox1.Location = New System.Drawing.Point(557, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 409)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Editar)
        Me.Controls.Add(Me.Lista)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        CType(Me.gridUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Lista.ResumeLayout(False)
        Me.Lista.PerformLayout()
        Me.Editar.ResumeLayout(False)
        Me.Editar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnArchivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Lista As System.Windows.Forms.GroupBox
    Friend WithEvents Editar As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtNumReg As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
