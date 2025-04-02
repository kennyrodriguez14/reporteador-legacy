<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CargaPresupuestoBonos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CargaPresupuestoBonos))
        Me.ComboSucursal = New System.Windows.Forms.ComboBox
        Me.DataPresupuestos = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Cargar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboEmpresa = New System.Windows.Forms.ComboBox
        Me.Guardar = New System.Windows.Forms.Button
        CType(Me.DataPresupuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboSucursal
        '
        Me.ComboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSucursal.FormattingEnabled = True
        Me.ComboSucursal.Items.AddRange(New Object() {"TODAS", "SPS", "SRC", "SAB", "TGU"})
        Me.ComboSucursal.Location = New System.Drawing.Point(353, 18)
        Me.ComboSucursal.Name = "ComboSucursal"
        Me.ComboSucursal.Size = New System.Drawing.Size(188, 21)
        Me.ComboSucursal.TabIndex = 5
        '
        'DataPresupuestos
        '
        Me.DataPresupuestos.AllowUserToAddRows = False
        Me.DataPresupuestos.AllowUserToDeleteRows = False
        Me.DataPresupuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataPresupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataPresupuestos.Location = New System.Drawing.Point(6, 9)
        Me.DataPresupuestos.Name = "DataPresupuestos"
        Me.DataPresupuestos.Size = New System.Drawing.Size(1161, 537)
        Me.DataPresupuestos.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(300, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Sucursal:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.DataPresupuestos)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1173, 552)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'Cargar
        '
        Me.Cargar.Location = New System.Drawing.Point(901, 16)
        Me.Cargar.Name = "Cargar"
        Me.Cargar.Size = New System.Drawing.Size(130, 23)
        Me.Cargar.TabIndex = 4
        Me.Cargar.Text = "Cargar"
        Me.Cargar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ComboSucursal)
        Me.GroupBox1.Controls.Add(Me.Cargar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboEmpresa)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1173, 48)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1037, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Cargar de Matinal"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(587, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tipo:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"PROVEEDOR", "VOLUMEN"})
        Me.ComboBox1.Location = New System.Drawing.Point(620, 18)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(275, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Empresa:"
        '
        'ComboEmpresa
        '
        Me.ComboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEmpresa.FormattingEnabled = True
        Me.ComboEmpresa.Location = New System.Drawing.Point(65, 18)
        Me.ComboEmpresa.Name = "ComboEmpresa"
        Me.ComboEmpresa.Size = New System.Drawing.Size(188, 21)
        Me.ComboEmpresa.TabIndex = 0
        '
        'Guardar
        '
        Me.Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guardar.Location = New System.Drawing.Point(1049, 612)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(130, 23)
        Me.Guardar.TabIndex = 8
        Me.Guardar.Text = "Guardar"
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'Frm_CargaPresupuestoBonos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1197, 643)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Guardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_CargaPresupuestoBonos"
        Me.Text = "Cargar Presupuestos Bonos"
        CType(Me.DataPresupuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents DataPresupuestos As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Cargar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Guardar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
