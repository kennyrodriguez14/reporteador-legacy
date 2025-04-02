<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_productos_almacen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_productos_almacen))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grd_productos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.txt_busqueda = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_tipo_filtro = New System.Windows.Forms.ComboBox()
        Me.cmb_flota = New System.Windows.Forms.ComboBox()
        Me.lbl_empresa = New System.Windows.Forms.Label()
        Me.btn_sabu = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grd_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grd_productos)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 244)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'grd_productos
        '
        Me.grd_productos.AllowUserToAddRows = False
        Me.grd_productos.AllowUserToDeleteRows = False
        Me.grd_productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_productos.Location = New System.Drawing.Point(3, 16)
        Me.grd_productos.MultiSelect = False
        Me.grd_productos.Name = "grd_productos"
        Me.grd_productos.ReadOnly = True
        Me.grd_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_productos.Size = New System.Drawing.Size(490, 225)
        Me.grd_productos.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.txt_busqueda)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmb_tipo_filtro)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 54)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtos"
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(436, 19)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(54, 21)
        Me.btn_buscar.TabIndex = 3
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'txt_busqueda
        '
        Me.txt_busqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_busqueda.Location = New System.Drawing.Point(192, 20)
        Me.txt_busqueda.Name = "txt_busqueda"
        Me.txt_busqueda.Size = New System.Drawing.Size(238, 20)
        Me.txt_busqueda.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filtrar por:"
        '
        'cmb_tipo_filtro
        '
        Me.cmb_tipo_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo_filtro.FormattingEnabled = True
        Me.cmb_tipo_filtro.Items.AddRange(New Object() {"Codigo", "Descripcion"})
        Me.cmb_tipo_filtro.Location = New System.Drawing.Point(65, 19)
        Me.cmb_tipo_filtro.Name = "cmb_tipo_filtro"
        Me.cmb_tipo_filtro.Size = New System.Drawing.Size(121, 21)
        Me.cmb_tipo_filtro.TabIndex = 1
        '
        'cmb_flota
        '
        Me.cmb_flota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_flota.FormattingEnabled = True
        Me.cmb_flota.Items.AddRange(New Object() {"Consumo", "Flota"})
        Me.cmb_flota.Location = New System.Drawing.Point(77, 7)
        Me.cmb_flota.Name = "cmb_flota"
        Me.cmb_flota.Size = New System.Drawing.Size(121, 21)
        Me.cmb_flota.TabIndex = 1
        Me.cmb_flota.Visible = False
        '
        'lbl_empresa
        '
        Me.lbl_empresa.AutoSize = True
        Me.lbl_empresa.Location = New System.Drawing.Point(18, 10)
        Me.lbl_empresa.Name = "lbl_empresa"
        Me.lbl_empresa.Size = New System.Drawing.Size(51, 13)
        Me.lbl_empresa.TabIndex = 0
        Me.lbl_empresa.Text = "Empresa:"
        Me.lbl_empresa.Visible = False
        '
        'btn_sabu
        '
        Me.btn_sabu.Location = New System.Drawing.Point(15, 91)
        Me.btn_sabu.Name = "btn_sabu"
        Me.btn_sabu.Size = New System.Drawing.Size(116, 21)
        Me.btn_sabu.TabIndex = 7
        Me.btn_sabu.Text = "Seleccionar"
        Me.btn_sabu.UseVisualStyleBackColor = True
        '
        'frm_productos_almacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 370)
        Me.Controls.Add(Me.btn_sabu)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_empresa)
        Me.Controls.Add(Me.cmb_flota)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_productos_almacen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Productos"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grd_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grd_productos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents txt_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_tipo_filtro As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_flota As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_empresa As System.Windows.Forms.Label
    Friend WithEvents btn_sabu As System.Windows.Forms.Button
End Class
