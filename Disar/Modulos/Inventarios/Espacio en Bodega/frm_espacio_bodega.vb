Imports Disar.data

Public Class frm_espacio_bodega

    Dim conexion As New clsInventarios
    Dim style, style2 As Microsoft.Office.Interop.Excel.Style

    Private Sub frm_espacio_bodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSucursal.SelectedItem = "SRC"
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        'Try
        '    Dim conexion_bita As New cls_bitacora_reporteador
        '    conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó reporte de espacios de almacén", "REPORTES", _
        '                              "Fecha: " & DateTime.Now)
        'Catch ex As Exception
        'End Try
        Try

            grd_general.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            grd_detallado.Columns.Clear()
            grd_general.Columns.Clear()

            grd_detallado.DataSource = conexion.Espacio_en_bodega(cmbSucursal.SelectedItem, cmbFecha.Value.Date)
            grd_general.DataSource = conexion.Espacio_en_bodega(cmbSucursal.SelectedItem + "_DET", cmbFecha.Value.Date)

            calcular_totales()
            AgregaDatosExtra1()

            For i = 0 To grd_detallado.Columns.Count - 1
                grd_detallado.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
            Next i

            Calcular_TotalesVolumen()
        Catch ex As Exception
            MessageBox.Show("Error " + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            'grd_detallado.Columns(3).Visible = False
            grd_detallado.Columns(4).Visible = False
            grd_detallado.Columns(5).Visible = False
            grd_detallado.Columns(6).Visible = False
            grd_detallado.Columns(7).Visible = False
            grd_detallado.Columns(8).Visible = False

            grd_detallado.Columns(11).Visible = False

            grd_detallado.Columns(1).DividerWidth = 3
            grd_detallado.Columns(3).DividerWidth = 3
        Catch ex As Exception

        End Try
    End Sub

    Sub calcular_totales()
        Try
            Dim cap As Double = 0
            Dim ocupado As Double = 0
            Dim disponible As Double = 0

            For i As Integer = 0 To grd_detallado.RowCount - 1
                If Not IsDBNull(grd_detallado.Rows(i).Cells("Capacidad").Value) Then
                    cap += grd_detallado.Rows(i).Cells("Capacidad").Value
                End If
                If Not IsDBNull(grd_detallado.Rows(i).Cells("Ocupado").Value) Then
                    ocupado += grd_detallado.Rows(i).Cells("Ocupado").Value
                End If
                If Not IsDBNull(grd_detallado.Rows(i).Cells("Disponible").Value) Then
                    disponible += grd_detallado.Rows(i).Cells("Disponible").Value
                End If

                If grd_detallado.Rows(i).Cells("Disponible").Value < 0 Then
                    grd_detallado.Rows(i).DefaultCellStyle.BackColor = Color.DarkRed
                    grd_detallado.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If

            Next

            lbltotaltarimas.Text = cap
            lbltotalocupado.Text = ocupado
            lbltotaldisponible.Text = disponible
            lblpordisponible.Text = FormatPercent(disponible / cap)
            lblporocupado.Text = FormatPercent(ocupado / cap)
            LbVolumen.Text = 0
            lblVolDisp.Text = 0
            lblVolOcup.Text = 0
            lblVolPorDisp.Text = 0
            lblVolPorOc.Text = 0
        Catch ex As Exception

        End Try
    End Sub

    Sub Calcular_TotalesVolumen()
        Dim Vol As Decimal = Val(lbltotaltarimas.Text) * 1.56
        Dim VolDisp As Decimal = 0
        Dim VolOc As Decimal = 0

        For Each row As DataGridViewRow In grd_detallado.Rows
            If Not IsDBNull(row.Cells("ColExt2").Value) Then
                VolOc += Val(row.Cells("ColExt2").Value)
            End If
        Next
        VolDisp = Vol - VolOc

        LbVolumen.Text = Vol
        lblVolDisp.Text = Math.Round(VolDisp, 2)
        lblVolOcup.Text = Math.Round(VolOc, 2)
        lblVolPorDisp.Text = FormatPercent(VolDisp / Vol)
        lblVolPorOc.Text = FormatPercent(VolOc / Vol)

    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet, wSheet2 As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Size = 11
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            style2 = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes2")
            style2.Font.Bold = True
            style2.Font.Size = 11

            Dim cap As Double = 0
            Dim ocupado As Double = 0
            Dim disponible As Double = 0

            For i As Integer = 0 To grd_detallado.RowCount - 1
                If Not IsDBNull(grd_detallado.Rows(i).Cells(2).Value) Then
                    cap += grd_detallado.Rows(i).Cells(2).Value
                End If
                If Not IsDBNull(grd_detallado.Rows(i).Cells(4).Value) Then
                    ocupado += grd_detallado.Rows(i).Cells(4).Value
                End If
                If Not IsDBNull(grd_detallado.Rows(i).Cells(5).Value) Then
                    disponible += grd_detallado.Rows(i).Cells(5).Value
                End If
            Next



            If grd_detallado.RowCount <= 0 Then
            Else
                wSheet2 = wBook.Sheets.Add()
                wSheet2.Name = "Detallado"

                wSheet2.Cells(1, 1).value = "Total de Tarimas: "
                wSheet2.Cells(1, 1).Style = "Reportes2"
                wSheet2.Cells(1, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(1, 2).value = lbltotaltarimas.Text
                wSheet2.Cells(1, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                wSheet2.Cells(2, 1).value = "Total Utilizado: "
                wSheet2.Cells(2, 1).Style = "Reportes2"
                wSheet2.Cells(2, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(2, 2).value = lbltotalocupado.Text
                wSheet2.Cells(2, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                wSheet2.Cells(3, 1).value = "Total Disponible: "
                wSheet2.Cells(3, 1).Style = "Reportes2"
                wSheet2.Cells(3, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(3, 2).value = lbltotaldisponible.Text
                wSheet2.Cells(3, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                Try
                    wSheet2.Cells(4, 1).value = "Porcentaje Utilizado: "
                    wSheet2.Cells(4, 1).Style = "Reportes2"
                    wSheet2.Cells(4, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet2.Cells(4, 2).value = lblporocupado.Text
                    wSheet2.Cells(4, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                    wSheet2.Cells(5, 1).value = "Porcentaje Disponible: "
                    wSheet2.Cells(5, 1).Style = "Reportes2"
                    wSheet2.Cells(5, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet2.Cells(5, 2).value = lblpordisponible.Text
                    wSheet2.Cells(5, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                Catch ex As Exception

                End Try

                For c As Integer = 0 To grd_general.Columns.Count - 1
                    wSheet2.Cells(8, c + 1).value = grd_general.Columns(c).HeaderText
                    wSheet2.Cells(8, c + 1).Style = "Reportes"
                Next
                For r As Integer = 0 To grd_general.RowCount - 1
                    For c As Integer = 0 To grd_general.Columns.Count - 1
                        wSheet2.Cells(r + 9, c + 1).value = grd_general.Item(c, r).Value
                        wSheet2.Cells(r + 9, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    Next
                Next
                wSheet2.Columns.AutoFit()
            End If

            If grd_general.RowCount <= 0 Then
            Else
                wSheet = wBook.Sheets.Add()
                wSheet.Name = "Consolidado"


                For c As Integer = 0 To grd_detallado.Columns.Count - 1
                    If grd_detallado.Columns(c).Visible = True Or c = 0 Then
                        wSheet.Cells(8, c + 1).value = grd_detallado.Columns(c).HeaderText
                        wSheet.Cells(8, c + 1).Style = "Reportes"
                    End If
                Next
                For r As Integer = 0 To grd_detallado.RowCount - 1
                    For c As Integer = 0 To grd_detallado.Columns.Count - 1
                        If grd_detallado.Columns(c).Visible = True Or c = 0 Then
                            wSheet.Cells(r + 9, c + 1).value = grd_detallado.Item(c, r).Value
                            wSheet.Cells(r + 9, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                        End If
                    Next
                Next

                wSheet.Range("I1").EntireColumn.Delete()
                wSheet.Range("H1").EntireColumn.Delete()
                wSheet.Range("G1").EntireColumn.Delete()
                wSheet.Range("F1").EntireColumn.Delete()
                wSheet.Range("E1").EntireColumn.Delete()

                wSheet.Cells(1, 1).value = "Total de Tarimas: "
                wSheet.Cells(1, 1).Style = "Reportes2"
                wSheet.Cells(1, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(1, 2).value = lbltotaltarimas.Text
                wSheet.Cells(1, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                wSheet.Cells(2, 1).value = "Total Utilizado: "
                wSheet.Cells(2, 1).Style = "Reportes2"
                wSheet.Cells(2, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, 2).value = lbltotalocupado.Text
                wSheet.Cells(2, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                wSheet.Cells(3, 1).value = "Total Disponible: "
                wSheet.Cells(3, 1).Style = "Reportes2"
                wSheet.Cells(3, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(3, 2).value = lbltotaldisponible.Text
                wSheet.Cells(3, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                Try
                    wSheet.Cells(4, 1).value = "Porcentaje Utilizado: "
                    wSheet.Cells(4, 1).Style = "Reportes2"
                    wSheet.Cells(4, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(4, 2).value = lblporocupado.Text
                    wSheet.Cells(4, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                    wSheet.Cells(5, 1).value = "Porcentaje Disponible: "
                    wSheet.Cells(5, 1).Style = "Reportes2"
                    wSheet.Cells(5, 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(5, 2).value = lblpordisponible.Text
                    wSheet.Cells(5, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                Catch ex As Exception

                End Try



                wSheet.Cells(1, 4).value = "Volumen Total: "
                wSheet.Cells(1, 4).Style = "Reportes2"
                wSheet.Cells(1, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(1, 5).value = LbVolumen.Text
                wSheet.Cells(1, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                wSheet.Cells(2, 4).value = "Volumen Ocupado: "
                wSheet.Cells(2, 4).Style = "Reportes2"
                wSheet.Cells(2, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, 5).value = lblVolOcup.Text
                wSheet.Cells(2, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                wSheet.Cells(3, 4).value = "Volumen Disponible: "
                wSheet.Cells(3, 4).Style = "Reportes2"
                wSheet.Cells(3, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(3, 5).value = lblVolDisp.Text
                wSheet.Cells(3, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                wSheet.Cells(4, 4).value = "Porcentaje Utilizado: "
                wSheet.Cells(4, 4).Style = "Reportes2"
                wSheet.Cells(4, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(4, 5).value = lblVolPorOc.Text
                wSheet.Cells(4, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                wSheet.Cells(5, 4).value = "Porcentaje Disponible: "
                wSheet.Cells(5, 4).Style = "Reportes2"
                wSheet.Cells(5, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(5, 5).value = lblVolPorDisp.Text
                wSheet.Cells(5, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                wSheet.Cells.Range("C7:D7").Merge()
                wSheet.Cells.Range("C7:D7").Borders.LineStyle = BorderStyle.FixedSingle
                wSheet.Cells.Range("C7:D7").Value = "TARIMAJE"
                wSheet.Cells.Range("C7:D7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                wSheet.Cells.Range("E7:F7").Merge()
                wSheet.Cells.Range("E7:F7").Borders.LineStyle = BorderStyle.FixedSingle
                wSheet.Cells.Range("E7:F7").Value = "VOLUMEN"
                wSheet.Cells.Range("E7:F7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                wSheet.Columns.AutoFit()
            End If
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Exportar()
    End Sub

    Private Sub grd_detallado_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_detallado.Sorted
        For i As Integer = 0 To grd_detallado.RowCount - 1
            If grd_detallado.Rows(i).Cells("Disponible").Value < 0 Then
                grd_detallado.Rows(i).DefaultCellStyle.BackColor = Color.DarkRed
                grd_detallado.Rows(i).DefaultCellStyle.ForeColor = Color.White
            End If
        Next
    End Sub

    Sub AgregaDatosExtra1()

        grd_detallado.Columns(0).Visible = False
        Dim ColumnaExt1 As New DataGridViewTextBoxColumn
        ColumnaExt1.Name = "ColExt1"
        ColumnaExt1.HeaderText = "Capacidad Volumen"
        ColumnaExt1.DataPropertyName = "ColExt1"
        grd_detallado.Columns.Add(ColumnaExt1)

        Dim ColumnaExt2 As New DataGridViewTextBoxColumn
        ColumnaExt2.Name = "ColExt2"
        ColumnaExt2.HeaderText = "Volumen Ocupado"
        ColumnaExt2.DataPropertyName = "ColExt2"

        Dim ColumnaExt3 As New DataGridViewTextBoxColumn
        ColumnaExt3.Name = "ColExt3"
        ColumnaExt3.HeaderText = "% Volumen Ocupado"
        ColumnaExt3.DataPropertyName = "ColExt3"

        Dim ColumnaExt4 As New DataGridViewTextBoxColumn
        ColumnaExt4.Name = "ColExt4"
        ColumnaExt4.HeaderText = "% Disponible"
        ColumnaExt4.DataPropertyName = "ColExt4"

        grd_detallado.Columns.Add(ColumnaExt2)
        grd_detallado.Columns.Add(ColumnaExt3)
        grd_detallado.Columns.Add(ColumnaExt4)

        For Each row As DataGridViewRow In grd_detallado.Rows
            row.Cells("ColExt1").Value = row.Cells("Capacidad").Value * 1.56

            For Each row2 As DataGridViewRow In grd_general.Rows
                If row.Cells(0).Value = row2.Cells(0).Value Then
                    row.Cells("ColExt2").Value += row2.Cells("Volumen Total").Value
                End If
                If row.Cells(0).Value = "TAR" Or row.Cells(0).Value = "ARC" Then
                    row.Cells("ColExt2").Value = row.Cells("ColExt1").Value
                End If
            Next
            row.Cells("ColExt3").Value = (row.Cells("ColExt2").Value / row.Cells("ColExt1").Value) * 100
            row.Cells("ColExt4").Value = 100 - (row.Cells("ColExt3").Value)

            row.Cells("ColExt1").Value = Math.Round(row.Cells("ColExt1").Value, 2)
            row.Cells("ColExt2").Value = Math.Round(row.Cells("ColExt2").Value, 2)
            row.Cells("ColExt3").Value = Math.Round(row.Cells("ColExt3").Value, 2)
            row.Cells("ColExt4").Value = Math.Round(row.Cells("ColExt4").Value, 2)

        Next

    End Sub

    Private Sub BtnConfigurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConfigurar.Click
        If FrmConfigPaletizado.Visible = True Then
            FrmConfigPaletizado.BringToFront()
        Else
            FrmConfigPaletizado.MdiParent = _Inicio
            FrmConfigPaletizado.Show()
        End If
    End Sub

End Class