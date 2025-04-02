Imports Disar.data

Public Class frm_malas_cargas_formato_factura
    Dim conexion As New clsMalasCargas
    Dim Clase As New cls_reporte_carga
    Dim Sucursal As String = "SRC"
    Private Sub grdFactura_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFactura.CellClick
        If e.ColumnIndex = btn_codigo_reporte.Index Then
            Try
                frm_ayuda_productos_malas_cargas.Empresa = "SAN RAFAEL"
            Catch ex As Exception

            End Try
            If frm_ayuda_productos_malas_cargas.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdFactura.CurrentRow.Cells(1).Value = frm_ayuda_productos_malas_cargas.Codigo
                grdFactura.CurrentRow.Cells(2).Value = frm_ayuda_productos_malas_cargas.Descripcion
            End If
        End If

        If e.ColumnIndex = btn_codigocargado.Index Then
            If frm_ayuda_productos_malas_cargas.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdFactura.CurrentRow.Cells(4).Value = frm_ayuda_productos_malas_cargas.Codigo
                grdFactura.CurrentRow.Cells(5).Value = frm_ayuda_productos_malas_cargas.Descripcion
            End If
        End If

        If e.ColumnIndex = btn_encargado.Index Then
            If cmb_almacen.SelectedValue = 1 Then
                Sucursal = "SPS"
            ElseIf cmb_almacen.SelectedValue = 2 Then
                Sucursal = "SRC"
            ElseIf cmb_almacen.SelectedValue = 3 Then
                Sucursal = "3"
            Else
                Sucursal = "4"
            End If
            frm_encargados.Sucursal = Sucursal
            If frm_encargados.ShowDialog = Windows.Forms.DialogResult.OK Then
                grdFactura.CurrentRow.Cells(7).Value = frm_encargados.Id
            End If
        End If
    End Sub

    Private Sub frm_malas_cargas_formato_factura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_almacen()
    End Sub

    Sub Cargar_almacen()
        cmb_almacen.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
        cmb_almacen.ValueMember = "ID"
        cmb_almacen.DisplayMember = "ALMACEN"
    End Sub


    Sub guardar()
        Try
            For index As Integer = 0 To grdFactura.Rows.Count - 1
                If grdFactura.Rows(index).Cells(1).Value <> "" Then
                    conexion.Insert(cmbFecha.Value.Date, grdFactura.Rows(index).Cells(8).Value _
                                                , grdFactura.Rows(index).Cells(1).Value, grdFactura.Rows(index).Cells(4).Value, _
                                                grdFactura.Rows(index).Cells(7).Value, grdFactura.Rows(index).Cells(9).Value, cmb_almacen.SelectedValue)
                End If
            Next
            MessageBox.Show("Datos Guardados Exitosamente")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        guardar()
        Me.Close()
    End Sub

    Private Sub Grp_ingreso_Enter(sender As Object, e As EventArgs) Handles grp_ingreso.Enter

    End Sub
End Class