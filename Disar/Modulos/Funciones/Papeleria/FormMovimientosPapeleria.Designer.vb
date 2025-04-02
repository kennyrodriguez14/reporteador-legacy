<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMovimientosPapeleria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMovimientosPapeleria))
        Me.DataPendientes = New System.Windows.Forms.DataGridView
        Me.GroupPendientes = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupMovimientos = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.BtnFiltrar = New System.Windows.Forms.Button
        Me.ComboAlmacen = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DataMovimientos = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        CType(Me.DataPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPendientes.SuspendLayout()
        Me.GroupMovimientos.SuspendLayout()
        CType(Me.DataMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataPendientes
        '
        Me.DataPendientes.AllowUserToAddRows = False
        Me.DataPendientes.AllowUserToDeleteRows = False
        Me.DataPendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataPendientes.Location = New System.Drawing.Point(6, 55)
        Me.DataPendientes.Name = "DataPendientes"
        Me.DataPendientes.ReadOnly = True
        Me.DataPendientes.Size = New System.Drawing.Size(1019, 354)
        Me.DataPendientes.TabIndex = 0
        '
        'GroupPendientes
        '
        Me.GroupPendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPendientes.Controls.Add(Me.Button1)
        Me.GroupPendientes.Controls.Add(Me.DataPendientes)
        Me.GroupPendientes.Location = New System.Drawing.Point(12, 12)
        Me.GroupPendientes.Name = "GroupPendientes"
        Me.GroupPendientes.Size = New System.Drawing.Size(1032, 418)
        Me.GroupPendientes.TabIndex = 2
        Me.GroupPendientes.TabStop = False
        Me.GroupPendientes.Text = "Solicitudes Pendientes"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(933, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Ver Histórico"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupMovimientos
        '
        Me.GroupMovimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupMovimientos.Controls.Add(Me.Label2)
        Me.GroupMovimientos.Controls.Add(Me.Button2)
        Me.GroupMovimientos.Controls.Add(Me.BtnFiltrar)
        Me.GroupMovimientos.Controls.Add(Me.ComboAlmacen)
        Me.GroupMovimientos.Controls.Add(Me.Label4)
        Me.GroupMovimientos.Controls.Add(Me.Label1)
        Me.GroupMovimientos.Controls.Add(Me.DateTimePicker1)
        Me.GroupMovimientos.Controls.Add(Me.DataMovimientos)
        Me.GroupMovimientos.Controls.Add(Me.DateTimePicker2)
        Me.GroupMovimientos.Location = New System.Drawing.Point(12, 12)
        Me.GroupMovimientos.Name = "GroupMovimientos"
        Me.GroupMovimientos.Size = New System.Drawing.Size(1032, 418)
        Me.GroupMovimientos.TabIndex = 3
        Me.GroupMovimientos.TabStop = False
        Me.GroupMovimientos.Text = "Movimientos al Inventario"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(933, 26)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(93, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Ver Solicitudes"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.Location = New System.Drawing.Point(692, 27)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.BtnFiltrar.TabIndex = 10
        Me.BtnFiltrar.Text = "Filtrar"
        Me.BtnFiltrar.UseVisualStyleBackColor = True
        '
        'ComboAlmacen
        '
        Me.ComboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAlmacen.FormattingEnabled = True
        Me.ComboAlmacen.Items.AddRange(New Object() {"TODAS", "SPS", "SRC", "SAB", "TGU", "SR AGRO SRC"})
        Me.ComboAlmacen.Location = New System.Drawing.Point(525, 28)
        Me.ComboAlmacen.Name = "ComboAlmacen"
        Me.ComboAlmacen.Size = New System.Drawing.Size(155, 21)
        Me.ComboAlmacen.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(468, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Almacén:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "De:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(31, 28)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'DataMovimientos
        '
        Me.DataMovimientos.AllowUserToAddRows = False
        Me.DataMovimientos.AllowUserToDeleteRows = False
        Me.DataMovimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataMovimientos.Location = New System.Drawing.Point(7, 55)
        Me.DataMovimientos.Name = "DataMovimientos"
        Me.DataMovimientos.ReadOnly = True
        Me.DataMovimientos.Size = New System.Drawing.Size(1019, 354)
        Me.DataMovimientos.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(237, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "A:"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(254, 28)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 12
        '
        'FormMovimientosPapeleria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 442)
        Me.Controls.Add(Me.GroupPendientes)
        Me.Controls.Add(Me.GroupMovimientos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMovimientosPapeleria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos a Papelería"
        CType(Me.DataPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPendientes.ResumeLayout(False)
        Me.GroupMovimientos.ResumeLayout(False)
        Me.GroupMovimientos.PerformLayout()
        CType(Me.DataMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents GroupPendientes As System.Windows.Forms.GroupBox
    Friend WithEvents GroupMovimientos As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataMovimientos As System.Windows.Forms.DataGridView
    Friend WithEvents BtnFiltrar As System.Windows.Forms.Button
    Friend WithEvents ComboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
End Class
