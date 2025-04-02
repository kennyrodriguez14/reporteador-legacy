Imports Disar.data

Public Class frm_reporte_promociones
    Dim promo As New ClsPromociones




    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If cmbEmpresa.Text = "SAN-RAFAEL" Then
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = promo.PromocionesSanRafael(DateIni.Value.Date, Datefin.Value.Date)
        ElseIf cmbEmpresa.Text = "SR-AGRO" Then
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = promo.PromocionesSrAgro(DateIni.Value.Date, Datefin.Value.Date)
        ElseIf cmbEmpresa.Text = "DIMOSA" Then
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = promo.PromocionesDimosa(DateIni.Value.Date, Datefin.Value.Date)
        ElseIf cmbEmpresa.Text = "OPL" Then
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = promo.PromocionesOPL(DateIni.Value.Date, Datefin.Value.Date)
        End If


    End Sub

    Private Sub frm_promociones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEmpresa.SelectedText = "SAN-RAFAEL"
        '  MsgBox(cmbEmpresa.Text.ToString)
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()



            wSheet.Cells(1, 1).value = "Reporte de Promociones " & cmbEmpresa.Text
            wSheet.Range("A1:L1").Merge()
            wSheet.Range("A1:L1").Font.Size = "16"
            wSheet.Range("A1:L1").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter





            For c As Integer = 0 To DataGridView1.Columns.Count - 1

                wSheet.Cells(3, c + 1).value = DataGridView1.Columns(c).HeaderText
                wSheet.Cells(3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next
            For r As Integer = 0 To DataGridView1.RowCount - 1
                For c As Integer = 0 To DataGridView1.Columns.Count - 1
                    wSheet.Cells(r + 4, c + 1).value = DataGridView1.Item(c, r).Value
                    wSheet.Cells(r + 4, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Exportar()
    End Sub

   
End Class