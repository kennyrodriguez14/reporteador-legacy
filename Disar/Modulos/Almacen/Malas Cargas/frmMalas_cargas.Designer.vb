<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMalas_cargas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMalas_cargas))
        Me.ingreso = New System.Windows.Forms.Panel
        Me.txtobservacion = New System.Windows.Forms.RichTextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.cmbDia = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbEncargado = New System.Windows.Forms.ComboBox
        Me.txtdescripcion2 = New System.Windows.Forms.TextBox
        Me.txtdescripcion1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtcodigo_cargado = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtcodigo_reporte = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcantidad = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.grdDatos = New System.Windows.Forms.DataGridView
        Me.filtro = New System.Windows.Forms.GroupBox
        Me.fin = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.inicio = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.ingreso.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.filtro.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ingreso
        '
        Me.ingreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ingreso.Controls.Add(Me.Label11)
        Me.ingreso.Controls.Add(Me.cmb_sucursal)
        Me.ingreso.Controls.Add(Me.txtobservacion)
        Me.ingreso.Controls.Add(Me.Button3)
        Me.ingreso.Controls.Add(Me.Button2)
        Me.ingreso.Controls.Add(Me.btnCancelar)
        Me.ingreso.Controls.Add(Me.Label1)
        Me.ingreso.Controls.Add(Me.btnAceptar)
        Me.ingreso.Controls.Add(Me.cmbDia)
        Me.ingreso.Controls.Add(Me.Label2)
        Me.ingreso.Controls.Add(Me.Label4)
        Me.ingreso.Controls.Add(Me.cmbEncargado)
        Me.ingreso.Controls.Add(Me.txtdescripcion2)
        Me.ingreso.Controls.Add(Me.txtdescripcion1)
        Me.ingreso.Controls.Add(Me.Label10)
        Me.ingreso.Controls.Add(Me.Label8)
        Me.ingreso.Controls.Add(Me.txtcodigo_cargado)
        Me.ingreso.Controls.Add(Me.Label9)
        Me.ingreso.Controls.Add(Me.txtcodigo_reporte)
        Me.ingreso.Controls.Add(Me.Label7)
        Me.ingreso.Controls.Add(Me.txtcantidad)
        Me.ingreso.Controls.Add(Me.Label3)
        Me.ingreso.Location = New System.Drawing.Point(239, 86)
        Me.ingreso.Name = "ingreso"
        Me.ingreso.Size = New System.Drawing.Size(494, 360)
        Me.ingreso.TabIndex = 26
        Me.ingreso.Visible = False
        '
        'txtobservacion
        '
        Me.txtobservacion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtobservacion.Location = New System.Drawing.Point(135, 242)
        Me.txtobservacion.Name = "txtobservacion"
        Me.txtobservacion.Size = New System.Drawing.Size(318, 82)
        Me.txtobservacion.TabIndex = 15
        Me.txtobservacion.Text = ""
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button3.Location = New System.Drawing.Point(135, 153)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(27, 20)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "?"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Location = New System.Drawing.Point(135, 101)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(27, 20)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "?"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(416, 334)
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
        Me.Label1.Location = New System.Drawing.Point(85, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Fecha:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(3, 334)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'cmbDia
        '
        Me.cmbDia.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbDia.Location = New System.Drawing.Point(131, 22)
        Me.cmbDia.Name = "cmbDia"
        Me.cmbDia.Size = New System.Drawing.Size(318, 20)
        Me.cmbDia.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Encargado:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(55, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Observacion:"
        '
        'cmbEncargado
        '
        Me.cmbEncargado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbEncargado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEncargado.FormattingEnabled = True
        Me.cmbEncargado.Location = New System.Drawing.Point(132, 205)
        Me.cmbEncargado.Name = "cmbEncargado"
        Me.cmbEncargado.Size = New System.Drawing.Size(318, 21)
        Me.cmbEncargado.TabIndex = 14
        '
        'txtdescripcion2
        '
        Me.txtdescripcion2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtdescripcion2.Location = New System.Drawing.Point(132, 179)
        Me.txtdescripcion2.Name = "txtdescripcion2"
        Me.txtdescripcion2.ReadOnly = True
        Me.txtdescripcion2.Size = New System.Drawing.Size(317, 20)
        Me.txtdescripcion2.TabIndex = 13
        '
        'txtdescripcion1
        '
        Me.txtdescripcion1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtdescripcion1.Location = New System.Drawing.Point(132, 127)
        Me.txtdescripcion1.Name = "txtdescripcion1"
        Me.txtdescripcion1.ReadOnly = True
        Me.txtdescripcion1.Size = New System.Drawing.Size(317, 20)
        Me.txtdescripcion1.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(59, 182)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Descripcion:"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(59, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Descripcion:"
        '
        'txtcodigo_cargado
        '
        Me.txtcodigo_cargado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtcodigo_cargado.Location = New System.Drawing.Point(165, 153)
        Me.txtcodigo_cargado.Name = "txtcodigo_cargado"
        Me.txtcodigo_cargado.ReadOnly = True
        Me.txtcodigo_cargado.Size = New System.Drawing.Size(284, 20)
        Me.txtcodigo_cargado.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(39, 156)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Codigo Cargado:"
        '
        'txtcodigo_reporte
        '
        Me.txtcodigo_reporte.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtcodigo_reporte.Location = New System.Drawing.Point(165, 101)
        Me.txtcodigo_reporte.Name = "txtcodigo_reporte"
        Me.txtcodigo_reporte.ReadOnly = True
        Me.txtcodigo_reporte.Size = New System.Drawing.Size(284, 20)
        Me.txtcodigo_reporte.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Codigo Reporte:"
        '
        'txtcantidad
        '
        Me.txtcantidad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtcantidad.Location = New System.Drawing.Point(132, 75)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(317, 20)
        Me.txtcantidad.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Cantidad:"
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
        Me.grdDatos.Location = New System.Drawing.Point(12, 86)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.ReadOnly = True
        Me.grdDatos.Size = New System.Drawing.Size(941, 360)
        Me.grdDatos.TabIndex = 28
        '
        'filtro
        '
        Me.filtro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtro.Controls.Add(Me.Label12)
        Me.filtro.Controls.Add(Me.fin)
        Me.filtro.Controls.Add(Me.cmb_almacen)
        Me.filtro.Controls.Add(Me.Label6)
        Me.filtro.Controls.Add(Me.Button1)
        Me.filtro.Controls.Add(Me.inicio)
        Me.filtro.Controls.Add(Me.Label5)
        Me.filtro.Location = New System.Drawing.Point(11, 28)
        Me.filtro.Name = "filtro"
        Me.filtro.Size = New System.Drawing.Size(942, 52)
        Me.filtro.TabIndex = 27
        Me.filtro.TabStop = False
        '
        'fin
        '
        Me.fin.Location = New System.Drawing.Point(606, 19)
        Me.fin.Name = "fin"
        Me.fin.Size = New System.Drawing.Size(215, 20)
        Me.fin.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(576, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Fin:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(850, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 19)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Generar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'inicio
        '
        Me.inicio.Location = New System.Drawing.Point(316, 19)
        Me.inicio.Name = "inicio"
        Me.inicio.Size = New System.Drawing.Size(215, 20)
        Me.inicio.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(280, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Inicio:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(973, 25)
        Me.ToolStrip1.TabIndex = 29
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.NuevoToolStripMenuItem.Text = "Nuevo"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(74, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Sucursal:"
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(131, 48)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(318, 21)
        Me.cmb_sucursal.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Sucursal:"
        '
        'cmb_almacen
        '
        Me.cmb_almacen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(66, 19)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(175, 21)
        Me.cmb_almacen.TabIndex = 1
        '
        'frmMalas_cargas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 458)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ingreso)
        Me.Controls.Add(Me.grdDatos)
        Me.Controls.Add(Me.filtro)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMalas_cargas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Malas cargas"
        Me.ingreso.ResumeLayout(False)
        Me.ingreso.PerformLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.filtro.ResumeLayout(False)
        Me.filtro.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ingreso As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cmbDia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbEncargado As System.Windows.Forms.ComboBox
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdDatos As System.Windows.Forms.DataGridView
    Friend WithEvents filtro As System.Windows.Forms.GroupBox
    Friend WithEvents fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtdescripcion2 As System.Windows.Forms.TextBox
    Friend WithEvents txtdescripcion1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo_cargado As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo_reporte As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtobservacion As System.Windows.Forms.RichTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
End Class
