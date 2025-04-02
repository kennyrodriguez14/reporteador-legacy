<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientesPareto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientesPareto))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DESC = New System.Windows.Forms.Label
        Me.BtnExportar = New System.Windows.Forms.Button
        Me.BtnGenerar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DataReporte = New System.Windows.Forms.DataGridView
        Me.Clave = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Contacto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Teléfono = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cumpleaños = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Porcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataTemp = New System.Windows.Forms.DataGridView
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.DESC)
        Me.GroupBox1.Controls.Add(Me.BtnExportar)
        Me.GroupBox1.Controls.Add(Me.BtnGenerar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(867, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DESC
        '
        Me.DESC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DESC.AutoSize = True
        Me.DESC.ForeColor = System.Drawing.Color.DarkRed
        Me.DESC.Location = New System.Drawing.Point(720, 16)
        Me.DESC.Name = "DESC"
        Me.DESC.Size = New System.Drawing.Size(141, 26)
        Me.DESC.TabIndex = 5
        Me.DESC.Text = "*Hay clientes cumpleañeros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "el día de hoy"
        Me.DESC.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'BtnExportar
        '
        Me.BtnExportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnExportar.Location = New System.Drawing.Point(23, 27)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(56, 51)
        Me.BtnExportar.TabIndex = 4
        Me.BtnExportar.Text = "Exportar"
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Location = New System.Drawing.Point(532, 51)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.BtnGenerar.TabIndex = 3
        Me.BtnGenerar.Text = "Generar"
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(323, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(97, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ventas desde:"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(326, 52)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 2
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(100, 52)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'DataReporte
        '
        Me.DataReporte.AllowUserToAddRows = False
        Me.DataReporte.AllowUserToDeleteRows = False
        Me.DataReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataReporte.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Clave, Me.Status, Me.Nombre, Me.Contacto, Me.Teléfono, Me.Vendedor, Me.Cumpleaños, Me.Porcentaje})
        Me.DataReporte.Location = New System.Drawing.Point(12, 135)
        Me.DataReporte.Name = "DataReporte"
        Me.DataReporte.ReadOnly = True
        Me.DataReporte.Size = New System.Drawing.Size(867, 367)
        Me.DataReporte.TabIndex = 5
        '
        'Clave
        '
        Me.Clave.HeaderText = "Clave"
        Me.Clave.Name = "Clave"
        Me.Clave.ReadOnly = True
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre Cliente"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Contacto
        '
        Me.Contacto.HeaderText = "Contacto"
        Me.Contacto.Name = "Contacto"
        Me.Contacto.ReadOnly = True
        '
        'Teléfono
        '
        Me.Teléfono.HeaderText = "Teléfono"
        Me.Teléfono.Name = "Teléfono"
        Me.Teléfono.ReadOnly = True
        '
        'Vendedor
        '
        Me.Vendedor.HeaderText = "Vendedor"
        Me.Vendedor.Name = "Vendedor"
        Me.Vendedor.ReadOnly = True
        '
        'Cumpleaños
        '
        Me.Cumpleaños.HeaderText = "Fecha Cumpleaños"
        Me.Cumpleaños.Name = "Cumpleaños"
        Me.Cumpleaños.ReadOnly = True
        '
        'Porcentaje
        '
        Me.Porcentaje.HeaderText = "Porcentaje Ventas"
        Me.Porcentaje.Name = "Porcentaje"
        Me.Porcentaje.ReadOnly = True
        '
        'DataTemp
        '
        Me.DataTemp.AllowUserToAddRows = False
        Me.DataTemp.AllowUserToDeleteRows = False
        Me.DataTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataTemp.Location = New System.Drawing.Point(143, 322)
        Me.DataTemp.Name = "DataTemp"
        Me.DataTemp.ReadOnly = True
        Me.DataTemp.Size = New System.Drawing.Size(629, 150)
        Me.DataTemp.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(721, 45)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(140, 50)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Visible = False
        '
        'FrmClientesPareto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 514)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataReporte)
        Me.Controls.Add(Me.DataTemp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmClientesPareto"
        Me.Text = "FrmClientesPareto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataReporte As System.Windows.Forms.DataGridView
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents DataTemp As System.Windows.Forms.DataGridView
    Friend WithEvents Clave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Contacto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Teléfono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vendedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cumpleaños As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Porcentaje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESC As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
