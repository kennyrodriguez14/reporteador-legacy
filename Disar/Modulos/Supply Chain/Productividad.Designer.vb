<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Productividad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Productividad))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._gbCriteriosBusqueda = New System.Windows.Forms.GroupBox
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me._btnGenerar = New System.Windows.Forms.Button
        Me._cmbFechai = New System.Windows.Forms.DateTimePicker
        Me._lblFechai = New System.Windows.Forms.Label
        Me.Panel = New System.Windows.Forms.TabControl
        Me.Usuario1 = New System.Windows.Forms.TabPage
        Me.txtMinutosXF1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNumMinutos = New System.Windows.Forms.Label
        Me.txtPromedioMinutos = New System.Windows.Forms.Label
        Me.txtNumHoras = New System.Windows.Forms.Label
        Me.txtPromedioHoras = New System.Windows.Forms.Label
        Me.txtNumeroFacturas = New System.Windows.Forms.Label
        Me.txtHorafinal = New System.Windows.Forms.Label
        Me.txtHoraInicial = New System.Windows.Forms.Label
        Me.lblhoraf = New System.Windows.Forms.Label
        Me.lblhorai = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me._gridUsuario1 = New System.Windows.Forms.DataGridView
        Me.Usuario2 = New System.Windows.Forms.TabPage
        Me.txtMinutosXF2 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNumMinutos2 = New System.Windows.Forms.Label
        Me.txtPromMinutos2 = New System.Windows.Forms.Label
        Me.txtNumHoras2 = New System.Windows.Forms.Label
        Me.txtPromedioHoras2 = New System.Windows.Forms.Label
        Me.txtNumeroFacturas2 = New System.Windows.Forms.Label
        Me.txtHoraFinal2 = New System.Windows.Forms.Label
        Me.txtHoraInicial2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me._gridUsuario2 = New System.Windows.Forms.DataGridView
        Me.Usuario3 = New System.Windows.Forms.TabPage
        Me.txtMF3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtnum3 = New System.Windows.Forms.Label
        Me.txtfxm3 = New System.Windows.Forms.Label
        Me.txtnh3 = New System.Windows.Forms.Label
        Me.txtFxh3 = New System.Windows.Forms.Label
        Me.txtNF3 = New System.Windows.Forms.Label
        Me.txtHfinal3 = New System.Windows.Forms.Label
        Me.txtHinicial3 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me._gridUsuario3 = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me._gbCriteriosBusqueda.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        Me.Usuario1.SuspendLayout()
        CType(Me._gridUsuario1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Usuario2.SuspendLayout()
        CType(Me._gridUsuario2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Usuario3.SuspendLayout()
        CType(Me._gridUsuario3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(992, 39)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '_Archivo
        '
        Me._Archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAExcelToolStripMenuItem})
        Me._Archivo.Image = Global.Disar.My.Resources.Resources.Opciones
        Me._Archivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Archivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._Archivo.Name = "_Archivo"
        Me._Archivo.Size = New System.Drawing.Size(100, 36)
        Me._Archivo.Text = "Acciones"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Excel_32
        Me.ExportarAExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(171, 38)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar a Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        '_gbCriteriosBusqueda
        '
        Me._gbCriteriosBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gbCriteriosBusqueda.Controls.Add(Me.Imagen)
        Me._gbCriteriosBusqueda.Controls.Add(Me._btnGenerar)
        Me._gbCriteriosBusqueda.Controls.Add(Me._cmbFechai)
        Me._gbCriteriosBusqueda.Controls.Add(Me._lblFechai)
        Me._gbCriteriosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._gbCriteriosBusqueda.Location = New System.Drawing.Point(12, 42)
        Me._gbCriteriosBusqueda.Name = "_gbCriteriosBusqueda"
        Me._gbCriteriosBusqueda.Size = New System.Drawing.Size(968, 62)
        Me._gbCriteriosBusqueda.TabIndex = 9
        Me._gbCriteriosBusqueda.TabStop = False
        Me._gbCriteriosBusqueda.Text = "Criterios de Busqueda"
        '
        'Imagen
        '
        Me.Imagen.Image = Global.Disar.My.Resources.Resources.Disar_Logo_26
        Me.Imagen.Location = New System.Drawing.Point(745, 39)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(15, 17)
        Me.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen.TabIndex = 24
        Me.Imagen.TabStop = False
        Me.Imagen.Visible = False
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(802, 22)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(87, 25)
        Me._btnGenerar.TabIndex = 6
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        '_cmbFechai
        '
        Me._cmbFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._cmbFechai.Location = New System.Drawing.Point(498, 23)
        Me._cmbFechai.Name = "_cmbFechai"
        Me._cmbFechai.Size = New System.Drawing.Size(277, 23)
        Me._cmbFechai.TabIndex = 4
        '
        '_lblFechai
        '
        Me._lblFechai.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._lblFechai.AutoSize = True
        Me._lblFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblFechai.Location = New System.Drawing.Point(390, 25)
        Me._lblFechai.Name = "_lblFechai"
        Me._lblFechai.Size = New System.Drawing.Size(104, 17)
        Me._lblFechai.TabIndex = 0
        Me._lblFechai.Text = "Fecha Inicial:"
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.Controls.Add(Me.Usuario1)
        Me.Panel.Controls.Add(Me.Usuario2)
        Me.Panel.Controls.Add(Me.Usuario3)
        Me.Panel.Location = New System.Drawing.Point(13, 111)
        Me.Panel.Name = "Panel"
        Me.Panel.SelectedIndex = 0
        Me.Panel.Size = New System.Drawing.Size(967, 489)
        Me.Panel.TabIndex = 10
        '
        'Usuario1
        '
        Me.Usuario1.Controls.Add(Me.txtMinutosXF1)
        Me.Usuario1.Controls.Add(Me.Label3)
        Me.Usuario1.Controls.Add(Me.txtNumMinutos)
        Me.Usuario1.Controls.Add(Me.txtPromedioMinutos)
        Me.Usuario1.Controls.Add(Me.txtNumHoras)
        Me.Usuario1.Controls.Add(Me.txtPromedioHoras)
        Me.Usuario1.Controls.Add(Me.txtNumeroFacturas)
        Me.Usuario1.Controls.Add(Me.txtHorafinal)
        Me.Usuario1.Controls.Add(Me.txtHoraInicial)
        Me.Usuario1.Controls.Add(Me.lblhoraf)
        Me.Usuario1.Controls.Add(Me.lblhorai)
        Me.Usuario1.Controls.Add(Me.Label22)
        Me.Usuario1.Controls.Add(Me.Label23)
        Me.Usuario1.Controls.Add(Me.Label24)
        Me.Usuario1.Controls.Add(Me.Label25)
        Me.Usuario1.Controls.Add(Me.Label26)
        Me.Usuario1.Controls.Add(Me._gridUsuario1)
        Me.Usuario1.Location = New System.Drawing.Point(4, 22)
        Me.Usuario1.Name = "Usuario1"
        Me.Usuario1.Padding = New System.Windows.Forms.Padding(3)
        Me.Usuario1.Size = New System.Drawing.Size(959, 463)
        Me.Usuario1.TabIndex = 2
        Me.Usuario1.UseVisualStyleBackColor = True
        '
        'txtMinutosXF1
        '
        Me.txtMinutosXF1.AutoSize = True
        Me.txtMinutosXF1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinutosXF1.Location = New System.Drawing.Point(847, 32)
        Me.txtMinutosXF1.Name = "txtMinutosXF1"
        Me.txtMinutosXF1.Size = New System.Drawing.Size(10, 15)
        Me.txtMinutosXF1.TabIndex = 38
        Me.txtMinutosXF1.Text = " "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(704, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Minutos por Factura:"
        '
        'txtNumMinutos
        '
        Me.txtNumMinutos.AutoSize = True
        Me.txtNumMinutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumMinutos.Location = New System.Drawing.Point(848, 12)
        Me.txtNumMinutos.Name = "txtNumMinutos"
        Me.txtNumMinutos.Size = New System.Drawing.Size(10, 15)
        Me.txtNumMinutos.TabIndex = 34
        Me.txtNumMinutos.Text = " "
        '
        'txtPromedioMinutos
        '
        Me.txtPromedioMinutos.AutoSize = True
        Me.txtPromedioMinutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPromedioMinutos.Location = New System.Drawing.Point(611, 32)
        Me.txtPromedioMinutos.Name = "txtPromedioMinutos"
        Me.txtPromedioMinutos.Size = New System.Drawing.Size(10, 15)
        Me.txtPromedioMinutos.TabIndex = 33
        Me.txtPromedioMinutos.Text = " "
        '
        'txtNumHoras
        '
        Me.txtNumHoras.AutoSize = True
        Me.txtNumHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumHoras.Location = New System.Drawing.Point(611, 12)
        Me.txtNumHoras.Name = "txtNumHoras"
        Me.txtNumHoras.Size = New System.Drawing.Size(10, 15)
        Me.txtNumHoras.TabIndex = 32
        Me.txtNumHoras.Text = " "
        '
        'txtPromedioHoras
        '
        Me.txtPromedioHoras.AutoSize = True
        Me.txtPromedioHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPromedioHoras.Location = New System.Drawing.Point(349, 32)
        Me.txtPromedioHoras.Name = "txtPromedioHoras"
        Me.txtPromedioHoras.Size = New System.Drawing.Size(10, 15)
        Me.txtPromedioHoras.TabIndex = 31
        Me.txtPromedioHoras.Text = " "
        '
        'txtNumeroFacturas
        '
        Me.txtNumeroFacturas.AutoSize = True
        Me.txtNumeroFacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroFacturas.Location = New System.Drawing.Point(349, 12)
        Me.txtNumeroFacturas.Name = "txtNumeroFacturas"
        Me.txtNumeroFacturas.Size = New System.Drawing.Size(10, 15)
        Me.txtNumeroFacturas.TabIndex = 30
        Me.txtNumeroFacturas.Text = " "
        '
        'txtHorafinal
        '
        Me.txtHorafinal.AutoSize = True
        Me.txtHorafinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorafinal.Location = New System.Drawing.Point(102, 32)
        Me.txtHorafinal.Name = "txtHorafinal"
        Me.txtHorafinal.Size = New System.Drawing.Size(10, 15)
        Me.txtHorafinal.TabIndex = 29
        Me.txtHorafinal.Text = " "
        '
        'txtHoraInicial
        '
        Me.txtHoraInicial.AutoSize = True
        Me.txtHoraInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraInicial.Location = New System.Drawing.Point(102, 12)
        Me.txtHoraInicial.Name = "txtHoraInicial"
        Me.txtHoraInicial.Size = New System.Drawing.Size(10, 15)
        Me.txtHoraInicial.TabIndex = 28
        Me.txtHoraInicial.Text = " "
        '
        'lblhoraf
        '
        Me.lblhoraf.AutoSize = True
        Me.lblhoraf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhoraf.Location = New System.Drawing.Point(27, 32)
        Me.lblhoraf.Name = "lblhoraf"
        Me.lblhoraf.Size = New System.Drawing.Size(78, 15)
        Me.lblhoraf.TabIndex = 27
        Me.lblhoraf.Text = "Hora Final:"
        '
        'lblhorai
        '
        Me.lblhorai.AutoSize = True
        Me.lblhorai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhorai.Location = New System.Drawing.Point(20, 12)
        Me.lblhorai.Name = "lblhorai"
        Me.lblhorai.Size = New System.Drawing.Size(85, 15)
        Me.lblhorai.TabIndex = 26
        Me.lblhorai.Text = "Hora Inicial:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(470, 32)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(139, 15)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "Facturas por Minuto:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(217, 32)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(126, 15)
        Me.Label23.TabIndex = 24
        Me.Label23.Text = "Facturas por Hora:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(485, 12)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(124, 15)
        Me.Label24.TabIndex = 23
        Me.Label24.Text = "Numero de Horas:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(706, 12)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(137, 15)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "Numero de Minutos:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(202, 12)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(141, 15)
        Me.Label26.TabIndex = 21
        Me.Label26.Text = "Numero de Facturas:"
        '
        '_gridUsuario1
        '
        Me._gridUsuario1.AllowUserToAddRows = False
        Me._gridUsuario1.AllowUserToDeleteRows = False
        Me._gridUsuario1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gridUsuario1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridUsuario1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridUsuario1.Location = New System.Drawing.Point(4, 64)
        Me._gridUsuario1.Name = "_gridUsuario1"
        Me._gridUsuario1.ReadOnly = True
        Me._gridUsuario1.Size = New System.Drawing.Size(947, 393)
        Me._gridUsuario1.TabIndex = 2
        '
        'Usuario2
        '
        Me.Usuario2.Controls.Add(Me.txtMinutosXF2)
        Me.Usuario2.Controls.Add(Me.Label2)
        Me.Usuario2.Controls.Add(Me.txtNumMinutos2)
        Me.Usuario2.Controls.Add(Me.txtPromMinutos2)
        Me.Usuario2.Controls.Add(Me.txtNumHoras2)
        Me.Usuario2.Controls.Add(Me.txtPromedioHoras2)
        Me.Usuario2.Controls.Add(Me.txtNumeroFacturas2)
        Me.Usuario2.Controls.Add(Me.txtHoraFinal2)
        Me.Usuario2.Controls.Add(Me.txtHoraInicial2)
        Me.Usuario2.Controls.Add(Me.Label7)
        Me.Usuario2.Controls.Add(Me.Label8)
        Me.Usuario2.Controls.Add(Me.Label9)
        Me.Usuario2.Controls.Add(Me.Label10)
        Me.Usuario2.Controls.Add(Me.Label11)
        Me.Usuario2.Controls.Add(Me.Label12)
        Me.Usuario2.Controls.Add(Me.Label13)
        Me.Usuario2.Controls.Add(Me._gridUsuario2)
        Me.Usuario2.Location = New System.Drawing.Point(4, 22)
        Me.Usuario2.Name = "Usuario2"
        Me.Usuario2.Padding = New System.Windows.Forms.Padding(3)
        Me.Usuario2.Size = New System.Drawing.Size(959, 463)
        Me.Usuario2.TabIndex = 1
        Me.Usuario2.UseVisualStyleBackColor = True
        '
        'txtMinutosXF2
        '
        Me.txtMinutosXF2.AutoSize = True
        Me.txtMinutosXF2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinutosXF2.Location = New System.Drawing.Point(849, 32)
        Me.txtMinutosXF2.Name = "txtMinutosXF2"
        Me.txtMinutosXF2.Size = New System.Drawing.Size(10, 15)
        Me.txtMinutosXF2.TabIndex = 36
        Me.txtMinutosXF2.Text = " "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(706, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 15)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Minutos por Factura:"
        '
        'txtNumMinutos2
        '
        Me.txtNumMinutos2.AutoSize = True
        Me.txtNumMinutos2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumMinutos2.Location = New System.Drawing.Point(849, 12)
        Me.txtNumMinutos2.Name = "txtNumMinutos2"
        Me.txtNumMinutos2.Size = New System.Drawing.Size(10, 15)
        Me.txtNumMinutos2.TabIndex = 34
        Me.txtNumMinutos2.Text = " "
        '
        'txtPromMinutos2
        '
        Me.txtPromMinutos2.AutoSize = True
        Me.txtPromMinutos2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPromMinutos2.Location = New System.Drawing.Point(616, 32)
        Me.txtPromMinutos2.Name = "txtPromMinutos2"
        Me.txtPromMinutos2.Size = New System.Drawing.Size(10, 15)
        Me.txtPromMinutos2.TabIndex = 20
        Me.txtPromMinutos2.Text = " "
        '
        'txtNumHoras2
        '
        Me.txtNumHoras2.AutoSize = True
        Me.txtNumHoras2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumHoras2.Location = New System.Drawing.Point(616, 12)
        Me.txtNumHoras2.Name = "txtNumHoras2"
        Me.txtNumHoras2.Size = New System.Drawing.Size(10, 15)
        Me.txtNumHoras2.TabIndex = 19
        Me.txtNumHoras2.Text = " "
        '
        'txtPromedioHoras2
        '
        Me.txtPromedioHoras2.AutoSize = True
        Me.txtPromedioHoras2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPromedioHoras2.Location = New System.Drawing.Point(347, 32)
        Me.txtPromedioHoras2.Name = "txtPromedioHoras2"
        Me.txtPromedioHoras2.Size = New System.Drawing.Size(10, 15)
        Me.txtPromedioHoras2.TabIndex = 18
        Me.txtPromedioHoras2.Text = " "
        '
        'txtNumeroFacturas2
        '
        Me.txtNumeroFacturas2.AutoSize = True
        Me.txtNumeroFacturas2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroFacturas2.Location = New System.Drawing.Point(347, 12)
        Me.txtNumeroFacturas2.Name = "txtNumeroFacturas2"
        Me.txtNumeroFacturas2.Size = New System.Drawing.Size(10, 15)
        Me.txtNumeroFacturas2.TabIndex = 17
        Me.txtNumeroFacturas2.Text = " "
        '
        'txtHoraFinal2
        '
        Me.txtHoraFinal2.AutoSize = True
        Me.txtHoraFinal2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraFinal2.Location = New System.Drawing.Point(102, 32)
        Me.txtHoraFinal2.Name = "txtHoraFinal2"
        Me.txtHoraFinal2.Size = New System.Drawing.Size(10, 15)
        Me.txtHoraFinal2.TabIndex = 16
        Me.txtHoraFinal2.Text = " "
        '
        'txtHoraInicial2
        '
        Me.txtHoraInicial2.AutoSize = True
        Me.txtHoraInicial2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraInicial2.Location = New System.Drawing.Point(102, 12)
        Me.txtHoraInicial2.Name = "txtHoraInicial2"
        Me.txtHoraInicial2.Size = New System.Drawing.Size(10, 15)
        Me.txtHoraInicial2.TabIndex = 15
        Me.txtHoraInicial2.Text = " "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Hora Final:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 15)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Hora Inicial:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(470, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 15)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Facturas por Minuto:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(217, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 15)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Facturas por Hora:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(485, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 15)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Numero de Horas:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(708, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(137, 15)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Numero de Minutos:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(202, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(141, 15)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Numero de Facturas:"
        '
        '_gridUsuario2
        '
        Me._gridUsuario2.AllowUserToAddRows = False
        Me._gridUsuario2.AllowUserToDeleteRows = False
        Me._gridUsuario2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gridUsuario2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridUsuario2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridUsuario2.Location = New System.Drawing.Point(4, 64)
        Me._gridUsuario2.Name = "_gridUsuario2"
        Me._gridUsuario2.ReadOnly = True
        Me._gridUsuario2.Size = New System.Drawing.Size(947, 393)
        Me._gridUsuario2.TabIndex = 1
        '
        'Usuario3
        '
        Me.Usuario3.Controls.Add(Me.txtMF3)
        Me.Usuario3.Controls.Add(Me.Label4)
        Me.Usuario3.Controls.Add(Me.txtnum3)
        Me.Usuario3.Controls.Add(Me.txtfxm3)
        Me.Usuario3.Controls.Add(Me.txtnh3)
        Me.Usuario3.Controls.Add(Me.txtFxh3)
        Me.Usuario3.Controls.Add(Me.txtNF3)
        Me.Usuario3.Controls.Add(Me.txtHfinal3)
        Me.Usuario3.Controls.Add(Me.txtHinicial3)
        Me.Usuario3.Controls.Add(Me.Label19)
        Me.Usuario3.Controls.Add(Me.Label20)
        Me.Usuario3.Controls.Add(Me.Label21)
        Me.Usuario3.Controls.Add(Me.Label27)
        Me.Usuario3.Controls.Add(Me.Label28)
        Me.Usuario3.Controls.Add(Me.Label29)
        Me.Usuario3.Controls.Add(Me.Label30)
        Me.Usuario3.Controls.Add(Me._gridUsuario3)
        Me.Usuario3.Location = New System.Drawing.Point(4, 22)
        Me.Usuario3.Name = "Usuario3"
        Me.Usuario3.Padding = New System.Windows.Forms.Padding(3)
        Me.Usuario3.Size = New System.Drawing.Size(959, 463)
        Me.Usuario3.TabIndex = 3
        Me.Usuario3.Text = " "
        Me.Usuario3.UseVisualStyleBackColor = True
        '
        'txtMF3
        '
        Me.txtMF3.AutoSize = True
        Me.txtMF3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMF3.Location = New System.Drawing.Point(848, 34)
        Me.txtMF3.Name = "txtMF3"
        Me.txtMF3.Size = New System.Drawing.Size(10, 15)
        Me.txtMF3.TabIndex = 52
        Me.txtMF3.Text = " "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(706, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 15)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Minutos por Factura:"
        '
        'txtnum3
        '
        Me.txtnum3.AutoSize = True
        Me.txtnum3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnum3.Location = New System.Drawing.Point(848, 14)
        Me.txtnum3.Name = "txtnum3"
        Me.txtnum3.Size = New System.Drawing.Size(10, 15)
        Me.txtnum3.TabIndex = 50
        Me.txtnum3.Text = " "
        '
        'txtfxm3
        '
        Me.txtfxm3.AutoSize = True
        Me.txtfxm3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfxm3.Location = New System.Drawing.Point(616, 32)
        Me.txtfxm3.Name = "txtfxm3"
        Me.txtfxm3.Size = New System.Drawing.Size(10, 15)
        Me.txtfxm3.TabIndex = 49
        Me.txtfxm3.Text = " "
        '
        'txtnh3
        '
        Me.txtnh3.AutoSize = True
        Me.txtnh3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnh3.Location = New System.Drawing.Point(616, 12)
        Me.txtnh3.Name = "txtnh3"
        Me.txtnh3.Size = New System.Drawing.Size(10, 15)
        Me.txtnh3.TabIndex = 48
        Me.txtnh3.Text = " "
        '
        'txtFxh3
        '
        Me.txtFxh3.AutoSize = True
        Me.txtFxh3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFxh3.Location = New System.Drawing.Point(347, 32)
        Me.txtFxh3.Name = "txtFxh3"
        Me.txtFxh3.Size = New System.Drawing.Size(10, 15)
        Me.txtFxh3.TabIndex = 47
        Me.txtFxh3.Text = " "
        '
        'txtNF3
        '
        Me.txtNF3.AutoSize = True
        Me.txtNF3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNF3.Location = New System.Drawing.Point(347, 12)
        Me.txtNF3.Name = "txtNF3"
        Me.txtNF3.Size = New System.Drawing.Size(10, 15)
        Me.txtNF3.TabIndex = 46
        Me.txtNF3.Text = " "
        '
        'txtHfinal3
        '
        Me.txtHfinal3.AutoSize = True
        Me.txtHfinal3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHfinal3.Location = New System.Drawing.Point(102, 32)
        Me.txtHfinal3.Name = "txtHfinal3"
        Me.txtHfinal3.Size = New System.Drawing.Size(10, 15)
        Me.txtHfinal3.TabIndex = 45
        Me.txtHfinal3.Text = " "
        '
        'txtHinicial3
        '
        Me.txtHinicial3.AutoSize = True
        Me.txtHinicial3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHinicial3.Location = New System.Drawing.Point(102, 12)
        Me.txtHinicial3.Name = "txtHinicial3"
        Me.txtHinicial3.Size = New System.Drawing.Size(10, 15)
        Me.txtHinicial3.TabIndex = 44
        Me.txtHinicial3.Text = " "
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(27, 32)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 15)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "Hora Final:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(20, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(85, 15)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "Hora Inicial:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(470, 32)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(139, 15)
        Me.Label21.TabIndex = 41
        Me.Label21.Text = "Facturas por Minuto:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(217, 32)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(126, 15)
        Me.Label27.TabIndex = 40
        Me.Label27.Text = "Facturas por Hora:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(485, 12)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(124, 15)
        Me.Label28.TabIndex = 39
        Me.Label28.Text = "Numero de Horas:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(708, 12)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(137, 15)
        Me.Label29.TabIndex = 38
        Me.Label29.Text = "Numero de Minutos:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(202, 12)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(141, 15)
        Me.Label30.TabIndex = 37
        Me.Label30.Text = "Numero de Facturas:"
        '
        '_gridUsuario3
        '
        Me._gridUsuario3.AllowUserToAddRows = False
        Me._gridUsuario3.AllowUserToDeleteRows = False
        Me._gridUsuario3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gridUsuario3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._gridUsuario3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridUsuario3.Location = New System.Drawing.Point(6, 64)
        Me._gridUsuario3.Name = "_gridUsuario3"
        Me._gridUsuario3.ReadOnly = True
        Me._gridUsuario3.Size = New System.Drawing.Size(947, 393)
        Me._gridUsuario3.TabIndex = 2
        '
        'Productividad
        '
        Me.AcceptButton = Me._btnGenerar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 612)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me._gbCriteriosBusqueda)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Productividad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productividad"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._gbCriteriosBusqueda.ResumeLayout(False)
        Me._gbCriteriosBusqueda.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        Me.Usuario1.ResumeLayout(False)
        Me.Usuario1.PerformLayout()
        CType(Me._gridUsuario1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Usuario2.ResumeLayout(False)
        Me.Usuario2.PerformLayout()
        CType(Me._gridUsuario2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Usuario3.ResumeLayout(False)
        Me.Usuario3.PerformLayout()
        CType(Me._gridUsuario3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _gbCriteriosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents _cmbFechai As System.Windows.Forms.DateTimePicker
    Friend WithEvents _lblFechai As System.Windows.Forms.Label
    Friend WithEvents Panel As System.Windows.Forms.TabControl
    Friend WithEvents Usuario2 As System.Windows.Forms.TabPage
    Friend WithEvents _gridUsuario2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPromMinutos2 As System.Windows.Forms.Label
    Friend WithEvents txtNumHoras2 As System.Windows.Forms.Label
    Friend WithEvents txtPromedioHoras2 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroFacturas2 As System.Windows.Forms.Label
    Friend WithEvents txtHoraFinal2 As System.Windows.Forms.Label
    Friend WithEvents txtHoraInicial2 As System.Windows.Forms.Label
    Friend WithEvents Usuario1 As System.Windows.Forms.TabPage
    Friend WithEvents txtNumMinutos As System.Windows.Forms.Label
    Friend WithEvents txtPromedioMinutos As System.Windows.Forms.Label
    Friend WithEvents txtNumHoras As System.Windows.Forms.Label
    Friend WithEvents txtPromedioHoras As System.Windows.Forms.Label
    Friend WithEvents txtNumeroFacturas As System.Windows.Forms.Label
    Friend WithEvents txtHorafinal As System.Windows.Forms.Label
    Friend WithEvents txtHoraInicial As System.Windows.Forms.Label
    Friend WithEvents lblhoraf As System.Windows.Forms.Label
    Friend WithEvents lblhorai As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents _gridUsuario1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtNumMinutos2 As System.Windows.Forms.Label
    Friend WithEvents txtMinutosXF1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMinutosXF2 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents Usuario3 As System.Windows.Forms.TabPage
    Friend WithEvents txtMF3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtnum3 As System.Windows.Forms.Label
    Friend WithEvents txtfxm3 As System.Windows.Forms.Label
    Friend WithEvents txtnh3 As System.Windows.Forms.Label
    Friend WithEvents txtFxh3 As System.Windows.Forms.Label
    Friend WithEvents txtNF3 As System.Windows.Forms.Label
    Friend WithEvents txtHfinal3 As System.Windows.Forms.Label
    Friend WithEvents txtHinicial3 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents _gridUsuario3 As System.Windows.Forms.DataGridView
End Class
