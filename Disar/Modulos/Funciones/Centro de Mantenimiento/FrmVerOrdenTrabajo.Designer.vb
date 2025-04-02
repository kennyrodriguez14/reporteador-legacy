<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVerOrdenTrabajo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVerOrdenTrabajo))
        Me.Datos2 = New System.Windows.Forms.GroupBox
        Me.TextKilometraje = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.TextAsignado = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextVehiculo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.FechaIngreso = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.FechaSalida = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.HoraSalida = New System.Windows.Forms.TextBox
        Me.HoraIngreso = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.Orden = New System.Windows.Forms.Label
        Me.BtnExportar = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.NumeroDeOrden = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Datos2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Datos2
        '
        Me.Datos2.Controls.Add(Me.TextKilometraje)
        Me.Datos2.Controls.Add(Me.Label5)
        Me.Datos2.Controls.Add(Me.TextVehiculo)
        Me.Datos2.Controls.Add(Me.Label4)
        Me.Datos2.Controls.Add(Me.Label7)
        Me.Datos2.Controls.Add(Me.TextAsignado)
        Me.Datos2.Location = New System.Drawing.Point(12, 30)
        Me.Datos2.Name = "Datos2"
        Me.Datos2.Size = New System.Drawing.Size(311, 86)
        Me.Datos2.TabIndex = 5
        Me.Datos2.TabStop = False
        '
        'TextKilometraje
        '
        Me.TextKilometraje.Enabled = False
        Me.TextKilometraje.Location = New System.Drawing.Point(72, 35)
        Me.TextKilometraje.Name = "TextKilometraje"
        Me.TextKilometraje.Size = New System.Drawing.Size(221, 20)
        Me.TextKilometraje.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Kilometraje:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Vehículo:"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextObservaciones.Enabled = False
        Me.TextObservaciones.Location = New System.Drawing.Point(12, 450)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(923, 60)
        Me.TextObservaciones.TabIndex = 6
        '
        'TextAsignado
        '
        Me.TextAsignado.Enabled = False
        Me.TextAsignado.Location = New System.Drawing.Point(72, 58)
        Me.TextAsignado.Name = "TextAsignado"
        Me.TextAsignado.Size = New System.Drawing.Size(221, 20)
        Me.TextAsignado.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 434)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Observaciones:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Encargado:"
        '
        'TextVehiculo
        '
        Me.TextVehiculo.Enabled = False
        Me.TextVehiculo.Location = New System.Drawing.Point(72, 13)
        Me.TextVehiculo.Name = "TextVehiculo"
        Me.TextVehiculo.Size = New System.Drawing.Size(221, 20)
        Me.TextVehiculo.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Ingreso:"
        '
        'FechaIngreso
        '
        Me.FechaIngreso.Enabled = False
        Me.FechaIngreso.Location = New System.Drawing.Point(95, 19)
        Me.FechaIngreso.Name = "FechaIngreso"
        Me.FechaIngreso.Size = New System.Drawing.Size(221, 20)
        Me.FechaIngreso.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha Salida:"
        '
        'FechaSalida
        '
        Me.FechaSalida.Enabled = False
        Me.FechaSalida.Location = New System.Drawing.Point(95, 42)
        Me.FechaSalida.Name = "FechaSalida"
        Me.FechaSalida.Size = New System.Drawing.Size(221, 20)
        Me.FechaSalida.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnExportar)
        Me.GroupBox1.Controls.Add(Me.HoraIngreso)
        Me.GroupBox1.Controls.Add(Me.FechaIngreso)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.HoraSalida)
        Me.GroupBox1.Controls.Add(Me.FechaSalida)
        Me.GroupBox1.Location = New System.Drawing.Point(329, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(606, 77)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'HoraSalida
        '
        Me.HoraSalida.Enabled = False
        Me.HoraSalida.Location = New System.Drawing.Point(361, 42)
        Me.HoraSalida.Name = "HoraSalida"
        Me.HoraSalida.Size = New System.Drawing.Size(162, 20)
        Me.HoraSalida.TabIndex = 7
        '
        'HoraIngreso
        '
        Me.HoraIngreso.Enabled = False
        Me.HoraIngreso.Location = New System.Drawing.Point(361, 19)
        Me.HoraIngreso.Name = "HoraIngreso"
        Me.HoraIngreso.Size = New System.Drawing.Size(162, 20)
        Me.HoraIngreso.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(322, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Hora:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(322, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Hora:"
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Location = New System.Drawing.Point(12, 124)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.Size = New System.Drawing.Size(923, 307)
        Me.DataDatos.TabIndex = 9
        '
        'Orden
        '
        Me.Orden.AutoSize = True
        Me.Orden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Orden.Location = New System.Drawing.Point(21, 14)
        Me.Orden.Name = "Orden"
        Me.Orden.Size = New System.Drawing.Size(50, 16)
        Me.Orden.TabIndex = 0
        Me.Orden.Text = "Orden"
        '
        'BtnExportar
        '
        Me.BtnExportar.Image = Global.Disar.My.Resources.Resources.Application_View_Detail_32
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnExportar.Location = New System.Drawing.Point(533, 13)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(63, 58)
        Me.BtnExportar.TabIndex = 10
        Me.BtnExportar.Text = "Exportar"
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(804, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Orden Nº:"
        '
        'NumeroDeOrden
        '
        Me.NumeroDeOrden.AutoSize = True
        Me.NumeroDeOrden.Location = New System.Drawing.Point(863, 17)
        Me.NumeroDeOrden.Name = "NumeroDeOrden"
        Me.NumeroDeOrden.Size = New System.Drawing.Size(15, 13)
        Me.NumeroDeOrden.TabIndex = 0
        Me.NumeroDeOrden.Text = "♦"
        '
        'FrmVerOrdenTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 522)
        Me.Controls.Add(Me.DataDatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Datos2)
        Me.Controls.Add(Me.NumeroDeOrden)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Orden)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.Label8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmVerOrdenTrabajo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ver Orden de Trabajo"
        Me.Datos2.ResumeLayout(False)
        Me.Datos2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Datos2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextKilometraje As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextVehiculo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextAsignado As System.Windows.Forms.TextBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FechaIngreso As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FechaSalida As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents HoraIngreso As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents HoraSalida As System.Windows.Forms.TextBox
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents Orden As System.Windows.Forms.Label
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents NumeroDeOrden As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
