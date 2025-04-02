Imports Disar.data

Public Class Frm_AccidentesLaborales

    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub Frm_AccidentesLaborales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextAlmacen.Text = _Inicio.Almacen
        Try
            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Ingreso Accidentes Laborales", "REPORTES", _
                                      "Fecha: " & DateTime.Now)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Frm_RegistroDeAccidente.ShowDialog()
    End Sub

    Private Sub BtnExporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExporter.Click
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

        wSheet.Cells.Range("A1:E1").Merge()
        wSheet.Cells.Range("A1:E1").Borders.LineStyle = BorderStyle.FixedSingle
        wSheet.Cells.Range("A1:E1").Value = " Reporte de Accidentes Laborales "
        wSheet.Cells.Range("A1:E1").Style = "Estilo"

        For c As Integer = 0 To DataDatos.Columns.Count - 1
            wSheet.Cells(2, c + 1).value = DataDatos.Columns(c).HeaderText
            wSheet.Cells(2, c + 1).Style = "Estilo"
        Next
        For r As Integer = 0 To DataDatos.RowCount - 1
            For c As Integer = 0 To DataDatos.Columns.Count - 1
                wSheet.Cells(r + 3, c + 1).value = (DataDatos.Rows(r).Cells(c).Value.ToString)
                wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            Next
        Next
        wSheet.Columns.AutoFit()
        excel.Visible = True
        excel.Quit()
    End Sub

    Private Sub Cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cargar.Click
        CargaDatos()
    End Sub

    Sub CargaDatos()
        Dim db As New Cls_AccidentesLaborales
        Try
            DataDatos.DataSource = db.ObtieneRegistros(DateDeste.Value, DateHasta.Value, Val(TextAlmacen.Text))

            Dim ContadorDias As Integer = 0

            For i As Integer = 0 To DateDiff(DateInterval.Day, DateDeste.Value, DateHasta.Value)
                If DateDeste.Value.AddDays(i).Date.DayOfWeek <> DayOfWeek.Sunday Then
                    ContadorDias += 1
                End If
            Next

            TextCantidadDeAccidentes.Text = DataDatos.RowCount
            TextPorcentaje.Text = Math.Round((DataDatos.RowCount / ContadorDias), 2) * 100 & "%"
        Catch ex As Exception
        End Try
    End Sub

  
End Class