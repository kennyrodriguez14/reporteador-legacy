<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Presupuestos_Deptos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Presupuestos_Deptos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnEditar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.grpListado = New System.Windows.Forms.GroupBox
        Me.gridPresupuestos = New System.Windows.Forms.DataGridView
        Me.grpInsertar = New System.Windows.Forms.GroupBox
        Me.txtCuenta = New System.Windows.Forms.TextBox
        Me.txtDepartamento = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPresupuesto = New System.Windows.Forms.TextBox
        Me.ToolStrip1.SuspendLayout()
        Me.grpListado.SuspendLayout()
        CType(Me.gridPresupuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInsertar.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.ToolStripSeparator1, Me.btnEditar, Me.ToolStripSeparator2, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(450, 39)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnNuevo.Image = Global.Disar.My.Resources.Resources.addpresdepto
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(94, 36)
        Me.btnNuevo.Text = "Agregar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btnEditar
        '
        Me.btnEditar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnEditar.Image = Global.Disar.My.Resources.Resources.File_Edit_32
        Me.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(101, 36)
        Me.btnEditar.Text = "Modificar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.Delete_32
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(93, 36)
        Me.ToolStripButton1.Text = "Eliminar"
        '
        'grpListado
        '
        Me.grpListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpListado.Controls.Add(Me.gridPresupuestos)
        Me.grpListado.Location = New System.Drawing.Point(12, 42)
        Me.grpListado.Name = "grpListado"
        Me.grpListado.Size = New System.Drawing.Size(426, 306)
        Me.grpListado.TabIndex = 1
        Me.grpListado.TabStop = False
        Me.grpListado.Text = "Listado de Presupuestos"
        '
        'gridPresupuestos
        '
        Me.gridPresupuestos.AllowUserToAddRows = False
        Me.gridPresupuestos.AllowUserToDeleteRows = False
        Me.gridPresupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridPresupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridPresupuestos.DefaultCellStyle = DataGridViewCellStyle1
        Me.gridPresupuestos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPresupuestos.Location = New System.Drawing.Point(3, 16)
        Me.gridPresupuestos.Name = "gridPresupuestos"
        Me.gridPresupuestos.ReadOnly = True
        Me.gridPresupuestos.Size = New System.Drawing.Size(420, 287)
        Me.gridPresupuestos.TabIndex = 1
        '
        'grpInsertar
        '
        Me.grpInsertar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grpInsertar.Controls.Add(Me.txtPresupuesto)
        Me.grpInsertar.Controls.Add(Me.txtCuenta)
        Me.grpInsertar.Controls.Add(Me.Label5)
        Me.grpInsertar.Controls.Add(Me.txtDepartamento)
        Me.grpInsertar.Controls.Add(Me.Label4)
        Me.grpInsertar.Controls.Add(Me.Label2)
        Me.grpInsertar.Controls.Add(Me.txtCodigo)
        Me.grpInsertar.Controls.Add(Me.Label1)
        Me.grpInsertar.Controls.Add(Me.btnCancelar)
        Me.grpInsertar.Controls.Add(Me.btnAceptar)
        Me.grpInsertar.Location = New System.Drawing.Point(71, 121)
        Me.grpInsertar.Name = "grpInsertar"
        Me.grpInsertar.Size = New System.Drawing.Size(313, 178)
        Me.grpInsertar.TabIndex = 3
        Me.grpInsertar.TabStop = False
        Me.grpInsertar.Text = "Ingreso de Presupuestos"
        Me.grpInsertar.Visible = False
        '
        'txtCuenta
        '
        Me.txtCuenta.AutoCompleteCustomSource.AddRange(New String() {"ADMINISTRACION", "IT", "LOGISTICA"})
        Me.txtCuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCuenta.Location = New System.Drawing.Point(114, 86)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(180, 20)
        Me.txtCuenta.TabIndex = 3
        Me.txtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDepartamento
        '
        Me.txtDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartamento.Location = New System.Drawing.Point(114, 60)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(180, 20)
        Me.txtDepartamento.TabIndex = 2
        Me.txtDepartamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(57, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Cuenta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Departamento:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(114, 31)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(180, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Codigo:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(232, 150)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(6, 150)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Presupuesto:"
        '
        'txtPresupuesto
        '
        Me.txtPresupuesto.AutoCompleteCustomSource.AddRange(New String() {"ADMINISTRACION", "IT", "LOGISTICA"})
        Me.txtPresupuesto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPresupuesto.Location = New System.Drawing.Point(114, 112)
        Me.txtPresupuesto.Name = "txtPresupuesto"
        Me.txtPresupuesto.Size = New System.Drawing.Size(180, 20)
        Me.txtPresupuesto.TabIndex = 4
        Me.txtPresupuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Presupuestos_Deptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 360)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grpInsertar)
        Me.Controls.Add(Me.grpListado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Presupuestos_Deptos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Presupuestos por Departamentos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpListado.ResumeLayout(False)
        CType(Me.gridPresupuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInsertar.ResumeLayout(False)
        Me.grpInsertar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grpListado As System.Windows.Forms.GroupBox
    Friend WithEvents gridPresupuestos As System.Windows.Forms.DataGridView
    Friend WithEvents grpInsertar As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtPresupuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
