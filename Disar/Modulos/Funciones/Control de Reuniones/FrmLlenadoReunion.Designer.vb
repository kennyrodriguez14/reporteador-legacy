<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLlenadoReunion
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLlenadoReunion))
        Me.DataParticipantes = New System.Windows.Forms.DataGridView
        Me.DataDetalles = New System.Windows.Forms.DataGridView
        Me.DataPendientes = New System.Windows.Forms.DataGridView
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Reunion = New System.Windows.Forms.Label
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.FechaHora = New System.Windows.Forms.Label
        Me.ReunionID = New System.Windows.Forms.Label
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.BtnAgregarParticipante = New System.Windows.Forms.Button
        Me.BtnQuitarParticipante = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ActualizaPendientes = New System.Windows.Forms.Button
        CType(Me.DataParticipantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataParticipantes
        '
        Me.DataParticipantes.AllowUserToAddRows = False
        Me.DataParticipantes.AllowUserToDeleteRows = False
        Me.DataParticipantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataParticipantes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataParticipantes.Location = New System.Drawing.Point(526, 53)
        Me.DataParticipantes.Name = "DataParticipantes"
        Me.DataParticipantes.RowHeadersVisible = False
        Me.DataParticipantes.Size = New System.Drawing.Size(434, 209)
        Me.DataParticipantes.TabIndex = 5
        '
        'DataDetalles
        '
        Me.DataDetalles.AllowUserToAddRows = False
        Me.DataDetalles.AllowUserToDeleteRows = False
        Me.DataDetalles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataDetalles.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDetalles.Location = New System.Drawing.Point(18, 53)
        Me.DataDetalles.Name = "DataDetalles"
        Me.DataDetalles.RowHeadersVisible = False
        Me.DataDetalles.Size = New System.Drawing.Size(499, 209)
        Me.DataDetalles.TabIndex = 4
        '
        'DataPendientes
        '
        Me.DataPendientes.AllowUserToAddRows = False
        Me.DataPendientes.AllowUserToDeleteRows = False
        Me.DataPendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataPendientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataPendientes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataPendientes.Location = New System.Drawing.Point(18, 298)
        Me.DataPendientes.Name = "DataPendientes"
        Me.DataPendientes.ReadOnly = True
        Me.DataPendientes.Size = New System.Drawing.Size(710, 161)
        Me.DataPendientes.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.DataPendientes, "Haga doble clic sobre una tarea para finalizarla")
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextObservaciones.Location = New System.Drawing.Point(734, 298)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(226, 161)
        Me.TextObservaciones.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(731, 282)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Observaciones:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Puntos de la reunión:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(523, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Asistencia y participantes:"
        '
        'Reunion
        '
        Me.Reunion.AutoSize = True
        Me.Reunion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reunion.Location = New System.Drawing.Point(5, 14)
        Me.Reunion.Name = "Reunion"
        Me.Reunion.Size = New System.Drawing.Size(14, 16)
        Me.Reunion.TabIndex = 7
        Me.Reunion.Text = "*"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Location = New System.Drawing.Point(874, 462)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(86, 49)
        Me.BtnGuardar.TabIndex = 9
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 282)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tareas:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(522, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Iniciada en:"
        '
        'FechaHora
        '
        Me.FechaHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FechaHora.AutoSize = True
        Me.FechaHora.Location = New System.Drawing.Point(585, 11)
        Me.FechaHora.Name = "FechaHora"
        Me.FechaHora.Size = New System.Drawing.Size(73, 13)
        Me.FechaHora.TabIndex = 11
        Me.FechaHora.Text = "DD/mm/aaaa"
        '
        'ReunionID
        '
        Me.ReunionID.AutoSize = True
        Me.ReunionID.Location = New System.Drawing.Point(15, 11)
        Me.ReunionID.Name = "ReunionID"
        Me.ReunionID.Size = New System.Drawing.Size(58, 13)
        Me.ReunionID.TabIndex = 12
        Me.ReunionID.Text = "ReunionID"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Location = New System.Drawing.Point(18, 462)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(86, 49)
        Me.BtnCancelar.TabIndex = 9
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnAgregarParticipante
        '
        Me.BtnAgregarParticipante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregarParticipante.Location = New System.Drawing.Point(936, 27)
        Me.BtnAgregarParticipante.Name = "BtnAgregarParticipante"
        Me.BtnAgregarParticipante.Size = New System.Drawing.Size(24, 23)
        Me.BtnAgregarParticipante.TabIndex = 13
        Me.BtnAgregarParticipante.Text = "+"
        Me.ToolTip1.SetToolTip(Me.BtnAgregarParticipante, "Agregar a una persona a la reunión (La persona agregada se añadirá a la bitácora " & _
                "y recibirá correo con la misma).")
        Me.BtnAgregarParticipante.UseVisualStyleBackColor = True
        '
        'BtnQuitarParticipante
        '
        Me.BtnQuitarParticipante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnQuitarParticipante.Location = New System.Drawing.Point(912, 27)
        Me.BtnQuitarParticipante.Name = "BtnQuitarParticipante"
        Me.BtnQuitarParticipante.Size = New System.Drawing.Size(24, 23)
        Me.BtnQuitarParticipante.TabIndex = 13
        Me.BtnQuitarParticipante.Text = "-"
        Me.ToolTip1.SetToolTip(Me.BtnQuitarParticipante, "Quitar participante seleccionado de esta reunión")
        Me.BtnQuitarParticipante.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Reunion)
        Me.GroupBox1.Location = New System.Drawing.Point(18, -4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 38)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'ActualizaPendientes
        '
        Me.ActualizaPendientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ActualizaPendientes.Location = New System.Drawing.Point(707, 435)
        Me.ActualizaPendientes.Name = "ActualizaPendientes"
        Me.ActualizaPendientes.Size = New System.Drawing.Size(20, 23)
        Me.ActualizaPendientes.TabIndex = 15
        Me.ActualizaPendientes.Text = "!"
        Me.ActualizaPendientes.UseVisualStyleBackColor = True
        '
        'FrmLlenadoReunion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 523)
        Me.ControlBox = False
        Me.Controls.Add(Me.ActualizaPendientes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnQuitarParticipante)
        Me.Controls.Add(Me.BtnAgregarParticipante)
        Me.Controls.Add(Me.ReunionID)
        Me.Controls.Add(Me.FechaHora)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.DataParticipantes)
        Me.Controls.Add(Me.DataDetalles)
        Me.Controls.Add(Me.DataPendientes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLlenadoReunion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Reunión"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataParticipantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataParticipantes As System.Windows.Forms.DataGridView
    Friend WithEvents DataDetalles As System.Windows.Forms.DataGridView
    Friend WithEvents DataPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Reunion As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FechaHora As System.Windows.Forms.Label
    Friend WithEvents ReunionID As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnAgregarParticipante As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtnQuitarParticipante As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ActualizaPendientes As System.Windows.Forms.Button
End Class
