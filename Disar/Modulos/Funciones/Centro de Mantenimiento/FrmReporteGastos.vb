Imports Disar.data

Public Class FrmReporteGastos

    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub FrmReporteGastos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaCombo()
        Try
            VehiculoID.SelectedValue = FrmCentro_Mantenimiento.DataDatos.CurrentRow.Cells("ColN").Value
        Catch ex As Exception
        End Try
    End Sub

    Sub CargaCombo()
        Try
            Dim db As New ClsBitacoraEventos
            ComboFiltro.DataSource = db.ConceptosBusqueda
            ComboFiltro.DisplayMember = "CONCEPTODES"
            ComboFiltro.ValueMember = "CONCEPTOID"

            VehiculoID.DataSource = db.TodosVehiculosRep
            VehiculoID.ValueMember = "Nº"
            VehiculoID.DisplayMember = "DESCRIPCIÓN"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCargar.Click
        Try
            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó reporte costos por vehículo", "Centro de Mantenimiento", _
                                      "Fecha: " & DateTime.Now)
        Catch ex As Exception
        End Try
        LlenaDatos()
        Dim Costo As Decimal = 0
        Try
            For Each row As DataGridViewRow In DataDatos.Rows
                Costo += row.Cells("COSTO TOTAL").Value
            Next
            LCosto.Text = "L " & FormatNumber(Math.Round(Costo, 2))
            DataDatos.Columns(5).Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Sub LlenaDatos()
        Try
            DataDatos.Columns.Clear()
        Catch ex As Exception
        End Try
        Dim Col As New DataGridViewTextBoxColumn
        Col.HeaderText = "RENDIMIENTO"
        Col.Name = "RENDIMIENTO"

        Dim db As New ClsBitacoraEventos
        If ComboFiltro.SelectedValue = 0 Then
            If VehiculoID.SelectedValue = 0 Then
                DataDatos.DataSource = db.CARGATODOSCOSTOSTODOSVEHICULOS(DteDesde.Value, DteHasta.Value)
            Else
                DataDatos.DataSource = db.CARGATODOSCOSTOS(VehiculoID.SelectedValue, DteDesde.Value, DteHasta.Value)
            End If

        Else
            If VehiculoID.SelectedValue = 0 Then
                DataDatos.DataSource = db.CARGACOSTOSTODOSVEHICULOS(VehiculoID.SelectedValue, ComboFiltro.SelectedValue, DteDesde.Value, DteHasta.Value)
            Else
                DataDatos.DataSource = db.CARGACOSTOS(VehiculoID.SelectedValue, ComboFiltro.SelectedValue, DteDesde.Value, DteHasta.Value)
            End If

            DataDatos.Columns.Add(Col)
            For Each row As DataGridViewRow In DataDatos.Rows
                Try
                    Dim Anterior As Decimal = row.Cells(9).Value
                    Dim Siguiente As Decimal = DataDatos.Rows(row.Index + 1).Cells(9).Value
                    Dim total As Decimal = Math.Round((Siguiente - Anterior) / row.Cells("CANTIDAD").Value, 2)
                    row.Cells("RENDIMIENTO").Value = total.ToString & " KM / Gal"
                Catch ex As Exception
                End Try
            Next
        End If
        Try
            'DataDatos.Columns(3).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmReporteGastos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
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

            wSheet.Cells.Range("A1:K1").Merge()
            wSheet.Cells.Range("A1:K1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:K1").Value = " Reporte de Costo por Vehículo "
            wSheet.Cells.Range("A1:K1").Style = "Estilo"

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

End Class