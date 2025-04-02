<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CoberturaProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CoberturaProducto))
        Me._gridUniverso = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me._GridCobertura = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._cmbFechaFinal = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextProductoNombre = New System.Windows.Forms.TextBox
        Me.TextProducto = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.ComboLineas = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._cmbFechaInicial = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me._cmbSucursal = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me._gridVentas = New System.Windows.Forms.DataGridView
        CType(Me._gridUniverso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._GridCobertura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me._gridVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_gridUniverso
        '
        Me._gridUniverso.AllowUserToAddRows = False
        Me._gridUniverso.AllowUserToDeleteRows = False
        Me._gridUniverso.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._gridUniverso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridUniverso.Location = New System.Drawing.Point(12, 342)
        Me._gridUniverso.Name = "_gridUniverso"
        Me._gridUniverso.ReadOnly = True
        Me._gridUniverso.Size = New System.Drawing.Size(377, 166)
        Me._gridUniverso.TabIndex = 15
        Me._gridUniverso.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(685, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fecha Final:"
        '
        '_GridCobertura
        '
        Me._GridCobertura.AllowUserToAddRows = False
        Me._GridCobertura.AllowUserToDeleteRows = False
        Me._GridCobertura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._GridCobertura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._GridCobertura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._GridCobertura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridCobertura.Location = New System.Drawing.Point(12, 179)
        Me._GridCobertura.Name = "_GridCobertura"
        Me._GridCobertura.ReadOnly = True
        Me._GridCobertura.Size = New System.Drawing.Size(1199, 329)
        Me._GridCobertura.TabIndex = 14
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1223, 39)
        Me.ToolStrip1.TabIndex = 12
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
        '_cmbFechaFinal
        '
        Me._cmbFechaFinal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechaFinal.Location = New System.Drawing.Point(781, 27)
        Me._cmbFechaFinal.Name = "_cmbFechaFinal"
        Me._cmbFechaFinal.Size = New System.Drawing.Size(302, 26)
        Me._cmbFechaFinal.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TextProductoNombre)
        Me.GroupBox1.Controls.Add(Me.TextProducto)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ComboLineas)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me._cmbFechaFinal)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me._btnGenerar)
        Me.GroupBox1.Controls.Add(Me._cmbFechaInicial)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me._cmbSucursal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1199, 125)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Criterios de Busqueda"
        '
        'TextProductoNombre
        '
        Me.TextProductoNombre.Enabled = False
        Me.TextProductoNombre.Location = New System.Drawing.Point(641, 76)
        Me.TextProductoNombre.Name = "TextProductoNombre"
        Me.TextProductoNombre.Size = New System.Drawing.Size(442, 26)
        Me.TextProductoNombre.TabIndex = 12
        '
        'TextProducto
        '
        Me.TextProducto.Enabled = False
        Me.TextProducto.Location = New System.Drawing.Point(394, 75)
        Me.TextProducto.Name = "TextProducto"
        Me.TextProducto.Size = New System.Drawing.Size(241, 26)
        Me.TextProducto.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(287, 75)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 28)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Producto"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboLineas
        '
        Me.ComboLineas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ComboLineas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboLineas.FormattingEnabled = True
        Me.ComboLineas.Items.AddRange(New Object() {"SPS", "SRC", "Tocoa", "Tegucigalpa"})
        Me.ComboLineas.Location = New System.Drawing.Point(84, 75)
        Me.ComboLineas.Name = "ComboLineas"
        Me.ComboLineas.Size = New System.Drawing.Size(194, 28)
        Me.ComboLineas.TabIndex = 9
        Me.ComboLineas.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Linea:"
        Me.Label4.Visible = False
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Location = New System.Drawing.Point(1098, 43)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(86, 44)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_cmbFechaInicial
        '
        Me._cmbFechaInicial.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechaInicial.Location = New System.Drawing.Point(383, 27)
        Me._cmbFechaInicial.Name = "_cmbFechaInicial"
        Me._cmbFechaInicial.Size = New System.Drawing.Size(302, 26)
        Me._cmbFechaInicial.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(284, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha Inicial:"
        '
        '_cmbSucursal
        '
        Me._cmbSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbSucursal.FormattingEnabled = True
        Me._cmbSucursal.Items.AddRange(New Object() {"SPS", "SRC", "Saba", "Tegucigalpa"})
        Me._cmbSucursal.Location = New System.Drawing.Point(84, 25)
        Me._cmbSucursal.Name = "_cmbSucursal"
        Me._cmbSucursal.Size = New System.Drawing.Size(194, 28)
        Me._cmbSucursal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sucursal:"
        '
        '_gridVentas
        '
        Me._gridVentas.AllowUserToAddRows = False
        Me._gridVentas.AllowUserToDeleteRows = False
        Me._gridVentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._gridVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridVentas.Location = New System.Drawing.Point(834, 342)
        Me._gridVentas.Name = "_gridVentas"
        Me._gridVentas.ReadOnly = True
        Me._gridVentas.Size = New System.Drawing.Size(377, 166)
        Me._gridVentas.TabIndex = 16
        Me._gridVentas.Visible = False
        '
        'CoberturaProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1223, 514)
        Me.Controls.Add(Me._gridUniverso)
        Me.Controls.Add(Me._GridCobertura)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me._gridVentas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CoberturaProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobertura Por Producto"
        CType(Me._gridUniverso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._GridCobertura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me._gridVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _gridUniverso As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents _GridCobertura As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _cmbFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _cmbFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents _cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _gridVentas As System.Windows.Forms.DataGridView
    Friend WithEvents TextProductoNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextProducto As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboLineas As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
