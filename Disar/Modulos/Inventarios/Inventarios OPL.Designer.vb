<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventarios_OPL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventarios_OPL))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me._grpCBuquedas = New System.Windows.Forms.GroupBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblsucursal = New System.Windows.Forms.Label()
        Me.lblbus = New System.Windows.Forms.Label()
        Me._btnGenerar = New System.Windows.Forms.Button()
        Me.cmbsucursal = New System.Windows.Forms.ComboBox()
        Me.cmbTbusqueda = New System.Windows.Forms.ComboBox()
        Me._gridInventarios = New System.Windows.Forms.DataGridView()
        Me.DataTemp = New System.Windows.Forms.DataGridView()
        Me._Archivo = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me._grpCBuquedas.SuspendLayout()
        CType(Me._gridInventarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Archivo, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1020, 39)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
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
        Me._grpCBuquedas.Controls.Add(Me.txtCodigo)
        Me._grpCBuquedas.Controls.Add(Me.lblsucursal)
        Me._grpCBuquedas.Controls.Add(Me.lblbus)
        Me._grpCBuquedas.Controls.Add(Me._btnGenerar)
        Me._grpCBuquedas.Controls.Add(Me.cmbsucursal)
        Me._grpCBuquedas.Controls.Add(Me.cmbTbusqueda)
        Me._grpCBuquedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._grpCBuquedas.Location = New System.Drawing.Point(12, 48)
        Me._grpCBuquedas.Name = "_grpCBuquedas"
        Me._grpCBuquedas.Size = New System.Drawing.Size(996, 51)
        Me._grpCBuquedas.TabIndex = 17
        Me._grpCBuquedas.TabStop = False
        Me._grpCBuquedas.Text = "Criterios de Busqueda"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(501, 21)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(234, 21)
        Me.txtCodigo.TabIndex = 3
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
        Me.lblsucursal.Text = "Sucursal:"
        '
        'lblbus
        '
        Me.lblbus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblbus.AutoSize = True
        Me.lblbus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbus.Location = New System.Drawing.Point(330, 21)
        Me.lblbus.Name = "lblbus"
        Me.lblbus.Size = New System.Drawing.Size(69, 15)
        Me.lblbus.TabIndex = 0
        Me.lblbus.Text = "Buscar por:"
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
        Me.cmbsucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsucursal.FormattingEnabled = True
        Me.cmbsucursal.Items.AddRange(New Object() {"SPS", "SRC", "Saba", "Tegucigalpa"})
        Me.cmbsucursal.Location = New System.Drawing.Point(236, 19)
        Me.cmbsucursal.Name = "cmbsucursal"
        Me.cmbsucursal.Size = New System.Drawing.Size(91, 23)
        Me.cmbsucursal.TabIndex = 1
        '
        'cmbTbusqueda
        '
        Me.cmbTbusqueda.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbTbusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTbusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTbusqueda.FormattingEnabled = True
        Me.cmbTbusqueda.Items.AddRange(New Object() {"TODOS", "CODIGO", "NOMBRE"})
        Me.cmbTbusqueda.Location = New System.Drawing.Point(401, 19)
        Me.cmbTbusqueda.Name = "cmbTbusqueda"
        Me.cmbTbusqueda.Size = New System.Drawing.Size(91, 23)
        Me.cmbTbusqueda.TabIndex = 2
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
        Me._gridInventarios.Location = New System.Drawing.Point(12, 105)
        Me._gridInventarios.Name = "_gridInventarios"
        Me._gridInventarios.ReadOnly = True
        Me._gridInventarios.Size = New System.Drawing.Size(996, 434)
        Me._gridInventarios.TabIndex = 18
        '
        'DataTemp
        '
        Me.DataTemp.AllowUserToAddRows = False
        Me.DataTemp.AllowUserToDeleteRows = False
        Me.DataTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataTemp.Location = New System.Drawing.Point(55, 240)
        Me.DataTemp.Name = "DataTemp"
        Me.DataTemp.ReadOnly = True
        Me.DataTemp.Size = New System.Drawing.Size(457, 123)
        Me.DataTemp.TabIndex = 19
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
        'Inventarios_OPL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 545)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me._grpCBuquedas)
        Me.Controls.Add(Me._gridInventarios)
        Me.Controls.Add(Me.DataTemp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Inventarios_OPL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventarios OPL"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me._grpCBuquedas.ResumeLayout(False)
        Me._grpCBuquedas.PerformLayout()
        CType(Me._gridInventarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents _Archivo As ToolStripDropDownButton
    Friend WithEvents ExportarAExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents _grpCBuquedas As GroupBox
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents lblsucursal As Label
    Friend WithEvents lblbus As Label
    Friend WithEvents _btnGenerar As Button
    Friend WithEvents cmbsucursal As ComboBox
    Friend WithEvents cmbTbusqueda As ComboBox
    Friend WithEvents _gridInventarios As DataGridView
    Friend WithEvents DataTemp As DataGridView
End Class
