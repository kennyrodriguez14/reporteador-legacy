<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_validacion_sae_DIMOSA
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.grd_repo = New System.Windows.Forms.DataGridView
        Me.txt_totalr = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grd_sae = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grp_precios_productos = New System.Windows.Forms.GroupBox
        Me.txt_total_sae = New System.Windows.Forms.TextBox
        CType(Me.grd_repo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_sae, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grp_precios_productos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(794, 344)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 26)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Total:"
        '
        'grd_repo
        '
        Me.grd_repo.AllowUserToAddRows = False
        Me.grd_repo.AllowUserToDeleteRows = False
        Me.grd_repo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_repo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_repo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_repo.Location = New System.Drawing.Point(3, 16)
        Me.grd_repo.MultiSelect = False
        Me.grd_repo.Name = "grd_repo"
        Me.grd_repo.ReadOnly = True
        Me.grd_repo.RowHeadersVisible = False
        Me.grd_repo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_repo.Size = New System.Drawing.Size(494, 317)
        Me.grd_repo.TabIndex = 18
        '
        'txt_totalr
        '
        Me.txt_totalr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totalr.Location = New System.Drawing.Point(359, 345)
        Me.txt_totalr.Name = "txt_totalr"
        Me.txt_totalr.ReadOnly = True
        Me.txt_totalr.Size = New System.Drawing.Size(150, 26)
        Me.txt_totalr.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(288, 344)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 26)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Total:"
        '
        'grd_sae
        '
        Me.grd_sae.AllowUserToAddRows = False
        Me.grd_sae.AllowUserToDeleteRows = False
        Me.grd_sae.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_sae.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_sae.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_sae.Location = New System.Drawing.Point(3, 16)
        Me.grd_sae.MultiSelect = False
        Me.grd_sae.Name = "grd_sae"
        Me.grd_sae.ReadOnly = True
        Me.grd_sae.RowHeadersVisible = False
        Me.grd_sae.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_sae.Size = New System.Drawing.Size(494, 317)
        Me.grd_sae.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.grd_sae)
        Me.GroupBox1.Location = New System.Drawing.Point(518, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(500, 336)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SAE"
        '
        'grp_precios_productos
        '
        Me.grp_precios_productos.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.grp_precios_productos.Controls.Add(Me.grd_repo)
        Me.grp_precios_productos.Location = New System.Drawing.Point(12, 8)
        Me.grp_precios_productos.Name = "grp_precios_productos"
        Me.grp_precios_productos.Size = New System.Drawing.Size(500, 336)
        Me.grp_precios_productos.TabIndex = 23
        Me.grp_precios_productos.TabStop = False
        Me.grp_precios_productos.Text = "Reporteador"
        '
        'txt_total_sae
        '
        Me.txt_total_sae.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_sae.Location = New System.Drawing.Point(865, 346)
        Me.txt_total_sae.Name = "txt_total_sae"
        Me.txt_total_sae.ReadOnly = True
        Me.txt_total_sae.Size = New System.Drawing.Size(150, 26)
        Me.txt_total_sae.TabIndex = 26
        '
        'frm_validacion_sae_DIMOSA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 381)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_totalr)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp_precios_productos)
        Me.Controls.Add(Me.txt_total_sae)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_validacion_sae_DIMOSA"
        Me.Text = "Validación de inventario DIMOSA"
        CType(Me.grd_repo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_sae, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.grp_precios_productos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grd_repo As System.Windows.Forms.DataGridView
    Friend WithEvents txt_totalr As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grd_sae As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grp_precios_productos As System.Windows.Forms.GroupBox
    Friend WithEvents txt_total_sae As System.Windows.Forms.TextBox
End Class
