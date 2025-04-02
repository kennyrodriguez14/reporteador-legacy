Imports Disar.data

Public Class Saldos_Detallados_Nuevo

    Dim Conexion As New cls_antiguedad_saldos

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            If ComboEmpresa.Text = "SAN RAFAEL" Then
                GridSaldos.DataSource = Conexion.Saldos_detallados(f1.Value.Date, cmbSucursal.Text)
            ElseIf ComboEmpresa.Text = "DIMOSA" Then
                GridSaldos.DataSource = Conexion.Saldos_detalladosDimosa(f1.Value.Date, cmbSucursal.Text)
            Else
                GridSaldos.DataSource = Conexion.Saldos_detalladosAGRO(f1.Value.Date, cmbSucursal.Text)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            Dim hasta As Integer = GridSaldos.ColumnCount - 1
            wSheet.Cells.Range("A1:P1").MergeCells = True

            If cmbSucursal.Text = "CARTERA INCOBRABLE" Then
                wSheet.Cells.Range("A1:P1").Value = "CARTERA INCOBRABLE " + f1.Value.Date()
            Else
                wSheet.Cells.Range("A1:P1").Value = "ANTIGUEDAD DE SALDOS AL " + f1.Value.Date()
            End If


            wSheet.Cells.Range("A1:P1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:P1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A1:P1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:P1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:P1").Font.Bold = True
            For c As Integer = 0 To GridSaldos.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = "'" + GridSaldos.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(2, c + 1).Font.Bold = True
            Next
            For r As Integer = 0 To GridSaldos.RowCount - 1
                For c As Integer = 0 To GridSaldos.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = GridSaldos.Item(c, r).Value
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

    Private Sub Saldos_Detallado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _Inicio.SANRAFAEL = 1 Then
            ComboEmpresa.Items.Add("SAN RAFAEL")
        End If
        If _Inicio.DIMOSA = 1 Then
            ComboEmpresa.Items.Add("DIMOSA")
        End If
        If _Inicio.AGRO = 1 Then
            ComboEmpresa.Items.Add("SR AGRO")
        End If
        ComboEmpresa.SelectedIndex = 0
        LlenaSucursales()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Exportar()
    End Sub

    Sub LlenaSucursales()
        If ComboEmpresa.Text = "SAN RAFAEL" Then
            Try
                cmbSucursal.DataSource = Conexion.llenar_combo_box(Now.Date, "LLENAR_COMBO_BOX")
                cmbSucursal.ValueMember = "ID"
                cmbSucursal.DisplayMember = "SUCURSAL"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf ComboEmpresa.Text = "DIMOSA" Then
            Try
                cmbSucursal.DataSource = Conexion.llenar_combo_box_DIMOSA(Now.Date, "LLENAR_COMBO_BOX")
                cmbSucursal.ValueMember = "ID"
                cmbSucursal.DisplayMember = "SUCURSAL"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Try
                cmbSucursal.DataSource = Conexion.llenar_combo_box_AGRO(Now.Date, "LLENAR_COMBO_BOX")
                cmbSucursal.ValueMember = "ID"
                cmbSucursal.DisplayMember = "SUCURSAL"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        
    End Sub

    Private Sub ComboEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEmpresa.SelectedIndexChanged
        LlenaSucursales()
    End Sub
End Class