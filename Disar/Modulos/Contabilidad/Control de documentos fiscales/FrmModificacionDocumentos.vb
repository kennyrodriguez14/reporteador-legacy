Imports Disar.data

Public Class FrmModificacionDocumentos

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim db As New ClsDocumentos
        Try
            Dim s = db.ModificaDoc(TextTipo.Text, TextSerie.Text, TextDesde.Text, TextHasta.Text, TextCAI.Text, TextSolicitada.Text, TextOtorgada.Text, TextAlmacen.Text, DtRecepcion.Value, DtLimiteImpresion.Value, TextEmpresa.Text)
            If s = "s" Then
                MsgBox("Se modificó el dato exitosamente", MsgBoxStyle.Information)
                FrmDocumentosFiscales.BtnMostrar.PerformClick()
                Me.Dispose()
            Else
                MsgBox(s)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class