Imports Disar.data
Public Class Saldos
    Dim Conexion As New cls_antiguedad_saldos
    Dim ds = New System.Data.DataSet

    Private Sub Saldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _Inicio.SANRAFAEL = 1 Then
            ComboEmpresa.Items.Add("SAN RAFAEL")
        End If
        If _Inicio.DIMOSA = 1 Then
            ComboEmpresa.Items.Add("DIMOSA")
        End If
        If _Inicio.AGRO = 1 Then
            ComboEmpresa.Items.Add("SR AGRO")
        End If

        Try
            cmbSucursal.DataSource = Conexion.llenar_combo_box(Now.Date, "LLENAR_COMBO_BOX")
            cmbSucursal.ValueMember = "ID"
            cmbSucursal.DisplayMember = "SUCURSAL"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'cmbSucursal.SelectedItem = "CONSUMO"
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            'GridSaldos.DataSource = Conexion.Saldos(f1.Value.Date, cmbSucursal.SelectedItem)
            grilla.DataSource = Nothing
            grilla.Refresh()
            If ComboEmpresa.Text = "SAN RAFAEL" Then
                ds = Conexion.Saldos_desglose(f1.Value.Date, cmbSucursal.Text)
            ElseIf ComboEmpresa.Text = "DIMOSA" Then
                ds = Conexion.Saldos_desglose_DIMOSA(f1.Value.Date, cmbSucursal.Text)
            Else
                ds = Conexion.Saldos_desglose_AGRO(f1.Value.Date, cmbSucursal.Text)
            End If

            grilla.DataSource = ds.Tables("A")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim tabla = New DataTable
            tabla = ds.Tables("A")

            Dim tabla2 = New DataTable
            tabla2 = ds.Tables("B")

            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet2 As Microsoft.Office.Interop.Excel.Worksheet

            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Detalle"
            'Dim hasta As Integer = tabla.Columns.Count - 1
            wSheet.Cells.Range("A1:F1").MergeCells = True

            If cmbSucursal.Text = "CARTERA INCOBRABLE" Then
                wSheet.Cells.Range("A1:F1").Value = "CARTERA INCOBRABLE DETALLADA AL " + f1.Value.Date()
            Else
                wSheet.Cells.Range("A1:F1").Value = "ANTIGUEDAD DETALLADA DE SALDOS AL " + f1.Value.Date()
            End If

            wSheet.Cells.Range("A1:F1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:F1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A1:F1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:F1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:F1").Font.Bold = True

            For c As Integer = 0 To tabla2.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = "'" + tabla2.Columns(c).ToString
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(2, c + 1).Font.Bold = True
            Next
            For r As Integer = 0 To tabla2.Rows.Count - 1
                For c As Integer = 0 To tabla2.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = tabla2.Rows(r)(c)
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()


            'wBook.Sheets.Add(wSheet2)
            wSheet2 = wBook.Sheets.Add()
            wSheet2.Name = "General"
            'Dim hasta As Integer = tabla.Columns.Count - 1
            wSheet2.Cells.Range("A1:O1").MergeCells = True

            If cmbSucursal.Text = "CARTERA INCOBRABLE" Then
                wSheet2.Cells.Range("A1:O1").Value = "CARTERA INCOBRABLE AL " + f1.Value.Date()
            Else
                wSheet2.Cells.Range("A1:O1").Value = "ANTIGUEDAD DE SALDOS AL " + f1.Value.Date()
            End If

            wSheet2.Cells.Range("A1:O1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet2.Cells.Range("A1:O1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet2.Cells.Range("A1:O1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet2.Cells.Range("A1:O1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet2.Cells.Range("A1:O1").Font.Bold = True

            For c As Integer = 0 To tabla.Columns.Count - 1
                wSheet2.Cells(2, c + 1).value = "'" + tabla.Columns(c).ToString
                wSheet2.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet2.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet2.Cells(2, c + 1).Font.Bold = True
            Next
            For r As Integer = 0 To tabla.Rows.Count - 1
                For c As Integer = 0 To tabla.Columns.Count - 1
                    wSheet2.Cells(r + 3, c + 1).value = tabla.Rows(r)(c)
                    wSheet2.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet2.Columns.AutoFit()

            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEmpresa.SelectedIndexChanged
        If ComboEmpresa.Text = "SAN RAFAEL" Then
            Try
                cmbSucursal.DataSource = Conexion.llenar_combo_box(Now.Date, "LLENAR_COMBO_BOX")
                cmbSucursal.ValueMember = "ID"
                cmbSucursal.DisplayMember = "SUCURSAL"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        If ComboEmpresa.Text = "DIMOSA" Then
            Try
                cmbSucursal.DataSource = Conexion.llenar_combo_box_DIMOSA(Now.Date, "LLENAR_COMBO_BOX")
                cmbSucursal.ValueMember = "ID"
                cmbSucursal.DisplayMember = "SUCURSAL"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        If ComboEmpresa.Text = "SR AGRO" Then
            Try
                cmbSucursal.DataSource = Conexion.llenar_combo_box_AGRO(Now.Date, "LLENAR_COMBO_BOX")
                cmbSucursal.ValueMember = "ID"
                cmbSucursal.DisplayMember = "SUCURSAL"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub
End Class