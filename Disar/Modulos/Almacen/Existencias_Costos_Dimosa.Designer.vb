<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Existencias_Costos_Dimosa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Existencias_Costos_Dimosa))
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.grd_costos = New System.Windows.Forms.DataGridView
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.grp_filtros = New System.Windows.Forms.GroupBox
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.cmb_f2 = New System.Windows.Forms.DateTimePicker
        Me.lblFin = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        CType(Me.grd_costos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_filtros.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
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
        'grd_costos
        '
        Me.grd_costos.AllowUserToAddRows = False
        Me.grd_costos.AllowUserToDeleteRows = False
        Me.grd_costos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_costos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_costos.Location = New System.Drawing.Point(17, 135)
        Me.grd_costos.Name = "grd_costos"
        Me.grd_costos.ReadOnly = True
        Me.grd_costos.Size = New System.Drawing.Size(850, 399)
        Me.grd_costos.TabIndex = 29
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
        'grp_filtros
        '
        Me.grp_filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_filtros.Controls.Add(Me.btnGenerar)
        Me.grp_filtros.Controls.Add(Me.cmb_f2)
        Me.grp_filtros.Controls.Add(Me.lblFin)
        Me.grp_filtros.Location = New System.Drawing.Point(12, 62)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(859, 48)
        Me.grp_filtros.TabIndex = 28
        Me.grp_filtros.TabStop = False
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Location = New System.Drawing.Point(370, 19)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 22)
        Me.btnGenerar.TabIndex = 2
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'cmb_f2
        '
        Me.cmb_f2.Location = New System.Drawing.Point(133, 19)
        Me.cmb_f2.Name = "cmb_f2"
        Me.cmb_f2.Size = New System.Drawing.Size(215, 20)
        Me.cmb_f2.TabIndex = 1
        '
        'lblFin
        '
        Me.lblFin.AutoSize = True
        Me.lblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFin.Location = New System.Drawing.Point(6, 19)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(103, 17)
        Me.lblFin.TabIndex = 0
        Me.lblFin.Text = "Fecha de corte"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(883, 39)
        Me.ToolStrip1.TabIndex = 27
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Existencias_Costos_Dimosa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 539)
        Me.Controls.Add(Me.grd_costos)
        Me.Controls.Add(Me.grp_filtros)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Existencias_Costos_Dimosa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Existencias y Costos DIMOSA"
        CType(Me.grd_costos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents grd_costos As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmb_f2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFin As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
End Class
