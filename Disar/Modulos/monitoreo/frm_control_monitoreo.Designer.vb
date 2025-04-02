<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_control_monitoreo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_control_monitoreo))
        Me.grd_listado_lotes = New System.Windows.Forms.DataGridView
        Me.grp_filtros = New System.Windows.Forms.GroupBox
        Me.btn_generar = New System.Windows.Forms.Button
        Me.cmb_fecha_ini = New System.Windows.Forms.DateTimePicker
        Me.lbl_fecha = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_exportar = New System.Windows.Forms.ToolStripButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_fecha_fin = New System.Windows.Forms.DateTimePicker
        CType(Me.grd_listado_lotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_filtros.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grd_listado_lotes
        '
        Me.grd_listado_lotes.AllowUserToAddRows = False
        Me.grd_listado_lotes.AllowUserToDeleteRows = False
        Me.grd_listado_lotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_listado_lotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_listado_lotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_listado_lotes.Location = New System.Drawing.Point(12, 104)
        Me.grd_listado_lotes.Name = "grd_listado_lotes"
        Me.grd_listado_lotes.ReadOnly = True
        Me.grd_listado_lotes.Size = New System.Drawing.Size(1232, 477)
        Me.grd_listado_lotes.TabIndex = 25
        '
        'grp_filtros
        '
        Me.grp_filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_filtros.Controls.Add(Me.btn_generar)
        Me.grp_filtros.Controls.Add(Me.cmb_fecha_fin)
        Me.grp_filtros.Controls.Add(Me.Label1)
        Me.grp_filtros.Controls.Add(Me.cmb_fecha_ini)
        Me.grp_filtros.Controls.Add(Me.lbl_fecha)
        Me.grp_filtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_filtros.Location = New System.Drawing.Point(12, 42)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(1232, 56)
        Me.grp_filtros.TabIndex = 24
        Me.grp_filtros.TabStop = False
        '
        'btn_generar
        '
        Me.btn_generar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_generar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_generar.Location = New System.Drawing.Point(910, 15)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(82, 34)
        Me.btn_generar.TabIndex = 3
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_generar.UseVisualStyleBackColor = True
        '
        'cmb_fecha_ini
        '
        Me.cmb_fecha_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_ini.Location = New System.Drawing.Point(137, 21)
        Me.cmb_fecha_ini.Name = "cmb_fecha_ini"
        Me.cmb_fecha_ini.Size = New System.Drawing.Size(282, 23)
        Me.cmb_fecha_ini.TabIndex = 1
        '
        'lbl_fecha
        '
        Me.lbl_fecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fecha.Location = New System.Drawing.Point(31, 24)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(100, 17)
        Me.lbl_fecha.TabIndex = 0
        Me.lbl_fecha.Text = "Fecha Inicio:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_exportar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1256, 39)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_exportar
        '
        Me.btn_exportar.AccessibleRole = System.Windows.Forms.AccessibleRole.Equation
        Me.btn_exportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.btn_exportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(69, 36)
        Me.btn_exportar.Text = "Excel"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(516, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Fin:"
        '
        'cmb_fecha_fin
        '
        Me.cmb_fecha_fin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_fin.Location = New System.Drawing.Point(606, 21)
        Me.cmb_fecha_fin.Name = "cmb_fecha_fin"
        Me.cmb_fecha_fin.Size = New System.Drawing.Size(282, 23)
        Me.cmb_fecha_fin.TabIndex = 1
        '
        'frm_control_monitoreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1256, 593)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grd_listado_lotes)
        Me.Controls.Add(Me.grp_filtros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_control_monitoreo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control y Monitoreo"
        CType(Me.grd_listado_lotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents grd_listado_lotes As System.Windows.Forms.DataGridView
    Private WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Private WithEvents btn_generar As System.Windows.Forms.Button
    Private WithEvents cmb_fecha_ini As System.Windows.Forms.DateTimePicker
    Private WithEvents lbl_fecha As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripButton
    Private WithEvents cmb_fecha_fin As System.Windows.Forms.DateTimePicker
    Private WithEvents Label1 As System.Windows.Forms.Label
End Class
