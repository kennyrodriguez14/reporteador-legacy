<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_carga_acumulado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_carga_acumulado))
        Me.Contenedor = New System.Windows.Forms.TabControl()
        Me.Bodega = New System.Windows.Forms.TabPage()
        Me.grdBodega = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pesobodega = New System.Windows.Forms.Label()
        Me.Unidadesbodega = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dinerobodega = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Imagen = New System.Windows.Forms.PictureBox()
        Me.folio_fin = New System.Windows.Forms.Label()
        Me.folio_ini = New System.Windows.Forms.Label()
        Me.cmb_Fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.cmbFecha_ini = New System.Windows.Forms.DateTimePicker()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me._btnLimpiar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._btnGenerar = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Contenedor.SuspendLayout()
        Me.Bodega.SuspendLayout()
        CType(Me.grdBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Contenedor
        '
        Me.Contenedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Contenedor.Controls.Add(Me.Bodega)
        Me.Contenedor.Location = New System.Drawing.Point(12, 124)
        Me.Contenedor.Name = "Contenedor"
        Me.Contenedor.SelectedIndex = 0
        Me.Contenedor.Size = New System.Drawing.Size(878, 435)
        Me.Contenedor.TabIndex = 13
        '
        'Bodega
        '
        Me.Bodega.Controls.Add(Me.grdBodega)
        Me.Bodega.Controls.Add(Me.Label3)
        Me.Bodega.Controls.Add(Me.pesobodega)
        Me.Bodega.Controls.Add(Me.Unidadesbodega)
        Me.Bodega.Controls.Add(Me.Label5)
        Me.Bodega.Controls.Add(Me.dinerobodega)
        Me.Bodega.Controls.Add(Me.Label7)
        Me.Bodega.Location = New System.Drawing.Point(4, 22)
        Me.Bodega.Name = "Bodega"
        Me.Bodega.Padding = New System.Windows.Forms.Padding(3)
        Me.Bodega.Size = New System.Drawing.Size(870, 409)
        Me.Bodega.TabIndex = 0
        Me.Bodega.Text = "Bodega"
        Me.Bodega.UseVisualStyleBackColor = True
        '
        'grdBodega
        '
        Me.grdBodega.AllowUserToAddRows = False
        Me.grdBodega.AllowUserToDeleteRows = False
        Me.grdBodega.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdBodega.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdBodega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBodega.Location = New System.Drawing.Point(6, 25)
        Me.grdBodega.Name = "grdBodega"
        Me.grdBodega.ReadOnly = True
        Me.grdBodega.Size = New System.Drawing.Size(858, 378)
        Me.grdBodega.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(473, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Total Unidades:"
        '
        'pesobodega
        '
        Me.pesobodega.AutoSize = True
        Me.pesobodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pesobodega.Location = New System.Drawing.Point(115, 7)
        Me.pesobodega.Name = "pesobodega"
        Me.pesobodega.Size = New System.Drawing.Size(23, 15)
        Me.pesobodega.TabIndex = 10
        Me.pesobodega.Text = "    "
        '
        'Unidadesbodega
        '
        Me.Unidadesbodega.AutoSize = True
        Me.Unidadesbodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Unidadesbodega.Location = New System.Drawing.Point(587, 7)
        Me.Unidadesbodega.Name = "Unidadesbodega"
        Me.Unidadesbodega.Size = New System.Drawing.Size(23, 15)
        Me.Unidadesbodega.TabIndex = 10
        Me.Unidadesbodega.Text = "    "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(243, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Total en Dinero:"
        '
        'dinerobodega
        '
        Me.dinerobodega.AutoSize = True
        Me.dinerobodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dinerobodega.Location = New System.Drawing.Point(359, 7)
        Me.dinerobodega.Name = "dinerobodega"
        Me.dinerobodega.Size = New System.Drawing.Size(23, 15)
        Me.dinerobodega.TabIndex = 10
        Me.dinerobodega.Text = "    "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Total en Peso:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Imagen)
        Me.GroupBox1.Controls.Add(Me.folio_fin)
        Me.GroupBox1.Controls.Add(Me.folio_ini)
        Me.GroupBox1.Controls.Add(Me.cmb_Fecha_fin)
        Me.GroupBox1.Controls.Add(Me.cmbFecha_ini)
        Me.GroupBox1.Controls.Add(Me.cmbAlmacen)
        Me.GroupBox1.Controls.Add(Me.cmbSucursal)
        Me.GroupBox1.Controls.Add(Me._btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me._btnGenerar)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(878, 76)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Imagen
        '
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.wtSR
        Me.Imagen.Location = New System.Drawing.Point(7, 13)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(21, 15)
        Me.Imagen.TabIndex = 11
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        'folio_fin
        '
        Me.folio_fin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.folio_fin.AutoSize = True
        Me.folio_fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folio_fin.Location = New System.Drawing.Point(465, 49)
        Me.folio_fin.Name = "folio_fin"
        Me.folio_fin.Size = New System.Drawing.Size(0, 15)
        Me.folio_fin.TabIndex = 10
        '
        'folio_ini
        '
        Me.folio_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.folio_ini.AutoSize = True
        Me.folio_ini.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folio_ini.Location = New System.Drawing.Point(161, 52)
        Me.folio_ini.Name = "folio_ini"
        Me.folio_ini.Size = New System.Drawing.Size(0, 15)
        Me.folio_ini.TabIndex = 10
        '
        'cmb_Fecha_fin
        '
        Me.cmb_Fecha_fin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_Fecha_fin.Location = New System.Drawing.Point(465, 46)
        Me.cmb_Fecha_fin.Name = "cmb_Fecha_fin"
        Me.cmb_Fecha_fin.Size = New System.Drawing.Size(245, 21)
        Me.cmb_Fecha_fin.TabIndex = 3
        '
        'cmbFecha_ini
        '
        Me.cmbFecha_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbFecha_ini.Location = New System.Drawing.Point(155, 49)
        Me.cmbFecha_ini.Name = "cmbFecha_ini"
        Me.cmbFecha_ini.Size = New System.Drawing.Size(245, 21)
        Me.cmbFecha_ini.TabIndex = 3
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(465, 15)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(245, 23)
        Me.cmbAlmacen.TabIndex = 2
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Items.AddRange(New Object() {"CONSUMO", "SR AGRO", "OPL"})
        Me.cmbSucursal.Location = New System.Drawing.Point(155, 16)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(144, 23)
        Me.cmbSucursal.TabIndex = 1
        '
        '_btnLimpiar
        '
        Me._btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnLimpiar.Location = New System.Drawing.Point(765, 44)
        Me._btnLimpiar.Name = "_btnLimpiar"
        Me._btnLimpiar.Size = New System.Drawing.Size(77, 27)
        Me._btnLimpiar.TabIndex = 7
        Me._btnLimpiar.Text = "Limpiar"
        Me._btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(407, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Almacen:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(438, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Fin:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(95, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Empresa:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(116, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Inicio:"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Location = New System.Drawing.Point(765, 13)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(77, 26)
        Me._btnGenerar.TabIndex = 6
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(902, 39)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'frm_reporte_carga_acumulado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 571)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Contenedor)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_reporte_carga_acumulado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Carga Acumulado"
        Me.Contenedor.ResumeLayout(False)
        Me.Bodega.ResumeLayout(False)
        Me.Bodega.PerformLayout()
        CType(Me.grdBodega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Contenedor As System.Windows.Forms.TabControl
    Friend WithEvents Bodega As System.Windows.Forms.TabPage
    Friend WithEvents grdBodega As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pesobodega As System.Windows.Forms.Label
    Friend WithEvents Unidadesbodega As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dinerobodega As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents folio_fin As System.Windows.Forms.Label
    Friend WithEvents folio_ini As System.Windows.Forms.Label
    Friend WithEvents cmbFecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents _btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmb_Fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
