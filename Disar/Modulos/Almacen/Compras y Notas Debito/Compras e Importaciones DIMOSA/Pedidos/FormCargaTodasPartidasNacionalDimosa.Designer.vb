<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCargaTodasPartidasCompraNacionalDimosa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCargaTodasPartidasCompraNacionalDimosa))
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.TextBuscar = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txt_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmb_uni = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.txt_codigo_producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_nombre_producto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_factor_conversion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_uni_entrada = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_calcular = New System.Windows.Forms.DataGridViewButtonColumn
        Me.txt_precio_final = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_precio_neg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_descuento_por = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_isv_por = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_con_lote = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodProv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Registrar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ColCantidadAnterior = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.txt_cantidad, Me.cmb_uni, Me.txt_codigo_producto, Me.txt_nombre_producto, Me.txt_factor_conversion, Me.txt_uni_entrada, Me.btn_calcular, Me.txt_precio_final, Me.txt_precio_neg, Me.txt_descuento_por, Me.txt_isv_por, Me.txt_con_lote, Me.CodProv, Me.Registrar, Me.ColCantidadAnterior})
        Me.DataDatos.Location = New System.Drawing.Point(12, 48)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.RowHeadersWidth = 20
        Me.DataDatos.Size = New System.Drawing.Size(1100, 427)
        Me.DataDatos.TabIndex = 3
        '
        'TextBuscar
        '
        Me.TextBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBuscar.Location = New System.Drawing.Point(13, 22)
        Me.TextBuscar.Name = "TextBuscar"
        Me.TextBuscar.Size = New System.Drawing.Size(196, 20)
        Me.TextBuscar.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Disar.My.Resources.Resources.img_modulo_monitoreo
        Me.PictureBox1.Location = New System.Drawing.Point(209, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 34)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'txt_cantidad
        '
        Me.txt_cantidad.HeaderText = "Cantidad"
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Width = 74
        '
        'cmb_uni
        '
        Me.cmb_uni.HeaderText = "Unidad"
        Me.cmb_uni.Items.AddRange(New Object() {"pz", "cj"})
        Me.cmb_uni.Name = "cmb_uni"
        Me.cmb_uni.Width = 47
        '
        'txt_codigo_producto
        '
        Me.txt_codigo_producto.HeaderText = "Codigo"
        Me.txt_codigo_producto.Name = "txt_codigo_producto"
        Me.txt_codigo_producto.ReadOnly = True
        Me.txt_codigo_producto.Width = 65
        '
        'txt_nombre_producto
        '
        Me.txt_nombre_producto.HeaderText = "Producto"
        Me.txt_nombre_producto.Name = "txt_nombre_producto"
        Me.txt_nombre_producto.ReadOnly = True
        Me.txt_nombre_producto.Width = 75
        '
        'txt_factor_conversion
        '
        Me.txt_factor_conversion.HeaderText = "Factor Conversión"
        Me.txt_factor_conversion.Name = "txt_factor_conversion"
        Me.txt_factor_conversion.ReadOnly = True
        Me.txt_factor_conversion.Width = 108
        '
        'txt_uni_entrada
        '
        Me.txt_uni_entrada.HeaderText = "Unidad Entrada"
        Me.txt_uni_entrada.Name = "txt_uni_entrada"
        Me.txt_uni_entrada.ReadOnly = True
        Me.txt_uni_entrada.Width = 97
        '
        'btn_calcular
        '
        Me.btn_calcular.HeaderText = "..."
        Me.btn_calcular.Name = "btn_calcular"
        Me.btn_calcular.ReadOnly = True
        Me.btn_calcular.Width = 22
        '
        'txt_precio_final
        '
        Me.txt_precio_final.HeaderText = "Precio Final"
        Me.txt_precio_final.Name = "txt_precio_final"
        Me.txt_precio_final.Width = 80
        '
        'txt_precio_neg
        '
        Me.txt_precio_neg.HeaderText = "Precio Negociado"
        Me.txt_precio_neg.Name = "txt_precio_neg"
        Me.txt_precio_neg.ReadOnly = True
        Me.txt_precio_neg.Width = 107
        '
        'txt_descuento_por
        '
        Me.txt_descuento_por.HeaderText = "% Descuento"
        Me.txt_descuento_por.Name = "txt_descuento_por"
        Me.txt_descuento_por.Width = 88
        '
        'txt_isv_por
        '
        Me.txt_isv_por.HeaderText = "% ISV"
        Me.txt_isv_por.Name = "txt_isv_por"
        Me.txt_isv_por.Width = 56
        '
        'txt_con_lote
        '
        Me.txt_con_lote.HeaderText = "Con Lote"
        Me.txt_con_lote.Name = "txt_con_lote"
        Me.txt_con_lote.ReadOnly = True
        Me.txt_con_lote.Visible = False
        Me.txt_con_lote.Width = 70
        '
        'CodProv
        '
        Me.CodProv.HeaderText = "Cod Proveedor"
        Me.CodProv.Name = "CodProv"
        Me.CodProv.Width = 95
        '
        'Registrar
        '
        Me.Registrar.HeaderText = "✔"
        Me.Registrar.Name = "Registrar"
        Me.Registrar.ReadOnly = True
        Me.Registrar.Width = 25
        '
        'ColCantidadAnterior
        '
        Me.ColCantidadAnterior.HeaderText = "Cantidad Anterior"
        Me.ColCantidadAnterior.Name = "ColCantidadAnterior"
        Me.ColCantidadAnterior.ReadOnly = True
        Me.ColCantidadAnterior.Visible = False
        Me.ColCantidadAnterior.Width = 104
        '
        'FormCargaTodasPartidasCompraNacionalDimosa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1124, 486)
        Me.Controls.Add(Me.DataDatos)
        Me.Controls.Add(Me.TextBuscar)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormCargaTodasPartidasCompraNacionalDimosa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga Partidas Compra Nacional DIMOSA"
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents TextBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmb_uni As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txt_codigo_producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_nombre_producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_factor_conversion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_uni_entrada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_calcular As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents txt_precio_final As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_precio_neg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_descuento_por As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_isv_por As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_con_lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodProv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Registrar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ColCantidadAnterior As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
