<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Bonificaciones_Nuevo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Bonificaciones_Nuevo))
        Me.Label4 = New System.Windows.Forms.Label
        Me.tab_control_ejecutivos = New System.Windows.Forms.TabControl
        Me.Label3 = New System.Windows.Forms.Label
        Me.Cmb_Fecha_Inicial = New System.Windows.Forms.DateTimePicker
        Me.Cmb_Fecha_Final = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboEmpresa = New System.Windows.Forms.ComboBox
        Me.DataSupervisores = New System.Windows.Forms.DataGridView
        Me.BtnMostrarInfo = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataSupervisores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(473, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Hasta:"
        '
        'tab_control_ejecutivos
        '
        Me.tab_control_ejecutivos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_control_ejecutivos.Location = New System.Drawing.Point(12, 43)
        Me.tab_control_ejecutivos.Name = "tab_control_ejecutivos"
        Me.tab_control_ejecutivos.SelectedIndex = 0
        Me.tab_control_ejecutivos.Size = New System.Drawing.Size(1015, 510)
        Me.tab_control_ejecutivos.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(473, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Desde:"
        '
        'Cmb_Fecha_Inicial
        '
        Me.Cmb_Fecha_Inicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmb_Fecha_Inicial.Location = New System.Drawing.Point(476, 134)
        Me.Cmb_Fecha_Inicial.Name = "Cmb_Fecha_Inicial"
        Me.Cmb_Fecha_Inicial.Size = New System.Drawing.Size(198, 20)
        Me.Cmb_Fecha_Inicial.TabIndex = 12
        '
        'Cmb_Fecha_Final
        '
        Me.Cmb_Fecha_Final.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmb_Fecha_Final.Location = New System.Drawing.Point(476, 185)
        Me.Cmb_Fecha_Final.Name = "Cmb_Fecha_Final"
        Me.Cmb_Fecha_Final.Size = New System.Drawing.Size(198, 20)
        Me.Cmb_Fecha_Final.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboEmpresa)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Cmb_Fecha_Inicial)
        Me.GroupBox1.Controls.Add(Me.Cmb_Fecha_Final)
        Me.GroupBox1.Controls.Add(Me.DataSupervisores)
        Me.GroupBox1.Controls.Add(Me.BtnMostrarInfo)
        Me.GroupBox1.Location = New System.Drawing.Point(180, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(679, 407)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selección de Supervisores"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Empresa:"
        '
        'ComboEmpresa
        '
        Me.ComboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEmpresa.FormattingEnabled = True
        Me.ComboEmpresa.Location = New System.Drawing.Point(60, 27)
        Me.ComboEmpresa.Name = "ComboEmpresa"
        Me.ComboEmpresa.Size = New System.Drawing.Size(292, 21)
        Me.ComboEmpresa.TabIndex = 13
        '
        'DataSupervisores
        '
        Me.DataSupervisores.AllowUserToAddRows = False
        Me.DataSupervisores.AllowUserToDeleteRows = False
        Me.DataSupervisores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataSupervisores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataSupervisores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataSupervisores.Location = New System.Drawing.Point(6, 54)
        Me.DataSupervisores.Name = "DataSupervisores"
        Me.DataSupervisores.RowHeadersVisible = False
        Me.DataSupervisores.Size = New System.Drawing.Size(463, 347)
        Me.DataSupervisores.TabIndex = 5
        '
        'BtnMostrarInfo
        '
        Me.BtnMostrarInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMostrarInfo.Location = New System.Drawing.Point(476, 211)
        Me.BtnMostrarInfo.Name = "BtnMostrarInfo"
        Me.BtnMostrarInfo.Size = New System.Drawing.Size(198, 78)
        Me.BtnMostrarInfo.TabIndex = 2
        Me.BtnMostrarInfo.Text = "Mostrar Información"
        Me.BtnMostrarInfo.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Exportar"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Frm_Bonificaciones_Nuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 566)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tab_control_ejecutivos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Bonificaciones_Nuevo"
        Me.Text = "Bonificaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataSupervisores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tab_control_ejecutivos As System.Windows.Forms.TabControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Fecha_Inicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cmb_Fecha_Final As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataSupervisores As System.Windows.Forms.DataGridView
    Friend WithEvents BtnMostrarInfo As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboEmpresa As System.Windows.Forms.ComboBox
End Class
