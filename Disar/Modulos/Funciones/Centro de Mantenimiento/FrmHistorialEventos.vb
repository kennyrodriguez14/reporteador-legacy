Imports Disar.data

Public Class FrmHistorialEventos

    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub FrmHistorialEventos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim db As New ClsBitacoraEventos
            DataDatos.DataSource = db.FiltraTodosEventos(FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells("ColN").Value)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub FrmHistorialEventos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
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

            wSheet.Cells.Range("A1:G1").Merge()
            wSheet.Cells.Range("A1:G1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:G1").Value = " Reporte de Eventos Programados por Vehículo " & FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells("ColN").Value
            wSheet.Cells.Range("A1:G1").Style = "Estilo"

            For c As Integer = 0 To DataDatos.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = DataDatos.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Estilo"
            Next

            For r As Integer = 0 To DataDatos.RowCount - 1
                For c As Integer = 0 To DataDatos.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = DataDatos.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        End If
    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Try
            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó historial de eventos vehiculares", "Centro de Mantenimiento", _
                                      "Fecha: " & DateTime.Now)
        Catch ex As Exception
        End Try
        Try
            Dim db As New ClsBitacoraEventos
            DataDatos.DataSource = db.FiltraTodosEventosFecha(FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells("ColN").Value, DateTimePicker1.Value, DateTimePicker2.Value)
        Catch ex As Exception
        End Try
    End Sub

End Class