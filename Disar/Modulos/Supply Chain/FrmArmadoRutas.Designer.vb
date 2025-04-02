<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmArmadoRutas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArmadoRutas))
        Me.mapa = New GMap.NET.WindowsForms.GMapControl
        Me.DataClientes = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.X = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Y = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextKM = New System.Windows.Forms.NumericUpDown
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.BtnGenerar = New System.Windows.Forms.Button
        Me.TextCantidadClientes = New System.Windows.Forms.TextBox
        Me.TextY = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextX = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.Etiquetas = New System.Windows.Forms.Button
        Me.ComboEstilo = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.DataClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TextKM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mapa
        '
        Me.mapa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mapa.Bearing = 0.0!
        Me.mapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mapa.CanDragMap = True
        Me.mapa.EmptyTileColor = System.Drawing.Color.AliceBlue
        Me.mapa.GrayScaleMode = False
        Me.mapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.mapa.LevelsKeepInMemmory = 5
        Me.mapa.Location = New System.Drawing.Point(400, 13)
        Me.mapa.MarkersEnabled = True
        Me.mapa.MaxZoom = 2
        Me.mapa.MinZoom = 2
        Me.mapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.mapa.Name = "mapa"
        Me.mapa.NegativeMode = False
        Me.mapa.PolygonsEnabled = True
        Me.mapa.RetryLoadTile = 0
        Me.mapa.RoutesEnabled = True
        Me.mapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.mapa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.mapa.ShowTileGridLines = False
        Me.mapa.Size = New System.Drawing.Size(572, 543)
        Me.mapa.TabIndex = 11
        Me.mapa.Zoom = 0
        '
        'DataClientes
        '
        Me.DataClientes.AllowUserToAddRows = False
        Me.DataClientes.AllowUserToDeleteRows = False
        Me.DataClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Nombre, Me.Direccion, Me.X, Me.Y})
        Me.DataClientes.Location = New System.Drawing.Point(13, 196)
        Me.DataClientes.Name = "DataClientes"
        Me.DataClientes.ReadOnly = True
        Me.DataClientes.RowHeadersVisible = False
        Me.DataClientes.Size = New System.Drawing.Size(381, 360)
        Me.DataClientes.TabIndex = 12
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Direccion
        '
        Me.Direccion.HeaderText = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.ReadOnly = True
        '
        'X
        '
        Me.X.HeaderText = "X"
        Me.X.Name = "X"
        Me.X.ReadOnly = True
        '
        'Y
        '
        Me.Y.HeaderText = "Y"
        Me.Y.Name = "Y"
        Me.Y.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextKM)
        Me.GroupBox1.Controls.Add(Me.DateFecha)
        Me.GroupBox1.Controls.Add(Me.BtnGenerar)
        Me.GroupBox1.Controls.Add(Me.TextCantidadClientes)
        Me.GroupBox1.Controls.Add(Me.TextY)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextX)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(381, 142)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'TextKM
        '
        Me.TextKM.Location = New System.Drawing.Point(143, 15)
        Me.TextKM.Name = "TextKM"
        Me.TextKM.Size = New System.Drawing.Size(141, 20)
        Me.TextKM.TabIndex = 7
        Me.TextKM.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(143, 39)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(142, 20)
        Me.DateFecha.TabIndex = 6
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Image = Global.Disar.My.Resources.Resources.CD
        Me.BtnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnGenerar.Location = New System.Drawing.Point(294, 40)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(75, 70)
        Me.BtnGenerar.TabIndex = 5
        Me.BtnGenerar.Text = "Identificar Clientes"
        Me.BtnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'TextCantidadClientes
        '
        Me.TextCantidadClientes.Enabled = False
        Me.TextCantidadClientes.Location = New System.Drawing.Point(143, 114)
        Me.TextCantidadClientes.Name = "TextCantidadClientes"
        Me.TextCantidadClientes.Size = New System.Drawing.Size(141, 20)
        Me.TextCantidadClientes.TabIndex = 4
        '
        'TextY
        '
        Me.TextY.Enabled = False
        Me.TextY.Location = New System.Drawing.Point(143, 89)
        Me.TextY.Name = "TextY"
        Me.TextY.Size = New System.Drawing.Size(141, 20)
        Me.TextY.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Clientes encontrados:"
        '
        'TextX
        '
        Me.TextX.Enabled = False
        Me.TextX.Location = New System.Drawing.Point(143, 64)
        Me.TextX.Name = "TextX"
        Me.TextX.Size = New System.Drawing.Size(141, 20)
        Me.TextX.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(56, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ruta de Fecha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Kilómetros a la redonda:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Y:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(121, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "X:"
        '
        'DataDatos
        '
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Location = New System.Drawing.Point(400, 13)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.Size = New System.Drawing.Size(240, 150)
        Me.DataDatos.TabIndex = 14
        '
        'Etiquetas
        '
        Me.Etiquetas.Image = Global.Disar.My.Resources.Resources.Client_Account_Template_32
        Me.Etiquetas.Location = New System.Drawing.Point(356, 155)
        Me.Etiquetas.Name = "Etiquetas"
        Me.Etiquetas.Size = New System.Drawing.Size(39, 39)
        Me.Etiquetas.TabIndex = 15
        Me.Etiquetas.UseVisualStyleBackColor = True
        '
        'ComboEstilo
        '
        Me.ComboEstilo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEstilo.FormattingEnabled = True
        Me.ComboEstilo.Items.AddRange(New Object() {"Google Alternativo", "Google", "Calle", "Satélite con etiquetas", "Satélite sin etiquetas"})
        Me.ComboEstilo.Location = New System.Drawing.Point(156, 165)
        Me.ComboEstilo.Name = "ComboEstilo"
        Me.ComboEstilo.Size = New System.Drawing.Size(142, 21)
        Me.ComboEstilo.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(69, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Estilo de mapa:"
        '
        'FrmArmadoRutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 568)
        Me.Controls.Add(Me.ComboEstilo)
        Me.Controls.Add(Me.Etiquetas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataClientes)
        Me.Controls.Add(Me.mapa)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DataDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmArmadoRutas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Armado de Rutas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TextKM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents mapa As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents DataClientes As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents X As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Y As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents TextCantidadClientes As System.Windows.Forms.TextBox
    Friend WithEvents TextY As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextX As System.Windows.Forms.TextBox
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextKM As System.Windows.Forms.NumericUpDown
    Friend WithEvents Etiquetas As System.Windows.Forms.Button
    Friend WithEvents ComboEstilo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
