<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Resumen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Resumen))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._MnuBuscar = New System.Windows.Forms.ToolStripDropDownButton
        Me.FechasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MensualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SeleccionarFechasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me._cmbSucursal = New System.Windows.Forms.ComboBox
        Me.lblSucursal = New System.Windows.Forms.Label
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.grpFechas = New System.Windows.Forms.GroupBox
        Me._cmbFechaf = New System.Windows.Forms.DateTimePicker
        Me._lblFechai = New System.Windows.Forms.Label
        Me._lblFechaf = New System.Windows.Forms.Label
        Me._cmbFechai = New System.Windows.Forms.DateTimePicker
        Me.grpMensual = New System.Windows.Forms.GroupBox
        Me._txtAño = New System.Windows.Forms.NumericUpDown
        Me.cmbMes = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._gridResumen = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me._gbCriteriosBusqueda.SuspendLayout()
        Me.grpFechas.SuspendLayout()
        Me.grpMensual.SuspendLayout()
        CType(Me._txtAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1, Me._MnuBuscar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1159, 39)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '_Archivo
        '
        Me._Archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarToolStripMenuItem, Me.CerrarToolStripMenuItem})
        Me._Archivo.Image = Global.Disar.My.Resources.Resources.Opciones
        Me._Archivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Archivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._Archivo.Name = "_Archivo"
        Me._Archivo.Size = New System.Drawing.Size(100, 36)
        Me._Archivo.Text = "Acciones"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Excel_32
        Me.ExportarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.ExportarToolStripMenuItem.Text = "Exportar a Texto"
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.CerrarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        '_MnuBuscar
        '
        Me._MnuBuscar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FechasToolStripMenuItem})
        Me._MnuBuscar.Image = Global.Disar.My.Resources.Resources.lupa
        Me._MnuBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._MnuBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._MnuBuscar.Name = "_MnuBuscar"
        Me._MnuBuscar.Size = New System.Drawing.Size(84, 36)
        Me._MnuBuscar.Text = "Filtros"
        '
        'FechasToolStripMenuItem
        '
        Me.FechasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MensualToolStripMenuItem, Me.SeleccionarFechasToolStripMenuItem})
        Me.FechasToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Mensual
        Me.FechasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FechasToolStripMenuItem.Name = "FechasToolStripMenuItem"
        Me.FechasToolStripMenuItem.Size = New System.Drawing.Size(126, 38)
        Me.FechasToolStripMenuItem.Text = "Fechas"
        '
        'MensualToolStripMenuItem
        '
        Me.MensualToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Calendar_icon
        Me.MensualToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MensualToolStripMenuItem.Name = "MensualToolStripMenuItem"
        Me.MensualToolStripMenuItem.Size = New System.Drawing.Size(189, 38)
        Me.MensualToolStripMenuItem.Text = "Mensual"
        '
        'SeleccionarFechasToolStripMenuItem
        '
        Me.SeleccionarFechasToolStripMenuItem.Image = Global.Disar.My.Resources.Resources._3D_Calendar_red_32
        Me.SeleccionarFechasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SeleccionarFechasToolStripMenuItem.Name = "SeleccionarFechasToolStripMenuItem"
        Me.SeleccionarFechasToolStripMenuItem.Size = New System.Drawing.Size(189, 38)
        Me.SeleccionarFechasToolStripMenuItem.Text = "Seleccionar Fechas"
        '
        '_gbCriteriosBusqueda
        '
        Me._gbCriteriosBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbSucursal)
        Me._gbCriteriosBusqueda.Controls.Add(Me.lblSucursal)
        Me._gbCriteriosBusqueda.Controls.Add(Me._btnGenerar)
        Me._gbCriteriosBusqueda.Controls.Add(Me.grpFechas)
        Me._gbCriteriosBusqueda.Controls.Add(Me.grpMensual)
        Me._gbCriteriosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbCriteriosBusqueda.Location = New System.Drawing.Point(12, 42)
        Me._gbCriteriosBusqueda.Name = "_gbCriteriosBusqueda"
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(1135, 82)
        Me._gbCriteriosBusqueda.TabIndex = 9
        Me._gbCriteriosBusqueda.TabStop = False
        '
        '_cmbSucursal
        '
        Me._cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbSucursal.FormattingEnabled = True
        Me._cmbSucursal.Items.AddRange(New Object() {"Santa Rosa Copan", "San Pedro Sula", "Saba", "Tegucigalpa", "Ambas"})
        Me._cmbSucursal.Location = New System.Drawing.Point(94, 32)
        Me._cmbSucursal.Name = "_cmbSucursal"
        Me._cmbSucursal.Size = New System.Drawing.Size(153, 24)
        Me._cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSucursal.Location = New System.Drawing.Point(12, 36)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(76, 17)
        Me.lblSucursal.TabIndex = 7
        Me.lblSucursal.Text = "Sucursal:"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(1031, 31)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(87, 25)
        Me._btnGenerar.TabIndex = 6
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'grpFechas
        '
        Me.grpFechas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFechas.Controls.Add(Me._cmbFechaf)
        Me.grpFechas.Controls.Add(Me._lblFechai)
        Me.grpFechas.Controls.Add(Me._lblFechaf)
        Me.grpFechas.Controls.Add(Me._cmbFechai)
        Me.grpFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFechas.Location = New System.Drawing.Point(253, 17)
        Me.grpFechas.Name = "grpFechas"
        Me.grpFechas.Size = New System.Drawing.Size(772, 46)
        Me.grpFechas.TabIndex = 14
        Me.grpFechas.TabStop = False
        Me.grpFechas.Visible = False
        '
        '_cmbFechaf
        '
        Me._cmbFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechaf.Location = New System.Drawing.Point(483, 16)
        Me._cmbFechaf.Name = "_cmbFechaf"
        Me._cmbFechaf.Size = New System.Drawing.Size(272, 23)
        Me._cmbFechaf.TabIndex = 5
        '
        '_lblFechai
        '
        Me._lblFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechai.AutoSize = True
        Me._lblFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechai.Location = New System.Drawing.Point(1, 16)
        Me._lblFechai.Name = "_lblFechai"
        Me._lblFechai.Size = New System.Drawing.Size(104, 17)
        Me._lblFechai.TabIndex = 0
        Me._lblFechai.Text = "Fecha Inicial:"
        '
        '_lblFechaf
        '
        Me._lblFechaf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaf.AutoSize = True
        Me._lblFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaf.Location = New System.Drawing.Point(386, 16)
        Me._lblFechaf.Name = "_lblFechaf"
        Me._lblFechaf.Size = New System.Drawing.Size(97, 17)
        Me._lblFechaf.TabIndex = 1
        Me._lblFechaf.Text = "Fecha Final:"
        '
        '_cmbFechai
        '
        Me._cmbFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechai.Location = New System.Drawing.Point(106, 13)
        Me._cmbFechai.Name = "_cmbFechai"
        Me._cmbFechai.Size = New System.Drawing.Size(277, 23)
        Me._cmbFechai.TabIndex = 4
        '
        'grpMensual
        '
        Me.grpMensual.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMensual.Controls.Add(Me._txtAño)
        Me.grpMensual.Controls.Add(Me.cmbMes)
        Me.grpMensual.Controls.Add(Me.Label2)
        Me.grpMensual.Controls.Add(Me.Label1)
        Me.grpMensual.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMensual.Location = New System.Drawing.Point(253, 18)
        Me.grpMensual.Name = "grpMensual"
        Me.grpMensual.Size = New System.Drawing.Size(772, 46)
        Me.grpMensual.TabIndex = 13
        Me.grpMensual.TabStop = False
        '
        '_txtAño
        '
        Me._txtAño.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._txtAño.Location = New System.Drawing.Point(420, 15)
        Me._txtAño.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me._txtAño.Name = "_txtAño"
        Me._txtAño.Size = New System.Drawing.Size(95, 23)
        Me._txtAño.TabIndex = 3
        Me._txtAño.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me._txtAño.ThousandsSeparator = True
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cmbMes.Location = New System.Drawing.Point(247, 15)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(117, 24)
        Me.cmbMes.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(373, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Año:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(199, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Mes:"
        '
        '_gridResumen
        '
        Me._gridResumen.AllowUserToAddRows = False
        Me._gridResumen.AllowUserToDeleteRows = False
        Me._gridResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gridResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridResumen.Location = New System.Drawing.Point(13, 130)
        Me._gridResumen.Name = "_gridResumen"
        Me._gridResumen.ReadOnly = True
        Me._gridResumen.Size = New System.Drawing.Size(1134, 540)
        Me._gridResumen.TabIndex = 10
        '
        'Resumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1159, 682)
        Me.Controls.Add(Me._gridResumen)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Resumen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resumen"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        Me.grpFechas.ResumeLayout(False)
        Me.grpFechas.PerformLayout()
        Me.grpMensual.ResumeLayout(False)
        Me.grpMensual.PerformLayout()
        CType(Me._txtAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _cmbFechai As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechai As System.Windows.Forms.Label
    Friend WithEvents _cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents _cmbFechaf As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechaf As System.Windows.Forms.Label
    Friend WithEvents _gridResumen As System.Windows.Forms.DataGridView
    Friend WithEvents ExportarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents _txtAño As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _MnuBuscar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents FechasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MensualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeleccionarFechasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpMensual As System.Windows.Forms.GroupBox
    Friend WithEvents grpFechas As System.Windows.Forms.GroupBox
End Class
