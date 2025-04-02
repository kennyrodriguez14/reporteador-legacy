Imports Disar.data
Public Class frm_productos_indivual
    Dim conexion As New cls_descuentos_tacticos
    Public cve_art, producto, cve_prov, proveedor As String
    Public isv As Double
    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged
        Try
            grd_lista.DataSource = conexion.listar_productos_nota_credito_individual(txt_busqueda.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_lista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista.DoubleClick
        Try
            cve_art = grd_lista.CurrentRow.Cells(0).Value
            producto = grd_lista.CurrentRow.Cells(1).Value
            cve_prov = grd_lista.CurrentRow.Cells(2).Value
            proveedor = grd_lista.CurrentRow.Cells(3).Value
            isv = grd_lista.CurrentRow.Cells(4).Value
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class