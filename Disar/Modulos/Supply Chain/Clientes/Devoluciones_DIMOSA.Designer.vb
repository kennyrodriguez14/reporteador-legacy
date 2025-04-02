<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Devoluciones_DIMOSA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Devoluciones_DIMOSA))
        Me.lblsucursal = New System.Windows.Forms.Label
        Me.TotalFacturado = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblFacturado = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmbsucursal = New System.Windows.Forms.ComboBox
        Me.totaldevuelto = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.efectividad = New System.Windows.Forms.Label
        Me.porcentajeefec = New System.Windows.Forms.Label
        Me._lblFechaInicio = New System.Windows.Forms.Label
        Me.f2 = New System.Windows.Forms.DateTimePicker
        Me._gridAdicionales = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.f1 = New System.Windows.Forms.DateTimePicker
        Me._griddevoluciones = New System.Windows.Forms.DataGridView
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.imagen2 = New System.Windows.Forms.PictureBox
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me.ToolStrip1.SuspendLayout()
        CType(Me._gridAdicionales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._griddevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._grpCBuquedas.SuspendLayout()
        CType(Me.imagen2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblsucursal
        '
        Me.lblsucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblsucursal.AutoSize = True
        Me.lblsucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsucursal.Location = New System.Drawing.Point(13, 26)
        Me.lblsucursal.Name = "lblsucursal"
        Me.lblsucursal.Size = New System.Drawing.Size(58, 15)
        Me.lblsucursal.TabIndex = 24
        Me.lblsucursal.Text = "Sucursal:"
        '
        'TotalFacturado
        '
        Me.TotalFacturado.AutoSize = True
        Me.TotalFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalFacturado.Location = New System.Drawing.Point(197, 115)
        Me.TotalFacturado.Name = "TotalFacturado"
        Me.TotalFacturado.Size = New System.Drawing.Size(28, 17)
        Me.TotalFacturado.TabIndex = 35
        Me.TotalFacturado.Text = "    "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 17)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Total Monto Devuelto:"
        '
        'lblFacturado
        '
        Me.lblFacturado.AutoSize = True
        Me.lblFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacturado.Location = New System.Drawing.Point(14, 113)
        Me.lblFacturado.Name = "lblFacturado"
        Me.lblFacturado.Size = New System.Drawing.Size(177, 17)
        Me.lblFacturado.TabIndex = 32
        Me.lblFacturado.Text = "Total Monto Facturado:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(931, 39)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'cmbsucursal
        '
        Me.cmbsucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbsucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsucursal.DropDownWidth = 180
        Me.cmbsucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsucursal.FormattingEnabled = True
        Me.cmbsucursal.Location = New System.Drawing.Point(71, 23)
        Me.cmbsucursal.Name = "cmbsucursal"
        Me.cmbsucursal.Size = New System.Drawing.Size(124, 23)
        Me.cmbsucursal.TabIndex = 1
        '
        'totaldevuelto
        '
        Me.totaldevuelto.AutoSize = True
        Me.totaldevuelto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totaldevuelto.Location = New System.Drawing.Point(197, 133)
        Me.totaldevuelto.Name = "totaldevuelto"
        Me.totaldevuelto.Size = New System.Drawing.Size(28, 17)
        Me.totaldevuelto.TabIndex = 34
        Me.totaldevuelto.Text = "    "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(423, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 17)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "% Efectividad:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(487, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Fin:"
        '
        'efectividad
        '
        Me.efectividad.AutoSize = True
        Me.efectividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.efectividad.Location = New System.Drawing.Point(536, 114)
        Me.efectividad.Name = "efectividad"
        Me.efectividad.Size = New System.Drawing.Size(28, 17)
        Me.efectividad.TabIndex = 39
        Me.efectividad.Text = "    "
        '
        'porcentajeefec
        '
        Me.porcentajeefec.AutoSize = True
        Me.porcentajeefec.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.porcentajeefec.Location = New System.Drawing.Point(536, 132)
        Me.porcentajeefec.Name = "porcentajeefec"
        Me.porcentajeefec.Size = New System.Drawing.Size(28, 17)
        Me.porcentajeefec.TabIndex = 38
        Me.porcentajeefec.Text = "    "
        '
        '_lblFechaInicio
        '
        Me._lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaInicio.AutoSize = True
        Me._lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaInicio.Location = New System.Drawing.Point(199, 26)
        Me._lblFechaInicio.Name = "_lblFechaInicio"
        Me._lblFechaInicio.Size = New System.Drawing.Size(39, 15)
        Me._lblFechaInicio.TabIndex = 20
        Me._lblFechaInicio.Text = "Inicio:"
        '
        'f2
        '
        Me.f2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.f2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f2.Location = New System.Drawing.Point(520, 25)
        Me.f2.Name = "f2"
        Me.f2.Size = New System.Drawing.Size(241, 21)
        Me.f2.TabIndex = 3
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
        Me._gridAdicionales.Location = New System.Drawing.Point(870, 116)
        Me._gridAdicionales.Name = "_gridAdicionales"
        Me._gridAdicionales.ReadOnly = True
        Me._gridAdicionales.Size = New System.Drawing.Size(49, 30)
        Me._gridAdicionales.TabIndex = 31
        Me._gridAdicionales.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(441, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 17)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Efectividad:"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(774, 21)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(80, 30)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'f1
        '
        Me.f1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.f1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f1.Location = New System.Drawing.Point(243, 25)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(244, 21)
        Me.f1.TabIndex = 2
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
        Me._griddevoluciones.Location = New System.Drawing.Point(12, 154)
        Me._griddevoluciones.Name = "_griddevoluciones"
        Me._griddevoluciones.ReadOnly = True
        Me._griddevoluciones.Size = New System.Drawing.Size(907, 379)
        Me._griddevoluciones.TabIndex = 29
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
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 48)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(907, 62)
        Me._grpCBuquedas.TabIndex = 30
        Me._grpCBuquedas.TabStop = False
        Me._grpCBuquedas.Text = "Criterios de Busqueda"
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
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.generacion
        Me.Imagen.Location = New System.Drawing.Point(859, 39)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(23, 20)
        Me.Imagen.TabIndex = 11
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        'Devoluciones_DIMOSA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 539)
        Me.Controls.Add(Me.TotalFacturado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFacturado)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.totaldevuelto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.efectividad)
        Me.Controls.Add(Me.porcentajeefec)
        Me.Controls.Add(Me._gridAdicionales)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me._griddevoluciones)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Devoluciones_DIMOSA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devoluciones DIMOSA"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me._gridAdicionales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._griddevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        CType(Me.imagen2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblsucursal As System.Windows.Forms.Label
    Friend WithEvents TotalFacturado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFacturado As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbsucursal As System.Windows.Forms.ComboBox
    Friend WithEvents totaldevuelto As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents efectividad As System.Windows.Forms.Label
    Friend WithEvents porcentajeefec As System.Windows.Forms.Label
    Friend WithEvents _lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents f2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents _gridAdicionales As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents f1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents _griddevoluciones As System.Windows.Forms.DataGridView
    Friend WithEvents imagen2 As System.Windows.Forms.PictureBox
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
End Class
