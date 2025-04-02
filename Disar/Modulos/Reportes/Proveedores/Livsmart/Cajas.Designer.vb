<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cajas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cajas))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me.Porcentaje = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DiasR = New System.Windows.Forms.Label
        Me.DiasM = New System.Windows.Forms.Label
        Me.DiasT = New System.Windows.Forms.Label
        Me.lblDiasRestantes = New System.Windows.Forms.Label
        Me.lblDiasM = New System.Windows.Forms.Label
        Me.lblDiasT = New System.Windows.Forms.Label
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._cmbFechaf = New System.Windows.Forms.DateTimePicker
        Me._cmbFechai = New System.Windows.Forms.DateTimePicker
        Me._lblFechaf = New System.Windows.Forms.Label
        Me._lblFechai = New System.Windows.Forms.Label
        Me._PResumen = New System.Windows.Forms.TabPage
        Me._gridResumen = New System.Windows.Forms.DataGridView
        Me.SPS = New System.Windows.Forms.TabPage
        Me._gridcajasSPS = New System.Windows.Forms.DataGridView
        Me.SRC = New System.Windows.Forms.TabPage
        Me._gridJC1 = New System.Windows.Forms.DataGridView
        Me._gridJC3 = New System.Windows.Forms.DataGridView
        Me._gridcajasSRC = New System.Windows.Forms.DataGridView
        Me._gridJC2 = New System.Windows.Forms.DataGridView
        Me.Pestañas = New System.Windows.Forms.TabControl
        Me._gridFinal = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._gbCriteriosBusqueda.SuspendLayout()
        Me._PResumen.SuspendLayout()
        CType(Me._gridResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SPS.SuspendLayout()
        CType(Me._gridcajasSPS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SRC.SuspendLayout()
        CType(Me._gridJC1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridJC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridcajasSRC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridJC2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pestañas.SuspendLayout()
        CType(Me._gridFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(925, 39)
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
        'Imagen
        '
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.Disar_Logo_26
        Me.Imagen.Location = New System.Drawing.Point(868, 378)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(15, 17)
        Me.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen.TabIndex = 37
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        'Porcentaje
        '
        Me.Porcentaje.AutoSize = True
        Me.Porcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Porcentaje.Location = New System.Drawing.Point(470, 119)
        Me.Porcentaje.Name = "Porcentaje"
        Me.Porcentaje.Size = New System.Drawing.Size(27, 13)
        Me.Porcentaje.TabIndex = 36
        Me.Porcentaje.Text = "     "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(377, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Porcentaje Ideal:"
        '
        'DiasR
        '
        Me.DiasR.AutoSize = True
        Me.DiasR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiasR.Location = New System.Drawing.Point(344, 119)
        Me.DiasR.Name = "DiasR"
        Me.DiasR.Size = New System.Drawing.Size(27, 13)
        Me.DiasR.TabIndex = 34
        Me.DiasR.Text = "     "
        '
        'DiasM
        '
        Me.DiasM.AutoSize = True
        Me.DiasM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiasM.Location = New System.Drawing.Point(228, 119)
        Me.DiasM.Name = "DiasM"
        Me.DiasM.Size = New System.Drawing.Size(27, 13)
        Me.DiasM.TabIndex = 33
        Me.DiasM.Text = "     "
        '
        'DiasT
        '
        Me.DiasT.AutoSize = True
        Me.DiasT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiasT.Location = New System.Drawing.Point(109, 119)
        Me.DiasT.Name = "DiasT"
        Me.DiasT.Size = New System.Drawing.Size(27, 13)
        Me.DiasT.TabIndex = 32
        Me.DiasT.Text = "     "
        '
        'lblDiasRestantes
        '
        Me.lblDiasRestantes.AutoSize = True
        Me.lblDiasRestantes.Location = New System.Drawing.Point(256, 119)
        Me.lblDiasRestantes.Name = "lblDiasRestantes"
        Me.lblDiasRestantes.Size = New System.Drawing.Size(82, 13)
        Me.lblDiasRestantes.TabIndex = 31
        Me.lblDiasRestantes.Text = "Dias Restantes:"
        '
        'lblDiasM
        '
        Me.lblDiasM.AutoSize = True
        Me.lblDiasM.Location = New System.Drawing.Point(137, 119)
        Me.lblDiasM.Name = "lblDiasM"
        Me.lblDiasM.Size = New System.Drawing.Size(85, 13)
        Me.lblDiasM.TabIndex = 30
        Me.lblDiasM.Text = "Dias Mensuales:"
        '
        'lblDiasT
        '
        Me.lblDiasT.AutoSize = True
        Me.lblDiasT.Location = New System.Drawing.Point(16, 119)
        Me.lblDiasT.Name = "lblDiasT"
        Me.lblDiasT.Size = New System.Drawing.Size(87, 13)
        Me.lblDiasT.TabIndex = 29
        Me.lblDiasT.Text = "Dias Trabajados:"
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
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(901, 73)
        Me._gbCriteriosBusqueda.TabIndex = 24
        Me._gbCriteriosBusqueda.TabStop = False
        Me._gbCriteriosBusqueda.Text = "Criterios de Busqueda"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(790, 31)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(79, 23)
        Me._btnGenerar.TabIndex = 3
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_cmbFechaf
        '
        Me._cmbFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbFechaf.Location = New System.Drawing.Point(515, 31)
        Me._cmbFechaf.Name = "_cmbFechaf"
        Me._cmbFechaf.Size = New System.Drawing.Size(259, 23)
        Me._cmbFechaf.TabIndex = 2
        '
        '_cmbFechai
        '
        Me._cmbFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmbFechai.Location = New System.Drawing.Point(138, 31)
        Me._cmbFechai.Name = "_cmbFechai"
        Me._cmbFechai.Size = New System.Drawing.Size(261, 23)
        Me._cmbFechai.TabIndex = 1
        '
        '_lblFechaf
        '
        Me._lblFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaf.AutoSize = True
        Me._lblFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaf.Location = New System.Drawing.Point(412, 34)
        Me._lblFechaf.Name = "_lblFechaf"
        Me._lblFechaf.Size = New System.Drawing.Size(97, 17)
        Me._lblFechaf.TabIndex = 1
        Me._lblFechaf.Text = "Fecha Final:"
        '
        '_lblFechai
        '
        Me._lblFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechai.AutoSize = True
        Me._lblFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechai.Location = New System.Drawing.Point(30, 34)
        Me._lblFechai.Name = "_lblFechai"
        Me._lblFechai.Size = New System.Drawing.Size(104, 17)
        Me._lblFechai.TabIndex = 0
        Me._lblFechai.Text = "Fecha Inicial:"
        '
        '_PResumen
        '
        Me._PResumen.Controls.Add(Me._gridResumen)
        Me._PResumen.Location = New System.Drawing.Point(4, 22)
        Me._PResumen.Name = "_PResumen"
        Me._PResumen.Padding = New System.Windows.Forms.Padding(3)
        Me._PResumen.Size = New System.Drawing.Size(255, 92)
        Me._PResumen.TabIndex = 2
        Me._PResumen.Text = "Resumen General"
        Me._PResumen.UseVisualStyleBackColor = True
        '
        '_gridResumen
        '
        Me._gridResumen.AllowUserToAddRows = False
        Me._gridResumen.AllowUserToDeleteRows = False
        Me._gridResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridResumen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._gridResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridResumen.Location = New System.Drawing.Point(3, 3)
        Me._gridResumen.Name = "_gridResumen"
        Me._gridResumen.ReadOnly = True
        Me._gridResumen.Size = New System.Drawing.Size(249, 86)
        Me._gridResumen.TabIndex = 37
        '
        'SPS
        '
        Me.SPS.Controls.Add(Me._gridcajasSPS)
        Me.SPS.Location = New System.Drawing.Point(4, 22)
        Me.SPS.Name = "SPS"
        Me.SPS.Padding = New System.Windows.Forms.Padding(3)
        Me.SPS.Size = New System.Drawing.Size(255, 92)
        Me.SPS.TabIndex = 1
        Me.SPS.Text = "San Pedro Sula"
        Me.SPS.UseVisualStyleBackColor = True
        '
        '_gridcajasSPS
        '
        Me._gridcajasSPS.AllowUserToAddRows = False
        Me._gridcajasSPS.AllowUserToDeleteRows = False
        Me._gridcajasSPS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridcajasSPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridcajasSPS.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridcajasSPS.Location = New System.Drawing.Point(3, 3)
        Me._gridcajasSPS.Name = "_gridcajasSPS"
        Me._gridcajasSPS.ReadOnly = True
        Me._gridcajasSPS.Size = New System.Drawing.Size(249, 86)
        Me._gridcajasSPS.TabIndex = 11
        '
        'SRC
        '
        Me.SRC.Controls.Add(Me._gridJC1)
        Me.SRC.Controls.Add(Me.Imagen)
        Me.SRC.Controls.Add(Me._gridJC3)
        Me.SRC.Controls.Add(Me._gridcajasSRC)
        Me.SRC.Controls.Add(Me._gridJC2)
        Me.SRC.Location = New System.Drawing.Point(4, 22)
        Me.SRC.Name = "SRC"
        Me.SRC.Padding = New System.Windows.Forms.Padding(3)
        Me.SRC.Size = New System.Drawing.Size(255, 92)
        Me.SRC.TabIndex = 0
        Me.SRC.Text = "Santa Rosa"
        Me.SRC.UseVisualStyleBackColor = True
        '
        '_gridJC1
        '
        Me._gridJC1.AllowUserToAddRows = False
        Me._gridJC1.AllowUserToDeleteRows = False
        Me._gridJC1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._gridJC1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridJC1.Location = New System.Drawing.Point(806, 384)
        Me._gridJC1.Name = "_gridJC1"
        Me._gridJC1.ReadOnly = True
        Me._gridJC1.Size = New System.Drawing.Size(16, 14)
        Me._gridJC1.TabIndex = 37
        Me._gridJC1.Visible = False
        '
        '_gridJC3
        '
        Me._gridJC3.AllowUserToAddRows = False
        Me._gridJC3.AllowUserToDeleteRows = False
        Me._gridJC3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._gridJC3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridJC3.Location = New System.Drawing.Point(828, 384)
        Me._gridJC3.Name = "_gridJC3"
        Me._gridJC3.ReadOnly = True
        Me._gridJC3.Size = New System.Drawing.Size(16, 14)
        Me._gridJC3.TabIndex = 39
        Me._gridJC3.Visible = False
        '
        '_gridcajasSRC
        '
        Me._gridcajasSRC.AllowUserToAddRows = False
        Me._gridcajasSRC.AllowUserToDeleteRows = False
        Me._gridcajasSRC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridcajasSRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridcajasSRC.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridcajasSRC.Location = New System.Drawing.Point(3, 3)
        Me._gridcajasSRC.Name = "_gridcajasSRC"
        Me._gridcajasSRC.ReadOnly = True
        Me._gridcajasSRC.Size = New System.Drawing.Size(249, 86)
        Me._gridcajasSRC.TabIndex = 11
        '
        '_gridJC2
        '
        Me._gridJC2.AllowUserToAddRows = False
        Me._gridJC2.AllowUserToDeleteRows = False
        Me._gridJC2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._gridJC2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridJC2.Location = New System.Drawing.Point(850, 384)
        Me._gridJC2.Name = "_gridJC2"
        Me._gridJC2.ReadOnly = True
        Me._gridJC2.Size = New System.Drawing.Size(12, 14)
        Me._gridJC2.TabIndex = 38
        Me._gridJC2.Visible = False
        '
        'Pestañas
        '
        Me.Pestañas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pestañas.Controls.Add(Me.SRC)
        Me.Pestañas.Controls.Add(Me.SPS)
        Me.Pestañas.Controls.Add(Me._PResumen)
        Me.Pestañas.Location = New System.Drawing.Point(652, 114)
        Me.Pestañas.Name = "Pestañas"
        Me.Pestañas.SelectedIndex = 0
        Me.Pestañas.Size = New System.Drawing.Size(263, 118)
        Me.Pestañas.TabIndex = 28
        Me.Pestañas.Visible = False
        '
        '_gridFinal
        '
        Me._gridFinal.AllowUserToAddRows = False
        Me._gridFinal.AllowUserToDeleteRows = False
        Me._gridFinal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gridFinal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridFinal.Location = New System.Drawing.Point(12, 143)
        Me._gridFinal.Name = "_gridFinal"
        Me._gridFinal.ReadOnly = True
        Me._gridFinal.Size = New System.Drawing.Size(901, 518)
        Me._gridFinal.TabIndex = 38
        '
        'Cajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 673)
        Me.Controls.Add(Me._gridFinal)
        Me.Controls.Add(Me.Porcentaje)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DiasR)
        Me.Controls.Add(Me.DiasM)
        Me.Controls.Add(Me.DiasT)
        Me.Controls.Add(Me.lblDiasRestantes)
        Me.Controls.Add(Me.lblDiasM)
        Me.Controls.Add(Me.lblDiasT)
        Me.Controls.Add(Me.Pestañas)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Cajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cajas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        Me._PResumen.ResumeLayout(False)
        CType(Me._gridResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SPS.ResumeLayout(False)
        CType(Me._gridcajasSPS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SRC.ResumeLayout(False)
        CType(Me._gridJC1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridJC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridcajasSRC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridJC2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pestañas.ResumeLayout(False)
        CType(Me._gridFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents Porcentaje As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DiasR As System.Windows.Forms.Label
    Friend WithEvents DiasM As System.Windows.Forms.Label
    Friend WithEvents DiasT As System.Windows.Forms.Label
    Friend WithEvents lblDiasRestantes As System.Windows.Forms.Label
    Friend WithEvents lblDiasM As System.Windows.Forms.Label
    Friend WithEvents lblDiasT As System.Windows.Forms.Label
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _cmbFechaf As System.Windows.Forms.DateTimePicker
    Friend WithEvents _cmbFechai As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechaf As System.Windows.Forms.Label
    Friend WithEvents _lblFechai As System.Windows.Forms.Label
    Friend WithEvents _PResumen As System.Windows.Forms.TabPage
    Friend WithEvents SPS As System.Windows.Forms.TabPage
    Friend WithEvents _gridcajasSPS As System.Windows.Forms.DataGridView
    Friend WithEvents SRC As System.Windows.Forms.TabPage
    Friend WithEvents _gridcajasSRC As System.Windows.Forms.DataGridView
    Friend WithEvents Pestañas As System.Windows.Forms.TabControl
    Friend WithEvents _gridJC1 As System.Windows.Forms.DataGridView
    Friend WithEvents _gridJC3 As System.Windows.Forms.DataGridView
    Friend WithEvents _gridJC2 As System.Windows.Forms.DataGridView
    Friend WithEvents _gridResumen As System.Windows.Forms.DataGridView
    Friend WithEvents _gridFinal As System.Windows.Forms.DataGridView
End Class
