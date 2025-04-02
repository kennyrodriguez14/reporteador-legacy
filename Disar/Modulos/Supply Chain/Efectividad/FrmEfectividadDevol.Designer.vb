<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEfectividadDevol
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEfectividadDevol))
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.BtnGenerar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboSucursal = New System.Windows.Forms.ComboBox
        Me.ComboFiltro = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboEd = New System.Windows.Forms.ComboBox
        Me.tbAgro = New System.Windows.Forms.TabPage
        Me.DataAgro = New System.Windows.Forms.DataGridView
        Me.tbConsumo = New System.Windows.Forms.TabPage
        Me.DataConsumo = New System.Windows.Forms.DataGridView
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.tbAgro.SuspendLayout()
        CType(Me.DataAgro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbConsumo.SuspendLayout()
        CType(Me.DataConsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateHasta
        '
        Me.DateHasta.Location = New System.Drawing.Point(656, 56)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(200, 20)
        Me.DateHasta.TabIndex = 3
        '
        'DateDesde
        '
        Me.DateDesde.Location = New System.Drawing.Point(656, 28)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(200, 20)
        Me.DateDesde.TabIndex = 3
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Location = New System.Drawing.Point(880, 39)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(75, 50)
        Me.BtnGenerar.TabIndex = 7
        Me.BtnGenerar.Text = "Generar"
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(354, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sucursal:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Filtro:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(597, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(597, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Desde:"
        '
        'ComboSucursal
        '
        Me.ComboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSucursal.FormattingEnabled = True
        Me.ComboSucursal.Items.AddRange(New Object() {"TODAS", "SPS", "SRC", "SABA", "TEGUCIGALPA"})
        Me.ComboSucursal.Location = New System.Drawing.Point(411, 28)
        Me.ComboSucursal.Name = "ComboSucursal"
        Me.ComboSucursal.Size = New System.Drawing.Size(180, 21)
        Me.ComboSucursal.TabIndex = 1
        '
        'ComboFiltro
        '
        Me.ComboFiltro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboFiltro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboFiltro.FormattingEnabled = True
        Me.ComboFiltro.Location = New System.Drawing.Point(95, 55)
        Me.ComboFiltro.Name = "ComboFiltro"
        Me.ComboFiltro.Size = New System.Drawing.Size(253, 21)
        Me.ComboFiltro.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DateHasta)
        Me.GroupBox1.Controls.Add(Me.DateDesde)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboSucursal)
        Me.GroupBox1.Controls.Add(Me.ComboFiltro)
        Me.GroupBox1.Controls.Add(Me.ComboEd)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(862, 91)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filtrar por:"
        '
        'ComboEd
        '
        Me.ComboEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEd.FormattingEnabled = True
        Me.ComboEd.Items.AddRange(New Object() {"Sucursal", "Entregador", "Vehículo"})
        Me.ComboEd.Location = New System.Drawing.Point(95, 28)
        Me.ComboEd.Name = "ComboEd"
        Me.ComboEd.Size = New System.Drawing.Size(253, 21)
        Me.ComboEd.TabIndex = 1
        '
        'tbAgro
        '
        Me.tbAgro.Controls.Add(Me.DataAgro)
        Me.tbAgro.Location = New System.Drawing.Point(4, 22)
        Me.tbAgro.Name = "tbAgro"
        Me.tbAgro.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAgro.Size = New System.Drawing.Size(1018, 298)
        Me.tbAgro.TabIndex = 1
        Me.tbAgro.Text = "SR Agro"
        Me.tbAgro.UseVisualStyleBackColor = True
        '
        'DataAgro
        '
        Me.DataAgro.AllowUserToAddRows = False
        Me.DataAgro.AllowUserToDeleteRows = False
        Me.DataAgro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataAgro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataAgro.Location = New System.Drawing.Point(3, 3)
        Me.DataAgro.Name = "DataAgro"
        Me.DataAgro.ReadOnly = True
        Me.DataAgro.Size = New System.Drawing.Size(1012, 292)
        Me.DataAgro.TabIndex = 1
        '
        'tbConsumo
        '
        Me.tbConsumo.Controls.Add(Me.DataConsumo)
        Me.tbConsumo.Location = New System.Drawing.Point(4, 22)
        Me.tbConsumo.Name = "tbConsumo"
        Me.tbConsumo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbConsumo.Size = New System.Drawing.Size(1018, 298)
        Me.tbConsumo.TabIndex = 0
        Me.tbConsumo.Text = "Consumo"
        Me.tbConsumo.UseVisualStyleBackColor = True
        '
        'DataConsumo
        '
        Me.DataConsumo.AllowUserToAddRows = False
        Me.DataConsumo.AllowUserToDeleteRows = False
        Me.DataConsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataConsumo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataConsumo.Location = New System.Drawing.Point(3, 3)
        Me.DataConsumo.Name = "DataConsumo"
        Me.DataConsumo.ReadOnly = True
        Me.DataConsumo.Size = New System.Drawing.Size(1012, 292)
        Me.DataConsumo.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tbConsumo)
        Me.TabControl1.Controls.Add(Me.tbAgro)
        Me.TabControl1.Location = New System.Drawing.Point(12, 111)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1026, 324)
        Me.TabControl1.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(959, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 51)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Exportar a Excel"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmEfectividadDevol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 445)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnGenerar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmEfectividadDevol"
        Me.Text = "Devoluciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbAgro.ResumeLayout(False)
        CType(Me.DataAgro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbConsumo.ResumeLayout(False)
        CType(Me.DataConsumo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents ComboFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboEd As System.Windows.Forms.ComboBox
    Friend WithEvents tbAgro As System.Windows.Forms.TabPage
    Friend WithEvents DataAgro As System.Windows.Forms.DataGridView
    Friend WithEvents tbConsumo As System.Windows.Forms.TabPage
    Friend WithEvents DataConsumo As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
