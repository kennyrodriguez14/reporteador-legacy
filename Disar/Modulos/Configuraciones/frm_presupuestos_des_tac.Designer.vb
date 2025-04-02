<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_presupuestos_des_tac
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_presupuestos_des_tac))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.grd_presupuestos = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_fecha = New System.Windows.Forms.DateTimePicker
        Me.btn_generar = New System.Windows.Forms.Button
        Me.grp_filtros = New System.Windows.Forms.GroupBox
        Me.grp_datos = New System.Windows.Forms.GroupBox
        Me.txt_mes_id = New System.Windows.Forms.TextBox
        Me.txt_mes = New System.Windows.Forms.TextBox
        Me.txt_año = New System.Windows.Forms.TextBox
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox
        Me.cmb_status = New System.Windows.Forms.ComboBox
        Me.cmb_mes = New System.Windows.Forms.DateTimePicker
        Me.cmb_año = New System.Windows.Forms.DateTimePicker
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.txt_restante = New System.Windows.Forms.TextBox
        Me.txt_valor = New System.Windows.Forms.TextBox
        Me.lbl_estado = New System.Windows.Forms.Label
        Me.lbl_restante = New System.Windows.Forms.Label
        Me.lbl_valor = New System.Windows.Forms.Label
        Me.lbl_proveedor = New System.Windows.Forms.Label
        Me.lbl_mes = New System.Windows.Forms.Label
        Me.lbl_año = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grd_presupuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_filtros.SuspendLayout()
        Me.grp_datos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(656, 39)
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '_Archivo
        '
        Me._Archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.ModificarToolStripMenuItem, Me.EliminarToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me._Archivo.Image = Global.Disar.My.Resources.Resources.Opciones
        Me._Archivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Archivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._Archivo.Name = "_Archivo"
        Me._Archivo.Size = New System.Drawing.Size(100, 36)
        Me._Archivo.Text = "Acciones"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Folder_48
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NuevoToolStripMenuItem.Text = "Nuevo"
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.File_Edit_32
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ModificarToolStripMenuItem.Text = "Modificar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Delete_32
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'grd_presupuestos
        '
        Me.grd_presupuestos.AllowUserToAddRows = False
        Me.grd_presupuestos.AllowUserToDeleteRows = False
        Me.grd_presupuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_presupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_presupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_presupuestos.Location = New System.Drawing.Point(12, 98)
        Me.grd_presupuestos.Name = "grd_presupuestos"
        Me.grd_presupuestos.ReadOnly = True
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.grd_presupuestos.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_presupuestos.Size = New System.Drawing.Size(632, 328)
        Me.grd_presupuestos.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Mes:"
        '
        'cmb_fecha
        '
        Me.cmb_fecha.CustomFormat = "MMMM yyyy"
        Me.cmb_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.cmb_fecha.Location = New System.Drawing.Point(44, 19)
        Me.cmb_fecha.Name = "cmb_fecha"
        Me.cmb_fecha.ShowUpDown = True
        Me.cmb_fecha.Size = New System.Drawing.Size(133, 20)
        Me.cmb_fecha.TabIndex = 25
        '
        'btn_generar
        '
        Me.btn_generar.Location = New System.Drawing.Point(183, 17)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(82, 22)
        Me.btn_generar.TabIndex = 26
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.UseVisualStyleBackColor = True
        '
        'grp_filtros
        '
        Me.grp_filtros.Controls.Add(Me.btn_generar)
        Me.grp_filtros.Controls.Add(Me.Label1)
        Me.grp_filtros.Controls.Add(Me.cmb_fecha)
        Me.grp_filtros.Location = New System.Drawing.Point(12, 42)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(632, 50)
        Me.grp_filtros.TabIndex = 27
        Me.grp_filtros.TabStop = False
        Me.grp_filtros.Text = "Filtros"
        '
        'grp_datos
        '
        Me.grp_datos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grp_datos.Controls.Add(Me.txt_mes_id)
        Me.grp_datos.Controls.Add(Me.txt_mes)
        Me.grp_datos.Controls.Add(Me.txt_año)
        Me.grp_datos.Controls.Add(Me.cmb_proveedor)
        Me.grp_datos.Controls.Add(Me.cmb_status)
        Me.grp_datos.Controls.Add(Me.cmb_mes)
        Me.grp_datos.Controls.Add(Me.cmb_año)
        Me.grp_datos.Controls.Add(Me.btn_cancelar)
        Me.grp_datos.Controls.Add(Me.btn_aceptar)
        Me.grp_datos.Controls.Add(Me.txt_restante)
        Me.grp_datos.Controls.Add(Me.txt_valor)
        Me.grp_datos.Controls.Add(Me.lbl_estado)
        Me.grp_datos.Controls.Add(Me.lbl_restante)
        Me.grp_datos.Controls.Add(Me.lbl_valor)
        Me.grp_datos.Controls.Add(Me.lbl_proveedor)
        Me.grp_datos.Controls.Add(Me.lbl_mes)
        Me.grp_datos.Controls.Add(Me.lbl_año)
        Me.grp_datos.Location = New System.Drawing.Point(154, 117)
        Me.grp_datos.Name = "grp_datos"
        Me.grp_datos.Size = New System.Drawing.Size(365, 238)
        Me.grp_datos.TabIndex = 28
        Me.grp_datos.TabStop = False
        Me.grp_datos.Text = "Ingreso"
        '
        'txt_mes_id
        '
        Me.txt_mes_id.Location = New System.Drawing.Point(336, 19)
        Me.txt_mes_id.Name = "txt_mes_id"
        Me.txt_mes_id.Size = New System.Drawing.Size(11, 20)
        Me.txt_mes_id.TabIndex = 10
        '
        'txt_mes
        '
        Me.txt_mes.Location = New System.Drawing.Point(231, 19)
        Me.txt_mes.Name = "txt_mes"
        Me.txt_mes.ReadOnly = True
        Me.txt_mes.Size = New System.Drawing.Size(100, 20)
        Me.txt_mes.TabIndex = 10
        Me.txt_mes.Visible = False
        '
        'txt_año
        '
        Me.txt_año.Location = New System.Drawing.Point(79, 19)
        Me.txt_año.Name = "txt_año"
        Me.txt_año.ReadOnly = True
        Me.txt_año.Size = New System.Drawing.Size(100, 20)
        Me.txt_año.TabIndex = 10
        Me.txt_año.Visible = False
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(79, 45)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(248, 21)
        Me.cmb_proveedor.TabIndex = 4
        '
        'cmb_status
        '
        Me.cmb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_status.FormattingEnabled = True
        Me.cmb_status.Items.AddRange(New Object() {"BAJA", "ALTA"})
        Me.cmb_status.Location = New System.Drawing.Point(79, 138)
        Me.cmb_status.Name = "cmb_status"
        Me.cmb_status.Size = New System.Drawing.Size(248, 21)
        Me.cmb_status.TabIndex = 7
        '
        'cmb_mes
        '
        Me.cmb_mes.CustomFormat = "MMMM"
        Me.cmb_mes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.cmb_mes.Location = New System.Drawing.Point(231, 19)
        Me.cmb_mes.Name = "cmb_mes"
        Me.cmb_mes.ShowUpDown = True
        Me.cmb_mes.Size = New System.Drawing.Size(96, 20)
        Me.cmb_mes.TabIndex = 3
        '
        'cmb_año
        '
        Me.cmb_año.CustomFormat = "yyyy"
        Me.cmb_año.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.cmb_año.Location = New System.Drawing.Point(79, 19)
        Me.cmb_año.Name = "cmb_año"
        Me.cmb_año.ShowUpDown = True
        Me.cmb_año.Size = New System.Drawing.Size(96, 20)
        Me.cmb_año.TabIndex = 2
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.Location = New System.Drawing.Point(250, 184)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(109, 44)
        Me.btn_cancelar.TabIndex = 9
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = Global.Disar.My.Resources.Resources.img_aceptar
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_aceptar.Location = New System.Drawing.Point(6, 184)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(108, 44)
        Me.btn_aceptar.TabIndex = 8
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'txt_restante
        '
        Me.txt_restante.Location = New System.Drawing.Point(78, 107)
        Me.txt_restante.Name = "txt_restante"
        Me.txt_restante.ReadOnly = True
        Me.txt_restante.Size = New System.Drawing.Size(249, 20)
        Me.txt_restante.TabIndex = 6
        '
        'txt_valor
        '
        Me.txt_valor.Location = New System.Drawing.Point(78, 76)
        Me.txt_valor.Name = "txt_valor"
        Me.txt_valor.Size = New System.Drawing.Size(249, 20)
        Me.txt_valor.TabIndex = 5
        '
        'lbl_estado
        '
        Me.lbl_estado.AutoSize = True
        Me.lbl_estado.Location = New System.Drawing.Point(29, 141)
        Me.lbl_estado.Name = "lbl_estado"
        Me.lbl_estado.Size = New System.Drawing.Size(43, 13)
        Me.lbl_estado.TabIndex = 0
        Me.lbl_estado.Text = "Estado:"
        '
        'lbl_restante
        '
        Me.lbl_restante.AutoSize = True
        Me.lbl_restante.Location = New System.Drawing.Point(19, 110)
        Me.lbl_restante.Name = "lbl_restante"
        Me.lbl_restante.Size = New System.Drawing.Size(53, 13)
        Me.lbl_restante.TabIndex = 0
        Me.lbl_restante.Text = "Restante:"
        '
        'lbl_valor
        '
        Me.lbl_valor.AutoSize = True
        Me.lbl_valor.Location = New System.Drawing.Point(38, 79)
        Me.lbl_valor.Name = "lbl_valor"
        Me.lbl_valor.Size = New System.Drawing.Size(34, 13)
        Me.lbl_valor.TabIndex = 0
        Me.lbl_valor.Text = "Valor:"
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Location = New System.Drawing.Point(13, 48)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(59, 13)
        Me.lbl_proveedor.TabIndex = 0
        Me.lbl_proveedor.Text = "Proveedor:"
        '
        'lbl_mes
        '
        Me.lbl_mes.AutoSize = True
        Me.lbl_mes.Location = New System.Drawing.Point(194, 22)
        Me.lbl_mes.Name = "lbl_mes"
        Me.lbl_mes.Size = New System.Drawing.Size(30, 13)
        Me.lbl_mes.TabIndex = 0
        Me.lbl_mes.Text = "Mes:"
        '
        'lbl_año
        '
        Me.lbl_año.AutoSize = True
        Me.lbl_año.Location = New System.Drawing.Point(43, 22)
        Me.lbl_año.Name = "lbl_año"
        Me.lbl_año.Size = New System.Drawing.Size(29, 13)
        Me.lbl_año.TabIndex = 0
        Me.lbl_año.Text = "Año:"
        '
        'frm_presupuestos_des_tac
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 440)
        Me.Controls.Add(Me.grp_datos)
        Me.Controls.Add(Me.grp_filtros)
        Me.Controls.Add(Me.grd_presupuestos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_presupuestos_des_tac"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Presupuestos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grd_presupuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        Me.grp_datos.ResumeLayout(False)
        Me.grp_datos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grd_presupuestos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Friend WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Friend WithEvents grp_datos As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_año As System.Windows.Forms.Label
    Friend WithEvents txt_restante As System.Windows.Forms.TextBox
    Friend WithEvents txt_valor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_estado As System.Windows.Forms.Label
    Friend WithEvents lbl_restante As System.Windows.Forms.Label
    Friend WithEvents lbl_valor As System.Windows.Forms.Label
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents lbl_mes As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmb_status As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_mes As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_año As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_mes As System.Windows.Forms.TextBox
    Friend WithEvents txt_año As System.Windows.Forms.TextBox
    Friend WithEvents txt_mes_id As System.Windows.Forms.TextBox
End Class
