<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_margenes_utilidad_producto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_margenes_utilidad_producto))
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox
        Me.btn_generar = New System.Windows.Forms.Button
        Me.grd_margenes = New System.Windows.Forms.DataGridView
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_exportar = New System.Windows.Forms.ToolStripButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        CType(Me.grd_margenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(66, 49)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(208, 21)
        Me.cmbEmpresa.TabIndex = 17
        '
        'btn_generar
        '
        Me.btn_generar.Location = New System.Drawing.Point(291, 46)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(75, 23)
        Me.btn_generar.TabIndex = 16
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.UseVisualStyleBackColor = True
        '
        'grd_margenes
        '
        Me.grd_margenes.AllowUserToAddRows = False
        Me.grd_margenes.AllowUserToDeleteRows = False
        Me.grd_margenes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_margenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_margenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_margenes.Location = New System.Drawing.Point(12, 78)
        Me.grd_margenes.Name = "grd_margenes"
        Me.grd_margenes.ReadOnly = True
        Me.grd_margenes.Size = New System.Drawing.Size(1137, 507)
        Me.grd_margenes.TabIndex = 14
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btn_exportar
        '
        Me.btn_exportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.btn_exportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(86, 36)
        Me.btn_exportar.Text = "Exportar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Empresa"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_exportar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1161, 39)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'frm_margenes_utilidad_producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1161, 591)
        Me.Controls.Add(Me.cmbEmpresa)
        Me.Controls.Add(Me.btn_generar)
        Me.Controls.Add(Me.grd_margenes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_margenes_utilidad_producto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Margenes de utilidad por producto"
        CType(Me.grd_margenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents grd_margenes As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
End Class
