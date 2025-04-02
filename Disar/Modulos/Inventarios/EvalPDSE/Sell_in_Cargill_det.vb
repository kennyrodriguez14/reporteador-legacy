﻿Imports Disar.data
Public Class Sell_in_Cargill_det
    Dim Conexion As New cls_evaluacion_pdse
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet, wSheet2 As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Mascotas"
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet.Cells.Range("A1").Select()
            Try
                wSheet.Paste()
            Catch ex As Exception
            End Try
            wSheet.Cells.Range("A1").Value = "______________________________"
            wSheet.Cells.Range("A1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, imagencargill.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet.Cells.Range("C1").Select()
            Try
                wSheet.Paste()
            Catch ex As Exception
            End Try
            Clipboard.Clear()
            'wSheet.Cells.Range("A5").Value = "GENERADO :"
            'wSheet.Cells.Range("B5").Value = Now
            wSheet.Cells.Range("A7:E7").Merge()
            wSheet.Cells.Range("A7:E7").Value = "SELL IN CARGILL MASCOTAS"
            wSheet.Cells.Range("A7:E7").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A7:E7").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A7:E7").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A7:E7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A7:E7").Font.Bold = True
            wSheet.Cells.Range("C4").Value = "FECHA INICIAL"
            wSheet.Cells.Range("C4").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("C4").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("C4").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("C4").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("C4").Font.Bold = True
            wSheet.Cells.Range("D4").Value = _cmbFechai.Value.Date
            wSheet.Cells.Range("D4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("C5").Value = "FECHA FINAL"
            wSheet.Cells.Range("C5").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("C5").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("C5").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("C5").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("C5").Font.Bold = True
            wSheet.Cells.Range("D5").Value = _cmbFechaf.Value.Date
            wSheet.Cells.Range("D5").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("A7:D7").Select()
            For c As Integer = 0 To grd_mascotas.Columns.Count - 1
                wSheet.Cells(8, c + 1).value = grd_mascotas.Columns(c).HeaderText
                wSheet.Cells(8, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                wSheet.Cells(8, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(8, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(8, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet.Cells(8, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                wSheet.Cells(8, c + 1).Font.Bold = True
            Next
            For r As Integer = 0 To grd_mascotas.RowCount - 1
                For c As Integer = 0 To grd_mascotas.Columns.Count - 1
                    wSheet.Cells(r + 9, c + 1).value = grd_mascotas.Item(c, r).Value
                    wSheet.Cells(r + 9, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()

            wSheet2 = wBook.Sheets.Add
            wSheet2.Name = "Balanceados"
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet2.Cells.Range("A1").Select()
            Try
                wSheet2.Paste()
            Catch ex As Exception
            End Try
            wSheet2.Cells.Range("A1").Value = "______________________________"
            wSheet2.Cells.Range("A1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, imagencargill.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet2.Cells.Range("C1").Select()
            Try
                wSheet2.Paste()
            Catch ex As Exception
            End Try
            Clipboard.Clear()
            'wSheet.Cells.Range("A5").Value = "GENERADO :"
            'wSheet.Cells.Range("B5").Value = Now
            wSheet2.Cells.Range("A7:D7").Merge()
            wSheet2.Cells.Range("A7:D7").Value = "SELL IN CARGILL BALANCEADOS"
            wSheet2.Cells.Range("A7:D7").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet2.Cells.Range("A7:D7").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet2.Cells.Range("A7:D7").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet2.Cells.Range("A7:D7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet2.Cells.Range("A7:D7").Font.Bold = True
            wSheet2.Cells.Range("C4").Value = "FECHA INICIAL"
            wSheet2.Cells.Range("C4").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet2.Cells.Range("C4").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet2.Cells.Range("C4").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet2.Cells.Range("C4").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet2.Cells.Range("C4").Font.Bold = True
            wSheet2.Cells.Range("D4").Value = _cmbFechai.Value.Date
            wSheet2.Cells.Range("D4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet2.Cells.Range("C5").Value = "FECHA FINAL"
            wSheet2.Cells.Range("C5").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet2.Cells.Range("C5").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet2.Cells.Range("C5").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet2.Cells.Range("C5").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet2.Cells.Range("C5").Font.Bold = True
            wSheet2.Cells.Range("D5").Value = _cmbFechaf.Value.Date
            wSheet2.Cells.Range("D5").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet2.Cells.Range("A7:D7").Select()
            For c As Integer = 0 To grd_balanceados.Columns.Count - 1
                wSheet2.Cells(8, c + 1).value = grd_balanceados.Columns(c).HeaderText
                wSheet2.Cells(8, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                wSheet2.Cells(8, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet2.Cells(8, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet2.Cells(8, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet2.Cells(8, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                wSheet2.Cells(8, c + 1).Font.Bold = True
            Next
            For r As Integer = 0 To grd_balanceados.RowCount - 1
                For c As Integer = 0 To grd_balanceados.Columns.Count - 1
                    wSheet2.Cells(r + 9, c + 1).value = grd_balanceados.Item(c, r).Value
                    wSheet2.Cells(r + 9, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet2.Columns.AutoFit()


            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            grd_balanceados.DataSource = Conexion.VentasTotProd(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "sellin_cargill_det_BAL", "1")
            grd_mascotas.DataSource = Conexion.VentasTotProd(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "sellin_cargill_det_PET", "1")
        Catch ex As Exception
            MsgBox("Error al cargar los datos " + ex.ToString)
        End Try
    End Sub
End Class