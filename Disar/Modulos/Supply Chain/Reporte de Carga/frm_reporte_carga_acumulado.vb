Imports Disar.data
Public Class frm_reporte_carga_acumulado
    Dim Clase As New cls_reporte_carga
    Dim style, style2 As Microsoft.Office.Interop.Excel.Style
    Dim Tabla As New DataTable
    Dim TotalCan, TotalImp, TotaPes As Integer
    Dim Filas As DataRow = Tabla.NewRow
    Dim Activo As Integer = 0
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            Activo = 1
            grdBodega.DataSource = Clase.reporte_carga_acumulado(cmbFecha_ini.Value, cmb_Fecha_fin.Value, "GENERAL", cmbAlmacen.SelectedValue, cmbSucursal.SelectedItem)
            grdBodega.Columns(6).Visible = False

            Dim Uni, pes, dine As Double
            For i As Integer = 0 To grdBodega.RowCount - 1
                Uni += grdBodega.Rows(i).Cells(3).Value
                dine += grdBodega.Rows(i).Cells(4).Value
                pes += grdBodega.Rows(i).Cells(6).Value
            Next
            dinerobodega.Text = FormatNumber(dine, 2)
            pesobodega.Text = FormatNumber(pes, 2)
            Unidadesbodega.Text = FormatNumber(Uni, 2)
            dine = 0
            Uni = 0
            pes = 0

            Dim conexion As New cls_bitacora_reporteador
            conexion.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Genero Reporte de carga acumulado", "Supply Chain", _
                                      "Fecha del reporte: " + cmbFecha_ini.Value.Date + " " + cmb_Fecha_fin.Value.Date + _
                                      " almacen:" + cmbAlmacen.SelectedValue.ToString)
        Catch ex As Exception
            MsgBox("Error al Generar Reporte de Carga ")
        End Try
    End Sub


    Private Sub frm_reporte_carga_acumulado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSucursal.SelectedItem = "CONSUMO"
        Cargar_Almacen()
    End Sub

    Sub Cargar_Almacen()
        cmbAlmacen.DataSource = Clase.getAlmacen(0, 0, cmbSucursal.SelectedItem, Now, "", "ALM", 1)
        cmbAlmacen.ValueMember = "ID"
        cmbAlmacen.DisplayMember = "ALMACEN"
    End Sub

    Private Sub cmbSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSucursal.SelectedIndexChanged
        Cargar_Almacen()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()


            wSheet.Name = "Bodega"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Size = 9
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            If grdBodega.RowCount <= 0 Then
            Else
                Clipboard.Clear()
                Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
                wSheet.Select()
                wSheet.Cells.Range("A1").Select()
                Try
                    wSheet.Paste()
                Catch ex As Exception
                End Try

                wSheet.Cells.Range("A7:C7").Merge()
                wSheet.Cells.Range("A7:C7").Value = "REPORTE DE CARGA"
                wSheet.Cells.Range("A7:C7").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet.Cells.Range("A7:C7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


                wSheet.Cells.Range("B19:D19").Merge()
                wSheet.Cells.Range("B19:D19").Value = "________________________________"
                wSheet.Cells.Range("B19:D19").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet.Cells.Range("B19:D19").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                wSheet.Cells.Range("B20:D20").Merge()
                wSheet.Cells.Range("B20:D20").Value = "     FIRMA DEL ENTREGADOR     "
                wSheet.Cells.Range("B20:D20").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet.Cells.Range("B20:D20").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                wSheet.Cells.Range("A1:G1").Font.Size = 10
                wSheet.Cells(3, 1).Font.Size = 9
                wSheet.Cells(4, 1).Font.Size = 9
                wSheet.Cells(5, 1).Font.Size = 9
                wSheet.Cells(6, 1).Font.Size = 9
                wSheet.Cells(6, 2).Font.Size = 9
                wSheet.Cells(7, 1).Font.Size = 9
                wSheet.Cells(8, 1).Font.Size = 9
                wSheet.Cells(8, 2).Font.Size = 9
                wSheet.Cells(8, 3).Font.Size = 9
                wSheet.Cells(9, 1).Font.Size = 9
                wSheet.Cells(10, 1).value = "VENTA:"
                wSheet.Cells(11, 1).value = "RUTA:"
                wSheet.Cells(12, 1).value = "VENDIDO:"
                wSheet.Cells(13, 1).value = "FACTURADO: "

           

                wSheet.Cells(16, 1).value = "ENTREGADOR:"
                wSheet.Cells(17, 1).value = "PESO: "
                wSheet.Cells(17, 2).value = pesobodega.Text
                For c As Integer = 0 To grdBodega.Columns.Count - 2
                    wSheet.Cells(22, c + 1).value = grdBodega.Columns(c).HeaderText
                    wSheet.Cells(22, c + 1).Style = "Reportes"
                Next
                Dim Cont As Integer = 0
                For r As Integer = 0 To grdBodega.RowCount - 1
                    For c As Integer = 0 To grdBodega.Columns.Count - 2
                        If c = 1 Then
                            wSheet.Cells(r + 23, c + 1).value = "'" + grdBodega.Item(c, r).Value
                        Else

                            wSheet.Cells(r + 23, c + 1).value = grdBodega.Item(c, r).Value
                        End If
                        wSheet.Cells(r + 23, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                        wSheet.Cells(r + 23, c + 1).Font.Size = 9
                        Cont = r + 23
                    Next
                Next
                wSheet.Cells(Cont + 1, 3).value = "TOTALES"
                wSheet.Cells(Cont + 1, 3).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(Cont + 1, 3).Font.Size = 9
                wSheet.Cells(Cont + 1, 3).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(Cont + 1, 3).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                wSheet.Cells(Cont + 1, 4).value = Unidadesbodega.Text
                wSheet.Cells(Cont + 1, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(Cont + 1, 4).Font.Size = 9
                wSheet.Cells(Cont + 1, 4).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(Cont + 1, 4).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                wSheet.Cells(Cont + 1, 5).value = dinerobodega.Text
                wSheet.Cells(Cont + 1, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(Cont + 1, 5).Font.Size = 9
                wSheet.Cells(Cont + 1, 5).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(Cont + 1, 5).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)


                wSheet.Columns.AutoFit()
            End If


            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
 
End Class