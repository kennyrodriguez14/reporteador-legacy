<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPresupuestosAgroMatinal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPresupuestosAgroMatinal))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.ComboMes = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DataMetas = New System.Windows.Forms.DataGridView
        Me.BtnDesactivarPresupuesto = New System.Windows.Forms.Button
        Me.BtnAgregarPresupuesto = New System.Windows.Forms.Button
        Me.BtnDesactivarPantalla = New System.Windows.Forms.Button
        Me.BtnAgregarPantalla = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataPantallas = New System.Windows.Forms.DataGridView
        Me.DataVendedores = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataMetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataPantallas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.BtnDesactivarPantalla)
        Me.GroupBox1.Controls.Add(Me.BtnAgregarPantalla)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DataPantallas)
        Me.GroupBox1.Controls.Add(Me.DataVendedores)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(919, 512)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.DataMetas)
        Me.GroupBox2.Controls.Add(Me.BtnDesactivarPresupuesto)
        Me.GroupBox2.Controls.Add(Me.BtnAgregarPresupuesto)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 328)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(822, 178)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Presupuestos de "
        Me.GroupBox2.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox3.Controls.Add(Me.ComboMes)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(604, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(193, 76)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Mes:"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(54, 44)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown1.TabIndex = 3
        Me.NumericUpDown1.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'ComboMes
        '
        Me.ComboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboMes.FormattingEnabled = True
        Me.ComboMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.ComboMes.Location = New System.Drawing.Point(54, 18)
        Me.ComboMes.Name = "ComboMes"
        Me.ComboMes.Size = New System.Drawing.Size(121, 21)
        Me.ComboMes.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Año:"
        '
        'DataMetas
        '
        Me.DataMetas.AllowUserToAddRows = False
        Me.DataMetas.AllowUserToDeleteRows = False
        Me.DataMetas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataMetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataMetas.Location = New System.Drawing.Point(6, 19)
        Me.DataMetas.Name = "DataMetas"
        Me.DataMetas.ReadOnly = True
        Me.DataMetas.RowHeadersVisible = False
        Me.DataMetas.Size = New System.Drawing.Size(549, 150)
        Me.DataMetas.TabIndex = 5
        '
        'BtnDesactivarPresupuesto
        '
        Me.BtnDesactivarPresupuesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDesactivarPresupuesto.Image = Global.Disar.My.Resources.Resources.Bullet_Toggle_Minus_32
        Me.BtnDesactivarPresupuesto.Location = New System.Drawing.Point(721, 119)
        Me.BtnDesactivarPresupuesto.Name = "BtnDesactivarPresupuesto"
        Me.BtnDesactivarPresupuesto.Size = New System.Drawing.Size(76, 50)
        Me.BtnDesactivarPresupuesto.TabIndex = 7
        Me.BtnDesactivarPresupuesto.Text = "Desactivar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Selección"
        Me.BtnDesactivarPresupuesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnDesactivarPresupuesto.UseVisualStyleBackColor = True
        '
        'BtnAgregarPresupuesto
        '
        Me.BtnAgregarPresupuesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregarPresupuesto.Image = Global.Disar.My.Resources.Resources.Badge_plus_32
        Me.BtnAgregarPresupuesto.Location = New System.Drawing.Point(604, 119)
        Me.BtnAgregarPresupuesto.Name = "BtnAgregarPresupuesto"
        Me.BtnAgregarPresupuesto.Size = New System.Drawing.Size(76, 50)
        Me.BtnAgregarPresupuesto.TabIndex = 6
        Me.BtnAgregarPresupuesto.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nuevo"
        Me.BtnAgregarPresupuesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAgregarPresupuesto.UseVisualStyleBackColor = True
        '
        'BtnDesactivarPantalla
        '
        Me.BtnDesactivarPantalla.Image = Global.Disar.My.Resources.Resources.Bullet_Toggle_Minus_32
        Me.BtnDesactivarPantalla.Location = New System.Drawing.Point(837, 94)
        Me.BtnDesactivarPantalla.Name = "BtnDesactivarPantalla"
        Me.BtnDesactivarPantalla.Size = New System.Drawing.Size(76, 56)
        Me.BtnDesactivarPantalla.TabIndex = 3
        Me.BtnDesactivarPantalla.Text = "Desactivar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pantalla"
        Me.BtnDesactivarPantalla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnDesactivarPantalla.UseVisualStyleBackColor = True
        '
        'BtnAgregarPantalla
        '
        Me.BtnAgregarPantalla.Image = Global.Disar.My.Resources.Resources.Badge_plus_32
        Me.BtnAgregarPantalla.Location = New System.Drawing.Point(837, 32)
        Me.BtnAgregarPantalla.Name = "BtnAgregarPantalla"
        Me.BtnAgregarPantalla.Size = New System.Drawing.Size(76, 56)
        Me.BtnAgregarPantalla.TabIndex = 2
        Me.BtnAgregarPantalla.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pantalla"
        Me.BtnAgregarPantalla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAgregarPantalla.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(628, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Pantallas asignadas al vendedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(286, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Dé clic sobre un vendedor para ver las pantallas asignadas"
        '
        'DataPantallas
        '
        Me.DataPantallas.AllowUserToAddRows = False
        Me.DataPantallas.AllowUserToDeleteRows = False
        Me.DataPantallas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataPantallas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataPantallas.Location = New System.Drawing.Point(586, 32)
        Me.DataPantallas.Name = "DataPantallas"
        Me.DataPantallas.ReadOnly = True
        Me.DataPantallas.RowHeadersVisible = False
        Me.DataPantallas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataPantallas.Size = New System.Drawing.Size(245, 275)
        Me.DataPantallas.TabIndex = 4
        '
        'DataVendedores
        '
        Me.DataVendedores.AllowUserToAddRows = False
        Me.DataVendedores.AllowUserToDeleteRows = False
        Me.DataVendedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataVendedores.Location = New System.Drawing.Point(15, 32)
        Me.DataVendedores.Name = "DataVendedores"
        Me.DataVendedores.ReadOnly = True
        Me.DataVendedores.RowHeadersVisible = False
        Me.DataVendedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataVendedores.Size = New System.Drawing.Size(549, 275)
        Me.DataVendedores.TabIndex = 1
        '
        'FrmPresupuestosAgroMatinal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 537)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmPresupuestosAgroMatinal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pantallas y Presupuestos - Matinal SR Agro"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataMetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataPantallas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDesactivarPantalla As System.Windows.Forms.Button
    Friend WithEvents BtnAgregarPantalla As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataPantallas As System.Windows.Forms.DataGridView
    Friend WithEvents DataVendedores As System.Windows.Forms.DataGridView
    Friend WithEvents DataMetas As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDesactivarPresupuesto As System.Windows.Forms.Button
    Friend WithEvents BtnAgregarPresupuesto As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents ComboMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
