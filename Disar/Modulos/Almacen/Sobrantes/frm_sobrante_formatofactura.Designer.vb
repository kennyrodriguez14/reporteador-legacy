<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_sobrante_formatofactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_sobrante_formatofactura))
        Me.btn_verificacion = New System.Windows.Forms.DataGridViewButtonColumn
        Me.grp_ingreso = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        Me.grdFactura = New System.Windows.Forms.DataGridView
        Me.btn_fecha = New System.Windows.Forms.DataGridViewButtonColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_producto = New System.Windows.Forms.DataGridViewButtonColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ruta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_entregador = New System.Windows.Forms.DataGridViewButtonColumn
        Me.entregador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.observacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.verificacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.grp_ingreso.SuspendLayout()
        CType(Me.grdFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_verificacion
        '
        Me.btn_verificacion.HeaderText = "Verificacion"
        Me.btn_verificacion.Name = "btn_verificacion"
        Me.btn_verificacion.Width = 68
        '
        'grp_ingreso
        '
        Me.grp_ingreso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso.Controls.Add(Me.Label1)
        Me.grp_ingreso.Controls.Add(Me.cmb_empresa)
        Me.grp_ingreso.Controls.Add(Me.grdFactura)
        Me.grp_ingreso.Controls.Add(Me.Label12)
        Me.grp_ingreso.Controls.Add(Me.cmb_almacen)
        Me.grp_ingreso.Controls.Add(Me.btn_cancelar)
        Me.grp_ingreso.Controls.Add(Me.btn_aceptar)
        Me.grp_ingreso.Location = New System.Drawing.Point(12, 34)
        Me.grp_ingreso.Name = "grp_ingreso"
        Me.grp_ingreso.Size = New System.Drawing.Size(935, 442)
        Me.grp_ingreso.TabIndex = 35
        Me.grp_ingreso.TabStop = False
        Me.grp_ingreso.Text = "Recurrencias"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Empresa:"
        '
        'cmb_empresa
        '
        Me.cmb_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Items.AddRange(New Object() {"SAN RAFAEL", "SR AGRO", "DIMOSA"})
        Me.cmb_empresa.Location = New System.Drawing.Point(75, 17)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(212, 21)
        Me.cmb_empresa.TabIndex = 26
        '
        'grdFactura
        '
        Me.grdFactura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grdFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFactura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btn_fecha, Me.fecha, Me.btn_producto, Me.codigo, Me.descripcion, Me.cantidad, Me.ruta, Me.btn_entregador, Me.entregador, Me.observacion, Me.btn_verificacion, Me.verificacion})
        Me.grdFactura.Location = New System.Drawing.Point(7, 77)
        Me.grdFactura.Name = "grdFactura"
        Me.grdFactura.Size = New System.Drawing.Size(922, 324)
        Me.grdFactura.TabIndex = 10
        '
        'btn_fecha
        '
        Me.btn_fecha.HeaderText = "..."
        Me.btn_fecha.Name = "btn_fecha"
        Me.btn_fecha.Width = 22
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.Width = 62
        '
        'btn_producto
        '
        Me.btn_producto.HeaderText = "..."
        Me.btn_producto.Name = "btn_producto"
        Me.btn_producto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btn_producto.Width = 41
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.Width = 65
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Width = 88
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.Width = 74
        '
        'ruta
        '
        Me.ruta.HeaderText = "Ruta"
        Me.ruta.Name = "ruta"
        Me.ruta.Width = 55
        '
        'btn_entregador
        '
        Me.btn_entregador.HeaderText = "..."
        Me.btn_entregador.Name = "btn_entregador"
        Me.btn_entregador.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_entregador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btn_entregador.Width = 41
        '
        'entregador
        '
        Me.entregador.HeaderText = "Entregador"
        Me.entregador.Name = "entregador"
        Me.entregador.Width = 84
        '
        'observacion
        '
        Me.observacion.HeaderText = "Observacion"
        Me.observacion.Name = "observacion"
        Me.observacion.Width = 92
        '
        'verificacion
        '
        Me.verificacion.HeaderText = "Verificacion"
        Me.verificacion.Name = "verificacion"
        Me.verificacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.verificacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.verificacion.Width = 68
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Sucursal:"
        '
        'cmb_almacen
        '
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(75, 45)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(212, 21)
        Me.cmb_almacen.TabIndex = 8
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Location = New System.Drawing.Point(854, 413)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 12
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_aceptar.Location = New System.Drawing.Point(6, 413)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 11
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(959, 25)
        Me.ToolStrip1.TabIndex = 36
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'frm_sobrante_formatofactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 482)
        Me.Controls.Add(Me.grp_ingreso)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_sobrante_formatofactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sobrantes"
        Me.grp_ingreso.ResumeLayout(False)
        Me.grp_ingreso.PerformLayout()
        CType(Me.grdFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_verificacion As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents grp_ingreso As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents grdFactura As System.Windows.Forms.DataGridView
    Friend WithEvents btn_fecha As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_producto As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ruta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_entregador As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents entregador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents observacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents verificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
End Class
