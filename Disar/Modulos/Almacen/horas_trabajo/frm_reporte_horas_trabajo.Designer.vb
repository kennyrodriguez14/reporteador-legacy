<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_horas_trabajo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_horas_trabajo))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.grdReporte = New System.Windows.Forms.DataGridView
        Me.filtro = New System.Windows.Forms.GroupBox
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox
        Me.lblAlmacen = New System.Windows.Forms.Label
        Me.cmbFin = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmFechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.filtro.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(868, 39)
        Me.ToolStrip1.TabIndex = 26
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
        'grdReporte
        '
        Me.grdReporte.AllowUserToAddRows = False
        Me.grdReporte.AllowUserToDeleteRows = False
        Me.grdReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdReporte.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdReporte.Location = New System.Drawing.Point(12, 91)
        Me.grdReporte.Name = "grdReporte"
        Me.grdReporte.ReadOnly = True
        Me.grdReporte.Size = New System.Drawing.Size(844, 420)
        Me.grdReporte.TabIndex = 29
        '
        'filtro
        '
        Me.filtro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtro.Controls.Add(Me.cmbAlmacen)
        Me.filtro.Controls.Add(Me.lblAlmacen)
        Me.filtro.Controls.Add(Me.cmbFin)
        Me.filtro.Controls.Add(Me.Label1)
        Me.filtro.Controls.Add(Me.Button1)
        Me.filtro.Controls.Add(Me.cmFechaIni)
        Me.filtro.Controls.Add(Me.Label5)
        Me.filtro.Location = New System.Drawing.Point(12, 42)
        Me.filtro.Name = "filtro"
        Me.filtro.Size = New System.Drawing.Size(844, 43)
        Me.filtro.TabIndex = 28
        Me.filtro.TabStop = False
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(50, 14)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(165, 21)
        Me.cmbAlmacen.TabIndex = 31
        '
        'lblAlmacen
        '
        Me.lblAlmacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Location = New System.Drawing.Point(0, 18)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(51, 13)
        Me.lblAlmacen.TabIndex = 30
        Me.lblAlmacen.Text = "Sucursal:"
        '
        'cmbFin
        '
        Me.cmbFin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbFin.Location = New System.Drawing.Point(552, 14)
        Me.cmbFin.Name = "cmbFin"
        Me.cmbFin.Size = New System.Drawing.Size(194, 20)
        Me.cmbFin.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(491, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha Final:"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.Location = New System.Drawing.Point(764, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 19)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Generar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmFechaIni
        '
        Me.cmFechaIni.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmFechaIni.Location = New System.Drawing.Point(288, 14)
        Me.cmFechaIni.Name = "cmFechaIni"
        Me.cmFechaIni.Size = New System.Drawing.Size(196, 20)
        Me.cmFechaIni.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(221, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha Inicial:"
        '
        'frm_reporte_horas_trabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 523)
        Me.Controls.Add(Me.grdReporte)
        Me.Controls.Add(Me.filtro)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_reporte_horas_trabajo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de horas de trabajo"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.filtro.ResumeLayout(False)
        Me.filtro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdReporte As System.Windows.Forms.DataGridView
    Friend WithEvents filtro As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
End Class
