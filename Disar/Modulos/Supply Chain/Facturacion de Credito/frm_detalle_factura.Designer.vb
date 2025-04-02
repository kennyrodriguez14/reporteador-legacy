<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_detalle_factura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_detalle_factura))
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.txttotal = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtisv = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtsubtotal = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtdescuento = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtalmacen = New System.Windows.Forms.TextBox
        Me.txt_num_factura = New System.Windows.Forms.TextBox
        Me.lbl_clientes = New System.Windows.Forms.TextBox
        Me.txt_cve_vend = New System.Windows.Forms.TextBox
        Me.txtfecha = New System.Windows.Forms.TextBox
        Me.lbl_codigo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grid_factura = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.grid_factura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Location = New System.Drawing.Point(12, 594)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 18
        Me.btn_guardar.Text = "Imprimir"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'txttotal
        '
        Me.txttotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttotal.AutoSize = True
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(847, 590)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(19, 20)
        Me.txttotal.TabIndex = 15
        Me.txttotal.Text = "0"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(793, 590)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Total:"
        '
        'txtisv
        '
        Me.txtisv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtisv.AutoSize = True
        Me.txtisv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtisv.Location = New System.Drawing.Point(847, 563)
        Me.txtisv.Name = "txtisv"
        Me.txtisv.Size = New System.Drawing.Size(19, 20)
        Me.txtisv.TabIndex = 17
        Me.txtisv.Text = "0"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(808, 563)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 20)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Isv:"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtsubtotal.AutoSize = True
        Me.txtsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubtotal.Location = New System.Drawing.Point(847, 510)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.Size = New System.Drawing.Size(19, 20)
        Me.txtsubtotal.TabIndex = 13
        Me.txtsubtotal.Text = "0"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(759, 510)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Sub-Total:"
        '
        'txtdescuento
        '
        Me.txtdescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdescuento.AutoSize = True
        Me.txtdescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento.Location = New System.Drawing.Point(847, 536)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.Size = New System.Drawing.Size(19, 20)
        Me.txtdescuento.TabIndex = 11
        Me.txtdescuento.Text = "0"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(750, 536)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Descuento:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtalmacen)
        Me.GroupBox1.Controls.Add(Me.txt_num_factura)
        Me.GroupBox1.Controls.Add(Me.lbl_clientes)
        Me.GroupBox1.Controls.Add(Me.txt_cve_vend)
        Me.GroupBox1.Controls.Add(Me.txtfecha)
        Me.GroupBox1.Controls.Add(Me.lbl_codigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1036, 117)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'txtalmacen
        '
        Me.txtalmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtalmacen.Location = New System.Drawing.Point(319, 16)
        Me.txtalmacen.Name = "txtalmacen"
        Me.txtalmacen.ReadOnly = True
        Me.txtalmacen.Size = New System.Drawing.Size(199, 20)
        Me.txtalmacen.TabIndex = 6
        '
        'txt_num_factura
        '
        Me.txt_num_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_num_factura.Location = New System.Drawing.Point(107, 19)
        Me.txt_num_factura.Name = "txt_num_factura"
        Me.txt_num_factura.ReadOnly = True
        Me.txt_num_factura.Size = New System.Drawing.Size(111, 20)
        Me.txt_num_factura.TabIndex = 6
        '
        'lbl_clientes
        '
        Me.lbl_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_clientes.Location = New System.Drawing.Point(242, 45)
        Me.lbl_clientes.Name = "lbl_clientes"
        Me.lbl_clientes.ReadOnly = True
        Me.lbl_clientes.Size = New System.Drawing.Size(360, 20)
        Me.lbl_clientes.TabIndex = 6
        '
        'txt_cve_vend
        '
        Me.txt_cve_vend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cve_vend.Location = New System.Drawing.Point(327, 75)
        Me.txt_cve_vend.Name = "txt_cve_vend"
        Me.txt_cve_vend.ReadOnly = True
        Me.txt_cve_vend.Size = New System.Drawing.Size(88, 20)
        Me.txt_cve_vend.TabIndex = 6
        '
        'txtfecha
        '
        Me.txtfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecha.Location = New System.Drawing.Point(107, 75)
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.ReadOnly = True
        Me.txtfecha.Size = New System.Drawing.Size(111, 20)
        Me.txtfecha.TabIndex = 6
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(107, 45)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.ReadOnly = True
        Me.lbl_codigo.Size = New System.Drawing.Size(111, 20)
        Me.lbl_codigo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(238, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 20)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Almacen:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Nº Factura:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(238, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 20)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Vendedor:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cliente:"
        '
        'grid_factura
        '
        Me.grid_factura.AllowUserToAddRows = False
        Me.grid_factura.AllowUserToDeleteRows = False
        Me.grid_factura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid_factura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grid_factura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_factura.Location = New System.Drawing.Point(13, 135)
        Me.grid_factura.Name = "grid_factura"
        Me.grid_factura.ReadOnly = True
        Me.grid_factura.Size = New System.Drawing.Size(1035, 359)
        Me.grid_factura.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(94, 594)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm_detalle_factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 629)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtisv)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtsubtotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtdescuento)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grid_factura)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_detalle_factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Factura"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grid_factura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txttotal As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtisv As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtsubtotal As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdescuento As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_num_factura As System.Windows.Forms.TextBox
    Friend WithEvents lbl_clientes As System.Windows.Forms.TextBox
    Friend WithEvents txt_cve_vend As System.Windows.Forms.TextBox
    Friend WithEvents lbl_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grid_factura As System.Windows.Forms.DataGridView
    Friend WithEvents txtalmacen As System.Windows.Forms.TextBox
    Friend WithEvents txtfecha As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
