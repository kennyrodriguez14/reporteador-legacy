<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_carga_camiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_carga_camiones))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_generar = New System.Windows.Forms.Button
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmb_fecha_fin = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_fecha_ini = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_exportar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.grupo = New System.Windows.Forms.TabControl
        Me.pnel_detalle = New System.Windows.Forms.TabPage
        Me.grd_listado = New System.Windows.Forms.DataGridView
        Me.pnel_encabezado = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.grd_encabezado = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.grd_resumen = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grupo.SuspendLayout()
        Me.pnel_detalle.SuspendLayout()
        CType(Me.grd_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnel_encabezado.SuspendLayout()
        CType(Me.grd_encabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_resumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btn_generar)
        Me.GroupBox1.Controls.Add(Me.cmb_almacen)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmb_fecha_fin)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmb_fecha_ini)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(952, 52)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'btn_generar
        '
        Me.btn_generar.Location = New System.Drawing.Point(865, 19)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(75, 23)
        Me.btn_generar.TabIndex = 4
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.UseVisualStyleBackColor = True
        '
        'cmb_almacen
        '
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(67, 19)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(191, 21)
        Me.cmb_almacen.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Almacen:"
        '
        'cmb_fecha_fin
        '
        Me.cmb_fecha_fin.Location = New System.Drawing.Point(626, 20)
        Me.cmb_fecha_fin.Name = "cmb_fecha_fin"
        Me.cmb_fecha_fin.Size = New System.Drawing.Size(194, 20)
        Me.cmb_fecha_fin.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(550, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha Inicial:"
        '
        'cmb_fecha_ini
        '
        Me.cmb_fecha_ini.Location = New System.Drawing.Point(340, 20)
        Me.cmb_fecha_ini.Name = "cmb_fecha_ini"
        Me.cmb_fecha_ini.Size = New System.Drawing.Size(197, 20)
        Me.cmb_fecha_ini.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(264, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Inicial:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_exportar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(976, 39)
        Me.ToolStrip1.TabIndex = 35
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'btn_exportar
        '
        Me.btn_exportar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_exportar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_exportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.btn_exportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(72, 36)
        Me.btn_exportar.Tag = "Exportar a Excel"
        Me.btn_exportar.Text = "Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'grupo
        '
        Me.grupo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grupo.Controls.Add(Me.pnel_detalle)
        Me.grupo.Controls.Add(Me.pnel_encabezado)
        Me.grupo.Location = New System.Drawing.Point(13, 100)
        Me.grupo.Name = "grupo"
        Me.grupo.SelectedIndex = 0
        Me.grupo.Size = New System.Drawing.Size(951, 596)
        Me.grupo.TabIndex = 36
        '
        'pnel_detalle
        '
        Me.pnel_detalle.Controls.Add(Me.grd_listado)
        Me.pnel_detalle.Location = New System.Drawing.Point(4, 22)
        Me.pnel_detalle.Name = "pnel_detalle"
        Me.pnel_detalle.Padding = New System.Windows.Forms.Padding(3)
        Me.pnel_detalle.Size = New System.Drawing.Size(943, 570)
        Me.pnel_detalle.TabIndex = 0
        Me.pnel_detalle.Text = "Detalle"
        Me.pnel_detalle.UseVisualStyleBackColor = True
        '
        'grd_listado
        '
        Me.grd_listado.AllowUserToAddRows = False
        Me.grd_listado.AllowUserToDeleteRows = False
        Me.grd_listado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_listado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_listado.Location = New System.Drawing.Point(3, 3)
        Me.grd_listado.Name = "grd_listado"
        Me.grd_listado.ReadOnly = True
        Me.grd_listado.Size = New System.Drawing.Size(937, 564)
        Me.grd_listado.TabIndex = 35
        '
        'pnel_encabezado
        '
        Me.pnel_encabezado.Controls.Add(Me.Label5)
        Me.pnel_encabezado.Controls.Add(Me.grd_resumen)
        Me.pnel_encabezado.Controls.Add(Me.Label3)
        Me.pnel_encabezado.Controls.Add(Me.grd_encabezado)
        Me.pnel_encabezado.Location = New System.Drawing.Point(4, 22)
        Me.pnel_encabezado.Name = "pnel_encabezado"
        Me.pnel_encabezado.Padding = New System.Windows.Forms.Padding(3)
        Me.pnel_encabezado.Size = New System.Drawing.Size(943, 570)
        Me.pnel_encabezado.TabIndex = 1
        Me.pnel_encabezado.Text = "Encabezado"
        Me.pnel_encabezado.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(379, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(217, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Tiempo promedio por tipo de Reporte"
        '
        'grd_encabezado
        '
        Me.grd_encabezado.AllowUserToAddRows = False
        Me.grd_encabezado.AllowUserToDeleteRows = False
        Me.grd_encabezado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_encabezado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_encabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_encabezado.Location = New System.Drawing.Point(262, 26)
        Me.grd_encabezado.Name = "grd_encabezado"
        Me.grd_encabezado.ReadOnly = True
        Me.grd_encabezado.Size = New System.Drawing.Size(456, 219)
        Me.grd_encabezado.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(456, 260)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Resumen"
        '
        'grd_resumen
        '
        Me.grd_resumen.AllowUserToAddRows = False
        Me.grd_resumen.AllowUserToDeleteRows = False
        Me.grd_resumen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_resumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_resumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_resumen.Location = New System.Drawing.Point(8, 276)
        Me.grd_resumen.Name = "grd_resumen"
        Me.grd_resumen.ReadOnly = True
        Me.grd_resumen.Size = New System.Drawing.Size(927, 288)
        Me.grd_resumen.TabIndex = 37
        '
        'frm_reporte_carga_camiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 708)
        Me.Controls.Add(Me.grupo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_reporte_carga_camiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Carga de Camiones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grupo.ResumeLayout(False)
        Me.pnel_detalle.ResumeLayout(False)
        CType(Me.grd_listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnel_encabezado.ResumeLayout(False)
        Me.pnel_encabezado.PerformLayout()
        CType(Me.grd_encabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_resumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents cmb_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grupo As System.Windows.Forms.TabControl
    Friend WithEvents pnel_detalle As System.Windows.Forms.TabPage
    Friend WithEvents grd_listado As System.Windows.Forms.DataGridView
    Friend WithEvents pnel_encabezado As System.Windows.Forms.TabPage
    Friend WithEvents grd_encabezado As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grd_resumen As System.Windows.Forms.DataGridView
End Class
