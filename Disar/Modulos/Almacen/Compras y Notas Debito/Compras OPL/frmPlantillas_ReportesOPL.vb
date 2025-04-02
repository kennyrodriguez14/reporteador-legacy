Imports Disar.data

Public Class frmPlantillas_ReportesOPL

    Private Sub FrmPlantillas_ReportesOPL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub CargaDevos()
        Dim db As New cls_notas_debito

    End Sub

    Private Sub BtnGenerar_Click(sender As Object, e As EventArgs) Handles BtnGenerar.Click
        CargaDevos()
    End Sub

End Class