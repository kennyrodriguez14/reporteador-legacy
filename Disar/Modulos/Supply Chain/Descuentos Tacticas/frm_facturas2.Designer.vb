﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_facturas2
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grd_lista = New System.Windows.Forms.DataGridView
        Me.lbl_factura = New System.Windows.Forms.Label
        Me.txt_numero_factura = New System.Windows.Forms.TextBox
        Me.cmb_folio = New System.Windows.Forms.ComboBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grd_lista)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(867, 255)
        Me.GroupBox2.TabIndex = 4
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
        Me.grd_lista.Location = New System.Drawing.Point(3, 16)
        Me.grd_lista.Name = "grd_lista"
        Me.grd_lista.ReadOnly = True
        Me.grd_lista.RowHeadersVisible = False
        Me.grd_lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_lista.Size = New System.Drawing.Size(861, 236)
        Me.grd_lista.TabIndex = 2
        '
        'lbl_factura
        '
        Me.lbl_factura.AutoSize = True
        Me.lbl_factura.Location = New System.Drawing.Point(15, 12)
        Me.lbl_factura.Name = "lbl_factura"
        Me.lbl_factura.Size = New System.Drawing.Size(46, 13)
        Me.lbl_factura.TabIndex = 5
        Me.lbl_factura.Text = "Factura:"
        '
        'txt_numero_factura
        '
        Me.txt_numero_factura.Location = New System.Drawing.Point(199, 9)
        Me.txt_numero_factura.Name = "txt_numero_factura"
        Me.txt_numero_factura.Size = New System.Drawing.Size(152, 20)
        Me.txt_numero_factura.TabIndex = 0
        '
        'cmb_folio
        '
        Me.cmb_folio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_folio.FormattingEnabled = True
        Me.cmb_folio.Location = New System.Drawing.Point(67, 8)
        Me.cmb_folio.Name = "cmb_folio"
        Me.cmb_folio.Size = New System.Drawing.Size(126, 21)
        Me.cmb_folio.TabIndex = 6
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(357, 8)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(60, 21)
        Me.btn_aceptar.TabIndex = 7
        Me.btn_aceptar.Text = "Buscar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'frm_facturas
        '
        Me.AcceptButton = Me.btn_aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 298)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.cmb_folio)
        Me.Controls.Add(Me.txt_numero_factura)
        Me.Controls.Add(Me.lbl_factura)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_facturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Facturas"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grd_lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grd_lista As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_factura As System.Windows.Forms.Label
    Friend WithEvents txt_numero_factura As System.Windows.Forms.TextBox
    Friend WithEvents cmb_folio As System.Windows.Forms.ComboBox
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
End Class
