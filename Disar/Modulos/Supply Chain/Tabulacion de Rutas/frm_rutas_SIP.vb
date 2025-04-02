Imports Disar.data
Public Class frm_rutas_SIP
    Dim conexion As New cls_ayuda_rutas
    Private Sub frm_rutas_SIP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged
        Try
            grd_rutas.DataSource = conexion.BuscarRUTAS_SIP(Val(txt_busqueda.Text), txt_busqueda.Text.ToUpper)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_rutas_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_rutas.CellMouseDoubleClick
        frm_tabulacion_rutas_SIP.txt_id_ruta.Text = grd_rutas.CurrentRow.Cells(0).Value
        frm_tabulacion_rutas_SIP.txt_ruta.Text = grd_rutas.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class