<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DispD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_DispD))
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnExportar = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DInicio = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Final = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CheckViajes = New System.Windows.Forms.CheckBox
        Me.CkRemisiones = New System.Windows.Forms.CheckBox
        Me.CheckAgro = New System.Windows.Forms.CheckBox
        Me.CheckEntregas = New System.Windows.Forms.CheckBox
        Me.Reporte = New System.Windows.Forms.Label
        Me.BtnGenerar = New System.Windows.Forms.Button
        Me.CheckCombustible = New System.Windows.Forms.CheckBox
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataDatos.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataDatos.Location = New System.Drawing.Point(12, 146)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.RowHeadersVisible = False
        Me.DataDatos.Size = New System.Drawing.Size(965, 302)
        Me.DataDatos.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnExportar)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Reporte)
        Me.GroupBox1.Controls.Add(Me.BtnGenerar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(965, 128)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'BtnExportar
        '
        Me.BtnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnExportar.Location = New System.Drawing.Point(883, 24)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(67, 64)
        Me.BtnExportar.TabIndex = 7
        Me.BtnExportar.Text = "Exportar Información"
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.DInicio)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Final)
        Me.GroupBox3.Location = New System.Drawing.Point(498, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(281, 84)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango de Fechas"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Desde:"
        '
        'DInicio
        '
        Me.DInicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DInicio.Location = New System.Drawing.Point(63, 23)
        Me.DInicio.Name = "DInicio"
        Me.DInicio.Size = New System.Drawing.Size(200, 20)
        Me.DInicio.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Hasta:"
        '
        'Final
        '
        Me.Final.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Final.Location = New System.Drawing.Point(63, 49)
        Me.Final.Name = "Final"
        Me.Final.Size = New System.Drawing.Size(200, 20)
        Me.Final.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CheckCombustible)
        Me.GroupBox2.Controls.Add(Me.CheckViajes)
        Me.GroupBox2.Controls.Add(Me.CkRemisiones)
        Me.GroupBox2.Controls.Add(Me.CheckAgro)
        Me.GroupBox2.Controls.Add(Me.CheckEntregas)
        Me.GroupBox2.Location = New System.Drawing.Point(285, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(207, 111)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mostrar"
        '
        'CheckViajes
        '
        Me.CheckViajes.AutoSize = True
        Me.CheckViajes.Checked = True
        Me.CheckViajes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckViajes.Location = New System.Drawing.Point(9, 70)
        Me.CheckViajes.Name = "CheckViajes"
        Me.CheckViajes.Size = New System.Drawing.Size(76, 17)
        Me.CheckViajes.TabIndex = 5
        Me.CheckViajes.Text = "Otros usos"
        Me.CheckViajes.UseVisualStyleBackColor = True
        '
        'CkRemisiones
        '
        Me.CkRemisiones.AutoSize = True
        Me.CkRemisiones.Checked = True
        Me.CkRemisiones.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkRemisiones.Location = New System.Drawing.Point(9, 53)
        Me.CkRemisiones.Name = "CkRemisiones"
        Me.CkRemisiones.Size = New System.Drawing.Size(80, 17)
        Me.CkRemisiones.TabIndex = 4
        Me.CkRemisiones.Text = "Remisiones"
        Me.CkRemisiones.UseVisualStyleBackColor = True
        '
        'CheckAgro
        '
        Me.CheckAgro.AutoSize = True
        Me.CheckAgro.Checked = True
        Me.CheckAgro.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckAgro.Location = New System.Drawing.Point(9, 36)
        Me.CheckAgro.Name = "CheckAgro"
        Me.CheckAgro.Size = New System.Drawing.Size(111, 17)
        Me.CheckAgro.TabIndex = 4
        Me.CheckAgro.Text = "Entregas SR Agro"
        Me.CheckAgro.UseVisualStyleBackColor = True
        '
        'CheckEntregas
        '
        Me.CheckEntregas.AutoSize = True
        Me.CheckEntregas.Checked = True
        Me.CheckEntregas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckEntregas.Location = New System.Drawing.Point(9, 19)
        Me.CheckEntregas.Name = "CheckEntregas"
        Me.CheckEntregas.Size = New System.Drawing.Size(114, 17)
        Me.CheckEntregas.TabIndex = 4
        Me.CheckEntregas.Text = "Entregas consumo"
        Me.CheckEntregas.UseVisualStyleBackColor = True
        '
        'Reporte
        '
        Me.Reporte.AutoSize = True
        Me.Reporte.Location = New System.Drawing.Point(6, 29)
        Me.Reporte.Name = "Reporte"
        Me.Reporte.Size = New System.Drawing.Size(27, 13)
        Me.Reporte.TabIndex = 3
        Me.Reporte.Text = "Rep"
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerar.Location = New System.Drawing.Point(784, 24)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(90, 64)
        Me.BtnGenerar.TabIndex = 2
        Me.BtnGenerar.Text = "Generar"
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'CheckCombustible
        '
        Me.CheckCombustible.AutoSize = True
        Me.CheckCombustible.Checked = True
        Me.CheckCombustible.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckCombustible.Location = New System.Drawing.Point(9, 87)
        Me.CheckCombustible.Name = "CheckCombustible"
        Me.CheckCombustible.Size = New System.Drawing.Size(134, 17)
        Me.CheckCombustible.TabIndex = 6
        Me.CheckCombustible.Text = "Cargas de Combustible"
        Me.CheckCombustible.UseVisualStyleBackColor = True
        '
        'Frm_DispD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 467)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_DispD"
        Me.Text = "Reporte de Disponibilidad"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents Final As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Reporte As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CkRemisiones As System.Windows.Forms.CheckBox
    Friend WithEvents CheckAgro As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEntregas As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents CheckViajes As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCombustible As System.Windows.Forms.CheckBox
End Class
