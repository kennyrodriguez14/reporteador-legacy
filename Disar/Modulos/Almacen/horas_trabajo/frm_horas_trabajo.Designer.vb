<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_horas_trabajo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_horas_trabajo))
        Me.tiempo = New System.Windows.Forms.Timer(Me.components)
        Me.grdHoras = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFecha = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSalida = New System.Windows.Forms.Button()
        Me.btnEntrada = New System.Windows.Forms.Button()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.cmbAlmacen = New System.Windows.Forms.ComboBox()
        CType(Me.grdHoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tiempo
        '
        Me.tiempo.Enabled = True
        '
        'grdHoras
        '
        Me.grdHoras.AllowUserToAddRows = False
        Me.grdHoras.AllowUserToDeleteRows = False
        Me.grdHoras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdHoras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdHoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdHoras.Location = New System.Drawing.Point(13, 163)
        Me.grdHoras.Name = "grdHoras"
        Me.grdHoras.ReadOnly = True
        Me.grdHoras.Size = New System.Drawing.Size(425, 175)
        Me.grdHoras.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha:"
        '
        'cmbFecha
        '
        Me.cmbFecha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFecha.Location = New System.Drawing.Point(74, 109)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.Size = New System.Drawing.Size(364, 20)
        Me.cmbFecha.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(450, 39)
        Me.ToolStrip1.TabIndex = 27
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Disar.My.Resources.Resources.File_Blue
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(93, 36)
        Me.ToolStripDropDownButton1.Text = "Archivo"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.NuevoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(196, 38)
        Me.NuevoToolStripMenuItem.Text = "Nuevo"
        '
        'btnSalida
        '
        Me.btnSalida.Image = Global.Disar.My.Resources.Resources.Alarm_Clock_red_32
        Me.btnSalida.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalida.Location = New System.Drawing.Point(285, 42)
        Me.btnSalida.Name = "btnSalida"
        Me.btnSalida.Size = New System.Drawing.Size(153, 52)
        Me.btnSalida.TabIndex = 2
        Me.btnSalida.Text = "Salida"
        Me.btnSalida.UseVisualStyleBackColor = True
        '
        'btnEntrada
        '
        Me.btnEntrada.Image = Global.Disar.My.Resources.Resources.Alarm_Clock_green_32
        Me.btnEntrada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEntrada.Location = New System.Drawing.Point(13, 42)
        Me.btnEntrada.Name = "btnEntrada"
        Me.btnEntrada.Size = New System.Drawing.Size(153, 52)
        Me.btnEntrada.TabIndex = 1
        Me.btnEntrada.Text = "Entrada"
        Me.btnEntrada.UseVisualStyleBackColor = True
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Location = New System.Drawing.Point(16, 140)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(51, 13)
        Me.lblAlmacen.TabIndex = 28
        Me.lblAlmacen.Text = "Sucursal:"
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlmacen.FormattingEnabled = True
        Me.cmbAlmacen.Location = New System.Drawing.Point(74, 136)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(364, 21)
        Me.cmbAlmacen.TabIndex = 29
        '
        'frm_horas_trabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 350)
        Me.Controls.Add(Me.cmbAlmacen)
        Me.Controls.Add(Me.lblAlmacen)
        Me.Controls.Add(Me.btnSalida)
        Me.Controls.Add(Me.btnEntrada)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.cmbFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdHoras)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_horas_trabajo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Horas de Trabajo"
        CType(Me.grdHoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tiempo As System.Windows.Forms.Timer
    Friend WithEvents grdHoras As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbFecha As System.Windows.Forms.DateTimePicker
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEntrada As System.Windows.Forms.Button
    Friend WithEvents btnSalida As System.Windows.Forms.Button
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacen As System.Windows.Forms.ComboBox
End Class
