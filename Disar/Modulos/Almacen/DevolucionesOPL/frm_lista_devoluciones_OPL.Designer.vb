<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_lista_devoluciones_OPL
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_lista_devoluciones_OPL))
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.filtros = New System.Windows.Forms.GroupBox()
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.cmb_fecha_ini = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.btn_modificar = New System.Windows.Forms.ToolStripButton()
        Me.btn_eliminar = New System.Windows.Forms.ToolStripButton()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.mnu_carga_entregadores = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.grd_lista_devoluciones = New System.Windows.Forms.DataGridView()
        Me.filtros.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grd_lista_devoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'filtros
        '
        Me.filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtros.Controls.Add(Me.cmb_sucursal)
        Me.filtros.Controls.Add(Me.Label2)
        Me.filtros.Controls.Add(Me.btn_aceptar)
        Me.filtros.Controls.Add(Me.cmb_fecha_ini)
        Me.filtros.Controls.Add(Me.Label1)
        Me.filtros.Location = New System.Drawing.Point(16, 59)
        Me.filtros.Margin = New System.Windows.Forms.Padding(4)
        Me.filtros.Name = "filtros"
        Me.filtros.Padding = New System.Windows.Forms.Padding(4)
        Me.filtros.Size = New System.Drawing.Size(1479, 64)
        Me.filtros.TabIndex = 24
        Me.filtros.TabStop = False
        Me.filtros.Text = "Filtro"
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(97, 17)
        Me.cmb_sucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(304, 24)
        Me.cmb_sucursal.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Sucursal:"
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_aceptar.Location = New System.Drawing.Point(828, 16)
        Me.btn_aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(100, 28)
        Me.btn_aceptar.TabIndex = 4
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'cmb_fecha_ini
        '
        Me.cmb_fecha_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_ini.Location = New System.Drawing.Point(533, 20)
        Me.cmb_fecha_ini.Margin = New System.Windows.Forms.Padding(4)
        Me.cmb_fecha_ini.Name = "cmb_fecha_ini"
        Me.cmb_fecha_ini.Size = New System.Drawing.Size(285, 22)
        Me.cmb_fecha_ini.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(417, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Inicio:"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btn_nuevo, Me.ToolStripSeparator2, Me.btn_modificar, Me.ToolStripSeparator3, Me.btn_eliminar, Me.ToolStripSeparator4, Me.btn_salir, Me.ToolStripSeparator6, Me.mnu_carga_entregadores, Me.ToolStripSeparator5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1511, 39)
        Me.ToolStrip1.TabIndex = 25
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_nuevo.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.btn_nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(91, 36)
        Me.btn_nuevo.Text = "Nuevo"
        '
        'btn_modificar
        '
        Me.btn_modificar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_modificar.Image = Global.Disar.My.Resources.Resources.File_Edit_32
        Me.btn_modificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_modificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(111, 36)
        Me.btn_modificar.Text = "Visualizar"
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_eliminar.Image = Global.Disar.My.Resources.Resources.Delete_32
        Me.btn_eliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(102, 36)
        Me.btn_eliminar.Text = "Eliminar"
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(77, 36)
        Me.btn_salir.Text = "Salir"
        '
        'mnu_carga_entregadores
        '
        Me.mnu_carga_entregadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnu_carga_entregadores.Image = Global.Disar.My.Resources.Resources.img_devoluciones_entregadores
        Me.mnu_carga_entregadores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnu_carga_entregadores.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnu_carga_entregadores.Name = "mnu_carga_entregadores"
        Me.mnu_carga_entregadores.Size = New System.Drawing.Size(195, 36)
        Me.mnu_carga_entregadores.Text = "Cargar Devoluciones"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 39)
        '
        'grd_lista_devoluciones
        '
        Me.grd_lista_devoluciones.AllowUserToAddRows = False
        Me.grd_lista_devoluciones.AllowUserToDeleteRows = False
        Me.grd_lista_devoluciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_lista_devoluciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grd_lista_devoluciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_lista_devoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grd_lista_devoluciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.grd_lista_devoluciones.Location = New System.Drawing.Point(16, 130)
        Me.grd_lista_devoluciones.Margin = New System.Windows.Forms.Padding(4)
        Me.grd_lista_devoluciones.Name = "grd_lista_devoluciones"
        Me.grd_lista_devoluciones.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grd_lista_devoluciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grd_lista_devoluciones.RowHeadersVisible = False
        Me.grd_lista_devoluciones.RowHeadersWidth = 51
        Me.grd_lista_devoluciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_lista_devoluciones.Size = New System.Drawing.Size(1479, 464)
        Me.grd_lista_devoluciones.TabIndex = 26
        '
        'frm_lista_devoluciones_OPL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1511, 602)
        Me.Controls.Add(Me.filtros)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grd_lista_devoluciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frm_lista_devoluciones_OPL"
        Me.Text = "Menú Principal de Devoluciones - OPL D"
        Me.filtros.ResumeLayout(False)
        Me.filtros.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grd_lista_devoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents filtros As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmb_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_eliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_modificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_nuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents grd_lista_devoluciones As System.Windows.Forms.DataGridView
    Friend WithEvents mnu_carga_entregadores As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
End Class
