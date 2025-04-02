<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_agregar_productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_agregar_productos))
        Me.Label1 = New System.Windows.Forms.Label
        Me.codigo = New System.Windows.Forms.TextBox
        Me.descripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.factor = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.precio = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.con_lote = New System.Windows.Forms.CheckBox
        Me.aceptar = New System.Windows.Forms.Button
        Me.cancelar = New System.Windows.Forms.Button
        Me.costeo = New System.Windows.Forms.ComboBox
        Me.equema = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.alterno = New System.Windows.Forms.TextBox
        Me.linea = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.entrada = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.salida = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.unidad_empaque = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.volumen = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.peso = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.proveedor = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.precio_teg = New System.Windows.Forms.TextBox
        Me.txt_buscar_proveedor = New System.Windows.Forms.TextBox
        Me.txt_buscar_linea = New System.Windows.Forms.TextBox
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.paletizado_src = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.paletizado_sps = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.paletizado_tocoa = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.ubicacion_src = New System.Windows.Forms.TextBox
        Me.ubicacion_sps = New System.Windows.Forms.TextBox
        Me.ubicacion_tocoa = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.ubicacion_tegus = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.categoria = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.subcategoria = New System.Windows.Forms.ComboBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.megacategoria = New System.Windows.Forms.ComboBox
        Me.paletizado_sr_agro = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.cod_barra = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.codigo_barra_cj = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.lista2 = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.lista3 = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.lista4 = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.lista5 = New System.Windows.Forms.TextBox
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.btn_agregar_multi = New System.Windows.Forms.Button
        Me.grd_multialmacen = New System.Windows.Forms.DataGridView
        CType(Me.grd_multialmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(67, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo:"
        '
        'codigo
        '
        Me.codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.codigo.Location = New System.Drawing.Point(114, 84)
        Me.codigo.Name = "codigo"
        Me.codigo.Size = New System.Drawing.Size(100, 20)
        Me.codigo.TabIndex = 1
        '
        'descripcion
        '
        Me.descripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.descripcion.Location = New System.Drawing.Point(114, 110)
        Me.descripcion.MaxLength = 40
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Size = New System.Drawing.Size(392, 20)
        Me.descripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripcion:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 218)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Linea:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Factor entre uds:"
        '
        'factor
        '
        Me.factor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.factor.Location = New System.Drawing.Point(114, 136)
        Me.factor.Name = "factor"
        Me.factor.Size = New System.Drawing.Size(100, 20)
        Me.factor.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 469)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Precio Publico:"
        '
        'precio
        '
        Me.precio.Location = New System.Drawing.Point(114, 466)
        Me.precio.Name = "precio"
        Me.precio.Size = New System.Drawing.Size(50, 20)
        Me.precio.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(67, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Costeo:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(312, 191)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Esquema:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Monotype Corsiva", 25.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(156, 4)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(216, 41)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Nuevo Producto"
        '
        'con_lote
        '
        Me.con_lote.AutoSize = True
        Me.con_lote.Location = New System.Drawing.Point(223, 190)
        Me.con_lote.Name = "con_lote"
        Me.con_lote.Size = New System.Drawing.Size(52, 17)
        Me.con_lote.TabIndex = 11
        Me.con_lote.Text = "Lotes"
        Me.con_lote.UseVisualStyleBackColor = True
        '
        'aceptar
        '
        Me.aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceptar.Location = New System.Drawing.Point(12, 613)
        Me.aceptar.Name = "aceptar"
        Me.aceptar.Size = New System.Drawing.Size(102, 48)
        Me.aceptar.TabIndex = 17
        Me.aceptar.Text = "Aceptar"
        Me.aceptar.UseVisualStyleBackColor = True
        '
        'cancelar
        '
        Me.cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelar.Location = New System.Drawing.Point(415, 613)
        Me.cancelar.Name = "cancelar"
        Me.cancelar.Size = New System.Drawing.Size(102, 48)
        Me.cancelar.TabIndex = 18
        Me.cancelar.Text = "Cancelar"
        Me.cancelar.UseVisualStyleBackColor = True
        '
        'costeo
        '
        Me.costeo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.costeo.FormattingEnabled = True
        Me.costeo.Items.AddRange(New Object() {"Promedio"})
        Me.costeo.Location = New System.Drawing.Point(114, 188)
        Me.costeo.Name = "costeo"
        Me.costeo.Size = New System.Drawing.Size(100, 21)
        Me.costeo.TabIndex = 13
        '
        'equema
        '
        Me.equema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.equema.FormattingEnabled = True
        Me.equema.Items.AddRange(New Object() {"15%", "Excento"})
        Me.equema.Location = New System.Drawing.Point(372, 188)
        Me.equema.Name = "equema"
        Me.equema.Size = New System.Drawing.Size(134, 21)
        Me.equema.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(351, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Alterno:"
        '
        'alterno
        '
        Me.alterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.alterno.Location = New System.Drawing.Point(395, 84)
        Me.alterno.Name = "alterno"
        Me.alterno.Size = New System.Drawing.Size(111, 20)
        Me.alterno.TabIndex = 2
        '
        'linea
        '
        Me.linea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.linea.FormattingEnabled = True
        Me.linea.Location = New System.Drawing.Point(114, 241)
        Me.linea.Name = "linea"
        Me.linea.Size = New System.Drawing.Size(392, 21)
        Me.linea.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(220, 139)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 13)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Unidad de Entrada:"
        '
        'entrada
        '
        Me.entrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.entrada.FormattingEnabled = True
        Me.entrada.Items.AddRange(New Object() {"cj", "pz"})
        Me.entrada.Location = New System.Drawing.Point(318, 136)
        Me.entrada.Name = "entrada"
        Me.entrada.Size = New System.Drawing.Size(37, 21)
        Me.entrada.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(367, 139)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Unidad de Salida:"
        '
        'salida
        '
        Me.salida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.salida.FormattingEnabled = True
        Me.salida.Items.AddRange(New Object() {"pz", "cj"})
        Me.salida.Location = New System.Drawing.Point(456, 136)
        Me.salida.Name = "salida"
        Me.salida.Size = New System.Drawing.Size(50, 21)
        Me.salida.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(55, 156)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 26)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Unidad " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Empaque:"
        '
        'unidad_empaque
        '
        Me.unidad_empaque.Location = New System.Drawing.Point(114, 162)
        Me.unidad_empaque.Name = "unidad_empaque"
        Me.unidad_empaque.Size = New System.Drawing.Size(100, 20)
        Me.unidad_empaque.TabIndex = 8
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(244, 165)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Volumen:"
        '
        'volumen
        '
        Me.volumen.Location = New System.Drawing.Point(296, 162)
        Me.volumen.Name = "volumen"
        Me.volumen.Size = New System.Drawing.Size(59, 20)
        Me.volumen.TabIndex = 9
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(399, 165)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(34, 13)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Peso:"
        '
        'peso
        '
        Me.peso.Location = New System.Drawing.Point(436, 162)
        Me.peso.Name = "peso"
        Me.peso.Size = New System.Drawing.Size(70, 20)
        Me.peso.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(51, 271)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Proveedor:"
        '
        'proveedor
        '
        Me.proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.proveedor.FormattingEnabled = True
        Me.proveedor.Location = New System.Drawing.Point(114, 294)
        Me.proveedor.Name = "proveedor"
        Me.proveedor.Size = New System.Drawing.Size(392, 21)
        Me.proveedor.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(171, 495)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Lista 6:"
        '
        'precio_teg
        '
        Me.precio_teg.Location = New System.Drawing.Point(211, 491)
        Me.precio_teg.Name = "precio_teg"
        Me.precio_teg.Size = New System.Drawing.Size(50, 20)
        Me.precio_teg.TabIndex = 14
        '
        'txt_buscar_proveedor
        '
        Me.txt_buscar_proveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_buscar_proveedor.Location = New System.Drawing.Point(114, 268)
        Me.txt_buscar_proveedor.Name = "txt_buscar_proveedor"
        Me.txt_buscar_proveedor.Size = New System.Drawing.Size(392, 20)
        Me.txt_buscar_proveedor.TabIndex = 12
        '
        'txt_buscar_linea
        '
        Me.txt_buscar_linea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_buscar_linea.Location = New System.Drawing.Point(114, 215)
        Me.txt_buscar_linea.Name = "txt_buscar_linea"
        Me.txt_buscar_linea.Size = New System.Drawing.Size(392, 20)
        Me.txt_buscar_linea.TabIndex = 12
        '
        'cmb_empresa
        '
        Me.cmb_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Items.AddRange(New Object() {"SAN RAFAEL", "SR AGRO", "DIMOSA"})
        Me.cmb_empresa.Location = New System.Drawing.Point(114, 57)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(125, 21)
        Me.cmb_empresa.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(59, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Empresa:"
        '
        'paletizado_src
        '
        Me.paletizado_src.Location = New System.Drawing.Point(152, 400)
        Me.paletizado_src.Name = "paletizado_src"
        Me.paletizado_src.Size = New System.Drawing.Size(50, 20)
        Me.paletizado_src.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(51, 400)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Paletizado:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(117, 405)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "SRC:"
        '
        'paletizado_sps
        '
        Me.paletizado_sps.Location = New System.Drawing.Point(239, 400)
        Me.paletizado_sps.Name = "paletizado_sps"
        Me.paletizado_sps.Size = New System.Drawing.Size(50, 20)
        Me.paletizado_sps.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(208, 405)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "SPS:"
        '
        'paletizado_tocoa
        '
        Me.paletizado_tocoa.Location = New System.Drawing.Point(331, 400)
        Me.paletizado_tocoa.Name = "paletizado_tocoa"
        Me.paletizado_tocoa.Size = New System.Drawing.Size(50, 20)
        Me.paletizado_tocoa.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(296, 405)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Saba:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(52, 429)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(58, 13)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "Ubicacion:"
        '
        'ubicacion_src
        '
        Me.ubicacion_src.Location = New System.Drawing.Point(152, 426)
        Me.ubicacion_src.Name = "ubicacion_src"
        Me.ubicacion_src.Size = New System.Drawing.Size(50, 20)
        Me.ubicacion_src.TabIndex = 3
        '
        'ubicacion_sps
        '
        Me.ubicacion_sps.Location = New System.Drawing.Point(239, 426)
        Me.ubicacion_sps.Name = "ubicacion_sps"
        Me.ubicacion_sps.Size = New System.Drawing.Size(50, 20)
        Me.ubicacion_sps.TabIndex = 3
        '
        'ubicacion_tocoa
        '
        Me.ubicacion_tocoa.Location = New System.Drawing.Point(331, 426)
        Me.ubicacion_tocoa.Name = "ubicacion_tocoa"
        Me.ubicacion_tocoa.Size = New System.Drawing.Size(50, 20)
        Me.ubicacion_tocoa.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(117, 429)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(32, 13)
        Me.Label23.TabIndex = 21
        Me.Label23.Text = "SRC:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(208, 429)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(31, 13)
        Me.Label24.TabIndex = 21
        Me.Label24.Text = "SPS:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(296, 429)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(35, 13)
        Me.Label25.TabIndex = 21
        Me.Label25.Text = "Saba:"
        '
        'ubicacion_tegus
        '
        Me.ubicacion_tegus.Location = New System.Drawing.Point(456, 426)
        Me.ubicacion_tegus.Name = "ubicacion_tegus"
        Me.ubicacion_tegus.Size = New System.Drawing.Size(50, 20)
        Me.ubicacion_tegus.TabIndex = 3
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(387, 429)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(69, 13)
        Me.Label26.TabIndex = 21
        Me.Label26.Text = "Tegucigalpa:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(55, 324)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 13)
        Me.Label27.TabIndex = 6
        Me.Label27.Text = "Categoria:"
        '
        'categoria
        '
        Me.categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.categoria.FormattingEnabled = True
        Me.categoria.Location = New System.Drawing.Point(114, 321)
        Me.categoria.Name = "categoria"
        Me.categoria.Size = New System.Drawing.Size(120, 21)
        Me.categoria.TabIndex = 15
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(37, 350)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(73, 13)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "Subcategoria:"
        '
        'subcategoria
        '
        Me.subcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.subcategoria.FormattingEnabled = True
        Me.subcategoria.Location = New System.Drawing.Point(114, 347)
        Me.subcategoria.Name = "subcategoria"
        Me.subcategoria.Size = New System.Drawing.Size(120, 21)
        Me.subcategoria.TabIndex = 15
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(245, 324)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(81, 13)
        Me.Label29.TabIndex = 6
        Me.Label29.Text = "Megacategoria:"
        '
        'megacategoria
        '
        Me.megacategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.megacategoria.FormattingEnabled = True
        Me.megacategoria.Location = New System.Drawing.Point(331, 321)
        Me.megacategoria.Name = "megacategoria"
        Me.megacategoria.Size = New System.Drawing.Size(120, 21)
        Me.megacategoria.TabIndex = 15
        '
        'paletizado_sr_agro
        '
        Me.paletizado_sr_agro.Location = New System.Drawing.Point(456, 402)
        Me.paletizado_sr_agro.Name = "paletizado_sr_agro"
        Me.paletizado_sr_agro.Size = New System.Drawing.Size(50, 20)
        Me.paletizado_sr_agro.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(406, 405)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(50, 13)
        Me.Label30.TabIndex = 21
        Me.Label30.Text = "SR Agro:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(39, 377)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(71, 13)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "Codigo Barra:"
        '
        'cod_barra
        '
        Me.cod_barra.Location = New System.Drawing.Point(114, 374)
        Me.cod_barra.Name = "cod_barra"
        Me.cod_barra.Size = New System.Drawing.Size(100, 20)
        Me.cod_barra.TabIndex = 12
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(219, 377)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(95, 13)
        Me.Label32.TabIndex = 6
        Me.Label32.Text = "Codigo Barra Caja:"
        '
        'codigo_barra_cj
        '
        Me.codigo_barra_cj.Location = New System.Drawing.Point(315, 374)
        Me.codigo_barra_cj.Name = "codigo_barra_cj"
        Me.codigo_barra_cj.Size = New System.Drawing.Size(100, 20)
        Me.codigo_barra_cj.TabIndex = 12
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(170, 468)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(41, 13)
        Me.Label33.TabIndex = 6
        Me.Label33.Text = "Lista 2:"
        '
        'lista2
        '
        Me.lista2.Location = New System.Drawing.Point(211, 465)
        Me.lista2.Name = "lista2"
        Me.lista2.Size = New System.Drawing.Size(50, 20)
        Me.lista2.TabIndex = 12
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(268, 468)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(41, 13)
        Me.Label34.TabIndex = 6
        Me.Label34.Text = "Lista 3:"
        '
        'lista3
        '
        Me.lista3.Location = New System.Drawing.Point(315, 465)
        Me.lista3.Name = "lista3"
        Me.lista3.Size = New System.Drawing.Size(50, 20)
        Me.lista3.TabIndex = 12
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(372, 469)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(41, 13)
        Me.Label35.TabIndex = 6
        Me.Label35.Text = "Lista 4:"
        '
        'lista4
        '
        Me.lista4.Location = New System.Drawing.Point(419, 466)
        Me.lista4.Name = "lista4"
        Me.lista4.Size = New System.Drawing.Size(50, 20)
        Me.lista4.TabIndex = 12
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(67, 495)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(41, 13)
        Me.Label36.TabIndex = 6
        Me.Label36.Text = "Lista 5:"
        '
        'lista5
        '
        Me.lista5.Location = New System.Drawing.Point(114, 492)
        Me.lista5.Name = "lista5"
        Me.lista5.Size = New System.Drawing.Size(50, 20)
        Me.lista5.TabIndex = 12
        '
        'cmb_almacen
        '
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(160, 516)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(173, 21)
        Me.cmb_almacen.TabIndex = 23
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(87, 519)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(72, 13)
        Me.Label38.TabIndex = 24
        Me.Label38.Text = "Multialmacen:"
        '
        'btn_agregar_multi
        '
        Me.btn_agregar_multi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar_multi.Location = New System.Drawing.Point(339, 516)
        Me.btn_agregar_multi.Name = "btn_agregar_multi"
        Me.btn_agregar_multi.Size = New System.Drawing.Size(102, 21)
        Me.btn_agregar_multi.TabIndex = 17
        Me.btn_agregar_multi.Text = "Agregar"
        Me.btn_agregar_multi.UseVisualStyleBackColor = True
        '
        'grd_multialmacen
        '
        Me.grd_multialmacen.AllowUserToAddRows = False
        Me.grd_multialmacen.AllowUserToDeleteRows = False
        Me.grd_multialmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_multialmacen.Location = New System.Drawing.Point(136, 543)
        Me.grd_multialmacen.Name = "grd_multialmacen"
        Me.grd_multialmacen.ReadOnly = True
        Me.grd_multialmacen.Size = New System.Drawing.Size(256, 118)
        Me.grd_multialmacen.TabIndex = 25
        '
        'frm_agregar_productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 673)
        Me.Controls.Add(Me.grd_multialmacen)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.cmb_almacen)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmb_empresa)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.megacategoria)
        Me.Controls.Add(Me.subcategoria)
        Me.Controls.Add(Me.categoria)
        Me.Controls.Add(Me.equema)
        Me.Controls.Add(Me.salida)
        Me.Controls.Add(Me.entrada)
        Me.Controls.Add(Me.proveedor)
        Me.Controls.Add(Me.linea)
        Me.Controls.Add(Me.costeo)
        Me.Controls.Add(Me.cancelar)
        Me.Controls.Add(Me.btn_agregar_multi)
        Me.Controls.Add(Me.aceptar)
        Me.Controls.Add(Me.con_lote)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.precio_teg)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_buscar_linea)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txt_buscar_proveedor)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.codigo_barra_cj)
        Me.Controls.Add(Me.cod_barra)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.lista5)
        Me.Controls.Add(Me.lista4)
        Me.Controls.Add(Me.lista3)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.lista2)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.precio)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.peso)
        Me.Controls.Add(Me.volumen)
        Me.Controls.Add(Me.unidad_empaque)
        Me.Controls.Add(Me.factor)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ubicacion_tegus)
        Me.Controls.Add(Me.ubicacion_tocoa)
        Me.Controls.Add(Me.ubicacion_sps)
        Me.Controls.Add(Me.paletizado_sr_agro)
        Me.Controls.Add(Me.paletizado_tocoa)
        Me.Controls.Add(Me.ubicacion_src)
        Me.Controls.Add(Me.paletizado_sps)
        Me.Controls.Add(Me.paletizado_src)
        Me.Controls.Add(Me.descripcion)
        Me.Controls.Add(Me.alterno)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.codigo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_agregar_productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        CType(Me.grd_multialmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents codigo As System.Windows.Forms.TextBox
    Friend WithEvents descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents factor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents precio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents con_lote As System.Windows.Forms.CheckBox
    Friend WithEvents aceptar As System.Windows.Forms.Button
    Friend WithEvents cancelar As System.Windows.Forms.Button
    Friend WithEvents costeo As System.Windows.Forms.ComboBox
    Friend WithEvents equema As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents alterno As System.Windows.Forms.TextBox
    Friend WithEvents linea As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents entrada As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents salida As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents unidad_empaque As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents volumen As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents peso As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents precio_teg As System.Windows.Forms.TextBox
    Friend WithEvents txt_buscar_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_buscar_linea As System.Windows.Forms.TextBox
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents paletizado_src As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents paletizado_sps As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents paletizado_tocoa As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ubicacion_src As System.Windows.Forms.TextBox
    Friend WithEvents ubicacion_sps As System.Windows.Forms.TextBox
    Friend WithEvents ubicacion_tocoa As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ubicacion_tegus As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents categoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents subcategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents megacategoria As System.Windows.Forms.ComboBox
    Friend WithEvents paletizado_sr_agro As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cod_barra As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents codigo_barra_cj As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lista2 As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lista3 As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lista4 As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lista5 As System.Windows.Forms.TextBox
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents btn_agregar_multi As System.Windows.Forms.Button
    Friend WithEvents grd_multialmacen As System.Windows.Forms.DataGridView
End Class
