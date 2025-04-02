<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmr_lista_facturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmr_lista_facturas))
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_generar = New System.Windows.Forms.Button
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.cmb_fecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.grd_lista = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.NuevaFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1.SuspendLayout()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_generar)
        Me.GroupBox1.Controls.Add(Me.cmb_almacen)
        Me.GroupBox1.Controls.Add(Me.cmb_fecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(934, 68)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'btn_generar
        '
        Me.btn_generar.Location = New System.Drawing.Point(685, 27)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(75, 22)
        Me.btn_generar.TabIndex = 9
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.UseVisualStyleBackColor = True
        '
        'cmb_almacen
        '
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(402, 27)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(264, 21)
        Me.cmb_almacen.TabIndex = 8
        '
        'cmb_fecha
        '
        Me.cmb_fecha.Location = New System.Drawing.Point(82, 29)
        Me.cmb_fecha.Name = "cmb_fecha"
        Me.cmb_fecha.Size = New System.Drawing.Size(213, 20)
        Me.cmb_fecha.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(330, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Almacen:"
        '
        'grd_lista
        '
        Me.grd_lista.AllowUserToAddRows = False
        Me.grd_lista.AllowUserToDeleteRows = False
        Me.grd_lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_lista.Location = New System.Drawing.Point(13, 117)
        Me.grd_lista.Name = "grd_lista"
        Me.grd_lista.ReadOnly = True
        Me.grd_lista.Size = New System.Drawing.Size(933, 333)
        Me.grd_lista.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(958, 39)
        Me.ToolStrip1.TabIndex = 25
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaFacturaToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Disar.My.Resources.Resources.File_Blue
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(93, 36)
        Me.ToolStripDropDownButton1.Text = "Archivo"
        '
        'NuevaFacturaToolStripMenuItem
        '
        Me.NuevaFacturaToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.NuevaFacturaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevaFacturaToolStripMenuItem.Name = "NuevaFacturaToolStripMenuItem"
        Me.NuevaFacturaToolStripMenuItem.Size = New System.Drawing.Size(166, 38)
        Me.NuevaFacturaToolStripMenuItem.Text = "Nueva Factura"
        '
        'fmr_lista_facturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 462)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grd_lista)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fmr_lista_facturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Facturas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents grd_lista As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_generar As System.Windows.Forms.Button
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents NuevaFacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
