<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Presupuesto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Presupuesto))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnArchivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton
        Me.btnEditar = New System.Windows.Forms.ToolStripButton
        Me.Editar = New System.Windows.Forms.GroupBox
        Me.txtNumReg = New System.Windows.Forms.TextBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.txtsucu = New System.Windows.Forms.TextBox
        Me.txtpre = New System.Windows.Forms.TextBox
        Me.txtnom = New System.Windows.Forms.TextBox
        Me.txtid = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Lista = New System.Windows.Forms.GroupBox
        Me.GridPresupuestos = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me.Editar.SuspendLayout()
        Me.Lista.SuspendLayout()
        CType(Me.GridPresupuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnArchivo, Me.btnNuevo, Me.btnEditar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(536, 39)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnArchivo
        '
        Me.btnArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarToolStripMenuItem})
        Me.btnArchivo.Image = Global.Disar.My.Resources.Resources.Archivo
        Me.btnArchivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnArchivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(93, 36)
        Me.btnArchivo.Text = "Archivo"
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.CerrarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(122, 38)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Disar.My.Resources.Resources.Cliente
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 36)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Disar.My.Resources.Resources.Guardar
        Me.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(73, 36)
        Me.btnEditar.Text = "Editar"
        '
        'Editar
        '
        Me.Editar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Editar.Controls.Add(Me.txtNumReg)
        Me.Editar.Controls.Add(Me.btnCancelar)
        Me.Editar.Controls.Add(Me.btnAceptar)
        Me.Editar.Controls.Add(Me.txtsucu)
        Me.Editar.Controls.Add(Me.txtpre)
        Me.Editar.Controls.Add(Me.txtnom)
        Me.Editar.Controls.Add(Me.txtid)
        Me.Editar.Controls.Add(Me.Label4)
        Me.Editar.Controls.Add(Me.Label3)
        Me.Editar.Controls.Add(Me.Label2)
        Me.Editar.Controls.Add(Me.Label1)
        Me.Editar.Location = New System.Drawing.Point(119, 119)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(299, 195)
        Me.Editar.TabIndex = 4
        Me.Editar.TabStop = False
        Me.Editar.Visible = False
        '
        'txtNumReg
        '
        Me.txtNumReg.Location = New System.Drawing.Point(265, 169)
        Me.txtNumReg.Name = "txtNumReg"
        Me.txtNumReg.Size = New System.Drawing.Size(28, 20)
        Me.txtNumReg.TabIndex = 7
        Me.txtNumReg.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(184, 166)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(81, 166)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtsucu
        '
        Me.txtsucu.Location = New System.Drawing.Point(85, 126)
        Me.txtsucu.Name = "txtsucu"
        Me.txtsucu.Size = New System.Drawing.Size(193, 20)
        Me.txtsucu.TabIndex = 4
        '
        'txtpre
        '
        Me.txtpre.Location = New System.Drawing.Point(85, 91)
        Me.txtpre.Name = "txtpre"
        Me.txtpre.Size = New System.Drawing.Size(193, 20)
        Me.txtpre.TabIndex = 3
        '
        'txtnom
        '
        Me.txtnom.Location = New System.Drawing.Point(85, 54)
        Me.txtnom.Name = "txtnom"
        Me.txtnom.Size = New System.Drawing.Size(193, 20)
        Me.txtnom.TabIndex = 2
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(85, 19)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(193, 20)
        Me.txtid.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Sucursal:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Presupuesto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo:"
        '
        'Lista
        '
        Me.Lista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lista.Controls.Add(Me.GridPresupuestos)
        Me.Lista.Location = New System.Drawing.Point(12, 42)
        Me.Lista.Name = "Lista"
        Me.Lista.Size = New System.Drawing.Size(512, 354)
        Me.Lista.TabIndex = 5
        Me.Lista.TabStop = False
        '
        'GridPresupuestos
        '
        Me.GridPresupuestos.AllowUserToAddRows = False
        Me.GridPresupuestos.AllowUserToDeleteRows = False
        Me.GridPresupuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPresupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridPresupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridPresupuestos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.GridPresupuestos.Location = New System.Drawing.Point(3, 16)
        Me.GridPresupuestos.Name = "GridPresupuestos"
        Me.GridPresupuestos.ReadOnly = True
        Me.GridPresupuestos.Size = New System.Drawing.Size(506, 335)
        Me.GridPresupuestos.TabIndex = 0
        '
        'Presupuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 408)
        Me.Controls.Add(Me.Editar)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Lista)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Presupuesto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Presupuestos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Editar.ResumeLayout(False)
        Me.Editar.PerformLayout()
        Me.Lista.ResumeLayout(False)
        CType(Me.GridPresupuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnArchivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Editar As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumReg As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtnom As System.Windows.Forms.TextBox
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtsucu As System.Windows.Forms.TextBox
    Friend WithEvents txtpre As System.Windows.Forms.TextBox
    Friend WithEvents Lista As System.Windows.Forms.GroupBox
    Friend WithEvents GridPresupuestos As System.Windows.Forms.DataGridView
End Class
