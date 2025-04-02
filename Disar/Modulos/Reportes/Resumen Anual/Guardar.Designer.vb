<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuardarArchivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuardarArchivo))
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblruta = New System.Windows.Forms.Label
        Me.btnEspecificar = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.BuscarCarpeta = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ruta:"
        '
        'lblruta
        '
        Me.lblruta.AutoSize = True
        Me.lblruta.Location = New System.Drawing.Point(53, 18)
        Me.lblruta.Name = "lblruta"
        Me.lblruta.Size = New System.Drawing.Size(145, 13)
        Me.lblruta.TabIndex = 1
        Me.lblruta.Text = "C:\Reportes\Resumen Anual"
        '
        'btnEspecificar
        '
        Me.btnEspecificar.Location = New System.Drawing.Point(9, 56)
        Me.btnEspecificar.Name = "btnEspecificar"
        Me.btnEspecificar.Size = New System.Drawing.Size(75, 23)
        Me.btnEspecificar.TabIndex = 2
        Me.btnEspecificar.Text = "Seleccionar"
        Me.btnEspecificar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(192, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmGuardarArchivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 91)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnEspecificar)
        Me.Controls.Add(Me.lblruta)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGuardarArchivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guardar"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblruta As System.Windows.Forms.Label
    Friend WithEvents btnEspecificar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BuscarCarpeta As System.Windows.Forms.FolderBrowserDialog
End Class
