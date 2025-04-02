Imports Disar.data

Public Class DetallesFactura

    Private Sub Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aceptar.Click
        Me.Close()
    End Sub

    Private Sub DetallesFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conexion_bita As New cls_bitacora_reporteador
        conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó detalle de detalles en perfil de clientes Agro", "REPORTES", _
                                  "Fecha: " & DateTime.Now)
    End Sub
End Class