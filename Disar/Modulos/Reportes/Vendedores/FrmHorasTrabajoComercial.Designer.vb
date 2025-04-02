<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHorasTrabajoComercial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHorasTrabajoComercial))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnExportar = New System.Windows.Forms.Button
        Me.BtnGenerar = New System.Windows.Forms.Button
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboSucursal = New System.Windows.Forms.ComboBox
        Me.ComboVendedor = New System.Windows.Forms.ComboBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabDetalle = New System.Windows.Forms.TabPage
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.TabHoras = New System.Windows.Forms.TabPage
        Me.DataHoras = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabDetalle.SuspendLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabHoras.SuspendLayout()
        CType(Me.DataHoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnExportar)
        Me.GroupBox1.Controls.Add(Me.BtnGenerar)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboSucursal)
        Me.GroupBox1.Controls.Add(Me.ComboVendedor)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(854, 87)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'BtnExportar
        '
        Me.BtnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.BtnExportar.Location = New System.Drawing.Point(772, 19)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(60, 52)
        Me.BtnExportar.TabIndex = 3
        Me.BtnExportar.Text = "Exportar"
        Me.BtnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerar.Image = Global.Disar.My.Resources.Resources.Application_View_Detail_32
        Me.BtnGenerar.Location = New System.Drawing.Point(706, 19)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(60, 52)
        Me.BtnGenerar.TabIndex = 3
        Me.BtnGenerar.Text = "Generar"
        Me.BtnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(444, 50)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 2
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(444, 22)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(404, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(401, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Desde:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(72, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Sucursal:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Filtrar por Vendedor:"
        '
        'ComboSucursal
        '
        Me.ComboSucursal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboSucursal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSucursal.FormattingEnabled = True
        Me.ComboSucursal.Items.AddRange(New Object() {"Todos", "San Pedro Sula", "Santa Rosa de Copán", "Tocoa", "Tegucigalpa"})
        Me.ComboSucursal.Location = New System.Drawing.Point(125, 22)
        Me.ComboSucursal.Name = "ComboSucursal"
        Me.ComboSucursal.Size = New System.Drawing.Size(242, 21)
        Me.ComboSucursal.TabIndex = 0
        '
        'ComboVendedor
        '
        Me.ComboVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboVendedor.FormattingEnabled = True
        Me.ComboVendedor.Location = New System.Drawing.Point(125, 49)
        Me.ComboVendedor.Name = "ComboVendedor"
        Me.ComboVendedor.Size = New System.Drawing.Size(242, 21)
        Me.ComboVendedor.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabDetalle)
        Me.TabControl1.Controls.Add(Me.TabHoras)
        Me.TabControl1.Location = New System.Drawing.Point(13, 105)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(853, 385)
        Me.TabControl1.TabIndex = 2
        '
        'TabDetalle
        '
        Me.TabDetalle.Controls.Add(Me.DataDatos)
        Me.TabDetalle.Location = New System.Drawing.Point(4, 22)
        Me.TabDetalle.Name = "TabDetalle"
        Me.TabDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDetalle.Size = New System.Drawing.Size(845, 359)
        Me.TabDetalle.TabIndex = 0
        Me.TabDetalle.Text = "Detalle"
        Me.TabDetalle.UseVisualStyleBackColor = True
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataDatos.Location = New System.Drawing.Point(3, 3)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.Size = New System.Drawing.Size(839, 353)
        Me.DataDatos.TabIndex = 1
        '
        'TabHoras
        '
        Me.TabHoras.Controls.Add(Me.DataHoras)
        Me.TabHoras.Location = New System.Drawing.Point(4, 22)
        Me.TabHoras.Name = "TabHoras"
        Me.TabHoras.Padding = New System.Windows.Forms.Padding(3)
        Me.TabHoras.Size = New System.Drawing.Size(845, 359)
        Me.TabHoras.TabIndex = 1
        Me.TabHoras.Text = "Horas Trabajadas"
        Me.TabHoras.UseVisualStyleBackColor = True
        '
        'DataHoras
        '
        Me.DataHoras.AllowUserToAddRows = False
        Me.DataHoras.AllowUserToDeleteRows = False
        Me.DataHoras.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataHoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataHoras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataHoras.Location = New System.Drawing.Point(3, 3)
        Me.DataHoras.Name = "DataHoras"
        Me.DataHoras.ReadOnly = True
        Me.DataHoras.Size = New System.Drawing.Size(839, 353)
        Me.DataHoras.TabIndex = 2
        '
        'FrmHorasTrabajoComercial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 502)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmHorasTrabajoComercial"
        Me.Text = "Horas Trabajadas Comercial"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabDetalle.ResumeLayout(False)
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabHoras.ResumeLayout(False)
        CType(Me.DataHoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabDetalle As System.Windows.Forms.TabPage
    Friend WithEvents TabHoras As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents DataHoras As System.Windows.Forms.DataGridView
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
End Class
