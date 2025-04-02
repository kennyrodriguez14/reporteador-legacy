<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRechazaCheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRechazaCheque))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.LCheque = New System.Windows.Forms.Label
        Me.LMonto = New System.Windows.Forms.Label
        Me.LCliente = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnRechazarPago = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(117, 90)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(376, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'LCheque
        '
        Me.LCheque.AutoSize = True
        Me.LCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCheque.Location = New System.Drawing.Point(12, 37)
        Me.LCheque.Name = "LCheque"
        Me.LCheque.Size = New System.Drawing.Size(51, 15)
        Me.LCheque.TabIndex = 6
        Me.LCheque.Text = "Label1"
        '
        'LMonto
        '
        Me.LMonto.AutoSize = True
        Me.LMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LMonto.Location = New System.Drawing.Point(12, 62)
        Me.LMonto.Name = "LMonto"
        Me.LMonto.Size = New System.Drawing.Size(51, 15)
        Me.LMonto.TabIndex = 5
        Me.LMonto.Text = "Label1"
        '
        'LCliente
        '
        Me.LCliente.AutoSize = True
        Me.LCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCliente.Location = New System.Drawing.Point(12, 11)
        Me.LCliente.Name = "LCliente"
        Me.LCliente.Size = New System.Drawing.Size(51, 15)
        Me.LCliente.TabIndex = 4
        Me.LCliente.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Motivo de rechace:"
        '
        'BtnRechazarPago
        '
        Me.BtnRechazarPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnRechazarPago.Image = Global.Disar.My.Resources.Resources.Adblock_Dark_32
        Me.BtnRechazarPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRechazarPago.Location = New System.Drawing.Point(372, 157)
        Me.BtnRechazarPago.Name = "BtnRechazarPago"
        Me.BtnRechazarPago.Size = New System.Drawing.Size(121, 39)
        Me.BtnRechazarPago.TabIndex = 8
        Me.BtnRechazarPago.Text = "Rechazar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cheque"
        Me.BtnRechazarPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRechazarPago.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(117, 118)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(376, 20)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Visible = False
        '
        'FrmRechazaCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 208)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnRechazarPago)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LCheque)
        Me.Controls.Add(Me.LMonto)
        Me.Controls.Add(Me.LCliente)
        Me.Controls.Add(Me.ComboBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRechazaCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rechazar Cheque"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents LCheque As System.Windows.Forms.Label
    Friend WithEvents LMonto As System.Windows.Forms.Label
    Friend WithEvents LCliente As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnRechazarPago As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
