<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Saldos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Saldos))
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox
        Me.cmbSucursal = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._lblFechaInicio = New System.Windows.Forms.Label
        Me.f1 = New System.Windows.Forms.DateTimePicker
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn20 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle
        Me.grilla = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExportar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ComboEmpresa = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me._grpCBuquedas.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = "N2"
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "+30"
        Me.DataGridTextBoxColumn11.MappingName = "+30"
        Me.DataGridTextBoxColumn11.NullText = "0"
        Me.DataGridTextBoxColumn11.ReadOnly = True
        Me.DataGridTextBoxColumn11.Width = 75
        '
        '_grpCBuquedas
        '
        Me._grpCBuquedas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._grpCBuquedas.Controls.Add(Me.ComboEmpresa)
        Me._grpCBuquedas.Controls.Add(Me.Label1)
        Me._grpCBuquedas.Controls.Add(Me.cmbSucursal)
        Me._grpCBuquedas.Controls.Add(Me.Label2)
        Me._grpCBuquedas.Controls.Add(Me._btnGenerar)
        Me._grpCBuquedas.Controls.Add(Me._lblFechaInicio)
        Me._grpCBuquedas.Controls.Add(Me.f1)
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 45)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(1094, 47)
        Me._grpCBuquedas.TabIndex = 13
        Me._grpCBuquedas.TabStop = False
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(387, 17)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(215, 24)
        Me.cmbSucursal.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(309, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Sucursal:"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(970, 19)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(70, 22)
        Me._btnGenerar.TabIndex = 6
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_lblFechaInicio
        '
        Me._lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaInicio.AutoSize = True
        Me._lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaInicio.Location = New System.Drawing.Point(608, 22)
        Me._lblFechaInicio.Name = "_lblFechaInicio"
        Me._lblFechaInicio.Size = New System.Drawing.Size(55, 16)
        Me._lblFechaInicio.TabIndex = 0
        Me._lblFechaInicio.Text = "Fecha:"
        '
        'f1
        '
        Me.f1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.f1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f1.Location = New System.Drawing.Point(663, 19)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(301, 22)
        Me.f1.TabIndex = 4
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = "N2"
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "+15"
        Me.DataGridTextBoxColumn10.MappingName = "+15"
        Me.DataGridTextBoxColumn10.NullText = "0"
        Me.DataGridTextBoxColumn10.ReadOnly = True
        Me.DataGridTextBoxColumn10.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = "N2"
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "+45"
        Me.DataGridTextBoxColumn12.MappingName = "+45"
        Me.DataGridTextBoxColumn12.NullText = "0"
        Me.DataGridTextBoxColumn12.ReadOnly = True
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = "N2"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "1-5"
        Me.DataGridTextBoxColumn7.MappingName = "1-5"
        Me.DataGridTextBoxColumn7.NullText = "0"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = "N2"
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "+10"
        Me.DataGridTextBoxColumn9.MappingName = "+10"
        Me.DataGridTextBoxColumn9.NullText = "0"
        Me.DataGridTextBoxColumn9.ReadOnly = True
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = "N2"
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "+60"
        Me.DataGridTextBoxColumn13.MappingName = "+60"
        Me.DataGridTextBoxColumn13.NullText = "0"
        Me.DataGridTextBoxColumn13.ReadOnly = True
        Me.DataGridTextBoxColumn13.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = "N2"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "6-9"
        Me.DataGridTextBoxColumn8.MappingName = "6-9"
        Me.DataGridTextBoxColumn8.NullText = "0"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "FECHA APLICACION"
        Me.DataGridTextBoxColumn19.MappingName = "FECHA_APLI"
        Me.DataGridTextBoxColumn19.NullText = ""
        Me.DataGridTextBoxColumn19.ReadOnly = True
        Me.DataGridTextBoxColumn19.Width = 200
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Format = "N2"
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "Dias de Credito"
        Me.DataGridTextBoxColumn14.MappingName = "Dias de Credito"
        Me.DataGridTextBoxColumn14.NullText = "0"
        Me.DataGridTextBoxColumn14.ReadOnly = True
        Me.DataGridTextBoxColumn14.Width = 140
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "NUMERO DE FACTURA"
        Me.DataGridTextBoxColumn17.MappingName = "NO_FACTURA"
        Me.DataGridTextBoxColumn17.NullText = "Vacio"
        Me.DataGridTextBoxColumn17.ReadOnly = True
        Me.DataGridTextBoxColumn17.Width = 200
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.HeaderText = "FECHA VENCIMIENTO"
        Me.DataGridTextBoxColumn20.MappingName = "FECHA_VENC"
        Me.DataGridTextBoxColumn20.NullText = ""
        Me.DataGridTextBoxColumn20.ReadOnly = True
        Me.DataGridTextBoxColumn20.Width = 200
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = "N2"
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "Limite de Credito"
        Me.DataGridTextBoxColumn15.MappingName = "Limite de Credito"
        Me.DataGridTextBoxColumn15.NullText = "0"
        Me.DataGridTextBoxColumn15.ReadOnly = True
        Me.DataGridTextBoxColumn15.Width = 140
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "CLIENTE"
        Me.DataGridTextBoxColumn16.MappingName = "CLIENTE"
        Me.DataGridTextBoxColumn16.NullText = "Vacio"
        Me.DataGridTextBoxColumn16.ReadOnly = True
        Me.DataGridTextBoxColumn16.Width = 350
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = "N2"
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "AL CORRIENTE"
        Me.DataGridTextBoxColumn6.MappingName = "AL CORRIENTE"
        Me.DataGridTextBoxColumn6.NullText = "0"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 140
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaption
        Me.DataGridTableStyle2.DataGrid = Me.grilla
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn18})
        Me.DataGridTableStyle2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "B"
        '
        'grilla
        '
        Me.grilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grilla.DataMember = ""
        Me.grilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grilla.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grilla.Location = New System.Drawing.Point(13, 99)
        Me.grilla.Name = "grilla"
        Me.grilla.ParentRowsVisible = False
        Me.grilla.PreferredColumnWidth = 60
        Me.grilla.ReadOnly = True
        Me.grilla.Size = New System.Drawing.Size(1093, 420)
        Me.grilla.TabIndex = 15
        Me.grilla.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1, Me.DataGridTableStyle2})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaption
        Me.DataGridTableStyle1.DataGrid = Me.grilla
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15})
        Me.DataGridTableStyle1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "A"
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "SUCURSAL"
        Me.DataGridTextBoxColumn1.MappingName = "SUCURSAL"
        Me.DataGridTextBoxColumn1.NullText = "Vacio"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 90
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "NOMBRE"
        Me.DataGridTextBoxColumn2.MappingName = "NOMBRE"
        Me.DataGridTextBoxColumn2.NullText = "Vacio"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 180
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "CCLIE"
        Me.DataGridTextBoxColumn3.MappingName = "CCLIE"
        Me.DataGridTextBoxColumn3.NullText = "Vacio"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 60
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "CLIENTE"
        Me.DataGridTextBoxColumn4.MappingName = "CLIENTE"
        Me.DataGridTextBoxColumn4.NullText = "Vacio"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 350
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = "N2"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "SALDO"
        Me.DataGridTextBoxColumn5.MappingName = "SALDO"
        Me.DataGridTextBoxColumn5.NullText = "0"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Format = "N2"
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "SALDO"
        Me.DataGridTextBoxColumn18.MappingName = "SALDO"
        Me.DataGridTextBoxColumn18.NullText = "0"
        Me.DataGridTextBoxColumn18.ReadOnly = True
        Me.DataGridTextBoxColumn18.Width = 150
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btnExportar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1118, 39)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnExportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.btnExportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(72, 36)
        Me.btnExportar.Tag = "Exportar a Excel"
        Me.btnExportar.Text = "Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ComboEmpresa
        '
        Me.ComboEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ComboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboEmpresa.FormattingEnabled = True
        Me.ComboEmpresa.Location = New System.Drawing.Point(88, 17)
        Me.ComboEmpresa.Name = "ComboEmpresa"
        Me.ComboEmpresa.Size = New System.Drawing.Size(215, 24)
        Me.ComboEmpresa.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Empresa:"
        '
        'Saldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1118, 525)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grilla)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Saldos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Antiguedad de Saldos"
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents f1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn20 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents grilla As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ComboEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
