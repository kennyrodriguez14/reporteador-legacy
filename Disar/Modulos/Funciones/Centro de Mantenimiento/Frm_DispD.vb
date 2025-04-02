Imports Disar.data

Public Class Frm_DispD

    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Try
            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó reporte de disponibilidad vehicular", "Centro de Mantenimiento", _
                                      "Fecha: " & DateTime.Now)
        Catch ex As Exception
        End Try

        Dim A As Integer = 0
        Dim db As New ClsBitacoraEventos

        Dim dt As New DataTable

        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        Try
            DataDatos.Columns.Clear()
        Catch ex As Exception
        End Try
        Try
            DataDatos.Rows.Clear()
        Catch ex As Exception
        End Try

        dt = db.VehiculosActivosYNulos

        Dim Columna0 As New DataGridViewTextBoxColumn
        Columna0.Name = "ID"
        Columna0.HeaderText = "Nº"
        Columna0.Frozen = True

        Dim Columna1 As New DataGridViewTextBoxColumn
        Columna1.Name = "Vehiculo"
        Columna1.HeaderText = "Vehículo"
        Columna1.Frozen = True

        Dim Columna2 As New DataGridViewTextBoxColumn
        Columna2.Name = "Porcentaje"
        Columna2.HeaderText = "Porcentaje Disponibilidad"
        Columna2.DividerWidth = 3
        Columna2.Frozen = True

        DataDatos.Columns.Add(Columna0)
        DataDatos.Columns.Add(Columna1)
        DataDatos.Columns.Add(Columna2)

        Try
            For i As Integer = 0 To dt.Rows.Count
                DataDatos.Rows.Add(dt(i)(0), dt(i)(1), "")
            Next
        Catch ex As Exception
        End Try

        Dias()

    End Sub

    Sub Dias()

        For i As Integer = 0 To DateDiff(DateInterval.Day, DInicio.Value, Final.Value)
            If DInicio.Value.AddDays(i).Date.DayOfWeek <> DayOfWeek.Sunday Then
                DataDatos.Columns.Add(DInicio.Value.AddDays(i).Date, DInicio.Value.AddDays(i).Date)
            End If
        Next

        If Reporte.Text = "Disponibilidad Distribución" Then

            For Each row As DataGridViewRow In DataDatos.Rows
                For Each col As DataGridViewColumn In DataDatos.Columns
                    Try

                        If col.Index > 2 Then

                            If CheckEntregas.CheckState = CheckState.Checked Then
                                Dim dta As New DataTable
                                dta.Rows.Clear()

                                Dim db As New ClsBitacoraEventos
                                dta = db.DisponibilidadDistribucionConsumo(col.HeaderText, row.Cells(0).Value)
                                If dta.Rows.Count > 0 Then
                                    row.Cells(col.Index).Value = dta(0)(1)
                                End If
                            End If

                            If CheckAgro.CheckState = CheckState.Checked Then
                                Dim dtb As New DataTable
                                dtb.Rows.Clear()

                                Dim db As New ClsBitacoraEventos
                                dtb = db.DisponibilidadDistribucionAgro(col.HeaderText, row.Cells(0).Value)
                                If dtb.Rows.Count > 0 Then
                                    row.Cells(col.Index).Value = row.Cells(col.Index).Value & vbNewLine & dtb(0)(1)
                                End If
                            End If

                            If CkRemisiones.CheckState = CheckState.Checked Then
                                Dim dtc As New DataTable
                                dtc.Rows.Clear()

                                Dim db As New ClsBitacoraEventos
                                dtc = db.DisponibilidadDistribucionRemisiones(col.HeaderText, row.Cells(0).Value)
                                If dtc.Rows.Count > 0 Then
                                    row.Cells(col.Index).Value = row.Cells(col.Index).Value & vbNewLine & dtc(0)(1)
                                End If
                            End If

                            If CheckViajes.CheckState = CheckState.Checked Then
                                Dim dtd As New DataTable
                                dtd.Rows.Clear()

                                Dim db As New ClsBitacoraEventos
                                dtd = db.VMuestraTodosViajes(col.HeaderText, col.HeaderText, row.Cells(0).Value)
                                If dtd.Rows.Count > 0 Then
                                    row.Cells(col.Index).Value = row.Cells(col.Index).Value & vbNewLine & "OTROS"
                                End If
                            End If

                            If CheckCombustible.CheckState = CheckState.Checked Then
                                Dim dtcomb As New DataTable
                                dtcomb.Rows.Clear()

                                Dim db As New ClsBitacoraEventos
                                dtcomb = db.CARGACOSTOS(row.Cells(0).Value, 60, col.HeaderText, col.HeaderText)
                                If dtcomb.Rows.Count > 0 Then
                                    row.Cells(col.Index).Value = row.Cells(col.Index).Value & vbNewLine & "CARGO COMBUSTIBLE"
                                End If
                            End If


                        End If

                    Catch ex As Exception
                    End Try
                Next
            Next
            FormatoDistribucion()

        End If
        If Reporte.Text = "Disponibilidad Mecánica" Then

            For Each row As DataGridViewRow In DataDatos.Rows
                For Each col As DataGridViewColumn In DataDatos.Columns
                    Try

                        If col.Index > 2 Then

                            Dim dta As New DataTable
                            dta.Rows.Clear()

                            Dim db As New ClsBitacoraEventos
                            dta = db.ReporteMecanica(row.Cells(0).Value, col.HeaderText)

                            If dta.Rows.Count > 0 Then
                                row.Cells(col.Index).Value = dta(0)(5)
                            End If

                        End If

                    Catch ex As Exception
                    End Try
                Next
            Next
            FormatoMecanica()
        End If
   End Sub

    Private Sub Frm_DispD_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        FrmCentro_Mantenimiento.BringToFront()
        Me.Dispose()
    End Sub

    Sub FormatoDistribucion()
        If DataDatos.ColumnCount > 2 Then
            For Each row As DataGridViewRow In DataDatos.Rows
                Dim Contador As Integer = 0
                For Each column As DataGridViewColumn In DataDatos.Columns
                    If row.Cells(column.Index).Value = "" Then
                        Contador += 1
                    End If
                Next
                Contador -= 1
                If Contador > (DataDatos.ColumnCount - 3) / 2 Then
                    row.DefaultCellStyle.BackColor = Color.Khaki
                End If

                row.Cells(2).Value = Math.Round(100 - ((Contador / (DataDatos.ColumnCount - 3)) * 100), 2) & "%"
                '& "Contador: " & Contador & " Columnas" & DataDatos.ColumnCount - 3

            Next

        End If
    End Sub

    Sub FormatoMecanica()
        If DataDatos.ColumnCount > 2 Then
            For Each row As DataGridViewRow In DataDatos.Rows
                Dim Contador As Integer = 0
                For Each column As DataGridViewColumn In DataDatos.Columns
                    If row.Cells(column.Index).Value = "" Then
                        Contador += 1
                    End If
                Next
                Contador -= 1
                If Contador < (DataDatos.ColumnCount - 3) / 2 Then
                    row.DefaultCellStyle.BackColor = Color.Salmon
                End If
                row.Cells(2).Value = 100 - (Contador / (DataDatos.ColumnCount - 3)) * 100 & "%"
            Next

        End If
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        If DataDatos.RowCount > 0 Then
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            For c As Integer = 0 To DataDatos.Columns.Count - 1
                If DataDatos.Columns(c).Visible = True Then
                    If c > 1 Then
                        wSheet.Cells(2, c + 1).value = " " & DataDatos.Columns(c).HeaderText.ToString & " "
                        'wSheet.Cells(2, c + 1).NumberFormat = "dd-mm-yyyy"
                        If c > 4 Then
                            wSheet.Cells(1, c + 1).Style = "Estilo"
                        End If
                    Else
                        wSheet.Cells(2, c + 1).value = DataDatos.Columns(c).HeaderText
                    End If
                    wSheet.Cells(2, c + 1).Style = "Estilo"
                End If
            Next
            For r As Integer = 0 To DataDatos.RowCount - 1
                For c As Integer = 0 To DataDatos.Columns.Count - 1
                    If DataDatos.Columns(c).Visible = True Then
                        wSheet.Cells(r + 3, c + 1).value = DataDatos.Item(c, r).Value
                        wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                        wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                        wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        If DataDatos.Rows(r).Cells(1).Value = "" Then
                            wSheet.Cells(r + 3, 2).Value = "-"
                            wSheet.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Beige)
                            'wSheet.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(DataDatos.Rows(r).DefaultCellStyle.BackColor)
                        End If
                    End If
                Next
            Next


            wSheet.Cells.Range("A1:E1").Merge()
            wSheet.Cells.Range("A1:E1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:E1").Value = " Reporte de Disponibilidad de Vehículos "
            wSheet.Cells.Range("A1:E1").Style = "Estilo"

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        End If
    End Sub
 
End Class