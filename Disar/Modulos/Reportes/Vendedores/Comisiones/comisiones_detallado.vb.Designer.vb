<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class comisiones_detallado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(comisiones_detallado))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._cmbFechaf = New System.Windows.Forms.DateTimePicker
        Me._cmbFechai = New System.Windows.Forms.DateTimePicker
        Me._lblFechaf = New System.Windows.Forms.Label
        Me._lblFechai = New System.Windows.Forms.Label
        Me.pestañas = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.gridComisiones_detalle = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grd_comisiones_mayoreo = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.grd_sr_agro = New System.Windows.Forms.DataGridView
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me._gbCriteriosBusqueda.SuspendLayout()
        Me.pestañas.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.gridComisiones_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grd_comisiones_mayoreo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.grd_sr_agro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1162, 39)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 36)
        Me.ToolStripButton1.Tag = "Exportar a Excel"
        Me.ToolStripButton1.Text = "Excel"
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
        Me._gbCriteriosBusqueda.Controls.Add(Me.cmb_almacen)
        Me._gbCriteriosBusqueda.Controls.Add(Me.Label1)
        Me._gbCriteriosBusqueda.Controls.Add(Me._btnGenerar)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechai)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechai)
        Me._gbCriteriosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbCriteriosBusqueda.Location = New System.Drawing.Point(12, 42)
        Me._gbCriteriosBusqueda.Name = "_gbCriteriosBusqueda"
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(1138, 45)
        Me._gbCriteriosBusqueda.TabIndex = 18
        Me._gbCriteriosBusqueda.TabStop = False
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(1039, 14)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(77, 25)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_cmbFechaf
        '
        Me._cmbFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechaf.Location = New System.Drawing.Point(774, 16)
        Me._cmbFechaf.Name = "_cmbFechaf"
        Me._cmbFechaf.Size = New System.Drawing.Size(257, 23)
        Me._cmbFechaf.TabIndex = 3
        '
        '_cmbFechai
        '
        Me._cmbFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechai.Location = New System.Drawing.Point(412, 16)
        Me._cmbFechai.Name = "_cmbFechai"
        Me._cmbFechai.Size = New System.Drawing.Size(260, 23)
        Me._cmbFechai.TabIndex = 2
        '
        '_lblFechaf
        '
        Me._lblFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaf.AutoSize = True
        Me._lblFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaf.Location = New System.Drawing.Point(679, 18)
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
        Me._lblFechai.Location = New System.Drawing.Point(310, 18)
        Me._lblFechai.Name = "_lblFechai"
        Me._lblFechai.Size = New System.Drawing.Size(104, 17)
        Me._lblFechai.TabIndex = 0
        Me._lblFechai.Text = "Fecha Inicial:"
        '
        'pestañas
        '
        Me.pestañas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pestañas.Controls.Add(Me.TabPage1)
        Me.pestañas.Controls.Add(Me.TabPage2)
        Me.pestañas.Controls.Add(Me.TabPage3)
        Me.pestañas.Location = New System.Drawing.Point(12, 93)
        Me.pestañas.Name = "pestañas"
        Me.pestañas.SelectedIndex = 0
        Me.pestañas.Size = New System.Drawing.Size(1138, 378)
        Me.pestañas.TabIndex = 19
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gridComisiones_detalle)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1130, 352)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'gridComisiones_detalle
        '
        Me.gridComisiones_detalle.AllowUserToAddRows = False
        Me.gridComisiones_detalle.AllowUserToDeleteRows = False
        Me.gridComisiones_detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.gridComisiones_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridComisiones_detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridComisiones_detalle.Location = New System.Drawing.Point(3, 3)
        Me.gridComisiones_detalle.Name = "gridComisiones_detalle"
        Me.gridComisiones_detalle.ReadOnly = True
        Me.gridComisiones_detalle.Size = New System.Drawing.Size(1124, 346)
        Me.gridComisiones_detalle.TabIndex = 12
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grd_comisiones_mayoreo)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(960, 352)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Mayoreo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grd_comisiones_mayoreo
        '
        Me.grd_comisiones_mayoreo.AllowUserToAddRows = False
        Me.grd_comisiones_mayoreo.AllowUserToDeleteRows = False
        Me.grd_comisiones_mayoreo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_comisiones_mayoreo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_comisiones_mayoreo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_comisiones_mayoreo.Location = New System.Drawing.Point(3, 3)
        Me.grd_comisiones_mayoreo.Name = "grd_comisiones_mayoreo"
        Me.grd_comisiones_mayoreo.ReadOnly = True
        Me.grd_comisiones_mayoreo.Size = New System.Drawing.Size(954, 346)
        Me.grd_comisiones_mayoreo.TabIndex = 13
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.grd_sr_agro)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(960, 352)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "SR Agro"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'grd_sr_agro
        '
        Me.grd_sr_agro.AllowUserToAddRows = False
        Me.grd_sr_agro.AllowUserToDeleteRows = False
        Me.grd_sr_agro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_sr_agro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_sr_agro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_sr_agro.Location = New System.Drawing.Point(3, 3)
        Me.grd_sr_agro.Name = "grd_sr_agro"
        Me.grd_sr_agro.ReadOnly = True
        Me.grd_sr_agro.Size = New System.Drawing.Size(954, 346)
        Me.grd_sr_agro.TabIndex = 14
        '
        'cmb_almacen
        '
        Me.cmb_almacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(84, 15)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(227, 24)
        Me.cmb_almacen.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Almacen:"
        '
        'comisiones_detallado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1162, 483)
        Me.Controls.Add(Me.pestañas)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "comisiones_detallado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "comisiones_detallado"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        Me.pestañas.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.gridComisiones_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grd_comisiones_mayoreo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.grd_sr_agro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _cmbFechaf As System.Windows.Forms.DateTimePicker
    Friend WithEvents _cmbFechai As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechaf As System.Windows.Forms.Label
    Friend WithEvents _lblFechai As System.Windows.Forms.Label
    Friend WithEvents pestañas As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents gridComisiones_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grd_comisiones_mayoreo As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents grd_sr_agro As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
