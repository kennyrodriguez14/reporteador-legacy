<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_detalle_opl
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_detalle_opl))
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox()
        Me.txt_cve_vend = New System.Windows.Forms.TextBox()
        Me.txt_estado = New System.Windows.Forms.TextBox()
        Me.txt_tipo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_numero_factura = New System.Windows.Forms.TextBox()
        Me.btn_eliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_modifcar = New System.Windows.Forms.ToolStripButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_codigo_cliente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_enviar = New System.Windows.Forms.ToolStripButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grd_lista = New System.Windows.Forms.DataGridView()
        Me.txt_num_alma = New System.Windows.Forms.TextBox()
        Me.txt_sucursal = New System.Windows.Forms.TextBox()
        Me.txt_fecha = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_num_registro = New System.Windows.Forms.TextBox()
        Me.lbl_codigo = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.grp_ingreso_datos = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_ingreso_datos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(483, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(62, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sucursal:"
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombre_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(341, 24)
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.ReadOnly = True
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(387, 20)
        Me.txt_nombre_cliente.TabIndex = 3
        '
        'txt_cve_vend
        '
        Me.txt_cve_vend.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_cve_vend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cve_vend.Location = New System.Drawing.Point(495, 78)
        Me.txt_cve_vend.Name = "txt_cve_vend"
        Me.txt_cve_vend.ReadOnly = True
        Me.txt_cve_vend.Size = New System.Drawing.Size(46, 20)
        Me.txt_cve_vend.TabIndex = 9
        '
        'txt_estado
        '
        Me.txt_estado.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_estado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_estado.Location = New System.Drawing.Point(608, 78)
        Me.txt_estado.Name = "txt_estado"
        Me.txt_estado.ReadOnly = True
        Me.txt_estado.Size = New System.Drawing.Size(120, 20)
        Me.txt_estado.TabIndex = 9
        '
        'txt_tipo
        '
        Me.txt_tipo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tipo.Location = New System.Drawing.Point(350, 77)
        Me.txt_tipo.Name = "txt_tipo"
        Me.txt_tipo.ReadOnly = True
        Me.txt_tipo.Size = New System.Drawing.Size(71, 20)
        Me.txt_tipo.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(428, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Vendedor:"
        '
        'txt_numero_factura
        '
        Me.txt_numero_factura.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_numero_factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numero_factura.Location = New System.Drawing.Point(128, 77)
        Me.txt_numero_factura.Name = "txt_numero_factura"
        Me.txt_numero_factura.ReadOnly = True
        Me.txt_numero_factura.Size = New System.Drawing.Size(133, 20)
        Me.txt_numero_factura.TabIndex = 8
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Image = Global.Disar.My.Resources.Resources.Delete_32
        Me.btn_eliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(86, 36)
        Me.btn_eliminar.Text = "Eliminar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'btn_modifcar
        '
        Me.btn_modifcar.Image = CType(resources.GetObject("btn_modifcar.Image"), System.Drawing.Image)
        Me.btn_modifcar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_modifcar.Name = "btn_modifcar"
        Me.btn_modifcar.Size = New System.Drawing.Size(78, 36)
        Me.btn_modifcar.Text = "Modificar"
        Me.btn_modifcar.Visible = False
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(549, 558)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 17)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Valor Total:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(552, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Estado:"
        '
        'txt_codigo_cliente
        '
        Me.txt_codigo_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_cliente.Location = New System.Drawing.Point(263, 25)
        Me.txt_codigo_cliente.Name = "txt_codigo_cliente"
        Me.txt_codigo_cliente.ReadOnly = True
        Me.txt_codigo_cliente.Size = New System.Drawing.Size(72, 20)
        Me.txt_codigo_cliente.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(264, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tipo de Pago:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_enviar, Me.ToolStripSeparator1, Me.btn_eliminar, Me.ToolStripSeparator2, Me.btn_modifcar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(810, 39)
        Me.ToolStrip1.TabIndex = 34
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_enviar
        '
        Me.btn_enviar.Enabled = False
        Me.btn_enviar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_enviar.Image = Global.Disar.My.Resources.Resources.SAE
        Me.btn_enviar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_enviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_enviar.Name = "btn_enviar"
        Me.btn_enviar.Size = New System.Drawing.Size(107, 36)
        Me.btn_enviar.Text = "Envio a SAE"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(50, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nº Factura:"
        '
        'grd_lista
        '
        Me.grd_lista.AllowUserToAddRows = False
        Me.grd_lista.AllowUserToDeleteRows = False
        Me.grd_lista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_lista.Location = New System.Drawing.Point(14, 155)
        Me.grd_lista.Name = "grd_lista"
        Me.grd_lista.ReadOnly = True
        Me.grd_lista.Size = New System.Drawing.Size(785, 394)
        Me.grd_lista.TabIndex = 31
        '
        'txt_num_alma
        '
        Me.txt_num_alma.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_num_alma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_num_alma.Location = New System.Drawing.Point(128, 51)
        Me.txt_num_alma.Name = "txt_num_alma"
        Me.txt_num_alma.ReadOnly = True
        Me.txt_num_alma.Size = New System.Drawing.Size(56, 20)
        Me.txt_num_alma.TabIndex = 6
        '
        'txt_sucursal
        '
        Me.txt_sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_sucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sucursal.Location = New System.Drawing.Point(190, 51)
        Me.txt_sucursal.Name = "txt_sucursal"
        Me.txt_sucursal.ReadOnly = True
        Me.txt_sucursal.Size = New System.Drawing.Size(287, 20)
        Me.txt_sucursal.TabIndex = 6
        '
        'txt_fecha
        '
        Me.txt_fecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fecha.Location = New System.Drawing.Point(535, 51)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(193, 20)
        Me.txt_fecha.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(211, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Cliente:"
        '
        'txt_num_registro
        '
        Me.txt_num_registro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_num_registro.Location = New System.Drawing.Point(128, 23)
        Me.txt_num_registro.Name = "txt_num_registro"
        Me.txt_num_registro.ReadOnly = True
        Me.txt_num_registro.Size = New System.Drawing.Size(64, 20)
        Me.txt_num_registro.TabIndex = 1
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(59, 26)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(63, 13)
        Me.lbl_codigo.TabIndex = 0
        Me.lbl_codigo.Text = "Num Reg:"
        '
        'txt_total
        '
        Me.txt_total.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(648, 555)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(110, 23)
        Me.txt_total.TabIndex = 32
        '
        'grp_ingreso_datos
        '
        Me.grp_ingreso_datos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso_datos.Controls.Add(Me.Label4)
        Me.grp_ingreso_datos.Controls.Add(Me.Label3)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_nombre_cliente)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_cve_vend)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_estado)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_tipo)
        Me.grp_ingreso_datos.Controls.Add(Me.Label7)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_numero_factura)
        Me.grp_ingreso_datos.Controls.Add(Me.Label1)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_codigo_cliente)
        Me.grp_ingreso_datos.Controls.Add(Me.Label6)
        Me.grp_ingreso_datos.Controls.Add(Me.Label5)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_num_alma)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_sucursal)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_fecha)
        Me.grp_ingreso_datos.Controls.Add(Me.Label2)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_num_registro)
        Me.grp_ingreso_datos.Controls.Add(Me.lbl_codigo)
        Me.grp_ingreso_datos.Location = New System.Drawing.Point(13, 43)
        Me.grp_ingreso_datos.Name = "grp_ingreso_datos"
        Me.grp_ingreso_datos.Size = New System.Drawing.Size(786, 106)
        Me.grp_ingreso_datos.TabIndex = 30
        Me.grp_ingreso_datos.TabStop = False
        Me.grp_ingreso_datos.Text = "Datos Generales"
        '
        'frm_detalle_opl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 579)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grd_lista)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.grp_ingreso_datos)
        Me.Name = "frm_detalle_opl"
        Me.Text = "frm_detalle_opl"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_ingreso_datos.ResumeLayout(False)
        Me.grp_ingreso_datos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_nombre_cliente As TextBox
    Friend WithEvents txt_cve_vend As TextBox
    Friend WithEvents txt_estado As TextBox
    Friend WithEvents txt_tipo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_numero_factura As TextBox
    Friend WithEvents btn_eliminar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btn_modifcar As ToolStripButton
    Friend WithEvents Label11 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_codigo_cliente As TextBox
    Friend WithEvents Label6 As Label
    Private WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btn_enviar As ToolStripButton
    Friend WithEvents Label5 As Label
    Friend WithEvents grd_lista As DataGridView
    Friend WithEvents txt_num_alma As TextBox
    Friend WithEvents txt_sucursal As TextBox
    Friend WithEvents txt_fecha As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_num_registro As TextBox
    Friend WithEvents lbl_codigo As Label
    Friend WithEvents txt_total As TextBox
    Friend WithEvents grp_ingreso_datos As GroupBox
End Class
