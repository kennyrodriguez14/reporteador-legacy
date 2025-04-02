<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tasa_cambiaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tasa_cambiaria))
        Me.grd_presupuestos = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_nueva_tasa = New System.Windows.Forms.TextBox
        Me.btn_cambiar = New System.Windows.Forms.Button
        CType(Me.grd_presupuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.grd_presupuestos.Location = New System.Drawing.Point(12, 59)
        Me.grd_presupuestos.Name = "grd_presupuestos"
        Me.grd_presupuestos.ReadOnly = True
        Me.grd_presupuestos.RowHeadersVisible = False
        Me.grd_presupuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_presupuestos.Size = New System.Drawing.Size(455, 107)
        Me.grd_presupuestos.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(104, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 34)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Tasa " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cambiaria:"
        '
        'txt_nueva_tasa
        '
        Me.txt_nueva_tasa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nueva_tasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nueva_tasa.Location = New System.Drawing.Point(195, 27)
        Me.txt_nueva_tasa.Name = "txt_nueva_tasa"
        Me.txt_nueva_tasa.Size = New System.Drawing.Size(75, 26)
        Me.txt_nueva_tasa.TabIndex = 26
        '
        'btn_cambiar
        '
        Me.btn_cambiar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_cambiar.Location = New System.Drawing.Point(277, 27)
        Me.btn_cambiar.Name = "btn_cambiar"
        Me.btn_cambiar.Size = New System.Drawing.Size(97, 23)
        Me.btn_cambiar.TabIndex = 27
        Me.btn_cambiar.Text = "Cambiar"
        Me.btn_cambiar.UseVisualStyleBackColor = True
        '
        'frm_tasa_cambiaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 178)
        Me.Controls.Add(Me.btn_cambiar)
        Me.Controls.Add(Me.txt_nueva_tasa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grd_presupuestos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_tasa_cambiaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tasa Cambiaria"
        CType(Me.grd_presupuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grd_presupuestos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_nueva_tasa As System.Windows.Forms.TextBox
    Friend WithEvents btn_cambiar As System.Windows.Forms.Button
End Class
