<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLiquidacionesGuardadas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLiquidacionesGuardadas))
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.TextVehiculo = New System.Windows.Forms.TextBox
        Me.DataGastos = New System.Windows.Forms.DataGridView
        Me.DataPorcentajes = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Tipo = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Fecha = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.EntregadorNombre = New System.Windows.Forms.Label
        Me.Entregador = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Identidad = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PrecioComb = New System.Windows.Forms.Label
        Me.Ruta = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.NumeroLiquidacion = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Gastos = New System.Windows.Forms.GroupBox
        Me.NumeroDeposito = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TotalArqueo = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TotalGastos = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Liquidaciones = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.BtnExportar = New System.Windows.Forms.Button
        Me.BtnGenerar = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Btn_QuitarLiquidacion = New System.Windows.Forms.Button
        Me.Btn_EnviarGastos = New System.Windows.Forms.Button
        Me.BtnReImprimir = New System.Windows.Forms.Button
        Me.DataLiquidaciones = New System.Windows.Forms.DataGridView
        CType(Me.DataGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataPorcentajes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gastos.SuspendLayout()
        Me.Liquidaciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataLiquidaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(17, 485)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(94, 42)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.Image = Global.Disar.My.Resources.Resources.Gnome_Emblem_Default_32
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(991, 485)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(159, 42)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "Guardar y Enviar a CC"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'TextVehiculo
        '
        Me.TextVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextVehiculo.Location = New System.Drawing.Point(79, 127)
        Me.TextVehiculo.Name = "TextVehiculo"
        Me.TextVehiculo.Size = New System.Drawing.Size(33, 20)
        Me.TextVehiculo.TabIndex = 3
        '
        'DataGastos
        '
        Me.DataGastos.AllowUserToAddRows = False
        Me.DataGastos.AllowUserToDeleteRows = False
        Me.DataGastos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGastos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGastos.Location = New System.Drawing.Point(17, 174)
        Me.DataGastos.Name = "DataGastos"
        Me.DataGastos.Size = New System.Drawing.Size(1131, 310)
        Me.DataGastos.TabIndex = 2
        '
        'DataPorcentajes
        '
        Me.DataPorcentajes.AllowUserToAddRows = False
        Me.DataPorcentajes.AllowUserToDeleteRows = False
        Me.DataPorcentajes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataPorcentajes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataPorcentajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataPorcentajes.Location = New System.Drawing.Point(676, 19)
        Me.DataPorcentajes.Name = "DataPorcentajes"
        Me.DataPorcentajes.ReadOnly = True
        Me.DataPorcentajes.Size = New System.Drawing.Size(466, 128)
        Me.DataPorcentajes.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Gastos registrados:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Vehículo:"
        '
        'Tipo
        '
        Me.Tipo.AutoSize = True
        Me.Tipo.Location = New System.Drawing.Point(78, 107)
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Size = New System.Drawing.Size(15, 13)
        Me.Tipo.TabIndex = 0
        Me.Tipo.Text = "♦"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Tipo:"
        '
        'Fecha
        '
        Me.Fecha.AutoSize = True
        Me.Fecha.Location = New System.Drawing.Point(78, 85)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(15, 13)
        Me.Fecha.TabIndex = 0
        Me.Fecha.Text = "♦"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Fecha:"
        '
        'EntregadorNombre
        '
        Me.EntregadorNombre.AutoSize = True
        Me.EntregadorNombre.Location = New System.Drawing.Point(120, 64)
        Me.EntregadorNombre.Name = "EntregadorNombre"
        Me.EntregadorNombre.Size = New System.Drawing.Size(15, 13)
        Me.EntregadorNombre.TabIndex = 0
        Me.EntregadorNombre.Text = "♦"
        '
        'Entregador
        '
        Me.Entregador.AutoSize = True
        Me.Entregador.Location = New System.Drawing.Point(78, 63)
        Me.Entregador.Name = "Entregador"
        Me.Entregador.Size = New System.Drawing.Size(15, 13)
        Me.Entregador.TabIndex = 0
        Me.Entregador.Text = "♦"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Entregador:"
        '
        'Identidad
        '
        Me.Identidad.AutoSize = True
        Me.Identidad.Location = New System.Drawing.Point(78, 42)
        Me.Identidad.Name = "Identidad"
        Me.Identidad.Size = New System.Drawing.Size(15, 13)
        Me.Identidad.TabIndex = 0
        Me.Identidad.Text = "♦"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Identidad:"
        '
        'PrecioComb
        '
        Me.PrecioComb.AutoSize = True
        Me.PrecioComb.Location = New System.Drawing.Point(190, 130)
        Me.PrecioComb.Name = "PrecioComb"
        Me.PrecioComb.Size = New System.Drawing.Size(15, 13)
        Me.PrecioComb.TabIndex = 0
        Me.PrecioComb.Text = "♦"
        '
        'Ruta
        '
        Me.Ruta.AutoSize = True
        Me.Ruta.Location = New System.Drawing.Point(158, 20)
        Me.Ruta.Name = "Ruta"
        Me.Ruta.Size = New System.Drawing.Size(15, 13)
        Me.Ruta.TabIndex = 0
        Me.Ruta.Text = "♦"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(120, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Precio Comb:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(120, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Ruta:"
        '
        'NumeroLiquidacion
        '
        Me.NumeroLiquidacion.AutoSize = True
        Me.NumeroLiquidacion.Location = New System.Drawing.Point(78, 20)
        Me.NumeroLiquidacion.Name = "NumeroLiquidacion"
        Me.NumeroLiquidacion.Size = New System.Drawing.Size(15, 13)
        Me.NumeroLiquidacion.TabIndex = 0
        Me.NumeroLiquidacion.Text = "♦"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Liquidación:"
        '
        'Gastos
        '
        Me.Gastos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Gastos.Controls.Add(Me.NumeroDeposito)
        Me.Gastos.Controls.Add(Me.Label14)
        Me.Gastos.Controls.Add(Me.TotalArqueo)
        Me.Gastos.Controls.Add(Me.Label11)
        Me.Gastos.Controls.Add(Me.TotalGastos)
        Me.Gastos.Controls.Add(Me.Label12)
        Me.Gastos.Controls.Add(Me.BtnCancelar)
        Me.Gastos.Controls.Add(Me.BtnGuardar)
        Me.Gastos.Controls.Add(Me.TextVehiculo)
        Me.Gastos.Controls.Add(Me.DataGastos)
        Me.Gastos.Controls.Add(Me.DataPorcentajes)
        Me.Gastos.Controls.Add(Me.Label8)
        Me.Gastos.Controls.Add(Me.Label5)
        Me.Gastos.Controls.Add(Me.Tipo)
        Me.Gastos.Controls.Add(Me.Label7)
        Me.Gastos.Controls.Add(Me.Fecha)
        Me.Gastos.Controls.Add(Me.Label6)
        Me.Gastos.Controls.Add(Me.EntregadorNombre)
        Me.Gastos.Controls.Add(Me.Entregador)
        Me.Gastos.Controls.Add(Me.Label4)
        Me.Gastos.Controls.Add(Me.Identidad)
        Me.Gastos.Controls.Add(Me.Label3)
        Me.Gastos.Controls.Add(Me.PrecioComb)
        Me.Gastos.Controls.Add(Me.Ruta)
        Me.Gastos.Controls.Add(Me.Label10)
        Me.Gastos.Controls.Add(Me.Label9)
        Me.Gastos.Controls.Add(Me.NumeroLiquidacion)
        Me.Gastos.Controls.Add(Me.Label2)
        Me.Gastos.Location = New System.Drawing.Point(12, 12)
        Me.Gastos.Name = "Gastos"
        Me.Gastos.Size = New System.Drawing.Size(1160, 530)
        Me.Gastos.TabIndex = 5
        Me.Gastos.TabStop = False
        '
        'NumeroDeposito
        '
        Me.NumeroDeposito.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumeroDeposito.AutoSize = True
        Me.NumeroDeposito.Location = New System.Drawing.Point(600, 64)
        Me.NumeroDeposito.Name = "NumeroDeposito"
        Me.NumeroDeposito.Size = New System.Drawing.Size(15, 13)
        Me.NumeroDeposito.TabIndex = 6
        Me.NumeroDeposito.Text = "♦"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(498, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Número de Depósito:"
        '
        'TotalArqueo
        '
        Me.TotalArqueo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TotalArqueo.AutoSize = True
        Me.TotalArqueo.Location = New System.Drawing.Point(600, 42)
        Me.TotalArqueo.Name = "TotalArqueo"
        Me.TotalArqueo.Size = New System.Drawing.Size(15, 13)
        Me.TotalArqueo.TabIndex = 6
        Me.TotalArqueo.Text = "♦"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(498, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Total de Arqueo:"
        '
        'TotalGastos
        '
        Me.TotalGastos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TotalGastos.AutoSize = True
        Me.TotalGastos.Location = New System.Drawing.Point(600, 20)
        Me.TotalGastos.Name = "TotalGastos"
        Me.TotalGastos.Size = New System.Drawing.Size(15, 13)
        Me.TotalGastos.TabIndex = 6
        Me.TotalGastos.Text = "♦"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(498, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Total de Gastos:"
        '
        'Liquidaciones
        '
        Me.Liquidaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Liquidaciones.Controls.Add(Me.GroupBox1)
        Me.Liquidaciones.Controls.Add(Me.Btn_QuitarLiquidacion)
        Me.Liquidaciones.Controls.Add(Me.Btn_EnviarGastos)
        Me.Liquidaciones.Controls.Add(Me.BtnReImprimir)
        Me.Liquidaciones.Controls.Add(Me.DataLiquidaciones)
        Me.Liquidaciones.Location = New System.Drawing.Point(12, 12)
        Me.Liquidaciones.Name = "Liquidaciones"
        Me.Liquidaciones.Size = New System.Drawing.Size(1160, 530)
        Me.Liquidaciones.TabIndex = 4
        Me.Liquidaciones.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.BtnExportar)
        Me.GroupBox1.Controls.Add(Me.BtnGenerar)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1147, 50)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"SAN RAFAEL", "DIMOSA", "SR AGRO"})
        Me.ComboBox1.Location = New System.Drawing.Point(703, 17)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(199, 21)
        Me.ComboBox1.TabIndex = 8
        Me.ComboBox1.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(647, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Empresa:"
        Me.Label15.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(446, 18)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(195, 20)
        Me.DateTimePicker2.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(327, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Fecha Facturación Final:"
        '
        'BtnExportar
        '
        Me.BtnExportar.Location = New System.Drawing.Point(1030, 16)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(111, 23)
        Me.BtnExportar.TabIndex = 4
        Me.BtnExportar.Text = "Exportar"
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Location = New System.Drawing.Point(919, 16)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(105, 23)
        Me.BtnGenerar.TabIndex = 2
        Me.BtnGenerar.Text = "Generar"
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(126, 19)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(193, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Facturación Inicio:"
        '
        'Btn_QuitarLiquidacion
        '
        Me.Btn_QuitarLiquidacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_QuitarLiquidacion.Location = New System.Drawing.Point(1053, 63)
        Me.Btn_QuitarLiquidacion.Name = "Btn_QuitarLiquidacion"
        Me.Btn_QuitarLiquidacion.Size = New System.Drawing.Size(101, 34)
        Me.Btn_QuitarLiquidacion.TabIndex = 4
        Me.Btn_QuitarLiquidacion.Text = "Quitar Liquidación"
        Me.Btn_QuitarLiquidacion.UseVisualStyleBackColor = True
        '
        'Btn_EnviarGastos
        '
        Me.Btn_EnviarGastos.Location = New System.Drawing.Point(7, 63)
        Me.Btn_EnviarGastos.Name = "Btn_EnviarGastos"
        Me.Btn_EnviarGastos.Size = New System.Drawing.Size(86, 34)
        Me.Btn_EnviarGastos.TabIndex = 3
        Me.Btn_EnviarGastos.Text = "Enviar Gastos"
        Me.Btn_EnviarGastos.UseVisualStyleBackColor = True
        '
        'BtnReImprimir
        '
        Me.BtnReImprimir.Location = New System.Drawing.Point(882, 69)
        Me.BtnReImprimir.Name = "BtnReImprimir"
        Me.BtnReImprimir.Size = New System.Drawing.Size(165, 23)
        Me.BtnReImprimir.TabIndex = 3
        Me.BtnReImprimir.Text = "Imprimir Gastos Seleccionados"
        Me.BtnReImprimir.UseVisualStyleBackColor = True
        Me.BtnReImprimir.Visible = False
        '
        'DataLiquidaciones
        '
        Me.DataLiquidaciones.AllowUserToAddRows = False
        Me.DataLiquidaciones.AllowUserToDeleteRows = False
        Me.DataLiquidaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataLiquidaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataLiquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataLiquidaciones.Location = New System.Drawing.Point(7, 101)
        Me.DataLiquidaciones.Name = "DataLiquidaciones"
        Me.DataLiquidaciones.ReadOnly = True
        Me.DataLiquidaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataLiquidaciones.Size = New System.Drawing.Size(1147, 421)
        Me.DataLiquidaciones.TabIndex = 1
        '
        'FrmLiquidacionesGuardadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1185, 554)
        Me.Controls.Add(Me.Liquidaciones)
        Me.Controls.Add(Me.Gastos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLiquidacionesGuardadas"
        Me.Text = "Liquidaciones guardadas"
        CType(Me.DataGastos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataPorcentajes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gastos.ResumeLayout(False)
        Me.Gastos.PerformLayout()
        Me.Liquidaciones.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataLiquidaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents TextVehiculo As System.Windows.Forms.TextBox
    Friend WithEvents DataGastos As System.Windows.Forms.DataGridView
    Friend WithEvents DataPorcentajes As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Tipo As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Fecha As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents EntregadorNombre As System.Windows.Forms.Label
    Friend WithEvents Entregador As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Identidad As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PrecioComb As System.Windows.Forms.Label
    Friend WithEvents Ruta As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents NumeroLiquidacion As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Gastos As System.Windows.Forms.GroupBox
    Friend WithEvents Liquidaciones As System.Windows.Forms.GroupBox
    Friend WithEvents DataLiquidaciones As System.Windows.Forms.DataGridView
    Friend WithEvents TotalGastos As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents NumeroDeposito As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TotalArqueo As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Btn_QuitarLiquidacion As System.Windows.Forms.Button
    Friend WithEvents Btn_EnviarGastos As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents BtnReImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
