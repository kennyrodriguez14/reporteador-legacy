<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEstadoVehiculo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEstadoVehiculo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.NMotor = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.NChasis = New System.Windows.Forms.TextBox
        Me.BtnHistorial = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TextDetalle = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TextDisponibilidadD = New System.Windows.Forms.TextBox
        Me.TextDisponibilidadM = New System.Windows.Forms.TextBox
        Me.TextDepto = New System.Windows.Forms.TextBox
        Me.TextCubicaje = New System.Windows.Forms.TextBox
        Me.TextCapacidadMaxima = New System.Windows.Forms.TextBox
        Me.TextMonto = New System.Windows.Forms.TextBox
        Me.TextCapacidadLibras = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextSucursal = New System.Windows.Forms.TextBox
        Me.TextEstado = New System.Windows.Forms.TextBox
        Me.TextModelo = New System.Windows.Forms.TextBox
        Me.TextMarca = New System.Windows.Forms.TextBox
        Me.TextPlaca = New System.Windows.Forms.TextBox
        Me.TextDescripción = New System.Windows.Forms.TextBox
        Me.TextID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me.Data_Imagenes = New System.Windows.Forms.DataGridView
        Me.Desc = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.NEncargado = New System.Windows.Forms.TextBox
        Me.BtnCambios = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Data_Imagenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnCambios)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.BtnHistorial)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 261)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 373)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.NMotor)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.NChasis)
        Me.GroupBox5.Location = New System.Drawing.Point(24, 228)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(341, 70)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        '
        'NMotor
        '
        Me.NMotor.Enabled = False
        Me.NMotor.Location = New System.Drawing.Point(129, 41)
        Me.NMotor.Name = "NMotor"
        Me.NMotor.Size = New System.Drawing.Size(206, 20)
        Me.NMotor.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 45)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Serie Motor:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Serie Chasis:"
        '
        'NChasis
        '
        Me.NChasis.Enabled = False
        Me.NChasis.Location = New System.Drawing.Point(129, 15)
        Me.NChasis.Name = "NChasis"
        Me.NChasis.Size = New System.Drawing.Size(206, 20)
        Me.NChasis.TabIndex = 1
        '
        'BtnHistorial
        '
        Me.BtnHistorial.Location = New System.Drawing.Point(568, 335)
        Me.BtnHistorial.Name = "BtnHistorial"
        Me.BtnHistorial.Size = New System.Drawing.Size(170, 33)
        Me.BtnHistorial.TabIndex = 4
        Me.BtnHistorial.Text = "Ver Historial de Eventos"
        Me.BtnHistorial.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.NEncargado)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.TextDetalle)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Location = New System.Drawing.Point(397, 228)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(341, 70)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'TextDetalle
        '
        Me.TextDetalle.Enabled = False
        Me.TextDetalle.Location = New System.Drawing.Point(129, 15)
        Me.TextDetalle.Name = "TextDetalle"
        Me.TextDetalle.Size = New System.Drawing.Size(206, 20)
        Me.TextDetalle.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Detalle:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextDisponibilidadD)
        Me.GroupBox3.Controls.Add(Me.TextDisponibilidadM)
        Me.GroupBox3.Controls.Add(Me.TextDepto)
        Me.GroupBox3.Controls.Add(Me.TextCubicaje)
        Me.GroupBox3.Controls.Add(Me.TextCapacidadMaxima)
        Me.GroupBox3.Controls.Add(Me.TextMonto)
        Me.GroupBox3.Controls.Add(Me.TextCapacidadLibras)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Location = New System.Drawing.Point(397, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(341, 202)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'TextDisponibilidadD
        '
        Me.TextDisponibilidadD.Enabled = False
        Me.TextDisponibilidadD.Location = New System.Drawing.Point(165, 175)
        Me.TextDisponibilidadD.Name = "TextDisponibilidadD"
        Me.TextDisponibilidadD.Size = New System.Drawing.Size(170, 20)
        Me.TextDisponibilidadD.TabIndex = 1
        '
        'TextDisponibilidadM
        '
        Me.TextDisponibilidadM.Enabled = False
        Me.TextDisponibilidadM.Location = New System.Drawing.Point(165, 147)
        Me.TextDisponibilidadM.Name = "TextDisponibilidadM"
        Me.TextDisponibilidadM.Size = New System.Drawing.Size(170, 20)
        Me.TextDisponibilidadM.TabIndex = 1
        '
        'TextDepto
        '
        Me.TextDepto.Enabled = False
        Me.TextDepto.Location = New System.Drawing.Point(129, 121)
        Me.TextDepto.Name = "TextDepto"
        Me.TextDepto.Size = New System.Drawing.Size(206, 20)
        Me.TextDepto.TabIndex = 1
        '
        'TextCubicaje
        '
        Me.TextCubicaje.Enabled = False
        Me.TextCubicaje.Location = New System.Drawing.Point(129, 94)
        Me.TextCubicaje.Name = "TextCubicaje"
        Me.TextCubicaje.Size = New System.Drawing.Size(206, 20)
        Me.TextCubicaje.TabIndex = 1
        '
        'TextCapacidadMaxima
        '
        Me.TextCapacidadMaxima.Enabled = False
        Me.TextCapacidadMaxima.Location = New System.Drawing.Point(129, 67)
        Me.TextCapacidadMaxima.Name = "TextCapacidadMaxima"
        Me.TextCapacidadMaxima.Size = New System.Drawing.Size(206, 20)
        Me.TextCapacidadMaxima.TabIndex = 1
        '
        'TextMonto
        '
        Me.TextMonto.Enabled = False
        Me.TextMonto.Location = New System.Drawing.Point(129, 40)
        Me.TextMonto.Name = "TextMonto"
        Me.TextMonto.Size = New System.Drawing.Size(206, 20)
        Me.TextMonto.TabIndex = 1
        '
        'TextCapacidadLibras
        '
        Me.TextCapacidadLibras.Enabled = False
        Me.TextCapacidadLibras.Location = New System.Drawing.Point(129, 13)
        Me.TextCapacidadLibras.Name = "TextCapacidadLibras"
        Me.TextCapacidadLibras.Size = New System.Drawing.Size(206, 20)
        Me.TextCapacidadLibras.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Capacidad (lbs):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 151)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Disponibilidad Mecánica:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Disponibilidad de Distribución:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Monto:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 124)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Depto CC:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Capacidad Maxima:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 97)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Cubicaje:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextSucursal)
        Me.GroupBox2.Controls.Add(Me.TextEstado)
        Me.GroupBox2.Controls.Add(Me.TextModelo)
        Me.GroupBox2.Controls.Add(Me.TextMarca)
        Me.GroupBox2.Controls.Add(Me.TextPlaca)
        Me.GroupBox2.Controls.Add(Me.TextDescripción)
        Me.GroupBox2.Controls.Add(Me.TextID)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(341, 202)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'TextSucursal
        '
        Me.TextSucursal.Enabled = False
        Me.TextSucursal.Location = New System.Drawing.Point(129, 175)
        Me.TextSucursal.Name = "TextSucursal"
        Me.TextSucursal.Size = New System.Drawing.Size(206, 20)
        Me.TextSucursal.TabIndex = 1
        '
        'TextEstado
        '
        Me.TextEstado.Enabled = False
        Me.TextEstado.Location = New System.Drawing.Point(129, 148)
        Me.TextEstado.Name = "TextEstado"
        Me.TextEstado.Size = New System.Drawing.Size(206, 20)
        Me.TextEstado.TabIndex = 1
        '
        'TextModelo
        '
        Me.TextModelo.Enabled = False
        Me.TextModelo.Location = New System.Drawing.Point(129, 121)
        Me.TextModelo.Name = "TextModelo"
        Me.TextModelo.Size = New System.Drawing.Size(206, 20)
        Me.TextModelo.TabIndex = 1
        '
        'TextMarca
        '
        Me.TextMarca.Enabled = False
        Me.TextMarca.Location = New System.Drawing.Point(129, 94)
        Me.TextMarca.Name = "TextMarca"
        Me.TextMarca.Size = New System.Drawing.Size(206, 20)
        Me.TextMarca.TabIndex = 1
        '
        'TextPlaca
        '
        Me.TextPlaca.Enabled = False
        Me.TextPlaca.Location = New System.Drawing.Point(129, 67)
        Me.TextPlaca.Name = "TextPlaca"
        Me.TextPlaca.Size = New System.Drawing.Size(206, 20)
        Me.TextPlaca.TabIndex = 1
        '
        'TextDescripción
        '
        Me.TextDescripción.Enabled = False
        Me.TextDescripción.Location = New System.Drawing.Point(129, 40)
        Me.TextDescripción.Name = "TextDescripción"
        Me.TextDescripción.Size = New System.Drawing.Size(206, 20)
        Me.TextDescripción.TabIndex = 1
        '
        'TextID
        '
        Me.TextID.Enabled = False
        Me.TextID.Location = New System.Drawing.Point(129, 13)
        Me.TextID.Name = "TextID"
        Me.TextID.Size = New System.Drawing.Size(206, 20)
        Me.TextID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID de Vehículo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descripción:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nº de Placa:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Marca:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Modelo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Estado del Vehículo:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Asignado a sucursal:"
        '
        'Imagen
        '
        Me.Imagen.Location = New System.Drawing.Point(224, 13)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(337, 223)
        Me.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Imagen.TabIndex = 1
        Me.Imagen.TabStop = False
        '
        'Data_Imagenes
        '
        Me.Data_Imagenes.AllowUserToAddRows = False
        Me.Data_Imagenes.AllowUserToDeleteRows = False
        Me.Data_Imagenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Data_Imagenes.Location = New System.Drawing.Point(661, 296)
        Me.Data_Imagenes.Name = "Data_Imagenes"
        Me.Data_Imagenes.ReadOnly = True
        Me.Data_Imagenes.Size = New System.Drawing.Size(71, 69)
        Me.Data_Imagenes.TabIndex = 2
        '
        'Desc
        '
        Me.Desc.AutoSize = True
        Me.Desc.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Desc.Location = New System.Drawing.Point(266, 219)
        Me.Desc.Name = "Desc"
        Me.Desc.Size = New System.Drawing.Size(249, 13)
        Me.Desc.TabIndex = 3
        Me.Desc.Text = "Aún no se han cargado imágenes de este vehículo"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(123, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Encargado de Vehículo:"
        '
        'NEncargado
        '
        Me.NEncargado.Enabled = False
        Me.NEncargado.Location = New System.Drawing.Point(129, 41)
        Me.NEncargado.Name = "NEncargado"
        Me.NEncargado.Size = New System.Drawing.Size(206, 20)
        Me.NEncargado.TabIndex = 1
        '
        'BtnCambios
        '
        Me.BtnCambios.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCambios.Location = New System.Drawing.Point(568, 304)
        Me.BtnCambios.Name = "BtnCambios"
        Me.BtnCambios.Size = New System.Drawing.Size(170, 23)
        Me.BtnCambios.TabIndex = 6
        Me.BtnCambios.Text = "Cambiar Encargado / Chasis / Motor"
        Me.BtnCambios.UseVisualStyleBackColor = True
        '
        'FrmEstadoVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 646)
        Me.Controls.Add(Me.Desc)
        Me.Controls.Add(Me.Imagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Data_Imagenes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmEstadoVehiculo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalles de vehículo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Data_Imagenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextDescripción As System.Windows.Forms.TextBox
    Friend WithEvents TextID As System.Windows.Forms.TextBox
    Friend WithEvents TextPlaca As System.Windows.Forms.TextBox
    Friend WithEvents TextDepto As System.Windows.Forms.TextBox
    Friend WithEvents TextCubicaje As System.Windows.Forms.TextBox
    Friend WithEvents TextCapacidadMaxima As System.Windows.Forms.TextBox
    Friend WithEvents TextMonto As System.Windows.Forms.TextBox
    Friend WithEvents TextCapacidadLibras As System.Windows.Forms.TextBox
    Friend WithEvents TextSucursal As System.Windows.Forms.TextBox
    Friend WithEvents TextEstado As System.Windows.Forms.TextBox
    Friend WithEvents TextModelo As System.Windows.Forms.TextBox
    Friend WithEvents TextMarca As System.Windows.Forms.TextBox
    Friend WithEvents TextDetalle As System.Windows.Forms.TextBox
    Friend WithEvents TextDisponibilidadD As System.Windows.Forms.TextBox
    Friend WithEvents TextDisponibilidadM As System.Windows.Forms.TextBox
    Friend WithEvents BtnHistorial As System.Windows.Forms.Button
    Friend WithEvents Data_Imagenes As System.Windows.Forms.DataGridView
    Friend WithEvents Desc As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents NMotor As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents NChasis As System.Windows.Forms.TextBox
    Friend WithEvents NEncargado As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents BtnCambios As System.Windows.Forms.Button
End Class
