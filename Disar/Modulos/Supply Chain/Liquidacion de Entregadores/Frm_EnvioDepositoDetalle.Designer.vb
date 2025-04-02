<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_EnvioDepositoDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_EnvioDepositoDetalle))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextLiquidacion = New System.Windows.Forms.TextBox
        Me.TextRuta = New System.Windows.Forms.TextBox
        Me.TextFecha = New System.Windows.Forms.TextBox
        Me.TextEntregadorID = New System.Windows.Forms.TextBox
        Me.TextEntregadorNombre = New System.Windows.Forms.TextBox
        Me.TextDeposito = New System.Windows.Forms.TextBox
        Me.TextTotalIngresado = New System.Windows.Forms.TextBox
        Me.TextTotalAutorizado = New System.Windows.Forms.TextBox
        Me.btnEnviar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.N_Almacen = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextTipo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Entregador:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nº Depósito:"
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(245, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ruta:"
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
        'TextLiquidacion
        '
        Me.TextLiquidacion.Enabled = False
        Me.TextLiquidacion.Location = New System.Drawing.Point(139, 28)
        Me.TextLiquidacion.Name = "TextLiquidacion"
        Me.TextLiquidacion.Size = New System.Drawing.Size(100, 20)
        Me.TextLiquidacion.TabIndex = 1
        '
        'TextRuta
        '
        Me.TextRuta.Enabled = False
        Me.TextRuta.Location = New System.Drawing.Point(284, 28)
        Me.TextRuta.Name = "TextRuta"
        Me.TextRuta.Size = New System.Drawing.Size(225, 20)
        Me.TextRuta.TabIndex = 1
        '
        'TextFecha
        '
        Me.TextFecha.Location = New System.Drawing.Point(139, 57)
        Me.TextFecha.Name = "TextFecha"
        Me.TextFecha.Size = New System.Drawing.Size(100, 20)
        Me.TextFecha.TabIndex = 1
        '
        'TextEntregadorID
        '
        Me.TextEntregadorID.Enabled = False
        Me.TextEntregadorID.Location = New System.Drawing.Point(139, 86)
        Me.TextEntregadorID.Name = "TextEntregadorID"
        Me.TextEntregadorID.Size = New System.Drawing.Size(43, 20)
        Me.TextEntregadorID.TabIndex = 1
        '
        'TextEntregadorNombre
        '
        Me.TextEntregadorNombre.Enabled = False
        Me.TextEntregadorNombre.Location = New System.Drawing.Point(188, 86)
        Me.TextEntregadorNombre.Name = "TextEntregadorNombre"
        Me.TextEntregadorNombre.Size = New System.Drawing.Size(211, 20)
        Me.TextEntregadorNombre.TabIndex = 1
        '
        'TextDeposito
        '
        Me.TextDeposito.Location = New System.Drawing.Point(139, 115)
        Me.TextDeposito.Name = "TextDeposito"
        Me.TextDeposito.Size = New System.Drawing.Size(100, 20)
        Me.TextDeposito.TabIndex = 1
        '
        'TextTotalIngresado
        '
        Me.TextTotalIngresado.Enabled = False
        Me.TextTotalIngresado.Location = New System.Drawing.Point(139, 159)
        Me.TextTotalIngresado.Name = "TextTotalIngresado"
        Me.TextTotalIngresado.Size = New System.Drawing.Size(100, 20)
        Me.TextTotalIngresado.TabIndex = 1
        '
        'TextTotalAutorizado
        '
        Me.TextTotalAutorizado.Location = New System.Drawing.Point(248, 159)
        Me.TextTotalAutorizado.Name = "TextTotalAutorizado"
        Me.TextTotalAutorizado.Size = New System.Drawing.Size(100, 20)
        Me.TextTotalAutorizado.TabIndex = 1
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(457, 226)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 27)
        Me.btnEnviar.TabIndex = 2
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
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
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 207)
        Me.GroupBox1.TabIndex = 3
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
        'TextTipo
        '
        Me.TextTipo.Enabled = False
        Me.TextTipo.Location = New System.Drawing.Point(284, 57)
        Me.TextTipo.Name = "TextTipo"
        Me.TextTipo.Size = New System.Drawing.Size(115, 20)
        Me.TextTipo.TabIndex = 1
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
        'Frm_EnvioDepositoDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 263)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_EnvioDepositoDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envío de Depósito a Bancos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextLiquidacion As System.Windows.Forms.TextBox
    Friend WithEvents TextRuta As System.Windows.Forms.TextBox
    Friend WithEvents TextFecha As System.Windows.Forms.TextBox
    Friend WithEvents TextEntregadorID As System.Windows.Forms.TextBox
    Friend WithEvents TextEntregadorNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextDeposito As System.Windows.Forms.TextBox
    Friend WithEvents TextTotalIngresado As System.Windows.Forms.TextBox
    Friend WithEvents TextTotalAutorizado As System.Windows.Forms.TextBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextTipo As System.Windows.Forms.TextBox
    Friend WithEvents N_Almacen As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
