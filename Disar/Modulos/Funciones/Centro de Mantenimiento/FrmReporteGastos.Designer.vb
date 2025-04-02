<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporteGastos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReporteGastos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.VehiculoID = New System.Windows.Forms.ComboBox
        Me.DteHasta = New System.Windows.Forms.DateTimePicker
        Me.DteDesde = New System.Windows.Forms.DateTimePicker
        Me.ComboFiltro = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnCargar = New System.Windows.Forms.Button
        Me.LCosto = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.BtnExportar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DataDatos)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(859, 516)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataDatos.Location = New System.Drawing.Point(3, 16)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.Size = New System.Drawing.Size(853, 497)
        Me.DataDatos.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.VehiculoID)
        Me.GroupBox2.Controls.Add(Me.DteHasta)
        Me.GroupBox2.Controls.Add(Me.DteDesde)
        Me.GroupBox2.Controls.Add(Me.ComboFiltro)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(653, 86)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'VehiculoID
        '
        Me.VehiculoID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.VehiculoID.FormattingEnabled = True
        Me.VehiculoID.Location = New System.Drawing.Point(94, 28)
        Me.VehiculoID.Name = "VehiculoID"
        Me.VehiculoID.Size = New System.Drawing.Size(275, 21)
        Me.VehiculoID.TabIndex = 3
        '
        'DteHasta
        '
        Me.DteHasta.Location = New System.Drawing.Point(434, 53)
        Me.DteHasta.Name = "DteHasta"
        Me.DteHasta.Size = New System.Drawing.Size(200, 20)
        Me.DteHasta.TabIndex = 2
        '
        'DteDesde
        '
        Me.DteDesde.Location = New System.Drawing.Point(434, 29)
        Me.DteDesde.Name = "DteDesde"
        Me.DteDesde.Size = New System.Drawing.Size(200, 20)
        Me.DteDesde.TabIndex = 2
        '
        'ComboFiltro
        '
        Me.ComboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboFiltro.DropDownWidth = 300
        Me.ComboFiltro.FormattingEnabled = True
        Me.ComboFiltro.Location = New System.Drawing.Point(94, 52)
        Me.ComboFiltro.Name = "ComboFiltro"
        Me.ComboFiltro.Size = New System.Drawing.Size(276, 21)
        Me.ComboFiltro.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(388, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(388, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Desde:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Vehículo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filtrar Costos:"
        '
        'BtnCargar
        '
        Me.BtnCargar.Location = New System.Drawing.Point(672, 35)
        Me.BtnCargar.Name = "BtnCargar"
        Me.BtnCargar.Size = New System.Drawing.Size(75, 54)
        Me.BtnCargar.TabIndex = 2
        Me.BtnCargar.Text = "Cargar Información"
        Me.BtnCargar.UseVisualStyleBackColor = True
        '
        'LCosto
        '
        Me.LCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LCosto.AutoSize = True
        Me.LCosto.Location = New System.Drawing.Point(78, 633)
        Me.LCosto.Name = "LCosto"
        Me.LCosto.Size = New System.Drawing.Size(39, 13)
        Me.LCosto.TabIndex = 4
        Me.LCosto.Text = "♦♦♦♦"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 633)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Costo Total:"
        '
        'BtnExportar
        '
        Me.BtnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnExportar.Location = New System.Drawing.Point(753, 35)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(101, 54)
        Me.BtnExportar.TabIndex = 6
        Me.BtnExportar.Text = "Exportar Información"
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'FrmReporteGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 666)
        Me.Controls.Add(Me.BtnExportar)
        Me.Controls.Add(Me.LCosto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnCargar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmReporteGastos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Costos por Vehículo"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DteHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DteDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnCargar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LCosto As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents VehiculoID As System.Windows.Forms.ComboBox
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
End Class
