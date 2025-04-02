<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RegistroDeAccidente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RegistroDeAccidente))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnRegistrar = New System.Windows.Forms.Button
        Me.TextColaborador = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.DateHora = New System.Windows.Forms.DateTimePicker
        Me.TextSucursal = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextDescripcion = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TextSucursal)
        Me.GroupBox1.Controls.Add(Me.DateHora)
        Me.GroupBox1.Controls.Add(Me.DateFecha)
        Me.GroupBox1.Controls.Add(Me.TextDescripcion)
        Me.GroupBox1.Controls.Add(Me.TextColaborador)
        Me.GroupBox1.Controls.Add(Me.BtnRegistrar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(437, 182)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Sucursal:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Hora del accidente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha del accidente:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Colaborador:"
        '
        'BtnRegistrar
        '
        Me.BtnRegistrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRegistrar.Location = New System.Drawing.Point(356, 153)
        Me.BtnRegistrar.Name = "BtnRegistrar"
        Me.BtnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.BtnRegistrar.TabIndex = 6
        Me.BtnRegistrar.Text = "Registrar"
        Me.BtnRegistrar.UseVisualStyleBackColor = True
        '
        'TextColaborador
        '
        Me.TextColaborador.Location = New System.Drawing.Point(155, 22)
        Me.TextColaborador.Name = "TextColaborador"
        Me.TextColaborador.Size = New System.Drawing.Size(200, 20)
        Me.TextColaborador.TabIndex = 1
        '
        'DateFecha
        '
        Me.DateFecha.Location = New System.Drawing.Point(155, 48)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(200, 20)
        Me.DateFecha.TabIndex = 2
        '
        'DateHora
        '
        Me.DateHora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateHora.Location = New System.Drawing.Point(155, 74)
        Me.DateHora.Name = "DateHora"
        Me.DateHora.ShowUpDown = True
        Me.DateHora.Size = New System.Drawing.Size(200, 20)
        Me.DateHora.TabIndex = 3
        '
        'TextSucursal
        '
        Me.TextSucursal.Enabled = False
        Me.TextSucursal.Location = New System.Drawing.Point(155, 126)
        Me.TextSucursal.Name = "TextSucursal"
        Me.TextSucursal.Size = New System.Drawing.Size(145, 20)
        Me.TextSucursal.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Descripción:"
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(155, 100)
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(200, 20)
        Me.TextDescripcion.TabIndex = 4
        '
        'Frm_RegistroDeAccidente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 207)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_RegistroDeAccidente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Accidente Laboral"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnRegistrar As System.Windows.Forms.Button
    Friend WithEvents TextSucursal As System.Windows.Forms.TextBox
    Friend WithEvents DateHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextColaborador As System.Windows.Forms.TextBox
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
