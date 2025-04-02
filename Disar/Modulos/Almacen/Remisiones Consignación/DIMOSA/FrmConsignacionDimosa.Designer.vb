<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsignacionDimosa
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsignacionDimosa))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtEstadoRem = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_documento = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_cai = New System.Windows.Forms.TextBox
        Me.txt_empresa = New System.Windows.Forms.TextBox
        Me.txt_peso_total = New System.Windows.Forms.TextBox
        Me.txt_vehiculo = New System.Windows.Forms.TextBox
        Me.txt_motivo = New System.Windows.Forms.TextBox
        Me.txt_transportista = New System.Windows.Forms.TextBox
        Me.txt_remite = New System.Windows.Forms.TextBox
        Me.cmb_fecha_final = New System.Windows.Forms.DateTimePicker
        Me.cmb_fecha_inicio = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextClienteClave = New System.Windows.Forms.TextBox
        Me.txt_destino = New System.Windows.Forms.TextBox
        Me.grd_detalle = New System.Windows.Forms.DataGridView
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnCompletarRemision = New System.Windows.Forms.Button
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1.SuspendLayout()
        CType(Me.grd_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TxtEstadoRem)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txt_documento)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_cai)
        Me.GroupBox1.Controls.Add(Me.txt_empresa)
        Me.GroupBox1.Controls.Add(Me.txt_peso_total)
        Me.GroupBox1.Controls.Add(Me.txt_vehiculo)
        Me.GroupBox1.Controls.Add(Me.txt_motivo)
        Me.GroupBox1.Controls.Add(Me.txt_transportista)
        Me.GroupBox1.Controls.Add(Me.txt_remite)
        Me.GroupBox1.Controls.Add(Me.cmb_fecha_final)
        Me.GroupBox1.Controls.Add(Me.cmb_fecha_inicio)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextClienteClave)
        Me.GroupBox1.Controls.Add(Me.txt_destino)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(768, 185)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Encabezado"
        '
        'TxtEstadoRem
        '
        Me.TxtEstadoRem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtEstadoRem.Location = New System.Drawing.Point(532, 159)
        Me.TxtEstadoRem.Name = "TxtEstadoRem"
        Me.TxtEstadoRem.ReadOnly = True
        Me.TxtEstadoRem.Size = New System.Drawing.Size(212, 20)
        Me.TxtEstadoRem.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(531, 147)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(130, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Estado de Consignación:"
        '
        'txt_documento
        '
        Me.txt_documento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_documento.Location = New System.Drawing.Point(96, 19)
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.ReadOnly = True
        Me.txt_documento.Size = New System.Drawing.Size(406, 20)
        Me.txt_documento.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Documento:"
        '
        'txt_cai
        '
        Me.txt_cai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cai.Location = New System.Drawing.Point(134, 48)
        Me.txt_cai.Name = "txt_cai"
        Me.txt_cai.ReadOnly = True
        Me.txt_cai.Size = New System.Drawing.Size(32, 20)
        Me.txt_cai.TabIndex = 7
        Me.txt_cai.Visible = False
        '
        'txt_empresa
        '
        Me.txt_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_empresa.Location = New System.Drawing.Point(96, 48)
        Me.txt_empresa.Name = "txt_empresa"
        Me.txt_empresa.ReadOnly = True
        Me.txt_empresa.Size = New System.Drawing.Size(32, 20)
        Me.txt_empresa.TabIndex = 7
        Me.txt_empresa.Visible = False
        '
        'txt_peso_total
        '
        Me.txt_peso_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_peso_total.Location = New System.Drawing.Point(607, 117)
        Me.txt_peso_total.Name = "txt_peso_total"
        Me.txt_peso_total.ReadOnly = True
        Me.txt_peso_total.Size = New System.Drawing.Size(137, 20)
        Me.txt_peso_total.TabIndex = 5
        '
        'txt_vehiculo
        '
        Me.txt_vehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_vehiculo.Location = New System.Drawing.Point(438, 149)
        Me.txt_vehiculo.Name = "txt_vehiculo"
        Me.txt_vehiculo.ReadOnly = True
        Me.txt_vehiculo.Size = New System.Drawing.Size(64, 20)
        Me.txt_vehiculo.TabIndex = 5
        '
        'txt_motivo
        '
        Me.txt_motivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_motivo.Location = New System.Drawing.Point(96, 149)
        Me.txt_motivo.Name = "txt_motivo"
        Me.txt_motivo.ReadOnly = True
        Me.txt_motivo.Size = New System.Drawing.Size(270, 20)
        Me.txt_motivo.TabIndex = 4
        '
        'txt_transportista
        '
        Me.txt_transportista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_transportista.Location = New System.Drawing.Point(96, 116)
        Me.txt_transportista.Name = "txt_transportista"
        Me.txt_transportista.ReadOnly = True
        Me.txt_transportista.Size = New System.Drawing.Size(406, 20)
        Me.txt_transportista.TabIndex = 3
        '
        'txt_remite
        '
        Me.txt_remite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_remite.Location = New System.Drawing.Point(96, 48)
        Me.txt_remite.Name = "txt_remite"
        Me.txt_remite.ReadOnly = True
        Me.txt_remite.Size = New System.Drawing.Size(406, 20)
        Me.txt_remite.TabIndex = 1
        '
        'cmb_fecha_final
        '
        Me.cmb_fecha_final.Enabled = False
        Me.cmb_fecha_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_fecha_final.Location = New System.Drawing.Point(533, 80)
        Me.cmb_fecha_final.Name = "cmb_fecha_final"
        Me.cmb_fecha_final.Size = New System.Drawing.Size(211, 20)
        Me.cmb_fecha_final.TabIndex = 2
        '
        'cmb_fecha_inicio
        '
        Me.cmb_fecha_inicio.Enabled = False
        Me.cmb_fecha_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_fecha_inicio.Location = New System.Drawing.Point(533, 30)
        Me.cmb_fecha_inicio.Name = "cmb_fecha_inicio"
        Me.cmb_fecha_inicio.Size = New System.Drawing.Size(211, 20)
        Me.cmb_fecha_inicio.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(529, 121)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Peso Total:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(530, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha Final de Traslado:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(372, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Vehiculo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 26)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Motivo de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Traslado:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(530, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Fecha Inicio de Traslado:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Transportista:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Destino:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Remite:"
        '
        'TextClienteClave
        '
        Me.TextClienteClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextClienteClave.Location = New System.Drawing.Point(96, 80)
        Me.TextClienteClave.Name = "TextClienteClave"
        Me.TextClienteClave.ReadOnly = True
        Me.TextClienteClave.Size = New System.Drawing.Size(80, 20)
        Me.TextClienteClave.TabIndex = 2
        '
        'txt_destino
        '
        Me.txt_destino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_destino.Location = New System.Drawing.Point(182, 80)
        Me.txt_destino.Name = "txt_destino"
        Me.txt_destino.ReadOnly = True
        Me.txt_destino.Size = New System.Drawing.Size(320, 20)
        Me.txt_destino.TabIndex = 2
        '
        'grd_detalle
        '
        Me.grd_detalle.AllowUserToAddRows = False
        Me.grd_detalle.AllowUserToDeleteRows = False
        Me.grd_detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_detalle.Location = New System.Drawing.Point(3, 16)
        Me.grd_detalle.Name = "grd_detalle"
        Me.grd_detalle.Size = New System.Drawing.Size(762, 266)
        Me.grd_detalle.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.grd_detalle)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 243)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(768, 285)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(792, 39)
        Me.ToolStrip1.TabIndex = 25
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'BtnCompletarRemision
        '
        Me.BtnCompletarRemision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCompletarRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCompletarRemision.Image = Global.Disar.My.Resources.Resources.img_aceptar
        Me.BtnCompletarRemision.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCompletarRemision.Location = New System.Drawing.Point(585, 529)
        Me.BtnCompletarRemision.Name = "BtnCompletarRemision"
        Me.BtnCompletarRemision.Size = New System.Drawing.Size(195, 44)
        Me.BtnCompletarRemision.TabIndex = 26
        Me.BtnCompletarRemision.Text = "Completar consignación y generar factura"
        Me.BtnCompletarRemision.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnCompletarRemision, "Completa la consignación, devuelve todo el producto de las partidas al inventario" & _
                " y después hace una factura de salida con las cantidades especificadas.")
        Me.BtnCompletarRemision.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(15, 529)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(183, 44)
        Me.BtnCancelar.TabIndex = 27
        Me.BtnCancelar.Text = "Cancelar consignación y devolver a almacén"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnCancelar, "Cancela la consignación actual y devuelve el producto de las partidas al almacén " & _
                "de origen sin generar factura.")
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Disar.My.Resources.Resources.File_Blue
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(93, 36)
        Me.ToolStripDropDownButton1.Text = "Archivo"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.img_impresora
        Me.NuevoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(136, 38)
        Me.NuevoToolStripMenuItem.Text = "Imprimir"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Disar.My.Resources.Resources.img_salir
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(136, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'FrmConsignacionDimosa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 575)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnCompletarRemision)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmConsignacionDimosa"
        Me.Text = "Consignación DIMOSA"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grd_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtEstadoRem As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_cai As System.Windows.Forms.TextBox
    Friend WithEvents txt_empresa As System.Windows.Forms.TextBox
    Friend WithEvents txt_peso_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_vehiculo As System.Windows.Forms.TextBox
    Friend WithEvents txt_motivo As System.Windows.Forms.TextBox
    Friend WithEvents txt_transportista As System.Windows.Forms.TextBox
    Friend WithEvents txt_remite As System.Windows.Forms.TextBox
    Friend WithEvents cmb_fecha_final As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmb_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextClienteClave As System.Windows.Forms.TextBox
    Friend WithEvents txt_destino As System.Windows.Forms.TextBox
    Friend WithEvents grd_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnCompletarRemision As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
