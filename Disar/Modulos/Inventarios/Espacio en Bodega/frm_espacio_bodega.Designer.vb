<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_espacio_bodega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_espacio_bodega))
        Me.grpFiltros = New System.Windows.Forms.GroupBox
        Me.BtnConfigurar = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbFecha = New System.Windows.Forms.DateTimePicker
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.cmbSucursal = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grd_detallado = New System.Windows.Forms.DataGridView
        Me.Panel = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grd_general = New System.Windows.Forms.DataGridView
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbltotaltarimas = New System.Windows.Forms.Label
        Me.lbltotalocupado = New System.Windows.Forms.Label
        Me.lbltotaldisponible = New System.Windows.Forms.Label
        Me.lblporocupado = New System.Windows.Forms.Label
        Me.lblpordisponible = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LbVolumen = New System.Windows.Forms.Label
        Me.lblVolPorDisp = New System.Windows.Forms.Label
        Me.lblVolDisp = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblVolPorOc = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblVolOcup = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.grpFiltros.SuspendLayout()
        CType(Me.grd_detallado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.grd_general, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpFiltros
        '
        Me.grpFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFiltros.Controls.Add(Me.BtnConfigurar)
        Me.grpFiltros.Controls.Add(Me.Label7)
        Me.grpFiltros.Controls.Add(Me.cmbFecha)
        Me.grpFiltros.Controls.Add(Me._btnGenerar)
        Me.grpFiltros.Controls.Add(Me.cmbSucursal)
        Me.grpFiltros.Controls.Add(Me.Label1)
        Me.grpFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFiltros.Location = New System.Drawing.Point(12, 42)
        Me.grpFiltros.Name = "grpFiltros"
        Me.grpFiltros.Size = New System.Drawing.Size(878, 49)
        Me.grpFiltros.TabIndex = 2
        Me.grpFiltros.TabStop = False
        '
        'BtnConfigurar
        '
        Me.BtnConfigurar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConfigurar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfigurar.Location = New System.Drawing.Point(753, 17)
        Me.BtnConfigurar.Name = "BtnConfigurar"
        Me.BtnConfigurar.Size = New System.Drawing.Size(119, 23)
        Me.BtnConfigurar.TabIndex = 5
        Me.BtnConfigurar.Text = "Fijar Paletizado"
        Me.BtnConfigurar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(163, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Fecha:"
        '
        'cmbFecha
        '
        Me.cmbFecha.Location = New System.Drawing.Point(227, 16)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.Size = New System.Drawing.Size(300, 26)
        Me.cmbFecha.TabIndex = 2
        '
        '_btnGenerar
        '
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(542, 17)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(65, 23)
        Me._btnGenerar.TabIndex = 3
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'cmbSucursal
        '
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Items.AddRange(New Object() {"SPS", "SRC", "Tocoa", "Tegucigalpa"})
        Me.cmbSucursal.Location = New System.Drawing.Point(70, 16)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(87, 23)
        Me.cmbSucursal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sucursal:"
        '
        'grd_detallado
        '
        Me.grd_detallado.AllowUserToAddRows = False
        Me.grd_detallado.AllowUserToDeleteRows = False
        Me.grd_detallado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_detallado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_detallado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_detallado.Location = New System.Drawing.Point(3, 3)
        Me.grd_detallado.Name = "grd_detallado"
        Me.grd_detallado.ReadOnly = True
        Me.grd_detallado.Size = New System.Drawing.Size(865, 412)
        Me.grd_detallado.TabIndex = 9
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.Controls.Add(Me.TabPage1)
        Me.Panel.Controls.Add(Me.TabPage2)
        Me.Panel.Location = New System.Drawing.Point(13, 154)
        Me.Panel.Name = "Panel"
        Me.Panel.SelectedIndex = 0
        Me.Panel.Size = New System.Drawing.Size(879, 444)
        Me.Panel.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grd_detallado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(871, 418)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Consolidado"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grd_general)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(871, 418)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grd_general
        '
        Me.grd_general.AllowUserToAddRows = False
        Me.grd_general.AllowUserToDeleteRows = False
        Me.grd_general.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_general.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_general.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_general.Location = New System.Drawing.Point(3, 3)
        Me.grd_general.Name = "grd_general"
        Me.grd_general.ReadOnly = True
        Me.grd_general.Size = New System.Drawing.Size(865, 412)
        Me.grd_general.TabIndex = 10
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 36)
        Me.ToolStripButton1.Tag = "Exportar a Excel"
        Me.ToolStripButton1.Text = "Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(904, 39)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripButton2.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(72, 36)
        Me.ToolStripButton2.Tag = "Exportar a Excel"
        Me.ToolStripButton2.Text = "Excel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Total de Tarimas:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(144, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Total Ocupado:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(144, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Total Disponible:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(290, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Porcentaje Ocupado:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(290, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Porcentaje Disponible:"
        '
        'lbltotaltarimas
        '
        Me.lbltotaltarimas.AutoSize = True
        Me.lbltotaltarimas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotaltarimas.Location = New System.Drawing.Point(113, 16)
        Me.lbltotaltarimas.Name = "lbltotaltarimas"
        Me.lbltotaltarimas.Size = New System.Drawing.Size(13, 13)
        Me.lbltotaltarimas.TabIndex = 18
        Me.lbltotaltarimas.Text = "0"
        '
        'lbltotalocupado
        '
        Me.lbltotalocupado.AutoSize = True
        Me.lbltotalocupado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalocupado.Location = New System.Drawing.Point(245, 16)
        Me.lbltotalocupado.Name = "lbltotalocupado"
        Me.lbltotalocupado.Size = New System.Drawing.Size(13, 13)
        Me.lbltotalocupado.TabIndex = 18
        Me.lbltotalocupado.Text = "0"
        '
        'lbltotaldisponible
        '
        Me.lbltotaldisponible.AutoSize = True
        Me.lbltotaldisponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotaldisponible.Location = New System.Drawing.Point(245, 39)
        Me.lbltotaldisponible.Name = "lbltotaldisponible"
        Me.lbltotaldisponible.Size = New System.Drawing.Size(13, 13)
        Me.lbltotaldisponible.TabIndex = 18
        Me.lbltotaldisponible.Text = "0"
        '
        'lblporocupado
        '
        Me.lblporocupado.AutoSize = True
        Me.lblporocupado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblporocupado.Location = New System.Drawing.Point(421, 16)
        Me.lblporocupado.Name = "lblporocupado"
        Me.lblporocupado.Size = New System.Drawing.Size(13, 13)
        Me.lblporocupado.TabIndex = 18
        Me.lblporocupado.Text = "0"
        '
        'lblpordisponible
        '
        Me.lblpordisponible.AutoSize = True
        Me.lblpordisponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpordisponible.Location = New System.Drawing.Point(421, 39)
        Me.lblpordisponible.Name = "lblpordisponible"
        Me.lblpordisponible.Size = New System.Drawing.Size(13, 13)
        Me.lblpordisponible.TabIndex = 18
        Me.lblpordisponible.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbltotaltarimas)
        Me.GroupBox1.Controls.Add(Me.lbltotaldisponible)
        Me.GroupBox1.Controls.Add(Me.lbltotalocupado)
        Me.GroupBox1.Controls.Add(Me.lblpordisponible)
        Me.GroupBox1.Controls.Add(Me.lblporocupado)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 90)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(481, 61)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.LbVolumen)
        Me.GroupBox2.Controls.Add(Me.lblVolPorDisp)
        Me.GroupBox2.Controls.Add(Me.lblVolDisp)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lblVolPorOc)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lblVolOcup)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(500, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(390, 83)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        '
        'LbVolumen
        '
        Me.LbVolumen.AutoSize = True
        Me.LbVolumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbVolumen.Location = New System.Drawing.Point(148, 16)
        Me.LbVolumen.Name = "LbVolumen"
        Me.LbVolumen.Size = New System.Drawing.Size(13, 13)
        Me.LbVolumen.TabIndex = 18
        Me.LbVolumen.Text = "0"
        '
        'lblVolPorDisp
        '
        Me.lblVolPorDisp.AutoSize = True
        Me.lblVolPorDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVolPorDisp.Location = New System.Drawing.Point(330, 62)
        Me.lblVolPorDisp.Name = "lblVolPorDisp"
        Me.lblVolPorDisp.Size = New System.Drawing.Size(13, 13)
        Me.lblVolPorDisp.TabIndex = 18
        Me.lblVolPorDisp.Text = "0"
        '
        'lblVolDisp
        '
        Me.lblVolDisp.AutoSize = True
        Me.lblVolDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVolDisp.Location = New System.Drawing.Point(148, 62)
        Me.lblVolDisp.Name = "lblVolDisp"
        Me.lblVolDisp.Size = New System.Drawing.Size(13, 13)
        Me.lblVolDisp.TabIndex = 18
        Me.lblVolDisp.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Volumen Total:"
        '
        'lblVolPorOc
        '
        Me.lblVolPorOc.AutoSize = True
        Me.lblVolPorOc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVolPorOc.Location = New System.Drawing.Point(330, 39)
        Me.lblVolPorOc.Name = "lblVolPorOc"
        Me.lblVolPorOc.Size = New System.Drawing.Size(13, 13)
        Me.lblVolPorOc.TabIndex = 18
        Me.lblVolPorOc.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(201, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Porcentaje Ocupado:"
        '
        'lblVolOcup
        '
        Me.lblVolOcup.AutoSize = True
        Me.lblVolOcup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVolOcup.Location = New System.Drawing.Point(148, 39)
        Me.lblVolOcup.Name = "lblVolOcup"
        Me.lblVolOcup.Size = New System.Drawing.Size(13, 13)
        Me.lblVolOcup.TabIndex = 18
        Me.lblVolOcup.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(201, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(135, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Porcentaje Disponible:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(25, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Volumen Ocupado:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(25, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Volumen Disponible:"
        '
        'frm_espacio_bodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 610)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grpFiltros)
        Me.Controls.Add(Me.Panel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_espacio_bodega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Espacio en Bodega"
        Me.grpFiltros.ResumeLayout(False)
        Me.grpFiltros.PerformLayout()
        CType(Me.grd_detallado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grd_general, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grd_detallado As System.Windows.Forms.DataGridView
    Friend WithEvents Panel As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grd_general As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbltotaltarimas As System.Windows.Forms.Label
    Friend WithEvents lbltotalocupado As System.Windows.Forms.Label
    Friend WithEvents lbltotaldisponible As System.Windows.Forms.Label
    Friend WithEvents lblporocupado As System.Windows.Forms.Label
    Friend WithEvents lblpordisponible As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LbVolumen As System.Windows.Forms.Label
    Friend WithEvents lblVolPorDisp As System.Windows.Forms.Label
    Friend WithEvents lblVolDisp As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblVolPorOc As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblVolOcup As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BtnConfigurar As System.Windows.Forms.Button
End Class
