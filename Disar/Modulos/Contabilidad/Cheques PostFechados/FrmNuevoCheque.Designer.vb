<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNuevoCheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNuevoCheque))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnCliente = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.ComboBanco = New System.Windows.Forms.ComboBox
        Me.TxtCuenta = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtClienteNombre = New System.Windows.Forms.TextBox
        Me.TxtStatus = New System.Windows.Forms.TextBox
        Me.TxtClienteClave = New System.Windows.Forms.TextBox
        Me.TxtMonto = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtNumeroCheque = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ColMonto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColAbonos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.ColFactura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataFacturas = New System.Windows.Forms.DataGridView
        Me.BtnFactura = New System.Windows.Forms.Button
        Me.BtnAceptar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtNumeroBanco = New System.Windows.Forms.TextBox
        Me.BtnQuitar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtNumeroBanco)
        Me.GroupBox1.Controls.Add(Me.BtnCliente)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.ComboBanco)
        Me.GroupBox1.Controls.Add(Me.TxtCuenta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtClienteNombre)
        Me.GroupBox1.Controls.Add(Me.TxtStatus)
        Me.GroupBox1.Controls.Add(Me.TxtClienteClave)
        Me.GroupBox1.Controls.Add(Me.TxtMonto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtNumeroCheque)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(682, 198)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'BtnCliente
        '
        Me.BtnCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCliente.Location = New System.Drawing.Point(70, 160)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(75, 22)
        Me.BtnCliente.TabIndex = 6
        Me.BtnCliente.Text = "Busca Cliente"
        Me.BtnCliente.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(151, 88)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 4
        '
        'ComboBanco
        '
        Me.ComboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBanco.FormattingEnabled = True
        Me.ComboBanco.Location = New System.Drawing.Point(151, 53)
        Me.ComboBanco.Name = "ComboBanco"
        Me.ComboBanco.Size = New System.Drawing.Size(194, 21)
        Me.ComboBanco.TabIndex = 2
        '
        'TxtCuenta
        '
        Me.TxtCuenta.Enabled = False
        Me.TxtCuenta.Location = New System.Drawing.Point(351, 53)
        Me.TxtCuenta.Name = "TxtCuenta"
        Me.TxtCuenta.Size = New System.Drawing.Size(158, 20)
        Me.TxtCuenta.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Banco:"
        '
        'TxtClienteNombre
        '
        Me.TxtClienteNombre.Enabled = False
        Me.TxtClienteNombre.Location = New System.Drawing.Point(232, 162)
        Me.TxtClienteNombre.Name = "TxtClienteNombre"
        Me.TxtClienteNombre.Size = New System.Drawing.Size(444, 20)
        Me.TxtClienteNombre.TabIndex = 1
        '
        'TxtStatus
        '
        Me.TxtStatus.Enabled = False
        Me.TxtStatus.Location = New System.Drawing.Point(601, 17)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(75, 20)
        Me.TxtStatus.TabIndex = 1
        Me.TxtStatus.Text = "Pendiente"
        '
        'TxtClienteClave
        '
        Me.TxtClienteClave.Enabled = False
        Me.TxtClienteClave.Location = New System.Drawing.Point(151, 162)
        Me.TxtClienteClave.Name = "TxtClienteClave"
        Me.TxtClienteClave.Size = New System.Drawing.Size(75, 20)
        Me.TxtClienteClave.TabIndex = 1
        '
        'TxtMonto
        '
        Me.TxtMonto.Location = New System.Drawing.Point(151, 125)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(194, 20)
        Me.TxtMonto.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(553, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Status:"
        '
        'TxtNumeroCheque
        '
        Me.TxtNumeroCheque.Location = New System.Drawing.Point(151, 17)
        Me.TxtNumeroCheque.Name = "TxtNumeroCheque"
        Me.TxtNumeroCheque.Size = New System.Drawing.Size(194, 20)
        Me.TxtNumeroCheque.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Cliente:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Monto del Depósito:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Vencimiento:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número de Depósito:"
        '
        'ColMonto
        '
        Me.ColMonto.HeaderText = "Monto"
        Me.ColMonto.Name = "ColMonto"
        Me.ColMonto.ReadOnly = True
        '
        'ColAbonos
        '
        Me.ColAbonos.HeaderText = "Abonos"
        Me.ColAbonos.Name = "ColAbonos"
        Me.ColAbonos.ReadOnly = True
        '
        'ColFecha
        '
        Me.ColFecha.HeaderText = "Fecha"
        Me.ColFecha.Name = "ColFecha"
        Me.ColFecha.ReadOnly = True
        '
        'ColSaldo
        '
        Me.ColSaldo.HeaderText = "Saldo"
        Me.ColSaldo.Name = "ColSaldo"
        Me.ColSaldo.ReadOnly = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(18, 436)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 33)
        Me.BtnCancelar.TabIndex = 12
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'ColFactura
        '
        Me.ColFactura.HeaderText = "Documento"
        Me.ColFactura.Name = "ColFactura"
        Me.ColFactura.ReadOnly = True
        '
        'DataFacturas
        '
        Me.DataFacturas.AllowUserToAddRows = False
        Me.DataFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataFacturas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColFactura, Me.ColFecha, Me.ColMonto, Me.ColAbonos, Me.ColSaldo})
        Me.DataFacturas.Location = New System.Drawing.Point(6, 49)
        Me.DataFacturas.Name = "DataFacturas"
        Me.DataFacturas.ReadOnly = True
        Me.DataFacturas.Size = New System.Drawing.Size(670, 158)
        Me.DataFacturas.TabIndex = 0
        '
        'BtnFactura
        '
        Me.BtnFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFactura.Location = New System.Drawing.Point(6, 19)
        Me.BtnFactura.Name = "BtnFactura"
        Me.BtnFactura.Size = New System.Drawing.Size(113, 22)
        Me.BtnFactura.TabIndex = 7
        Me.BtnFactura.Text = "Agrega Factura"
        Me.BtnFactura.UseVisualStyleBackColor = True
        Me.BtnFactura.Visible = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAceptar.Location = New System.Drawing.Point(619, 436)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 33)
        Me.BtnAceptar.TabIndex = 13
        Me.BtnAceptar.Text = "Guardar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnQuitar)
        Me.GroupBox2.Controls.Add(Me.BtnFactura)
        Me.GroupBox2.Controls.Add(Me.DataFacturas)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 213)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(682, 217)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'TxtNumeroBanco
        '
        Me.TxtNumeroBanco.Enabled = False
        Me.TxtNumeroBanco.Location = New System.Drawing.Point(515, 53)
        Me.TxtNumeroBanco.Name = "TxtNumeroBanco"
        Me.TxtNumeroBanco.Size = New System.Drawing.Size(100, 20)
        Me.TxtNumeroBanco.TabIndex = 7
        '
        'BtnQuitar
        '
        Me.BtnQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnQuitar.Location = New System.Drawing.Point(563, 19)
        Me.BtnQuitar.Name = "BtnQuitar"
        Me.BtnQuitar.Size = New System.Drawing.Size(113, 22)
        Me.BtnQuitar.TabIndex = 8
        Me.BtnQuitar.Text = "Quitar Factura"
        Me.BtnQuitar.UseVisualStyleBackColor = True
        Me.BtnQuitar.Visible = False
        '
        'FrmNuevoCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 478)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmNuevoCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Depósito"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCliente As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBanco As System.Windows.Forms.ComboBox
    Friend WithEvents TxtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtClienteNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtStatus As System.Windows.Forms.TextBox
    Friend WithEvents TxtClienteClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAbonos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents ColFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents BtnFactura As System.Windows.Forms.Button
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNumeroBanco As System.Windows.Forms.TextBox
    Friend WithEvents BtnQuitar As System.Windows.Forms.Button
End Class
