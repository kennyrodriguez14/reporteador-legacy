<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Busqueda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Busqueda))
        Me.grp_vista = New System.Windows.Forms.GroupBox
        Me.grd_productos = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBusqueda = New System.Windows.Forms.TextBox
        Me.grp_vista.SuspendLayout()
        CType(Me.grd_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp_vista
        '
        Me.grp_vista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_vista.Controls.Add(Me.grd_productos)
        Me.grp_vista.Location = New System.Drawing.Point(12, 29)
        Me.grp_vista.Name = "grp_vista"
        Me.grp_vista.Size = New System.Drawing.Size(398, 185)
        Me.grp_vista.TabIndex = 2
        Me.grp_vista.TabStop = False
        '
        'grd_productos
        '
        Me.grd_productos.AllowUserToAddRows = False
        Me.grd_productos.AllowUserToDeleteRows = False
        Me.grd_productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_productos.Location = New System.Drawing.Point(3, 16)
        Me.grd_productos.Name = "grd_productos"
        Me.grd_productos.ReadOnly = True
        Me.grd_productos.Size = New System.Drawing.Size(392, 166)
        Me.grd_productos.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nombre:"
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Location = New System.Drawing.Point(65, 10)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(347, 20)
        Me.txtBusqueda.TabIndex = 4
        '
        'Busqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 226)
        Me.Controls.Add(Me.txtBusqueda)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grp_vista)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Busqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda"
        Me.TopMost = True
        Me.grp_vista.ResumeLayout(False)
        CType(Me.grd_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grp_vista As System.Windows.Forms.GroupBox
    Friend WithEvents grd_productos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
End Class
