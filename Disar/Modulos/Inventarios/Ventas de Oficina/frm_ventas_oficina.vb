Imports Disar.data

Public Class frm_ventas_oficina
    Dim conexion As New cls_ventas_oficina
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

            wSheet.Cells.Range("A1:E1").Merge()
            wSheet.Cells.Range("A1:E1").Font.Bold = True
            wSheet.Cells.Range("A1:E1").Value = "Ventas de Oficina " & Now.Date
            wSheet.Cells.Range("A1:E1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:E1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            For c As Integer = 0 To grd_ventas_oficina.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grd_ventas_oficina.Columns(c).HeaderText
            Next
            For r As Integer = 0 To grd_ventas_oficina.RowCount - 1
                For c As Integer = 0 To grd_ventas_oficina.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = grd_ventas_oficina.Item(c, r).Value
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            If ComboBox1.Text = "SAN RAFAEL" Then
                grd_ventas_oficina.DataSource = conexion.Ventas_Ofi(cmbFecha_ini.Value.Date)
            Else
                grd_ventas_oficina.DataSource = conexion.Ventas_OfiDIMOSA(cmbFecha_ini.Value.Date)
            End If

        Catch ex As Exception
        End Try


    End Sub

    Private Sub frm_ventas_oficina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _Inicio.SANRAFAEL = 1 Then
            ComboBox1.Items.Add("SAN RAFAEL")
        End If
        If _Inicio.DIMOSA = 1 Then
            ComboBox1.Items.Add("DIMOSA")
        End If
        ComboBox1.SelectedIndex = 0
    End Sub
End Class