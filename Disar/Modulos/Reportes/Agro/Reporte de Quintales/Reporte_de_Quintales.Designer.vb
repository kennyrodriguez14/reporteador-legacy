<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reporte_de_Quintales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reporte_de_Quintales))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._cmbFechaf = New System.Windows.Forms.DateTimePicker
        Me._cmbFechai = New System.Windows.Forms.DateTimePicker
        Me._lblFechaf = New System.Windows.Forms.Label
        Me._lblFechai = New System.Windows.Forms.Label
        Me.Pestañas = New System.Windows.Forms.TabControl
        Me.Alex = New System.Windows.Forms.TabPage
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me._gridalex = New System.Windows.Forms.DataGridView
        Me.Allan = New System.Windows.Forms.TabPage
        Me._gridallan = New System.Windows.Forms.DataGridView
        Me.SRC = New System.Windows.Forms.TabPage
        Me._gridsrc = New System.Windows.Forms.DataGridView
        Me.Agrogracias = New System.Windows.Forms.TabPage
        Me._gridgracias = New System.Windows.Forms.DataGridView
        Me.resumen = New System.Windows.Forms.TabPage
        Me._gridResumen = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me._gbCriteriosBusqueda.SuspendLayout()
        Me.Pestañas.SuspendLayout()
        Me.Alex.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridalex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Allan.SuspendLayout()
        CType(Me._gridallan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SRC.SuspendLayout()
        CType(Me._gridsrc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Agrogracias.SuspendLayout()
        CType(Me._gridgracias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.resumen.SuspendLayout()
        CType(Me._gridResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(988, 39)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '_Archivo
        '
        Me._Archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAExcelToolStripMenuItem, Me.CerrarToolStripMenuItem})
        Me._Archivo.Image = Global.Disar.My.Resources.Resources.Opciones
        Me._Archivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Archivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._Archivo.Name = "_Archivo"
        Me._Archivo.Size = New System.Drawing.Size(100, 36)
        Me._Archivo.Text = "Acciones"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Excel_32
        Me.ExportarAExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(171, 38)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar a Excel"
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.CerrarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(171, 38)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        '_gbCriteriosBusqueda
        '
        Me._gbCriteriosBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gbCriteriosBusqueda.Controls.Add(Me._btnGenerar)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechai)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechai)
        Me._gbCriteriosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbCriteriosBusqueda.Location = New System.Drawing.Point(12, 42)
        Me._gbCriteriosBusqueda.Name = "_gbCriteriosBusqueda"
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(964, 54)
        Me._gbCriteriosBusqueda.TabIndex = 25
        Me._gbCriteriosBusqueda.TabStop = False
        Me._gbCriteriosBusqueda.Text = "Criterios de Busqueda"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(844, 20)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(79, 23)
        Me._btnGenerar.TabIndex = 3
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_cmbFechaf
        '
        Me._cmbFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbFechaf.Location = New System.Drawing.Point(569, 20)
        Me._cmbFechaf.Name = "_cmbFechaf"
        Me._cmbFechaf.Size = New System.Drawing.Size(259, 23)
        Me._cmbFechaf.TabIndex = 2
        '
        '_cmbFechai
        '
        Me._cmbFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbFechai.Location = New System.Drawing.Point(158, 20)
        Me._cmbFechai.Name = "_cmbFechai"
        Me._cmbFechai.Size = New System.Drawing.Size(261, 23)
        Me._cmbFechai.TabIndex = 1
        '
        '_lblFechaf
        '
        Me._lblFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaf.AutoSize = True
        Me._lblFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaf.Location = New System.Drawing.Point(466, 23)
        Me._lblFechaf.Name = "_lblFechaf"
        Me._lblFechaf.Size = New System.Drawing.Size(97, 17)
        Me._lblFechaf.TabIndex = 1
        Me._lblFechaf.Text = "Fecha Final:"
        '
        '_lblFechai
        '
        Me._lblFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechai.AutoSize = True
        Me._lblFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechai.Location = New System.Drawing.Point(50, 23)
        Me._lblFechai.Name = "_lblFechai"
        Me._lblFechai.Size = New System.Drawing.Size(104, 17)
        Me._lblFechai.TabIndex = 0
        Me._lblFechai.Text = "Fecha Inicial:"
        '
        'Pestañas
        '
        Me.Pestañas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pestañas.Controls.Add(Me.Alex)
        Me.Pestañas.Controls.Add(Me.Allan)
        Me.Pestañas.Controls.Add(Me.SRC)
        Me.Pestañas.Controls.Add(Me.Agrogracias)
        Me.Pestañas.Controls.Add(Me.resumen)
        Me.Pestañas.Location = New System.Drawing.Point(13, 103)
        Me.Pestañas.Name = "Pestañas"
        Me.Pestañas.SelectedIndex = 0
        Me.Pestañas.Size = New System.Drawing.Size(963, 440)
        Me.Pestañas.TabIndex = 4
        '
        'Alex
        '
        Me.Alex.Controls.Add(Me.Imagen)
        Me.Alex.Controls.Add(Me._gridalex)
        Me.Alex.Location = New System.Drawing.Point(4, 22)
        Me.Alex.Name = "Alex"
        Me.Alex.Padding = New System.Windows.Forms.Padding(3)
        Me.Alex.Size = New System.Drawing.Size(955, 414)
        Me.Alex.TabIndex = 0
        Me.Alex.Text = "Alex Navarro"
        Me.Alex.UseVisualStyleBackColor = True
        '
        'Imagen
        '
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.Disar_Logo_26
        Me.Imagen.Location = New System.Drawing.Point(937, 3)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(15, 17)
        Me.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen.TabIndex = 41
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        '_gridalex
        '
        Me._gridalex.AllowUserToAddRows = False
        Me._gridalex.AllowUserToDeleteRows = False
        Me._gridalex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridalex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridalex.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridalex.Location = New System.Drawing.Point(3, 3)
        Me._gridalex.Name = "_gridalex"
        Me._gridalex.ReadOnly = True
        Me._gridalex.Size = New System.Drawing.Size(949, 408)
        Me._gridalex.TabIndex = 40
        '
        'Allan
        '
        Me.Allan.Controls.Add(Me._gridallan)
        Me.Allan.Location = New System.Drawing.Point(4, 22)
        Me.Allan.Name = "Allan"
        Me.Allan.Padding = New System.Windows.Forms.Padding(3)
        Me.Allan.Size = New System.Drawing.Size(955, 414)
        Me.Allan.TabIndex = 1
        Me.Allan.Text = "Allan Quijano"
        Me.Allan.UseVisualStyleBackColor = True
        '
        '_gridallan
        '
        Me._gridallan.AllowUserToAddRows = False
        Me._gridallan.AllowUserToDeleteRows = False
        Me._gridallan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridallan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridallan.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridallan.Location = New System.Drawing.Point(3, 3)
        Me._gridallan.Name = "_gridallan"
        Me._gridallan.ReadOnly = True
        Me._gridallan.Size = New System.Drawing.Size(949, 408)
        Me._gridallan.TabIndex = 40
        '
        'SRC
        '
        Me.SRC.Controls.Add(Me._gridsrc)
        Me.SRC.Location = New System.Drawing.Point(4, 22)
        Me.SRC.Name = "SRC"
        Me.SRC.Size = New System.Drawing.Size(955, 414)
        Me.SRC.TabIndex = 2
        Me.SRC.Text = "Agro SRC"
        Me.SRC.UseVisualStyleBackColor = True
        '
        '_gridsrc
        '
        Me._gridsrc.AllowUserToAddRows = False
        Me._gridsrc.AllowUserToDeleteRows = False
        Me._gridsrc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridsrc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridsrc.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridsrc.Location = New System.Drawing.Point(0, 0)
        Me._gridsrc.Name = "_gridsrc"
        Me._gridsrc.ReadOnly = True
        Me._gridsrc.Size = New System.Drawing.Size(955, 414)
        Me._gridsrc.TabIndex = 40
        '
        'Agrogracias
        '
        Me.Agrogracias.Controls.Add(Me._gridgracias)
        Me.Agrogracias.Location = New System.Drawing.Point(4, 22)
        Me.Agrogracias.Name = "Agrogracias"
        Me.Agrogracias.Size = New System.Drawing.Size(955, 414)
        Me.Agrogracias.TabIndex = 3
        Me.Agrogracias.Text = "Agro GRACIAS"
        Me.Agrogracias.UseVisualStyleBackColor = True
        '
        '_gridgracias
        '
        Me._gridgracias.AllowUserToAddRows = False
        Me._gridgracias.AllowUserToDeleteRows = False
        Me._gridgracias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridgracias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridgracias.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridgracias.Location = New System.Drawing.Point(0, 0)
        Me._gridgracias.Name = "_gridgracias"
        Me._gridgracias.ReadOnly = True
        Me._gridgracias.Size = New System.Drawing.Size(955, 414)
        Me._gridgracias.TabIndex = 40
        '
        'resumen
        '
        Me.resumen.Controls.Add(Me._gridResumen)
        Me.resumen.Location = New System.Drawing.Point(4, 22)
        Me.resumen.Name = "resumen"
        Me.resumen.Size = New System.Drawing.Size(955, 414)
        Me.resumen.TabIndex = 4
        Me.resumen.Text = "Resumen"
        Me.resumen.UseVisualStyleBackColor = True
        '
        '_gridResumen
        '
        Me._gridResumen.AllowUserToAddRows = False
        Me._gridResumen.AllowUserToDeleteRows = False
        Me._gridResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridResumen.Location = New System.Drawing.Point(0, 0)
        Me._gridResumen.Name = "_gridResumen"
        Me._gridResumen.ReadOnly = True
        Me._gridResumen.Size = New System.Drawing.Size(955, 414)
        Me._gridResumen.TabIndex = 41
        '
        'Reporte_de_Quintales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(988, 555)
        Me.Controls.Add(Me.Pestañas)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Reporte_de_Quintales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Quintales"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        Me.Pestañas.ResumeLayout(False)
        Me.Alex.ResumeLayout(False)
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridalex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Allan.ResumeLayout(False)
        CType(Me._gridallan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SRC.ResumeLayout(False)
        CType(Me._gridsrc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Agrogracias.ResumeLayout(False)
        CType(Me._gridgracias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.resumen.ResumeLayout(False)
        CType(Me._gridResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _cmbFechaf As System.Windows.Forms.DateTimePicker
    Friend WithEvents _cmbFechai As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechaf As System.Windows.Forms.Label
    Friend WithEvents _lblFechai As System.Windows.Forms.Label
    Friend WithEvents Pestañas As System.Windows.Forms.TabControl
    Friend WithEvents Alex As System.Windows.Forms.TabPage
    Friend WithEvents _gridalex As System.Windows.Forms.DataGridView
    Friend WithEvents Allan As System.Windows.Forms.TabPage
    Friend WithEvents _gridallan As System.Windows.Forms.DataGridView
    Friend WithEvents SRC As System.Windows.Forms.TabPage
    Friend WithEvents _gridsrc As System.Windows.Forms.DataGridView
    Friend WithEvents Agrogracias As System.Windows.Forms.TabPage
    Friend WithEvents _gridgracias As System.Windows.Forms.DataGridView
    Friend WithEvents resumen As System.Windows.Forms.TabPage
    Friend WithEvents _gridResumen As System.Windows.Forms.DataGridView
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
End Class
