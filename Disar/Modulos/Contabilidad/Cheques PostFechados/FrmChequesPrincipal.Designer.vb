<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChequesPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChequesPrincipal))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BtnBusca = New System.Windows.Forms.Button
        Me.ComboFiltro = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.BtnRechazarPago = New System.Windows.Forms.Button
        Me.BtnAprobar = New System.Windows.Forms.Button
        Me.BtnNuevoCheque = New System.Windows.Forms.Button
        Me.DataCheques = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.BtnRechazarPago)
        Me.GroupBox1.Controls.Add(Me.BtnAprobar)
        Me.GroupBox1.Controls.Add(Me.BtnNuevoCheque)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(860, 133)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtnBusca)
        Me.GroupBox2.Controls.Add(Me.ComboFiltro)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DateHasta)
        Me.GroupBox2.Controls.Add(Me.DateDesde)
        Me.GroupBox2.Location = New System.Drawing.Point(430, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(424, 114)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtrar Depósitos"
        '
        'BtnBusca
        '
        Me.BtnBusca.Image = Global.Disar.My.Resources.Resources.img_modulo_monitoreo
        Me.BtnBusca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBusca.Location = New System.Drawing.Point(324, 40)
        Me.BtnBusca.Name = "BtnBusca"
        Me.BtnBusca.Size = New System.Drawing.Size(79, 39)
        Me.BtnBusca.TabIndex = 4
        Me.BtnBusca.Text = "Buscar"
        Me.BtnBusca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBusca.UseVisualStyleBackColor = True
        '
        'ComboFiltro
        '
        Me.ComboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboFiltro.FormattingEnabled = True
        Me.ComboFiltro.Items.AddRange(New Object() {"Todos", "Pendientes", "Enviados a SAE"})
        Me.ComboFiltro.Location = New System.Drawing.Point(88, 81)
        Me.ComboFiltro.Name = "ComboFiltro"
        Me.ComboFiltro.Size = New System.Drawing.Size(200, 21)
        Me.ComboFiltro.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Filtro:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Desde:"
        '
        'DateHasta
        '
        Me.DateHasta.Location = New System.Drawing.Point(88, 49)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(200, 20)
        Me.DateHasta.TabIndex = 1
        '
        'DateDesde
        '
        Me.DateDesde.Location = New System.Drawing.Point(88, 23)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(200, 20)
        Me.DateDesde.TabIndex = 1
        '
        'BtnRechazarPago
        '
        Me.BtnRechazarPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnRechazarPago.Image = Global.Disar.My.Resources.Resources.Adblock_Dark_32
        Me.BtnRechazarPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRechazarPago.Location = New System.Drawing.Point(273, 13)
        Me.BtnRechazarPago.Name = "BtnRechazarPago"
        Me.BtnRechazarPago.Size = New System.Drawing.Size(121, 39)
        Me.BtnRechazarPago.TabIndex = 0
        Me.BtnRechazarPago.Text = "Rechazar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Depósito"
        Me.BtnRechazarPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRechazarPago.UseVisualStyleBackColor = True
        Me.BtnRechazarPago.Visible = False
        '
        'BtnAprobar
        '
        Me.BtnAprobar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAprobar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.BtnAprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAprobar.Location = New System.Drawing.Point(140, 13)
        Me.BtnAprobar.Name = "BtnAprobar"
        Me.BtnAprobar.Size = New System.Drawing.Size(121, 39)
        Me.BtnAprobar.TabIndex = 0
        Me.BtnAprobar.Text = "Enviar a SAE"
        Me.BtnAprobar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAprobar.UseVisualStyleBackColor = True
        '
        'BtnNuevoCheque
        '
        Me.BtnNuevoCheque.Image = Global.Disar.My.Resources.Resources.File_new_32
        Me.BtnNuevoCheque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevoCheque.Location = New System.Drawing.Point(6, 13)
        Me.BtnNuevoCheque.Name = "BtnNuevoCheque"
        Me.BtnNuevoCheque.Size = New System.Drawing.Size(121, 39)
        Me.BtnNuevoCheque.TabIndex = 0
        Me.BtnNuevoCheque.Text = "Nuevo Depósito"
        Me.BtnNuevoCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNuevoCheque.UseVisualStyleBackColor = True
        '
        'DataCheques
        '
        Me.DataCheques.AllowUserToAddRows = False
        Me.DataCheques.AllowUserToDeleteRows = False
        Me.DataCheques.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DataCheques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataCheques.Location = New System.Drawing.Point(12, 145)
        Me.DataCheques.Name = "DataCheques"
        Me.DataCheques.ReadOnly = True
        Me.DataCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataCheques.Size = New System.Drawing.Size(860, 387)
        Me.DataCheques.TabIndex = 3
        '
        'FrmChequesPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 544)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataCheques)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmChequesPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envío de Depósitos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBusca As System.Windows.Forms.Button
    Friend WithEvents ComboFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnRechazarPago As System.Windows.Forms.Button
    Friend WithEvents BtnAprobar As System.Windows.Forms.Button
    Friend WithEvents BtnNuevoCheque As System.Windows.Forms.Button
    Friend WithEvents DataCheques As System.Windows.Forms.DataGridView
End Class
