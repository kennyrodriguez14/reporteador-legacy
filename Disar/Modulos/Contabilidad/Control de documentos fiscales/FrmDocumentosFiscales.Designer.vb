<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDocumentosFiscales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDocumentosFiscales))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BtnEditar = New System.Windows.Forms.Button
        Me.BtnMostrar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboDocumento = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DataDatos)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1035, 346)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataDatos.Location = New System.Drawing.Point(3, 16)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataDatos.Size = New System.Drawing.Size(1029, 327)
        Me.DataDatos.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtnEditar)
        Me.GroupBox2.Controls.Add(Me.BtnMostrar)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.ComboDocumento)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1035, 73)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'BtnEditar
        '
        Me.BtnEditar.Location = New System.Drawing.Point(448, 26)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(112, 23)
        Me.BtnEditar.TabIndex = 3
        Me.BtnEditar.Text = "Editar Seleccionado"
        Me.BtnEditar.UseVisualStyleBackColor = True
        '
        'BtnMostrar
        '
        Me.BtnMostrar.Location = New System.Drawing.Point(367, 26)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(75, 23)
        Me.BtnMostrar.TabIndex = 2
        Me.BtnMostrar.Text = "Mostrar"
        Me.BtnMostrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Documento:"
        '
        'ComboDocumento
        '
        Me.ComboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDocumento.FormattingEnabled = True
        Me.ComboDocumento.Items.AddRange(New Object() {"Facturas", "Devoluciones", "Compras", "Devoluciones de Compra", "Remisiones"})
        Me.ComboDocumento.Location = New System.Drawing.Point(101, 27)
        Me.ComboDocumento.Name = "ComboDocumento"
        Me.ComboDocumento.Size = New System.Drawing.Size(257, 21)
        Me.ComboDocumento.TabIndex = 0
        '
        'FrmDocumentosFiscales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 450)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmDocumentosFiscales"
        Me.Text = "Control de Documentos Fiscales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents BtnEditar As System.Windows.Forms.Button
End Class
