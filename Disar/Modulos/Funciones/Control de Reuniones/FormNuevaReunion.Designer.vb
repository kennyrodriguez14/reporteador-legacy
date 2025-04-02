<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNuevaReunion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNuevaReunion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataParticipantes = New System.Windows.Forms.DataGridView
        Me.Nick = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnQuitar = New System.Windows.Forms.Button
        Me.BtnAgregar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DataTemas = New System.Windows.Forms.DataGridView
        Me.Tema = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ComboDia = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextResponsable = New System.Windows.Forms.TextBox
        Me.TextExtra = New System.Windows.Forms.TextBox
        Me.TextPeriodo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextNombre = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataParticipantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataTemas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataParticipantes)
        Me.GroupBox1.Controls.Add(Me.BtnQuitar)
        Me.GroupBox1.Controls.Add(Me.BtnAgregar)
        Me.GroupBox1.Location = New System.Drawing.Point(528, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 214)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Participantes"
        '
        'DataParticipantes
        '
        Me.DataParticipantes.AllowUserToAddRows = False
        Me.DataParticipantes.AllowUserToDeleteRows = False
        Me.DataParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataParticipantes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataParticipantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nick, Me.Nombre})
        Me.DataParticipantes.Location = New System.Drawing.Point(8, 20)
        Me.DataParticipantes.Name = "DataParticipantes"
        Me.DataParticipantes.ReadOnly = True
        Me.DataParticipantes.RowHeadersVisible = False
        Me.DataParticipantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataParticipantes.Size = New System.Drawing.Size(337, 188)
        Me.DataParticipantes.TabIndex = 0
        '
        'Nick
        '
        Me.Nick.HeaderText = "Nick"
        Me.Nick.Name = "Nick"
        Me.Nick.ReadOnly = True
        Me.Nick.Visible = False
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'BtnQuitar
        '
        Me.BtnQuitar.Location = New System.Drawing.Point(353, 115)
        Me.BtnQuitar.Name = "BtnQuitar"
        Me.BtnQuitar.Size = New System.Drawing.Size(30, 23)
        Me.BtnQuitar.TabIndex = 3
        Me.BtnQuitar.Text = "-"
        Me.BtnQuitar.UseVisualStyleBackColor = True
        '
        'BtnAgregar
        '
        Me.BtnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor
        Me.BtnAgregar.Location = New System.Drawing.Point(353, 73)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(30, 23)
        Me.BtnAgregar.TabIndex = 3
        Me.BtnAgregar.Text = "+"
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataTemas)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 261)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 213)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Temas a tratar"
        '
        'DataTemas
        '
        Me.DataTemas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataTemas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataTemas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataTemas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tema})
        Me.DataTemas.Location = New System.Drawing.Point(6, 19)
        Me.DataTemas.Name = "DataTemas"
        Me.DataTemas.Size = New System.Drawing.Size(484, 188)
        Me.DataTemas.TabIndex = 0
        '
        'Tema
        '
        Me.Tema.HeaderText = "Tema"
        Me.Tema.Name = "Tema"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ComboDia)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.TextResponsable)
        Me.GroupBox3.Controls.Add(Me.TextExtra)
        Me.GroupBox3.Controls.Add(Me.TextPeriodo)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TextNombre)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(496, 242)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'ComboDia
        '
        Me.ComboDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDia.FormattingEnabled = True
        Me.ComboDia.Items.AddRange(New Object() {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"})
        Me.ComboDia.Location = New System.Drawing.Point(113, 163)
        Me.ComboDia.Name = "ComboDia"
        Me.ComboDia.Size = New System.Drawing.Size(298, 21)
        Me.ComboDia.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(417, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "HH:mm:ss"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(374, 49)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.ShowUpDown = True
        Me.DateTimePicker2.Size = New System.Drawing.Size(93, 20)
        Me.DateTimePicker2.TabIndex = 2
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "HH:mm:ss"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(113, 49)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(93, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Responsable:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(264, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Hora de Finalización:"
        '
        'TextResponsable
        '
        Me.TextResponsable.Enabled = False
        Me.TextResponsable.Location = New System.Drawing.Point(113, 90)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.Size = New System.Drawing.Size(298, 20)
        Me.TextResponsable.TabIndex = 3
        '
        'TextExtra
        '
        Me.TextExtra.Location = New System.Drawing.Point(113, 190)
        Me.TextExtra.Name = "TextExtra"
        Me.TextExtra.Size = New System.Drawing.Size(298, 20)
        Me.TextExtra.TabIndex = 6
        '
        'TextPeriodo
        '
        Me.TextPeriodo.Location = New System.Drawing.Point(113, 137)
        Me.TextPeriodo.Name = "TextPeriodo"
        Me.TextPeriodo.Size = New System.Drawing.Size(298, 20)
        Me.TextPeriodo.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Día:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 193)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Info Extra:"
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(113, 23)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(354, 20)
        Me.TextNombre.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Período:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Hora de Inicio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Nombre:"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor
        Me.BtnGuardar.Image = Global.Disar.My.Resources.Resources.Guardar
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(830, 418)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(88, 50)
        Me.BtnGuardar.TabIndex = 0
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'FormNuevaReunion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 486)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormNuevaReunion"
        Me.Text = "Nueva planificación de reunión"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataParticipantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataTemas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataParticipantes As System.Windows.Forms.DataGridView
    Friend WithEvents BtnQuitar As System.Windows.Forms.Button
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataTemas As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboDia As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextResponsable As System.Windows.Forms.TextBox
    Friend WithEvents TextExtra As System.Windows.Forms.TextBox
    Friend WithEvents TextPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Nick As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tema As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
