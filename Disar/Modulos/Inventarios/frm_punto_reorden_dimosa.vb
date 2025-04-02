Imports Disar.data
Imports System.IO
Imports Microsoft.Office.Interop

Public Class frm_punto_reorden_dimosa
    Dim conexion As New cls_punto_reorden
    Dim FlNm As String
    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Try
            grd_punto_reorden.DataSource = conexion.punto_reorden_dimosa(cmb_fecha_fin.Value, txt_dias.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mnu_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_exportar.Click
        Try
            Dim sData As String = ""
            Dim sData2 As String = ""

            For index As Integer = 0 To grd_punto_reorden.Rows.Count - 1
                sData += grd_punto_reorden.Rows(index).Cells(0).Value & vbTab & grd_punto_reorden.Rows(index).Cells(1).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(2).Value & vbTab & grd_punto_reorden.Rows(index).Cells(3).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(4).Value & vbTab & grd_punto_reorden.Rows(index).Cells(5).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(6).Value & vbTab & grd_punto_reorden.Rows(index).Cells(7).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(8).Value & vbTab & grd_punto_reorden.Rows(index).Cells(9).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(10).Value & vbTab & grd_punto_reorden.Rows(index).Cells(11).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(12).Value & vbTab & grd_punto_reorden.Rows(index).Cells(13).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(14).Value & vbCr

                sData2 += grd_punto_reorden.Rows(index).Cells(15).Value & vbCr
            Next

            Clipboard.Clear()
            Clipboard.SetText(sData)

            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook

            Dim ruta_excel As String
            ruta_excel = "C:\FORMATO_PUNTO_REORDEN_DIMOSA.xls"

            wBook = excel.Workbooks.Open(ruta_excel, True)
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            wSheet = wBook.Worksheets(1)

            wSheet.Range("A2").Select()
            wSheet.Paste()

            Clipboard.Clear()
            Clipboard.SetText(sData2)
            wSheet.Range("S2").Select()
            wSheet.Paste()

            Clipboard.Clear()
            excel.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class