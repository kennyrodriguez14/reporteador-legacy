<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_agregar_proveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_agregar_proveedores))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.txt_nombre = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_calle = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_municipio = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_rtn = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_pais = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_limite_credito = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_cai = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_contacto_compra = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_contacto_pago = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_manejo_credito = New System.Windows.Forms.CheckBox
        Me.txt_fecha_limite = New System.Windows.Forms.DateTimePicker
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.cmb_tipo = New System.Windows.Forms.ComboBox
        Me.txt_dias_credito = New System.Windows.Forms.NumericUpDown
        Me.txt_forma_pago = New System.Windows.Forms.ComboBox
        Me.txt_tipo_pago = New System.Windows.Forms.ComboBox
        Me.TextDepartamento = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_telefono = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmb_clasificacion = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txt_rango = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        CType(Me.txt_dias_credito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo:"
        '
        'txt_codigo
        '
        Me.txt_codigo.Location = New System.Drawing.Point(105, 49)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(100, 20)
        Me.txt_codigo.TabIndex = 1
        '
        'txt_nombre
        '
        Me.txt_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nombre.Location = New System.Drawing.Point(105, 75)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(446, 20)
        Me.txt_nombre.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre:"
        '
        'txt_calle
        '
        Me.txt_calle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_calle.Location = New System.Drawing.Point(105, 101)
        Me.txt_calle.Name = "txt_calle"
        Me.txt_calle.Size = New System.Drawing.Size(446, 20)
        Me.txt_calle.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(71, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Calle:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Departamento:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(369, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Municipio:"
        '
        'txt_municipio
        '
        Me.txt_municipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_municipio.Location = New System.Drawing.Point(426, 127)
        Me.txt_municipio.Name = "txt_municipio"
        Me.txt_municipio.Size = New System.Drawing.Size(125, 20)
        Me.txt_municipio.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(71, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "RTN:"
        '
        'txt_rtn
        '
        Me.txt_rtn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_rtn.Location = New System.Drawing.Point(105, 153)
        Me.txt_rtn.Name = "txt_rtn"
        Me.txt_rtn.Size = New System.Drawing.Size(211, 20)
        Me.txt_rtn.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(393, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Tipo:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(74, 180)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Pais:"
        '
        'txt_pais
        '
        Me.txt_pais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pais.Location = New System.Drawing.Point(105, 177)
        Me.txt_pais.Name = "txt_pais"
        Me.txt_pais.Size = New System.Drawing.Size(211, 20)
        Me.txt_pais.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(210, 205)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Dias Credito:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(336, 205)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Limite de Credito:"
        '
        'txt_limite_credito
        '
        Me.txt_limite_credito.Enabled = False
        Me.txt_limite_credito.Location = New System.Drawing.Point(426, 202)
        Me.txt_limite_credito.Name = "txt_limite_credito"
        Me.txt_limite_credito.Size = New System.Drawing.Size(125, 20)
        Me.txt_limite_credito.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 232)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Forma de Pago:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(76, 259)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "CAI:"
        '
        'txt_cai
        '
        Me.txt_cai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_cai.Location = New System.Drawing.Point(105, 256)
        Me.txt_cai.Name = "txt_cai"
        Me.txt_cai.Size = New System.Drawing.Size(125, 20)
        Me.txt_cai.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(270, 259)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Fecha Limite:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(134, 371)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Contacto Compra:"
        '
        'txt_contacto_compra
        '
        Me.txt_contacto_compra.Location = New System.Drawing.Point(232, 368)
        Me.txt_contacto_compra.Name = "txt_contacto_compra"
        Me.txt_contacto_compra.Size = New System.Drawing.Size(211, 20)
        Me.txt_contacto_compra.TabIndex = 16
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(130, 345)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Contacto de Pago:"
        '
        'txt_contacto_pago
        '
        Me.txt_contacto_pago.Location = New System.Drawing.Point(232, 342)
        Me.txt_contacto_pago.Name = "txt_contacto_pago"
        Me.txt_contacto_pago.Size = New System.Drawing.Size(211, 20)
        Me.txt_contacto_pago.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(338, 232)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Tipo de Tercero:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Monotype Corsiva", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(179, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(179, 33)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Nuevo Proveedor"
        '
        'txt_manejo_credito
        '
        Me.txt_manejo_credito.AutoSize = True
        Me.txt_manejo_credito.Location = New System.Drawing.Point(93, 203)
        Me.txt_manejo_credito.Name = "txt_manejo_credito"
        Me.txt_manejo_credito.Size = New System.Drawing.Size(112, 17)
        Me.txt_manejo_credito.TabIndex = 8
        Me.txt_manejo_credito.Text = "Manejo de Credito"
        Me.txt_manejo_credito.UseVisualStyleBackColor = True
        '
        'txt_fecha_limite
        '
        Me.txt_fecha_limite.Location = New System.Drawing.Point(339, 256)
        Me.txt_fecha_limite.Name = "txt_fecha_limite"
        Me.txt_fecha_limite.Size = New System.Drawing.Size(211, 20)
        Me.txt_fecha_limite.TabIndex = 14
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Location = New System.Drawing.Point(153, 394)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(102, 48)
        Me.btn_aceptar.TabIndex = 17
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Location = New System.Drawing.Point(317, 394)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(102, 48)
        Me.btn_cancelar.TabIndex = 18
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'cmb_tipo
        '
        Me.cmb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo.FormattingEnabled = True
        Me.cmb_tipo.Items.AddRange(New Object() {"Local", "Extranjero"})
        Me.cmb_tipo.Location = New System.Drawing.Point(426, 153)
        Me.cmb_tipo.Name = "cmb_tipo"
        Me.cmb_tipo.Size = New System.Drawing.Size(125, 21)
        Me.cmb_tipo.TabIndex = 7
        '
        'txt_dias_credito
        '
        Me.txt_dias_credito.Enabled = False
        Me.txt_dias_credito.Location = New System.Drawing.Point(277, 203)
        Me.txt_dias_credito.Name = "txt_dias_credito"
        Me.txt_dias_credito.Size = New System.Drawing.Size(39, 20)
        Me.txt_dias_credito.TabIndex = 9
        '
        'txt_forma_pago
        '
        Me.txt_forma_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txt_forma_pago.FormattingEnabled = True
        Me.txt_forma_pago.Items.AddRange(New Object() {"Transferencia", "Efectivo"})
        Me.txt_forma_pago.Location = New System.Drawing.Point(105, 229)
        Me.txt_forma_pago.Name = "txt_forma_pago"
        Me.txt_forma_pago.Size = New System.Drawing.Size(211, 21)
        Me.txt_forma_pago.TabIndex = 11
        '
        'txt_tipo_pago
        '
        Me.txt_tipo_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txt_tipo_pago.FormattingEnabled = True
        Me.txt_tipo_pago.Items.AddRange(New Object() {"Proveedor Nacional", "Proveedor Extranjero", "Acreedor"})
        Me.txt_tipo_pago.Location = New System.Drawing.Point(426, 229)
        Me.txt_tipo_pago.Name = "txt_tipo_pago"
        Me.txt_tipo_pago.Size = New System.Drawing.Size(125, 21)
        Me.txt_tipo_pago.TabIndex = 12
        '
        'TextDepartamento
        '
        Me.TextDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextDepartamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TextDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.TextDepartamento.FormattingEnabled = True
        Me.TextDepartamento.Items.AddRange(New Object() {"ATLANTIDA", "CHOLUTECA", "COLON", "COMAYAGUA", "COPAN", "CORTES", "EL PARAISO", "FCO MORAZAN", "GRACIAS A DIOS", "INTIBUCA", "ISLAS DE LA BAHIA", "LA PAZ", "LEMPIRA", "OCOTEPEQUE", "OLANCHO", "SANTA BARBARA", "VALLE", "YORO"})
        Me.TextDepartamento.Location = New System.Drawing.Point(105, 126)
        Me.TextDepartamento.Name = "TextDepartamento"
        Me.TextDepartamento.Size = New System.Drawing.Size(211, 21)
        Me.TextDepartamento.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(51, 310)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Telefono:"
        '
        'txt_telefono
        '
        Me.txt_telefono.Location = New System.Drawing.Point(104, 307)
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.Size = New System.Drawing.Size(211, 20)
        Me.txt_telefono.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(354, 310)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Clasificacion:"
        '
        'cmb_clasificacion
        '
        Me.cmb_clasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_clasificacion.FormattingEnabled = True
        Me.cmb_clasificacion.Items.AddRange(New Object() {"Proveedor", "Acreedor"})
        Me.cmb_clasificacion.Location = New System.Drawing.Point(425, 306)
        Me.cmb_clasificacion.Name = "cmb_clasificacion"
        Me.cmb_clasificacion.Size = New System.Drawing.Size(125, 21)
        Me.cmb_clasificacion.TabIndex = 7
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(61, 284)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Rango:"
        '
        'txt_rango
        '
        Me.txt_rango.Location = New System.Drawing.Point(105, 281)
        Me.txt_rango.Name = "txt_rango"
        Me.txt_rango.Size = New System.Drawing.Size(211, 20)
        Me.txt_rango.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(216, 51)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(51, 13)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Empresa:"
        '
        'cmb_empresa
        '
        Me.cmb_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Items.AddRange(New Object() {"SAN RAFAEL", "SR AGRO", "DIMOSA"})
        Me.cmb_empresa.Location = New System.Drawing.Point(273, 48)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(125, 21)
        Me.cmb_empresa.TabIndex = 7
        '
        'frm_agregar_proveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 457)
        Me.Controls.Add(Me.TextDepartamento)
        Me.Controls.Add(Me.txt_forma_pago)
        Me.Controls.Add(Me.txt_dias_credito)
        Me.Controls.Add(Me.txt_tipo_pago)
        Me.Controls.Add(Me.cmb_clasificacion)
        Me.Controls.Add(Me.cmb_empresa)
        Me.Controls.Add(Me.cmb_tipo)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.txt_fecha_limite)
        Me.Controls.Add(Me.txt_manejo_credito)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_rtn)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txt_contacto_pago)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txt_contacto_compra)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txt_cai)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_limite_credito)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_rango)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txt_telefono)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_pais)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_municipio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_calle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.txt_codigo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_agregar_proveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Proveedores"
        CType(Me.txt_dias_credito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_calle As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_municipio As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_rtn As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_pais As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_limite_credito As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_cai As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_contacto_compra As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_contacto_pago As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_manejo_credito As System.Windows.Forms.CheckBox
    Friend WithEvents txt_fecha_limite As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents cmb_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents txt_dias_credito As System.Windows.Forms.NumericUpDown
    Friend WithEvents txt_forma_pago As System.Windows.Forms.ComboBox
    Friend WithEvents txt_tipo_pago As System.Windows.Forms.ComboBox
    Friend WithEvents TextDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_telefono As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmb_clasificacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_rango As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
End Class
