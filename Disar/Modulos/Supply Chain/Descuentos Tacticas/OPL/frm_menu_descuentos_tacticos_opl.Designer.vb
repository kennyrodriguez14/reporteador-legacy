<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_menu_descuentos_tacticos_opl
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
        Me.grd_lista = New System.Windows.Forms.DataGridView()
        Me.btn_cancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_presupuestos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.grp_descuentos_tacticos = New System.Windows.Forms.GroupBox()
        Me.btn_detalles = New System.Windows.Forms.ToolStripButton()
        Me.btn_agregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.cmb_almacen = New System.Windows.Forms.ComboBox()
        Me.lbl_sucursal = New System.Windows.Forms.Label()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.cmb_fecha = New System.Windows.Forms.DateTimePicker()
        Me.grp_filtros = New System.Windows.Forms.GroupBox()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_descuentos_tacticos.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grp_filtros.SuspendLayout()
        Me.SuspendLayout()
        '
        'grd_lista
        '
        Me.grd_lista.AllowUserToAddRows = False
        Me.grd_lista.AllowUserToDeleteRows = False
        Me.grd_lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_lista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_lista.Location = New System.Drawing.Point(3, 16)
        Me.grd_lista.Name = "grd_lista"
        Me.grd_lista.ReadOnly = True
        Me.grd_lista.RowHeadersVisible = False
        Me.grd_lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_lista.Size = New System.Drawing.Size(1042, 394)
        Me.grd_lista.TabIndex = 0
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Enabled = False
        Me.btn_cancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.Adblock_Dark_32
        Me.btn_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(114, 36)
        Me.btn_cancelar.Text = "Cancelar SAE"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 39)
        '
        'btn_presupuestos
        '
        Me.btn_presupuestos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_presupuestos.Image = Global.Disar.My.Resources.Resources.Dollar_32
        Me.btn_presupuestos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_presupuestos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_presupuestos.Name = "btn_presupuestos"
        Me.btn_presupuestos.Size = New System.Drawing.Size(117, 36)
        Me.btn_presupuestos.Text = "Presupuestos"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.Gnome_Folder_New_32
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(95, 36)
        Me.ToolStripButton1.Text = "Resumen"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_salir.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(67, 36)
        Me.btn_salir.Text = "Salir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'grp_descuentos_tacticos
        '
        Me.grp_descuentos_tacticos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_descuentos_tacticos.Controls.Add(Me.grd_lista)
        Me.grp_descuentos_tacticos.Location = New System.Drawing.Point(13, 107)
        Me.grp_descuentos_tacticos.Name = "grp_descuentos_tacticos"
        Me.grp_descuentos_tacticos.Size = New System.Drawing.Size(1048, 413)
        Me.grp_descuentos_tacticos.TabIndex = 21
        Me.grp_descuentos_tacticos.TabStop = False
        Me.grp_descuentos_tacticos.Text = "Descuentos Tacticos"
        '
        'btn_detalles
        '
        Me.btn_detalles.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_detalles.Image = Global.Disar.My.Resources.Resources.Books_32
        Me.btn_detalles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_detalles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_detalles.Name = "btn_detalles"
        Me.btn_detalles.Size = New System.Drawing.Size(110, 36)
        Me.btn_detalles.Text = "Ver Detalles"
        '
        'btn_agregar
        '
        Me.btn_agregar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_agregar.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.btn_agregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_agregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(88, 36)
        Me.btn_agregar.Text = "Agregar"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_agregar, Me.ToolStripSeparator4, Me.btn_detalles, Me.ToolStripSeparator1, Me.btn_salir, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator3, Me.btn_presupuestos, Me.ToolStripSeparator5, Me.btn_cancelar, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1073, 39)
        Me.ToolStrip1.TabIndex = 20
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 39)
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(641, 17)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(76, 23)
        Me.btn_aceptar.TabIndex = 4
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'cmb_almacen
        '
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(64, 18)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(298, 21)
        Me.cmb_almacen.TabIndex = 3
        '
        'lbl_sucursal
        '
        Me.lbl_sucursal.AutoSize = True
        Me.lbl_sucursal.Location = New System.Drawing.Point(7, 21)
        Me.lbl_sucursal.Name = "lbl_sucursal"
        Me.lbl_sucursal.Size = New System.Drawing.Size(51, 13)
        Me.lbl_sucursal.TabIndex = 2
        Me.lbl_sucursal.Text = "Sucursal:"
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(368, 22)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(40, 13)
        Me.lbl_fecha.TabIndex = 1
        Me.lbl_fecha.Text = "Fecha:"
        '
        'cmb_fecha
        '
        Me.cmb_fecha.Location = New System.Drawing.Point(414, 19)
        Me.cmb_fecha.Name = "cmb_fecha"
        Me.cmb_fecha.Size = New System.Drawing.Size(221, 20)
        Me.cmb_fecha.TabIndex = 0
        '
        'grp_filtros
        '
        Me.grp_filtros.Controls.Add(Me.btn_aceptar)
        Me.grp_filtros.Controls.Add(Me.cmb_almacen)
        Me.grp_filtros.Controls.Add(Me.lbl_sucursal)
        Me.grp_filtros.Controls.Add(Me.lbl_fecha)
        Me.grp_filtros.Controls.Add(Me.cmb_fecha)
        Me.grp_filtros.Location = New System.Drawing.Point(13, 51)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(1048, 50)
        Me.grp_filtros.TabIndex = 22
        Me.grp_filtros.TabStop = False
        Me.grp_filtros.Text = "Filtros"
        '
        'frm_menu_descuentos_tacticos_opl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 523)
        Me.Controls.Add(Me.grp_descuentos_tacticos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grp_filtros)
        Me.Name = "frm_menu_descuentos_tacticos_opl"
        Me.Text = "frm_menu_descuentos_tacticos_opl"
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_descuentos_tacticos.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grd_lista As DataGridView
    Friend WithEvents btn_cancelar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btn_presupuestos As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btn_salir As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents grp_descuentos_tacticos As GroupBox
    Friend WithEvents btn_detalles As ToolStripButton
    Friend WithEvents btn_agregar As ToolStripButton
    Private WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents btn_aceptar As Button
    Friend WithEvents cmb_almacen As ComboBox
    Friend WithEvents lbl_sucursal As Label
    Friend WithEvents lbl_fecha As Label
    Friend WithEvents cmb_fecha As DateTimePicker
    Friend WithEvents grp_filtros As GroupBox
End Class
