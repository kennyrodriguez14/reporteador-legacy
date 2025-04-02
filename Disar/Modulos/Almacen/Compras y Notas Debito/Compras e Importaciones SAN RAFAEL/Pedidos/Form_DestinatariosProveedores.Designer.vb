<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_DestinatariosProveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_DestinatariosProveedores))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.colCorreo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColTipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextProveedor = New System.Windows.Forms.TextBox
        Me.TextEmpresa = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextProveedorID = New System.Windows.Forms.TextBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCorreo, Me.ColTipo})
        Me.DataGridView1.Location = New System.Drawing.Point(14, 70)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(475, 544)
        Me.DataGridView1.TabIndex = 0
        '
        'colCorreo
        '
        Me.colCorreo.HeaderText = "Correo"
        Me.colCorreo.Name = "colCorreo"
        '
        'ColTipo
        '
        Me.ColTipo.HeaderText = "Tipo"
        Me.ColTipo.Items.AddRange(New Object() {"Principal", "Copia"})
        Me.ColTipo.Name = "ColTipo"
        Me.ColTipo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Proveedor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Empresa:"
        '
        'TextProveedor
        '
        Me.TextProveedor.Enabled = False
        Me.TextProveedor.Location = New System.Drawing.Point(145, 15)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.Size = New System.Drawing.Size(220, 20)
        Me.TextProveedor.TabIndex = 3
        '
        'TextEmpresa
        '
        Me.TextEmpresa.Enabled = False
        Me.TextEmpresa.Location = New System.Drawing.Point(78, 41)
        Me.TextEmpresa.Name = "TextEmpresa"
        Me.TextEmpresa.Size = New System.Drawing.Size(174, 20)
        Me.TextEmpresa.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(281, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextProveedorID
        '
        Me.TextProveedorID.Enabled = False
        Me.TextProveedorID.Location = New System.Drawing.Point(78, 15)
        Me.TextProveedorID.Name = "TextProveedorID"
        Me.TextProveedorID.Size = New System.Drawing.Size(61, 20)
        Me.TextProveedorID.TabIndex = 6
        '
        'Form_DestinatariosProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 626)
        Me.Controls.Add(Me.TextProveedorID)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextEmpresa)
        Me.Controls.Add(Me.TextProveedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_DestinatariosProveedores"
        Me.Text = "Listado de Destinatarios"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents colCorreo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TextProveedor As System.Windows.Forms.TextBox
    Friend WithEvents TextEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextProveedorID As System.Windows.Forms.TextBox
End Class
