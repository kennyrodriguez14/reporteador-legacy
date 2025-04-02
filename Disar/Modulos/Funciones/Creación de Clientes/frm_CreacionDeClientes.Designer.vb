<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CreacionDeClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CreacionDeClientes))
        Me.DataClientes = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnCoordenadas = New System.Windows.Forms.Button()
        Me.BtnReactivar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.BtnSuspender = New System.Windows.Forms.Button()
        Me.BtnActualizar = New System.Windows.Forms.Button()
        Me.TextBuscar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.GroupPrincipal = New System.Windows.Forms.GroupBox()
        Me.GroupClienteNuevo = New System.Windows.Forms.GroupBox()
        Me.TextCarga = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.CheckCargill = New System.Windows.Forms.CheckBox()
        Me.CheckNestle = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DateFechaCreacion = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextEncuesta = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextTipoPago = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ComboSemana = New System.Windows.Forms.ComboBox()
        Me.TextVendedor = New System.Windows.Forms.TextBox()
        Me.ComboDiaVisita = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboSucursal = New System.Windows.Forms.ComboBox()
        Me.ComboVendedor = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextLong = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextLat = New System.Windows.Forms.TextBox()
        Me.LSemana = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextDepartamento = New System.Windows.Forms.ComboBox()
        Me.TextNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextDireccion = New System.Windows.Forms.TextBox()
        Me.TextMunicipio = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextColonia = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TtxOPL = New System.Windows.Forms.TextBox()
        Me.ComboTipo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextInterno = New System.Windows.Forms.TextBox()
        Me.TextColgate = New System.Windows.Forms.TextBox()
        Me.TextNestle = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextTelefono = New System.Windows.Forms.TextBox()
        Me.TextPropietario = New System.Windows.Forms.TextBox()
        Me.TextRTN = New System.Windows.Forms.TextBox()
        CType(Me.DataClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupPrincipal.SuspendLayout()
        Me.GroupClienteNuevo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataClientes
        '
        Me.DataClientes.AllowUserToAddRows = False
        Me.DataClientes.AllowUserToDeleteRows = False
        Me.DataClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataClientes.Location = New System.Drawing.Point(8, 113)
        Me.DataClientes.Name = "DataClientes"
        Me.DataClientes.ReadOnly = True
        Me.DataClientes.Size = New System.Drawing.Size(817, 400)
        Me.DataClientes.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnCoordenadas)
        Me.GroupBox1.Controls.Add(Me.BtnReactivar)
        Me.GroupBox1.Controls.Add(Me.btnModificar)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.BtnSuspender)
        Me.GroupBox1.Controls.Add(Me.BtnActualizar)
        Me.GroupBox1.Controls.Add(Me.TextBuscar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnNuevo)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(819, 88)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BtnCoordenadas
        '
        Me.BtnCoordenadas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCoordenadas.Image = Global.Disar.My.Resources.Resources.Check_Round_32
        Me.BtnCoordenadas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCoordenadas.Location = New System.Drawing.Point(486, 17)
        Me.BtnCoordenadas.Name = "BtnCoordenadas"
        Me.BtnCoordenadas.Size = New System.Drawing.Size(78, 63)
        Me.BtnCoordenadas.TabIndex = 8
        Me.BtnCoordenadas.Text = "Certificar Coordenadas"
        Me.BtnCoordenadas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCoordenadas.UseVisualStyleBackColor = True
        '
        'BtnReactivar
        '
        Me.BtnReactivar.Image = Global.Disar.My.Resources.Resources.Ordering_32
        Me.BtnReactivar.Location = New System.Drawing.Point(311, 19)
        Me.BtnReactivar.Name = "BtnReactivar"
        Me.BtnReactivar.Size = New System.Drawing.Size(68, 55)
        Me.BtnReactivar.TabIndex = 7
        Me.BtnReactivar.Text = "Reactivar"
        Me.BtnReactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnReactivar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Image = Global.Disar.My.Resources.Resources.File_Edit_32
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModificar.Location = New System.Drawing.Point(89, 19)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(68, 55)
        Me.btnModificar.TabIndex = 6
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(571, 21)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(242, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'BtnSuspender
        '
        Me.BtnSuspender.Image = Global.Disar.My.Resources.Resources.Adblock_Dark_32
        Me.BtnSuspender.Location = New System.Drawing.Point(237, 19)
        Me.BtnSuspender.Name = "BtnSuspender"
        Me.BtnSuspender.Size = New System.Drawing.Size(68, 55)
        Me.BtnSuspender.TabIndex = 4
        Me.BtnSuspender.Text = "Suspender"
        Me.BtnSuspender.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnSuspender.UseVisualStyleBackColor = True
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Image = Global.Disar.My.Resources.Resources.Arrow_double_anticlockwise_x_32
        Me.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnActualizar.Location = New System.Drawing.Point(163, 19)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(68, 55)
        Me.BtnActualizar.TabIndex = 3
        Me.BtnActualizar.Text = "Actualizar"
        Me.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnActualizar.UseVisualStyleBackColor = True
        '
        'TextBuscar
        '
        Me.TextBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBuscar.Location = New System.Drawing.Point(610, 48)
        Me.TextBuscar.Name = "TextBuscar"
        Me.TextBuscar.Size = New System.Drawing.Size(203, 20)
        Me.TextBuscar.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(568, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Buscar:"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Image = Global.Disar.My.Resources.Resources.img_ingresar_rutas
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnNuevo.Location = New System.Drawing.Point(15, 19)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(68, 55)
        Me.BtnNuevo.TabIndex = 0
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'GroupPrincipal
        '
        Me.GroupPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPrincipal.Controls.Add(Me.DataClientes)
        Me.GroupPrincipal.Controls.Add(Me.GroupBox1)
        Me.GroupPrincipal.Location = New System.Drawing.Point(13, 12)
        Me.GroupPrincipal.Name = "GroupPrincipal"
        Me.GroupPrincipal.Size = New System.Drawing.Size(837, 543)
        Me.GroupPrincipal.TabIndex = 3
        Me.GroupPrincipal.TabStop = False
        '
        'GroupClienteNuevo
        '
        Me.GroupClienteNuevo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupClienteNuevo.Controls.Add(Me.TextCarga)
        Me.GroupClienteNuevo.Controls.Add(Me.Label21)
        Me.GroupClienteNuevo.Controls.Add(Me.PictureBox1)
        Me.GroupClienteNuevo.Controls.Add(Me.GroupBox7)
        Me.GroupClienteNuevo.Controls.Add(Me.Button1)
        Me.GroupClienteNuevo.Controls.Add(Me.BtnCancelar)
        Me.GroupClienteNuevo.Controls.Add(Me.BtnGuardar)
        Me.GroupClienteNuevo.Controls.Add(Me.GroupBox6)
        Me.GroupClienteNuevo.Controls.Add(Me.GroupBox4)
        Me.GroupClienteNuevo.Controls.Add(Me.GroupBox3)
        Me.GroupClienteNuevo.Controls.Add(Me.GroupBox5)
        Me.GroupClienteNuevo.Controls.Add(Me.GroupBox2)
        Me.GroupClienteNuevo.Location = New System.Drawing.Point(13, 13)
        Me.GroupClienteNuevo.Name = "GroupClienteNuevo"
        Me.GroupClienteNuevo.Size = New System.Drawing.Size(837, 542)
        Me.GroupClienteNuevo.TabIndex = 4
        Me.GroupClienteNuevo.TabStop = False
        '
        'TextCarga
        '
        Me.TextCarga.Location = New System.Drawing.Point(757, 16)
        Me.TextCarga.Name = "TextCarga"
        Me.TextCarga.Size = New System.Drawing.Size(58, 20)
        Me.TextCarga.TabIndex = 8
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(689, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 13)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "Cargar Info:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(296, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(244, 67)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckCargill)
        Me.GroupBox7.Controls.Add(Me.CheckNestle)
        Me.GroupBox7.Controls.Add(Me.Label19)
        Me.GroupBox7.Controls.Add(Me.Label20)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 469)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(439, 48)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        '
        'CheckCargill
        '
        Me.CheckCargill.AutoSize = True
        Me.CheckCargill.Location = New System.Drawing.Point(364, 19)
        Me.CheckCargill.Name = "CheckCargill"
        Me.CheckCargill.Size = New System.Drawing.Size(15, 14)
        Me.CheckCargill.TabIndex = 1
        Me.CheckCargill.UseVisualStyleBackColor = True
        '
        'CheckNestle
        '
        Me.CheckNestle.AutoSize = True
        Me.CheckNestle.Enabled = False
        Me.CheckNestle.Location = New System.Drawing.Point(115, 19)
        Me.CheckNestle.Name = "CheckNestle"
        Me.CheckNestle.Size = New System.Drawing.Size(15, 14)
        Me.CheckNestle.TabIndex = 0
        Me.CheckNestle.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(277, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Bloqueo Cargill:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(32, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(82, 13)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Bloqueo Nestlé:"
        '
        'Button1
        '
        Me.Button1.Image = Global.Disar.My.Resources.Resources.Report_321
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(474, 474)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 60)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Limpiar campos"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCancelar.Location = New System.Drawing.Point(689, 474)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(60, 60)
        Me.BtnCancelar.TabIndex = 1
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnGuardar.Location = New System.Drawing.Point(755, 474)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(60, 60)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.DateFechaCreacion)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Controls.Add(Me.TextEncuesta)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.TextTipoPago)
        Me.GroupBox6.Location = New System.Drawing.Point(474, 355)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(341, 104)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(15, 77)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Encuesta:"
        '
        'DateFechaCreacion
        '
        Me.DateFechaCreacion.Enabled = False
        Me.DateFechaCreacion.Location = New System.Drawing.Point(119, 47)
        Me.DateFechaCreacion.Name = "DateFechaCreacion"
        Me.DateFechaCreacion.Size = New System.Drawing.Size(199, 20)
        Me.DateFechaCreacion.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Fecha de Creación:"
        '
        'TextEncuesta
        '
        Me.TextEncuesta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEncuesta.Location = New System.Drawing.Point(119, 74)
        Me.TextEncuesta.Name = "TextEncuesta"
        Me.TextEncuesta.Size = New System.Drawing.Size(199, 20)
        Me.TextEncuesta.TabIndex = 2
        Me.TextEncuesta.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Tipo de pago:"
        '
        'TextTipoPago
        '
        Me.TextTipoPago.Enabled = False
        Me.TextTipoPago.Location = New System.Drawing.Point(119, 19)
        Me.TextTipoPago.Name = "TextTipoPago"
        Me.TextTipoPago.Size = New System.Drawing.Size(199, 20)
        Me.TextTipoPago.TabIndex = 0
        Me.TextTipoPago.Text = "CONTADO"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ComboSemana)
        Me.GroupBox4.Controls.Add(Me.TextVendedor)
        Me.GroupBox4.Controls.Add(Me.ComboDiaVisita)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.ComboSucursal)
        Me.GroupBox4.Controls.Add(Me.ComboVendedor)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.TextLong)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.TextLat)
        Me.GroupBox4.Controls.Add(Me.LSemana)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 278)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(439, 182)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'ComboSemana
        '
        Me.ComboSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSemana.FormattingEnabled = True
        Me.ComboSemana.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.ComboSemana.Location = New System.Drawing.Point(323, 49)
        Me.ComboSemana.Name = "ComboSemana"
        Me.ComboSemana.Size = New System.Drawing.Size(56, 21)
        Me.ComboSemana.TabIndex = 4
        '
        'TextVendedor
        '
        Me.TextVendedor.Location = New System.Drawing.Point(115, 20)
        Me.TextVendedor.Name = "TextVendedor"
        Me.TextVendedor.Size = New System.Drawing.Size(51, 20)
        Me.TextVendedor.TabIndex = 0
        '
        'ComboDiaVisita
        '
        Me.ComboDiaVisita.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboDiaVisita.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboDiaVisita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDiaVisita.FormattingEnabled = True
        Me.ComboDiaVisita.Items.AddRange(New Object() {"LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES", "SABADO"})
        Me.ComboDiaVisita.Location = New System.Drawing.Point(115, 49)
        Me.ComboDiaVisita.Name = "ComboDiaVisita"
        Me.ComboDiaVisita.Size = New System.Drawing.Size(171, 21)
        Me.ComboDiaVisita.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(34, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Día de Visita:"
        '
        'ComboSucursal
        '
        Me.ComboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSucursal.FormattingEnabled = True
        Me.ComboSucursal.Items.AddRange(New Object() {"SAN PEDRO SULA", "SANTA ROSA DE COPÁN", "SABA", "TEGUCIGALPA"})
        Me.ComboSucursal.Location = New System.Drawing.Point(115, 132)
        Me.ComboSucursal.Name = "ComboSucursal"
        Me.ComboSucursal.Size = New System.Drawing.Size(264, 21)
        Me.ComboSucursal.TabIndex = 7
        '
        'ComboVendedor
        '
        Me.ComboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVendedor.FormattingEnabled = True
        Me.ComboVendedor.Location = New System.Drawing.Point(172, 19)
        Me.ComboVendedor.Name = "ComboVendedor"
        Me.ComboVendedor.Size = New System.Drawing.Size(207, 21)
        Me.ComboVendedor.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(34, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Vendedor:"
        '
        'TextLong
        '
        Me.TextLong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextLong.Location = New System.Drawing.Point(115, 78)
        Me.TextLong.MaxLength = 12
        Me.TextLong.Name = "TextLong"
        Me.TextLong.Size = New System.Drawing.Size(264, 20)
        Me.TextLong.TabIndex = 5
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(34, 137)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Sucursal:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(34, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Longitud:"
        '
        'TextLat
        '
        Me.TextLat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextLat.Location = New System.Drawing.Point(115, 105)
        Me.TextLat.MaxLength = 12
        Me.TextLat.Name = "TextLat"
        Me.TextLat.Size = New System.Drawing.Size(264, 20)
        Me.TextLat.TabIndex = 6
        '
        'LSemana
        '
        Me.LSemana.AutoSize = True
        Me.LSemana.Location = New System.Drawing.Point(292, 52)
        Me.LSemana.Name = "LSemana"
        Me.LSemana.Size = New System.Drawing.Size(31, 13)
        Me.LSemana.TabIndex = 0
        Me.LSemana.Text = "Sem:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(34, 108)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Latitud:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.TextDepartamento)
        Me.GroupBox3.Controls.Add(Me.TextNombre)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.TextDireccion)
        Me.GroupBox3.Controls.Add(Me.TextMunicipio)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.TextColonia)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 73)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(439, 187)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre:"
        '
        'TextDepartamento
        '
        Me.TextDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextDepartamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TextDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.TextDepartamento.FormattingEnabled = True
        Me.TextDepartamento.Items.AddRange(New Object() {"ATLANTIDA", "CHOLUTECA", "COLON", "COMAYAGUA", "COPAN", "CORTES", "EL PARAISO", "FCO MORAZAN", "GRACIAS A DIOS", "INTIBUCA", "ISLAS DE LA BAHIA", "LA PAZ", "LEMPIRA", "OCOTEPEQUE", "OLANCHO", "SANTA BARBARA", "VALLE", "YORO"})
        Me.TextDepartamento.Location = New System.Drawing.Point(115, 137)
        Me.TextDepartamento.Name = "TextDepartamento"
        Me.TextDepartamento.Size = New System.Drawing.Size(264, 21)
        Me.TextDepartamento.TabIndex = 4
        '
        'TextNombre
        '
        Me.TextNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombre.Location = New System.Drawing.Point(115, 29)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(264, 20)
        Me.TextNombre.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Dirección:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Departamento:"
        '
        'TextDireccion
        '
        Me.TextDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDireccion.Location = New System.Drawing.Point(115, 56)
        Me.TextDireccion.Name = "TextDireccion"
        Me.TextDireccion.Size = New System.Drawing.Size(264, 20)
        Me.TextDireccion.TabIndex = 1
        '
        'TextMunicipio
        '
        Me.TextMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextMunicipio.Location = New System.Drawing.Point(115, 110)
        Me.TextMunicipio.Name = "TextMunicipio"
        Me.TextMunicipio.Size = New System.Drawing.Size(264, 20)
        Me.TextMunicipio.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Colonia:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Municipio:"
        '
        'TextColonia
        '
        Me.TextColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextColonia.Location = New System.Drawing.Point(115, 83)
        Me.TextColonia.Name = "TextColonia"
        Me.TextColonia.Size = New System.Drawing.Size(264, 20)
        Me.TextColonia.TabIndex = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.TtxOPL)
        Me.GroupBox5.Controls.Add(Me.ComboTipo)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.TextInterno)
        Me.GroupBox5.Controls.Add(Me.TextColgate)
        Me.GroupBox5.Controls.Add(Me.TextNestle)
        Me.GroupBox5.Location = New System.Drawing.Point(474, 205)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(341, 144)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(12, 113)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 13)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "Código OPL:"
        '
        'TtxOPL
        '
        Me.TtxOPL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TtxOPL.Location = New System.Drawing.Point(93, 110)
        Me.TtxOPL.Name = "TtxOPL"
        Me.TtxOPL.Size = New System.Drawing.Size(225, 20)
        Me.TtxOPL.TabIndex = 5
        '
        'ComboTipo
        '
        Me.ComboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipo.FormattingEnabled = True
        Me.ComboTipo.Location = New System.Drawing.Point(93, 17)
        Me.ComboTipo.Name = "ComboTipo"
        Me.ComboTipo.Size = New System.Drawing.Size(225, 21)
        Me.ComboTipo.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Tipo:"
        '
        'TextInterno
        '
        Me.TextInterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextInterno.Enabled = False
        Me.TextInterno.Location = New System.Drawing.Point(93, 87)
        Me.TextInterno.Name = "TextInterno"
        Me.TextInterno.Size = New System.Drawing.Size(225, 20)
        Me.TextInterno.TabIndex = 3
        '
        'TextColgate
        '
        Me.TextColgate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextColgate.Enabled = False
        Me.TextColgate.Location = New System.Drawing.Point(93, 64)
        Me.TextColgate.Name = "TextColgate"
        Me.TextColgate.Size = New System.Drawing.Size(225, 20)
        Me.TextColgate.TabIndex = 2
        '
        'TextNestle
        '
        Me.TextNestle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNestle.Enabled = False
        Me.TextNestle.Location = New System.Drawing.Point(93, 41)
        Me.TextNestle.Name = "TextNestle"
        Me.TextNestle.Size = New System.Drawing.Size(225, 20)
        Me.TextNestle.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TextTelefono)
        Me.GroupBox2.Controls.Add(Me.TextPropietario)
        Me.GroupBox2.Controls.Add(Me.TextRTN)
        Me.GroupBox2.Location = New System.Drawing.Point(474, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(341, 132)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Teléfono:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Propietario:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "RTN:"
        '
        'TextTelefono
        '
        Me.TextTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTelefono.Location = New System.Drawing.Point(93, 83)
        Me.TextTelefono.Name = "TextTelefono"
        Me.TextTelefono.Size = New System.Drawing.Size(225, 20)
        Me.TextTelefono.TabIndex = 2
        '
        'TextPropietario
        '
        Me.TextPropietario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextPropietario.Location = New System.Drawing.Point(93, 56)
        Me.TextPropietario.Name = "TextPropietario"
        Me.TextPropietario.Size = New System.Drawing.Size(225, 20)
        Me.TextPropietario.TabIndex = 1
        '
        'TextRTN
        '
        Me.TextRTN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRTN.Location = New System.Drawing.Point(93, 29)
        Me.TextRTN.Name = "TextRTN"
        Me.TextRTN.Size = New System.Drawing.Size(225, 20)
        Me.TextRTN.TabIndex = 0
        '
        'frm_CreacionDeClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 583)
        Me.Controls.Add(Me.GroupClienteNuevo)
        Me.Controls.Add(Me.GroupPrincipal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_CreacionDeClientes"
        Me.Text = "Creación de Clientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupPrincipal.ResumeLayout(False)
        Me.GroupClienteNuevo.ResumeLayout(False)
        Me.GroupClienteNuevo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataClientes As System.Windows.Forms.DataGridView
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBuscar As System.Windows.Forms.TextBox
    Friend WithEvents GroupPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents GroupClienteNuevo As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TextMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextColonia As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextPropietario As System.Windows.Forms.TextBox
    Friend WithEvents TextRTN As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextTelefono As System.Windows.Forms.TextBox
    Friend WithEvents ComboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextColgate As System.Windows.Forms.TextBox
    Friend WithEvents TextNestle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DateFechaCreacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextTipoPago As System.Windows.Forms.TextBox
    Friend WithEvents TextInterno As System.Windows.Forms.TextBox
    Friend WithEvents ComboDiaVisita As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents ComboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextLong As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextLat As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents TextEncuesta As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnActualizar As System.Windows.Forms.Button
    Friend WithEvents TextVendedor As System.Windows.Forms.TextBox
    Friend WithEvents TextDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CheckCargill As System.Windows.Forms.CheckBox
    Friend WithEvents CheckNestle As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LSemana As System.Windows.Forms.Label
    Friend WithEvents ComboSemana As System.Windows.Forms.ComboBox
    Friend WithEvents BtnSuspender As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents TextCarga As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents BtnReactivar As System.Windows.Forms.Button
    Friend WithEvents BtnCoordenadas As System.Windows.Forms.Button
    Friend WithEvents Label22 As Label
    Friend WithEvents TtxOPL As TextBox
End Class
