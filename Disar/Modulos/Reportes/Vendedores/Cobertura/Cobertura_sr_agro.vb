Imports Disar.data
Public Class Cobertura_sr_agro
    Dim Cobertura As New cls_coberturas_SR_AGRO

    Dim Tabla As New DataTable
    Dim Lineas As DataRow = Tabla.NewRow()
    Dim ini, fin As Date
    Dim P23, P24, P42, P43, P45, P55, P61, P62, P63, POtros As Integer
    Dim P23G, P24G, P42G, P43G, P45G, P55G, P61G, P62G, P63G, POtrosG As Integer
    Dim Universo, UniversoGeneral As Integer

    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim nombre As String
    Dim activo As Integer = 0

    Private Sub Cobertura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicializardate()
        Me.MdiParent = _Inicio
        LlenarEncabezado()
        cargar_sucursal()
    End Sub

    Sub cargar_sucursal()
        Try
            Dim conexion As New cls_coberturas_SR_AGRO
            _cmbSucursal.DataSource = conexion.listar_almacenes()
            _cmbSucursal.DisplayMember = "DESCR"
            _cmbSucursal.ValueMember = "CVE_ALM"
        Catch ex As Exception

        End Try
    End Sub

    'Boton para generar los datos
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Iniciar_Variables()
        ini = _cmbFechaInicial.Value.Date
        fin = _cmbFechaFinal.Value.Date
        limpiar()
        Try
            activo = 1
            _gridUniverso.DataSource = Cobertura.ListaUniverso()
            If _cmbFechaFinal.Value.Date < _cmbFechaInicial.Value.Date Then
                MessageBox.Show("La Fecha Final no puede ser menor que la Fecha Inicial", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                _cmbFechaFinal.Focus()
            Else
                For i As Integer = 0 To _gridUniverso.RowCount - 1
                    Lineas("CLAVE") = _gridUniverso.Rows(i).Cells(0).Value
                    Lineas("VENDEDOR") = _gridUniverso.Rows(i).Cells(1).Value
                    Lineas("UNIVERSO") = _gridUniverso.Rows(i).Cells(2).Value

                    Universo = _gridUniverso.Rows(i).Cells(2).Value

                    _gridVentas.DataSource = Cobertura.VentasXLinea(ini, fin, "23", _gridUniverso.Rows(i).Cells(0).Value, _cmbSucursal.SelectedValue)
                    P23 = _gridVentas.RowCount
                    _gridVentas.DataSource = Cobertura.VentasXLinea(ini, fin, "24", _gridUniverso.Rows(i).Cells(0).Value, _cmbSucursal.SelectedValue)
                    P24 = _gridVentas.RowCount
                    _gridVentas.DataSource = Cobertura.VentasXLinea(ini, fin, "42", _gridUniverso.Rows(i).Cells(0).Value, _cmbSucursal.SelectedValue)
                    P42 = _gridVentas.RowCount
                    _gridVentas.DataSource = Cobertura.VentasXLinea(ini, fin, "43", _gridUniverso.Rows(i).Cells(0).Value, _cmbSucursal.SelectedValue)
                    P43 = _gridVentas.RowCount
                    _gridVentas.DataSource = Cobertura.VentasXLinea(ini, fin, "45", _gridUniverso.Rows(i).Cells(0).Value, _cmbSucursal.SelectedValue)
                    P45 = _gridVentas.RowCount
                    _gridVentas.DataSource = Cobertura.VentasXLinea(ini, fin, "55", _gridUniverso.Rows(i).Cells(0).Value, _cmbSucursal.SelectedValue)
                    P55 = _gridVentas.RowCount
                    _gridVentas.DataSource = Cobertura.VentasXLinea(ini, fin, "61", _gridUniverso.Rows(i).Cells(0).Value, _cmbSucursal.SelectedValue)
                    P61 = _gridVentas.RowCount
                    _gridVentas.DataSource = Cobertura.VentasXLinea(ini, fin, "62", _gridUniverso.Rows(i).Cells(0).Value, _cmbSucursal.SelectedValue)
                    P62 = _gridVentas.RowCount
                    _gridVentas.DataSource = Cobertura.VentasXLinea(ini, fin, "63", _gridUniverso.Rows(i).Cells(0).Value, _cmbSucursal.SelectedValue)
                    P63 = _gridVentas.RowCount

                    _gridVentas.DataSource = Cobertura.VentasXLineaOTROS(ini, fin, _gridUniverso.Rows(i).Cells(0).Value, _cmbSucursal.SelectedValue)
                    POtros = _gridVentas.RowCount


                    UniversoGeneral += Universo
                    P23G += P23
                    P24G += P24
                    P42G += P42
                    P43G += P43
                    P45G += P45
                    P55G += P55
                    P61G += P61
                    P62G += P62
                    P63G += P63
                    POtrosG += POtros

                    Lineas("ALCON CONCENTRADOS") = P23
                    Lineas("CARGILL") = P24
                    Lineas("AGRO INDUSTRIALES") = P42
                    Lineas("PROAGRO") = P43
                    Lineas("TECNO SUPPLIER") = P45
                    Lineas("DUWEST") = P55
                    Lineas("VIEXCO S. DE R.L.") = P61
                    Lineas("SEAGRO") = P62
                    Lineas("COLONO AGROPECUARIO") = P63
                    Lineas("SR AGRO") = POtros

                    Lineas("% ALCON CONCENTRADOS") = Math.Round((P23 / Universo) * 100, 2)
                    Lineas("% CARGILL") = Math.Round((P24 / Universo) * 100, 2)
                    Lineas("% AGRO INDUSTRIALES") = Math.Round((P42 / Universo) * 100, 2)
                    Lineas("% PROAGRO") = Math.Round((P43 / Universo) * 100, 2)
                    Lineas("% TECNO SUPPLIER") = Math.Round((P45 / Universo) * 100, 2)
                    Lineas("% DUWEST") = Math.Round((P55 / Universo) * 100, 2)
                    Lineas("% VIEXCO S. DE R.L.") = Math.Round((P61 / Universo) * 100, 2)
                    Lineas("% SEAGRO") = Math.Round((P62 / Universo) * 100, 2)
                    Lineas("% COLONO AGROPECUARIO") = Math.Round((P63 / Universo) * 100, 2)
                    Lineas("% SR AGRO") = Math.Round((POtros / Universo) * 100, 2)

                    Tabla.Rows.Add(Lineas)
                    Lineas = Tabla.NewRow()
                Next

                Lineas("CLAVE") = "SR AGRO"
                Lineas("VENDEDOR") = "TOTAL"
                Lineas("UNIVERSO") = UniversoGeneral

                Lineas("ALCON CONCENTRADOS") = P23G
                Lineas("CARGILL") = P24G
                Lineas("AGRO INDUSTRIALES") = P42G
                Lineas("PROAGRO") = P43G
                Lineas("TECNO SUPPLIER") = P45G
                Lineas("DUWEST") = P55G
                Lineas("VIEXCO S. DE R.L.") = P61G
                Lineas("SEAGRO") = P62G
                Lineas("COLONO AGROPECUARIO") = P63G
                Lineas("SR AGRO") = POtrosG

                Lineas("% ALCON CONCENTRADOS") = Math.Round((P23G / UniversoGeneral) * 100, 2)
                Lineas("% CARGILL") = Math.Round((P24G / UniversoGeneral) * 100, 2)
                Lineas("% AGRO INDUSTRIALES") = Math.Round((P42G / UniversoGeneral) * 100, 2)
                Lineas("% PROAGRO") = Math.Round((P43G / UniversoGeneral) * 100, 2)
                Lineas("% TECNO SUPPLIER") = Math.Round((P45G / UniversoGeneral) * 100, 2)
                Lineas("% DUWEST") = Math.Round((P55G / UniversoGeneral) * 100, 2)
                Lineas("% VIEXCO S. DE R.L.") = Math.Round((P61G / UniversoGeneral) * 100, 2)
                Lineas("% SEAGRO") = Math.Round((P62G / UniversoGeneral) * 100, 2)
                Lineas("% COLONO AGROPECUARIO") = Math.Round((P63G / UniversoGeneral) * 100, 2)
                Lineas("% SR AGRO") = Math.Round((POtrosG / UniversoGeneral) * 100, 2)

                Tabla.Rows.Add(Lineas)

                Me._GridCobertura.DataSource = Tabla

            End If
        Catch ex As Exception
            MessageBox.Show("Error al Generar " + ex.ToString, "Ha ocurrido un Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Iniciar_Variables()
        UniversoGeneral = 0
        P23G = 0
        P24G = 0
        P42G = 0
        P43G = 0
        P45G = 0
        P55G = 0
        P61G = 0
        P62G = 0
        P63G = 0
        POtrosG = 0
    End Sub

    'Subrutina para llenar las columnas de la tabla
    Sub LlenarEncabezado()
        Tabla.Columns.Add("CLAVE")
        Tabla.Columns.Add("VENDEDOR")
        Tabla.Columns.Add("UNIVERSO")
        Tabla.Columns.Add("ALCON CONCENTRADOS")
        Tabla.Columns.Add("CARGILL")
        Tabla.Columns.Add("AGRO INDUSTRIALES")
        Tabla.Columns.Add("PROAGRO")
        Tabla.Columns.Add("TECNO SUPPLIER")
        Tabla.Columns.Add("DUWEST")
        Tabla.Columns.Add("VIEXCO S. DE R.L.")
        Tabla.Columns.Add("SEAGRO")
        Tabla.Columns.Add("COLONO AGROPECUARIO")
        Tabla.Columns.Add("SR AGRO")

        Tabla.Columns.Add("% ALCON CONCENTRADOS")
        Tabla.Columns.Add("% CARGILL")
        Tabla.Columns.Add("% AGRO INDUSTRIALES")
        Tabla.Columns.Add("% PROAGRO")
        Tabla.Columns.Add("% TECNO SUPPLIER")
        Tabla.Columns.Add("% DUWEST")
        Tabla.Columns.Add("% VIEXCO S. DE R.L.")
        Tabla.Columns.Add("% SEAGRO")
        Tabla.Columns.Add("% COLONO AGROPECUARIO")
        Tabla.Columns.Add("% SR AGRO")

    End Sub

    'Subrutina para limpiar los datos del grid
    Sub limpiar()
        For c = 0 To _GridCobertura.RowCount - 1
            Tabla.Clear()
        Next
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Hoja"
            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:V1").Merge()
            wSheet.Cells.Range("A1:V1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:V1").Value = "Reporte de Coberturas del  " + _cmbFechaInicial.Value.Date + "  al  " + _cmbFechaFinal.Value.Date
            wSheet.Cells.Range("A1:V1").Style = "Reportes"

            For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _GridCobertura.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _GridCobertura.RowCount - 1
                For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _GridCobertura.Item(c, r).Value
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

    Private Sub EnviarACorreoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If activo = 1 Then
            CorreoAdjunto()
            Correo.DocAdjunto = "C:\Reportes\Coberturas\Reporte de Coberturas.XLSX"
            Correo._txtAsunto.Text = "Reporte de Coberturas de " + nombre
            Correo.Visible = True
        Else
            MsgBox("Aun no se han Generado los Datos", MsgBoxStyle.Information, "Informacion")
        End If

    End Sub

    Sub CorreoAdjunto()
        Try
            nombre = _cmbFechaInicial.Value.Date + " al " + _cmbFechaFinal.Value.Date
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Hoja"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 14
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:V1").Merge()
            wSheet.Cells.Range("A1:V1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:V1").Value = "Reporte de Coberturas del  " + _cmbFechaInicial.Value.Date + "  al  " + _cmbFechaFinal.Value.Date
            wSheet.Cells.Range("A1:V1").Style = "Reportes"

            For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _GridCobertura.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _GridCobertura.RowCount - 1
                For c As Integer = 0 To _GridCobertura.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _GridCobertura.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next
            wSheet.Columns.AutoFit()
            wBook.SaveAs("C:\Reportes\Coberturas\Reporte de Coberturas.XLSX")
            excel.Quit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub inicializardate()
        _cmbFechaInicial.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            _cmbFechaFinal.Value = Today
        Else
            _cmbFechaFinal.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub
End Class