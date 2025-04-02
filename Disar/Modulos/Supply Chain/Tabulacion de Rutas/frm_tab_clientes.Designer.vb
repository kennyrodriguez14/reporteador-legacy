<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tab_clientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tab_clientes))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmb_tipo_busqueda = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_busqueda = New System.Windows.Forms.TextBox
        Me.lbl_ruta = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.group_listado = New System.Windows.Forms.GroupBox
        Me.grd_clientes = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        Me.group_listado.SuspendLayout()
        CType(Me.grd_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmb_tipo_busqueda)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_busqueda)
        Me.GroupBox1.Controls.Add(Me.lbl_ruta)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(474, 48)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'cmb_tipo_busqueda
        '
        Me.cmb_tipo_busqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipo_busqueda.FormattingEnabled = True
        Me.cmb_tipo_busqueda.Items.AddRange(New Object() {"Nombre", "Codigo"})
        Me.cmb_tipo_busqueda.Location = New System.Drawing.Point(66, 18)
        Me.cmb_tipo_busqueda.Name = "cmb_tipo_busqueda"
        Me.cmb_tipo_busqueda.Size = New System.Drawing.Size(92, 21)
        Me.cmb_tipo_busqueda.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Buscar por:"
        '
        'txt_busqueda
        '
        Me.txt_busqueda.Location = New System.Drawing.Point(164, 18)
        Me.txt_busqueda.Name = "txt_busqueda"
        Me.txt_busqueda.Size = New System.Drawing.Size(303, 20)
        Me.txt_busqueda.TabIndex = 1
        '
        'lbl_ruta
        '
        Me.lbl_ruta.AutoSize = True
        Me.lbl_ruta.Location = New System.Drawing.Point(125, 18)
        Me.lbl_ruta.Name = "lbl_ruta"
        Me.lbl_ruta.Size = New System.Drawing.Size(33, 13)
        Me.lbl_ruta.TabIndex = 0
        Me.lbl_ruta.Text = "Ruta:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(498, 25)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'group_listado
        '
        Me.group_listado.Controls.Add(Me.grd_clientes)
        Me.group_listado.Location = New System.Drawing.Point(13, 83)
        Me.group_listado.Name = "group_listado"
        Me.group_listado.Size = New System.Drawing.Size(473, 230)
        Me.group_listado.TabIndex = 12
        Me.group_listado.TabStop = False
        '
        'grd_clientes
        '
        Me.grd_clientes.AllowUserToAddRows = False
        Me.grd_clientes.AllowUserToDeleteRows = False
        Me.grd_clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_clientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_clientes.Location = New System.Drawing.Point(3, 16)
        Me.grd_clientes.Name = "grd_clientes"
        Me.grd_clientes.ReadOnly = True
        Me.grd_clientes.RowHeadersVisible = False
        Me.grd_clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_clientes.Size = New System.Drawing.Size(467, 211)
        Me.grd_clientes.TabIndex = 2
        '
        'frm_tab_clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 325)
        Me.Controls.Add(Me.group_listado)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_tab_clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Clientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.group_listado.ResumeLayout(False)
        CType(Me.grd_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ruta As System.Windows.Forms.Label
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmb_tipo_busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents group_listado As System.Windows.Forms.GroupBox
    Friend WithEvents grd_clientes As System.Windows.Forms.DataGridView
End Class
