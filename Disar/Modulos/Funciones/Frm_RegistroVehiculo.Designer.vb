<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RegistroVehiculo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RegistroVehiculo))
        Me.GroupReg = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextKilometraje = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextMotivo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextEncargado = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboVehiculo = New System.Windows.Forms.ComboBox
        Me.GroupTodo = New System.Windows.Forms.GroupBox
        Me.Nuevo = New System.Windows.Forms.Button
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.BtnGenerar = New System.Windows.Forms.Button
        Me.Desde = New System.Windows.Forms.DateTimePicker
        Me.Hasta = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupReg.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupTodo.SuspendLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupReg
        '
        Me.GroupReg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupReg.Controls.Add(Me.GroupBox3)
        Me.GroupReg.Location = New System.Drawing.Point(13, 12)
        Me.GroupReg.Name = "GroupReg"
        Me.GroupReg.Size = New System.Drawing.Size(770, 375)
        Me.GroupReg.TabIndex = 0
        Me.GroupReg.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.BtnCancelar)
        Me.GroupBox3.Controls.Add(Me.DateFecha)
        Me.GroupBox3.Controls.Add(Me.BtnGuardar)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.TextKilometraje)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.TextMotivo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.TextEncargado)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.ComboVehiculo)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(622, 252)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vehículo:"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(508, 191)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(93, 42)
        Me.BtnCancelar.TabIndex = 8
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'DateFecha
        '
        Me.DateFecha.Location = New System.Drawing.Point(152, 111)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(200, 20)
        Me.DateFecha.TabIndex = 5
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(409, 191)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(93, 42)
        Me.BtnGuardar.TabIndex = 7
        Me.BtnGuardar.Text = "Registrar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Persona que lo utilizó:"
        '
        'TextKilometraje
        '
        Me.TextKilometraje.Location = New System.Drawing.Point(152, 139)
        Me.TextKilometraje.Name = "TextKilometraje"
        Me.TextKilometraje.Size = New System.Drawing.Size(316, 20)
        Me.TextKilometraje.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Motivo de uso:"
        '
        'TextMotivo
        '
        Me.TextMotivo.Location = New System.Drawing.Point(152, 83)
        Me.TextMotivo.Name = "TextMotivo"
        Me.TextMotivo.Size = New System.Drawing.Size(316, 20)
        Me.TextMotivo.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Fecha:"
        '
        'TextEncargado
        '
        Me.TextEncargado.Location = New System.Drawing.Point(152, 55)
        Me.TextEncargado.Name = "TextEncargado"
        Me.TextEncargado.Size = New System.Drawing.Size(316, 20)
        Me.TextEncargado.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Registro de Kilometraje:"
        '
        'ComboVehiculo
        '
        Me.ComboVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVehiculo.FormattingEnabled = True
        Me.ComboVehiculo.Location = New System.Drawing.Point(152, 26)
        Me.ComboVehiculo.Name = "ComboVehiculo"
        Me.ComboVehiculo.Size = New System.Drawing.Size(316, 21)
        Me.ComboVehiculo.TabIndex = 2
        '
        'GroupTodo
        '
        Me.GroupTodo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupTodo.Controls.Add(Me.Nuevo)
        Me.GroupTodo.Controls.Add(Me.DataDatos)
        Me.GroupTodo.Controls.Add(Me.GroupBox1)
        Me.GroupTodo.Location = New System.Drawing.Point(13, 12)
        Me.GroupTodo.Name = "GroupTodo"
        Me.GroupTodo.Size = New System.Drawing.Size(770, 375)
        Me.GroupTodo.TabIndex = 1
        Me.GroupTodo.TabStop = False
        '
        'Nuevo
        '
        Me.Nuevo.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Nuevo.Location = New System.Drawing.Point(6, 14)
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Size = New System.Drawing.Size(62, 58)
        Me.Nuevo.TabIndex = 12
        Me.Nuevo.Text = "Agregar"
        Me.Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Nuevo.UseVisualStyleBackColor = True
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Location = New System.Drawing.Point(6, 84)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.Size = New System.Drawing.Size(758, 285)
        Me.DataDatos.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.BtnGenerar)
        Me.GroupBox1.Controls.Add(Me.Desde)
        Me.GroupBox1.Controls.Add(Me.Hasta)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(126, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(638, 61)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Ver registros"
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Location = New System.Drawing.Point(518, 32)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(112, 23)
        Me.BtnGenerar.TabIndex = 11
        Me.BtnGenerar.Text = "Generar"
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'Desde
        '
        Me.Desde.Location = New System.Drawing.Point(56, 33)
        Me.Desde.Name = "Desde"
        Me.Desde.Size = New System.Drawing.Size(200, 20)
        Me.Desde.TabIndex = 9
        '
        'Hasta
        '
        Me.Hasta.Location = New System.Drawing.Point(302, 33)
        Me.Hasta.Name = "Hasta"
        Me.Hasta.Size = New System.Drawing.Size(200, 20)
        Me.Hasta.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(262, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Hasta:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Desde:"
        '
        'Frm_RegistroVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 399)
        Me.Controls.Add(Me.GroupTodo)
        Me.Controls.Add(Me.GroupReg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_RegistroVehiculo"
        Me.Text = "Registro de Uso Vehicular"
        Me.GroupReg.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupTodo.ResumeLayout(False)
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupReg As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupTodo As System.Windows.Forms.GroupBox
    Friend WithEvents ComboVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents TextMotivo As System.Windows.Forms.TextBox
    Friend WithEvents TextEncargado As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextKilometraje As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Nuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
