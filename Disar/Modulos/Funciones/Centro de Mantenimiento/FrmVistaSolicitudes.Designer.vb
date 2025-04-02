<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVistaSolicitudes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVistaSolicitudes))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me.BtnDescargar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BtnCompletar = New System.Windows.Forms.Button
        Me.TextFechaConfirmacion = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextFechaRevision = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextFecha = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextVehiculo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextEstado = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextDescripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextSolicitante = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Data_Imagenes = New System.Windows.Forms.DataGridView
        Me.Num = New System.Windows.Forms.Label
        Me.GuardaImagen = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox1.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Data_Imagenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Imagen)
        Me.GroupBox1.Controls.Add(Me.BtnDescargar)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Data_Imagenes)
        Me.GroupBox1.Controls.Add(Me.Num)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(759, 500)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Imagen
        '
        Me.Imagen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Imagen.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Imagen.Location = New System.Drawing.Point(167, 11)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(424, 315)
        Me.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Imagen.TabIndex = 3
        Me.Imagen.TabStop = False
        '
        'BtnDescargar
        '
        Me.BtnDescargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDescargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnDescargar.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDescargar.Image = Global.Disar.My.Resources.Resources.File_Blue
        Me.BtnDescargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDescargar.Location = New System.Drawing.Point(591, 289)
        Me.BtnDescargar.Name = "BtnDescargar"
        Me.BtnDescargar.Size = New System.Drawing.Size(154, 37)
        Me.BtnDescargar.TabIndex = 86
        Me.BtnDescargar.Text = "Descargar Imagen"
        Me.BtnDescargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDescargar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtnCompletar)
        Me.GroupBox2.Controls.Add(Me.TextFechaConfirmacion)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TextFechaRevision)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TextFecha)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TextVehiculo)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextEstado)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TextDescripcion)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TextSolicitante)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 322)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(743, 172)
        Me.GroupBox2.TabIndex = 87
        Me.GroupBox2.TabStop = False
        '
        'BtnCompletar
        '
        Me.BtnCompletar.Location = New System.Drawing.Point(589, 128)
        Me.BtnCompletar.Name = "BtnCompletar"
        Me.BtnCompletar.Size = New System.Drawing.Size(148, 37)
        Me.BtnCompletar.TabIndex = 1
        Me.BtnCompletar.Text = "Marcar como completa"
        Me.BtnCompletar.UseVisualStyleBackColor = True
        '
        'TextFechaConfirmacion
        '
        Me.TextFechaConfirmacion.Location = New System.Drawing.Point(132, 137)
        Me.TextFechaConfirmacion.Name = "TextFechaConfirmacion"
        Me.TextFechaConfirmacion.ReadOnly = True
        Me.TextFechaConfirmacion.Size = New System.Drawing.Size(148, 20)
        Me.TextFechaConfirmacion.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Fecha de Confirmación:"
        '
        'TextFechaRevision
        '
        Me.TextFechaRevision.Location = New System.Drawing.Point(132, 111)
        Me.TextFechaRevision.Name = "TextFechaRevision"
        Me.TextFechaRevision.ReadOnly = True
        Me.TextFechaRevision.Size = New System.Drawing.Size(148, 20)
        Me.TextFechaRevision.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha de Revisión:"
        '
        'TextFecha
        '
        Me.TextFecha.Location = New System.Drawing.Point(589, 78)
        Me.TextFecha.Name = "TextFecha"
        Me.TextFecha.ReadOnly = True
        Me.TextFecha.Size = New System.Drawing.Size(148, 20)
        Me.TextFecha.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(485, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Fecha de Solicitud:"
        '
        'TextVehiculo
        '
        Me.TextVehiculo.Location = New System.Drawing.Point(589, 19)
        Me.TextVehiculo.Name = "TextVehiculo"
        Me.TextVehiculo.ReadOnly = True
        Me.TextVehiculo.Size = New System.Drawing.Size(148, 20)
        Me.TextVehiculo.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(530, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Vehículo:"
        '
        'TextEstado
        '
        Me.TextEstado.Location = New System.Drawing.Point(589, 49)
        Me.TextEstado.Name = "TextEstado"
        Me.TextEstado.ReadOnly = True
        Me.TextEstado.Size = New System.Drawing.Size(148, 20)
        Me.TextEstado.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(540, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Estado:"
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(132, 45)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.ReadOnly = True
        Me.TextDescripcion.Size = New System.Drawing.Size(347, 55)
        Me.TextDescripcion.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descripción:"
        '
        'TextSolicitante
        '
        Me.TextSolicitante.Location = New System.Drawing.Point(132, 19)
        Me.TextSolicitante.Name = "TextSolicitante"
        Me.TextSolicitante.ReadOnly = True
        Me.TextSolicitante.Size = New System.Drawing.Size(347, 20)
        Me.TextSolicitante.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Solicitud De"
        '
        'Data_Imagenes
        '
        Me.Data_Imagenes.AllowUserToAddRows = False
        Me.Data_Imagenes.AllowUserToDeleteRows = False
        Me.Data_Imagenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Data_Imagenes.Location = New System.Drawing.Point(379, 132)
        Me.Data_Imagenes.Name = "Data_Imagenes"
        Me.Data_Imagenes.ReadOnly = True
        Me.Data_Imagenes.Size = New System.Drawing.Size(71, 69)
        Me.Data_Imagenes.TabIndex = 4
        '
        'Num
        '
        Me.Num.AutoSize = True
        Me.Num.Location = New System.Drawing.Point(7, 11)
        Me.Num.Name = "Num"
        Me.Num.Size = New System.Drawing.Size(11, 13)
        Me.Num.TabIndex = 0
        Me.Num.Text = "º"
        '
        'FrmVistaSolicitudes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 524)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmVistaSolicitudes"
        Me.Text = "Vista de Solicitud"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Data_Imagenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Num As System.Windows.Forms.Label
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents Data_Imagenes As System.Windows.Forms.DataGridView
    Friend WithEvents BtnDescargar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCompletar As System.Windows.Forms.Button
    Friend WithEvents GuardaImagen As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TextFechaConfirmacion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextFechaRevision As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextVehiculo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
