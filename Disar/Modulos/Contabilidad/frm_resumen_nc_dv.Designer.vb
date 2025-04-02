<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_resumen_nc_dv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_resumen_nc_dv))
        Me.grp_filtros = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_fecha = New System.Windows.Forms.DateTimePicker
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_entregador = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.lbl_sucursal = New System.Windows.Forms.Label
        Me.btn_exportar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.grp_descuentos_tacticos = New System.Windows.Forms.GroupBox
        Me.grd_lista = New System.Windows.Forms.DataGridView
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.grp_filtros.SuspendLayout()
        Me.grp_descuentos_tacticos.SuspendLayout()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_filtros
        '
        Me.grp_filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_filtros.Controls.Add(Me.Label2)
        Me.grp_filtros.Controls.Add(Me.cmb_fecha)
        Me.grp_filtros.Controls.Add(Me.btn_aceptar)
        Me.grp_filtros.Controls.Add(Me.cmb_empresa)
        Me.grp_filtros.Controls.Add(Me.Label1)
        Me.grp_filtros.Controls.Add(Me.cmb_entregador)
        Me.grp_filtros.Controls.Add(Me.Label3)
        Me.grp_filtros.Controls.Add(Me.cmb_almacen)
        Me.grp_filtros.Controls.Add(Me.lbl_sucursal)
        Me.grp_filtros.Location = New System.Drawing.Point(12, 48)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(1167, 70)
        Me.grp_filtros.TabIndex = 25
        Me.grp_filtros.TabStop = False
        Me.grp_filtros.Text = "Filtros"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha:"
        '
        'cmb_fecha
        '
        Me.cmb_fecha.Location = New System.Drawing.Point(64, 43)
        Me.cmb_fecha.Name = "cmb_fecha"
        Me.cmb_fecha.Size = New System.Drawing.Size(217, 20)
        Me.cmb_fecha.TabIndex = 5
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_aceptar.Location = New System.Drawing.Point(647, 16)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(92, 48)
        Me.btn_aceptar.TabIndex = 6
        Me.btn_aceptar.Text = "Generar"
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'cmb_empresa
        '
        Me.cmb_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Location = New System.Drawing.Point(64, 16)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(217, 21)
        Me.cmb_empresa.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Empresa:"
        '
        'cmb_entregador
        '
        Me.cmb_entregador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_entregador.FormattingEnabled = True
        Me.cmb_entregador.Location = New System.Drawing.Point(363, 43)
        Me.cmb_entregador.Name = "cmb_entregador"
        Me.cmb_entregador.Size = New System.Drawing.Size(278, 21)
        Me.cmb_entregador.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(288, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Entregador:"
        '
        'cmb_almacen
        '
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(363, 16)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(278, 21)
        Me.cmb_almacen.TabIndex = 2
        '
        'lbl_sucursal
        '
        Me.lbl_sucursal.AutoSize = True
        Me.lbl_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sucursal.Location = New System.Drawing.Point(301, 19)
        Me.lbl_sucursal.Name = "lbl_sucursal"
        Me.lbl_sucursal.Size = New System.Drawing.Size(60, 13)
        Me.lbl_sucursal.TabIndex = 2
        Me.lbl_sucursal.Text = "Sucursal:"
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
        'grp_descuentos_tacticos
        '
        Me.grp_descuentos_tacticos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_descuentos_tacticos.Controls.Add(Me.grd_lista)
        Me.grp_descuentos_tacticos.Location = New System.Drawing.Point(12, 124)
        Me.grp_descuentos_tacticos.Name = "grp_descuentos_tacticos"
        Me.grp_descuentos_tacticos.Size = New System.Drawing.Size(1170, 477)
        Me.grp_descuentos_tacticos.TabIndex = 27
        Me.grp_descuentos_tacticos.TabStop = False
        '
        'grd_lista
        '
        Me.grd_lista.AllowUserToAddRows = False
        Me.grd_lista.AllowUserToDeleteRows = False
        Me.grd_lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_lista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_lista.Location = New System.Drawing.Point(3, 16)
        Me.grd_lista.Name = "grd_lista"
        Me.grd_lista.ReadOnly = True
        Me.grd_lista.RowHeadersVisible = False
        Me.grd_lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_lista.Size = New System.Drawing.Size(1164, 458)
        Me.grd_lista.TabIndex = 0
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_exportar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1194, 39)
        Me.ToolStrip1.TabIndex = 26
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'frm_resumen_nc_dv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 607)
        Me.Controls.Add(Me.grp_filtros)
        Me.Controls.Add(Me.grp_descuentos_tacticos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_resumen_nc_dv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nota de Crédito Por Descuento"
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        Me.grp_descuentos_tacticos.ResumeLayout(False)
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_entregador As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_sucursal As System.Windows.Forms.Label
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grp_descuentos_tacticos As System.Windows.Forms.GroupBox
    Friend WithEvents grd_lista As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
End Class
