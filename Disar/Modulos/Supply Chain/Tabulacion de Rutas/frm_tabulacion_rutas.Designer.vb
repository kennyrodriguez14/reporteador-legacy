<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tabulacion_rutas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tabulacion_rutas))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Label1 = New System.Windows.Forms.Label
        Me.grp_tabulacion = New System.Windows.Forms.GroupBox
        Me.grd_ingresar = New System.Windows.Forms.DataGridView
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_Peso = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Llegada = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Salida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_ayuda_ruta = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmb_liquidacion_hf = New System.Windows.Forms.DateTimePicker
        Me.cmb_almuerzo_hf = New System.Windows.Forms.DateTimePicker
        Me.cmb_devoluciones_hf = New System.Windows.Forms.DateTimePicker
        Me.cmb_desayuno_hf = New System.Windows.Forms.DateTimePicker
        Me.cmb_liquidacion_hi = New System.Windows.Forms.DateTimePicker
        Me.cmb_almuerzo_hi = New System.Windows.Forms.DateTimePicker
        Me.cmb_llegada_hf = New System.Windows.Forms.DateTimePicker
        Me.cmb_devoluciones_hi = New System.Windows.Forms.DateTimePicker
        Me.cmb_salida_hf = New System.Windows.Forms.DateTimePicker
        Me.cmb_llegada_hi = New System.Windows.Forms.DateTimePicker
        Me.cmb_desayuno_hi = New System.Windows.Forms.DateTimePicker
        Me.cmb_salida_hi = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_ruta = New System.Windows.Forms.TextBox
        Me.txt_id_ruta = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_peso = New System.Windows.Forms.TextBox
        Me.btn_elimina_grid = New System.Windows.Forms.Button
        Me.btn_agrega_grid = New System.Windows.Forms.Button
        Me.btn_ayuda_clientes = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmb_fin_cliente = New System.Windows.Forms.DateTimePicker
        Me.cmb_inicio_cliente = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txt_codigo_cliente = New System.Windows.Forms.TextBox
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.ToolStrip1.SuspendLayout()
        Me.grp_tabulacion.SuspendLayout()
        CType(Me.grd_ingresar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(749, 25)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(167, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Ruta:"
        '
        'grp_tabulacion
        '
        Me.grp_tabulacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_tabulacion.Controls.Add(Me.grd_ingresar)
        Me.grp_tabulacion.Location = New System.Drawing.Point(12, 277)
        Me.grp_tabulacion.Name = "grp_tabulacion"
        Me.grp_tabulacion.Size = New System.Drawing.Size(722, 215)
        Me.grp_tabulacion.TabIndex = 24
        Me.grp_tabulacion.TabStop = False
        '
        'grd_ingresar
        '
        Me.grd_ingresar.AllowUserToAddRows = False
        Me.grd_ingresar.AllowUserToDeleteRows = False
        Me.grd_ingresar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ingresar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Nombre, Me.col_Peso, Me.Llegada, Me.Salida})
        Me.grd_ingresar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_ingresar.Location = New System.Drawing.Point(3, 16)
        Me.grd_ingresar.Name = "grd_ingresar"
        Me.grd_ingresar.ReadOnly = True
        Me.grd_ingresar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_ingresar.Size = New System.Drawing.Size(716, 196)
        Me.grd_ingresar.TabIndex = 24
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre del Cliente"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'col_Peso
        '
        Me.col_Peso.HeaderText = "Peso"
        Me.col_Peso.Name = "col_Peso"
        Me.col_Peso.ReadOnly = True
        '
        'Llegada
        '
        Me.Llegada.HeaderText = "Llegada"
        Me.Llegada.Name = "Llegada"
        Me.Llegada.ReadOnly = True
        '
        'Salida
        '
        Me.Salida.HeaderText = "Salida"
        Me.Salida.Name = "Salida"
        Me.Salida.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btn_ayuda_ruta)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmb_liquidacion_hf)
        Me.GroupBox1.Controls.Add(Me.cmb_almuerzo_hf)
        Me.GroupBox1.Controls.Add(Me.cmb_devoluciones_hf)
        Me.GroupBox1.Controls.Add(Me.cmb_desayuno_hf)
        Me.GroupBox1.Controls.Add(Me.cmb_liquidacion_hi)
        Me.GroupBox1.Controls.Add(Me.cmb_almuerzo_hi)
        Me.GroupBox1.Controls.Add(Me.cmb_llegada_hf)
        Me.GroupBox1.Controls.Add(Me.cmb_devoluciones_hi)
        Me.GroupBox1.Controls.Add(Me.cmb_salida_hf)
        Me.GroupBox1.Controls.Add(Me.cmb_llegada_hi)
        Me.GroupBox1.Controls.Add(Me.cmb_desayuno_hi)
        Me.GroupBox1.Controls.Add(Me.cmb_salida_hi)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_ruta)
        Me.GroupBox1.Controls.Add(Me.txt_id_ruta)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(722, 153)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btn_ayuda_ruta
        '
        Me.btn_ayuda_ruta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_ayuda_ruta.Location = New System.Drawing.Point(211, 18)
        Me.btn_ayuda_ruta.Name = "btn_ayuda_ruta"
        Me.btn_ayuda_ruta.Size = New System.Drawing.Size(26, 20)
        Me.btn_ayuda_ruta.TabIndex = 1
        Me.btn_ayuda_ruta.Text = "..."
        Me.btn_ayuda_ruta.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(634, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Salida"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(257, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Salida"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(497, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Llegada"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(120, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Llegada"
        '
        'cmb_liquidacion_hf
        '
        Me.cmb_liquidacion_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_liquidacion_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_liquidacion_hf.Location = New System.Drawing.Point(601, 118)
        Me.cmb_liquidacion_hf.Name = "cmb_liquidacion_hf"
        Me.cmb_liquidacion_hf.ShowUpDown = True
        Me.cmb_liquidacion_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_liquidacion_hf.TabIndex = 15
        '
        'cmb_almuerzo_hf
        '
        Me.cmb_almuerzo_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_almuerzo_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_almuerzo_hf.Location = New System.Drawing.Point(224, 118)
        Me.cmb_almuerzo_hf.Name = "cmb_almuerzo_hf"
        Me.cmb_almuerzo_hf.ShowUpDown = True
        Me.cmb_almuerzo_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_almuerzo_hf.TabIndex = 9
        '
        'cmb_devoluciones_hf
        '
        Me.cmb_devoluciones_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_devoluciones_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_devoluciones_hf.Location = New System.Drawing.Point(599, 92)
        Me.cmb_devoluciones_hf.Name = "cmb_devoluciones_hf"
        Me.cmb_devoluciones_hf.ShowUpDown = True
        Me.cmb_devoluciones_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_devoluciones_hf.TabIndex = 13
        '
        'cmb_desayuno_hf
        '
        Me.cmb_desayuno_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_desayuno_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_desayuno_hf.Location = New System.Drawing.Point(222, 92)
        Me.cmb_desayuno_hf.Name = "cmb_desayuno_hf"
        Me.cmb_desayuno_hf.ShowUpDown = True
        Me.cmb_desayuno_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_desayuno_hf.TabIndex = 7
        '
        'cmb_liquidacion_hi
        '
        Me.cmb_liquidacion_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_liquidacion_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_liquidacion_hi.Location = New System.Drawing.Point(474, 118)
        Me.cmb_liquidacion_hi.Name = "cmb_liquidacion_hi"
        Me.cmb_liquidacion_hi.ShowUpDown = True
        Me.cmb_liquidacion_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_liquidacion_hi.TabIndex = 14
        '
        'cmb_almuerzo_hi
        '
        Me.cmb_almuerzo_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_almuerzo_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_almuerzo_hi.Location = New System.Drawing.Point(97, 118)
        Me.cmb_almuerzo_hi.Name = "cmb_almuerzo_hi"
        Me.cmb_almuerzo_hi.ShowUpDown = True
        Me.cmb_almuerzo_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_almuerzo_hi.TabIndex = 8
        '
        'cmb_llegada_hf
        '
        Me.cmb_llegada_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_llegada_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_llegada_hf.Location = New System.Drawing.Point(599, 66)
        Me.cmb_llegada_hf.Name = "cmb_llegada_hf"
        Me.cmb_llegada_hf.ShowUpDown = True
        Me.cmb_llegada_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_llegada_hf.TabIndex = 11
        '
        'cmb_devoluciones_hi
        '
        Me.cmb_devoluciones_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_devoluciones_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_devoluciones_hi.Location = New System.Drawing.Point(472, 92)
        Me.cmb_devoluciones_hi.Name = "cmb_devoluciones_hi"
        Me.cmb_devoluciones_hi.ShowUpDown = True
        Me.cmb_devoluciones_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_devoluciones_hi.TabIndex = 12
        '
        'cmb_salida_hf
        '
        Me.cmb_salida_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_salida_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_salida_hf.Location = New System.Drawing.Point(222, 66)
        Me.cmb_salida_hf.Name = "cmb_salida_hf"
        Me.cmb_salida_hf.ShowUpDown = True
        Me.cmb_salida_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_salida_hf.TabIndex = 5
        '
        'cmb_llegada_hi
        '
        Me.cmb_llegada_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_llegada_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_llegada_hi.Location = New System.Drawing.Point(472, 66)
        Me.cmb_llegada_hi.Name = "cmb_llegada_hi"
        Me.cmb_llegada_hi.ShowUpDown = True
        Me.cmb_llegada_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_llegada_hi.TabIndex = 10
        '
        'cmb_desayuno_hi
        '
        Me.cmb_desayuno_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_desayuno_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_desayuno_hi.Location = New System.Drawing.Point(95, 92)
        Me.cmb_desayuno_hi.Name = "cmb_desayuno_hi"
        Me.cmb_desayuno_hi.ShowUpDown = True
        Me.cmb_desayuno_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_desayuno_hi.TabIndex = 6
        '
        'cmb_salida_hi
        '
        Me.cmb_salida_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_salida_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_salida_hi.Location = New System.Drawing.Point(95, 66)
        Me.cmb_salida_hi.Name = "cmb_salida_hi"
        Me.cmb_salida_hi.ShowUpDown = True
        Me.cmb_salida_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_salida_hi.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(367, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Liquidacion General:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(341, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Entrega de Devoluciones:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(396, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Llegada a CD:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Almuerzo:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Desayuno:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Salida de CD:"
        '
        'txt_ruta
        '
        Me.txt_ruta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_ruta.Location = New System.Drawing.Point(285, 19)
        Me.txt_ruta.Name = "txt_ruta"
        Me.txt_ruta.ReadOnly = True
        Me.txt_ruta.Size = New System.Drawing.Size(312, 20)
        Me.txt_ruta.TabIndex = 3
        '
        'txt_id_ruta
        '
        Me.txt_id_ruta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_id_ruta.Location = New System.Drawing.Point(243, 19)
        Me.txt_id_ruta.Name = "txt_id_ruta"
        Me.txt_id_ruta.ReadOnly = True
        Me.txt_id_ruta.Size = New System.Drawing.Size(36, 20)
        Me.txt_id_ruta.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txt_peso)
        Me.GroupBox2.Controls.Add(Me.btn_elimina_grid)
        Me.GroupBox2.Controls.Add(Me.btn_agrega_grid)
        Me.GroupBox2.Controls.Add(Me.btn_ayuda_clientes)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.cmb_fin_cliente)
        Me.GroupBox2.Controls.Add(Me.cmb_inicio_cliente)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txt_codigo_cliente)
        Me.GroupBox2.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 187)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(722, 90)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(476, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Peso:"
        '
        'txt_peso
        '
        Me.txt_peso.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_peso.Location = New System.Drawing.Point(471, 31)
        Me.txt_peso.Name = "txt_peso"
        Me.txt_peso.Size = New System.Drawing.Size(62, 20)
        Me.txt_peso.TabIndex = 25
        '
        'btn_elimina_grid
        '
        Me.btn_elimina_grid.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_elimina_grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_elimina_grid.Location = New System.Drawing.Point(659, 57)
        Me.btn_elimina_grid.Name = "btn_elimina_grid"
        Me.btn_elimina_grid.Size = New System.Drawing.Size(57, 27)
        Me.btn_elimina_grid.TabIndex = 23
        Me.btn_elimina_grid.Text = "Eliminar"
        Me.btn_elimina_grid.UseVisualStyleBackColor = True
        '
        'btn_agrega_grid
        '
        Me.btn_agrega_grid.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_agrega_grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agrega_grid.Location = New System.Drawing.Point(6, 57)
        Me.btn_agrega_grid.Name = "btn_agrega_grid"
        Me.btn_agrega_grid.Size = New System.Drawing.Size(57, 27)
        Me.btn_agrega_grid.TabIndex = 22
        Me.btn_agrega_grid.Text = "Agregar"
        Me.btn_agrega_grid.UseVisualStyleBackColor = True
        '
        'btn_ayuda_clientes
        '
        Me.btn_ayuda_clientes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_ayuda_clientes.Location = New System.Drawing.Point(9, 31)
        Me.btn_ayuda_clientes.Name = "btn_ayuda_clientes"
        Me.btn_ayuda_clientes.Size = New System.Drawing.Size(26, 20)
        Me.btn_ayuda_clientes.TabIndex = 17
        Me.btn_ayuda_clientes.Text = "..."
        Me.btn_ayuda_clientes.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(649, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Salida"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(558, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Llegada"
        '
        'cmb_fin_cliente
        '
        Me.cmb_fin_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fin_cliente.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_fin_cliente.Location = New System.Drawing.Point(631, 31)
        Me.cmb_fin_cliente.Name = "cmb_fin_cliente"
        Me.cmb_fin_cliente.ShowUpDown = True
        Me.cmb_fin_cliente.Size = New System.Drawing.Size(85, 20)
        Me.cmb_fin_cliente.TabIndex = 21
        '
        'cmb_inicio_cliente
        '
        Me.cmb_inicio_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_inicio_cliente.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_inicio_cliente.Location = New System.Drawing.Point(539, 31)
        Me.cmb_inicio_cliente.Name = "cmb_inicio_cliente"
        Me.cmb_inicio_cliente.ShowUpDown = True
        Me.cmb_inicio_cliente.Size = New System.Drawing.Size(88, 20)
        Me.cmb_inicio_cliente.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(106, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Cliente:"
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(44, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Codigo:"
        '
        'txt_codigo_cliente
        '
        Me.txt_codigo_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_codigo_cliente.Location = New System.Drawing.Point(39, 31)
        Me.txt_codigo_cliente.Name = "txt_codigo_cliente"
        Me.txt_codigo_cliente.ReadOnly = True
        Me.txt_codigo_cliente.Size = New System.Drawing.Size(62, 20)
        Me.txt_codigo_cliente.TabIndex = 18
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(104, 31)
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.ReadOnly = True
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(361, 20)
        Me.txt_nombre_cliente.TabIndex = 19
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Location = New System.Drawing.Point(12, 498)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(73, 23)
        Me.btn_guardar.TabIndex = 25
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Location = New System.Drawing.Point(661, 498)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(73, 23)
        Me.btn_cancelar.TabIndex = 26
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'frm_tabulacion_rutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 533)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp_tabulacion)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_tabulacion_rutas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabulacion de Rutas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grp_tabulacion.ResumeLayout(False)
        CType(Me.grd_ingresar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grp_tabulacion As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_ruta As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_ruta As System.Windows.Forms.TextBox
    Friend WithEvents cmb_almuerzo_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_desayuno_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_salida_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmb_liquidacion_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_almuerzo_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_devoluciones_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_desayuno_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_liquidacion_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_llegada_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_devoluciones_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_salida_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_llegada_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmb_fin_cliente As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_inicio_cliente As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents btn_ayuda_ruta As System.Windows.Forms.Button
    Friend WithEvents btn_elimina_grid As System.Windows.Forms.Button
    Friend WithEvents btn_agrega_grid As System.Windows.Forms.Button
    Friend WithEvents btn_ayuda_clientes As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents grd_ingresar As System.Windows.Forms.DataGridView
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Peso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Llegada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Salida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_peso As System.Windows.Forms.TextBox
End Class
