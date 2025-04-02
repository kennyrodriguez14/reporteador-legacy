<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_sobrantes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_sobrantes))
        Me.ingreso = New System.Windows.Forms.Panel
        Me.CmbEmpresaIns = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtObservacion = New System.Windows.Forms.RichTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbEntregador = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.cmbDia = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtdescripcion1 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtcodigo_apartado = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRuta = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtcantidad = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.inicio = New System.Windows.Forms.DateTimePicker
        Me.grdDatos = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CambiarStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.fin = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.Cbox_Sucursal = New System.Windows.Forms.ComboBox
        Me.filtro = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.ingreso.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.filtro.SuspendLayout()
        Me.SuspendLayout()
        '
        'ingreso
        '
        Me.ingreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ingreso.Controls.Add(Me.CmbEmpresaIns)
        Me.ingreso.Controls.Add(Me.Label14)
        Me.ingreso.Controls.Add(Me.cmb_almacen)
        Me.ingreso.Controls.Add(Me.Label10)
        Me.ingreso.Controls.Add(Me.txtObservacion)
        Me.ingreso.Controls.Add(Me.Label9)
        Me.ingreso.Controls.Add(Me.cmbEntregador)
        Me.ingreso.Controls.Add(Me.Button2)
        Me.ingreso.Controls.Add(Me.btnCancelar)
        Me.ingreso.Controls.Add(Me.Label1)
        Me.ingreso.Controls.Add(Me.btnAceptar)
        Me.ingreso.Controls.Add(Me.cmbDia)
        Me.ingreso.Controls.Add(Me.Label4)
        Me.ingreso.Controls.Add(Me.txtdescripcion1)
        Me.ingreso.Controls.Add(Me.Label8)
        Me.ingreso.Controls.Add(Me.txtcodigo_apartado)
        Me.ingreso.Controls.Add(Me.Label7)
        Me.ingreso.Controls.Add(Me.txtRuta)
        Me.ingreso.Controls.Add(Me.Label2)
        Me.ingreso.Controls.Add(Me.txtcantidad)
        Me.ingreso.Controls.Add(Me.Label3)
        Me.ingreso.Location = New System.Drawing.Point(263, 160)
        Me.ingreso.Name = "ingreso"
        Me.ingreso.Size = New System.Drawing.Size(494, 324)
        Me.ingreso.TabIndex = 39
        Me.ingreso.Visible = False
        '
        'CmbEmpresaIns
        '
        Me.CmbEmpresaIns.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CmbEmpresaIns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEmpresaIns.FormattingEnabled = True
        Me.CmbEmpresaIns.Items.AddRange(New Object() {"SAN RAFAEL", "DIMOSA"})
        Me.CmbEmpresaIns.Location = New System.Drawing.Point(124, 11)
        Me.CmbEmpresaIns.Name = "CmbEmpresaIns"
        Me.CmbEmpresaIns.Size = New System.Drawing.Size(317, 21)
        Me.CmbEmpresaIns.TabIndex = 26
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(70, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Empresa:"
        '
        'cmb_almacen
        '
        Me.cmb_almacen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(124, 38)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(318, 21)
        Me.cmb_almacen.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(67, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Sucursal:"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(125, 228)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(318, 51)
        Me.txtObservacion.TabIndex = 8
        Me.txtObservacion.Text = ""
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(49, 231)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Observacion:"
        '
        'cmbEntregador
        '
        Me.cmbEntregador.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbEntregador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntregador.FormattingEnabled = True
        Me.cmbEntregador.Location = New System.Drawing.Point(124, 195)
        Me.cmbEntregador.Name = "cmbEntregador"
        Me.cmbEntregador.Size = New System.Drawing.Size(318, 21)
        Me.cmbEntregador.TabIndex = 7
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Location = New System.Drawing.Point(129, 91)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(27, 20)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "?"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(416, 298)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(79, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Fecha:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(3, 298)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'cmbDia
        '
        Me.cmbDia.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbDia.Location = New System.Drawing.Point(125, 65)
        Me.cmbDia.Name = "cmbDia"
        Me.cmbDia.Size = New System.Drawing.Size(318, 20)
        Me.cmbDia.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Entregador:"
        '
        'txtdescripcion1
        '
        Me.txtdescripcion1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtdescripcion1.Location = New System.Drawing.Point(126, 117)
        Me.txtdescripcion1.Name = "txtdescripcion1"
        Me.txtdescripcion1.ReadOnly = True
        Me.txtdescripcion1.Size = New System.Drawing.Size(317, 20)
        Me.txtdescripcion1.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(53, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Descripcion:"
        '
        'txtcodigo_apartado
        '
        Me.txtcodigo_apartado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtcodigo_apartado.Location = New System.Drawing.Point(159, 91)
        Me.txtcodigo_apartado.Name = "txtcodigo_apartado"
        Me.txtcodigo_apartado.ReadOnly = True
        Me.txtcodigo_apartado.Size = New System.Drawing.Size(284, 20)
        Me.txtcodigo_apartado.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(76, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Codigo:"
        '
        'txtRuta
        '
        Me.txtRuta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtRuta.Location = New System.Drawing.Point(125, 169)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(317, 20)
        Me.txtRuta.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(86, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Ruta:"
        '
        'txtcantidad
        '
        Me.txtcantidad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtcantidad.Location = New System.Drawing.Point(126, 143)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(317, 20)
        Me.txtcantidad.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(67, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Cantidad:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(372, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Inicio:"
        '
        'inicio
        '
        Me.inicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.inicio.Location = New System.Drawing.Point(408, 43)
        Me.inicio.Name = "inicio"
        Me.inicio.Size = New System.Drawing.Size(194, 20)
        Me.inicio.TabIndex = 1
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
        Me.grdDatos.Location = New System.Drawing.Point(12, 137)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.ReadOnly = True
        Me.grdDatos.Size = New System.Drawing.Size(997, 384)
        Me.grdDatos.TabIndex = 40
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.Location = New System.Drawing.Point(827, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 19)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Generar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(608, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Fin:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1015, 25)
        Me.ToolStrip1.TabIndex = 41
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.CambiarStatusToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Disar.My.Resources.Resources.File_Blue
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(77, 22)
        Me.ToolStripDropDownButton1.Text = "Archivo"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.NuevoToolStripMenuItem.Text = "Nuevo"
        '
        'CambiarStatusToolStripMenuItem
        '
        Me.CambiarStatusToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Arrow_double_anticlockwise_x_32
        Me.CambiarStatusToolStripMenuItem.Name = "CambiarStatusToolStripMenuItem"
        Me.CambiarStatusToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.CambiarStatusToolStripMenuItem.Text = "Cambiar Verificacion"
        '
        'fin
        '
        Me.fin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.fin.Location = New System.Drawing.Point(629, 43)
        Me.fin.Name = "fin"
        Me.fin.Size = New System.Drawing.Size(192, 20)
        Me.fin.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(76, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Sucursal:"
        '
        'Cbox_Sucursal
        '
        Me.Cbox_Sucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cbox_Sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbox_Sucursal.FormattingEnabled = True
        Me.Cbox_Sucursal.Items.AddRange(New Object() {"SAN RAFAEL", "SR AGRO", "DIMOSA"})
        Me.Cbox_Sucursal.Location = New System.Drawing.Point(126, 12)
        Me.Cbox_Sucursal.Name = "Cbox_Sucursal"
        Me.Cbox_Sucursal.Size = New System.Drawing.Size(240, 21)
        Me.Cbox_Sucursal.TabIndex = 26
        '
        'filtro
        '
        Me.filtro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtro.Controls.Add(Me.Cbox_Sucursal)
        Me.filtro.Controls.Add(Me.Label13)
        Me.filtro.Controls.Add(Me.cmb_sucursal)
        Me.filtro.Controls.Add(Me.Label11)
        Me.filtro.Controls.Add(Me.fin)
        Me.filtro.Controls.Add(Me.Label6)
        Me.filtro.Controls.Add(Me.Button1)
        Me.filtro.Controls.Add(Me.inicio)
        Me.filtro.Controls.Add(Me.Label5)
        Me.filtro.Location = New System.Drawing.Point(12, 44)
        Me.filtro.Name = "filtro"
        Me.filtro.Size = New System.Drawing.Size(997, 75)
        Me.filtro.TabIndex = 38
        Me.filtro.TabStop = False
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(76, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Empresa:"
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(125, 42)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(241, 21)
        Me.cmb_sucursal.TabIndex = 24
        '
        'frm_sobrantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 536)
        Me.Controls.Add(Me.ingreso)
        Me.Controls.Add(Me.grdDatos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.filtro)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_sobrantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sobrantes"
        Me.ingreso.ResumeLayout(False)
        Me.ingreso.PerformLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.filtro.ResumeLayout(False)
        Me.filtro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ingreso As System.Windows.Forms.Panel
    Friend WithEvents CmbEmpresaIns As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.RichTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbEntregador As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cmbDia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdescripcion1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo_apartado As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdDatos As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Cbox_Sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents filtro As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
End Class
