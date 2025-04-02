<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EfectividadRangoFechas_sr_agro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EfectividadRangoFechas_sr_agro))
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RadioMenores = New System.Windows.Forms.RadioButton
        Me.RadioTodos = New System.Windows.Forms.RadioButton
        Me._GridNC = New System.Windows.Forms.DataGridView
        Me._GridEfectivos = New System.Windows.Forms.DataGridView
        Me._GridVisitados = New System.Windows.Forms.DataGridView
        Me._GridVendedores = New System.Windows.Forms.DataGridView
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._cmbFechaf = New System.Windows.Forms.DateTimePicker
        Me._cmbFechai = New System.Windows.Forms.DateTimePicker
        Me._lblFechaf = New System.Windows.Forms.Label
        Me._lblFechai = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._GridEfectividadRF = New System.Windows.Forms.DataGridView
        Me._gbCriteriosBusqueda.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me._GridNC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._GridEfectivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._GridVisitados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._GridVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me._GridEfectividadRF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_gbCriteriosBusqueda
        '
        Me._gbCriteriosBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gbCriteriosBusqueda.Controls.Add(Me.GroupBox2)
        Me._gbCriteriosBusqueda.Controls.Add(Me._GridNC)
        Me._gbCriteriosBusqueda.Controls.Add(Me._GridEfectivos)
        Me._gbCriteriosBusqueda.Controls.Add(Me._GridVisitados)
        Me._gbCriteriosBusqueda.Controls.Add(Me._GridVendedores)
        Me._gbCriteriosBusqueda.Controls.Add(Me._btnGenerar)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechai)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechai)
        Me._gbCriteriosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbCriteriosBusqueda.Location = New System.Drawing.Point(12, 42)
        Me._gbCriteriosBusqueda.Name = "_gbCriteriosBusqueda"
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(990, 85)
        Me._gbCriteriosBusqueda.TabIndex = 0
        Me._gbCriteriosBusqueda.TabStop = False
        Me._gbCriteriosBusqueda.Text = "Criterios de Busqueda"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.Controls.Add(Me.RadioMenores)
        Me.GroupBox2.Controls.Add(Me.RadioTodos)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(695, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(121, 63)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'RadioMenores
        '
        Me.RadioMenores.AutoSize = True
        Me.RadioMenores.Location = New System.Drawing.Point(6, 36)
        Me.RadioMenores.Name = "RadioMenores"
        Me.RadioMenores.Size = New System.Drawing.Size(113, 19)
        Me.RadioMenores.TabIndex = 0
        Me.RadioMenores.TabStop = True
        Me.RadioMenores.Text = "Ventas < 30,000"
        Me.RadioMenores.UseVisualStyleBackColor = True
        '
        'RadioTodos
        '
        Me.RadioTodos.AutoSize = True
        Me.RadioTodos.Location = New System.Drawing.Point(6, 15)
        Me.RadioTodos.Name = "RadioTodos"
        Me.RadioTodos.Size = New System.Drawing.Size(59, 19)
        Me.RadioTodos.TabIndex = 0
        Me.RadioTodos.TabStop = True
        Me.RadioTodos.Text = "Todos"
        Me.RadioTodos.UseVisualStyleBackColor = True
        '
        '_GridNC
        '
        Me._GridNC.AllowUserToAddRows = False
        Me._GridNC.AllowUserToDeleteRows = False
        Me._GridNC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridNC.Location = New System.Drawing.Point(819, 0)
        Me._GridNC.Name = "_GridNC"
        Me._GridNC.ReadOnly = True
        Me._GridNC.Size = New System.Drawing.Size(13, 13)
        Me._GridNC.TabIndex = 12
        Me._GridNC.Visible = False
        '
        '_GridEfectivos
        '
        Me._GridEfectivos.AllowUserToAddRows = False
        Me._GridEfectivos.AllowUserToDeleteRows = False
        Me._GridEfectivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridEfectivos.Location = New System.Drawing.Point(838, 0)
        Me._GridEfectivos.Name = "_GridEfectivos"
        Me._GridEfectivos.ReadOnly = True
        Me._GridEfectivos.Size = New System.Drawing.Size(13, 13)
        Me._GridEfectivos.TabIndex = 9
        Me._GridEfectivos.Visible = False
        '
        '_GridVisitados
        '
        Me._GridVisitados.AllowUserToAddRows = False
        Me._GridVisitados.AllowUserToDeleteRows = False
        Me._GridVisitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridVisitados.Location = New System.Drawing.Point(857, 0)
        Me._GridVisitados.Name = "_GridVisitados"
        Me._GridVisitados.ReadOnly = True
        Me._GridVisitados.Size = New System.Drawing.Size(17, 13)
        Me._GridVisitados.TabIndex = 8
        Me._GridVisitados.Visible = False
        '
        '_GridVendedores
        '
        Me._GridVendedores.AllowUserToAddRows = False
        Me._GridVendedores.AllowUserToDeleteRows = False
        Me._GridVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridVendedores.Location = New System.Drawing.Point(880, 0)
        Me._GridVendedores.Name = "_GridVendedores"
        Me._GridVendedores.ReadOnly = True
        Me._GridVendedores.Size = New System.Drawing.Size(14, 13)
        Me._GridVendedores.TabIndex = 7
        Me._GridVendedores.Visible = False
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(817, 35)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(87, 29)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_cmbFechaf
        '
        Me._cmbFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbFechaf.Location = New System.Drawing.Point(495, 39)
        Me._cmbFechaf.Name = "_cmbFechaf"
        Me._cmbFechaf.Size = New System.Drawing.Size(199, 20)
        Me._cmbFechaf.TabIndex = 3
        '
        '_cmbFechai
        '
        Me._cmbFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbFechai.Location = New System.Drawing.Point(197, 39)
        Me._cmbFechai.Name = "_cmbFechai"
        Me._cmbFechai.Size = New System.Drawing.Size(204, 20)
        Me._cmbFechai.TabIndex = 2
        '
        '_lblFechaf
        '
        Me._lblFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaf.AutoSize = True
        Me._lblFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaf.Location = New System.Drawing.Point(403, 41)
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
        Me._lblFechai.Location = New System.Drawing.Point(87, 41)
        Me._lblFechai.Name = "_lblFechai"
        Me._lblFechai.Size = New System.Drawing.Size(104, 17)
        Me._lblFechai.TabIndex = 0
        Me._lblFechai.Text = "Fecha Inicial:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1014, 39)
        Me.ToolStrip1.TabIndex = 7
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
        '_GridEfectividadRF
        '
        Me._GridEfectividadRF.AllowUserToAddRows = False
        Me._GridEfectividadRF.AllowUserToDeleteRows = False
        Me._GridEfectividadRF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._GridEfectividadRF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._GridEfectividadRF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridEfectividadRF.Location = New System.Drawing.Point(13, 133)
        Me._GridEfectividadRF.Name = "_GridEfectividadRF"
        Me._GridEfectividadRF.ReadOnly = True
        Me._GridEfectividadRF.Size = New System.Drawing.Size(989, 367)
        Me._GridEfectividadRF.TabIndex = 8
        '
        'EfectividadRangoFechas_sr_agro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 512)
        Me.Controls.Add(Me._GridEfectividadRF)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EfectividadRangoFechas_sr_agro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Efectividad por Rango de Fechas"
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me._GridNC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._GridEfectivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._GridVisitados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._GridVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me._GridEfectividadRF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _lblFechaf As System.Windows.Forms.Label
    Friend WithEvents _lblFechai As System.Windows.Forms.Label
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _cmbFechaf As System.Windows.Forms.DateTimePicker
    Friend WithEvents _cmbFechai As System.Windows.Forms.DateTimePicker
    Friend WithEvents _GridEfectividadRF As System.Windows.Forms.DataGridView
    Friend WithEvents _GridVendedores As System.Windows.Forms.DataGridView
    Friend WithEvents _GridVisitados As System.Windows.Forms.DataGridView
    Friend WithEvents _GridEfectivos As System.Windows.Forms.DataGridView
    Friend WithEvents _GridNC As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioMenores As System.Windows.Forms.RadioButton
    Friend WithEvents RadioTodos As System.Windows.Forms.RadioButton
End Class
