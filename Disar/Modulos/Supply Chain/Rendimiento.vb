Imports Disar.data
Public Class Rendimiento
    Dim Conexion As New clsCombustible
    Private Sub Rendimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicio.Value = 1 & "/" & Now.Month & "/" & Now.Year
        CargaCombo()
    End Sub

    Sub CargaCombo()
        Try
            Dim db As New ClsBitacoraEventos
            ComboFiltro.DataSource = db.ConceptosBusqueda
            ComboFiltro.DisplayMember = "CONCEPTODES"
            ComboFiltro.ValueMember = "CONCEPTOID"

            ComboFiltro.SelectedValue = 60
            ComboFiltro.Enabled = False

            VehiculoID.DataSource = db.TodosVehiculosRep
            VehiculoID.ValueMember = "Nº"
            VehiculoID.DisplayMember = "DESCRIPCIÓN"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        If Fin.Value.Date < Inicio.Value.Date Then
            MessageBox.Show("La fecha inicial no puede ser mayor a la final", "Fechas Incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                'RendimientoC.DataSource = Conexion.Rentabilidad_Combustible(Inicio.Value.Date, Fin.Value.Date, VehiculoID.SelectedItem)
                'MsgBox(ComboFiltro.SelectedValue)
                LlenaDatos()
            Catch ex As Exception
                MsgBox("Error " + ex.ToString)
            End Try
        End If
    End Sub


    Sub LlenaDatos()

        Try
            RendimientoC.Columns.Clear()
        Catch ex As Exception
        End Try
        Dim Col As New DataGridViewTextBoxColumn
        Col.HeaderText = "RENDIMIENTO"
        Col.Name = "RENDIMIENTO"

        Dim db As New ClsBitacoraEventos

        If VehiculoID.SelectedValue = 0 Then
            RendimientoC.DataSource = db.CARGACOSTOSTODOSVEHICULOS(VehiculoID.SelectedValue, ComboFiltro.SelectedValue, Inicio.Value, Fin.Value)
        Else
            RendimientoC.DataSource = db.CARGACOSTOS(VehiculoID.SelectedValue, ComboFiltro.SelectedValue, Inicio.Value, Fin.Value)
        End If

        RendimientoC.Columns.Add(Col)
        For Each row As DataGridViewRow In RendimientoC.Rows
            Try
                Dim Anterior As Decimal = RendimientoC.Rows(row.Index - 1).Cells(9).Value
                row.Cells(8).Value = Anterior
                Dim Siguiente As Decimal = RendimientoC.Rows(row.Index).Cells(9).Value
                Dim total As Decimal = Math.Round((Siguiente - Anterior) / row.Cells("CANTIDAD").Value, 2)
                row.Cells("RENDIMIENTO").Value = total.ToString & " KM / GAL"
                Try
                    If row.Cells("VEHICULO").Value <> RendimientoC.Rows(row.Index - 1).Cells("VEHICULO").Value Then
                        row.Cells("RENDIMIENTO").Value = ""
                    End If
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try
        Next

        Try
            'DataDatos.Columns(3).Visible = False
        Catch ex As Exception

        End Try
    End Sub


    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Cells.Range("A1:G1").Merge()
            wSheet.Cells.Range("A1:G1").Value = "KM/G por Vehiculo del " + Inicio.Value.Date + " al " + Fin.Value.Date
            wSheet.Cells.Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A1:G1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:G1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:G1").Font.Bold = True
            For c As Integer = 0 To RendimientoC.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = RendimientoC.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            Next
            For r As Integer = 0 To RendimientoC.RowCount - 1
                For c As Integer = 0 To RendimientoC.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = RendimientoC.Item(c, r).Value
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

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub
End Class