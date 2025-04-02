<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCambioEstadoVehiculo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCambioEstadoVehiculo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.TextObs = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.CheckDistrib = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CheckMecanica = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CheckActivo = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Nombre = New System.Windows.Forms.Label
        Me.ID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnGuardar)
        Me.GroupBox1.Controls.Add(Me.TextObs)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Nombre)
        Me.GroupBox1.Controls.Add(Me.ID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(369, 306)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(265, 269)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.BtnGuardar.TabIndex = 5
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'TextObs
        '
        Me.TextObs.Location = New System.Drawing.Point(135, 216)
        Me.TextObs.Multiline = True
        Me.TextObs.Name = "TextObs"
        Me.TextObs.Size = New System.Drawing.Size(205, 37)
        Me.TextObs.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(49, 227)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Observación:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckDistrib)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(24, 149)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(316, 43)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'CheckDistrib
        '
        Me.CheckDistrib.AutoSize = True
        Me.CheckDistrib.Location = New System.Drawing.Point(216, 16)
        Me.CheckDistrib.Name = "CheckDistrib"
        Me.CheckDistrib.Size = New System.Drawing.Size(75, 17)
        Me.CheckDistrib.TabIndex = 1
        Me.CheckDistrib.Text = "Disponible"
        Me.CheckDistrib.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Disponibilidad De Distribución"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckMecanica)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 103)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(316, 43)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'CheckMecanica
        '
        Me.CheckMecanica.AutoSize = True
        Me.CheckMecanica.Location = New System.Drawing.Point(216, 16)
        Me.CheckMecanica.Name = "CheckMecanica"
        Me.CheckMecanica.Size = New System.Drawing.Size(75, 17)
        Me.CheckMecanica.TabIndex = 1
        Me.CheckMecanica.Text = "Disponible"
        Me.CheckMecanica.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Disponibilidad Mecánica:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckActivo)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(316, 43)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'CheckActivo
        '
        Me.CheckActivo.AutoSize = True
        Me.CheckActivo.Location = New System.Drawing.Point(216, 15)
        Me.CheckActivo.Name = "CheckActivo"
        Me.CheckActivo.Size = New System.Drawing.Size(56, 17)
        Me.CheckActivo.TabIndex = 1
        Me.CheckActivo.Text = "Activo"
        Me.CheckActivo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Estado activo:"
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(164, 36)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(16, 13)
        Me.Nombre.TabIndex = 1
        Me.Nombre.Text = "♦"
        '
        'ID
        '
        Me.ID.AutoSize = True
        Me.ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ID.Location = New System.Drawing.Point(120, 36)
        Me.ID.Name = "ID"
        Me.ID.Size = New System.Drawing.Size(16, 13)
        Me.ID.TabIndex = 1
        Me.ID.Text = "♦"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vehículo"
        '
        'FrmCambioEstadoVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 331)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCambioEstadoVehiculo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de Estado de Vehículo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Nombre As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextObs As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckDistrib As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckMecanica As System.Windows.Forms.CheckBox
    Friend WithEvents CheckActivo As System.Windows.Forms.CheckBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
End Class
