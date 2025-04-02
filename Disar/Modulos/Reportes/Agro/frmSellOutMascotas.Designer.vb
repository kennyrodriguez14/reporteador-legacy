<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSellOutMascotas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSellOutMascotas))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._cmbFechaf = New System.Windows.Forms.DateTimePicker
        Me._cmbFechai = New System.Windows.Forms.DateTimePicker
        Me._lblFechaf = New System.Windows.Forms.Label
        Me._lblFechai = New System.Windows.Forms.Label
        Me.GridGeneral = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me._gbCriteriosBusqueda.SuspendLayout()
        CType(Me.GridGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(953, 39)
        Me.ToolStrip1.TabIndex = 45
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        '_gbCriteriosBusqueda
        '
        Me._gbCriteriosBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gbCriteriosBusqueda.Controls.Add(Me._btnGenerar)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechai)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechai)
        Me._gbCriteriosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbCriteriosBusqueda.Location = New System.Drawing.Point(12, 42)
        Me._gbCriteriosBusqueda.Name = "_gbCriteriosBusqueda"
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(929, 52)
        Me._gbCriteriosBusqueda.TabIndex = 47
        Me._gbCriteriosBusqueda.TabStop = False
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(828, 18)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(95, 27)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_cmbFechaf
        '
        Me._cmbFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbFechaf.Location = New System.Drawing.Point(516, 18)
        Me._cmbFechaf.Name = "_cmbFechaf"
        Me._cmbFechaf.Size = New System.Drawing.Size(261, 23)
        Me._cmbFechaf.TabIndex = 3
        '
        '_cmbFechai
        '
        Me._cmbFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbFechai.Location = New System.Drawing.Point(126, 18)
        Me._cmbFechai.Name = "_cmbFechai"
        Me._cmbFechai.Size = New System.Drawing.Size(261, 23)
        Me._cmbFechai.TabIndex = 2
        '
        '_lblFechaf
        '
        Me._lblFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaf.AutoSize = True
        Me._lblFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaf.Location = New System.Drawing.Point(414, 20)
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
        Me._lblFechai.Location = New System.Drawing.Point(17, 20)
        Me._lblFechai.Name = "_lblFechai"
        Me._lblFechai.Size = New System.Drawing.Size(104, 17)
        Me._lblFechai.TabIndex = 0
        Me._lblFechai.Text = "Fecha Inicial:"
        '
        'GridGeneral
        '
        Me.GridGeneral.AllowUserToAddRows = False
        Me.GridGeneral.AllowUserToDeleteRows = False
        Me.GridGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridGeneral.Location = New System.Drawing.Point(12, 101)
        Me.GridGeneral.Name = "GridGeneral"
        Me.GridGeneral.ReadOnly = True
        Me.GridGeneral.Size = New System.Drawing.Size(929, 401)
        Me.GridGeneral.TabIndex = 48
        '
        'frmSellOutMascotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 514)
        Me.Controls.Add(Me.GridGeneral)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSellOutMascotas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sell Out Mascotas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        CType(Me.GridGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _cmbFechaf As System.Windows.Forms.DateTimePicker
    Friend WithEvents _cmbFechai As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechaf As System.Windows.Forms.Label
    Friend WithEvents _lblFechai As System.Windows.Forms.Label
    Friend WithEvents GridGeneral As System.Windows.Forms.DataGridView
End Class
