Imports Disar.data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class ReporteCarga_valorCero
    Dim Clase As New cls_reporte_carga_valorcero 'clsRptCarga
    Dim style, style2 As Microsoft.Office.Interop.Excel.Style
    Dim Tabla As New DataTable
    Dim TotalCan, TotalImp, TotaPes As Integer
    Dim Filas As DataRow = Tabla.NewRow
    Dim Activo As Integer = 0

    Dim direccion_archivo = ""


    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        desde()
        hasta()
        If _txtDesde.Text.Length > 8 Or _txtHasta.Text.Length > 8 Then
            MessageBox.Show("Valores erroneos en rangos de facturas")
        Else
            If _txtDesde.Text = "" Or _txtHasta.Text = "" Then
                MsgBox("Campos Vacios", MsgBoxStyle.Information, "Facturas")
            ElseIf Val(_txtDesde.Text) > Val(_txtHasta.Text) Then
                MsgBox("La Factura Inicial debe ser menor que la Final", MsgBoxStyle.Information, "Rango Equivocado")
            Else
                Try
                    Activo = 1
                    grdBodega.DataSource = Clase.RC(folio_ini.Text + _txtDesde.Text, folio_fin.Text + _txtHasta.Text, cmbSucursal.SelectedItem, _
                                                    cmbFecha.Value.Date, "N", "GENERAL", cmbAlmacen.SelectedValue)
                    grdBodega.Columns(6).Visible = False
                    grdContado.DataSource = Clase.RC(folio_ini.Text + _txtDesde.Text, folio_fin.Text + _txtHasta.Text, cmbSucursal.SelectedItem, _
                                                     cmbFecha.Value.Date, "Cont", "FILTRO", cmbAlmacen.SelectedValue)
                    grdCredito.DataSource = Clase.RC(folio_ini.Text + _txtDesde.Text, folio_fin.Text + _txtHasta.Text, cmbSucursal.SelectedItem, _
                                                     cmbFecha.Value.Date, "Cred", "FILTRO", cmbAlmacen.SelectedValue)
                    Dim Uni, pes As Double
                    For i As Integer = 0 To grdBodega.RowCount - 1
                        Uni += grdBodega.Rows(i).Cells.Item("CANT").Value

                        pes += grdBodega.Rows(i).Cells.Item("PESO").Value
                    Next
                    rango.Text = Val(_txtHasta.Text) - Val(_txtDesde.Text) + 1

                    pesobodega.Text = FormatNumber(pes, 2)
                    Unidadesbodega.Text = FormatNumber(Uni, 2)

                    Uni = 0
                    pes = 0
                    For i As Integer = 0 To grdContado.RowCount - 1
                        Uni += grdContado.Rows(i).Cells.Item("CANT").Value

                        pes += grdContado.Rows(i).Cells.Item("PESO").Value
                    Next

                    pesocontado.Text = FormatNumber(pes, 2)
                    unidadescontado.Text = FormatNumber(Uni, 2)

                    Uni = 0
                    pes = 0
                    For i As Integer = 0 To grdCredito.RowCount - 1
                        Uni += grdCredito.Rows(i).Cells.Item("CANT").Value
                        pes += grdCredito.Rows(i).Cells.Item("PESO").Value
                    Next

                    pesocredito.Text = FormatNumber(pes, 2)
                    unidadescredito.Text = FormatNumber(Uni, 2)

                    Uni = 0
                    pes = 0

                    Dim conexion As New cls_bitacora_reporteador
                    conexion.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Genero Reporte de carga valor 0", "Supply Chain", _
                                              "Fecha del reporte: " + cmbFecha.Value.Date + " Facturas: " + _txtDesde.Text + "-" + _txtHasta.Text _
                                              + " almacen:" + cmbAlmacen.SelectedValue.ToString)
                    _txtDesde.Enabled = False
                    _txtHasta.Enabled = False
                Catch ex As Exception
                    MsgBox("Error al Generar Reporte de Carga ")
                End Try
            End If
        End If
    End Sub

    Sub desde()

        Dim cero As String = ""
        Dim num As String = ""
        num = _txtDesde.Text
        For index As Integer = 1 To 8 - num.Length
            cero += "0"
        Next
        _txtDesde.Text = cero + _txtDesde.Text
        _txtHasta.Focus()

    End Sub

    Sub hasta()
        Dim cero As String = ""
        Dim num As String = ""
        num = _txtHasta.Text
        For index As Integer = 1 To 8 - num.Length
            cero += "0"
        Next
        _txtHasta.Text = cero + _txtHasta.Text
        _btnGenerar.Focus()
    End Sub

    Private Sub _btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnLimpiar.Click
        _txtDesde.Enabled = True
        _txtHasta.Enabled = True
        rango.Text = ""

        Unidadesbodega.Text = ""
        pesobodega.Text = ""

        unidadescontado.Text = ""
        pesocontado.Text = ""

        unidadescredito.Text = ""
        pesocredito.Text = ""

        Activo = 0
        _txtDesde.Text = ""
        _txtHasta.Text = ""
        grdBodega.DataSource = Nothing
        grdContado.DataSource = Nothing
        grdCredito.DataSource = Nothing
        _txtDesde.Focus()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet, wSheet2, wSheet3 As Microsoft.Office.Interop.Excel.Worksheet

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

            'CLIENTES CONTADO
            wSheet2 = wBook.Sheets.Add()
            wSheet2 = wBook.ActiveSheet()
            wSheet2.Name = "Contado"
            If grdContado.RowCount <= 0 Then
            Else
                Clipboard.Clear()
                Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
                wSheet2.Cells.Range("A1").Select()
                Try
                    wSheet2.Paste()
                Catch ex As Exception
                End Try

                wSheet2.Cells.Range("A7:C7").Merge()
                wSheet2.Cells.Range("A7:C7").Value = "REPORTE DE CARGA"
                wSheet2.Cells.Range("A7:C7").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet2.Cells.Range("A7:C7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                wSheet2.Cells.Range("B19:D19").Merge()
                wSheet2.Cells.Range("B19:D19").Value = "________________________________"
                wSheet2.Cells.Range("B19:D19").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet2.Cells.Range("B19:D19").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                wSheet2.Cells.Range("B20:D20").Merge()
                wSheet2.Cells.Range("B20:D20").Value = "     FIRMA DEL ENTREGADOR     "
                wSheet2.Cells.Range("B20:D20").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet2.Cells.Range("B20:D20").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                wSheet2.Cells.Range("A1:G1").Font.Size = 10
                wSheet2.Cells(3, 1).Font.Size = 9
                wSheet2.Cells(4, 1).Font.Size = 9
                wSheet2.Cells(5, 1).Font.Size = 9
                wSheet2.Cells(6, 1).Font.Size = 9
                wSheet2.Cells(6, 2).Font.Size = 9
                wSheet2.Cells(7, 1).Font.Size = 9
                wSheet2.Cells(8, 1).Font.Size = 9
                wSheet2.Cells(8, 2).Font.Size = 9
                wSheet2.Cells(8, 3).Font.Size = 9
                wSheet2.Cells(9, 1).Font.Size = 9
                wSheet2.Cells(10, 1).value = "VENTA:"
                wSheet2.Cells(11, 1).value = "RUTA:"
                wSheet2.Cells(12, 1).value = "VENDIDO:"
                wSheet2.Cells(13, 1).value = "FACTURADO: "

                wSheet2.Cells(14, 1).value = "ENTREGADO:"
                If _txtDesde.Text = _txtHasta.Text Then
                    wSheet2.Cells(15, 1).value = "Nº FACTURA: "
                    wSheet2.Cells(15, 2).value = _txtDesde.Text
                Else
                    wSheet2.Cells(15, 1).value = "Nº FACTURAS: "
                    wSheet2.Cells(15, 2).value = grdContado.Rows(0).Cells(5).Value
                    wSheet2.Cells(15, 3).value = grdContado.Rows(0).Cells(6).Value
                End If

                wSheet2.Cells(16, 1).value = "ENTREGADOR:"

                For c As Integer = 0 To grdContado.Columns.Count - 3
                    If c = grdContado.Columns.Count - 3 Then
                        wSheet2.Cells(22, c + 1).value = grdContado.Columns(7).HeaderText
                        wSheet2.Cells(22, c + 1).Style = "Reportes"
                    Else
                        wSheet2.Cells(22, c + 1).value = grdContado.Columns(c).HeaderText
                        wSheet2.Cells(22, c + 1).Style = "Reportes"
                    End If
                Next

                Dim Cont2 As Integer = 0
                For r As Integer = 0 To grdContado.RowCount - 1
                    For c As Integer = 0 To grdContado.Columns.Count - 3
                        If c = grdContado.Columns.Count - 3 Then
                            wSheet2.Cells(r + 23, c + 1).value = grdContado.Item(7, r).Value
                            wSheet2.Cells(r + 23, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet2.Cells(r + 23, c + 1).Font.Size = 9
                            Cont2 = r + 23
                        Else
                            wSheet2.Cells(r + 23, c + 1).value = grdContado.Item(c, r).Value
                            wSheet2.Cells(r + 23, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet2.Cells(r + 23, c + 1).Font.Size = 9
                            Cont2 = r + 23
                        End If
                    Next
                Next
                wSheet2.Cells(Cont2 + 1, 2).value = "TOTALES"
                wSheet2.Cells(Cont2 + 1, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(Cont2 + 1, 2).Font.Size = 9
                wSheet2.Cells(Cont2 + 1, 2).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet2.Cells(Cont2 + 1, 2).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                wSheet2.Cells(Cont2 + 1, 3).value = unidadescontado.Text
                wSheet2.Cells(Cont2 + 1, 3).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(Cont2 + 1, 3).Font.Size = 9
                wSheet2.Cells(Cont2 + 1, 3).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet2.Cells(Cont2 + 1, 3).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                wSheet2.Cells(Cont2 + 1, 4).value = ""
                wSheet2.Cells(Cont2 + 1, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(Cont2 + 1, 4).Font.Size = 9
                wSheet2.Cells(Cont2 + 1, 4).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet2.Cells(Cont2 + 1, 4).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                wSheet2.Cells(Cont2 + 1, 5).value = pesocontado.Text
                wSheet2.Cells(Cont2 + 1, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(Cont2 + 1, 5).Font.Size = 9
                wSheet2.Cells(Cont2 + 1, 5).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet2.Cells(Cont2 + 1, 5).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet2.Columns.AutoFit()
            End If
            'CLIENTES CREDITO
            wSheet3 = wBook.Sheets.Add()
            wSheet3 = wBook.ActiveSheet()
            wSheet3.Name = "Credito"

            If grdCredito.RowCount <= 0 Then
            Else
                Clipboard.Clear()
                Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
                wSheet3.Cells.Range("A1").Select()
                Try
                    wSheet3.Paste()
                Catch ex As Exception
                End Try


                wSheet3.Cells.Range("A7:C7").Merge()
                wSheet3.Cells.Range("A7:C7").Value = "REPORTE DE CARGA"
                wSheet3.Cells.Range("A7:C7").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet3.Cells.Range("A7:C7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                wSheet3.Cells.Range("B19:D19").Merge()
                wSheet3.Cells.Range("B19:D19").Value = "________________________________"
                wSheet3.Cells.Range("B19:D19").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet3.Cells.Range("B19:D19").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                wSheet3.Cells.Range("B20:D20").Merge()
                wSheet3.Cells.Range("B20:D20").Value = "     FIRMA DEL ENTREGADOR     "
                wSheet3.Cells.Range("B20:D20").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet3.Cells.Range("B20:D20").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                wSheet3.Cells.Range("A1:G1").Font.Size = 10
                wSheet3.Cells(3, 1).Font.Size = 9
                wSheet3.Cells(4, 1).Font.Size = 9
                wSheet3.Cells(5, 1).Font.Size = 9
                wSheet3.Cells(6, 1).Font.Size = 9
                wSheet3.Cells(6, 2).Font.Size = 9
                wSheet3.Cells(7, 1).Font.Size = 9
                wSheet3.Cells(8, 1).Font.Size = 9
                wSheet3.Cells(8, 2).Font.Size = 9
                wSheet3.Cells(8, 3).Font.Size = 9
                wSheet3.Cells(9, 1).Font.Size = 9
                wSheet3.Cells(10, 1).value = "VENTA:"
                wSheet3.Cells(11, 1).value = "RUTA:"
                wSheet3.Cells(12, 1).value = "VENDIDO:"
                wSheet3.Cells(13, 1).value = "FACTURADO: "

                wSheet3.Cells(14, 1).value = "ENTREGADO:"
                If _txtDesde.Text = _txtHasta.Text Then
                    wSheet3.Cells(15, 1).value = "Nº FACTURA: "
                    wSheet3.Cells(15, 2).value = _txtDesde.Text
                Else
                    wSheet3.Cells(15, 1).value = "Nº FACTURAS: "
                    wSheet3.Cells(15, 2).value = grdCredito.Rows(0).Cells(5).Value
                    wSheet3.Cells(15, 3).value = grdCredito.Rows(0).Cells(6).Value
                End If

                wSheet3.Cells(16, 1).value = "ENTREGADOR:"

                For c As Integer = 0 To grdCredito.Columns.Count - 3
                    If c = grdCredito.Columns.Count - 3 Then
                        wSheet3.Cells(22, c + 1).value = grdCredito.Columns(7).HeaderText
                        wSheet3.Cells(22, c + 1).Style = "Reportes"
                    Else
                        wSheet3.Cells(22, c + 1).value = grdCredito.Columns(c).HeaderText
                        wSheet3.Cells(22, c + 1).Style = "Reportes"
                    End If
                Next
                Dim Cont3 As Integer = 0
                For r As Integer = 0 To grdCredito.RowCount - 1
                    For c As Integer = 0 To grdCredito.Columns.Count - 3
                        If c = grdCredito.Columns.Count - 3 Then
                            wSheet3.Cells(r + 23, c + 1).value = grdCredito.Item(7, r).Value
                            wSheet3.Cells(r + 23, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet3.Cells(r + 23, c + 1).Font.Size = 9
                            Cont3 = r + 23
                        Else
                            wSheet3.Cells(r + 23, c + 1).value = grdCredito.Item(c, r).Value
                            wSheet3.Cells(r + 23, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet3.Cells(r + 23, c + 1).Font.Size = 9
                            Cont3 = r + 23
                        End If
                    Next
                Next
                wSheet3.Cells(Cont3 + 1, 2).value = "TOTALES"
                wSheet3.Cells(Cont3 + 1, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(Cont3 + 1, 2).Font.Size = 9
                wSheet3.Cells(Cont3 + 1, 2).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet3.Cells(Cont3 + 1, 2).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                wSheet3.Cells(Cont3 + 1, 3).value = unidadescredito.Text
                wSheet3.Cells(Cont3 + 1, 3).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(Cont3 + 1, 3).Font.Size = 9
                wSheet3.Cells(Cont3 + 1, 3).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet3.Cells(Cont3 + 1, 3).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                wSheet3.Cells(Cont3 + 1, 4).value = ""
                wSheet3.Cells(Cont3 + 1, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(Cont3 + 1, 4).Font.Size = 9
                wSheet3.Cells(Cont3 + 1, 4).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet3.Cells(Cont3 + 1, 4).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                wSheet3.Cells(Cont3 + 1, 5).value = pesocredito.Text
                wSheet3.Cells(Cont3 + 1, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(Cont3 + 1, 5).Font.Size = 9
                wSheet3.Cells(Cont3 + 1, 5).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet3.Cells(Cont3 + 1, 5).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet3.Columns.AutoFit()
            End If

            'BODEGA
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

                wSheet.Cells(14, 1).value = "ENTREGADO:"
                If _txtDesde.Text = _txtHasta.Text Then
                    wSheet.Cells(15, 1).value = "Nº FACTURA: "
                    wSheet.Cells(15, 2).value = _txtDesde.Text
                Else
                    wSheet.Cells(15, 1).value = "Nº FACTURAS: "
                    wSheet.Cells(15, 2).value = _txtDesde.Text
                    wSheet.Cells(15, 3).value = _txtHasta.Text
                End If

                wSheet.Cells(16, 1).value = "ENTREGADOR:"
                wSheet.Cells(17, 1).value = "PESO: "
                wSheet.Cells(17, 2).value = pesobodega.Text
                For c As Integer = 0 To grdBodega.Columns.Count - 1
                    wSheet.Cells(22, c + 1).value = grdBodega.Columns(c).HeaderText
                    wSheet.Cells(22, c + 1).Style = "Reportes"
                Next
                Dim Cont As Integer = 0
                For r As Integer = 0 To grdBodega.RowCount - 1
                    For c As Integer = 0 To grdBodega.Columns.Count - 1
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

                If cmbAlmacen.SelectedValue = 1 Then
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

                    wSheet.Cells(Cont + 1, 5).value = ""
                    wSheet.Cells(Cont + 1, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(Cont + 1, 5).Font.Size = 9
                    wSheet.Cells(Cont + 1, 5).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                    wSheet.Cells(Cont + 1, 5).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                Else
                    wSheet.Cells(Cont + 1, 3).value = Unidadesbodega.Text
                    wSheet.Cells(Cont + 1, 3).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(Cont + 1, 3).Font.Size = 9
                    wSheet.Cells(Cont + 1, 3).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                    wSheet.Cells(Cont + 1, 3).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                    wSheet.Cells(Cont + 1, 4).value = "TOTALES"
                    wSheet.Cells(Cont + 1, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(Cont + 1, 4).Font.Size = 9
                    wSheet.Cells(Cont + 1, 4).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                    wSheet.Cells(Cont + 1, 4).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

                    wSheet.Cells(Cont + 1, 5).value = ""
                    wSheet.Cells(Cont + 1, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(Cont + 1, 5).Font.Size = 9
                    wSheet.Cells(Cont + 1, 5).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                    wSheet.Cells(Cont + 1, 5).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                End If
                


                wSheet.Columns.AutoFit()
            End If


            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub ReporteCarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmbSucursal.Items.Clear()
        Catch ex As Exception
        End Try
        If _Inicio.SANRAFAEL = 1 Then
            cmbSucursal.Items.Add("CONSUMO")
        End If
        If _Inicio.DIMOSA = 1 Then
            cmbSucursal.Items.Add("DIMOSA")
        End If
        If _Inicio.AGRO = 1 Then
            cmbSucursal.Items.Add("SR AGRO")
        End If

        cmbSucursal.Items.Add("OPL")

        cmbSucursal.SelectedIndex = 0
    End Sub

    Sub Cargar_Almacen()
        cmbAlmacen.DataSource = Clase.getAlmacen(0, 0, cmbSucursal.SelectedItem, Now, "", "ALM", 1)
        cmbAlmacen.ValueMember = "ID"
        cmbAlmacen.DisplayMember = "ALMACEN"
    End Sub

    Private Sub cmbSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSucursal.SelectedIndexChanged
        Cargar_Almacen()
    End Sub

    Private Sub cmbAlmacen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAlmacen.SelectedIndexChanged
        If cmbSucursal.SelectedItem = "CONSUMO" Then
            If cmbAlmacen.SelectedValue.ToString = "1" Then
                folio_ini.Text = "00-001-01-"
                folio_fin.Text = "00-001-01-"
            ElseIf cmbAlmacen.SelectedValue.ToString = "2" Then
                folio_ini.Text = "01-001-01-"
                folio_fin.Text = "01-001-01-"
            ElseIf cmbAlmacen.SelectedValue.ToString = "3" Then
                If cmbFecha.Value <= Convert.ToDateTime("13/02/2018") Then
                    folio_ini.Text = "02-001-01-"
                    folio_fin.Text = "02-001-01-"
                Else
                    folio_ini.Text = "04-001-01-"
                    folio_fin.Text = "04-001-01-"
                End If
            ElseIf cmbAlmacen.SelectedValue.ToString = "4" Then
                folio_ini.Text = "03-001-01-"
                folio_fin.Text = "03-001-01-"
            End If
        ElseIf cmbSucursal.SelectedItem = "SR AGRO" Then
            Try
                Dim dt As New DataTable
                dt = Clase.getFolioAgro(cmbAlmacen.SelectedValue)
                folio_ini.Text = dt(0)(0)
                folio_fin.Text = dt(0)(0)
            Catch ex As Exception
            End Try
        ElseIf cmbSucursal.SelectedItem = "DIMOSA" Then
            Try
                If cmbAlmacen.SelectedValue.ToString = "1" Then
                    folio_ini.Text = "00-005-01-"
                    folio_fin.Text = "00-005-01-"
                End If
                If cmbAlmacen.SelectedValue.ToString = "2" Then
                    folio_ini.Text = "02-003-01-"
                    folio_fin.Text = "02-003-01-"
                End If
                If cmbAlmacen.SelectedValue.ToString = "3" Then
                    folio_ini.Text = "01-005-01-"
                    folio_fin.Text = "01-005-01-"
                End If
                If cmbAlmacen.SelectedValue.ToString = "4" Then
                    folio_ini.Text = "03-001-01-"
                    folio_fin.Text = "03-001-01-"
                End If
            Catch ex As Exception
            End Try
        ElseIf cmbSucursal.SelectedItem = "OPL" Then
            Try
                If cmbAlmacen.SelectedValue.ToString = "1" Then
                    folio_ini.Text = "00-001-01-"
                    folio_fin.Text = "00-001-01-"
                End If
                If cmbAlmacen.SelectedValue.ToString = "2" Then
                    folio_ini.Text = ""
                    folio_fin.Text = ""
                End If
                If cmbAlmacen.SelectedValue.ToString = "3" Then
                    folio_ini.Text = "01-001-01-"
                    folio_fin.Text = "01-001-01-"
                End If
                If cmbAlmacen.SelectedValue.ToString = "4" Then
                    folio_ini.Text = ""
                    folio_fin.Text = ""
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If Activo <> 1 Then
            MsgBox("Todavia no se Han Generado Datos", MsgBoxStyle.Exclamation, "Informacion Vacia")
        Else
            ExportarPDF()
        End If
    End Sub

    Private Sub cmbFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFecha.ValueChanged
        If cmbAlmacen.SelectedValue = 3 Then
            If cmbFecha.Value <= Convert.ToDateTime("13/02/2018") Then
                folio_ini.Text = "02-001-01-"
                folio_fin.Text = "02-001-01-"
            Else
                folio_ini.Text = "04-001-01-"
                folio_fin.Text = "04-001-01-"
            End If
        End If
    End Sub

    Sub ExportarPDF()
        Try
            FolderBrowserDialog1.Description = "Guardar Remision"
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
             Then
                direccion_archivo = FolderBrowserDialog1.SelectedPath + "\"
            End If

            ImprimirRemision_DISAR()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ImprimirRemision_DISAR()

        Dim tabla_encabezado As New PdfPTable(3)
        tabla_encabezado.DefaultCell.Padding = 3
        tabla_encabezado.DefaultCell.BorderColor = Color.WHITE
        tabla_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezado.WidthPercentage = (500 / 5.1F)
        tabla_encabezado.SetWidths(New Integer() {2, 4, 2})

        Dim tabla_encabezadoDetalles As New PdfPTable(4)
        tabla_encabezadoDetalles.DefaultCell.Padding = 3
        tabla_encabezadoDetalles.DefaultCell.BorderColor = Color.WHITE
        tabla_encabezadoDetalles.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezadoDetalles.WidthPercentage = (500 / 5.1F)
        tabla_encabezadoDetalles.SetWidths(New Integer() {1, 5, 5, 5})
        'tabla_encabezado.SpacingAfter = 20

        Dim tabla_sub_encabezado As New PdfPTable(3)
        tabla_sub_encabezado.DefaultCell.Padding = 3
        tabla_sub_encabezado.DefaultCell.BorderColor = Color.WHITE
        tabla_sub_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_sub_encabezado.WidthPercentage = (400 / 5.23F)
        tabla_sub_encabezado.SetWidths(New Integer() {4, 1, 2})

        Dim tabla_transportista As New PdfPTable(3)
        tabla_transportista.DefaultCell.Padding = 3
        tabla_transportista.DefaultCell.BorderColor = Color.WHITE
        tabla_transportista.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_transportista.WidthPercentage = (500 / 5.1F)
        tabla_transportista.SetWidths(New Integer() {1, 4, 1})
        tabla_transportista.SpacingAfter = 20

        Dim tabla_grilla As New PdfPTable(7)
        tabla_grilla.DefaultCell.Padding = 3
        tabla_grilla.WidthPercentage = 30
        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla.DefaultCell.BorderWidth = 1
        tabla_grilla.WidthPercentage = (480 / 5.23F)
       
        tabla_grilla.SetWidths(New Integer() {1, 3, 5, 1, 1, 1, 1})
       
        tabla_grilla.SpacingBefore = 20

        Dim tabla_encabezado2 As New PdfPTable(3)
        tabla_encabezado2.DefaultCell.Padding = 3
        tabla_encabezado2.DefaultCell.BorderColor = Color.WHITE
        tabla_encabezado2.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezado2.WidthPercentage = (500 / 5.1F)
        tabla_encabezado2.SetWidths(New Integer() {1, 4, 1})
        tabla_encabezado2.SpacingAfter = 20

        Dim tabla_transportista2 As New PdfPTable(3)
        tabla_transportista2.DefaultCell.Padding = 3
        tabla_transportista2.DefaultCell.BorderColor = Color.WHITE
        tabla_transportista2.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_transportista2.WidthPercentage = (500 / 5.1F)
        tabla_transportista2.SetWidths(New Integer() {1, 4, 1})
        tabla_transportista2.SpacingAfter = 20

        Dim tabla_grilla2 As New PdfPTable(7)
        tabla_grilla2.DefaultCell.Padding = 3
        tabla_grilla2.WidthPercentage = 30
        tabla_grilla2.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla2.DefaultCell.BorderWidth = 1
        tabla_grilla2.WidthPercentage = (480 / 5.23F)

        tabla_grilla2.SetWidths(New Integer() {1, 3, 5, 1, 1, 1, 1})

        tabla_grilla2.SpacingBefore = 20

        Dim tabla_encabezado3 As New PdfPTable(3)
        tabla_encabezado3.DefaultCell.Padding = 3
        tabla_encabezado3.DefaultCell.BorderColor = Color.WHITE
        tabla_encabezado3.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezado3.WidthPercentage = (500 / 5.1F)
        tabla_encabezado3.SetWidths(New Integer() {1, 4, 1})
        tabla_encabezado3.SpacingAfter = 20

        Dim tabla_transportista3 As New PdfPTable(3)
        tabla_transportista3.DefaultCell.Padding = 3
        tabla_transportista3.DefaultCell.BorderColor = Color.WHITE
        tabla_transportista3.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_transportista3.WidthPercentage = (500 / 5.1F)
        tabla_transportista3.SetWidths(New Integer() {1, 4, 1})
        tabla_transportista3.SpacingAfter = 20

        Dim tabla_grilla3
        If cmbSucursal.Text = "SR AGRO" Then
            tabla_grilla3 = New PdfPTable(12)
        Else
            tabla_grilla3 = New PdfPTable(11)
        End If

        tabla_grilla3.DefaultCell.Padding = 3
        tabla_grilla3.WidthPercentage = 30
        tabla_grilla3.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla3.DefaultCell.BorderWidth = 1
        tabla_grilla3.WidthPercentage = (480 / 5.23F)
        If cmbSucursal.Text = "SR AGRO" Then
            tabla_grilla3.SetWidths(New Integer() {1, 2, 2, 2, 5, 1, 1, 1, 2, 3, 2, 2})
        Else
            tabla_grilla3.SetWidths(New Integer() {1, 2, 2, 2, 5, 1, 1, 1, 2, 2, 2})
        End If

        tabla_grilla3.SpacingBefore = 20

        Dim Vendido As Date
        Dim Facturado As Date
        Dim Entregado As Date

        Dim Venta As String = ""
        Dim Ruta As String = ""

        Dim Entregador As String = ""
        Dim Vehiculo As String = ""
        Dim Peso As String = ""

        'Try
        Dim dtDatos As New DataTable
        Dim dbs As New cls_reporte_carga_valorcero
        If cmbSucursal.Text = "CONSUMO" Then
            dtDatos = dbs.DatosEntrega(folio_ini.Text & _txtDesde.Text, folio_fin.Text & _txtHasta.Text)
        ElseIf cmbSucursal.Text = "SR AGRO" Then
            dtDatos = dbs.DatosEntregaAGRO(cmbFecha.Value, folio_ini.Text & _txtDesde.Text, folio_fin.Text & _txtHasta.Text)
            If dtDatos.Rows.Count > 0 Then
            Else
                dtDatos = dbs.DatosEntregaAGRO(cmbFecha.Value, "02-001-01-" & _txtDesde.Text, "02-001-01-" & _txtHasta.Text)
            End If
        ElseIf cmbSucursal.Text = "DIMOSA" Then
            dtDatos = dbs.DatosEntregaDIMOSA(cmbFecha.Value, folio_ini.Text & _txtDesde.Text, folio_fin.Text & _txtHasta.Text)
        ElseIf cmbSucursal.Text = "OPL" Then
            dtDatos = dbs.DatosEntregaOPL(cmbFecha.Value, folio_ini.Text & _txtDesde.Text, folio_fin.Text & _txtHasta.Text)
        End If
        Ruta = dtDatos(0)(0)
        Peso = dtDatos(0)(1)
        Venta = dtDatos(0)(2)
        Vehiculo = dtDatos(0)(3)
        Entregador = dtDatos(0)(4)

        Facturado = dtDatos(0)(5)
        Vendido = DateAdd(DateInterval.Day, -1, Facturado)
        Entregado = DateAdd(DateInterval.Day, 1, Facturado)

        If Vendido.DayOfWeek = Day.Sunday Then
            Vendido = DateAdd(DateInterval.Day, -2, Facturado)
        End If

        If Entregado.DayOfWeek = Day.Sunday Then
            Entregado = DateAdd(DateInterval.Day, 2, Facturado)
        End If
        'Catch ex As Exception
        '    Facturado = Today.Date
        '    Vendido = DateAdd(DateInterval.Day, -1, Facturado)
        '    Entregado = DateAdd(DateInterval.Day, 1, Facturado)

        '    If Vendido.DayOfWeek = 7 Then
        '        Vendido = DateAdd(DateInterval.Day, -2, Facturado)
        '    End If

        '    If Entregado.DayOfWeek = 7 Then
        '        Entregado = DateAdd(DateInterval.Day, 2, Facturado)
        '    End If
        'End Try


        'Exporting to PDF
        If direccion_archivo = "" Then
            direccion_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
            'If Not Directory.Exists(direccion_archivo) Then
            '    Directory.CreateDirectory(direccion_archivo)
            'End If
        End If

        Using stream As New FileStream(direccion_archivo & "Reporte de Carga - Almacen " & cmbAlmacen.SelectedValue & " " & _txtDesde.Text & " a " & _txtHasta.Text & ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.LETTER, 10, 10, 10, 20)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory

            logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")
            If cmbSucursal.Text = "DIMOSA" Then
                logo = Image.GetInstance(recurso & "\Resources\DIMOSA-26.png")
            End If
            If cmbSucursal.Text = "SR AGRO" Then
                logo = Image.GetInstance(recurso & "\Resources\SR AGRO LOGO.jpg")
            End If
            If cmbSucursal.Text = "OPL" Then
                logo = Image.GetInstance(recurso & "\Resources\OPL.png")
            End If
            Dim pageN As String
            pageN = pdfDoc.PageNumber

            Dim ch As New Chunk("Página " & pageN)

            Dim fecha As Integer
            fecha = pdfDoc.AddCreationDate

            Dim footerText As String = "Generado por: " & _Inicio.lblUsuario.Text & " - Fecha: " & Today.Date & " Hora:" & Now.TimeOfDay.ToString.Substring(0, 8) & " - Página: " & pageN
            Dim chkFooter As New Chunk(footerText, FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK))

            Dim p2 As New Phrase(chkFooter)

            Dim footer As New HeaderFooter(p2, True)
            pdfDoc.Footer = footer


            tabla_encabezado.AddCell(logo)
            Dim cell As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL, S. DE R.L. DE C.V. " & vbCrLf & _
                            "Reporte de Carga", FontFactory.GetFont("arial", 12, Font.Bold, Color.BLACK)))
            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell(New Phrase("Página 1", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))

            tabla_sub_encabezado.AddCell(New Phrase("VENTA: " & Venta, FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("RUTA: " & Ruta, FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("VENDIDO: " & Vendido.Date & vbNewLine & "FACTURADO: " & Facturado.Date & vbNewLine & "ENTREGADO: " & Entregado.Date & vbNewLine, FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell(New Phrase(""))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Nº FACTURAS: " & _txtDesde.Text & " " & _txtHasta.Text & vbNewLine & "ENTREGADOR: " & Entregador & vbNewLine & "VEHICULO: " & Vehiculo & vbNewLine & "PESO: " & Peso, FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")

            tabla_transportista.AddCell(" ")
            Dim cell2 As New PdfPCell(New Phrase("_________________________", FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            cell2.BorderColor = Color.WHITE
            cell2.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_transportista.AddCell(cell2)
            tabla_transportista.AddCell("")
            tabla_transportista.AddCell("")
            cell2 = New PdfPCell(New Phrase("Entregador" & vbNewLine & vbNewLine, FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            cell2.BorderColor = Color.WHITE
            cell2.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_transportista.AddCell(cell2)
            tabla_transportista.AddCell("" & vbNewLine)



            tabla_transportista.AddCell(" ")
            Dim cell3 As New PdfPCell(New Phrase("CONTADO", FontFactory.GetFont("arial black", 11, Font.Bold, Color.BLACK)))
            cell3.BorderColor = Color.WHITE
            cell3.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_transportista.AddCell(cell3)
            tabla_transportista.AddCell("")


            Dim cell_sangria_titulo As New PdfPCell(New Phrase(""))
            cell_sangria_titulo.BorderColor = Color.WHITE
            tabla_grilla.AddCell(cell_sangria_titulo)

            For index As Integer = 0 To grdContado.ColumnCount - 3
                If index = grdContado.ColumnCount - 3 Then
                    Dim cell_encabezado As New PdfPCell(New Phrase(grdContado.Columns(grdContado.ColumnCount - 1).HeaderText.ToUpper, FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                    cell_encabezado.BackgroundColor = Color.GRAY
                    tabla_grilla.AddCell(cell_encabezado)
                Else
                    Dim cell_encabezado As New PdfPCell(New Phrase(grdContado.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                    cell_encabezado.BackgroundColor = Color.GRAY
                    tabla_grilla.AddCell(cell_encabezado)
                End If
            Next

            For i As Integer = 0 To grdContado.RowCount - 1
                Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                cell_sangria_contenido.BorderColor = Color.WHITE
                tabla_grilla.AddCell(cell_sangria_contenido)
                For j As Integer = 0 To grdContado.ColumnCount - 3
                    If j = grdContado.ColumnCount - 3 Then
                        tabla_grilla.AddCell(New Phrase(Convert.ToString(grdContado.Rows(i).Cells(grdContado.ColumnCount - 1).Value), FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
                    Else
                        If j = 3 Then
                            If CheckBox1.CheckState = CheckState.Checked Then
                                tabla_grilla.AddCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
                            Else
                                tabla_grilla.AddCell(New Phrase(Convert.ToString(grdContado.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
                            End If
                        Else
                            tabla_grilla.AddCell(New Phrase(Convert.ToString(grdContado.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
                        End If
                    End If

                Next
            Next

            Dim cell_sangria_contenidoFuera As New PdfPCell(New Phrase(""))
            cell_sangria_contenidoFuera.BorderColor = Color.WHITE

            tabla_grilla.AddCell(cell_sangria_contenidoFuera)

            Dim Cell_Interior As New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase("TOTALES", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase(unidadescontado.Text, FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase(pesocontado.Text, FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla.AddCell(Cell_Interior)

            If grdContado.RowCount > 0 Then
                pdfDoc.Add(tabla_encabezado)
                pdfDoc.Add(tabla_sub_encabezado)
                pdfDoc.Add(tabla_transportista)
                pdfDoc.Add(tabla_grilla)
                pdfDoc.NewPage()
            End If


            tabla_encabezado2.AddCell(logo)
            Dim cellEnc2 As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL, S.A. DE C.V. " & vbCrLf & _
                            "Reporte de Carga", FontFactory.GetFont("arial", 12, Font.Bold, Color.BLACK)))
            cellEnc2.BorderColor = Color.WHITE
            cellEnc2.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado2.AddCell(cellEnc2)
            tabla_encabezado2.AddCell(New Phrase(" ", FontFactory.GetFont("arial", 12, Font.Bold, Color.BLACK)))

            tabla_transportista2.AddCell(" ")
            Dim cell2Trans As New PdfPCell(New Phrase("_________________________", FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            cell2Trans.BorderColor = Color.WHITE
            cell2Trans.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_transportista2.AddCell(cell2Trans)
            tabla_transportista2.AddCell("")
            tabla_transportista2.AddCell("")
            cell2Trans = New PdfPCell(New Phrase("Entregador" & vbNewLine & vbNewLine, FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            cell2Trans.BorderColor = Color.WHITE
            cell2Trans.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_transportista2.AddCell(cell2Trans)
            tabla_transportista2.AddCell("" & vbNewLine)

            tabla_transportista.AddCell(" " & vbNewLine & vbNewLine)
            tabla_transportista.AddCell(" " & vbNewLine & vbNewLine)
            tabla_transportista.AddCell(" " & vbNewLine & vbNewLine)

            tabla_transportista2.AddCell(" ")
            Dim cell3Trans As New PdfPCell(New Phrase("CREDITO", FontFactory.GetFont("arial black", 11, Font.Bold, Color.BLACK)))
            cell3Trans.BorderColor = Color.WHITE
            cell3Trans.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_transportista2.AddCell(cell3Trans)
            tabla_transportista2.AddCell("")

            'Segunda Grilla
            Dim cell_sangria_titulo2 As New PdfPCell(New Phrase(""))
            cell_sangria_titulo2.BorderColor = Color.WHITE
            tabla_grilla2.AddCell(cell_sangria_titulo2)

            For index As Integer = 0 To grdCredito.ColumnCount - 3
                If index = grdCredito.ColumnCount - 3 Then
                    Dim cell_encabezado As New PdfPCell(New Phrase(grdCredito.Columns(grdContado.ColumnCount - 1).HeaderText.ToUpper, FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                    cell_encabezado.BackgroundColor = Color.GRAY
                    tabla_grilla2.AddCell(cell_encabezado)
                Else
                    Dim cell_encabezado As New PdfPCell(New Phrase(grdCredito.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                    cell_encabezado.BackgroundColor = Color.GRAY
                    tabla_grilla2.AddCell(cell_encabezado)
                End If
            Next

            For i As Integer = 0 To grdCredito.RowCount - 1
                Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                cell_sangria_contenido.BorderColor = Color.WHITE
                tabla_grilla2.AddCell(cell_sangria_contenido)
                For j As Integer = 0 To grdCredito.ColumnCount - 3
                    If j = grdCredito.ColumnCount - 3 Then
                        tabla_grilla2.AddCell(New Phrase(Convert.ToString(grdCredito.Rows(i).Cells(grdCredito.ColumnCount - 1).Value), FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
                    Else
                        If j = 3 Then
                            If CheckBox1.CheckState = CheckState.Checked Then
                                tabla_grilla2.AddCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
                            Else
                                tabla_grilla2.AddCell(New Phrase(Convert.ToString(grdCredito.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
                            End If
                        Else
                            tabla_grilla2.AddCell(New Phrase(Convert.ToString(grdCredito.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
                        End If

                    End If
                Next
            Next
            tabla_grilla2.AddCell(cell_sangria_contenidoFuera)

            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla2.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase("TOTALES", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla2.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase(unidadescredito.Text, FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla2.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla2.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase(pesocredito.Text, FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla2.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla2.AddCell(Cell_Interior)

            If grdCredito.RowCount > 0 Then
                pdfDoc.Add(tabla_encabezado2)
                pdfDoc.Add(tabla_sub_encabezado)
                pdfDoc.Add(tabla_transportista2)
                pdfDoc.Add(tabla_grilla2)

                pdfDoc.NewPage()
            End If


            tabla_encabezado3.AddCell(logo)
            Dim cellEnc3 As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL, S.A. DE C.V. " & vbCrLf & _
                            "Reporte de Carga", FontFactory.GetFont("arial", 12, Font.Bold, Color.BLACK)))
            cellEnc3.BorderColor = Color.WHITE
            cellEnc3.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado3.AddCell(cellEnc3)
            tabla_encabezado3.AddCell(New Phrase("", FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))

            tabla_encabezadoDetalles.AddCell(New Phrase(""))
            tabla_encabezadoDetalles.AddCell(New Phrase(vbNewLine & vbNewLine & vbNewLine & vbNewLine & _
                                                "Sacado por: _________" & vbNewLine & "Inicio: ______________" & vbNewLine & "Fin: ________________" & vbNewLine & vbNewLine, FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            tabla_encabezadoDetalles.AddCell(New Phrase(vbNewLine & vbNewLine & vbNewLine & vbNewLine & _
                                                "Chequeado por: ______" & vbNewLine & "Inicio: ______________" & vbNewLine & "Fin: ________________" & vbNewLine & vbNewLine, FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
            tabla_encabezadoDetalles.AddCell(New Phrase(vbNewLine & vbNewLine & vbNewLine & vbNewLine & _
                                                "Cargado por: ________" & vbNewLine & "Inicio: ______________" & vbNewLine & "Fin: ________________" & vbNewLine & vbNewLine, FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))


            tabla_transportista3.AddCell(" ")
            Dim cell4Trans As New PdfPCell(New Phrase("_________________________", FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            cell4Trans.BorderColor = Color.WHITE
            cell4Trans.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_transportista3.AddCell(cell4Trans)
            tabla_transportista3.AddCell("")
            tabla_transportista3.AddCell("")
            cell4Trans = New PdfPCell(New Phrase("Entregador" & vbNewLine & vbNewLine, FontFactory.GetFont("arial", 10, Font.Bold, Color.BLACK)))
            cell4Trans.BorderColor = Color.WHITE
            cell4Trans.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_transportista3.AddCell(cell4Trans)
            tabla_transportista3.AddCell("" & vbNewLine)

            tabla_transportista3.AddCell(" " & vbNewLine & vbNewLine)
            tabla_transportista3.AddCell(" " & vbNewLine & vbNewLine)
            tabla_transportista3.AddCell(" " & vbNewLine & vbNewLine)

            tabla_transportista3.AddCell(" ")
            Dim cell5Trans As New PdfPCell(New Phrase("BODEGA", FontFactory.GetFont("arial black", 11, Font.Bold, Color.BLACK)))
            cell5Trans.BorderColor = Color.WHITE
            cell5Trans.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_transportista3.AddCell(cell5Trans)
            tabla_transportista3.AddCell("")

            'Tercera Grilla
            Dim cell_sangria_titulo3 As New PdfPCell(New Phrase(""))
            cell_sangria_titulo3.BorderColor = Color.WHITE
            tabla_grilla3.AddCell(cell_sangria_titulo3)

            For index As Integer = 0 To grdBodega.ColumnCount - 1

                Dim cell_encabezado As New PdfPCell(New Phrase(grdBodega.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 9, Font.Bold, Color.BLACK)))
                cell_encabezado.BackgroundColor = Color.GRAY
                tabla_grilla3.AddCell(cell_encabezado)

            Next

            For i As Integer = 0 To grdBodega.RowCount - 1
                Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                cell_sangria_contenido.BorderColor = Color.WHITE
                tabla_grilla3.AddCell(cell_sangria_contenido)
                For j As Integer = 0 To grdBodega.ColumnCount - 1
                    tabla_grilla3.AddCell(New Phrase(Convert.ToString(grdBodega.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 7, Font.Bold, Color.BLACK)))
                Next
            Next
            Dim cell_sangria_contenidoX As New PdfPCell(New Phrase(""))
            cell_sangria_contenidoX.BorderColor = Color.WHITE
            tabla_grilla3.AddCell(cell_sangria_contenidoX)

            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla3.AddCell(Cell_Interior)
            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla3.AddCell(Cell_Interior)
            Cell_Interior = New PdfPCell(New Phrase("TOTALES", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla3.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase(Unidadesbodega.Text, FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla3.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla3.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla3.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla3.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase(pesobodega.Text, FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla3.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla3.AddCell(Cell_Interior)

            Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
            Cell_Interior.BackgroundColor = Color.GRAY
            tabla_grilla3.AddCell(Cell_Interior)

            If cmbSucursal.Text = "SR AGRO" Then
                Cell_Interior = New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 8, Font.Bold, Color.BLACK)))
                Cell_Interior.BackgroundColor = Color.GRAY
                tabla_grilla3.AddCell(Cell_Interior)
            End If

            pdfDoc.Add(tabla_encabezado3)
            pdfDoc.Add(tabla_encabezadoDetalles)
            pdfDoc.Add(tabla_sub_encabezado)
            pdfDoc.Add(tabla_transportista3)
            pdfDoc.Add(tabla_grilla3)

            pdfDoc.Close()
            stream.Close()

            Process.Start(direccion_archivo & "Reporte de Carga - Almacen " & cmbAlmacen.SelectedValue & " " & _txtDesde.Text & " a " & _txtHasta.Text & ".pdf")
        End Using
    End Sub

End Class