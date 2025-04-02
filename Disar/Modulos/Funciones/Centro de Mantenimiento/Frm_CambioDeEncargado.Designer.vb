<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CambioDeEncargado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CambioDeEncargado))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextChasis = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextSerie = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextEncargado = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LVehiculo = New System.Windows.Forms.Label
        Me.Guardar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextChasis)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextSerie)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextEncargado)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 105)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'TextChasis
        '
        Me.TextChasis.Location = New System.Drawing.Point(76, 73)
        Me.TextChasis.Name = "TextChasis"
        Me.TextChasis.Size = New System.Drawing.Size(241, 20)
        Me.TextChasis.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Serie Chasis:"
        '
        'TextSerie
        '
        Me.TextSerie.Location = New System.Drawing.Point(76, 47)
        Me.TextSerie.Name = "TextSerie"
        Me.TextSerie.Size = New System.Drawing.Size(241, 20)
        Me.TextSerie.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Serie Motor:"
        '
        'TextEncargado
        '
        Me.TextEncargado.Location = New System.Drawing.Point(76, 21)
        Me.TextEncargado.Name = "TextEncargado"
        Me.TextEncargado.Size = New System.Drawing.Size(241, 20)
        Me.TextEncargado.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Encargado:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Vehículo "
        '
        'LVehiculo
        '
        Me.LVehiculo.AutoSize = True
        Me.LVehiculo.Location = New System.Drawing.Point(68, 13)
        Me.LVehiculo.Name = "LVehiculo"
        Me.LVehiculo.Size = New System.Drawing.Size(15, 13)
        Me.LVehiculo.TabIndex = 2
        Me.LVehiculo.Text = "♦"
        '
        'Guardar
        '
        Me.Guardar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Guardar.Location = New System.Drawing.Point(343, 96)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(85, 38)
        Me.Guardar.TabIndex = 3
        Me.Guardar.Text = "Guardar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cambios"
        Me.Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'Frm_CambioDeEncargado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 144)
        Me.Controls.Add(Me.Guardar)
        Me.Controls.Add(Me.LVehiculo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_CambioDeEncargado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio De Datos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextEncargado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextChasis As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LVehiculo As System.Windows.Forms.Label
    Friend WithEvents Guardar As System.Windows.Forms.Button
End Class
