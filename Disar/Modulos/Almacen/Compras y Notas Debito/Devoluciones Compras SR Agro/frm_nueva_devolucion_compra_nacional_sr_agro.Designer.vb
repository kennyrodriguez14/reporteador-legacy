<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_nueva_devolucion_compra_nacional_sr_agro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_nueva_devolucion_compra_nacional_sr_agro))
        Me.grp_ingreso_datos = New System.Windows.Forms.GroupBox
        Me.txt_flete = New System.Windows.Forms.TextBox
        Me.cmb_tipo_devolucion = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtn_fact_sae = New System.Windows.Forms.TextBox
        Me.txt_cve_compra = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.cmb_fecha_vencimiento = New System.Windows.Forms.DateTimePicker
        Me.Label28 = New System.Windows.Forms.Label
        Me.cmb_lote = New System.Windows.Forms.CheckBox
        Me.txt_lote = New System.Windows.Forms.TextBox
        Me.cmb_fecha_documento = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.btn_cargar_compra = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_rfc = New System.Windows.Forms.TextBox
        Me.txt_nombre_proveedor = New System.Windows.Forms.TextBox
        Me.txt_codigo_proveedor = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_descuento_general = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_referencia_proveedor = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_mostrador_producto = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.txt_totalmostrador = New System.Windows.Forms.TextBox
        Me.txt_total_final = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_isvmostrador = New System.Windows.Forms.TextBox
        Me.txt_isv_final = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_descuento_mostrador = New System.Windows.Forms.TextBox
        Me.txt_descuento_final = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_subtotalmostrador = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txt_subtotal_final = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grp_partida = New System.Windows.Forms.GroupBox
        Me.grd_ingreso = New System.Windows.Forms.DataGridView
        Me.btn_salir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.grp_ingreso_datos.SuspendLayout()
        Me.grp_partida.SuspendLayout()
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_ingreso_datos
        '
        resources.ApplyResources(Me.grp_ingreso_datos, "grp_ingreso_datos")
        Me.grp_ingreso_datos.Controls.Add(Me.txt_flete)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_tipo_devolucion)
        Me.grp_ingreso_datos.Controls.Add(Me.Label7)
        Me.grp_ingreso_datos.Controls.Add(Me.txtn_fact_sae)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_cve_compra)
        Me.grp_ingreso_datos.Controls.Add(Me.Label29)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_vencimiento)
        Me.grp_ingreso_datos.Controls.Add(Me.Label28)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_lote)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_lote)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_fecha_documento)
        Me.grp_ingreso_datos.Controls.Add(Me.Label17)
        Me.grp_ingreso_datos.Controls.Add(Me.cmb_sucursal)
        Me.grp_ingreso_datos.Controls.Add(Me.btn_cargar_compra)
        Me.grp_ingreso_datos.Controls.Add(Me.Label3)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_rfc)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_nombre_proveedor)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_codigo_proveedor)
        Me.grp_ingreso_datos.Controls.Add(Me.Label8)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_descuento_general)
        Me.grp_ingreso_datos.Controls.Add(Me.Label2)
        Me.grp_ingreso_datos.Controls.Add(Me.txt_referencia_proveedor)
        Me.grp_ingreso_datos.Controls.Add(Me.Label9)
        Me.grp_ingreso_datos.Controls.Add(Me.Label1)
        Me.grp_ingreso_datos.Name = "grp_ingreso_datos"
        Me.grp_ingreso_datos.TabStop = False
        '
        'txt_flete
        '
        resources.ApplyResources(Me.txt_flete, "txt_flete")
        Me.txt_flete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_flete.Name = "txt_flete"
        Me.txt_flete.ReadOnly = True
        Me.txt_flete.TabStop = False
        '
        'cmb_tipo_devolucion
        '
        resources.ApplyResources(Me.cmb_tipo_devolucion, "cmb_tipo_devolucion")
        Me.cmb_tipo_devolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo_devolucion.FormattingEnabled = True
        Me.cmb_tipo_devolucion.Items.AddRange(New Object() {resources.GetString("cmb_tipo_devolucion.Items"), resources.GetString("cmb_tipo_devolucion.Items1")})
        Me.cmb_tipo_devolucion.Name = "cmb_tipo_devolucion"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'txtn_fact_sae
        '
        resources.ApplyResources(Me.txtn_fact_sae, "txtn_fact_sae")
        Me.txtn_fact_sae.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtn_fact_sae.Name = "txtn_fact_sae"
        Me.txtn_fact_sae.ReadOnly = True
        Me.txtn_fact_sae.TabStop = False
        '
        'txt_cve_compra
        '
        resources.ApplyResources(Me.txt_cve_compra, "txt_cve_compra")
        Me.txt_cve_compra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cve_compra.Name = "txt_cve_compra"
        Me.txt_cve_compra.ReadOnly = True
        Me.txt_cve_compra.TabStop = False
        '
        'Label29
        '
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.Name = "Label29"
        '
        'cmb_fecha_vencimiento
        '
        resources.ApplyResources(Me.cmb_fecha_vencimiento, "cmb_fecha_vencimiento")
        Me.cmb_fecha_vencimiento.Name = "cmb_fecha_vencimiento"
        '
        'Label28
        '
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.Name = "Label28"
        '
        'cmb_lote
        '
        resources.ApplyResources(Me.cmb_lote, "cmb_lote")
        Me.cmb_lote.Name = "cmb_lote"
        Me.cmb_lote.UseVisualStyleBackColor = True
        '
        'txt_lote
        '
        resources.ApplyResources(Me.txt_lote, "txt_lote")
        Me.txt_lote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_lote.Name = "txt_lote"
        Me.txt_lote.ReadOnly = True
        '
        'cmb_fecha_documento
        '
        resources.ApplyResources(Me.cmb_fecha_documento, "cmb_fecha_documento")
        Me.cmb_fecha_documento.Name = "cmb_fecha_documento"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'cmb_sucursal
        '
        resources.ApplyResources(Me.cmb_sucursal, "cmb_sucursal")
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Name = "cmb_sucursal"
        '
        'btn_cargar_compra
        '
        resources.ApplyResources(Me.btn_cargar_compra, "btn_cargar_compra")
        Me.btn_cargar_compra.Name = "btn_cargar_compra"
        Me.btn_cargar_compra.UseVisualStyleBackColor = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txt_rfc
        '
        resources.ApplyResources(Me.txt_rfc, "txt_rfc")
        Me.txt_rfc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_rfc.Name = "txt_rfc"
        Me.txt_rfc.ReadOnly = True
        Me.txt_rfc.TabStop = False
        '
        'txt_nombre_proveedor
        '
        resources.ApplyResources(Me.txt_nombre_proveedor, "txt_nombre_proveedor")
        Me.txt_nombre_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nombre_proveedor.Name = "txt_nombre_proveedor"
        Me.txt_nombre_proveedor.ReadOnly = True
        Me.txt_nombre_proveedor.TabStop = False
        '
        'txt_codigo_proveedor
        '
        resources.ApplyResources(Me.txt_codigo_proveedor, "txt_codigo_proveedor")
        Me.txt_codigo_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_codigo_proveedor.Name = "txt_codigo_proveedor"
        Me.txt_codigo_proveedor.ReadOnly = True
        Me.txt_codigo_proveedor.TabStop = False
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'txt_descuento_general
        '
        resources.ApplyResources(Me.txt_descuento_general, "txt_descuento_general")
        Me.txt_descuento_general.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_general.Name = "txt_descuento_general"
        Me.txt_descuento_general.ReadOnly = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txt_referencia_proveedor
        '
        resources.ApplyResources(Me.txt_referencia_proveedor, "txt_referencia_proveedor")
        Me.txt_referencia_proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_referencia_proveedor.Name = "txt_referencia_proveedor"
        Me.txt_referencia_proveedor.ReadOnly = True
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txt_mostrador_producto
        '
        resources.ApplyResources(Me.txt_mostrador_producto, "txt_mostrador_producto")
        Me.txt_mostrador_producto.Name = "txt_mostrador_producto"
        Me.txt_mostrador_producto.ReadOnly = True
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'btn_cancelar
        '
        resources.ApplyResources(Me.btn_cancelar, "btn_cancelar")
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        resources.ApplyResources(Me.btn_guardar, "btn_guardar")
        Me.btn_guardar.Image = Global.Disar.My.Resources.Resources.Guardar
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'txt_totalmostrador
        '
        resources.ApplyResources(Me.txt_totalmostrador, "txt_totalmostrador")
        Me.txt_totalmostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_totalmostrador.Name = "txt_totalmostrador"
        Me.txt_totalmostrador.ReadOnly = True
        '
        'txt_total_final
        '
        resources.ApplyResources(Me.txt_total_final, "txt_total_final")
        Me.txt_total_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total_final.Name = "txt_total_final"
        Me.txt_total_final.ReadOnly = True
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.Name = "Label27"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'txt_isvmostrador
        '
        resources.ApplyResources(Me.txt_isvmostrador, "txt_isvmostrador")
        Me.txt_isvmostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isvmostrador.Name = "txt_isvmostrador"
        Me.txt_isvmostrador.ReadOnly = True
        '
        'txt_isv_final
        '
        resources.ApplyResources(Me.txt_isv_final, "txt_isv_final")
        Me.txt_isv_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_isv_final.Name = "txt_isv_final"
        Me.txt_isv_final.ReadOnly = True
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.Name = "Label26"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'txt_descuento_mostrador
        '
        resources.ApplyResources(Me.txt_descuento_mostrador, "txt_descuento_mostrador")
        Me.txt_descuento_mostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_mostrador.Name = "txt_descuento_mostrador"
        Me.txt_descuento_mostrador.ReadOnly = True
        '
        'txt_descuento_final
        '
        resources.ApplyResources(Me.txt_descuento_final, "txt_descuento_final")
        Me.txt_descuento_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_descuento_final.Name = "txt_descuento_final"
        Me.txt_descuento_final.ReadOnly = True
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.Name = "Label25"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txt_subtotalmostrador
        '
        resources.ApplyResources(Me.txt_subtotalmostrador, "txt_subtotalmostrador")
        Me.txt_subtotalmostrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_subtotalmostrador.Name = "txt_subtotalmostrador"
        Me.txt_subtotalmostrador.ReadOnly = True
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.Name = "Label24"
        '
        'txt_subtotal_final
        '
        resources.ApplyResources(Me.txt_subtotal_final, "txt_subtotal_final")
        Me.txt_subtotal_final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_subtotal_final.Name = "txt_subtotal_final"
        Me.txt_subtotal_final.ReadOnly = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'grp_partida
        '
        resources.ApplyResources(Me.grp_partida, "grp_partida")
        Me.grp_partida.Controls.Add(Me.grd_ingreso)
        Me.grp_partida.Name = "grp_partida"
        Me.grp_partida.TabStop = False
        '
        'grd_ingreso
        '
        Me.grd_ingreso.AllowUserToAddRows = False
        Me.grd_ingreso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_ingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.grd_ingreso, "grd_ingreso")
        Me.grd_ingreso.Name = "grd_ingreso"
        Me.grd_ingreso.RowHeadersVisible = False
        Me.grd_ingreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'btn_salir
        '
        resources.ApplyResources(Me.btn_salir, "btn_salir")
        Me.btn_salir.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.btn_salir.Name = "btn_salir"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_salir, Me.ToolStripSeparator7})
        resources.ApplyResources(Me.ToolStrip2, "ToolStrip2")
        Me.ToolStrip2.Name = "ToolStrip2"
        '
        'frm_nueva_devolucion_compra_nacional
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.txt_mostrador_producto)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txt_totalmostrador)
        Me.Controls.Add(Me.txt_total_final)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_isvmostrador)
        Me.Controls.Add(Me.txt_isv_final)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_descuento_mostrador)
        Me.Controls.Add(Me.txt_descuento_final)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_subtotalmostrador)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txt_subtotal_final)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.grp_partida)
        Me.Controls.Add(Me.grp_ingreso_datos)
        Me.KeyPreview = True
        Me.Name = "frm_nueva_devolucion_compra_nacional"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_ingreso_datos.ResumeLayout(False)
        Me.grp_ingreso_datos.PerformLayout()
        Me.grp_partida.ResumeLayout(False)
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grp_ingreso_datos As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_fecha_vencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmb_lote As System.Windows.Forms.CheckBox
    Friend WithEvents txt_lote As System.Windows.Forms.TextBox
    Friend WithEvents cmb_fecha_documento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btn_cargar_compra As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_rfc As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento_general As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_referencia_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_mostrador_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_totalmostrador As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_final As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_isvmostrador As System.Windows.Forms.TextBox
    Friend WithEvents txt_isv_final As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_descuento_mostrador As System.Windows.Forms.TextBox
    Friend WithEvents txt_descuento_final As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_subtotalmostrador As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_subtotal_final As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grp_partida As System.Windows.Forms.GroupBox
    Friend WithEvents grd_ingreso As System.Windows.Forms.DataGridView
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txt_cve_compra As System.Windows.Forms.TextBox
    Friend WithEvents txtn_fact_sae As System.Windows.Forms.TextBox
    Friend WithEvents txt_flete As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmb_tipo_devolucion As System.Windows.Forms.ComboBox
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
End Class
