<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_guia_remision
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_guia_remision))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtViajesRecomendados = New System.Windows.Forms.TextBox
        Me.TxtViajes = New System.Windows.Forms.TextBox
        Me.TxtVehiculoCapacidad = New System.Windows.Forms.TextBox
        Me.pnl_vehiculo = New System.Windows.Forms.Panel
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_nplaca_vehiculo = New System.Windows.Forms.TextBox
        Me.txt_marca_vehiculo = New System.Windows.Forms.TextBox
        Me.pnl_transportista = New System.Windows.Forms.Panel
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_rtn_otro_transportista = New System.Windows.Forms.TextBox
        Me.txt_otro_transportista = New System.Windows.Forms.TextBox
        Me.datos_externos = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_direccion = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_rtn = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_destino = New System.Windows.Forms.TextBox
        Me.cmb_otro_vehiculo = New System.Windows.Forms.CheckBox
        Me.cmb_otro_transportista = New System.Windows.Forms.CheckBox
        Me.cmb_otro_destino = New System.Windows.Forms.CheckBox
        Me.lbl_almacen_destino = New System.Windows.Forms.Label
        Me.lbl_almacen = New System.Windows.Forms.Label
        Me.lbl_empresa = New System.Windows.Forms.Label
        Me.txt_buscar_transportista = New System.Windows.Forms.TextBox
        Me.cmb_fecha_final = New System.Windows.Forms.DateTimePicker
        Me.cmb_fecha_inicio = New System.Windows.Forms.DateTimePicker
        Me.cmb_destino = New System.Windows.Forms.ComboBox
        Me.cmb_vehiculo = New System.Windows.Forms.ComboBox
        Me.cmb_motivo = New System.Windows.Forms.ComboBox
        Me.cmb_concepto_entrada = New System.Windows.Forms.ComboBox
        Me.cmb_concepto_salida = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cmb_transportista = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmb_remite = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgv_detalles = New System.Windows.Forms.DataGridView
        Me.col_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_cargar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.col_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.peso = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.peso_total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lote = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.guardar_pdf_dialog = New System.Windows.Forms.SaveFileDialog
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbl_peso_total = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.pnl_vehiculo.SuspendLayout()
        Me.pnl_transportista.SuspendLayout()
        Me.datos_externos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_detalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TxtViajesRecomendados)
        Me.GroupBox1.Controls.Add(Me.TxtViajes)
        Me.GroupBox1.Controls.Add(Me.TxtVehiculoCapacidad)
        Me.GroupBox1.Controls.Add(Me.pnl_vehiculo)
        Me.GroupBox1.Controls.Add(Me.pnl_transportista)
        Me.GroupBox1.Controls.Add(Me.datos_externos)
        Me.GroupBox1.Controls.Add(Me.cmb_otro_vehiculo)
        Me.GroupBox1.Controls.Add(Me.cmb_otro_transportista)
        Me.GroupBox1.Controls.Add(Me.cmb_otro_destino)
        Me.GroupBox1.Controls.Add(Me.lbl_almacen_destino)
        Me.GroupBox1.Controls.Add(Me.lbl_almacen)
        Me.GroupBox1.Controls.Add(Me.lbl_empresa)
        Me.GroupBox1.Controls.Add(Me.txt_buscar_transportista)
        Me.GroupBox1.Controls.Add(Me.cmb_fecha_final)
        Me.GroupBox1.Controls.Add(Me.cmb_fecha_inicio)
        Me.GroupBox1.Controls.Add(Me.cmb_destino)
        Me.GroupBox1.Controls.Add(Me.cmb_vehiculo)
        Me.GroupBox1.Controls.Add(Me.cmb_motivo)
        Me.GroupBox1.Controls.Add(Me.cmb_concepto_entrada)
        Me.GroupBox1.Controls.Add(Me.cmb_concepto_salida)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.cmb_transportista)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmb_remite)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1026, 287)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Encabezado"
        '
        'TxtViajesRecomendados
        '
        Me.TxtViajesRecomendados.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtViajesRecomendados.Enabled = False
        Me.TxtViajesRecomendados.Location = New System.Drawing.Point(919, 260)
        Me.TxtViajesRecomendados.Name = "TxtViajesRecomendados"
        Me.TxtViajesRecomendados.Size = New System.Drawing.Size(51, 20)
        Me.TxtViajesRecomendados.TabIndex = 13
        '
        'TxtViajes
        '
        Me.TxtViajes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtViajes.Location = New System.Drawing.Point(743, 260)
        Me.TxtViajes.Name = "TxtViajes"
        Me.TxtViajes.Size = New System.Drawing.Size(51, 20)
        Me.TxtViajes.TabIndex = 13
        '
        'TxtVehiculoCapacidad
        '
        Me.TxtVehiculoCapacidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtVehiculoCapacidad.Enabled = False
        Me.TxtVehiculoCapacidad.Location = New System.Drawing.Point(743, 234)
        Me.TxtVehiculoCapacidad.Name = "TxtVehiculoCapacidad"
        Me.TxtVehiculoCapacidad.Size = New System.Drawing.Size(178, 20)
        Me.TxtVehiculoCapacidad.TabIndex = 13
        '
        'pnl_vehiculo
        '
        Me.pnl_vehiculo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnl_vehiculo.Controls.Add(Me.Label16)
        Me.pnl_vehiculo.Controls.Add(Me.Label17)
        Me.pnl_vehiculo.Controls.Add(Me.txt_nplaca_vehiculo)
        Me.pnl_vehiculo.Controls.Add(Me.txt_marca_vehiculo)
        Me.pnl_vehiculo.Location = New System.Drawing.Point(743, 181)
        Me.pnl_vehiculo.Name = "pnl_vehiculo"
        Me.pnl_vehiculo.Size = New System.Drawing.Size(227, 56)
        Me.pnl_vehiculo.TabIndex = 8
        Me.pnl_vehiculo.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "# Placa:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(26, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Marca:"
        '
        'txt_nplaca_vehiculo
        '
        Me.txt_nplaca_vehiculo.Location = New System.Drawing.Point(69, 31)
        Me.txt_nplaca_vehiculo.Name = "txt_nplaca_vehiculo"
        Me.txt_nplaca_vehiculo.Size = New System.Drawing.Size(140, 20)
        Me.txt_nplaca_vehiculo.TabIndex = 13
        '
        'txt_marca_vehiculo
        '
        Me.txt_marca_vehiculo.Location = New System.Drawing.Point(69, 7)
        Me.txt_marca_vehiculo.Name = "txt_marca_vehiculo"
        Me.txt_marca_vehiculo.Size = New System.Drawing.Size(140, 20)
        Me.txt_marca_vehiculo.TabIndex = 13
        '
        'pnl_transportista
        '
        Me.pnl_transportista.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnl_transportista.Controls.Add(Me.Label15)
        Me.pnl_transportista.Controls.Add(Me.Label14)
        Me.pnl_transportista.Controls.Add(Me.txt_rtn_otro_transportista)
        Me.pnl_transportista.Controls.Add(Me.txt_otro_transportista)
        Me.pnl_transportista.Location = New System.Drawing.Point(95, 180)
        Me.pnl_transportista.Name = "pnl_transportista"
        Me.pnl_transportista.Size = New System.Drawing.Size(416, 46)
        Me.pnl_transportista.TabIndex = 8
        Me.pnl_transportista.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(269, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "RTN:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Nombre:"
        '
        'txt_rtn_otro_transportista
        '
        Me.txt_rtn_otro_transportista.Location = New System.Drawing.Point(272, 20)
        Me.txt_rtn_otro_transportista.Name = "txt_rtn_otro_transportista"
        Me.txt_rtn_otro_transportista.Size = New System.Drawing.Size(132, 20)
        Me.txt_rtn_otro_transportista.TabIndex = 13
        '
        'txt_otro_transportista
        '
        Me.txt_otro_transportista.Location = New System.Drawing.Point(9, 20)
        Me.txt_otro_transportista.Name = "txt_otro_transportista"
        Me.txt_otro_transportista.Size = New System.Drawing.Size(245, 20)
        Me.txt_otro_transportista.TabIndex = 13
        '
        'datos_externos
        '
        Me.datos_externos.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.datos_externos.Controls.Add(Me.Label8)
        Me.datos_externos.Controls.Add(Me.txt_direccion)
        Me.datos_externos.Controls.Add(Me.Label9)
        Me.datos_externos.Controls.Add(Me.txt_rtn)
        Me.datos_externos.Controls.Add(Me.Label10)
        Me.datos_externos.Controls.Add(Me.txt_destino)
        Me.datos_externos.Location = New System.Drawing.Point(95, 70)
        Me.datos_externos.Name = "datos_externos"
        Me.datos_externos.Size = New System.Drawing.Size(415, 77)
        Me.datos_externos.TabIndex = 7
        Me.datos_externos.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Destino Externo:"
        '
        'txt_direccion
        '
        Me.txt_direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_direccion.Location = New System.Drawing.Point(6, 53)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(261, 20)
        Me.txt_direccion.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Direccion:"
        '
        'txt_rtn
        '
        Me.txt_rtn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_rtn.Location = New System.Drawing.Point(273, 53)
        Me.txt_rtn.Name = "txt_rtn"
        Me.txt_rtn.Size = New System.Drawing.Size(139, 20)
        Me.txt_rtn.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(270, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "RTN:"
        '
        'txt_destino
        '
        Me.txt_destino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_destino.Location = New System.Drawing.Point(6, 18)
        Me.txt_destino.Name = "txt_destino"
        Me.txt_destino.Size = New System.Drawing.Size(406, 20)
        Me.txt_destino.TabIndex = 4
        '
        'cmb_otro_vehiculo
        '
        Me.cmb_otro_vehiculo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_otro_vehiculo.AutoSize = True
        Me.cmb_otro_vehiculo.Location = New System.Drawing.Point(973, 155)
        Me.cmb_otro_vehiculo.Name = "cmb_otro_vehiculo"
        Me.cmb_otro_vehiculo.Size = New System.Drawing.Size(50, 17)
        Me.cmb_otro_vehiculo.TabIndex = 3
        Me.cmb_otro_vehiculo.Text = "otro?"
        Me.cmb_otro_vehiculo.UseVisualStyleBackColor = True
        '
        'cmb_otro_transportista
        '
        Me.cmb_otro_transportista.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_otro_transportista.AutoSize = True
        Me.cmb_otro_transportista.Location = New System.Drawing.Point(516, 155)
        Me.cmb_otro_transportista.Name = "cmb_otro_transportista"
        Me.cmb_otro_transportista.Size = New System.Drawing.Size(50, 17)
        Me.cmb_otro_transportista.TabIndex = 3
        Me.cmb_otro_transportista.Text = "otro?"
        Me.cmb_otro_transportista.UseVisualStyleBackColor = True
        '
        'cmb_otro_destino
        '
        Me.cmb_otro_destino.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_otro_destino.AutoSize = True
        Me.cmb_otro_destino.Location = New System.Drawing.Point(516, 41)
        Me.cmb_otro_destino.Name = "cmb_otro_destino"
        Me.cmb_otro_destino.Size = New System.Drawing.Size(66, 30)
        Me.cmb_otro_destino.TabIndex = 3
        Me.cmb_otro_destino.Text = "otro " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "destino?"
        Me.cmb_otro_destino.UseVisualStyleBackColor = True
        '
        'lbl_almacen_destino
        '
        Me.lbl_almacen_destino.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_almacen_destino.AutoSize = True
        Me.lbl_almacen_destino.Location = New System.Drawing.Point(129, 46)
        Me.lbl_almacen_destino.Name = "lbl_almacen_destino"
        Me.lbl_almacen_destino.Size = New System.Drawing.Size(19, 13)
        Me.lbl_almacen_destino.TabIndex = 4
        Me.lbl_almacen_destino.Text = "    "
        Me.lbl_almacen_destino.Visible = False
        '
        'lbl_almacen
        '
        Me.lbl_almacen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_almacen.AutoSize = True
        Me.lbl_almacen.Location = New System.Drawing.Point(129, 16)
        Me.lbl_almacen.Name = "lbl_almacen"
        Me.lbl_almacen.Size = New System.Drawing.Size(19, 13)
        Me.lbl_almacen.TabIndex = 4
        Me.lbl_almacen.Text = "    "
        Me.lbl_almacen.Visible = False
        '
        'lbl_empresa
        '
        Me.lbl_empresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_empresa.AutoSize = True
        Me.lbl_empresa.Location = New System.Drawing.Point(154, 16)
        Me.lbl_empresa.Name = "lbl_empresa"
        Me.lbl_empresa.Size = New System.Drawing.Size(31, 13)
        Me.lbl_empresa.TabIndex = 4
        Me.lbl_empresa.Text = "        "
        Me.lbl_empresa.Visible = False
        '
        'txt_buscar_transportista
        '
        Me.txt_buscar_transportista.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_buscar_transportista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_buscar_transportista.Location = New System.Drawing.Point(366, 154)
        Me.txt_buscar_transportista.Name = "txt_buscar_transportista"
        Me.txt_buscar_transportista.Size = New System.Drawing.Size(144, 20)
        Me.txt_buscar_transportista.TabIndex = 8
        '
        'cmb_fecha_final
        '
        Me.cmb_fecha_final.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_fecha_final.Location = New System.Drawing.Point(743, 98)
        Me.cmb_fecha_final.Name = "cmb_fecha_final"
        Me.cmb_fecha_final.Size = New System.Drawing.Size(198, 20)
        Me.cmb_fecha_final.TabIndex = 12
        '
        'cmb_fecha_inicio
        '
        Me.cmb_fecha_inicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_fecha_inicio.Location = New System.Drawing.Point(743, 72)
        Me.cmb_fecha_inicio.Name = "cmb_fecha_inicio"
        Me.cmb_fecha_inicio.Size = New System.Drawing.Size(211, 20)
        Me.cmb_fecha_inicio.TabIndex = 11
        '
        'cmb_destino
        '
        Me.cmb_destino.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_destino.DropDownWidth = 700
        Me.cmb_destino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_destino.FormattingEnabled = True
        Me.cmb_destino.Location = New System.Drawing.Point(95, 43)
        Me.cmb_destino.Name = "cmb_destino"
        Me.cmb_destino.Size = New System.Drawing.Size(415, 21)
        Me.cmb_destino.TabIndex = 2
        '
        'cmb_vehiculo
        '
        Me.cmb_vehiculo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_vehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_vehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_vehiculo.FormattingEnabled = True
        Me.cmb_vehiculo.Location = New System.Drawing.Point(743, 153)
        Me.cmb_vehiculo.Name = "cmb_vehiculo"
        Me.cmb_vehiculo.Size = New System.Drawing.Size(227, 21)
        Me.cmb_vehiculo.TabIndex = 10
        '
        'cmb_motivo
        '
        Me.cmb_motivo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_motivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_motivo.FormattingEnabled = True
        Me.cmb_motivo.Location = New System.Drawing.Point(95, 234)
        Me.cmb_motivo.Name = "cmb_motivo"
        Me.cmb_motivo.Size = New System.Drawing.Size(416, 21)
        Me.cmb_motivo.TabIndex = 9
        '
        'cmb_concepto_entrada
        '
        Me.cmb_concepto_entrada.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_concepto_entrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_concepto_entrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_concepto_entrada.FormattingEnabled = True
        Me.cmb_concepto_entrada.Location = New System.Drawing.Point(743, 45)
        Me.cmb_concepto_entrada.Name = "cmb_concepto_entrada"
        Me.cmb_concepto_entrada.Size = New System.Drawing.Size(265, 21)
        Me.cmb_concepto_entrada.TabIndex = 7
        '
        'cmb_concepto_salida
        '
        Me.cmb_concepto_salida.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_concepto_salida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_concepto_salida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_concepto_salida.FormattingEnabled = True
        Me.cmb_concepto_salida.Location = New System.Drawing.Point(743, 19)
        Me.cmb_concepto_salida.Name = "cmb_concepto_salida"
        Me.cmb_concepto_salida.Size = New System.Drawing.Size(265, 21)
        Me.cmb_concepto_salida.TabIndex = 7
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(823, 263)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Recomendados:"
        '
        'cmb_transportista
        '
        Me.cmb_transportista.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_transportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_transportista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_transportista.FormattingEnabled = True
        Me.cmb_transportista.Location = New System.Drawing.Point(95, 153)
        Me.cmb_transportista.Name = "cmb_transportista"
        Me.cmb_transportista.Size = New System.Drawing.Size(265, 21)
        Me.cmb_transportista.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(925, 238)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(23, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "lbs"
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(692, 263)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Viajes:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(589, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha Final de Traslado:"
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(593, 237)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(144, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Capacidad de Vehículo:"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(677, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Vehiculo:"
        '
        'cmb_remite
        '
        Me.cmb_remite.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_remite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_remite.DropDownWidth = 700
        Me.cmb_remite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_remite.FormattingEnabled = True
        Me.cmb_remite.Location = New System.Drawing.Point(95, 16)
        Me.cmb_remite.Name = "cmb_remite"
        Me.cmb_remite.Size = New System.Drawing.Size(415, 21)
        Me.cmb_remite.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 26)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Motivo de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Traslado:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(624, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Concepto Entrada:"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(633, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Concepto Salida:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(585, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Fecha Inicio de Traslado:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Transportista:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Destino:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Remite:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgv_detalles)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 321)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1026, 365)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'dgv_detalles
        '
        Me.dgv_detalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_detalles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_cantidad, Me.col_cargar, Me.col_codigo, Me.col_descripcion, Me.peso, Me.peso_total, Me.lote})
        Me.dgv_detalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_detalles.Location = New System.Drawing.Point(3, 16)
        Me.dgv_detalles.MultiSelect = False
        Me.dgv_detalles.Name = "dgv_detalles"
        Me.dgv_detalles.Size = New System.Drawing.Size(1020, 346)
        Me.dgv_detalles.TabIndex = 0
        '
        'col_cantidad
        '
        Me.col_cantidad.HeaderText = "Cantidad"
        Me.col_cantidad.Name = "col_cantidad"
        Me.col_cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'col_cargar
        '
        Me.col_cargar.FillWeight = 50.0!
        Me.col_cargar.HeaderText = "..."
        Me.col_cargar.Name = "col_cargar"
        Me.col_cargar.Text = "..."
        Me.col_cargar.Width = 20
        '
        'col_codigo
        '
        Me.col_codigo.HeaderText = "Codigo"
        Me.col_codigo.Name = "col_codigo"
        Me.col_codigo.ReadOnly = True
        Me.col_codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_codigo.Width = 150
        '
        'col_descripcion
        '
        Me.col_descripcion.HeaderText = "Descripcion"
        Me.col_descripcion.Name = "col_descripcion"
        Me.col_descripcion.ReadOnly = True
        Me.col_descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_descripcion.Width = 400
        '
        'peso
        '
        Me.peso.HeaderText = "Peso Unidad"
        Me.peso.Name = "peso"
        Me.peso.ReadOnly = True
        '
        'peso_total
        '
        Me.peso_total.HeaderText = "Peso Total"
        Me.peso_total.Name = "peso_total"
        Me.peso_total.ReadOnly = True
        '
        'lote
        '
        Me.lote.HeaderText = "Con Lote"
        Me.lote.Name = "lote"
        Me.lote.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1051, 25)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lbl_peso_total
        '
        Me.lbl_peso_total.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbl_peso_total.AutoSize = True
        Me.lbl_peso_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_peso_total.Location = New System.Drawing.Point(561, 702)
        Me.lbl_peso_total.Name = "lbl_peso_total"
        Me.lbl_peso_total.Size = New System.Drawing.Size(0, 20)
        Me.lbl_peso_total.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(460, 702)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 20)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Peso total:"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.Location = New System.Drawing.Point(919, 692)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(96, 42)
        Me.btn_cancelar.TabIndex = 16
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = Global.Disar.My.Resources.Resources.img_aceptar
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_aceptar.Location = New System.Drawing.Point(37, 692)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(96, 42)
        Me.btn_aceptar.TabIndex = 15
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'frm_guia_remision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1051, 746)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lbl_peso_total)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_guia_remision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guia de Remision"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnl_vehiculo.ResumeLayout(False)
        Me.pnl_vehiculo.PerformLayout()
        Me.pnl_transportista.ResumeLayout(False)
        Me.pnl_transportista.PerformLayout()
        Me.datos_externos.ResumeLayout(False)
        Me.datos_externos.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgv_detalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmb_remite As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_destino As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_transportista As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_motivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgv_detalles As System.Windows.Forms.DataGridView
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents txt_buscar_transportista As System.Windows.Forms.TextBox
    Friend WithEvents cmb_vehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_empresa As System.Windows.Forms.Label
    Friend WithEvents lbl_almacen As System.Windows.Forms.Label
    Friend WithEvents guardar_pdf_dialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cmb_otro_destino As System.Windows.Forms.CheckBox
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents txt_rtn As System.Windows.Forms.TextBox
    Friend WithEvents txt_destino As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents datos_externos As System.Windows.Forms.Panel
    Friend WithEvents lbl_peso_total As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_concepto_salida As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_concepto_entrada As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents col_cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_cargar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents col_codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents peso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents peso_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnl_transportista As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_rtn_otro_transportista As System.Windows.Forms.TextBox
    Friend WithEvents txt_otro_transportista As System.Windows.Forms.TextBox
    Friend WithEvents cmb_otro_transportista As System.Windows.Forms.CheckBox
    Friend WithEvents pnl_vehiculo As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_nplaca_vehiculo As System.Windows.Forms.TextBox
    Friend WithEvents txt_marca_vehiculo As System.Windows.Forms.TextBox
    Friend WithEvents cmb_otro_vehiculo As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_almacen_destino As System.Windows.Forms.Label
    Friend WithEvents TxtViajes As System.Windows.Forms.TextBox
    Friend WithEvents TxtVehiculoCapacidad As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtViajesRecomendados As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class
