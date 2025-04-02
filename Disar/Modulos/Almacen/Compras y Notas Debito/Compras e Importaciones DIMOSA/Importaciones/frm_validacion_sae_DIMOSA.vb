Imports Disar.data
Public Class frm_validacion_sae_DIMOSA
    Dim conexion_notas_debito As New cls_notas_debito

    Public CLAVE As String

    Private Sub frm_validacion_sae_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            grd_repo.DataSource = conexion_notas_debito.validacion_sae_reporteador_DIMOSA(CLAVE, "REPO")
            grd_sae.DataSource = conexion_notas_debito.validacion_sae_reporteador_DIMOSA(CLAVE, "SAE")

            Dim total1 As Double = 0, total2 As Double = 0
            For index As Integer = 0 To grd_repo.Rows.Count - 1
                total1 += grd_repo.Rows(index).Cells(4).Value
            Next

            For index As Integer = 0 To grd_sae.Rows.Count - 1
                total2 += grd_sae.Rows(index).Cells(4).Value
            Next

            txt_totalr.Text = total1.ToString("N2")
            txt_total_sae.Text = total2.ToString("N2")
        Catch ex As Exception
        End Try
    End Sub
End Class