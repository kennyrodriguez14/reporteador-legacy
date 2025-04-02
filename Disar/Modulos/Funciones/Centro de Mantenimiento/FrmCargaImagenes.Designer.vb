<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCargaImagenes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCargaImagenes))
        Me.Dialog = New System.Windows.Forms.OpenFileDialog
        Me.btnBuscaFotografías = New System.Windows.Forms.Button
        Me.GroupImagenes = New System.Windows.Forms.GroupBox
        Me.Vehiculo = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Contador = New System.Windows.Forms.Label
        Me.TextDecc = New System.Windows.Forms.TextBox
        Me.Btn_Siguiente = New System.Windows.Forms.Button
        Me.Btn_Anterior = New System.Windows.Forms.Button
        Me.Imagen = New System.Windows.Forms.PictureBox
        Me.Data_Imagenes = New System.Windows.Forms.DataGridView
        Me.PictureFotos = New System.Windows.Forms.PictureBox
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.GroupImagenes.SuspendLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Data_Imagenes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureFotos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dialog
        '
        Me.Dialog.Filter = "Todos los archivos de Imagen|(*.jpg;*.PNG;*.JPG;*.JPEG;*.GIF;*.png;)"
        Me.Dialog.InitialDirectory = "C:\\"
        Me.Dialog.Multiselect = True
        Me.Dialog.Title = "Seleccionar Documentos de Respaldo..."
        '
        'btnBuscaFotografías
        '
        Me.btnBuscaFotografías.Location = New System.Drawing.Point(368, 387)
        Me.btnBuscaFotografías.Name = "btnBuscaFotografías"
        Me.btnBuscaFotografías.Size = New System.Drawing.Size(158, 23)
        Me.btnBuscaFotografías.TabIndex = 21
        Me.btnBuscaFotografías.Text = "Carga nueva(s) foto(s)"
        Me.btnBuscaFotografías.UseVisualStyleBackColor = True
        '
        'GroupImagenes
        '
        Me.GroupImagenes.Controls.Add(Me.Vehiculo)
        Me.GroupImagenes.Controls.Add(Me.Label2)
        Me.GroupImagenes.Controls.Add(Me.Label1)
        Me.GroupImagenes.Controls.Add(Me.Contador)
        Me.GroupImagenes.Controls.Add(Me.TextDecc)
        Me.GroupImagenes.Controls.Add(Me.Btn_Siguiente)
        Me.GroupImagenes.Controls.Add(Me.Btn_Anterior)
        Me.GroupImagenes.Controls.Add(Me.Imagen)
        Me.GroupImagenes.Controls.Add(Me.Data_Imagenes)
        Me.GroupImagenes.Location = New System.Drawing.Point(12, 12)
        Me.GroupImagenes.Name = "GroupImagenes"
        Me.GroupImagenes.Size = New System.Drawing.Size(514, 369)
        Me.GroupImagenes.TabIndex = 22
        Me.GroupImagenes.TabStop = False
        '
        'Vehiculo
        '
        Me.Vehiculo.AutoSize = True
        Me.Vehiculo.Location = New System.Drawing.Point(53, 21)
        Me.Vehiculo.Name = "Vehiculo"
        Me.Vehiculo.Size = New System.Drawing.Size(48, 13)
        Me.Vehiculo.TabIndex = 0
        Me.Vehiculo.Text = "Vehiculo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Vehículo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.Label1.Location = New System.Drawing.Point(130, 177)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(259, 39)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Aún no se han registrado imágenes de este vehículo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Haga clic sobre el botón de " & _
            "carga de imágenes para" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "añadir las fotografías del vehículo."
        '
        'Contador
        '
        Me.Contador.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Contador.AutoSize = True
        Me.Contador.Location = New System.Drawing.Point(418, 22)
        Me.Contador.Name = "Contador"
        Me.Contador.Size = New System.Drawing.Size(50, 13)
        Me.Contador.TabIndex = 98
        Me.Contador.Text = "Contador"
        Me.Contador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextDecc
        '
        Me.TextDecc.Location = New System.Drawing.Point(103, 336)
        Me.TextDecc.Name = "TextDecc"
        Me.TextDecc.Size = New System.Drawing.Size(309, 20)
        Me.TextDecc.TabIndex = 95
        '
        'Btn_Siguiente
        '
        Me.Btn_Siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Siguiente.Image = Global.Disar.My.Resources.Resources.Next_32
        Me.Btn_Siguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Siguiente.Location = New System.Drawing.Point(418, 290)
        Me.Btn_Siguiente.Name = "Btn_Siguiente"
        Me.Btn_Siguiente.Size = New System.Drawing.Size(90, 39)
        Me.Btn_Siguiente.TabIndex = 93
        Me.Btn_Siguiente.Text = "Siguiente"
        Me.Btn_Siguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Siguiente.UseVisualStyleBackColor = True
        '
        'Btn_Anterior
        '
        Me.Btn_Anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Anterior.Image = Global.Disar.My.Resources.Resources.Previous_32
        Me.Btn_Anterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Anterior.Location = New System.Drawing.Point(6, 290)
        Me.Btn_Anterior.Name = "Btn_Anterior"
        Me.Btn_Anterior.Size = New System.Drawing.Size(86, 39)
        Me.Btn_Anterior.TabIndex = 94
        Me.Btn_Anterior.Text = "Anterior"
        Me.Btn_Anterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Anterior.UseVisualStyleBackColor = True
        '
        'Imagen
        '
        Me.Imagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Imagen.Location = New System.Drawing.Point(103, 19)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(309, 310)
        Me.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Imagen.TabIndex = 1
        Me.Imagen.TabStop = False
        '
        'Data_Imagenes
        '
        Me.Data_Imagenes.AllowUserToAddRows = False
        Me.Data_Imagenes.AllowUserToDeleteRows = False
        Me.Data_Imagenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Data_Imagenes.Location = New System.Drawing.Point(137, 120)
        Me.Data_Imagenes.Name = "Data_Imagenes"
        Me.Data_Imagenes.ReadOnly = True
        Me.Data_Imagenes.Size = New System.Drawing.Size(240, 150)
        Me.Data_Imagenes.TabIndex = 2
        '
        'PictureFotos
        '
        Me.PictureFotos.Location = New System.Drawing.Point(141, 45)
        Me.PictureFotos.Name = "PictureFotos"
        Me.PictureFotos.Size = New System.Drawing.Size(257, 251)
        Me.PictureFotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureFotos.TabIndex = 20
        Me.PictureFotos.TabStop = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(314, 310)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.BtnGuardar.TabIndex = 23
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'FrmCargaImagenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 422)
        Me.Controls.Add(Me.GroupImagenes)
        Me.Controls.Add(Me.btnBuscaFotografías)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.PictureFotos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCargaImagenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga Imágenes"
        Me.GroupImagenes.ResumeLayout(False)
        Me.GroupImagenes.PerformLayout()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Data_Imagenes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureFotos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureFotos As System.Windows.Forms.PictureBox
    Friend WithEvents btnBuscaFotografías As System.Windows.Forms.Button
    Friend WithEvents GroupImagenes As System.Windows.Forms.GroupBox
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents Vehiculo As System.Windows.Forms.Label
    Friend WithEvents Data_Imagenes As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Siguiente As System.Windows.Forms.Button
    Friend WithEvents Btn_Anterior As System.Windows.Forms.Button
    Friend WithEvents TextDecc As System.Windows.Forms.TextBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Contador As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
