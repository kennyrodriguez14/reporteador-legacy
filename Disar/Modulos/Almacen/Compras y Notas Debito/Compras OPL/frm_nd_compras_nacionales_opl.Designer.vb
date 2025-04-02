<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_nd_compras_nacionales_opl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_nd_compras_nacionales_opl))
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.grd_lista_remisiones = New System.Windows.Forms.DataGridView()
        Me.cmb_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.cmb_fecha_ini = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.filtros = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.btn_ajustes = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn_debito = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_credito = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.grd_lista_remisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.filtros.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_nuevo, Me.ToolStripSeparator3, Me.btn_ajustes, Me.ToolStripSeparator7, Me.btn_salir})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1091, 39)
        Me.ToolStrip2.TabIndex = 23
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 39)
        '
        'grd_lista_remisiones
        '
        Me.grd_lista_remisiones.AllowUserToAddRows = False
        Me.grd_lista_remisiones.AllowUserToDeleteRows = False
        Me.grd_lista_remisiones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_lista_remisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grd_lista_remisiones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_lista_remisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grd_lista_remisiones.DefaultCellStyle = DataGridViewCellStyle2
        Me.grd_lista_remisiones.Location = New System.Drawing.Point(12, 118)
        Me.grd_lista_remisiones.MultiSelect = False
        Me.grd_lista_remisiones.Name = "grd_lista_remisiones"
        Me.grd_lista_remisiones.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grd_lista_remisiones.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grd_lista_remisiones.RowHeadersVisible = False
        Me.grd_lista_remisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_lista_remisiones.Size = New System.Drawing.Size(1067, 338)
        Me.grd_lista_remisiones.TabIndex = 22
        '
        'cmb_fecha_fin
        '
        Me.cmb_fecha_fin.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmb_fecha_fin.Location = New System.Drawing.Point(103, 40)
        Me.cmb_fecha_fin.Name = "cmb_fecha_fin"
        Me.cmb_fecha_fin.Size = New System.Drawing.Size(215, 20)
        Me.cmb_fecha_fin.TabIndex = 1
        '
        'cmb_fecha_ini
        '
        Me.cmb_fecha_ini.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmb_fecha_ini.Location = New System.Drawing.Point(103, 17)
        Me.cmb_fecha_ini.Name = "cmb_fecha_ini"
        Me.cmb_fecha_ini.Size = New System.Drawing.Size(215, 20)
        Me.cmb_fecha_ini.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha Fin:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Inicio:"
        '
        'filtros
        '
        Me.filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtros.Controls.Add(Me.BtnExportar)
        Me.filtros.Controls.Add(Me.btn_aceptar)
        Me.filtros.Controls.Add(Me.cmb_fecha_fin)
        Me.filtros.Controls.Add(Me.cmb_fecha_ini)
        Me.filtros.Controls.Add(Me.Label2)
        Me.filtros.Controls.Add(Me.Label1)
        Me.filtros.Location = New System.Drawing.Point(12, 48)
        Me.filtros.Name = "filtros"
        Me.filtros.Size = New System.Drawing.Size(1067, 64)
        Me.filtros.TabIndex = 21
        Me.filtros.TabStop = False
        Me.filtros.Text = "Filtro"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_nuevo.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.btn_nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(80, 36)
        Me.btn_nuevo.Text = "Nuevo"
        '
        'btn_ajustes
        '
        Me.btn_ajustes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_debito, Me.btn_credito})
        Me.btn_ajustes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ajustes.Image = Global.Disar.My.Resources.Resources.addpresdepto
        Me.btn_ajustes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_ajustes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ajustes.Name = "btn_ajustes"
        Me.btn_ajustes.Size = New System.Drawing.Size(87, 36)
        Me.btn_ajustes.Text = "Ajuste"
        '
        'btn_debito
        '
        Me.btn_debito.Image = Global.Disar.My.Resources.Resources.img_flecha_derecha
        Me.btn_debito.Name = "btn_debito"
        Me.btn_debito.Size = New System.Drawing.Size(180, 22)
        Me.btn_debito.Text = "Debito"
        '
        'btn_credito
        '
        Me.btn_credito.Image = Global.Disar.My.Resources.Resources.img_fecha_izquierdad
        Me.btn_credito.Name = "btn_credito"
        Me.btn_credito.Size = New System.Drawing.Size(180, 22)
        Me.btn_credito.Text = "Credito"
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(68, 36)
        Me.btn_salir.Text = "Salir"
        '
        'BtnExportar
        '
        Me.BtnExportar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BtnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.Location = New System.Drawing.Point(423, 17)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(93, 43)
        Me.BtnExportar.TabIndex = 13
        Me.BtnExportar.Text = "Exportar"
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = Global.Disar.My.Resources.Resources.img_aceptar
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_aceptar.Location = New System.Drawing.Point(324, 17)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(93, 43)
        Me.btn_aceptar.TabIndex = 4
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'frm_nd_compras_nacionales_opl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 462)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.grd_lista_remisiones)
        Me.Controls.Add(Me.filtros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_nd_compras_nacionales_opl"
        Me.Text = "Compras OPL"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.grd_lista_remisiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.filtros.ResumeLayout(False)
        Me.filtros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btn_nuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Private WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents grd_lista_remisiones As DataGridView
    Friend WithEvents BtnExportar As Button
    Friend WithEvents btn_aceptar As Button
    Friend WithEvents cmb_fecha_fin As DateTimePicker
    Friend WithEvents cmb_fecha_ini As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents filtros As GroupBox
    Friend WithEvents btn_salir As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents btn_ajustes As ToolStripDropDownButton
    Friend WithEvents btn_debito As ToolStripMenuItem
    Friend WithEvents btn_credito As ToolStripMenuItem
End Class
