Imports Disar.data
Public Class Reporte_de_Quintales
    Dim Conexion As New cls_ventas_diarias_agro
    Dim style, style3, style4, style2, style5 As Microsoft.Office.Interop.Excel.Style

    Private Sub Reporte_de_Quintales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _cmbFechai.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            _cmbFechaf.Value = Today
        Else
            _cmbFechaf.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub

    Sub Cargar()
        Try
            _gridalex.DataSource = Conexion.Quintales_Agro(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "srcQAGRO1")
        Catch ex As Exception
            MsgBox("Error al cargar datos de Alex" + ex.Message)
        End Try

        Try
            _gridallan.DataSource = Conexion.Quintales_Agro(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "srcQAGRO2")
        Catch ex As Exception
            MsgBox("Error al cargar datos de Allan" + ex.Message)
        End Try

        Try
            _gridsrc.DataSource = Conexion.Quintales_Agro(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "srcQAGRO3")
        Catch ex As Exception
            MsgBox("Error al cargar datos de SRC" + ex.Message)
        End Try

        Try
            _gridgracias.DataSource = Conexion.Quintales_Agro(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "srcQAGRO4")
        Catch ex As Exception
            MsgBox("Error al cargar datos de Gracias" + ex.Message)
        End Try

        Try
            _gridResumen.DataSource = Conexion.Quintales_Agro(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "srcQAGROresumen")
        Catch ex As Exception
            MsgBox("Error al cargar datos de Resumen" + ex.Message)
        End Try
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        If _cmbFechaf.Value.Date < _cmbFechai.Value.Date Then
            MessageBox.Show("La fecha inicial no puede ser mayor a la final", "Fechas Incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Cargar()
        End If
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet, wSheet2, wSheet3, wSheet4, wSheet5 As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = Allan.Text

            style4 = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style4.Font.Bold = True
            style4.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style4.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style4.Font.Size = 11
            style4.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:D1").Merge()
            wSheet.Cells.Range("A1:D1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:D1").Value = "REPORTE QUINTALES DE " + Allan.Text.ToUpper
            wSheet.Cells.Range("A1:D1").Style = "Reportes"

            For c As Integer = 0 To _gridallan.Columns.Count - 2
                wSheet.Cells(2, c + 1).value = _gridallan.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridallan.RowCount - 1
                For c As Integer = 0 To _gridallan.Columns.Count - 2
                    wSheet.Cells(r + 3, c + 1).value = _gridallan.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next

            wSheet2 = wBook.Sheets.Add()
            wSheet2.Name = Alex.Text
            wSheet2.Cells.Range("A1:D1").Merge()
            wSheet2.Cells.Range("A1:D1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet2.Cells.Range("A1:D1").Value = "REPORTE QUINTALES DE " + Alex.Text.ToUpper
            wSheet2.Cells.Range("A1:D1").Style = "Reportes"

            For c As Integer = 0 To _gridalex.Columns.Count - 2
                wSheet2.Cells(2, c + 1).value = _gridalex.Columns(c).HeaderText
                wSheet2.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridalex.RowCount - 1
                For c As Integer = 0 To _gridalex.Columns.Count - 2
                    wSheet2.Cells(r + 3, c + 1).value = _gridalex.Item(c, r).Value
                    wSheet2.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next

            wSheet4 = wBook.Sheets.Add()
            wSheet4.Name = SRC.Text
            wSheet4.Cells.Range("A1:D1").Merge()
            wSheet4.Cells.Range("A1:D1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet4.Cells.Range("A1:D1").Value = "REPORTE QUINTALES DE " + SRC.Text.ToUpper
            wSheet4.Cells.Range("A1:D1").Style = "Reportes"

            For c As Integer = 0 To _gridsrc.Columns.Count - 1
                wSheet4.Cells(2, c + 1).value = _gridsrc.Columns(c).HeaderText
                wSheet4.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridsrc.RowCount - 1
                For c As Integer = 0 To _gridsrc.Columns.Count - 1
                    wSheet4.Cells(r + 3, c + 1).value = _gridsrc.Item(c, r).Value
                    wSheet4.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next

            wSheet5 = wBook.Sheets.Add()
            wSheet5.Name = Agrogracias.Text
            wSheet5.Cells.Range("A1:D1").Merge()
            wSheet5.Cells.Range("A1:D1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet5.Cells.Range("A1:D1").Value = "REPORTE QUINTALES DE " + Agrogracias.Text.ToUpper
            wSheet5.Cells.Range("A1:D1").Style = "Reportes"

            For c As Integer = 0 To _gridgracias.Columns.Count - 1
                wSheet5.Cells(2, c + 1).value = _gridgracias.Columns(c).HeaderText
                wSheet5.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridgracias.RowCount - 1
                For c As Integer = 0 To _gridgracias.Columns.Count - 1
                    wSheet5.Cells(r + 3, c + 1).value = _gridgracias.Item(c, r).Value
                    wSheet5.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next

            wSheet3 = wBook.Sheets.Add()
            wSheet3.Name = resumen.Text
            wSheet3.Cells.Range("A1").Value = "--------------------------------------------------------------------------------"
            wSheet3.Cells.Range("A1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet3.Cells.Range("B1").Value = "---------------------"
            wSheet3.Cells.Range("B1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet3.Cells.Range("A1").Select()
            Try
                wSheet3.Paste()
            Catch ex As Exception
            End Try

            wSheet3.Cells.Range("A6:B6").Merge()
            wSheet3.Cells.Range("A6:B6").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet3.Cells.Range("A6:B6").Value = "REPORTE EN QUINTALES " + resumen.Text.ToUpper
            wSheet3.Cells.Range("A6:B6").Style = "Reportes"

            For c As Integer = 0 To _gridResumen.Columns.Count - 1
                wSheet3.Cells(7, c + 1).value = _gridResumen.Columns(c).HeaderText
                wSheet3.Cells(7, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridResumen.RowCount - 1
                For c As Integer = 0 To _gridResumen.Columns.Count - 1
                    wSheet3.Cells(r + 8, c + 1).value = _gridResumen.Item(c, r).Value
                    wSheet3.Cells(r + 8, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet5.Columns.AutoFit()
            wSheet4.Columns.AutoFit()
            wSheet3.Columns.AutoFit()
            wSheet2.Columns.AutoFit()
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class