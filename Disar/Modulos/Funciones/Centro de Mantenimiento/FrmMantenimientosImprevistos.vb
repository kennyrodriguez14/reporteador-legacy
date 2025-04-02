Imports Disar.data

Public Class FrmMantenimientosImprevistos

    Private Sub Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nuevo.Click
        FrmNuevoEventoNoProgramado.ShowDialog()
    End Sub

    Sub CargaDatos()
        Dim db As New ClsBitacoraEventos
        Try
            DataDatos.DataSource = db.FiltraTodosEventosNoProgramadosFecha(DInicio.Value, Final.Value)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Try
            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó detalle de mantenimientos vehiculares no planificados", "Centro de Mantenimiento", _
                                      "Fecha: " & DateTime.Now)
        Catch ex As Exception
        End Try
        CargaDatos()
    End Sub

End Class