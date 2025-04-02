<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMatinalAgro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMatinalAgro))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ComboSuper = New System.Windows.Forms.ComboBox
        Me.DataVendedores = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.ChkTodos = New System.Windows.Forms.CheckBox
        Me.BtnListarVendedores = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Prueba = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Cmb_Fecha_Inicial = New System.Windows.Forms.DateTimePicker
        Me.BtnMostrarInfo = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Seleccionados = New System.Windows.Forms.TextBox
        Me._GridNC = New System.Windows.Forms.DataGridView
        Me._GridEfectivos = New System.Windows.Forms.DataGridView
        Me._GridVisitados = New System.Windows.Forms.DataGridView
        Me._GridVendedores = New System.Windows.Forms.DataGridView
        Me._GridEfectividadRF = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TextDiasRestantes = New System.Windows.Forms.TextBox
        Me.TextDiasTrabajados = New System.Windows.Forms.TextBox
        Me.TextDiasMensuales = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExportar = New System.Windows.Forms.Button
        Me.BtnVolver = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.Prueba, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._GridNC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._GridEfectivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._GridVisitados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._GridVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._GridEfectividadRF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(951, 491)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selección de vendedores"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.ComboSuper)
        Me.GroupBox3.Controls.Add(Me.DataVendedores)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.ChkTodos)
        Me.GroupBox3.Controls.Add(Me.BtnListarVendedores)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(677, 466)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'ComboSuper
        '
        Me.ComboSuper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSuper.FormattingEnabled = True
        Me.ComboSuper.Location = New System.Drawing.Point(205, 11)
        Me.ComboSuper.Name = "ComboSuper"
        Me.ComboSuper.Size = New System.Drawing.Size(187, 21)
        Me.ComboSuper.TabIndex = 7
        Me.ComboSuper.Visible = False
        '
        'DataVendedores
        '
        Me.DataVendedores.AllowUserToAddRows = False
        Me.DataVendedores.AllowUserToDeleteRows = False
        Me.DataVendedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataVendedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataVendedores.Location = New System.Drawing.Point(7, 50)
        Me.DataVendedores.Name = "DataVendedores"
        Me.DataVendedores.RowHeadersVisible = False
        Me.DataVendedores.Size = New System.Drawing.Size(663, 410)
        Me.DataVendedores.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Vendedores"
        '
        'ChkTodos
        '
        Me.ChkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTodos.AutoSize = True
        Me.ChkTodos.Location = New System.Drawing.Point(519, 13)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(151, 17)
        Me.ChkTodos.TabIndex = 4
        Me.ChkTodos.Text = "Generar todos los registros"
        Me.ChkTodos.UseVisualStyleBackColor = True
        Me.ChkTodos.Visible = False
        '
        'BtnListarVendedores
        '
        Me.BtnListarVendedores.Location = New System.Drawing.Point(7, 11)
        Me.BtnListarVendedores.Name = "BtnListarVendedores"
        Me.BtnListarVendedores.Size = New System.Drawing.Size(188, 21)
        Me.BtnListarVendedores.TabIndex = 1
        Me.BtnListarVendedores.Text = "Actualizar listado"
        Me.BtnListarVendedores.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.GroupBox6)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Seleccionados)
        Me.GroupBox4.Controls.Add(Me._GridNC)
        Me.GroupBox4.Controls.Add(Me._GridEfectivos)
        Me.GroupBox4.Controls.Add(Me._GridVisitados)
        Me.GroupBox4.Controls.Add(Me._GridVendedores)
        Me.GroupBox4.Controls.Add(Me._GridEfectividadRF)
        Me.GroupBox4.Location = New System.Drawing.Point(689, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(249, 466)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.Prueba)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.Cmb_Fecha_Inicial)
        Me.GroupBox6.Controls.Add(Me.BtnMostrarInfo)
        Me.GroupBox6.Location = New System.Drawing.Point(14, 43)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(220, 172)
        Me.GroupBox6.TabIndex = 13
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Parámetros:"
        '
        'Prueba
        '
        Me.Prueba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Prueba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Prueba.Location = New System.Drawing.Point(58, 179)
        Me.Prueba.Name = "Prueba"
        Me.Prueba.Size = New System.Drawing.Size(131, 15)
        Me.Prueba.TabIndex = 14
        Me.Prueba.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fecha:"
        '
        'Cmb_Fecha_Inicial
        '
        Me.Cmb_Fecha_Inicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmb_Fecha_Inicial.Location = New System.Drawing.Point(12, 56)
        Me.Cmb_Fecha_Inicial.Name = "Cmb_Fecha_Inicial"
        Me.Cmb_Fecha_Inicial.Size = New System.Drawing.Size(198, 20)
        Me.Cmb_Fecha_Inicial.TabIndex = 8
        '
        'BtnMostrarInfo
        '
        Me.BtnMostrarInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMostrarInfo.Location = New System.Drawing.Point(19, 91)
        Me.BtnMostrarInfo.Name = "BtnMostrarInfo"
        Me.BtnMostrarInfo.Size = New System.Drawing.Size(188, 68)
        Me.BtnMostrarInfo.TabIndex = 2
        Me.BtnMostrarInfo.Text = "Mostrar Información"
        Me.BtnMostrarInfo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Total Seleccionados:"
        '
        'Seleccionados
        '
        Me.Seleccionados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Seleccionados.Location = New System.Drawing.Point(149, 18)
        Me.Seleccionados.Name = "Seleccionados"
        Me.Seleccionados.ReadOnly = True
        Me.Seleccionados.Size = New System.Drawing.Size(85, 20)
        Me.Seleccionados.TabIndex = 5
        '
        '_GridNC
        '
        Me._GridNC.AllowUserToAddRows = False
        Me._GridNC.AllowUserToDeleteRows = False
        Me._GridNC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridNC.Location = New System.Drawing.Point(87, 159)
        Me._GridNC.Name = "_GridNC"
        Me._GridNC.ReadOnly = True
        Me._GridNC.Size = New System.Drawing.Size(13, 13)
        Me._GridNC.TabIndex = 19
        Me._GridNC.Visible = False
        '
        '_GridEfectivos
        '
        Me._GridEfectivos.AllowUserToAddRows = False
        Me._GridEfectivos.AllowUserToDeleteRows = False
        Me._GridEfectivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridEfectivos.Location = New System.Drawing.Point(106, 159)
        Me._GridEfectivos.Name = "_GridEfectivos"
        Me._GridEfectivos.ReadOnly = True
        Me._GridEfectivos.Size = New System.Drawing.Size(13, 13)
        Me._GridEfectivos.TabIndex = 18
        Me._GridEfectivos.Visible = False
        '
        '_GridVisitados
        '
        Me._GridVisitados.AllowUserToAddRows = False
        Me._GridVisitados.AllowUserToDeleteRows = False
        Me._GridVisitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridVisitados.Location = New System.Drawing.Point(125, 159)
        Me._GridVisitados.Name = "_GridVisitados"
        Me._GridVisitados.ReadOnly = True
        Me._GridVisitados.Size = New System.Drawing.Size(17, 13)
        Me._GridVisitados.TabIndex = 17
        Me._GridVisitados.Visible = False
        '
        '_GridVendedores
        '
        Me._GridVendedores.AllowUserToAddRows = False
        Me._GridVendedores.AllowUserToDeleteRows = False
        Me._GridVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridVendedores.Location = New System.Drawing.Point(148, 159)
        Me._GridVendedores.Name = "_GridVendedores"
        Me._GridVendedores.ReadOnly = True
        Me._GridVendedores.Size = New System.Drawing.Size(14, 13)
        Me._GridVendedores.TabIndex = 16
        Me._GridVendedores.Visible = False
        '
        '_GridEfectividadRF
        '
        Me._GridEfectividadRF.AllowUserToAddRows = False
        Me._GridEfectividadRF.AllowUserToDeleteRows = False
        Me._GridEfectividadRF.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me._GridEfectividadRF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._GridEfectividadRF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridEfectividadRF.Location = New System.Drawing.Point(95, 177)
        Me._GridEfectividadRF.Name = "_GridEfectividadRF"
        Me._GridEfectividadRF.ReadOnly = True
        Me._GridEfectividadRF.Size = New System.Drawing.Size(54, 10)
        Me._GridEfectividadRF.TabIndex = 15
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.btnExportar)
        Me.GroupBox2.Controls.Add(Me.BtnVolver)
        Me.GroupBox2.Controls.Add(Me.TabControl1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(951, 491)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información de Vendedores Seleccionados"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.TextDiasRestantes)
        Me.GroupBox5.Controls.Add(Me.TextDiasTrabajados)
        Me.GroupBox5.Controls.Add(Me.TextDiasMensuales)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Location = New System.Drawing.Point(592, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(359, 63)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        '
        'TextDiasRestantes
        '
        Me.TextDiasRestantes.Enabled = False
        Me.TextDiasRestantes.Location = New System.Drawing.Point(266, 36)
        Me.TextDiasRestantes.Name = "TextDiasRestantes"
        Me.TextDiasRestantes.Size = New System.Drawing.Size(62, 20)
        Me.TextDiasRestantes.TabIndex = 1
        '
        'TextDiasTrabajados
        '
        Me.TextDiasTrabajados.Enabled = False
        Me.TextDiasTrabajados.Location = New System.Drawing.Point(266, 10)
        Me.TextDiasTrabajados.Name = "TextDiasTrabajados"
        Me.TextDiasTrabajados.Size = New System.Drawing.Size(62, 20)
        Me.TextDiasTrabajados.TabIndex = 1
        '
        'TextDiasMensuales
        '
        Me.TextDiasMensuales.Enabled = False
        Me.TextDiasMensuales.Location = New System.Drawing.Point(9, 23)
        Me.TextDiasMensuales.Name = "TextDiasMensuales"
        Me.TextDiasMensuales.Size = New System.Drawing.Size(84, 20)
        Me.TextDiasMensuales.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(185, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Días Restantes:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(180, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Días Trabajados:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Días Mensuales:"
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = Global.Disar.My.Resources.Resources.Pdf_32
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.Location = New System.Drawing.Point(18, 19)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(133, 38)
        Me.btnExportar.TabIndex = 6
        Me.btnExportar.Text = "Exportar Documentos"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'BtnVolver
        '
        Me.BtnVolver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVolver.Location = New System.Drawing.Point(844, 460)
        Me.BtnVolver.Name = "BtnVolver"
        Me.BtnVolver.Size = New System.Drawing.Size(101, 25)
        Me.BtnVolver.TabIndex = 5
        Me.BtnVolver.Text = "Volver"
        Me.BtnVolver.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Location = New System.Drawing.Point(18, 62)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(927, 392)
        Me.TabControl1.TabIndex = 4
        '
        'FrmMatinalAgro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 509)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMatinalAgro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Matinal SR Agro"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.Prueba, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._GridNC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._GridEfectivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._GridVisitados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._GridVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._GridEfectividadRF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboSuper As System.Windows.Forms.ComboBox
    Friend WithEvents DataVendedores As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnListarVendedores As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Prueba As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Fecha_Inicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnMostrarInfo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Seleccionados As System.Windows.Forms.TextBox
    Friend WithEvents _GridNC As System.Windows.Forms.DataGridView
    Friend WithEvents _GridEfectivos As System.Windows.Forms.DataGridView
    Friend WithEvents _GridVisitados As System.Windows.Forms.DataGridView
    Friend WithEvents _GridVendedores As System.Windows.Forms.DataGridView
    Friend WithEvents _GridEfectividadRF As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TextDiasRestantes As System.Windows.Forms.TextBox
    Friend WithEvents TextDiasTrabajados As System.Windows.Forms.TextBox
    Friend WithEvents TextDiasMensuales As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents BtnVolver As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
