<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigPaletizado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfigPaletizado))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnAceptar = New System.Windows.Forms.Button
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.CmbAlmacen = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdPaletizado = New System.Windows.Forms.DataGridView
        Me.BtnFiltrar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextAnterior = New System.Windows.Forms.TextBox
        Me.TextNuevo = New System.Windows.Forms.TextBox
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColNombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColPaletizadoAnterior = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColPaletizadoNuevo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPaletizado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.TextNuevo)
        Me.GroupBox1.Controls.Add(Me.TextAnterior)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.BtnFiltrar)
        Me.GroupBox1.Controls.Add(Me.grdPaletizado)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbAlmacen)
        Me.GroupBox1.Controls.Add(Me.BtnCancelar)
        Me.GroupBox1.Controls.Add(Me.BtnAceptar)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 476)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAceptar.Location = New System.Drawing.Point(644, 418)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptar.TabIndex = 0
        Me.BtnAceptar.Text = "Guardar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(644, 447)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelar.TabIndex = 0
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAlmacen.FormattingEnabled = True
        Me.CmbAlmacen.Items.AddRange(New Object() {"SPS", "SRC", "TOCOA"})
        Me.CmbAlmacen.Location = New System.Drawing.Point(77, 19)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(247, 21)
        Me.CmbAlmacen.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Almacén"
        '
        'grdPaletizado
        '
        Me.grdPaletizado.AllowUserToAddRows = False
        Me.grdPaletizado.AllowUserToDeleteRows = False
        Me.grdPaletizado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdPaletizado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPaletizado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.ColNombre, Me.ColPaletizadoAnterior, Me.ColPaletizadoNuevo})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdPaletizado.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdPaletizado.Location = New System.Drawing.Point(26, 46)
        Me.grdPaletizado.Name = "grdPaletizado"
        Me.grdPaletizado.Size = New System.Drawing.Size(693, 366)
        Me.grdPaletizado.TabIndex = 3
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.Location = New System.Drawing.Point(330, 17)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.BtnFiltrar.TabIndex = 4
        Me.BtnFiltrar.Text = "Filtrar"
        Me.BtnFiltrar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 427)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Total anterior:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 452)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Total nuevo:"
        '
        'TextAnterior
        '
        Me.TextAnterior.Enabled = False
        Me.TextAnterior.Location = New System.Drawing.Point(104, 424)
        Me.TextAnterior.Name = "TextAnterior"
        Me.TextAnterior.Size = New System.Drawing.Size(107, 20)
        Me.TextAnterior.TabIndex = 6
        '
        'TextNuevo
        '
        Me.TextNuevo.Enabled = False
        Me.TextNuevo.Location = New System.Drawing.Point(104, 449)
        Me.TextNuevo.Name = "TextNuevo"
        Me.TextNuevo.Size = New System.Drawing.Size(107, 20)
        Me.TextNuevo.TabIndex = 6
        '
        'colID
        '
        Me.colID.HeaderText = "Nº Linea"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        '
        'ColNombre
        '
        Me.ColNombre.HeaderText = "Linea"
        Me.ColNombre.Name = "ColNombre"
        Me.ColNombre.ReadOnly = True
        '
        'ColPaletizadoAnterior
        '
        Me.ColPaletizadoAnterior.HeaderText = "Paletizado Anterior"
        Me.ColPaletizadoAnterior.Name = "ColPaletizadoAnterior"
        Me.ColPaletizadoAnterior.ReadOnly = True
        '
        'ColPaletizadoNuevo
        '
        Me.ColPaletizadoNuevo.HeaderText = "Paletizado Nuevo"
        Me.ColPaletizadoNuevo.Name = "ColPaletizadoNuevo"
        '
        'FrmConfigPaletizado
        '
        Me.AcceptButton = Me.BtnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancelar
        Me.ClientSize = New System.Drawing.Size(750, 501)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmConfigPaletizado"
        Me.Text = "Configurar Paletizado"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdPaletizado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents grdPaletizado As System.Windows.Forms.DataGridView
    Friend WithEvents BtnFiltrar As System.Windows.Forms.Button
    Friend WithEvents TextNuevo As System.Windows.Forms.TextBox
    Friend WithEvents TextAnterior As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPaletizadoAnterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPaletizadoNuevo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
