﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPromoAPromo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPromoAPromo))
        Me.grd_detalles = New System.Windows.Forms.DataGridView
        Me.colPROMO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCodigoPromo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCantPromo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUnidadPromo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLotePromo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCodigoProducto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCantidadProducto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUnidadProducto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoteProducto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupProducto = New System.Windows.Forms.GroupBox
        Me.ComboUnidadProducto = New System.Windows.Forms.ComboBox
        Me.TxtCantidadSalida = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtLoteProducto = New System.Windows.Forms.TextBox
        Me.TxtCodigoProd = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCantidadEntrada = New System.Windows.Forms.TextBox
        Me.ComboConcepto = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtUnidadEntrada = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtDescripcionPromo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtLotePromo = New System.Windows.Forms.TextBox
        Me.TxtCodigoPromo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnLotes = New System.Windows.Forms.Button
        Me.BtnAgregar = New System.Windows.Forms.Button
        Me.BtnBuscaProducto = New System.Windows.Forms.Button
        Me.BtnBuscaPromo = New System.Windows.Forms.Button
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.BtnCancelar = New System.Windows.Forms.Button
        CType(Me.grd_detalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupProducto.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grd_detalles
        '
        Me.grd_detalles.AllowUserToAddRows = False
        Me.grd_detalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_detalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_detalles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPROMO, Me.colCodigoPromo, Me.colCantPromo, Me.colUnidadPromo, Me.colLotePromo, Me.ColCodigoProducto, Me.colCantidadProducto, Me.colUnidadProducto, Me.colLoteProducto, Me.colConcepto})
        Me.grd_detalles.Location = New System.Drawing.Point(0, 3)
        Me.grd_detalles.MultiSelect = False
        Me.grd_detalles.Name = "grd_detalles"
        Me.grd_detalles.ReadOnly = True
        Me.grd_detalles.Size = New System.Drawing.Size(938, 240)
        Me.grd_detalles.TabIndex = 2
        '
        'colPROMO
        '
        Me.colPROMO.FillWeight = 386.1003!
        Me.colPROMO.HeaderText = "CARGA EN PRODUCTO"
        Me.colPROMO.Name = "colPROMO"
        Me.colPROMO.ReadOnly = True
        Me.colPROMO.Width = 300
        '
        'colCodigoPromo
        '
        Me.colCodigoPromo.FillWeight = 66.64865!
        Me.colCodigoPromo.HeaderText = "Código Promo Salida"
        Me.colCodigoPromo.Name = "colCodigoPromo"
        Me.colCodigoPromo.ReadOnly = True
        '
        'colCantPromo
        '
        Me.colCantPromo.FillWeight = 63.52912!
        Me.colCantPromo.HeaderText = "Cantidad Promo Salida"
        Me.colCantPromo.Name = "colCantPromo"
        Me.colCantPromo.ReadOnly = True
        '
        'colUnidadPromo
        '
        Me.colUnidadPromo.FillWeight = 60.81105!
        Me.colUnidadPromo.HeaderText = "Unidad Salida"
        Me.colUnidadPromo.Name = "colUnidadPromo"
        Me.colUnidadPromo.ReadOnly = True
        '
        'colLotePromo
        '
        Me.colLotePromo.FillWeight = 58.44282!
        Me.colLotePromo.HeaderText = "Lote Promo Salida"
        Me.colLotePromo.Name = "colLotePromo"
        Me.colLotePromo.ReadOnly = True
        '
        'ColCodigoProducto
        '
        Me.ColCodigoProducto.FillWeight = 84.4671!
        Me.ColCodigoProducto.HeaderText = "Código Promo Entrada"
        Me.ColCodigoProducto.Name = "ColCodigoProducto"
        Me.ColCodigoProducto.ReadOnly = True
        '
        'colCantidadProducto
        '
        Me.colCantidadProducto.FillWeight = 79.05432!
        Me.colCantidadProducto.HeaderText = "Cantidad Entrada"
        Me.colCantidadProducto.Name = "colCantidadProducto"
        Me.colCantidadProducto.ReadOnly = True
        '
        'colUnidadProducto
        '
        Me.colUnidadProducto.FillWeight = 74.33818!
        Me.colUnidadProducto.HeaderText = "Unidad Entrada"
        Me.colUnidadProducto.Name = "colUnidadProducto"
        Me.colUnidadProducto.ReadOnly = True
        '
        'colLoteProducto
        '
        Me.colLoteProducto.FillWeight = 70.22897!
        Me.colLoteProducto.HeaderText = "Lote Promo Entrada"
        Me.colLoteProducto.Name = "colLoteProducto"
        Me.colLoteProducto.ReadOnly = True
        '
        'colConcepto
        '
        Me.colConcepto.FillWeight = 56.37937!
        Me.colConcepto.HeaderText = "Concepto Prov"
        Me.colConcepto.Name = "colConcepto"
        Me.colConcepto.ReadOnly = True
        '
        'GroupProducto
        '
        Me.GroupProducto.Controls.Add(Me.ComboUnidadProducto)
        Me.GroupProducto.Controls.Add(Me.BtnAgregar)
        Me.GroupProducto.Controls.Add(Me.BtnBuscaProducto)
        Me.GroupProducto.Controls.Add(Me.TxtCantidadSalida)
        Me.GroupProducto.Controls.Add(Me.Label5)
        Me.GroupProducto.Controls.Add(Me.Label4)
        Me.GroupProducto.Controls.Add(Me.TxtDescripcion)
        Me.GroupProducto.Controls.Add(Me.Label2)
        Me.GroupProducto.Controls.Add(Me.TxtLoteProducto)
        Me.GroupProducto.Controls.Add(Me.TxtCodigoProd)
        Me.GroupProducto.Controls.Add(Me.Label11)
        Me.GroupProducto.Controls.Add(Me.Label1)
        Me.GroupProducto.Location = New System.Drawing.Point(423, 11)
        Me.GroupProducto.Name = "GroupProducto"
        Me.GroupProducto.Size = New System.Drawing.Size(409, 194)
        Me.GroupProducto.TabIndex = 16
        Me.GroupProducto.TabStop = False
        Me.GroupProducto.Text = "Información de la promoción de entrada:"
        '
        'ComboUnidadProducto
        '
        Me.ComboUnidadProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUnidadProducto.FormattingEnabled = True
        Me.ComboUnidadProducto.Location = New System.Drawing.Point(175, 88)
        Me.ComboUnidadProducto.Name = "ComboUnidadProducto"
        Me.ComboUnidadProducto.Size = New System.Drawing.Size(217, 21)
        Me.ComboUnidadProducto.TabIndex = 5
        '
        'TxtCantidadSalida
        '
        Me.TxtCantidadSalida.Enabled = False
        Me.TxtCantidadSalida.Location = New System.Drawing.Point(130, 117)
        Me.TxtCantidadSalida.Name = "TxtCantidadSalida"
        Me.TxtCantidadSalida.Size = New System.Drawing.Size(262, 20)
        Me.TxtCantidadSalida.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Cantidad de entrada:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Unidad de entrada de la promo:"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Location = New System.Drawing.Point(130, 63)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(262, 20)
        Me.TxtDescripcion.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descripción:"
        '
        'TxtLoteProducto
        '
        Me.TxtLoteProducto.Enabled = False
        Me.TxtLoteProducto.Location = New System.Drawing.Point(345, 37)
        Me.TxtLoteProducto.Name = "TxtLoteProducto"
        Me.TxtLoteProducto.Size = New System.Drawing.Size(47, 20)
        Me.TxtLoteProducto.TabIndex = 1
        '
        'TxtCodigoProd
        '
        Me.TxtCodigoProd.Enabled = False
        Me.TxtCodigoProd.Location = New System.Drawing.Point(130, 37)
        Me.TxtCodigoProd.Name = "TxtCodigoProd"
        Me.TxtCodigoProd.Size = New System.Drawing.Size(127, 20)
        Me.TxtCodigoProd.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(308, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Lote:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código de Promo:"
        '
        'TxtCantidadEntrada
        '
        Me.TxtCantidadEntrada.Enabled = False
        Me.TxtCantidadEntrada.Location = New System.Drawing.Point(130, 115)
        Me.TxtCantidadEntrada.Name = "TxtCantidadEntrada"
        Me.TxtCantidadEntrada.Size = New System.Drawing.Size(265, 20)
        Me.TxtCantidadEntrada.TabIndex = 1
        '
        'ComboConcepto
        '
        Me.ComboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboConcepto.FormattingEnabled = True
        Me.ComboConcepto.Location = New System.Drawing.Point(130, 144)
        Me.ComboConcepto.Name = "ComboConcepto"
        Me.ComboConcepto.Size = New System.Drawing.Size(265, 21)
        Me.ComboConcepto.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cantidad de salida:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 147)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Concepto Proveedor:"
        '
        'TxtUnidadEntrada
        '
        Me.TxtUnidadEntrada.Enabled = False
        Me.TxtUnidadEntrada.Location = New System.Drawing.Point(130, 89)
        Me.TxtUnidadEntrada.Name = "TxtUnidadEntrada"
        Me.TxtUnidadEntrada.Size = New System.Drawing.Size(265, 20)
        Me.TxtUnidadEntrada.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnBuscaPromo)
        Me.GroupBox1.Controls.Add(Me.TxtCantidadEntrada)
        Me.GroupBox1.Controls.Add(Me.ComboConcepto)
        Me.GroupBox1.Controls.Add(Me.TxtUnidadEntrada)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtDescripcionPromo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TxtLotePromo)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoPromo)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 194)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de la promoción de salida: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Unidad de promoción:"
        '
        'TxtDescripcionPromo
        '
        Me.TxtDescripcionPromo.Enabled = False
        Me.TxtDescripcionPromo.Location = New System.Drawing.Point(130, 63)
        Me.TxtDescripcionPromo.Name = "TxtDescripcionPromo"
        Me.TxtDescripcionPromo.Size = New System.Drawing.Size(265, 20)
        Me.TxtDescripcionPromo.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Descripción:"
        '
        'TxtLotePromo
        '
        Me.TxtLotePromo.Enabled = False
        Me.TxtLotePromo.Location = New System.Drawing.Point(344, 37)
        Me.TxtLotePromo.Name = "TxtLotePromo"
        Me.TxtLotePromo.Size = New System.Drawing.Size(51, 20)
        Me.TxtLotePromo.TabIndex = 1
        '
        'TxtCodigoPromo
        '
        Me.TxtCodigoPromo.Enabled = False
        Me.TxtCodigoPromo.Location = New System.Drawing.Point(130, 37)
        Me.TxtCodigoPromo.Name = "TxtCodigoPromo"
        Me.TxtCodigoPromo.Size = New System.Drawing.Size(127, 20)
        Me.TxtCodigoPromo.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(307, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Lote:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Código de promo:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.grd_detalles)
        Me.Panel1.Location = New System.Drawing.Point(12, 216)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(938, 252)
        Me.Panel1.TabIndex = 14
        '
        'BtnLotes
        '
        Me.BtnLotes.Image = Global.Disar.My.Resources.Resources.Archivos
        Me.BtnLotes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLotes.Location = New System.Drawing.Point(855, 161)
        Me.BtnLotes.Name = "BtnLotes"
        Me.BtnLotes.Size = New System.Drawing.Size(95, 44)
        Me.BtnLotes.TabIndex = 17
        Me.BtnLotes.Text = "Ver Lotes"
        Me.BtnLotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnLotes.UseVisualStyleBackColor = True
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Enabled = False
        Me.BtnAgregar.Image = Global.Disar.My.Resources.Resources.Productos
        Me.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgregar.Location = New System.Drawing.Point(21, 152)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(83, 36)
        Me.BtnAgregar.TabIndex = 3
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'BtnBuscaProducto
        '
        Me.BtnBuscaProducto.BackgroundImage = Global.Disar.My.Resources.Resources.lupa_icono_3813_32
        Me.BtnBuscaProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnBuscaProducto.Enabled = False
        Me.BtnBuscaProducto.Location = New System.Drawing.Point(258, 33)
        Me.BtnBuscaProducto.Name = "BtnBuscaProducto"
        Me.BtnBuscaProducto.Size = New System.Drawing.Size(27, 27)
        Me.BtnBuscaProducto.TabIndex = 2
        Me.BtnBuscaProducto.UseVisualStyleBackColor = True
        '
        'BtnBuscaPromo
        '
        Me.BtnBuscaPromo.BackgroundImage = Global.Disar.My.Resources.Resources.lupa_icono_3813_32
        Me.BtnBuscaPromo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnBuscaPromo.Location = New System.Drawing.Point(258, 33)
        Me.BtnBuscaPromo.Name = "BtnBuscaPromo"
        Me.BtnBuscaPromo.Size = New System.Drawing.Size(27, 27)
        Me.BtnBuscaPromo.TabIndex = 2
        Me.BtnBuscaPromo.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = Global.Disar.My.Resources.Resources.img_aceptar
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(819, 486)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(131, 44)
        Me.BtnGuardar.TabIndex = 12
        Me.BtnGuardar.Text = "Guardar Cambios"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(12, 486)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(92, 44)
        Me.BtnCancelar.TabIndex = 13
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'FormPromoAPromo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 541)
        Me.Controls.Add(Me.BtnLotes)
        Me.Controls.Add(Me.GroupProducto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormPromoAPromo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traslado de Promoción a Promoción"
        CType(Me.grd_detalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupProducto.ResumeLayout(False)
        Me.GroupProducto.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grd_detalles As System.Windows.Forms.DataGridView
    Friend WithEvents GroupProducto As System.Windows.Forms.GroupBox
    Friend WithEvents ComboUnidadProducto As System.Windows.Forms.ComboBox
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents BtnBuscaProducto As System.Windows.Forms.Button
    Friend WithEvents TxtCantidadSalida As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtLoteProducto As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoProd As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaPromo As System.Windows.Forms.Button
    Friend WithEvents TxtCantidadEntrada As System.Windows.Forms.TextBox
    Friend WithEvents ComboConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtUnidadEntrada As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcionPromo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtLotePromo As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoPromo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents colPROMO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigoPromo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantPromo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnidadPromo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLotePromo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCodigoProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidadProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnidadProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoteProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnLotes As System.Windows.Forms.Button
End Class
