<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tab_detalle_rutas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tab_detalle_rutas))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.grd_lista_rutas = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_ruta = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_salida = New System.Windows.Forms.TextBox
        Me.txt_desayuno = New System.Windows.Forms.TextBox
        Me.txt_almuerzo = New System.Windows.Forms.TextBox
        Me.txt_devoluciones = New System.Windows.Forms.TextBox
        Me.txt_liquidacion = New System.Windows.Forms.TextBox
        Me.txt_tiempo = New System.Windows.Forms.TextBox
        Me.txt_regreso = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_id = New System.Windows.Forms.TextBox
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grd_lista_rutas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(567, 39)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAExcelToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Disar.My.Resources.Resources.File_Blue
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(93, 36)
        Me.ToolStripDropDownButton1.Text = "Archivo"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.ExportarAExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(171, 38)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar a Excel"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(171, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'grd_lista_rutas
        '
        Me.grd_lista_rutas.AllowUserToAddRows = False
        Me.grd_lista_rutas.AllowUserToDeleteRows = False
        Me.grd_lista_rutas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_lista_rutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_lista_rutas.Location = New System.Drawing.Point(12, 171)
        Me.grd_lista_rutas.Name = "grd_lista_rutas"
        Me.grd_lista_rutas.ReadOnly = True
        Me.grd_lista_rutas.Size = New System.Drawing.Size(541, 296)
        Me.grd_lista_rutas.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_tiempo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_almuerzo)
        Me.GroupBox1.Controls.Add(Me.txt_desayuno)
        Me.GroupBox1.Controls.Add(Me.txt_regreso)
        Me.GroupBox1.Controls.Add(Me.txt_liquidacion)
        Me.GroupBox1.Controls.Add(Me.txt_devoluciones)
        Me.GroupBox1.Controls.Add(Me.txt_salida)
        Me.GroupBox1.Controls.Add(Me.txt_id)
        Me.GroupBox1.Controls.Add(Me.txt_ruta)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(543, 123)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(280, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Liquidacion General:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(254, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Entrega de Devoluciones:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(83, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Salida de CD:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(101, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Almuerzo:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(100, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Desayuno:"
        '
        'txt_ruta
        '
        Me.txt_ruta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_ruta.Location = New System.Drawing.Point(115, 16)
        Me.txt_ruta.Name = "txt_ruta"
        Me.txt_ruta.ReadOnly = True
        Me.txt_ruta.Size = New System.Drawing.Size(263, 20)
        Me.txt_ruta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Ruta:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(384, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Tiempo Total:"
        '
        'txt_salida
        '
        Me.txt_salida.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_salida.Location = New System.Drawing.Point(160, 46)
        Me.txt_salida.Name = "txt_salida"
        Me.txt_salida.ReadOnly = True
        Me.txt_salida.Size = New System.Drawing.Size(63, 20)
        Me.txt_salida.TabIndex = 3
        '
        'txt_desayuno
        '
        Me.txt_desayuno.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_desayuno.Location = New System.Drawing.Point(160, 70)
        Me.txt_desayuno.Name = "txt_desayuno"
        Me.txt_desayuno.ReadOnly = True
        Me.txt_desayuno.Size = New System.Drawing.Size(63, 20)
        Me.txt_desayuno.TabIndex = 5
        '
        'txt_almuerzo
        '
        Me.txt_almuerzo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_almuerzo.Location = New System.Drawing.Point(160, 95)
        Me.txt_almuerzo.Name = "txt_almuerzo"
        Me.txt_almuerzo.ReadOnly = True
        Me.txt_almuerzo.Size = New System.Drawing.Size(63, 20)
        Me.txt_almuerzo.TabIndex = 7
        '
        'txt_devoluciones
        '
        Me.txt_devoluciones.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_devoluciones.Location = New System.Drawing.Point(390, 46)
        Me.txt_devoluciones.Name = "txt_devoluciones"
        Me.txt_devoluciones.ReadOnly = True
        Me.txt_devoluciones.Size = New System.Drawing.Size(64, 20)
        Me.txt_devoluciones.TabIndex = 4
        '
        'txt_liquidacion
        '
        Me.txt_liquidacion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_liquidacion.Location = New System.Drawing.Point(390, 95)
        Me.txt_liquidacion.Name = "txt_liquidacion"
        Me.txt_liquidacion.ReadOnly = True
        Me.txt_liquidacion.Size = New System.Drawing.Size(64, 20)
        Me.txt_liquidacion.TabIndex = 6
        '
        'txt_tiempo
        '
        Me.txt_tiempo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_tiempo.Location = New System.Drawing.Point(462, 16)
        Me.txt_tiempo.Name = "txt_tiempo"
        Me.txt_tiempo.ReadOnly = True
        Me.txt_tiempo.Size = New System.Drawing.Size(54, 20)
        Me.txt_tiempo.TabIndex = 8
        '
        'txt_regreso
        '
        Me.txt_regreso.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_regreso.Location = New System.Drawing.Point(390, 70)
        Me.txt_regreso.Name = "txt_regreso"
        Me.txt_regreso.ReadOnly = True
        Me.txt_regreso.Size = New System.Drawing.Size(64, 20)
        Me.txt_regreso.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(307, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Regreso a CD:"
        '
        'txt_id
        '
        Me.txt_id.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_id.Location = New System.Drawing.Point(71, 16)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.ReadOnly = True
        Me.txt_id.Size = New System.Drawing.Size(38, 20)
        Me.txt_id.TabIndex = 2
        '
        'frm_tab_detalle_rutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 479)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grd_lista_rutas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_tab_detalle_rutas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de la Ruta"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grd_lista_rutas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grd_lista_rutas As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_ruta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_almuerzo As System.Windows.Forms.TextBox
    Friend WithEvents txt_desayuno As System.Windows.Forms.TextBox
    Friend WithEvents txt_tiempo As System.Windows.Forms.TextBox
    Friend WithEvents txt_liquidacion As System.Windows.Forms.TextBox
    Friend WithEvents txt_devoluciones As System.Windows.Forms.TextBox
    Friend WithEvents txt_salida As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_regreso As System.Windows.Forms.TextBox
    Friend WithEvents txt_id As System.Windows.Forms.TextBox
End Class
