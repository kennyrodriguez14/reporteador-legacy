<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EjecucionPresupuestos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EjecucionPresupuestos))
        Me.GridPresupuestos = New System.Windows.Forms.DataGridView
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox
        Me.txtCuenta_ini = New System.Windows.Forms.MaskedTextBox
        Me.txtCuenta_Fin = New System.Windows.Forms.MaskedTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbFecha_fin = New System.Windows.Forms.DateTimePicker
        Me.lbldesde = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbFecha_ini = New System.Windows.Forms.DateTimePicker
        Me._lblFechaInicio = New System.Windows.Forms.Label
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        CType(Me.GridPresupuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._grpCBuquedas.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridPresupuestos
        '
        Me.GridPresupuestos.AllowUserToAddRows = False
        Me.GridPresupuestos.AllowUserToDeleteRows = False
        Me.GridPresupuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPresupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridPresupuestos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridPresupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridPresupuestos.Location = New System.Drawing.Point(12, 116)
        Me.GridPresupuestos.Name = "GridPresupuestos"
        Me.GridPresupuestos.ReadOnly = True
        Me.GridPresupuestos.Size = New System.Drawing.Size(674, 297)
        Me.GridPresupuestos.TabIndex = 7
        '
        '_grpCBuquedas
        '
        Me._grpCBuquedas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._grpCBuquedas.Controls.Add(Me.txtCuenta_ini)
        Me._grpCBuquedas.Controls.Add(Me.txtCuenta_Fin)
        Me._grpCBuquedas.Controls.Add(Me.Label6)
        Me._grpCBuquedas.Controls.Add(Me.cmbFecha_fin)
        Me._grpCBuquedas.Controls.Add(Me.lbldesde)
        Me._grpCBuquedas.Controls.Add(Me.Label1)
        Me._grpCBuquedas.Controls.Add(Me.cmbFecha_ini)
        Me._grpCBuquedas.Controls.Add(Me._lblFechaInicio)
        Me._grpCBuquedas.Controls.Add(Me._btnGenerar)
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 42)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(674, 68)
        Me._grpCBuquedas.TabIndex = 14
        Me._grpCBuquedas.TabStop = False
        '
        'txtCuenta_ini
        '
        Me.txtCuenta_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCuenta_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta_ini.Location = New System.Drawing.Point(59, 42)
        Me.txtCuenta_ini.Name = "txtCuenta_ini"
        Me.txtCuenta_ini.Size = New System.Drawing.Size(236, 21)
        Me.txtCuenta_ini.TabIndex = 4
        Me.txtCuenta_ini.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCuenta_Fin
        '
        Me.txtCuenta_Fin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCuenta_Fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta_Fin.Location = New System.Drawing.Point(343, 40)
        Me.txtCuenta_Fin.Name = "txtCuenta_Fin"
        Me.txtCuenta_Fin.Size = New System.Drawing.Size(234, 21)
        Me.txtCuenta_Fin.TabIndex = 5
        Me.txtCuenta_Fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(301, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Hasta:"
        '
        'cmbFecha_fin
        '
        Me.cmbFecha_fin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbFecha_fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFecha_fin.Location = New System.Drawing.Point(343, 12)
        Me.cmbFecha_fin.Name = "cmbFecha_fin"
        Me.cmbFecha_fin.Size = New System.Drawing.Size(234, 21)
        Me.cmbFecha_fin.TabIndex = 3
        '
        'lbldesde
        '
        Me.lbldesde.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbldesde.AutoSize = True
        Me.lbldesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldesde.Location = New System.Drawing.Point(12, 42)
        Me.lbldesde.Name = "lbldesde"
        Me.lbldesde.Size = New System.Drawing.Size(46, 15)
        Me.lbldesde.TabIndex = 0
        Me.lbldesde.Text = "Desde:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(316, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fin:"
        '
        'cmbFecha_ini
        '
        Me.cmbFecha_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbFecha_ini.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFecha_ini.Location = New System.Drawing.Point(59, 12)
        Me.cmbFecha_ini.Name = "cmbFecha_ini"
        Me.cmbFecha_ini.Size = New System.Drawing.Size(236, 21)
        Me.cmbFecha_ini.TabIndex = 2
        '
        '_lblFechaInicio
        '
        Me._lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechaInicio.AutoSize = True
        Me._lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechaInicio.Location = New System.Drawing.Point(21, 15)
        Me._lblFechaInicio.Name = "_lblFechaInicio"
        Me._lblFechaInicio.Size = New System.Drawing.Size(39, 15)
        Me._lblFechaInicio.TabIndex = 0
        Me._lblFechaInicio.Text = "Inicio:"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(587, 20)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(81, 30)
        Me._btnGenerar.TabIndex = 6
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(698, 39)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 36)
        Me.ToolStripButton1.Tag = "Exportar a Excel"
        Me.ToolStripButton1.Text = "Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'EjecucionPresupuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 425)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me.GridPresupuestos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EjecucionPresupuestos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ejecucion de Presupuestos"
        CType(Me.GridPresupuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridPresupuestos As System.Windows.Forms.DataGridView
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents txtCuenta_ini As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCuenta_Fin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbldesde As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbFecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
