<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_carga_camiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_carga_camiones))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmb_sucursal = New System.Windows.Forms.ComboBox
        Me.cmb_turno = New System.Windows.Forms.ComboBox
        Me.cmb_fecha = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.pnl_ingreso = New System.Windows.Forms.Panel
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.id = New System.Windows.Forms.Label
        Me.label_id = New System.Windows.Forms.Label
        Me.grd_ingreso = New System.Windows.Forms.DataGridView
        Me.btn_camion = New System.Windows.Forms.DataGridViewButtonColumn
        Me.camion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_fac_ini = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_fac_fin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_reporte_sacado = New System.Windows.Forms.DataGridViewButtonColumn
        Me.reporte_sacado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_tiempo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_tipo_reporte = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.btn_reportechequeado = New System.Windows.Forms.DataGridViewButtonColumn
        Me.reporte_chequeado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TiempoChequeado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_reporte_cargado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_tiempo_cargado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_observacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Peso = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grd_partidas = New System.Windows.Forms.DataGridView
        Me.pnl_ingreso.SuspendLayout()
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_partidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sucursal:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Turno:"
        '
        'cmb_sucursal
        '
        Me.cmb_sucursal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_sucursal.FormattingEnabled = True
        Me.cmb_sucursal.Location = New System.Drawing.Point(73, 36)
        Me.cmb_sucursal.Name = "cmb_sucursal"
        Me.cmb_sucursal.Size = New System.Drawing.Size(200, 21)
        Me.cmb_sucursal.TabIndex = 1
        '
        'cmb_turno
        '
        Me.cmb_turno.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_turno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_turno.FormattingEnabled = True
        Me.cmb_turno.Items.AddRange(New Object() {"Diurno", "Nocturno"})
        Me.cmb_turno.Location = New System.Drawing.Point(73, 89)
        Me.cmb_turno.Name = "cmb_turno"
        Me.cmb_turno.Size = New System.Drawing.Size(200, 21)
        Me.cmb_turno.TabIndex = 3
        '
        'cmb_fecha
        '
        Me.cmb_fecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmb_fecha.Location = New System.Drawing.Point(73, 63)
        Me.cmb_fecha.Name = "cmb_fecha"
        Me.cmb_fecha.Size = New System.Drawing.Size(200, 20)
        Me.cmb_fecha.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(488, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingreso de Informacion"
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.Location = New System.Drawing.Point(10, 474)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 5
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'pnl_ingreso
        '
        Me.pnl_ingreso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_ingreso.Controls.Add(Me.btn_cancelar)
        Me.pnl_ingreso.Controls.Add(Me.btn_guardar)
        Me.pnl_ingreso.Controls.Add(Me.cmb_fecha)
        Me.pnl_ingreso.Controls.Add(Me.cmb_turno)
        Me.pnl_ingreso.Controls.Add(Me.cmb_sucursal)
        Me.pnl_ingreso.Controls.Add(Me.Label4)
        Me.pnl_ingreso.Controls.Add(Me.Label3)
        Me.pnl_ingreso.Controls.Add(Me.id)
        Me.pnl_ingreso.Controls.Add(Me.label_id)
        Me.pnl_ingreso.Controls.Add(Me.Label2)
        Me.pnl_ingreso.Controls.Add(Me.grd_ingreso)
        Me.pnl_ingreso.Controls.Add(Me.Label1)
        Me.pnl_ingreso.Controls.Add(Me.grd_partidas)
        Me.pnl_ingreso.Location = New System.Drawing.Point(13, 12)
        Me.pnl_ingreso.Name = "pnl_ingreso"
        Me.pnl_ingreso.Size = New System.Drawing.Size(1169, 502)
        Me.pnl_ingreso.TabIndex = 0
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Location = New System.Drawing.Point(91, 474)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 6
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'id
        '
        Me.id.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.id.AutoSize = True
        Me.id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id.Location = New System.Drawing.Point(73, 13)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(22, 13)
        Me.id.TabIndex = 2
        Me.id.Text = "Id:"
        Me.id.Visible = False
        '
        'label_id
        '
        Me.label_id.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.label_id.AutoSize = True
        Me.label_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_id.Location = New System.Drawing.Point(45, 13)
        Me.label_id.Name = "label_id"
        Me.label_id.Size = New System.Drawing.Size(22, 13)
        Me.label_id.TabIndex = 2
        Me.label_id.Text = "Id:"
        Me.label_id.Visible = False
        '
        'grd_ingreso
        '
        Me.grd_ingreso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_ingreso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grd_ingreso.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.grd_ingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ingreso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btn_camion, Me.camion, Me.col_fac_ini, Me.col_fac_fin, Me.btn_reporte_sacado, Me.reporte_sacado, Me.col_tiempo, Me.col_tipo_reporte, Me.btn_reportechequeado, Me.reporte_chequeado, Me.TiempoChequeado, Me.col_reporte_cargado, Me.col_tiempo_cargado, Me.col_observacion, Me.Peso})
        Me.grd_ingreso.Location = New System.Drawing.Point(3, 118)
        Me.grd_ingreso.Name = "grd_ingreso"
        Me.grd_ingreso.Size = New System.Drawing.Size(1163, 350)
        Me.grd_ingreso.TabIndex = 4
        '
        'btn_camion
        '
        Me.btn_camion.HeaderText = "..."
        Me.btn_camion.Name = "btn_camion"
        Me.btn_camion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_camion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btn_camion.Width = 41
        '
        'camion
        '
        Me.camion.HeaderText = "Camion"
        Me.camion.Name = "camion"
        Me.camion.Width = 67
        '
        'col_fac_ini
        '
        Me.col_fac_ini.HeaderText = "Factura Inicial"
        Me.col_fac_ini.Name = "col_fac_ini"
        Me.col_fac_ini.Width = 90
        '
        'col_fac_fin
        '
        Me.col_fac_fin.HeaderText = "Factura Final"
        Me.col_fac_fin.Name = "col_fac_fin"
        Me.col_fac_fin.Width = 86
        '
        'btn_reporte_sacado
        '
        Me.btn_reporte_sacado.HeaderText = "..."
        Me.btn_reporte_sacado.Name = "btn_reporte_sacado"
        Me.btn_reporte_sacado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_reporte_sacado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btn_reporte_sacado.Width = 41
        '
        'reporte_sacado
        '
        Me.reporte_sacado.HeaderText = "Reporte Sacado"
        Me.reporte_sacado.Name = "reporte_sacado"
        Me.reporte_sacado.Width = 101
        '
        'col_tiempo
        '
        Me.col_tiempo.HeaderText = "Tiempo Sacado"
        Me.col_tiempo.Name = "col_tiempo"
        Me.col_tiempo.Width = 98
        '
        'col_tipo_reporte
        '
        Me.col_tipo_reporte.HeaderText = "Tipo de Reporte"
        Me.col_tipo_reporte.Name = "col_tipo_reporte"
        Me.col_tipo_reporte.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_tipo_reporte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'btn_reportechequeado
        '
        Me.btn_reportechequeado.HeaderText = "..."
        Me.btn_reportechequeado.Name = "btn_reportechequeado"
        Me.btn_reportechequeado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_reportechequeado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btn_reportechequeado.Width = 41
        '
        'reporte_chequeado
        '
        Me.reporte_chequeado.HeaderText = "Reporte Chequeado"
        Me.reporte_chequeado.Name = "reporte_chequeado"
        Me.reporte_chequeado.Width = 117
        '
        'TiempoChequeado
        '
        Me.TiempoChequeado.HeaderText = "Tiempo de Chequeado"
        Me.TiempoChequeado.Name = "TiempoChequeado"
        Me.TiempoChequeado.Width = 128
        '
        'col_reporte_cargado
        '
        Me.col_reporte_cargado.HeaderText = "Reporte Cargado"
        Me.col_reporte_cargado.Name = "col_reporte_cargado"
        Me.col_reporte_cargado.Width = 104
        '
        'col_tiempo_cargado
        '
        Me.col_tiempo_cargado.HeaderText = "Tiempo de Cargado"
        Me.col_tiempo_cargado.Name = "col_tiempo_cargado"
        Me.col_tiempo_cargado.Width = 115
        '
        'col_observacion
        '
        Me.col_observacion.HeaderText = "Observacion"
        Me.col_observacion.Name = "col_observacion"
        Me.col_observacion.Width = 92
        '
        'Peso
        '
        Me.Peso.HeaderText = "Peso"
        Me.Peso.Name = "Peso"
        Me.Peso.Width = 56
        '
        'grd_partidas
        '
        Me.grd_partidas.AllowUserToAddRows = False
        Me.grd_partidas.AllowUserToDeleteRows = False
        Me.grd_partidas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_partidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_partidas.Location = New System.Drawing.Point(3, 118)
        Me.grd_partidas.Name = "grd_partidas"
        Me.grd_partidas.ReadOnly = True
        Me.grd_partidas.Size = New System.Drawing.Size(1166, 350)
        Me.grd_partidas.TabIndex = 7
        Me.grd_partidas.Visible = False
        '
        'frm_carga_camiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 526)
        Me.Controls.Add(Me.pnl_ingreso)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_carga_camiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga de Camiones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_ingreso.ResumeLayout(False)
        Me.pnl_ingreso.PerformLayout()
        CType(Me.grd_ingreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_partidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_turno As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents pnl_ingreso As System.Windows.Forms.Panel
    Friend WithEvents grd_ingreso As System.Windows.Forms.DataGridView
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.Label
    Friend WithEvents label_id As System.Windows.Forms.Label
    Friend WithEvents grd_partidas As System.Windows.Forms.DataGridView
    Friend WithEvents btn_camion As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents camion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_fac_ini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_fac_fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_reporte_sacado As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents reporte_sacado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_tiempo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_tipo_reporte As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents btn_reportechequeado As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents reporte_chequeado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TiempoChequeado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_reporte_cargado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_tiempo_cargado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_observacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Peso As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
