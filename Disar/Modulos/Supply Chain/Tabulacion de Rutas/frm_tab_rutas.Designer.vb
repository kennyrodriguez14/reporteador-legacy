<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tab_rutas
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_busqueda = New System.Windows.Forms.TextBox
        Me.lbl_ruta = New System.Windows.Forms.Label
        Me.group_listado = New System.Windows.Forms.GroupBox
        Me.grd_rutas = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.group_ingreso = New System.Windows.Forms.GroupBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.txt_nombre_ruta = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_codigo_ruta = New System.Windows.Forms.TextBox
        Me.lbl_id = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.group_listado.SuspendLayout()
        CType(Me.grd_rutas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.group_ingreso.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_busqueda)
        Me.GroupBox1.Controls.Add(Me.lbl_ruta)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 41)
        Me.GroupBox1.TabIndex = 0
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
        'group_listado
        '
        Me.group_listado.Controls.Add(Me.grd_rutas)
        Me.group_listado.Location = New System.Drawing.Point(12, 75)
        Me.group_listado.Name = "group_listado"
        Me.group_listado.Size = New System.Drawing.Size(473, 205)
        Me.group_listado.TabIndex = 0
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
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(497, 25)
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '_Archivo
        '
        Me._Archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.EditarToolStripMenuItem})
        Me._Archivo.Image = Global.Disar.My.Resources.Resources.Opciones
        Me._Archivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._Archivo.Name = "_Archivo"
        Me._Archivo.Size = New System.Drawing.Size(84, 22)
        Me._Archivo.Text = "Acciones"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.NuevoToolStripMenuItem.Text = "Nuevo"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.File_Edit_32
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'group_ingreso
        '
        Me.group_ingreso.Controls.Add(Me.btn_cancelar)
        Me.group_ingreso.Controls.Add(Me.btn_aceptar)
        Me.group_ingreso.Controls.Add(Me.txt_nombre_ruta)
        Me.group_ingreso.Controls.Add(Me.Label1)
        Me.group_ingreso.Controls.Add(Me.txt_codigo_ruta)
        Me.group_ingreso.Controls.Add(Me.lbl_id)
        Me.group_ingreso.Location = New System.Drawing.Point(104, 103)
        Me.group_ingreso.Name = "group_ingreso"
        Me.group_ingreso.Size = New System.Drawing.Size(301, 125)
        Me.group_ingreso.TabIndex = 3
        Me.group_ingreso.TabStop = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Location = New System.Drawing.Point(220, 96)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 6
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(6, 96)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 5
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'txt_nombre_ruta
        '
        Me.txt_nombre_ruta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nombre_ruta.Location = New System.Drawing.Point(66, 55)
        Me.txt_nombre_ruta.Name = "txt_nombre_ruta"
        Me.txt_nombre_ruta.Size = New System.Drawing.Size(213, 20)
        Me.txt_nombre_ruta.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ruta:"
        '
        'txt_codigo_ruta
        '
        Me.txt_codigo_ruta.Location = New System.Drawing.Point(68, 24)
        Me.txt_codigo_ruta.Name = "txt_codigo_ruta"
        Me.txt_codigo_ruta.ReadOnly = True
        Me.txt_codigo_ruta.Size = New System.Drawing.Size(213, 20)
        Me.txt_codigo_ruta.TabIndex = 3
        '
        'lbl_id
        '
        Me.lbl_id.AutoSize = True
        Me.lbl_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_id.Location = New System.Drawing.Point(19, 27)
        Me.lbl_id.Name = "lbl_id"
        Me.lbl_id.Size = New System.Drawing.Size(50, 13)
        Me.lbl_id.TabIndex = 0
        Me.lbl_id.Text = "Codigo:"
        '
        'frm_tab_rutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 292)
        Me.Controls.Add(Me.group_ingreso)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.group_listado)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_tab_rutas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rutas de Entrega"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.group_listado.ResumeLayout(False)
        CType(Me.grd_rutas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.group_ingreso.ResumeLayout(False)
        Me.group_ingreso.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents group_listado As System.Windows.Forms.GroupBox
    Friend WithEvents txt_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ruta As System.Windows.Forms.Label
    Friend WithEvents grd_rutas As System.Windows.Forms.DataGridView
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents group_ingreso As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents txt_nombre_ruta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_ruta As System.Windows.Forms.TextBox
    Friend WithEvents lbl_id As System.Windows.Forms.Label
End Class
