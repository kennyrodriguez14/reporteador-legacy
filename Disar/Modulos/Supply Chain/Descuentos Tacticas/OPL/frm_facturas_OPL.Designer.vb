<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_facturas_OPL
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
        Me.txt_sucursal = New System.Windows.Forms.TextBox()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.cmb_folio = New System.Windows.Forms.ComboBox()
        Me.txt_numero_factura = New System.Windows.Forms.TextBox()
        Me.lbl_factura = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grd_lista = New System.Windows.Forms.DataGridView()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_sucursal
        '
        Me.txt_sucursal.Enabled = False
        Me.txt_sucursal.Location = New System.Drawing.Point(259, 10)
        Me.txt_sucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_sucursal.Name = "txt_sucursal"
        Me.txt_sucursal.Size = New System.Drawing.Size(281, 22)
        Me.txt_sucursal.TabIndex = 21
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(761, 9)
        Me.btn_aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(80, 26)
        Me.btn_aceptar.TabIndex = 20
        Me.btn_aceptar.Text = "Buscar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'cmb_folio
        '
        Me.cmb_folio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_folio.FormattingEnabled = True
        Me.cmb_folio.Location = New System.Drawing.Point(83, 10)
        Me.cmb_folio.Margin = New System.Windows.Forms.Padding(4)
        Me.cmb_folio.Name = "cmb_folio"
        Me.cmb_folio.Size = New System.Drawing.Size(167, 24)
        Me.cmb_folio.TabIndex = 19
        '
        'txt_numero_factura
        '
        Me.txt_numero_factura.Location = New System.Drawing.Point(550, 10)
        Me.txt_numero_factura.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_numero_factura.Name = "txt_numero_factura"
        Me.txt_numero_factura.Size = New System.Drawing.Size(201, 22)
        Me.txt_numero_factura.TabIndex = 16
        '
        'lbl_factura
        '
        Me.lbl_factura.AutoSize = True
        Me.lbl_factura.Location = New System.Drawing.Point(14, 15)
        Me.lbl_factura.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_factura.Name = "lbl_factura"
        Me.lbl_factura.Size = New System.Drawing.Size(60, 17)
        Me.lbl_factura.TabIndex = 18
        Me.lbl_factura.Text = "Factura:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grd_lista)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 39)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1156, 314)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lista"
        '
        'grd_lista
        '
        Me.grd_lista.AllowUserToAddRows = False
        Me.grd_lista.AllowUserToDeleteRows = False
        Me.grd_lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_lista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_lista.Location = New System.Drawing.Point(4, 19)
        Me.grd_lista.Margin = New System.Windows.Forms.Padding(4)
        Me.grd_lista.Name = "grd_lista"
        Me.grd_lista.ReadOnly = True
        Me.grd_lista.RowHeadersVisible = False
        Me.grd_lista.RowHeadersWidth = 51
        Me.grd_lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_lista.Size = New System.Drawing.Size(1148, 291)
        Me.grd_lista.TabIndex = 2
        '
        'frm_facturas_OPL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 366)
        Me.Controls.Add(Me.txt_sucursal)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.cmb_folio)
        Me.Controls.Add(Me.txt_numero_factura)
        Me.Controls.Add(Me.lbl_factura)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frm_facturas_OPL"
        Me.Text = "Facturas OPL"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_sucursal As TextBox
    Friend WithEvents btn_aceptar As Button
    Friend WithEvents cmb_folio As ComboBox
    Friend WithEvents txt_numero_factura As TextBox
    Friend WithEvents lbl_factura As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents grd_lista As DataGridView
End Class
