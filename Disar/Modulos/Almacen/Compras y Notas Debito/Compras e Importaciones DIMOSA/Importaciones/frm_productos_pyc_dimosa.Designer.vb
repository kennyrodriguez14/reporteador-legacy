<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_productos_pyc_dimosa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_productos_pyc_dimosa))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_salir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_nuevo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_eliminar = New System.Windows.Forms.ToolStripButton
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.grp_ingreso = New System.Windows.Forms.GroupBox
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.grp_precios_productos = New System.Windows.Forms.GroupBox
        Me.grid = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me.grp_ingreso.SuspendLayout()
        Me.grp_precios_productos.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.btn_salir, Me.ToolStripSeparator1, Me.btn_nuevo, Me.ToolStripSeparator3, Me.btn_eliminar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(552, 39)
        Me.ToolStrip1.TabIndex = 23
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_nuevo.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.btn_nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(88, 36)
        Me.btn_nuevo.Text = "Agregar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_eliminar.Image = Global.Disar.My.Resources.Resources.Delete_32
        Me.btn_eliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(87, 36)
        Me.btn_eliminar.Text = "Eliminar"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Location = New System.Drawing.Point(217, 70)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 32)
        Me.btn_cancelar.TabIndex = 2
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_buscar
        '
        Me.btn_buscar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_buscar.Location = New System.Drawing.Point(96, 18)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(71, 20)
        Me.btn_buscar.TabIndex = 23
        Me.btn_buscar.Text = "..."
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'grp_ingreso
        '
        Me.grp_ingreso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grp_ingreso.Controls.Add(Me.btn_buscar)
        Me.grp_ingreso.Controls.Add(Me.btn_cancelar)
        Me.grp_ingreso.Controls.Add(Me.btn_guardar)
        Me.grp_ingreso.Controls.Add(Me.txt_descripcion)
        Me.grp_ingreso.Controls.Add(Me.txt_codigo)
        Me.grp_ingreso.Controls.Add(Me.Label3)
        Me.grp_ingreso.Controls.Add(Me.Label2)
        Me.grp_ingreso.Location = New System.Drawing.Point(87, 157)
        Me.grp_ingreso.Name = "grp_ingreso"
        Me.grp_ingreso.Size = New System.Drawing.Size(378, 121)
        Me.grp_ingreso.TabIndex = 25
        Me.grp_ingreso.TabStop = False
        Me.grp_ingreso.Visible = False
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(87, 70)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 32)
        Me.btn_guardar.TabIndex = 2
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descripcion.Location = New System.Drawing.Point(96, 44)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.ReadOnly = True
        Me.txt_descripcion.Size = New System.Drawing.Size(255, 20)
        Me.txt_descripcion.TabIndex = 1
        '
        'txt_codigo
        '
        Me.txt_codigo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo.Location = New System.Drawing.Point(173, 18)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.ReadOnly = True
        Me.txt_codigo.Size = New System.Drawing.Size(178, 20)
        Me.txt_codigo.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Descripcion:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Codigo:"
        '
        'grp_precios_productos
        '
        Me.grp_precios_productos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_precios_productos.Controls.Add(Me.grid)
        Me.grp_precios_productos.Location = New System.Drawing.Point(13, 48)
        Me.grp_precios_productos.Name = "grp_precios_productos"
        Me.grp_precios_productos.Size = New System.Drawing.Size(527, 368)
        Me.grp_precios_productos.TabIndex = 24
        Me.grp_precios_productos.TabStop = False
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Location = New System.Drawing.Point(3, 16)
        Me.grid.MultiSelect = False
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        Me.grid.RowHeadersVisible = False
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid.Size = New System.Drawing.Size(521, 349)
        Me.grid.TabIndex = 18
        '
        'frm_productos_pyc_dimosa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 422)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grp_ingreso)
        Me.Controls.Add(Me.grp_precios_productos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_productos_pyc_dimosa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precios Negociados"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grp_ingreso.ResumeLayout(False)
        Me.grp_ingreso.PerformLayout()
        Me.grp_precios_productos.ResumeLayout(False)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_nuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_eliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents grp_ingreso As System.Windows.Forms.GroupBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grp_precios_productos As System.Windows.Forms.GroupBox
    Friend WithEvents grid As System.Windows.Forms.DataGridView
End Class
