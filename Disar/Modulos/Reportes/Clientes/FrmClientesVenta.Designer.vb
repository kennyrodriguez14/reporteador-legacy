<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientesVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientesVenta))
        Me.BtnAceptar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboVendedor = New System.Windows.Forms.ComboBox
        Me.ComboSupervisor = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Empresa = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Exportar = New System.Windows.Forms.Button
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataReportes2 = New System.Windows.Forms.DataGridView
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataReportes2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(338, 63)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(98, 37)
        Me.BtnAceptar.TabIndex = 1
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ComboVendedor)
        Me.GroupBox1.Controls.Add(Me.ComboSupervisor)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Empresa)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Exportar)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.BtnAceptar)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(978, 106)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'ComboVendedor
        '
        Me.ComboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVendedor.DropDownWidth = 220
        Me.ComboVendedor.FormattingEnabled = True
        Me.ComboVendedor.Location = New System.Drawing.Point(457, 36)
        Me.ComboVendedor.Name = "ComboVendedor"
        Me.ComboVendedor.Size = New System.Drawing.Size(257, 21)
        Me.ComboVendedor.TabIndex = 15
        Me.ComboVendedor.Visible = False
        '
        'ComboSupervisor
        '
        Me.ComboSupervisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSupervisor.DropDownWidth = 220
        Me.ComboSupervisor.FormattingEnabled = True
        Me.ComboSupervisor.Location = New System.Drawing.Point(512, 11)
        Me.ComboSupervisor.Name = "ComboSupervisor"
        Me.ComboSupervisor.Size = New System.Drawing.Size(202, 21)
        Me.ComboSupervisor.TabIndex = 14
        Me.ComboSupervisor.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(454, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Supervisor:"
        Me.Label5.Visible = False
        '
        'Empresa
        '
        Me.Empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Empresa.FormattingEnabled = True
        Me.Empresa.Location = New System.Drawing.Point(126, 11)
        Me.Empresa.Name = "Empresa"
        Me.Empresa.Size = New System.Drawing.Size(310, 21)
        Me.Empresa.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Empresa:"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Detalle Por Vendedor", "Listado de Clientes Creados", "Listado de Clientes Suspendidos"})
        Me.ComboBox2.Location = New System.Drawing.Point(457, 36)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(257, 21)
        Me.ComboBox2.TabIndex = 10
        Me.ComboBox2.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Venta Perdida y Venta Baja", "Clientes Nuevos", "Clientes Por Ruta (Vendedor)", "Análisis de Clientes en Riesgo"})
        Me.ComboBox1.Location = New System.Drawing.Point(126, 36)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(310, 21)
        Me.ComboBox1.TabIndex = 9
        '
        'Exportar
        '
        Me.Exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Exportar.Location = New System.Drawing.Point(897, 31)
        Me.Exportar.Name = "Exportar"
        Me.Exportar.Size = New System.Drawing.Size(75, 47)
        Me.Exportar.TabIndex = 8
        Me.Exportar.Text = "Exportar"
        Me.Exportar.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "MMM/yyyy"
        Me.DateTimePicker2.Location = New System.Drawing.Point(126, 83)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(206, 20)
        Me.DateTimePicker2.TabIndex = 5
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "MMM/yyyy"
        Me.DateTimePicker1.Location = New System.Drawing.Point(126, 61)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(206, 20)
        Me.DateTimePicker1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Ventas hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Reporte:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ventas desde:"
        '
        'DataReportes2
        '
        Me.DataReportes2.AllowUserToAddRows = False
        Me.DataReportes2.AllowUserToDeleteRows = False
        Me.DataReportes2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataReportes2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataReportes2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataReportes2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataReportes2.Location = New System.Drawing.Point(13, 123)
        Me.DataReportes2.Name = "DataReportes2"
        Me.DataReportes2.ReadOnly = True
        Me.DataReportes2.RowHeadersVisible = False
        Me.DataReportes2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataReportes2.Size = New System.Drawing.Size(980, 507)
        Me.DataReportes2.TabIndex = 7
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Location = New System.Drawing.Point(12, 122)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(981, 514)
        Me.TabControl1.TabIndex = 8
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "ColImagen"
        Me.DataGridViewImageColumn1.Image = Global.Disar.My.Resources.Resources.Badge_plus_32
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 179
        '
        'FrmClientesVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 641)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.DataReportes2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmClientesVenta"
        Me.Text = "Datos de clientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataReportes2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Exportar As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataReportes2 As System.Windows.Forms.DataGridView
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboSupervisor As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboVendedor As System.Windows.Forms.ComboBox
End Class
