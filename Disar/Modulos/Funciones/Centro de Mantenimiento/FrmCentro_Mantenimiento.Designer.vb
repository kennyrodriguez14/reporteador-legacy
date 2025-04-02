<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCentro_Mantenimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCentro_Mantenimiento))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolDetalles = New System.Windows.Forms.ToolStripButton
        Me.ToolImagenes = New System.Windows.Forms.ToolStripButton
        Me.ToolStatus = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolTareas = New System.Windows.Forms.ToolStripButton
        Me.MantenimientoNoProgram = New System.Windows.Forms.ToolStripButton
        Me.ToolCosto = New System.Windows.Forms.ToolStripButton
        Me.ToolPuntoReorden = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolDispD = New System.Windows.Forms.ToolStripButton
        Me.ToolVehiculos = New System.Windows.Forms.ToolStripButton
        Me.ToolDispM = New System.Windows.Forms.ToolStripButton
        Me.ToolTaller = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LAviso = New System.Windows.Forms.Label
        Me.BtnSolicitudes = New System.Windows.Forms.Button
        Me.BtnExportar = New System.Windows.Forms.Button
        Me.CheckTareas = New System.Windows.Forms.CheckBox
        Me.CmbCusuca = New System.Windows.Forms.ComboBox
        Me.BtnFiltra = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RadioDistribucion = New System.Windows.Forms.RadioButton
        Me.RadioMecanica = New System.Windows.Forms.RadioButton
        Me.RadioActivos = New System.Windows.Forms.RadioButton
        Me.RadioTodos = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Data_Imagenes = New System.Windows.Forms.DataGridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.BtnOrdenes = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Data_Imagenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DataDatos)
        Me.GroupBox1.Location = New System.Drawing.Point(70, 99)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(982, 536)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Vehículos"
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Location = New System.Drawing.Point(7, 20)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.RowHeadersVisible = False
        Me.DataDatos.Size = New System.Drawing.Size(969, 510)
        Me.DataDatos.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolDetalles, Me.ToolImagenes, Me.ToolStatus, Me.ToolStripSeparator2, Me.ToolTareas, Me.MantenimientoNoProgram, Me.ToolCosto, Me.ToolPuntoReorden, Me.ToolStripSeparator3, Me.ToolDispD, Me.ToolVehiculos, Me.ToolDispM, Me.ToolTaller, Me.ToolStripSeparator4, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(74, 647)
        Me.ToolStrip1.TabIndex = 1
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(72, 6)
        '
        'ToolDetalles
        '
        Me.ToolDetalles.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolDetalles.Image = Global.Disar.My.Resources.Resources.Application_View_Detail_32
        Me.ToolDetalles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolDetalles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDetalles.Name = "ToolDetalles"
        Me.ToolDetalles.Size = New System.Drawing.Size(72, 48)
        Me.ToolDetalles.Text = "Ver Detalles"
        Me.ToolDetalles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolDetalles.ToolTipText = "Ver detalles del vehículo seleccionado"
        '
        'ToolImagenes
        '
        Me.ToolImagenes.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolImagenes.Image = Global.Disar.My.Resources.Resources.Picture_Add_32
        Me.ToolImagenes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolImagenes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolImagenes.Name = "ToolImagenes"
        Me.ToolImagenes.Size = New System.Drawing.Size(72, 48)
        Me.ToolImagenes.Text = "Imágenes"
        Me.ToolImagenes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolImagenes.ToolTipText = "Modifica las fotografías del vehículo"
        '
        'ToolStatus
        '
        Me.ToolStatus.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStatus.Image = Global.Disar.My.Resources.Resources.Document_Mark_As_Final_32
        Me.ToolStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStatus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStatus.Name = "ToolStatus"
        Me.ToolStatus.Size = New System.Drawing.Size(72, 48)
        Me.ToolStatus.Text = "Disponibilidad"
        Me.ToolStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStatus.ToolTipText = "Cambiar disponibilidad del vehículo seleccionado"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(72, 6)
        '
        'ToolTareas
        '
        Me.ToolTareas.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolTareas.Image = Global.Disar.My.Resources.Resources.Calendar_32
        Me.ToolTareas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolTareas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolTareas.Name = "ToolTareas"
        Me.ToolTareas.Size = New System.Drawing.Size(72, 48)
        Me.ToolTareas.Text = "Programar"
        Me.ToolTareas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTareas.ToolTipText = "Ver y programar eventros para vehículo seleccionado"
        '
        'MantenimientoNoProgram
        '
        Me.MantenimientoNoProgram.Font = New System.Drawing.Font("Segoe UI", 6.5!)
        Me.MantenimientoNoProgram.Image = Global.Disar.My.Resources.Resources.mountain_bike_crankset_032x032
        Me.MantenimientoNoProgram.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MantenimientoNoProgram.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MantenimientoNoProgram.Name = "MantenimientoNoProgram"
        Me.MantenimientoNoProgram.Size = New System.Drawing.Size(72, 48)
        Me.MantenimientoNoProgram.Text = "No Programado"
        Me.MantenimientoNoProgram.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.MantenimientoNoProgram.ToolTipText = "Ver / Agregar mantenimientos no programados"
        '
        'ToolCosto
        '
        Me.ToolCosto.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolCosto.Image = Global.Disar.My.Resources.Resources.Money_Transportation_32
        Me.ToolCosto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolCosto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCosto.Name = "ToolCosto"
        Me.ToolCosto.Size = New System.Drawing.Size(72, 48)
        Me.ToolCosto.Text = "Costo Total"
        Me.ToolCosto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolCosto.ToolTipText = "Reporte de Costo Total por Vehículo"
        '
        'ToolPuntoReorden
        '
        Me.ToolPuntoReorden.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolPuntoReorden.Image = Global.Disar.My.Resources.Resources.Cajas_Lvsmart
        Me.ToolPuntoReorden.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolPuntoReorden.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPuntoReorden.Name = "ToolPuntoReorden"
        Me.ToolPuntoReorden.Size = New System.Drawing.Size(72, 48)
        Me.ToolPuntoReorden.Text = "Punto Reorden"
        Me.ToolPuntoReorden.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolPuntoReorden.ToolTipText = "Punto de Reorden de repuestos"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(72, 6)
        '
        'ToolDispD
        '
        Me.ToolDispD.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolDispD.Image = Global.Disar.My.Resources.Resources.Car_utilization_32
        Me.ToolDispD.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolDispD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDispD.Name = "ToolDispD"
        Me.ToolDispD.Size = New System.Drawing.Size(72, 48)
        Me.ToolDispD.Text = "Disponibilidad D"
        Me.ToolDispD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolDispD.ToolTipText = "Reporte de Disponibilidad de Distribución para el vehículo seleccionado"
        '
        'ToolVehiculos
        '
        Me.ToolVehiculos.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolVehiculos.Image = Global.Disar.My.Resources.Resources._4x4_Pickup_32
        Me.ToolVehiculos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolVehiculos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolVehiculos.Name = "ToolVehiculos"
        Me.ToolVehiculos.Size = New System.Drawing.Size(72, 48)
        Me.ToolVehiculos.Text = "Uso Vehicular"
        Me.ToolVehiculos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolDispM
        '
        Me.ToolDispM.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolDispM.Image = Global.Disar.My.Resources.Resources.Acar_32
        Me.ToolDispM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolDispM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDispM.Name = "ToolDispM"
        Me.ToolDispM.Size = New System.Drawing.Size(72, 48)
        Me.ToolDispM.Text = "Disponibilidad M"
        Me.ToolDispM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolDispM.ToolTipText = "Reporte de Disponibilidad Mecánica para el vehículo seleccionado"
        '
        'ToolTaller
        '
        Me.ToolTaller.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolTaller.Image = Global.Disar.My.Resources.Resources.System_Preferences_32
        Me.ToolTaller.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolTaller.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolTaller.Name = "ToolTaller"
        Me.ToolTaller.Size = New System.Drawing.Size(72, 48)
        Me.ToolTaller.Text = "Tiempo en Taller"
        Me.ToolTaller.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTaller.ToolTipText = "Registrar tiempo que el vehículo se encontró fuera de servicio por estar en mante" & _
            "nimiento en taller"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(72, 6)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 4)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.LAviso)
        Me.GroupBox2.Controls.Add(Me.BtnSolicitudes)
        Me.GroupBox2.Controls.Add(Me.BtnExportar)
        Me.GroupBox2.Controls.Add(Me.CheckTareas)
        Me.GroupBox2.Controls.Add(Me.CmbCusuca)
        Me.GroupBox2.Controls.Add(Me.BtnFiltra)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(70, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(857, 87)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'LAviso
        '
        Me.LAviso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LAviso.ForeColor = System.Drawing.Color.DarkRed
        Me.LAviso.Location = New System.Drawing.Point(596, 10)
        Me.LAviso.Name = "LAviso"
        Me.LAviso.Size = New System.Drawing.Size(255, 13)
        Me.LAviso.TabIndex = 7
        Me.LAviso.Text = "Usted tiene *** solicitudes vehiculares por completar."
        Me.LAviso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnSolicitudes
        '
        Me.BtnSolicitudes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSolicitudes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSolicitudes.Image = Global.Disar.My.Resources.Resources.Archivos
        Me.BtnSolicitudes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSolicitudes.Location = New System.Drawing.Point(748, 26)
        Me.BtnSolicitudes.Name = "BtnSolicitudes"
        Me.BtnSolicitudes.Size = New System.Drawing.Size(102, 54)
        Me.BtnSolicitudes.TabIndex = 6
        Me.BtnSolicitudes.Text = "Otras Solicitudes"
        Me.BtnSolicitudes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSolicitudes.UseVisualStyleBackColor = True
        '
        'BtnExportar
        '
        Me.BtnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnExportar.Location = New System.Drawing.Point(642, 26)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(101, 54)
        Me.BtnExportar.TabIndex = 5
        Me.BtnExportar.Text = "Exportar Información"
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'CheckTareas
        '
        Me.CheckTareas.AutoSize = True
        Me.CheckTareas.Checked = True
        Me.CheckTareas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckTareas.Location = New System.Drawing.Point(411, 22)
        Me.CheckTareas.Name = "CheckTareas"
        Me.CheckTareas.Size = New System.Drawing.Size(148, 17)
        Me.CheckTareas.TabIndex = 4
        Me.CheckTareas.Text = "Mostrar tareas pendientes"
        Me.CheckTareas.UseVisualStyleBackColor = True
        '
        'CmbCusuca
        '
        Me.CmbCusuca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCusuca.FormattingEnabled = True
        Me.CmbCusuca.Location = New System.Drawing.Point(131, 19)
        Me.CmbCusuca.Name = "CmbCusuca"
        Me.CmbCusuca.Size = New System.Drawing.Size(273, 21)
        Me.CmbCusuca.TabIndex = 1
        '
        'BtnFiltra
        '
        Me.BtnFiltra.Image = Global.Disar.My.Resources.Resources.Filter_List_32
        Me.BtnFiltra.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnFiltra.Location = New System.Drawing.Point(566, 26)
        Me.BtnFiltra.Name = "BtnFiltra"
        Me.BtnFiltra.Size = New System.Drawing.Size(70, 54)
        Me.BtnFiltra.TabIndex = 3
        Me.BtnFiltra.Text = "Cargar"
        Me.BtnFiltra.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnFiltra.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioDistribucion)
        Me.GroupBox3.Controls.Add(Me.RadioMecanica)
        Me.GroupBox3.Controls.Add(Me.RadioActivos)
        Me.GroupBox3.Controls.Add(Me.RadioTodos)
        Me.GroupBox3.Location = New System.Drawing.Point(131, 38)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(428, 40)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'RadioDistribucion
        '
        Me.RadioDistribucion.AutoSize = True
        Me.RadioDistribucion.Location = New System.Drawing.Point(275, 14)
        Me.RadioDistribucion.Name = "RadioDistribucion"
        Me.RadioDistribucion.Size = New System.Drawing.Size(148, 17)
        Me.RadioDistribucion.TabIndex = 0
        Me.RadioDistribucion.TabStop = True
        Me.RadioDistribucion.Text = "Disponibilidad Distribución"
        Me.RadioDistribucion.UseVisualStyleBackColor = True
        '
        'RadioMecanica
        '
        Me.RadioMecanica.AutoSize = True
        Me.RadioMecanica.Location = New System.Drawing.Point(133, 14)
        Me.RadioMecanica.Name = "RadioMecanica"
        Me.RadioMecanica.Size = New System.Drawing.Size(140, 17)
        Me.RadioMecanica.TabIndex = 0
        Me.RadioMecanica.TabStop = True
        Me.RadioMecanica.Text = "Disponibilidad Mecánica"
        Me.RadioMecanica.UseVisualStyleBackColor = True
        '
        'RadioActivos
        '
        Me.RadioActivos.AutoSize = True
        Me.RadioActivos.Location = New System.Drawing.Point(67, 14)
        Me.RadioActivos.Name = "RadioActivos"
        Me.RadioActivos.Size = New System.Drawing.Size(60, 17)
        Me.RadioActivos.TabIndex = 0
        Me.RadioActivos.TabStop = True
        Me.RadioActivos.Text = "Activos"
        Me.RadioActivos.UseVisualStyleBackColor = True
        '
        'RadioTodos
        '
        Me.RadioTodos.AutoSize = True
        Me.RadioTodos.Location = New System.Drawing.Point(6, 14)
        Me.RadioTodos.Name = "RadioTodos"
        Me.RadioTodos.Size = New System.Drawing.Size(55, 17)
        Me.RadioTodos.TabIndex = 0
        Me.RadioTodos.TabStop = True
        Me.RadioTodos.Text = "Todos"
        Me.RadioTodos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Filtrar Disponibilidad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filtrar Vehículo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(70, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "     "
        '
        'Data_Imagenes
        '
        Me.Data_Imagenes.AllowUserToAddRows = False
        Me.Data_Imagenes.AllowUserToDeleteRows = False
        Me.Data_Imagenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Data_Imagenes.Location = New System.Drawing.Point(296, 44)
        Me.Data_Imagenes.Name = "Data_Imagenes"
        Me.Data_Imagenes.ReadOnly = True
        Me.Data_Imagenes.Size = New System.Drawing.Size(24, 20)
        Me.Data_Imagenes.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.BtnOrdenes)
        Me.GroupBox4.Location = New System.Drawing.Point(933, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(119, 87)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'BtnOrdenes
        '
        Me.BtnOrdenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOrdenes.Image = Global.Disar.My.Resources.Resources.CarRepairBlue2_32
        Me.BtnOrdenes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnOrdenes.Location = New System.Drawing.Point(6, 26)
        Me.BtnOrdenes.Name = "BtnOrdenes"
        Me.BtnOrdenes.Size = New System.Drawing.Size(107, 54)
        Me.BtnOrdenes.TabIndex = 0
        Me.BtnOrdenes.Text = "Órdenes de Trabajo"
        Me.BtnOrdenes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOrdenes.UseVisualStyleBackColor = True
        '
        'FrmCentro_Mantenimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1064, 647)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Data_Imagenes)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCentro_Mantenimiento"
        Me.Text = "Centro de Mantenimiento"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Data_Imagenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolDetalles As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolImagenes As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTareas As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbCusuca As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnFiltra As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadioDistribucion As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMecanica As System.Windows.Forms.RadioButton
    Friend WithEvents RadioTodos As System.Windows.Forms.RadioButton
    Friend WithEvents ToolCosto As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolPuntoReorden As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStatus As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RadioActivos As System.Windows.Forms.RadioButton
    Friend WithEvents CheckTareas As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents ToolDispM As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolDispD As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTaller As System.Windows.Forms.ToolStripButton
    Friend WithEvents Data_Imagenes As System.Windows.Forms.DataGridView
    Friend WithEvents MantenimientoNoProgram As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolVehiculos As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSolicitudes As System.Windows.Forms.Button
    Friend WithEvents LAviso As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOrdenes As System.Windows.Forms.Button
End Class
