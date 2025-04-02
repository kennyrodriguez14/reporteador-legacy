Imports Disar.data

Public Class frm_CargaProductoMatinal

    Private Sub frm_CargaProductoMatinal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actualiza()
    End Sub

    Private Sub BtnDesactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDesactivar.Click

        Dim db As New ClsProductos

        Dim a = MsgBox("¿Está seguro que desea eliminar el producto para el vendedor seleccionado?", MsgBoxStyle.YesNo)

        If DataActivos.RowCount > 0 Then
            If a = MsgBoxResult.Yes Then
                Dim s = db.ModificaEstado(DataActivos.CurrentRow.Cells("ID").Value)
                MsgBox("Registro actualizado")
                actualiza()
            End If
        End If
 
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        FrmNuevoProdMatinal.ShowDialog()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            Dim db As New ClsProductos
            DataActivos.DataSource = db.CargaValidosPorVendedor(TextBox1.Text)
        Catch ex As Exception
        End Try
    End Sub

    Sub actualiza()
        Dim db As New ClsProductos
        DataActivos.DataSource = db.CargaValidos
    End Sub
 
End Class