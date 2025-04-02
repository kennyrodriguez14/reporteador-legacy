<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_pivot_ventas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_pivot_ventas))
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me.rdbtn_mensual = New System.Windows.Forms.RadioButton
        Me.rdbtn_consolidado = New System.Windows.Forms.RadioButton
        Me.cmb_linea = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblSucursal = New System.Windows.Forms.Label
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._cmbFechaf = New System.Windows.Forms.DateTimePicker
        Me._cmbFechai = New System.Windows.Forms.DateTimePicker
        Me._lblFechaf = New System.Windows.Forms.Label
        Me._lblFechai = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExcelRapidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExcelNormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.grd_pivot_ventas = New System.Windows.Forms.DataGridView
        Me._gbCriteriosBusqueda.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grd_pivot_ventas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_gbCriteriosBusqueda
        '
        Me._gbCriteriosBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gbCriteriosBusqueda.Controls.Add(Me.rdbtn_mensual)
        Me._gbCriteriosBusqueda.Controls.Add(Me.rdbtn_consolidado)
        Me._gbCriteriosBusqueda.Controls.Add(Me.cmb_linea)
        Me._gbCriteriosBusqueda.Controls.Add(Me.Label1)
        Me._gbCriteriosBusqueda.Controls.Add(Me.cmbAlmacen)
        Me._gbCriteriosBusqueda.Controls.Add(Me.Label2)
        Me._gbCriteriosBusqueda.Controls.Add(Me.lblSucursal)
        Me._gbCriteriosBusqueda.Controls.Add(Me._btnGenerar)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechai)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechai)
        Me._gbCriteriosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbCriteriosBusqueda.Location = New System.Drawing.Point(12, 40)
        Me._gbCriteriosBusqueda.Name = "_gbCriteriosBusqueda"
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(1237, 80)
        Me._gbCriteriosBusqueda.TabIndex = 11
        Me._gbCriteriosBusqueda.TabStop = False
        Me._gbCriteriosBusqueda.Text = "Criterios de Busqueda"
        '
        'rdbtn_mensual
        '
        Me.rdbtn_mensual.AutoSize = True
        Me.rdbtn_mensual.Location = New System.Drawing.Point(98, 48)
        Me.rdbtn_mensual.Name = "rdbtn_mensual"
        Me.rdbtn_mensual.Size = New System.Drawing.Size(79, 21)
        Me.rdbtn_mensual.TabIndex = 14
        Me.rdbtn_mensual.Text = "Mensual"
        Me.rdbtn_mensual.UseVisualStyleBackColor = True
        '
        'rdbtn_consolidado
        '
        Me.rdbtn_consolidado.AutoSize = True
        Me.rdbtn_consolidado.Checked = True
        Me.rdbtn_consolidado.Location = New System.Drawing.Point(98, 25)
        Me.rdbtn_consolidado.Name = "rdbtn_consolidado"
        Me.rdbtn_consolidado.Size = New System.Drawing.Size(104, 21)
        Me.rdbtn_consolidado.TabIndex = 14
        Me.rdbtn_consolidado.TabStop = True
        Me.rdbtn_consolidado.Text = "Consolidado"
        Me.rdbtn_consolidado.UseVisualStyleBackColor = True
        '
        'cmb_linea
        '
        Me.cmb_linea.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_linea.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmb_linea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_linea.FormattingEnabled = True
        Me.cmb_linea.Location = New System.Drawing.Point(326, 48)
        Me.cmb_linea.Name = "cmb_linea"
        Me.cmb_linea.Size = New System.Drawing.Size(273, 24)
        Me.cmb_linea.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(271, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Linea:"
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbAlmacen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(326, 17)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(273, 24)
        Me.cmbAlmacen.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Tipo:"
        '
        'lblSucursal
        '
        Me.lblSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSucursal.Location = New System.Drawing.Point(248, 20)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(76, 17)
        Me.lblSucursal.TabIndex = 13
        Me.lblSucursal.Text = "Sucursal:"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(1148, 32)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(83, 25)
        Me._btnGenerar.TabIndex = 3
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_cmbFechaf
        '
        Me._cmbFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechaf.Location = New System.Drawing.Point(683, 49)
        Me._cmbFechaf.Name = "_cmbFechaf"
        Me._cmbFechaf.Size = New System.Drawing.Size(259, 23)
        Me._cmbFechaf.TabIndex = 2
        '
        '_cmbFechai
        '
        Me._cmbFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechai.Location = New System.Drawing.Point(683, 20)
        Me._cmbFechai.Name = "_cmbFechai"
        Me._cmbFechai.Size = New System.Drawing.Size(259, 23)
        Me._cmbFechai.TabIndex = 1
        '
        '_lblFechaf
        '
        Me._lblFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaf.AutoSize = True
        Me._lblFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaf.Location = New System.Drawing.Point(651, 52)
        Me._lblFechaf.Name = "_lblFechaf"
        Me._lblFechaf.Size = New System.Drawing.Size(35, 17)
        Me._lblFechaf.TabIndex = 1
        Me._lblFechaf.Text = "Fin:"
        '
        '_lblFechai
        '
        Me._lblFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechai.AutoSize = True
        Me._lblFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechai.Location = New System.Drawing.Point(635, 22)
        Me._lblFechai.Name = "_lblFechai"
        Me._lblFechai.Size = New System.Drawing.Size(51, 17)
        Me._lblFechai.TabIndex = 0
        Me._lblFechai.Text = "Inicio:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripDropDownButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1261, 39)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelRapidoToolStripMenuItem, Me.ExcelNormalToolStripMenuItem})
        Me.ToolStripDropDownButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripDropDownButton1.Image = Global.Disar.My.Resources.Resources.Excel_32
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(141, 36)
        Me.ToolStripDropDownButton1.Text = "Exportar a Excel"
        '
        'ExcelRapidoToolStripMenuItem
        '
        Me.ExcelRapidoToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.ExcelRapidoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExcelRapidoToolStripMenuItem.Name = "ExcelRapidoToolStripMenuItem"
        Me.ExcelRapidoToolStripMenuItem.Size = New System.Drawing.Size(178, 38)
        Me.ExcelRapidoToolStripMenuItem.Text = "Exporte Rápido"
        '
        'ExcelNormalToolStripMenuItem
        '
        Me.ExcelNormalToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.img_exce_normal
        Me.ExcelNormalToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExcelNormalToolStripMenuItem.Name = "ExcelNormalToolStripMenuItem"
        Me.ExcelNormalToolStripMenuItem.Size = New System.Drawing.Size(178, 38)
        Me.ExcelNormalToolStripMenuItem.Text = "Exporte Normal"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'grd_pivot_ventas
        '
        Me.grd_pivot_ventas.AllowUserToAddRows = False
        Me.grd_pivot_ventas.AllowUserToDeleteRows = False
        Me.grd_pivot_ventas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_pivot_ventas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_pivot_ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_pivot_ventas.Location = New System.Drawing.Point(12, 126)
        Me.grd_pivot_ventas.Name = "grd_pivot_ventas"
        Me.grd_pivot_ventas.ReadOnly = True
        Me.grd_pivot_ventas.Size = New System.Drawing.Size(1237, 485)
        Me.grd_pivot_ventas.TabIndex = 13
        '
        'frm_pivot_ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1261, 623)
        Me.Controls.Add(Me.grd_pivot_ventas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_pivot_ventas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pivot de Ventas"
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grd_pivot_ventas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _cmbFechaf As System.Windows.Forms.DateTimePicker
    Friend WithEvents _cmbFechai As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechaf As System.Windows.Forms.Label
    Friend WithEvents _lblFechai As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grd_pivot_ventas As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_linea As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdbtn_mensual As System.Windows.Forms.RadioButton
    Friend WithEvents rdbtn_consolidado As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExcelRapidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcelNormalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
