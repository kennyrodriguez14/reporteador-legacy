<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Resumen_Costos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.grp_filtros = New System.Windows.Forms.GroupBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.cmb_f2 = New System.Windows.Forms.DateTimePicker()
        Me.lblFin = New System.Windows.Forms.Label()
        Me.cmb_F1 = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.grd_costos = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblTotalEntradas = New System.Windows.Forms.Label()
        Me.txtTotalEntradas = New System.Windows.Forms.TextBox()
        Me.txtTotalSalidas = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.grp_filtros.SuspendLayout()
        CType(Me.grd_costos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(75, 16)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(161, 21)
        Me.cmbSucursal.TabIndex = 3
        '
        'grp_filtros
        '
        Me.grp_filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_filtros.Controls.Add(Me.cmbSucursal)
        Me.grp_filtros.Controls.Add(Me.btnGenerar)
        Me.grp_filtros.Controls.Add(Me.cmb_f2)
        Me.grp_filtros.Controls.Add(Me.lblFin)
        Me.grp_filtros.Controls.Add(Me.cmb_F1)
        Me.grp_filtros.Controls.Add(Me.Label12)
        Me.grp_filtros.Controls.Add(Me.lblInicio)
        Me.grp_filtros.Location = New System.Drawing.Point(12, 48)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(859, 48)
        Me.grp_filtros.TabIndex = 15
        Me.grp_filtros.TabStop = False
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Location = New System.Drawing.Point(773, 15)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 22)
        Me.btnGenerar.TabIndex = 2
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'cmb_f2
        '
        Me.cmb_f2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_f2.Location = New System.Drawing.Point(550, 16)
        Me.cmb_f2.Name = "cmb_f2"
        Me.cmb_f2.Size = New System.Drawing.Size(215, 20)
        Me.cmb_f2.TabIndex = 1
        '
        'lblFin
        '
        Me.lblFin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFin.AutoSize = True
        Me.lblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFin.Location = New System.Drawing.Point(516, 17)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(31, 17)
        Me.lblFin.TabIndex = 0
        Me.lblFin.Text = "Fin:"
        '
        'cmb_F1
        '
        Me.cmb_F1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_F1.Location = New System.Drawing.Point(292, 16)
        Me.cmb_F1.Name = "cmb_F1"
        Me.cmb_F1.Size = New System.Drawing.Size(215, 20)
        Me.cmb_F1.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 17)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Sucursal:"
        '
        'lblInicio
        '
        Me.lblInicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicio.Location = New System.Drawing.Point(242, 16)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(44, 17)
        Me.lblInicio.TabIndex = 0
        Me.lblInicio.Text = "Inicio:"
        '
        'grd_costos
        '
        Me.grd_costos.AllowUserToAddRows = False
        Me.grd_costos.AllowUserToDeleteRows = False
        Me.grd_costos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_costos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_costos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grd_costos.DefaultCellStyle = DataGridViewCellStyle1
        Me.grd_costos.Location = New System.Drawing.Point(12, 153)
        Me.grd_costos.Name = "grd_costos"
        Me.grd_costos.ReadOnly = True
        Me.grd_costos.Size = New System.Drawing.Size(859, 374)
        Me.grd_costos.TabIndex = 16
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(883, 39)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'lblTotalEntradas
        '
        Me.lblTotalEntradas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotalEntradas.AutoSize = True
        Me.lblTotalEntradas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEntradas.Location = New System.Drawing.Point(12, 117)
        Me.lblTotalEntradas.Name = "lblTotalEntradas"
        Me.lblTotalEntradas.Size = New System.Drawing.Size(105, 17)
        Me.lblTotalEntradas.TabIndex = 4
        Me.lblTotalEntradas.Text = "Total Entradas:"
        '
        'txtTotalEntradas
        '
        Me.txtTotalEntradas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtTotalEntradas.Location = New System.Drawing.Point(123, 116)
        Me.txtTotalEntradas.Name = "txtTotalEntradas"
        Me.txtTotalEntradas.ReadOnly = True
        Me.txtTotalEntradas.Size = New System.Drawing.Size(194, 20)
        Me.txtTotalEntradas.TabIndex = 17
        '
        'txtTotalSalidas
        '
        Me.txtTotalSalidas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtTotalSalidas.Location = New System.Drawing.Point(681, 117)
        Me.txtTotalSalidas.Name = "txtTotalSalidas"
        Me.txtTotalSalidas.ReadOnly = True
        Me.txtTotalSalidas.Size = New System.Drawing.Size(166, 20)
        Me.txtTotalSalidas.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(590, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Total Salidas:"
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
        'frm_Resumen_Costos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 539)
        Me.Controls.Add(Me.txtTotalSalidas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotalEntradas)
        Me.Controls.Add(Me.lblTotalEntradas)
        Me.Controls.Add(Me.grp_filtros)
        Me.Controls.Add(Me.grd_costos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frm_Resumen_Costos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resumen de Costos"
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        CType(Me.grd_costos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmb_f2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFin As System.Windows.Forms.Label
    Friend WithEvents cmb_F1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents grd_costos As System.Windows.Forms.DataGridView
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblTotalEntradas As System.Windows.Forms.Label
    Friend WithEvents txtTotalEntradas As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalSalidas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
