Imports Disar.data
Public Class frm_clientes
    Dim conexion As New cls_descuentos_tacticos
    Public codigo, cliente, cve_vend, vendedor, rfc, pago As String
    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged
        Try
            grd_lista.DataSource = conexion.Listar_Clientes(txt_busqueda.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_lista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista.DoubleClick
        Try
            codigo = grd_lista.CurrentRow.Cells(0).Value
            cliente = grd_lista.CurrentRow.Cells(1).Value
            cve_vend = grd_lista.CurrentRow.Cells(2).Value
            vendedor = grd_lista.CurrentRow.Cells(3).Value
            rfc = grd_lista.CurrentRow.Cells(4).Value
            pago = grd_lista.CurrentRow.Cells(5).Value
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

 
End Class