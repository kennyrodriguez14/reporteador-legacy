<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_libro_ventas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_libro_ventas))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_exportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.grp_filtros = New System.Windows.Forms.GroupBox()
        Me.cmb_almacen = New System.Windows.Forms.ComboBox()
        Me.cmb_tipo = New System.Windows.Forms.ComboBox()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.cmb_f2 = New System.Windows.Forms.DateTimePicker()
        Me.lblFin = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_F1 = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.grd_ventas = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        Me.grp_filtros.SuspendLayout()
        CType(Me.grd_ventas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_exportar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1213, 39)
        Me.ToolStrip1.TabIndex = 12
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
        'grp_filtros
        '
        Me.grp_filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_filtros.Controls.Add(Me.cmb_almacen)
        Me.grp_filtros.Controls.Add(Me.cmb_tipo)
        Me.grp_filtros.Controls.Add(Me.cmbSucursal)
        Me.grp_filtros.Controls.Add(Me.btnGenerar)
        Me.grp_filtros.Controls.Add(Me.cmb_f2)
        Me.grp_filtros.Controls.Add(Me.lblFin)
        Me.grp_filtros.Controls.Add(Me.Label1)
        Me.grp_filtros.Controls.Add(Me.Label2)
        Me.grp_filtros.Controls.Add(Me.cmb_F1)
        Me.grp_filtros.Controls.Add(Me.Label12)
        Me.grp_filtros.Controls.Add(Me.lblInicio)
        Me.grp_filtros.Location = New System.Drawing.Point(12, 42)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(1189, 77)
        Me.grp_filtros.TabIndex = 14
        Me.grp_filtros.TabStop = False
        '
        'cmb_almacen
        '
        Me.cmb_almacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(234, 46)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(329, 21)
        Me.cmb_almacen.TabIndex = 4
        '
        'cmb_tipo
        '
        Me.cmb_tipo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo.FormattingEnabled = True
        Me.cmb_tipo.Items.AddRange(New Object() {"Ventas", " Compras", "Importaciones", "Devoluciones de ventas", "Devoluciones de compras", "Libro de ventas", "Libro de devoluciones", "Libro Auxiliar de Compras", "Libro Auxiliar de Ventas", "Libro Auxiliar de Ventas (Diario)"})
        Me.cmb_tipo.Location = New System.Drawing.Point(615, 47)
        Me.cmb_tipo.Name = "cmb_tipo"
        Me.cmb_tipo.Size = New System.Drawing.Size(277, 21)
        Me.cmb_tipo.TabIndex = 5
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(234, 19)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(132, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Location = New System.Drawing.Point(915, 24)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(85, 32)
        Me.btnGenerar.TabIndex = 6
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'cmb_f2
        '
        Me.cmb_f2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_f2.Location = New System.Drawing.Point(680, 19)
        Me.cmb_f2.Name = "cmb_f2"
        Me.cmb_f2.Size = New System.Drawing.Size(212, 20)
        Me.cmb_f2.TabIndex = 3
        '
        'lblFin
        '
        Me.lblFin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFin.AutoSize = True
        Me.lblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFin.Location = New System.Drawing.Point(648, 21)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(31, 17)
        Me.lblFin.TabIndex = 0
        Me.lblFin.Text = "Fin:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(168, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Almacen:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(569, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tipo:"
        '
        'cmb_F1
        '
        Me.cmb_F1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_F1.Location = New System.Drawing.Point(417, 20)
        Me.cmb_F1.Name = "cmb_F1"
        Me.cmb_F1.Size = New System.Drawing.Size(218, 20)
        Me.cmb_F1.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(168, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 17)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Empresa:"
        '
        'lblInicio
        '
        Me.lblInicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicio.Location = New System.Drawing.Point(374, 20)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(44, 17)
        Me.lblInicio.TabIndex = 0
        Me.lblInicio.Text = "Inicio:"
        '
        'grd_ventas
        '
        Me.grd_ventas.AllowUserToAddRows = False
        Me.grd_ventas.AllowUserToDeleteRows = False
        Me.grd_ventas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_ventas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ventas.Location = New System.Drawing.Point(13, 126)
        Me.grd_ventas.Name = "grd_ventas"
        Me.grd_ventas.ReadOnly = True
        Me.grd_ventas.Size = New System.Drawing.Size(1188, 397)
        Me.grd_ventas.TabIndex = 15
        '
        'frm_libro_ventas
        '
        Me.AcceptButton = Me.btnGenerar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1213, 535)
        Me.Controls.Add(Me.grd_ventas)
        Me.Controls.Add(Me.grp_filtros)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_libro_ventas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Libro de Ventas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        CType(Me.grd_ventas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmb_f2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFin As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_F1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents grd_ventas As System.Windows.Forms.DataGridView
End Class
