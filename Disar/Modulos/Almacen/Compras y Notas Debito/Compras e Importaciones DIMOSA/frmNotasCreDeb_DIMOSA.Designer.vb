<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotasCreDeb_DIMOSA
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
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataDebito1 = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ID2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Producto2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Total2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataCredito = New System.Windows.Forms.DataGridView
        CType(Me.DataDebito1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Total
        '
        Me.Total.HeaderText = "Total Nota Débito"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'DataDebito1
        '
        Me.DataDebito1.AllowUserToAddRows = False
        Me.DataDebito1.AllowUserToDeleteRows = False
        Me.DataDebito1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDebito1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDebito1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Producto, Me.Total})
        Me.DataDebito1.Location = New System.Drawing.Point(9, 54)
        Me.DataDebito1.Name = "DataDebito1"
        Me.DataDebito1.ReadOnly = True
        Me.DataDebito1.RowHeadersVisible = False
        Me.DataDebito1.Size = New System.Drawing.Size(417, 350)
        Me.DataDebito1.TabIndex = 3
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'Producto
        '
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        '
        'ID2
        '
        Me.ID2.HeaderText = "ID"
        Me.ID2.Name = "ID2"
        Me.ID2.ReadOnly = True
        '
        'Producto2
        '
        Me.Producto2.HeaderText = "Producto"
        Me.Producto2.Name = "Producto2"
        Me.Producto2.ReadOnly = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(453, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Notas de Crédito"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Notas de Débito"
        '
        'Total2
        '
        Me.Total2.HeaderText = "Total Nota Crédito"
        Me.Total2.Name = "Total2"
        Me.Total2.ReadOnly = True
        '
        'DataCredito
        '
        Me.DataCredito.AllowUserToAddRows = False
        Me.DataCredito.AllowUserToDeleteRows = False
        Me.DataCredito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataCredito.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID2, Me.Producto2, Me.Total2})
        Me.DataCredito.Location = New System.Drawing.Point(456, 54)
        Me.DataCredito.Name = "DataCredito"
        Me.DataCredito.ReadOnly = True
        Me.DataCredito.RowHeadersVisible = False
        Me.DataCredito.Size = New System.Drawing.Size(417, 350)
        Me.DataCredito.TabIndex = 2
        '
        'frmNotasCreDeb_DIMOSA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 429)
        Me.Controls.Add(Me.DataDebito1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataCredito)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmNotasCreDeb_DIMOSA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notas de Crédito y Débito"
        CType(Me.DataDebito1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataDebito1 As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Total2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataCredito As System.Windows.Forms.DataGridView
End Class
