<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Multialmacen_DIMOSA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Multialmacen_DIMOSA))
        Me.txtlinea = New System.Windows.Forms.TextBox
        Me.lblsucursal = New System.Windows.Forms.Label
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox
        Me.lblbus = New System.Windows.Forms.Label
        Me._btnGenerar = New System.Windows.Forms.Button
        Me.cmbsucursal = New System.Windows.Forms.ComboBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me._gridmultialmacen = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me._grpCBuquedas.SuspendLayout()
        CType(Me._gridmultialmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtlinea
        '
        Me.txtlinea.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtlinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtlinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlinea.Location = New System.Drawing.Point(418, 21)
        Me.txtlinea.Name = "txtlinea"
        Me.txtlinea.Size = New System.Drawing.Size(296, 21)
        Me.txtlinea.TabIndex = 3
        '
        'lblsucursal
        '
        Me.lblsucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblsucursal.AutoSize = True
        Me.lblsucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsucursal.Location = New System.Drawing.Point(176, 21)
        Me.lblsucursal.Name = "lblsucursal"
        Me.lblsucursal.Size = New System.Drawing.Size(58, 15)
        Me.lblsucursal.TabIndex = 0
        Me.lblsucursal.Text = "Almacen:"
        '
        '_grpCBuquedas
        '
        Me._grpCBuquedas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._grpCBuquedas.Controls.Add(Me.txtlinea)
        Me._grpCBuquedas.Controls.Add(Me.lblsucursal)
        Me._grpCBuquedas.Controls.Add(Me.lblbus)
        Me._grpCBuquedas.Controls.Add(Me._btnGenerar)
        Me._grpCBuquedas.Controls.Add(Me.cmbsucursal)
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 51)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(996, 51)
        Me._grpCBuquedas.TabIndex = 19
        Me._grpCBuquedas.TabStop = False
        Me._grpCBuquedas.Text = "Criterios de Busqueda"
        '
        'lblbus
        '
        Me.lblbus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblbus.AutoSize = True
        Me.lblbus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbus.Location = New System.Drawing.Point(358, 25)
        Me.lblbus.Name = "lblbus"
        Me.lblbus.Size = New System.Drawing.Size(41, 15)
        Me.lblbus.TabIndex = 0
        Me.lblbus.Text = "Linea:"
        '
        '_btnGenerar
        '
        Me._btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._btnGenerar.Location = New System.Drawing.Point(744, 20)
        Me._btnGenerar.Name = "_btnGenerar"
        Me._btnGenerar.Size = New System.Drawing.Size(74, 24)
        Me._btnGenerar.TabIndex = 4
        Me._btnGenerar.Text = "Generar"
        Me._btnGenerar.UseVisualStyleBackColor = True
        '
        'cmbsucursal
        '
        Me.cmbsucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbsucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsucursal.DropDownWidth = 200
        Me.cmbsucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsucursal.FormattingEnabled = True
        Me.cmbsucursal.Location = New System.Drawing.Point(236, 19)
        Me.cmbsucursal.Name = "cmbsucursal"
        Me.cmbsucursal.Size = New System.Drawing.Size(91, 23)
        Me.cmbsucursal.TabIndex = 1
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        '_gridmultialmacen
        '
        Me._gridmultialmacen.AllowUserToAddRows = False
        Me._gridmultialmacen.AllowUserToDeleteRows = False
        Me._gridmultialmacen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._gridmultialmacen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me._gridmultialmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridmultialmacen.Location = New System.Drawing.Point(12, 108)
        Me._gridmultialmacen.Name = "_gridmultialmacen"
        Me._gridmultialmacen.ReadOnly = True
        Me._gridmultialmacen.Size = New System.Drawing.Size(996, 434)
        Me._gridmultialmacen.TabIndex = 20
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1020, 39)
        Me.ToolStrip1.TabIndex = 18
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
        'Multialmacen_DIMOSA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 545)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me._gridmultialmacen)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Multialmacen_DIMOSA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Multialmacen DIMOSA"
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        CType(Me._gridmultialmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtlinea As System.Windows.Forms.TextBox
    Friend WithEvents lblsucursal As System.Windows.Forms.Label
    Friend WithEvents _grpCBuquedas As System.Windows.Forms.GroupBox
    Friend WithEvents lblbus As System.Windows.Forms.Label
    Friend WithEvents _btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmbsucursal As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _gridmultialmacen As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents _Archivo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
