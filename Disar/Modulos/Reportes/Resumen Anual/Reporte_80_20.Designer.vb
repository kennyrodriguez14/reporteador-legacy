<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reporte_80_20
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reporte_80_20))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me._txtAño = New System.Windows.Forms.NumericUpDown
        Me.cmbMes = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._cmbSucursal = New System.Windows.Forms.ComboBox
        Me.lblSucursal = New System.Windows.Forms.Label
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.Pestañas = New System.Windows.Forms.TabControl
        Me.BIC = New System.Windows.Forms.TabPage
        Me._gridBIC = New System.Windows.Forms.DataGridView
        Me.LIVSMART = New System.Windows.Forms.TabPage
        Me._gridLivsmart = New System.Windows.Forms.DataGridView
        Me.NESTLE = New System.Windows.Forms.TabPage
        Me._gridNestle = New System.Windows.Forms.DataGridView
        Me.COLGATE = New System.Windows.Forms.TabPage
        Me._gridColgate = New System.Windows.Forms.DataGridView
        Me.KC = New System.Windows.Forms.TabPage
        Me._gridKC = New System.Windows.Forms.DataGridView
        Me.alcon = New System.Windows.Forms.TabPage
        Me._gridAlcon = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me._gbCriteriosBusqueda.SuspendLayout()
        CType(Me._txtAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pestañas.SuspendLayout()
        Me.BIC.SuspendLayout()
        CType(Me._gridBIC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LIVSMART.SuspendLayout()
        CType(Me._gridLivsmart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NESTLE.SuspendLayout()
        CType(Me._gridNestle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.COLGATE.SuspendLayout()
        CType(Me._gridColgate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KC.SuspendLayout()
        CType(Me._gridKC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.alcon.SuspendLayout()
        CType(Me._gridAlcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(989, 39)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '_Archivo
        '
        Me._Archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarToolStripMenuItem, Me.CerrarToolStripMenuItem})
        Me._Archivo.Image = Global.Disar.My.Resources.Resources.Opciones
        Me._Archivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Archivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._Archivo.Name = "_Archivo"
        Me._Archivo.Size = New System.Drawing.Size(100, 36)
        Me._Archivo.Text = "Acciones"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Excel_32
        Me.ExportarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.ExportarToolStripMenuItem.Text = "Exportar a Texto"
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.CerrarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
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
        Me._gbCriteriosBusqueda.Controls.Add(Me._txtAño)
        Me._gbCriteriosBusqueda.Controls.Add(Me.cmbMes)
        Me._gbCriteriosBusqueda.Controls.Add(Me.Label2)
        Me._gbCriteriosBusqueda.Controls.Add(Me.Label1)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbSucursal)
        Me._gbCriteriosBusqueda.Controls.Add(Me.lblSucursal)
        Me._gbCriteriosBusqueda.Controls.Add(Me._btnGenerar)
        Me._gbCriteriosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbCriteriosBusqueda.Location = New System.Drawing.Point(12, 42)
        Me._gbCriteriosBusqueda.Name = "_gbCriteriosBusqueda"
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(965, 51)
        Me._gbCriteriosBusqueda.TabIndex = 10
        Me._gbCriteriosBusqueda.TabStop = False
        '
        '_txtAño
        '
        Me._txtAño.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._txtAño.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtAño.Location = New System.Drawing.Point(702, 16)
        Me._txtAño.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me._txtAño.Name = "_txtAño"
        Me._txtAño.Size = New System.Drawing.Size(95, 23)
        Me._txtAño.TabIndex = 3
        Me._txtAño.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me._txtAño.ThousandsSeparator = True
        '
        'cmbMes
        '
        Me.cmbMes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"})
        Me.cmbMes.Location = New System.Drawing.Point(435, 16)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(135, 24)
        Me.cmbMes.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(655, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Año:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(390, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Mes:"
        '
        '_cmbSucursal
        '
        Me._cmbSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbSucursal.FormattingEnabled = True
        Me._cmbSucursal.Items.AddRange(New Object() {"Santa Rosa Copan", "San Pedro Sula", "Saba", "Tegucigalpa"})
        Me._cmbSucursal.Location = New System.Drawing.Point(125, 16)
        Me._cmbSucursal.Name = "_cmbSucursal"
        Me._cmbSucursal.Size = New System.Drawing.Size(192, 24)
        Me._cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSucursal.Location = New System.Drawing.Point(50, 20)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(76, 17)
        Me.lblSucursal.TabIndex = 7
        Me.lblSucursal.Text = "Sucursal:"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(872, 15)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(87, 25)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'Pestañas
        '
        Me.Pestañas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pestañas.Controls.Add(Me.BIC)
        Me.Pestañas.Controls.Add(Me.LIVSMART)
        Me.Pestañas.Controls.Add(Me.NESTLE)
        Me.Pestañas.Controls.Add(Me.COLGATE)
        Me.Pestañas.Controls.Add(Me.KC)
        Me.Pestañas.Controls.Add(Me.alcon)
        Me.Pestañas.Location = New System.Drawing.Point(12, 99)
        Me.Pestañas.Name = "Pestañas"
        Me.Pestañas.SelectedIndex = 0
        Me.Pestañas.Size = New System.Drawing.Size(965, 395)
        Me.Pestañas.TabIndex = 12
        '
        'BIC
        '
        Me.BIC.Controls.Add(Me._gridBIC)
        Me.BIC.Location = New System.Drawing.Point(4, 22)
        Me.BIC.Name = "BIC"
        Me.BIC.Padding = New System.Windows.Forms.Padding(3)
        Me.BIC.Size = New System.Drawing.Size(957, 369)
        Me.BIC.TabIndex = 0
        Me.BIC.Text = "BIC"
        Me.BIC.UseVisualStyleBackColor = True
        '
        '_gridBIC
        '
        Me._gridBIC.AllowUserToAddRows = False
        Me._gridBIC.AllowUserToDeleteRows = False
        Me._gridBIC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gridBIC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridBIC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridBIC.Location = New System.Drawing.Point(0, 0)
        Me._gridBIC.Name = "_gridBIC"
        Me._gridBIC.ReadOnly = True
        Me._gridBIC.Size = New System.Drawing.Size(957, 369)
        Me._gridBIC.TabIndex = 13
        '
        'LIVSMART
        '
        Me.LIVSMART.Controls.Add(Me._gridLivsmart)
        Me.LIVSMART.Location = New System.Drawing.Point(4, 22)
        Me.LIVSMART.Name = "LIVSMART"
        Me.LIVSMART.Padding = New System.Windows.Forms.Padding(3)
        Me.LIVSMART.Size = New System.Drawing.Size(957, 369)
        Me.LIVSMART.TabIndex = 1
        Me.LIVSMART.Text = "LIVSMART"
        Me.LIVSMART.UseVisualStyleBackColor = True
        '
        '_gridLivsmart
        '
        Me._gridLivsmart.AllowUserToAddRows = False
        Me._gridLivsmart.AllowUserToDeleteRows = False
        Me._gridLivsmart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gridLivsmart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridLivsmart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridLivsmart.Location = New System.Drawing.Point(0, 0)
        Me._gridLivsmart.Name = "_gridLivsmart"
        Me._gridLivsmart.ReadOnly = True
        Me._gridLivsmart.Size = New System.Drawing.Size(957, 369)
        Me._gridLivsmart.TabIndex = 12
        '
        'NESTLE
        '
        Me.NESTLE.Controls.Add(Me._gridNestle)
        Me.NESTLE.Location = New System.Drawing.Point(4, 22)
        Me.NESTLE.Name = "NESTLE"
        Me.NESTLE.Size = New System.Drawing.Size(957, 369)
        Me.NESTLE.TabIndex = 2
        Me.NESTLE.Text = "NESTLE"
        Me.NESTLE.UseVisualStyleBackColor = True
        '
        '_gridNestle
        '
        Me._gridNestle.AllowUserToAddRows = False
        Me._gridNestle.AllowUserToDeleteRows = False
        Me._gridNestle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridNestle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridNestle.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridNestle.Location = New System.Drawing.Point(0, 0)
        Me._gridNestle.Name = "_gridNestle"
        Me._gridNestle.ReadOnly = True
        Me._gridNestle.Size = New System.Drawing.Size(957, 369)
        Me._gridNestle.TabIndex = 12
        '
        'COLGATE
        '
        Me.COLGATE.Controls.Add(Me._gridColgate)
        Me.COLGATE.Location = New System.Drawing.Point(4, 22)
        Me.COLGATE.Name = "COLGATE"
        Me.COLGATE.Size = New System.Drawing.Size(957, 369)
        Me.COLGATE.TabIndex = 3
        Me.COLGATE.Text = "COLGATE"
        Me.COLGATE.UseVisualStyleBackColor = True
        '
        '_gridColgate
        '
        Me._gridColgate.AllowUserToAddRows = False
        Me._gridColgate.AllowUserToDeleteRows = False
        Me._gridColgate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridColgate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridColgate.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridColgate.Location = New System.Drawing.Point(0, 0)
        Me._gridColgate.Name = "_gridColgate"
        Me._gridColgate.ReadOnly = True
        Me._gridColgate.Size = New System.Drawing.Size(957, 369)
        Me._gridColgate.TabIndex = 12
        '
        'KC
        '
        Me.KC.Controls.Add(Me._gridKC)
        Me.KC.Location = New System.Drawing.Point(4, 22)
        Me.KC.Name = "KC"
        Me.KC.Size = New System.Drawing.Size(957, 369)
        Me.KC.TabIndex = 4
        Me.KC.Text = "KC"
        Me.KC.UseVisualStyleBackColor = True
        '
        '_gridKC
        '
        Me._gridKC.AllowUserToAddRows = False
        Me._gridKC.AllowUserToDeleteRows = False
        Me._gridKC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridKC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridKC.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridKC.Location = New System.Drawing.Point(0, 0)
        Me._gridKC.Name = "_gridKC"
        Me._gridKC.ReadOnly = True
        Me._gridKC.Size = New System.Drawing.Size(957, 369)
        Me._gridKC.TabIndex = 12
        '
        'alcon
        '
        Me.alcon.Controls.Add(Me._gridAlcon)
        Me.alcon.Location = New System.Drawing.Point(4, 22)
        Me.alcon.Name = "alcon"
        Me.alcon.Padding = New System.Windows.Forms.Padding(3)
        Me.alcon.Size = New System.Drawing.Size(957, 369)
        Me.alcon.TabIndex = 5
        Me.alcon.Text = "ALCON"
        Me.alcon.UseVisualStyleBackColor = True
        '
        '_gridAlcon
        '
        Me._gridAlcon.AllowUserToAddRows = False
        Me._gridAlcon.AllowUserToDeleteRows = False
        Me._gridAlcon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridAlcon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridAlcon.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridAlcon.Location = New System.Drawing.Point(3, 3)
        Me._gridAlcon.Name = "_gridAlcon"
        Me._gridAlcon.ReadOnly = True
        Me._gridAlcon.Size = New System.Drawing.Size(951, 363)
        Me._gridAlcon.TabIndex = 13
        '
        'Reporte_80_20
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(989, 506)
        Me.Controls.Add(Me.Pestañas)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Reporte_80_20"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte 80 / 20"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        CType(Me._txtAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pestañas.ResumeLayout(False)
        Me.BIC.ResumeLayout(False)
        CType(Me._gridBIC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LIVSMART.ResumeLayout(False)
        CType(Me._gridLivsmart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NESTLE.ResumeLayout(False)
        CType(Me._gridNestle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.COLGATE.ResumeLayout(False)
        CType(Me._gridColgate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KC.ResumeLayout(False)
        CType(Me._gridKC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.alcon.ResumeLayout(False)
        CType(Me._gridAlcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents _txtAño As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Pestañas As System.Windows.Forms.TabControl
    Friend WithEvents BIC As System.Windows.Forms.TabPage
    Friend WithEvents LIVSMART As System.Windows.Forms.TabPage
    Friend WithEvents NESTLE As System.Windows.Forms.TabPage
    Friend WithEvents COLGATE As System.Windows.Forms.TabPage
    Friend WithEvents KC As System.Windows.Forms.TabPage
    Friend WithEvents _gridNestle As System.Windows.Forms.DataGridView
    Friend WithEvents _gridColgate As System.Windows.Forms.DataGridView
    Friend WithEvents _gridKC As System.Windows.Forms.DataGridView
    Friend WithEvents _gridLivsmart As System.Windows.Forms.DataGridView
    Friend WithEvents _gridBIC As System.Windows.Forms.DataGridView
    Friend WithEvents alcon As System.Windows.Forms.TabPage
    Friend WithEvents _gridAlcon As System.Windows.Forms.DataGridView
End Class
