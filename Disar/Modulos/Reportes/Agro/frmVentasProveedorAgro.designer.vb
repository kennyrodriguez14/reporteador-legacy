<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentasProveedorAgro
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
        Me._lblFechaInicio = New System.Windows.Forms.Label
        Me.cmbFechaInicial = New System.Windows.Forms.DateTimePicker
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Pestañas = New System.Windows.Forms.TabControl
        Me._AGROSRC = New System.Windows.Forms.TabPage
        Me._gridAgroSrc = New System.Windows.Forms.DataGridView
        Me._AGROGRACIAS = New System.Windows.Forms.TabPage
        Me._gridAgroGracias = New System.Windows.Forms.DataGridView
        Me.__AGROSANJUAN = New System.Windows.Forms.TabPage
        Me._gridAgroSanjuan = New System.Windows.Forms.DataGridView
        Me._AGROSANTABARBARA = New System.Windows.Forms.TabPage
        Me._GridAgroSantaB = New System.Windows.Forms.DataGridView
        Me._AGROCEDE = New System.Windows.Forms.TabPage
        Me._gridAgroCede = New System.Windows.Forms.DataGridView
        Me._MOVIL40 = New System.Windows.Forms.TabPage
        Me._gridMovil40 = New System.Windows.Forms.DataGridView
        Me._MOVIL41 = New System.Windows.Forms.TabPage
        Me._gridMovil41 = New System.Windows.Forms.DataGridView
        Me._MOVIL07 = New System.Windows.Forms.TabPage
        Me._gridMovil07 = New System.Windows.Forms.DataGridView
        Me.RESUMEN = New System.Windows.Forms.TabPage
        Me._gridResumen = New System.Windows.Forms.DataGridView
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me._gridResumenCierre = New System.Windows.Forms.DataGridView
        Me._grpCBuquedas.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Pestañas.SuspendLayout()
        Me._AGROSRC.SuspendLayout()
        CType(Me._gridAgroSrc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._AGROGRACIAS.SuspendLayout()
        CType(Me._gridAgroGracias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.__AGROSANJUAN.SuspendLayout()
        CType(Me._gridAgroSanjuan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._AGROSANTABARBARA.SuspendLayout()
        CType(Me._GridAgroSantaB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._AGROCEDE.SuspendLayout()
        CType(Me._gridAgroCede, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._MOVIL40.SuspendLayout()
        CType(Me._gridMovil40, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._MOVIL41.SuspendLayout()
        CType(Me._gridMovil41, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._MOVIL07.SuspendLayout()
        CType(Me._gridMovil07, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RESUMEN.SuspendLayout()
        CType(Me._gridResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me._gridResumenCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_lblFechaInicio
        '
        Me._lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaInicio.AutoSize = True
        Me._lblFechaInicio.Location = New System.Drawing.Point(232, 23)
        Me._lblFechaInicio.Name = "_lblFechaInicio"
        Me._lblFechaInicio.Size = New System.Drawing.Size(135, 20)
        Me._lblFechaInicio.TabIndex = 0
        Me._lblFechaInicio.Text = "Fecha de Ventas:"
        '
        'cmbFechaInicial
        '
        Me.cmbFechaInicial.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbFechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFechaInicial.Location = New System.Drawing.Point(373, 20)
        Me.cmbFechaInicial.Name = "cmbFechaInicial"
        Me.cmbFechaInicial.Size = New System.Drawing.Size(301, 26)
        Me.cmbFechaInicial.TabIndex = 1
        '
        '_grpCBuquedas
        '
        Me._grpCBuquedas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._grpCBuquedas.Controls.Add(Me.Imagen)
        Me._grpCBuquedas.Controls.Add(Me._btnGenerar)
        Me._grpCBuquedas.Controls.Add(Me._lblFechaInicio)
        Me._grpCBuquedas.Controls.Add(Me.cmbFechaInicial)
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 48)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(972, 62)
        Me._grpCBuquedas.TabIndex = 12
        Me._grpCBuquedas.TabStop = False
        Me._grpCBuquedas.Text = "Criterios de Busqueda"
        '
        'Imagen
        '
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.Disar_Logo_26
        Me.Imagen.Location = New System.Drawing.Point(942, 36)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(23, 20)
        Me.Imagen.TabIndex = 11
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Location = New System.Drawing.Point(753, 19)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(96, 28)
        Me._btnGenerar.TabIndex = 2
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1004, 39)
        Me.ToolStrip1.TabIndex = 11
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
        'Pestañas
        '
        Me.Pestañas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pestañas.Controls.Add(Me._AGROSRC)
        Me.Pestañas.Controls.Add(Me._AGROGRACIAS)
        Me.Pestañas.Controls.Add(Me.__AGROSANJUAN)
        Me.Pestañas.Controls.Add(Me._AGROSANTABARBARA)
        Me.Pestañas.Controls.Add(Me._AGROCEDE)
        Me.Pestañas.Controls.Add(Me._MOVIL40)
        Me.Pestañas.Controls.Add(Me._MOVIL41)
        Me.Pestañas.Controls.Add(Me._MOVIL07)
        Me.Pestañas.Controls.Add(Me.RESUMEN)
        Me.Pestañas.Controls.Add(Me.TabPage1)
        Me.Pestañas.Location = New System.Drawing.Point(16, 119)
        Me.Pestañas.Name = "Pestañas"
        Me.Pestañas.SelectedIndex = 0
        Me.Pestañas.Size = New System.Drawing.Size(972, 476)
        Me.Pestañas.TabIndex = 14
        '
        '_AGROSRC
        '
        Me._AGROSRC.Controls.Add(Me._gridAgroSrc)
        Me._AGROSRC.Location = New System.Drawing.Point(4, 22)
        Me._AGROSRC.Name = "_AGROSRC"
        Me._AGROSRC.Padding = New System.Windows.Forms.Padding(3)
        Me._AGROSRC.Size = New System.Drawing.Size(964, 450)
        Me._AGROSRC.TabIndex = 0
        Me._AGROSRC.Text = "AGRO-SRC"
        Me._AGROSRC.UseVisualStyleBackColor = True
        '
        '_gridAgroSrc
        '
        Me._gridAgroSrc.AllowUserToAddRows = False
        Me._gridAgroSrc.AllowUserToDeleteRows = False
        Me._gridAgroSrc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridAgroSrc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridAgroSrc.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridAgroSrc.Location = New System.Drawing.Point(3, 3)
        Me._gridAgroSrc.Name = "_gridAgroSrc"
        Me._gridAgroSrc.ReadOnly = True
        Me._gridAgroSrc.Size = New System.Drawing.Size(958, 444)
        Me._gridAgroSrc.TabIndex = 10
        '
        '_AGROGRACIAS
        '
        Me._AGROGRACIAS.Controls.Add(Me._gridAgroGracias)
        Me._AGROGRACIAS.Location = New System.Drawing.Point(4, 22)
        Me._AGROGRACIAS.Name = "_AGROGRACIAS"
        Me._AGROGRACIAS.Padding = New System.Windows.Forms.Padding(3)
        Me._AGROGRACIAS.Size = New System.Drawing.Size(964, 450)
        Me._AGROGRACIAS.TabIndex = 1
        Me._AGROGRACIAS.Text = "AGRO-GRACIAS"
        Me._AGROGRACIAS.UseVisualStyleBackColor = True
        '
        '_gridAgroGracias
        '
        Me._gridAgroGracias.AllowUserToAddRows = False
        Me._gridAgroGracias.AllowUserToDeleteRows = False
        Me._gridAgroGracias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridAgroGracias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridAgroGracias.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridAgroGracias.Location = New System.Drawing.Point(3, 3)
        Me._gridAgroGracias.Name = "_gridAgroGracias"
        Me._gridAgroGracias.ReadOnly = True
        Me._gridAgroGracias.Size = New System.Drawing.Size(958, 444)
        Me._gridAgroGracias.TabIndex = 11
        '
        '__AGROSANJUAN
        '
        Me.__AGROSANJUAN.Controls.Add(Me._gridAgroSanjuan)
        Me.__AGROSANJUAN.Location = New System.Drawing.Point(4, 22)
        Me.__AGROSANJUAN.Name = "__AGROSANJUAN"
        Me.__AGROSANJUAN.Size = New System.Drawing.Size(964, 450)
        Me.__AGROSANJUAN.TabIndex = 8
        Me.__AGROSANJUAN.Text = "AGRO-SAN JUAN"
        Me.__AGROSANJUAN.UseVisualStyleBackColor = True
        '
        '_gridAgroSanjuan
        '
        Me._gridAgroSanjuan.AllowUserToAddRows = False
        Me._gridAgroSanjuan.AllowUserToDeleteRows = False
        Me._gridAgroSanjuan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridAgroSanjuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridAgroSanjuan.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridAgroSanjuan.Location = New System.Drawing.Point(0, 0)
        Me._gridAgroSanjuan.Name = "_gridAgroSanjuan"
        Me._gridAgroSanjuan.ReadOnly = True
        Me._gridAgroSanjuan.Size = New System.Drawing.Size(964, 450)
        Me._gridAgroSanjuan.TabIndex = 12
        '
        '_AGROSANTABARBARA
        '
        Me._AGROSANTABARBARA.Controls.Add(Me._GridAgroSantaB)
        Me._AGROSANTABARBARA.Location = New System.Drawing.Point(4, 22)
        Me._AGROSANTABARBARA.Name = "_AGROSANTABARBARA"
        Me._AGROSANTABARBARA.Size = New System.Drawing.Size(964, 450)
        Me._AGROSANTABARBARA.TabIndex = 9
        Me._AGROSANTABARBARA.Text = "AGRO-SANTA BÁRBARA"
        Me._AGROSANTABARBARA.UseVisualStyleBackColor = True
        '
        '_GridAgroSantaB
        '
        Me._GridAgroSantaB.AllowUserToAddRows = False
        Me._GridAgroSantaB.AllowUserToDeleteRows = False
        Me._GridAgroSantaB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._GridAgroSantaB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridAgroSantaB.Dock = System.Windows.Forms.DockStyle.Fill
        Me._GridAgroSantaB.Location = New System.Drawing.Point(0, 0)
        Me._GridAgroSantaB.Name = "_GridAgroSantaB"
        Me._GridAgroSantaB.ReadOnly = True
        Me._GridAgroSantaB.Size = New System.Drawing.Size(964, 450)
        Me._GridAgroSantaB.TabIndex = 13
        '
        '_AGROCEDE
        '
        Me._AGROCEDE.Controls.Add(Me._gridAgroCede)
        Me._AGROCEDE.Location = New System.Drawing.Point(4, 22)
        Me._AGROCEDE.Name = "_AGROCEDE"
        Me._AGROCEDE.Padding = New System.Windows.Forms.Padding(3)
        Me._AGROCEDE.Size = New System.Drawing.Size(964, 450)
        Me._AGROCEDE.TabIndex = 3
        Me._AGROCEDE.Text = "AGRO-CEDE"
        Me._AGROCEDE.UseVisualStyleBackColor = True
        '
        '_gridAgroCede
        '
        Me._gridAgroCede.AllowUserToAddRows = False
        Me._gridAgroCede.AllowUserToDeleteRows = False
        Me._gridAgroCede.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridAgroCede.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridAgroCede.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridAgroCede.Location = New System.Drawing.Point(3, 3)
        Me._gridAgroCede.Name = "_gridAgroCede"
        Me._gridAgroCede.ReadOnly = True
        Me._gridAgroCede.Size = New System.Drawing.Size(958, 444)
        Me._gridAgroCede.TabIndex = 12
        '
        '_MOVIL40
        '
        Me._MOVIL40.Controls.Add(Me._gridMovil40)
        Me._MOVIL40.Location = New System.Drawing.Point(4, 22)
        Me._MOVIL40.Name = "_MOVIL40"
        Me._MOVIL40.Size = New System.Drawing.Size(964, 450)
        Me._MOVIL40.TabIndex = 4
        Me._MOVIL40.Text = "MOVIL-40"
        Me._MOVIL40.UseVisualStyleBackColor = True
        '
        '_gridMovil40
        '
        Me._gridMovil40.AllowUserToAddRows = False
        Me._gridMovil40.AllowUserToDeleteRows = False
        Me._gridMovil40.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridMovil40.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridMovil40.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridMovil40.Location = New System.Drawing.Point(0, 0)
        Me._gridMovil40.Name = "_gridMovil40"
        Me._gridMovil40.ReadOnly = True
        Me._gridMovil40.Size = New System.Drawing.Size(964, 450)
        Me._gridMovil40.TabIndex = 11
        '
        '_MOVIL41
        '
        Me._MOVIL41.Controls.Add(Me._gridMovil41)
        Me._MOVIL41.Location = New System.Drawing.Point(4, 22)
        Me._MOVIL41.Name = "_MOVIL41"
        Me._MOVIL41.Size = New System.Drawing.Size(964, 450)
        Me._MOVIL41.TabIndex = 5
        Me._MOVIL41.Text = "MOVIL-41"
        Me._MOVIL41.UseVisualStyleBackColor = True
        '
        '_gridMovil41
        '
        Me._gridMovil41.AllowUserToAddRows = False
        Me._gridMovil41.AllowUserToDeleteRows = False
        Me._gridMovil41.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridMovil41.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridMovil41.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridMovil41.Location = New System.Drawing.Point(0, 0)
        Me._gridMovil41.Name = "_gridMovil41"
        Me._gridMovil41.ReadOnly = True
        Me._gridMovil41.Size = New System.Drawing.Size(964, 450)
        Me._gridMovil41.TabIndex = 11
        '
        '_MOVIL07
        '
        Me._MOVIL07.Controls.Add(Me._gridMovil07)
        Me._MOVIL07.Location = New System.Drawing.Point(4, 22)
        Me._MOVIL07.Name = "_MOVIL07"
        Me._MOVIL07.Size = New System.Drawing.Size(964, 450)
        Me._MOVIL07.TabIndex = 6
        Me._MOVIL07.Text = "MOVIL07"
        Me._MOVIL07.UseVisualStyleBackColor = True
        '
        '_gridMovil07
        '
        Me._gridMovil07.AllowUserToAddRows = False
        Me._gridMovil07.AllowUserToDeleteRows = False
        Me._gridMovil07.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridMovil07.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridMovil07.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridMovil07.Location = New System.Drawing.Point(0, 0)
        Me._gridMovil07.Name = "_gridMovil07"
        Me._gridMovil07.ReadOnly = True
        Me._gridMovil07.Size = New System.Drawing.Size(964, 450)
        Me._gridMovil07.TabIndex = 11
        '
        'RESUMEN
        '
        Me.RESUMEN.Controls.Add(Me._gridResumen)
        Me.RESUMEN.Location = New System.Drawing.Point(4, 22)
        Me.RESUMEN.Name = "RESUMEN"
        Me.RESUMEN.Size = New System.Drawing.Size(964, 450)
        Me.RESUMEN.TabIndex = 2
        Me.RESUMEN.Text = "RESUMEN"
        Me.RESUMEN.UseVisualStyleBackColor = True
        '
        '_gridResumen
        '
        Me._gridResumen.AllowUserToAddRows = False
        Me._gridResumen.AllowUserToDeleteRows = False
        Me._gridResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridResumen.Location = New System.Drawing.Point(0, 0)
        Me._gridResumen.Name = "_gridResumen"
        Me._gridResumen.ReadOnly = True
        Me._gridResumen.Size = New System.Drawing.Size(964, 450)
        Me._gridResumen.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me._gridResumenCierre)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(964, 450)
        Me.TabPage1.TabIndex = 7
        Me.TabPage1.Text = "RESUMEN A CIERRE"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        '_gridResumenCierre
        '
        Me._gridResumenCierre.AllowUserToAddRows = False
        Me._gridResumenCierre.AllowUserToDeleteRows = False
        Me._gridResumenCierre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridResumenCierre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridResumenCierre.Dock = System.Windows.Forms.DockStyle.Fill
        Me._gridResumenCierre.Location = New System.Drawing.Point(0, 0)
        Me._gridResumenCierre.Name = "_gridResumenCierre"
        Me._gridResumenCierre.ReadOnly = True
        Me._gridResumenCierre.Size = New System.Drawing.Size(964, 450)
        Me._gridResumenCierre.TabIndex = 0
        '
        'frmVentasProveedorAgro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 598)
        Me.Controls.Add(Me.Pestañas)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmVentasProveedorAgro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas por proveedor SR-AGRO"
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Pestañas.ResumeLayout(False)
        Me._AGROSRC.ResumeLayout(False)
        CType(Me._gridAgroSrc, System.ComponentModel.ISupportInitialize).EndInit()
        Me._AGROGRACIAS.ResumeLayout(False)
        CType(Me._gridAgroGracias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.__AGROSANJUAN.ResumeLayout(False)
        CType(Me._gridAgroSanjuan, System.ComponentModel.ISupportInitialize).EndInit()
        Me._AGROSANTABARBARA.ResumeLayout(False)
        CType(Me._GridAgroSantaB, System.ComponentModel.ISupportInitialize).EndInit()
        Me._AGROCEDE.ResumeLayout(False)
        CType(Me._gridAgroCede, System.ComponentModel.ISupportInitialize).EndInit()
        Me._MOVIL40.ResumeLayout(False)
        CType(Me._gridMovil40, System.ComponentModel.ISupportInitialize).EndInit()
        Me._MOVIL41.ResumeLayout(False)
        CType(Me._gridMovil41, System.ComponentModel.ISupportInitialize).EndInit()
        Me._MOVIL07.ResumeLayout(False)
        CType(Me._gridMovil07, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RESUMEN.ResumeLayout(False)
        CType(Me._gridResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me._gridResumenCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents cmbFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Pestañas As System.Windows.Forms.TabControl
    Friend WithEvents _AGROSRC As System.Windows.Forms.TabPage
    Friend WithEvents _gridAgroSrc As System.Windows.Forms.DataGridView
    Friend WithEvents _AGROGRACIAS As System.Windows.Forms.TabPage
    Friend WithEvents _gridAgroGracias As System.Windows.Forms.DataGridView
    Friend WithEvents __AGROSANJUAN As System.Windows.Forms.TabPage
    Friend WithEvents _gridAgroSanjuan As System.Windows.Forms.DataGridView
    Friend WithEvents _AGROCEDE As System.Windows.Forms.TabPage
    Friend WithEvents _gridAgroCede As System.Windows.Forms.DataGridView
    Friend WithEvents _MOVIL40 As System.Windows.Forms.TabPage
    Friend WithEvents _gridMovil40 As System.Windows.Forms.DataGridView
    Friend WithEvents _MOVIL41 As System.Windows.Forms.TabPage
    Friend WithEvents _gridMovil41 As System.Windows.Forms.DataGridView
    Friend WithEvents _MOVIL07 As System.Windows.Forms.TabPage
    Friend WithEvents _gridMovil07 As System.Windows.Forms.DataGridView
    Friend WithEvents RESUMEN As System.Windows.Forms.TabPage
    Friend WithEvents _gridResumen As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents _gridResumenCierre As System.Windows.Forms.DataGridView
    Friend WithEvents _AGROSANTABARBARA As System.Windows.Forms.TabPage
    Friend WithEvents _GridAgroSantaB As System.Windows.Forms.DataGridView
End Class
