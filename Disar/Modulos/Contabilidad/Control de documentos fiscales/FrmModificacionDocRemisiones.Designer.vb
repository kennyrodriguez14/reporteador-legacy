<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificacionDocRemisiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModificacionDocRemisiones))
        Me.DtLimiteImpresion = New System.Windows.Forms.DateTimePicker
        Me.TextAlmacen = New System.Windows.Forms.TextBox
        Me.TextEmpresa = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextCAI = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextDesde = New System.Windows.Forms.TextBox
        Me.TextSerie = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtLimiteImpresion
        '
        Me.DtLimiteImpresion.Location = New System.Drawing.Point(126, 204)
        Me.DtLimiteImpresion.Name = "DtLimiteImpresion"
        Me.DtLimiteImpresion.Size = New System.Drawing.Size(194, 20)
        Me.DtLimiteImpresion.TabIndex = 9
        '
        'TextAlmacen
        '
        Me.TextAlmacen.Enabled = False
        Me.TextAlmacen.Location = New System.Drawing.Point(57, 44)
        Me.TextAlmacen.Name = "TextAlmacen"
        Me.TextAlmacen.Size = New System.Drawing.Size(263, 20)
        Me.TextAlmacen.TabIndex = 5
        '
        'TextEmpresa
        '
        Me.TextEmpresa.Enabled = False
        Me.TextEmpresa.Location = New System.Drawing.Point(57, 19)
        Me.TextEmpresa.Name = "TextEmpresa"
        Me.TextEmpresa.Size = New System.Drawing.Size(263, 20)
        Me.TextEmpresa.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 207)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Fecha Límite Impresión:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Almacén:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Empresa:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "CAI:"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(290, 265)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.BtnGuardar.TabIndex = 13
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Rango:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(21, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Serie:"
        '
        'TextCAI
        '
        Me.TextCAI.Location = New System.Drawing.Point(57, 178)
        Me.TextCAI.Name = "TextCAI"
        Me.TextCAI.Size = New System.Drawing.Size(263, 20)
        Me.TextCAI.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DtLimiteImpresion)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextAlmacen)
        Me.GroupBox1.Controls.Add(Me.TextEmpresa)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextCAI)
        Me.GroupBox1.Controls.Add(Me.TextDesde)
        Me.GroupBox1.Controls.Add(Me.TextSerie)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(353, 247)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'TextDesde
        '
        Me.TextDesde.Location = New System.Drawing.Point(57, 152)
        Me.TextDesde.Name = "TextDesde"
        Me.TextDesde.Size = New System.Drawing.Size(263, 20)
        Me.TextDesde.TabIndex = 1
        '
        'TextSerie
        '
        Me.TextSerie.Enabled = False
        Me.TextSerie.Location = New System.Drawing.Point(57, 70)
        Me.TextSerie.Name = "TextSerie"
        Me.TextSerie.Size = New System.Drawing.Size(263, 20)
        Me.TextSerie.TabIndex = 1
        '
        'FrmModificacionDocRemisiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 297)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmModificacionDocRemisiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación de documentos fiscales [Remisiones]"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DtLimiteImpresion As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents TextEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextCAI As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextDesde As System.Windows.Forms.TextBox
    Friend WithEvents TextSerie As System.Windows.Forms.TextBox
End Class
