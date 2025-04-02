<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SellOut_Colgate_Archivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SellOut_Colgate_Archivos))
        Me._gridChain4 = New System.Windows.Forms.DataGridView
        Me._gridSalesTeam = New System.Windows.Forms.DataGridView
        Me.BuscarCarpeta = New System.Windows.Forms.FolderBrowserDialog
        Me._gridRoutmast4 = New System.Windows.Forms.DataGridView
        Me._gridCustMast = New System.Windows.Forms.DataGridView
        Me._gridInventry = New System.Windows.Forms.DataGridView
        Me._gridSales = New System.Windows.Forms.DataGridView
        Me._gridDisteffe = New System.Windows.Forms.DataGridView
        Me.grpDestino = New System.Windows.Forms.GroupBox
        Me.btnDestino = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblInicio = New System.Windows.Forms.Label
        Me._cmbF2 = New System.Windows.Forms.DateTimePicker
        Me._cmbF1 = New System.Windows.Forms.DateTimePicker
        Me.Ruta = New System.Windows.Forms.Label
        Me.lblDestino = New System.Windows.Forms.Label
        Me.btnGenerar = New System.Windows.Forms.Button
        CType(Me._gridChain4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridSalesTeam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridRoutmast4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridCustMast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridInventry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridSales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._gridDisteffe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDestino.SuspendLayout()
        Me.SuspendLayout()
        '
        '_gridChain4
        '
        Me._gridChain4.AllowUserToAddRows = False
        Me._gridChain4.AllowUserToDeleteRows = False
        Me._gridChain4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridChain4.Location = New System.Drawing.Point(196, 130)
        Me._gridChain4.Name = "_gridChain4"
        Me._gridChain4.ReadOnly = True
        Me._gridChain4.Size = New System.Drawing.Size(83, 27)
        Me._gridChain4.TabIndex = 0
        Me._gridChain4.Visible = False
        '
        '_gridSalesTeam
        '
        Me._gridSalesTeam.AllowUserToAddRows = False
        Me._gridSalesTeam.AllowUserToDeleteRows = False
        Me._gridSalesTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridSalesTeam.Location = New System.Drawing.Point(107, 130)
        Me._gridSalesTeam.Name = "_gridSalesTeam"
        Me._gridSalesTeam.ReadOnly = True
        Me._gridSalesTeam.Size = New System.Drawing.Size(83, 27)
        Me._gridSalesTeam.TabIndex = 2
        Me._gridSalesTeam.Visible = False
        '
        '_gridRoutmast4
        '
        Me._gridRoutmast4.AllowUserToAddRows = False
        Me._gridRoutmast4.AllowUserToDeleteRows = False
        Me._gridRoutmast4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridRoutmast4.Location = New System.Drawing.Point(18, 130)
        Me._gridRoutmast4.Name = "_gridRoutmast4"
        Me._gridRoutmast4.ReadOnly = True
        Me._gridRoutmast4.Size = New System.Drawing.Size(83, 27)
        Me._gridRoutmast4.TabIndex = 6
        Me._gridRoutmast4.Visible = False
        '
        '_gridCustMast
        '
        Me._gridCustMast.AllowUserToAddRows = False
        Me._gridCustMast.AllowUserToDeleteRows = False
        Me._gridCustMast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridCustMast.Location = New System.Drawing.Point(136, 64)
        Me._gridCustMast.Name = "_gridCustMast"
        Me._gridCustMast.ReadOnly = True
        Me._gridCustMast.Size = New System.Drawing.Size(83, 27)
        Me._gridCustMast.TabIndex = 7
        Me._gridCustMast.Visible = False
        '
        '_gridInventry
        '
        Me._gridInventry.AllowUserToAddRows = False
        Me._gridInventry.AllowUserToDeleteRows = False
        Me._gridInventry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridInventry.Location = New System.Drawing.Point(47, 64)
        Me._gridInventry.Name = "_gridInventry"
        Me._gridInventry.ReadOnly = True
        Me._gridInventry.Size = New System.Drawing.Size(83, 27)
        Me._gridInventry.TabIndex = 8
        Me._gridInventry.Visible = False
        '
        '_gridSales
        '
        Me._gridSales.AllowUserToAddRows = False
        Me._gridSales.AllowUserToDeleteRows = False
        Me._gridSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridSales.Location = New System.Drawing.Point(47, 31)
        Me._gridSales.Name = "_gridSales"
        Me._gridSales.ReadOnly = True
        Me._gridSales.Size = New System.Drawing.Size(83, 27)
        Me._gridSales.TabIndex = 9
        Me._gridSales.Visible = False
        '
        '_gridDisteffe
        '
        Me._gridDisteffe.AllowUserToAddRows = False
        Me._gridDisteffe.AllowUserToDeleteRows = False
        Me._gridDisteffe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridDisteffe.Location = New System.Drawing.Point(136, 31)
        Me._gridDisteffe.Name = "_gridDisteffe"
        Me._gridDisteffe.ReadOnly = True
        Me._gridDisteffe.Size = New System.Drawing.Size(83, 27)
        Me._gridDisteffe.TabIndex = 10
        Me._gridDisteffe.Visible = False
        '
        'grpDestino
        '
        Me.grpDestino.Controls.Add(Me.btnDestino)
        Me.grpDestino.Controls.Add(Me.Label1)
        Me.grpDestino.Controls.Add(Me.lblInicio)
        Me.grpDestino.Controls.Add(Me._cmbF2)
        Me.grpDestino.Controls.Add(Me._cmbF1)
        Me.grpDestino.Controls.Add(Me.Ruta)
        Me.grpDestino.Controls.Add(Me.lblDestino)
        Me.grpDestino.Controls.Add(Me.btnGenerar)
        Me.grpDestino.Location = New System.Drawing.Point(16, 12)
        Me.grpDestino.Name = "grpDestino"
        Me.grpDestino.Size = New System.Drawing.Size(263, 199)
        Me.grpDestino.TabIndex = 11
        Me.grpDestino.TabStop = False
        Me.grpDestino.Text = "Criterios"
        '
        'btnDestino
        '
        Me.btnDestino.Location = New System.Drawing.Point(9, 85)
        Me.btnDestino.Name = "btnDestino"
        Me.btnDestino.Size = New System.Drawing.Size(75, 23)
        Me.btnDestino.TabIndex = 3
        Me.btnDestino.Text = "Destino"
        Me.btnDestino.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Fin:"
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Location = New System.Drawing.Point(6, 31)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(35, 13)
        Me.lblInicio.TabIndex = 9
        Me.lblInicio.Text = "Inicio:"
        '
        '_cmbF2
        '
        Me._cmbF2.Location = New System.Drawing.Point(47, 55)
        Me._cmbF2.Name = "_cmbF2"
        Me._cmbF2.Size = New System.Drawing.Size(200, 20)
        Me._cmbF2.TabIndex = 2
        '
        '_cmbF1
        '
        Me._cmbF1.Location = New System.Drawing.Point(47, 29)
        Me._cmbF1.Name = "_cmbF1"
        Me._cmbF1.Size = New System.Drawing.Size(200, 20)
        Me._cmbF1.TabIndex = 1
        '
        'Ruta
        '
        Me.Ruta.AutoSize = True
        Me.Ruta.Location = New System.Drawing.Point(58, 111)
        Me.Ruta.Name = "Ruta"
        Me.Ruta.Size = New System.Drawing.Size(65, 13)
        Me.Ruta.TabIndex = 6
        Me.Ruta.Text = "C:\Reportes"
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.Location = New System.Drawing.Point(6, 111)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(46, 13)
        Me.lblDestino.TabIndex = 4
        Me.lblDestino.Text = "Destino:"
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(95, 138)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "Generar Archivos"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'SellOut_Colgate_Archivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 222)
        Me.Controls.Add(Me.grpDestino)
        Me.Controls.Add(Me._gridDisteffe)
        Me.Controls.Add(Me._gridSales)
        Me.Controls.Add(Me._gridInventry)
        Me.Controls.Add(Me._gridCustMast)
        Me.Controls.Add(Me._gridRoutmast4)
        Me.Controls.Add(Me._gridSalesTeam)
        Me.Controls.Add(Me._gridChain4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SellOut_Colgate_Archivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SellOut Colgate Archivos"
        CType(Me._gridChain4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridSalesTeam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridRoutmast4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridCustMast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridInventry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridSales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._gridDisteffe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDestino.ResumeLayout(False)
        Me.grpDestino.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _gridChain4 As System.Windows.Forms.DataGridView
    Friend WithEvents _gridSalesTeam As System.Windows.Forms.DataGridView
    Friend WithEvents BuscarCarpeta As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents _gridRoutmast4 As System.Windows.Forms.DataGridView
    Friend WithEvents _gridCustMast As System.Windows.Forms.DataGridView
    Friend WithEvents _gridInventry As System.Windows.Forms.DataGridView
    Friend WithEvents _gridSales As System.Windows.Forms.DataGridView
    Friend WithEvents _gridDisteffe As System.Windows.Forms.DataGridView
    Friend WithEvents grpDestino As System.Windows.Forms.GroupBox
    Friend WithEvents btnDestino As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents _cmbF2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents _cmbF1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Ruta As System.Windows.Forms.Label
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
End Class
