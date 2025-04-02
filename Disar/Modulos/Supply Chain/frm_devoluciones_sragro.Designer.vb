<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_devoluciones_sragro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_devoluciones_sragro))
        Me.porcentajeefec = New System.Windows.Forms.Label
        Me.efectividad = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.totaldevuelto = New System.Windows.Forms.Label
        Me.TotalFacturado = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblFacturado = New System.Windows.Forms.Label
        Me._gridAdicionales = New System.Windows.Forms.DataGridView
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox
        Me.lblsucursal = New System.Windows.Forms.Label
        Me.cmbsucursal = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblFechaInicio = New System.Windows.Forms.Label
        Me.f2 = New System.Windows.Forms.DateTimePicker
        Me.f1 = New System.Windows.Forms.DateTimePicker
        Me.imagen2 = New System.Windows.Forms.PictureBox
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._griddevoluciones = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        CType(Me._gridAdicionales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._grpCBuquedas.SuspendLayout()
        CType(Me.imagen2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._griddevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'porcentajeefec
        '
        Me.porcentajeefec.AutoSize = True
        Me.porcentajeefec.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.porcentajeefec.Location = New System.Drawing.Point(536, 150)
        Me.porcentajeefec.Name = "porcentajeefec"
        Me.porcentajeefec.Size = New System.Drawing.Size(28, 17)
        Me.porcentajeefec.TabIndex = 38
        Me.porcentajeefec.Text = "    "
        '
        'efectividad
        '
        Me.efectividad.AutoSize = True
        Me.efectividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.efectividad.Location = New System.Drawing.Point(536, 132)
        Me.efectividad.Name = "efectividad"
        Me.efectividad.Size = New System.Drawing.Size(28, 17)
        Me.efectividad.TabIndex = 39
        Me.efectividad.Text = "    "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(423, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 17)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "% Efectividad:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(441, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 17)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Efectividad:"
        '
        'totaldevuelto
        '
        Me.totaldevuelto.AutoSize = True
        Me.totaldevuelto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totaldevuelto.Location = New System.Drawing.Point(197, 151)
        Me.totaldevuelto.Name = "totaldevuelto"
        Me.totaldevuelto.Size = New System.Drawing.Size(28, 17)
        Me.totaldevuelto.TabIndex = 34
        Me.totaldevuelto.Text = "    "
        '
        'TotalFacturado
        '
        Me.TotalFacturado.AutoSize = True
        Me.TotalFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalFacturado.Location = New System.Drawing.Point(197, 133)
        Me.TotalFacturado.Name = "TotalFacturado"
        Me.TotalFacturado.Size = New System.Drawing.Size(28, 17)
        Me.TotalFacturado.TabIndex = 35
        Me.TotalFacturado.Text = "    "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 17)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Total Monto Devuelto:"
        '
        'lblFacturado
        '
        Me.lblFacturado.AutoSize = True
        Me.lblFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacturado.Location = New System.Drawing.Point(14, 131)
        Me.lblFacturado.Name = "lblFacturado"
        Me.lblFacturado.Size = New System.Drawing.Size(177, 17)
        Me.lblFacturado.TabIndex = 33
        Me.lblFacturado.Text = "Total Monto Facturado:"
        '
        '_gridAdicionales
        '
        Me._gridAdicionales.AllowUserToAddRows = False
        Me._gridAdicionales.AllowUserToDeleteRows = False
        Me._gridAdicionales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gridAdicionales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me._gridAdicionales.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._gridAdicionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridAdicionales.Location = New System.Drawing.Point(870, 134)
        Me._gridAdicionales.Name = "_gridAdicionales"
        Me._gridAdicionales.ReadOnly = True
        Me._gridAdicionales.Size = New System.Drawing.Size(49, 106)
        Me._gridAdicionales.TabIndex = 31
        Me._gridAdicionales.Visible = False
        '
        '_grpCBuquedas
        '
        Me._grpCBuquedas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._grpCBuquedas.Controls.Add(Me.lblsucursal)
        Me._grpCBuquedas.Controls.Add(Me.cmbsucursal)
        Me._grpCBuquedas.Controls.Add(Me.Label1)
        Me._grpCBuquedas.Controls.Add(Me._lblFechaInicio)
        Me._grpCBuquedas.Controls.Add(Me.f2)
        Me._grpCBuquedas.Controls.Add(Me.f1)
        Me._grpCBuquedas.Controls.Add(Me.imagen2)
        Me._grpCBuquedas.Controls.Add(Me.Imagen)
        Me._grpCBuquedas.Controls.Add(Me._btnGenerar)
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 42)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(907, 88)
        Me._grpCBuquedas.TabIndex = 30
        Me._grpCBuquedas.TabStop = False
        Me._grpCBuquedas.Text = "Criterios de Busqueda"
        '
        'lblsucursal
        '
        Me.lblsucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblsucursal.AutoSize = True
        Me.lblsucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsucursal.Location = New System.Drawing.Point(141, 26)
        Me.lblsucursal.Name = "lblsucursal"
        Me.lblsucursal.Size = New System.Drawing.Size(58, 15)
        Me.lblsucursal.TabIndex = 24
        Me.lblsucursal.Text = "Sucursal:"
        '
        'cmbsucursal
        '
        Me.cmbsucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbsucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsucursal.FormattingEnabled = True
        Me.cmbsucursal.Location = New System.Drawing.Point(201, 23)
        Me.cmbsucursal.Name = "cmbsucursal"
        Me.cmbsucursal.Size = New System.Drawing.Size(273, 23)
        Me.cmbsucursal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(447, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Fin:"
        '
        '_lblFechaInicio
        '
        Me._lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaInicio.AutoSize = True
        Me._lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaInicio.Location = New System.Drawing.Point(159, 55)
        Me._lblFechaInicio.Name = "_lblFechaInicio"
        Me._lblFechaInicio.Size = New System.Drawing.Size(39, 15)
        Me._lblFechaInicio.TabIndex = 20
        Me._lblFechaInicio.Text = "Inicio:"
        '
        'f2
        '
        Me.f2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.f2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f2.Location = New System.Drawing.Point(480, 54)
        Me.f2.Name = "f2"
        Me.f2.Size = New System.Drawing.Size(241, 21)
        Me.f2.TabIndex = 3
        '
        'f1
        '
        Me.f1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.f1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f1.Location = New System.Drawing.Point(203, 54)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(244, 21)
        Me.f1.TabIndex = 2
        '
        'imagen2
        '
        Me.imagen2.Image = Global.Disar.My.Resources.Resources.equipoo
        Me.imagen2.Location = New System.Drawing.Point(888, 39)
        Me.imagen2.Name = "imagen2"
        Me.imagen2.Size = New System.Drawing.Size(23, 20)
        Me.imagen2.TabIndex = 11
        Me.imagen2.TabStop = False
        Me.imagen2.Visible = False
        '
        'Imagen
        '
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.SR_AGRO_LOGO
        Me.Imagen.Location = New System.Drawing.Point(859, 39)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(23, 20)
        Me.Imagen.TabIndex = 11
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(641, 23)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(80, 25)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_griddevoluciones
        '
        Me._griddevoluciones.AllowUserToAddRows = False
        Me._griddevoluciones.AllowUserToDeleteRows = False
        Me._griddevoluciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._griddevoluciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._griddevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._griddevoluciones.Location = New System.Drawing.Point(12, 177)
        Me._griddevoluciones.Name = "_griddevoluciones"
        Me._griddevoluciones.ReadOnly = True
        Me._griddevoluciones.Size = New System.Drawing.Size(907, 435)
        Me._griddevoluciones.TabIndex = 29
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(933, 39)
        Me.ToolStrip1.TabIndex = 28
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
        'frm_devoluciones_sragro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 621)
        Me.Controls.Add(Me.porcentajeefec)
        Me.Controls.Add(Me.efectividad)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.totaldevuelto)
        Me.Controls.Add(Me.TotalFacturado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFacturado)
        Me.Controls.Add(Me._gridAdicionales)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me._griddevoluciones)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_devoluciones_sragro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devoluciones SR Agro"
        CType(Me._gridAdicionales, System.ComponentModel.ISupportInitialize).EndInit()
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        CType(Me.imagen2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._griddevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents porcentajeefec As System.Windows.Forms.Label
    Friend WithEvents efectividad As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents totaldevuelto As System.Windows.Forms.Label
    Friend WithEvents TotalFacturado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFacturado As System.Windows.Forms.Label
    Friend WithEvents _gridAdicionales As System.Windows.Forms.DataGridView
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents lblsucursal As System.Windows.Forms.Label
    Friend WithEvents cmbsucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents f2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents f1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents imagen2 As System.Windows.Forms.PictureBox
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _griddevoluciones As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
