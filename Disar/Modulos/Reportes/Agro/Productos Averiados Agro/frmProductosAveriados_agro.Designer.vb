<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductosAveriados_agro
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
        Me.Label12 = New System.Windows.Forms.Label
        Me.grp_ingreso = New System.Windows.Forms.GroupBox
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.nombre = New System.Windows.Forms.Label
        Me.codigo = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.grdFactura = New System.Windows.Forms.DataGridView
        Me.codigo_producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.observacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmbFecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.filtro = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmbSuursal = New System.Windows.Forms.ComboBox
        Me.cmFechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.grdProductosAveriados = New System.Windows.Forms.DataGridView
        Me.grp_ingreso.SuspendLayout()
        CType(Me.grdFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.filtro.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grdProductosAveriados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(43, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Sucursal:"
        '
        'grp_ingreso
        '
        Me.grp_ingreso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso.Controls.Add(Me.Label12)
        Me.grp_ingreso.Controls.Add(Me.cmb_almacen)
        Me.grp_ingreso.Controls.Add(Me.Button4)
        Me.grp_ingreso.Controls.Add(Me.Button3)
        Me.grp_ingreso.Controls.Add(Me.nombre)
        Me.grp_ingreso.Controls.Add(Me.codigo)
        Me.grp_ingreso.Controls.Add(Me.Button2)
        Me.grp_ingreso.Controls.Add(Me.btnBuscar)
        Me.grp_ingreso.Controls.Add(Me.Label3)
        Me.grp_ingreso.Controls.Add(Me.grdFactura)
        Me.grp_ingreso.Controls.Add(Me.cmbFecha)
        Me.grp_ingreso.Controls.Add(Me.Label2)
        Me.grp_ingreso.Location = New System.Drawing.Point(37, 85)
        Me.grp_ingreso.Name = "grp_ingreso"
        Me.grp_ingreso.Size = New System.Drawing.Size(925, 472)
        Me.grp_ingreso.TabIndex = 31
        Me.grp_ingreso.TabStop = False
        Me.grp_ingreso.Text = "Datos"
        Me.grp_ingreso.Visible = False
        '
        'cmb_almacen
        '
        Me.cmb_almacen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(100, 45)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(212, 21)
        Me.cmb_almacen.TabIndex = 8
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(844, 443)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Cancelar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(7, 443)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Aceptar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'nombre
        '
        Me.nombre.AutoSize = True
        Me.nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre.Location = New System.Drawing.Point(448, 24)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(50, 13)
        Me.nombre.TabIndex = 7
        Me.nombre.Text = "Nombre"
        '
        'codigo
        '
        Me.codigo.AutoSize = True
        Me.codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigo.Location = New System.Drawing.Point(395, 24)
        Me.codigo.Name = "codigo"
        Me.codigo.Size = New System.Drawing.Size(46, 13)
        Me.codigo.TabIndex = 6
        Me.codigo.Text = "Codigo"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 67)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(21, 20)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(368, 20)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(21, 20)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "?"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(320, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cliente:"
        '
        'grdFactura
        '
        Me.grdFactura.AllowUserToAddRows = False
        Me.grdFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grdFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFactura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo_producto, Me.descripcion, Me.cantidad, Me.observacion, Me.costo})
        Me.grdFactura.Location = New System.Drawing.Point(7, 93)
        Me.grdFactura.Name = "grdFactura"
        Me.grdFactura.Size = New System.Drawing.Size(912, 338)
        Me.grdFactura.TabIndex = 10
        '
        'codigo_producto
        '
        Me.codigo_producto.Frozen = True
        Me.codigo_producto.HeaderText = "Codigo Producto"
        Me.codigo_producto.Name = "codigo_producto"
        Me.codigo_producto.ReadOnly = True
        Me.codigo_producto.Width = 102
        '
        'descripcion
        '
        Me.descripcion.Frozen = True
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'cantidad
        '
        Me.cantidad.Frozen = True
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.Width = 74
        '
        'observacion
        '
        Me.observacion.Frozen = True
        Me.observacion.HeaderText = "Observacion"
        Me.observacion.Name = "observacion"
        Me.observacion.Width = 92
        '
        'costo
        '
        Me.costo.HeaderText = "Costo"
        Me.costo.Name = "costo"
        Me.costo.ReadOnly = True
        Me.costo.Width = 59
        '
        'cmbFecha
        '
        Me.cmbFecha.Location = New System.Drawing.Point(100, 19)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.Size = New System.Drawing.Size(212, 20)
        Me.cmbFecha.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha:"
        '
        'filtro
        '
        Me.filtro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtro.Controls.Add(Me.Label1)
        Me.filtro.Controls.Add(Me.Button1)
        Me.filtro.Controls.Add(Me.cmbSuursal)
        Me.filtro.Controls.Add(Me.cmFechaIni)
        Me.filtro.Controls.Add(Me.Label5)
        Me.filtro.Location = New System.Drawing.Point(13, 48)
        Me.filtro.Name = "filtro"
        Me.filtro.Size = New System.Drawing.Size(973, 38)
        Me.filtro.TabIndex = 30
        Me.filtro.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Sucursal:"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.Location = New System.Drawing.Point(590, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 19)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Generar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbSuursal
        '
        Me.cmbSuursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbSuursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSuursal.FormattingEnabled = True
        Me.cmbSuursal.Location = New System.Drawing.Point(70, 11)
        Me.cmbSuursal.Name = "cmbSuursal"
        Me.cmbSuursal.Size = New System.Drawing.Size(212, 21)
        Me.cmbSuursal.TabIndex = 1
        '
        'cmFechaIni
        '
        Me.cmFechaIni.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmFechaIni.Location = New System.Drawing.Point(369, 10)
        Me.cmFechaIni.Name = "cmFechaIni"
        Me.cmFechaIni.Size = New System.Drawing.Size(215, 20)
        Me.cmFechaIni.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(293, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha Inicial:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(998, 39)
        Me.ToolStrip1.TabIndex = 29
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Disar.My.Resources.Resources.Archivo
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(93, 36)
        Me.ToolStripDropDownButton1.Text = "Archivo"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.NuevoToolStripMenuItem.Text = "Nuevo"
        '
        'grdProductosAveriados
        '
        Me.grdProductosAveriados.AllowUserToAddRows = False
        Me.grdProductosAveriados.AllowUserToDeleteRows = False
        Me.grdProductosAveriados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdProductosAveriados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdProductosAveriados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdProductosAveriados.Location = New System.Drawing.Point(13, 92)
        Me.grdProductosAveriados.Name = "grdProductosAveriados"
        Me.grdProductosAveriados.ReadOnly = True
        Me.grdProductosAveriados.Size = New System.Drawing.Size(973, 511)
        Me.grdProductosAveriados.TabIndex = 28
        '
        'frmProductosAveriados_agro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 609)
        Me.Controls.Add(Me.grp_ingreso)
        Me.Controls.Add(Me.filtro)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grdProductosAveriados)
        Me.Name = "frmProductosAveriados_agro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos Averiados Agro"
        Me.grp_ingreso.ResumeLayout(False)
        Me.grp_ingreso.PerformLayout()
        CType(Me.grdFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.filtro.ResumeLayout(False)
        Me.filtro.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grdProductosAveriados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents grp_ingreso As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents nombre As System.Windows.Forms.Label
    Friend WithEvents codigo As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdFactura As System.Windows.Forms.DataGridView
    Friend WithEvents codigo_producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents observacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents filtro As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbSuursal As System.Windows.Forms.ComboBox
    Friend WithEvents cmFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grdProductosAveriados As System.Windows.Forms.DataGridView
End Class
