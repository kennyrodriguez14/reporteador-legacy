<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_error_recepcion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_error_recepcion))
        Me.ingreso = New System.Windows.Forms.Panel
        Me.CmbEmpresaIns = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmbSolucion = New System.Windows.Forms.ComboBox
        Me.cmb_almacen_ins = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbResponsable = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.cmbDia = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtdescripcion2 = New System.Windows.Forms.TextBox
        Me.txtdescripcion1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtcodigo_reportado = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtcodigo_apartado = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcantidad = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Cbox_Sucursal = New System.Windows.Forms.ComboBox
        Me.filtro = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.fin = New System.Windows.Forms.DateTimePicker
        Me.cmb_sucursal_rpt = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.inicio = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.grdDatos = New System.Windows.Forms.DataGridView
        Me.ComboProveedores = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.ComboProveedorEnvia = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.ingreso.SuspendLayout()
        Me.filtro.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ingreso
        '
        Me.ingreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ingreso.Controls.Add(Me.ComboProveedorEnvia)
        Me.ingreso.Controls.Add(Me.Label16)
        Me.ingreso.Controls.Add(Me.CmbEmpresaIns)
        Me.ingreso.Controls.Add(Me.Label14)
        Me.ingreso.Controls.Add(Me.cmbSolucion)
        Me.ingreso.Controls.Add(Me.cmb_almacen_ins)
        Me.ingreso.Controls.Add(Me.Label2)
        Me.ingreso.Controls.Add(Me.cmbResponsable)
        Me.ingreso.Controls.Add(Me.Label11)
        Me.ingreso.Controls.Add(Me.Button3)
        Me.ingreso.Controls.Add(Me.Button2)
        Me.ingreso.Controls.Add(Me.btnCancelar)
        Me.ingreso.Controls.Add(Me.Label1)
        Me.ingreso.Controls.Add(Me.btnAceptar)
        Me.ingreso.Controls.Add(Me.cmbDia)
        Me.ingreso.Controls.Add(Me.Label4)
        Me.ingreso.Controls.Add(Me.txtdescripcion2)
        Me.ingreso.Controls.Add(Me.txtdescripcion1)
        Me.ingreso.Controls.Add(Me.Label10)
        Me.ingreso.Controls.Add(Me.Label8)
        Me.ingreso.Controls.Add(Me.txtcodigo_reportado)
        Me.ingreso.Controls.Add(Me.Label9)
        Me.ingreso.Controls.Add(Me.txtcodigo_apartado)
        Me.ingreso.Controls.Add(Me.Label7)
        Me.ingreso.Controls.Add(Me.txtcantidad)
        Me.ingreso.Controls.Add(Me.Label3)
        Me.ingreso.Location = New System.Drawing.Point(226, 152)
        Me.ingreso.Name = "ingreso"
        Me.ingreso.Size = New System.Drawing.Size(494, 351)
        Me.ingreso.TabIndex = 40
        Me.ingreso.Visible = False
        '
        'CmbEmpresaIns
        '
        Me.CmbEmpresaIns.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CmbEmpresaIns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEmpresaIns.FormattingEnabled = True
        Me.CmbEmpresaIns.Items.AddRange(New Object() {"SAN RAFAEL", "DIMOSA"})
        Me.CmbEmpresaIns.Location = New System.Drawing.Point(119, 35)
        Me.CmbEmpresaIns.Name = "CmbEmpresaIns"
        Me.CmbEmpresaIns.Size = New System.Drawing.Size(317, 21)
        Me.CmbEmpresaIns.TabIndex = 23
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(65, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Empresa:"
        '
        'cmbSolucion
        '
        Me.cmbSolucion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbSolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSolucion.FormattingEnabled = True
        Me.cmbSolucion.Location = New System.Drawing.Point(119, 269)
        Me.cmbSolucion.Name = "cmbSolucion"
        Me.cmbSolucion.Size = New System.Drawing.Size(318, 21)
        Me.cmbSolucion.TabIndex = 15
        '
        'cmb_almacen_ins
        '
        Me.cmb_almacen_ins.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_almacen_ins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen_ins.FormattingEnabled = True
        Me.cmb_almacen_ins.Location = New System.Drawing.Point(119, 62)
        Me.cmb_almacen_ins.Name = "cmb_almacen_ins"
        Me.cmb_almacen_ins.Size = New System.Drawing.Size(318, 21)
        Me.cmb_almacen_ins.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Sucursal:"
        '
        'cmbResponsable
        '
        Me.cmbResponsable.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResponsable.FormattingEnabled = True
        Me.cmbResponsable.Location = New System.Drawing.Point(119, 114)
        Me.cmbResponsable.Name = "cmbResponsable"
        Me.cmbResponsable.Size = New System.Drawing.Size(318, 21)
        Me.cmbResponsable.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(41, 117)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Responsable:"
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button3.Location = New System.Drawing.Point(119, 217)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(27, 20)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "?"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Location = New System.Drawing.Point(119, 165)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(27, 20)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "?"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(405, 310)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Fecha:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(21, 310)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'cmbDia
        '
        Me.cmbDia.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbDia.Location = New System.Drawing.Point(119, 6)
        Me.cmbDia.Name = "cmbDia"
        Me.cmbDia.Size = New System.Drawing.Size(318, 20)
        Me.cmbDia.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 273)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Solucion:"
        '
        'txtdescripcion2
        '
        Me.txtdescripcion2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtdescripcion2.Location = New System.Drawing.Point(119, 243)
        Me.txtdescripcion2.Name = "txtdescripcion2"
        Me.txtdescripcion2.ReadOnly = True
        Me.txtdescripcion2.Size = New System.Drawing.Size(317, 20)
        Me.txtdescripcion2.TabIndex = 14
        '
        'txtdescripcion1
        '
        Me.txtdescripcion1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtdescripcion1.Location = New System.Drawing.Point(119, 191)
        Me.txtdescripcion1.Name = "txtdescripcion1"
        Me.txtdescripcion1.ReadOnly = True
        Me.txtdescripcion1.Size = New System.Drawing.Size(317, 20)
        Me.txtdescripcion1.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(47, 246)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Descripcion:"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(47, 194)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Descripcion:"
        '
        'txtcodigo_reportado
        '
        Me.txtcodigo_reportado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtcodigo_reportado.Location = New System.Drawing.Point(152, 217)
        Me.txtcodigo_reportado.Name = "txtcodigo_reportado"
        Me.txtcodigo_reportado.ReadOnly = True
        Me.txtcodigo_reportado.Size = New System.Drawing.Size(284, 20)
        Me.txtcodigo_reportado.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 220)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Codigo Cargado:"
        '
        'txtcodigo_apartado
        '
        Me.txtcodigo_apartado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtcodigo_apartado.Location = New System.Drawing.Point(152, 165)
        Me.txtcodigo_apartado.Name = "txtcodigo_apartado"
        Me.txtcodigo_apartado.ReadOnly = True
        Me.txtcodigo_apartado.Size = New System.Drawing.Size(284, 20)
        Me.txtcodigo_apartado.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Codigo Reporte:"
        '
        'txtcantidad
        '
        Me.txtcantidad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtcantidad.Location = New System.Drawing.Point(119, 141)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(317, 20)
        Me.txtcantidad.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Cantidad:"
        '
        'Cbox_Sucursal
        '
        Me.Cbox_Sucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cbox_Sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbox_Sucursal.FormattingEnabled = True
        Me.Cbox_Sucursal.Items.AddRange(New Object() {"SAN RAFAEL", "DIMOSA"})
        Me.Cbox_Sucursal.Location = New System.Drawing.Point(67, 11)
        Me.Cbox_Sucursal.Name = "Cbox_Sucursal"
        Me.Cbox_Sucursal.Size = New System.Drawing.Size(220, 21)
        Me.Cbox_Sucursal.TabIndex = 21
        '
        'filtro
        '
        Me.filtro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtro.Controls.Add(Me.ComboProveedores)
        Me.filtro.Controls.Add(Me.Label15)
        Me.filtro.Controls.Add(Me.Cbox_Sucursal)
        Me.filtro.Controls.Add(Me.Label13)
        Me.filtro.Controls.Add(Me.fin)
        Me.filtro.Controls.Add(Me.cmb_sucursal_rpt)
        Me.filtro.Controls.Add(Me.Label12)
        Me.filtro.Controls.Add(Me.Label6)
        Me.filtro.Controls.Add(Me.Button1)
        Me.filtro.Controls.Add(Me.inicio)
        Me.filtro.Controls.Add(Me.Label5)
        Me.filtro.Location = New System.Drawing.Point(0, 37)
        Me.filtro.Name = "filtro"
        Me.filtro.Size = New System.Drawing.Size(947, 70)
        Me.filtro.TabIndex = 39
        Me.filtro.TabStop = False
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Empresa:"
        '
        'fin
        '
        Me.fin.Location = New System.Drawing.Point(634, 42)
        Me.fin.Name = "fin"
        Me.fin.Size = New System.Drawing.Size(215, 20)
        Me.fin.TabIndex = 3
        '
        'cmb_sucursal_rpt
        '
        Me.cmb_sucursal_rpt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_sucursal_rpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal_rpt.FormattingEnabled = True
        Me.cmb_sucursal_rpt.Location = New System.Drawing.Point(67, 39)
        Me.cmb_sucursal_rpt.Name = "cmb_sucursal_rpt"
        Me.cmb_sucursal_rpt.Size = New System.Drawing.Size(220, 21)
        Me.cmb_sucursal_rpt.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Sucursal:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(604, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Fin:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(864, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 19)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Generar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'inicio
        '
        Me.inicio.Location = New System.Drawing.Point(374, 42)
        Me.inicio.Name = "inicio"
        Me.inicio.Size = New System.Drawing.Size(215, 20)
        Me.inicio.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(337, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Inicio:"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.NuevoToolStripMenuItem.Text = "Nuevo"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Disar.My.Resources.Resources.File_Blue
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(77, 22)
        Me.ToolStripDropDownButton1.Text = "Archivo"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(947, 25)
        Me.ToolStrip1.TabIndex = 38
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'grdDatos
        '
        Me.grdDatos.AllowUserToAddRows = False
        Me.grdDatos.AllowUserToDeleteRows = False
        Me.grdDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grdDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDatos.Location = New System.Drawing.Point(-10, 113)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.ReadOnly = True
        Me.grdDatos.Size = New System.Drawing.Size(967, 412)
        Me.grdDatos.TabIndex = 41
        '
        'ComboProveedores
        '
        Me.ComboProveedores.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ComboProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboProveedores.DropDownWidth = 300
        Me.ComboProveedores.FormattingEnabled = True
        Me.ComboProveedores.Items.AddRange(New Object() {"SAN RAFAEL", "DIMOSA"})
        Me.ComboProveedores.Location = New System.Drawing.Point(363, 11)
        Me.ComboProveedores.Name = "ComboProveedores"
        Me.ComboProveedores.Size = New System.Drawing.Size(220, 21)
        Me.ComboProveedores.TabIndex = 23
        Me.ComboProveedores.Visible = False
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(302, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Proveedor:"
        Me.Label15.Visible = False
        '
        'ComboProveedorEnvia
        '
        Me.ComboProveedorEnvia.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ComboProveedorEnvia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboProveedorEnvia.FormattingEnabled = True
        Me.ComboProveedorEnvia.Location = New System.Drawing.Point(119, 87)
        Me.ComboProveedorEnvia.Name = "ComboProveedorEnvia"
        Me.ComboProveedorEnvia.Size = New System.Drawing.Size(318, 21)
        Me.ComboProveedorEnvia.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(52, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Proveedor:"
        '
        'frm_error_recepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 528)
        Me.Controls.Add(Me.ingreso)
        Me.Controls.Add(Me.filtro)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grdDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_error_recepcion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Errores de Recepción"
        Me.ingreso.ResumeLayout(False)
        Me.ingreso.PerformLayout()
        Me.filtro.ResumeLayout(False)
        Me.filtro.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ingreso As System.Windows.Forms.Panel
    Friend WithEvents CmbEmpresaIns As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbSolucion As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_almacen_ins As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cmbDia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdescripcion2 As System.Windows.Forms.TextBox
    Friend WithEvents txtdescripcion1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo_reportado As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo_apartado As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cbox_Sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents filtro As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_sucursal_rpt As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents grdDatos As System.Windows.Forms.DataGridView
    Friend WithEvents ComboProveedores As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ComboProveedorEnvia As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
