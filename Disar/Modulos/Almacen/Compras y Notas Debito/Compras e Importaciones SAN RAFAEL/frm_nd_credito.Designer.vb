<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_nd_credito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_nd_credito))
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_isv = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_descuento = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_subtotal = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grd_lista = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmb_fecha = New System.Windows.Forms.DateTimePicker
        Me.txt_compra_local = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_compra_sae = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_ref_proveedor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_proveedor = New System.Windows.Forms.TextBox
        Me.txt_codigo_proveedor = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_num_almacen = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_codigo_ajuste = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_exportar = New System.Windows.Forms.ToolStripButton
        Me.GroupBox2.SuspendLayout()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_total
        '
        Me.txt_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total.Location = New System.Drawing.Point(651, 494)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(150, 20)
        Me.txt_total.TabIndex = 28
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(613, 497)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Total:"
        '
        'txt_isv
        '
        Me.txt_isv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isv.Location = New System.Drawing.Point(651, 468)
        Me.txt_isv.Name = "txt_isv"
        Me.txt_isv.ReadOnly = True
        Me.txt_isv.Size = New System.Drawing.Size(150, 20)
        Me.txt_isv.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(614, 471)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "I.S.V:"
        '
        'txt_descuento
        '
        Me.txt_descuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento.Location = New System.Drawing.Point(436, 472)
        Me.txt_descuento.Name = "txt_descuento"
        Me.txt_descuento.ReadOnly = True
        Me.txt_descuento.Size = New System.Drawing.Size(150, 20)
        Me.txt_descuento.TabIndex = 30
        Me.txt_descuento.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(370, 475)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Descuento:"
        Me.Label8.Visible = False
        '
        'txt_subtotal
        '
        Me.txt_subtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_subtotal.Location = New System.Drawing.Point(651, 441)
        Me.txt_subtotal.Name = "txt_subtotal"
        Me.txt_subtotal.ReadOnly = True
        Me.txt_subtotal.Size = New System.Drawing.Size(150, 20)
        Me.txt_subtotal.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(592, 444)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Sub Total:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grd_lista)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 164)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(792, 271)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Productos"
        '
        'grd_lista
        '
        Me.grd_lista.AllowUserToAddRows = False
        Me.grd_lista.AllowUserToDeleteRows = False
        Me.grd_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_lista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_lista.Location = New System.Drawing.Point(3, 16)
        Me.grd_lista.Name = "grd_lista"
        Me.grd_lista.ReadOnly = True
        Me.grd_lista.Size = New System.Drawing.Size(786, 252)
        Me.grd_lista.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmb_fecha)
        Me.GroupBox1.Controls.Add(Me.txt_compra_local)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_compra_sae)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_ref_proveedor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_proveedor)
        Me.GroupBox1.Controls.Add(Me.txt_codigo_proveedor)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txt_num_almacen)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_codigo_ajuste)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(792, 116)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion"
        '
        'cmb_fecha
        '
        Me.cmb_fecha.Enabled = False
        Me.cmb_fecha.Location = New System.Drawing.Point(303, 53)
        Me.cmb_fecha.Name = "cmb_fecha"
        Me.cmb_fecha.Size = New System.Drawing.Size(201, 20)
        Me.cmb_fecha.TabIndex = 2
        '
        'txt_compra_local
        '
        Me.txt_compra_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_compra_local.Location = New System.Drawing.Point(626, 53)
        Me.txt_compra_local.Name = "txt_compra_local"
        Me.txt_compra_local.ReadOnly = True
        Me.txt_compra_local.Size = New System.Drawing.Size(130, 20)
        Me.txt_compra_local.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(519, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "No. Compra (Local):"
        '
        'txt_compra_sae
        '
        Me.txt_compra_sae.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_compra_sae.Location = New System.Drawing.Point(626, 22)
        Me.txt_compra_sae.Name = "txt_compra_sae"
        Me.txt_compra_sae.ReadOnly = True
        Me.txt_compra_sae.Size = New System.Drawing.Size(130, 20)
        Me.txt_compra_sae.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(524, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "No. Compra (SAE):"
        '
        'txt_ref_proveedor
        '
        Me.txt_ref_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ref_proveedor.Location = New System.Drawing.Point(303, 23)
        Me.txt_ref_proveedor.Name = "txt_ref_proveedor"
        Me.txt_ref_proveedor.ReadOnly = True
        Me.txt_ref_proveedor.Size = New System.Drawing.Size(201, 20)
        Me.txt_ref_proveedor.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Ref. Proveedor:"
        '
        'txt_proveedor
        '
        Me.txt_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_proveedor.Location = New System.Drawing.Point(303, 81)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.ReadOnly = True
        Me.txt_proveedor.Size = New System.Drawing.Size(453, 20)
        Me.txt_proveedor.TabIndex = 1
        '
        'txt_codigo_proveedor
        '
        Me.txt_codigo_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_proveedor.Location = New System.Drawing.Point(93, 79)
        Me.txt_codigo_proveedor.Name = "txt_codigo_proveedor"
        Me.txt_codigo_proveedor.ReadOnly = True
        Me.txt_codigo_proveedor.Size = New System.Drawing.Size(119, 20)
        Me.txt_codigo_proveedor.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(241, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Proveedor:"
        '
        'txt_num_almacen
        '
        Me.txt_num_almacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_num_almacen.Location = New System.Drawing.Point(93, 53)
        Me.txt_num_almacen.Name = "txt_num_almacen"
        Me.txt_num_almacen.ReadOnly = True
        Me.txt_num_almacen.Size = New System.Drawing.Size(119, 20)
        Me.txt_num_almacen.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Cod Proveedor:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Almacen:"
        '
        'txt_codigo_ajuste
        '
        Me.txt_codigo_ajuste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_ajuste.Location = New System.Drawing.Point(93, 25)
        Me.txt_codigo_ajuste.Name = "txt_codigo_ajuste"
        Me.txt_codigo_ajuste.ReadOnly = True
        Me.txt_codigo_ajuste.Size = New System.Drawing.Size(119, 20)
        Me.txt_codigo_ajuste.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo Credito:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btn_exportar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(813, 39)
        Me.ToolStrip1.TabIndex = 32
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btn_exportar
        '
        Me.btn_exportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.btn_exportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(69, 36)
        Me.btn_exportar.Text = "Excel"
        '
        'frm_nd_credito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 549)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_isv)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_descuento)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_subtotal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_nd_credito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Credito"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_isv As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grd_lista As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_compra_local As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_compra_sae As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_ref_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_num_almacen As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_ajuste As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripButton
End Class
