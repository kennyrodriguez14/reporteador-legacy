<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_precios_negociados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_precios_negociados))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_salir = New System.Windows.Forms.ToolStripButton
        Me.grd_precios = New System.Windows.Forms.DataGridView
        Me.grp_precios_productos = New System.Windows.Forms.GroupBox
        Me.txt_buqueda = New System.Windows.Forms.TextBox
        Me.grp_filtros = New System.Windows.Forms.GroupBox
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grp_ingreso = New System.Windows.Forms.GroupBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.txt_precio_negociado = New System.Windows.Forms.TextBox
        Me.txt_validador = New System.Windows.Forms.TextBox
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_exportar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grd_precios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_precios_productos.SuspendLayout()
        Me.grp_filtros.SuspendLayout()
        Me.grp_ingreso.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.btn_salir, Me.ToolStripSeparator1, Me.btn_exportar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(561, 39)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
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
        'grd_precios
        '
        Me.grd_precios.AllowUserToAddRows = False
        Me.grd_precios.AllowUserToDeleteRows = False
        Me.grd_precios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_precios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_precios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_precios.Location = New System.Drawing.Point(3, 16)
        Me.grd_precios.MultiSelect = False
        Me.grd_precios.Name = "grd_precios"
        Me.grd_precios.ReadOnly = True
        Me.grd_precios.RowHeadersVisible = False
        Me.grd_precios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_precios.Size = New System.Drawing.Size(530, 344)
        Me.grd_precios.TabIndex = 18
        '
        'grp_precios_productos
        '
        Me.grp_precios_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_precios_productos.Controls.Add(Me.grd_precios)
        Me.grp_precios_productos.Location = New System.Drawing.Point(13, 149)
        Me.grp_precios_productos.Name = "grp_precios_productos"
        Me.grp_precios_productos.Size = New System.Drawing.Size(536, 363)
        Me.grp_precios_productos.TabIndex = 19
        Me.grp_precios_productos.TabStop = False
        Me.grp_precios_productos.Text = "Precios por Producto"
        '
        'txt_buqueda
        '
        Me.txt_buqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_buqueda.Location = New System.Drawing.Point(83, 16)
        Me.txt_buqueda.Name = "txt_buqueda"
        Me.txt_buqueda.Size = New System.Drawing.Size(293, 20)
        Me.txt_buqueda.TabIndex = 20
        '
        'grp_filtros
        '
        Me.grp_filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_filtros.Controls.Add(Me.btn_buscar)
        Me.grp_filtros.Controls.Add(Me.cmb_proveedor)
        Me.grp_filtros.Controls.Add(Me.Label4)
        Me.grp_filtros.Controls.Add(Me.Label1)
        Me.grp_filtros.Controls.Add(Me.txt_buqueda)
        Me.grp_filtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_filtros.Location = New System.Drawing.Point(16, 54)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(533, 76)
        Me.grp_filtros.TabIndex = 21
        Me.grp_filtros.TabStop = False
        Me.grp_filtros.Text = "Filtros"
        '
        'btn_buscar
        '
        Me.btn_buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_buscar.Location = New System.Drawing.Point(452, 14)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(75, 23)
        Me.btn_buscar.TabIndex = 23
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(83, 42)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(354, 21)
        Me.cmb_proveedor.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Proveedor:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Producto:"
        '
        'grp_ingreso
        '
        Me.grp_ingreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grp_ingreso.Controls.Add(Me.btn_cancelar)
        Me.grp_ingreso.Controls.Add(Me.btn_guardar)
        Me.grp_ingreso.Controls.Add(Me.txt_precio_negociado)
        Me.grp_ingreso.Controls.Add(Me.txt_validador)
        Me.grp_ingreso.Controls.Add(Me.txt_descripcion)
        Me.grp_ingreso.Controls.Add(Me.txt_codigo)
        Me.grp_ingreso.Controls.Add(Me.Label5)
        Me.grp_ingreso.Controls.Add(Me.Label3)
        Me.grp_ingreso.Controls.Add(Me.Label2)
        Me.grp_ingreso.Location = New System.Drawing.Point(39, 136)
        Me.grp_ingreso.Name = "grp_ingreso"
        Me.grp_ingreso.Size = New System.Drawing.Size(486, 274)
        Me.grp_ingreso.TabIndex = 22
        Me.grp_ingreso.TabStop = False
        Me.grp_ingreso.Text = "Ingreso de precios"
        Me.grp_ingreso.Visible = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Location = New System.Drawing.Point(405, 236)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 32)
        Me.btn_cancelar.TabIndex = 2
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(6, 236)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 32)
        Me.btn_guardar.TabIndex = 2
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'txt_precio_negociado
        '
        Me.txt_precio_negociado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_precio_negociado.Location = New System.Drawing.Point(35, 189)
        Me.txt_precio_negociado.Name = "txt_precio_negociado"
        Me.txt_precio_negociado.Size = New System.Drawing.Size(143, 20)
        Me.txt_precio_negociado.TabIndex = 1
        '
        'txt_validador
        '
        Me.txt_validador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_validador.Location = New System.Drawing.Point(184, 57)
        Me.txt_validador.Name = "txt_validador"
        Me.txt_validador.ReadOnly = True
        Me.txt_validador.Size = New System.Drawing.Size(143, 20)
        Me.txt_validador.TabIndex = 1
        Me.txt_validador.Visible = False
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Location = New System.Drawing.Point(35, 123)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(417, 20)
        Me.txt_descripcion.TabIndex = 1
        '
        'txt_codigo
        '
        Me.txt_codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo.Location = New System.Drawing.Point(35, 57)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.ReadOnly = True
        Me.txt_codigo.Size = New System.Drawing.Size(143, 20)
        Me.txt_codigo.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Precio Negociado:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Descripcion:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Codigo:"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btn_exportar
        '
        Me.btn_exportar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_exportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.btn_exportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(91, 36)
        Me.btn_exportar.Text = "Exportar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'frm_precios_negociados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 524)
        Me.Controls.Add(Me.grp_ingreso)
        Me.Controls.Add(Me.grp_filtros)
        Me.Controls.Add(Me.grp_precios_productos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_precios_negociados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precios negociados"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grd_precios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_precios_productos.ResumeLayout(False)
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        Me.grp_ingreso.ResumeLayout(False)
        Me.grp_ingreso.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents grd_precios As System.Windows.Forms.DataGridView
    Friend WithEvents grp_precios_productos As System.Windows.Forms.GroupBox
    Friend WithEvents txt_buqueda As System.Windows.Forms.TextBox
    Friend WithEvents grp_filtros As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grp_ingreso As System.Windows.Forms.GroupBox
    Friend WithEvents txt_precio_negociado As System.Windows.Forms.TextBox
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_validador As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
