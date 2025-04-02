<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_descuentos_tacticos_admin_dimosa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_descuentos_tacticos_admin_dimosa))
        Me.grp_filtros = New System.Windows.Forms.GroupBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.lbl_sucursal = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_fecha = New System.Windows.Forms.Label
        Me.cmb_fecha_fin = New System.Windows.Forms.DateTimePicker
        Me.cmb_fecha_ini = New System.Windows.Forms.DateTimePicker
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.grd_lista = New System.Windows.Forms.DataGridView
        Me.grp_descuentos_tacticos = New System.Windows.Forms.GroupBox
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.grp_filtros.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_descuentos_tacticos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_filtros
        '
        Me.grp_filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_filtros.Controls.Add(Me.btn_aceptar)
        Me.grp_filtros.Controls.Add(Me.cmb_almacen)
        Me.grp_filtros.Controls.Add(Me.lbl_sucursal)
        Me.grp_filtros.Controls.Add(Me.Label1)
        Me.grp_filtros.Controls.Add(Me.lbl_fecha)
        Me.grp_filtros.Controls.Add(Me.cmb_fecha_fin)
        Me.grp_filtros.Controls.Add(Me.cmb_fecha_ini)
        Me.grp_filtros.Location = New System.Drawing.Point(12, 48)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(1239, 77)
        Me.grp_filtros.TabIndex = 20
        Me.grp_filtros.TabStop = False
        Me.grp_filtros.Text = "Filtros"
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_aceptar.Location = New System.Drawing.Point(850, 17)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(76, 23)
        Me.btn_aceptar.TabIndex = 4
        Me.btn_aceptar.Text = "Generar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'cmb_almacen
        '
        Me.cmb_almacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(391, 19)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(298, 21)
        Me.cmb_almacen.TabIndex = 3
        '
        'lbl_sucursal
        '
        Me.lbl_sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_sucursal.AutoSize = True
        Me.lbl_sucursal.Location = New System.Drawing.Point(334, 22)
        Me.lbl_sucursal.Name = "lbl_sucursal"
        Me.lbl_sucursal.Size = New System.Drawing.Size(51, 13)
        Me.lbl_sucursal.TabIndex = 2
        Me.lbl_sucursal.Text = "Sucursal:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(634, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha Final:"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(315, 52)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(70, 13)
        Me.lbl_fecha.TabIndex = 1
        Me.lbl_fecha.Text = "Fecha Inicial:"
        '
        'cmb_fecha_fin
        '
        Me.cmb_fecha_fin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_fin.Location = New System.Drawing.Point(705, 49)
        Me.cmb_fecha_fin.Name = "cmb_fecha_fin"
        Me.cmb_fecha_fin.Size = New System.Drawing.Size(221, 20)
        Me.cmb_fecha_fin.TabIndex = 0
        '
        'cmb_fecha_ini
        '
        Me.cmb_fecha_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_ini.Location = New System.Drawing.Point(391, 49)
        Me.cmb_fecha_ini.Name = "cmb_fecha_ini"
        Me.cmb_fecha_ini.Size = New System.Drawing.Size(221, 20)
        Me.cmb_fecha_ini.TabIndex = 0
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1266, 39)
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'grd_lista
        '
        Me.grd_lista.AllowUserToAddRows = False
        Me.grd_lista.AllowUserToDeleteRows = False
        Me.grd_lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_lista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_lista.Location = New System.Drawing.Point(3, 16)
        Me.grd_lista.Name = "grd_lista"
        Me.grd_lista.ReadOnly = True
        Me.grd_lista.RowHeadersVisible = False
        Me.grd_lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_lista.Size = New System.Drawing.Size(1236, 305)
        Me.grd_lista.TabIndex = 0
        '
        'grp_descuentos_tacticos
        '
        Me.grp_descuentos_tacticos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_descuentos_tacticos.Controls.Add(Me.grd_lista)
        Me.grp_descuentos_tacticos.Location = New System.Drawing.Point(12, 131)
        Me.grp_descuentos_tacticos.Name = "grp_descuentos_tacticos"
        Me.grp_descuentos_tacticos.Size = New System.Drawing.Size(1242, 324)
        Me.grp_descuentos_tacticos.TabIndex = 21
        Me.grp_descuentos_tacticos.TabStop = False
        Me.grp_descuentos_tacticos.Text = "Descuentos Tacticos"
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
        'frm_descuentos_tacticos_admin_dimosa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1266, 461)
        Me.Controls.Add(Me.grp_filtros)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grp_descuentos_tacticos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_descuentos_tacticos_admin_dimosa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descuentos Tacticos DIMOSA"
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_descuentos_tacticos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_sucursal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grd_lista As System.Windows.Forms.DataGridView
    Friend WithEvents grp_descuentos_tacticos As System.Windows.Forms.GroupBox
End Class
