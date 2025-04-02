Imports Disar.data

Public Class FrmClientesPareto
    Dim Total As Decimal
    Dim PorcentajeCompleto As Decimal
    Dim Sumar As String
    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click

        Dim conexion_bita As New cls_bitacora_reporteador
        conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó reporte de cumpleañeros clientes pareto", "REPORTES", _
                                  "Fecha: " & DateTime.Now)

        DESC.Visible = False
        TextBox1.Visible = False

        DataTemp.DataSource = Nothing
        DataReporte.Rows.Clear()

        Dim db As New ClsClientes
        Total = 0
        PorcentajeCompleto = 0

        Try
            DataTemp.DataSource = db.Pareto(DateTimePicker1.Value, DateTimePicker2.Value)

            For Each row As DataGridViewRow In DataTemp.Rows
                Total += row.Cells("VENTAS").Value
            Next

            Dim Meta As Decimal
            Meta = Total * 0.8

            For Each row As DataGridViewRow In DataTemp.Rows
                If PorcentajeCompleto < Meta Then
                    Sumar = Math.Round(((row.Cells("VENTAS").Value / Total) * 100), 4) & "%"
                    DataReporte.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, Sumar)
                    PorcentajeCompleto += row.Cells("VENTAS").Value
                Else
                    Exit For
                End If
            Next
            TextBox1.Text = "Cumpleañeros:"
            For Each row As DataGridViewRow In DataReporte.Rows
                If Not IsDBNull(row.Cells("Cumpleaños").Value) Then
                    If Convert.ToDateTime(row.Cells("Cumpleaños").Value).Day = Today.Day And Convert.ToDateTime(row.Cells("Cumpleaños").Value).Month = Today.Month Then
                        row.DefaultCellStyle.BackColor = Color.DarkRed
                        row.DefaultCellStyle.ForeColor = Color.White
                        DESC.Visible = True
                        TextBox1.Visible = True
                        TextBox1.Text = TextBox1.Text & vbNewLine & row.Cells(0).Value
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        If DataReporte.RowCount > 0 Then
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

            wSheet.Cells.Range("A1:H1").Merge()
            wSheet.Cells.Range("A1:H1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:H1").Value = " Reporte de Clientes - [Cumpleañeros Clientes Pareto] "
            wSheet.Cells.Range("A1:H1").Style = "Estilo"

            For c As Integer = 0 To DataReporte.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = DataReporte.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Estilo"
            Next
            For r As Integer = 0 To DataReporte.RowCount - 1
                For c As Integer = 0 To DataReporte.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = DataReporte.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    'wSheet.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(DataDatos.Rows(r).DefaultCellStyle.BackColor)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        End If
    End Sub
     
    Private Sub FrmClientesPareto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DESC.Visible = False
    End Sub

End Class