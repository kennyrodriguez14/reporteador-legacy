Imports Disar.data
Public Class frm_devoluciones_sragro
    Dim Conexion As New cls_reportes_varios 'clsReportesVarios
    Dim conexion2 As New cls_descuentos_tacticos_sragro
    Private Sub frm_devoluciones_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_almacen()
    End Sub

    Sub cargar_almacen()
        cmbsucursal.DataSource = conexion2.ListarAlmacenes()
        cmbsucursal.ValueMember = "ID"
        cmbsucursal.DisplayMember = "ALMACEN"
    End Sub

    Sub Cargar()
        Try
            _griddevoluciones.DataSource = Conexion.Devoluciones_SRAGRO(f1.Value.Date, f2.Value.Date, cmbsucursal.SelectedValue, "DEVOS")
            _gridAdicionales.DataSource = Conexion.Devoluciones_SRAGRO(f1.Value.Date, f2.Value.Date, cmbsucursal.SelectedValue, "ADICIONALES")

            TotalFacturado.Text = FormatNumber(_gridAdicionales.Rows(0).Cells(0).Value - _gridAdicionales.Rows(1).Cells(0).Value, 2)
            Dim D As Double = 0
            For i As Integer = 0 To _griddevoluciones.RowCount - 1
                D += _griddevoluciones.Rows(i).Cells(5).Value
            Next
            totaldevuelto.Text = FormatNumber(D, 2)
            efectividad.Text = FormatNumber(TotalFacturado.Text - totaldevuelto.Text, 2)
            porcentajeefec.Text = FormatPercent(efectividad.Text / TotalFacturado.Text, 2)
        Catch ex As Exception
            MsgBox("Error al cargar los datos " + ex.ToString)
        End Try
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Cargar()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Cells.Range("C2:E2").Merge()
            wSheet.Cells.Range("C2:E2").Value = "Devoluciones de " + f1.Value.Date + " al " + f2.Value.Date
            'wSheet.Cells.Range("C2:E2").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("C2:E2").Font.Size = 12
            wSheet.Cells.Range("C2:E2").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick)
            'wSheet.Cells.Range("C2:E2").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("C2:E2").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("C2:E2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("C2:E2").Font.Bold = True

            wSheet.Cells.Range("H1").Value = "----------------------------------------"
            wSheet.Cells.Range("H1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, imagen2.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet.Cells.Range("H1").Select()
            Try
                wSheet.Paste()
            Catch ex As Exception
            End Try

            wSheet.Cells.Range("A1").Value = "----------------------------------------"
            wSheet.Cells.Range("A1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet.Cells.Range("A1").Select()
            Try
                wSheet.Paste()
            Catch ex As Exception
            End Try
            Dim Cont As Integer = 0
            Dim f As Integer = 0
            For c As Integer = 0 To _griddevoluciones.Columns.Count - 1
                wSheet.Cells(4, c + 1).value = _griddevoluciones.Columns(c).HeaderText
                wSheet.Cells(4, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(4, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(4, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(4, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet.Cells(4, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                wSheet.Cells(4, c + 1).Font.Bold = True
            Next
            For r As Integer = 0 To _griddevoluciones.RowCount - 1
                For c As Integer = 0 To _griddevoluciones.Columns.Count - 1
                    wSheet.Cells(r + 5, c + 1).value = _griddevoluciones.Item(c, r).Value
                    wSheet.Cells(r + 5, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
                Cont = r + 5
            Next

            For c As Integer = 0 To _griddevoluciones.Columns.Count - 1
                wSheet.Cells(Cont + 1, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(Cont + 1, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(Cont + 1, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(Cont + 1, c + 1).Font.Bold = True
            Next
            Try
                wSheet.Cells(Cont + 1, 5).value = " Total "
                wSheet.Cells(Cont + 1, 6).value = totaldevuelto.Text

                For i As Integer = 3 To _griddevoluciones.ColumnCount - 2
                    wSheet.Cells(Cont + 3, i).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(Cont + 3, i).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                    wSheet.Cells(Cont + 3, i).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                    wSheet.Cells(Cont + 3, i).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(Cont + 3, i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    wSheet.Cells(Cont + 3, i).Font.Bold = True
                Next

                For i As Integer = 3 To _griddevoluciones.ColumnCount - 2
                    wSheet.Cells(Cont + 4, i).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(Cont + 4, i).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(Cont + 4, i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    wSheet.Cells(Cont + 4, i).Font.Bold = True
                Next

                wSheet.Cells(Cont + 3, 3).value = "Total Monto Facturado"
                wSheet.Cells(Cont + 4, 3).value = TotalFacturado.Text
                wSheet.Cells(Cont + 3, 4).value = "Total Monto Devuelto"
                wSheet.Cells(Cont + 4, 4).value = totaldevuelto.Text
                wSheet.Cells(Cont + 3, 5).value = "Efectividad"
                wSheet.Cells(Cont + 4, 5).value = efectividad.Text
                wSheet.Cells(Cont + 3, 6).value = "% Efectividad"
                wSheet.Cells(Cont + 4, 6).value = porcentajeefec.Text
                Cont = Cont + 3
            Catch ex As Exception
                MsgBox("Error al calcular totales " + ex.ToString)
            End Try
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class