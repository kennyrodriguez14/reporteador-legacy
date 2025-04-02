<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOrdenesDeTrabajo
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOrdenesDeTrabajo))
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnVrs = New System.Windows.Forms.Button
        Me.Hasta = New System.Windows.Forms.DateTimePicker
        Me.Desde = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnVer = New System.Windows.Forms.Button
        Me.BtnNueva = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboOrden = New System.Windows.Forms.ComboBox
        Me.CmbVehiculo = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ACT = New System.Windows.Forms.Button
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Location = New System.Drawing.Point(12, 98)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.RowHeadersVisible = False
        Me.DataDatos.Size = New System.Drawing.Size(1048, 382)
        Me.DataDatos.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnVrs)
        Me.GroupBox1.Controls.Add(Me.Hasta)
        Me.GroupBox1.Controls.Add(Me.Desde)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.BtnVer)
        Me.GroupBox1.Controls.Add(Me.BtnNueva)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(942, 89)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'BtnVrs
        '
        Me.BtnVrs.Location = New System.Drawing.Point(133, 23)
        Me.BtnVrs.Name = "BtnVrs"
        Me.BtnVrs.Size = New System.Drawing.Size(151, 48)
        Me.BtnVrs.TabIndex = 6
        Me.BtnVrs.Text = "Reporte Mantenimiento Preventivo vrs Correctivo"
        Me.BtnVrs.UseVisualStyleBackColor = True
        '
        'Hasta
        '
        Me.Hasta.Location = New System.Drawing.Point(331, 53)
        Me.Hasta.Name = "Hasta"
        Me.Hasta.Size = New System.Drawing.Size(200, 20)
        Me.Hasta.TabIndex = 5
        '
        'Desde
        '
        Me.Desde.Location = New System.Drawing.Point(331, 27)
        Me.Desde.Name = "Desde"
        Me.Desde.Size = New System.Drawing.Size(200, 20)
        Me.Desde.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(290, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Hasta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(290, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Desde:"
        '
        'BtnVer
        '
        Me.BtnVer.Location = New System.Drawing.Point(16, 48)
        Me.BtnVer.Name = "BtnVer"
        Me.BtnVer.Size = New System.Drawing.Size(111, 23)
        Me.BtnVer.TabIndex = 0
        Me.BtnVer.Text = "Ver"
        Me.ToolTip1.SetToolTip(Me.BtnVer, "Ver los detalles de la orden seleccionada")
        Me.BtnVer.UseVisualStyleBackColor = True
        '
        'BtnNueva
        '
        Me.BtnNueva.Location = New System.Drawing.Point(16, 23)
        Me.BtnNueva.Name = "BtnNueva"
        Me.BtnNueva.Size = New System.Drawing.Size(111, 23)
        Me.BtnNueva.TabIndex = 0
        Me.BtnNueva.Text = "Nueva"
        Me.ToolTip1.SetToolTip(Me.BtnNueva, "Crea nueva órden de trabajo")
        Me.BtnNueva.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.ComboOrden)
        Me.GroupBox2.Controls.Add(Me.CmbVehiculo)
        Me.GroupBox2.Location = New System.Drawing.Point(537, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(400, 74)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filtrar Vehículo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Filtrar por orden"
        '
        'ComboOrden
        '
        Me.ComboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboOrden.FormattingEnabled = True
        Me.ComboOrden.Location = New System.Drawing.Point(116, 41)
        Me.ComboOrden.Name = "ComboOrden"
        Me.ComboOrden.Size = New System.Drawing.Size(273, 21)
        Me.ComboOrden.TabIndex = 3
        '
        'CmbVehiculo
        '
        Me.CmbVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVehiculo.FormattingEnabled = True
        Me.CmbVehiculo.Location = New System.Drawing.Point(116, 16)
        Me.CmbVehiculo.Name = "CmbVehiculo"
        Me.CmbVehiculo.Size = New System.Drawing.Size(273, 21)
        Me.CmbVehiculo.TabIndex = 3
        '
        'ACT
        '
        Me.ACT.Location = New System.Drawing.Point(968, 30)
        Me.ACT.Name = "ACT"
        Me.ACT.Size = New System.Drawing.Size(92, 44)
        Me.ACT.TabIndex = 3
        Me.ACT.Text = "Actualizar"
        Me.ACT.UseVisualStyleBackColor = True
        '
        'FormOrdenesDeTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1072, 492)
        Me.Controls.Add(Me.ACT)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormOrdenesDeTrabajo"
        Me.Text = "Órdenes de Trabajo"
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnVer As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtnNueva As System.Windows.Forms.Button
    Friend WithEvents CmbVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboOrden As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnVrs As System.Windows.Forms.Button
    Friend WithEvents ACT As System.Windows.Forms.Button
End Class
