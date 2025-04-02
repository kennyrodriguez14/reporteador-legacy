<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rentabilidad_por_Producto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rentabilidad_por_Producto))
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me.cmbproveedor = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbvendedor = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me._cmbSucursal = New System.Windows.Forms.ComboBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.lblSucursal = New System.Windows.Forms.Label
        Me._cmbFechaf = New System.Windows.Forms.DateTimePicker
        Me._lblFechai = New System.Windows.Forms.Label
        Me._cmbFechai = New System.Windows.Forms.DateTimePicker
        Me._lblFechaf = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._GridRentabilidad = New System.Windows.Forms.DataGridView
        Me._gbCriteriosBusqueda.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me._GridRentabilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_gbCriteriosBusqueda
        '
        Me._gbCriteriosBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gbCriteriosBusqueda.Controls.Add(Me.cmbproveedor)
        Me._gbCriteriosBusqueda.Controls.Add(Me.Label2)
        Me._gbCriteriosBusqueda.Controls.Add(Me.cmbvendedor)
        Me._gbCriteriosBusqueda.Controls.Add(Me.Label1)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbSucursal)
        Me._gbCriteriosBusqueda.Controls.Add(Me._btnGenerar)
        Me._gbCriteriosBusqueda.Controls.Add(Me.lblSucursal)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechai)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechai)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechaf)
        Me._gbCriteriosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbCriteriosBusqueda.Location = New System.Drawing.Point(12, 41)
        Me._gbCriteriosBusqueda.Name = "_gbCriteriosBusqueda"
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(913, 88)
        Me._gbCriteriosBusqueda.TabIndex = 17
        Me._gbCriteriosBusqueda.TabStop = False
        '
        'cmbproveedor
        '
        Me.cmbproveedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbproveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbproveedor.FormattingEnabled = True
        Me.cmbproveedor.Items.AddRange(New Object() {"TODOS"})
        Me.cmbproveedor.Location = New System.Drawing.Point(677, 54)
        Me.cmbproveedor.Name = "cmbproveedor"
        Me.cmbproveedor.Size = New System.Drawing.Size(225, 24)
        Me.cmbproveedor.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(592, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Proveedor:"
        '
        'cmbvendedor
        '
        Me.cmbvendedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbvendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbvendedor.FormattingEnabled = True
        Me.cmbvendedor.Items.AddRange(New Object() {"TODOS"})
        Me.cmbvendedor.Location = New System.Drawing.Point(327, 54)
        Me.cmbvendedor.Name = "cmbvendedor"
        Me.cmbvendedor.Size = New System.Drawing.Size(246, 24)
        Me.cmbvendedor.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(244, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Vendedor:"
        '
        '_cmbSucursal
        '
        Me._cmbSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbSucursal.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbSucursal.FormattingEnabled = True
        Me._cmbSucursal.Items.AddRange(New Object() {"SRC", "SPS", "Tocoa", "SR AGRO", "CONSUMO"})
        Me._cmbSucursal.Location = New System.Drawing.Point(93, 54)
        Me._cmbSucursal.Name = "_cmbSucursal"
        Me._cmbSucursal.Size = New System.Drawing.Size(130, 24)
        Me._cmbSucursal.TabIndex = 3
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(821, 16)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(79, 23)
        Me._btnGenerar.TabIndex = 6
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'lblSucursal
        '
        Me.lblSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSucursal.Location = New System.Drawing.Point(19, 57)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(76, 17)
        Me.lblSucursal.TabIndex = 7
        Me.lblSucursal.Text = "Sucursal:"
        '
        '_cmbFechaf
        '
        Me._cmbFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechaf.Location = New System.Drawing.Point(529, 17)
        Me._cmbFechaf.Name = "_cmbFechaf"
        Me._cmbFechaf.Size = New System.Drawing.Size(272, 23)
        Me._cmbFechaf.TabIndex = 2
        '
        '_lblFechai
        '
        Me._lblFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechai.AutoSize = True
        Me._lblFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechai.Location = New System.Drawing.Point(26, 19)
        Me._lblFechai.Name = "_lblFechai"
        Me._lblFechai.Size = New System.Drawing.Size(104, 17)
        Me._lblFechai.TabIndex = 0
        Me._lblFechai.Text = "Fecha Inicial:"
        '
        '_cmbFechai
        '
        Me._cmbFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechai.Location = New System.Drawing.Point(132, 17)
        Me._cmbFechai.Name = "_cmbFechai"
        Me._cmbFechai.Size = New System.Drawing.Size(277, 23)
        Me._cmbFechai.TabIndex = 1
        '
        '_lblFechaf
        '
        Me._lblFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaf.AutoSize = True
        Me._lblFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaf.Location = New System.Drawing.Point(431, 19)
        Me._lblFechaf.Name = "_lblFechaf"
        Me._lblFechaf.Size = New System.Drawing.Size(97, 17)
        Me._lblFechaf.TabIndex = 1
        Me._lblFechaf.Text = "Fecha Final:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(937, 39)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
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
        '_GridRentabilidad
        '
        Me._GridRentabilidad.AllowUserToAddRows = False
        Me._GridRentabilidad.AllowUserToDeleteRows = False
        Me._GridRentabilidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._GridRentabilidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._GridRentabilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridRentabilidad.Location = New System.Drawing.Point(12, 135)
        Me._GridRentabilidad.Name = "_GridRentabilidad"
        Me._GridRentabilidad.ReadOnly = True
        Me._GridRentabilidad.Size = New System.Drawing.Size(913, 395)
        Me._GridRentabilidad.TabIndex = 19
        '
        'Rentabilidad_por_Producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 542)
        Me.Controls.Add(Me._GridRentabilidad)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Rentabilidad_por_Producto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rentabilidad por Producto"
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me._GridRentabilidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents cmbproveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbvendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents _cmbFechaf As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechai As System.Windows.Forms.Label
    Friend WithEvents _cmbFechai As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechaf As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _GridRentabilidad As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
