<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAsignarPendiente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAsignarPendiente))
        Me.ComboAsignacion = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TareaID = New System.Windows.Forms.Label
        Me.Tarea = New System.Windows.Forms.Label
        Me.Reunion = New System.Windows.Forms.Label
        Me.CodigoReunion = New System.Windows.Forms.Label
        Me.TxtNombreAsignacion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtDescripcionAsignacion = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.TxtSolicitante = New System.Windows.Forms.TextBox
        Me.TextBusca = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DataSucursales = New System.Windows.Forms.DataGridView
        Me.Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Asignar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSucursales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboAsignacion
        '
        Me.ComboAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAsignacion.FormattingEnabled = True
        Me.ComboAsignacion.Location = New System.Drawing.Point(201, 118)
        Me.ComboAsignacion.Name = "ComboAsignacion"
        Me.ComboAsignacion.Size = New System.Drawing.Size(236, 21)
        Me.ComboAsignacion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Asignar a:"
        '
        'TareaID
        '
        Me.TareaID.AutoSize = True
        Me.TareaID.Location = New System.Drawing.Point(24, 24)
        Me.TareaID.Name = "TareaID"
        Me.TareaID.Size = New System.Drawing.Size(46, 13)
        Me.TareaID.TabIndex = 2
        Me.TareaID.Text = "TareaID"
        '
        'Tarea
        '
        Me.Tarea.AutoSize = True
        Me.Tarea.Location = New System.Drawing.Point(81, 27)
        Me.Tarea.Name = "Tarea"
        Me.Tarea.Size = New System.Drawing.Size(35, 13)
        Me.Tarea.TabIndex = 3
        Me.Tarea.Text = "Tarea"
        '
        'Reunion
        '
        Me.Reunion.AutoSize = True
        Me.Reunion.Location = New System.Drawing.Point(366, 24)
        Me.Reunion.Name = "Reunion"
        Me.Reunion.Size = New System.Drawing.Size(47, 13)
        Me.Reunion.TabIndex = 3
        Me.Reunion.Text = "Reunion"
        '
        'CodigoReunion
        '
        Me.CodigoReunion.AutoSize = True
        Me.CodigoReunion.Location = New System.Drawing.Point(428, 24)
        Me.CodigoReunion.Name = "CodigoReunion"
        Me.CodigoReunion.Size = New System.Drawing.Size(47, 13)
        Me.CodigoReunion.TabIndex = 3
        Me.CodigoReunion.Text = "Reunion"
        '
        'TxtNombreAsignacion
        '
        Me.TxtNombreAsignacion.Location = New System.Drawing.Point(27, 89)
        Me.TxtNombreAsignacion.Name = "TxtNombreAsignacion"
        Me.TxtNombreAsignacion.Size = New System.Drawing.Size(410, 20)
        Me.TxtNombreAsignacion.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre de la asignación:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(467, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Descripción de la asignación:"
        '
        'TxtDescripcionAsignacion
        '
        Me.TxtDescripcionAsignacion.Location = New System.Drawing.Point(470, 89)
        Me.TxtDescripcionAsignacion.Name = "TxtDescripcionAsignacion"
        Me.TxtDescripcionAsignacion.Size = New System.Drawing.Size(348, 20)
        Me.TxtDescripcionAsignacion.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Solicitante:"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(712, 307)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(106, 40)
        Me.BtnGuardar.TabIndex = 6
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(17, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(668, 55)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(607, 118)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(211, 20)
        Me.DateTimePicker1.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(467, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Fecha prevista de entrega:"
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataDatos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Location = New System.Drawing.Point(27, 173)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.Size = New System.Drawing.Size(410, 174)
        Me.DataDatos.TabIndex = 5
        '
        'TxtSolicitante
        '
        Me.TxtSolicitante.Location = New System.Drawing.Point(201, 118)
        Me.TxtSolicitante.Name = "TxtSolicitante"
        Me.TxtSolicitante.Size = New System.Drawing.Size(213, 20)
        Me.TxtSolicitante.TabIndex = 4
        '
        'TextBusca
        '
        Me.TextBusca.Location = New System.Drawing.Point(89, 119)
        Me.TextBusca.Name = "TextBusca"
        Me.TextBusca.Size = New System.Drawing.Size(106, 20)
        Me.TextBusca.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(467, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Asignar a sucursal:"
        '
        'DataSucursales
        '
        Me.DataSucursales.AllowUserToAddRows = False
        Me.DataSucursales.AllowUserToDeleteRows = False
        Me.DataSucursales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataSucursales.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataSucursales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sucursal, Me.Asignar})
        Me.DataSucursales.Location = New System.Drawing.Point(470, 173)
        Me.DataSucursales.Name = "DataSucursales"
        Me.DataSucursales.Size = New System.Drawing.Size(348, 128)
        Me.DataSucursales.TabIndex = 10
        '
        'Sucursal
        '
        Me.Sucursal.HeaderText = "Sucursal"
        Me.Sucursal.Name = "Sucursal"
        Me.Sucursal.ReadOnly = True
        '
        'Asignar
        '
        Me.Asignar.HeaderText = "Asignar"
        Me.Asignar.Name = "Asignar"
        '
        'FormAsignarPendiente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 362)
        Me.Controls.Add(Me.DataSucursales)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBusca)
        Me.Controls.Add(Me.DataDatos)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.TxtDescripcionAsignacion)
        Me.Controls.Add(Me.TxtNombreAsignacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Tarea)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboAsignacion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CodigoReunion)
        Me.Controls.Add(Me.Reunion)
        Me.Controls.Add(Me.TareaID)
        Me.Controls.Add(Me.TxtSolicitante)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAsignarPendiente"
        Me.Text = "Asignar Pendiente"
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSucursales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboAsignacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TareaID As System.Windows.Forms.Label
    Friend WithEvents Tarea As System.Windows.Forms.Label
    Friend WithEvents Reunion As System.Windows.Forms.Label
    Friend WithEvents CodigoReunion As System.Windows.Forms.Label
    Friend WithEvents TxtNombreAsignacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcionAsignacion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents TxtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents TextBusca As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataSucursales As System.Windows.Forms.DataGridView
    Friend WithEvents Sucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Asignar As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
