<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromociones_Principal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPromociones_Principal))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.NuevaCargaDePromociónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NuevaCargaDeProductoDesdePromociónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TrasladoDePromociónAPromociónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEmpresa = New System.Windows.Forms.TextBox
        Me.txtAlmacen = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboAlmacen = New System.Windows.Forms.ComboBox
        Me.elabel = New System.Windows.Forms.Label
        Me.GrpFiltro = New System.Windows.Forms.GroupBox
        Me.BtnFiltro = New System.Windows.Forms.Button
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.BtnFiltra = New System.Windows.Forms.Button
        Me.GrillaPromos = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboEmpresa = New System.Windows.Forms.ComboBox
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GrpFiltro.SuspendLayout()
        CType(Me.GrillaPromos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(893, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaCargaDePromociónToolStripMenuItem, Me.NuevaCargaDeProductoDesdePromociónToolStripMenuItem, Me.TrasladoDePromociónAPromociónToolStripMenuItem, Me.ExportarAExcelToolStripMenuItem})
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.Gnome_Folder_New_32
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(86, 36)
        Me.ToolStripButton1.Text = "Tareas"
        '
        'NuevaCargaDePromociónToolStripMenuItem
        '
        Me.NuevaCargaDePromociónToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.img_ingresar_rutas
        Me.NuevaCargaDePromociónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevaCargaDePromociónToolStripMenuItem.Name = "NuevaCargaDePromociónToolStripMenuItem"
        Me.NuevaCargaDePromociónToolStripMenuItem.Size = New System.Drawing.Size(285, 38)
        Me.NuevaCargaDePromociónToolStripMenuItem.Text = "Nueva Carga de Promoción"
        '
        'NuevaCargaDeProductoDesdePromociónToolStripMenuItem
        '
        Me.NuevaCargaDeProductoDesdePromociónToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Efectividad_Red
        Me.NuevaCargaDeProductoDesdePromociónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevaCargaDeProductoDesdePromociónToolStripMenuItem.Name = "NuevaCargaDeProductoDesdePromociónToolStripMenuItem"
        Me.NuevaCargaDeProductoDesdePromociónToolStripMenuItem.Size = New System.Drawing.Size(285, 38)
        Me.NuevaCargaDeProductoDesdePromociónToolStripMenuItem.Text = "Carga de Producto desde Promoción"
        '
        'TrasladoDePromociónAPromociónToolStripMenuItem
        '
        Me.TrasladoDePromociónAPromociónToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Arrow_double_anticlockwise_x_32
        Me.TrasladoDePromociónAPromociónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TrasladoDePromociónAPromociónToolStripMenuItem.Name = "TrasladoDePromociónAPromociónToolStripMenuItem"
        Me.TrasladoDePromociónAPromociónToolStripMenuItem.Size = New System.Drawing.Size(285, 38)
        Me.TrasladoDePromociónAPromociónToolStripMenuItem.Text = "Traslado de Promoción a Promoción"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Excel_32
        Me.ExportarAExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(285, 38)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar a Excel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Empresa:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Almacén:"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Enabled = False
        Me.txtEmpresa.Location = New System.Drawing.Point(257, 36)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(154, 20)
        Me.txtEmpresa.TabIndex = 3
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Enabled = False
        Me.txtAlmacen.Location = New System.Drawing.Point(80, 58)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.Size = New System.Drawing.Size(154, 20)
        Me.txtAlmacen.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ComboEmpresa)
        Me.GroupBox1.Controls.Add(Me.ComboAlmacen)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAlmacen)
        Me.GroupBox1.Controls.Add(Me.elabel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtEmpresa)
        Me.GroupBox1.Controls.Add(Me.GrpFiltro)
        Me.GroupBox1.Controls.Add(Me.BtnFiltra)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(869, 100)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'ComboAlmacen
        '
        Me.ComboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAlmacen.FormattingEnabled = True
        Me.ComboAlmacen.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.ComboAlmacen.Location = New System.Drawing.Point(336, 57)
        Me.ComboAlmacen.Name = "ComboAlmacen"
        Me.ComboAlmacen.Size = New System.Drawing.Size(75, 21)
        Me.ComboAlmacen.TabIndex = 5
        Me.ComboAlmacen.Visible = False
        '
        'elabel
        '
        Me.elabel.AutoSize = True
        Me.elabel.Location = New System.Drawing.Point(252, 61)
        Me.elabel.Name = "elabel"
        Me.elabel.Size = New System.Drawing.Size(83, 13)
        Me.elabel.TabIndex = 2
        Me.elabel.Text = "Definir almacén:"
        Me.elabel.Visible = False
        '
        'GrpFiltro
        '
        Me.GrpFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpFiltro.Controls.Add(Me.BtnFiltro)
        Me.GrpFiltro.Controls.Add(Me.DateTimePicker2)
        Me.GrpFiltro.Controls.Add(Me.Label4)
        Me.GrpFiltro.Controls.Add(Me.Label3)
        Me.GrpFiltro.Controls.Add(Me.DateTimePicker1)
        Me.GrpFiltro.Location = New System.Drawing.Point(536, 10)
        Me.GrpFiltro.Name = "GrpFiltro"
        Me.GrpFiltro.Size = New System.Drawing.Size(327, 84)
        Me.GrpFiltro.TabIndex = 4
        Me.GrpFiltro.TabStop = False
        Me.GrpFiltro.Text = "Filtrar por fecha"
        Me.GrpFiltro.Visible = False
        '
        'BtnFiltro
        '
        Me.BtnFiltro.Location = New System.Drawing.Point(220, 30)
        Me.BtnFiltro.Name = "BtnFiltro"
        Me.BtnFiltro.Size = New System.Drawing.Size(101, 23)
        Me.BtnFiltro.TabIndex = 3
        Me.BtnFiltro.Text = "Filtrar"
        Me.BtnFiltro.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(71, 44)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(143, 20)
        Me.DateTimePicker2.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Hasta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Desde:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(71, 19)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(143, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'BtnFiltra
        '
        Me.BtnFiltra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFiltra.Location = New System.Drawing.Point(756, 40)
        Me.BtnFiltra.Name = "BtnFiltra"
        Me.BtnFiltra.Size = New System.Drawing.Size(101, 23)
        Me.BtnFiltra.TabIndex = 3
        Me.BtnFiltra.Text = "Buscar por fechas"
        Me.BtnFiltra.UseVisualStyleBackColor = True
        '
        'GrillaPromos
        '
        Me.GrillaPromos.AllowUserToAddRows = False
        Me.GrillaPromos.AllowUserToDeleteRows = False
        Me.GrillaPromos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrillaPromos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GrillaPromos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaPromos.Location = New System.Drawing.Point(13, 217)
        Me.GrillaPromos.Name = "GrillaPromos"
        Me.GrillaPromos.ReadOnly = True
        Me.GrillaPromos.Size = New System.Drawing.Size(868, 253)
        Me.GrillaPromos.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(196, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Traslados de Promociones"
        '
        'ComboEmpresa
        '
        Me.ComboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEmpresa.FormattingEnabled = True
        Me.ComboEmpresa.Items.AddRange(New Object() {"SAN RAFAEL", "DIMOSA", "SR AGRO"})
        Me.ComboEmpresa.Location = New System.Drawing.Point(80, 36)
        Me.ComboEmpresa.Name = "ComboEmpresa"
        Me.ComboEmpresa.Size = New System.Drawing.Size(154, 21)
        Me.ComboEmpresa.TabIndex = 6
        '
        'frmPromociones_Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 562)
        Me.Controls.Add(Me.GrillaPromos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPromociones_Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traslado de Promociones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpFiltro.ResumeLayout(False)
        Me.GrpFiltro.PerformLayout()
        CType(Me.GrillaPromos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents NuevaCargaDePromociónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GrpFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnFiltro As System.Windows.Forms.Button
    Friend WithEvents BtnFiltra As System.Windows.Forms.Button
    Friend WithEvents GrillaPromos As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NuevaCargaDeProductoDesdePromociónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents elabel As System.Windows.Forms.Label
    Friend WithEvents TrasladoDePromociónAPromociónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboEmpresa As System.Windows.Forms.ComboBox
End Class
