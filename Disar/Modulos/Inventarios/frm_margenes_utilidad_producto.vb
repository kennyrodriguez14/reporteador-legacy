Imports Disar.data
Public Class frm_margenes_utilidad_producto
    Dim conexion As New clsInventarios
    Private Sub frm_margenes_utilidad_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmbEmpresa.Items.Clear()
            If _Inicio.SANRAFAEL = 1 Then
                cmbEmpresa.Items.Add("CONSUMO")
            End If
            If _Inicio.DIMOSA = 1 Then
                cmbEmpresa.Items.Add("DIMOSA")
            End If
        Catch ex As Exception

        End Try
        cmbEmpresa.SelectedIndex = 0
    End Sub

    Sub cargar()
        Try
            grd_margenes.DataSource = conexion.utilidad_por_producto(cmbEmpresa.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet
            wSheet.Cells.Range("A1:M1").Merge()
            wSheet.Cells.Range("A1:M1").Value = " Margenes de Utilidad por Producto "
            wSheet.Cells.Range("A1:M1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("A1:M1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:M1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:M1").Font.Bold = True

            For c As Integer = 0 To grd_margenes.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grd_margenes.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next
            For r As Integer = 0 To grd_margenes.RowCount - 1
                For c As Integer = 0 To grd_margenes.Columns.Count - 1
                    If c = 1 Then
                        wSheet.Cells(r + 3, c + 1).value = "'" + grd_margenes.Item(c, r).Value
                        wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    Else
                        wSheet.Cells(r + 3, c + 1).value = grd_margenes.Item(c, r).Value
                        wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    End If
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Exportar()
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        cargar()
    End Sub
End Class