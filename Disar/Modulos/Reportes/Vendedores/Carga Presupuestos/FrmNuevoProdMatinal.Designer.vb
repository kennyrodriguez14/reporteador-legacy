<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNuevoProdMatinal
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
        Me.Cancelar = New System.Windows.Forms.Button
        Me.Guardar = New System.Windows.Forms.Button
        Me.ComboCalculo = New System.Windows.Forms.ComboBox
        Me.TextNombre = New System.Windows.Forms.TextBox
        Me.TextCantidad = New System.Windows.Forms.TextBox
        Me.TextBusca = New System.Windows.Forms.TextBox
        Me.TextClave = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkTodos = New System.Windows.Forms.CheckBox
        Me.DataVendedores = New System.Windows.Forms.DataGridView
        Me.DataProductos = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BuscaVend = New System.Windows.Forms.TextBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        CType(Me.DataVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cancelar
        '
        Me.Cancelar.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.Cancelar.Location = New System.Drawing.Point(956, 137)
        Me.Cancelar.Name = "Cancelar"
        Me.Cancelar.Size = New System.Drawing.Size(75, 62)
        Me.Cancelar.TabIndex = 25
        Me.Cancelar.Text = "Cancelar"
        Me.Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Cancelar.UseVisualStyleBackColor = True
        '
        'Guardar
        '
        Me.Guardar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.Guardar.Location = New System.Drawing.Point(956, 60)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(75, 62)
        Me.Guardar.TabIndex = 26
        Me.Guardar.Text = "Guardar"
        Me.Guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'ComboCalculo
        '
        Me.ComboCalculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCalculo.FormattingEnabled = True
        Me.ComboCalculo.Items.AddRange(New Object() {"Lempiras", "Unidades", "Cajas", "Quintales"})
        Me.ComboCalculo.Location = New System.Drawing.Point(670, 128)
        Me.ComboCalculo.Name = "ComboCalculo"
        Me.ComboCalculo.Size = New System.Drawing.Size(185, 21)
        Me.ComboCalculo.TabIndex = 23
        '
        'TextNombre
        '
        Me.TextNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNombre.Location = New System.Drawing.Point(670, 83)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.ReadOnly = True
        Me.TextNombre.Size = New System.Drawing.Size(248, 20)
        Me.TextNombre.TabIndex = 19
        '
        'TextCantidad
        '
        Me.TextCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCantidad.Location = New System.Drawing.Point(660, 211)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.Size = New System.Drawing.Size(185, 20)
        Me.TextCantidad.TabIndex = 22
        '
        'TextBusca
        '
        Me.TextBusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBusca.Location = New System.Drawing.Point(110, 18)
        Me.TextBusca.Name = "TextBusca"
        Me.TextBusca.Size = New System.Drawing.Size(306, 20)
        Me.TextBusca.TabIndex = 21
        '
        'TextClave
        '
        Me.TextClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextClave.Location = New System.Drawing.Point(670, 61)
        Me.TextClave.Name = "TextClave"
        Me.TextClave.ReadOnly = True
        Me.TextClave.Size = New System.Drawing.Size(247, 20)
        Me.TextClave.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 253)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Vendedores a los que se asignará:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(660, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Cantidad Meta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(668, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Medio de cálculo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Buscar Producto:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(667, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Producto:"
        '
        'ChkTodos
        '
        Me.ChkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTodos.AutoSize = True
        Me.ChkTodos.Location = New System.Drawing.Point(932, 252)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(99, 17)
        Me.ChkTodos.TabIndex = 13
        Me.ChkTodos.Text = "Asignar a todos"
        Me.ChkTodos.UseVisualStyleBackColor = True
        Me.ChkTodos.Visible = False
        '
        'DataVendedores
        '
        Me.DataVendedores.AllowUserToAddRows = False
        Me.DataVendedores.AllowUserToDeleteRows = False
        Me.DataVendedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataVendedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataVendedores.Location = New System.Drawing.Point(15, 276)
        Me.DataVendedores.Name = "DataVendedores"
        Me.DataVendedores.RowHeadersVisible = False
        Me.DataVendedores.Size = New System.Drawing.Size(1016, 238)
        Me.DataVendedores.TabIndex = 12
        '
        'DataProductos
        '
        Me.DataProductos.AllowUserToAddRows = False
        Me.DataProductos.AllowUserToDeleteRows = False
        Me.DataProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataProductos.Location = New System.Drawing.Point(15, 44)
        Me.DataProductos.Name = "DataProductos"
        Me.DataProductos.ReadOnly = True
        Me.DataProductos.Size = New System.Drawing.Size(646, 191)
        Me.DataProductos.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.TextCantidad)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(913, 237)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Disar.My.Resources.Resources.img_modulo_monitoreo
        Me.PictureBox1.Location = New System.Drawing.Point(412, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 33)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'BuscaVend
        '
        Me.BuscaVend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscaVend.Location = New System.Drawing.Point(191, 250)
        Me.BuscaVend.Name = "BuscaVend"
        Me.BuscaVend.Size = New System.Drawing.Size(228, 20)
        Me.BuscaVend.TabIndex = 27
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Disar.My.Resources.Resources.img_modulo_monitoreo
        Me.PictureBox2.Location = New System.Drawing.Point(422, 244)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(31, 33)
        Me.PictureBox2.TabIndex = 28
        Me.PictureBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(658, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Aplicar desde:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(660, 170)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(185, 20)
        Me.DateTimePicker1.TabIndex = 24
        '
        'FrmNuevoProdMatinal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 519)
        Me.Controls.Add(Me.BuscaVend)
        Me.Controls.Add(Me.Cancelar)
        Me.Controls.Add(Me.Guardar)
        Me.Controls.Add(Me.ComboCalculo)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.TextBusca)
        Me.Controls.Add(Me.TextClave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChkTodos)
        Me.Controls.Add(Me.DataVendedores)
        Me.Controls.Add(Me.DataProductos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmNuevoProdMatinal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNuevoProdMatinal"
        CType(Me.DataVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancelar As System.Windows.Forms.Button
    Friend WithEvents Guardar As System.Windows.Forms.Button
    Friend WithEvents ComboCalculo As System.Windows.Forms.ComboBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TextBusca As System.Windows.Forms.TextBox
    Friend WithEvents TextClave As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents DataVendedores As System.Windows.Forms.DataGridView
    Friend WithEvents DataProductos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BuscaVend As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
