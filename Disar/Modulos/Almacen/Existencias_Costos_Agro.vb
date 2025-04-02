Imports Disar.data
Public Class Existencias_Costos_Agro
    Dim conexion As New cls_costos_existencias
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try

            grd_costos.DataSource = conexion.costos_existencias(cmb_f2.Value.Date)


        Catch ex As Exception

        End Try
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



            For c As Integer = 0 To grd_costos.Columns.Count - 1

                wSheet.Cells(2, c + 1).value = grd_costos.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next

            For r As Integer = 0 To grd_costos.RowCount - 1
                ' MsgBox("contador" & r)
                For c As Integer = 0 To grd_costos.Columns.Count - 1

                    wSheet.Cells(r + 3, c + 1).value = grd_costos.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

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