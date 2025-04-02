Imports Disar.data
Imports System.Object
Imports System.MarshalByRefObject
Imports System.ComponentModel.Component
Imports System.Windows.Forms.Control
Public Class Efectividad_sr_agro
    Dim dia As String
    Dim DataView As DataView

    Dim _ListaVendedor_sr_agro As New _clsVendedoresSRAGRO

    Dim Efectividad_clase_agro As New cls_efectividad_SRAGRO

    Dim miDataTable As New DataTable
    Dim Lineas As DataRow = miDataTable.NewRow()
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim totaldeVisitas, Facturados, NC, TotalV, TotalE As Integer
    Dim nombre As String
    Dim activo As Integer = 0

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            activo = 1
            Cargar()
            efectividad()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Efectividad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _FechaInicial.Value = Now.AddDays(-1)
        LlenarEncabezado()

        Me.MdiParent = _Inicio
        RadioTodos.Checked = True
    End Sub

    Sub Visita(ByVal Clave As Integer, ByVal dias As String)
        Dim dv As DataView

        dv = Efectividad_clase_agro.Visitados(Clave, dias)
        If Not IsNothing(Efectividad_clase_agro.Visitados(Clave, dias)) Then
            _GridDiaVisita.DataSource = dv
        End If
    End Sub

    Sub Num_efectivos(ByVal Clave As Integer)
        If RadioTodos.Checked = True Then
            DataView = Efectividad_clase_agro.Efectivos(_FechaInicial.Value.Date, Clave)
        Else
            DataView = Efectividad_clase_agro.EfectivosMenores30(_FechaInicial.Value.Date, Clave)
        End If
        If Not IsNothing(Efectividad_clase_agro.Efectivos(_FechaInicial.Value.Date, Clave)) Then
            DGNE.DataSource = DataView
        End If
    End Sub

    Sub NumNCDiarias(ByVal Clave As Integer)
        DataView = Efectividad_clase_agro.NotasCDiarias(_FechaInicial.Value.Date, Clave)
        If Not IsNothing(Efectividad_clase_agro.NotasCDiarias(_FechaInicial.Value.Date, Clave)) Then
            _gridNCDiarias.DataSource = DataView
        End If
    End Sub

    Sub SelecciondeDia()
        If _FechaInicial.Value.DayOfWeek = DayOfWeek.Monday Then
            dia = "6_SABADO"
        ElseIf _FechaInicial.Value.DayOfWeek = DayOfWeek.Tuesday Then
            dia = "1_LUNES"
        ElseIf _FechaInicial.Value.DayOfWeek = DayOfWeek.Wednesday Then
            dia = "2_MARTES"
        ElseIf _FechaInicial.Value.DayOfWeek = DayOfWeek.Thursday Then
            dia = "3_MIERCOLES"
        ElseIf _FechaInicial.Value.DayOfWeek = DayOfWeek.Friday Then
            dia = "4_JUEVES"
        ElseIf _FechaInicial.Value.DayOfWeek = DayOfWeek.Saturday Then
            dia = "5_VIERNES"
        ElseIf _FechaInicial.Value.DayOfWeek = DayOfWeek.Sunday Then
            dia = "6_SABADO"
        End If
    End Sub

    Sub Cargar()
        Try
            DataView = _ListaVendedor_sr_agro.Datos()
            If Not IsNothing(_ListaVendedor_sr_agro.Datos()) Then
                ListaVendedores.DataSource = DataView
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub efectividad()
        limpiar()
        Dim c As Integer
        Dim j As Integer = 0
        Try
            For c = 0 To ListaVendedores.RowCount - 1
                If ListaVendedores.Rows(j).Cells(2).Value = "DET" Then
                    DGNE.DataSource = Nothing
                    _gridNCDiarias.DataSource = Nothing
                    SelecciondeDia()
                    totaldeVisitas = 0
                    Num_efectivos(ListaVendedores.Rows(j).Cells(0).Value)
                    NumNCDiarias(ListaVendedores.Rows(j).Cells(0).Value)
                    Visita(ListaVendedores.Rows(j).Cells(0).Value, dia)
                    Lineas("Fecha") = FormatDateTime(_FechaInicial.Value.Date, DateFormat.ShortDate)
                    Lineas("Clave") = ListaVendedores.Rows(j).Cells(0).Value
                    Lineas("Vendedor") = ListaVendedores.Rows(j).Cells(1).Value
                  
                    totaldeVisitas = _GridDiaVisita.Rows(0).Cells(0).Value
                    Lineas("Clientes por Dia") = totaldeVisitas

                    NC = _gridNCDiarias.RowCount
                    Lineas("Efectivos") = DGNE.RowCount + NC
                    If _GridDiaVisita.Rows(0).Cells(0).Value = 0 Then
                        Lineas("Porcentaje") = 0 & "%"
                    Else
                        Lineas("Porcentaje") = Math.Round(DGNE.RowCount / totaldeVisitas * 100) & "%"
                    End If
                    If DGNE.RowCount + NC > 0 Then
                        If Lineas("Clientes por Dia") <= 0 Then
                        Else
                            miDataTable.Rows.Add(Lineas)
                            Lineas = miDataTable.NewRow()
                        End If
                    End If

                End If
                j = j + 1
            Next

            Me._GridEfectividad.DataSource = miDataTable
        Catch ex As Exception
        End Try
    End Sub

    Sub LlenarEncabezado()
        miDataTable.Columns.Add("Fecha")
        miDataTable.Columns.Add("Clave")
        miDataTable.Columns.Add("Vendedor")
        miDataTable.Columns.Add("Clientes por Dia")
        miDataTable.Columns.Add("Efectivos")
        miDataTable.Columns.Add("Porcentaje")
    End Sub

    Sub limpiar()
        For c = 0 To _GridEfectividad.RowCount - 1
            miDataTable.Clear()
        Next
        DGNE.DataSource = Nothing
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Efectividad"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            wSheet.Cells.Range("A1:F1").Merge()
            wSheet.Cells.Range("A1:F1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:F1").Value = "Reporte de Efectividad de " + _FechaInicial.Value.Date
            wSheet.Cells.Range("A1:F1").Style = "Reportes"


            For c As Integer = 0 To _GridEfectividad.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _GridEfectividad.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _GridEfectividad.RowCount - 1
                For c As Integer = 0 To _GridEfectividad.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _GridEfectividad.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    Private Sub EnviarACorreoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If activo = 1 Then
            CorreoAdjunto()
            Correo.DocAdjunto = "C:\Reportes\Efectividad\Reporte de Efectividad.XLSX"
            Correo._txtAsunto.Text = "Reporte de Efectividad Diaria del " + _FechaInicial.Value.Date
            Correo.Visible = True
        Else
            MsgBox("Aun no se han Generado los Datos", MsgBoxStyle.Information, "Informacion")
        End If

    End Sub

    Sub CorreoAdjunto()
        Try
            nombre = _FechaInicial.Value.Date
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Hoja"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("NewStyle")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 14
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:F1").Merge()
            wSheet.Cells.Range("A1:F1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:F1").Value = "Reporte de Efectividad Diaria del  " + _FechaInicial.Value.Date
            wSheet.Cells.Range("A1:F1").Style = "NewStyle"


            For c As Integer = 0 To _GridEfectividad.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _GridEfectividad.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "NewStyle"
            Next
            For r As Integer = 0 To _GridEfectividad.RowCount - 1
                For c As Integer = 0 To _GridEfectividad.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _GridEfectividad.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next
            wSheet.Columns.AutoFit()
            wBook.SaveAs("C:\Reportes\Efectividad\Reporte de Efectividad.XLSX")
            excel.Quit()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub
End Class