<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Devoluciones_Notas_De_Credito_SRAGRO
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
        Me.lblTotalDevoluciones = New System.Windows.Forms.Label
        Me.lblDevoluviones = New System.Windows.Forms.Label
        Me.lblTotalDescuento = New System.Windows.Forms.Label
        Me.lblDescuento = New System.Windows.Forms.Label
        Me.lblTotalImpuesto = New System.Windows.Forms.Label
        Me.lblImpuesto = New System.Windows.Forms.Label
        Me.lblTotalImporte = New System.Windows.Forms.Label
        Me.lblImporte = New System.Windows.Forms.Label
        Me.LblNumeroRegistros = New System.Windows.Forms.Label
        Me.lblRegistros = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox
        Me.lblsucursal = New System.Windows.Forms.Label
        Me.cmbsucursal = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblFechaInicio = New System.Windows.Forms.Label
        Me.f2 = New System.Windows.Forms.DateTimePicker
        Me.f1 = New System.Windows.Forms.DateTimePicker
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._griddevoluciones = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me._grpCBuquedas.SuspendLayout()
        CType(Me._griddevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTotalDevoluciones
        '
        Me.lblTotalDevoluciones.AutoSize = True
        Me.lblTotalDevoluciones.Location = New System.Drawing.Point(824, 134)
        Me.lblTotalDevoluciones.Name = "lblTotalDevoluciones"
        Me.lblTotalDevoluciones.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalDevoluciones.TabIndex = 46
        Me.lblTotalDevoluciones.Text = "0"
        '
        'lblDevoluviones
        '
        Me.lblDevoluviones.AutoSize = True
        Me.lblDevoluviones.Location = New System.Drawing.Point(722, 134)
        Me.lblDevoluviones.Name = "lblDevoluviones"
        Me.lblDevoluviones.Size = New System.Drawing.Size(99, 13)
        Me.lblDevoluviones.TabIndex = 45
        Me.lblDevoluviones.Text = "Total Devoluciones"
        '
        'lblTotalDescuento
        '
        Me.lblTotalDescuento.AutoSize = True
        Me.lblTotalDescuento.Location = New System.Drawing.Point(593, 134)
        Me.lblTotalDescuento.Name = "lblTotalDescuento"
        Me.lblTotalDescuento.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalDescuento.TabIndex = 44
        Me.lblTotalDescuento.Text = "0"
        '
        'lblDescuento
        '
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.Location = New System.Drawing.Point(506, 134)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(86, 13)
        Me.lblDescuento.TabIndex = 43
        Me.lblDescuento.Text = "Total Descuento"
        '
        'lblTotalImpuesto
        '
        Me.lblTotalImpuesto.AutoSize = True
        Me.lblTotalImpuesto.Location = New System.Drawing.Point(387, 134)
        Me.lblTotalImpuesto.Name = "lblTotalImpuesto"
        Me.lblTotalImpuesto.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalImpuesto.TabIndex = 42
        Me.lblTotalImpuesto.Text = "0"
        '
        'lblImpuesto
        '
        Me.lblImpuesto.AutoSize = True
        Me.lblImpuesto.Location = New System.Drawing.Point(307, 134)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(77, 13)
        Me.lblImpuesto.TabIndex = 41
        Me.lblImpuesto.Text = "Total Impuesto"
        '
        'lblTotalImporte
        '
        Me.lblTotalImporte.AutoSize = True
        Me.lblTotalImporte.Location = New System.Drawing.Point(189, 134)
        Me.lblTotalImporte.Name = "lblTotalImporte"
        Me.lblTotalImporte.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalImporte.TabIndex = 40
        Me.lblTotalImporte.Text = "0"
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Location = New System.Drawing.Point(116, 134)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(69, 13)
        Me.lblImporte.TabIndex = 39
        Me.lblImporte.Text = "Total Importe"
        '
        'LblNumeroRegistros
        '
        Me.LblNumeroRegistros.AutoSize = True
        Me.LblNumeroRegistros.Location = New System.Drawing.Point(69, 134)
        Me.LblNumeroRegistros.Name = "LblNumeroRegistros"
        Me.LblNumeroRegistros.Size = New System.Drawing.Size(13, 13)
        Me.LblNumeroRegistros.TabIndex = 38
        Me.LblNumeroRegistros.Text = "0"
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Location = New System.Drawing.Point(14, 134)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(51, 13)
        Me.lblRegistros.TabIndex = 37
        Me.lblRegistros.Text = "Registros"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(931, 39)
        Me.ToolStrip1.TabIndex = 34
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
        Me._grpCBuquedas.Controls.Add(Me._btnGenerar)
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 51)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(907, 62)
        Me._grpCBuquedas.TabIndex = 36
        Me._grpCBuquedas.TabStop = False
        Me._grpCBuquedas.Text = "Criterios de Busqueda"
        '
        'lblsucursal
        '
        Me.lblsucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblsucursal.AutoSize = True
        Me.lblsucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsucursal.Location = New System.Drawing.Point(23, 26)
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
        Me.cmbsucursal.Items.AddRange(New Object() {"Agro-SRC", "Agro-GRACIAS", "Agro-SAN JUAN", "Agro-SANTA BÁRBARA", "AGRO", "Movil 41", "Movil 40", "Movil 07", "TODAS"})
        Me.cmbsucursal.Location = New System.Drawing.Point(83, 23)
        Me.cmbsucursal.Name = "cmbsucursal"
        Me.cmbsucursal.Size = New System.Drawing.Size(91, 23)
        Me.cmbsucursal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(479, 26)
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
        Me._lblFechaInicio.Location = New System.Drawing.Point(191, 26)
        Me._lblFechaInicio.Name = "_lblFechaInicio"
        Me._lblFechaInicio.Size = New System.Drawing.Size(39, 15)
        Me._lblFechaInicio.TabIndex = 20
        Me._lblFechaInicio.Text = "Inicio:"
        '
        'f2
        '
        Me.f2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.f2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f2.Location = New System.Drawing.Point(512, 25)
        Me.f2.Name = "f2"
        Me.f2.Size = New System.Drawing.Size(241, 21)
        Me.f2.TabIndex = 3
        '
        'f1
        '
        Me.f1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.f1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f1.Location = New System.Drawing.Point(235, 25)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(244, 21)
        Me.f1.TabIndex = 2
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
        '_griddevoluciones
        '
        Me._griddevoluciones.AllowUserToAddRows = False
        Me._griddevoluciones.AllowUserToDeleteRows = False
        Me._griddevoluciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._griddevoluciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._griddevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._griddevoluciones.Location = New System.Drawing.Point(12, 157)
        Me._griddevoluciones.Name = "_griddevoluciones"
        Me._griddevoluciones.ReadOnly = True
        Me._griddevoluciones.Size = New System.Drawing.Size(907, 379)
        Me._griddevoluciones.TabIndex = 35
        '
        'Devoluciones_Notas_De_Credito_SRAGRO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 539)
        Me.Controls.Add(Me.lblTotalDevoluciones)
        Me.Controls.Add(Me.lblDevoluviones)
        Me.Controls.Add(Me.lblTotalDescuento)
        Me.Controls.Add(Me.lblDescuento)
        Me.Controls.Add(Me.lblTotalImpuesto)
        Me.Controls.Add(Me.lblImpuesto)
        Me.Controls.Add(Me.lblTotalImporte)
        Me.Controls.Add(Me.lblImporte)
        Me.Controls.Add(Me.LblNumeroRegistros)
        Me.Controls.Add(Me.lblRegistros)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me._griddevoluciones)
        Me.Name = "Devoluciones_Notas_De_Credito_SRAGRO"
        Me.Text = "Resumen devoluciones y notas de credito SR AGRO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        CType(Me._griddevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTotalDevoluciones As System.Windows.Forms.Label
    Friend WithEvents lblDevoluviones As System.Windows.Forms.Label
    Friend WithEvents lblTotalDescuento As System.Windows.Forms.Label
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents lblTotalImpuesto As System.Windows.Forms.Label
    Friend WithEvents lblImpuesto As System.Windows.Forms.Label
    Friend WithEvents lblTotalImporte As System.Windows.Forms.Label
    Friend WithEvents lblImporte As System.Windows.Forms.Label
    Friend WithEvents LblNumeroRegistros As System.Windows.Forms.Label
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents lblsucursal As System.Windows.Forms.Label
    Friend WithEvents cmbsucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents f2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents f1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _griddevoluciones As System.Windows.Forms.DataGridView
End Class
