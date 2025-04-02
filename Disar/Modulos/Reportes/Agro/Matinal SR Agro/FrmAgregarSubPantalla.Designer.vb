<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAgregarSubPantalla
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Vendedor = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Pantalla = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextCantidad = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextMedicion = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.ComboMes = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnAgregar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendedor:"
        '
        'Vendedor
        '
        Me.Vendedor.AutoSize = True
        Me.Vendedor.Location = New System.Drawing.Point(104, 30)
        Me.Vendedor.Name = "Vendedor"
        Me.Vendedor.Size = New System.Drawing.Size(53, 13)
        Me.Vendedor.TabIndex = 0
        Me.Vendedor.Text = "Vendedor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Pantalla:"
        '
        'Pantalla
        '
        Me.Pantalla.AutoSize = True
        Me.Pantalla.Location = New System.Drawing.Point(104, 61)
        Me.Pantalla.Name = "Pantalla"
        Me.Pantalla.Size = New System.Drawing.Size(48, 13)
        Me.Pantalla.TabIndex = 0
        Me.Pantalla.Text = "Pantalla:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Medición:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Medir en:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"L", "QQ", "TM"})
        Me.ComboBox1.Location = New System.Drawing.Point(107, 124)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(171, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Cantidad:"
        '
        'TextCantidad
        '
        Me.TextCantidad.Location = New System.Drawing.Point(107, 158)
        Me.TextCantidad.Name = "TextCantidad"
        Me.TextCantidad.Size = New System.Drawing.Size(171, 20)
        Me.TextCantidad.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextMedicion)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(538, 185)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'TextMedicion
        '
        Me.TextMedicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TextMedicion.FormattingEnabled = True
        Me.TextMedicion.Location = New System.Drawing.Point(95, 82)
        Me.TextMedicion.Name = "TextMedicion"
        Me.TextMedicion.Size = New System.Drawing.Size(171, 21)
        Me.TextMedicion.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox2.Controls.Add(Me.ComboMes)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(345, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(193, 88)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mes:"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(56, 47)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown1.TabIndex = 3
        Me.NumericUpDown1.Value = New Decimal(New Integer() {2017, 0, 0, 0})
        '
        'ComboMes
        '
        Me.ComboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboMes.FormattingEnabled = True
        Me.ComboMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.ComboMes.Location = New System.Drawing.Point(56, 21)
        Me.ComboMes.Name = "ComboMes"
        Me.ComboMes.Size = New System.Drawing.Size(121, 21)
        Me.ComboMes.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Año:"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgregar.Location = New System.Drawing.Point(556, 84)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(82, 48)
        Me.BtnAgregar.TabIndex = 5
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'FrmAgregarSubPantalla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 206)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.TextCantidad)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Pantalla)
        Me.Controls.Add(Me.Vendedor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmAgregarSubPantalla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Presupuesto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Vendedor As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Pantalla As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextCantidad As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents TextMedicion As System.Windows.Forms.ComboBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboMes As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
