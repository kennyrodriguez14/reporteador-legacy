<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAceptaCheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAceptaCheque))
        Me.DataFacturas = New System.Windows.Forms.DataGridView
        Me.ColFactura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColMonto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColAbonos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COLPAGO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnAprobar = New System.Windows.Forms.Button
        Me.LCliente = New System.Windows.Forms.Label
        Me.LMonto = New System.Windows.Forms.Label
        Me.Carga = New System.Windows.Forms.DataGridView
        Me.LCheque = New System.Windows.Forms.Label
        Me.Cuenta = New System.Windows.Forms.Label
        Me.NumeroBan = New System.Windows.Forms.Label
        Me.Almacen = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.DataFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Carga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataFacturas
        '
        Me.DataFacturas.AllowUserToAddRows = False
        Me.DataFacturas.AllowUserToDeleteRows = False
        Me.DataFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataFacturas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColFactura, Me.ColMonto, Me.ColAbonos, Me.ColSaldo, Me.COLPAGO})
        Me.DataFacturas.Location = New System.Drawing.Point(12, 86)
        Me.DataFacturas.Name = "DataFacturas"
        Me.DataFacturas.Size = New System.Drawing.Size(842, 158)
        Me.DataFacturas.TabIndex = 1
        '
        'ColFactura
        '
        Me.ColFactura.HeaderText = "Documento"
        Me.ColFactura.Name = "ColFactura"
        Me.ColFactura.ReadOnly = True
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
        'ColSaldo
        '
        Me.ColSaldo.HeaderText = "Saldo"
        Me.ColSaldo.Name = "ColSaldo"
        Me.ColSaldo.ReadOnly = True
        '
        'COLPAGO
        '
        Me.COLPAGO.HeaderText = "Pago"
        Me.COLPAGO.Name = "COLPAGO"
        Me.COLPAGO.ToolTipText = "Cantidad de dinero que abonará a la factura"
        '
        'BtnAprobar
        '
        Me.BtnAprobar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAprobar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.BtnAprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAprobar.Location = New System.Drawing.Point(729, 250)
        Me.BtnAprobar.Name = "BtnAprobar"
        Me.BtnAprobar.Size = New System.Drawing.Size(125, 39)
        Me.BtnAprobar.TabIndex = 2
        Me.BtnAprobar.Text = "Enviar  a SAE"
        Me.BtnAprobar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAprobar.UseVisualStyleBackColor = True
        '
        'LCliente
        '
        Me.LCliente.AutoSize = True
        Me.LCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCliente.Location = New System.Drawing.Point(12, 11)
        Me.LCliente.Name = "LCliente"
        Me.LCliente.Size = New System.Drawing.Size(51, 15)
        Me.LCliente.TabIndex = 3
        Me.LCliente.Text = "Label1"
        '
        'LMonto
        '
        Me.LMonto.AutoSize = True
        Me.LMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LMonto.Location = New System.Drawing.Point(12, 62)
        Me.LMonto.Name = "LMonto"
        Me.LMonto.Size = New System.Drawing.Size(51, 15)
        Me.LMonto.TabIndex = 3
        Me.LMonto.Text = "Label1"
        '
        'Carga
        '
        Me.Carga.AllowUserToAddRows = False
        Me.Carga.AllowUserToDeleteRows = False
        Me.Carga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Carga.Location = New System.Drawing.Point(317, 215)
        Me.Carga.Name = "Carga"
        Me.Carga.ReadOnly = True
        Me.Carga.Size = New System.Drawing.Size(240, 21)
        Me.Carga.TabIndex = 4
        '
        'LCheque
        '
        Me.LCheque.AutoSize = True
        Me.LCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCheque.Location = New System.Drawing.Point(12, 37)
        Me.LCheque.Name = "LCheque"
        Me.LCheque.Size = New System.Drawing.Size(51, 15)
        Me.LCheque.TabIndex = 3
        Me.LCheque.Text = "Label1"
        '
        'Cuenta
        '
        Me.Cuenta.AutoSize = True
        Me.Cuenta.Location = New System.Drawing.Point(737, 13)
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.Size = New System.Drawing.Size(75, 13)
        Me.Cuenta.TabIndex = 5
        Me.Cuenta.Text = "Cuenta Banco"
        '
        'NumeroBan
        '
        Me.NumeroBan.AutoSize = True
        Me.NumeroBan.Location = New System.Drawing.Point(737, 39)
        Me.NumeroBan.Name = "NumeroBan"
        Me.NumeroBan.Size = New System.Drawing.Size(78, 13)
        Me.NumeroBan.TabIndex = 6
        Me.NumeroBan.Text = "Numero Banco"
        '
        'Almacen
        '
        Me.Almacen.AutoSize = True
        Me.Almacen.Location = New System.Drawing.Point(737, 64)
        Me.Almacen.Name = "Almacen"
        Me.Almacen.Size = New System.Drawing.Size(48, 13)
        Me.Almacen.TabIndex = 7
        Me.Almacen.Text = "Almacén"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(686, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Cuenta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(686, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Nº Banco:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(686, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Almacén:"
        '
        'FrmAceptaCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 297)
        Me.Controls.Add(Me.Almacen)
        Me.Controls.Add(Me.NumeroBan)
        Me.Controls.Add(Me.Cuenta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LCheque)
        Me.Controls.Add(Me.LMonto)
        Me.Controls.Add(Me.LCliente)
        Me.Controls.Add(Me.BtnAprobar)
        Me.Controls.Add(Me.DataFacturas)
        Me.Controls.Add(Me.Carga)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAceptaCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enviar Pago a SAE"
        CType(Me.DataFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Carga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents BtnAprobar As System.Windows.Forms.Button
    Friend WithEvents LCliente As System.Windows.Forms.Label
    Friend WithEvents LMonto As System.Windows.Forms.Label
    Friend WithEvents ColFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAbonos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COLPAGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Carga As System.Windows.Forms.DataGridView
    Friend WithEvents LCheque As System.Windows.Forms.Label
    Friend WithEvents Cuenta As System.Windows.Forms.Label
    Friend WithEvents NumeroBan As System.Windows.Forms.Label
    Friend WithEvents Almacen As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
