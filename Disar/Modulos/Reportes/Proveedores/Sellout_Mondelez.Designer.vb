<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sellout_Mondelez
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sellout_Mondelez))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me._btnGenerar = New System.Windows.Forms.Button()
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.f2 = New System.Windows.Forms.DateTimePicker()
        Me.f1 = New System.Windows.Forms.DateTimePicker()
        Me._lblFechaInicio = New System.Windows.Forms.Label()
        Me.GridGeneral = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me._grpCBuquedas.SuspendLayout()
        CType(Me.GridGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1015, 39)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(69, 36)
        Me.ToolStripButton1.Text = "Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(618, 53)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(72, 23)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_grpCBuquedas
        '
        Me._grpCBuquedas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._grpCBuquedas.Controls.Add(Me.ComboBox1)
        Me._grpCBuquedas.Controls.Add(Me.Label2)
        Me._grpCBuquedas.Controls.Add(Me.Button1)
        Me._grpCBuquedas.Controls.Add(Me._btnGenerar)
        Me._grpCBuquedas.Controls.Add(Me.f2)
        Me._grpCBuquedas.Controls.Add(Me.f1)
        Me._grpCBuquedas.Controls.Add(Me.Label1)
        Me._grpCBuquedas.Controls.Add(Me._lblFechaInicio)
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 42)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(989, 94)
        Me._grpCBuquedas.TabIndex = 19
        Me._grpCBuquedas.TabStop = False
        Me._grpCBuquedas.Text = "Criterios de Busqueda"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(902, 53)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Exportar Txt"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(322, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fin:"
        '
        'f2
        '
        Me.f2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.f2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f2.Location = New System.Drawing.Point(349, 55)
        Me.f2.Name = "f2"
        Me.f2.Size = New System.Drawing.Size(229, 21)
        Me.f2.TabIndex = 3
        '
        'f1
        '
        Me.f1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.f1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f1.Location = New System.Drawing.Point(70, 55)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(228, 21)
        Me.f1.TabIndex = 2
        '
        '_lblFechaInicio
        '
        Me._lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaInicio.AutoSize = True
        Me._lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaInicio.Location = New System.Drawing.Point(10, 60)
        Me._lblFechaInicio.Name = "_lblFechaInicio"
        Me._lblFechaInicio.Size = New System.Drawing.Size(39, 15)
        Me._lblFechaInicio.TabIndex = 0
        Me._lblFechaInicio.Text = "Inicio:"
        '
        'GridGeneral
        '
        Me.GridGeneral.AllowUserToAddRows = False
        Me.GridGeneral.AllowUserToDeleteRows = False
        Me.GridGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridGeneral.Location = New System.Drawing.Point(12, 142)
        Me.GridGeneral.Name = "GridGeneral"
        Me.GridGeneral.ReadOnly = True
        Me.GridGeneral.Size = New System.Drawing.Size(989, 411)
        Me.GridGeneral.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tipo SO:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Anterior", "Nuevo"})
        Me.ComboBox1.Location = New System.Drawing.Point(70, 25)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(228, 24)
        Me.ComboBox1.TabIndex = 7
        '
        'Sellout_Mondelez
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 591)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me.GridGeneral)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Sellout_Mondelez"
        Me.Text = "Sellout_Mondelez"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        CType(Me.GridGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents f2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents f1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GridGeneral As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label2 As Label
End Class
