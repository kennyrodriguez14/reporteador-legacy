<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCarga_promedio_Camiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCarga_promedio_Camiones))
        Me.ingreso = New System.Windows.Forms.Panel
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcantidad = New System.Windows.Forms.TextBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.cmbDia = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbTurno = New System.Windows.Forms.ComboBox
        Me.txtPeso = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.grdDatos = New System.Windows.Forms.DataGridView
        Me.filtro = New System.Windows.Forms.GroupBox
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.fin = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.inicio = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ingreso.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.filtro.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ingreso
        '
        Me.ingreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ingreso.Controls.Add(Me.cmb_almacen)
        Me.ingreso.Controls.Add(Me.Label7)
        Me.ingreso.Controls.Add(Me.txtcantidad)
        Me.ingreso.Controls.Add(Me.btnCancelar)
        Me.ingreso.Controls.Add(Me.Label1)
        Me.ingreso.Controls.Add(Me.btnAceptar)
        Me.ingreso.Controls.Add(Me.cmbDia)
        Me.ingreso.Controls.Add(Me.Label2)
        Me.ingreso.Controls.Add(Me.Label4)
        Me.ingreso.Controls.Add(Me.cmbTurno)
        Me.ingreso.Controls.Add(Me.txtPeso)
        Me.ingreso.Controls.Add(Me.Label3)
        Me.ingreso.Location = New System.Drawing.Point(86, 110)
        Me.ingreso.Name = "ingreso"
        Me.ingreso.Size = New System.Drawing.Size(606, 263)
        Me.ingreso.TabIndex = 23
        Me.ingreso.Visible = False
        '
        'cmb_almacen
        '
        Me.cmb_almacen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(174, 42)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(318, 21)
        Me.cmb_almacen.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(123, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Sucursal:"
        '
        'txtcantidad
        '
        Me.txtcantidad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtcantidad.Location = New System.Drawing.Point(175, 176)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(317, 20)
        Me.txtcantidad.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(528, 237)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(148, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Dia:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(3, 237)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'cmbDia
        '
        Me.cmbDia.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbDia.Enabled = False
        Me.cmbDia.Location = New System.Drawing.Point(174, 76)
        Me.cmbDia.Name = "cmbDia"
        Me.cmbDia.Size = New System.Drawing.Size(318, 20)
        Me.cmbDia.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(136, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Turno:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(74, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Cantidad de Carros:"
        '
        'cmbTurno
        '
        Me.cmbTurno.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurno.FormattingEnabled = True
        Me.cmbTurno.Items.AddRange(New Object() {"Diurno", "Nocturno"})
        Me.cmbTurno.Location = New System.Drawing.Point(174, 109)
        Me.cmbTurno.Name = "cmbTurno"
        Me.cmbTurno.Size = New System.Drawing.Size(318, 21)
        Me.cmbTurno.TabIndex = 2
        '
        'txtPeso
        '
        Me.txtPeso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtPeso.Location = New System.Drawing.Point(175, 143)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(317, 20)
        Me.txtPeso.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(140, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Peso:"
        '
        'grdDatos
        '
        Me.grdDatos.AllowUserToAddRows = False
        Me.grdDatos.AllowUserToDeleteRows = False
        Me.grdDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDatos.Location = New System.Drawing.Point(12, 72)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.ReadOnly = True
        Me.grdDatos.Size = New System.Drawing.Size(746, 327)
        Me.grdDatos.TabIndex = 25
        '
        'filtro
        '
        Me.filtro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtro.Controls.Add(Me.cmb_sucursal)
        Me.filtro.Controls.Add(Me.Label8)
        Me.filtro.Controls.Add(Me.fin)
        Me.filtro.Controls.Add(Me.Label6)
        Me.filtro.Controls.Add(Me.Button1)
        Me.filtro.Controls.Add(Me.inicio)
        Me.filtro.Controls.Add(Me.Label5)
        Me.filtro.Location = New System.Drawing.Point(12, 28)
        Me.filtro.Name = "filtro"
        Me.filtro.Size = New System.Drawing.Size(754, 38)
        Me.filtro.TabIndex = 24
        Me.filtro.TabStop = False
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(55, 13)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(166, 21)
        Me.cmb_sucursal.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Sucursal:"
        '
        'fin
        '
        Me.fin.Location = New System.Drawing.Point(483, 13)
        Me.fin.Name = "fin"
        Me.fin.Size = New System.Drawing.Size(195, 20)
        Me.fin.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(459, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Fin:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(683, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 19)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Generar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'inicio
        '
        Me.inicio.Location = New System.Drawing.Point(259, 13)
        Me.inicio.Name = "inicio"
        Me.inicio.Size = New System.Drawing.Size(195, 20)
        Me.inicio.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(227, 16)
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
        Me.ToolStrip1.Size = New System.Drawing.Size(778, 25)
        Me.ToolStrip1.TabIndex = 26
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
        'frmCarga_promedio_Camiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 411)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ingreso)
        Me.Controls.Add(Me.grdDatos)
        Me.Controls.Add(Me.filtro)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCarga_promedio_Camiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga promedio de camiones"
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
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cmbDia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTurno As System.Windows.Forms.ComboBox
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
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
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
