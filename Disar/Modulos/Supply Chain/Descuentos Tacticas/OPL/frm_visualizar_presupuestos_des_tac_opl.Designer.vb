<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_visualizar_presupuestos_des_tac_OPL
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
        Me.btn_generar = New System.Windows.Forms.Button()
        Me.grp_filtros = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_fecha = New System.Windows.Forms.DateTimePicker()
        Me.grd_presupuestos = New System.Windows.Forms.DataGridView()
        Me.grp_filtros.SuspendLayout()
        CType(Me.grd_presupuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_generar
        '
        Me.btn_generar.Location = New System.Drawing.Point(277, 20)
        Me.btn_generar.Name = "btn_generar"
        Me.btn_generar.Size = New System.Drawing.Size(82, 22)
        Me.btn_generar.TabIndex = 26
        Me.btn_generar.Text = "Generar"
        Me.btn_generar.UseVisualStyleBackColor = True
        '
        'grp_filtros
        '
        Me.grp_filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_filtros.Controls.Add(Me.btn_generar)
        Me.grp_filtros.Controls.Add(Me.Label1)
        Me.grp_filtros.Controls.Add(Me.cmb_fecha)
        Me.grp_filtros.Location = New System.Drawing.Point(12, 12)
        Me.grp_filtros.Name = "grp_filtros"
        Me.grp_filtros.Size = New System.Drawing.Size(1009, 50)
        Me.grp_filtros.TabIndex = 32
        Me.grp_filtros.TabStop = False
        Me.grp_filtros.Text = "Filtros"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Mes:"
        '
        'cmb_fecha
        '
        Me.cmb_fecha.CustomFormat = "MMMM yyyy"
        Me.cmb_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.cmb_fecha.Location = New System.Drawing.Point(44, 19)
        Me.cmb_fecha.Name = "cmb_fecha"
        Me.cmb_fecha.ShowUpDown = True
        Me.cmb_fecha.Size = New System.Drawing.Size(227, 20)
        Me.cmb_fecha.TabIndex = 25
        '
        'grd_presupuestos
        '
        Me.grd_presupuestos.AllowUserToAddRows = False
        Me.grd_presupuestos.AllowUserToDeleteRows = False
        Me.grd_presupuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_presupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_presupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_presupuestos.Location = New System.Drawing.Point(12, 68)
        Me.grd_presupuestos.Name = "grd_presupuestos"
        Me.grd_presupuestos.ReadOnly = True
        Me.grd_presupuestos.Size = New System.Drawing.Size(1009, 463)
        Me.grd_presupuestos.TabIndex = 33
        '
        'frm_visualizar_presupuestos_des_tac_opl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 543)
        Me.Controls.Add(Me.grp_filtros)
        Me.Controls.Add(Me.grd_presupuestos)
        Me.Name = "frm_visualizar_presupuestos_des_tac_opl"
        Me.Text = "frm_visualizar_presupuestos_des_tac_opl"
        Me.grp_filtros.ResumeLayout(False)
        Me.grp_filtros.PerformLayout()
        CType(Me.grd_presupuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_generar As Button
    Friend WithEvents grp_filtros As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmb_fecha As DateTimePicker
    Friend WithEvents grd_presupuestos As DataGridView
End Class
