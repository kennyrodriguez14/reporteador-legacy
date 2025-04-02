<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReunionesPrincipal
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReunionesPrincipal))
        Me.DataPendientes = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataReuniones = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnAgregar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.DataParticipantes = New System.Windows.Forms.DataGridView
        Me.DataDetalles = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Usuario = New System.Windows.Forms.Label
        Me.BtnIniciarReunino = New System.Windows.Forms.Button
        Me.BtnCrearReunion = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.mnuArchivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.MisReunionesAnterioresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_Pendientes = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuReportes = New System.Windows.Forms.ToolStripDropDownButton
        Me.EstadísticaDeReunionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EfectividadDeReunionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EfectividadDeTiempoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EstadísticaDePendientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AsistenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        CType(Me.DataPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataReuniones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataParticipantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataPendientes.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataPendientes.Location = New System.Drawing.Point(6, 322)
        Me.DataPendientes.Name = "DataPendientes"
        Me.DataPendientes.ReadOnly = True
        Me.DataPendientes.RowHeadersVisible = False
        Me.DataPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataPendientes.Size = New System.Drawing.Size(655, 214)
        Me.DataPendientes.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 307)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sus pendientes asignados:"
        '
        'DataReuniones
        '
        Me.DataReuniones.AllowUserToAddRows = False
        Me.DataReuniones.AllowUserToDeleteRows = False
        Me.DataReuniones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataReuniones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataReuniones.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataReuniones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataReuniones.Location = New System.Drawing.Point(6, 45)
        Me.DataReuniones.Name = "DataReuniones"
        Me.DataReuniones.ReadOnly = True
        Me.DataReuniones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataReuniones.Size = New System.Drawing.Size(655, 250)
        Me.DataReuniones.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(227, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Reuniones en las que se encuentra registrado:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnAgregar)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.DataParticipantes)
        Me.GroupBox1.Controls.Add(Me.DataDetalles)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(686, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 419)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'BtnAgregar
        '
        Me.BtnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor
        Me.BtnAgregar.Location = New System.Drawing.Point(283, 43)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(30, 23)
        Me.BtnAgregar.TabIndex = 4
        Me.BtnAgregar.Text = "+"
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 247)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(197, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Participantes de Reunión Seleccionada:"
        '
        'DataParticipantes
        '
        Me.DataParticipantes.AllowUserToAddRows = False
        Me.DataParticipantes.AllowUserToDeleteRows = False
        Me.DataParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataParticipantes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataParticipantes.Location = New System.Drawing.Point(6, 262)
        Me.DataParticipantes.Name = "DataParticipantes"
        Me.DataParticipantes.ReadOnly = True
        Me.DataParticipantes.RowHeadersVisible = False
        Me.DataParticipantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataParticipantes.Size = New System.Drawing.Size(274, 151)
        Me.DataParticipantes.TabIndex = 2
        '
        'DataDetalles
        '
        Me.DataDetalles.AllowUserToAddRows = False
        Me.DataDetalles.AllowUserToDeleteRows = False
        Me.DataDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDetalles.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDetalles.Location = New System.Drawing.Point(6, 45)
        Me.DataDetalles.Name = "DataDetalles"
        Me.DataDetalles.ReadOnly = True
        Me.DataDetalles.RowHeadersVisible = False
        Me.DataDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataDetalles.Size = New System.Drawing.Size(274, 192)
        Me.DataDetalles.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(174, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Detalles de Reunión Seleccionada:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DataReuniones)
        Me.GroupBox2.Controls.Add(Me.DataPendientes)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(667, 542)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Usuario
        '
        Me.Usuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Usuario.Location = New System.Drawing.Point(592, 18)
        Me.Usuario.Name = "Usuario"
        Me.Usuario.Size = New System.Drawing.Size(409, 21)
        Me.Usuario.TabIndex = 0
        Me.Usuario.Text = "*"
        Me.Usuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnIniciarReunino
        '
        Me.BtnIniciarReunino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnIniciarReunino.Location = New System.Drawing.Point(686, 460)
        Me.BtnIniciarReunino.Name = "BtnIniciarReunino"
        Me.BtnIniciarReunino.Size = New System.Drawing.Size(141, 56)
        Me.BtnIniciarReunino.TabIndex = 4
        Me.BtnIniciarReunino.Text = "Empezar reunión seleccionada"
        Me.BtnIniciarReunino.UseVisualStyleBackColor = True
        '
        'BtnCrearReunion
        '
        Me.BtnCrearReunion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCrearReunion.Location = New System.Drawing.Point(883, 460)
        Me.BtnCrearReunion.Name = "BtnCrearReunion"
        Me.BtnCrearReunion.Size = New System.Drawing.Size(116, 27)
        Me.BtnCrearReunion.TabIndex = 4
        Me.BtnCrearReunion.Text = "Crear nueva reunión"
        Me.BtnCrearReunion.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivo, Me.ToolStripSeparator1, Me.mnuReportes, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1014, 39)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'mnuArchivo
        '
        Me.mnuArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MisReunionesAnterioresToolStripMenuItem, Me.mnu_Pendientes, Me.SalirToolStripMenuItem})
        Me.mnuArchivo.Image = Global.Disar.My.Resources.Resources.Ordering_32
        Me.mnuArchivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuArchivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuArchivo.Name = "mnuArchivo"
        Me.mnuArchivo.Size = New System.Drawing.Size(117, 36)
        Me.mnuArchivo.Text = "Información"
        '
        'MisReunionesAnterioresToolStripMenuItem
        '
        Me.MisReunionesAnterioresToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.img_usuarios
        Me.MisReunionesAnterioresToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MisReunionesAnterioresToolStripMenuItem.Name = "MisReunionesAnterioresToolStripMenuItem"
        Me.MisReunionesAnterioresToolStripMenuItem.Size = New System.Drawing.Size(219, 38)
        Me.MisReunionesAnterioresToolStripMenuItem.Text = "Mis reuniones anteriores"
        '
        'mnu_Pendientes
        '
        Me.mnu_Pendientes.Image = Global.Disar.My.Resources.Resources.Analysis_32
        Me.mnu_Pendientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnu_Pendientes.Name = "mnu_Pendientes"
        Me.mnu_Pendientes.Size = New System.Drawing.Size(219, 38)
        Me.mnu_Pendientes.Text = "Gestión de Pendientes"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(219, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'mnuReportes
        '
        Me.mnuReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EstadísticaDeReunionesToolStripMenuItem, Me.EfectividadDeReunionToolStripMenuItem, Me.EfectividadDeTiempoToolStripMenuItem, Me.EstadísticaDePendientesToolStripMenuItem, Me.AsistenciasToolStripMenuItem})
        Me.mnuReportes.Image = Global.Disar.My.Resources.Resources.File_Edit_32
        Me.mnuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuReportes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuReportes.Name = "mnuReportes"
        Me.mnuReportes.Size = New System.Drawing.Size(97, 36)
        Me.mnuReportes.Text = "Reportes"
        Me.mnuReportes.Visible = False
        '
        'EstadísticaDeReunionesToolStripMenuItem
        '
        Me.EstadísticaDeReunionesToolStripMenuItem.Name = "EstadísticaDeReunionesToolStripMenuItem"
        Me.EstadísticaDeReunionesToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.EstadísticaDeReunionesToolStripMenuItem.Text = "Estadística de Reuniones"
        '
        'EfectividadDeReunionToolStripMenuItem
        '
        Me.EfectividadDeReunionToolStripMenuItem.Name = "EfectividadDeReunionToolStripMenuItem"
        Me.EfectividadDeReunionToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.EfectividadDeReunionToolStripMenuItem.Text = "Efectividad de Reunion"
        '
        'EfectividadDeTiempoToolStripMenuItem
        '
        Me.EfectividadDeTiempoToolStripMenuItem.Name = "EfectividadDeTiempoToolStripMenuItem"
        Me.EfectividadDeTiempoToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.EfectividadDeTiempoToolStripMenuItem.Text = "Efectividad de Tiempo"
        '
        'EstadísticaDePendientesToolStripMenuItem
        '
        Me.EstadísticaDePendientesToolStripMenuItem.Name = "EstadísticaDePendientesToolStripMenuItem"
        Me.EstadísticaDePendientesToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.EstadísticaDePendientesToolStripMenuItem.Text = "Estadística de Pendientes"
        '
        'AsistenciasToolStripMenuItem
        '
        Me.AsistenciasToolStripMenuItem.Name = "AsistenciasToolStripMenuItem"
        Me.AsistenciasToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AsistenciasToolStripMenuItem.Text = "Asistencias"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'FormReunionesPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 582)
        Me.Controls.Add(Me.Usuario)
        Me.Controls.Add(Me.BtnCrearReunion)
        Me.Controls.Add(Me.BtnIniciarReunino)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormReunionesPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Centro de Reuniones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataReuniones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataParticipantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataReuniones As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Usuario As System.Windows.Forms.Label
    Friend WithEvents DataDetalles As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnIniciarReunino As System.Windows.Forms.Button
    Friend WithEvents BtnCrearReunion As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuArchivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuReportes As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadísticaDeReunionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EfectividadDeReunionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EfectividadDeTiempoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsistenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataParticipantes As System.Windows.Forms.DataGridView
    Friend WithEvents MisReunionesAnterioresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EstadísticaDePendientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents mnu_Pendientes As System.Windows.Forms.ToolStripMenuItem
End Class
