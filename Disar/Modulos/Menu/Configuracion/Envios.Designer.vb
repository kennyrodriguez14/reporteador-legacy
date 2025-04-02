<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Envios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Envios))
        Me.GridEnvios = New System.Windows.Forms.DataGridView
        Me.Grid = New System.Windows.Forms.GroupBox
        Me.Modificar = New System.Windows.Forms.GroupBox
        Me.Datos = New System.Windows.Forms.GroupBox
        Me.txtContraseña = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEmisor = New System.Windows.Forms.TextBox
        Me.cmbEstado = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDias = New System.Windows.Forms.TextBox
        Me.txtDescripcion = New System.Windows.Forms.RichTextBox
        Me.txtHora = New System.Windows.Forms.TextBox
        Me.txtMensaje = New System.Windows.Forms.RichTextBox
        Me.txtCopia = New System.Windows.Forms.RichTextBox
        Me.txtReceptor = New System.Windows.Forms.RichTextBox
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.txtReporte = New System.Windows.Forms.TextBox
        Me.txtFormu = New System.Windows.Forms.TextBox
        Me.txtAsunto = New System.Windows.Forms.TextBox
        Me.txtId = New System.Windows.Forms.TextBox
        Me.lblPuerto = New System.Windows.Forms.Label
        Me.lblServidor = New System.Windows.Forms.Label
        Me.lblDiasEnvio = New System.Windows.Forms.Label
        Me.lblDescripcion = New System.Windows.Forms.Label
        Me.lblHora = New System.Windows.Forms.Label
        Me.lblMensaje = New System.Windows.Forms.Label
        Me.lblAsunto = New System.Windows.Forms.Label
        Me.lblCopia = New System.Windows.Forms.Label
        Me.lblRecibe = New System.Windows.Forms.Label
        Me.lblEnvia = New System.Windows.Forms.Label
        Me.lblReporte = New System.Windows.Forms.Label
        Me.lblFormulario = New System.Windows.Forms.Label
        Me.lblId = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnModificar = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnArchivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnAtras = New System.Windows.Forms.Button
        CType(Me.GridEnvios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grid.SuspendLayout()
        Me.Modificar.SuspendLayout()
        Me.Datos.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridEnvios
        '
        Me.GridEnvios.AllowUserToAddRows = False
        Me.GridEnvios.AllowUserToDeleteRows = False
        Me.GridEnvios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridEnvios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridEnvios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridEnvios.Location = New System.Drawing.Point(3, 16)
        Me.GridEnvios.Name = "GridEnvios"
        Me.GridEnvios.ReadOnly = True
        Me.GridEnvios.Size = New System.Drawing.Size(530, 378)
        Me.GridEnvios.TabIndex = 1
        '
        'Grid
        '
        Me.Grid.Controls.Add(Me.GridEnvios)
        Me.Grid.Location = New System.Drawing.Point(13, 47)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(536, 397)
        Me.Grid.TabIndex = 2
        Me.Grid.TabStop = False
        Me.Grid.Text = "Datos"
        '
        'Modificar
        '
        Me.Modificar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Modificar.Controls.Add(Me.btnAtras)
        Me.Modificar.Controls.Add(Me.Datos)
        Me.Modificar.Controls.Add(Me.btnCancelar)
        Me.Modificar.Controls.Add(Me.btnAceptar)
        Me.Modificar.Controls.Add(Me.btnModificar)
        Me.Modificar.Location = New System.Drawing.Point(14, 44)
        Me.Modificar.Name = "Modificar"
        Me.Modificar.Size = New System.Drawing.Size(535, 400)
        Me.Modificar.TabIndex = 3
        Me.Modificar.TabStop = False
        Me.Modificar.Text = "Actualizar"
        Me.Modificar.Visible = False
        '
        'Datos
        '
        Me.Datos.Controls.Add(Me.txtContraseña)
        Me.Datos.Controls.Add(Me.Label2)
        Me.Datos.Controls.Add(Me.txtEmisor)
        Me.Datos.Controls.Add(Me.cmbEstado)
        Me.Datos.Controls.Add(Me.Label1)
        Me.Datos.Controls.Add(Me.txtDias)
        Me.Datos.Controls.Add(Me.txtDescripcion)
        Me.Datos.Controls.Add(Me.txtHora)
        Me.Datos.Controls.Add(Me.txtMensaje)
        Me.Datos.Controls.Add(Me.txtCopia)
        Me.Datos.Controls.Add(Me.txtReceptor)
        Me.Datos.Controls.Add(Me.txtPort)
        Me.Datos.Controls.Add(Me.txtServer)
        Me.Datos.Controls.Add(Me.txtReporte)
        Me.Datos.Controls.Add(Me.txtFormu)
        Me.Datos.Controls.Add(Me.txtAsunto)
        Me.Datos.Controls.Add(Me.txtId)
        Me.Datos.Controls.Add(Me.lblPuerto)
        Me.Datos.Controls.Add(Me.lblServidor)
        Me.Datos.Controls.Add(Me.lblDiasEnvio)
        Me.Datos.Controls.Add(Me.lblDescripcion)
        Me.Datos.Controls.Add(Me.lblHora)
        Me.Datos.Controls.Add(Me.lblMensaje)
        Me.Datos.Controls.Add(Me.lblAsunto)
        Me.Datos.Controls.Add(Me.lblCopia)
        Me.Datos.Controls.Add(Me.lblRecibe)
        Me.Datos.Controls.Add(Me.lblEnvia)
        Me.Datos.Controls.Add(Me.lblReporte)
        Me.Datos.Controls.Add(Me.lblFormulario)
        Me.Datos.Controls.Add(Me.lblId)
        Me.Datos.Enabled = False
        Me.Datos.Location = New System.Drawing.Point(7, 18)
        Me.Datos.Name = "Datos"
        Me.Datos.Size = New System.Drawing.Size(519, 343)
        Me.Datos.TabIndex = 34
        Me.Datos.TabStop = False
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(370, 94)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseña.Size = New System.Drawing.Size(137, 20)
        Me.txtContraseña.TabIndex = 64
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(308, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Contraseña:"
        '
        'txtEmisor
        '
        Me.txtEmisor.Location = New System.Drawing.Point(89, 94)
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.Size = New System.Drawing.Size(213, 20)
        Me.txtEmisor.TabIndex = 62
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Inactivo"})
        Me.cmbEstado.Location = New System.Drawing.Point(415, 15)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(92, 21)
        Me.cmbEstado.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(374, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Estado:"
        '
        'txtDias
        '
        Me.txtDias.Location = New System.Drawing.Point(271, 311)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(236, 20)
        Me.txtDias.TabIndex = 59
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(89, 268)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(418, 34)
        Me.txtDescripcion.TabIndex = 58
        Me.txtDescripcion.Text = ""
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(89, 311)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(87, 20)
        Me.txtHora.TabIndex = 57
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(89, 228)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(418, 34)
        Me.txtMensaje.TabIndex = 56
        Me.txtMensaje.Text = ""
        '
        'txtCopia
        '
        Me.txtCopia.Location = New System.Drawing.Point(89, 162)
        Me.txtCopia.Name = "txtCopia"
        Me.txtCopia.Size = New System.Drawing.Size(418, 34)
        Me.txtCopia.TabIndex = 55
        Me.txtCopia.Text = ""
        '
        'txtReceptor
        '
        Me.txtReceptor.Location = New System.Drawing.Point(89, 122)
        Me.txtReceptor.Name = "txtReceptor"
        Me.txtReceptor.Size = New System.Drawing.Size(418, 34)
        Me.txtReceptor.TabIndex = 54
        Me.txtReceptor.Text = ""
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(339, 16)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(32, 20)
        Me.txtPort.TabIndex = 53
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(171, 16)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(127, 20)
        Me.txtServer.TabIndex = 52
        '
        'txtReporte
        '
        Me.txtReporte.Location = New System.Drawing.Point(89, 68)
        Me.txtReporte.Name = "txtReporte"
        Me.txtReporte.Size = New System.Drawing.Size(418, 20)
        Me.txtReporte.TabIndex = 51
        '
        'txtFormu
        '
        Me.txtFormu.Location = New System.Drawing.Point(89, 42)
        Me.txtFormu.Name = "txtFormu"
        Me.txtFormu.Size = New System.Drawing.Size(418, 20)
        Me.txtFormu.TabIndex = 49
        '
        'txtAsunto
        '
        Me.txtAsunto.Location = New System.Drawing.Point(89, 202)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(418, 20)
        Me.txtAsunto.TabIndex = 48
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(89, 16)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(32, 20)
        Me.txtId.TabIndex = 47
        '
        'lblPuerto
        '
        Me.lblPuerto.AutoSize = True
        Me.lblPuerto.Location = New System.Drawing.Point(299, 19)
        Me.lblPuerto.Name = "lblPuerto"
        Me.lblPuerto.Size = New System.Drawing.Size(41, 13)
        Me.lblPuerto.TabIndex = 46
        Me.lblPuerto.Text = "Puerto:"
        '
        'lblServidor
        '
        Me.lblServidor.AutoSize = True
        Me.lblServidor.Location = New System.Drawing.Point(122, 19)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(49, 13)
        Me.lblServidor.TabIndex = 45
        Me.lblServidor.Text = "Servidor:"
        '
        'lblDiasEnvio
        '
        Me.lblDiasEnvio.AutoSize = True
        Me.lblDiasEnvio.Location = New System.Drawing.Point(195, 314)
        Me.lblDiasEnvio.Name = "lblDiasEnvio"
        Me.lblDiasEnvio.Size = New System.Drawing.Size(73, 13)
        Me.lblDiasEnvio.TabIndex = 44
        Me.lblDiasEnvio.Text = "Dias de Envio"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(17, 271)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(66, 13)
        Me.lblDescripcion.TabIndex = 43
        Me.lblDescripcion.Text = "Descripcion:"
        '
        'lblHora
        '
        Me.lblHora.AutoSize = True
        Me.lblHora.Location = New System.Drawing.Point(5, 314)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(78, 13)
        Me.lblHora.TabIndex = 42
        Me.lblHora.Text = "Hora de Envio:"
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Location = New System.Drawing.Point(33, 231)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(50, 13)
        Me.lblMensaje.TabIndex = 41
        Me.lblMensaje.Text = "Mensaje:"
        '
        'lblAsunto
        '
        Me.lblAsunto.AutoSize = True
        Me.lblAsunto.Location = New System.Drawing.Point(40, 205)
        Me.lblAsunto.Name = "lblAsunto"
        Me.lblAsunto.Size = New System.Drawing.Size(43, 13)
        Me.lblAsunto.TabIndex = 40
        Me.lblAsunto.Text = "Asunto:"
        '
        'lblCopia
        '
        Me.lblCopia.AutoSize = True
        Me.lblCopia.Location = New System.Drawing.Point(46, 165)
        Me.lblCopia.Name = "lblCopia"
        Me.lblCopia.Size = New System.Drawing.Size(37, 13)
        Me.lblCopia.TabIndex = 39
        Me.lblCopia.Text = "Copia:"
        '
        'lblRecibe
        '
        Me.lblRecibe.AutoSize = True
        Me.lblRecibe.Location = New System.Drawing.Point(29, 125)
        Me.lblRecibe.Name = "lblRecibe"
        Me.lblRecibe.Size = New System.Drawing.Size(54, 13)
        Me.lblRecibe.TabIndex = 38
        Me.lblRecibe.Text = "Receptor:"
        '
        'lblEnvia
        '
        Me.lblEnvia.AutoSize = True
        Me.lblEnvia.Location = New System.Drawing.Point(40, 98)
        Me.lblEnvia.Name = "lblEnvia"
        Me.lblEnvia.Size = New System.Drawing.Size(41, 13)
        Me.lblEnvia.TabIndex = 37
        Me.lblEnvia.Text = "Emisor:"
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.Location = New System.Drawing.Point(35, 71)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(48, 13)
        Me.lblReporte.TabIndex = 36
        Me.lblReporte.Text = "Reporte:"
        '
        'lblFormulario
        '
        Me.lblFormulario.AutoSize = True
        Me.lblFormulario.Location = New System.Drawing.Point(25, 45)
        Me.lblFormulario.Name = "lblFormulario"
        Me.lblFormulario.Size = New System.Drawing.Size(58, 13)
        Me.lblFormulario.TabIndex = 35
        Me.lblFormulario.Text = "Formulario:"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(64, 19)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(19, 13)
        Me.lblId.TabIndex = 34
        Me.lblId.Text = "Id:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(272, 377)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 30
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        Me.btnCancelar.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(186, 377)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 29
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        Me.btnAceptar.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(186, 377)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 28
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnArchivo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(561, 39)
        Me.ToolStrip1.TabIndex = 4
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
        'btnAtras
        '
        Me.btnAtras.Location = New System.Drawing.Point(272, 377)
        Me.btnAtras.Name = "btnAtras"
        Me.btnAtras.Size = New System.Drawing.Size(75, 23)
        Me.btnAtras.TabIndex = 35
        Me.btnAtras.Text = "Atras"
        Me.btnAtras.UseVisualStyleBackColor = True
        '
        'Envios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 454)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Modificar)
        Me.Controls.Add(Me.Grid)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Envios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envios"
        CType(Me.GridEnvios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grid.ResumeLayout(False)
        Me.Modificar.ResumeLayout(False)
        Me.Datos.ResumeLayout(False)
        Me.Datos.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridEnvios As System.Windows.Forms.DataGridView
    Friend WithEvents Grid As System.Windows.Forms.GroupBox
    Friend WithEvents Modificar As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnArchivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents Datos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDias As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.RichTextBox
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents txtMensaje As System.Windows.Forms.RichTextBox
    Friend WithEvents txtCopia As System.Windows.Forms.RichTextBox
    Friend WithEvents txtReceptor As System.Windows.Forms.RichTextBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtReporte As System.Windows.Forms.TextBox
    Friend WithEvents txtFormu As System.Windows.Forms.TextBox
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents lblPuerto As System.Windows.Forms.Label
    Friend WithEvents lblServidor As System.Windows.Forms.Label
    Friend WithEvents lblDiasEnvio As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents lblAsunto As System.Windows.Forms.Label
    Friend WithEvents lblCopia As System.Windows.Forms.Label
    Friend WithEvents lblRecibe As System.Windows.Forms.Label
    Friend WithEvents lblEnvia As System.Windows.Forms.Label
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents lblFormulario As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmisor As System.Windows.Forms.TextBox
    Friend WithEvents btnAtras As System.Windows.Forms.Button
End Class
