<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroAgro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroAgro))
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataReg = New System.Windows.Forms.DataGridView
        Me.Usuario = New System.Windows.Forms.Label
        Me.BtnRegistro = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.LFecha = New System.Windows.Forms.Label
        Me.Nombre = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.IP = New System.Windows.Forms.Label
        Me.ComboMotivo = New System.Windows.Forms.ComboBox
        Me.TextOtro = New System.Windows.Forms.TextBox
        Me.BtnCargar = New System.Windows.Forms.Button
        Me.ComboEMPLEADO = New System.Windows.Forms.ComboBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.BtnExportar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        CType(Me.DataReg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Registro de fecha:"
        '
        'DataReg
        '
        Me.DataReg.AllowUserToAddRows = False
        Me.DataReg.AllowUserToDeleteRows = False
        Me.DataReg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataReg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataReg.Location = New System.Drawing.Point(15, 145)
        Me.DataReg.Name = "DataReg"
        Me.DataReg.ReadOnly = True
        Me.DataReg.Size = New System.Drawing.Size(912, 264)
        Me.DataReg.TabIndex = 2
        '
        'Usuario
        '
        Me.Usuario.AutoSize = True
        Me.Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Usuario.Location = New System.Drawing.Point(15, 52)
        Me.Usuario.Name = "Usuario"
        Me.Usuario.Size = New System.Drawing.Size(25, 13)
        Me.Usuario.TabIndex = 3
        Me.Usuario.Text = "♦♦"
        '
        'BtnRegistro
        '
        Me.BtnRegistro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRegistro.Image = Global.Disar.My.Resources.Resources.Clock_Silver_Dark_32
        Me.BtnRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRegistro.Location = New System.Drawing.Point(203, 36)
        Me.BtnRegistro.Name = "BtnRegistro"
        Me.BtnRegistro.Size = New System.Drawing.Size(159, 49)
        Me.BtnRegistro.TabIndex = 0
        Me.BtnRegistro.Text = "Registrar Entrada/Salida"
        Me.BtnRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRegistro.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Motivo:"
        '
        'LFecha
        '
        Me.LFecha.AutoSize = True
        Me.LFecha.Location = New System.Drawing.Point(109, 99)
        Me.LFecha.Name = "LFecha"
        Me.LFecha.Size = New System.Drawing.Size(55, 13)
        Me.LFecha.TabIndex = 1
        Me.LFecha.Text = "♦♦♦♦♦♦"
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(15, 70)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(43, 13)
        Me.Nombre.TabIndex = 3
        Me.Nombre.Text = "♦♦♦♦"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoEllipsis = True
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(574, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Guardado desde:"
        '
        'IP
        '
        Me.IP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IP.AutoEllipsis = True
        Me.IP.AutoSize = True
        Me.IP.Location = New System.Drawing.Point(662, 129)
        Me.IP.Name = "IP"
        Me.IP.Size = New System.Drawing.Size(17, 13)
        Me.IP.TabIndex = 6
        Me.IP.Text = "IP"
        '
        'ComboMotivo
        '
        Me.ComboMotivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboMotivo.FormattingEnabled = True
        Me.ComboMotivo.Items.AddRange(New Object() {"ENTRADA", "SALIDA", "ENTRADA DESPUES DE COMER", "SALIDA PARA COMER", "OTRO"})
        Me.ComboMotivo.Location = New System.Drawing.Point(18, 37)
        Me.ComboMotivo.Name = "ComboMotivo"
        Me.ComboMotivo.Size = New System.Drawing.Size(179, 21)
        Me.ComboMotivo.TabIndex = 7
        '
        'TextOtro
        '
        Me.TextOtro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextOtro.Location = New System.Drawing.Point(18, 65)
        Me.TextOtro.Name = "TextOtro"
        Me.TextOtro.Size = New System.Drawing.Size(179, 20)
        Me.TextOtro.TabIndex = 8
        Me.TextOtro.Visible = False
        '
        'BtnCargar
        '
        Me.BtnCargar.Location = New System.Drawing.Point(317, 94)
        Me.BtnCargar.Name = "BtnCargar"
        Me.BtnCargar.Size = New System.Drawing.Size(114, 47)
        Me.BtnCargar.TabIndex = 9
        Me.BtnCargar.Text = "Cargar Información"
        Me.BtnCargar.UseVisualStyleBackColor = True
        '
        'ComboEMPLEADO
        '
        Me.ComboEMPLEADO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEMPLEADO.FormattingEnabled = True
        Me.ComboEMPLEADO.Location = New System.Drawing.Point(15, 70)
        Me.ComboEMPLEADO.Name = "ComboEMPLEADO"
        Me.ComboEMPLEADO.Size = New System.Drawing.Size(296, 21)
        Me.ComboEMPLEADO.TabIndex = 10
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(112, 95)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 11
        '
        'BtnExportar
        '
        Me.BtnExportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.Location = New System.Drawing.Point(437, 94)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(81, 47)
        Me.BtnExportar.TabIndex = 12
        Me.BtnExportar.Text = "Exportar"
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.BtnRegistro)
        Me.GroupBox1.Controls.Add(Me.ComboMotivo)
        Me.GroupBox1.Controls.Add(Me.TextOtro)
        Me.GroupBox1.Location = New System.Drawing.Point(559, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 100)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nuevo Registro"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Hasta:"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(112, 119)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 11
        '
        'FrmRegistroAgro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 425)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnExportar)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.ComboEMPLEADO)
        Me.Controls.Add(Me.BtnCargar)
        Me.Controls.Add(Me.IP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.Usuario)
        Me.Controls.Add(Me.DataReg)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LFecha)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRegistroAgro"
        Me.Text = "Registro SR Agro"
        CType(Me.DataReg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnRegistro As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataReg As System.Windows.Forms.DataGridView
    Friend WithEvents Usuario As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LFecha As System.Windows.Forms.Label
    Friend WithEvents Nombre As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents IP As System.Windows.Forms.Label
    Friend WithEvents ComboMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents TextOtro As System.Windows.Forms.TextBox
    Friend WithEvents BtnCargar As System.Windows.Forms.Button
    Friend WithEvents ComboEMPLEADO As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
End Class
