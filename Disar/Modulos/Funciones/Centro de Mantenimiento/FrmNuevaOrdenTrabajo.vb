Imports Disar.data

Public Class FrmNuevaOrdenTrabajo

    Sub ActualizaDatos()
        Try
            DataGridView1.Columns.Clear()
        Catch ex As Exception
        End Try
        Try
            Dim db As New ClsOrdenTrabajoVehicular
            DataGridView1.DataSource = db.DetalleOrden(ComboBox1.SelectedValue)
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnTarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTarea.Click
        FrmTareaOrdenVehiculo.Orden = ComboBox1.SelectedValue
        If FrmTareaOrdenVehiculo.ShowDialog = Windows.Forms.DialogResult.OK Then
            ActualizaDatos()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ActualizaDatos()
    End Sub

    Private Sub FrmNuevaOrdenTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenaCombo()
        LlenaVehiculos()
    End Sub

    Sub llenaCombo()
        Try
            Dim db As New ClsOrdenTrabajoVehicular
            ComboBox1.DataSource = db.TodasOrdenes
            ComboBox1.ValueMember = "ID"
            ComboBox1.DisplayMember = "Detalle Orden"
        Catch ex As Exception
        End Try
        Try
            ComboTipo.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Sub LlenaVehiculos()
        Dim db As New ClsBitacoraEventos
        CmbVehiculo.DataSource = db.VehiculosRep
        CmbVehiculo.ValueMember = "Nº"
        CmbVehiculo.DisplayMember = "DESCRIPCIÓN"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Datos1.Visible = True
        BtnCancelar.Visible = True
        Guardar.Visible = True

        Label6.Visible = False
        Label10.Visible = False

        ComboBox1.Visible = False
        Button1.Visible = False
        BtnTarea.Visible = False
        ComboTipo.Visible = False
        Dim Col1 As New DataGridViewComboBoxColumn
        Col1.Name = "Actividad"
        Col1.HeaderText = "Actividad"
        Col1.Items.Add("Revision")
        Col1.Items.Add("Cambio")
        Col1.Items.Add("Lubricación")
        Col1.Items.Add("Engrase")
        Col1.Items.Add("Ajuste")
        Col1.Items.Add("Reparación")
        Dim Col2 As New DataGridViewComboBoxColumn
        Col2.Name = "Tipo"
        Col2.HeaderText = "Tipo"
        Col2.Items.Add("Preventivo")
        Col2.Items.Add("Correctivo")
        Dim Col3 As New DataGridViewTextBoxColumn
        Col3.Name = "Repuesto"
        Col3.HeaderText = "Repuesto"
        Col3.ReadOnly = True
        Dim Col4 As New DataGridViewTextBoxColumn
        Col4.Name = "Cantidad"
        Col4.HeaderText = "Cantidad"
        Col4.ReadOnly = True
        Dim Col5 As New DataGridViewTextBoxColumn
        Col5.Name = "Costo"
        Col5.HeaderText = "Costo"
        Col5.ReadOnly = True
        DataGridView1.Columns("Elemento").ReadOnly = True
        DataGridView1.Columns.Add(Col1)
        DataGridView1.Columns.Add(Col2)
        DataGridView1.Columns.Add(Col3)
        DataGridView1.Columns.Add(Col4)
        DataGridView1.Columns.Add(Col5)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Datos1.Visible = False
        BtnCancelar.Visible = False
        Guardar.Visible = False
        ComboBox1.Visible = True
        ComboTipo.Visible = True
        Button1.Visible = True
        BtnTarea.Visible = True

        Label6.Visible = True
        Label10.Visible = True

        ActualizaDatos()
    End Sub

 

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim validClick As Boolean = (e.RowIndex <> -1 AndAlso e.ColumnIndex <> -1)
        Dim datagridview = TryCast(sender, DataGridView)

        If e.ColumnIndex >= 0 Then
            If TypeOf datagridview.Columns(e.ColumnIndex) Is DataGridViewComboBoxColumn AndAlso validClick Then
                datagridview.BeginEdit(True)
                DirectCast(datagridview.EditingControl, ComboBox).DroppedDown = True
            End If

            If TypeOf datagridview.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn AndAlso validClick And e.ColumnIndex >= 5 Then
                If FormAgregarRepuesto.ShowDialog = Windows.Forms.DialogResult.OK Then
                    DataGridView1.CurrentRow.Cells("Repuesto").Value = FormAgregarRepuesto.Repuesto
                    DataGridView1.CurrentRow.Cells("Cantidad").Value = FormAgregarRepuesto.Cantidad
                    DataGridView1.CurrentRow.Cells("Costo").Value = FormAgregarRepuesto.Costo
                End If
            End If
        End If

    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guardar.Click
        Dim dt As New DataTable
        Try
            dt.Rows.Clear()
            dt.Columns.Clear()
        Catch ex As Exception
        End Try

        For Each column As DataGridViewColumn In DataGridView1.Columns
            dt.Columns.Add(column.HeaderText)
        Next

        For Each row As DataGridViewRow In DataGridView1.Rows
            dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value)
        Next

        Dim db As New ClsOrdenTrabajoVehicular
        Dim s = db.GuardaOrden(dt, FechaIngreso.Value, FechaSalida.Value, HoraEntrada.Text, HoraSalida.Text, CmbVehiculo.SelectedValue, TextObservaciones.Text, ComboBox1.SelectedValue, TextAsignado.Text, _Inicio.lblUsuario.Text, Val(TextKilometraje.Text), ComboTipo.Text)

        If s = "s" Then
            MsgBox("Registro guardado exitosamente")
            FormOrdenesDeTrabajo.ActualizarDatos()
            BtnCancelar.PerformClick()
        Else
            MsgBox(s)
        End If

    End Sub

    Private Sub FechaIngreso_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FechaIngreso.ValueChanged
        Try
            FechaSalida.Value = FechaIngreso.Value
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            DataGridView1.CurrentRow.Cells("Repuesto").Value = ""
            DataGridView1.CurrentRow.Cells("Cantidad").Value = ""
            DataGridView1.CurrentRow.Cells("Costo").Value = ""
        End If
        If Not IsNumeric(e.KeyCode) Then
            e.Handled = True
        End If
    End Sub
End Class

