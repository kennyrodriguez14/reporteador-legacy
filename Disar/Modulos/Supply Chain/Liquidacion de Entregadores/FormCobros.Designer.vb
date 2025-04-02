<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCobros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCobros))
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.ComboSucursal = New System.Windows.Forms.ComboBox
        Me.BtnExportar = New System.Windows.Forms.Button
        Me.BtnGenerar = New System.Windows.Forms.Button
        Me.DateCobro = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pendientes = New System.Windows.Forms.DataGridView
        Me.ComboEmpresa = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.Pendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "hasta:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(105, 42)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 17
        '
        'ComboSucursal
        '
        Me.ComboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSucursal.FormattingEnabled = True
        Me.ComboSucursal.Items.AddRange(New Object() {"SPS", "SRC", "SABA", "TGU"})
        Me.ComboSucursal.Location = New System.Drawing.Point(391, 39)
        Me.ComboSucursal.Name = "ComboSucursal"
        Me.ComboSucursal.Size = New System.Drawing.Size(121, 21)
        Me.ComboSucursal.TabIndex = 16
        '
        'BtnExportar
        '
        Me.BtnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.Location = New System.Drawing.Point(960, 27)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(99, 35)
        Me.BtnExportar.TabIndex = 15
        Me.BtnExportar.Text = "Exportar Documento"
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerar.Image = Global.Disar.My.Resources.Resources.Coins_32
        Me.BtnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGenerar.Location = New System.Drawing.Point(868, 27)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(86, 35)
        Me.BtnGenerar.TabIndex = 14
        Me.BtnGenerar.Text = "Generar"
        Me.BtnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'DateCobro
        '
        Me.DateCobro.Location = New System.Drawing.Point(105, 16)
        Me.DateCobro.Name = "DateCobro"
        Me.DateCobro.Size = New System.Drawing.Size(200, 20)
        Me.DateCobro.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(334, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Sucursal:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Fecha de Cobro:"
        '
        'Pendientes
        '
        Me.Pendientes.AllowUserToAddRows = False
        Me.Pendientes.AllowUserToDeleteRows = False
        Me.Pendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Pendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Pendientes.Location = New System.Drawing.Point(12, 76)
        Me.Pendientes.Name = "Pendientes"
        Me.Pendientes.Size = New System.Drawing.Size(1083, 404)
        Me.Pendientes.TabIndex = 10
        '
        'ComboEmpresa
        '
        Me.ComboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEmpresa.FormattingEnabled = True
        Me.ComboEmpresa.Location = New System.Drawing.Point(391, 15)
        Me.ComboEmpresa.Name = "ComboEmpresa"
        Me.ComboEmpresa.Size = New System.Drawing.Size(121, 21)
        Me.ComboEmpresa.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(334, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Empresa:"
        '
        'FormCobros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1107, 492)
        Me.Controls.Add(Me.ComboEmpresa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.ComboSucursal)
        Me.Controls.Add(Me.BtnExportar)
        Me.Controls.Add(Me.BtnGenerar)
        Me.Controls.Add(Me.DateCobro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pendientes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormCobros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formato de Cobros"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Pendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents DateCobro As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pendientes As System.Windows.Forms.DataGridView
    Friend WithEvents ComboEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
