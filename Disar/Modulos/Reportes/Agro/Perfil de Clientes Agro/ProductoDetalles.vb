Imports Disar.data

Public Class ProductoDetalles

    Private Sub Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aceptar.Click
        Me.Close()
    End Sub

    Private Sub ProductoDetalles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó detalles de productos en perfil de clientes Agro", "REPORTES", _
                                      "Fecha: " & DateTime.Now)
        Catch ex As Exception
        End Try
        DataGridView1.DefaultCellStyle.ForeColor = Color.Black
    End Sub
End Class