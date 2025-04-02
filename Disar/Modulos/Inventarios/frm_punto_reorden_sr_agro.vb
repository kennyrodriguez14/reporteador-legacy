Imports Disar.data
Imports System.IO
Imports Microsoft.Office.Interop

Public Class frm_punto_reorden_sr_agro
    Dim conexion As New cls_punto_reorden
    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Try
            grd_punto_reorden.DataSource = conexion.punto_reorden_sr_agro(cmb_fecha_fin.Value, txt_dias.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mnu_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_exportar.Click
        exportar()
    End Sub

    Sub Exportar()
        'Try
        '    Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        '    Dim wBook As Microsoft.Office.Interop.Excel.Workbook

        '    Dim ruta_excel As String
        '    ruta_excel = "C:\FORMATO_PUNTO_REORDEN_SR_AGRO_NUEVO.xls"

        '    wBook = excel.Workbooks.Open(ruta_excel, , True)
        '    Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        '    wSheet = wBook.Worksheets(1)
        '    For r As Integer = 0 To grd_punto_reorden.RowCount - 1
        '        For c As Integer = 0 To grd_punto_reorden.Columns.Count - 1
        '            If c = 14 Then
        '                wSheet.Cells(r + 2, 19).value = grd_punto_reorden.Item(c, r).Value
        '            ElseIf c = 15 Then
        '                wSheet.Cells(r + 2, 16).value = grd_punto_reorden.Item(c, r).Value
        '            Else
        '                wSheet.Cells(r + 2, c + 1).value = grd_punto_reorden.Item(c, r).Value
        '            End If
        '        Next
        '    Next
        '    excel.Visible = True
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

        Try
            Dim sData As String = ""
            Dim sData2dias As String = ""
            Dim sData3peso As String = ""

            For index As Integer = 0 To grd_punto_reorden.Rows.Count - 1
                sData += grd_punto_reorden.Rows(index).Cells(0).Value & vbTab & grd_punto_reorden.Rows(index).Cells(1).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(2).Value & vbTab & grd_punto_reorden.Rows(index).Cells(3).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(4).Value & vbTab & grd_punto_reorden.Rows(index).Cells(5).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(6).Value & vbTab & grd_punto_reorden.Rows(index).Cells(7).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(8).Value & vbTab & grd_punto_reorden.Rows(index).Cells(9).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(10).Value & vbTab & grd_punto_reorden.Rows(index).Cells(11).Value & vbTab _
                & grd_punto_reorden.Rows(index).Cells(12).Value & vbTab & grd_punto_reorden.Rows(index).Cells(13).Value & vbTab & grd_punto_reorden.Rows(index).Cells(14).Value & vbCr

                sData2dias += grd_punto_reorden.Rows(index).Cells(15).Value & vbCr
                sData3peso += grd_punto_reorden.Rows(index).Cells(16).Value & vbCr
            Next

            Clipboard.Clear()
            Clipboard.SetText(sData)

            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook

            Dim ruta_excel As String
            ruta_excel = "C:\FORMATO_PUNTO_REORDEN_SR_AGRO_NUEVO.xls"

            wBook = excel.Workbooks.Open(ruta_excel, True)
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            wSheet = wBook.Worksheets(1)

            wSheet.Range("A2").Select()
            wSheet.Paste()

            Clipboard.Clear()
            Clipboard.SetText(sData2dias)
            wSheet.Range("T2").Select()
            wSheet.Paste()
            Clipboard.Clear()

            Clipboard.SetText(sData3peso)
            wSheet.Range("Q2").Select()
            wSheet.Paste()
            Clipboard.Clear()

            excel.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Sub excel2()
    '    If grd_punto_reorden.RowCount > 0 Then
    '        Dim dt As New DataTable
    '        dt = grd_punto_reorden.DataSource
    '        Dim save As New SaveFileDialog
    '        save.Filter = "ARCHIVO XML (*.xml)|*.xml"
    '        save.FileName = "EMPLEADOS" & " " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xml"
    '        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
    '            'If Not IO.File.Exists(save.FileName) Then
    '            Dim fs As System.IO.FileStream
    '            Dim xtw As System.Xml.XmlTextWriter
    '            dt.TableName = "items"
    '            fs = New System.IO.FileStream(save.FileName, IO.FileMode.Create)
    '            xtw = New System.Xml.XmlTextWriter(fs, System.Text.Encoding.Unicode)
    '            xtw.WriteProcessingInstruction("xml", "version='1.0'")
    '            xtw.WriteProcessingInstruction("mso-application", "progid='Excel.Sheet'")
    '            dt.WriteXml(xtw)
    '            xtw.Close()
    '            MsgBox("SE EXPORTO CORRECTAMENTE")
    '        End If
    '    Else
    '        MsgBox("NO HAY DATOS QUE EXPORTAR", MsgBoxStyle.Critical, "VERIFICAR")
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub frm_punto_reorden_sr_agro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class