<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Completar_Orden_Pedido_Agro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Completar_Orden_Pedido_Agro))
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextEstado = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.Btn_Volver = New System.Windows.Forms.Button
        Me.TextCompra = New System.Windows.Forms.TextBox
        Me.TextFechaCompra = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextSolicitante = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextNumero = New System.Windows.Forms.TextBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextNumProv = New System.Windows.Forms.TextBox
        Me.TextProveedor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextAlmacen = New System.Windows.Forms.TextBox
        Me.DataPedidos = New System.Windows.Forms.DataGridView
        Me.TextDescripcionSucursal = New System.Windows.Forms.TextBox
        Me.TextTipo = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextFechaSol = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        CType(Me.DataPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(706, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Estado:"
        '
        'TextEstado
        '
        Me.TextEstado.Enabled = False
        Me.TextEstado.Location = New System.Drawing.Point(822, 17)
        Me.TextEstado.Name = "TextEstado"
        Me.TextEstado.Size = New System.Drawing.Size(144, 20)
        Me.TextEstado.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(706, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Usuario Compra:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(415, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Fecha de Compra:"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(721, 563)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(141, 42)
        Me.BtnCancelar.TabIndex = 25
        Me.BtnCancelar.Text = "Cancelar Pedido"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'Btn_Volver
        '
        Me.Btn_Volver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Volver.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Volver.Image = Global.Disar.My.Resources.Resources.Atras
        Me.Btn_Volver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Volver.Location = New System.Drawing.Point(12, 563)
        Me.Btn_Volver.Name = "Btn_Volver"
        Me.Btn_Volver.Size = New System.Drawing.Size(89, 42)
        Me.Btn_Volver.TabIndex = 26
        Me.Btn_Volver.Text = "Volver"
        Me.Btn_Volver.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Volver.UseVisualStyleBackColor = True
        '
        'TextCompra
        '
        Me.TextCompra.Enabled = False
        Me.TextCompra.Location = New System.Drawing.Point(822, 69)
        Me.TextCompra.Name = "TextCompra"
        Me.TextCompra.Size = New System.Drawing.Size(144, 20)
        Me.TextCompra.TabIndex = 14
        '
        'TextFechaCompra
        '
        Me.TextFechaCompra.Enabled = False
        Me.TextFechaCompra.Location = New System.Drawing.Point(519, 69)
        Me.TextFechaCompra.Name = "TextFechaCompra"
        Me.TextFechaCompra.Size = New System.Drawing.Size(132, 20)
        Me.TextFechaCompra.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(706, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Usuario Solicitante:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(415, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Fecha de Solicitud:"
        '
        'TextSolicitante
        '
        Me.TextSolicitante.Enabled = False
        Me.TextSolicitante.Location = New System.Drawing.Point(822, 43)
        Me.TextSolicitante.Name = "TextSolicitante"
        Me.TextSolicitante.Size = New System.Drawing.Size(144, 20)
        Me.TextSolicitante.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nº Orden de Compra:"
        '
        'TextNumero
        '
        Me.TextNumero.Enabled = False
        Me.TextNumero.Location = New System.Drawing.Point(117, 17)
        Me.TextNumero.Name = "TextNumero"
        Me.TextNumero.Size = New System.Drawing.Size(52, 20)
        Me.TextNumero.TabIndex = 3
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_aceptar.Location = New System.Drawing.Point(868, 563)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(156, 42)
        Me.btn_aceptar.TabIndex = 24
        Me.btn_aceptar.Text = "Imprimir Recepción"
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Proveedor:"
        '
        'TextNumProv
        '
        Me.TextNumProv.Enabled = False
        Me.TextNumProv.Location = New System.Drawing.Point(117, 43)
        Me.TextNumProv.Name = "TextNumProv"
        Me.TextNumProv.Size = New System.Drawing.Size(52, 20)
        Me.TextNumProv.TabIndex = 5
        '
        'TextProveedor
        '
        Me.TextProveedor.Enabled = False
        Me.TextProveedor.Location = New System.Drawing.Point(175, 43)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.Size = New System.Drawing.Size(215, 20)
        Me.TextProveedor.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Almacén:"
        '
        'TextAlmacen
        '
        Me.TextAlmacen.Enabled = False
        Me.TextAlmacen.Location = New System.Drawing.Point(117, 69)
        Me.TextAlmacen.Name = "TextAlmacen"
        Me.TextAlmacen.Size = New System.Drawing.Size(52, 20)
        Me.TextAlmacen.TabIndex = 8
        '
        'DataPedidos
        '
        Me.DataPedidos.AllowUserToAddRows = False
        Me.DataPedidos.AllowUserToDeleteRows = False
        Me.DataPedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataPedidos.Location = New System.Drawing.Point(12, 126)
        Me.DataPedidos.Name = "DataPedidos"
        Me.DataPedidos.Size = New System.Drawing.Size(1012, 431)
        Me.DataPedidos.TabIndex = 22
        '
        'TextDescripcionSucursal
        '
        Me.TextDescripcionSucursal.Enabled = False
        Me.TextDescripcionSucursal.Location = New System.Drawing.Point(175, 69)
        Me.TextDescripcionSucursal.Name = "TextDescripcionSucursal"
        Me.TextDescripcionSucursal.Size = New System.Drawing.Size(215, 20)
        Me.TextDescripcionSucursal.TabIndex = 9
        '
        'TextTipo
        '
        Me.TextTipo.Enabled = False
        Me.TextTipo.Location = New System.Drawing.Point(519, 17)
        Me.TextTipo.Name = "TextTipo"
        Me.TextTipo.Size = New System.Drawing.Size(132, 20)
        Me.TextTipo.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextEstado)
        Me.GroupBox1.Controls.Add(Me.TextNumero)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextNumProv)
        Me.GroupBox1.Controls.Add(Me.TextCompra)
        Me.GroupBox1.Controls.Add(Me.TextProveedor)
        Me.GroupBox1.Controls.Add(Me.TextFechaCompra)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TextAlmacen)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextDescripcionSucursal)
        Me.GroupBox1.Controls.Add(Me.TextSolicitante)
        Me.GroupBox1.Controls.Add(Me.TextTipo)
        Me.GroupBox1.Controls.Add(Me.TextFechaSol)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1012, 106)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'TextFechaSol
        '
        Me.TextFechaSol.Enabled = False
        Me.TextFechaSol.Location = New System.Drawing.Point(519, 43)
        Me.TextFechaSol.Name = "TextFechaSol"
        Me.TextFechaSol.Size = New System.Drawing.Size(132, 20)
        Me.TextFechaSol.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(415, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Tipo de Compra:"
        '
        'Frm_Completar_Orden_Pedido_Agro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 615)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.Btn_Volver)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.DataPedidos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Completar_Orden_Pedido_Agro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Completar Orden de Pedido SR Agro"
        CType(Me.DataPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Volver As System.Windows.Forms.Button
    Friend WithEvents TextCompra As System.Windows.Forms.TextBox
    Friend WithEvents TextFechaCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextNumero As System.Windows.Forms.TextBox
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextNumProv As System.Windows.Forms.TextBox
    Friend WithEvents TextProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents DataPedidos As System.Windows.Forms.DataGridView
    Friend WithEvents TextDescripcionSucursal As System.Windows.Forms.TextBox
    Friend WithEvents TextTipo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextFechaSol As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
