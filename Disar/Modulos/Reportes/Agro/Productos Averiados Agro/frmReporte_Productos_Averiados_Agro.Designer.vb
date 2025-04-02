<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporte_Productos_Averiados_Agro
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbFin = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.grdReporte = New System.Windows.Forms.DataGridView
        Me.cmFechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.filtro = New System.Windows.Forms.GroupBox
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
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
        Me.ToolStrip1.Size = New System.Drawing.Size(1038, 39)
        Me.ToolStrip1.TabIndex = 28
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
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Sucursal:"
        '
        'cmbFin
        '
        Me.cmbFin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbFin.Location = New System.Drawing.Point(648, 12)
        Me.cmbFin.Name = "cmbFin"
        Me.cmbFin.Size = New System.Drawing.Size(215, 20)
        Me.cmbFin.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(577, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha Final:"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.Location = New System.Drawing.Point(907, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 19)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Generar"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.grdReporte.Location = New System.Drawing.Point(12, 92)
        Me.grdReporte.Name = "grdReporte"
        Me.grdReporte.ReadOnly = True
        Me.grdReporte.Size = New System.Drawing.Size(1014, 488)
        Me.grdReporte.TabIndex = 27
        '
        'cmFechaIni
        '
        Me.cmFechaIni.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmFechaIni.Location = New System.Drawing.Point(346, 13)
        Me.cmFechaIni.Name = "cmFechaIni"
        Me.cmFechaIni.Size = New System.Drawing.Size(215, 20)
        Me.cmFechaIni.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(274, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha Inicial:"
        '
        'filtro
        '
        Me.filtro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtro.Controls.Add(Me.Label12)
        Me.filtro.Controls.Add(Me.cmbFin)
        Me.filtro.Controls.Add(Me.Label1)
        Me.filtro.Controls.Add(Me.cmb_almacen)
        Me.filtro.Controls.Add(Me.Button1)
        Me.filtro.Controls.Add(Me.cmFechaIni)
        Me.filtro.Controls.Add(Me.Label5)
        Me.filtro.Location = New System.Drawing.Point(12, 48)
        Me.filtro.Name = "filtro"
        Me.filtro.Size = New System.Drawing.Size(1014, 38)
        Me.filtro.TabIndex = 29
        Me.filtro.TabStop = False
        '
        'cmb_almacen
        '
        Me.cmb_almacen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(56, 12)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(212, 21)
        Me.cmb_almacen.TabIndex = 1
        '
        'frmReporte_Productos_Averiados_Agro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 586)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grdReporte)
        Me.Controls.Add(Me.filtro)
        Me.Name = "frmReporte_Productos_Averiados_Agro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos Averiados Agro"
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents grdReporte As System.Windows.Forms.DataGridView
    Friend WithEvents cmFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents filtro As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
End Class
