<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Combustible
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Combustible))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me.sucursal = New System.Windows.Forms.ComboBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.Fin = New System.Windows.Forms.DateTimePicker
        Me.Inicio = New System.Windows.Forms.DateTimePicker
        Me._lblFechaf = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblFechai = New System.Windows.Forms.Label
        Me.combustibles = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me._gbCriteriosBusqueda.SuspendLayout()
        CType(Me.combustibles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(929, 39)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '_Archivo
        '
        Me._Archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAExcelToolStripMenuItem})
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        '_gbCriteriosBusqueda
        '
        Me._gbCriteriosBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gbCriteriosBusqueda.Controls.Add(Me.sucursal)
        Me._gbCriteriosBusqueda.Controls.Add(Me._btnGenerar)
        Me._gbCriteriosBusqueda.Controls.Add(Me.Fin)
        Me._gbCriteriosBusqueda.Controls.Add(Me.Inicio)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me.Label1)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechai)
        Me._gbCriteriosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbCriteriosBusqueda.Location = New System.Drawing.Point(12, 42)
        Me._gbCriteriosBusqueda.Name = "_gbCriteriosBusqueda"
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(905, 73)
        Me._gbCriteriosBusqueda.TabIndex = 25
        Me._gbCriteriosBusqueda.TabStop = False
        Me._gbCriteriosBusqueda.Text = "Criterios de Busqueda"
        '
        'sucursal
        '
        Me.sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sucursal.FormattingEnabled = True
        Me.sucursal.Items.AddRange(New Object() {"SRC", "SPS"})
        Me.sucursal.Location = New System.Drawing.Point(86, 33)
        Me.sucursal.Name = "sucursal"
        Me.sucursal.Size = New System.Drawing.Size(74, 21)
        Me.sucursal.TabIndex = 1
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(819, 31)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(79, 23)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'Fin
        '
        Me.Fin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fin.Location = New System.Drawing.Point(597, 34)
        Me.Fin.Name = "Fin"
        Me.Fin.Size = New System.Drawing.Size(210, 20)
        Me.Fin.TabIndex = 3
        '
        'Inicio
        '
        Me.Inicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Inicio.Location = New System.Drawing.Point(277, 34)
        Me.Inicio.Name = "Inicio"
        Me.Inicio.Size = New System.Drawing.Size(211, 20)
        Me.Inicio.TabIndex = 2
        '
        '_lblFechaf
        '
        Me._lblFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaf.AutoSize = True
        Me._lblFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaf.Location = New System.Drawing.Point(499, 34)
        Me._lblFechaf.Name = "_lblFechaf"
        Me._lblFechaf.Size = New System.Drawing.Size(97, 17)
        Me._lblFechaf.TabIndex = 1
        Me._lblFechaf.Text = "Fecha Final:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sucursal:"
        '
        '_lblFechai
        '
        Me._lblFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechai.AutoSize = True
        Me._lblFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechai.Location = New System.Drawing.Point(172, 34)
        Me._lblFechai.Name = "_lblFechai"
        Me._lblFechai.Size = New System.Drawing.Size(104, 17)
        Me._lblFechai.TabIndex = 0
        Me._lblFechai.Text = "Fecha Inicial:"
        '
        'combustibles
        '
        Me.combustibles.AllowUserToAddRows = False
        Me.combustibles.AllowUserToDeleteRows = False
        Me.combustibles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.combustibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.combustibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.combustibles.Location = New System.Drawing.Point(12, 122)
        Me.combustibles.Name = "combustibles"
        Me.combustibles.ReadOnly = True
        Me.combustibles.Size = New System.Drawing.Size(905, 400)
        Me.combustibles.TabIndex = 26
        '
        'Combustible
        '
        Me.AcceptButton = Me._btnGenerar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 534)
        Me.Controls.Add(Me.combustibles)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Combustible"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Combustible"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        CType(Me.combustibles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechaf As System.Windows.Forms.Label
    Friend WithEvents _lblFechai As System.Windows.Forms.Label
    Friend WithEvents sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents combustibles As System.Windows.Forms.DataGridView
End Class
