<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tasa_cambiaria_sragro
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
        Me.btn_cambiar = New System.Windows.Forms.Button
        Me.txt_nueva_tasa = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grd_presupuestos = New System.Windows.Forms.DataGridView
        CType(Me.grd_presupuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_cambiar
        '
        Me.btn_cambiar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_cambiar.Location = New System.Drawing.Point(272, 22)
        Me.btn_cambiar.Name = "btn_cambiar"
        Me.btn_cambiar.Size = New System.Drawing.Size(97, 23)
        Me.btn_cambiar.TabIndex = 31
        Me.btn_cambiar.Text = "Cambiar"
        Me.btn_cambiar.UseVisualStyleBackColor = True
        '
        'txt_nueva_tasa
        '
        Me.txt_nueva_tasa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nueva_tasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nueva_tasa.Location = New System.Drawing.Point(190, 22)
        Me.txt_nueva_tasa.Name = "txt_nueva_tasa"
        Me.txt_nueva_tasa.Size = New System.Drawing.Size(75, 26)
        Me.txt_nueva_tasa.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(99, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 34)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Tasa " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cambiaria:"
        '
        'grd_presupuestos
        '
        Me.grd_presupuestos.AllowUserToAddRows = False
        Me.grd_presupuestos.AllowUserToDeleteRows = False
        Me.grd_presupuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_presupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_presupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_presupuestos.Location = New System.Drawing.Point(12, 54)
        Me.grd_presupuestos.Name = "grd_presupuestos"
        Me.grd_presupuestos.ReadOnly = True
        Me.grd_presupuestos.RowHeadersVisible = False
        Me.grd_presupuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_presupuestos.Size = New System.Drawing.Size(445, 98)
        Me.grd_presupuestos.TabIndex = 28
        '
        'frm_tasa_cambiaria_sragro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 164)
        Me.Controls.Add(Me.btn_cambiar)
        Me.Controls.Add(Me.txt_nueva_tasa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grd_presupuestos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_tasa_cambiaria_sragro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tasa Cambiaria SR Agro"
        CType(Me.grd_presupuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_cambiar As System.Windows.Forms.Button
    Friend WithEvents txt_nueva_tasa As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grd_presupuestos As System.Windows.Forms.DataGridView
End Class
