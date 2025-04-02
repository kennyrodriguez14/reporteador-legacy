Imports Disar.data

Public Class FrmHorasTrabajoComercial

    Dim Tipo As String
    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub FrmHorasTrabajoComercial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboSucursal.SelectedIndex = 0
    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Dim dt As New DataTable
        Dim Tablas As New DataTable
        Dim Tablas2 As New DataTable
        Dim db As New clsComisiones
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        If ComboVendedor.Text = "TODOS" Then
            If ComboSucursal.Text = "Todos" Then
                dt = db.Vendedores("TODOS", "S")
            Else
                dt = db.Vendedores(Tipo, "S")
            End If
        Else
            dt.Columns.Add("CVE_VEND")
            dt.Columns.Add("NOMBRE")
            dt.Rows.Add(ComboVendedor.SelectedValue, ComboVendedor.Text)
        End If

        Tablas.Columns.Add("Clave")
        Tablas.Columns.Add("Nombre")
        Tablas2.Columns.Add("Clave")
        Tablas2.Columns.Add("Nombre")

        Try
            For i As Integer = 0 To dt.Rows.Count
                Tablas.Rows.Add(dt(i)("CVE_VEND"), dt(i)("NOMBRE"))
                Tablas2.Rows.Add(dt(i)("CVE_VEND"), dt(i)("NOMBRE"))
            Next
        Catch ex As Exception
        End Try

        For i As Integer = 0 To DateDiff(DateInterval.Day, DateTimePicker1.Value, DateTimePicker2.Value)
            If DateTimePicker1.Value.AddDays(i).Date.DayOfWeek <> DayOfWeek.Sunday Then
                Tablas.Columns.Add("Entrada " & DateTimePicker1.Value.AddDays(i).Date)
                Tablas.Columns.Add("Salida " & DateTimePicker1.Value.AddDays(i).Date)
                Tablas2.Columns.Add(DateTimePicker1.Value.AddDays(i).Date)
            End If
        Next

        DataDatos.DataSource = Tablas
        DataHoras.DataSource = Tablas2
        DataDatos.Columns(0).Frozen = True
        DataDatos.Columns(1).Frozen = True
        DataHoras.Columns(0).Frozen = True
        DataHoras.Columns(1).Frozen = True

        CargarDatos()

        FormatoGrid()
    End Sub

    Private Sub ComboSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSucursal.SelectedValueChanged
        If ComboSucursal.Text = "San Pedro Sula" Then
            Tipo = "SP@S"
        End If
        If ComboSucursal.Text = "Santa Rosa de Copán" Then
            Tipo = "SR@C"
        End If
        If ComboSucursal.Text = "Tocoa" Then
            Tipo = "TOC@A"
        End If
        If ComboSucursal.Text = "Tegucigalpa" Then
            Tipo = "TG@U"
        End If
        If ComboSucursal.Text = "Todos" Then
            Tipo = "TODOS"
        End If
        LlenaVendedores()
    End Sub

    Sub LlenaVendedores()
        Dim db As New clsComisiones
        Try
            ComboVendedor.DataSource = db.Vendedores(Tipo, "N")
            ComboVendedor.DisplayMember = "NOMBRE"
            ComboVendedor.ValueMember = "CVE_VEND"
        Catch ex As Exception
        End Try
    End Sub

    Sub FormatoGrid()
        With Me.DataDatos
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .RowHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Raised
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Raised
            For Each column As DataGridViewColumn In DataDatos.Columns
                If column.Index Mod 2 <> 0 Then
                    column.DividerWidth = 4
                Else
                    column.DividerWidth = 0
                End If
            Next
        End With

    End Sub

    Sub CargarDatos()
        Dim db As New clsComisiones
        Dim Tipo As String = "I"
        For Each row As DataGridViewRow In DataDatos.Rows
            Dim Vendedor As String = row.Cells(0).Value
            For Each column As DataGridViewColumn In DataDatos.Columns
                If column.Index > 1 Then
                    Dim Fecha As Date
                    If column.Index Mod 2 = 0 Then
                        Fecha = Convert.ToDateTime(column.HeaderText.Substring(8, 10))
                        Tipo = "I"
                    Else
                        Fecha = Convert.ToDateTime(column.HeaderText.Substring(7, 10))
                        Tipo = "F"
                    End If

                    Try
                        row.Cells(column.Index).Value = db.HorasTrabajadas(Fecha, Vendedor, Tipo)(0)(0)
                    Catch ex As Exception
                    End Try

                End If
            Next
        Next

        For Each row As DataGridViewRow In DataHoras.Rows
            Dim Vendedor As String = row.Cells(0).Value

            For Each column As DataGridViewColumn In DataHoras.Columns
                If column.Index > 1 Then
                    Dim Inicio As DateTime
                    Dim Final As DateTime
                    Dim a As Integer = 0
                    Try
                        Inicio = db.HorasTrabajadas(column.HeaderText, Vendedor, "I")(0)(0)
                    Catch ex As Exception
                        a = 1
                    End Try
                    Try
                        Final = db.HorasTrabajadas(column.HeaderText, Vendedor, "F")(0)(0)
                    Catch ex As Exception
                        a = 1
                    End Try
                    If a = 0 Then
                        Dim Horas As Integer = DateDiff(DateInterval.Hour, Inicio, Final)
                        row.Cells(column.Index).Value = Horas.ToString
                    Else
                        row.Cells(column.Index).Value = 0
                    End If
                End If
            Next
        Next


    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Entradas y Salidas - Comercial"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            Dim filas As Integer = 1

            wSheet.Cells.Range("A1:E1").Merge()
            wSheet.Cells.Range("A1:E1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:E1").Value = " Reporte de Entradas / Salidas Comercial [" & ComboSucursal.Text & "]"
            wSheet.Cells.Range("A1:E1").Style = "Estilo"

            filas += 1
            For c As Integer = 0 To DataDatos.Columns.Count - 1

                If c <= 1 Then
                    wSheet.Cells(filas, c + 1).value = DataDatos.Columns(c).HeaderText.ToString
                    wSheet.Cells(filas, c + 1).Style = "Estilo"
                Else
                    wSheet.Cells(filas, c + 1).value = DataDatos.Columns(c).HeaderText.ToString
                    wSheet.Cells(filas, c + 1).Style = "Estilo"
                    wSheet.Cells(filas, c + 1).NumberFormat = "dd-mm-yyyy"
                    If c > 4 Then
                        wSheet.Cells(1, c + 1).Style = "Estilo"
                    End If
                End If
            Next
            For r As Integer = 0 To DataDatos.RowCount - 1
                filas += 1
                For c As Integer = 0 To DataDatos.Columns.Count - 1
                    wSheet.Cells(filas, c + 1).value = DataDatos.Item(c, r).Value
                    wSheet.Cells(filas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(filas, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(filas, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next

            'Exporte de Horas
            filas += 3
            Dim Asse = filas
            wSheet.Cells.Range("A" & filas & ":E" & filas & "").Merge()
            wSheet.Cells.Range("A" & filas & ":E" & filas & "").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & filas & ":E" & filas & "").Value = " Horas Trabajadas Comercial - [" & ComboSucursal.Text & "]"
            wSheet.Cells.Range("A" & filas & ":E" & filas & "").Style = "Estilo"

            filas += 1
            For c As Integer = 0 To DataHoras.Columns.Count - 1

                If c <= 1 Then
                    wSheet.Cells(filas, c + 1).value = DataHoras.Columns(c).HeaderText.ToString
                    wSheet.Cells(filas, c + 1).Style = "Estilo"
                Else
                    wSheet.Cells(filas, c + 1).value = DataHoras.Columns(c).HeaderText.ToString
                    wSheet.Cells(filas, c + 1).Style = "Estilo"
                    wSheet.Cells(filas, c + 1).NumberFormat = "dd-mm-yyyy"
                    If c > 4 Then
                        wSheet.Cells(Asse, c + 1).Style = "Estilo"
                    End If
                End If
            Next
            For r As Integer = 0 To DataHoras.RowCount - 1
                filas += 1
                For c As Integer = 0 To DataHoras.Columns.Count - 1
                    wSheet.Cells(filas, c + 1).value = DataHoras.Item(c, r).Value
                    wSheet.Cells(filas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(filas, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(filas, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class