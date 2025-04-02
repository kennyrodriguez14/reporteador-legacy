Imports Disar.data

Public Class frm_resumen_nc_dv
    Dim conexion As New cls_descuentos_tacticos
    Private Sub frm_nc_por_desc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_empresa()
        cargar_almacen()
        cargar_entre()
    End Sub

    Sub cargar_almacen()
        Try
            cmb_almacen.DataSource = conexion.reporte_nc_por_descuento_almacen("ALMACEN", cmb_empresa.SelectedValue)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"
        Catch ex As Exception

        End Try
    End Sub

    Sub cargar_empresa()
        cmb_empresa.DataSource = conexion.reporte_nc_por_descuento_empresa("EMPRESA")
        cmb_empresa.ValueMember = "CODIGO"
        cmb_empresa.DisplayMember = "EMPRESA"
    End Sub

    Sub exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            Dim style As Microsoft.Office.Interop.Excel.Style
            style = wSheet.Application.ActiveWorkbook.Styles.Add("NewStyle")
            style.Font.Bold = True
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:K1").Merge()
            wSheet.Cells.Range("A1:K1").Value = "Distribuidora San Rafael, S. de R. L. de C. V. (SAN RAFAEL)"
            wSheet.Cells.Range("A1:K1").Style = "NewStyle"
            'wSheet.Cells.Range("A1:I1").Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("A2:K2").Merge()
            wSheet.Cells.Range("A2:K2").Value = "Telefono: 2509-0007"
            wSheet.Cells.Range("A2:K2").Style = "NewStyle"
            'wSheet.Cells.Range("A2:I2").Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("A3:K3").Merge()
            wSheet.Cells.Range("A3:K3").Value = "info@sanrafaelhn.com"
            wSheet.Cells.Range("A3:K3").Style = "NewStyle"
            'wSheet.Cells.Range("A3:I3").Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("A4:K4").Merge()
            wSheet.Cells.Range("A4:K4").Value = "RTN: 05019017934322"
            wSheet.Cells.Range("A4:K4").Style = "NewStyle"
            'wSheet.Cells.Range("A4:I4").Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("A5:K5").Merge()
            wSheet.Cells.Range("A5:K5").Value = "Resumen Devoluciones/Notas de Credito fecha: " + cmb_fecha.Value.Date
            wSheet.Cells.Range("A5:K5").Style = "NewStyle"
            'wSheet.Cells.Range("A5:I5").Borders.LineStyle = BorderStyle.FixedSingle

            For c As Integer = 0 To grd_lista.Columns.Count - 1
                wSheet.Cells(7, c + 1).value = grd_lista.Columns(c).HeaderText
                wSheet.Cells(7, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                wSheet.Cells(7, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(7, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(7, c + 1).Font.Bold = True
                wSheet.Cells(7, c + 1).Font.Size = 11
            Next

            Dim indice_filas As Integer = 0
            indice_filas += 8
            Dim subtotal As Double = 0, isv As Double = 0, total As Double = 0

            For r As Integer = 0 To grd_lista.RowCount - 1
                If r > 0 Then
                    If grd_lista.Rows(r).Cells(9).Value <> grd_lista.Rows(r - 1).Cells(9).Value Then

                        wSheet.Cells.Range("A" + (r + indice_filas).ToString + ":F" + (r + indice_filas).ToString).Merge()
                        wSheet.Cells.Range("A" + (r + indice_filas).ToString + ":F" + (r + indice_filas).ToString).Value = "TOTAL NOTAS DE CREDITO DEL DIA " + cmb_fecha.Value.Date
                        wSheet.Cells.Range("A" + (r + indice_filas).ToString + ":F" + (r + indice_filas).ToString).Style = "NewStyle"
                        wSheet.Cells.Range("A" + (r + indice_filas).ToString + ":F" + (r + indice_filas).ToString).Borders.LineStyle = BorderStyle.FixedSingle

                        wSheet.Cells.Range("G" + (r + indice_filas).ToString).Merge()
                        wSheet.Cells.Range("G" + (r + indice_filas).ToString).Value = subtotal.ToString("N2")
                        wSheet.Cells.Range("G" + (r + indice_filas).ToString).Style = "NewStyle"
                        wSheet.Cells.Range("G" + (r + indice_filas).ToString).Borders.LineStyle = BorderStyle.FixedSingle

                        wSheet.Cells.Range("H" + (r + indice_filas).ToString).Merge()
                        wSheet.Cells.Range("H" + (r + indice_filas).ToString).Value = isv.ToString("N2")
                        wSheet.Cells.Range("H" + (r + indice_filas).ToString).Style = "NewStyle"
                        wSheet.Cells.Range("H" + (r + indice_filas).ToString).Borders.LineStyle = BorderStyle.FixedSingle

                        wSheet.Cells.Range("I" + (r + indice_filas).ToString).Merge()
                        wSheet.Cells.Range("I" + (r + indice_filas).ToString).Value = total.ToString("N2")
                        wSheet.Cells.Range("I" + (r + indice_filas).ToString).Style = "NewStyle"
                        wSheet.Cells.Range("I" + (r + indice_filas).ToString).Borders.LineStyle = BorderStyle.FixedSingle

                        'For c As Integer = 0 To grd_lista.Columns.Count - 1
                        '    wSheet.Cells(r + indice_filas, c + 1).value = ""
                        '    wSheet.Cells(r + indice_filas, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                        'Next
                        indice_filas += 1
                        subtotal = 0
                        isv = 0
                        total = 0

                        For c As Integer = 0 To grd_lista.Columns.Count - 1
                            wSheet.Cells(r + indice_filas, c + 1).value = ""
                        Next
                        indice_filas += 1

                        For c As Integer = 0 To grd_lista.Columns.Count - 1
                            wSheet.Cells(r + indice_filas, c + 1).value = grd_lista.Columns(c).HeaderText
                            wSheet.Cells(r + indice_filas, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                            wSheet.Cells(r + indice_filas, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                            wSheet.Cells(r + indice_filas, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                            wSheet.Cells(r + indice_filas, c + 1).Font.Bold = True
                            wSheet.Cells(r + indice_filas, c + 1).Font.Size = 11
                        Next
                        indice_filas += 1

                        For c As Integer = 0 To grd_lista.Columns.Count - 1
                            wSheet.Cells(r + indice_filas, c + 1).value = grd_lista.Item(c, r).Value
                            wSheet.Cells(r + indice_filas, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                        Next
                    Else
                        For c As Integer = 0 To grd_lista.Columns.Count - 1
                            wSheet.Cells(r + indice_filas, c + 1).value = grd_lista.Item(c, r).Value
                            wSheet.Cells(r + indice_filas, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                        Next
                    End If
                Else
                    For c As Integer = 0 To grd_lista.Columns.Count - 1
                        wSheet.Cells(r + indice_filas, c + 1).value = grd_lista.Item(c, r).Value
                        wSheet.Cells(r + indice_filas, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                    Next
                End If

                subtotal += grd_lista.Rows(r).Cells("Sub Total").Value
                isv += grd_lista.Rows(r).Cells("Impuesto").Value
                total += grd_lista.Rows(r).Cells("Total NC").Value
            Next
            Dim indice As Integer = 0

            indice = grd_lista.RowCount + indice_filas
            wSheet.Cells.Range("A" + indice.ToString + ":F" + indice.ToString).Merge()
            wSheet.Cells.Range("A" + indice.ToString + ":F" + indice.ToString).Value = "TOTAL NOTAS DE CREDITO DEL DIA " + cmb_fecha.Value.Date
            wSheet.Cells.Range("A" + indice.ToString + ":F" + indice.ToString).Style = "NewStyle"
            wSheet.Cells.Range("A" + indice.ToString + ":F" + indice.ToString).Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("G" + indice.ToString).Merge()
            wSheet.Cells.Range("G" + indice.ToString).Value = subtotal.ToString("N2")
            wSheet.Cells.Range("G" + indice.ToString).Style = "NewStyle"
            wSheet.Cells.Range("G" + indice.ToString).Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("H" + indice.ToString).Merge()
            wSheet.Cells.Range("H" + indice.ToString).Value = isv.ToString("N2")
            wSheet.Cells.Range("H" + indice.ToString).Style = "NewStyle"
            wSheet.Cells.Range("H" + indice.ToString).Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Cells.Range("I" + indice.ToString).Merge()
            wSheet.Cells.Range("I" + indice.ToString).Value = total.ToString("N2")
            wSheet.Cells.Range("I" + indice.ToString).Style = "NewStyle"
            wSheet.Cells.Range("I" + indice.ToString).Borders.LineStyle = BorderStyle.FixedSingle

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            grd_lista.DataSource = conexion.resumen_nc_dv(cmb_fecha.Value, cmb_fecha.Value, cmb_almacen.SelectedValue, cmb_empresa.SelectedValue, cmb_entregador.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        exportar()
    End Sub

    Private Sub cmb_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectedIndexChanged
        cargar_almacen()
    End Sub

    Private Sub cmb_almacen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_almacen.SelectedIndexChanged
        cargar_entre()
    End Sub

    Sub cargar_entre()
        Try
            Dim db As New ClsEfectividad
            cmb_entregador.DataSource = db.Entregadores(cmb_almacen.SelectedValue, cmb_empresa.Text)
            cmb_entregador.ValueMember = "EntregadorCodigo"
            cmb_entregador.DisplayMember = "EntregadorNombre"
        Catch ex As Exception
        End Try
    End Sub
End Class