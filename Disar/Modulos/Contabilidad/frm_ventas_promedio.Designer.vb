<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ventas_promedio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ventas_promedio))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.grp_filtros = New System.Windows.Forms.GroupBox
        Me.txt_Limite = New System.Windows.Forms.TextBox
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox
        Me.cmbSucursal = New System.Windows.Forms.ComboBox
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.cmb_f2 = New System.Windows.Forms.DateTimePicker
        Me.lblFin = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_F1 = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblInicio = New System.Windows.Forms.Label
        Me.Grid_general = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me.grp_filtros.SuspendLayout()
        CType(Me.Grid_general, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(864, 39)
        Me.ToolStrip1.TabIndex = 11
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'grp_filtros
        '
        Me.grp_filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_filtros.Controls.Add(Me.txt_Limite)
        Me.grp_filtros.Controls.Add(Me.cmbAlmacen)
        Me.grp_filtros.Controls.Add(Me.cmbSucursal)
        Me.grp_filtros.Controls.Add(Me.btnGenerar)
        Me.grp_filtros.Controls.Add(Me.cmb_f2)
        Me.grp_filtros.Controls.Add(Me.lblFin)
        Me.grp_filtros.Controls.Add(Me.Label1)
        Me.grp_filtros.Controls.Add(Me.cmb_F1)
        Me.grp_filtros.Controls.Add(Me.Label12)
        Me.grp_filtros.Controls.Add(Me.Label2)
        Me.grp_filtros.Controls.Add(Me.lblInicio)
        Me.grp_filtros.Location = New System.Drawing.Point(12, 42)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(840, 77)
        Me.grp_filtros.TabIndex = 10
        Me.grp_filtros.TabStop = False
        '
        'txt_Limite
        '
        Me.txt_Limite.Location = New System.Drawing.Point(650, 30)
        Me.txt_Limite.Name = "txt_Limite"
        Me.txt_Limite.Size = New System.Drawing.Size(96, 20)
        Me.txt_Limite.TabIndex = 4
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(79, 46)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(240, 21)
        Me.cmbAlmacen.TabIndex = 2
        '
        'cmbSucursal
        '
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Items.AddRange(New Object() {"CONSUMO", "SR AGRO"})
        Me.cmbSucursal.Location = New System.Drawing.Point(79, 19)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(240, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Location = New System.Drawing.Point(752, 28)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 22)
        Me.btnGenerar.TabIndex = 5
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'cmb_f2
        '
        Me.cmb_f2.Location = New System.Drawing.Point(379, 46)
        Me.cmb_f2.Name = "cmb_f2"
        Me.cmb_f2.Size = New System.Drawing.Size(212, 20)
        Me.cmb_f2.TabIndex = 3
        '
        'lblFin
        '
        Me.lblFin.AutoSize = True
        Me.lblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFin.Location = New System.Drawing.Point(345, 47)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(31, 17)
        Me.lblFin.TabIndex = 0
        Me.lblFin.Text = "Fin:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Almacen:"
        '
        'cmb_F1
        '
        Me.cmb_F1.Location = New System.Drawing.Point(379, 20)
        Me.cmb_F1.Name = "cmb_F1"
        Me.cmb_F1.Size = New System.Drawing.Size(212, 20)
        Me.cmb_F1.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 17)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Sucursal:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(602, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Limite:"
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicio.Location = New System.Drawing.Point(332, 20)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(44, 17)
        Me.lblInicio.TabIndex = 0
        Me.lblInicio.Text = "Inicio:"
        '
        'Grid_general
        '
        Me.Grid_general.AllowUserToAddRows = False
        Me.Grid_general.AllowUserToDeleteRows = False
        Me.Grid_general.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid_general.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.Grid_general.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_general.Location = New System.Drawing.Point(13, 126)
        Me.Grid_general.Name = "Grid_general"
        Me.Grid_general.ReadOnly = True
        Me.Grid_general.Size = New System.Drawing.Size(839, 387)
        Me.Grid_general.TabIndex = 12
        '
        'frm_ventas_promedio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 525)
        Me.Controls.Add(Me.Grid_general)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grp_filtros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_ventas_promedio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas Promedio"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        CType(Me.Grid_general, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmb_f2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFin As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_F1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents txt_Limite As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Grid_general As System.Windows.Forms.DataGridView
End Class
