<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Efectividad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Efectividad))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextSemana = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RadioMenores = New System.Windows.Forms.RadioButton
        Me.RadioTodos = New System.Windows.Forms.RadioButton
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._FechaInicial = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me._Sucursal = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._GridEfectividad = New System.Windows.Forms.DataGridView
        Me.ListaVendedores = New System.Windows.Forms.DataGridView
        Me.DGNE = New System.Windows.Forms.DataGridView
        Me._GridDiaVisita = New System.Windows.Forms.DataGridView
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me._gridNCDiarias = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me._GridEfectividad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListaVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGNE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._GridDiaVisita, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me._gridNCDiarias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TextSemana)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me._btnGenerar)
        Me.GroupBox1.Controls.Add(Me._FechaInicial)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me._Sucursal)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1005, 85)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Criterios de Busqueda"
        '
        'TextSemana
        '
        Me.TextSemana.Location = New System.Drawing.Point(838, 35)
        Me.TextSemana.Name = "TextSemana"
        Me.TextSemana.Size = New System.Drawing.Size(37, 26)
        Me.TextSemana.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.Controls.Add(Me.RadioMenores)
        Me.GroupBox2.Controls.Add(Me.RadioTodos)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(207, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(121, 63)
        Me.GroupBox2.TabIndex = 4
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
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Location = New System.Drawing.Point(913, 36)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(86, 26)
        Me._btnGenerar.TabIndex = 3
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_FechaInicial
        '
        Me._FechaInicial.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._FechaInicial.Location = New System.Drawing.Point(442, 35)
        Me._FechaInicial.Name = "_FechaInicial"
        Me._FechaInicial.Size = New System.Drawing.Size(301, 26)
        Me._FechaInicial.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(334, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha Inicial:"
        '
        '_Sucursal
        '
        Me._Sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._Sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._Sucursal.FormattingEnabled = True
        Me._Sucursal.Items.AddRange(New Object() {"SPS", "SRC", "Saba", "Tegucigalpa"})
        Me._Sucursal.Location = New System.Drawing.Point(90, 37)
        Me._Sucursal.Name = "_Sucursal"
        Me._Sucursal.Size = New System.Drawing.Size(105, 28)
        Me._Sucursal.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(759, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Semana:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sucursal:"
        '
        '_GridEfectividad
        '
        Me._GridEfectividad.AllowUserToAddRows = False
        Me._GridEfectividad.AllowUserToDeleteRows = False
        Me._GridEfectividad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._GridEfectividad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._GridEfectividad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridEfectividad.Location = New System.Drawing.Point(13, 135)
        Me._GridEfectividad.Name = "_GridEfectividad"
        Me._GridEfectividad.ReadOnly = True
        Me._GridEfectividad.Size = New System.Drawing.Size(1004, 306)
        Me._GridEfectividad.TabIndex = 1
        '
        'ListaVendedores
        '
        Me.ListaVendedores.AllowUserToAddRows = False
        Me.ListaVendedores.AllowUserToDeleteRows = False
        Me.ListaVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListaVendedores.Location = New System.Drawing.Point(75, 207)
        Me.ListaVendedores.Name = "ListaVendedores"
        Me.ListaVendedores.ReadOnly = True
        Me.ListaVendedores.Size = New System.Drawing.Size(13, 11)
        Me.ListaVendedores.TabIndex = 2
        Me.ListaVendedores.Visible = False
        '
        'DGNE
        '
        Me.DGNE.AllowUserToAddRows = False
        Me.DGNE.AllowUserToDeleteRows = False
        Me.DGNE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGNE.Location = New System.Drawing.Point(56, 207)
        Me.DGNE.Name = "DGNE"
        Me.DGNE.ReadOnly = True
        Me.DGNE.Size = New System.Drawing.Size(13, 11)
        Me.DGNE.TabIndex = 3
        Me.DGNE.Visible = False
        '
        '_GridDiaVisita
        '
        Me._GridDiaVisita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridDiaVisita.Location = New System.Drawing.Point(36, 207)
        Me._GridDiaVisita.Name = "_GridDiaVisita"
        Me._GridDiaVisita.Size = New System.Drawing.Size(14, 11)
        Me._GridDiaVisita.TabIndex = 5
        Me._GridDiaVisita.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1029, 39)
        Me.ToolStrip1.TabIndex = 6
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
        '_gridNCDiarias
        '
        Me._gridNCDiarias.AllowUserToAddRows = False
        Me._gridNCDiarias.AllowUserToDeleteRows = False
        Me._gridNCDiarias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridNCDiarias.Location = New System.Drawing.Point(14, 207)
        Me._gridNCDiarias.Name = "_gridNCDiarias"
        Me._gridNCDiarias.ReadOnly = True
        Me._gridNCDiarias.Size = New System.Drawing.Size(16, 11)
        Me._gridNCDiarias.TabIndex = 7
        Me._gridNCDiarias.Visible = False
        '
        'Efectividad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 453)
        Me.Controls.Add(Me._gridNCDiarias)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me._GridDiaVisita)
        Me.Controls.Add(Me.DGNE)
        Me.Controls.Add(Me.ListaVendedores)
        Me.Controls.Add(Me._GridEfectividad)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Efectividad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Efectividad "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me._GridEfectividad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListaVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGNE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._GridDiaVisita, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me._gridNCDiarias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents _Sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _FechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents _GridEfectividad As System.Windows.Forms.DataGridView
    Friend WithEvents ListaVendedores As System.Windows.Forms.DataGridView
    Friend WithEvents DGNE As System.Windows.Forms.DataGridView
    Friend WithEvents _GridDiaVisita As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _gridNCDiarias As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioMenores As System.Windows.Forms.RadioButton
    Friend WithEvents RadioTodos As System.Windows.Forms.RadioButton
    Friend WithEvents TextSemana As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
