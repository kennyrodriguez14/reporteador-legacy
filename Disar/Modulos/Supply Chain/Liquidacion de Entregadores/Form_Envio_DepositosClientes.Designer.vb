<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Envio_DepositosClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Envio_DepositosClientes))
        Me.TextTotalAutorizado = New System.Windows.Forms.TextBox
        Me.TextEntregadorNombre = New System.Windows.Forms.TextBox
        Me.btnEnviar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.N_Almacen = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextTotalIngresado = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextDeposito = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextEntregadorID = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextFecha = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextTipo = New System.Windows.Forms.TextBox
        Me.TextRuta = New System.Windows.Forms.TextBox
        Me.TextLiquidacion = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBanco = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextCuenta = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextTotalAutorizado
        '
        Me.TextTotalAutorizado.Location = New System.Drawing.Point(248, 159)
        Me.TextTotalAutorizado.Name = "TextTotalAutorizado"
        Me.TextTotalAutorizado.Size = New System.Drawing.Size(100, 20)
        Me.TextTotalAutorizado.TabIndex = 1
        '
        'TextEntregadorNombre
        '
        Me.TextEntregadorNombre.Enabled = False
        Me.TextEntregadorNombre.Location = New System.Drawing.Point(188, 117)
        Me.TextEntregadorNombre.Name = "TextEntregadorNombre"
        Me.TextEntregadorNombre.Size = New System.Drawing.Size(211, 20)
        Me.TextEntregadorNombre.TabIndex = 1
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(637, 225)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 27)
        Me.btnEnviar.TabIndex = 4
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TextCuenta)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TextBanco)
        Me.GroupBox1.Controls.Add(Me.N_Almacen)
        Me.GroupBox1.Controls.Add(Me.TextTotalAutorizado)
        Me.GroupBox1.Controls.Add(Me.TextEntregadorNombre)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextTotalIngresado)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextDeposito)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextEntregadorID)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextFecha)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextTipo)
        Me.GroupBox1.Controls.Add(Me.TextRuta)
        Me.GroupBox1.Controls.Add(Me.TextLiquidacion)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(700, 207)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'N_Almacen
        '
        Me.N_Almacen.AutoSize = True
        Me.N_Almacen.Location = New System.Drawing.Point(450, 60)
        Me.N_Almacen.Name = "N_Almacen"
        Me.N_Almacen.Size = New System.Drawing.Size(15, 13)
        Me.N_Almacen.TabIndex = 4
        Me.N_Almacen.Text = "♦"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = " Nº de Liquidación"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Fecha de Facturación:"
        '
        'TextTotalIngresado
        '
        Me.TextTotalIngresado.Enabled = False
        Me.TextTotalIngresado.Location = New System.Drawing.Point(139, 159)
        Me.TextTotalIngresado.Name = "TextTotalIngresado"
        Me.TextTotalIngresado.Size = New System.Drawing.Size(100, 20)
        Me.TextTotalIngresado.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Entregador:"
        '
        'TextDeposito
        '
        Me.TextDeposito.Location = New System.Drawing.Point(556, 118)
        Me.TextDeposito.Name = "TextDeposito"
        Me.TextDeposito.Size = New System.Drawing.Size(100, 20)
        Me.TextDeposito.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(490, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nº Depósito:"
        '
        'TextEntregadorID
        '
        Me.TextEntregadorID.Enabled = False
        Me.TextEntregadorID.Location = New System.Drawing.Point(139, 117)
        Me.TextEntregadorID.Name = "TextEntregadorID"
        Me.TextEntregadorID.Size = New System.Drawing.Size(43, 20)
        Me.TextEntregadorID.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total a Depositar:"
        '
        'TextFecha
        '
        Me.TextFecha.Location = New System.Drawing.Point(139, 57)
        Me.TextFecha.Name = "TextFecha"
        Me.TextFecha.Size = New System.Drawing.Size(100, 20)
        Me.TextFecha.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(405, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Almacen"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(245, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Tipo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(245, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ruta:"
        '
        'TextTipo
        '
        Me.TextTipo.Enabled = False
        Me.TextTipo.Location = New System.Drawing.Point(284, 57)
        Me.TextTipo.Name = "TextTipo"
        Me.TextTipo.Size = New System.Drawing.Size(115, 20)
        Me.TextTipo.TabIndex = 1
        '
        'TextRuta
        '
        Me.TextRuta.Enabled = False
        Me.TextRuta.Location = New System.Drawing.Point(284, 28)
        Me.TextRuta.Name = "TextRuta"
        Me.TextRuta.Size = New System.Drawing.Size(225, 20)
        Me.TextRuta.TabIndex = 1
        '
        'TextLiquidacion
        '
        Me.TextLiquidacion.Enabled = False
        Me.TextLiquidacion.Location = New System.Drawing.Point(139, 28)
        Me.TextLiquidacion.Name = "TextLiquidacion"
        Me.TextLiquidacion.Size = New System.Drawing.Size(100, 20)
        Me.TextLiquidacion.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label7.Location = New System.Drawing.Point(165, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 12)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Ingresado"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label8.Location = New System.Drawing.Point(274, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 12)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Autorizado"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(517, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Banco:"
        '
        'TextBanco
        '
        Me.TextBanco.Enabled = False
        Me.TextBanco.Location = New System.Drawing.Point(556, 28)
        Me.TextBanco.Name = "TextBanco"
        Me.TextBanco.Size = New System.Drawing.Size(138, 20)
        Me.TextBanco.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(514, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Cuenta:"
        '
        'TextCuenta
        '
        Me.TextCuenta.Enabled = False
        Me.TextCuenta.Location = New System.Drawing.Point(556, 57)
        Me.TextCuenta.Name = "TextCuenta"
        Me.TextCuenta.Size = New System.Drawing.Size(138, 20)
        Me.TextCuenta.TabIndex = 8
        '
        'Form_Envio_DepositosClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 280)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Envio_DepositosClientes"
        Me.Text = "Envío de Depósitos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextTotalAutorizado As System.Windows.Forms.TextBox
    Friend WithEvents TextEntregadorNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents N_Almacen As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextTotalIngresado As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextDeposito As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextEntregadorID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextTipo As System.Windows.Forms.TextBox
    Friend WithEvents TextRuta As System.Windows.Forms.TextBox
    Friend WithEvents TextLiquidacion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBanco As System.Windows.Forms.TextBox
End Class
