<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetallePresupuestos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetallePresupuestos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtcveFin = New System.Windows.Forms.MaskedTextBox
        Me.txtcveIni = New System.Windows.Forms.MaskedTextBox
        Me.txtDepartamento = New System.Windows.Forms.MaskedTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Fin = New System.Windows.Forms.DateTimePicker
        Me.Inicio = New System.Windows.Forms.DateTimePicker
        Me.GridPresupuestos = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me._grpCBuquedas.SuspendLayout()
        CType(Me.GridPresupuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(584, 39)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 36)
        Me.ToolStripButton1.Tag = "Exportar a Excel"
        Me.ToolStripButton1.Text = "Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        '_grpCBuquedas
        '
        Me._grpCBuquedas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._grpCBuquedas.Controls.Add(Me.Label4)
        Me._grpCBuquedas.Controls.Add(Me.Label3)
        Me._grpCBuquedas.Controls.Add(Me.Label2)
        Me._grpCBuquedas.Controls.Add(Me.txtcveFin)
        Me._grpCBuquedas.Controls.Add(Me.txtcveIni)
        Me._grpCBuquedas.Controls.Add(Me.txtDepartamento)
        Me._grpCBuquedas.Controls.Add(Me.Label5)
        Me._grpCBuquedas.Controls.Add(Me.Label1)
        Me._grpCBuquedas.Controls.Add(Me.Fin)
        Me._grpCBuquedas.Controls.Add(Me.Inicio)
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 42)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(560, 102)
        Me._grpCBuquedas.TabIndex = 17
        Me._grpCBuquedas.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(101, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Cuentas:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(106, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fechas:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Departamento:"
        '
        'txtcveFin
        '
        Me.txtcveFin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtcveFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcveFin.Location = New System.Drawing.Point(339, 68)
        Me.txtcveFin.Name = "txtcveFin"
        Me.txtcveFin.ReadOnly = True
        Me.txtcveFin.Size = New System.Drawing.Size(142, 21)
        Me.txtcveFin.TabIndex = 1
        Me.txtcveFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcveIni
        '
        Me.txtcveIni.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtcveIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcveIni.Location = New System.Drawing.Point(168, 68)
        Me.txtcveIni.Name = "txtcveIni"
        Me.txtcveIni.ReadOnly = True
        Me.txtcveIni.Size = New System.Drawing.Size(142, 21)
        Me.txtcveIni.TabIndex = 1
        Me.txtcveIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartamento.Location = New System.Drawing.Point(168, 18)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(313, 21)
        Me.txtDepartamento.TabIndex = 1
        Me.txtDepartamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(317, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "a"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(316, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "al"
        '
        'Fin
        '
        Me.Fin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Fin.Enabled = False
        Me.Fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fin.Location = New System.Drawing.Point(339, 44)
        Me.Fin.Name = "Fin"
        Me.Fin.Size = New System.Drawing.Size(142, 21)
        Me.Fin.TabIndex = 2
        '
        'Inicio
        '
        Me.Inicio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Inicio.Enabled = False
        Me.Inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Inicio.Location = New System.Drawing.Point(168, 44)
        Me.Inicio.Name = "Inicio"
        Me.Inicio.Size = New System.Drawing.Size(142, 21)
        Me.Inicio.TabIndex = 2
        '
        'GridPresupuestos
        '
        Me.GridPresupuestos.AllowUserToAddRows = False
        Me.GridPresupuestos.AllowUserToDeleteRows = False
        Me.GridPresupuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPresupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridPresupuestos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridPresupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridPresupuestos.Location = New System.Drawing.Point(12, 150)
        Me.GridPresupuestos.Name = "GridPresupuestos"
        Me.GridPresupuestos.ReadOnly = True
        Me.GridPresupuestos.Size = New System.Drawing.Size(560, 212)
        Me.GridPresupuestos.TabIndex = 18
        '
        'frmDetallePresupuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 374)
        Me.Controls.Add(Me.GridPresupuestos)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDetallePresupuestos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        CType(Me.GridPresupuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents txtDepartamento As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GridPresupuestos As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcveFin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtcveIni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
