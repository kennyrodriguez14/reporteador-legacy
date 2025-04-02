<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_devoluciones_SRAgro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_devoluciones_SRAgro))
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.filtros = New System.Windows.Forms.GroupBox
        Me.txt_folio = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_factura_final = New System.Windows.Forms.TextBox
        Me.txt_factura_inicial = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.cmb_fecha_ini = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.grd_reporte = New System.Windows.Forms.DataGridView
        Me.filtros.SuspendLayout()
        CType(Me.grd_reporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(100, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Folio:"
        Me.Label6.Visible = False
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(10, 31)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(203, 21)
        Me.cmb_sucursal.TabIndex = 7
        '
        'filtros
        '
        Me.filtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filtros.Controls.Add(Me.txt_folio)
        Me.filtros.Controls.Add(Me.Label6)
        Me.filtros.Controls.Add(Me.cmb_sucursal)
        Me.filtros.Controls.Add(Me.Label2)
        Me.filtros.Controls.Add(Me.txt_factura_final)
        Me.filtros.Controls.Add(Me.txt_factura_inicial)
        Me.filtros.Controls.Add(Me.Label4)
        Me.filtros.Controls.Add(Me.Label3)
        Me.filtros.Controls.Add(Me.btn_aceptar)
        Me.filtros.Controls.Add(Me.cmb_fecha_ini)
        Me.filtros.Controls.Add(Me.Label1)
        Me.filtros.Location = New System.Drawing.Point(7, 5)
        Me.filtros.Name = "filtros"
        Me.filtros.Size = New System.Drawing.Size(444, 115)
        Me.filtros.TabIndex = 28
        Me.filtros.TabStop = False
        Me.filtros.Text = "Filtro"
        '
        'txt_folio
        '
        Me.txt_folio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_folio.Location = New System.Drawing.Point(142, 85)
        Me.txt_folio.Name = "txt_folio"
        Me.txt_folio.ReadOnly = True
        Me.txt_folio.Size = New System.Drawing.Size(203, 20)
        Me.txt_folio.TabIndex = 9
        Me.txt_folio.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Sucursal:"
        '
        'txt_factura_final
        '
        Me.txt_factura_final.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_factura_final.Location = New System.Drawing.Point(317, 58)
        Me.txt_factura_final.Name = "txt_factura_final"
        Me.txt_factura_final.Size = New System.Drawing.Size(117, 20)
        Me.txt_factura_final.TabIndex = 5
        '
        'txt_factura_inicial
        '
        Me.txt_factura_inicial.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_factura_inicial.Location = New System.Drawing.Point(96, 58)
        Me.txt_factura_inicial.Name = "txt_factura_inicial"
        Me.txt_factura_inicial.Size = New System.Drawing.Size(117, 20)
        Me.txt_factura_inicial.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(232, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Rango Final:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Rango Inicial:"
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_aceptar.Location = New System.Drawing.Point(162, 83)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(121, 27)
        Me.btn_aceptar.TabIndex = 6
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'cmb_fecha_ini
        '
        Me.cmb_fecha_ini.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha_ini.Location = New System.Drawing.Point(231, 32)
        Me.cmb_fecha_ini.Name = "cmb_fecha_ini"
        Me.cmb_fecha_ini.Size = New System.Drawing.Size(203, 20)
        Me.cmb_fecha_ini.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(228, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'grd_reporte
        '
        Me.grd_reporte.AllowUserToAddRows = False
        Me.grd_reporte.AllowUserToDeleteRows = False
        Me.grd_reporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_reporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_reporte.Location = New System.Drawing.Point(7, 126)
        Me.grd_reporte.Name = "grd_reporte"
        Me.grd_reporte.ReadOnly = True
        Me.grd_reporte.Size = New System.Drawing.Size(444, 132)
        Me.grd_reporte.TabIndex = 29
        '
        'frm_reporte_devoluciones_SRAgro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 263)
        Me.Controls.Add(Me.filtros)
        Me.Controls.Add(Me.grd_reporte)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_reporte_devoluciones_SRAgro"
        Me.Text = "Resumen Devoluciones"
        Me.filtros.ResumeLayout(False)
        Me.filtros.PerformLayout()
        CType(Me.grd_reporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents filtros As System.Windows.Forms.GroupBox
    Friend WithEvents txt_folio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_factura_final As System.Windows.Forms.TextBox
    Friend WithEvents txt_factura_inicial As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents cmb_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grd_reporte As System.Windows.Forms.DataGridView
End Class
