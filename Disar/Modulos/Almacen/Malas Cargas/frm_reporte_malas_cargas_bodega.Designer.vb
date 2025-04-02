<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_malas_cargas_bodega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_malas_cargas_bodega))
        Me.filtro = New System.Windows.Forms.GroupBox
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox
        Me.lblAlmacen = New System.Windows.Forms.Label
        Me.cmbFin = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmFechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.grupo = New System.Windows.Forms.TabControl
        Me.pnel_detalle = New System.Windows.Forms.TabPage
        Me.grd_listado = New System.Windows.Forms.DataGridView
        Me.pnel_encabezado = New System.Windows.Forms.TabPage
        Me.grd_encabezado = New System.Windows.Forms.DataGridView
        Me.filtro.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grupo.SuspendLayout()
        Me.pnel_detalle.SuspendLayout()
        CType(Me.grd_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnel_encabezado.SuspendLayout()
        CType(Me.grd_encabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'filtro
        '
        Me.filtro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtro.Controls.Add(Me.cmbAlmacen)
        Me.filtro.Controls.Add(Me.lblAlmacen)
        Me.filtro.Controls.Add(Me.cmbFin)
        Me.filtro.Controls.Add(Me.Label1)
        Me.filtro.Controls.Add(Me.Button1)
        Me.filtro.Controls.Add(Me.cmFechaIni)
        Me.filtro.Controls.Add(Me.Label5)
        Me.filtro.Location = New System.Drawing.Point(7, 47)
        Me.filtro.Name = "filtro"
        Me.filtro.Size = New System.Drawing.Size(998, 38)
        Me.filtro.TabIndex = 29
        Me.filtro.TabStop = False
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(62, 10)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(210, 21)
        Me.cmbAlmacen.TabIndex = 33
        '
        'lblAlmacen
        '
        Me.lblAlmacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Location = New System.Drawing.Point(12, 14)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(51, 13)
        Me.lblAlmacen.TabIndex = 32
        Me.lblAlmacen.Text = "Sucursal:"
        '
        'cmbFin
        '
        Me.cmbFin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbFin.Location = New System.Drawing.Point(677, 12)
        Me.cmbFin.Name = "cmbFin"
        Me.cmbFin.Size = New System.Drawing.Size(215, 20)
        Me.cmbFin.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(606, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha Final:"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.Location = New System.Drawing.Point(930, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 19)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Generar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmFechaIni
        '
        Me.cmFechaIni.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmFechaIni.Location = New System.Drawing.Point(354, 12)
        Me.cmFechaIni.Name = "cmFechaIni"
        Me.cmFechaIni.Size = New System.Drawing.Size(215, 20)
        Me.cmFechaIni.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(278, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha Inicial:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1017, 39)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(69, 36)
        Me.ToolStripButton1.Text = "Excel"
        '
        'grupo
        '
        Me.grupo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grupo.Controls.Add(Me.pnel_detalle)
        Me.grupo.Controls.Add(Me.pnel_encabezado)
        Me.grupo.Location = New System.Drawing.Point(7, 91)
        Me.grupo.Name = "grupo"
        Me.grupo.SelectedIndex = 0
        Me.grupo.Size = New System.Drawing.Size(998, 432)
        Me.grupo.TabIndex = 37
        '
        'pnel_detalle
        '
        Me.pnel_detalle.Controls.Add(Me.grd_listado)
        Me.pnel_detalle.Location = New System.Drawing.Point(4, 22)
        Me.pnel_detalle.Name = "pnel_detalle"
        Me.pnel_detalle.Padding = New System.Windows.Forms.Padding(3)
        Me.pnel_detalle.Size = New System.Drawing.Size(990, 406)
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
        Me.grd_listado.Size = New System.Drawing.Size(984, 400)
        Me.grd_listado.TabIndex = 35
        '
        'pnel_encabezado
        '
        Me.pnel_encabezado.Controls.Add(Me.grd_encabezado)
        Me.pnel_encabezado.Location = New System.Drawing.Point(4, 22)
        Me.pnel_encabezado.Name = "pnel_encabezado"
        Me.pnel_encabezado.Padding = New System.Windows.Forms.Padding(3)
        Me.pnel_encabezado.Size = New System.Drawing.Size(990, 406)
        Me.pnel_encabezado.TabIndex = 1
        Me.pnel_encabezado.Text = "Encabezado"
        Me.pnel_encabezado.UseVisualStyleBackColor = True
        '
        'grd_encabezado
        '
        Me.grd_encabezado.AllowUserToAddRows = False
        Me.grd_encabezado.AllowUserToDeleteRows = False
        Me.grd_encabezado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grd_encabezado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_encabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_encabezado.Location = New System.Drawing.Point(280, 90)
        Me.grd_encabezado.Name = "grd_encabezado"
        Me.grd_encabezado.ReadOnly = True
        Me.grd_encabezado.Size = New System.Drawing.Size(456, 219)
        Me.grd_encabezado.TabIndex = 35
        '
        'frm_reporte_malas_cargas_bodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 535)
        Me.Controls.Add(Me.grupo)
        Me.Controls.Add(Me.filtro)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_reporte_malas_cargas_bodega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de malas cargas"
        Me.filtro.ResumeLayout(False)
        Me.filtro.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grupo.ResumeLayout(False)
        Me.pnel_detalle.ResumeLayout(False)
        CType(Me.grd_listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnel_encabezado.ResumeLayout(False)
        CType(Me.grd_encabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents filtro As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents grupo As System.Windows.Forms.TabControl
    Friend WithEvents pnel_detalle As System.Windows.Forms.TabPage
    Friend WithEvents grd_listado As System.Windows.Forms.DataGridView
    Friend WithEvents pnel_encabezado As System.Windows.Forms.TabPage
    Friend WithEvents grd_encabezado As System.Windows.Forms.DataGridView
End Class
