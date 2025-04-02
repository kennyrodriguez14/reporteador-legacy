<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_resumen_des_tac_SRAGRO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_resumen_des_tac_SRAGRO))
        Me.grd_listado = New System.Windows.Forms.DataGridView
        Me.grp_ingreso_datos = New System.Windows.Forms.GroupBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.lbl_sucursal = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_fecha = New System.Windows.Forms.Label
        Me.cmb_fecha_final = New System.Windows.Forms.DateTimePicker
        Me.cmb_fecha_inicial = New System.Windows.Forms.DateTimePicker
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_excel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        CType(Me.grd_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_ingreso_datos.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grd_listado
        '
        Me.grd_listado.AllowUserToAddRows = False
        Me.grd_listado.AllowUserToDeleteRows = False
        Me.grd_listado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_listado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_listado.Location = New System.Drawing.Point(12, 100)
        Me.grd_listado.Name = "grd_listado"
        Me.grd_listado.ReadOnly = True
        Me.grd_listado.Size = New System.Drawing.Size(1077, 383)
        Me.grd_listado.TabIndex = 21
        '
        'grp_ingreso_datos
        '
        Me.grp_ingreso_datos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso_datos.Controls.Add(Me.btn_aceptar)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_almacen)
        Me.grp_ingreso_datos.Controls.Add(Me.lbl_sucursal)
        Me.grp_ingreso_datos.Controls.Add(Me.Label1)
        Me.grp_ingreso_datos.Controls.Add(Me.lbl_fecha)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_final)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_inicial)
        Me.grp_ingreso_datos.Location = New System.Drawing.Point(12, 42)
        Me.grp_ingreso_datos.Name = "grp_ingreso_datos"
        Me.grp_ingreso_datos.Size = New System.Drawing.Size(1077, 52)
        Me.grp_ingreso_datos.TabIndex = 20
        Me.grp_ingreso_datos.TabStop = False
        Me.grp_ingreso_datos.Text = "Filtros"
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_aceptar.Location = New System.Drawing.Point(980, 19)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(76, 23)
        Me.btn_aceptar.TabIndex = 9
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'cmb_almacen
        '
        Me.cmb_almacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(68, 21)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(298, 21)
        Me.cmb_almacen.TabIndex = 8
        '
        'lbl_sucursal
        '
        Me.lbl_sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_sucursal.AutoSize = True
        Me.lbl_sucursal.Location = New System.Drawing.Point(17, 24)
        Me.lbl_sucursal.Name = "lbl_sucursal"
        Me.lbl_sucursal.Size = New System.Drawing.Size(51, 13)
        Me.lbl_sucursal.TabIndex = 7
        Me.lbl_sucursal.Text = "Sucursal:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(674, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Fecha Inicial:"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(376, 24)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(70, 13)
        Me.lbl_fecha.TabIndex = 6
        Me.lbl_fecha.Text = "Fecha Inicial:"
        '
        'cmb_fecha_final
        '
        Me.cmb_fecha_final.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_final.Location = New System.Drawing.Point(747, 21)
        Me.cmb_fecha_final.Name = "cmb_fecha_final"
        Me.cmb_fecha_final.Size = New System.Drawing.Size(221, 20)
        Me.cmb_fecha_final.TabIndex = 5
        '
        'cmb_fecha_inicial
        '
        Me.cmb_fecha_inicial.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_inicial.Location = New System.Drawing.Point(446, 21)
        Me.cmb_fecha_inicial.Name = "cmb_fecha_inicial"
        Me.cmb_fecha_inicial.Size = New System.Drawing.Size(221, 20)
        Me.cmb_fecha_inicial.TabIndex = 5
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_excel, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1101, 39)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_excel
        '
        Me.btn_excel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_excel.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.btn_excel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_excel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(72, 36)
        Me.btn_excel.Text = "Excel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'frm_resumen_des_tac_SRAGRO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 495)
        Me.Controls.Add(Me.grd_listado)
        Me.Controls.Add(Me.grp_ingreso_datos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_resumen_des_tac_SRAGRO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resumen Descuentos Tacticos SR Agro"
        CType(Me.grd_listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_ingreso_datos.ResumeLayout(False)
        Me.grp_ingreso_datos.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grd_listado As System.Windows.Forms.DataGridView
    Friend WithEvents grp_ingreso_datos As System.Windows.Forms.GroupBox
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_sucursal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_fecha_inicial As System.Windows.Forms.DateTimePicker
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_excel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
