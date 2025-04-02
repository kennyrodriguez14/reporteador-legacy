<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventarios_SR_AGRO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventarios_SR_AGRO))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._gridInventarios = New System.Windows.Forms.DataGridView
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.lblbus = New System.Windows.Forms.Label
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.ToolStrip1.SuspendLayout()
        CType(Me._gridInventarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._grpCBuquedas.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1020, 39)
        Me.ToolStrip1.TabIndex = 13
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        '_Archivo
        '
        Me._Archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAExcelToolStripMenuItem, Me.CerrarToolStripMenuItem})
        Me._Archivo.Image = Global.Disar.My.Resources.Resources.Opciones
        Me._Archivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me._Archivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._Archivo.Name = "_Archivo"
        Me._Archivo.Size = New System.Drawing.Size(100, 36)
        Me._Archivo.Text = "Acciones"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Excel_32
        Me.ExportarAExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(171, 38)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar a Excel"
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.CerrarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(171, 38)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        '_gridInventarios
        '
        Me._gridInventarios.AllowUserToAddRows = False
        Me._gridInventarios.AllowUserToDeleteRows = False
        Me._gridInventarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gridInventarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me._gridInventarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridInventarios.Location = New System.Drawing.Point(12, 106)
        Me._gridInventarios.Name = "_gridInventarios"
        Me._gridInventarios.ReadOnly = True
        Me._gridInventarios.Size = New System.Drawing.Size(996, 404)
        Me._gridInventarios.TabIndex = 16
        '
        '_grpCBuquedas
        '
        Me._grpCBuquedas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._grpCBuquedas.Controls.Add(Me.txtCodigo)
        Me._grpCBuquedas.Controls.Add(Me.lblbus)
        Me._grpCBuquedas.Controls.Add(Me._btnGenerar)
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 49)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(996, 51)
        Me._grpCBuquedas.TabIndex = 15
        Me._grpCBuquedas.TabStop = False
        Me._grpCBuquedas.Text = "Criterios de Busqueda"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(53, 21)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(84, 21)
        Me.txtCodigo.TabIndex = 3
        '
        'lblbus
        '
        Me.lblbus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblbus.AutoSize = True
        Me.lblbus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbus.Location = New System.Drawing.Point(6, 23)
        Me.lblbus.Name = "lblbus"
        Me.lblbus.Size = New System.Drawing.Size(41, 15)
        Me.lblbus.TabIndex = 0
        Me.lblbus.Text = "Linea:"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(143, 21)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(74, 21)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'Inventarios_SR_AGRO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 522)
        Me.Controls.Add(Me._gridInventarios)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Inventarios_SR_AGRO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventarios_SR_AGRO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me._gridInventarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _gridInventarios As System.Windows.Forms.DataGridView
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblbus As System.Windows.Forms.Label
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
End Class
