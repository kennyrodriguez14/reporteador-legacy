<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentasporProveedor
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VentasporProveedor))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblFechaInicio = New System.Windows.Forms.Label
        Me.cmb_fecha_ini = New System.Windows.Forms.DateTimePicker
        Me.cmbFechaFinal = New System.Windows.Forms.DateTimePicker
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grdmovil2 = New System.Windows.Forms.DataGridView
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.grd_movil1 = New System.Windows.Forms.DataGridView
        Me.RESUMEN = New System.Windows.Forms.TabPage
        Me._gridResumen = New System.Windows.Forms.DataGridView
        Me.tegucigalpa = New System.Windows.Forms.TabPage
        Me.grd_Teg = New System.Windows.Forms.DataGridView
        Me.tocoa = New System.Windows.Forms.TabPage
        Me.grd_tocoa = New System.Windows.Forms.DataGridView
        Me._psps = New System.Windows.Forms.TabPage
        Me._gridSPS = New System.Windows.Forms.DataGridView
        Me._src = New System.Windows.Forms.TabPage
        Me._gridSRC = New System.Windows.Forms.DataGridView
        Me.Pestañas = New System.Windows.Forms.TabControl
        Me.ToolStrip1.SuspendLayout()
        Me._grpCBuquedas.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdmovil2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.grd_movil1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RESUMEN.SuspendLayout()
        CType(Me._gridResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tegucigalpa.SuspendLayout()
        CType(Me.grd_Teg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tocoa.SuspendLayout()
        CType(Me.grd_tocoa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._psps.SuspendLayout()
        CType(Me._gridSPS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._src.SuspendLayout()
        CType(Me._gridSRC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pestañas.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1097, 39)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '_Archivo
        '
        Me._Archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAExcelToolStripMenuItem, Me.CerrarToolStripMenuItem})
        Me._Archivo.Image = Global.Disar.My.Resources.Resources.Opciones
        Me._Archivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Archivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._Archivo.Name = "_Archivo"
        Me._Archivo.Size = New System.Drawing.Size(100, 36)
        Me._Archivo.Text = "Acciones"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Excel_32
        Me.ExportarAExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(171, 38)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar a Excel"
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.CerrarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(171, 38)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        '_grpCBuquedas
        '
        Me._grpCBuquedas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._grpCBuquedas.Controls.Add(Me.Imagen)
        Me._grpCBuquedas.Controls.Add(Me._btnGenerar)
        Me._grpCBuquedas.Controls.Add(Me.Label1)
        Me._grpCBuquedas.Controls.Add(Me._lblFechaInicio)
        Me._grpCBuquedas.Controls.Add(Me.cmb_fecha_ini)
        Me._grpCBuquedas.Controls.Add(Me.cmbFechaFinal)
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 42)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(1073, 62)
        Me._grpCBuquedas.TabIndex = 8
        Me._grpCBuquedas.TabStop = False
        Me._grpCBuquedas.Text = "Criterios de Busqueda"
        '
        'Imagen
        '
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.wtSR
        Me.Imagen.Location = New System.Drawing.Point(1046, 36)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(23, 20)
        Me.Imagen.TabIndex = 11
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Location = New System.Drawing.Point(908, 25)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(96, 28)
        Me._btnGenerar.TabIndex = 2
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(499, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Final:"
        '
        '_lblFechaInicio
        '
        Me._lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaInicio.AutoSize = True
        Me._lblFechaInicio.Location = New System.Drawing.Point(84, 29)
        Me._lblFechaInicio.Name = "_lblFechaInicio"
        Me._lblFechaInicio.Size = New System.Drawing.Size(102, 20)
        Me._lblFechaInicio.TabIndex = 0
        Me._lblFechaInicio.Text = "Fecha Inicial:"
        '
        'cmb_fecha_ini
        '
        Me.cmb_fecha_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_ini.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_fecha_ini.Location = New System.Drawing.Point(192, 26)
        Me.cmb_fecha_ini.Name = "cmb_fecha_ini"
        Me.cmb_fecha_ini.Size = New System.Drawing.Size(301, 26)
        Me.cmb_fecha_ini.TabIndex = 1
        '
        'cmbFechaFinal
        '
        Me.cmbFechaFinal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFechaFinal.Location = New System.Drawing.Point(601, 26)
        Me.cmbFechaFinal.Name = "cmbFechaFinal"
        Me.cmbFechaFinal.Size = New System.Drawing.Size(301, 26)
        Me.cmbFechaFinal.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdmovil2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1065, 450)
        Me.TabPage2.TabIndex = 5
        Me.TabPage2.Text = "Almacén Selvin Zelaya"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdmovil2
        '
        Me.grdmovil2.AllowUserToAddRows = False
        Me.grdmovil2.AllowUserToDeleteRows = False
        Me.grdmovil2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdmovil2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdmovil2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdmovil2.Location = New System.Drawing.Point(3, 3)
        Me.grdmovil2.Name = "grdmovil2"
        Me.grdmovil2.ReadOnly = True
        Me.grdmovil2.Size = New System.Drawing.Size(1059, 444)
        Me.grdmovil2.TabIndex = 13
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grd_movil1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1065, 450)
        Me.TabPage1.TabIndex = 4
        Me.TabPage1.Text = "Almacén Daniel Salinas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grd_movil1
        '
        Me.grd_movil1.AllowUserToAddRows = False
        Me.grd_movil1.AllowUserToDeleteRows = False
        Me.grd_movil1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_movil1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_movil1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_movil1.Location = New System.Drawing.Point(3, 3)
        Me.grd_movil1.Name = "grd_movil1"
        Me.grd_movil1.ReadOnly = True
        Me.grd_movil1.Size = New System.Drawing.Size(1059, 444)
        Me.grd_movil1.TabIndex = 13
        '
        'RESUMEN
        '
        Me.RESUMEN.Controls.Add(Me._gridResumen)
        Me.RESUMEN.Location = New System.Drawing.Point(4, 22)
        Me.RESUMEN.Name = "RESUMEN"
        Me.RESUMEN.Size = New System.Drawing.Size(1065, 450)
        Me.RESUMEN.TabIndex = 2
        Me.RESUMEN.Text = "Resumen Noroccidente"
        Me.RESUMEN.UseVisualStyleBackColor = True
        '
        '_gridResumen
        '
        Me._gridResumen.AllowUserToAddRows = False
        Me._gridResumen.AllowUserToDeleteRows = False
        Me._gridResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gridResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridResumen.Location = New System.Drawing.Point(3, 3)
        Me._gridResumen.Name = "_gridResumen"
        Me._gridResumen.ReadOnly = True
        DataGridViewCellStyle1.Format = "N2"
        Me._gridResumen.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me._gridResumen.Size = New System.Drawing.Size(1059, 444)
        Me._gridResumen.TabIndex = 12
        '
        'tegucigalpa
        '
        Me.tegucigalpa.Controls.Add(Me.grd_Teg)
        Me.tegucigalpa.Location = New System.Drawing.Point(4, 22)
        Me.tegucigalpa.Name = "tegucigalpa"
        Me.tegucigalpa.Size = New System.Drawing.Size(1065, 450)
        Me.tegucigalpa.TabIndex = 7
        Me.tegucigalpa.Text = "Tegucigalpa"
        Me.tegucigalpa.UseVisualStyleBackColor = True
        '
        'grd_Teg
        '
        Me.grd_Teg.AllowUserToAddRows = False
        Me.grd_Teg.AllowUserToDeleteRows = False
        Me.grd_Teg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_Teg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_Teg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_Teg.Location = New System.Drawing.Point(3, 3)
        Me.grd_Teg.Name = "grd_Teg"
        Me.grd_Teg.ReadOnly = True
        Me.grd_Teg.Size = New System.Drawing.Size(1059, 444)
        Me.grd_Teg.TabIndex = 13
        '
        'tocoa
        '
        Me.tocoa.Controls.Add(Me.grd_tocoa)
        Me.tocoa.Location = New System.Drawing.Point(4, 22)
        Me.tocoa.Name = "tocoa"
        Me.tocoa.Padding = New System.Windows.Forms.Padding(3)
        Me.tocoa.Size = New System.Drawing.Size(1065, 450)
        Me.tocoa.TabIndex = 3
        Me.tocoa.Text = "Sabá"
        Me.tocoa.UseVisualStyleBackColor = True
        '
        'grd_tocoa
        '
        Me.grd_tocoa.AllowUserToAddRows = False
        Me.grd_tocoa.AllowUserToDeleteRows = False
        Me.grd_tocoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_tocoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_tocoa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_tocoa.Location = New System.Drawing.Point(3, 3)
        Me.grd_tocoa.Name = "grd_tocoa"
        Me.grd_tocoa.ReadOnly = True
        Me.grd_tocoa.Size = New System.Drawing.Size(1059, 444)
        Me.grd_tocoa.TabIndex = 12
        '
        '_psps
        '
        Me._psps.Controls.Add(Me._gridSPS)
        Me._psps.Location = New System.Drawing.Point(4, 22)
        Me._psps.Name = "_psps"
        Me._psps.Padding = New System.Windows.Forms.Padding(3)
        Me._psps.Size = New System.Drawing.Size(1065, 450)
        Me._psps.TabIndex = 1
        Me._psps.Text = "SPS"
        Me._psps.UseVisualStyleBackColor = True
        '
        '_gridSPS
        '
        Me._gridSPS.AllowUserToAddRows = False
        Me._gridSPS.AllowUserToDeleteRows = False
        Me._gridSPS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridSPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridSPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridSPS.Location = New System.Drawing.Point(3, 3)
        Me._gridSPS.Name = "_gridSPS"
        Me._gridSPS.ReadOnly = True
        Me._gridSPS.Size = New System.Drawing.Size(1059, 444)
        Me._gridSPS.TabIndex = 11
        '
        '_src
        '
        Me._src.Controls.Add(Me._gridSRC)
        Me._src.Location = New System.Drawing.Point(4, 22)
        Me._src.Name = "_src"
        Me._src.Padding = New System.Windows.Forms.Padding(3)
        Me._src.Size = New System.Drawing.Size(1065, 450)
        Me._src.TabIndex = 0
        Me._src.Text = "SRC"
        Me._src.UseVisualStyleBackColor = True
        '
        '_gridSRC
        '
        Me._gridSRC.AllowUserToAddRows = False
        Me._gridSRC.AllowUserToDeleteRows = False
        Me._gridSRC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridSRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridSRC.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridSRC.Location = New System.Drawing.Point(3, 3)
        Me._gridSRC.Name = "_gridSRC"
        Me._gridSRC.ReadOnly = True
        Me._gridSRC.Size = New System.Drawing.Size(1059, 444)
        Me._gridSRC.TabIndex = 10
        '
        'Pestañas
        '
        Me.Pestañas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pestañas.Controls.Add(Me._src)
        Me.Pestañas.Controls.Add(Me._psps)
        Me.Pestañas.Controls.Add(Me.tocoa)
        Me.Pestañas.Controls.Add(Me.tegucigalpa)
        Me.Pestañas.Controls.Add(Me.RESUMEN)
        Me.Pestañas.Controls.Add(Me.TabPage1)
        Me.Pestañas.Controls.Add(Me.TabPage2)
        Me.Pestañas.Location = New System.Drawing.Point(12, 110)
        Me.Pestañas.Name = "Pestañas"
        Me.Pestañas.SelectedIndex = 0
        Me.Pestañas.Size = New System.Drawing.Size(1073, 476)
        Me.Pestañas.TabIndex = 10
        '
        'VentasporProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 598)
        Me.Controls.Add(Me.Pestañas)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "VentasporProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas por Proveedor"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdmovil2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grd_movil1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RESUMEN.ResumeLayout(False)
        CType(Me._gridResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tegucigalpa.ResumeLayout(False)
        CType(Me.grd_Teg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tocoa.ResumeLayout(False)
        CType(Me.grd_tocoa, System.ComponentModel.ISupportInitialize).EndInit()
        Me._psps.ResumeLayout(False)
        CType(Me._gridSPS, System.ComponentModel.ISupportInitialize).EndInit()
        Me._src.ResumeLayout(False)
        CType(Me._gridSRC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pestañas.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents cmbFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdmovil2 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents grd_movil1 As System.Windows.Forms.DataGridView
    Friend WithEvents RESUMEN As System.Windows.Forms.TabPage
    Friend WithEvents _gridResumen As System.Windows.Forms.DataGridView
    Friend WithEvents tegucigalpa As System.Windows.Forms.TabPage
    Friend WithEvents grd_Teg As System.Windows.Forms.DataGridView
    Friend WithEvents tocoa As System.Windows.Forms.TabPage
    Friend WithEvents grd_tocoa As System.Windows.Forms.DataGridView
    Friend WithEvents _psps As System.Windows.Forms.TabPage
    Friend WithEvents _gridSPS As System.Windows.Forms.DataGridView
    Friend WithEvents _src As System.Windows.Forms.TabPage
    Friend WithEvents _gridSRC As System.Windows.Forms.DataGridView
    Friend WithEvents Pestañas As System.Windows.Forms.TabControl
End Class
