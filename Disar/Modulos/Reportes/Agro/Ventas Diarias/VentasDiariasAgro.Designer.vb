<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentasDiariasAgro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VentasDiariasAgro))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._cmbFechaf = New System.Windows.Forms.DateTimePicker
        Me._cmbFechai = New System.Windows.Forms.DateTimePicker
        Me._lblFechaf = New System.Windows.Forms.Label
        Me._lblFechai = New System.Windows.Forms.Label
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me.Porcentaje = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DiasR = New System.Windows.Forms.Label
        Me.DiasM = New System.Windows.Forms.Label
        Me.DiasT = New System.Windows.Forms.Label
        Me.lblDiasRestantes = New System.Windows.Forms.Label
        Me.lblDiasM = New System.Windows.Forms.Label
        Me.lblDiasT = New System.Windows.Forms.Label
        Me.Pestañas = New System.Windows.Forms.TabControl
        Me.detalle = New System.Windows.Forms.TabPage
        Me._gridVEOSFINAL = New System.Windows.Forms.DataGridView
        Me.oficina = New System.Windows.Forms.TabPage
        Me.gridoficinas = New System.Windows.Forms.DataGridView
        Me.vd = New System.Windows.Forms.TabPage
        Me.gridVendedores = New System.Windows.Forms.DataGridView
        Me._gridvd = New System.Windows.Forms.DataGridView
        Me.resumen = New System.Windows.Forms.TabPage
        Me._gridresumen = New System.Windows.Forms.DataGridView
        Me.PorcentajeFinal = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me._gbCriteriosBusqueda.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pestañas.SuspendLayout()
        Me.detalle.SuspendLayout()
        CType(Me._gridVEOSFINAL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.oficina.SuspendLayout()
        CType(Me.gridoficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vd.SuspendLayout()
        CType(Me.gridVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridvd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.resumen.SuspendLayout()
        CType(Me._gridresumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(852, 39)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '_Archivo
        '
        Me._Archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAExcelToolStripMenuItem})
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        '_gbCriteriosBusqueda
        '
        Me._gbCriteriosBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gbCriteriosBusqueda.Controls.Add(Me._btnGenerar)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechai)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechaf)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechai)
        Me._gbCriteriosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbCriteriosBusqueda.Location = New System.Drawing.Point(12, 42)
        Me._gbCriteriosBusqueda.Name = "_gbCriteriosBusqueda"
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(828, 62)
        Me._gbCriteriosBusqueda.TabIndex = 9
        Me._gbCriteriosBusqueda.TabStop = False
        Me._gbCriteriosBusqueda.Text = "Criterios de Busqueda"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(721, 20)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(80, 25)
        Me._btnGenerar.TabIndex = 3
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_cmbFechaf
        '
        Me._cmbFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbFechaf.Location = New System.Drawing.Point(459, 23)
        Me._cmbFechaf.Name = "_cmbFechaf"
        Me._cmbFechaf.Size = New System.Drawing.Size(210, 20)
        Me._cmbFechaf.TabIndex = 2
        '
        '_cmbFechai
        '
        Me._cmbFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbFechai.Location = New System.Drawing.Point(115, 23)
        Me._cmbFechai.Name = "_cmbFechai"
        Me._cmbFechai.Size = New System.Drawing.Size(210, 20)
        Me._cmbFechai.TabIndex = 1
        '
        '_lblFechaf
        '
        Me._lblFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaf.AutoSize = True
        Me._lblFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaf.Location = New System.Drawing.Point(380, 26)
        Me._lblFechaf.Name = "_lblFechaf"
        Me._lblFechaf.Size = New System.Drawing.Size(77, 13)
        Me._lblFechaf.TabIndex = 1
        Me._lblFechaf.Text = "Fecha Final:"
        '
        '_lblFechai
        '
        Me._lblFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechai.AutoSize = True
        Me._lblFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechai.Location = New System.Drawing.Point(32, 26)
        Me._lblFechai.Name = "_lblFechai"
        Me._lblFechai.Size = New System.Drawing.Size(84, 13)
        Me._lblFechai.TabIndex = 0
        Me._lblFechai.Text = "Fecha Inicial:"
        '
        'Imagen
        '
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.SR_AGRO_LOGO
        Me.Imagen.Location = New System.Drawing.Point(794, 110)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(15, 17)
        Me.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen.TabIndex = 33
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        'Porcentaje
        '
        Me.Porcentaje.AutoSize = True
        Me.Porcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Porcentaje.Location = New System.Drawing.Point(466, 114)
        Me.Porcentaje.Name = "Porcentaje"
        Me.Porcentaje.Size = New System.Drawing.Size(27, 13)
        Me.Porcentaje.TabIndex = 32
        Me.Porcentaje.Text = "     "
        Me.Porcentaje.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(373, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Porcentaje Ideal:"
        '
        'DiasR
        '
        Me.DiasR.AutoSize = True
        Me.DiasR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiasR.Location = New System.Drawing.Point(340, 114)
        Me.DiasR.Name = "DiasR"
        Me.DiasR.Size = New System.Drawing.Size(27, 13)
        Me.DiasR.TabIndex = 6
        Me.DiasR.Text = "     "
        '
        'DiasM
        '
        Me.DiasM.AutoSize = True
        Me.DiasM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiasM.Location = New System.Drawing.Point(224, 114)
        Me.DiasM.Name = "DiasM"
        Me.DiasM.Size = New System.Drawing.Size(27, 13)
        Me.DiasM.TabIndex = 5
        Me.DiasM.Text = "     "
        '
        'DiasT
        '
        Me.DiasT.AutoSize = True
        Me.DiasT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiasT.Location = New System.Drawing.Point(105, 114)
        Me.DiasT.Name = "DiasT"
        Me.DiasT.Size = New System.Drawing.Size(27, 13)
        Me.DiasT.TabIndex = 4
        Me.DiasT.Text = "     "
        '
        'lblDiasRestantes
        '
        Me.lblDiasRestantes.AutoSize = True
        Me.lblDiasRestantes.Location = New System.Drawing.Point(252, 114)
        Me.lblDiasRestantes.Name = "lblDiasRestantes"
        Me.lblDiasRestantes.Size = New System.Drawing.Size(82, 13)
        Me.lblDiasRestantes.TabIndex = 27
        Me.lblDiasRestantes.Text = "Dias Restantes:"
        '
        'lblDiasM
        '
        Me.lblDiasM.AutoSize = True
        Me.lblDiasM.Location = New System.Drawing.Point(133, 114)
        Me.lblDiasM.Name = "lblDiasM"
        Me.lblDiasM.Size = New System.Drawing.Size(85, 13)
        Me.lblDiasM.TabIndex = 26
        Me.lblDiasM.Text = "Dias Mensuales:"
        '
        'lblDiasT
        '
        Me.lblDiasT.AutoSize = True
        Me.lblDiasT.Location = New System.Drawing.Point(12, 114)
        Me.lblDiasT.Name = "lblDiasT"
        Me.lblDiasT.Size = New System.Drawing.Size(87, 13)
        Me.lblDiasT.TabIndex = 25
        Me.lblDiasT.Text = "Dias Trabajados:"
        '
        'Pestañas
        '
        Me.Pestañas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pestañas.Controls.Add(Me.detalle)
        Me.Pestañas.Controls.Add(Me.oficina)
        Me.Pestañas.Controls.Add(Me.vd)
        Me.Pestañas.Controls.Add(Me.resumen)
        Me.Pestañas.Location = New System.Drawing.Point(12, 133)
        Me.Pestañas.Name = "Pestañas"
        Me.Pestañas.SelectedIndex = 0
        Me.Pestañas.Size = New System.Drawing.Size(828, 230)
        Me.Pestañas.TabIndex = 8
        '
        'detalle
        '
        Me.detalle.Controls.Add(Me._gridVEOSFINAL)
        Me.detalle.Location = New System.Drawing.Point(4, 22)
        Me.detalle.Name = "detalle"
        Me.detalle.Padding = New System.Windows.Forms.Padding(3)
        Me.detalle.Size = New System.Drawing.Size(820, 204)
        Me.detalle.TabIndex = 0
        Me.detalle.Text = "Detalle VEO'S"
        Me.detalle.UseVisualStyleBackColor = True
        '
        '_gridVEOSFINAL
        '
        Me._gridVEOSFINAL.AllowUserToAddRows = False
        Me._gridVEOSFINAL.AllowUserToDeleteRows = False
        Me._gridVEOSFINAL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridVEOSFINAL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridVEOSFINAL.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridVEOSFINAL.Location = New System.Drawing.Point(3, 3)
        Me._gridVEOSFINAL.Name = "_gridVEOSFINAL"
        Me._gridVEOSFINAL.ReadOnly = True
        Me._gridVEOSFINAL.Size = New System.Drawing.Size(814, 198)
        Me._gridVEOSFINAL.TabIndex = 37
        '
        'oficina
        '
        Me.oficina.Controls.Add(Me.gridoficinas)
        Me.oficina.Location = New System.Drawing.Point(4, 22)
        Me.oficina.Name = "oficina"
        Me.oficina.Padding = New System.Windows.Forms.Padding(3)
        Me.oficina.Size = New System.Drawing.Size(820, 204)
        Me.oficina.TabIndex = 5
        Me.oficina.Text = "Agro OFICINAS"
        Me.oficina.UseVisualStyleBackColor = True
        '
        'gridoficinas
        '
        Me.gridoficinas.AllowUserToAddRows = False
        Me.gridoficinas.AllowUserToDeleteRows = False
        Me.gridoficinas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridoficinas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridoficinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridoficinas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridoficinas.Location = New System.Drawing.Point(3, 3)
        Me.gridoficinas.Name = "gridoficinas"
        Me.gridoficinas.ReadOnly = True
        Me.gridoficinas.Size = New System.Drawing.Size(814, 198)
        Me.gridoficinas.TabIndex = 12
        '
        'vd
        '
        Me.vd.Controls.Add(Me.gridVendedores)
        Me.vd.Controls.Add(Me._gridvd)
        Me.vd.Location = New System.Drawing.Point(4, 22)
        Me.vd.Name = "vd"
        Me.vd.Padding = New System.Windows.Forms.Padding(3)
        Me.vd.Size = New System.Drawing.Size(820, 204)
        Me.vd.TabIndex = 3
        Me.vd.Text = "Ventas Diarias"
        Me.vd.UseVisualStyleBackColor = True
        '
        'gridVendedores
        '
        Me.gridVendedores.AllowUserToAddRows = False
        Me.gridVendedores.AllowUserToDeleteRows = False
        Me.gridVendedores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridVendedores.Location = New System.Drawing.Point(789, 280)
        Me.gridVendedores.Name = "gridVendedores"
        Me.gridVendedores.ReadOnly = True
        Me.gridVendedores.Size = New System.Drawing.Size(39, 26)
        Me.gridVendedores.TabIndex = 0
        Me.gridVendedores.Visible = False
        '
        '_gridvd
        '
        Me._gridvd.AllowUserToAddRows = False
        Me._gridvd.AllowUserToDeleteRows = False
        Me._gridvd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridvd.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridvd.Location = New System.Drawing.Point(3, 3)
        Me._gridvd.Name = "_gridvd"
        Me._gridvd.ReadOnly = True
        Me._gridvd.Size = New System.Drawing.Size(814, 198)
        Me._gridvd.TabIndex = 0
        '
        'resumen
        '
        Me.resumen.Controls.Add(Me._gridresumen)
        Me.resumen.Location = New System.Drawing.Point(4, 22)
        Me.resumen.Name = "resumen"
        Me.resumen.Padding = New System.Windows.Forms.Padding(3)
        Me.resumen.Size = New System.Drawing.Size(820, 204)
        Me.resumen.TabIndex = 1
        Me.resumen.Text = "Resumen"
        Me.resumen.UseVisualStyleBackColor = True
        '
        '_gridresumen
        '
        Me._gridresumen.AllowUserToAddRows = False
        Me._gridresumen.AllowUserToDeleteRows = False
        Me._gridresumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridresumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridresumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridresumen.Location = New System.Drawing.Point(3, 3)
        Me._gridresumen.Name = "_gridresumen"
        Me._gridresumen.ReadOnly = True
        Me._gridresumen.Size = New System.Drawing.Size(814, 198)
        Me._gridresumen.TabIndex = 11
        '
        'PorcentajeFinal
        '
        Me.PorcentajeFinal.AutoSize = True
        Me.PorcentajeFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PorcentajeFinal.Location = New System.Drawing.Point(466, 114)
        Me.PorcentajeFinal.Name = "PorcentajeFinal"
        Me.PorcentajeFinal.Size = New System.Drawing.Size(27, 13)
        Me.PorcentajeFinal.TabIndex = 7
        Me.PorcentajeFinal.Text = "     "
        '
        'VentasDiariasAgro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 375)
        Me.Controls.Add(Me.Pestañas)
        Me.Controls.Add(Me.Imagen)
        Me.Controls.Add(Me.PorcentajeFinal)
        Me.Controls.Add(Me.Porcentaje)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DiasR)
        Me.Controls.Add(Me.DiasM)
        Me.Controls.Add(Me.DiasT)
        Me.Controls.Add(Me.lblDiasRestantes)
        Me.Controls.Add(Me.lblDiasM)
        Me.Controls.Add(Me.lblDiasT)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "VentasDiariasAgro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas Diarias Agro"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pestañas.ResumeLayout(False)
        Me.detalle.ResumeLayout(False)
        CType(Me._gridVEOSFINAL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.oficina.ResumeLayout(False)
        CType(Me.gridoficinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vd.ResumeLayout(False)
        CType(Me.gridVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridvd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.resumen.ResumeLayout(False)
        CType(Me._gridresumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _cmbFechaf As System.Windows.Forms.DateTimePicker
    Friend WithEvents _cmbFechai As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechaf As System.Windows.Forms.Label
    Friend WithEvents _lblFechai As System.Windows.Forms.Label
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents Porcentaje As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DiasR As System.Windows.Forms.Label
    Friend WithEvents DiasM As System.Windows.Forms.Label
    Friend WithEvents DiasT As System.Windows.Forms.Label
    Friend WithEvents lblDiasRestantes As System.Windows.Forms.Label
    Friend WithEvents lblDiasM As System.Windows.Forms.Label
    Friend WithEvents lblDiasT As System.Windows.Forms.Label
    Friend WithEvents Pestañas As System.Windows.Forms.TabControl
    Friend WithEvents detalle As System.Windows.Forms.TabPage
    Friend WithEvents oficina As System.Windows.Forms.TabPage
    Friend WithEvents gridoficinas As System.Windows.Forms.DataGridView
    Friend WithEvents vd As System.Windows.Forms.TabPage
    Friend WithEvents _gridvd As System.Windows.Forms.DataGridView
    Friend WithEvents resumen As System.Windows.Forms.TabPage
    Friend WithEvents _gridresumen As System.Windows.Forms.DataGridView
    Friend WithEvents _gridVEOSFINAL As System.Windows.Forms.DataGridView
    Friend WithEvents gridVendedores As System.Windows.Forms.DataGridView
    Friend WithEvents PorcentajeFinal As System.Windows.Forms.Label
End Class
