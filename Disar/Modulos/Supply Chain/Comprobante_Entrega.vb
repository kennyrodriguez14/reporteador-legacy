Imports Disar.data
Public Class Comprobante_Entrega
    Dim Conexion As New cls_comprobante_entrega
    Dim dt As New DataTable
    Dim Filas As DataRow = dt.NewRow()


    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        ' Try
        Grid.DataSource = Conexion.CEntrega(_txtDesde.Text, _txtHasta.Text, cmbSucursal.SelectedItem, DateTimePicker1.Value.Date)
        Columnas()
        For i As Integer = 0 To Grid.RowCount - 1

            If i >= 1 Then
                If Grid.Rows(i).Cells(0).Value <> Grid.Rows(i - 1).Cells(0).Value Then
                    Filas("CODIGO") = " "
                    dt.Rows.Add(Filas)
                    Filas = dt.NewRow
                    Filas("DESCRIPCION") = "____________________________________________"
                    dt.Rows.Add(Filas)
                    Filas = dt.NewRow
                    Filas("CODIGO") = "."
                    Filas("DESCRIPCION") = "FIRMA RECIBIDO CLIENTE"
                    dt.Rows.Add(Filas)
                    Filas = dt.NewRow
                    Filas("CODIGO") = " "
                    dt.Rows.Add(Filas)
                    Filas = dt.NewRow
                    Filas("CODIGO") = "."
                    Filas("DESCRIPCION") = "COMPROBANTE DE ENTREGA"
                    dt.Rows.Add(Filas)
                    Filas = dt.NewRow
                    Filas("CODIGO") = "CLIENTE: "
                    Filas("DESCRIPCION") = Grid.Rows(i).Cells(0).Value
                    dt.Rows.Add(Filas)
                    Filas = dt.NewRow
                    Filas("CODIGO") = "FACTURA #: "
                    Filas("DESCRIPCION") = Grid.Rows(i).Cells(1).Value
                    dt.Rows.Add(Filas)
                    Filas = dt.NewRow
                    Filas("CODIGO") = "CODIGO"
                    Filas("DESCRIPCION") = "DESCRIPCION"
                    Filas("CANTIDAD") = "CANTIDAD"
                    Filas("TOTAL") = "TOTAL"
                    dt.Rows.Add(Filas)
                    Filas = dt.NewRow
                End If

                Filas("CODIGO") = Grid.Rows(i).Cells(2).Value
                Filas("DESCRIPCION") = Grid.Rows(i).Cells(3).Value
                Filas("CANTIDAD") = Grid.Rows(i).Cells(4).Value
                Filas("TOTAL") = Grid.Rows(i).Cells(5).Value
                dt.Rows.Add(Filas)
                Filas = dt.NewRow
            Else

                Filas("CODIGO") = "."
                Filas("DESCRIPCION") = "COMPROBANTE DE ENTREGA"
                dt.Rows.Add(Filas)
                Filas = dt.NewRow
                Filas("CODIGO") = "CLIENTE: "
                Filas("DESCRIPCION") = Grid.Rows(i).Cells(0).Value
                dt.Rows.Add(Filas)
                Filas = dt.NewRow
                Filas("CODIGO") = "FACTURA #: "
                Filas("DESCRIPCION") = Grid.Rows(i).Cells(1).Value
                dt.Rows.Add(Filas)
                Filas = dt.NewRow
                Filas("CODIGO") = "CODIGO"
                Filas("DESCRIPCION") = "DESCRIPCION"
                Filas("CANTIDAD") = "CANTIDAD"
                Filas("TOTAL") = "TOTAL"
                dt.Rows.Add(Filas)
                Filas = dt.NewRow

                Filas("CODIGO") = Grid.Rows(i).Cells(2).Value
                Filas("DESCRIPCION") = Grid.Rows(i).Cells(3).Value
                Filas("CANTIDAD") = Grid.Rows(i).Cells(4).Value
                Filas("TOTAL") = Grid.Rows(i).Cells(5).Value
                dt.Rows.Add(Filas)
                Filas = dt.NewRow
            End If
        Next
        Filas("CODIGO") = ""
        dt.Rows.Add(Filas)
        Filas = dt.NewRow
        Filas("DESCRIPCION") = "____________________________________________"
        dt.Rows.Add(Filas)
        Filas = dt.NewRow
        Filas("CODIGO") = "."
        Filas("DESCRIPCION") = "FIRMA RECIBIDO CLIENTE"
        dt.Rows.Add(Filas)
        GridFinal.DataSource = dt
        'Catch ex As Exception

        'End Try
    End Sub

    Sub Columnas()
        dt.Clear()
        dt.Columns.Clear()
        dt.Columns.Add("CODIGO")
        dt.Columns.Add("DESCRIPCION")
        dt.Columns.Add("CANTIDAD")
        dt.Columns.Add("TOTAL")
        GridFinal.DataSource = dt
    End Sub

    Private Sub Comprobante_Entrega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSucursal.SelectedItem = "SRC"
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperLetterSmall

            For r As Integer = 0 To GridFinal.RowCount - 1
                For c As Integer = 0 To GridFinal.Columns.Count - 1
                    wSheet.Cells(r + 2, c + 1).value = GridFinal.Item(c, r).Value
                    If GridFinal.Item(c, r).Value Is "." Or GridFinal.Item(c, r).Value Is "CLIENTE: " Or GridFinal.Item(c, r).Value Is "FACTURA #: " Then
                        wSheet.Cells(r + 2, 2).Font.Bold = True
                        wSheet.Cells(r + 2, 1).Font.Bold = True
                        wSheet.Cells(r + 2, 2).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                        wSheet.Cells(r + 2, 2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    End If
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True

        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        Exportar()
    End Sub
End Class