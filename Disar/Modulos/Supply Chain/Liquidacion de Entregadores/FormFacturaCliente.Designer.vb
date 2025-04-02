<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFacturaCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFacturaCliente))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBusca = New System.Windows.Forms.TextBox
        Me.TextFacturas = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextNegocio = New System.Windows.Forms.TextBox
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.BtnSeleccionar = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 50)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(722, 240)
        Me.DataGridView1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(344, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cliente:"
        '
        'TextBusca
        '
        Me.TextBusca.Location = New System.Drawing.Point(389, 24)
        Me.TextBusca.Name = "TextBusca"
        Me.TextBusca.Size = New System.Drawing.Size(345, 20)
        Me.TextBusca.TabIndex = 4
        '
        'TextFacturas
        '
        Me.TextFacturas.Location = New System.Drawing.Point(12, 340)
        Me.TextFacturas.Multiline = True
        Me.TextFacturas.Name = "TextFacturas"
        Me.TextFacturas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextFacturas.Size = New System.Drawing.Size(374, 62)
        Me.TextFacturas.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 322)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Facturas:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(399, 322)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Nombre Negocio:"
        '
        'TextNegocio
        '
        Me.TextNegocio.Location = New System.Drawing.Point(402, 340)
        Me.TextNegocio.Name = "TextNegocio"
        Me.TextNegocio.Size = New System.Drawing.Size(161, 20)
        Me.TextNegocio.TabIndex = 4
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(649, 340)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(85, 62)
        Me.BtnGuardar.TabIndex = 7
        Me.BtnGuardar.Text = "Cargar Info de Facturas"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnSeleccionar
        '
        Me.BtnSeleccionar.Location = New System.Drawing.Point(12, 296)
        Me.BtnSeleccionar.Name = "BtnSeleccionar"
        Me.BtnSeleccionar.Size = New System.Drawing.Size(150, 23)
        Me.BtnSeleccionar.TabIndex = 8
        Me.BtnSeleccionar.Text = "Seleccionar"
        Me.BtnSeleccionar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(402, 378)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(48, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Vaciar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FormFacturaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 414)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BtnSeleccionar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextFacturas)
        Me.Controls.Add(Me.TextNegocio)
        Me.Controls.Add(Me.TextBusca)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormFacturaCliente"
        Me.Text = "Selección de Facturas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBusca As System.Windows.Forms.TextBox
    Friend WithEvents TextFacturas As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextNegocio As System.Windows.Forms.TextBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
