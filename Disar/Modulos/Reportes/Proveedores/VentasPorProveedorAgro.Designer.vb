<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentasporProveedorAgro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VentasporProveedorAgro))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblFechaInicio = New System.Windows.Forms.Label
        Me.cmb_fecha_ini = New System.Windows.Forms.DateTimePicker
        Me.cmbFechaFinal = New System.Windows.Forms.DateTimePicker
        Me.Pestañas = New System.Windows.Forms.TabControl
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me.ToolStrip1.SuspendLayout()
        Me._grpCBuquedas.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1097, 39)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
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
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 51)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(1073, 62)
        Me._grpCBuquedas.TabIndex = 15
        Me._grpCBuquedas.TabStop = False
        Me._grpCBuquedas.Text = "Criterios de Busqueda"
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
        Me.Label1.Location = New System.Drawing.Point(554, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Final:"
        '
        '_lblFechaInicio
        '
        Me._lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaInicio.AutoSize = True
        Me._lblFechaInicio.Location = New System.Drawing.Point(165, 30)
        Me._lblFechaInicio.Name = "_lblFechaInicio"
        Me._lblFechaInicio.Size = New System.Drawing.Size(86, 16)
        Me._lblFechaInicio.TabIndex = 0
        Me._lblFechaInicio.Text = "Fecha Inicial:"
        '
        'cmb_fecha_ini
        '
        Me.cmb_fecha_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_ini.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_fecha_ini.Location = New System.Drawing.Point(256, 26)
        Me.cmb_fecha_ini.Name = "cmb_fecha_ini"
        Me.cmb_fecha_ini.Size = New System.Drawing.Size(283, 24)
        Me.cmb_fecha_ini.TabIndex = 1
        '
        'cmbFechaFinal
        '
        Me.cmbFechaFinal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFechaFinal.Location = New System.Drawing.Point(637, 26)
        Me.cmbFechaFinal.Name = "cmbFechaFinal"
        Me.cmbFechaFinal.Size = New System.Drawing.Size(265, 24)
        Me.cmbFechaFinal.TabIndex = 1
        '
        'Pestañas
        '
        Me.Pestañas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pestañas.Location = New System.Drawing.Point(12, 119)
        Me.Pestañas.Name = "Pestañas"
        Me.Pestañas.SelectedIndex = 0
        Me.Pestañas.Size = New System.Drawing.Size(1073, 476)
        Me.Pestañas.TabIndex = 16
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
        'Imagen
        '
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.SR_AGRO_LOGO
        Me.Imagen.Location = New System.Drawing.Point(1046, 36)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(23, 20)
        Me.Imagen.TabIndex = 11
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        'VentasPorProveedorAgro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 598)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me.Pestañas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "VentasPorProveedorAgro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas Por Proveedor SR Agro"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Pestañas As System.Windows.Forms.TabControl
End Class
