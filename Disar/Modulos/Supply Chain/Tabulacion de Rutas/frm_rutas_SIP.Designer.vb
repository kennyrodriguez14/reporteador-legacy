<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_rutas_SIP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_rutas_SIP))
        Me.group_listado = New System.Windows.Forms.GroupBox
        Me.grd_rutas = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_busqueda = New System.Windows.Forms.TextBox
        Me.lbl_ruta = New System.Windows.Forms.Label
        Me.group_listado.SuspendLayout()
        CType(Me.grd_rutas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'group_listado
        '
        Me.group_listado.Controls.Add(Me.grd_rutas)
        Me.group_listado.Location = New System.Drawing.Point(12, 59)
        Me.group_listado.Name = "group_listado"
        Me.group_listado.Size = New System.Drawing.Size(473, 205)
        Me.group_listado.TabIndex = 5
        Me.group_listado.TabStop = False
        '
        'grd_rutas
        '
        Me.grd_rutas.AllowUserToAddRows = False
        Me.grd_rutas.AllowUserToDeleteRows = False
        Me.grd_rutas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_rutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_rutas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_rutas.Location = New System.Drawing.Point(3, 16)
        Me.grd_rutas.Name = "grd_rutas"
        Me.grd_rutas.ReadOnly = True
        Me.grd_rutas.Size = New System.Drawing.Size(467, 186)
        Me.grd_rutas.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_busqueda)
        Me.GroupBox1.Controls.Add(Me.lbl_ruta)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 41)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'txt_busqueda
        '
        Me.txt_busqueda.Location = New System.Drawing.Point(90, 13)
        Me.txt_busqueda.Name = "txt_busqueda"
        Me.txt_busqueda.Size = New System.Drawing.Size(303, 20)
        Me.txt_busqueda.TabIndex = 1
        '
        'lbl_ruta
        '
        Me.lbl_ruta.AutoSize = True
        Me.lbl_ruta.Location = New System.Drawing.Point(51, 16)
        Me.lbl_ruta.Name = "lbl_ruta"
        Me.lbl_ruta.Size = New System.Drawing.Size(33, 13)
        Me.lbl_ruta.TabIndex = 0
        Me.lbl_ruta.Text = "Ruta:"
        '
        'frm_rutas_SIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 272)
        Me.Controls.Add(Me.group_listado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_rutas_SIP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rutas del SIP"
        Me.group_listado.ResumeLayout(False)
        CType(Me.grd_rutas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents group_listado As System.Windows.Forms.GroupBox
    Friend WithEvents grd_rutas As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ruta As System.Windows.Forms.Label
End Class
