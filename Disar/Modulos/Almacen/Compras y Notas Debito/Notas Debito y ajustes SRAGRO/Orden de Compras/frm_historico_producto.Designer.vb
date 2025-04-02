<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_historico_producto
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
        Me.grp_filtros = New System.Windows.Forms.GroupBox
        Me.grd_producto = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_buqueda = New System.Windows.Forms.TextBox
        Me.grp_datos_producto = New System.Windows.Forms.GroupBox
        Me.cmb_uni = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_dias_hab = New System.Windows.Forms.TextBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_producto = New System.Windows.Forms.TextBox
        Me.txt_precio_neg = New System.Windows.Forms.TextBox
        Me.txt_pedido = New System.Windows.Forms.TextBox
        Me.txt_dias_aut = New System.Windows.Forms.TextBox
        Me.txt_existencia_gracias = New System.Windows.Forms.TextBox
        Me.txt_existencia_cd = New System.Windows.Forms.TextBox
        Me.txt_existencia_src = New System.Windows.Forms.TextBox
        Me.txt_existencia = New System.Windows.Forms.TextBox
        Me.txt_sugtri = New System.Windows.Forms.TextBox
        Me.txt_dias_inve = New System.Windows.Forms.TextBox
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.grd_precios = New System.Windows.Forms.DataGridView
        Me.grp_filtros.SuspendLayout()
        CType(Me.grd_producto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_datos_producto.SuspendLayout()
        CType(Me.grd_precios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp_filtros
        '
        Me.grp_filtros.Controls.Add(Me.grd_producto)
        Me.grp_filtros.Controls.Add(Me.Label1)
        Me.grp_filtros.Controls.Add(Me.txt_buqueda)
        Me.grp_filtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_filtros.Location = New System.Drawing.Point(14, 12)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(623, 562)
        Me.grp_filtros.TabIndex = 0
        Me.grp_filtros.TabStop = False
        '
        'grd_producto
        '
        Me.grd_producto.AllowUserToAddRows = False
        Me.grd_producto.AllowUserToDeleteRows = False
        Me.grd_producto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_producto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_producto.Location = New System.Drawing.Point(7, 43)
        Me.grd_producto.Name = "grd_producto"
        Me.grd_producto.ReadOnly = True
        Me.grd_producto.RowHeadersVisible = False
        Me.grd_producto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_producto.Size = New System.Drawing.Size(609, 513)
        Me.grd_producto.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Producto:"
        '
        'txt_buqueda
        '
        Me.txt_buqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_buqueda.Location = New System.Drawing.Point(130, 17)
        Me.txt_buqueda.Name = "txt_buqueda"
        Me.txt_buqueda.Size = New System.Drawing.Size(380, 20)
        Me.txt_buqueda.TabIndex = 22
        '
        'grp_datos_producto
        '
        Me.grp_datos_producto.Controls.Add(Me.cmb_uni)
        Me.grp_datos_producto.Controls.Add(Me.Label13)
        Me.grp_datos_producto.Controls.Add(Me.Label9)
        Me.grp_datos_producto.Controls.Add(Me.txt_dias_hab)
        Me.grp_datos_producto.Controls.Add(Me.btn_cancelar)
        Me.grp_datos_producto.Controls.Add(Me.btn_aceptar)
        Me.grp_datos_producto.Controls.Add(Me.Label8)
        Me.grp_datos_producto.Controls.Add(Me.Label7)
        Me.grp_datos_producto.Controls.Add(Me.Label10)
        Me.grp_datos_producto.Controls.Add(Me.Label12)
        Me.grp_datos_producto.Controls.Add(Me.Label14)
        Me.grp_datos_producto.Controls.Add(Me.Label11)
        Me.grp_datos_producto.Controls.Add(Me.Label6)
        Me.grp_datos_producto.Controls.Add(Me.Label5)
        Me.grp_datos_producto.Controls.Add(Me.Label4)
        Me.grp_datos_producto.Controls.Add(Me.Label3)
        Me.grp_datos_producto.Controls.Add(Me.Label2)
        Me.grp_datos_producto.Controls.Add(Me.txt_producto)
        Me.grp_datos_producto.Controls.Add(Me.txt_precio_neg)
        Me.grp_datos_producto.Controls.Add(Me.txt_pedido)
        Me.grp_datos_producto.Controls.Add(Me.txt_dias_aut)
        Me.grp_datos_producto.Controls.Add(Me.txt_existencia_gracias)
        Me.grp_datos_producto.Controls.Add(Me.txt_existencia_cd)
        Me.grp_datos_producto.Controls.Add(Me.txt_existencia_src)
        Me.grp_datos_producto.Controls.Add(Me.txt_existencia)
        Me.grp_datos_producto.Controls.Add(Me.txt_sugtri)
        Me.grp_datos_producto.Controls.Add(Me.txt_dias_inve)
        Me.grp_datos_producto.Controls.Add(Me.txt_codigo)
        Me.grp_datos_producto.Controls.Add(Me.grd_precios)
        Me.grp_datos_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_datos_producto.Location = New System.Drawing.Point(18, 2)
        Me.grp_datos_producto.Name = "grp_datos_producto"
        Me.grp_datos_producto.Size = New System.Drawing.Size(614, 566)
        Me.grp_datos_producto.TabIndex = 2
        Me.grp_datos_producto.TabStop = False
        Me.grp_datos_producto.Visible = False
        '
        'cmb_uni
        '
        Me.cmb_uni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_uni.FormattingEnabled = True
        Me.cmb_uni.Items.AddRange(New Object() {"pz", "cj"})
        Me.cmb_uni.Location = New System.Drawing.Point(510, 454)
        Me.cmb_uni.Name = "cmb_uni"
        Me.cmb_uni.Size = New System.Drawing.Size(91, 21)
        Me.cmb_uni.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(476, 457)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Uni:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(426, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Dias habiles:"
        '
        'txt_dias_hab
        '
        Me.txt_dias_hab.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dias_hab.Location = New System.Drawing.Point(510, 54)
        Me.txt_dias_hab.Name = "txt_dias_hab"
        Me.txt_dias_hab.ReadOnly = True
        Me.txt_dias_hab.Size = New System.Drawing.Size(91, 26)
        Me.txt_dias_hab.TabIndex = 26
        Me.txt_dias_hab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Location = New System.Drawing.Point(517, 524)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(84, 36)
        Me.btn_cancelar.TabIndex = 25
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(394, 524)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(84, 36)
        Me.btn_aceptar.TabIndex = 25
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(396, 422)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Precio negociado:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(456, 382)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Pedido:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(400, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Dias Autorizados:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(417, 220)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Exist. Gracias:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(443, 302)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Exist. CD:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(435, 262)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Exist. SRC:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(437, 340)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Existencia:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(445, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Sugerido:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(391, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Dias de Inventario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Producto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Venta ultimo año:"
        '
        'txt_producto
        '
        Me.txt_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_producto.Location = New System.Drawing.Point(181, 11)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.ReadOnly = True
        Me.txt_producto.Size = New System.Drawing.Size(427, 26)
        Me.txt_producto.TabIndex = 22
        '
        'txt_precio_neg
        '
        Me.txt_precio_neg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_precio_neg.Location = New System.Drawing.Point(510, 414)
        Me.txt_precio_neg.Name = "txt_precio_neg"
        Me.txt_precio_neg.ReadOnly = True
        Me.txt_precio_neg.Size = New System.Drawing.Size(91, 26)
        Me.txt_precio_neg.TabIndex = 22
        Me.txt_precio_neg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_pedido
        '
        Me.txt_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pedido.Location = New System.Drawing.Point(510, 374)
        Me.txt_pedido.Name = "txt_pedido"
        Me.txt_pedido.Size = New System.Drawing.Size(91, 26)
        Me.txt_pedido.TabIndex = 22
        Me.txt_pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_dias_aut
        '
        Me.txt_dias_aut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dias_aut.Location = New System.Drawing.Point(510, 94)
        Me.txt_dias_aut.Name = "txt_dias_aut"
        Me.txt_dias_aut.ReadOnly = True
        Me.txt_dias_aut.Size = New System.Drawing.Size(91, 26)
        Me.txt_dias_aut.TabIndex = 22
        Me.txt_dias_aut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_existencia_gracias
        '
        Me.txt_existencia_gracias.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_existencia_gracias.Location = New System.Drawing.Point(510, 214)
        Me.txt_existencia_gracias.Name = "txt_existencia_gracias"
        Me.txt_existencia_gracias.ReadOnly = True
        Me.txt_existencia_gracias.Size = New System.Drawing.Size(91, 26)
        Me.txt_existencia_gracias.TabIndex = 22
        Me.txt_existencia_gracias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_existencia_cd
        '
        Me.txt_existencia_cd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_existencia_cd.Location = New System.Drawing.Point(510, 294)
        Me.txt_existencia_cd.Name = "txt_existencia_cd"
        Me.txt_existencia_cd.ReadOnly = True
        Me.txt_existencia_cd.Size = New System.Drawing.Size(91, 26)
        Me.txt_existencia_cd.TabIndex = 22
        Me.txt_existencia_cd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_existencia_src
        '
        Me.txt_existencia_src.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_existencia_src.Location = New System.Drawing.Point(510, 254)
        Me.txt_existencia_src.Name = "txt_existencia_src"
        Me.txt_existencia_src.ReadOnly = True
        Me.txt_existencia_src.Size = New System.Drawing.Size(91, 26)
        Me.txt_existencia_src.TabIndex = 22
        Me.txt_existencia_src.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_existencia
        '
        Me.txt_existencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_existencia.Location = New System.Drawing.Point(510, 334)
        Me.txt_existencia.Name = "txt_existencia"
        Me.txt_existencia.ReadOnly = True
        Me.txt_existencia.Size = New System.Drawing.Size(91, 26)
        Me.txt_existencia.TabIndex = 22
        Me.txt_existencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_sugtri
        '
        Me.txt_sugtri.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sugtri.Location = New System.Drawing.Point(510, 174)
        Me.txt_sugtri.Name = "txt_sugtri"
        Me.txt_sugtri.ReadOnly = True
        Me.txt_sugtri.Size = New System.Drawing.Size(91, 26)
        Me.txt_sugtri.TabIndex = 22
        Me.txt_sugtri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_dias_inve
        '
        Me.txt_dias_inve.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dias_inve.Location = New System.Drawing.Point(510, 134)
        Me.txt_dias_inve.Name = "txt_dias_inve"
        Me.txt_dias_inve.ReadOnly = True
        Me.txt_dias_inve.Size = New System.Drawing.Size(91, 26)
        Me.txt_dias_inve.TabIndex = 22
        Me.txt_dias_inve.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_codigo
        '
        Me.txt_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.Location = New System.Drawing.Point(69, 11)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.ReadOnly = True
        Me.txt_codigo.Size = New System.Drawing.Size(106, 26)
        Me.txt_codigo.TabIndex = 22
        '
        'grd_precios
        '
        Me.grd_precios.AllowUserToAddRows = False
        Me.grd_precios.AllowUserToDeleteRows = False
        Me.grd_precios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_precios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_precios.Location = New System.Drawing.Point(7, 54)
        Me.grd_precios.MultiSelect = False
        Me.grd_precios.Name = "grd_precios"
        Me.grd_precios.ReadOnly = True
        Me.grd_precios.RowHeadersVisible = False
        Me.grd_precios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_precios.Size = New System.Drawing.Size(382, 506)
        Me.grd_precios.TabIndex = 19
        '
        'frm_historico_producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 586)
        Me.Controls.Add(Me.grp_datos_producto)
        Me.Controls.Add(Me.grp_filtros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frm_historico_producto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Historial del Producto"
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        CType(Me.grd_producto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_datos_producto.ResumeLayout(False)
        Me.grp_datos_producto.PerformLayout()
        CType(Me.grd_precios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_buqueda As System.Windows.Forms.TextBox
    Friend WithEvents grp_datos_producto As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_producto As System.Windows.Forms.TextBox
    Friend WithEvents txt_dias_inve As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents grd_precios As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_pedido As System.Windows.Forms.TextBox
    Friend WithEvents txt_existencia As System.Windows.Forms.TextBox
    Friend WithEvents txt_sugtri As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_precio_neg As System.Windows.Forms.TextBox
    Friend WithEvents grd_producto As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_dias_hab As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_dias_aut As System.Windows.Forms.TextBox
    Friend WithEvents cmb_uni As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_existencia_gracias As System.Windows.Forms.TextBox
    Friend WithEvents txt_existencia_src As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_existencia_cd As System.Windows.Forms.TextBox
End Class
