<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNuevaSolicitudPapeleria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNuevaSolicitudPapeleria))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextSolicitante = New System.Windows.Forms.TextBox
        Me.TextDepartamento = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextFecha = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboAlmacen = New System.Windows.Forms.ComboBox
        Me.Agregar = New System.Windows.Forms.Button
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.Quitar = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Solicitante:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Departamento:"
        '
        'TextSolicitante
        '
        Me.TextSolicitante.Enabled = False
        Me.TextSolicitante.Location = New System.Drawing.Point(106, 30)
        Me.TextSolicitante.Name = "TextSolicitante"
        Me.TextSolicitante.Size = New System.Drawing.Size(241, 20)
        Me.TextSolicitante.TabIndex = 2
        '
        'TextDepartamento
        '
        Me.TextDepartamento.Enabled = False
        Me.TextDepartamento.Location = New System.Drawing.Point(106, 56)
        Me.TextDepartamento.Name = "TextDepartamento"
        Me.TextDepartamento.Size = New System.Drawing.Size(241, 20)
        Me.TextDepartamento.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboAlmacen)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextFecha)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(667, 77)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'TextFecha
        '
        Me.TextFecha.Enabled = False
        Me.TextFecha.Location = New System.Drawing.Point(497, 17)
        Me.TextFecha.Name = "TextFecha"
        Me.TextFecha.Size = New System.Drawing.Size(155, 20)
        Me.TextFecha.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(393, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha de Solicitud:"
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.DESCRIPCION, Me.CANTIDAD})
        Me.DataDatos.Location = New System.Drawing.Point(20, 139)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.Size = New System.Drawing.Size(645, 220)
        Me.DataDatos.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(393, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Almacén:"
        '
        'ComboAlmacen
        '
        Me.ComboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAlmacen.FormattingEnabled = True
        Me.ComboAlmacen.Items.AddRange(New Object() {"SPS", "SRC", "SAB", "TGU", "SR AGRO SRC"})
        Me.ComboAlmacen.Location = New System.Drawing.Point(497, 43)
        Me.ComboAlmacen.Name = "ComboAlmacen"
        Me.ComboAlmacen.Size = New System.Drawing.Size(155, 21)
        Me.ComboAlmacen.TabIndex = 7
        '
        'Agregar
        '
        Me.Agregar.Location = New System.Drawing.Point(19, 113)
        Me.Agregar.Name = "Agregar"
        Me.Agregar.Size = New System.Drawing.Size(75, 23)
        Me.Agregar.TabIndex = 6
        Me.Agregar.Text = "Agregar"
        Me.Agregar.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(583, 367)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(82, 29)
        Me.BtnGuardar.TabIndex = 7
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'Quitar
        '
        Me.Quitar.Location = New System.Drawing.Point(100, 113)
        Me.Quitar.Name = "Quitar"
        Me.Quitar.Size = New System.Drawing.Size(75, 23)
        Me.Quitar.TabIndex = 8
        Me.Quitar.Text = "Quitar"
        Me.Quitar.UseVisualStyleBackColor = True
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.HeaderText = "DESCRIPCION"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        '
        'CANTIDAD
        '
        Me.CANTIDAD.HeaderText = "CANTIDAD"
        Me.CANTIDAD.Name = "CANTIDAD"
        '
        'FormNuevaSolicitudPapeleria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 403)
        Me.Controls.Add(Me.Quitar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.DataDatos)
        Me.Controls.Add(Me.TextDepartamento)
        Me.Controls.Add(Me.TextSolicitante)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Agregar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormNuevaSolicitudPapeleria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva Solicitud de Papelería"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents TextDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents Agregar As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Quitar As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
