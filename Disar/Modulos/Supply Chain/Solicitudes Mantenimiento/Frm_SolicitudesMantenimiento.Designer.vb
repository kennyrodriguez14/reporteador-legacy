<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SolicitudesMantenimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SolicitudesMantenimiento))
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LAviso = New System.Windows.Forms.Label
        Me.BtnVer = New System.Windows.Forms.Button
        Me.BtnExportar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpTermina = New System.Windows.Forms.DateTimePicker
        Me.DtpInicio = New System.Windows.Forms.DateTimePicker
        Me.BtnFiltra = New System.Windows.Forms.Button
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.Data_Imagenes = New System.Windows.Forms.DataGridView
        Me.BtnVerificar = New System.Windows.Forms.Button
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Data_Imagenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Location = New System.Drawing.Point(12, 93)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.Size = New System.Drawing.Size(800, 350)
        Me.DataDatos.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnVerificar)
        Me.GroupBox1.Controls.Add(Me.LAviso)
        Me.GroupBox1.Controls.Add(Me.BtnVer)
        Me.GroupBox1.Controls.Add(Me.BtnExportar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtpTermina)
        Me.GroupBox1.Controls.Add(Me.DtpInicio)
        Me.GroupBox1.Controls.Add(Me.BtnFiltra)
        Me.GroupBox1.Controls.Add(Me.BtnNuevo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 74)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'LAviso
        '
        Me.LAviso.AutoSize = True
        Me.LAviso.Location = New System.Drawing.Point(226, 12)
        Me.LAviso.Name = "LAviso"
        Me.LAviso.Size = New System.Drawing.Size(33, 13)
        Me.LAviso.TabIndex = 10
        Me.LAviso.Text = "Aviso"
        '
        'BtnVer
        '
        Me.BtnVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVer.Image = Global.Disar.My.Resources.Resources.Analysis_32
        Me.BtnVer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnVer.Location = New System.Drawing.Point(78, 12)
        Me.BtnVer.Name = "BtnVer"
        Me.BtnVer.Size = New System.Drawing.Size(65, 56)
        Me.BtnVer.TabIndex = 9
        Me.BtnVer.Text = "Ver Solicitud"
        Me.BtnVer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnVer.UseVisualStyleBackColor = True
        '
        'BtnExportar
        '
        Me.BtnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportar.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnExportar.Location = New System.Drawing.Point(729, 12)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(65, 56)
        Me.BtnExportar.TabIndex = 8
        Me.BtnExportar.Text = "Exportar"
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(408, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(408, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Desde:"
        '
        'DtpTermina
        '
        Me.DtpTermina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpTermina.Location = New System.Drawing.Point(455, 45)
        Me.DtpTermina.Name = "DtpTermina"
        Me.DtpTermina.Size = New System.Drawing.Size(200, 20)
        Me.DtpTermina.TabIndex = 3
        '
        'DtpInicio
        '
        Me.DtpInicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpInicio.Location = New System.Drawing.Point(455, 19)
        Me.DtpInicio.Name = "DtpInicio"
        Me.DtpInicio.Size = New System.Drawing.Size(200, 20)
        Me.DtpInicio.TabIndex = 3
        '
        'BtnFiltra
        '
        Me.BtnFiltra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFiltra.Image = Global.Disar.My.Resources.Resources.Add_32
        Me.BtnFiltra.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnFiltra.Location = New System.Drawing.Point(661, 12)
        Me.BtnFiltra.Name = "BtnFiltra"
        Me.BtnFiltra.Size = New System.Drawing.Size(65, 56)
        Me.BtnFiltra.TabIndex = 2
        Me.BtnFiltra.Text = "Filtrar"
        Me.BtnFiltra.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnFiltra.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Image = Global.Disar.My.Resources.Resources.Ordering_32
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnNuevo.Location = New System.Drawing.Point(6, 12)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(65, 56)
        Me.BtnNuevo.TabIndex = 2
        Me.BtnNuevo.Text = "Nueva"
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'Data_Imagenes
        '
        Me.Data_Imagenes.AllowUserToAddRows = False
        Me.Data_Imagenes.AllowUserToDeleteRows = False
        Me.Data_Imagenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Data_Imagenes.Location = New System.Drawing.Point(309, 37)
        Me.Data_Imagenes.Name = "Data_Imagenes"
        Me.Data_Imagenes.ReadOnly = True
        Me.Data_Imagenes.Size = New System.Drawing.Size(24, 20)
        Me.Data_Imagenes.TabIndex = 10
        '
        'BtnVerificar
        '
        Me.BtnVerificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVerificar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.BtnVerificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnVerificar.Location = New System.Drawing.Point(149, 12)
        Me.BtnVerificar.Name = "BtnVerificar"
        Me.BtnVerificar.Size = New System.Drawing.Size(75, 56)
        Me.BtnVerificar.TabIndex = 11
        Me.BtnVerificar.Text = "Marcar como verificada"
        Me.BtnVerificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnVerificar.UseVisualStyleBackColor = True
        '
        'Frm_SolicitudesMantenimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 455)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataDatos)
        Me.Controls.Add(Me.Data_Imagenes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_SolicitudesMantenimiento"
        Me.Text = "Solicitudes de Mantenimiento"
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Data_Imagenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnFiltra As System.Windows.Forms.Button
    Friend WithEvents DtpTermina As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents BtnVer As System.Windows.Forms.Button
    Friend WithEvents Data_Imagenes As System.Windows.Forms.DataGridView
    Friend WithEvents LAviso As System.Windows.Forms.Label
    Friend WithEvents BtnVerificar As System.Windows.Forms.Button
End Class
