<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_NuevoPedido_Dimosa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_NuevoPedido_Dimosa))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.comboAlmacen = New System.Windows.Forms.ComboBox
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.col_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_Almacen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ClaveProv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Agregar = New System.Windows.Forms.Button
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextCantidad = New System.Windows.Forms.TextBox
        Me.ComboProv = New System.Windows.Forms.ComboBox
        Me.BtnCargaProducto = New System.Windows.Forms.Button
        Me.TextNombreProducto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextProducto = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnExcel = New System.Windows.Forms.Button
        Me.BtnDestinatarios = New System.Windows.Forms.Button
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Nacional", "Importación", "Cargill"})
        Me.ComboBox1.Location = New System.Drawing.Point(654, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(299, 21)
        Me.ComboBox1.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(563, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Tipo de Compra:"
        '
        'comboAlmacen
        '
        Me.comboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAlmacen.FormattingEnabled = True
        Me.comboAlmacen.Location = New System.Drawing.Point(99, 73)
        Me.comboAlmacen.Name = "comboAlmacen"
        Me.comboAlmacen.Size = New System.Drawing.Size(274, 21)
        Me.comboAlmacen.TabIndex = 12
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ID, Me.col_Nombre, Me.col_Cantidad, Me.col_Almacen, Me.ClaveProv})
        Me.DataDatos.Location = New System.Drawing.Point(12, 176)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.Size = New System.Drawing.Size(960, 468)
        Me.DataDatos.TabIndex = 20
        '
        'col_ID
        '
        Me.col_ID.HeaderText = "ID"
        Me.col_ID.Name = "col_ID"
        Me.col_ID.ReadOnly = True
        '
        'col_Nombre
        '
        Me.col_Nombre.HeaderText = "Nombre"
        Me.col_Nombre.Name = "col_Nombre"
        Me.col_Nombre.ReadOnly = True
        '
        'col_Cantidad
        '
        Me.col_Cantidad.HeaderText = "Cantidad"
        Me.col_Cantidad.Name = "col_Cantidad"
        Me.col_Cantidad.ReadOnly = True
        '
        'col_Almacen
        '
        Me.col_Almacen.HeaderText = "Almacén"
        Me.col_Almacen.Name = "col_Almacen"
        Me.col_Almacen.ReadOnly = True
        '
        'ClaveProv
        '
        Me.ClaveProv.HeaderText = "Clave Proveedor"
        Me.ClaveProv.Name = "ClaveProv"
        Me.ClaveProv.ReadOnly = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Almacén:"
        '
        'Button1
        '
        Me.Button1.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(846, 76)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 43)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Quitar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionado"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Agregar
        '
        Me.Agregar.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.Agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Agregar.Location = New System.Drawing.Point(733, 77)
        Me.Agregar.Name = "Agregar"
        Me.Agregar.Size = New System.Drawing.Size(107, 43)
        Me.Agregar.TabIndex = 8
        Me.Agregar.Text = "Agregar"
        Me.Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Agregar.UseVisualStyleBackColor = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(12, 650)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(96, 42)
        Me.BtnCancelar.TabIndex = 22
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_aceptar.Location = New System.Drawing.Point(833, 650)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(141, 42)
        Me.btn_aceptar.TabIndex = 21
        Me.btn_aceptar.Text = "Guardar y Enviar"
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(563, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cantidad:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnDestinatarios)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.comboAlmacen)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Agregar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextCantidad)
        Me.GroupBox1.Controls.Add(Me.ComboProv)
        Me.GroupBox1.Controls.Add(Me.BtnCargaProducto)
        Me.GroupBox1.Controls.Add(Me.TextNombreProducto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextProducto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(959, 125)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'TextCantidad
        '
        Me.TextCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCantidad.Location = New System.Drawing.Point(622, 98)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.Size = New System.Drawing.Size(86, 20)
        Me.TextCantidad.TabIndex = 6
        '
        'ComboProv
        '
        Me.ComboProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboProv.FormattingEnabled = True
        Me.ComboProv.Location = New System.Drawing.Point(99, 12)
        Me.ComboProv.Name = "ComboProv"
        Me.ComboProv.Size = New System.Drawing.Size(349, 21)
        Me.ComboProv.TabIndex = 5
        '
        'BtnCargaProducto
        '
        Me.BtnCargaProducto.Location = New System.Drawing.Point(479, 96)
        Me.BtnCargaProducto.Name = "BtnCargaProducto"
        Me.BtnCargaProducto.Size = New System.Drawing.Size(27, 23)
        Me.BtnCargaProducto.TabIndex = 4
        Me.BtnCargaProducto.Text = "..."
        Me.BtnCargaProducto.UseVisualStyleBackColor = True
        '
        'TextNombreProducto
        '
        Me.TextNombreProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNombreProducto.Location = New System.Drawing.Point(160, 98)
        Me.TextNombreProducto.Name = "TextNombreProducto"
        Me.TextNombreProducto.ReadOnly = True
        Me.TextNombreProducto.Size = New System.Drawing.Size(319, 20)
        Me.TextNombreProducto.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Producto:"
        '
        'TextProducto
        '
        Me.TextProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProducto.Location = New System.Drawing.Point(99, 98)
        Me.TextProducto.Name = "TextProducto"
        Me.TextProducto.ReadOnly = True
        Me.TextProducto.Size = New System.Drawing.Size(60, 20)
        Me.TextProducto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proveedor:"
        '
        'BtnExcel
        '
        Me.BtnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExcel.Location = New System.Drawing.Point(11, 153)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(116, 23)
        Me.BtnExcel.TabIndex = 24
        Me.BtnExcel.Text = "Cargar desde Excel..."
        Me.BtnExcel.UseVisualStyleBackColor = True
        '
        'BtnDestinatarios
        '
        Me.BtnDestinatarios.Image = Global.Disar.My.Resources.Resources.MailGreenHover
        Me.BtnDestinatarios.Location = New System.Drawing.Point(454, 11)
        Me.BtnDestinatarios.Name = "BtnDestinatarios"
        Me.BtnDestinatarios.Size = New System.Drawing.Size(52, 23)
        Me.BtnDestinatarios.TabIndex = 16
        Me.BtnDestinatarios.UseVisualStyleBackColor = True
        '
        'frm_NuevoPedido_Dimosa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 704)
        Me.Controls.Add(Me.DataDatos)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnExcel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_NuevoPedido_Dimosa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Pedido DIMOSA"
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents comboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents col_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Almacen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClaveProv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Agregar As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents ComboProv As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCargaProducto As System.Windows.Forms.Button
    Friend WithEvents TextNombreProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnExcel As System.Windows.Forms.Button
    Friend WithEvents BtnDestinatarios As System.Windows.Forms.Button
End Class
