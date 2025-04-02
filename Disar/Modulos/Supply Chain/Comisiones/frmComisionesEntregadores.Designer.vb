<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComisionesEntregadores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComisionesEntregadores))
        Me.Comisiones = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.BtnComisiones = New System.Windows.Forms.Button
        Me.Hasta = New System.Windows.Forms.DateTimePicker
        Me.Desde = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboEntregador = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextComisionesEntregasParciales = New System.Windows.Forms.TextBox
        Me.TextComisionesPeso = New System.Windows.Forms.TextBox
        Me.TextComisionesEntregasTotales = New System.Windows.Forms.TextBox
        Me.TextTotalPesoDevoluciones = New System.Windows.Forms.TextBox
        Me.TextTotalPeso = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TextTotalComisiones = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Detalle = New System.Windows.Forms.DataGridView
        Me.BtnDetalle = New System.Windows.Forms.Button
        CType(Me.Comisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Comisiones
        '
        Me.Comisiones.AllowUserToAddRows = False
        Me.Comisiones.AllowUserToDeleteRows = False
        Me.Comisiones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Comisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Comisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Comisiones.Location = New System.Drawing.Point(13, 99)
        Me.Comisiones.Name = "Comisiones"
        Me.Comisiones.ReadOnly = True
        Me.Comisiones.Size = New System.Drawing.Size(877, 372)
        Me.Comisiones.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.BtnComisiones)
        Me.GroupBox1.Controls.Add(Me.Hasta)
        Me.GroupBox1.Controls.Add(Me.Desde)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboEntregador)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(877, 80)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(430, 51)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "Todos"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(208, 49)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(27, 20)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = "1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(143, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Método:"
        '
        'BtnComisiones
        '
        Me.BtnComisiones.Location = New System.Drawing.Point(778, 19)
        Me.BtnComisiones.Name = "BtnComisiones"
        Me.BtnComisiones.Size = New System.Drawing.Size(85, 46)
        Me.BtnComisiones.TabIndex = 3
        Me.BtnComisiones.Text = "Calcular"
        Me.BtnComisiones.UseVisualStyleBackColor = True
        '
        'Hasta
        '
        Me.Hasta.Location = New System.Drawing.Point(557, 45)
        Me.Hasta.Name = "Hasta"
        Me.Hasta.Size = New System.Drawing.Size(200, 20)
        Me.Hasta.TabIndex = 2
        '
        'Desde
        '
        Me.Desde.Location = New System.Drawing.Point(557, 19)
        Me.Desde.Name = "Desde"
        Me.Desde.Size = New System.Drawing.Size(200, 20)
        Me.Desde.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(513, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(513, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Desde:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(143, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Entregador"
        '
        'ComboEntregador
        '
        Me.ComboEntregador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboEntregador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboEntregador.FormattingEnabled = True
        Me.ComboEntregador.Location = New System.Drawing.Point(208, 19)
        Me.ComboEntregador.Name = "ComboEntregador"
        Me.ComboEntregador.Size = New System.Drawing.Size(278, 21)
        Me.ComboEntregador.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TextComisionesEntregasParciales)
        Me.GroupBox2.Controls.Add(Me.TextComisionesPeso)
        Me.GroupBox2.Controls.Add(Me.TextComisionesEntregasTotales)
        Me.GroupBox2.Controls.Add(Me.TextTotalPesoDevoluciones)
        Me.GroupBox2.Controls.Add(Me.TextTotalPeso)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(300, 477)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(590, 138)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'TextComisionesEntregasParciales
        '
        Me.TextComisionesEntregasParciales.Location = New System.Drawing.Point(229, 105)
        Me.TextComisionesEntregasParciales.Name = "TextComisionesEntregasParciales"
        Me.TextComisionesEntregasParciales.ReadOnly = True
        Me.TextComisionesEntregasParciales.Size = New System.Drawing.Size(100, 20)
        Me.TextComisionesEntregasParciales.TabIndex = 1
        '
        'TextComisionesPeso
        '
        Me.TextComisionesPeso.Location = New System.Drawing.Point(229, 61)
        Me.TextComisionesPeso.Name = "TextComisionesPeso"
        Me.TextComisionesPeso.ReadOnly = True
        Me.TextComisionesPeso.Size = New System.Drawing.Size(100, 20)
        Me.TextComisionesPeso.TabIndex = 1
        '
        'TextComisionesEntregasTotales
        '
        Me.TextComisionesEntregasTotales.Location = New System.Drawing.Point(229, 83)
        Me.TextComisionesEntregasTotales.Name = "TextComisionesEntregasTotales"
        Me.TextComisionesEntregasTotales.ReadOnly = True
        Me.TextComisionesEntregasTotales.Size = New System.Drawing.Size(100, 20)
        Me.TextComisionesEntregasTotales.TabIndex = 1
        '
        'TextTotalPesoDevoluciones
        '
        Me.TextTotalPesoDevoluciones.Location = New System.Drawing.Point(229, 39)
        Me.TextTotalPesoDevoluciones.Name = "TextTotalPesoDevoluciones"
        Me.TextTotalPesoDevoluciones.ReadOnly = True
        Me.TextTotalPesoDevoluciones.Size = New System.Drawing.Size(100, 20)
        Me.TextTotalPesoDevoluciones.TabIndex = 1
        '
        'TextTotalPeso
        '
        Me.TextTotalPeso.Location = New System.Drawing.Point(229, 17)
        Me.TextTotalPeso.Name = "TextTotalPeso"
        Me.TextTotalPeso.ReadOnly = True
        Me.TextTotalPeso.Size = New System.Drawing.Size(100, 20)
        Me.TextTotalPeso.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(56, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(172, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Comisiones por Entregas Parciales:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(56, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(164, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Comisiones por Entregas Totales:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(56, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Comisiones por Peso:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(49, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "- Total Peso Devoluciones:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(56, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total Peso:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextTotalComisiones)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(384, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'TextTotalComisiones
        '
        Me.TextTotalComisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalComisiones.Location = New System.Drawing.Point(26, 47)
        Me.TextTotalComisiones.Name = "TextTotalComisiones"
        Me.TextTotalComisiones.ReadOnly = True
        Me.TextTotalComisiones.Size = New System.Drawing.Size(152, 20)
        Me.TextTotalComisiones.TabIndex = 2
        Me.TextTotalComisiones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(60, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Total Comisiones"
        '
        'Detalle
        '
        Me.Detalle.AllowUserToAddRows = False
        Me.Detalle.AllowUserToDeleteRows = False
        Me.Detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Detalle.Location = New System.Drawing.Point(13, 99)
        Me.Detalle.Name = "Detalle"
        Me.Detalle.ReadOnly = True
        Me.Detalle.Size = New System.Drawing.Size(877, 372)
        Me.Detalle.TabIndex = 3
        '
        'BtnDetalle
        '
        Me.BtnDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDetalle.Location = New System.Drawing.Point(221, 482)
        Me.BtnDetalle.Name = "BtnDetalle"
        Me.BtnDetalle.Size = New System.Drawing.Size(75, 55)
        Me.BtnDetalle.TabIndex = 4
        Me.BtnDetalle.Text = "Detalle"
        Me.BtnDetalle.UseVisualStyleBackColor = True
        '
        'frmComisionesEntregadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 627)
        Me.Controls.Add(Me.BtnDetalle)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Detalle)
        Me.Controls.Add(Me.Comisiones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmComisionesEntregadores"
        Me.Text = "Comisiones Entregadores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Comisiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Comisiones As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboEntregador As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Detalle As System.Windows.Forms.DataGridView
    Friend WithEvents BtnDetalle As System.Windows.Forms.Button
    Friend WithEvents BtnComisiones As System.Windows.Forms.Button
    Friend WithEvents Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextComisionesEntregasParciales As System.Windows.Forms.TextBox
    Friend WithEvents TextComisionesPeso As System.Windows.Forms.TextBox
    Friend WithEvents TextComisionesEntregasTotales As System.Windows.Forms.TextBox
    Friend WithEvents TextTotalPesoDevoluciones As System.Windows.Forms.TextBox
    Friend WithEvents TextTotalPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextTotalComisiones As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
