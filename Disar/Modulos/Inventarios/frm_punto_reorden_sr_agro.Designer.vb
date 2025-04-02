<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_punto_reorden_sr_agro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_punto_reorden_sr_agro))
        Me.grd_punto_reorden = New System.Windows.Forms.DataGridView
        Me.grp_filtros = New System.Windows.Forms.GroupBox
        Me.txt_dias = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_generar = New System.Windows.Forms.Button
        Me.cmb_fecha_fin = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.mnu_exportar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        CType(Me.grd_punto_reorden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_filtros.SuspendLayout()
        CType(Me.txt_dias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.grd_punto_reorden.Location = New System.Drawing.Point(12, 91)
        Me.grd_punto_reorden.Name = "grd_punto_reorden"
        Me.grd_punto_reorden.ReadOnly = True
        Me.grd_punto_reorden.Size = New System.Drawing.Size(1117, 477)
        Me.grd_punto_reorden.TabIndex = 0
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
        Me.grp_filtros.Location = New System.Drawing.Point(13, 42)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(1116, 43)
        Me.grp_filtros.TabIndex = 1
        Me.grp_filtros.TabStop = False
        Me.grp_filtros.Text = "Filtros"
        '
        'txt_dias
        '
        Me.txt_dias.Location = New System.Drawing.Point(387, 14)
        Me.txt_dias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txt_dias.Name = "txt_dias"
        Me.txt_dias.ReadOnly = True
        Me.txt_dias.Size = New System.Drawing.Size(46, 20)
        Me.txt_dias.TabIndex = 5
        Me.txt_dias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(277, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Dias Incumplimiento:"
        '
        'btn_generar
        '
        Me.btn_generar.Location = New System.Drawing.Point(440, 14)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(75, 20)
        Me.btn_generar.TabIndex = 3
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.UseVisualStyleBackColor = True
        '
        'cmb_fecha_fin
        '
        Me.cmb_fecha_fin.Location = New System.Drawing.Point(52, 14)
        Me.cmb_fecha_fin.Name = "cmb_fecha_fin"
        Me.cmb_fecha_fin.Size = New System.Drawing.Size(219, 20)
        Me.cmb_fecha_fin.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_exportar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1141, 39)
        Me.ToolStrip1.TabIndex = 17
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
        Me.mnu_exportar.Size = New System.Drawing.Size(72, 36)
        Me.mnu_exportar.Tag = "Exportar a Excel"
        Me.mnu_exportar.Text = "Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'frm_punto_reorden_sr_agro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 580)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grp_filtros)
        Me.Controls.Add(Me.grd_punto_reorden)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_punto_reorden_sr_agro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Punto de Reorden SR AGRO"
        CType(Me.grd_punto_reorden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        CType(Me.txt_dias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grd_punto_reorden As System.Windows.Forms.DataGridView
    Friend WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents cmb_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents mnu_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txt_dias As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
