Imports Disar.data
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class frm_devoluciones_ingresadas_OPL
    Dim conexion As New cls_devoluciones
    Dim documento As String = ""
    Dim documento2 As String = ""
    Dim direccion_archivo = ""

    Private Sub frm_devoluciones_ingresadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DB As New clsSeguridad
            Dim dt As New System.Data.DataTable
            dt = DB.EnviaDevoluciones(_Inicio.lblUsuario.Text, "OPL")
            If dt(0)(0) = 1 Then
                btn_enviar_sae.Enabled = True
            Else
                btn_enviar_sae.Enabled = False
            End If
        Catch ex As Exception
        End Try
        cargar_almacen()
    End Sub

    Sub cargar_almacen()
        Try
            cmb_sucursal.DataSource = conexion.ListarAlmacenes2OPL()
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"

            cargar_folios()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar_correlativos()
        cargar()
    End Sub

    Sub cargar_correlativos()
        Try
            Dim serie As String = ""
            Dim ult_doc As Integer = 0
            documento = ""
            serie = txt_folio.Text
            ult_doc = Val(txt_factura_inicial.Text)
            Dim ceros As String = ""
            For cont As Integer = 1 To 8 - Convert.ToString(ult_doc).Length
                ceros += "0"
            Next
            documento = serie + ceros + Convert.ToString(ult_doc)
            txt_factura_inicial.Text = Convert.ToString(ult_doc)
            lbl_docini.Text = documento

            Dim serie2 As String = ""
            Dim ult_doc2 As Integer = 0
            documento2 = ""
            serie2 = txt_folio.Text
            ult_doc2 = txt_factura_final.Text
            Dim ceros2 As String = ""
            For cont As Integer = 1 To 8 - Convert.ToString(ult_doc2).Length
                ceros2 += "0"
            Next
            documento2 = serie2 + ceros2 + Convert.ToString(ult_doc2)
            txt_factura_final.Text = Convert.ToString(ult_doc2)
            lbl_docfin.Text = documento2
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Sub cargar_folios()
        Try
            Dim tabla_folio As New System.Data.DataTable
            tabla_folio = conexion.ListarfoliosOPL(cmb_sucursal.SelectedValue)
            txt_folio.Text = tabla_folio.Rows(0)(0)
        Catch ex As Exception
        End Try
    End Sub

    Sub cargar()
        Try
            grd_encabezados_contado.DataSource = conexion.lista_encabezados_devolucionesOPL(cmb_fecha_ini.Value, cmb_sucursal.SelectedValue,
                                                    "FILTRO_ALMACEN", documento, documento2, "")

            grd_reporte_carga.DataSource = conexion.lista_encabezados_devolucionesOPL(cmb_fecha_ini.Value, cmb_sucursal.SelectedValue,
                                                    "REPORTE_CARGA", documento, documento2, "")

            txt_entregador.Text = grd_encabezados_contado.Rows(0).Cells(12).Value

            If grd_encabezados_contado.RowCount > 0 Then
                btn_enviar_sae.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_reporte_carga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reporte_carga.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim style As Microsoft.Office.Interop.Excel.Style
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Reporte de Carga"

            Style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            Style.Font.Bold = True
            Style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            Style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Style.Font.Size = 11
            Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            wSheet.Cells.Range("A1:D1").Merge()
            wSheet.Cells.Range("A1:D1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:D1").Value = "Reporte de Carga de Devoluciones"
            wSheet.Cells.Range("A1:D1").Style = "Reportes"

            wSheet.Cells.Range("A2:D2").Merge()
            wSheet.Cells.Range("A2:D2").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A2:D2").Value = "Ruta: " + txt_ruta.Text
            wSheet.Cells.Range("A2:D2").Style = "Reportes"

            wSheet.Cells.Range("A3:D3").Merge()
            wSheet.Cells.Range("A3:D3").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A3:D3").Value = "Entregador: " + txt_entregador.Text
            wSheet.Cells.Range("A3:D3").Style = "Reportes"

            wSheet.Cells.Range("A4:D4").Merge()
            wSheet.Cells.Range("A4:D4").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A4:D4").Value = "Fecha Recepcion:" + Now.Date

            wSheet.Cells.Range("A5:D5").Merge()
            wSheet.Cells.Range("A5:D5").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A5:D5").Value = "Facturas: " + txt_factura_inicial.Text + " al " + txt_factura_final.Text
            wSheet.Cells.Range("A5:D5").Style = "Reportes"


            For c As Integer = 0 To grd_reporte_carga.Columns.Count - 1
                wSheet.Cells(6, c + 1).value = grd_reporte_carga.Columns(c).HeaderText
                wSheet.Cells(6, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To grd_reporte_carga.RowCount - 1
                For c As Integer = 0 To grd_reporte_carga.Columns.Count - 1
                    wSheet.Cells(r + 7, c + 1).value = grd_reporte_carga.Item(c, r).Value
                    wSheet.Cells(r + 7, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 7, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 7, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next

            wSheet.Cells.Range("A" & grd_reporte_carga.RowCount + 10 & ":B" & grd_reporte_carga.RowCount + 10).Merge()
            wSheet.Cells.Range("A" & grd_reporte_carga.RowCount + 10 & ":B" & grd_reporte_carga.RowCount + 10).Value = "Firma Almacen"

            wSheet.Cells.Range("A" & grd_reporte_carga.RowCount + 10 & ":B" & grd_reporte_carga.RowCount + 10).VerticalAlignment = _
                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A" & grd_reporte_carga.RowCount + 10 & ":B" & grd_reporte_carga.RowCount + 10).HorizontalAlignment = _
                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A" & grd_reporte_carga.RowCount + 9 & ":B" & grd_reporte_carga.RowCount + 9).Merge()
            wSheet.Cells.Range("A" & grd_reporte_carga.RowCount + 9 & ":B" & grd_reporte_carga.RowCount + 9).Value = "_________________________"

            wSheet.Cells.Range("A" & grd_reporte_carga.RowCount + 9 & ":B" & grd_reporte_carga.RowCount + 9).VerticalAlignment = _
                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A" & grd_reporte_carga.RowCount + 9 & ":B" & grd_reporte_carga.RowCount + 9).HorizontalAlignment = _
                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("C" & grd_reporte_carga.RowCount + 10 & ":D" & grd_reporte_carga.RowCount + 10).Merge()
            wSheet.Cells.Range("C" & grd_reporte_carga.RowCount + 10 & ":D" & grd_reporte_carga.RowCount + 10).Value = "Firma Entrega"
            wSheet.Cells.Range("C" & grd_reporte_carga.RowCount + 10 & ":D" & grd_reporte_carga.RowCount + 10).VerticalAlignment = _
                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("C" & grd_reporte_carga.RowCount + 10 & ":D" & grd_reporte_carga.RowCount + 10).HorizontalAlignment = _
                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("C" & grd_reporte_carga.RowCount + 9 & ":D" & grd_reporte_carga.RowCount + 9).Merge()
            wSheet.Cells.Range("C" & grd_reporte_carga.RowCount + 9 & ":D" & grd_reporte_carga.RowCount + 9).Value = "_________________________"

            wSheet.Cells.Range("C" & grd_reporte_carga.RowCount + 9 & ":D" & grd_reporte_carga.RowCount + 9).VerticalAlignment = _
                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("C" & grd_reporte_carga.RowCount + 9 & ":D" & grd_reporte_carga.RowCount + 9).HorizontalAlignment = _
                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()

            'Dim conexion_bita As New cls_bitacora_reporteador
            'conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Genero Reporte de Carga para Devolucion", "Almacen - Devoluciones", _
            '                          "Fecha: " + cmb_fecha_ini.Value + _
            '                          " Facturas: " + txt_factura_inicial.Text + " - " + txt_factura_final.Text)

        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub grd_reporte_carga_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_reporte_carga.DoubleClick
        frm_detalle_productos_OPL.Close()
        frm_detalle_productos_OPL.txt_factura_inicial.Text = documento
        frm_detalle_productos_OPL.txt_factura_final.Text = documento2
        frm_detalle_productos_OPL.txt_num_alma.Text = cmb_sucursal.SelectedValue
        frm_detalle_productos_OPL.txt_almacen.Text = cmb_sucursal.Text
        frm_detalle_productos_OPL.cmb_fecha.Value = cmb_fecha_ini.Value
        frm_detalle_productos_OPL.txt_cve_art.Text = grd_reporte_carga.CurrentRow.Cells(0).Value
        frm_detalle_productos_OPL.txt_producto.Text = grd_reporte_carga.CurrentRow.Cells(1).Value
        frm_detalle_productos_OPL.ShowDialog()
    End Sub

    Private Sub btn_enviar_sae_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar_sae.Click
        Try
            If conexion.validar_devos_enviadasOPL(cmb_sucursal.SelectedValue, cmb_fecha_ini.Value.Date _
                                               , lbl_docini.Text, lbl_docfin.Text).Rows.Count > 0 Then
                MessageBox.Show("Hay facturas que ya han sido enviadas a SAE", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim variable_error As String = ""
                Dim tabla_devos As New System.Data.DataTable
                tabla_devos = CType(grd_encabezados_contado.DataSource, System.Data.DataTable)

                variable_error = conexion.guardar_recepcion_SAE_OPL(tabla_devos, documento, documento2, cmb_fecha_ini.Value, cmb_sucursal.SelectedValue, _Inicio.lblUsuario.Text)

                If variable_error = "correcto" Then
                    MessageBox.Show("Informacion Enviada Correctamente", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim conexion_bita As New cls_bitacora_reporteador
                    conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Realizo envio a SAE - OPL", "Almacen - Devoluciones - OPL",
                                              "Fecha: " + cmb_fecha_ini.Value +
                                              " Facturas: " + txt_factura_inicial.Text + " - " + txt_factura_final.Text)
                    Me.Close()
                Else
                    MessageBox.Show(variable_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Exportar_liquidacion()
        Try
            Dim style As Microsoft.Office.Interop.Excel.Style

            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet2 As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()

            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Reporte de Liquidacion Contado"
            wSheet.PageSetup.PaperSize = XlPaperSize.xlPaperLetter

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:E1").Merge()
            wSheet.Cells.Range("A1:E1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:E1").Value = "Reporte de Liquidacion Contado"
            wSheet.Cells.Range("A1:E1").Style = "Reportes"

            wSheet.Cells.Range("A2:E2").Merge()
            wSheet.Cells.Range("A2:E2").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A2:E2").Value = "Ruta: " + txt_ruta.Text
            wSheet.Cells.Range("A2:E2").Style = "Reportes"

            wSheet.Cells.Range("A3:E3").Merge()
            wSheet.Cells.Range("A3:E3").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A3:E3").Value = "Entregador: " + txt_entregador.Text
            wSheet.Cells.Range("A3:E3").Style = "Reportes"

            wSheet.Cells.Range("A4:E4").Merge()
            wSheet.Cells.Range("A4:E4").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A4:E4").Value = "Fecha Recepcion:" + Now.Date

            wSheet.Cells.Range("A5:E5").Merge()
            wSheet.Cells.Range("A5:E5").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A5:E5").Value = "Facturas: " + txt_factura_inicial.Text + " al " + txt_factura_final.Text
            wSheet.Cells.Range("A5:E5").Style = "Reportes"

            For c As Integer = 0 To grd_liquidacion_contado.Columns.Count - 1
                wSheet.Cells(6, c + 1).value = grd_liquidacion_contado.Columns(c).HeaderText
                wSheet.Cells(6, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To grd_liquidacion_contado.RowCount - 1
                For c As Integer = 0 To grd_liquidacion_contado.Columns.Count - 1

                    If c = 3 Then
                        Dim val As Double = 0
                        If Not IsDBNull(grd_liquidacion_contado.Item(c, r).Value) Then
                            val = grd_liquidacion_contado.Item(c, r).Value
                        End If
                        wSheet.Cells(r + 7, c + 1).value = val.ToString("N2")
                    Else
                        wSheet.Cells(r + 7, c + 1).value = grd_liquidacion_contado.Item(c, r).Value
                    End If

                    wSheet.Cells(r + 7, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 7, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 7, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next

            Dim total As Double = 0

            For index As Integer = 0 To grd_liquidacion_contado.RowCount - 1
                total += grd_liquidacion_contado.Rows(index).Cells(3).Value
            Next

            Dim contado_filas As Integer = grd_liquidacion_contado.RowCount + 7

            contado_filas += 1

            wSheet.Cells(grd_liquidacion_contado.RowCount + contado_filas, 3).value = "Total Contado:"
            wSheet.Cells(grd_liquidacion_contado.RowCount + contado_filas, 3).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(grd_liquidacion_contado.RowCount + contado_filas, 3).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(grd_liquidacion_contado.RowCount + contado_filas, 3).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells(grd_liquidacion_contado.RowCount + contado_filas, 4).value = total.ToString("N2")
            wSheet.Cells(grd_liquidacion_contado.RowCount + contado_filas, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(grd_liquidacion_contado.RowCount + contado_filas, 4).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(grd_liquidacion_contado.RowCount + contado_filas, 4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            wSheet.Cells.Range("A" & grd_liquidacion_contado.RowCount + contado_filas & ":B" & grd_liquidacion_contado.RowCount + contado_filas).Merge()
            wSheet.Cells.Range("A" & grd_liquidacion_contado.RowCount + contado_filas & ":B" & grd_liquidacion_contado.RowCount + contado_filas).Value = _
                                                                                                          "_________________________"

            wSheet.Cells.Range("A" & grd_liquidacion_contado.RowCount + contado_filas & ":B" & grd_liquidacion_contado.RowCount + contado_filas).VerticalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A" & grd_liquidacion_contado.RowCount + contado_filas & ":B" & grd_liquidacion_contado.RowCount + contado_filas).HorizontalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("D" & grd_liquidacion_contado.RowCount + contado_filas & ":E" & grd_liquidacion_contado.RowCount + contado_filas).Merge()
            wSheet.Cells.Range("D" & grd_liquidacion_contado.RowCount + contado_filas & ":E" & grd_liquidacion_contado.RowCount + contado_filas).Value = _
                                                                                                        "_________________________"

            wSheet.Cells.Range("D" & grd_liquidacion_contado.RowCount + contado_filas & ":E" & grd_liquidacion_contado.RowCount + contado_filas).VerticalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("D" & grd_liquidacion_contado.RowCount + contado_filas & ":E" & grd_liquidacion_contado.RowCount + contado_filas).HorizontalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            contado_filas += 1

            wSheet.Cells.Range("A" & grd_liquidacion_contado.RowCount + contado_filas & ":B" & grd_liquidacion_contado.RowCount + contado_filas).Merge()
            wSheet.Cells.Range("A" & grd_liquidacion_contado.RowCount + contado_filas & ":B" & grd_liquidacion_contado.RowCount + contado_filas).Value = "Firma Almacen"

            wSheet.Cells.Range("A" & grd_liquidacion_contado.RowCount + contado_filas & ":B" & grd_liquidacion_contado.RowCount + contado_filas).VerticalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A" & grd_liquidacion_contado.RowCount + contado_filas & ":B" & grd_liquidacion_contado.RowCount + contado_filas).HorizontalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("D" & grd_liquidacion_contado.RowCount + contado_filas & ":E" & grd_liquidacion_contado.RowCount + contado_filas).Merge()
            wSheet.Cells.Range("D" & grd_liquidacion_contado.RowCount + contado_filas & ":E" & grd_liquidacion_contado.RowCount + contado_filas).Value = "Firma Entrega"
            wSheet.Cells.Range("D" & grd_liquidacion_contado.RowCount + contado_filas & ":E" & grd_liquidacion_contado.RowCount + contado_filas).VerticalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("D" & grd_liquidacion_contado.RowCount + contado_filas & ":E" & grd_liquidacion_contado.RowCount + contado_filas).HorizontalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Columns.AutoFit()


            'INICIO DE EXPORTACION DE CREDITO
            wSheet2 = wBook.Sheets.Add
            wSheet2.Name = "Reporte de Liquidacion Credito"
            wSheet2.PageSetup.PaperSize = XlPaperSize.xlPaperLetter

            'style2 = wSheet2.Application.ActiveWorkbook.Styles.Add("Reportes")
            'style2.Font.Bold = True
            'style2.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'style2.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            'style2.Font.Size = 11
            'style2.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            'style2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet2.Cells.Range("A1:E1").Merge()
            wSheet2.Cells.Range("A1:E1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet2.Cells.Range("A1:E1").Value = "Reporte de Liquidacion Contado"
            wSheet2.Cells.Range("A1:E1").Style = "Reportes"

            wSheet2.Cells.Range("A2:E2").Merge()
            wSheet2.Cells.Range("A2:E2").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet2.Cells.Range("A2:E2").Value = "Ruta: " + txt_ruta.Text
            wSheet2.Cells.Range("A2:E2").Style = "Reportes"

            wSheet2.Cells.Range("A3:E3").Merge()
            wSheet2.Cells.Range("A3:E3").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet2.Cells.Range("A3:E3").Value = "Entregador: " + txt_entregador.Text
            wSheet2.Cells.Range("A3:E3").Style = "Reportes"

            wSheet2.Cells.Range("A4:E4").Merge()
            wSheet2.Cells.Range("A4:E4").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet2.Cells.Range("A4:E4").Value = "Fecha Recepcion:" + Now.Date

            wSheet2.Cells.Range("A5:E5").Merge()
            wSheet2.Cells.Range("A5:E5").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet2.Cells.Range("A5:E5").Value = "Facturas: " + txt_factura_inicial.Text + " al " + txt_factura_final.Text
            wSheet2.Cells.Range("A5:E5").Style = "Reportes"

            For c As Integer = 0 To grd_liquidacion_credito.Columns.Count - 1
                wSheet2.Cells(6, c + 1).value = grd_liquidacion_credito.Columns(c).HeaderText
                wSheet2.Cells(6, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To grd_liquidacion_credito.RowCount - 1
                For c As Integer = 0 To grd_liquidacion_credito.Columns.Count - 1

                    If c = 3 Then
                        Dim val As Double = 0
                        val = grd_liquidacion_credito.Item(c, r).Value
                        wSheet2.Cells(r + 7, c + 1).value = val.ToString("N2")
                    Else
                        wSheet2.Cells(r + 7, c + 1).value = grd_liquidacion_credito.Item(c, r).Value
                    End If

                    wSheet2.Cells(r + 7, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet2.Cells(r + 7, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet2.Cells(r + 7, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next

            Dim total_credito As Double = 0

            For index As Integer = 0 To grd_liquidacion_credito.RowCount - 1
                total_credito += grd_liquidacion_credito.Rows(index).Cells(3).Value
            Next

            Dim contado_filas_credito As Integer = grd_liquidacion_credito.RowCount + 7

            contado_filas_credito += 1

            wSheet2.Cells(grd_liquidacion_credito.RowCount + contado_filas_credito, 3).value = "Total Credito:"
            wSheet2.Cells(grd_liquidacion_credito.RowCount + contado_filas_credito, 3).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet2.Cells(grd_liquidacion_credito.RowCount + contado_filas_credito, 3).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet2.Cells(grd_liquidacion_credito.RowCount + contado_filas_credito, 3).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet2.Cells(grd_liquidacion_credito.RowCount + contado_filas_credito, 4).value = total_credito.ToString("N2")
            wSheet2.Cells(grd_liquidacion_credito.RowCount + contado_filas_credito, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet2.Cells(grd_liquidacion_credito.RowCount + contado_filas_credito, 4).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet2.Cells(grd_liquidacion_credito.RowCount + contado_filas_credito, 4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            wSheet2.Cells.Range("A" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":B" & grd_liquidacion_credito.RowCount + contado_filas_credito).Merge()
            wSheet2.Cells.Range("A" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":B" & grd_liquidacion_credito.RowCount + contado_filas_credito).Value = _
                                                                                                          "_________________________"

            wSheet2.Cells.Range("A" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":B" & grd_liquidacion_credito.RowCount + contado_filas_credito).VerticalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet2.Cells.Range("A" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":B" & grd_liquidacion_credito.RowCount + contado_filas_credito).HorizontalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet2.Cells.Range("D" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":E" & grd_liquidacion_credito.RowCount + contado_filas_credito).Merge()
            wSheet2.Cells.Range("D" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":E" & grd_liquidacion_credito.RowCount + contado_filas_credito).Value = _
                                                                                                        "_________________________"

            wSheet2.Cells.Range("D" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":E" & grd_liquidacion_credito.RowCount + contado_filas_credito).VerticalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet2.Cells.Range("D" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":E" & grd_liquidacion_credito.RowCount + contado_filas_credito).HorizontalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            contado_filas += 1

            wSheet2.Cells.Range("A" & grd_liquidacion_credito.RowCount + contado_filas & ":B" & grd_liquidacion_credito.RowCount + contado_filas_credito).Merge()
            wSheet2.Cells.Range("A" & grd_liquidacion_credito.RowCount + contado_filas & ":B" & grd_liquidacion_credito.RowCount + contado_filas_credito).Value = "Firma Almacen"

            wSheet2.Cells.Range("A" & grd_liquidacion_credito.RowCount + contado_filas & ":B" & grd_liquidacion_credito.RowCount + contado_filas_credito).VerticalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet2.Cells.Range("A" & grd_liquidacion_credito.RowCount + contado_filas & ":B" & grd_liquidacion_credito.RowCount + contado_filas_credito).HorizontalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet2.Cells.Range("D" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":E" & grd_liquidacion_credito.RowCount + contado_filas_credito).Merge()
            wSheet2.Cells.Range("D" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":E" & grd_liquidacion_credito.RowCount + contado_filas_credito).Value = "Firma Entrega"
            wSheet2.Cells.Range("D" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":E" & grd_liquidacion_credito.RowCount + contado_filas_credito).VerticalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet2.Cells.Range("D" & grd_liquidacion_credito.RowCount + contado_filas_credito & ":E" & grd_liquidacion_credito.RowCount + contado_filas_credito).HorizontalAlignment = _
                                                                                            Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet2.Columns.AutoFit()
            'fin de exportacion de credito

            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            grd_liquidacion_contado.DataSource = conexion.lista_encabezados_devolucionesOPL(cmb_fecha_ini.Value, cmb_sucursal.SelectedValue,
                                                   "REPORTE_LIQUIDACION_CONTADO", documento, documento2, "")

            grd_liquidacion_credito.DataSource = conexion.lista_encabezados_devolucionesOPL(cmb_fecha_ini.Value, cmb_sucursal.SelectedValue,
                                                   "REPORTE_LIQUIDACION_CREDITO", documento, documento2, "")


            ''Inicio Documento PDF''


            FolderBrowserDialog1.Description = "Guardar Reporte"
            If FolderBrowserDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                direccion_archivo = FolderBrowserDialog1.SelectedPath + "\"
            End If

            ExportePDF()

            'Exportar_liquidacion()

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Genero Reporte de Carga para Liquidacion - OPL", "Almacen - Devoluciones - OPL",
                                      "Fecha: " + cmb_fecha_ini.Value +
                                      " Facturas: " + txt_factura_inicial.Text + " - " + txt_factura_final.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmb_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_sucursal.SelectedIndexChanged
        cargar_folios()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Sub ExportePDF()
        Dim tabla_encabezado As New PdfPTable(3)
        tabla_encabezado.DefaultCell.Padding = 3
        tabla_encabezado.DefaultCell.BorderColor = Color.WHITE
        tabla_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezado.WidthPercentage = (500 / 5.1F)
        tabla_encabezado.SetWidths(New Integer() {1, 4, 1})
        tabla_encabezado.SpacingAfter = 20

        Dim tabla_grillaContado As New PdfPTable(grd_liquidacion_contado.ColumnCount)
        tabla_grillaContado.DefaultCell.Padding = 3
        tabla_grillaContado.WidthPercentage = 30
        tabla_grillaContado.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grillaContado.DefaultCell.BorderWidth = 1
        tabla_grillaContado.WidthPercentage = (480 / 5.23F)
        tabla_grillaContado.SetWidths(New Integer() {1, 2, 1, 1, 1, 1})
        tabla_grillaContado.SpacingBefore = 20

        Dim tabla_datos_adicionales As New PdfPTable(grd_liquidacion_contado.ColumnCount)
        tabla_datos_adicionales.DefaultCell.Padding = 3
        tabla_datos_adicionales.DefaultCell.BorderColor = Color.WHITE
        tabla_datos_adicionales.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_datos_adicionales.WidthPercentage = 30
        tabla_datos_adicionales.WidthPercentage = (480 / 5.23F)
        tabla_datos_adicionales.SetWidths(New Integer() {1, 2, 1, 1, 1, 1})
        tabla_datos_adicionales.SpacingBefore = 20

        Dim tabla_fimas As New PdfPTable(2)
        tabla_fimas.DefaultCell.Padding = 3
        tabla_fimas.DefaultCell.BorderColor = Color.WHITE
        tabla_fimas.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_fimas.WidthPercentage = (300 / 5.23F)
        tabla_fimas.SetWidths(New Integer() {1, 1})
        tabla_fimas.SpacingBefore = 120

        Dim tabla_encabezado2 As New PdfPTable(3)
        tabla_encabezado2.DefaultCell.Padding = 3
        tabla_encabezado2.DefaultCell.BorderColor = Color.WHITE
        tabla_encabezado2.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_encabezado2.WidthPercentage = (500 / 5.1F)
        tabla_encabezado2.SetWidths(New Integer() {1, 4, 1})
        tabla_encabezado2.SpacingAfter = 20

        Dim tabla_grillaCredito As New PdfPTable(grd_liquidacion_credito.ColumnCount)
        tabla_grillaCredito.DefaultCell.Padding = 3
        tabla_grillaCredito.WidthPercentage = 30
        tabla_grillaCredito.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grillaCredito.DefaultCell.BorderWidth = 1
        tabla_grillaCredito.WidthPercentage = (480 / 5.23F)
        tabla_grillaCredito.SetWidths(New Integer() {1, 2, 1, 1, 1, 1})
        tabla_grillaCredito.SpacingBefore = 20

        Dim tabla_datos_adicionales2 As New PdfPTable(grd_liquidacion_credito.ColumnCount)
        tabla_datos_adicionales2.DefaultCell.Padding = 3
        tabla_datos_adicionales2.DefaultCell.BorderColor = Color.WHITE
        tabla_datos_adicionales2.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_datos_adicionales2.WidthPercentage = 30
        tabla_datos_adicionales2.WidthPercentage = (480 / 5.23F)
        tabla_datos_adicionales2.SetWidths(New Integer() {1, 2, 1, 1, 1, 1})
        tabla_datos_adicionales2.SpacingBefore = 20

        Dim tabla_fimas2 As New PdfPTable(2)
        tabla_fimas2.DefaultCell.Padding = 3
        tabla_fimas2.DefaultCell.BorderColor = Color.WHITE
        tabla_fimas2.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_fimas2.WidthPercentage = (300 / 5.23F)
        tabla_fimas2.SetWidths(New Integer() {1, 1})
        tabla_fimas2.SpacingBefore = 120

        If direccion_archivo = "" Then
            direccion_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
        End If

        Using stream As New FileStream(direccion_archivo & "REPORTE DE LIQUIDACION DE " + txt_factura_inicial.Text + " A " + txt_factura_final.Text + ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory
            logo = Image.GetInstance(recurso & "\Resources\OPL.png")
            tabla_encabezado.AddCell(logo)
            Dim cell As New PdfPCell(New Phrase("REPORTE DE LIQUIDACIÓN DE CONTADO", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell(New Phrase("Ruta: " & txt_ruta.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_encabezado.AddCell("")
            tabla_encabezado.AddCell(New Phrase("        " & vbTab & vbTab & "Entregador: " & txt_entregador.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_encabezado.AddCell("")
            tabla_encabezado.AddCell("")
            tabla_encabezado.AddCell(New Phrase("        " & vbTab & vbTab & "Fecha de Recepción: " & Now.Date, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_encabezado.AddCell("")
            tabla_encabezado.AddCell("")
            tabla_encabezado.AddCell(New Phrase("        " & vbTab & vbTab & "Facturas del: " & txt_factura_inicial.Text & " al: " & txt_factura_final.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_encabezado.AddCell("")
            tabla_encabezado.AddCell("")


            For index As Integer = 0 To grd_liquidacion_contado.ColumnCount - 1
                Dim cell_encabezado As New PdfPCell(New Phrase(grd_liquidacion_contado.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                cell_encabezado.BackgroundColor = Color.GRAY
                tabla_grillaContado.AddCell(cell_encabezado)
            Next

            Dim TotalContado As Decimal = 0
            For i As Integer = 0 To grd_liquidacion_contado.RowCount - 1
                TotalContado += grd_liquidacion_contado.Rows(i).Cells("Total").Value
                For j As Integer = 0 To grd_liquidacion_contado.ColumnCount - 1
                    tabla_grillaContado.AddCell(New Phrase(Convert.ToString(grd_liquidacion_contado.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                Next
            Next

            TotalContado = Math.Round(TotalContado, 6)

            tabla_datos_adicionales.AddCell("")
            tabla_datos_adicionales.AddCell("")
            tabla_datos_adicionales.AddCell("")
            tabla_datos_adicionales.AddCell("")
            tabla_datos_adicionales.AddCell("")
            tabla_datos_adicionales.AddCell("")
            tabla_datos_adicionales.AddCell("")
            tabla_datos_adicionales.AddCell("")
            tabla_datos_adicionales.AddCell(New Phrase("Total Contado: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_datos_adicionales.AddCell(New Phrase(TotalContado, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_datos_adicionales.AddCell("")
            tabla_datos_adicionales.AddCell("")

            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                                            Firma almacén       ")
            tabla_fimas.AddCell("                                             Firma Entrega        ")

            tabla_fimas.AddCell(New Phrase(" ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_fimas.AddCell(New Phrase(" ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_fimas.AddCell(New Phrase(" ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_fimas.AddCell(New Phrase(" ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_fimas.AddCell(New Phrase(" ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_fimas.AddCell(New Phrase(" ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_fimas.AddCell(New Phrase(" ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_fimas.AddCell(New Phrase(" ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_fimas.AddCell(New Phrase(" ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_fimas.AddCell(New Phrase(" ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))

            pdfDoc.Add(tabla_encabezado)
            pdfDoc.Add(tabla_grillaContado)
            pdfDoc.Add(tabla_datos_adicionales)
            pdfDoc.Add(tabla_fimas)

            'CRE
            tabla_encabezado2.AddCell(logo)
            Dim cell2 As New PdfPCell(New Phrase("REPORTE DE LIQUIDACIÓN DE CRÉDITO", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
            cell2.BorderColor = Color.WHITE
            cell2.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado2.AddCell(cell2)
            tabla_encabezado2.AddCell(New Phrase("Ruta: " & txt_ruta.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_encabezado2.AddCell("")
            tabla_encabezado2.AddCell(New Phrase("        " & vbTab & vbTab & "Entregador: " & txt_entregador.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_encabezado2.AddCell("")
            tabla_encabezado2.AddCell("")
            tabla_encabezado2.AddCell(New Phrase("        " & vbTab & vbTab & "Fecha de Recepción: " & Now.Date, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_encabezado2.AddCell("")
            tabla_encabezado2.AddCell("")
            tabla_encabezado2.AddCell(New Phrase("        " & vbTab & vbTab & "Facturas del: " & txt_factura_inicial.Text & " al: " & txt_factura_final.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_encabezado2.AddCell("")
            tabla_encabezado2.AddCell("")


            For index As Integer = 0 To grd_liquidacion_credito.ColumnCount - 1
                Dim cell_credito As New PdfPCell(New Phrase(grd_liquidacion_credito.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                cell_credito.BackgroundColor = Color.GRAY
                tabla_grillaCredito.AddCell(cell_credito)
            Next

            Dim TotalCredito As Decimal = 0
            For i As Integer = 0 To grd_liquidacion_credito.RowCount - 1
                TotalCredito += grd_liquidacion_credito.Rows(i).Cells("Total").Value
                For j As Integer = 0 To grd_liquidacion_credito.ColumnCount - 1
                    tabla_grillaCredito.AddCell(New Phrase(Convert.ToString(grd_liquidacion_credito.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                Next
            Next
            TotalCredito = Math.Round(TotalCredito, 6)

            tabla_datos_adicionales2.AddCell("")
            tabla_datos_adicionales2.AddCell("")
            tabla_datos_adicionales2.AddCell("")
            tabla_datos_adicionales2.AddCell("")
            tabla_datos_adicionales2.AddCell("")
            tabla_datos_adicionales2.AddCell("")
            tabla_datos_adicionales2.AddCell("")
            tabla_datos_adicionales2.AddCell("")
            tabla_datos_adicionales2.AddCell(New Phrase("Total Crédito:", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_datos_adicionales2.AddCell(New Phrase(TotalCredito, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            tabla_datos_adicionales2.AddCell("")
            tabla_datos_adicionales2.AddCell("")

            tabla_fimas2.AddCell("                    ____________________________________")
            tabla_fimas2.AddCell("                    ____________________________________")
            tabla_fimas2.AddCell("                                            Firma almacén       ")
            tabla_fimas2.AddCell("                                             Firma Entrega        ")

            pdfDoc.Add(tabla_encabezado2)
            pdfDoc.Add(tabla_grillaCredito)
            pdfDoc.Add(tabla_datos_adicionales2)
            pdfDoc.Add(tabla_fimas2)

            pdfDoc.Close()
            stream.Close()

            Process.Start(direccion_archivo & "REPORTE DE LIQUIDACION DE " + txt_factura_inicial.Text + " A " + txt_factura_final.Text + ".pdf")
        End Using

    End Sub

End Class