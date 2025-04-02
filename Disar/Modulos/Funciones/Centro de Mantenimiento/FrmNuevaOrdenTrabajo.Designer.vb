<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNuevaOrdenTrabajo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNuevaOrdenTrabajo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.TextAsignado = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.BtnTarea = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Guardar = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ComboTipo = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Datos1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.HoraSalida = New System.Windows.Forms.DateTimePicker
        Me.HoraEntrada = New System.Windows.Forms.DateTimePicker
        Me.FechaSalida = New System.Windows.Forms.DateTimePicker
        Me.FechaIngreso = New System.Windows.Forms.DateTimePicker
        Me.Datos2 = New System.Windows.Forms.GroupBox
        Me.TextKilometraje = New System.Windows.Forms.TextBox
        Me.CmbVehiculo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Datos1.SuspendLayout()
        Me.Datos2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnCancelar)
        Me.GroupBox1.Controls.Add(Me.TextObservaciones)
        Me.GroupBox1.Controls.Add(Me.TextAsignado)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.BtnTarea)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Guardar)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1052, 433)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(961, 353)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(85, 33)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancelar.UseVisualStyleBackColor = True
        Me.BtnCancelar.Visible = False
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextObservaciones.Location = New System.Drawing.Point(355, 355)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(597, 70)
        Me.TextObservaciones.TabIndex = 2
        '
        'TextAsignado
        '
        Me.TextAsignado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextAsignado.Location = New System.Drawing.Point(14, 374)
        Me.TextAsignado.Name = "TextAsignado"
        Me.TextAsignado.Size = New System.Drawing.Size(221, 20)
        Me.TextAsignado.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(276, 358)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Observaciones:"
        '
        'BtnTarea
        '
        Me.BtnTarea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTarea.Location = New System.Drawing.Point(1019, 19)
        Me.BtnTarea.Name = "BtnTarea"
        Me.BtnTarea.Size = New System.Drawing.Size(27, 23)
        Me.BtnTarea.TabIndex = 5
        Me.BtnTarea.Text = "+"
        Me.BtnTarea.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 358)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Encargado:"
        '
        'Guardar
        '
        Me.Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guardar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Guardar.Location = New System.Drawing.Point(961, 389)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(85, 38)
        Me.Guardar.TabIndex = 4
        Me.Guardar.Text = "Guardar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Orden"
        Me.Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Guardar.UseVisualStyleBackColor = True
        Me.Guardar.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 19)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1007, 328)
        Me.DataGridView1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ComboTipo)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 71)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'ComboTipo
        '
        Me.ComboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipo.FormattingEnabled = True
        Me.ComboTipo.Items.AddRange(New Object() {"Preventivo", "Correctivo"})
        Me.ComboTipo.Location = New System.Drawing.Point(49, 43)
        Me.ComboTipo.Name = "ComboTipo"
        Me.ComboTipo.Size = New System.Drawing.Size(203, 21)
        Me.ComboTipo.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Tipo:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(49, 16)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(203, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Orden:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(227, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 46)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Empezar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Datos1
        '
        Me.Datos1.Controls.Add(Me.Label3)
        Me.Datos1.Controls.Add(Me.Label2)
        Me.Datos1.Controls.Add(Me.Label9)
        Me.Datos1.Controls.Add(Me.Label1)
        Me.Datos1.Controls.Add(Me.HoraSalida)
        Me.Datos1.Controls.Add(Me.HoraEntrada)
        Me.Datos1.Controls.Add(Me.FechaSalida)
        Me.Datos1.Controls.Add(Me.FechaIngreso)
        Me.Datos1.Location = New System.Drawing.Point(625, 5)
        Me.Datos1.Name = "Datos1"
        Me.Datos1.Size = New System.Drawing.Size(440, 72)
        Me.Datos1.TabIndex = 2
        Me.Datos1.TabStop = False
        Me.Datos1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(262, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Hora Salida:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(262, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Hora Entrada:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Salida:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Ingreso:"
        '
        'HoraSalida
        '
        Me.HoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.HoraSalida.Location = New System.Drawing.Point(337, 41)
        Me.HoraSalida.Name = "HoraSalida"
        Me.HoraSalida.ShowUpDown = True
        Me.HoraSalida.Size = New System.Drawing.Size(91, 20)
        Me.HoraSalida.TabIndex = 6
        '
        'HoraEntrada
        '
        Me.HoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.HoraEntrada.Location = New System.Drawing.Point(337, 16)
        Me.HoraEntrada.Name = "HoraEntrada"
        Me.HoraEntrada.ShowUpDown = True
        Me.HoraEntrada.Size = New System.Drawing.Size(91, 20)
        Me.HoraEntrada.TabIndex = 6
        '
        'FechaSalida
        '
        Me.FechaSalida.Location = New System.Drawing.Point(58, 41)
        Me.FechaSalida.Name = "FechaSalida"
        Me.FechaSalida.Size = New System.Drawing.Size(193, 20)
        Me.FechaSalida.TabIndex = 6
        '
        'FechaIngreso
        '
        Me.FechaIngreso.Location = New System.Drawing.Point(58, 16)
        Me.FechaIngreso.Name = "FechaIngreso"
        Me.FechaIngreso.Size = New System.Drawing.Size(193, 20)
        Me.FechaIngreso.TabIndex = 6
        '
        'Datos2
        '
        Me.Datos2.Controls.Add(Me.Button1)
        Me.Datos2.Controls.Add(Me.TextKilometraje)
        Me.Datos2.Controls.Add(Me.CmbVehiculo)
        Me.Datos2.Controls.Add(Me.Label5)
        Me.Datos2.Controls.Add(Me.Label4)
        Me.Datos2.Location = New System.Drawing.Point(296, 6)
        Me.Datos2.Name = "Datos2"
        Me.Datos2.Size = New System.Drawing.Size(323, 71)
        Me.Datos2.TabIndex = 2
        Me.Datos2.TabStop = False
        '
        'TextKilometraje
        '
        Me.TextKilometraje.Location = New System.Drawing.Point(72, 43)
        Me.TextKilometraje.Name = "TextKilometraje"
        Me.TextKilometraje.Size = New System.Drawing.Size(138, 20)
        Me.TextKilometraje.TabIndex = 2
        '
        'CmbVehiculo
        '
        Me.CmbVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVehiculo.FormattingEnabled = True
        Me.CmbVehiculo.Location = New System.Drawing.Point(71, 17)
        Me.CmbVehiculo.Name = "CmbVehiculo"
        Me.CmbVehiculo.Size = New System.Drawing.Size(139, 21)
        Me.CmbVehiculo.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Kilometraje:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Vehículo:"
        '
        'FrmNuevaOrdenTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 514)
        Me.Controls.Add(Me.Datos2)
        Me.Controls.Add(Me.Datos1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmNuevaOrdenTrabajo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva Orden de Trabajo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Datos1.ResumeLayout(False)
        Me.Datos1.PerformLayout()
        Me.Datos2.ResumeLayout(False)
        Me.Datos2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents BtnTarea As System.Windows.Forms.Button
    Friend WithEvents Datos1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Datos2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents HoraSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents HoraEntrada As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextKilometraje As System.Windows.Forms.TextBox
    Friend WithEvents CmbVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents TextAsignado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents FechaSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
