<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RutaLogica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RutaLogica))
        Me.DataDatosFiltrados = New System.Windows.Forms.DataGridView
        Me.DataOrden = New System.Windows.Forms.DataGridView
        Me.ComboVendedores = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DFecha = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnBajar = New System.Windows.Forms.Button
        Me.BtnSubir = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ComboOrden = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnMapa = New System.Windows.Forms.Button
        Me.BtnExportar = New System.Windows.Forms.Button
        Me.BtnRuta = New System.Windows.Forms.Button
        Me.ComboEMPRESA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.DataDatosFiltrados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataDatosFiltrados
        '
        Me.DataDatosFiltrados.AllowUserToAddRows = False
        Me.DataDatosFiltrados.AllowUserToDeleteRows = False
        Me.DataDatosFiltrados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataDatosFiltrados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDatosFiltrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatosFiltrados.Location = New System.Drawing.Point(160, 192)
        Me.DataDatosFiltrados.Name = "DataDatosFiltrados"
        Me.DataDatosFiltrados.ReadOnly = True
        Me.DataDatosFiltrados.Size = New System.Drawing.Size(59, 163)
        Me.DataDatosFiltrados.TabIndex = 0
        '
        'DataOrden
        '
        Me.DataOrden.AllowDrop = True
        Me.DataOrden.AllowUserToAddRows = False
        Me.DataOrden.AllowUserToDeleteRows = False
        Me.DataOrden.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataOrden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataOrden.Location = New System.Drawing.Point(82, 66)
        Me.DataOrden.Name = "DataOrden"
        Me.DataOrden.ReadOnly = True
        Me.DataOrden.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataOrden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataOrden.Size = New System.Drawing.Size(1094, 452)
        Me.DataOrden.TabIndex = 0
        '
        'ComboVendedores
        '
        Me.ComboVendedores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboVendedores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboVendedores.DropDownHeight = 120
        Me.ComboVendedores.FormattingEnabled = True
        Me.ComboVendedores.IntegralHeight = False
        Me.ComboVendedores.Location = New System.Drawing.Point(71, 30)
        Me.ComboVendedores.Name = "ComboVendedores"
        Me.ComboVendedores.Size = New System.Drawing.Size(215, 21)
        Me.ComboVendedores.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Entregador:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(293, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha:"
        '
        'DFecha
        '
        Me.DFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DFecha.Location = New System.Drawing.Point(340, 33)
        Me.DFecha.Name = "DFecha"
        Me.DFecha.Size = New System.Drawing.Size(102, 20)
        Me.DFecha.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnBajar)
        Me.GroupBox1.Controls.Add(Me.BtnSubir)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(67, 459)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'BtnBajar
        '
        Me.BtnBajar.Image = Global.Disar.My.Resources.Resources.Arrow_Circle_Down_32
        Me.BtnBajar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnBajar.Location = New System.Drawing.Point(6, 76)
        Me.BtnBajar.Name = "BtnBajar"
        Me.BtnBajar.Size = New System.Drawing.Size(54, 50)
        Me.BtnBajar.TabIndex = 0
        Me.BtnBajar.Text = "Bajar"
        Me.BtnBajar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBajar.UseVisualStyleBackColor = True
        '
        'BtnSubir
        '
        Me.BtnSubir.Image = Global.Disar.My.Resources.Resources.Arrow_Circle_Up_32
        Me.BtnSubir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSubir.Location = New System.Drawing.Point(7, 17)
        Me.BtnSubir.Name = "BtnSubir"
        Me.BtnSubir.Size = New System.Drawing.Size(54, 50)
        Me.BtnSubir.TabIndex = 0
        Me.BtnSubir.Text = "Subir"
        Me.BtnSubir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSubir.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ComboEMPRESA)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ComboOrden)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(803, 45)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'ComboOrden
        '
        Me.ComboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboOrden.FormattingEnabled = True
        Me.ComboOrden.Items.AddRange(New Object() {"Más cercano primero", "Más lejano primero"})
        Me.ComboOrden.Location = New System.Drawing.Point(631, 17)
        Me.ComboOrden.Name = "ComboOrden"
        Me.ComboOrden.Size = New System.Drawing.Size(166, 21)
        Me.ComboOrden.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(586, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Orden:"
        '
        'BtnMapa
        '
        Me.BtnMapa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMapa.Image = Global.Disar.My.Resources.Resources.Map_32x32
        Me.BtnMapa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMapa.Location = New System.Drawing.Point(935, 22)
        Me.BtnMapa.Name = "BtnMapa"
        Me.BtnMapa.Size = New System.Drawing.Size(114, 38)
        Me.BtnMapa.TabIndex = 9
        Me.BtnMapa.Text = "Generar Mapa"
        Me.BtnMapa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnMapa.UseVisualStyleBackColor = True
        '
        'BtnExportar
        '
        Me.BtnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.Location = New System.Drawing.Point(1054, 22)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(122, 38)
        Me.BtnExportar.TabIndex = 8
        Me.BtnExportar.Text = "Exportar Información"
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'BtnRuta
        '
        Me.BtnRuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRuta.Image = Global.Disar.My.Resources.Resources.Routing_Turn_Arround_Right_32
        Me.BtnRuta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRuta.Location = New System.Drawing.Point(819, 22)
        Me.BtnRuta.Name = "BtnRuta"
        Me.BtnRuta.Size = New System.Drawing.Size(110, 38)
        Me.BtnRuta.TabIndex = 4
        Me.BtnRuta.Text = "Ordenar Ruta"
        Me.BtnRuta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRuta.UseVisualStyleBackColor = True
        '
        'ComboEMPRESA
        '
        Me.ComboEMPRESA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEMPRESA.FormattingEnabled = True
        Me.ComboEMPRESA.Items.AddRange(New Object() {"Más cercano primero", "Más lejano primero"})
        Me.ComboEMPRESA.Location = New System.Drawing.Point(439, 16)
        Me.ComboEMPRESA.Name = "ComboEMPRESA"
        Me.ComboEMPRESA.Size = New System.Drawing.Size(141, 21)
        Me.ComboEMPRESA.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(369, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Orden:"
        '
        'Frm_RutaLogica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 530)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnMapa)
        Me.Controls.Add(Me.BtnExportar)
        Me.Controls.Add(Me.BtnRuta)
        Me.Controls.Add(Me.DFecha)
        Me.Controls.Add(Me.ComboVendedores)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataOrden)
        Me.Controls.Add(Me.DataDatosFiltrados)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_RutaLogica"
        Me.Text = "Ruta Lógica de Entrega"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataDatosFiltrados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataOrden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataDatosFiltrados As System.Windows.Forms.DataGridView
    Friend WithEvents DataOrden As System.Windows.Forms.DataGridView
    Friend WithEvents ComboVendedores As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnRuta As System.Windows.Forms.Button
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents BtnMapa As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboOrden As System.Windows.Forms.ComboBox
    Friend WithEvents BtnBajar As System.Windows.Forms.Button
    Friend WithEvents BtnSubir As System.Windows.Forms.Button
    Friend WithEvents ComboEMPRESA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
