<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Clientes_Agro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Clientes_Agro))
        Me.ComboDíaVisita = New System.Windows.Forms.ComboBox
        Me.ComboVendedor = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBusca = New System.Windows.Forms.TextBox
        Me.BtnGenerar = New System.Windows.Forms.Button
        Me.DataClientes = New System.Windows.Forms.DataGridView
        CType(Me.DataClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboDíaVisita
        '
        Me.ComboDíaVisita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDíaVisita.FormattingEnabled = True
        Me.ComboDíaVisita.Location = New System.Drawing.Point(321, 26)
        Me.ComboDíaVisita.Name = "ComboDíaVisita"
        Me.ComboDíaVisita.Size = New System.Drawing.Size(157, 21)
        Me.ComboDíaVisita.TabIndex = 11
        '
        'ComboVendedor
        '
        Me.ComboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVendedor.FormattingEnabled = True
        Me.ComboVendedor.Location = New System.Drawing.Point(156, 26)
        Me.ComboVendedor.Name = "ComboVendedor"
        Me.ComboVendedor.Size = New System.Drawing.Size(157, 21)
        Me.ComboVendedor.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(549, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 12)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Filtrar por Nombre / ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(319, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Filtrar por día de visita:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(154, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Filtrar por Vendedor:"
        '
        'TextBusca
        '
        Me.TextBusca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBusca.Location = New System.Drawing.Point(551, 28)
        Me.TextBusca.Name = "TextBusca"
        Me.TextBusca.Size = New System.Drawing.Size(221, 20)
        Me.TextBusca.TabIndex = 7
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Location = New System.Drawing.Point(12, 11)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(135, 38)
        Me.BtnGenerar.TabIndex = 6
        Me.BtnGenerar.Text = "Actualizar Clientes"
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'DataClientes
        '
        Me.DataClientes.AllowUserToAddRows = False
        Me.DataClientes.AllowUserToDeleteRows = False
        Me.DataClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataClientes.Location = New System.Drawing.Point(12, 55)
        Me.DataClientes.Name = "DataClientes"
        Me.DataClientes.ReadOnly = True
        Me.DataClientes.RowHeadersVisible = False
        Me.DataClientes.Size = New System.Drawing.Size(760, 318)
        Me.DataClientes.TabIndex = 5
        '
        'Clientes_Agro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 384)
        Me.Controls.Add(Me.ComboDíaVisita)
        Me.Controls.Add(Me.ComboVendedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBusca)
        Me.Controls.Add(Me.BtnGenerar)
        Me.Controls.Add(Me.DataClientes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Clientes_Agro"
        Me.Text = "Clientes Agro"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboDíaVisita As System.Windows.Forms.ComboBox
    Friend WithEvents ComboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBusca As System.Windows.Forms.TextBox
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents DataClientes As System.Windows.Forms.DataGridView
End Class
