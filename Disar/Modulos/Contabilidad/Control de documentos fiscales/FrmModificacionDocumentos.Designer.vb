<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificacionDocumentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModificacionDocumentos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextTipo = New System.Windows.Forms.TextBox
        Me.TextCAI = New System.Windows.Forms.TextBox
        Me.TextHasta = New System.Windows.Forms.TextBox
        Me.TextDesde = New System.Windows.Forms.TextBox
        Me.TextSerie = New System.Windows.Forms.TextBox
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextEmpresa = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextSolicitada = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextOtorgada = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.DtRecepcion = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.DtLimiteImpresion = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextAlmacen = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextTipo)
        Me.GroupBox1.Controls.Add(Me.TextCAI)
        Me.GroupBox1.Controls.Add(Me.TextHasta)
        Me.GroupBox1.Controls.Add(Me.TextDesde)
        Me.GroupBox1.Controls.Add(Me.TextSerie)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 183)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "CAI:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Hasta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Desde:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Serie:"
        '
        'TextTipo
        '
        Me.TextTipo.Location = New System.Drawing.Point(57, 54)
        Me.TextTipo.Name = "TextTipo"
        Me.TextTipo.ReadOnly = True
        Me.TextTipo.Size = New System.Drawing.Size(75, 20)
        Me.TextTipo.TabIndex = 1
        '
        'TextCAI
        '
        Me.TextCAI.Location = New System.Drawing.Point(57, 150)
        Me.TextCAI.Name = "TextCAI"
        Me.TextCAI.Size = New System.Drawing.Size(182, 20)
        Me.TextCAI.TabIndex = 3
        '
        'TextHasta
        '
        Me.TextHasta.Location = New System.Drawing.Point(57, 124)
        Me.TextHasta.Name = "TextHasta"
        Me.TextHasta.Size = New System.Drawing.Size(182, 20)
        Me.TextHasta.TabIndex = 2
        '
        'TextDesde
        '
        Me.TextDesde.Location = New System.Drawing.Point(57, 97)
        Me.TextDesde.Name = "TextDesde"
        Me.TextDesde.Size = New System.Drawing.Size(182, 20)
        Me.TextDesde.TabIndex = 1
        '
        'TextSerie
        '
        Me.TextSerie.Location = New System.Drawing.Point(57, 29)
        Me.TextSerie.Name = "TextSerie"
        Me.TextSerie.ReadOnly = True
        Me.TextSerie.Size = New System.Drawing.Size(182, 20)
        Me.TextSerie.TabIndex = 1
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(551, 200)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.BtnGuardar.TabIndex = 10
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DtLimiteImpresion)
        Me.GroupBox2.Controls.Add(Me.DtRecepcion)
        Me.GroupBox2.Controls.Add(Me.TextAlmacen)
        Me.GroupBox2.Controls.Add(Me.TextEmpresa)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TextOtorgada)
        Me.GroupBox2.Controls.Add(Me.TextSolicitada)
        Me.GroupBox2.Location = New System.Drawing.Point(273, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(353, 183)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'TextEmpresa
        '
        Me.TextEmpresa.Enabled = False
        Me.TextEmpresa.Location = New System.Drawing.Point(70, 29)
        Me.TextEmpresa.Name = "TextEmpresa"
        Me.TextEmpresa.Size = New System.Drawing.Size(263, 20)
        Me.TextEmpresa.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Empresa:"
        '
        'TextSolicitada
        '
        Me.TextSolicitada.Location = New System.Drawing.Point(70, 83)
        Me.TextSolicitada.Multiline = True
        Me.TextSolicitada.Name = "TextSolicitada"
        Me.TextSolicitada.Size = New System.Drawing.Size(77, 26)
        Me.TextSolicitada.TabIndex = 6
        Me.TextSolicitada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 26)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Solicitada:"
        '
        'TextOtorgada
        '
        Me.TextOtorgada.Location = New System.Drawing.Point(256, 83)
        Me.TextOtorgada.Multiline = True
        Me.TextOtorgada.Name = "TextOtorgada"
        Me.TextOtorgada.Size = New System.Drawing.Size(77, 26)
        Me.TextOtorgada.TabIndex = 7
        Me.TextOtorgada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(199, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 26)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Otorgada:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Fecha de Recepción:"
        '
        'DtRecepcion
        '
        Me.DtRecepcion.Location = New System.Drawing.Point(139, 128)
        Me.DtRecepcion.Name = "DtRecepcion"
        Me.DtRecepcion.Size = New System.Drawing.Size(194, 20)
        Me.DtRecepcion.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 157)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Fecha Límite Impresión:"
        '
        'DtLimiteImpresion
        '
        Me.DtLimiteImpresion.Location = New System.Drawing.Point(139, 154)
        Me.DtLimiteImpresion.Name = "DtLimiteImpresion"
        Me.DtLimiteImpresion.Size = New System.Drawing.Size(194, 20)
        Me.DtLimiteImpresion.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Almacén:"
        '
        'TextAlmacen
        '
        Me.TextAlmacen.Location = New System.Drawing.Point(70, 54)
        Me.TextAlmacen.Name = "TextAlmacen"
        Me.TextAlmacen.Size = New System.Drawing.Size(263, 20)
        Me.TextAlmacen.TabIndex = 5
        '
        'FrmModificacionDocumentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 228)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmModificacionDocumentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación de documento"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextTipo As System.Windows.Forms.TextBox
    Friend WithEvents TextCAI As System.Windows.Forms.TextBox
    Friend WithEvents TextHasta As System.Windows.Forms.TextBox
    Friend WithEvents TextDesde As System.Windows.Forms.TextBox
    Friend WithEvents TextSerie As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DtLimiteImpresion As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtRecepcion As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextOtorgada As System.Windows.Forms.TextBox
    Friend WithEvents TextSolicitada As System.Windows.Forms.TextBox
    Friend WithEvents TextAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
