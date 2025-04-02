<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tabulacion_rutas_SIP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tabulacion_rutas_SIP))
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_elimina_grid = New System.Windows.Forms.Button
        Me.btn_agrega_grid = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmb_fin_cliente = New System.Windows.Forms.DateTimePicker
        Me.cmb_inicio_cliente = New System.Windows.Forms.DateTimePicker
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.grp_tabulacion = New System.Windows.Forms.GroupBox
        Me.grd_ingresar = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grp_tabulacion.SuspendLayout()
        CType(Me.grd_ingresar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Location = New System.Drawing.Point(748, 511)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(73, 23)
        Me.btn_cancelar.TabIndex = 31
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Location = New System.Drawing.Point(15, 511)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(73, 23)
        Me.btn_guardar.TabIndex = 30
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btn_elimina_grid)
        Me.GroupBox2.Controls.Add(Me.btn_agrega_grid)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.cmb_fin_cliente)
        Me.GroupBox2.Controls.Add(Me.cmb_inicio_cliente)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 192)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(809, 59)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        '
        'btn_elimina_grid
        '
        Me.btn_elimina_grid.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_elimina_grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_elimina_grid.Location = New System.Drawing.Point(529, 24)
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
        Me.btn_agrega_grid.Location = New System.Drawing.Point(244, 24)
        Me.btn_agrega_grid.Name = "btn_agrega_grid"
        Me.btn_agrega_grid.Size = New System.Drawing.Size(57, 27)
        Me.btn_agrega_grid.TabIndex = 22
        Me.btn_agrega_grid.Text = "Agregar"
        Me.btn_agrega_grid.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(456, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Salida"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(332, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Llegada"
        '
        'cmb_fin_cliente
        '
        Me.cmb_fin_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fin_cliente.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_fin_cliente.Location = New System.Drawing.Point(421, 31)
        Me.cmb_fin_cliente.Name = "cmb_fin_cliente"
        Me.cmb_fin_cliente.ShowUpDown = True
        Me.cmb_fin_cliente.Size = New System.Drawing.Size(102, 20)
        Me.cmb_fin_cliente.TabIndex = 21
        '
        'cmb_inicio_cliente
        '
        Me.cmb_inicio_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_inicio_cliente.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_inicio_cliente.Location = New System.Drawing.Point(307, 31)
        Me.cmb_inicio_cliente.Name = "cmb_inicio_cliente"
        Me.cmb_inicio_cliente.ShowUpDown = True
        Me.cmb_inicio_cliente.Size = New System.Drawing.Size(102, 20)
        Me.cmb_inicio_cliente.TabIndex = 20
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(809, 153)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'btn_ayuda_ruta
        '
        Me.btn_ayuda_ruta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_ayuda_ruta.Location = New System.Drawing.Point(254, 18)
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
        Me.Label11.Location = New System.Drawing.Point(677, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Salida"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(300, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Salida"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(540, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Llegada"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(163, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Llegada"
        '
        'cmb_liquidacion_hf
        '
        Me.cmb_liquidacion_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_liquidacion_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_liquidacion_hf.Location = New System.Drawing.Point(644, 118)
        Me.cmb_liquidacion_hf.Name = "cmb_liquidacion_hf"
        Me.cmb_liquidacion_hf.ShowUpDown = True
        Me.cmb_liquidacion_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_liquidacion_hf.TabIndex = 15
        '
        'cmb_almuerzo_hf
        '
        Me.cmb_almuerzo_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_almuerzo_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_almuerzo_hf.Location = New System.Drawing.Point(267, 118)
        Me.cmb_almuerzo_hf.Name = "cmb_almuerzo_hf"
        Me.cmb_almuerzo_hf.ShowUpDown = True
        Me.cmb_almuerzo_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_almuerzo_hf.TabIndex = 9
        '
        'cmb_devoluciones_hf
        '
        Me.cmb_devoluciones_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_devoluciones_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_devoluciones_hf.Location = New System.Drawing.Point(642, 92)
        Me.cmb_devoluciones_hf.Name = "cmb_devoluciones_hf"
        Me.cmb_devoluciones_hf.ShowUpDown = True
        Me.cmb_devoluciones_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_devoluciones_hf.TabIndex = 13
        '
        'cmb_desayuno_hf
        '
        Me.cmb_desayuno_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_desayuno_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_desayuno_hf.Location = New System.Drawing.Point(265, 92)
        Me.cmb_desayuno_hf.Name = "cmb_desayuno_hf"
        Me.cmb_desayuno_hf.ShowUpDown = True
        Me.cmb_desayuno_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_desayuno_hf.TabIndex = 7
        '
        'cmb_liquidacion_hi
        '
        Me.cmb_liquidacion_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_liquidacion_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_liquidacion_hi.Location = New System.Drawing.Point(517, 118)
        Me.cmb_liquidacion_hi.Name = "cmb_liquidacion_hi"
        Me.cmb_liquidacion_hi.ShowUpDown = True
        Me.cmb_liquidacion_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_liquidacion_hi.TabIndex = 14
        '
        'cmb_almuerzo_hi
        '
        Me.cmb_almuerzo_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_almuerzo_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_almuerzo_hi.Location = New System.Drawing.Point(140, 118)
        Me.cmb_almuerzo_hi.Name = "cmb_almuerzo_hi"
        Me.cmb_almuerzo_hi.ShowUpDown = True
        Me.cmb_almuerzo_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_almuerzo_hi.TabIndex = 8
        '
        'cmb_llegada_hf
        '
        Me.cmb_llegada_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_llegada_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_llegada_hf.Location = New System.Drawing.Point(642, 66)
        Me.cmb_llegada_hf.Name = "cmb_llegada_hf"
        Me.cmb_llegada_hf.ShowUpDown = True
        Me.cmb_llegada_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_llegada_hf.TabIndex = 11
        '
        'cmb_devoluciones_hi
        '
        Me.cmb_devoluciones_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_devoluciones_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_devoluciones_hi.Location = New System.Drawing.Point(515, 92)
        Me.cmb_devoluciones_hi.Name = "cmb_devoluciones_hi"
        Me.cmb_devoluciones_hi.ShowUpDown = True
        Me.cmb_devoluciones_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_devoluciones_hi.TabIndex = 12
        '
        'cmb_salida_hf
        '
        Me.cmb_salida_hf.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_salida_hf.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_salida_hf.Location = New System.Drawing.Point(265, 66)
        Me.cmb_salida_hf.Name = "cmb_salida_hf"
        Me.cmb_salida_hf.ShowUpDown = True
        Me.cmb_salida_hf.Size = New System.Drawing.Size(102, 20)
        Me.cmb_salida_hf.TabIndex = 5
        '
        'cmb_llegada_hi
        '
        Me.cmb_llegada_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_llegada_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_llegada_hi.Location = New System.Drawing.Point(515, 66)
        Me.cmb_llegada_hi.Name = "cmb_llegada_hi"
        Me.cmb_llegada_hi.ShowUpDown = True
        Me.cmb_llegada_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_llegada_hi.TabIndex = 10
        '
        'cmb_desayuno_hi
        '
        Me.cmb_desayuno_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_desayuno_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_desayuno_hi.Location = New System.Drawing.Point(138, 92)
        Me.cmb_desayuno_hi.Name = "cmb_desayuno_hi"
        Me.cmb_desayuno_hi.ShowUpDown = True
        Me.cmb_desayuno_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_desayuno_hi.TabIndex = 6
        '
        'cmb_salida_hi
        '
        Me.cmb_salida_hi.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_salida_hi.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.cmb_salida_hi.Location = New System.Drawing.Point(138, 66)
        Me.cmb_salida_hi.Name = "cmb_salida_hi"
        Me.cmb_salida_hi.ShowUpDown = True
        Me.cmb_salida_hi.Size = New System.Drawing.Size(102, 20)
        Me.cmb_salida_hi.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(410, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Liquidacion General:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(384, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Entrega de Devoluciones:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(439, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Llegada a CD:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(81, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Almuerzo:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Desayuno:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Salida de CD:"
        '
        'txt_ruta
        '
        Me.txt_ruta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_ruta.Location = New System.Drawing.Point(328, 19)
        Me.txt_ruta.Name = "txt_ruta"
        Me.txt_ruta.ReadOnly = True
        Me.txt_ruta.Size = New System.Drawing.Size(312, 20)
        Me.txt_ruta.TabIndex = 3
        '
        'txt_id_ruta
        '
        Me.txt_id_ruta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_id_ruta.Location = New System.Drawing.Point(286, 19)
        Me.txt_id_ruta.Name = "txt_id_ruta"
        Me.txt_id_ruta.ReadOnly = True
        Me.txt_id_ruta.Size = New System.Drawing.Size(36, 20)
        Me.txt_id_ruta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(210, 22)
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
        Me.grp_tabulacion.Location = New System.Drawing.Point(12, 257)
        Me.grp_tabulacion.Name = "grp_tabulacion"
        Me.grp_tabulacion.Size = New System.Drawing.Size(809, 248)
        Me.grp_tabulacion.TabIndex = 29
        Me.grp_tabulacion.TabStop = False
        '
        'grd_ingresar
        '
        Me.grd_ingresar.AllowUserToAddRows = False
        Me.grd_ingresar.AllowUserToDeleteRows = False
        Me.grd_ingresar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_ingresar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ingresar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_ingresar.Location = New System.Drawing.Point(3, 16)
        Me.grd_ingresar.Name = "grd_ingresar"
        Me.grd_ingresar.ReadOnly = True
        Me.grd_ingresar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_ingresar.Size = New System.Drawing.Size(803, 229)
        Me.grd_ingresar.TabIndex = 24
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(833, 25)
        Me.ToolStrip1.TabIndex = 32
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'frm_tabulacion_rutas_SIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 546)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp_tabulacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_tabulacion_rutas_SIP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabulacion de Rutas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grp_tabulacion.ResumeLayout(False)
        CType(Me.grd_ingresar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_elimina_grid As System.Windows.Forms.Button
    Friend WithEvents btn_agrega_grid As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmb_fin_cliente As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_inicio_cliente As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ayuda_ruta As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmb_liquidacion_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_almuerzo_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_devoluciones_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_desayuno_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_liquidacion_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_almuerzo_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_llegada_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_devoluciones_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_salida_hf As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_llegada_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_desayuno_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_salida_hi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_ruta As System.Windows.Forms.TextBox
    Friend WithEvents txt_id_ruta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grp_tabulacion As System.Windows.Forms.GroupBox
    Friend WithEvents grd_ingresar As System.Windows.Forms.DataGridView
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
