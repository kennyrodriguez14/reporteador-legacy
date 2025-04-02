Imports Disar.data

Public Class Frm_RegistroDeAccidente

    Private Sub BtnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegistrar.Click
        Dim db As New Cls_AccidentesLaborales

        Try
            Dim s = db.NuevoEventoProgramado(DateFecha.Value, DateHora.Value.TimeOfDay, TextDescripcion.Text, TextColaborador.Text, TextSucursal.Text)
            If s = "s" Then
                MsgBox("Se ha registrador el accidente", MsgBoxStyle.Information)
                Frm_AccidentesLaborales.CargaDatos()
                Me.Dispose()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Frm_RegistroDeAccidente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextSucursal.Text = _Inicio.Almacen
    End Sub

End Class