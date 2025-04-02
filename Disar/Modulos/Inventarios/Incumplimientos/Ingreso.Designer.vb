<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ingreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ingreso))
        Me.grp_Ingreso = New System.Windows.Forms.GroupBox
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.cmbFecha = New System.Windows.Forms.DateTimePicker
        Me.btnAyuda = New System.Windows.Forms.Button
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.grp_Ingreso.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_Ingreso
        '
        Me.grp_Ingreso.Controls.Add(Me.btnAceptar)
        Me.grp_Ingreso.Controls.Add(Me.cmbFecha)
        Me.grp_Ingreso.Controls.Add(Me.btnAyuda)
        Me.grp_Ingreso.Controls.Add(Me.txtCliente)
        Me.grp_Ingreso.Controls.Add(Me.txtCantidad)
        Me.grp_Ingreso.Controls.Add(Me.txtCodigo)
        Me.grp_Ingreso.Controls.Add(Me.Label1)
        Me.grp_Ingreso.Controls.Add(Me.Label4)
        Me.grp_Ingreso.Controls.Add(Me.Label3)
        Me.grp_Ingreso.Controls.Add(Me.lblCodigo)
        Me.grp_Ingreso.Location = New System.Drawing.Point(13, 12)
        Me.grp_Ingreso.Name = "grp_Ingreso"
        Me.grp_Ingreso.Size = New System.Drawing.Size(609, 311)
        Me.grp_Ingreso.TabIndex = 3
        Me.grp_Ingreso.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(268, 225)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(104, 41)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'cmbFecha
        '
        Me.cmbFecha.Location = New System.Drawing.Point(268, 167)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.Size = New System.Drawing.Size(198, 20)
        Me.cmbFecha.TabIndex = 5
        '
        'btnAyuda
        '
        Me.btnAyuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAyuda.Location = New System.Drawing.Point(473, 52)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(25, 20)
        Me.btnAyuda.TabIndex = 2
        Me.btnAyuda.Text = "?"
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(268, 92)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(198, 20)
        Me.txtCantidad.TabIndex = 3
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(268, 52)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(198, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(198, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(84, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(178, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Cantidad Incumplida:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(86, 52)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(176, 20)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Codigo del Producto:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(102, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo del Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(268, 129)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(198, 20)
        Me.txtCliente.TabIndex = 4
        '
        'Ingreso
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 335)
        Me.Controls.Add(Me.grp_Ingreso)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Ingreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso"
        Me.grp_Ingreso.ResumeLayout(False)
        Me.grp_Ingreso.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp_Ingreso As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents cmbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
