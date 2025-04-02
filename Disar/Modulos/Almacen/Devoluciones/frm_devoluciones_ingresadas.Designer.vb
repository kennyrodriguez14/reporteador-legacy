<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_devoluciones_ingresadas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_devoluciones_ingresadas))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_salir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.filtros = New System.Windows.Forms.GroupBox
        Me.txt_factura_final = New System.Windows.Forms.TextBox
        Me.txt_folio = New System.Windows.Forms.TextBox
        Me.txt_entregador = New System.Windows.Forms.TextBox
        Me.txt_ruta = New System.Windows.Forms.TextBox
        Me.txt_factura_inicial = New System.Windows.Forms.TextBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbl_docfin = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbl_docini = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.cmb_fecha_ini = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.grd_encabezados_contado = New System.Windows.Forms.DataGridView
        Me.btn_reporte_carga = New System.Windows.Forms.Button
        Me.btn_enviar_sae = New System.Windows.Forms.Button
        Me.tp_recepcion = New System.Windows.Forms.TabControl
        Me.detalle_devoluciones = New System.Windows.Forms.TabPage
        Me.reporte_carga = New System.Windows.Forms.TabPage
        Me.grd_liquidacion_credito = New System.Windows.Forms.DataGridView
        Me.grd_liquidacion_contado = New System.Windows.Forms.DataGridView
        Me.grd_reporte_carga = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ToolStrip1.SuspendLayout()
        Me.filtros.SuspendLayout()
        CType(Me.grd_encabezados_contado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_recepcion.SuspendLayout()
        Me.detalle_devoluciones.SuspendLayout()
        Me.reporte_carga.SuspendLayout()
        CType(Me.grd_liquidacion_credito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_liquidacion_contado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_reporte_carga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_salir, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(916, 39)
        Me.ToolStrip1.TabIndex = 23
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(68, 36)
        Me.btn_salir.Text = "Salir"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 39)
        '
        'filtros
        '
        Me.filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtros.Controls.Add(Me.txt_factura_final)
        Me.filtros.Controls.Add(Me.txt_folio)
        Me.filtros.Controls.Add(Me.txt_entregador)
        Me.filtros.Controls.Add(Me.txt_ruta)
        Me.filtros.Controls.Add(Me.txt_factura_inicial)
        Me.filtros.Controls.Add(Me.ComboBox1)
        Me.filtros.Controls.Add(Me.cmb_sucursal)
        Me.filtros.Controls.Add(Me.Label4)
        Me.filtros.Controls.Add(Me.Label5)
        Me.filtros.Controls.Add(Me.Label8)
        Me.filtros.Controls.Add(Me.lbl_docfin)
        Me.filtros.Controls.Add(Me.Label7)
        Me.filtros.Controls.Add(Me.lbl_docini)
        Me.filtros.Controls.Add(Me.Label3)
        Me.filtros.Controls.Add(Me.Label6)
        Me.filtros.Controls.Add(Me.Label2)
        Me.filtros.Controls.Add(Me.btn_aceptar)
        Me.filtros.Controls.Add(Me.cmb_fecha_ini)
        Me.filtros.Controls.Add(Me.Label1)
        Me.filtros.Location = New System.Drawing.Point(12, 42)
        Me.filtros.Name = "filtros"
        Me.filtros.Size = New System.Drawing.Size(892, 122)
        Me.filtros.TabIndex = 24
        Me.filtros.TabStop = False
        Me.filtros.Text = "Filtro"
        '
        'txt_factura_final
        '
        Me.txt_factura_final.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_factura_final.Location = New System.Drawing.Point(510, 71)
        Me.txt_factura_final.Name = "txt_factura_final"
        Me.txt_factura_final.Size = New System.Drawing.Size(203, 20)
        Me.txt_factura_final.TabIndex = 5
        '
        'txt_folio
        '
        Me.txt_folio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_folio.Location = New System.Drawing.Point(186, 45)
        Me.txt_folio.Name = "txt_folio"
        Me.txt_folio.ReadOnly = True
        Me.txt_folio.Size = New System.Drawing.Size(202, 20)
        Me.txt_folio.TabIndex = 2
        '
        'txt_entregador
        '
        Me.txt_entregador.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_entregador.Location = New System.Drawing.Point(510, 96)
        Me.txt_entregador.Name = "txt_entregador"
        Me.txt_entregador.Size = New System.Drawing.Size(203, 20)
        Me.txt_entregador.TabIndex = 4
        '
        'txt_ruta
        '
        Me.txt_ruta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_ruta.Location = New System.Drawing.Point(186, 96)
        Me.txt_ruta.Name = "txt_ruta"
        Me.txt_ruta.Size = New System.Drawing.Size(203, 20)
        Me.txt_ruta.TabIndex = 4
        '
        'txt_factura_inicial
        '
        Me.txt_factura_inicial.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_factura_inicial.Location = New System.Drawing.Point(187, 71)
        Me.txt_factura_inicial.Name = "txt_factura_inicial"
        Me.txt_factura_inicial.Size = New System.Drawing.Size(202, 20)
        Me.txt_factura_inicial.TabIndex = 4
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(510, 44)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(203, 21)
        Me.ComboBox1.TabIndex = 3
        Me.ComboBox1.Visible = False
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(186, 18)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(203, 21)
        Me.cmb_sucursal.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(426, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Rango Final:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(432, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Entregador:"
        Me.Label5.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(432, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Entregador:"
        '
        'lbl_docfin
        '
        Me.lbl_docfin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_docfin.AutoSize = True
        Me.lbl_docfin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_docfin.Location = New System.Drawing.Point(507, 94)
        Me.lbl_docfin.Name = "lbl_docfin"
        Me.lbl_docfin.Size = New System.Drawing.Size(0, 13)
        Me.lbl_docfin.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(144, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Ruta:"
        '
        'lbl_docini
        '
        Me.lbl_docini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_docini.AutoSize = True
        Me.lbl_docini.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_docini.Location = New System.Drawing.Point(183, 94)
        Me.lbl_docini.Name = "lbl_docini"
        Me.lbl_docini.Size = New System.Drawing.Size(0, 13)
        Me.lbl_docini.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(96, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Rango Inicial:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(144, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Folio:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(122, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Sucursal:"
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_aceptar.Location = New System.Drawing.Point(802, 25)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(84, 50)
        Me.btn_aceptar.TabIndex = 6
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'cmb_fecha_ini
        '
        Me.cmb_fecha_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_ini.Location = New System.Drawing.Point(510, 18)
        Me.cmb_fecha_ini.Name = "cmb_fecha_ini"
        Me.cmb_fecha_ini.Size = New System.Drawing.Size(203, 20)
        Me.cmb_fecha_ini.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(459, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'grd_encabezados_contado
        '
        Me.grd_encabezados_contado.AllowUserToAddRows = False
        Me.grd_encabezados_contado.AllowUserToDeleteRows = False
        Me.grd_encabezados_contado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_encabezados_contado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_encabezados_contado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_encabezados_contado.Location = New System.Drawing.Point(3, 3)
        Me.grd_encabezados_contado.Name = "grd_encabezados_contado"
        Me.grd_encabezados_contado.ReadOnly = True
        Me.grd_encabezados_contado.Size = New System.Drawing.Size(883, 322)
        Me.grd_encabezados_contado.TabIndex = 25
        '
        'btn_reporte_carga
        '
        Me.btn_reporte_carga.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_reporte_carga.Location = New System.Drawing.Point(6, 292)
        Me.btn_reporte_carga.Name = "btn_reporte_carga"
        Me.btn_reporte_carga.Size = New System.Drawing.Size(143, 23)
        Me.btn_reporte_carga.TabIndex = 7
        Me.btn_reporte_carga.Text = "Generar Reporte de Carga"
        Me.btn_reporte_carga.UseVisualStyleBackColor = True
        '
        'btn_enviar_sae
        '
        Me.btn_enviar_sae.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_enviar_sae.Enabled = False
        Me.btn_enviar_sae.Location = New System.Drawing.Point(766, 530)
        Me.btn_enviar_sae.Name = "btn_enviar_sae"
        Me.btn_enviar_sae.Size = New System.Drawing.Size(143, 23)
        Me.btn_enviar_sae.TabIndex = 26
        Me.btn_enviar_sae.Text = "Enviar a SAE"
        Me.btn_enviar_sae.UseVisualStyleBackColor = True
        '
        'tp_recepcion
        '
        Me.tp_recepcion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tp_recepcion.Controls.Add(Me.detalle_devoluciones)
        Me.tp_recepcion.Controls.Add(Me.reporte_carga)
        Me.tp_recepcion.Location = New System.Drawing.Point(12, 170)
        Me.tp_recepcion.Name = "tp_recepcion"
        Me.tp_recepcion.SelectedIndex = 0
        Me.tp_recepcion.Size = New System.Drawing.Size(897, 354)
        Me.tp_recepcion.TabIndex = 27
        '
        'detalle_devoluciones
        '
        Me.detalle_devoluciones.Controls.Add(Me.grd_encabezados_contado)
        Me.detalle_devoluciones.Location = New System.Drawing.Point(4, 22)
        Me.detalle_devoluciones.Name = "detalle_devoluciones"
        Me.detalle_devoluciones.Padding = New System.Windows.Forms.Padding(3)
        Me.detalle_devoluciones.Size = New System.Drawing.Size(889, 328)
        Me.detalle_devoluciones.TabIndex = 0
        Me.detalle_devoluciones.Text = "Devoluciones"
        Me.detalle_devoluciones.UseVisualStyleBackColor = True
        '
        'reporte_carga
        '
        Me.reporte_carga.Controls.Add(Me.grd_liquidacion_credito)
        Me.reporte_carga.Controls.Add(Me.grd_liquidacion_contado)
        Me.reporte_carga.Controls.Add(Me.grd_reporte_carga)
        Me.reporte_carga.Controls.Add(Me.Button1)
        Me.reporte_carga.Controls.Add(Me.btn_reporte_carga)
        Me.reporte_carga.Location = New System.Drawing.Point(4, 22)
        Me.reporte_carga.Name = "reporte_carga"
        Me.reporte_carga.Padding = New System.Windows.Forms.Padding(3)
        Me.reporte_carga.Size = New System.Drawing.Size(889, 328)
        Me.reporte_carga.TabIndex = 1
        Me.reporte_carga.Text = "Reporte de Carga"
        Me.reporte_carga.UseVisualStyleBackColor = True
        '
        'grd_liquidacion_credito
        '
        Me.grd_liquidacion_credito.AllowUserToAddRows = False
        Me.grd_liquidacion_credito.AllowUserToDeleteRows = False
        Me.grd_liquidacion_credito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_liquidacion_credito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_liquidacion_credito.Location = New System.Drawing.Point(588, 169)
        Me.grd_liquidacion_credito.Name = "grd_liquidacion_credito"
        Me.grd_liquidacion_credito.ReadOnly = True
        Me.grd_liquidacion_credito.Size = New System.Drawing.Size(146, 117)
        Me.grd_liquidacion_credito.TabIndex = 27
        Me.grd_liquidacion_credito.Visible = False
        '
        'grd_liquidacion_contado
        '
        Me.grd_liquidacion_contado.AllowUserToAddRows = False
        Me.grd_liquidacion_contado.AllowUserToDeleteRows = False
        Me.grd_liquidacion_contado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_liquidacion_contado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_liquidacion_contado.Location = New System.Drawing.Point(740, 169)
        Me.grd_liquidacion_contado.Name = "grd_liquidacion_contado"
        Me.grd_liquidacion_contado.ReadOnly = True
        Me.grd_liquidacion_contado.Size = New System.Drawing.Size(146, 117)
        Me.grd_liquidacion_contado.TabIndex = 27
        Me.grd_liquidacion_contado.Visible = False
        '
        'grd_reporte_carga
        '
        Me.grd_reporte_carga.AllowUserToAddRows = False
        Me.grd_reporte_carga.AllowUserToDeleteRows = False
        Me.grd_reporte_carga.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_reporte_carga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_reporte_carga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_reporte_carga.Location = New System.Drawing.Point(3, 3)
        Me.grd_reporte_carga.Name = "grd_reporte_carga"
        Me.grd_reporte_carga.ReadOnly = True
        Me.grd_reporte_carga.Size = New System.Drawing.Size(883, 283)
        Me.grd_reporte_carga.TabIndex = 26
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(155, 292)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(184, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Generar Reporte de Liquidacion"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm_devoluciones_ingresadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 565)
        Me.Controls.Add(Me.tp_recepcion)
        Me.Controls.Add(Me.btn_enviar_sae)
        Me.Controls.Add(Me.filtros)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_devoluciones_ingresadas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recepcion de Devoluciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.filtros.ResumeLayout(False)
        Me.filtros.PerformLayout()
        CType(Me.grd_encabezados_contado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_recepcion.ResumeLayout(False)
        Me.detalle_devoluciones.ResumeLayout(False)
        Me.reporte_carga.ResumeLayout(False)
        CType(Me.grd_liquidacion_credito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_liquidacion_contado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_reporte_carga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents filtros As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmb_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_factura_final As System.Windows.Forms.TextBox
    Friend WithEvents txt_factura_inicial As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grd_encabezados_contado As System.Windows.Forms.DataGridView
    Friend WithEvents btn_reporte_carga As System.Windows.Forms.Button
    Friend WithEvents btn_enviar_sae As System.Windows.Forms.Button
    Friend WithEvents tp_recepcion As System.Windows.Forms.TabControl
    Friend WithEvents detalle_devoluciones As System.Windows.Forms.TabPage
    Friend WithEvents reporte_carga As System.Windows.Forms.TabPage
    Friend WithEvents grd_reporte_carga As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grd_liquidacion_contado As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_folio As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_docfin As System.Windows.Forms.Label
    Friend WithEvents lbl_docini As System.Windows.Forms.Label
    Friend WithEvents txt_entregador As System.Windows.Forms.TextBox
    Friend WithEvents txt_ruta As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grd_liquidacion_credito As System.Windows.Forms.DataGridView
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
