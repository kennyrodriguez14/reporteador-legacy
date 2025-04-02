<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_punto_reorden_OPL
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.mnu_exportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.grp_filtros = New System.Windows.Forms.GroupBox()
        Me.txt_dias = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_generar = New System.Windows.Forms.Button()
        Me.cmb_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grd_punto_reorden = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        Me.grp_filtros.SuspendLayout()
        CType(Me.txt_dias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_punto_reorden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_exportar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1307, 39)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'mnu_exportar
        '
        Me.mnu_exportar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnu_exportar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnu_exportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.mnu_exportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnu_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnu_exportar.Name = "mnu_exportar"
        Me.mnu_exportar.Size = New System.Drawing.Size(80, 36)
        Me.mnu_exportar.Tag = "Exportar a Excel"
        Me.mnu_exportar.Text = "Excel"
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
        Me.grp_filtros.Controls.Add(Me.txt_dias)
        Me.grp_filtros.Controls.Add(Me.Label1)
        Me.grp_filtros.Controls.Add(Me.btn_generar)
        Me.grp_filtros.Controls.Add(Me.cmb_fecha_fin)
        Me.grp_filtros.Controls.Add(Me.Label2)
        Me.grp_filtros.Location = New System.Drawing.Point(13, 43)
        Me.grp_filtros.Margin = New System.Windows.Forms.Padding(4)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Padding = New System.Windows.Forms.Padding(4)
        Me.grp_filtros.Size = New System.Drawing.Size(1281, 53)
        Me.grp_filtros.TabIndex = 22
        Me.grp_filtros.TabStop = False
        Me.grp_filtros.Text = "Filtros"
        '
        'txt_dias
        '
        Me.txt_dias.Location = New System.Drawing.Point(516, 17)
        Me.txt_dias.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_dias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txt_dias.Name = "txt_dias"
        Me.txt_dias.ReadOnly = True
        Me.txt_dias.Size = New System.Drawing.Size(61, 22)
        Me.txt_dias.TabIndex = 5
        Me.txt_dias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(369, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Dias Incumplimiento:"
        '
        'btn_generar
        '
        Me.btn_generar.Location = New System.Drawing.Point(587, 17)
        Me.btn_generar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(100, 25)
        Me.btn_generar.TabIndex = 3
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.UseVisualStyleBackColor = True
        '
        'cmb_fecha_fin
        '
        Me.cmb_fecha_fin.Location = New System.Drawing.Point(69, 17)
        Me.cmb_fecha_fin.Margin = New System.Windows.Forms.Padding(4)
        Me.cmb_fecha_fin.Name = "cmb_fecha_fin"
        Me.cmb_fecha_fin.Size = New System.Drawing.Size(291, 22)
        Me.cmb_fecha_fin.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha:"
        '
        'grd_punto_reorden
        '
        Me.grd_punto_reorden.AllowUserToAddRows = False
        Me.grd_punto_reorden.AllowUserToDeleteRows = False
        Me.grd_punto_reorden.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_punto_reorden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_punto_reorden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_punto_reorden.Location = New System.Drawing.Point(13, 104)
        Me.grd_punto_reorden.Margin = New System.Windows.Forms.Padding(4)
        Me.grd_punto_reorden.Name = "grd_punto_reorden"
        Me.grd_punto_reorden.ReadOnly = True
        Me.grd_punto_reorden.RowHeadersWidth = 51
        Me.grd_punto_reorden.Size = New System.Drawing.Size(1281, 422)
        Me.grd_punto_reorden.TabIndex = 23
        '
        'frm_punto_reorden_OPL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1307, 539)
        Me.Controls.Add(Me.grd_punto_reorden)
        Me.Controls.Add(Me.grp_filtros)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frm_punto_reorden_OPL"
        Me.Text = "frm_punto_reorden_OPL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        CType(Me.txt_dias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_punto_reorden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents mnu_exportar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents grp_filtros As GroupBox
    Friend WithEvents txt_dias As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_generar As Button
    Friend WithEvents cmb_fecha_fin As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents grd_punto_reorden As DataGridView
End Class
