<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AccidentesLaborales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AccidentesLaborales))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextAlmacen = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Cargar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnExporter = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.DateDeste = New System.Windows.Forms.DateTimePicker
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextPorcentaje = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextCantidadDeAccidentes = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.BtnNuevo)
        Me.GroupBox1.Controls.Add(Me.DataDatos)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(807, 463)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextAlmacen)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Cargar)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.BtnExporter)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DateHasta)
        Me.GroupBox2.Controls.Add(Me.DateDeste)
        Me.GroupBox2.Location = New System.Drawing.Point(78, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(723, 73)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'TextAlmacen
        '
        Me.TextAlmacen.Enabled = False
        Me.TextAlmacen.Location = New System.Drawing.Point(232, 16)
        Me.TextAlmacen.Name = "TextAlmacen"
        Me.TextAlmacen.Size = New System.Drawing.Size(100, 20)
        Me.TextAlmacen.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(175, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Almacén:"
        '
        'Cargar
        '
        Me.Cargar.Image = Global.Disar.My.Resources.Resources.lupa
        Me.Cargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Cargar.Location = New System.Drawing.Point(603, 12)
        Me.Cargar.Name = "Cargar"
        Me.Cargar.Size = New System.Drawing.Size(54, 54)
        Me.Cargar.TabIndex = 2
        Me.Cargar.Text = "Cargar"
        Me.Cargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cargar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(350, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Hasta:"
        '
        'BtnExporter
        '
        Me.BtnExporter.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExporter.Image = Global.Disar.My.Resources.Resources.ExcelNuevo
        Me.BtnExporter.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnExporter.Location = New System.Drawing.Point(663, 12)
        Me.BtnExporter.Name = "BtnExporter"
        Me.BtnExporter.Size = New System.Drawing.Size(54, 54)
        Me.BtnExporter.TabIndex = 1
        Me.BtnExporter.Text = "Exportar"
        Me.BtnExporter.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnExporter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(350, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desde:"
        '
        'DateHasta
        '
        Me.DateHasta.Location = New System.Drawing.Point(397, 43)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(200, 20)
        Me.DateHasta.TabIndex = 0
        '
        'DateDeste
        '
        Me.DateDeste.Location = New System.Drawing.Point(397, 16)
        Me.DateDeste.Name = "DateDeste"
        Me.DateDeste.Size = New System.Drawing.Size(200, 20)
        Me.DateDeste.TabIndex = 0
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Image = Global.Disar.My.Resources.Resources.Error_Add_32
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnNuevo.Location = New System.Drawing.Point(7, 12)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(65, 68)
        Me.BtnNuevo.TabIndex = 1
        Me.BtnNuevo.Text = "Registrar Accidente"
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnNuevo.UseVisualStyleBackColor = True
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
        Me.DataDatos.Location = New System.Drawing.Point(6, 86)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.Size = New System.Drawing.Size(795, 307)
        Me.DataDatos.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.TextPorcentaje)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.TextCantidadDeAccidentes)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 392)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(794, 65)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(562, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "% días con accidentes:"
        '
        'TextPorcentaje
        '
        Me.TextPorcentaje.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextPorcentaje.Enabled = False
        Me.TextPorcentaje.Location = New System.Drawing.Point(688, 38)
        Me.TextPorcentaje.Name = "TextPorcentaje"
        Me.TextPorcentaje.Size = New System.Drawing.Size(100, 20)
        Me.TextPorcentaje.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(560, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Cantidad de accidentes:"
        '
        'TextCantidadDeAccidentes
        '
        Me.TextCantidadDeAccidentes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextCantidadDeAccidentes.Enabled = False
        Me.TextCantidadDeAccidentes.Location = New System.Drawing.Point(688, 12)
        Me.TextCantidadDeAccidentes.Name = "TextCantidadDeAccidentes"
        Me.TextCantidadDeAccidentes.Size = New System.Drawing.Size(100, 20)
        Me.TextCantidadDeAccidentes.TabIndex = 0
        '
        'Frm_AccidentesLaborales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 479)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_AccidentesLaborales"
        Me.Text = "Registro de Accidentes Laborales"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateDeste As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnExporter As System.Windows.Forms.Button
    Friend WithEvents TextPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents TextCantidadDeAccidentes As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cargar As System.Windows.Forms.Button
    Friend WithEvents TextAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
