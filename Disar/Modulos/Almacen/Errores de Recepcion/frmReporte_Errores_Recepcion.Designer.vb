<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporte_Errores_Recepcion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReporte_Errores_Recepcion))
        Me.filtro = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.cmbFin = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmFechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.grupo = New System.Windows.Forms.TabControl
        Me.pnel_detalle = New System.Windows.Forms.TabPage
        Me.grd_listado = New System.Windows.Forms.DataGridView
        Me.pnel_encabezado = New System.Windows.Forms.TabPage
        Me.grd_encabezado = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.filtro.SuspendLayout()
        Me.grupo.SuspendLayout()
        Me.pnel_detalle.SuspendLayout()
        CType(Me.grd_listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnel_encabezado.SuspendLayout()
        CType(Me.grd_encabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'filtro
        '
        Me.filtro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtro.Controls.Add(Me.Label2)
        Me.filtro.Controls.Add(Me.cmb_empresa)
        Me.filtro.Controls.Add(Me.Label12)
        Me.filtro.Controls.Add(Me.cmb_almacen)
        Me.filtro.Controls.Add(Me.cmbFin)
        Me.filtro.Controls.Add(Me.Label1)
        Me.filtro.Controls.Add(Me.Button1)
        Me.filtro.Controls.Add(Me.cmFechaIni)
        Me.filtro.Controls.Add(Me.Label5)
        Me.filtro.Location = New System.Drawing.Point(12, 51)
        Me.filtro.Name = "filtro"
        Me.filtro.Size = New System.Drawing.Size(1104, 83)
        Me.filtro.TabIndex = 42
        Me.filtro.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Empresa:"
        '
        'cmb_empresa
        '
        Me.cmb_empresa.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Items.AddRange(New Object() {"TODAS", "SAN RAFAEL", "DIMOSA"})
        Me.cmb_empresa.Location = New System.Drawing.Point(65, 16)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(204, 21)
        Me.cmb_empresa.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Sucursal:"
        '
        'cmb_almacen
        '
        Me.cmb_almacen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(65, 46)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(204, 21)
        Me.cmb_almacen.TabIndex = 24
        '
        'cmbFin
        '
        Me.cmbFin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbFin.Location = New System.Drawing.Point(608, 46)
        Me.cmbFin.Name = "cmbFin"
        Me.cmbFin.Size = New System.Drawing.Size(195, 20)
        Me.cmbFin.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(546, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha Final:"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.Location = New System.Drawing.Point(813, 47)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 19)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Generar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmFechaIni
        '
        Me.cmFechaIni.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmFechaIni.Location = New System.Drawing.Point(350, 46)
        Me.cmFechaIni.Name = "cmFechaIni"
        Me.cmFechaIni.Size = New System.Drawing.Size(193, 20)
        Me.cmFechaIni.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(283, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha Inicial:"
        '
        'grupo
        '
        Me.grupo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grupo.Controls.Add(Me.pnel_detalle)
        Me.grupo.Controls.Add(Me.pnel_encabezado)
        Me.grupo.Location = New System.Drawing.Point(12, 149)
        Me.grupo.Name = "grupo"
        Me.grupo.SelectedIndex = 0
        Me.grupo.Size = New System.Drawing.Size(1104, 382)
        Me.grupo.TabIndex = 44
        '
        'pnel_detalle
        '
        Me.pnel_detalle.Controls.Add(Me.grd_listado)
        Me.pnel_detalle.Location = New System.Drawing.Point(4, 22)
        Me.pnel_detalle.Name = "pnel_detalle"
        Me.pnel_detalle.Padding = New System.Windows.Forms.Padding(3)
        Me.pnel_detalle.Size = New System.Drawing.Size(1096, 356)
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
        Me.grd_listado.Size = New System.Drawing.Size(1090, 350)
        Me.grd_listado.TabIndex = 35
        '
        'pnel_encabezado
        '
        Me.pnel_encabezado.Controls.Add(Me.grd_encabezado)
        Me.pnel_encabezado.Location = New System.Drawing.Point(4, 22)
        Me.pnel_encabezado.Name = "pnel_encabezado"
        Me.pnel_encabezado.Padding = New System.Windows.Forms.Padding(3)
        Me.pnel_encabezado.Size = New System.Drawing.Size(1096, 356)
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
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1128, 39)
        Me.ToolStrip1.TabIndex = 43
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
        'frmReporte_Errores_Recepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1128, 534)
        Me.Controls.Add(Me.grupo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.filtro)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReporte_Errores_Recepcion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Errores de Recepción"
        Me.filtro.ResumeLayout(False)
        Me.filtro.PerformLayout()
        Me.grupo.ResumeLayout(False)
        Me.pnel_detalle.ResumeLayout(False)
        CType(Me.grd_listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnel_encabezado.ResumeLayout(False)
        CType(Me.grd_encabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents filtro As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grupo As System.Windows.Forms.TabControl
    Friend WithEvents pnel_detalle As System.Windows.Forms.TabPage
    Friend WithEvents grd_listado As System.Windows.Forms.DataGridView
    Friend WithEvents pnel_encabezado As System.Windows.Forms.TabPage
    Friend WithEvents grd_encabezado As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
End Class
