<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tab_rutas_principal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tab_rutas_principal))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.txt_busqueda_ruta = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grd_lista_rutas = New System.Windows.Forms.DataGridView
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.NuevaTabulacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IngresarDatosARutasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grd_lista_rutas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(949, 39)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.txt_busqueda_ruta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(925, 48)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(429, 14)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(75, 23)
        Me.btn_buscar.TabIndex = 3
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'txt_busqueda_ruta
        '
        Me.txt_busqueda_ruta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_busqueda_ruta.Location = New System.Drawing.Point(110, 16)
        Me.txt_busqueda_ruta.Name = "txt_busqueda_ruta"
        Me.txt_busqueda_ruta.Size = New System.Drawing.Size(313, 20)
        Me.txt_busqueda_ruta.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ruta:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.grd_lista_rutas)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(925, 352)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de Rutas"
        '
        'grd_lista_rutas
        '
        Me.grd_lista_rutas.AllowUserToAddRows = False
        Me.grd_lista_rutas.AllowUserToDeleteRows = False
        Me.grd_lista_rutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_lista_rutas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_lista_rutas.Location = New System.Drawing.Point(3, 16)
        Me.grd_lista_rutas.Name = "grd_lista_rutas"
        Me.grd_lista_rutas.ReadOnly = True
        Me.grd_lista_rutas.RowHeadersVisible = False
        Me.grd_lista_rutas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_lista_rutas.Size = New System.Drawing.Size(919, 333)
        Me.grd_lista_rutas.TabIndex = 0
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaTabulacionToolStripMenuItem, Me.IngresarDatosARutasToolStripMenuItem, Me.ReporteToolStripMenuItem, Me.ExportarAExcelToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Disar.My.Resources.Resources.File_Blue
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(93, 36)
        Me.ToolStripDropDownButton1.Text = "Archivo"
        '
        'NuevaTabulacionToolStripMenuItem
        '
        Me.NuevaTabulacionToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Efectividad_RF
        Me.NuevaTabulacionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevaTabulacionToolStripMenuItem.Name = "NuevaTabulacionToolStripMenuItem"
        Me.NuevaTabulacionToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.NuevaTabulacionToolStripMenuItem.Text = "Nueva Tabulacion"
        '
        'IngresarDatosARutasToolStripMenuItem
        '
        Me.IngresarDatosARutasToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.img_ingresar_rutas
        Me.IngresarDatosARutasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.IngresarDatosARutasToolStripMenuItem.Name = "IngresarDatosARutasToolStripMenuItem"
        Me.IngresarDatosARutasToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.IngresarDatosARutasToolStripMenuItem.Text = "Ingresar Datos a Rutas"
        '
        'ReporteToolStripMenuItem
        '
        Me.ReporteToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Briefcase_32__1_
        Me.ReporteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ReporteToolStripMenuItem.Name = "ReporteToolStripMenuItem"
        Me.ReporteToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.ReporteToolStripMenuItem.Text = "Reporte"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.ExportarAExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar a Excel"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'frm_tab_rutas_principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 460)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_tab_rutas_principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Tabulacion de Rutas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grd_lista_rutas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents NuevaTabulacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grd_lista_rutas As System.Windows.Forms.DataGridView
    Friend WithEvents txt_busqueda_ruta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresarDatosARutasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
