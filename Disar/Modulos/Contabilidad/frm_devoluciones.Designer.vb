<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_devoluciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_devoluciones))
        Me.grp_filtros = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_fecha = New System.Windows.Forms.DateTimePicker
        Me.txt_fin = New System.Windows.Forms.TextBox
        Me.txt_ceros2 = New System.Windows.Forms.TextBox
        Me.txt_ceros = New System.Windows.Forms.TextBox
        Me.txt_folio = New System.Windows.Forms.TextBox
        Me.txt_inicio = New System.Windows.Forms.TextBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.lbl_sucursal = New System.Windows.Forms.Label
        Me.lbl_fecha = New System.Windows.Forms.Label
        Me.btn_volver = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_exportar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.grp_descuentos_tacticos = New System.Windows.Forms.GroupBox
        Me.grd_lista = New System.Windows.Forms.DataGridView
        Me.grp_filtros.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grp_descuentos_tacticos.SuspendLayout()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp_filtros
        '
        Me.grp_filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_filtros.Controls.Add(Me.Label2)
        Me.grp_filtros.Controls.Add(Me.cmb_fecha)
        Me.grp_filtros.Controls.Add(Me.txt_fin)
        Me.grp_filtros.Controls.Add(Me.txt_ceros2)
        Me.grp_filtros.Controls.Add(Me.txt_ceros)
        Me.grp_filtros.Controls.Add(Me.txt_folio)
        Me.grp_filtros.Controls.Add(Me.txt_inicio)
        Me.grp_filtros.Controls.Add(Me.btn_aceptar)
        Me.grp_filtros.Controls.Add(Me.cmb_empresa)
        Me.grp_filtros.Controls.Add(Me.Label1)
        Me.grp_filtros.Controls.Add(Me.cmb_almacen)
        Me.grp_filtros.Controls.Add(Me.lbl_sucursal)
        Me.grp_filtros.Controls.Add(Me.lbl_fecha)
        Me.grp_filtros.Location = New System.Drawing.Point(12, 42)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(716, 99)
        Me.grp_filtros.TabIndex = 21
        Me.grp_filtros.TabStop = False
        Me.grp_filtros.Text = "Filtros"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(375, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha:"
        '
        'cmb_fecha
        '
        Me.cmb_fecha.Location = New System.Drawing.Point(427, 43)
        Me.cmb_fecha.Name = "cmb_fecha"
        Me.cmb_fecha.Size = New System.Drawing.Size(198, 20)
        Me.cmb_fecha.TabIndex = 5
        '
        'txt_fin
        '
        Me.txt_fin.Location = New System.Drawing.Point(292, 69)
        Me.txt_fin.Name = "txt_fin"
        Me.txt_fin.Size = New System.Drawing.Size(77, 20)
        Me.txt_fin.TabIndex = 4
        '
        'txt_ceros2
        '
        Me.txt_ceros2.Location = New System.Drawing.Point(217, 69)
        Me.txt_ceros2.Name = "txt_ceros2"
        Me.txt_ceros2.ReadOnly = True
        Me.txt_ceros2.Size = New System.Drawing.Size(69, 20)
        Me.txt_ceros2.TabIndex = 5
        '
        'txt_ceros
        '
        Me.txt_ceros.Location = New System.Drawing.Point(217, 43)
        Me.txt_ceros.Name = "txt_ceros"
        Me.txt_ceros.ReadOnly = True
        Me.txt_ceros.Size = New System.Drawing.Size(69, 20)
        Me.txt_ceros.TabIndex = 3
        '
        'txt_folio
        '
        Me.txt_folio.Location = New System.Drawing.Point(151, 43)
        Me.txt_folio.Name = "txt_folio"
        Me.txt_folio.ReadOnly = True
        Me.txt_folio.Size = New System.Drawing.Size(60, 20)
        Me.txt_folio.TabIndex = 2
        '
        'txt_inicio
        '
        Me.txt_inicio.Location = New System.Drawing.Point(292, 43)
        Me.txt_inicio.Name = "txt_inicio"
        Me.txt_inicio.Size = New System.Drawing.Size(77, 20)
        Me.txt_inicio.TabIndex = 3
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Location = New System.Drawing.Point(633, 16)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(76, 32)
        Me.btn_aceptar.TabIndex = 6
        Me.btn_aceptar.Text = "Generar"
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
        Me.Label1.Location = New System.Drawing.Point(7, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Empresa:"
        '
        'cmb_almacen
        '
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(347, 16)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(278, 21)
        Me.cmb_almacen.TabIndex = 2
        '
        'lbl_sucursal
        '
        Me.lbl_sucursal.AutoSize = True
        Me.lbl_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sucursal.Location = New System.Drawing.Point(287, 19)
        Me.lbl_sucursal.Name = "lbl_sucursal"
        Me.lbl_sucursal.Size = New System.Drawing.Size(60, 13)
        Me.lbl_sucursal.TabIndex = 2
        Me.lbl_sucursal.Text = "Sucursal:"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fecha.Location = New System.Drawing.Point(7, 46)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(140, 13)
        Me.lbl_fecha.TabIndex = 1
        Me.lbl_fecha.Text = "Rango de Documentos:"
        '
        'btn_volver
        '
        Me.btn_volver.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_volver.Location = New System.Drawing.Point(734, 58)
        Me.btn_volver.Name = "btn_volver"
        Me.btn_volver.Size = New System.Drawing.Size(76, 32)
        Me.btn_volver.TabIndex = 7
        Me.btn_volver.Text = "Volver"
        Me.btn_volver.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_exportar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1194, 39)
        Me.ToolStrip1.TabIndex = 23
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
        'grp_descuentos_tacticos
        '
        Me.grp_descuentos_tacticos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_descuentos_tacticos.Controls.Add(Me.grd_lista)
        Me.grp_descuentos_tacticos.Location = New System.Drawing.Point(12, 147)
        Me.grp_descuentos_tacticos.Name = "grp_descuentos_tacticos"
        Me.grp_descuentos_tacticos.Size = New System.Drawing.Size(1170, 448)
        Me.grp_descuentos_tacticos.TabIndex = 24
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
        Me.grd_lista.Size = New System.Drawing.Size(1164, 429)
        Me.grd_lista.TabIndex = 0
        '
        'frm_devoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 607)
        Me.Controls.Add(Me.grp_descuentos_tacticos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btn_volver)
        Me.Controls.Add(Me.grp_filtros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_devoluciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Devoluciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grp_descuentos_tacticos.ResumeLayout(False)
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Friend WithEvents txt_fin As System.Windows.Forms.TextBox
    Friend WithEvents txt_folio As System.Windows.Forms.TextBox
    Friend WithEvents txt_inicio As System.Windows.Forms.TextBox
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_sucursal As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grp_descuentos_tacticos As System.Windows.Forms.GroupBox
    Friend WithEvents grd_lista As System.Windows.Forms.DataGridView
    Friend WithEvents btn_volver As System.Windows.Forms.Button
    Friend WithEvents txt_ceros2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ceros As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha As System.Windows.Forms.DateTimePicker
End Class
