Imports Disar.data
Public Class frm_carga_camiones
    Dim conexion As New cls_carga_camiones_formatofactura
    Dim Sucursal As String
    Private Sub frm_carga_camiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cargar_tipo_reporte()
            cargar_almacen()
            'cargar_sacado()
            'cargar_chequeado()
            'cargar_camion()
            cmb_turno.SelectedItem = "Diurno"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        
    End Sub

    Sub cargar_almacen()
        cmb_sucursal.DataSource = conexion.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
        cmb_sucursal.ValueMember = "ID"
        cmb_sucursal.DisplayMember = "ALMACEN"
    End Sub

    Sub cargar_tipo_reporte()
        Dim column As DataGridViewComboBoxColumn = DirectCast(grd_ingreso.Columns(7), DataGridViewComboBoxColumn)
        With column
            .DataSource = conexion.select_tipo_reporte
            .DisplayMember = "Tipo_Reporte"
            .ValueMember = "Id"
        End With
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If MessageBox.Show("Los datos estan correctos", "Confirmacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim TransaccionId As Integer = 0

                If conexion.GetId Is DBNull.Value Or conexion.GetId <= 0 Then
                    TransaccionId = 1
                Else
                    TransaccionId = conexion.GetId
                End If

                conexion.Encabezado(TransaccionId, cmb_sucursal.SelectedValue, cmb_fecha.Value, cmb_turno.SelectedItem)

                For index As Integer = 0 To grd_ingreso.RowCount - 1
                    If grd_ingreso.Rows(index).Cells(1).Value > 0 Then
                        conexion.Partidas(TransaccionId, index + 1, grd_ingreso.Rows(index).Cells(1).Value, grd_ingreso.Rows(index).Cells(2).Value, grd_ingreso.Rows(index).Cells(3).Value, _
                        grd_ingreso.Rows(index).Cells(5).Value, grd_ingreso.Rows(index).Cells(6).Value, grd_ingreso.Rows(index).Cells(7).Value, grd_ingreso.Rows(index).Cells(9).Value, _
                        grd_ingreso.Rows(index).Cells(10).Value, grd_ingreso.Rows(index).Cells(11).Value, grd_ingreso.Rows(index).Cells(12).Value, grd_ingreso.Rows(index).Cells(13).Value, grd_ingreso.Rows(index).Cells(14).Value)
                    End If
                Next
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Sub cargar_partidas()
        grd_partidas.Visible = True
        Try
            grd_partidas.DataSource = conexion.get_partidas(Val(id.Text))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub grd_ingreso_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_ingreso.CellClick
        If cmb_sucursal.SelectedValue = 1 Then
            Sucursal = "SPS"
        ElseIf cmb_sucursal.SelectedValue = 2 Then
            Sucursal = "SRC"
        ElseIf cmb_sucursal.SelectedValue = 3 Then
            Sucursal = "3"
        ElseIf cmb_sucursal.SelectedValue = 4 Then
            Sucursal = "4"
        End If

        frm_camiones.Sucursal = cmb_sucursal.SelectedValue
        If e.ColumnIndex = btn_camion.Index Then
            If frm_camiones.ShowDialog = Windows.Forms.DialogResult.OK Then
                grd_ingreso.CurrentRow.Cells(1).Value = frm_camiones.Id
                grd_ingreso.CurrentRow.Cells(1).ReadOnly = True
            End If
        End If

        frm_encargados.Sucursal = Sucursal
        If e.ColumnIndex = btn_reporte_sacado.Index Then
            If frm_encargados.ShowDialog = Windows.Forms.DialogResult.OK Then
                grd_ingreso.CurrentRow.Cells(5).Value = frm_encargados.Id
                grd_ingreso.CurrentRow.Cells(5).ReadOnly = True
            End If
        End If

        frm_encargados.Sucursal = Sucursal
        If e.ColumnIndex = btn_reportechequeado.Index Then
            If frm_encargados.ShowDialog = Windows.Forms.DialogResult.OK Then
                grd_ingreso.CurrentRow.Cells(9).Value = frm_encargados.Id
                grd_ingreso.CurrentRow.Cells(9).ReadOnly = True
            End If
        End If

    End Sub

 
End Class