<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_recurrencias_formato_nuevo_factura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_recurrencias_formato_nuevo_factura))
        Me.grp_ingreso = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_empresa = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmb_almacen = New System.Windows.Forms.ComboBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.grdFactura = New System.Windows.Forms.DataGridView
        Me.btn_codigo_reporte = New System.Windows.Forms.DataGridViewButtonColumn
        Me.codigo_reporte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_codigocargado = New System.Windows.Forms.DataGridViewButtonColumn
        Me.codigo_cargado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion_cargado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_encargado = New System.Windows.Forms.DataGridViewButtonColumn
        Me.encargado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_solucion = New System.Windows.Forms.DataGridViewButtonColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.solucion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.empresa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmbFecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.grp_ingreso.SuspendLayout()
        CType(Me.grdFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp_ingreso
        '
        Me.grp_ingreso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ingreso.Controls.Add(Me.Label1)
        Me.grp_ingreso.Controls.Add(Me.cmb_empresa)
        Me.grp_ingreso.Controls.Add(Me.Label12)
        Me.grp_ingreso.Controls.Add(Me.cmb_almacen)
        Me.grp_ingreso.Controls.Add(Me.btn_cancelar)
        Me.grp_ingreso.Controls.Add(Me.btn_aceptar)
        Me.grp_ingreso.Controls.Add(Me.grdFactura)
        Me.grp_ingreso.Controls.Add(Me.cmbFecha)
        Me.grp_ingreso.Controls.Add(Me.Label2)
        Me.grp_ingreso.Location = New System.Drawing.Point(12, 28)
        Me.grp_ingreso.Name = "grp_ingreso"
        Me.grp_ingreso.Size = New System.Drawing.Size(1060, 505)
        Me.grp_ingreso.TabIndex = 34
        Me.grp_ingreso.TabStop = False
        Me.grp_ingreso.Text = "Recurrencias"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Empresa:"
        '
        'cmb_empresa
        '
        Me.cmb_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresa.FormattingEnabled = True
        Me.cmb_empresa.Items.AddRange(New Object() {"SAN RAFAEL", "DIMOSA"})
        Me.cmb_empresa.Location = New System.Drawing.Point(70, 46)
        Me.cmb_empresa.Name = "cmb_empresa"
        Me.cmb_empresa.Size = New System.Drawing.Size(212, 21)
        Me.cmb_empresa.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Sucursal:"
        '
        'cmb_almacen
        '
        Me.cmb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_almacen.FormattingEnabled = True
        Me.cmb_almacen.Location = New System.Drawing.Point(71, 75)
        Me.cmb_almacen.Name = "cmb_almacen"
        Me.cmb_almacen.Size = New System.Drawing.Size(212, 21)
        Me.cmb_almacen.TabIndex = 8
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Location = New System.Drawing.Point(979, 476)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 12
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_aceptar.Location = New System.Drawing.Point(6, 476)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 11
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'grdFactura
        '
        Me.grdFactura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grdFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFactura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btn_codigo_reporte, Me.codigo_reporte, Me.descripcion, Me.btn_codigocargado, Me.codigo_cargado, Me.descripcion_cargado, Me.btn_encargado, Me.encargado, Me.btn_solucion, Me.codigo, Me.solucion, Me.cantidad, Me.empresa})
        Me.grdFactura.Location = New System.Drawing.Point(7, 108)
        Me.grdFactura.Name = "grdFactura"
        Me.grdFactura.Size = New System.Drawing.Size(1047, 356)
        Me.grdFactura.TabIndex = 10
        '
        'btn_codigo_reporte
        '
        Me.btn_codigo_reporte.HeaderText = "..."
        Me.btn_codigo_reporte.Name = "btn_codigo_reporte"
        Me.btn_codigo_reporte.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_codigo_reporte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btn_codigo_reporte.Width = 41
        '
        'codigo_reporte
        '
        Me.codigo_reporte.HeaderText = "Codigo Reporte"
        Me.codigo_reporte.Name = "codigo_reporte"
        Me.codigo_reporte.Width = 97
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Width = 88
        '
        'btn_codigocargado
        '
        Me.btn_codigocargado.HeaderText = "..."
        Me.btn_codigocargado.Name = "btn_codigocargado"
        Me.btn_codigocargado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_codigocargado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btn_codigocargado.Width = 41
        '
        'codigo_cargado
        '
        Me.codigo_cargado.HeaderText = "Codigo Cargado"
        Me.codigo_cargado.Name = "codigo_cargado"
        Me.codigo_cargado.Width = 99
        '
        'descripcion_cargado
        '
        Me.descripcion_cargado.HeaderText = "Descripcion "
        Me.descripcion_cargado.Name = "descripcion_cargado"
        Me.descripcion_cargado.Width = 91
        '
        'btn_encargado
        '
        Me.btn_encargado.HeaderText = "..."
        Me.btn_encargado.Name = "btn_encargado"
        Me.btn_encargado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_encargado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btn_encargado.Width = 41
        '
        'encargado
        '
        Me.encargado.HeaderText = "Encargado"
        Me.encargado.Name = "encargado"
        Me.encargado.Width = 84
        '
        'btn_solucion
        '
        Me.btn_solucion.HeaderText = "..."
        Me.btn_solucion.Name = "btn_solucion"
        Me.btn_solucion.Width = 22
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.Width = 65
        '
        'solucion
        '
        Me.solucion.HeaderText = "Solucion"
        Me.solucion.Name = "solucion"
        Me.solucion.Width = 73
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.Width = 74
        '
        'empresa
        '
        Me.empresa.HeaderText = "Empresa"
        Me.empresa.Name = "empresa"
        Me.empresa.Visible = False
        Me.empresa.Width = 73
        '
        'cmbFecha
        '
        Me.cmbFecha.Location = New System.Drawing.Point(71, 19)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.Size = New System.Drawing.Size(212, 20)
        Me.cmbFecha.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1084, 25)
        Me.ToolStrip1.TabIndex = 35
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'frm_recurrencias_formato_nuevo_factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 532)
        Me.Controls.Add(Me.grp_ingreso)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_recurrencias_formato_nuevo_factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recurrencias"
        Me.grp_ingreso.ResumeLayout(False)
        Me.grp_ingreso.PerformLayout()
        CType(Me.grdFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grp_ingreso As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents grdFactura As System.Windows.Forms.DataGridView
    Friend WithEvents btn_codigo_reporte As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents codigo_reporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_codigocargado As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents codigo_cargado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion_cargado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_encargado As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents encargado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_solucion As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents solucion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents empresa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
End Class
